<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSucursales.aspx.cs" Inherits="TP7_Grupo19.SeleccionarSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 277px;
        }
        .auto-style4 {
            height: 26px;
            width: 277px;
        }
        .auto-style5 {
            width: 148px;
        }
        .auto-style6 {
            height: 26px;
            width: 148px;
        }
        .auto-style7 {
        }
        .auto-style8 {
            height: 26px;
            width: 215px;
        }
        .auto-style9 {
            width: 215px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">
                    <asp:Label ID="Label1" runat="server" Text="Búsqueda por nombre de sucursal:"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtBuscar" runat="server" Width="244px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:DataList ID="DataListProvincias" runat="server" DataSourceID="SqlDataSource2" Height="532px" HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnFiltrarProvincia" runat="server" CommandArgument='<%# Eval("Id_Provincia") %>' CommandName="FiltrarProvincia" OnCommand="btnFiltrarProvincia_Command" Text='<%# Eval("DescripcionProvincia") %>' />
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td class="auto-style7" colspan="2">
                    <asp:ListView ID="lvSucursales" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="3" DataKeyNames="Id_Sucursal">
                        <EditItemTemplate>
                            <td runat="server" style="background-color: #FFCC66; color: #000080;">Id_Sucursal:
                                <asp:Label ID="Id_SucursalLabel1" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                <br />
                                NombreSucursal:
                                <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                <br />DescripcionSucursal:
                                <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                <br />Id_ProvinciaSucursal:
                                <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                                <br />
                                URL_Imagen_Sucursal:
                                <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                <br />
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                <br /></td>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                <tr>
                                    <td>No se han devuelto datos.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
<td runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <InsertItemTemplate>
                            <td runat="server" style="">NombreSucursal:
                                <asp:TextBox ID="NombreSucursalTextBox" runat="server" Text='<%# Bind("NombreSucursal") %>' />
                                <br />DescripcionSucursal:
                                <asp:TextBox ID="DescripcionSucursalTextBox" runat="server" Text='<%# Bind("DescripcionSucursal") %>' />
                                <br />Id_ProvinciaSucursal:
                                <asp:TextBox ID="Id_ProvinciaSucursalTextBox" runat="server" Text='<%# Bind("Id_ProvinciaSucursal") %>' />
                                <br />
                                URL_Imagen_Sucursal:
                                <asp:TextBox ID="URL_Imagen_SucursalTextBox" runat="server" Text='<%# Bind("URL_Imagen_Sucursal") %>' />
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                <br />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                <br /></td>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <td runat="server" style="background-color: #FFFBD6; color: #333333;">
                                <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>'></asp:Label>
                                <br />
                                <br />
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" ImageUrl='<%# Eval("URL_Imagen_Sucursal") %>' Width="100px" />
                                <br />
                                <br />
                                <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>'></asp:Label>
                                <br />
                                <asp:Button ID="btnSeleccionar" runat="server" CommandArgument='<%# Eval ("Id_Sucursal") + "|" + Eval("NombreSucursal") + "|" + Eval("DescripcionSucursal") %>' CommandName="eventoSeleccionar" OnCommand="btnSeleccionar_Command" Text="Seleccionar" />
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr id="groupPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="text-align: center;background-color: #FFCC66; font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333">
                                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                            <Fields>
                                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                <asp:NumericPagerField />
                                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <td runat="server" style="background-color: #FFCC66; font-weight: bold;color: #000080;">Id_Sucursal:
                                <asp:Label ID="Id_SucursalLabel" runat="server" Text='<%# Eval("Id_Sucursal") %>' />
                                <br />NombreSucursal:
                                <asp:Label ID="NombreSucursalLabel" runat="server" Text='<%# Eval("NombreSucursal") %>' />
                                <br />DescripcionSucursal:
                                <asp:Label ID="DescripcionSucursalLabel" runat="server" Text='<%# Eval("DescripcionSucursal") %>' />
                                <br />Id_ProvinciaSucursal:
                                <asp:Label ID="Id_ProvinciaSucursalLabel" runat="server" Text='<%# Eval("Id_ProvinciaSucursal") %>' />
                                <br />
                                URL_Imagen_Sucursal:
                                <asp:Label ID="URL_Imagen_SucursalLabel" runat="server" Text='<%# Eval("URL_Imagen_Sucursal") %>' />
                                <br />
                            </td>
                        </SelectedItemTemplate>
                    </asp:ListView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style8"></td>
                <td class="auto-style4"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT * FROM [Provincia]"></asp:SqlDataSource>
                </td>
                <td class="auto-style9">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDSucursalesConnectionString %>" SelectCommand="SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [Id_ProvinciaSucursal], [URL_Imagen_Sucursal] FROM [Sucursal]"></asp:SqlDataSource>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
