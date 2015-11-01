<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeFile="Domain.aspx.cs" Inherits="Admin_Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 95px;
    }
    .style2
    {
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="376px">
        <br />
        <table style="width: 338px; height: 62px; margin-left: 240px; margin-top: 110px">
        <tr><td class="style2">&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Domain"></asp:Label>
            </td><td class="style1">
                <asp:TextBox ID="txtdom" runat="server" Width="175px"></asp:TextBox>
            </td>
        </tr>
        <tr><td class="style2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Register Domain" Width="110px" />
            </td>
        </tr>
        </table>
    </asp:Panel>
</asp:Content>

