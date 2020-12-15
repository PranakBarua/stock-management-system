<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagementSystem.UI.StockInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../DataTables-1.10.20/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../style.css" rel="stylesheet" />
      <style>
        input.error {
            border: 1px solid tomato;
        }
        label.error {
            color: tomato;
        }
    </style>
</head>
<body>
    <form id="stockInForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-3 left-side">
                      <div class="anc">
                        <a href="IndexUI.aspx">Home</a>
                    </div>
                    <div class="anc">
                        <a href="CategorySetupUI.aspx">Category Setup</a>
                   </div>
                   <div class="anc">
                        <a href="CompanySetupUI.aspx">Company Setup</a>
                   </div>
                   <div class="anc">
                        <a href="ItemSetupUI.aspx">Item Setup</a>
                   </div>
                    <div class="anc">
                        <a href="StockOutUI.aspx">Stock Out</a>
                    </div>
                    <div class="anc">
                        <a href="SearchAndViewItemsUI.aspx">Search and View Items</a>
                    </div>
                    <div class="anc">
                        <a href="ViewSalesBetweenTwoDatesUI.aspx">View Sales Between Two Dates</a>
                    </div>
        </div>
        <div class="col-lg-9 col-md-9 right-side">
        <fieldset>
            <legend>Stock In</legend>
            <table  class="display" style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="companyDropDownList" AutoPostBack="True"  CssClass="form-control" OnSelectedIndexChanged="companyDropDownList_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            
                 <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="itemDropDownList" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="itemDropDownList_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="reorderLevelTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="availableQuantityTextBox"  runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Stock In Quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="stockInQuantityTextBox"  CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="saveButton" CssClass="btn btn-secondary" runat="server" Text="Save" OnClick="saveButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>    
                </div>
            </div>
        </div>
    </form>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script>
        $(function () {
            $("#stockInForm").validate({
                rules: {
                    stockInQuantityTextBox: "required"
                },
                messages: {
                    stockInQuantityTextBox: "Please enter quantity"
                }
            });
        });
    </script>
    
</body>
</html>
