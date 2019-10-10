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
        public void ModificarTest()
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            Estudiante estudiante = repositorio.Buscar(0);
            estudiante.DetalleEstudiante.Add(new DetalleEstudiante(0, 1, "Tutorias", 5, 250, 100));
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