<%@ Page Title="Informatiques" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="informatiques.aspx.cs" Inherits="Informatique_Informatique" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <h1>Livres sur l'informatique</h1>
    <hr />
    <asp:ListView ID="ListInfo" runat="server" >
        <AlternatingItemTemplate>
            <table id="m_affiche">
                <tr>
                    <td width="15%">TITRE:</td>
                    <td width="50%"><%# Eval("titre")%></td>
                    <td class="col3"><asp:HyperLink ID="m_lien" runat="server" NavigateUrl='<%# Liens.LivresInfo(Eval("NumLivre").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>' >Description</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>AUTEUR:</td>
                    <td><%# Eval("auteur")%></td>
                    <td class="col3" width="20%"><%# Eval("prix","{0:c}") %></td>
                </tr>
                <tr>
                    <td>ISBN:</td>
                    <td><%# Eval("isbn")%></td>
                    <td class="col3" width="20%">Ajouter au pannier</td>
                </tr>
                <tr>
                    <td>EDITION:</td>
                    <td><%# Eval("edition")%></td>
                    <td class="col3" width="20%"><%# Eval("anneEdition")%></td>
                </tr>
            </table>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <span>Aucune donnée n&#39;a été retournée.</span>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table id="m_affiche">
                <tr>
                    <td width="15%">TITRE:</td>
                    <td width="50%"><%# Eval("titre")%></td>
                    <td class="col3"><asp:HyperLink ID="m_lien" runat="server" NavigateUrl='<%# Liens.LivresInfo(Eval("NumLivre").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>' >Description</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>AUTEUR:</td>
                    <td><%# Eval("auteur")%></td>
                    <td class="col3" width="20%"><%# Eval("prix","{0:c}") %></td>
                </tr>
                <tr>
                    <td>ISBN:</td>
                    <td><%# Eval("isbn")%></td>
                    <td class="col3" width="20%">Ajouter au pannier</td>
                </tr>
                <tr>
                    <td>EDITION:</td>
                    <td><%# Eval("edition")%></td>
                    <td class="col3" width="20%"><%# Eval("anneEdition")%></td>
                </tr>
            </table>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <table id="m_affiche">
                <tr>
                    <td width="15%">TITRE:</td>
                    <td width="50%"><%# Eval("titre")%></td>
                    <td class="col3"><asp:HyperLink ID="m_lien" runat="server" NavigateUrl='<%# Liens.LivresInfo(Eval("NumLivre").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>' >Description</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>AUTEUR:</td>
                    <td><%# Eval("auteur")%></td>
                    <td class="col3" width="20%"><%# Eval("prix","{0:c}") %></td>
                </tr>
                <tr>
                    <td>ISBN:</td>
                    <td><%# Eval("isbn")%></td>
                    <td class="col3" width="20%">Ajouter au pannier</td>
                </tr>
                <tr>
                    <td>EDITION:</td>
                    <td><%# Eval("edition")%></td>
                    <td class="col3" width="20%"><%# Eval("anneEdition")%></td>
                </tr>
            </table>
        </SelectedItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
                <asp:DataPager ID="DataPager1" runat="server" PageSize="5" >
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>

