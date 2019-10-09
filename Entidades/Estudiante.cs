using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Estudiante
    {
        [Key]
        public int EstudianteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Servicio { get; set; }
        public decimal Total { get; set; }
        public virtual List<DetalleEstudiante> DetalleEstudiante { get; set; }

        public Estudiante(int estudianteID, DateTime fecha, string servicio, decimal total, List<DetalleEstudiante> detalleEstudiante)
        {
            EstudianteID = estudianteID;
            Fecha = fecha;
            Servicio = servicio;
            Total = total;
            DetalleEstudiante = detalleEstudiante;
        }

        public Estudiante()
        {
            EstudianteID = 0;
            Fecha = DateTime.Now;
            Servicio = String.Empty;
            Total = 0;
            DetalleEstudiante = new List<DetalleEstudiante>();
        }
    }
}
