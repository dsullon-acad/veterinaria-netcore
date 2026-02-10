using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class ProductosController : Controller
    {
        private readonly string cadenaConexion = "server=localhost; database=veterinaria;user id=sa;password=sqladmin;TrustServerCertificate=true";
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
                conexion.Open();
            }
            return listado;
        }
        #endregion
    }
}
