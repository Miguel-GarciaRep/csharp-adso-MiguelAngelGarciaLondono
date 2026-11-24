using Inventario.Modelos;
using System.Text.Json;

namespace Inventario.Servicios;

public class RepositorioJson : IRepositorioProductos
{
    private readonly string _rutaArchivo;
    private List<Producto> _productos = [];

    public RepositorioJson(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
        Cargar();
    }

    private void Cargar()
    {
        if (!File.Exists(_rutaArchivo))
        {
            _productos = [];
            return;
        }

        try
        {
            var json = File.ReadAllText(_rutaArchivo);
            _productos = JsonSerializer.Deserialize<List<Producto>>(json) ?? [];
        }
        catch
        {
            _productos = [];
        }
    }

    private void Guardar()
    {
        var json = JsonSerializer.Serialize(_productos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_rutaArchivo, json);
    }

    public List<Producto> ObtenerTodos() => [.. _productos];

    public Producto? BuscarPorCodigo(string codigo)
    {
        string clave = codigo.Trim().ToUpper();
        return _productos.FirstOrDefault(p => p.Codigo == clave);
    }

    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
        Guardar();
    }

    public void Actualizar(Producto producto)
    {
        var idx = _productos.FindIndex(p => p.Codigo == producto.Codigo);
        if (idx >= 0)
        {
            _productos[idx] = producto;
            Guardar();
        }
    }

    public void Eliminar(string codigo)
    {
        string clave = codigo.Trim().ToUpper();
        var producto = _productos.FirstOrDefault(p => p.Codigo == clave);
        if (producto is not null)
        {
            _productos.Remove(producto);
            Guardar();
        }
    }

    public List<Categoria> ObtenerCategorias() => [new Categoria { Id = 1, Nombre = "General" }];
}