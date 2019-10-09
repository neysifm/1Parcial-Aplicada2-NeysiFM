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
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public virtual Estudiante Estudiantes { get; set; }

        public DetalleEstudiante(int detalleID, int estudianteID, decimal cantidad, decimal precio, decimal importe, Estudiante estudiantes)
        {
            DetalleID = detalleID;
            EstudianteID = estudianteID;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Estudiantes = estudiantes;
        }

        public DetalleEstudiante()
        {
            DetalleID = 0;
            EstudianteID = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }
    }
}
