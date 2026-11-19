using Microsoft.EntityFrameworkCore;

namespace Reto;

public partial class Form1 : Form
{
    // Controles (creados en código, con los nombres de la guía)
    private readonly DataGridView dgvContactos = new();
    private readonly TextBox txtBuscar = new(), txtNombre = new(), txtTelefono = new(), txtCorreo = new();
    private readonly Label lblTotal = new();
    private readonly Button btnAgregar = new(), btnEliminar = new(), btnGuardarCambios = new(), btnCancelar = new();
    private readonly ErrorProvider errorProvider1 = new();

    private int? _idEditando;   // null = agregando, con valor = editando

    public Form1()
    {
        Text = "Agenda de contactos";
        ClientSize = new Size(760, 560);
        StartPosition = FormStartPosition.CenterScreen;

        Campo("Nombre *", txtNombre, 15, 15, 200);
        Campo("Teléfono", txtTelefono, 230, 15, 150);
        Campo("Correo * (con @)", txtCorreo, 395, 15, 220);

        Boton(btnAgregar, "Agregar", 15, 80, 100);
        Boton(btnGuardarCambios, "Guardar cambios", 125, 80, 130);
        Boton(btnCancelar, "Cancelar", 265, 80, 90);
        Boton(btnEliminar, "Eliminar", 365, 80, 100);
        btnGuardarCambios.Enabled = false;
        btnCancelar.Enabled = false;

        Controls.Add(new Label { Text = "Buscar:", Left = 490, Top = 88, AutoSize = true });
        txtBuscar.SetBounds(545, 84, 200, 25);
        Controls.Add(txtBuscar);

        dgvContactos.SetBounds(15, 125, 730, 390);
        dgvContactos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvContactos.AutoGenerateColumns = false;
        dgvContactos.ReadOnly = true;
        dgvContactos.AllowUserToAddRows = false;
        dgvContactos.MultiSelect = false;
        dgvContactos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight = 20 });
        dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", FillWeight = 100 });
        dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono", FillWeight = 70 });
        dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Correo", HeaderText = "Correo", FillWeight = 110 });
        Controls.Add(dgvContactos);

        lblTotal.SetBounds(15, 525, 500, 25);
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        Controls.Add(lblTotal);

        btnAgregar.Click += btnAgregar_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnGuardarCambios.Click += btnGuardarCambios_Click;
        btnCancelar.Click += (_, _) => SalirDeEdicion();
        txtBuscar.TextChanged += txtBuscar_TextChanged;
        dgvContactos.CellDoubleClick += dgvContactos_CellDoubleClick;

        using (var db = new AgendaContext()) db.Database.EnsureCreated();
        CargarContactos();
    }

    private void Campo(string etiqueta, TextBox caja, int x, int y, int ancho)
    {
        Controls.Add(new Label { Text = etiqueta, Left = x, Top = y, AutoSize = true });
        caja.SetBounds(x, y + 22, ancho, 25);
        Controls.Add(caja);
    }

    private void Boton(Button b, string texto, int x, int y, int ancho)
    {
        b.Text = texto;
        b.SetBounds(x, y, ancho, 32);
        Controls.Add(b);
    }

    // 1. Grilla ordenada por nombre + total (y 4. búsqueda con filtro)
    private void CargarContactos(string filtro = "")
    {
        using var db = new AgendaContext();   // una oficina nueva para cada trámite
        dgvContactos.DataSource = db.Contactos
            .Where(c => EF.Functions.Like(c.Nombre, $"%{filtro}%"))
            .OrderBy(c => c.Nombre)
            .ToList();
        lblTotal.Text = $"{dgvContactos.Rows.Count} contactos   ·   doble clic en una fila para editarla";
    }

    // 4. Buscar en vivo
    private void txtBuscar_TextChanged(object? sender, EventArgs e)
        => CargarContactos(txtBuscar.Text.Trim());

    // Valida y marca errores con ErrorProvider
    private bool Validar()
    {
        errorProvider1.Clear();
        bool valido = true;

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            errorProvider1.SetError(txtNombre, "Escribe el nombre.");
            valido = false;
        }
        if (!txtCorreo.Text.Contains('@'))
        {
            errorProvider1.SetError(txtCorreo, "El correo debe tener @.");
            valido = false;
        }
        return valido;
    }

    // 2. Agregar
    private void btnAgregar_Click(object? sender, EventArgs e)
    {
        if (!Validar()) return;

        using var db = new AgendaContext();
        db.Contactos.Add(new Contacto
        {
            Nombre = txtNombre.Text.Trim(),
            Telefono = txtTelefono.Text.Trim(),
            Correo = txtCorreo.Text.Trim()
        });
        db.SaveChanges();   // ¡firma la planilla!

        LimpiarCampos();
        CargarContactos(txtBuscar.Text.Trim());
    }

    // 3. Eliminar con confirmación
    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (dgvContactos.CurrentRow?.DataBoundItem is not Contacto contacto)
        {
            MessageBox.Show("Selecciona un contacto primero.", "Eliminar");
            return;
        }
        if (MessageBox.Show($"¿Eliminar a {contacto.Nombre}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        using var db = new AgendaContext();
        db.Contactos.Remove(contacto);
        db.SaveChanges();

        SalirDeEdicion();
        CargarContactos(txtBuscar.Text.Trim());
    }

    // ⭐ Extra: editar. Doble clic carga la fila en los cuadros de texto
    private void dgvContactos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvContactos.CurrentRow?.DataBoundItem is not Contacto c) return;

        errorProvider1.Clear();
        _idEditando = c.Id;
        txtNombre.Text = c.Nombre;
        txtTelefono.Text = c.Telefono;
        txtCorreo.Text = c.Correo;

        btnAgregar.Enabled = false;
        btnGuardarCambios.Enabled = true;
        btnCancelar.Enabled = true;
    }

    private void btnGuardarCambios_Click(object? sender, EventArgs e)
    {
        if (_idEditando is null || !Validar()) return;

        using var db = new AgendaContext();
        var contacto = db.Contactos.Find(_idEditando.Value);
        if (contacto is null)
        {
            MessageBox.Show("Ese contacto ya no existe.");
            SalirDeEdicion();
            CargarContactos(txtBuscar.Text.Trim());
            return;
        }

        contacto.Nombre = txtNombre.Text.Trim();
        contacto.Telefono = txtTelefono.Text.Trim();
        contacto.Correo = txtCorreo.Text.Trim();
        db.SaveChanges();

        SalirDeEdicion();
        CargarContactos(txtBuscar.Text.Trim());
    }

    private void SalirDeEdicion()
    {
        _idEditando = null;
        LimpiarCampos();
        btnAgregar.Enabled = true;
        btnGuardarCambios.Enabled = false;
        btnCancelar.Enabled = false;
    }

    private void LimpiarCampos()
    {
        errorProvider1.Clear();
        txtNombre.Clear(); txtTelefono.Clear(); txtCorreo.Clear();
        txtNombre.Focus();
    }
}
