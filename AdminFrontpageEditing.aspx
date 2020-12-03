<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBackend.master" AutoEventWireup="true" CodeFile="AdminFrontpageEditing.aspx.cs" Inherits="AdminFrontpageEditing" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-10" style="float: right;">
        <asp:Panel ID="Panel_EditFrontpage" runat="server" Visible="false">
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <asp:TextBox ID="TextBox_Title" placeholder="Overskrift" class="form-control" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="TextBox_Text" placeholder="Tekst" class="form-control" runat="server" TextMode="MultiLine" Width="100%" Height="300px"></asp:TextBox><br />
                    <asp:Button ID="Button_Gem_Ret" runat="server" CssClass="btn btn-success" Text="Gem" OnClick="Button_Gem_Ret_Click" />
                </div>
                <hr />
            </div>
        </asp:Panel>

        <div class="col-lg-12">
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Velkomst Overskrift</th>
                        <th class="col-lg-8">Velkomst Tekst</th>
                        <th class="col-lg-1">ret</th>
                        <th class="col-lg-1">slet</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_Ret_WelcomeText" runat="server" OnItemCommand="Repeater_Ret_WelcomeText_ItemCommand" DataSourceID="SqlDataSource_Ret_WelcomeText">
                <ItemTemplate>
                    <table class="table table-hover">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("Welcome_heading") %></td>
                            <td class="col-lg-8"><%#Eval ("Welcome_text") %></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_ret" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("Welcome_id") %>' CommandName="Ret">Ret</asp:LinkButton></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_slet" class="btn btn-danger" runat="server" CommandArgument='<%#Eval ("Welcome_id") %>' CommandName="Slet">Slet</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Ret_WelcomeText" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [Welcome_Text]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

