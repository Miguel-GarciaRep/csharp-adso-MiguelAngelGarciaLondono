using System.Text.Json;
using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioJson : IRepositorioProductos
{
    private readonly string _ruta;

    public RepositorioJson(string ruta) => _ruta = ruta;

    public List<Producto> ObtenerTodos()
    {
        if (!File.Exists(_ruta)) return [];

        try
        {
            return JsonSerializer.Deserialize<List<Producto>>(File.ReadAllText(_ruta)) ?? [];
        }
        catch (Exception ex) when (ex is JsonException or ArgumentException)
        {
            // Archivo dañado: se guarda una copia y se empieza vacío
            File.Copy(_ruta, _ruta + ".danado", overwrite: true);
            return [];
        }
    }

    public Producto? BuscarPorCodigo(string codigo) =>
        ObtenerTodos().FirstOrDefault(p => MismoCodigo(p, codigo));

    public void Agregar(Producto producto)
    {
        var lista = ObtenerTodos();
        lista.Add(producto);
        Guardar(lista);
    }

    public void Actualizar(Producto producto)
    {
        var lista = ObtenerTodos();
        int i = lista.FindIndex(p => MismoCodigo(p, producto.Codigo));
        if (i >= 0)
        {
            lista[i] = producto;
            Guardar(lista);
        }
    }

    public void Eliminar(string codigo)
    {
        var lista = ObtenerTodos();
        lista.RemoveAll(p => MismoCodigo(p, codigo));
        Guardar(lista);
    }

    private void Guardar(List<Producto> lista) =>
        File.WriteAllText(_ruta, JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true }));

    private static bool MismoCodigo(Producto producto, string codigo) =>
        string.Equals(producto.Codigo, codigo.Trim(), StringComparison.OrdinalIgnoreCase);
}
