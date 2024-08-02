<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_StudentAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Student_MST_StudentAddEdit" Title="Student Add/Edit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Student " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Add/Edit" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlStudentList" runat="server" NavigateUrl="~/AdminPanel/Master/MST_Student/MST_StudentList.aspx" Text="Student List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Student Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMST_Student" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text="Student Add/Edit"></asp:Label>
                        </span>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblStudentName_XXXXX" runat="server" Text="Student Name"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtStudentName" CssClass="form-control" runat="server" PlaceHolder="Enter Student Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvStudentName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtStudentName" ErrorMessage="Enter Student Name"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEnrollmentNo_XXXXX" runat="server" Text="Enrollment No"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtEnrollmentNo" CssClass="form-control" runat="server" PlaceHolder="Enter Enrollment No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEnrollmentNo" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtEnrollmentNo" ErrorMessage="Enter Enrollment No"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRollNo_XXXXX" runat="server" Text="Roll No"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtRollNo" CssClass="form-control" runat="server" PlaceHolder="Enter Roll No"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblCurrentSem_XXXXX" runat="server" Text="Current Semester"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlCurrentSem" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCurrentSem" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlCurrentSem" ErrorMessage="Select Current Semester" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblGender_XXXXX" runat="server" Text="Gender"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvGender" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlGender" ErrorMessage="Select Gender" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblEmailInstitute_XXXXX" runat="server" Text="Email Institute"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtEmailInstitute" CssClass="form-control" runat="server" PlaceHolder="Enter Email Institute"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEmailPersonal_XXXXX" runat="server" Text="Email Personal"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtEmailPersonal" CssClass="form-control" runat="server" PlaceHolder="Enter Email Personal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="txtEmailPersonal" ErrorMessage="Select Gender" InitialValue="-1"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblToDate_XXXXX" runat="server" Text="Birth date"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="txtBirthDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Enter To Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblContactNo_XXXXX" runat="server" Text="Contact No"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server" PlaceHolder="Enter Contact No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Enter To Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" Text="Save" />
                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Student/MST_StudentList.aspx" Text="Cancel"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
