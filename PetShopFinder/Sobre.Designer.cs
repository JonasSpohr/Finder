namespace PetShopFinder
{
    partial class Sobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sobre));
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFinder = new System.Windows.Forms.Label();
            this.lblPetShop = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.lblDireitosReservados = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(197, 129);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lblFinder);
            this.panel1.Controls.Add(this.lblPetShop);
            this.panel1.Controls.Add(this.pbxLogo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 88);
            this.panel1.TabIndex = 1;
            // 
            // lblFinder
            // 
            this.lblFinder.AutoSize = true;
            this.lblFinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinder.ForeColor = System.Drawing.Color.Crimson;
            this.lblFinder.Location = new System.Drawing.Point(150, 57);
            this.lblFinder.Name = "lblFinder";
            this.lblFinder.Size = new System.Drawing.Size(65, 24);
            this.lblFinder.TabIndex = 2;
            this.lblFinder.Text = "Finder";
            // 
            // lblPetShop
            // 
            this.lblPetShop.AutoSize = true;
            this.lblPetShop.Font = new System.Drawing.Font("Arial Black", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetShop.ForeColor = System.Drawing.Color.Crimson;
            this.lblPetShop.Location = new System.Drawing.Point(89, 7);
            this.lblPetShop.Name = "lblPetShop";
            this.lblPetShop.Size = new System.Drawing.Size(187, 48);
            this.lblPetShop.TabIndex = 1;
            this.lblPetShop.Text = "Pet Shop";
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.Location = new System.Drawing.Point(4, 3);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(79, 81);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(13, 101);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(73, 13);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Text = "Versão: 2.0.0";
            // 
            // lblDireitosReservados
            // 
            this.lblDireitosReservados.AutoSize = true;
            this.lblDireitosReservados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireitosReservados.Location = new System.Drawing.Point(13, 118);
            this.lblDireitosReservados.Name = "lblDireitosReservados";
            this.lblDireitosReservados.Size = new System.Drawing.Size(145, 13);
            this.lblDireitosReservados.TabIndex = 3;
            this.lblDireitosReservados.Text = "Todos os direitos reservados";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(13, 135);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(160, 13);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "© 2015 - JRVB Soluções Digitais";
            // 
            // Sobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblDireitosReservados);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Sobre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblFinder;
        private System.Windows.Forms.Label lblPetShop;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label lblDireitosReservados;
        private System.Windows.Forms.Label lblCopyright;
    }
}