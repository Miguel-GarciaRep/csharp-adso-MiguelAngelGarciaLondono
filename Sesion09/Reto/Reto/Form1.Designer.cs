namespace Reto
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
            txtTitular = new TextBox();
            lblTitular = new Label();
            lblSaldo = new Label();
            txtSaldo = new TextBox();
            lblMonto = new Label();
            txtMonto = new TextBox();
            btnDepositar = new Button();
            btnRetirar = new Button();
            lstMovimientos = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // txtTitular
            // 
            txtTitular.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitular.Location = new Point(147, 24);
            txtTitular.Name = "txtTitular";
            txtTitular.Size = new Size(132, 25);
            txtTitular.TabIndex = 0;
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitular.Location = new Point(12, 24);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(129, 21);
            lblTitular.TabIndex = 1;
            lblTitular.Text = "Ingrese el titular";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSaldo.Location = new Point(271, 127);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(51, 21);
            lblSaldo.TabIndex = 2;
            lblSaldo.Text = "Saldo";
            // 
            // txtSaldo
            // 
            txtSaldo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSaldo.Location = new Point(231, 151);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Size = new Size(132, 25);
            txtSaldo.TabIndex = 13;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(12, 73);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(60, 21);
            lblMonto.TabIndex = 4;
            lblMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMonto.Location = new Point(78, 73);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(100, 25);
            txtMonto.TabIndex = 1;
            // 
            // btnDepositar
            // 
            btnDepositar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDepositar.Location = new Point(204, 66);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(89, 35);
            btnDepositar.TabIndex = 2;
            btnDepositar.Text = "Depositar";
            btnDepositar.UseVisualStyleBackColor = true;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // btnRetirar
            // 
            btnRetirar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRetirar.Location = new Point(299, 66);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(89, 35);
            btnRetirar.TabIndex = 3;
            btnRetirar.Text = "Retirar";
            btnRetirar.UseVisualStyleBackColor = true;
            btnRetirar.Click += btnRetirar_Click;
            // 
            // lstMovimientos
            // 
            lstMovimientos.FormattingEnabled = true;
            lstMovimientos.Location = new Point(12, 104);
            lstMovimientos.Name = "lstMovimientos";
            lstMovimientos.Size = new Size(166, 94);
            lstMovimientos.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 367);
            Controls.Add(lstMovimientos);
            Controls.Add(btnRetirar);
            Controls.Add(btnDepositar);
            Controls.Add(txtMonto);
            Controls.Add(lblMonto);
            Controls.Add(txtSaldo);
            Controls.Add(lblSaldo);
            Controls.Add(lblTitular);
            Controls.Add(txtTitular);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitular;
        private Label lblSaldo;
        private Label lblMonto;
        private ContextMenuStrip contextMenuStrip1;
        public TextBox txtTitular;
        public TextBox txtSaldo;
        public TextBox txtMonto;
        public Button btnDepositar;
        public Button btnRetirar;
        public ListBox lstMovimientos;
    }
}
