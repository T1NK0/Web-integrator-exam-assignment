<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBackend.master" AutoEventWireup="true" CodeFile="AdminAlbums.aspx.cs" Inherits="AdminAlbums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-10" style="float: right;">
        <div class="col-lg-12">
            <div class="col-lg-6">
                Navn:
            <asp:TextBox ID="TextBox_Name" placeholder="Navn" class="form-control" runat="server"></asp:TextBox><br />

                Pris:
            <asp:TextBox ID="TextBox_Price" placeholder="Pris" class="form-control" runat="server"></asp:TextBox><br />

                Artist:
            <asp:TextBox ID="TextBox_Artist" placeholder="Artist" class="form-control" runat="server"></asp:TextBox><br />

                Kategori:
            <asp:DropDownList ID="DropDownList_Genres" runat="server"></asp:DropDownList><br />

                <asp:Image ID="Image_Ret1" runat="server" Visible="false" /><br />
                <asp:HiddenField ID="HiddenField_oldImage1" runat="server" />
                <asp:FileUpload ID="FileUpload_Img1" runat="server" /><br />
                <asp:Button ID="Button_Opret" runat="server" class="btn btn-success" Text="Opret Album" OnClick="Button_Opret_Click" />
                <asp:Button ID="Button_Gem_Ret" Visible="false" runat="server" CssClass="btn btn-success" Text="Gem" OnClick="Button_Gem_Ret_Click" />
            </div>
        </div>

        <div class="col-lg-12">
            <hr />
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-2">Navn</th>
                        <th class="col-lg-2">Pris</th>
                        <th class="col-lg-2">Artist</th>
                        <th class="col-lg-2">Genre</th>
                        <th class="col-lg-2">Billede</th>
                        <th class="col-lg-1">ret</th>
                        <th class="col-lg-1">slet</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_Ret_Album" runat="server" OnItemCommand="Repeater_Ret_Journalister_ItemCommand" DataSourceID="SqlDataSource_Ret_Album">
                <ItemTemplate>
                    <table class="table table-hover">
                        <tr>
                            <td class="col-lg-2"><%#Eval ("Album_name") %></td>
                            <td class="col-lg-2"><%#Eval ("Album_price") %></td>
                            <td class="col-lg-2"><%#Eval ("Album_artist") %></td>
                            <td class="col-lg-2"><%#Eval ("Genre_name") %></td>
                            <asp:HiddenField ID="HiddenField_img_slet1" runat="server" Value='<%#Eval ("Album_img") %>' />
                            <td class="col-lg-2">
                                <img src="Images/50x50/<%#Eval ("Album_img") %>" /></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_ret" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("Album_id") %>' CommandName="Ret">Ret</asp:LinkButton></td>
                            <td class="col-lg-1">
                                <asp:LinkButton ID="LinkButton_slet" class="btn btn-danger" runat="server" CommandArgument='<%#Eval ("Album_id") %>' CommandName="Slet">Slet</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Ret_Album" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Genre.Genre_name, Albums.Album_name, Albums.Album_price, Albums.Album_img, Albums.Album_artist, Albums.Album_id FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

