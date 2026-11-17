using Inventario.Datos;
using Inventario.Modelos;

namespace Inventario.Servicios;

public class ServicioInventario
{
    private const int LimiteStockBajo = 5;

    private readonly IRepositorioProductos _repositorio;

    public ServicioInventario(IRepositorioProductos repositorio) => _repositorio = repositorio;

    public List<Producto> Listar() =>
        _repositorio.ObtenerTodos().OrderBy(p => p.Nombre).ToList();

    public void Agregar(Producto producto)
    {
        if (_repositorio.BuscarPorCodigo(producto.Codigo) is not null)
            throw new InvalidOperationException($"Ya existe el producto {producto.Codigo}.");

        _repositorio.Agregar(producto);
    }

    public void AgregarStock(string codigo, int cantidad)
    {
        Producto producto = ObtenerProducto(codigo);
        producto.AgregarStock(cantidad);
        _repositorio.Actualizar(producto);
    }

    public void Vender(string codigo, int cantidad)
    {
        Producto producto = ObtenerProducto(codigo);
        producto.Vender(cantidad);
        _repositorio.Actualizar(producto);
    }

    public List<Producto> StockBajo() =>
        Listar().Where(p => p.Stock < LimiteStockBajo).ToList();

    // Tarea: productos cuyo nombre o código contengan el texto, sin importar mayúsculas
    public List<Producto> BuscarPorTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException("Escribe un texto para buscar.");

        texto = texto.Trim();
        return Listar()
            .Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                     || p.Codigo.Contains(texto, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Tarea: la confirmación (s/n) la pide la consola, no el servicio
    public void Eliminar(string codigo)
    {
        Producto producto = ObtenerProducto(codigo);
        _repositorio.Eliminar(producto.Codigo);
    }

    private Producto ObtenerProducto(string codigo) =>
        _repositorio.BuscarPorCodigo(codigo)
            ?? throw new ArgumentException($"No existe el producto {codigo.Trim().ToUpperInvariant()}.");
}
