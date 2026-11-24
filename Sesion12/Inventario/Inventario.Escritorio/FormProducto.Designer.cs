namespace Inventario.Escritorio;

partial class FormProducto
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblCodigo = new Label();
        txtCodigo = new TextBox();
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblPrecio = new Label();
        numPrecio = new NumericUpDown();
        lblStock = new Label();
        numStock = new NumericUpDown();
        lblCategoria = new Label();
        cmbCategoria = new ComboBox();
        btnGuardar = new Button();
        btnCancelar = new Button();
        errorProvider1 = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        //
        // lblCodigo
        //
        lblCodigo.AutoSize = true;
        lblCodigo.Location = new Point(20, 20);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new Size(46, 15);
        lblCodigo.TabIndex = 0;
        lblCodigo.Text = "Código:";
        //
        // txtCodigo
        //
        txtCodigo.Location = new Point(120, 17);
        txtCodigo.MaxLength = 20;
        txtCodigo.Name = "txtCodigo";
        txtCodigo.Size = new Size(200, 23);
        txtCodigo.TabIndex = 1;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(20, 55);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(54, 15);
        lblNombre.TabIndex = 2;
        lblNombre.Text = "Nombre:";
        //
        // txtNombre
        //
        txtNombre.Location = new Point(120, 52);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(200, 23);
        txtNombre.TabIndex = 3;
        //
        // lblPrecio
        //
        lblPrecio.AutoSize = true;
        lblPrecio.Location = new Point(20, 90);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Size = new Size(43, 15);
        lblPrecio.TabIndex = 4;
        lblPrecio.Text = "Precio:";
        //
        // numPrecio
        //
        numPrecio.DecimalPlaces = 2;
        numPrecio.Location = new Point(120, 87);
        numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numPrecio.Name = "numPrecio";
        numPrecio.Size = new Size(200, 23);
        numPrecio.TabIndex = 5;
        //
        // lblStock
        //
        lblStock.AutoSize = true;
        lblStock.Location = new Point(20, 125);
        lblStock.Name = "lblStock";
        lblStock.Size = new Size(39, 15);
        lblStock.TabIndex = 6;
        lblStock.Text = "Stock:";
        //
        // numStock
        //
        numStock.Location = new Point(120, 122);
        numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numStock.Name = "numStock";
        numStock.Size = new Size(200, 23);
        numStock.TabIndex = 7;
        //
        // lblCategoria
        //
        lblCategoria.AutoSize = true;
        lblCategoria.Location = new Point(20, 160);
        lblCategoria.Name = "lblCategoria";
        lblCategoria.Size = new Size(61, 15);
        lblCategoria.TabIndex = 8;
        lblCategoria.Text = "Categoría:";
        //
        // cmbCategoria
        //
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategoria.Location = new Point(120, 157);
        cmbCategoria.Name = "cmbCategoria";
        cmbCategoria.Size = new Size(200, 23);
        cmbCategoria.TabIndex = 9;
        //
        // btnGuardar
        //
        btnGuardar.Location = new Point(120, 200);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(100, 30);
        btnGuardar.TabIndex = 10;
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = true;
        btnGuardar.Click += btnGuardar_Click;
        //
        // btnCancelar
        //
        btnCancelar.Location = new Point(226, 200);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(100, 30);
        btnCancelar.TabIndex = 11;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += btnCancelar_Click;
        //
        // errorProvider1
        //
        errorProvider1.ContainerControl = this;
        //
        // FormProducto
        //
        AcceptButton = btnGuardar;
        CancelButton = btnCancelar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(350, 250);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        Controls.Add(cmbCategoria);
        Controls.Add(lblCategoria);
        Controls.Add(numStock);
        Controls.Add(lblStock);
        Controls.Add(numPrecio);
        Controls.Add(lblPrecio);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        Controls.Add(txtCodigo);
        Controls.Add(lblCodigo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormProducto";
        StartPosition = FormStartPosition.CenterParent;
        ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
        ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblCodigo;
    private TextBox txtCodigo;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblPrecio;
    private NumericUpDown numPrecio;
    private Label lblStock;
    private NumericUpDown numStock;
    private Label lblCategoria;
    private ComboBox cmbCategoria;
    private Button btnGuardar;
    private Button btnCancelar;
    private ErrorProvider errorProvider1;
}