using System;
using System.Collections.Generic;
using System.Data;
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
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "eventoSeleccionar")
            {
                string[] propiedades = e.CommandArgument.ToString().Split('|');

                string Id_Sucursal = propiedades[0];
                string NombreSucursal= propiedades[1];  
                string DescSucursal= propiedades[2];

                dynamic Sucursal = new { ID_SUCURSAL = Id_Sucursal, NOMBRE= NombreSucursal, DESCRIPCION=DescSucursal };

                ActualizarDTSession(Sucursal);
                
            }
        }  

        private void ActualizarDTSession(dynamic obj)
        {
            if (Session["SucursalesSeleccionadas"] == null)
            {
                Session["SucursalesSeleccionadas"] = CrearDataTable();
            }

            DataTable dt = (DataTable)Session["SucursalesSeleccionadas"];

            string idSucursalNueva = obj.ID_SUCURSAL;
            bool yaExiste = dt.AsEnumerable().Any(row => row.Field<string>("ID_SUCURSAL") == idSucursalNueva);

            if (!yaExiste)
            {
                AgregarFilaDT(dt, obj);
            }
        }


        private DataTable CrearDataTable()
        {
            DataTable dt = new DataTable();

            DataColumn dataColumn = new DataColumn("ID_SUCURSAL", System.Type.GetType("System.String"));
            dt.Columns.Add(dataColumn);

            dataColumn = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            dt.Columns.Add(dataColumn);

            dataColumn = new DataColumn("DESCRIPCION", System.Type.GetType("System.String"));
            dt.Columns.Add(dataColumn);


            return dt;
        }

        private DataTable AgregarFilaDT(DataTable dt, dynamic nuevaSucursal)
        {
            DataRow dr = dt.NewRow();

            foreach (var propiedad in nuevaSucursal.GetType().GetProperties())
            {
                dr[$"{propiedad.Name}"] = propiedad.GetValue(nuevaSucursal, null);
            }

            dt.Rows.Add(dr);

            return dt;
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