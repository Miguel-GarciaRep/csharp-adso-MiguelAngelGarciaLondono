namespace Practica
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
            txtNumero1 = new TextBox();
            txtNumero2 = new TextBox();
            txtResultado = new TextBox();
            btnSumar = new Button();
            btnRestar = new Button();
            btnDividir = new Button();
            btnMultiplicar = new Button();
            SuspendLayout();
            // 
            // txtNumero1
            // 
            txtNumero1.Location = new Point(186, 38);
            txtNumero1.Name = "txtNumero1";
            txtNumero1.Size = new Size(161, 23);
            txtNumero1.TabIndex = 0;
            // 
            // txtNumero2
            // 
            txtNumero2.Location = new Point(186, 67);
            txtNumero2.Name = "txtNumero2";
            txtNumero2.Size = new Size(161, 23);
            txtNumero2.TabIndex = 1;
            // 
            // txtResultado
            // 
            txtResultado.Enabled = false;
            txtResultado.Location = new Point(186, 96);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(161, 23);
            txtResultado.TabIndex = 2;
            // 
            // btnSumar
            // 
            btnSumar.Location = new Point(405, 38);
            btnSumar.Name = "btnSumar";
            btnSumar.Size = new Size(75, 23);
            btnSumar.TabIndex = 3;
            btnSumar.Text = "Sumar";
            btnSumar.UseVisualStyleBackColor = true;
            btnSumar.Click += btnSumar_Click;
            // 
            // btnRestar
            // 
            btnRestar.Location = new Point(486, 38);
            btnRestar.Name = "btnRestar";
            btnRestar.Size = new Size(75, 23);
            btnRestar.TabIndex = 4;
            btnRestar.Text = "Restar";
            btnRestar.UseVisualStyleBackColor = true;
            btnRestar.Click += btnRestar_Click;
            // 
            // btnDividir
            // 
            btnDividir.Location = new Point(405, 66);
            btnDividir.Name = "btnDividir";
            btnDividir.Size = new Size(75, 23);
            btnDividir.TabIndex = 5;
            btnDividir.Text = "Dividir";
            btnDividir.UseVisualStyleBackColor = true;
            btnDividir.Click += btnDividir_Click;
            // 
            // btnMultiplicar
            // 
            btnMultiplicar.Location = new Point(486, 66);
            btnMultiplicar.Name = "btnMultiplicar";
            btnMultiplicar.Size = new Size(75, 23);
            btnMultiplicar.TabIndex = 6;
            btnMultiplicar.Text = "Multiplicar";
            btnMultiplicar.UseVisualStyleBackColor = true;
            btnMultiplicar.Click += btnMultiplicar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 450);
            Controls.Add(btnMultiplicar);
            Controls.Add(btnDividir);
            Controls.Add(btnRestar);
            Controls.Add(btnSumar);
            Controls.Add(txtResultado);
            Controls.Add(txtNumero2);
            Controls.Add(txtNumero1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumero1;
        private TextBox txtNumero2;
        private TextBox txtResultado;
        private Button btnSumar;
        private Button btnRestar;
        private Button btnDividir;
        private Button btnMultiplicar;
    }
}
