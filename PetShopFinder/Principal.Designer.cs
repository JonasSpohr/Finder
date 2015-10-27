namespace PetShopFinder
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.cboCidade = new System.Windows.Forms.ComboBox();
            this.dBPetDataSet = new PetShopFinder.DBPetDataSet();
            this.cboBairro = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreGooglePlacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inícioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisiçõesWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarChaveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sobrePetShopFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.tableAdapterManager = new PetShopFinder.DBPetDataSetTableAdapters.TableAdapterManager();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.chkBairro = new System.Windows.Forms.CheckBox();
            this.chkCidade = new System.Windows.Forms.CheckBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnMapa = new System.Windows.Forms.Button();
            this.cboKeys = new System.Windows.Forms.ComboBox();
            this.gbxLocation = new System.Windows.Forms.GroupBox();
            this.gbxGeo = new System.Windows.Forms.GroupBox();
            this.gbxEstabelecimento = new System.Windows.Forms.GroupBox();
            this.cboEstabelecimento = new System.Windows.Forms.ComboBox();
            this.gbxChaves = new System.Windows.Forms.GroupBox();
            this.txtLogExecucao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtLogRequisicao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dBPetDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbxLocation.SuspendLayout();
            this.gbxGeo.SuspendLayout();
            this.gbxEstabelecimento.SuspendLayout();
            this.gbxChaves.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(8, 71);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(40, 13);
            this.lblCidade.TabIndex = 3;
            this.lblCidade.Text = "Cidade";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(8, 125);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(34, 13);
            this.lblBairro.TabIndex = 4;
            this.lblBairro.Text = "Bairro";
            // 
            // cboCidade
            // 
            this.cboCidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCidade.DisplayMember = "CidadeId";
            this.cboCidade.Enabled = false;
            this.cboCidade.Location = new System.Drawing.Point(11, 87);
            this.cboCidade.Name = "cboCidade";
            this.cboCidade.Size = new System.Drawing.Size(250, 21);
            this.cboCidade.TabIndex = 6;
            this.cboCidade.ValueMember = "CidadeId";
            this.cboCidade.SelectedIndexChanged += new System.EventHandler(this.cboCidade_SelectedIndexChanged);
            // 
            // dBPetDataSet
            // 
            this.dBPetDataSet.DataSetName = "DBPetDataSet";
            this.dBPetDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cboBairro
            // 
            this.cboBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBairro.DisplayMember = "ufe_sg";
            this.cboBairro.Enabled = false;
            this.cboBairro.Location = new System.Drawing.Point(11, 141);
            this.cboBairro.Name = "cboBairro";
            this.cboBairro.Size = new System.Drawing.Size(250, 21);
            this.cboBairro.TabIndex = 7;
            this.cboBairro.ValueMember = "ufe_sg";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Crimson;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1247, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Arquivo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(92, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreGooglePlacesToolStripMenuItem,
            this.toolStripSeparator2,
            this.sobrePetShopFinderToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.sobreToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreGooglePlacesToolStripMenuItem
            // 
            this.sobreGooglePlacesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inícioToolStripMenuItem,
            this.requisiçõesWebToolStripMenuItem});
            this.sobreGooglePlacesToolStripMenuItem.Name = "sobreGooglePlacesToolStripMenuItem";
            this.sobreGooglePlacesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.sobreGooglePlacesToolStripMenuItem.Text = "Sobre Google Places";
            // 
            // inícioToolStripMenuItem
            // 
            this.inícioToolStripMenuItem.Name = "inícioToolStripMenuItem";
            this.inícioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.inícioToolStripMenuItem.Text = "API Google Places";
            this.inícioToolStripMenuItem.Click += new System.EventHandler(this.inícioToolStripMenuItem_Click);
            // 
            // requisiçõesWebToolStripMenuItem
            // 
            this.requisiçõesWebToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarChaveToolStripMenuItem1,
            this.textSearchToolStripMenuItem,
            this.detailSearchToolStripMenuItem});
            this.requisiçõesWebToolStripMenuItem.Name = "requisiçõesWebToolStripMenuItem";
            this.requisiçõesWebToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.requisiçõesWebToolStripMenuItem.Text = "Requisições Web";
            // 
            // gerarChaveToolStripMenuItem1
            // 
            this.gerarChaveToolStripMenuItem1.Name = "gerarChaveToolStripMenuItem1";
            this.gerarChaveToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.gerarChaveToolStripMenuItem1.Text = "Gerar Chave";
            this.gerarChaveToolStripMenuItem1.Click += new System.EventHandler(this.gerarChaveToolStripMenuItem1_Click);
            // 
            // textSearchToolStripMenuItem
            // 
            this.textSearchToolStripMenuItem.Name = "textSearchToolStripMenuItem";
            this.textSearchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.textSearchToolStripMenuItem.Text = "Text Search";
            this.textSearchToolStripMenuItem.Click += new System.EventHandler(this.textSearchToolStripMenuItem_Click);
            // 
            // detailSearchToolStripMenuItem
            // 
            this.detailSearchToolStripMenuItem.Name = "detailSearchToolStripMenuItem";
            this.detailSearchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.detailSearchToolStripMenuItem.Text = "Detail Search";
            this.detailSearchToolStripMenuItem.Click += new System.EventHandler(this.detailSearchToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // sobrePetShopFinderToolStripMenuItem
            // 
            this.sobrePetShopFinderToolStripMenuItem.Name = "sobrePetShopFinderToolStripMenuItem";
            this.sobrePetShopFinderToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.sobrePetShopFinderToolStripMenuItem.Text = "Sobre PetShop Finder";
            this.sobrePetShopFinderToolStripMenuItem.Click += new System.EventHandler(this.sobrePetShopFinderToolStripMenuItem_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.DisplayMember = "SIgla";
            this.cboEstado.Enabled = false;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEstado.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboEstado.Location = new System.Drawing.Point(11, 33);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(250, 21);
            this.cboEstado.TabIndex = 5;
            this.cboEstado.ValueMember = "SIgla";
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(8, 17);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(199, 43);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(29, 13);
            this.lblDistancia.TabIndex = 20;
            this.lblDistancia.Text = "Raio";
            this.toolTip1.SetToolTip(this.lblDistancia, "Metros");
            // 
            // txtDistancia
            // 
            this.txtDistancia.Enabled = false;
            this.txtDistancia.Location = new System.Drawing.Point(199, 59);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(62, 20);
            this.txtDistancia.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtDistancia, "Metros");
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(8, 43);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(45, 13);
            this.lblLatitude.TabIndex = 19;
            this.lblLatitude.Text = "Latitude";
            this.toolTip1.SetToolTip(this.lblLatitude, "Graus Decimais");
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(105, 43);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(54, 13);
            this.lblLongitude.TabIndex = 18;
            this.lblLongitude.Text = "Longitude";
            this.toolTip1.SetToolTip(this.lblLongitude, "Graus Decimais");
            // 
            // txtLongitude
            // 
            this.txtLongitude.Enabled = false;
            this.txtLongitude.Location = new System.Drawing.Point(105, 59);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(88, 20);
            this.txtLongitude.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtLongitude, "Graus Decimais");
            // 
            // txtLatitude
            // 
            this.txtLatitude.Enabled = false;
            this.txtLatitude.Location = new System.Drawing.Point(11, 59);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(88, 20);
            this.txtLatitude.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtLatitude, "Graus Decimais");
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.Color.Firebrick;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImportar.Location = new System.Drawing.Point(1160, 1);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(1);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 21);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CADLogBairroTableAdapter = null;
            this.tableAdapterManager.CADLogCaixaPostalComunitariaTableAdapter = null;
            this.tableAdapterManager.CADLogGrandeUsuarioTableAdapter = null;
            this.tableAdapterManager.CADLogLocalidadeTableAdapter = null;
            this.tableAdapterManager.CADLogLogradouroTableAdapter = null;
            this.tableAdapterManager.CADLogUnidadeOperacionalTableAdapter = null;
            this.tableAdapterManager.CidadeTableAdapter = null;
            this.tableAdapterManager.ClientePetTableAdapter = null;
            this.tableAdapterManager.ClienteTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.EstabelecimentoClienteTableAdapter = null;
            this.tableAdapterManager.EstabelecimentoProdutoTableAdapter = null;
            this.tableAdapterManager.EstabelecimentosAnoTableAdapter = null;
            this.tableAdapterManager.EstabelecimentosBaseTableAdapter = null;
            this.tableAdapterManager.EstabelecimentoServicoTableAdapter = null;
            this.tableAdapterManager.EstabelecimentoTableAdapter = null;
            this.tableAdapterManager.EstadoTableAdapter = null;
            this.tableAdapterManager.PaisTableAdapter = null;
            this.tableAdapterManager.PetTableAdapter = null;
            this.tableAdapterManager.ProdutoTableAdapter = null;
            this.tableAdapterManager.ProdutoTagTableAdapter = null;
            this.tableAdapterManager.RacaTableAdapter = null;
            this.tableAdapterManager.ServicoTableAdapter = null;
            this.tableAdapterManager.ServicoTagTableAdapter = null;
            this.tableAdapterManager.TagsTableAdapter = null;
            this.tableAdapterManager.TipoEstabelecimentoTableAdapter = null;
            this.tableAdapterManager.TipoPetTableAdapter = null;
            this.tableAdapterManager.TipoProdutoTableAdapter = null;
            this.tableAdapterManager.TipoServicoTableAdapter = null;
            this.tableAdapterManager.TipoUsuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PetShopFinder.DBPetDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuarioEstabelecimentoTableAdapter = null;
            this.tableAdapterManager.UsuarioTableAdapter = null;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(150, 17);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(108, 17);
            this.chkLocation.TabIndex = 3;
            this.chkLocation.Text = "Ponto Específico";
            this.chkLocation.UseVisualStyleBackColor = true;
            this.chkLocation.CheckedChanged += new System.EventHandler(this.chkLocation_CheckedChanged);
            // 
            // chkBairro
            // 
            this.chkBairro.AutoSize = true;
            this.chkBairro.Checked = true;
            this.chkBairro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBairro.Enabled = false;
            this.chkBairro.Location = new System.Drawing.Point(150, 124);
            this.chkBairro.Name = "chkBairro";
            this.chkBairro.Size = new System.Drawing.Size(105, 17);
            this.chkBairro.TabIndex = 23;
            this.chkBairro.Text = "Todos os Bairros";
            this.chkBairro.UseVisualStyleBackColor = true;
            this.chkBairro.CheckedChanged += new System.EventHandler(this.chkBairro_CheckedChanged);
            // 
            // chkCidade
            // 
            this.chkCidade.AutoSize = true;
            this.chkCidade.Checked = true;
            this.chkCidade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCidade.Enabled = false;
            this.chkCidade.Location = new System.Drawing.Point(150, 70);
            this.chkCidade.Name = "chkCidade";
            this.chkCidade.Size = new System.Drawing.Size(111, 17);
            this.chkCidade.TabIndex = 24;
            this.chkCidade.Text = "Todas as Cidades";
            this.chkCidade.UseVisualStyleBackColor = true;
            this.chkCidade.CheckedChanged += new System.EventHandler(this.chkCidades_CheckedChanged);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(150, 16);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(111, 17);
            this.chkEstado.TabIndex = 25;
            this.chkEstado.Text = "Todos os Estados";
            this.chkEstado.UseVisualStyleBackColor = true;
            this.chkEstado.CheckedChanged += new System.EventHandler(this.chkEstados_CheckedChanged);
            // 
            // btnMapa
            // 
            this.btnMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapa.BackColor = System.Drawing.Color.Firebrick;
            this.btnMapa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMapa.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMapa.Location = new System.Drawing.Point(1081, 1);
            this.btnMapa.Margin = new System.Windows.Forms.Padding(1);
            this.btnMapa.Name = "btnMapa";
            this.btnMapa.Size = new System.Drawing.Size(75, 21);
            this.btnMapa.TabIndex = 26;
            this.btnMapa.Text = "Mapa";
            this.btnMapa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMapa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMapa.UseVisualStyleBackColor = false;
            this.btnMapa.Click += new System.EventHandler(this.btnMapa_Click);
            // 
            // cboKeys
            // 
            this.cboKeys.BackColor = System.Drawing.Color.White;
            this.cboKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboKeys.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboKeys.Location = new System.Drawing.Point(10, 19);
            this.cboKeys.Name = "cboKeys";
            this.cboKeys.Size = new System.Drawing.Size(250, 21);
            this.cboKeys.TabIndex = 27;
            // 
            // gbxLocation
            // 
            this.gbxLocation.Controls.Add(this.cboEstado);
            this.gbxLocation.Controls.Add(this.lblEstado);
            this.gbxLocation.Controls.Add(this.chkEstado);
            this.gbxLocation.Controls.Add(this.chkBairro);
            this.gbxLocation.Controls.Add(this.chkCidade);
            this.gbxLocation.Controls.Add(this.cboCidade);
            this.gbxLocation.Controls.Add(this.cboBairro);
            this.gbxLocation.Controls.Add(this.lblCidade);
            this.gbxLocation.Controls.Add(this.lblBairro);
            this.gbxLocation.Location = new System.Drawing.Point(14, 163);
            this.gbxLocation.Name = "gbxLocation";
            this.gbxLocation.Size = new System.Drawing.Size(271, 177);
            this.gbxLocation.TabIndex = 28;
            this.gbxLocation.TabStop = false;
            // 
            // gbxGeo
            // 
            this.gbxGeo.Controls.Add(this.lblLatitude);
            this.gbxGeo.Controls.Add(this.txtLatitude);
            this.gbxGeo.Controls.Add(this.chkLocation);
            this.gbxGeo.Controls.Add(this.txtLongitude);
            this.gbxGeo.Controls.Add(this.lblLongitude);
            this.gbxGeo.Controls.Add(this.txtDistancia);
            this.gbxGeo.Controls.Add(this.lblDistancia);
            this.gbxGeo.Location = new System.Drawing.Point(14, 345);
            this.gbxGeo.Name = "gbxGeo";
            this.gbxGeo.Size = new System.Drawing.Size(271, 94);
            this.gbxGeo.TabIndex = 29;
            this.gbxGeo.TabStop = false;
            this.gbxGeo.Text = "Coordenadas Geográficas";
            // 
            // gbxEstabelecimento
            // 
            this.gbxEstabelecimento.Controls.Add(this.cboEstabelecimento);
            this.gbxEstabelecimento.Location = new System.Drawing.Point(14, 99);
            this.gbxEstabelecimento.Name = "gbxEstabelecimento";
            this.gbxEstabelecimento.Size = new System.Drawing.Size(271, 58);
            this.gbxEstabelecimento.TabIndex = 30;
            this.gbxEstabelecimento.TabStop = false;
            this.gbxEstabelecimento.Text = "Estabelecimento";
            // 
            // cboEstabelecimento
            // 
            this.cboEstabelecimento.BackColor = System.Drawing.Color.White;
            this.cboEstabelecimento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEstabelecimento.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cboEstabelecimento.Location = new System.Drawing.Point(10, 22);
            this.cboEstabelecimento.Name = "cboEstabelecimento";
            this.cboEstabelecimento.Size = new System.Drawing.Size(250, 21);
            this.cboEstabelecimento.TabIndex = 28;
            // 
            // gbxChaves
            // 
            this.gbxChaves.Controls.Add(this.cboKeys);
            this.gbxChaves.Location = new System.Drawing.Point(15, 39);
            this.gbxChaves.Name = "gbxChaves";
            this.gbxChaves.Size = new System.Drawing.Size(271, 55);
            this.gbxChaves.TabIndex = 31;
            this.gbxChaves.TabStop = false;
            this.gbxChaves.Text = "Chaves para Requisições";
            // 
            // txtLogExecucao
            // 
            this.txtLogExecucao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLogExecucao.Location = new System.Drawing.Point(14, 465);
            this.txtLogExecucao.Multiline = true;
            this.txtLogExecucao.Name = "txtLogExecucao";
            this.txtLogExecucao.ReadOnly = true;
            this.txtLogExecucao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogExecucao.Size = new System.Drawing.Size(272, 160);
            this.txtLogExecucao.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Execução";
            // 
            // txtLogRequisicao
            // 
            this.txtLogRequisicao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogRequisicao.Location = new System.Drawing.Point(292, 39);
            this.txtLogRequisicao.Multiline = true;
            this.txtLogRequisicao.Name = "txtLogRequisicao";
            this.txtLogRequisicao.ReadOnly = true;
            this.txtLogRequisicao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogRequisicao.Size = new System.Drawing.Size(943, 586);
            this.txtLogRequisicao.TabIndex = 34;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1247, 637);
            this.Controls.Add(this.txtLogRequisicao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogExecucao);
            this.Controls.Add(this.gbxChaves);
            this.Controls.Add(this.gbxEstabelecimento);
            this.Controls.Add(this.gbxGeo);
            this.Controls.Add(this.gbxLocation);
            this.Controls.Add(this.btnMapa);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PetShop Finder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dBPetDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxLocation.ResumeLayout(false);
            this.gbxLocation.PerformLayout();
            this.gbxGeo.ResumeLayout(false);
            this.gbxGeo.PerformLayout();
            this.gbxEstabelecimento.ResumeLayout(false);
            this.gbxChaves.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.ComboBox cboCidade;
        private System.Windows.Forms.ComboBox cboBairro;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sobrePetShopFinderToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Button btnImportar;
        private DBPetDataSet dBPetDataSet;
        private DBPetDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkBairro;
        private System.Windows.Forms.CheckBox chkCidade;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnMapa;
        private System.Windows.Forms.ComboBox cboKeys;
        private System.Windows.Forms.ToolStripMenuItem sobreGooglePlacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inícioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requisiçõesWebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarChaveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem textSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailSearchToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbxLocation;
        private System.Windows.Forms.GroupBox gbxGeo;
        private System.Windows.Forms.GroupBox gbxEstabelecimento;
        private System.Windows.Forms.GroupBox gbxChaves;
        private System.Windows.Forms.TextBox txtLogExecucao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEstabelecimento;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtLogRequisicao;
    }
}

