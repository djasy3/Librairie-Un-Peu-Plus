<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="Controles_Utilisateurs_UserInfo" %>

    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <ul>
                <li><asp:LoginStatus ID="LoginStatus1" runat="server" /></li>
            </ul>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <ul>
                <li>bonjour et bienvenu au site de la librairie un peu plus</li>
            </ul>
        </LoggedInTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrateur">
                <ContentTemplate>
                    <ul>
                        <li><asp:LoginName ID="LoginName2" runat="server" FormatString="Bienvenu <b>{0}</b>"/></li>
                        <li><asp:LoginStatus ID="LoginStatus2" runat="server"/></li>
                        <li><asp:HyperLink ID="LienAdminShoppingCart" runat="server" NavigateUrl="~/AdminShoppingCart.aspx" Text="Administrer le ShoppingCart" ToolTip="Administrer le ShoppingCart"/></li>
                        <li><asp:HyperLink ID="LienAdminCmds" runat="server" NavigateUrl="~/AdminCommandes.aspx" Text="Administrer les Commandes" ToolTip="Administrer les Commandes"/></li>
                        <li><asp:HyperLink ID="LienAdminDetailsCmds" runat="server" NavigateUrl="~/AdminDetailsCommandes.aspx" Text="Administrer les détails sur Commandes" ToolTip="Administrer les détails sur Commandes"/></li>
                    </ul>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Utilisateurs">
                <ContentTemplate>
                    <ul>
                        <li><asp:LoginName ID="LoginName2" runat="server" FormatString="Hallo <b>{0}</b>"/></li>
                        <li><asp:LoginStatus ID="LoginStatus1" runat="server"/></li>
                        <li><asp:HyperLink ID="LienProfile" runat="server" NavigateUrl="~/Connexion/Profile.aspx" Text="Modifier votre profile" ToolTip="Modifier vous informations personnelles"/></li>
                    </ul>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
