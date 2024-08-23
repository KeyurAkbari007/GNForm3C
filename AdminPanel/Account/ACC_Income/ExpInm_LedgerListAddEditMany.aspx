<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ExpInm_LedgerListAddEditMany.aspx.cs" Inherits="GNForm3C.ExpInm_LedgerListAddEditMany" %>

<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Income " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>

<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upMST_Income" runat="server" EnableViewState="true" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
        <ContentTemplate>

            <div class="row">
                <div class="col-md-12">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </div>
            </div>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label ID="lblFormHeader" runat="server" Text="Income Add/Edit"></asp:Label>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblHospitalID" runat="server" Text="Hospital"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblFinYearID" runat="server" Text="Financial Year"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select Financial Year" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%-- <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblIncomeTypeID" runat="server" Text="Income Type"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlIncomeTypeID" AutoPostBack="True" Enabled="false" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvIncomeTypeID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlIncomeTypeID" ErrorMessage="Select Income Type" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>

                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnShow" runat="server" CssClass="btn green" OnClick="btnShow_Click" Text="Show" />
                                        <asp:HyperLink ID="hlCancel1" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                        <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                        <label class="control-label">&nbsp;</label>
                                    </div>

                                </div>

                                <div class="portlet-body">
                                    <div class="row" runat="server">
                                        <div class="col-md-12">
                                            <div id="TableContent">
                                                <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">

                                                    <thead>
                                                        <tr class="TRDark">
                                                            <th class="text-center" style="width: 20px;">
                                                                <asp:Label ID="lblIsSelected" runat="server" Text="IsSelected"></asp:Label>
                                                            </th>
                                                            <th class="text-center" style="width: 20px;">
                                                                <asp:Label ID="lblSr" runat="server" Text="Sr."></asp:Label>
                                                            </th>

                                                            <th class="text-center" style="width: 150px;">
                                                                <asp:Label ID="lblIncomeDate" runat="server" Text="IncomeDate"></asp:Label>
                                                            </th>

                                                            <th>
                                                                <asp:Label ID="lblincometypeddl" runat="server" Text="IncomeType"></asp:Label>
                                                            </th>

                                                            <th class="text-center" style="width: 150px;">
                                                                <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lblNote" runat="server" Text=" Note"></asp:Label>
                                                            </th>


                                                        </tr>
                                                    </thead>
                                                    <%-- END Table Header --%>

                                                    <tbody>
                                                        <asp:Repeater ID="rpData" runat="server" OnItemDataBound="rpData_ItemDataBound">
                                                            <ItemTemplate>
                                                                <%-- Table Rows --%>
                                                                <tr class="odd gradeX">
                                                                    <td class="text-center">
                                                                        <asp:CheckBox runat="server" ID="chkIsSelected" Checked='<%#Eval("IncomeID").ToString().Trim() == String.Empty ? false : true %>' />
                                                                        <asp:HiddenField ID="hdIncomeID" runat="server" Value='<%#Eval("IncomeID ") %>' />

                                                                    </td>
                                                                    <td class="text-center">
                                                                        <%#Container.ItemIndex+1 %>
                                                                    </td>
                                                                    <td>
                                                                        <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                                                            <asp:TextBox ID="dtpIncomeDate" CssClass="form-control" runat="server" placeholder="Income Date" Text='<%#Eval("IncomeDate", "{0:dd-mm-yyyy}") %>'></asp:TextBox>
                                                                            <span class="input-group-btn">
                                                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                                            </span>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlIncomeTypeID" AutoPostBack="True" Enabled="false" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" Text='<%#Eval("Amount") %>' PlaceHolder="Enter Amount"></asp:TextBox>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Text='<%#Eval("Remarks") %>' PlaceHolder="Enter Remarks"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" Text='<%#Eval("Note") %>' PlaceHolder="Enter Note"></asp:TextBox>
                                                                    </td>


                                                                </tr>

                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="form-actions" runat="server">
                                            <div class="row">
                                                <div class="col-md-offset-1 col-md-9">

                                                    <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="lbtnAddRow" Visible="true">
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn green" SkinID="btnSave" OnClick="btnSave_Click" Text="Save" />
                                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text="Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
