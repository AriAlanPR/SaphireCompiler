namespace LyARev
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tstrcargar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnleer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnguardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtncargartokens = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtncargargram = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnansintax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtncarregsem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtngentoken = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnansem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnci = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnpost = new System.Windows.Forms.ToolStripMenuItem();
            this.btncodint = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvmatriztransicion = new System.Windows.Forms.DataGridView();
            this.Palabra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtleer = new System.Windows.Forms.TextBox();
            this.dgverrores = new System.Windows.Forms.DataGridView();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_Palabra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvid = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblconexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsprgb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblpa = new System.Windows.Forms.Label();
            this.lblerr = new System.Windows.Forms.Label();
            this.lblide = new System.Windows.Forms.Label();
            this.dgvcade = new System.Windows.Forms.DataGridView();
            this.Numcad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cadena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblcadenas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmatriztransicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgverrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcade)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.tstrcargar,
            this.toolStripSeparator1,
            this.tsbtnleer,
            this.toolStripSeparator3,
            this.tsbtnguardar,
            this.toolStripSeparator4,
            this.toolStripDropDownButton1,
            this.toolStripSeparator5,
            this.toolStripDropDownButton2,
            this.toolStripSeparator6,
            this.btnci,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(950, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tstrcargar
            // 
            this.tstrcargar.Image = ((System.Drawing.Image)(resources.GetObject("tstrcargar.Image")));
            this.tstrcargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrcargar.Name = "tstrcargar";
            this.tstrcargar.Size = new System.Drawing.Size(98, 24);
            this.tstrcargar.Text = "&Cargar MT";
            this.tstrcargar.Click += new System.EventHandler(this.tstrcargar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbtnleer
            // 
            this.tsbtnleer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnleer.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnleer.Image")));
            this.tsbtnleer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnleer.Name = "tsbtnleer";
            this.tsbtnleer.Size = new System.Drawing.Size(41, 24);
            this.tsbtnleer.Text = "&Leer";
            this.tsbtnleer.Click += new System.EventHandler(this.tstrleer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbtnguardar
            // 
            this.tsbtnguardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnguardar.Image")));
            this.tsbtnguardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnguardar.Name = "tsbtnguardar";
            this.tsbtnguardar.Size = new System.Drawing.Size(82, 24);
            this.tsbtnguardar.Text = "&Guardar";
            this.tsbtnguardar.Click += new System.EventHandler(this.tsbtnguardar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtncargartokens,
            this.tsbtncargargram,
            this.tsbtnansintax});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(88, 24);
            this.toolStripDropDownButton1.Text = "Sintáxis";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // tsbtncargartokens
            // 
            this.tsbtncargartokens.Image = ((System.Drawing.Image)(resources.GetObject("tsbtncargartokens.Image")));
            this.tsbtncargartokens.Name = "tsbtncargartokens";
            this.tsbtncargartokens.Size = new System.Drawing.Size(242, 24);
            this.tsbtncargartokens.Text = "Cargar archivo de tokens";
            this.tsbtncargartokens.Click += new System.EventHandler(this.tsbtncargartokens_Click);
            // 
            // tsbtncargargram
            // 
            this.tsbtncargargram.Image = ((System.Drawing.Image)(resources.GetObject("tsbtncargargram.Image")));
            this.tsbtncargargram.Name = "tsbtncargargram";
            this.tsbtncargargram.Size = new System.Drawing.Size(242, 24);
            this.tsbtncargargram.Text = "Cargar gramática";
            this.tsbtncargargram.Click += new System.EventHandler(this.tsbtncargargram_Click);
            // 
            // tsbtnansintax
            // 
            this.tsbtnansintax.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnansintax.Image")));
            this.tsbtnansintax.Name = "tsbtnansintax";
            this.tsbtnansintax.Size = new System.Drawing.Size(242, 24);
            this.tsbtnansintax.Text = "Analizar";
            this.tsbtnansintax.Click += new System.EventHandler(this.tsbtnansintax_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtncarregsem,
            this.tsbtngentoken,
            this.tsbtnansem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(107, 24);
            this.toolStripDropDownButton2.Text = "Semántica";
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // tsbtncarregsem
            // 
            this.tsbtncarregsem.Image = ((System.Drawing.Image)(resources.GetObject("tsbtncarregsem.Image")));
            this.tsbtncarregsem.Name = "tsbtncarregsem";
            this.tsbtncarregsem.Size = new System.Drawing.Size(256, 24);
            this.tsbtncarregsem.Text = "Cargar reglas semánticas";
            this.tsbtncarregsem.Click += new System.EventHandler(this.tsbtncarregsem_Click);
            // 
            // tsbtngentoken
            // 
            this.tsbtngentoken.Image = ((System.Drawing.Image)(resources.GetObject("tsbtngentoken.Image")));
            this.tsbtngentoken.Name = "tsbtngentoken";
            this.tsbtngentoken.Size = new System.Drawing.Size(256, 24);
            this.tsbtngentoken.Text = "Generar tokens temporales";
            this.tsbtngentoken.Click += new System.EventHandler(this.tsbtngentoken_Click);
            // 
            // tsbtnansem
            // 
            this.tsbtnansem.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnansem.Image")));
            this.tsbtnansem.Name = "tsbtnansem";
            this.tsbtnansem.Size = new System.Drawing.Size(256, 24);
            this.tsbtnansem.Text = "Analizar";
            this.tsbtnansem.Click += new System.EventHandler(this.tsbtnansem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // btnci
            // 
            this.btnci.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnpost,
            this.btncodint});
            this.btnci.Image = ((System.Drawing.Image)(resources.GetObject("btnci.Image")));
            this.btnci.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnci.Name = "btnci";
            this.btnci.Size = new System.Drawing.Size(164, 24);
            this.btnci.Text = "Código intermedio";
            this.btnci.Click += new System.EventHandler(this.btnci_Click);
            // 
            // btnpost
            // 
            this.btnpost.Image = ((System.Drawing.Image)(resources.GetObject("btnpost.Image")));
            this.btnpost.Name = "btnpost";
            this.btnpost.Size = new System.Drawing.Size(204, 24);
            this.btnpost.Text = "Postfijo";
            this.btnpost.Click += new System.EventHandler(this.btnpost_Click);
            // 
            // btncodint
            // 
            this.btncodint.Name = "btncodint";
            this.btncodint.Size = new System.Drawing.Size(204, 24);
            this.btncodint.Text = "Codigo intermedio";
            this.btncodint.Click += new System.EventHandler(this.btncodint_Click);
            // 
            // dgvmatriztransicion
            // 
            this.dgvmatriztransicion.AllowUserToAddRows = false;
            this.dgvmatriztransicion.AllowUserToDeleteRows = false;
            this.dgvmatriztransicion.AllowUserToResizeColumns = false;
            this.dgvmatriztransicion.AllowUserToResizeRows = false;
            this.dgvmatriztransicion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvmatriztransicion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmatriztransicion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvmatriztransicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmatriztransicion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Palabra,
            this.Tipo});
            this.dgvmatriztransicion.Location = new System.Drawing.Point(269, 60);
            this.dgvmatriztransicion.Name = "dgvmatriztransicion";
            this.dgvmatriztransicion.ReadOnly = true;
            this.dgvmatriztransicion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmatriztransicion.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvmatriztransicion.Size = new System.Drawing.Size(286, 187);
            this.dgvmatriztransicion.TabIndex = 2;
            // 
            // Palabra
            // 
            this.Palabra.HeaderText = "Palabra Reservada";
            this.Palabra.Name = "Palabra";
            this.Palabra.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Token";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // txtleer
            // 
            this.txtleer.Location = new System.Drawing.Point(12, 28);
            this.txtleer.Multiline = true;
            this.txtleer.Name = "txtleer";
            this.txtleer.Size = new System.Drawing.Size(251, 423);
            this.txtleer.TabIndex = 3;
            this.txtleer.Click += new System.EventHandler(this.txtleer_Click);
            this.txtleer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtleer_MouseClick);
            this.txtleer.TextChanged += new System.EventHandler(this.txtleer_TextChanged);
            // 
            // dgverrores
            // 
            this.dgverrores.AllowUserToAddRows = false;
            this.dgverrores.AllowUserToDeleteRows = false;
            this.dgverrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgverrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgverrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Error,
            this.Linea,
            this.No_Palabra});
            this.dgverrores.Location = new System.Drawing.Point(573, 266);
            this.dgverrores.Name = "dgverrores";
            this.dgverrores.ReadOnly = true;
            this.dgverrores.Size = new System.Drawing.Size(365, 185);
            this.dgverrores.TabIndex = 4;
            this.dgverrores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgverrores_CellContentClick);
            // 
            // Error
            // 
            this.Error.HeaderText = "Error";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "No.Linea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // No_Palabra
            // 
            this.No_Palabra.HeaderText = "No.Palabra";
            this.No_Palabra.Name = "No_Palabra";
            this.No_Palabra.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PALABRAS ACEPTADAS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(653, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ERRORES LEXICOS:";
            // 
            // dgvid
            // 
            this.dgvid.AllowUserToAddRows = false;
            this.dgvid.AllowUserToDeleteRows = false;
            this.dgvid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Token,
            this.Identificador,
            this.TipoId});
            this.dgvid.Location = new System.Drawing.Point(573, 60);
            this.dgvid.Name = "dgvid";
            this.dgvid.ReadOnly = true;
            this.dgvid.Size = new System.Drawing.Size(365, 187);
            this.dgvid.TabIndex = 7;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            this.Token.ReadOnly = true;
            // 
            // Identificador
            // 
            this.Identificador.HeaderText = "Identificador";
            this.Identificador.Name = "Identificador";
            this.Identificador.ReadOnly = true;
            // 
            // TipoId
            // 
            this.TipoId.HeaderText = "Tipo";
            this.TipoId.Name = "TipoId";
            this.TipoId.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblconexion,
            this.toolStripStatusLabel1,
            this.tsprgb1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(950, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tslblconexion
            // 
            this.tslblconexion.Name = "tslblconexion";
            this.tslblconexion.Size = new System.Drawing.Size(82, 17);
            this.tslblconexion.Text = "No conectado";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tsprgb1
            // 
            this.tsprgb1.Name = "tsprgb1";
            this.tsprgb1.Size = new System.Drawing.Size(100, 16);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IDENTIFICADORES:";
            // 
            // lblpa
            // 
            this.lblpa.AutoSize = true;
            this.lblpa.Location = new System.Drawing.Point(477, 44);
            this.lblpa.Name = "lblpa";
            this.lblpa.Size = new System.Drawing.Size(13, 13);
            this.lblpa.TabIndex = 10;
            this.lblpa.Text = "0";
            // 
            // lblerr
            // 
            this.lblerr.AutoSize = true;
            this.lblerr.Location = new System.Drawing.Point(770, 250);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(13, 13);
            this.lblerr.TabIndex = 11;
            this.lblerr.Text = "0";
            // 
            // lblide
            // 
            this.lblide.AutoSize = true;
            this.lblide.Location = new System.Drawing.Point(766, 44);
            this.lblide.Name = "lblide";
            this.lblide.Size = new System.Drawing.Size(13, 13);
            this.lblide.TabIndex = 12;
            this.lblide.Text = "0";
            // 
            // dgvcade
            // 
            this.dgvcade.AllowUserToAddRows = false;
            this.dgvcade.AllowUserToDeleteRows = false;
            this.dgvcade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numcad,
            this.Cadena});
            this.dgvcade.Location = new System.Drawing.Point(269, 266);
            this.dgvcade.Name = "dgvcade";
            this.dgvcade.ReadOnly = true;
            this.dgvcade.Size = new System.Drawing.Size(286, 185);
            this.dgvcade.TabIndex = 13;
            // 
            // Numcad
            // 
            this.Numcad.HeaderText = "Numero";
            this.Numcad.Name = "Numcad";
            this.Numcad.ReadOnly = true;
            // 
            // Cadena
            // 
            this.Cadena.HeaderText = "Cadena";
            this.Cadena.Name = "Cadena";
            this.Cadena.ReadOnly = true;
            // 
            // lblcadenas
            // 
            this.lblcadenas.AutoSize = true;
            this.lblcadenas.Location = new System.Drawing.Point(477, 250);
            this.lblcadenas.Name = "lblcadenas";
            this.lblcadenas.Size = new System.Drawing.Size(13, 13);
            this.lblcadenas.TabIndex = 15;
            this.lblcadenas.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "CADENAS:";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 24);
            this.toolStripButton1.Text = "Optimizar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 476);
            this.Controls.Add(this.lblcadenas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvcade);
            this.Controls.Add(this.lblide);
            this.Controls.Add(this.lblerr);
            this.Controls.Add(this.lblpa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgverrores);
            this.Controls.Add(this.txtleer);
            this.Controls.Add(this.dgvmatriztransicion);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "JHIN-PYG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmatriztransicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgverrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tstrcargar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnleer;
        private System.Windows.Forms.DataGridView dgvmatriztransicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Palabra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.TextBox txtleer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dgverrores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton tsbtnguardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridView dgvid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblconexion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tsprgb1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.Label lblpa;
        private System.Windows.Forms.Label lblerr;
        private System.Windows.Forms.Label lblide;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Palabra;
        private System.Windows.Forms.DataGridView dgvcade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numcad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cadena;
        private System.Windows.Forms.Label lblcadenas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem tsbtncargargram;
        private System.Windows.Forms.ToolStripMenuItem tsbtnansintax;
        private System.Windows.Forms.ToolStripMenuItem tsbtncargartokens;
        private System.Windows.Forms.ToolStripMenuItem tsbtngentoken;
        private System.Windows.Forms.ToolStripMenuItem tsbtncarregsem;
        private System.Windows.Forms.ToolStripMenuItem tsbtnansem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoId;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripDropDownButton btnci;
        private System.Windows.Forms.ToolStripMenuItem btnpost;
        private System.Windows.Forms.ToolStripMenuItem btncodint;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

