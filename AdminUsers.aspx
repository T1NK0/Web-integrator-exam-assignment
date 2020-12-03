<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBackend.master" AutoEventWireup="true" CodeFile="AdminUsers.aspx.cs" Inherits="AdminGrunker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-10" style="float: right;">
        <div class="col-lg-12">
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Navn</th>
                        <th class="col-lg-3">Email</th>
                        <th class="col-lg-2">Grunker</th>
                        <th class="col-lg-2">Image</th>
                        <th class="col-lg-1">Tildel 500 Grunker</th>
                        <th class="col-lg-1">Reset Grunker</th>
                        <th class="col-lg-1">slet</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_Delete_Users" runat="server" OnItemCommand="Repeater_Delete_Users_ItemCommand" DataSourceID="SqlDataSource_Delete_Users">
                <ItemTemplate>
                    <table class="table table-hover">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("User_name") %></td>
                            <td class="col-lg-3"><%#Eval ("User_email") %></td>
                            <td class="col-lg-2"><%#Eval ("User_grunker") %></td>
                            <asp:HiddenField ID="HiddenField_img_slet1" runat="server" Value='<%#Eval ("User_img") %>' />
                            <asp:HiddenField ID="HiddenField_Grunker" runat="server" Value='<%#Eval ("User_id") %>' />
                            <td class="col-lg-2">
                                <img src="Images/ProfilePicture/<%#Eval ("User_img") %>" style="width: 50px" /></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_TildelGrunker" class="btn btn-default" runat="server" CommandArgument='<%#Eval ("User_id") %>' CommandName="Tildel">Tildel Grunker</asp:LinkButton></td>
                            <td>
                                <asp:LinkButton ID="LinkButton_ResetGrunker" class="btn btn-default" runat="server" CommandArgument='<%#Eval ("User_id") %>' CommandName="Reset">Reset Grunker</asp:LinkButton>
                                </td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_slet" class="btn btn-danger" runat="server" CommandArgument='<%#Eval ("User_id") %>' CommandName="Slet">Slet</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Delete_Users" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

