<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JuegoDeDados.aspx.cs" Inherits="Casino.JuegoDados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<LINK href="estiloCasino.css" type="text/css" rel="stylesheet"/>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dados</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:Button ID="jugarDados" runat="server" TabIndex="1" Text="Ingresar a mesa!" CssClass="button" />
        <br />
        <br />
        <asp:Panel ID="mesaDados" runat="server" BackColor="#FFFFC0" Height="416px" Width="385px">
        </asp:Panel>
    
    </div>
        <br />
        Ficha que desea apostar:<br />
        <asp:RadioButtonList ID="fichas" runat="server" BorderColor="Yellow" BorderStyle="Solid"
            TabIndex="2">
        </asp:RadioButtonList>Tipo de apuesta que desea realizar:<br />
        <asp:RadioButtonList ID="tipoDeApuesta" runat="server" BorderColor="Yellow" BorderStyle="Solid"
            RepeatDirection="Horizontal" TabIndex="3">
            <asp:ListItem>Pass</asp:ListItem>
            <asp:ListItem>No Pass</asp:ListItem>
            <asp:ListItem>Venir</asp:ListItem>
            <asp:ListItem>No Venir</asp:ListItem>
            <asp:ListItem>De Campo</asp:ListItem>
            <asp:ListItem Value="A Ganar">A Ganar</asp:ListItem>
            <asp:ListItem Value="En Contra"></asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Button ID="apostar" runat="server" TabIndex="4" Text="Apostar!" CssClass="button" /><br />
    </form>
</body>
</html>
