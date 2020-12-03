<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <div class="col-lg-12">
            <h1>Albummer med anmeldelser</h1>
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Navn</th>
                        <th class="col-lg-2">Artist</th>
                        <th class="col-lg-2">Billede</th>
                        <th class="col-lg-2">Pris</th>
                        <th class="col-lg-3">Oprettelse</th>
                        <th class="col-lg-1">Læs Mere</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="RepeaterAlbums" runat="server">
                <ItemTemplate>
                    <table class="table">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("Album_Name") %></td>
                            <td class="col-lg-2"><%#Eval ("Album_artist") %></td>
                            <td class="col-lg-2">
                                <img src="Images/50x50/<%#Eval ("Album_img") %>" /></td>
                            <td class="col-lg-2"><%#Eval ("Album_price") %></td>
                            <td class="col-lg-3"><%#Eval ("Album_postdate") %></td>
                            <td class="col-lg-1">
                                <a href="Reviews.aspx?Album_id=<%#Eval("Album_id") %>&Genre_id=<%#Eval ("Genre_id") %>" class="btn btn-default">Læs Mere</a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="Literal_Pager" runat="server"></asp:Literal>
        </div>

        <div class="col-lg-12">
            <asp:Panel ID="Panel_Your_Reviews" runat="server" Visible="false">
            <h1>Anmeldelser af albummet</h1>
                <table class="table">
                    <thead>
                        <tr>
                            <th class="col-lg-2">Tittel</th>
                            <th class="col-lg-2">Anmeldelse</th>
                            <th class="col-lg-2">Dato</th>
                            <th class="col-lg-2">Album</th>
                            <th class="col-lg-2">Bruger Som har Anmeldt</th>
                            <th class="col-lg-2">Album Cover</th>
                        </tr>
                    </thead>
                </table>
                <asp:Repeater ID="Repeater_User_Reviews" runat="server" DataSourceID="SqlDataSource_User_Reviews">
                    <ItemTemplate>
                        <table class="table">
                            <tr>
                                <td class="col-lg-2"><%#Eval ("Review_title") %></td>
                                <td class="col-lg-2"><%#Eval ("Review_text") %></td>
                                <td class="col-lg-2"><%#Eval ("Review_date") %></td>
                                <td class="col-lg-2"><%#Eval ("Album_name") %></td>
                                <td class="col-lg-2"><%#Eval ("User_name") %></td>
                                <td class="col-lg-2">
                                    <img src="Images/50x50/<%#Eval ("Album_img") %>" /></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource_User_Reviews" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Review.Review_id, Review.Review_title, Review.Review_text, Review.Review_date, Review.fk_album_id, Review.fk_user_id, Review.fk_confirm_id, Users.User_name, Users.User_id, Review.fk_user_id AS Expr1, Albums.Album_id, Albums.Album_name, Albums.Album_img FROM Users INNER JOIN Review ON Users.User_id = Review.fk_user_id INNER JOIN Albums ON Review.fk_album_id = Albums.Album_id WHERE (Albums.Album_id = @Album_id)">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="Album_id" Name="Album_id"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
                </asp:Panel>
        </div>
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

