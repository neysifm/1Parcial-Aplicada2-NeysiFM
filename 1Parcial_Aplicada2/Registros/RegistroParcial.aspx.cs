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

            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString();
                ViewState[KeyViewState] = new Estudiante();
                Limpiar();
                int id = Request.QueryString["Estudiante"].ToInt();
                if (id > 0)
                {
                    using (RepositorioEstudiante repositorio = new RepositorioEstudiante())
                    {
                        Estudiante estudiante = repositorio.Buscar(id);
                        if (estudiante == null)
                        {
                            MostrarMensajes.Visible = true;
                            MostrarMensajes.Text = "Registro No encontrado";
                            MostrarMensajes.CssClass = "alert-danger";
                        }
                        else
                            LlenaCampo(estudiante);
                    }
                }
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
                MostrarMensajes.Text = "Guardado Exitosamente!!";
                MostrarMensajes.CssClass = "alert-success";
                MostrarMensajes.Visible = true;
            }
            else
            {
                MostrarMensajes.Text = "No Se Pudo Guardar El Registro";
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
                MostrarMensajes.Text = "Registro No encontrado";
                MostrarMensajes.CssClass = "alert-danger";
                return;
            }
            else
            {
                if (repositorio.Eliminar(id))
                {
                    Limpiar();
                    MostrarMensajes.Visible = true;
                    MostrarMensajes.Text = "Eliminado Correctamente!!";
                    MostrarMensajes.CssClass = "alert-danger";

                }
            }
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = ((Estudiante)ViewState[KeyViewState]);
            ViewState[KeyViewState] = estudiante;
            ServicioTextBox.Text = string.Empty;
            decimal Cantidad = CantidadTextBox.Text.ToDecimal();
            decimal Precio = PrecioTextBox.Text.ToDecimal();
            decimal Importe = ImporteTextBox.Text.ToDecimal();
            estudiante.AgregarDetalle(0, estudiante.EstudianteID, ServicioTextBox.Text, Cantidad, Precio, Importe);
            ActualizarGrid();
        }

        protected void RemoverDetalleClick_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = ((Estudiante)ViewState[KeyViewState]);
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            estudiante.RemoverDetalle(row.RowIndex);
            ViewState[KeyViewState] = estudiante;
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            Estudiante estudiante = (Estudiante)ViewState[KeyViewState];
            DetalleGridView.DataSource = estudiante.DetalleEstudiante;
            DetalleGridView.DataBind();
        }
    }
}