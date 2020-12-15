<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystem.UI.StockOutUI" %>

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
    <form id="stockOutForm" runat="server">
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
                        <a href="SearchAndViewItemsUI.aspx">Search and View Items</a>
                    </div>
                    <div class="anc">
                        <a href="ViewSalesBetweenTwoDatesUI.aspx">View Sales Between Two Dates</a>
                    </div>
                    </div>
                     <div class="col-lg-9 col-md-9 right-side">
        <fieldset>
            <legend>StockOut</legend>
            <table class="display" style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="companyDropDownList" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_OnSelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="itemDropDownList" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_OnSelectedIndexChanged"></asp:DropDownList>
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
                        <asp:TextBox ID="availableQuantityTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="stockOutQuantityTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="addButton" CssClass="btn btn-secondary" runat="server" Text="Add" OnClick="addButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="messageLevel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="stockOutGridView" class="display" style="width:100%" runat="server" AutoGenerateColumns="False" Width="103px">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label ID="itemNameLabel" runat="server" Text='<%#Eval("Item") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label ID="companyNameLabel" runat="server" Text='<%#Eval("Company") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="stockOutQuantityLabel" runat="server" Text='<%#Eval("StockOutQuantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table class="table table-responsive-md">
                 <tr>
                    
                    <td>
                        <asp:Button CssClass="btn btn-secondary" ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" />
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-secondary" ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" />
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-secondary" ID="lostButton" runat="server" Text="Lost" OnClick="lostButton_Click" />
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
    <script src="../DataTables-1.10.20/js/jquery.dataTables.min.js"></script>
    <script>
        $(function() {
           
            $("#stockOutForm").validate({
                rules: {
                    
                    stockOutQuantityTextBox: "required"
                },
                messages: {
                    stockOutQuantityTextBox: "Please enter quantity"

                }
            });
            $('#stockOutGridView').DataTable();
        });
    </script>
</body>
</html>
