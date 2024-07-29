<%@ Page Title="Ledger List" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ExpInm_LedgerList.aspx.cs" Inherits="AdminPanel_Account_ACC_Expense_ExpInm_LedgerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="~/Content/styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="ExpInm_LedgerList"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Account"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <ul class="breadcrumb">
        <li><a href="#">Home</a></li>
        <li><a href="#">Expense</a></li>
        <li class="active">Ledger List</li>
    </ul>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN FILTER FORM -->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <span class="caption-subject font-green-sharp bold uppercase">Filters</span>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <!-- Existing Filters -->
                <div class="form-group">
                    <label for="FromDate" class="col-sm-2 control-label">From Date:</label>
                    <div class="col-sm-4">
                        <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                            <asp:TextBox ID="FromDate" CssClass="form-control" runat="server" placeholder="From Date"></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ToDate" class="col-sm-2 control-label">To Date:</label>
                    <div class="col-sm-4">
                        <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                            <asp:TextBox ID="ToDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                            </span>
                        </div>
                    </div>
                </div>
                <!-- New Filter for Type -->
                <div class="form-group">
                    <label for="Type" class="col-sm-2 control-label">Type:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="Type" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Select Type" Value=""></asp:ListItem>
                            <asp:ListItem Text="Expense" Value="Expense"></asp:ListItem>
                            <asp:ListItem Text="Income" Value="Income"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- Existing Controls -->
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="ShowButton" runat="server" CssClass="btn btn-primary" Text="Show" OnClick="ShowButton_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- END FILTER FORM -->

    <!-- BEGIN RESULTS TABLE -->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <span class="caption-subject font-green-sharp bold uppercase">Ledger Records</span>
            </div>
            <div class="form-group">
                <%--<div class="col-sm-offset-2 col-sm-10">
        <asp:Button ID="btnDeleteSelected" runat="server" CssClass="btn btn-danger" Text="Delete Selected" OnClick="btnDeleteSelected_Click" />
    </div>--%>
            </div>
        </div>
        <div class="portlet-body">
            <asp:GridView ID="gvLedgerList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" OnRowDataBound="gvLedgerList_RowDataBound" ShowFooter="True" DataKeyNames="LedgerID">
                <Columns>

                    <%-- <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>--%>


                    <asp:BoundField DataField="LedgerDate" HeaderText="Date" SortExpression="LedgerDate" />
                    <asp:BoundField DataField="LedgerType" HeaderText="Type" SortExpression="LedgerType" />
                    <asp:BoundField DataField="LedgerAmount" HeaderText="Amount" SortExpression="LedgerAmount" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="LedgerNote" HeaderText="Note" SortExpression="LedgerNote" />
                </Columns>
                <FooterStyle BackColor="LightGray" Font-Bold="True" />
            </asp:GridView>



        </div>
    </div>


    <!-- END RESULTS TABLE -->
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
