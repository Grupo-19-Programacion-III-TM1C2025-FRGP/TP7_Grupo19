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
                /*Session["IdSucursal"] = propiedades[0];
                Session["NombreSucursal"] = propiedades[1];
                Session["DescripcionSucursal"] = propiedades[2];*/

                string Id_Sucursal = propiedades[0];
                string NombreSucursal= propiedades[1];  
                string DescSucursal= propiedades[2];

                dynamic Sucursal = new { ID_SUCURSAL = Id_Sucursal, NOMBRE= NombreSucursal, DESCRIPCION=DescSucursal };

                ActualizarDTSession(Sucursal);
                
            }
        }

        private void ActualizarDTSession(dynamic obj)
        {
            if (Session["TablaSucursalSeleccionada"] == null)
            {
                Session["TablaSucursalSeleccionada"] = CrearDataTable();
            }

            DataTable dt = (DataTable)Session["TablaSucursalSeleccionada"];

            int idSucursalNueva = Convert.ToInt32(obj.ID_SUCURSAL);
            bool yaExiste = dt.AsEnumerable().Any(row => row.Field<int>("Id_Sucursal") == idSucursalNueva);

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