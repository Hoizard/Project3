<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcMortgage.aspx.cs" Inherits="Project3.CalcMortgage" %>

<%@ Register Src="~/SiteNavigation.ascx" TagPrefix="uc1" TagName="SiteNavigation" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:SiteNavigation runat="server" ID="SiteNavigation" />
            <h2>Calculate Mortgage Monthly Payment</h2>
        </div>
        <p>
            Please enter the principle amount</p>
        <p>
            &nbsp;</p>
        <p>
            Please enter the loan duration in years<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>15 Years</asp:ListItem>
                <asp:ListItem>30 Years</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="OtherInterest" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
</html>
