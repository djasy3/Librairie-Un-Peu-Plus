<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModifierProfileUtilisateur.ascx.cs" Inherits="Controles_Utilisateurs_ModifierProfileUtilisateur" %>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="InfosProfile" SelectMethod="GetDonnees" TypeName="SourcesDonneesProfile" UpdateMethod="MajDonnees" StartRowIndexParameterName="0"></asp:ObjectDataSource>
<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/librairie2.mdb" SelectCommand="SELECT [ShippingRegionID], [ShippingRegion] FROM [ShippingRegion]"></asp:AccessDataSource>

<asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1">
    <ItemTemplate>
        <table>
            <tr>
                <td>Addresse 1</td>
                <td><asp:Label ID="Addresse1Label" runat="server" Text='<%# Bind("Addresse1") %>' /></td>
            </tr>
            <tr>
                <td>Addresse 2</td>
                <td><asp:Label ID="Addresse2Label" runat="server" Text='<%# Bind("Addresse2") %>' /></td>
            </tr>
            <tr>
                <td>Ville</td>
                <td><asp:Label ID="CiteLabel" runat="server" Text='<%# Bind("Cite") %>' /></td>
            </tr>
            <tr>
                <td>Etat</td>
                <td><asp:Label ID="RegionLabel" runat="server" Text='<%# Bind("Region") %>' /></td>
            </tr>
            <tr>
                <td>Code Postal</td>
                <td><asp:Label ID="CodePostalLabel" runat="server" Text='<%# Bind("CodePostal") %>' /></td>
            </tr>
            <tr>
                <td>Pays</td>
                <td><asp:Label ID="PaysLabel" runat="server" Text='<%# Bind("Pays") %>' /></td>
            </tr>
            <tr>
                <td>Zone de Livraison</td>
                <td><asp:DropDownList ID="m_listeZone" runat="server" SelectedValue='<%# Bind("ZoneLivraison") %>'
                     DataSourceID="AccessDataSource1"
                     DataTextField="ShippingRegion"
                     DataValueField="ShippingRegionID"
                     Enabled="false">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Home Phone</td>
                <td><asp:Label ID="HomePhoneLabel" runat="server" Text='<%# Bind("HomePhone") %>' /></td>
            </tr>
            <tr>
                <td>Office Phone</td>
                <td><asp:Label ID="OfficePhoneLabel" runat="server" Text='<%# Bind("OfficePhone") %>' /></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' /></td>
            </tr>
            <tr>
                <td>Carte De Credit</td>
                <td><asp:Label ID="CarteDeCreditLabel" runat="server" Text='<%# Bind("CarteDeCredit") %>' /></td>
            </tr>
            <tr>
                <td><asp:Button ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Modifier" /></td>
            </tr>
        </table>
    </ItemTemplate>
     <EditItemTemplate>
        <table>
            <tr>
                <td>Addresse 1</td>
                <td><asp:TextBox ID="Addresse1TextBox" runat="server" Text='<%# Bind("Addresse1") %>' Width="198px" Height="16px" /></td>
            </tr>
            <tr>
                <td>Addresse 2</td>
                <td><asp:TextBox ID="Addresse2TextBox" runat="server" Text='<%# Bind("Addresse2") %>' /></td>
            </tr>
            <tr>
                <td>Ville</td>
                <td><asp:TextBox ID="CiteTextBox" runat="server" Text='<%# Bind("Cite") %>' /></td>
            </tr>
            <tr>
                <td>Etat</td>
                <td><asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' /></td>
            </tr>
            <tr>
                <td>Code Postal</td>
                <td><asp:TextBox ID="CodePostalTextBox" runat="server" Text='<%# Bind("CodePostal") %>' /></td>
            </tr>
            <tr>
                <td>Pays</td>
                <td><asp:TextBox ID="PaysTextBox" runat="server" Text='<%# Bind("Pays") %>' /></td>
            </tr>
            <tr>
                <td>Zone de Livraison</td>
                <td><asp:DropDownList ID="m_listeZone" runat="server" SelectedValue='<%# Bind("ZoneLivraison") %>'
                     DataSourceID="AccessDataSource1"
                     DataTextField="ShippingRegion"
                     DataValueField="ShippingRegionID">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Home Phone</td>
                <td><asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' /></td>
            </tr>
            <tr>
                <td>Office Phone</td>
                <td><asp:TextBox ID="OfficePhoneTextBox" runat="server" Text='<%# Bind("OfficePhone") %>' /></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' /></td>
            </tr>
            <tr>
                <td valign="top">Carte De Credit</td>
                <td>
                    <table>
                        <tr>
                            <td>Proprietaire de la Carte</td>
                            <td><asp:TextBox ID="ProprietaireCarteLabel" runat="server" Text='<%# Bind("ProprietaireCarte") %>' /></td>
                        </tr>
                        <tr>
                            <td>Numéro de la Carte</td>
                            <td><asp:TextBox ID="NumeroCarteLabel" runat="server" Text='<%# Bind("NumeroCarte") %>' /></td>
                        </tr>
                        <tr>
                            <td>Date de Livraison</td>
                            <td><asp:TextBox ID="DateDeLivraisonLabel" runat="server" Text='<%# Bind("DateDeLivraison") %>' /></td>
                        </tr>
                        <tr>
                            <td>Numero de sécurité</td>
                            <td><asp:TextBox ID="NumeroLivraisonLabel" runat="server" Text='<%# Bind("NumeroLivraison") %>' /></td>
                        </tr>
                        <tr>
                            <td>Date d'expiration</td>
                            <td><asp:TextBox ID="DateExpirationLabel" runat="server" Text='<%# Bind("DateExpiration") %>' /></td>
                        </tr>
                        <tr>
                            <td>Type de carte</td>
                            <td><asp:TextBox ID="TypeCarteLabel" runat="server" Text='<%# Bind("TypeCarte") %>' /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Mettre à jour" CausesValidation="false" /></td>
                <td><asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Annuler" /></td>
            </tr>
        </table>
    </EditItemTemplate>
</asp:FormView>
