using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class DetalleEstudiante
    {
        [Key]
        public int DetalleID { get; set; }
        public int EstudianteID { get; set; }
        [ForeignKey("EstudianteID")]
        public virtual Estudiante Estudiantes { get; set; }
        public string Servicio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public DetalleEstudiante(int detalleID, int estudianteID, string servicio, decimal cantidad, decimal precio, decimal importe)
        {
            DetalleID = detalleID;
            EstudianteID = estudianteID;
            Servicio = servicio;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

        public DetalleEstudiante()
        {
            DetalleID = 0;
            EstudianteID = 0;
            Servicio = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }
    }
}
