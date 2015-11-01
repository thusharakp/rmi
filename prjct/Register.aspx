<%@ Page Title="" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Editor_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="White">
    <br />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <table style="margin-left: 54px">
 <tr>
         <td colspan="2">
         <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="True" 
             ForeColor="#0000CC" NavigateUrl="~/Register.aspx">WebDB Registration</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" 
                 ForeColor="#0000CC" NavigateUrl="~/Template.aspx">Template Registration</asp:HyperLink>
             <br />
         </td>
        </tr>
            <%--
    <caption>
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
         <tr>
             <td>
                 <asp:Label ID="lbled" runat="server" ForeColor="Black" Text="WebDB"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             </td>
             <td>
                 <asp:TextBox ID="txtdb" runat="server" Height="26px" Width="170px"></asp:TextBox>
                </td><td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ControlToValidate="txtdb" ErrorMessage="Please enter the name " 
                     ForeColor="#666666" ValidationGroup="val"></asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr><td>
             <asp:Label ID="Label3" runat="server" Text="Domain" ForeColor="Black"></asp:Label>
             </td><td>
                 <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="170px" 
                     onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                 </asp:DropDownList>
             </td><td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                     ErrorMessage="Please select a domain" InitialValue="--Select Domain--" 
                     ControlToValidate="DropDownList1" ValidationGroup="val"></asp:RequiredFieldValidator>
             </td></tr>
        <%-- <caption>
             <br />
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </caption>
     </caption>
        --%>
        
         <tr>
         <td>
         <asp:Label ID="lblcnt" runat="server" ForeColor="Black" Text="Contact Number"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td>
         <td>
         <asp:TextBox ID="txtcnt" runat="server" Width="170px" Height="26px"></asp:TextBox></td>
<%--&nbsp;--%><td><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtcnt" ErrorMessage="contact number is invalid" 
            ForeColor="#666666" 
            ValidationExpression="^((\\+91-?)|0)?[0-9]{10}$" 
            ValidationGroup="val"></asp:RegularExpressionValidator>
                 &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                     ControlToValidate="txtcnt" ErrorMessage="Please enter the contact number"></asp:RequiredFieldValidator>
         </td>
         </tr>
       <%-- </table>--%>
        
       <%-- <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       --%> 
       <tr>
       <td>
       <asp:Label ID="lblemail" runat="server" ForeColor="Black" Text="Email Id"></asp:Label>
       </td>
       <td>
       <asp:TextBox ID="txtemail" runat="server" Width="171px" Height="26px"></asp:TextBox></td>
<%--&nbsp;--%>
    <td>    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtemail" ErrorMessage="Invalid email id" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="val"></asp:RegularExpressionValidator>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="txtemail" ErrorMessage="Field is empty" 
            ValidationGroup="val"></asp:RequiredFieldValidator>
       </td>
       </tr>
       
       <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    --%><tr><td><asp:Label ID="lblur" runat="server" Text="URL" ForeColor="Black"></asp:Label></td><td>
         <asp:TextBox ID="txtur" runat="server" TextMode="MultiLine" Width="170px" 
             Height="26px" MaxLength="200"></asp:TextBox></td>
         <%--&nbsp;&nbsp;--%><td>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                 ControlToValidate="txtur" ErrorMessage="Please Enter a valid URL" 
                 ForeColor="#666666" 
                 ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" 
                 ValidationGroup="val"></asp:RegularExpressionValidator>
             &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                 ControlToValidate="txtur" ErrorMessage="Field is empty" ValidationGroup="val"></asp:RequiredFieldValidator>
         </td></tr>
        <tr><td>
            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Method"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtmeth" runat="server" Width="170px" Height="26px"></asp:TextBox>
            </td><td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtmeth" ErrorMessage="Please enter  method" 
                    ValidationGroup="val"></asp:RequiredFieldValidator>
            </td></tr>
            <tr><td>
                <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Connectives"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtcon" runat="server" Width="170px"></asp:TextBox>
                </td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtcon" ErrorMessage="Please enter the connectives" 
                        ValidationGroup="val"></asp:RequiredFieldValidator>
                </td></tr>
       <%-- <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       --%>
       <tr>
           <td>
               <asp:Label ID="txtunm" runat="server" ForeColor="Black" Text="Username"></asp:Label>
           </td>
           <td>
               <asp:TextBox ID="txtun" runat="server" Height="26px" Width="170px"></asp:TextBox>
           </td>
           <%--&nbsp;--%>
           <td>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                   ControlToValidate="txtun" ErrorMessage="Field Can't be empty" 
                   ForeColor="#666666" ValidationGroup="val"></asp:RequiredFieldValidator>
           </td>
            </tr>
       
       <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       --%><tr><td><asp:Label ID="lablps" runat="server" ForeColor="Black" Text="Password"></asp:Label></td><td> 
         <asp:TextBox ID="txtps" runat="server" MaxLength="10" Width="170px" 
            TextMode="Password" Height="26px"></asp:TextBox></td>
<%--&nbsp;--%><td><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="txtps" 
            ErrorMessage="Password Length must be between 7 to 10 characters" 
            ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{7,10}$" ValidationGroup="val"></asp:RegularExpressionValidator>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                 ControlToValidate="txtps" ErrorMessage="Field Can't be  empty" 
                 ValidationGroup="val"></asp:RequiredFieldValidator>
       </td></tr> 
        <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        --%><tr><td><asp:Label ID="lblcp" runat="server" ForeColor="Black" Text="Confirm Password"></asp:Label></td><td>
        <asp:TextBox ID="txtcp" runat="server" Width="170px" TextMode="Password" 
             Height="26px"></asp:TextBox></td>
        <%--&nbsp;&nbsp;--%>
        <td><asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtps" ControlToValidate="txtcp" 
            ErrorMessage="password does not match" ValidationGroup="val"></asp:CompareValidator>
        </td></tr>
       <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <caption>
    --%>    
    <%-- </caption>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    --%> 
     <caption>
         <br />
         
         <tr>
             <td>
             </td>
             <td>
                 <asp:Button ID="btnreg" runat="server" onclick="btnreg_Click" Text="Register" 
                     ValidationGroup="val" />
             <%--<caption>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <td>
             --%>        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%--<caption>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <td>
             --%><%--<caption>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <td>
             --%><asp:Button ID="btncl" runat="server" Text="Cancel" Width="70px" 
                     onclick="btncl_Click" ViewStateMode="Enabled" />
                 </td>
                     <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       --%>
         </tr>
     </caption>
        </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
   
</asp:Panel>
</asp:Content>

