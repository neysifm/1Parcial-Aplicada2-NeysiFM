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
        readonly string KeyViewState = "Utils";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[KeyViewState] = new Utils();
            }
        }

        private void Limpiar()
        {
            UtilsID.Text = 0.ToString();
            MostrarMensajes.Visible = false;
            MostrarMensajes.Text = string.Empty;
            ViewState[KeyViewState] = new Utils();
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
        private Utils LlenaClase()
        {
            Utils utilidades = new Utils();
            DateTime.TryParse(FechaTextBox.Text, out DateTime result);
            utilidades = (Utils)ViewState[KeyViewState];
            return utilidades;
        }
        private void LlenaCampo(Utils utilidades)
        {
            UtilsID.Text = utilidades.UtilsID.ToString();
            ViewState[KeyViewState] = utilidades;
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
            Utils utilidades = LlenaClase();
            RepositorioParcial repositorio = new RepositorioParcial();
            if (utilidades.UtilsID == 0)
                paso = repositorio.Guardar(utilidades);
            else
            {
                if (!BaseDeDatos())
                {
                    return;
                }
                paso = repositorio.Modificar(utilidades);
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
            RepositorioParcial repositorio = new RepositorioParcial();
            return repositorio.Buscar(UtilsID.Text.ToInt()) != null; ;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioParcial repositorio = new RepositorioParcial();
            Utils utilidades = repositorio.Buscar(UtilsID.Text.ToInt());
            if (utilidades != null)
            {
                Limpiar();
                LlenaCampo(utilidades);
            }
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioParcial repositorio = new RepositorioParcial();
            int id = UtilsID.Text.ToInt();
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
            Utils utilidades = ((Utils)ViewState[KeyViewState]);
            ViewState[KeyViewState] = utilidades;
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            Utils utiles = (Utils)ViewState[KeyViewState];
            DetalleGridView.DataBind();
        }

    }
}