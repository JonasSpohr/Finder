using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PetShopFinder
{
    public partial class frmPrincipal : Form
    {
        #region Variáveis

        DataTable dtbEstados = new DataTable();
        DataTable dtbCidades = new DataTable();
        DataTable dtbBairros = new DataTable();
        List<LogExecucao> logExecucao;
        List<Estados> listaEstados;
        string strConexao = "Data Source=n4jokuco18.database.windows.net;Initial Catalog=DBPet;Persist Security Info=True;User ID=petlogin;Password=!Leo2014";
        int intStatus = 1;
        int intTentativas = 0;
        int intRequisicoesEfetuadas = 0;
        int intRegistrosImportados = 0;
        bool blnFixBrowser = true;
        #endregion

        #region Rotinas Iniciais

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ListarXml();

            ListarEstados();

            //Carrega as chaves que serão utilizadas nas requisições do google places
            cboKeys.DataSource = Chaves.ListarChaves();
            cboKeys.ValueMember = "Chave";
            cboKeys.DisplayMember = "Chave";
            cboKeys.SelectedIndex = 0;

            //Carrega os estabelecimentos que serão pesquisados
            cboEstabelecimento.DataSource = Estabelecimentos.ListarEstabelecimentos();
            cboEstabelecimento.ValueMember = "IdEstabelecimento";
            cboEstabelecimento.DisplayMember = "Estabelecimento";
            cboEstabelecimento.SelectedIndex = 0;

            //Carrega os campos com a última execução do xml
            var log = LogExecucao.ListarUltimoLogExecucao();
            if (log != null)
            {
                //cboKeys.SelectedIndex = cboKeys.FindString(log.Attribute("chave").Value.ToString()); sempre inicia na primeira chave até esgotar as requisições
                cboEstabelecimento.SelectedIndex = cboEstabelecimento.FindString(log.Attribute("estabelecimento").Value.ToString());
                cboEstado.SelectedIndex = cboEstado.FindString(log.Attribute("nomeEstado").Value.ToString());
                cboCidade.SelectedIndex = cboCidade.FindString(log.Attribute("nomeCidade").Value.ToString());
                //ListarBairros();
                cboBairro.SelectedIndex = cboBairro.FindString(log.Attribute("nomeBairro").Value.ToString());
                intRequisicoesEfetuadas = int.Parse(log.Attribute("requisicoesEfetuadas").Value);
                intRegistrosImportados = int.Parse(log.Attribute("registrosImportados").Value);
            }

            //Para execução automática da importação, descomentar linha abaixo (btnImportar.PerformClick();)
            //btnImportar.PerformClick();
        }

        #endregion

        #region Eventos da Barra de Menu

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inícioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://developers.google.com/places/?hl=pt-br");
        }

        private void gerarChaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://developers.google.com/places/webservice/intro#Authentication");
        }

        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://developers.google.com/places/webservice/search#TextSearchRequests");
        }

        private void detailSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://developers.google.com/places/web-service/details?hl=pt-br");
        }

        private void sobrePetShopFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre newForm = new Sobre();
            newForm.ShowDialog();
        }

        #endregion

        #region Eventos dos Controles

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCidades();
            //ListarBairros();
        }

        private void cboCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarBairros();
        }

        private void chkLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLocation.Checked)
            {
                txtLatitude.Enabled = true;
                txtLongitude.Enabled = true;
                txtDistancia.Enabled = true;

                chkEstado.Enabled = false;
                cboEstado.Enabled = false;
                chkCidade.Enabled = false;
                cboCidade.Enabled = false;
                chkBairro.Enabled = false;
                cboBairro.Enabled = false;
            }
            else
            {
                txtLatitude.Enabled = false;
                txtLongitude.Enabled = false;
                txtDistancia.Enabled = false;

                chkEstado.Enabled = true;
                chkEstado.Checked = false;
                cboEstado.Enabled = true;
                chkCidade.Enabled = true;
                chkCidade.Checked = false;
                cboCidade.Enabled = true;
                chkBairro.Enabled = true;
                chkBairro.Checked = false;
                cboBairro.Enabled = true;
            }
        }

        private void chkEstados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstado.Checked)
            {
                cboEstado.Enabled = false;
                chkCidade.Checked = true;
                chkCidade.Enabled = false;
                cboCidade.Enabled = false;
                chkBairro.Checked = true;
                chkBairro.Enabled = false;
                cboBairro.Enabled = false;
            }
            else
            {
                cboEstado.Enabled = true;
                chkCidade.Checked = false;
                chkCidade.Enabled = true;
                cboCidade.Enabled = true;
                chkBairro.Checked = false;
                chkBairro.Enabled = true;
                cboBairro.Enabled = true;
            }
        }

        private void chkCidades_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCidade.Checked)
            {
                cboCidade.Enabled = false;
                chkBairro.Checked = true;
                chkBairro.Enabled = false;
                cboBairro.Enabled = false;
            }
            else
            {
                cboCidade.Enabled = true;
                chkBairro.Checked = false;
                chkBairro.Enabled = true;
                cboBairro.Enabled = true;
            }
        }

        private void chkBairro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBairro.Checked)
            {
                cboBairro.Enabled = false;
            }
            else
            {
                cboBairro.Enabled = true;
            }
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {
            if (blnFixBrowser)
            {
                //Chamada necessária:
                FixBrowser();
                //webBrowser1.ScriptErrorsSuppressed = true;
            }
            blnFixBrowser = false;
            //webBrowser1.Navigate("https://www.google.com.br/maps/" + MontarStringNavegacaoGoogleMaps());
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            LocalizarEstabelecimentos();
        }

        #endregion

        #region Rotinas Auxiliares

        private void ListarEstados()
        {
            //Carrega os estabelecimentos que serão pesquisados
            listaEstados = Estados.ListarEstados();
            cboEstado.DataSource = listaEstados;
            cboEstado.ValueMember = "siglaEstado";
            cboEstado.DisplayMember = "NomeEstado";
            cboEstado.SelectedIndex = 0;

            /*
            dtbEstados.Clear();
            using (SqlConnection conn = new SqlConnection(strConexao))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select EstadoId, PaisId, NomeCompleto, Sigla, Ativo FROM [dbo].[Estado] order by NomeCompleto", conn);
                SqlDataAdapter ad = new SqlDataAdapter(command);
                ad.Fill(dtbEstados);

                if (dtbEstados.Rows.Count > 0)
                {
                    cboEstado.DisplayMember = "NomeCompleto";
                    cboEstado.ValueMember = "Sigla";
                    cboEstado.DataSource = dtbEstados;
                }

                conn.Close();
            }
            */
        }

        private void ListarCidades()
        {
            if (cboEstado.SelectedValue != null)
            {
                dtbCidades.Clear();
                using (SqlConnection conn = new SqlConnection(strConexao))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select Cidade.CidadeId, Cidade.EstadoId, Cidade.Nome, Cidade.Ativo " +
                                                        "from [dbo].[Cidade] INNER JOIN " +
                                                        "     [dbo].[Estado] ON Estado.EstadoId = Cidade.EstadoId " +
                                                        "where (Estado.Sigla = '" + cboEstado.SelectedValue.ToString() + "') " +
                                                        "order by Cidade.Nome", conn);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dtbCidades);

                    if (dtbCidades.Rows.Count > 0)
                    {
                        cboCidade.DisplayMember = "Nome";
                        cboCidade.ValueMember = "CidadeId";
                        cboCidade.DataSource = dtbCidades;
                    }

                    conn.Close();
                }
            }
        }

        private void ListarBairros()
        {
            dtbBairros.Clear();
            using (SqlConnection conn = new SqlConnection(strConexao))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select distinct bai_no from [dbo].[Vw_BaseCEP] " +
                                                    "where UFE_SG = '" + cboEstado.SelectedValue + "' " +
                                                    "  and loc_no = '" + cboCidade.Text.Replace("'", "''") + "' " +
                                                    "  and bai_no <> '' " +
                                                    "order by bai_no", conn);
                SqlDataAdapter ad = new SqlDataAdapter(command);
                ad.Fill(dtbBairros);

                if (dtbBairros.Rows.Count > 0)
                {
                    cboBairro.DisplayMember = "bai_no";
                    cboBairro.ValueMember = "bai_no";
                    cboBairro.DataSource = dtbBairros;
                }

                conn.Close();
            }
        }

        private void ListarXml()
        {
            logExecucao = LogExecucao.ListarLogExecucao();
            if (logExecucao != null)
            {
                //Limpa o campo com histórico de execução
                txtLogExecucao.Text = "";
                foreach (LogExecucao log in logExecucao.Take(5))
                {
                    txtLogExecucao.Text += "Data/Hora: " + log.DataHoraExecucao.ToString() + Environment.NewLine;
                    txtLogExecucao.Text += "Chave: " + Environment.NewLine + log.Chave + Environment.NewLine;
                    txtLogExecucao.Text += "Estabelecimento: " + log.Estabelecimento + Environment.NewLine;
                    txtLogExecucao.Text += "Estado: " + log.NomeEstado + Environment.NewLine;
                    txtLogExecucao.Text += "Cidade: " + log.NomeCidade + Environment.NewLine;
                    txtLogExecucao.Text += "Bairro: " + log.NomeBairro + Environment.NewLine;
                    txtLogExecucao.Text += "Requisições Efetuadas: " + log.RequisicoesEfetuadas + Environment.NewLine;
                    txtLogExecucao.Text += "Registros Importados: " + log.RegistrosImportados + Environment.NewLine;
                    txtLogExecucao.Text += "---------------------------------------------------------------------------" + Environment.NewLine;
                }
            }
        }

        private void IncluirLog(string _key, string _estabelecimento, string _estado, string _cidade, string _bairro)
        {
            //Registra a execução no xml
            LogExecucao log = new LogExecucao()
            {
                DataHoraExecucao = DateTime.Now.ToString(),
                Chave = _key,
                Estabelecimento = _estabelecimento,
                NomeEstado = _estado,
                NomeCidade = _cidade,
                NomeBairro = _bairro,
                RegistrosImportados = intRegistrosImportados,
                RequisicoesEfetuadas = intRequisicoesEfetuadas
            };

            txtLogExecucao.Text = txtLogExecucao.Text.Insert(0, LogExecucao.IncluirLogExecucao(log) + Environment.NewLine + Environment.NewLine);
            //txtLogExecucao.AppendText();
        }

        /// <summary>
        /// Busca os estabelecimentos no google maps através do link abaixo:
        /// https://maps.googleapis.com/maps/api/place/textsearch/json?query=petshop+rio+grande+sul&location=51.503186,-0.126446&radius=5000&types=food|cafe&keyword=vegetarian&key=(sua_chave)
        /// e os detalhes do estabelecimento através do link abaixo:
        /// https://maps.googleapis.com/maps/api/place/details/json?placeid=ChIJKyotDWRhHJUR9iMhvrcP2Yg&key=(sua_chave)
        /// </summary>
        /// <param name="key">Chave necessária para consultar os estabelecimentos no google places</param>
        /// <returns></returns>
        private void LocalizarEstabelecimentos()
        {
            try
            {
                string key = cboKeys.Text;
                int estado = cboEstado.SelectedIndex;
                int cidade = cboCidade.SelectedIndex;
                int bairro = cboBairro.SelectedIndex;
                int estabelecimento = cboEstabelecimento.SelectedIndex;

                if (!string.IsNullOrWhiteSpace(txtLogRequisicao.Text))
                    if (MessageBox.Show("Voce gostaria de limpar o log de requisicões?", "Confirmação", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        txtLogRequisicao.Text = "";
                    }

                //Verifica se a checkbox "Todos os Estados" está marcada para iniciar o loop por Estados, Cidades e Bairros
                if (chkEstado.Checked)
                {
                    for (int e = estado; e < cboEstado.Items.Count; e++)
                    {
                        cboEstado.SelectedIndex = e;
                        ListarCidades();
                        for (int c = cidade; c < cboCidade.Items.Count; c++)
                        {
                            cboCidade.SelectedIndex = c;
                            ListarBairros();
                            for (int b = bairro; b < cboBairro.Items.Count; b++)
                            {
                                cboBairro.SelectedIndex = b;
                                for (int es = estabelecimento; es < cboEstabelecimento.Items.Count; es++) //estabelecimentos que serão pesquisados
                                {
                                    cboEstabelecimento.SelectedIndex = es;

                                    IncluirLog(key, cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.GetItemText(cboEstado.Items[e]), cboCidade.GetItemText(cboCidade.Items[c]), cboBairro.GetItemText(cboBairro.Items[b]));
                                    ListarXml();

                                    //Requisição TextSearch
                                    GetTextSearch(cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.GetItemText(cboEstado.Items[e]), cboCidade.GetItemText(cboCidade.Items[c]), cboBairro.GetItemText(cboBairro.Items[b]), ref key);
                                }
                                estabelecimento = 0;
                            }
                            bairro = 0;
                        }
                        cidade = 0;
                    }
                }
                else
                {
                    //Verifica se a checkbox "Todas as Cidades" está marcada para iniciar o loop por Cidades e Bairros
                    if (chkCidade.Checked)
                    {
                        for (int c = cidade; c < cboCidade.Items.Count; c++)
                        {
                            cboCidade.SelectedIndex = c;
                            for (int b = bairro; b < cboBairro.Items.Count; b++)
                            {
                                cboBairro.SelectedIndex = b;
                                for (int es = estabelecimento; es < cboEstabelecimento.Items.Count; es++) //estabelecimentos que serão pesquisados
                                {
                                    cboEstabelecimento.SelectedIndex = es;

                                    IncluirLog(key, cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.Text, cboCidade.GetItemText(cboCidade.Items[c]), cboBairro.GetItemText(cboBairro.Items[b]));
                                    //ListarXml();

                                    //Requisição TextSearch
                                    GetTextSearch(cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.Text, cboCidade.GetItemText(cboCidade.Items[c]), cboBairro.GetItemText(cboBairro.Items[b]), ref key);
                                }
                            }
                        }
                    }
                    else
                    {
                        //Verifica se a checkbox "Todos os Bairros" está marcada para iniciar o loop por Bairros
                        if (chkBairro.Checked)
                        {
                            for (int b = bairro; b < cboBairro.Items.Count; b++)
                            {
                                cboBairro.SelectedIndex = b;
                                for (int es = estabelecimento; es < cboEstabelecimento.Items.Count; es++) //estabelecimentos que serão pesquisados
                                {
                                    cboEstabelecimento.SelectedIndex = es;

                                    IncluirLog(key, cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.Text, cboCidade.Text, cboBairro.GetItemText(cboBairro.Items[b]));
                                    //ListarXml();

                                    //Requisição TextSearch
                                    GetTextSearch(cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.Text, cboCidade.Text, cboBairro.GetItemText(cboBairro.Items[b]), ref key);
                                }
                            }
                        }
                        else //Busca específica por Estado, Cidade e Bairro
                        {
                            for (int es = estabelecimento; es < cboEstabelecimento.Items.Count; es++) //estabelecimentos que serão pesquisados
                            {
                                cboEstabelecimento.SelectedIndex = es;

                                IncluirLog(key, cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.Text, cboCidade.Text, cboBairro.Text);
                                //ListarXml();

                                //Requisição TextSearch
                                GetTextSearch(cboEstabelecimento.GetItemText(cboEstabelecimento.Items[es]), cboEstado.Text, cboCidade.Text, cboBairro.Text, ref key);
                            }
                        }
                    }
                }
                MessageBox.Show("Estabelecimentos Importados com sucesso! Favor verificar os arquivos de log para mais detalhes sobre a execução.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void GetTextSearch(string _estabelecimento, string _estado, string _cidade, string _bairro, ref string key)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder erros = new StringBuilder();
            StringBuilder statusReq = new StringBuilder();
            string runSQL = "", cep = "", logradouro = "", numero = "", bairro = "", complemento = "", endereco = "", url = "", query = "";


            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            SEARCHPLACE:
            if (!url.Contains("pagetoken"))
            {
                //Monta a query para a requisição no google places
                query = MontarStringNavegacaoGooglePlaces(_estabelecimento, _estado, _cidade, _bairro);
                //Requisição TextSearch
                url = string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?{0}&types=pet_store|veterinary_care|store|hospital|establishment&key={1}", query, key);

                txtLogRequisicao.AppendText(Environment.NewLine);
                txtLogRequisicao.AppendText("### nova requisição: TEXTSEARCH");
                txtLogRequisicao.AppendText(Environment.NewLine);
                txtLogRequisicao.AppendText(url);
                txtLogRequisicao.AppendText(Environment.NewLine);
                txtLogRequisicao.AppendText(Environment.NewLine);
            }

            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            intRequisicoesEfetuadas += 1;

            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                string responseString = reader.ReadToEnd();
                TextSearchAPI.RootObject responseData = parser.Deserialize<TextSearchAPI.RootObject>(responseString);
                if (responseData != null)
                {
                    //--------------------------------------------------------------------------------
                    intStatus = VerificarStatusRequisicao("S", responseData.status, url, ref statusReq);
                    if (intStatus == -1) { goto ATUALIZALOG; } //Erro

                    if (intStatus == 2 && intTentativas < 3) //Refazer requisição
                    {
                        intTentativas += 1;
                        goto SEARCHPLACE;
                    }
                    else if (intStatus == 2 && intTentativas >= 3)
                    {
                        intTentativas = 0;
                        goto ATUALIZALOG;
                    }

                    if (intStatus == 3) //Trocar chave de requisição
                    {
                        int intIndex = cboKeys.SelectedIndex;
                        if ((cboKeys.Items.Count - 1) > intIndex)
                        {
                            cboKeys.SelectedIndex = intIndex + 1;
                            key = cboKeys.Text;
                            intStatus = 1;
                            goto SEARCHPLACE;
                        }
                        else { goto ATUALIZALOG; }

                    }
                    //--------------------------------------------------------------------------------

                    foreach (var item in responseData.results)
                    {
                        DETAILSPLACE:
                        //Requisição Detail
                        url = string.Format("https://maps.googleapis.com/maps/api/place/details/json?placeid={0}&key={1}&language=pt-BR", item.place_id, key);

                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText("### nova requisição: DETAIL");
                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText(url);
                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText("### Nomes Encontrados:");
                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText(Environment.NewLine);

                        request = System.Net.WebRequest.Create(url);
                        response = request.GetResponse();
                        intRequisicoesEfetuadas += 1;

                        using (var readerDetail = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            System.Web.Script.Serialization.JavaScriptSerializer parserDetail = new System.Web.Script.Serialization.JavaScriptSerializer();
                            string responseStringDetail = readerDetail.ReadToEnd();
                            DetailsAPI.RootObject responseDataDetail = parser.Deserialize<DetailsAPI.RootObject>(responseStringDetail);

                            if (responseDataDetail != null)
                            {
                                //--------------------------------------------------------------------------------
                                intStatus = VerificarStatusRequisicao("D", responseDataDetail.status, url, ref statusReq);
                                if (intStatus == -1) { goto ATUALIZALOG; } //Erro

                                if (intStatus == 2 && intTentativas < 3) //Refazer requisição
                                {
                                    intTentativas += 1;
                                    goto DETAILSPLACE;
                                }
                                else if (intStatus == 2 && intTentativas >= 3)
                                {
                                    intTentativas = 0;
                                    goto ATUALIZALOG;
                                }

                                if (intStatus == 3) //Trocar chave de requisição
                                {
                                    int intIndex = cboKeys.SelectedIndex;
                                    if ((cboKeys.Items.Count - 1) > intIndex)
                                    {
                                        cboKeys.SelectedIndex = intIndex + 1;
                                        key = cboKeys.Text;
                                        intStatus = 1;
                                        goto DETAILSPLACE;
                                    }
                                    else { goto ATUALIZALOG; }
                                }
                                //--------------------------------------------------------------------------------                                                

                                logradouro = "";
                                try { logradouro = responseDataDetail.result.address_components.Where(w => w.types[0].Equals("route")).Single().long_name; } catch { }

                                cep = "";
                                try { cep = responseDataDetail.result.address_components.Where(w => w.types[0].Equals("postal_code")).Single().long_name; } catch { }

                                numero = "";
                                try { numero = responseDataDetail.result.address_components.Where(w => w.types[0].Equals("street_number")).Single().long_name; } catch { }

                                complemento = "";
                                try { complemento = responseDataDetail.result.address_components.Where(w => w.types[0].Equals("subpremise")).Single().long_name; } catch { }

                                bairro = "";
                                try { bairro = responseDataDetail.result.address_components.Where(w => w.types[0].Equals("sublocality_level_1")).Single().long_name; } catch { }

                                if (logradouro == "")
                                {
                                    endereco = responseDataDetail.result.vicinity;
                                    string[] elemento = endereco.Split(',');
                                    if (elemento.Length > 0) { logradouro = elemento[0]; }
                                    if (elemento.Length > 1) { numero = elemento[1]; }
                                }

                                if (!string.IsNullOrWhiteSpace(cep) && string.IsNullOrWhiteSpace(bairro))
                                {
                                    bairro = GetBairro(cep);
                                }

                                txtLogRequisicao.AppendText(responseDataDetail.result.name);
                                txtLogRequisicao.AppendText(Environment.NewLine);

                                int active = 1;
                                if (!IsValidNomeFantasia(responseDataDetail.result.name))
                                    active = 0;

                                bairro = string.IsNullOrWhiteSpace(bairro) ? cboBairro.Text.Replace("'", "''") : bairro.Replace("'", "''");

                                runSQL = @"INSERT INTO [dbo].[Estabelecimento] 
                                           ([NomeFantasia],[PaisId],[EstadoId],[CidadeId],[CEP],[Logradouro],[Numero],[Complemento],[Ativo],
                                            [Telefone1],[Site],[Bairro],[Longitude],[Latitude],[InicioSegunda],[InicioTerca],[InicioQuarta],[InicioQuinta],[InicioSexta],
                                            [InicioSabado],[InicioDomingo],[FimSegunda],[FimTerca],[FimQuarta],[FimQuinta],[FimSexta],[FimSabado],[FimDomingo])
                                           VALUES (";
                                runSQL +=
                  /* NomeFantasia          */ "'" + responseDataDetail.result.name.Replace("'", "''") + "'," +
                  /* PaisId                */ "1," +
                  /* EstadoId              */ listaEstados.Where(w => w.SiglaEstado.Equals(cboEstado.SelectedValue.ToString())).Single().IdEstado + "," + //BuscarIdEstado(cboEstado.SelectedValue.ToString()) + "," +
                                                                                                                                                          /* CidadeId              */ cboCidade.SelectedValue.ToString() + "," +
                  /* CEP                   */ "'" + cep + "'," +
                  /* Logradouro            */ "'" + logradouro.Replace("'", "''") + "'," +
                  /* Numero                */ "'" + numero + "'," +
                  /* Complemento           */ "'" + complemento.Replace("'", "''") + "'," +
                  /* Ativo                 */  active + "," +
                  /* Telefone1             */ "'" + responseDataDetail.result.formatted_phone_number + "'," +
                  /* Site                  */ "'" + responseDataDetail.result.website + "'," +
                  /* Bairro                */ "'" + bairro + "'," +
                  /* Longitude             */ responseDataDetail.result.geometry.location.lng.ToString().Replace(",", ".") + "," +
                  /* Latitude              */ responseDataDetail.result.geometry.location.lat.ToString().Replace(",", ".") + "," +
                  /* InicioSegunda         */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "segunda-feira:", 0, "M") + "'," +
                  /* InicioTerca           */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "terça-feira:", 1, "M") + "'," +
                  /* InicioQuarta          */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "quarta-feira:", 2, "M") + "'," +
                  /* InicioQuinta          */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "quinta-feira:", 3, "M") + "'," +
                  /* InicioSexta           */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "sexta-feira:", 4, "M") + "'," +
                  /* InicioSabado          */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "sábado:", 5, "M") + "'," +
                  /* InicioDomingo         */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "domingo:", 6, "M") + "'," +
                  /* FimSegunda            */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "segunda-feira:", 0, "T") + "'," +
                  /* FimTerca              */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "terça-feira:", 1, "T") + "'," +
                  /* FimQuarta             */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "quarta-feira:", 2, "T") + "'," +
                  /* FimQuinta             */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "quinta-feira:", 3, "T") + "'," +
                  /* FimSexta              */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "sexta-feira:", 4, "T") + "'," +
                  /* FimSabado             */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "sábado:", 5, "T") + "'," +
                  /* FimDomingo            */ "'" + VerificarHorarioFuncionamento(responseDataDetail, "domingo:", 6, "T") + "')";

                                try
                                {
                                    if (RunSQL(responseDataDetail.result.name.Replace("'", "''"), cep, cboEstabelecimento.SelectedValue.ToString(),
                                        responseDataDetail.result.geometry.location.lat.ToString().Replace(",", "."),
                                        responseDataDetail.result.geometry.location.lng.ToString().Replace(",", "."), ref runSQL))
                                    {
                                        sql.AppendLine(runSQL);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    erros.AppendLine("----------------------------------------------------------------------------------------------------");
                                    erros.AppendLine("Erro msg: " + ex.Message);
                                    erros.AppendLine("Details: " + url);
                                    erros.AppendLine("Erro SQL: " + runSQL);
                                }
                            }
                        }
                    }

                    ATUALIZALOG:
                    if (sql.Length > 0)
                        CriarArquivoTxt(sql.ToString(), _estado, _cidade, _bairro, cboEstabelecimento.Text);

                    if (erros.Length > 0)
                        CriarArquivoErroTxt(erros.ToString(), _estado, _cidade, _bairro, cboEstabelecimento.Text);

                    if (statusReq.Length > 0)
                        CriarArquivoStatusRequisicaoTxt(statusReq.ToString(), _estado, _cidade, _bairro, cboEstabelecimento.Text);

                    sql.Clear();
                    erros.Clear();
                    statusReq.Clear();
                    runSQL = ""; cep = ""; logradouro = ""; numero = ""; bairro = ""; complemento = "";

                    if (intStatus == 3)
                    {
                        System.Environment.Exit(-1);
                    }

                    //Verifica se existe outra página de registros
                    if (!string.IsNullOrWhiteSpace(responseData.next_page_token))
                    {
                        //Requisição TextSearch
                        url = string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?pagetoken={0}&key={1}", responseData.next_page_token, key);

                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText("### nova requisição (PAGETOKEN): TEXTSEARCH");
                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText(url);
                        txtLogRequisicao.AppendText(Environment.NewLine);
                        txtLogRequisicao.AppendText(Environment.NewLine);

                        goto SEARCHPLACE;
                    }
                    else { url = ""; }

                    Application.DoEvents();
                }
            }
        }

        private string VerificarHorarioFuncionamento(DetailsAPI.RootObject objResult, string dia, int index, string strTurno)
        {
            string strRetorno = "";

            try
            {
                //Observação: se um local estiver sempre aberto, a seção close estará ausente da resposta. 
                //Os clientes podem confiar que sempre aberto será representado como um período open contendo day com valor 0 e time com valor 0000, e sem close.
                string diaSemana = objResult.result.opening_hours.weekday_text[index];
                diaSemana = diaSemana.Replace(dia, "");

                if (strTurno == "M")
                {
                    if (diaSemana.LastIndexOf("24 horas") != -1)
                        strRetorno = "00:00";
                    else
                        strRetorno = diaSemana.LastIndexOf(',') != -1 ? diaSemana.Split(',')[0].Split('–')[0].Trim() : diaSemana.Split('–')[0].Trim();
                }
                else //strTurno =="T"
                {
                    if (diaSemana.LastIndexOf("24 horas") != -1)
                        strRetorno = "23:59";
                    else
                        strRetorno = diaSemana.LastIndexOf(',') != -1 ? diaSemana.Split(',')[1].Split('–')[1].Trim() : diaSemana.Split('–')[1].Trim();
                }

                if (strRetorno == "Fechado") { strRetorno = ""; }
            }
            catch
            {
                strRetorno = "";
            }
            return strRetorno;
        }

        private bool IsValidNomeFantasia(string nomeFantasia)
        {

            if (nomeFantasia.ToUpper().LastIndexOf("SUPER") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("ADVOGA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("POUSADA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("FUNDAÇÃO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("RESORT") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("RESORT") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("LOCAÇÃO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("LOCAÇÃO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("ESCOLA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("ZOOLÓGICO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("ZOOLÓGICO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("CENTRO ESPÍRITA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("SHOPPING") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("CENTRO OFTALMOLOGISTA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("UNIVERSIDADE") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("JORNAL") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("CONSELHO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("PREFEITURA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("PREFEITURA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("CLUBE") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("CHAVEIRO") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("ACADEMIA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("MÓVEIS") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("PARÓQUIA") != -1)
                return false;

            if (nomeFantasia.ToUpper().LastIndexOf("IGREJA") != -1)
                return false;

            return true;
        }

        private int BuscarIdEstado(string strSiglaEstado)
        {
            int intIdEstado = -1;

            using (SqlConnection conn = new SqlConnection(strConexao))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select EstadoId FROM [dbo].[Estado] where Sigla = '" + strSiglaEstado + "'", conn);
                intIdEstado = (int)command.ExecuteScalar();

                conn.Close();
            }
            return intIdEstado;
        }

        /// <summary>
        /// Verifica o status de retorno da requisição
        /// </summary>
        /// <param name="tipoRequisicao">S=Place Search; D=Place Details</param>
        /// <param name="status">código de status retornado na requisição</param>
        /// <param name="strRequisicao">string com a requisição</param>
        /// <returns>1=OK; 2=Refazer requisição; 3=Trocar chave; -1=Erro</returns>
        private int VerificarStatusRequisicao(string tipoRequisicao, string status, string strRequisicao, ref StringBuilder statusRequisicao)
        {
            bool blnVerificacao = false;
            int intRetorno = -1;
            string strErro = "";
            try
            {
                if (tipoRequisicao == "S")
                {
                    /*
                      Códigos de status Place Search:
                      O campo status dentro do objeto de resposta da pesquisa pode conter os seguintes valores:
                        [OK]               Indica que nenhum erro ocorreu; o local foi detectado com sucesso e pelo menos um resultado foi retornado.
                        [ZERO_RESULTS]     Indica que a pesquisa foi bem sucedida, mas não retornou resultados.
                        [OVER_QUERY_LIMIT] Indica que você ultrapassou a cota da chave utilizada.
                        [REQUEST_DENIED]   Indica que a solicitação foi negada, geralmente por causa da falta de um parâmetro key válido.
                        [INVALID_REQUEST]  Geralmente indica que um parâmetro obrigatório da consulta(location ou radius) está ausente.
                    */
                    switch (status)
                    {
                        case "ZERO_RESULTS":
                            Console.WriteLine("A requisição não retornou resultados!");
                            strErro = "A requisição não retornou resultados!";
                            intRetorno = -1;
                            break;
                        case "OVER_QUERY_LIMIT":
                            Console.WriteLine("Limite de requisições atingido para a chave: " + cboKeys.Text);
                            strErro = "Limite de requisições atingido para a chave: " + cboKeys.Text;
                            intRetorno = 3;
                            break;
                        case "REQUEST_DENIED":
                            Console.WriteLine("A requisição foi negada! Verifique os parâmetros da solicitação.");
                            strErro = "A requisição foi negada! Verifique os parâmetros da solicitação.";
                            intRetorno = -1;
                            break;
                        case "INVALID_REQUEST":
                            Console.WriteLine("A requisição é inválida! Verifique os parâmetros obrigatórios da solicitação!");
                            strErro = "A requisição é inválida! Verifique os parâmetros obrigatórios da solicitação!";
                            intRetorno = -1;
                            break;
                        default:
                            Console.WriteLine("A requisição foi efetuada com sucesso!");
                            blnVerificacao = true;
                            intRetorno = 1;
                            break;
                    }
                }
                else //tipoRequisicao =="D"
                {
                    /*
                      Códigos de status Place Details:
                      O campo status dentro do objeto de resposta da pesquisa pode conter os seguintes valores:
                        [OK]               Indica que nenhum erro ocorreu; o local foi detectado com sucesso e pelo menos um resultado foi retornado.
                        [UNKNOWN_ERROR]    Indica um erro no lado do servidor. Pode-se obter êxito com uma nova tentativa.
                        [ZERO_RESULTS]     Indica que a referência era válida, mas não se refere mais a um resultado válido. 
                                           Isso poderá ocorrer se um estabelecimento não estiver mais em funcionamento.
                        [OVER_QUERY_LIMIT] Indica que você ultrapassou a cota.
                        [REQUEST_DENIED]   Indica que a solicitação foi negada, geralmente por causa da falta de um parâmetro key válido.
                        [INVALID_REQUEST]  Geralmente indica que a consulta (reference) está ausente.
                        [NOT_FOUND]        Indica que o local referenciado não foi encontrado no banco de dados de locais.
                    */
                    switch (status)
                    {
                        case "UNKNOWN_ERROR":
                            Console.WriteLine("Ocorreu um erro desconhecido no lado do servidor!");
                            strErro = "Ocorreu um erro desconhecido no lado do servidor!";
                            intRetorno = 2;
                            break;
                        case "ZERO_RESULTS":
                            Console.WriteLine("A referência era válida mas não se refere mais a um resultado válido!");
                            strErro = "A referência era válida mas não se refere mais a um resultado válido!";
                            intRetorno = -1;
                            break;
                        case "OVER_QUERY_LIMIT":
                            Console.WriteLine("Limite de requisições atingido para a chave: " + cboKeys.Text);
                            strErro = "Limite de requisições atingido para a chave: " + cboKeys.Text;
                            intRetorno = 3;
                            break;
                        case "REQUEST_DENIED":
                            Console.WriteLine("A requisição foi negada! Verifique os parâmetros da solicitação.");
                            strErro = "A requisição foi negada! Verifique os parâmetros da solicitação.";
                            intRetorno = -1;
                            break;
                        case "INVALID_REQUEST":
                            Console.WriteLine("A requisição é inválida! Verifique os parâmetros obrigatórios da solicitação!");
                            strErro = "A requisição é inválida! Verifique os parâmetros obrigatórios da solicitação!";
                            intRetorno = -1;
                            break;
                        case "NOT_FOUND":
                            Console.WriteLine("A requisição não encontrou o local no banco de dados!");
                            strErro = "A requisição não encontrou o local no banco de dados!";
                            intRetorno = -1;
                            break;
                        default:
                            Console.WriteLine("A requisição foi efetuada com sucesso!");
                            blnVerificacao = true;
                            intRetorno = 1;
                            break;
                    }
                }

                if (!blnVerificacao)
                {
                    statusRequisicao.AppendLine("----------------------------------------------------------------------------------------------------");
                    statusRequisicao.AppendLine("Erro msg: " + strErro);
                    if (tipoRequisicao == "S") { statusRequisicao.AppendLine("Tipo de Requisição: Place Search"); };
                    if (tipoRequisicao == "D") { statusRequisicao.AppendLine("Tipo de Requisição: Place Details"); };
                    statusRequisicao.AppendLine("details: " + strRequisicao);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return intRetorno;
        }

        private void CriarArquivoTxt(string dados, string estado, string cidade, string bairro, string estabelecimento)
        {
            try
            {
                string diretorio = string.Format("{0:yyyyMMdd}", DateTime.Now);

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                using (FileStream fs = File.Create(diretorio + "\\" + string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now) + "_Insert_" + estado + "_" + cidade + "_" + bairro.Replace("/", "_") + "_" + estabelecimento.Replace(" ", "") + ".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(dados);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CriarArquivoErroTxt(string dados, string estado, string cidade, string bairro, string estabelecimento)
        {
            try
            {
                string diretorio = string.Format("{0:yyyyMMdd}", DateTime.Now);

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                using (FileStream fs = File.Create(diretorio + "\\" + string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now) + "_Erro_Insert_" + estado + "_" + cidade + "_" + bairro.Replace("/", "_") + "_" + estabelecimento.Replace(" ", "") + ".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(dados);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CriarArquivoStatusRequisicaoTxt(string dados, string estado, string cidade, string bairro, string estabelecimento)
        {
            try
            {
                string diretorio = string.Format("{0:yyyyMMdd}", DateTime.Now);

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                using (FileStream fs = File.Create(diretorio + "\\" + string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now) + "_StatusRequisicao_" + estado + "_" + cidade + "_" + bairro.Replace("/", "_") + "_" + estabelecimento.Replace(" ", "") + ".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(dados);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string MontarStringNavegacaoGoogleMaps()
        {
            string urlNavigate = "";

            if (cboEstabelecimento.Text != "") { urlNavigate = "search/" + cboEstabelecimento.Text; }

            if (cboEstado.Text != "")
            {
                if (urlNavigate != "") { urlNavigate += "+"; }
                urlNavigate += cboEstado.Text;
            }

            if (cboCidade.Text != "")
            {
                if (urlNavigate != "") { urlNavigate += "+"; }
                urlNavigate += cboCidade.Text;
            }

            if (cboBairro.Text != "")
            {
                if (urlNavigate != "") { urlNavigate += "+"; }
                urlNavigate += cboBairro.Text;
            }

            if (txtLatitude.Text != "")
            {
                if (urlNavigate != "") { urlNavigate += "/@"; }
                urlNavigate += txtLatitude.Text;
            }

            if (txtLongitude.Text != "")
            {
                if (txtLatitude.Text != "") { urlNavigate += ","; }
                urlNavigate += txtLongitude.Text;
            }

            return urlNavigate;
        }

        private string MontarStringNavegacaoGooglePlaces(string estabelecimento, string estado, string cidade, string bairro)
        {
            string query = "";

            query = "query=" + estabelecimento;

            if (!chkLocation.Checked)
            {
                if (estado != "")
                {
                    if (query != "") { query += "+"; }
                    query += estado;
                }

                if (cidade != "")
                {
                    if (query != "") { query += "+"; }
                    query += cidade;
                }

                if (bairro != "")
                {
                    if (query != "") { query += "+"; }
                    query += bairro;
                }
            }
            else
            {
                if (txtLatitude.Text != "" && txtLongitude.Text != "" && txtDistancia.Text != "")
                {
                    if (query != "") { query += "location="; }
                    query += txtLatitude.Text + "," + txtLongitude.Text;
                    query += "&radius=" + txtDistancia.Text;
                }
            }

            return query;
        }

        private string GetBairro(string cep)
        {
            using (SqlConnection conn = new SqlConnection(strConexao))
            {

                conn.Open();

                //Verifica se o estabelecimento já existe no banco de dados
                SqlCommand command = new SqlCommand("select * from [dbo].[Vw_BaseCEP] where cep like '" + cep.Replace("-", "").Trim() + "'", conn);
                SqlDataAdapter adEstabelecimento = new SqlDataAdapter(command);
                DataTable dtbEstabelecimentos = new DataTable();
                adEstabelecimento.Fill(dtbEstabelecimentos);

                if (dtbEstabelecimentos.Rows.Count > 0)
                    return dtbEstabelecimentos.Rows[0]["bai_no"].ToString();

                return "";
            }
        }

        private bool RunSQL(string key, string cep, string idTipoEstabelecimento, string lat, string lng, ref string sql)
        {
            bool executed = true;

            using (SqlConnection conn = new SqlConnection(strConexao))
            {

                conn.Open();

                //Verifica se o estabelecimento já existe no banco de dados
                SqlCommand command = new SqlCommand("select * from Estabelecimento where nomefantasia = '" + key.Replace("'", "''") + "' and latitude = " + lat + " and longitude = " + lng, conn);
                SqlDataAdapter adEstabelecimento = new SqlDataAdapter(command);
                DataTable dtbEstabelecimentos = new DataTable();
                adEstabelecimento.Fill(dtbEstabelecimentos);

                if (dtbEstabelecimentos.Rows.Count > 0)
                {
                    //Se o estabelecimento já existe verifica se já existe a vinculação com o tipo de estabelecimento
                    command = new SqlCommand(@"select EstabelecimentoTipoEstabelecimentoId, EstabelecimentoId, TipoEstabelecimentoId 
                                               from EstabelecimentoTipoEstabelecimento 
                                               where EstabelecimentoId = " + dtbEstabelecimentos.Rows[0].ItemArray[0] + " and TipoEstabelecimentoId = " + idTipoEstabelecimento, conn);
                    SqlDataAdapter adTipoEstabelecimento = new SqlDataAdapter(command);
                    DataTable dtbTiposEstabelecimentos = new DataTable();
                    adTipoEstabelecimento.Fill(dtbTiposEstabelecimentos);

                    if (dtbTiposEstabelecimentos.Rows.Count > 0)
                    {
                        //Se já existir a vinculação, então não é executado nenhum insert no banco de dados
                        return false;
                    }
                    else
                    {
                        //Insere a vinculação do estabelecimento com o tipo de estabelecimento
                        sql = "insert into EstabelecimentoTipoEstabelecimento (EstabelecimentoId, TipoEstabelecimentoId) values (";
                        sql += dtbEstabelecimentos.Rows[0].ItemArray[0] + "," + idTipoEstabelecimento + ")";
                        command = new SqlCommand(sql, conn);
                        command.ExecuteNonQuery();

                        sql += System.Environment.NewLine;
                    }
                }
                else
                {
                    //Insere novo estabelecimento no banco de dados
                    Console.WriteLine("Novo estabelecimento: " + key + " / Cep: " + cep);
                    command = new SqlCommand(sql, conn);
                    command.ExecuteNonQuery();

                    sql += System.Environment.NewLine;
                    intRegistrosImportados += 1;
                    //--------------------------------------------------------------------

                    //Busca o Id do estabelecimento inserido
                    command = new SqlCommand("select max(EstabelecimentoId) as EstabelecimentoId from estabelecimento", conn);
                    int intIdEstabelecimento = (int)command.ExecuteScalar();
                    //--------------------------------------------------------------------

                    //Após inserir o estabelecimento, insere a vinculação com o tipo do estabelecimento
                    command = new SqlCommand(@"insert into EstabelecimentoTipoEstabelecimento (EstabelecimentoId, TipoEstabelecimentoId) 
                                               values (" + intIdEstabelecimento + "," + idTipoEstabelecimento + ")", conn);
                    command.ExecuteNonQuery();
                    //--------------------------------------------------------------------

                    sql += System.Environment.NewLine;
                    sql += "insert into EstabelecimentoTipoEstabelecimento (EstabelecimentoId, TipoEstabelecimentoId)";
                    sql += "values(" + intIdEstabelecimento + ", " + idTipoEstabelecimento + ")";
                    sql += System.Environment.NewLine;
                }
            }

            return executed;
        }

        /// <summary>
        /// Este método serve para corrigir problemas de script relacionados ao WebBrowser, e DEVE ser chamado na inicialização do form!
        /// </summary>
        private void FixBrowser()
        {
            try
            {
                Microsoft.Win32.RegistryKey regDM = null;
                bool is64 = Environment.Is64BitOperatingSystem;
                string KeyPath = "";
                if (is64)
                {
                    KeyPath = "SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                }
                else
                {
                    KeyPath = "SOFTWARE\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                }

                regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, false);
                if (regDM == null)
                {
                    regDM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath);
                }

                Microsoft.Win32.RegistryKey Sleutel = null;
                if ((regDM != null))
                {
                    string location = System.Environment.GetCommandLineArgs()[0];
                    string appName = System.IO.Path.GetFileName(location);
                    if (regDM.GetValue(appName) == null)
                    {
                        //Sleutel onbekend
                        regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, true);
                        Sleutel = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

                        //What OS are we using
                        Version OsVersion = System.Environment.OSVersion.Version;

                        if (OsVersion.Major == 6 & OsVersion.Minor == 1)
                        {
                            //WIN 7
                            Sleutel.SetValue(appName, 9000, Microsoft.Win32.RegistryValueKind.DWord);
                        }
                        else if (OsVersion.Major == 6 & OsVersion.Minor == 2)
                        {
                            //WIN 8
                            Sleutel.SetValue(appName, 10000, Microsoft.Win32.RegistryValueKind.DWord);
                        }
                        else if (OsVersion.Major == 5 & OsVersion.Minor == 1)
                        {
                            //WIN xp
                            Sleutel.SetValue(appName, 8000, Microsoft.Win32.RegistryValueKind.DWord);
                        }
                        Sleutel.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
