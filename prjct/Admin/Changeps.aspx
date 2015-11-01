<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.master" AutoEventWireup="true" CodeFile="Changeps.aspx.cs" Inherits="Editor_Changeps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="334px">
    <br />
        <br />
        &nbsp;<br />
        <table style="width: 664px; margin-left: 103px">
           <%-- <caption>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           --%>     <tr>
                    <td class="style1">
                        <asp:Label ID="lblps" runat="server" ForeColor="Black" Text="Current Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtps" runat="server" Width="165px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   --%>
                <%--<caption>
                --%>    
            <%--<caption>
            --%>   <%--
                <caption>
                    <br />--%>
                    <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   --%>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblnwps" runat="server" ForeColor="Black" Text="New Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnps" runat="server" Width="165px" TextMode="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtnps" 
                                ErrorMessage="Password Length must be between 7  to 10 characters" 
                                ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{7,10}$" ValidationGroup="val"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    --%>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Confirm Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtcps" runat="server" Width="165px" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtnps" ControlToValidate="txtcps" 
                                ErrorMessage="Password does not match" ForeColor="#666666" 
                                ValidationGroup="val"></asp:CompareValidator>
                        </td>
                    </tr>
                    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    --%><%--<caption>--%><%--<caption>--%><%--<caption>
                --%>
                    <%--<caption>
                        <br />
                    --%>    
            <caption>
                <br />
                <br />
                <br />
                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    --%>
                <tr>
                    <td colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btncp" runat="server" onclick="btncp_Click" 
                            Text="Change Password " />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btncl" runat="server" onclick="btncl_Click" Text="Cancel" 
                            Width="151px" />
                    </td>
                </tr>
                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                <%--</caption>
                </caption>
            </caption>
--%><%--</caption>
            </caption>--%><%-- </caption>
        --%><%--</caption>
        --%><%--
                    </caption>
            </caption>
            --%>
            </caption>
        </table>
    <br />
</asp:Panel>
</asp:Content>

