<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_ACC_IncomeByFinYearGroupByMatrix.aspx.cs" Inherits="AdminPanel_Reports_RPT_ACC_IncomeByFinYearGroupByMatrix_RPT_ACC_IncomeByFinYearGroupByMatrix" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
        <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="rvIncomeReport" runat="server" Width="100%" Height="600px">
        <LocalReport ReportPath="E:\gn\BHAVIN_GNWebForm3C_Code_20230213_0731PM\GNWebForm3C_CodeB\AdminPanel\Reports\RPT_ACC_IncomeByFinYearGroupByMatrix\RPT_ACC_IncomeByFinYearMatrix.rdlc"></LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

