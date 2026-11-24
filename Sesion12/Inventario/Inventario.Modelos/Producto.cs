namespace Inventario.Modelos;

public class Producto
{
    public string Codigo { get; private set; }
    public string Nombre { get; private set; }
    public decimal Precio { get; private set; }
    public int Stock { get; private set; }

    public int? CategoriaId { get; private set; }
    public Categoria? Categoria { get; private set; }

    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código es obligatorio.");
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.");
        if (precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        if (stock < 0)
            throw new ArgumentException("El stock no puede ser negativo.");

        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre.Trim();
        Precio = precio;
        Stock = stock;
    }

    public void CambiarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.");
        Nombre = nombre.Trim();
    }

    public void CambiarPrecio(decimal precio)
    {
        if (precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        Precio = precio;
    }

    public void CambiarStock(int stock)
    {
        if (stock < 0)
            throw new ArgumentException("El stock no puede ser negativo.");
        Stock = stock;
    }

    public void CambiarCategoria(int? categoriaId) => CategoriaId = categoriaId;
}