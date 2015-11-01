<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeFile="webcontent.aspx.cs" Inherits="Admin_webcontent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="423px">
    <br />
    <br />
    <table style="width: 480px; margin-left: 178px; height: 88px;">
<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnview" runat="server" onclick="btnview_Click" 
        Text="TrainData" Width="95px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btncln" runat="server" onclick="Button1_Click1" Text="Clean Up " 
        Width="95px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnalg" runat="server" onclick="Button1_Click" 
        Text="Data Clean" Width="100px" />
    </td></tr>
    </table>
      
     
   
        
      
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            style="margin-left: 168px; margin-top: 47px;" Height="101px">
            <Columns>
                <asp:BoundField DataField="Domain" HeaderText="Domain" />
                <asp:BoundField DataField="WDBs" HeaderText="WDBs" />
                <asp:BoundField DataField="Keywords-General" HeaderText="Keywords-General" />
                <asp:BoundField DataField="Keywords-Domain Specific" 
                    HeaderText="Keywords-Domain Specific" />
                <asp:BoundField DataField="Result Pages" HeaderText="Result Pages" />
            </Columns>
           <%-- <Columns>
                <asp:BoundField HeaderText="Domain" />
                <asp:BoundField HeaderText="Site" />
                <asp:BoundField HeaderText="Keyword-General" />
                <asp:BoundField HeaderText="Keyword-Domain Specific" />
                <asp:BoundField HeaderText="Result Pages" />
            </Columns>
--%>
        </asp:GridView>
    <br />
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    <br />
</asp:Panel>
</asp:Content>

