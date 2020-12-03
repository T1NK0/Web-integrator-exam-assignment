<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <%--        <div class="col-lg-4">
            <h3>Navn:</h3>
            <asp:Label ID="Label_name" runat="server" Text="Label"></asp:Label>

            <h3>Beskrivelse:</h3>
            <asp:Label ID="Label_description" runat="server" Text="Label"></asp:Label>

            <h3>Grunker:</h3>
            <asp:Label ID="Label_grunker" runat="server" Text="Label"></asp:Label>

        </div>
        <div class="col-lg-2"></div>
        <div class="col-lg-6">--%>
        <div class="col-lg-12">
            <asp:Panel ID="Panel_User_Info" runat="server" Visible="true">
                <asp:Repeater ID="Repeater_User_Profile" runat="server" DataSourceID="SqlDataSource_User_Profile" OnItemCommand="Repeater_User_Profile_ItemCommand">
                    <ItemTemplate>
                        <div class="col-lg-4">
                            <h3>Navn:</h3>
                            <h4><%#Eval ("User_name") %></h4>

                            <h3>Beskrivelse:</h3>
                            <h4><%#Eval ("User_description") %></h4>

                            <h3>Antal Grunker:</h3>
                            <h4><%#Eval ("User_grunker") %></h4>

                            <asp:Button ID="Button_EditUser" runat="server" class="btn btn-default" Text="Ret Profil" CommandArgument='<%#Eval ("User_id") %>' CommandName="Ret_Profil" />
                        </div>

                        <div class="col-lg-2"></div>

                        <div class="col-lg-6">
                            <div class="col-lg-6">
                                <img src="Images/ProfilePicture/<%#Eval ("User_img") %>" class="img-responsive" />
                            </div>

                            <div class="col-lg-6">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource_User_Profile" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [Users] WHERE ([User_id] = @User_id)">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="User_id" Name="User_id" Type="Int32"></asp:SessionParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>
        </div>
        <div class="col-lg-12">
            <div class="col-lg-6">
                <asp:Panel ID="Panel_Edit_User" runat="server" Visible="false">
                    <asp:Image ID="Image_Ret1" runat="server" Visible="false" /><br />
                    <asp:HiddenField ID="HiddenField_oldImage1" runat="server" />
                    <asp:FileUpload ID="FileUpload_Img1" runat="server" class="btn btn-default"/><br />

                    <p>Beskrivelse:</p>
                    <asp:TextBox ID="TextBox_Description" runat="server" placeholder="Beskrivelse" class="form-control" ValidationGroup="opret" Height="150" TextMode="MultiLine"></asp:TextBox><br />

                    <asp:Button ID="button_Edit_User_Confirm" runat="server" Text="Gem" OnClick="button_Edit_User_Confirm_Click" class="btn btn-default" />
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

