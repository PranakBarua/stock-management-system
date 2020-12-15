<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesBetweenTwoDatesUI.aspx.cs" Inherits="StockManagementSystem.UI.ViewSalesBetweenTwoDatesUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Scripts/jquery-ui-1.12.1.custom/jquery-ui.css" rel="stylesheet" />
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
    <form id="viewSalesBetweenTwoDatesForm" runat="server">
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
                        <a href="StockInUI.aspx">Stock In</a>
                    </div>
                    <div class="anc">
                        <a href="StockOutUI.aspx">Stock Out</a>
                    </div>

                    <div class="anc">
                        <a href="SearchAndViewItemsUI.aspx">Search and View Items</a>
                    </div>
                    </div>
                    <div class="col-lg-9 col-md-9 right-side">
        <fieldset>
            <legend>View Sales Between Two Dates</legend>
            <table class="display" style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="fromDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="toDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="searchButton" CssClass="btn btn-secondary" runat="server" Text="Search" OnClick="searchButton_Click" />
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
        <asp:GridView ID="viewSalesBetweenTwoDatesGridView" class="display" style="width:100%" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Item") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Sale Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("StockOutQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                </div>
            </div>
        </div>
    <div>
         
    </div>
    </form>
    <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
    <script src="../DataTables-1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script>
        $(function () {
            $("#viewSalesBetweenTwoDatesForm").validate({
                rules: {
                    fromDateTextBox: "required",
                    toDateTextBox: "required"
                },
                messages: {
                    fromDateTextBox: "Please select a date",
                    toDateTextBox: "Please select a date"
                }
            });
            $("#fromDateTextBox").datepicker();
            $("#toDateTextBox").datepicker();
            $('#viewSalesBetweenTwoDatesGridView').DataTable();
        });
  </script>
</body>
</html>
