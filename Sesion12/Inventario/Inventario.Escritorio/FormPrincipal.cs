using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

namespace Inventario.Escritorio;

public partial class FormPrincipal : Form
{
    private readonly ServicioInventario _servicio = new(new RepositorioEf());
    private ComboBox? cmbFiltroCategoria;

    public FormPrincipal()
    {
        InitializeComponent();
        ConfigurarFiltroCategoria();
        CargarProductos();
    }

    private void ConfigurarFiltroCategoria()
    {
        cmbFiltroCategoria = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 150,
            Location = new Point(btnAgregar.Location.X + btnAgregar.Width + 10, btnAgregar.Location.Y)
        };
        cmbFiltroCategoria.Items.Add("Todas");
        foreach (var cat in _servicio.Categorias())
            cmbFiltroCategoria.Items.Add(cat);
        cmbFiltroCategoria.SelectedIndex = 0;
        cmbFiltroCategoria.SelectedIndexChanged += (_, _) => CargarProductos();
        Controls.Add(cmbFiltroCategoria);
    }

    private void CargarProductos()
    {
        var productos = _servicio.Listar();

        if (cmbFiltroCategoria?.SelectedItem is Categoria cat)
            productos = productos.Where(p => p.CategoriaId == cat.Id).ToList();

        dgvProductos.DataSource = null;
        dgvProductos.DataSource = productos;
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        using var form = new FormProducto(_servicio.Categorias());
        if (form.ShowDialog(this) == DialogResult.OK && form.ProductoCreado is not null)
        {
            _servicio.Agregar(form.ProductoCreado);
            CargarProductos();
            MostrarResumen();
        }
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.CurrentRow?.DataBoundItem is not Producto producto) return;

        using var form = new FormProducto(_servicio.Categorias(), producto);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            _servicio.Actualizar(producto);
            CargarProductos();
            MostrarResumen();
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.CurrentRow?.DataBoundItem is not Producto producto) return;

        if (MessageBox.Show($"¿Eliminar {producto.Nombre}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        _servicio.Eliminar(producto.Codigo);
        CargarProductos();
        MostrarResumen();
    }

    private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (dgvProductos.Columns["CategoriaId"] is DataGridViewColumn id) id.Visible = false;
        if (dgvProductos.Columns["Categoria"] is DataGridViewColumn cat) cat.Visible = false;
        if (dgvProductos.Columns["Precio"] is DataGridViewColumn precio)
            precio.DefaultCellStyle.Format = "C2";
    }

    private void MostrarResumen()
    {
        var resumen = _servicio.ResumenPorCategoria();
        var lineas = resumen.Select(r => $"{r.Categoria}: {r.Cantidad} productos, {r.ValorTotal:C2}");
        Text = "Inventario - " + string.Join(" | ", lineas);
    }
}