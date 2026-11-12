namespace Practica2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtNombre = new TextBox();
            nudEdad = new NumericUpDown();
            cmbPrograma = new ComboBox();
            rdbManana = new RadioButton();
            rdbTarde = new RadioButton();
            chkTerminos = new CheckBox();
            btnInscribir = new Button();
            lstInscritos = new ListBox();
            errorProvider1 = new ErrorProvider(components);
            lblNombre = new Label();
            lblEdad = new Label();
            lblJornada = new Label();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.Info;
            txtNombre.Cursor = Cursors.IBeam;
            txtNombre.Location = new Point(28, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(239, 23);
            txtNombre.TabIndex = 0;
            // 
            // nudEdad
            // 
            nudEdad.BackColor = SystemColors.Info;
            nudEdad.Cursor = Cursors.IBeam;
            nudEdad.Location = new Point(312, 34);
            nudEdad.Minimum = new decimal(new int[] { 14, 0, 0, 0 });
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(72, 23);
            nudEdad.TabIndex = 3;
            nudEdad.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // cmbPrograma
            // 
            cmbPrograma.BackColor = SystemColors.Info;
            cmbPrograma.Cursor = Cursors.Hand;
            cmbPrograma.FormattingEnabled = true;
            cmbPrograma.Items.AddRange(new object[] { "ADSO", "Multimedia", "Contabilidad" });
            cmbPrograma.Location = new Point(74, 83);
            cmbPrograma.Name = "cmbPrograma";
            cmbPrograma.Size = new Size(149, 23);
            cmbPrograma.TabIndex = 1;
            cmbPrograma.Text = "Escoja su tecnologia";
            cmbPrograma.SelectedIndexChanged += cmbPrograma_SelectedIndexChanged;
            // 
            // rdbManana
            // 
            rdbManana.AutoSize = true;
            rdbManana.BackColor = SystemColors.Info;
            rdbManana.Cursor = Cursors.Hand;
            rdbManana.Location = new Point(312, 87);
            rdbManana.Name = "rdbManana";
            rdbManana.Size = new Size(68, 19);
            rdbManana.TabIndex = 4;
            rdbManana.TabStop = true;
            rdbManana.Text = "Mañana";
            rdbManana.UseVisualStyleBackColor = false;
            // 
            // rdbTarde
            // 
            rdbTarde.AutoSize = true;
            rdbTarde.BackColor = SystemColors.Info;
            rdbTarde.Cursor = Cursors.Hand;
            rdbTarde.Location = new Point(312, 116);
            rdbTarde.Name = "rdbTarde";
            rdbTarde.Size = new Size(54, 19);
            rdbTarde.TabIndex = 5;
            rdbTarde.TabStop = true;
            rdbTarde.Text = "Tarde";
            rdbTarde.UseVisualStyleBackColor = false;
            // 
            // chkTerminos
            // 
            chkTerminos.AutoSize = true;
            chkTerminos.BackColor = SystemColors.Info;
            chkTerminos.Cursor = Cursors.Hand;
            chkTerminos.Location = new Point(461, 13);
            chkTerminos.Name = "chkTerminos";
            chkTerminos.Size = new Size(194, 19);
            chkTerminos.TabIndex = 6;
            chkTerminos.Text = "Acepta terminos y condiciones?";
            chkTerminos.UseVisualStyleBackColor = false;
            // 
            // btnInscribir
            // 
            btnInscribir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnInscribir.BackColor = SystemColors.Info;
            btnInscribir.Cursor = Cursors.Hand;
            btnInscribir.Location = new Point(486, 38);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(141, 32);
            btnInscribir.TabIndex = 7;
            btnInscribir.Text = "Inscribirme";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click;
            // 
            // lstInscritos
            // 
            lstInscritos.BackColor = SystemColors.Info;
            lstInscritos.FormattingEnabled = true;
            lstInscritos.Location = new Point(443, 87);
            lstInscritos.Name = "lstInscritos";
            lstInscritos.Size = new Size(239, 64);
            lstInscritos.TabIndex = 8;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(74, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(147, 21);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Ingrese su nombre";
            lblNombre.Click += lblNombre_Click;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEdad.Location = new Point(285, 9);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(126, 21);
            lblEdad.TabIndex = 11;
            lblEdad.Text = "Ingrese su edad";
            lblEdad.Click += label2_Click;
            // 
            // lblJornada
            // 
            lblJornada.AutoSize = true;
            lblJornada.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJornada.Location = new Point(285, 60);
            lblJornada.Name = "lblJornada";
            lblJornada.Size = new Size(144, 21);
            lblJornada.TabIndex = 12;
            lblJornada.Text = "Ingrese su jornada";
            // 
            // Form1
            // 
            AcceptButton = btnInscribir;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(lblJornada);
            Controls.Add(lblEdad);
            Controls.Add(lblNombre);
            Controls.Add(lstInscritos);
            Controls.Add(btnInscribir);
            Controls.Add(chkTerminos);
            Controls.Add(rdbTarde);
            Controls.Add(rdbManana);
            Controls.Add(cmbPrograma);
            Controls.Add(nudEdad);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Inscripciones";
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private NumericUpDown nudEdad;
        private ComboBox cmbPrograma;
        private RadioButton rdbManana;
        private RadioButton rdbTarde;
        private CheckBox chkTerminos;
        private Button btnInscribir;
        private ListBox lstInscritos;
        private ErrorProvider errorProvider1;
        private Label lblNombre;
        private Label lblEdad;
        private Label lblJornada;
    }
}
