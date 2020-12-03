<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="MusicShop.aspx.cs" Inherits="Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <div class="col-lg-12">
            <h1>Sorterings Mulighedder:</h1>
            <asp:LinkButton ID="LinkButton_OrderBy_Aritst" runat="server" OnClick="LinkButton_OrderBy_Aritst_Click" CssClass="btn btn-default">Kunstner</asp:LinkButton>
            <asp:LinkButton ID="LinkButton_OrderBy_Album" runat="server" OnClick="LinkButton_OrderBy_Album_Click" CssClass="btn btn-default">Album</asp:LinkButton>
            <asp:LinkButton ID="LinkButton_OrderBy_Genre" runat="server" OnClick="LinkButton_OrderBy_Genre_Click" CssClass="btn btn-default">Genre</asp:LinkButton>
            <asp:LinkButton ID="LinkButton_OrderBy_Newest" runat="server" OnClick="LinkButton_OrderBy_Newest_Click" CssClass="btn btn-default">Nyeste</asp:LinkButton>
        </div>

        <div class="col-lg-12">
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
                                <a href="Album.aspx?Album_id=<%#Eval("Album_id") %>&Genre_id=<%#Eval ("Genre_id") %>&Album_price=<%#Eval ("Album_price") %>">
                                    <img src="Images/50x50/<%#Eval ("Album_img") %>" />
                                </a>
                            </td>
                            <td class="col-lg-2"><%#Eval ("Album_price") %></td>
                            <td class="col-lg-3"><%#Eval ("Album_postdate") %></td>
                            <td class="col-lg-1">
                                <a href="Album.aspx?Album_id=<%#Eval("Album_id") %>&Genre_id=<%#Eval ("Genre_id") %>&Album_price=<%#Eval ("Album_price") %>" class="btn btn-default">Læs Mere</a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Literal ID="Literal_Pager" runat="server"></asp:Literal>
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

