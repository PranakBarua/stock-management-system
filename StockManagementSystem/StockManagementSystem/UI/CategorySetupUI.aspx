<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockManagementSystem.UI.CategorySetupUI" %>

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
    <form id="categoryForm" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-3 left-side">
                    <div class="anc">
                        <a href="IndexUI.aspx">Home</a>
                    </div>
                   <div class="anc">
                        <a href="CompanySetupUI.aspx">Company Setup</a>
                   </div>
                   <div class="anc">
                        <a href="ItemSetupUI.aspx">Item Setup</a>
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
            <legend>Category Setup</legend>
            <table id="CategoryTable"  class="display" style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="nameTextBox"  CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="idHiddenField" runat="server" />
                    </td>
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
        <asp:GridView ID="categoryGridView" class="display" style="width:100%" runat="server" OnRowDataBound="categoryGridView_OnRowDataBound" AutoGenerateColumns="False" OnSelectedIndexChanged="categoryGridView_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="idLabel" Value='<%#Eval("Id") %>'/>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="nameLabel" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                </div>
                </div>
            </div>
    </form>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script src="../DataTables-1.10.20/js/jquery.dataTables.min.js"></script>
    <script>
        $(function() {
           
            $("#categoryForm").validate({
                rules: {
                    nameTextBox: "required"
        },
                messages:{
                    nameTextBox: "Please enter a category name"
            }
            });
           
        });
        $('#categoryGridView').DataTable();
    </script>
</body>
</html>
