using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_Grupo19.Clases;

namespace TP7_Grupo19
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "eventoSeleccionar")
            {
                string[] propiedades = e.CommandArgument.ToString().Split('|');

                /*
                propiedades[0] = id
                propiedades[1] = nombre
                propiedades[2] = descripcion
                */

                // Guardar las propiedades de la sucursal en Session
                Session["IdSucursal"] = propiedades[0];
                Session["NombreSucursal"] = propiedades[1];
                Session["DescripcionSucursal"] = propiedades[2];
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                SqlDataSource1.SelectCommand = @"SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [URL_Imagen_Sucursal] FROM [Sucursal] WHERE [NombreSucursal] LIKE @NombreSucursal";

                SqlDataSource1.SelectParameters.Clear();
                SqlDataSource1.SelectParameters.Add("NombreSucursal", "%" + txtBuscar.Text.Trim() + "%");
            }
            else
            {
                SqlDataSource1.SelectCommand = @"SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [URL_Imagen_Sucursal] FROM [Sucursal]";

                SqlDataSource1.SelectParameters.Clear();
            }
            lvSucursales.DataBind();
            txtBuscar.Text = "";
        }

        protected void btnFiltrarProvincia_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "FiltrarProvincia")
            {
                SqlDataSource1.SelectCommand = $@"SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [URL_Imagen_Sucursal] FROM [Sucursal] JOIN [Provincia] ON [Id_ProvinciaSucursal] = [Id_Provincia] WHERE [Id_Provincia] = {e.CommandArgument} ";
            }
        }
    }
}