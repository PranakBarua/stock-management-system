<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementSystem.UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../DataTables-1.10.20/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3 left-side">
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
                    <div class="anc">
                        <a href="ViewSalesBetweenTwoDatesUI.aspx">View Sales Between Two Dates</a>
                    </div>
            </div>
            <div class="col-lg-9 col-md-9 left-side right-side">
                </div>
        </div>
       
    </div>
    </form>
</body>
</html>
