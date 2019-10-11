using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEstudiante : RepositorioBase<Estudiante>
    {
        // METODO MODIFICAR
        public override bool Modificar(Estudiante entity)
        {
            bool paso = false;
            Estudiante Anterior = Buscar(entity.EstudianteID);
            Contexto contexto = new Contexto();
            try
            {
                using (Contexto baseDatos = new Contexto())
                {
                    foreach (var item in Anterior.DetalleEstudiante.ToList())
                    {
                        if (!entity.DetalleEstudiante.Exists(x => x.DetalleID == item.DetalleID))
                        {
                            baseDatos.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    baseDatos.SaveChanges();
                }
                foreach (var item in entity.DetalleEstudiante)
                {
                    var estado = EntityState.Unchanged;
                    if (item.DetalleID == 0)
                        estado = EntityState.Added;
                        contexto.Entry(item).State = estado;
                }
                contexto.Entry(entity).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        // METODO LISTAR
        public override List<Estudiante> GetList(Expression<Func<Estudiante, bool>> expression)
        {
            List<Estudiante> ListaEstudiante = new List<Estudiante>();
            Contexto db = new Contexto();
            try
            {
                foreach (var item in base.GetList(expression))
                {
                    ListaEstudiante.Add(Buscar(item.EstudianteID));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ListaEstudiante;
        }

        // METODO BUSCAR
        public override Estudiante Buscar(int id)
        {
            Estudiante estudiante = new Estudiante();
            Contexto contexto = new Contexto();
            try
            {
                 estudiante = contexto.Estudiantes.Include(x => x.DetalleEstudiante).Where(x => x.EstudianteID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiante;
        }
    }
}
