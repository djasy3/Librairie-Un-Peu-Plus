<%@ Page Title="Shopping cart" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <p><asp:Label ID="LabelTitre" runat="server" Text="Votre pannier" CssClass="CatalogTitre"/></p>
    <p><asp:Label ID="LabelEtat" runat="server" CssClass="Erreur"/></p>
    <asp:GridView ID="m_grid" runat="server" AutoGenerateColumns="False" DataKeyNames="NumLivre" Width="100%" BorderWidth="1px" OnRowDeleting="m_grid_RowDeleting" BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="titre" HeaderText="Nom Livre" ReadOnly="True" SortExpression="titre">
                <ControlStyle Width="100%"/>
            </asp:BoundField>
            <asp:BoundField DataField="prix" DataFormatString="{0:c}" HeaderText="Prix" ReadOnly="True" SortExpression="prix"/>
            <asp:TemplateField HeaderText="Quantité">
                <ItemTemplate>
                    <asp:TextBox ID="editQuantite" runat="server" CssClass="GridEditingRow" Width="24px" MaxLength="2" Text='<%#Eval("Quantite") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SubTotal" DataFormatString="{0:c}" HeaderText="Sous-Total" ReadOnly="True" SortExpression="SubTotal"/>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Effacer" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <p align="right">
        <span>Somme totale:</span>
        <asp:Label ID="LabelSommeTotale" runat="server" Text="Label" />
    </p>
    <p align="right">
        <asp:Button ID="updateButton" runat="server" Text="Mettre à jour la Quantité" OnClick="updateButton_Click" BackColor="#478F8F" BorderStyle="None" />
        <asp:Button ID="passerCmdButton" runat="server" Text="Passer la commande" OnClick="passerCmdButton_Click" BackColor="#478F8F" BorderStyle="None" CssClass="btn"/>
    </p>
</asp:Content>

