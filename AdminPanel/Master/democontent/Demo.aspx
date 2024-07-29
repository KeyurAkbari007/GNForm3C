<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="AdminPanel_DemoTable" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader" runat="server" Text="Demo Table"></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Demo Table"></asp:Label>
    </li>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
     <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-md-12">
            <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
        </div>
    </div>

           <%-- Search --%>
        <asp:UpdatePanel ID="upSearch" runat="server">
            <ContentTemplate>
                <div class="portlet light">
                    <div class="portlet-title">
                        <div class="caption">
                            <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                            <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server" Text="Search Demo Table"></asp:Label>
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse pull-right"></a>
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <div role="form">
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-search"></i>
                                                </span>
                                                <asp:TextBox ID="txtFirstName" CssClass="First form-control" runat="server" PlaceHolder="Enter First Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-search"></i>
                                                </span>
                                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" PlaceHolder="Enter Last Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-9">
                                        <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- End Search --%>

       <%-- <%-- Demo Table --%>
    <%--    <asp:UpdatePanel ID="upDemoTable" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%-- End Demo Table --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-table"></i>Demo Table

                    </div>
                    <div class="tools">
                        <div>
                            <asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Master/democontent/DemoAddEdit.aspx" runat="server"></asp:HyperLink>
                            <%--<div class="btn-group" runat="server" id="Div_ExportOption" visible="false">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>    
                                    </div>--%>
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-advanced table-striped table-hover" id="demoTable">
                            <thead>
                                <tr class="TRDark">
                                    <th>ID</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("ID") %></td>
                                            <td><%# Eval("fname") %></td>
                                            <td><%# Eval("lname") %></td>
                                            <td>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" SkinID="Delete" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" NavigateUrl='<%# "~/AdminPanel/Master/democontent/DemoAddEdit.aspx?ID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("ID").ToString()) %>' runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                    <%-- Pagination --%>
                    <div class="row">
                        <div class="col-md-4">
                            <label class="control-label">
                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label></label>
                        </div>
                        <div class="col-md-5">
                            <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                <ul class="pagination">
                                    <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                        <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage" CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton></li>
                                    <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                        <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton></li>
                                    <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                        <ItemTemplate>
                                            <li>
                                                <li class="paginate_button" id="liPageNo" runat="server">
                                                    <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>' CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></li>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <li class="paginate_button next disabled" id="liNext" runat="server">
                                        <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton></li>
                                    <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                        <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage" CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-3 pull-right">
                            <div class="btn-group" runat="server" id="Div_GoToPageNo">
                                <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)" runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4" MaxLength="9"></asp:TextBox>
                                <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4" CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                            </div>
                            <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                <label class="control-label">Page Size</label>
                                <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall" runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <%-- END Pagination --%>
                </div>
            </div>
        </div>
    </div>
            </ContentTemplate>
              <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                     <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                  </Triggers>
        </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
<%--    <script>

        $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);
    </script>--%>
</asp:Content>
