<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeFile="editordetails.aspx.cs" Inherits="Admin_editordetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="721px" style="margin-right: 0px" 
        Width="937px">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Domain"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlDomain" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlDomain_SelectedIndexChanged">
        </asp:DropDownList>
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView 
            ID="GridView1" runat="server" ForeColor="Black" 
            style="margin-left: 25px; margin-top: 10px;" Width="812px" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            AutoGenerateColumns="False" Height="169px" 
            onrowdeleting="GridView1_RowDeleting">
        <Columns>
            <%--<asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="newspaper" HeaderText="NewsPortal" />
            <asp:BoundField DataField="editorname" HeaderText="Editor Name" />
            <asp:BoundField DataField="contactnum" HeaderText="Contact Number" />
            <asp:BoundField DataField="emailid" HeaderText="Email Id" />
            <asp:BoundField DataField="url" HeaderText="URL" />
            <asp:BoundField DataField="status" HeaderText="Status" />--%>

            <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>

           <%-- <asp:TemplateField HeaderText="NewsPortal" >
            <ItemTemplate>
            <asp:Label ID="lblnews" runat="server" Text='<%#Eval("newspaper")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
--%>
             <asp:TemplateField HeaderText="WebDB Name">
            <ItemTemplate>
            <asp:Label ID="lbledit" runat="server" Text='<%#Eval("wdb")%>'> 
           </asp:Label>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Contact Number">
            <ItemTemplate>
            <asp:Label ID="lblcontact" runat="server" Text='<%#Eval("contactnum")%>'> 
           </asp:Label>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email Id">
            <ItemTemplate>
            <asp:Label ID="lablemail" runat="server" Text='<%#Eval("emailid")%>'>
            </asp:Label>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Url">
            <ItemTemplate>
            <asp:Label ID="lblurl" runat="server" Text='<%#Eval("url")%>'>
            </asp:Label>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
            <asp:Button ID="btnstatus" runat="server" Text='<%#Eval("status")%>' CommandName="delete" />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <br />
        <br /><br /><br />
</asp:Panel>
<br /><br /><br />
</asp:Content>

