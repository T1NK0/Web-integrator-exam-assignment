<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageBackend.master" AutoEventWireup="true" CodeFile="AdminContactInfo.aspx.cs" Inherits="AdminContactInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-10" style="float: right;">
        <asp:Panel ID="Panel_EditContactInfo" runat="server" Visible="false">
            <div class="col-lg-12">
                <div class="col-lg-6">
                    Addresse:
            <asp:TextBox ID="TextBox_Location_Name" placeholder="Addresse" class="form-control" runat="server"></asp:TextBox><br />

                    Addresse:
            <asp:TextBox ID="TextBox_Address" placeholder="Addresse" class="form-control" runat="server"></asp:TextBox><br />

                    Addresse:
            <asp:TextBox ID="TextBox_Postal_Number" placeholder="Addresse" class="form-control" runat="server"></asp:TextBox><br />

                    Addresse:
            <asp:TextBox ID="TextBox_Opening_Monday_Friday" placeholder="Addresse" class="form-control" runat="server"></asp:TextBox><br />

                    Addresse:
            <asp:TextBox ID="TextBox_Opening_Saturday" placeholder="Addresse" class="form-control" runat="server"></asp:TextBox><br />

                    Åbningstider:
            <asp:TextBox ID="TextBox_Opening_Sunday" placeholder="Åbningstider" class="form-control" runat="server"></asp:TextBox><br />

                    Telefonnummer:
            <asp:TextBox ID="TextBox_tlf" placeholder="Telefonnummer" class="form-control" runat="server"></asp:TextBox><br />

                    Email:
            <asp:TextBox ID="TextBox_email" placeholder="Email" class="form-control" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button_Gem_Ret" runat="server" CssClass="btn btn-success" Text="Gem" OnClick="Button_Gem_Ret_Click" />
                </div>
                <hr />
            </div>
        </asp:Panel>

        <div class="col-lg-12">
            <table class="table">
                <thead>
                    <tr>
                        <th class="col-lg-1">Lokations Navn</th>
                        <th class="col-lg-1">Addresse</th>
                        <th class="col-lg-1">Postnummer</th>
                        <th class="col-lg-1">Åbningstider Mandag-Fredag</th>
                        <th class="col-lg-1">Åbningstider Lørdag</th>
                        <th class="col-lg-1">Åbningstider Søndag</th>
                        <th class="col-lg-1">Telefonnummer</th>
                        <th class="col-lg-1">Email</th>
                        <th class="col-lg-2">ret</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_Ret_ContactInfo" runat="server" OnItemCommand="Repeater_Ret_ContactInfo_ItemCommand" DataSourceID="SqlDataSource_Ret_ContactInfo">
                <ItemTemplate>
                    <table class="table table-hover">
                        <tr>
                            <td class="col-lg-1"><%#Eval ("Contact_location_name") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_address") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_postal_number") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_opening_monday_friday") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_opening_saturday") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_opening_sunday") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_phone") %></td>
                            <td class="col-lg-1"><%#Eval ("Contact_email") %></td>
                            <td class="col-lg-2">
                                <asp:LinkButton ID="LinkButton_ret" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("Contact_id") %>' CommandName="Ret">Ret</asp:LinkButton></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Ret_ContactInfo" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [Contact]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

