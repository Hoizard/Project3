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
            Please enter the principle amount<asp:TextBox ID="PrincipleAmount" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Please enter the loan duration in years<asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                <asp:ListItem Value="15">15 Years</asp:ListItem>
                <asp:ListItem Value="30">30 Years</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="OtherYears" runat="server"></asp:TextBox>
        </p>
        <p>
            Please Select the interest rate<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="ComputeMortgage" runat="server" OnClick="ComputeMortgage_Click" Text="Monthly Payment" />
        </p>
        <asp:Label ID="ResultPayment" runat="server"></asp:Label>
    </form>
</body>
</html>
