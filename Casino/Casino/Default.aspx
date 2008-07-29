<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Casino._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<LINK href="estiloCasino.css" type="text/css" rel="stylesheet"/>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Bienvenidos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="font-weight: bold">BIENVENIDO!<br />
            <br />
            <img src="dados.bmp" /><br />
            <br />
        </span>
        <asp:Panel  ID="Panel1" runat="server" Height="100px" Width="327px">
            Ingrese los siguientes datos:<br />
            <br />
            usuario:<br />
        <asp:TextBox ID="usuario" runat="server" TabIndex="1"></asp:TextBox><br />
            contraseña:<br />
        <asp:TextBox TextMode="Password" ID="contrasenia" runat="server" TabIndex="2"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        &nbsp;&nbsp;<br />
        <asp:Button ID="entrar" runat="server" Text="Aceptar" CssClass="button" OnClick="leer" /><br />
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
