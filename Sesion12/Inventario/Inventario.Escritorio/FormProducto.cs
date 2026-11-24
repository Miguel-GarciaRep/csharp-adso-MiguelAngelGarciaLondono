using Inventario.Modelos;
using Inventario.Servicios;

namespace Inventario.Escritorio;

public partial class FormProducto : Form
{
    public Producto? ProductoCreado { get; private set; }
    private readonly Producto? _productoExistente;
    private readonly List<Categoria> _categorias;

    public FormProducto(List<Categoria> categorias) : this(categorias, null) { }

    public FormProducto(List<Categoria> categorias, Producto productoExistente)
    {
        InitializeComponent();
        _categorias = categorias;
        _productoExistente = productoExistente;

        cmbCategoria.DataSource = _categorias;
        cmbCategoria.DisplayMember = "Nombre";
        cmbCategoria.ValueMember = "Id";

        if (_productoExistente is not null)
        {
            Text = "Editar producto";
            txtCodigo.Text = _productoExistente.Codigo;
            txtCodigo.ReadOnly = true;
            txtNombre.Text = _productoExistente.Nombre;
            numPrecio.Value = _productoExistente.Precio;
            numStock.Value = _productoExistente.Stock;
            if (_productoExistente.CategoriaId.HasValue)
                cmbCategoria.SelectedValue = _productoExistente.CategoriaId.Value;
            else
                cmbCategoria.SelectedIndex = -1;
        }
        else
        {
            Text = "Nuevo producto";
            cmbCategoria.SelectedIndex = -1;
        }
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        errorProvider1.Clear();

        try
        {
            string codigo = txtCodigo.Text.Trim().ToUpper();
            string nombre = txtNombre.Text.Trim();
            decimal precio = numPrecio.Value;
            int stock = (int)numStock.Value;
            int? categoriaId = cmbCategoria.SelectedValue as int?;

            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (_productoExistente is null)
            {
                ProductoCreado = new Producto(codigo, nombre, precio, stock);
                ProductoCreado.CambiarCategoria(categoriaId);
            }
            else
            {
                _productoExistente.CambiarNombre(nombre);
                _productoExistente.CambiarPrecio(precio);
                _productoExistente.CambiarStock(stock);
                _productoExistente.CambiarCategoria(categoriaId);
                ProductoCreado = _productoExistente;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            errorProvider1.SetError(btnGuardar, ex.Message);
        }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}