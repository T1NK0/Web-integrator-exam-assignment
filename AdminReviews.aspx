<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBackend.master" AutoEventWireup="true" CodeFile="AdminReviews.aspx.cs" Inherits="AdminReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-10" style="float: right;">
        <div class="col-lg-12">
            <h1>Alle Anmeldelser</h1>
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Tittel</th>
                        <th class="col-lg-2">Anmeldelse</th>
                        <th class="col-lg-2">Dato</th>
                        <th class="col-lg-2">Album</th>
                        <th class="col-lg-2">Album Cover</th>
                        <th class="col-lg-1">ret</th>
                        <th class="col-lg-1">slet</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_Accept_Deny_Reviews" runat="server" OnItemCommand="Repeater_Accept_Deny_Reviews_ItemCommand" DataSourceID="SqlDataSource_Accept_Deny_Reviews">
                <ItemTemplate>
                    <table class="table table-hover">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("Review_title") %></td>
                            <td class="col-lg-2"><%#Eval ("Review_text") %></td>
                            <td class="col-lg-2"><%#Eval ("Review_date") %></td>
                            <td class="col-lg-2"><%#Eval ("Album_name") %></td>
                            <td class="col-lg-1">
                                <img src="Images/50x50/<%#Eval ("Album_img") %>" /></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_Accepter" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("Review_id") %>' CommandName="Accept">Accepter</asp:LinkButton></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("Review_id") %>' CommandName="Deny">Deny</asp:LinkButton></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_slet" class="btn btn-danger" runat="server" CommandArgument='<%#Eval ("Review_id") %>' CommandName="Slet">Slet</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Accept_Deny_Reviews" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Review.*, Review.fk_album_id AS Expr1, Albums.* FROM Albums INNER JOIN Review ON Albums.Album_id = Review.fk_album_id"></asp:SqlDataSource>
        </div>
        
        <div class="col-lg-12"><hr /></div>

        <div class="col-lg-12">
            <h1>Godkendte Anmeldelser</h1>
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Anmeldelse Tittel</th>
                        <th class="col-lg-4">Anmeldelse</th>
                        <th class="col-lg-2">Dato</th>
                        <th class="col-lg-2">Album Navn</th>
                        <th class="col-lg-2">Album_img</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_Show_Accepted_Reviews" runat="server" DataSourceID="SqlDataSource_Show_Accepted_Reviews">
                <ItemTemplate>
                    <table class="table">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("Review_title") %></td>
                            <td class="col-lg-4"><%#Eval ("Review_text") %></td>
                            <td class="col-lg-2"><%#Eval ("Review_date") %></td>
                            <td class="col-lg-2"><%#Eval ("Album_name") %></td>
                            <td class="col-lg-2">
                                <img src="Images/50x50/<%#Eval ("Album_img") %>" /></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Show_Accepted_Reviews" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Albums.Album_id, Genre.Genre_name, Albums.Album_artist, Albums.Album_img, Albums.Album_price, Albums.Album_name, Genre.Genre_id, Albums.Album_postdate, Review.* FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id INNER JOIN Review ON Albums.Album_id = Review.fk_album_id WHERE (Review.fk_confirm_id = 1) ORDER BY Albums.Album_postdate DESC"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

