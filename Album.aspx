<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="Album.aspx.cs" Inherits="Album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <div class="col-lg-12">
            <div class="col-lg-5">
                <h1>Albums med samme genre</h1>
                <asp:Repeater ID="Repeater_Albums" runat="server">
                    <ItemTemplate>
                        <h3><%#Eval ("Album_name") %></h3>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-6">
                <asp:Repeater ID="Repeater_Album" runat="server" DataSourceID="SqlDataSource_Album">
                    <ItemTemplate>
                        <div class="col-lg-6">
                            <h2><%#Eval ("Album_name") %></h2>
                            <h2><%#Eval ("Genre_name") %></h2>
                            <h2><%#Eval ("Album_price") %></h2>
<%--                            <asp:Panel ID="Panel_Buy_Album" runat="server" Visible="false">
                                <asp:Button ID="ButtonBuy" runat="server" Text="Læg i kurv" class="btn btn-default" Style="width: 50%;" CommandArgument='<%#Eval ("User_id") %>' CommandName="Buy" /><br />
                                <asp:HiddenField ID="HiddenField_Grunker" runat="server" Value='<%#Eval ("User_id") %>' />
                            </asp:Panel>--%>
                            <a href="Reviews.aspx?Album_id=<%#Eval("Album_id") %>&Genre_id=<%#Eval ("Genre_id") %>" class="btn btn-default" style="width: 100%;">Læs Mere</a>
                        </div>

                        <div class="col-lg-6">
                            <img src="Images/200x200/<%#Eval ("Album_img") %>" style="height: 235px;" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource_Album" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Albums.Album_name, Albums.Album_price, Albums.Album_img, Albums.Album_id, Albums.fk_genre_id, Genre.Genre_name, Genre.Genre_id FROM Albums INNER JOIN Genre ON Albums.fk_genre_id = Genre.Genre_id WHERE (Albums.Album_id = @Album_id)">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="Album_id" Name="Album_id"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Literal ID="Literal_Pager" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="col-lg-12">
            <div class="col-lg-6">
                <asp:Label ID="Label_Navn" runat="server" Text="Tittel:"></asp:Label><br />
                <asp:TextBox ID="TextBox_Title" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du skal skrive dit navn!" ControlToValidate="TextBox_Title" ValidationGroup="Review" Display="Static"></asp:RequiredFieldValidator><br />

                <asp:Label ID="Label_Comment" runat="server" Text="Skriv din anmeldelse:"></asp:Label><br />
                <asp:TextBox ID="TextBox_Content" runat="server" TextMode="MultiLine" ClientIDMode="Static" Rows="10" class="form-control"></asp:TextBox><br />

                <asp:Panel ID="Panel_NotLoggedIn" runat="server" Visible="false">
                    <asp:Label ID="Label1" runat="server" Text="Log ind, for at skrive en anmeldelse"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="Panel_LoggedIn" runat="server" Visible="true">
                    <asp:Button ID="Button_MakeReview" runat="server" Text="Post" OnClick="Button_MakeReview_Click" class="btn btn-default" ValidationGroup="Review" />
                </asp:Panel>
            </div>
        </div>

        <div class="col-lg-6">
            <asp:Panel ID="Panel_Your_Reviews" runat="server">
                <h1>Dine Anmeldelser af albummet</h1>
                <asp:Repeater ID="Repeater_Your_Reviews" runat="server" DataSourceID="SqlDataSource_Your_Reviews">
                    <ItemTemplate>
                        <h1>Tittel</h1>
                        <h4><%#Eval ("Review_title") %></h4>

                        <h1>Text</h1>
                        <h4><%#Eval ("Review_text") %></h4>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource_Your_Reviews" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Review.Review_title, Review.Review_text, Users.User_id, Albums.Album_id FROM Review INNER JOIN Users ON Review.fk_user_id = Users.User_id INNER JOIN Albums ON Review.fk_album_id = Albums.Album_id WHERE (Users.User_id = @User_id) AND (Albums.Album_id = @Album_id)">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="User_id" Name="User_id"></asp:SessionParameter>
                        <asp:QueryStringParameter QueryStringField="Album_id" Name="Album_id"></asp:QueryStringParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
        </div>
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

