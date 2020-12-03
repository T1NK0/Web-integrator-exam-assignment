<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageFrontend.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-2"></div>
    <div class="col-lg-8 main">
        <div class="col-lg-12">
            <div class="col-lg-6">
                <h1>Opret Bruger</h1>
                <p>Email:</p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server" ErrorMessage="Du skal skrive en email" ControlToValidate="TextBox_Email_Create" ValidationGroup="Opret" Display="Static"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Email_Create" runat="server" placeholder="Email" class="form-control" ValidationGroup="opret"></asp:TextBox><br />

                <p>Name:</p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Username" runat="server" ErrorMessage="Du skal skrive dit navn" ControlToValidate="TextBox_Username_Create" ValidationGroup="Opret" Display="Static"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Username_Create" runat="server" placeholder="Name" class="form-control" ValidationGroup="opret"></asp:TextBox><br />

                <p>Beskrivelse:</p>
                <asp:TextBox ID="TextBox_Description" runat="server" placeholder="Beskrivelse" class="form-control" ValidationGroup="opret" Height="150" TextMode="MultiLine"></asp:TextBox><br />

                <p>Password:</p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Password" runat="server" ErrorMessage="Du skal skrive et password" ControlToValidate="TextBox_Password_Create1" ValidationGroup="Opret" Display="Static"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox_Password_Create1" runat="server" placeholder="Password" class="form-control" TextMode="Password" ValidationGroup="Opret"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Koderne stemmer ikke over ens" ControlToCompare="TextBox_Password_Create2" ControlToValidate="TextBox_Password_Create1" ValidationGroup="Opret"></asp:CompareValidator><br />


                <p>Gentag Password:</p>
                <asp:TextBox ID="TextBox_Password_Create2" runat="server" placeholder="Gentag Password" class="form-control" TextMode="Password" ValidationGroup="opret"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Koderne stemmer ikke over ens" ControlToCompare="TextBox_Password_Create1" ControlToValidate="TextBox_Password_Create2" ValidationGroup="Opret"></asp:CompareValidator><br />

                <asp:FileUpload ID="FileUpload_Img" runat="server" class="btn btn-default" /><br />

                <asp:Button ID="button_create_user" runat="server" Text="Opret bruger" OnClick="button_create_user_Click" class="btn btn-default" ValidationGroup="Opret" />
            </div>
        </div>

        <div class="col-lg-12">
            <div class="col-lg-6">
                <h1>Login</h1>
                <div class="form-group">
                    <asp:TextBox ID="TextBox_email" runat="server" placeholder="Email" CssClass="form-control login_textbokse"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="TextBox_password" runat="server" Placeholder="Kodeord" TextMode="Password" CssClass="form-control login_textbokse"></asp:TextBox>
                    <asp:Label ID="Label_ErrorMessage" runat="server" Text=""></asp:Label><br />
                    <asp:Button ID="Button_login" runat="server" Text="Login" OnClick="Button_login_Click" ValidationGroup="login" class="btn btn-default" />
                    <%--<a href="ForgottenPassword.aspx" class="btn btn-default">Glemt Password</a>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

