<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Template.aspx.cs" Inherits="Template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="377px">
    <table style="width: 480px; margin-left: 201px; margin-top: 118px">
    <tr>
         <td colspan="2">
         <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" 
             ForeColor="#0000CC" NavigateUrl="~/Register.aspx">WebDB Registration</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" 
                 ForeColor="#0000CC" NavigateUrl="~/Template.aspx">Template Registration</asp:HyperLink>
             <br />
             <br />
         </td>
        </tr>
        <tr><td>
            <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Select WebDb"></asp:Label>
            </td><td>
                <asp:DropDownList ID="ddlweb" runat="server" Height="22px" Width="172px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlweb" ErrorMessage="Please select your WebDb" 
                    InitialValue="--Select WebDb--"></asp:RequiredFieldValidator>
            </td></tr>
    <tr><td class="style1">
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Element"></asp:Label>
        </td><td>
            <asp:TextBox ID="txtel" runat="server" Width="172px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtel" ErrorMessage="Please enter an element" 
                ValidationGroup="val"></asp:RequiredFieldValidator>
        </td></tr>
    <tr><td class="style1">
        <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Attribute"></asp:Label>
        </td><td>
            <asp:TextBox ID="txtatr" runat="server" Width="172px"></asp:TextBox>
        </td></tr>
        <tr><td>
            <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="Value"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtval" runat="server" Width="172px"></asp:TextBox>
            </td></tr>
       <tr><td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnregt" runat="server" Text="Register" Width="136px" 
               onclick="btnregt_Click" />
           </td></tr>
    </table>
    </asp:Panel>
</asp:Content>

