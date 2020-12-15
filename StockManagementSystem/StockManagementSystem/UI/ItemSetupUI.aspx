<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagementSystem.UI.ItemSetup" %>

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
    <form id="itemForm" runat="server">
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
                        <a href="StockInUI.aspx">Stock In</a>
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
            <legend>Item Setup</legend>
            <table  class="display" style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="categoryDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="companyDropDownList" CssClass="form-control"  runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="itemNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="reorderLevelTextBox" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <asp:Label ID="messageLabel" CssClass="text-success" runat="server" Text=""></asp:Label>
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


            $("#itemForm").validate({
                rules: {
                    //categoryDropDownList: "required",
                    companyDropDownList: "required",
                    itemNameTextBox: "required"
                },
                messages: {
                    //categoryDropDownList: {
                    //    required:"Please select a category "
                    //},
                    companyDropDownList: "Please select a company ",
                    itemNameTextBox: "Please enter a item name"
                   
                    
                }
                
        });
        });
    </script>
</body>
</html>


 

