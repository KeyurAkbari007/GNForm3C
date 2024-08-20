<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="HospitalWisePatientWiseTransaction.aspx.cs" Inherits="AdminPanel_Reports_RPT_ACC_GNTransaction_RPT_ACC_GNTransactionPatientReceipt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <div>
        <rsweb:ReportViewer ID="rvPatientReceipt" runat="server" Width="100%" Height="800px">
            <LocalReport ReportPath="AdminPanel\Reports\HospitalWisePatientWiseTransaction\HospitalWisePatientWiseTransaction.rdlc"></LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
