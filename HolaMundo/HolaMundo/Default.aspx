<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HolaMundo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Label ID="labelTexto" runat="server" Text="ola mlundo"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Text="Hola"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button2_Click" />
        <asp:Label ID="labelError" runat="server" Text="" ForeColor="IndianRed"></asp:Label>

    </main>

</asp:Content>
