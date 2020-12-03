<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <div class="col-lg-12">
            <div class="col-lg-4">
                <asp:Repeater ID="Repeater_WelcomeText" runat="server" DataSourceID="SqlDataSource_WelcomeText">
                    <ItemTemplate>
                        <h2><%#Eval ("Welcome_heading") %></h2>
                        <h4><%#Eval ("Welcome_text") %></h4>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource_WelcomeText" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [Welcome_Text]"></asp:SqlDataSource>
            </div>

            <div class="col-lg-4">
                <h1>Hit Listen</h1>

            </div>

            <div class="col-lg-4">
                <h1>Albums</h1>
                <asp:Repeater ID="Repeater_RandomAlbums" runat="server" DataSourceID="SqlDataSource_RandomAlbums">
                    <ItemTemplate>
                        <div>
                            <h3><%#Eval ("Album_name") %></h3>
                            <img src="Images/50x50/<%#Eval ("Album_img") %>" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource_RandomAlbums" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT TOP(3) Album_id, Album_name, Album_img FROM Albums ORDER BY NEWID()"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
