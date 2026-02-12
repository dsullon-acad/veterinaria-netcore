using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class ProductosController : Controller
    {
        private readonly string cadenaConexion = "server=localhost; database=veterinaria;Integrated security = true;TrustServerCertificate=true";
        public IActionResult Index()
        {
            var listado = obtenerProductos();
            return View(listado);
        }

        #region . Métodos privados .
        private List<Producto> obtenerProductos()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                using (var comando = new SqlCommand("SELECT * FROM Productos", conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if(lector != null && lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                listado.Add(new Producto()
                                {
                                    ID = lector.GetInt32(0),
                                    Nombre = lector.GetString(1),
                                    Descripcion = lector.GetString(2),
                                    PathImagen = lector.GetString(3),
                                    Precio = lector.GetDecimal(4),
                                    CategoriaID = lector.GetInt32(5)
                                });
                            }
                        }
                    }
                }
            }
            return listado;
        }
        #endregion
    }
}
