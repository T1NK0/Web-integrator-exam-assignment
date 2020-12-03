<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBackend.master" AutoEventWireup="true" CodeFile="AdminGenre.aspx.cs" Inherits="AdminGenre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-10" style="float: right;">
        <div class="col-lg-12">
            <asp:Panel ID="Panel_Edit" runat="server" Visible="false">
                <div class="col-lg-6">
                    Genre navn:
            <asp:TextBox ID="TextBox_GenreName" placeholder="Navn" class="form-control" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button_Gem_Ret" runat="server" CssClass="btn btn-success" Text="Gem" OnClick="Button_Gem_Ret_Click" />
                </div>

                <hr />
            </asp:Panel>
        </div>

        <div class="col-lg-12">
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Navn</th>
                        <th class="col-lg-1">ret</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_EditGenre" runat="server" OnItemCommand="Repeater_EditGenre_ItemCommand" DataSourceID="SqlDataSource_EditGenre">
                <ItemTemplate>
                    <table class="table table-hover">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("Genre_name") %></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_ret" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("Genre_id") %>' CommandName="Edit">Ret</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_EditGenre" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [Genre]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

