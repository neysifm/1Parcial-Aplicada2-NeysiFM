using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using _1Parcial_Aplicada2.Herramientas;
using System.Web.UI.WebControls;

namespace _1Parcial_Aplicada2.Registros
{
    public partial class RegistroParcial : System.Web.UI.Page
    {
        readonly string KeyViewState = "Estudiante";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[KeyViewState] = new Estudiante();
            }
        }

        private void Limpiar()
        {
            EstudianteID.Text = 0.ToString();
            EstudianteTextBox.Text = string.Empty;
            ServicioTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            MostrarMensajes.Visible = false;
            MostrarMensajes.Text = string.Empty;
            ViewState[KeyViewState] = new Estudiante();
            ActualizarGrid();
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(FechaTextBox.Text))
                paso = false;
            if (DetalleGridView.Rows.Count <= 0)
                paso = false;
            return paso;
        }
        private Estudiante LlenaClase()
        {
            Estudiante estudiante = new Estudiante();
            DateTime.TryParse(FechaTextBox.Text, out DateTime result);
            estudiante = (Estudiante)ViewState[KeyViewState];
            return estudiante;
        }
        private void LlenaCampo(Estudiante estudiante)
        {
            EstudianteID.Text = estudiante.EstudianteID.ToString();
            ViewState[KeyViewState] = estudiante;
            ActualizarGrid();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            bool paso = false;
            Estudiante estudiante = LlenaClase();
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            if (estudiante.EstudianteID == 0)
                paso = repositorio.Guardar(estudiante);
            else
            {
                if (!BaseDeDatos())
                {
                    return;
                }
                paso = repositorio.Modificar(estudiante);
            }
            if (paso)
            {
                Limpiar();
                MostrarMensajes.Text = "Guardado";
                MostrarMensajes.CssClass = "alert-success";
                MostrarMensajes.Visible = true;
            }
            else
            {
                MostrarMensajes.Text = "No guardo";
                MostrarMensajes.CssClass = "alert-warning";
                MostrarMensajes.Visible = true;
            }
        }

        private bool BaseDeDatos()
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            return repositorio.Buscar(EstudianteID.Text.ToInt()) != null; ;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            Estudiante estudiantes = repositorio.Buscar(EstudianteID.Text.ToInt());
            if (estudiantes != null)
            {
                Limpiar();
                LlenaCampo(estudiantes);
            }
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioEstudiante repositorio = new RepositorioEstudiante();
            int id = EstudianteID.Text.ToInt();
            if (!BaseDeDatos())
            {
                MostrarMensajes.Visible = true;
                MostrarMensajes.Text = "No encontrado";
                MostrarMensajes.CssClass = "alert-danger";
                return;
            }
            else
            {
                if (repositorio.Eliminar(id))
                {
                    Limpiar();
                    MostrarMensajes.Visible = true;
                    MostrarMensajes.Text = "Eliminado";
                    MostrarMensajes.CssClass = "alert-danger";

                }
            }
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Estudiante utilidades = ((Estudiante)ViewState[KeyViewState]);
            ViewState[KeyViewState] = utilidades;
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            Estudiante utiles = (Estudiante)ViewState[KeyViewState];
            DetalleGridView.DataBind();
        }

    }
}