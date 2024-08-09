<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard2.aspx.cs" Inherits="AdminPanel_Dashboard2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Master Dashboard" runat="server"></asp:Label>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>2
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ShowMessage" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblFinYearID_XXXXX" runat="server" Text="FinYear"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="displayChange"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select FinYear" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>
    <%-- Dashboard --%>
    <asp:UpdatePanel ID="Dashboard" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upDashboard" runat="server" UpdateMode="Conditional" Visible="false" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row" id="displayContent" runat="server">
                        <div class="col-md-12">

                            <asp:UpdatePanel ID="upCount" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption font-green">
                                                <i class="fa fa-line-chart font-green"></i>
                                                <span class="caption-subject bold uppercase">Total Overview</span>
                                            </div>
                                            <div class="tools"></div>
                                        </div>
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                                            <a class="dashboard-stat dashboard-stat-v2 blue" href='<%= "Account/ACC_Income/ACC_IncomeList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlFinYearID.SelectedValue.ToString())%>'>

                                                                <%--<a class="dashboard-stat dashboard-stat-v2 blue" href='<%# "~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(ddlFinYearID.SelectedValue.ToString()) %>'>--%>
                                                                <div class="visual">
                                                                    <i class="fa fa-comments"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblIncomeCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Incomes </div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                                            <a class="dashboard-stat dashboard-stat-v2 red" href='<%= "Account/ACC_Expense/ACC_ExpenseList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlFinYearID.SelectedValue.ToString())%>'>
                                                                <div class="visual">
                                                                    <i class="fa fa-list"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblExpenseCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Expenses</div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                                            <a class="dashboard-stat dashboard-stat-v2 green" href='<%= "Master/MST_SubTreatment/MST_SubTreatmentList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlFinYearID.SelectedValue.ToString())%>'>
                                                                <div class="visual">
                                                                    <i class="fa fa-shopping-cart"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblDifferenceCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Difference Income/Expense </div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpList" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet">
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="upTabview" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet">
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box yellow">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-h-square "></i></i>  TabView
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">
                                                                    <div class="tools ">
                                                                        <ul class="nav nav-tabs">
                                                                            <li class="active">
                                                                                <asp:LinkButton ID="lbtnCol" runat="server" href="#tab_Inc_CategoryWiseIncomeTotalList" Text="CategoryWiseIncomeTotalList" data-toggle="tab"></asp:LinkButton>
                                                                            </li>
                                                                            <li class="">
                                                                                <asp:LinkButton ID="LinkButton3" runat="server" href="#tab_Inc_CategoryWiseExpenseTotalList" Text="CategoryWiseExpenseTotalList" data-toggle="tab"></asp:LinkButton>
                                                                            </li>
                                                                            <li class="">
                                                                                <asp:LinkButton ID="LinkButton4" runat="server" href="#tab_Inc_HospitalWisePatientCountList" Text="HospitalWisePatientCountList" data-toggle="tab"></asp:LinkButton>
                                                                            </li>
                                                                            <li class="">
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" href="#tab_Inc_AccountTranscationList" Text="AccountTranscationList" data-toggle="tab"></asp:LinkButton>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                    <div class="portlet-body table-both-scroll">
                                                                        <div class="portlet light ">
                                                                            <div class="portlet-body">
                                                                                <div class="tab-content">

                                                                                    <div class="tab-pane active" id="tab_Inc_CategoryWiseIncomeTotalList">
                                                                                        <asp:Label ID="lblNoCategoryWiseIncomeTotalListRecords" runat="server" Text="No Records Found" Visible="false" CssClass="text-danger" />

                                                                                        <div id="CategoryWiseIncomeTotalList" runat="server">
                                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                                                <%-- Table Header --%>
                                                                                                <thead>
                                                                                                    <tr class="TRDark">
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label runat="server" Text="Sr."></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="lbhIncomeType" runat="server" Text="Income Type"></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="lbhTotal" runat="server" Text="Total"></asp:Label>
                                                                                                        </th>


                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <%-- END Table Header --%>

                                                                                                <tbody>
                                                                                                    <asp:Repeater ID="rpCategoryWiseIncomeTotalList" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <%-- Table Rows --%>
                                                                                                            <tr class="odd gradeX">
                                                                                                                <td>
                                                                                                                    <%# Container.ItemIndex + 1 %>
                                                                                                                </td>
                                                                                                                <td class="">
                                                                                                                    <%#Eval("IncomeType")%>
                                                                                                                </td>
                                                                                                                <td class="text-right">
                                                                                                                    <%#Eval("Total", GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <%-- END Table Rows --%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="tab-pane" id="tab_Inc_CategoryWiseExpenseTotalList">
                                                                                        <asp:Label ID="lblNoCategoryWiseExpenseTotalListRecords" runat="server" Text="No Records Found" Visible="false" CssClass="text-danger" />

                                                                                        <div id="CategoryWiseExpenseTotalList" runat="server">

                                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                                                <%-- Table Header --%>
                                                                                                <thead>
                                                                                                    <tr class="TRDark">
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label runat="server" Text="Sr."></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="lblExpenseType" runat="server" Text="Expense Type"></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                                                                                        </th>


                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <%-- END Table Header --%>

                                                                                                <tbody>
                                                                                                    <asp:Repeater ID="rpCategoryWiseExpenseTotalList" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <%-- Table Rows --%>
                                                                                                            <tr class="odd gradeX">
                                                                                                                <td>
                                                                                                                    <%# Container.ItemIndex + 1 %>
                                                                                                                </td>
                                                                                                                <td class="">
                                                                                                                    <%#Eval("ExpenseType")%>
                                                                                                                </td>
                                                                                                                <td class="text-right">
                                                                                                                    <%#Eval("Total", GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <%-- END Table Rows --%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="tab-pane" id="tab_Inc_HospitalWisePatientCountList">
                                                                                        <asp:Label ID="lblNoHospitalWisePatientCountListRecords" runat="server" Text="No Records Found" Visible="false" CssClass="text-danger" />

                                                                                        <div id="HospitalWisePatientCountList" runat="server">

                                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                                                <%-- Table Header --%>
                                                                                                <thead>
                                                                                                    <tr class="TRDark">
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="Label6" runat="server" Text="Sr."></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="">
                                                                                                            <asp:Label ID="lblHospital" runat="server" Text="Hospital"></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="lblPatient" runat="server" Text="Patient Count"></asp:Label>
                                                                                                        </th>

                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <%-- END Table Header --%>

                                                                                                <tbody>
                                                                                                    <asp:Repeater ID="rpHospitalWisePatientCountList" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <%-- Table Rows --%>
                                                                                                            <tr class="odd gradeX">
                                                                                                                <td>
                                                                                                                    <%# Container.ItemIndex + 1 %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("Hospital") %>
                                                                                                                </td>
                                                                                                                <td class="text-center">
                                                                                                                    <%#Eval("PatientCount") %>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <%-- END Table Rows --%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="tab-pane" id="tab_Inc_AccountTranscationList">
                                                                                        <asp:Label ID="lblNoAccountTranscationListRecords" runat="server" Text="No Records Found" Visible="false" CssClass="text-danger" />

                                                                                        <div id="AccountTranscationList" runat="server">

                                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                                                <%-- Table Header --%>
                                                                                                <thead>
                                                                                                    <tr class="TRDark">
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="Label1" runat="server" Text="Sr."></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhPatient" runat="server" Text="Patient"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhTreatmentID" runat="server" Text="Treatment"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhAmount" runat="server" Text="Amount"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhSerialNo" runat="server" Text="Serial No"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhReferenceDoctor" runat="server" Text="Reference Doctor"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhCount" runat="server" Text="Count"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhReceiptNo" runat="server" Text="Receipt No"></asp:Label>
                                                                                                        </th>
                                                                                                        <th class="text-center">
                                                                                                            <asp:Label ID="lbhDate" runat="server" Text="Date"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhDateOfAdmission" runat="server" Text="Date Of Admission"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhDateOfDischarge" runat="server" Text="Date Of Discharge"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhDeposite" runat="server" Text="Deposite"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhNetAmount" runat="server" Text="Net Amount"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhNoOfDays" runat="server" Text="No Of Days"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhHospitalID" runat="server" Text="Hospital"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhFinYearID" runat="server" Text="Fin Year"></asp:Label>
                                                                                                        </th>
                                                                                                        <th>
                                                                                                            <asp:Label ID="lbhReceiptTypeID" runat="server" Text="Receipt Type"></asp:Label>
                                                                                                        </th>

                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <%-- END Table Header --%>

                                                                                                <tbody>
                                                                                                    <asp:Repeater ID="rpAccountTranscationList" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <%-- Table Rows --%>
                                                                                                            <tr class="odd gradeX">

                                                                                                                <td>
                                                                                                                    <%# Container.ItemIndex + 1 %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:HyperLink ID="hlViewTransactionID" NavigateUrl='<%# "~/AdminPanel/Account/ACC_Transaction/ACC_TransactionView.aspx?TransactionID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("TransactionID").ToString()) %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("Patient") %></asp:HyperLink>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("Treatment") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithOutDecimalPoint) %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("SerialNo") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("ReferenceDoctor") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("Count") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("ReceiptNo") %>
                                                                                                                </td>
                                                                                                                <td class="text-center">
                                                                                                                    <%#Eval("Date", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("DateOfAdmission") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("DateOfDischarge") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("Deposite") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("NetAmount",GNForm3C.CV.DefaultCurrencyFormatWithOutDecimalPoint) %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("NoOfDays") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("Hospital") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("FinYearName") %>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <%#Eval("ReceiptTypeName") %>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <%-- END Table Rows --%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
                    <%--<asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </ContentTemplate>

    </asp:UpdatePanel>
    <%-- END Dashboard--%>


    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>