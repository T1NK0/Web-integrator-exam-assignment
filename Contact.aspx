<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <div class="col-lg-4">
            <h1>Kontakt Magasin</h1>
            <p>Dit Navn:</p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server" ErrorMessage="Du skal skrive en email" ControlToValidate="TextBox_Name" ValidationGroup="Kontakt" Display="Static"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBox_Name" runat="server" class="form-control"></asp:TextBox><br />


            <br />

            <p>Din E-mail:</p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ErrorMessage="Du skal skrive en email" ControlToValidate="TextBox_Email" ValidationGroup="Kontakt" Display="Static"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBox_Email" runat="server" class="form-control"></asp:TextBox><br />

            <br />

            <p>Emne:</p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Subject" runat="server" ErrorMessage="Du skal skrive en email" ControlToValidate="TextBox_Subject" ValidationGroup="Kontakt" Display="Static"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBox_Subject" runat="server" class="form-control"></asp:TextBox><br />

            <br />

            <p>Besked:</p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Message" runat="server" ErrorMessage="Du skal skrive en email" ControlToValidate="TextBox_Message" ValidationGroup="Kontakt" Display="Static"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBox_Message" runat="server" TextMode="MultiLine" Height="100px" class="form-control"></asp:TextBox><br />
            <asp:Button ID="Button_SendBesked" class="btn btn-default" runat="server" Text="Send Besked" OnClick="Button_SendBesked_Click"/>
        </div>
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

