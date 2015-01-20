<%@ Page Title="Créer un compte" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="account.aspx.cs" Inherits="Connexion_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <article id="m_gauche" >

        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" CancelDestinationPageUrl="~/" ContinueDestinationPageUrl="~/Connexion/Profile.aspx" CreateUserButtonText="Créer un compte" Font-Names="Verdana" Font-Size="10pt" OnCreatedUser="creerCompte">
                    <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                    <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                    <WizardSteps>
                        <asp:CreateUserWizardStep runat="server" />
                        <asp:CompleteWizardStep runat="server" />
                    </WizardSteps>
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Center" />
                    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="#FFFFFF" />
                    <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
                    <StepStyle BorderWidth="0px" />
                </asp:CreateUserWizard>
            </AnonymousTemplate>
            <LoggedInTemplate>
                Vous avez déja un compte
            </LoggedInTemplate>
        </asp:LoginView>

    </article>
</asp:Content>

