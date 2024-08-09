<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="STU_StudentAddEditPopUp.aspx.cs" Inherits="AdminPanel_Master_MST_Student_MST_StudentAddEditPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server" />
    <asp:UpdatePanel ID="upSTU_Student" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server"/> 
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server" />
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text="" />
                        </span>
                    </div>
                    <div class="tools">
                        <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static" />
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <!-- Student Name -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblStudentName" runat="server" Text="Student Name" />
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtStudentName" CssClass="form-control" runat="server" PlaceHolder="Enter Student Name" />
                                    <asp:RequiredFieldValidator ID="rfvStudentName" ControlToValidate="txtStudentName" Display="Dynamic" runat="server" ErrorMessage="Enter Student Name" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>

                            <!-- Enrollment No -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEnrollmentNo" runat="server" Text="Enrollment No" />
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEnrollmentNo" CssClass="form-control" runat="server" PlaceHolder="Enter Enrollment No" />
                                    <asp:RequiredFieldValidator ID="rfvEnrollmentNo" ControlToValidate="txtEnrollmentNo" Display="Dynamic" runat="server" ErrorMessage="Enter Enrollment No" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>

                            <!-- Current Sem -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblCurrentSem" runat="server" Text="Current Sem" />
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlCurrentSem" CssClass="form-control select2me" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvCurrentSem" ControlToValidate="ddlCurrentSem" Display="Dynamic" runat="server" ErrorMessage="Select Current Sem" InitialValue="-99" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>

                            <!-- Email Institute -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblEmailInstitute" runat="server" Text="Email Institute" />
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEmailInstitute" CssClass="form-control" runat="server" PlaceHolder="Enter Email Institute" />
                                </div>
                            </div>

                            <!-- Email Personal -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEmailPersonal" runat="server" Text="Email Personal" />
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEmailPersonal" CssClass="form-control" runat="server" PlaceHolder="Enter Email Personal" />
                                    <asp:RequiredFieldValidator ID="rfvEmailPersonal" ControlToValidate="txtEmailPersonal" Display="Dynamic" runat="server" ErrorMessage="Enter Email Personal" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>

                            <!-- Gender -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblGender" runat="server" Text="Gender" />
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlGender" CssClass="form-control select2me" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvGender" ControlToValidate="ddlGender" Display="Dynamic" runat="server" ErrorMessage="Select Gender" InitialValue="-99" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>

                            <!-- Roll No -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRollNo" runat="server" Text="Roll No" />
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtRollNo" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter RollNo" />
                                </div>
                            </div>

                            <!-- Birth Date -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date" />
                                </label>
                                <div class="col-md-5">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpBirthDate" CssClass="form-control" runat="server" placeholder="Birth Date" />
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvBirthDate" ControlToValidate="dtpBirthDate" Display="Dynamic" runat="server" ErrorMessage="Enter Birth Date" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>

                            <!-- Contact No -->
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact No" />
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server" PlaceHolder="Enter Contact No" />
                                    <asp:RequiredFieldValidator ID="rfvContactNo" ControlToValidate="txtContactNo" Display="Dynamic" runat="server" ErrorMessage="Enter Contact No" ValidationGroup="vgStudent" EnableClientScript="true" />
                                </div>
                            </div>
                        </div>
                        
                        <!-- Form Actions -->
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" ValidationGroup="vgStudent" CausesValidation="true" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Student/MST_StudentList.aspx" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                $("#CloseButton").trigger("click");
            }
        });

        $(document).ready(function () {
            $("#<%= btnSave.ClientID %>").click(function (event) {
                if (!Page_ClientValidate('vgStudent')) {
                    event.preventDefault();
                }
            });
        });
    </script>
</asp:Content>

