<%@ Page Title="Acceuil" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <h1>Nouveautés sur les livres !!!</h1>
    <hr />
    <nav id="img_index">
        <img src="Images/index_imgs.jpg" style="height: 178px; width: 308px" />
        <img src="Images/index_imgs2.jpg" style="height:178px" />
    </nav>
    <hr />
    <asp:ListView ID="ListIndex" runat="server" >
        <AlternatingItemTemplate>
            <table id="m_affiche">
                <tr>
                    <td width="15%">TITRE:</td>
                    <td width="50%"><%# Eval("Titre")%></td>
                    <td class="col3"><asp:HyperLink ID="m_lien" runat="server" NavigateUrl='<%# Liens.LivreIndex(Eval("Nouv").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>' >Description</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>AUTEUR:</td>
                    <td><%# Eval("Auteur")%></td>
                    <td class="col3" width="20%" >Prix: <%# Eval(" Prix", "{0:C}") %></td>
                </tr>
                <tr>
                    <td>Date sortie:</td>
                    <td><%# Eval("Date") %></td>
                </tr>
                <tr>
                    <td>ISBN</td>
                    <td><%# Eval("ISBN") %></td>
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
                    <td width="50%"><%# Eval("Titre")%></td>
                    <td class="col3"><asp:HyperLink ID="m_lien" runat="server" NavigateUrl='<%# Liens.LivreIndex(Eval("Nouv").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>' >Description</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>AUTEUR:</td>
                    <td><%# Eval("Auteur")%></td>
                    <td class="col3" width="20%">Prix: <%# Eval("Prix", "{0:C}") %></td>
                </tr>
                <tr>
                    <td>Date sortie:</td>
                    <td><%# Eval("Date") %></td>
                </tr>
                <tr>
                    <td>ISBN</td>
                    <td><%# Eval("ISBN") %></td>
                </tr>
            </table>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
                <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <table id="m_affiche">
                <tr>
                    <td width="15%">TITRE:</td>
                    <td width="50%"><%# Eval("Titre")%></td>
                    <td class="col3"><asp:HyperLink ID="m_lien" runat="server" NavigateUrl='<%# Liens.LivreIndex(Eval("Nouv").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>' >Description</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>AUTEUR:</td>
                    <td><%# Eval("Auteur")%></td>
                    <td class="col3" width="20%">Prix: <%# Eval("Prix", "{0:C}") %></td>
                </tr>
                <tr>
                    <td>Date sortie:</td>
                    <td><%# Eval("Date") %></td>
                </tr>
                <tr>
                    <td>ISBN</td>
                    <td><%# Eval("ISBN") %></td>
                </tr>
            </table>
        </SelectedItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>
</asp:Content>