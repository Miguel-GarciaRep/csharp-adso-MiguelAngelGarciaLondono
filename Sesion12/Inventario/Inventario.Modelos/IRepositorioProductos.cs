namespace Inventario.Modelos;

public interface IRepositorioProductos
{
    List<Producto> ObtenerTodos();
    Producto? BuscarPorCodigo(string codigo);
    void Agregar(Producto producto);
    void Actualizar(Producto producto);
    void Eliminar(string codigo);
    List<Categoria> ObtenerCategorias();
}