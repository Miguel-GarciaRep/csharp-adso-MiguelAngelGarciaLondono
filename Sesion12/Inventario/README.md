# Inventario con Base de Datos - Sesión 12

## Estructura de la solución
- **Inventario.Modelos** - Entidades e interfaces
- **Inventario.Datos** - DbContext y RepositorioEF
- **Inventario.Servicios** - Lógica de negocio y RepositorioJson
- **Inventario.Escritorio** - Windows Forms UI

## Cambio clave: JSON → Base de datos
```csharp
// Antes
private readonly ServicioInventario _servicio = new(new RepositorioJson("inventario.json"));

// Después (una sola línea)
private readonly ServicioInventario _servicio = new(new RepositorioEf());
```

## Entidades

### Categoria (Tabla 1 - la que se elige en ComboBox)
- `Id` (int)
- `Nombre` (string)
- `Productos` (List<Producto>)

### Producto (Tabla 2 - con relación a Categoria)
- `Codigo` (string, PK)
- `Nombre` (string)
- `Precio` (decimal)
- `Stock` (int)
- `CategoriaId` (int?)
- `Categoria` (Categoria?)

## Funcionalidades
- ✅ CRUD completo de productos
- ✅ Selección de categoría en ComboBox (DisplayMember/ValueMember)
- ✅ Filtro por categoría en grilla principal (ComboBox "Todas" + categorías)
- ✅ Resumen por categoría (GroupBy: cantidad y valor total)
- ✅ Datos persisten en SQLite (`inventario.db`)
- ✅ Datos iniciales: 3 categorías (Papelería, Tecnología, Aseo)

## Nivel extra implementado
- ComboBox de filtro por categoría en FormPrincipal
- Resumen por categoría en el título de la ventana

## Patrones aplicados
- **Repository Pattern**: `IRepositorioProductos` con dos implementaciones
- **Dependency Injection**: Servicio recibe repositorio por constructor
- **Include**: `_db.Productos.Include(p => p.Categoria)` para cargar relación
- **Separación de capas**: DbContext nunca en formularios