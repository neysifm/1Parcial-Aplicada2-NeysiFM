using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioParcial : RepositorioBase<Utils>
    {
        // METODO MODIFICAR
        public override bool Modificar(Utils entity)
        {
            bool paso = false;
            Utils Anterior = Buscar(entity.UtilsID);
            Contexto contexto = new Contexto();
            try
            {
                using (Contexto baseDatos = new Contexto())
                {
                    foreach (var item in Anterior.DetalleUtils.ToList())
                    {
                        if (!entity.DetalleUtils.Exists(x => x.DetalleID == item.DetalleID))
                        {
                            baseDatos.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    baseDatos.SaveChanges();
                }
                foreach (var item in entity.DetalleUtils)
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

        // METODO BUSCAR
        public override Utils Buscar(int id)
        {
            Utils Utilidades = new Utils();
            Contexto contexto = new Contexto();
            try
            {
                Utilidades = contexto.Utilidades.Include(x => x.DetalleUtils).Where(x => x.UtilsID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Utilidades;
        }
    }
}
