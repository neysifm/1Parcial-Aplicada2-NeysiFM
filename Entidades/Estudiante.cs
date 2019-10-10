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
        public decimal Total { get; set; }
        public virtual List<DetalleEstudiante> DetalleEstudiante { get; set; }

        public Estudiante(int estudianteID, DateTime fecha, decimal total, List<DetalleEstudiante> detalleEstudiante)
        {
            EstudianteID = estudianteID;
            Fecha = fecha;
            Total = total;
            DetalleEstudiante = detalleEstudiante;
        }

        public Estudiante()
        {
            EstudianteID = 0;
            Fecha = DateTime.Now;
            Total = 0;
            DetalleEstudiante = new List<DetalleEstudiante>();
        }

        public void AgregarDetalle(int detalleID, int estudianteID, string servicio, decimal cantidad, decimal precio, decimal importe)
        {
            DetalleEstudiante.Add(new DetalleEstudiante(detalleID, estudianteID, servicio, cantidad, precio, importe));
        }

        public void RemoverDetalle(int Eliminar)
        {
            this.DetalleEstudiante.RemoveAt(Eliminar);
        }
    }
}
