namespace Tarea
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblValor = new Label();
            txtValor = new TextBox();
            lblOrigen = new Label();
            cmbOrigen = new ComboBox();
            lblDestino = new Label();
            cmbDestino = new ComboBox();
            btnConvertir = new Button();
            lblResultado = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(20, 20);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(40, 15);
            lblValor.TabIndex = 0;
            lblValor.Text = "Valor:";
            // 
            // txtValor
            // 
            txtValor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtValor.Location = new Point(20, 40);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(380, 23);
            txtValor.TabIndex = 1;
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(20, 85);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(87, 15);
            lblOrigen.TabIndex = 2;
            lblOrigen.Text = "Unidad origen:";
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(20, 105);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(180, 23);
            cmbOrigen.TabIndex = 3;
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(220, 85);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(91, 15);
            lblDestino.TabIndex = 4;
            lblDestino.Text = "Unidad destino:";
            // 
            // cmbDestino
            // 
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(220, 105);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(180, 23);
            cmbDestino.TabIndex = 5;
            // 
            // btnConvertir
            // 
            btnConvertir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConvertir.Location = new Point(20, 150);
            btnConvertir.Name = "btnConvertir";
            btnConvertir.Size = new Size(380, 40);
            btnConvertir.TabIndex = 6;
            btnConvertir.Text = "Convertir";
            btnConvertir.UseVisualStyleBackColor = true;
            btnConvertir.Click += btnConvertir_Click;
            // 
            // lblResultado
            // 
            lblResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResultado.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblResultado.Location = new Point(20, 210);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(380, 50);
            lblResultado.TabIndex = 7;
            lblResultado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AcceptButton = btnConvertir;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 280);
            Controls.Add(lblValor);
            Controls.Add(txtValor);
            Controls.Add(lblOrigen);
            Controls.Add(cmbOrigen);
            Controls.Add(lblDestino);
            Controls.Add(cmbDestino);
            Controls.Add(btnConvertir);
            Controls.Add(lblResultado);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversor de temperatura";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblValor;
        private TextBox txtValor;
        private Label lblOrigen;
        private ComboBox cmbOrigen;
        private Label lblDestino;
        private ComboBox cmbDestino;
        private Button btnConvertir;
        private Label lblResultado;
        private ErrorProvider errorProvider1;
    }
}
