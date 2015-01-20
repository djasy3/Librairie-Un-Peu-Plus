<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SommaireShoppingCart.ascx.cs" Inherits="Controles_Utilisateurs_SommaireShoppingCart" %>

<table class="SommaireShoppingCart">
    <tr>
        <td><b><asp:Label ID="LabelSommaireShpcart" runat="server" /></b>
        <asp:HyperLink ID="LienVoirCart" runat="server" NavigateUrl="../ShoppingCart.aspx" CssClass="LienCart" ToolTip="Pour ajouter les livres dans le pannier, veuillez cliquer sur description" Text="(Mon pannier)"/></td>
    </tr>
    <tr><td>Quantité des livres(<span><asp:Label ID="LabelQteTotale" runat="server"/></span>)&nbsp;Prix:<span><asp:Label ID="LabelSommeTotal" runat="server" /></span></td></tr>
</table>
