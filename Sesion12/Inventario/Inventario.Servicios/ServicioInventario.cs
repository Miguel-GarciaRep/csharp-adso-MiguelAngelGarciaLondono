using Inventario.Modelos;

namespace Inventario.Servicios;

public class ServicioInventario
{
    private readonly IRepositorioProductos _repositorio;

    public ServicioInventario(IRepositorioProductos repositorio) => _repositorio = repositorio;

    public List<Producto> Listar() => _repositorio.ObtenerTodos();

    public Producto? Buscar(string codigo) => _repositorio.BuscarPorCodigo(codigo);

    public void Agregar(Producto producto) => _repositorio.Agregar(producto);

    public void Actualizar(Producto producto) => _repositorio.Actualizar(producto);

    public void Eliminar(string codigo) => _repositorio.Eliminar(codigo);

    public List<Categoria> Categorias() => _repositorio.ObtenerCategorias();

    // Nivel extra: resumen por categoría
    public List<ResumenCategoria> ResumenPorCategoria()
    {
        return _repositorio.ObtenerTodos()
            .GroupBy(p => p.Categoria?.Nombre ?? "Sin categoría")
            .Select(g => new ResumenCategoria(g.Key, g.Count(), g.Sum(p => p.Precio * p.Stock)))
            .OrderBy(r => r.Categoria)
            .ToList();
    }
}

public record ResumenCategoria(string Categoria, int Cantidad, decimal ValorTotal);