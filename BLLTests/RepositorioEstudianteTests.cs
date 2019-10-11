using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioEstudianteTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Estudiante estudiante = new Estudiante
            {
                EstudianteID = 1,
                Fecha = DateTime.Parse(DateTime.Now.Date.ToString("dd/MM/yy")),
            };
            bool paso = true;
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            paso = repositorio.Guardar(estudiante);
 
            Assert.IsTrue(paso); ;
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            Estudiante estudiante = repositorio.Buscar(1);
            estudiante.DetalleEstudiante.Add(new DetalleEstudiante(1, 0, "Otras", 2, 200, 300));
            bool paso = repositorio.Modificar(estudiante);
            repositorio.Dispose();
            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            Estudiante estudiante = repositorio.Buscar(0);
            repositorio.Dispose();
            Assert.AreEqual(true, !(estudiante is null));
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            List<Estudiante> lista = repositorio.GetList(x => true);
            repositorio.Dispose();
            bool paso = (lista.Count > 0);
            Assert.IsTrue(paso);
        }
    }
}