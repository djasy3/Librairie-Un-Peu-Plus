using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using SecurityLib;

/// <summary>
/// Description résumée de InfosProfile
/// </summary>
public class InfosProfile
{
    //les propriétés
    private string m_addresse1;
    private string m_addresse2;
    private string m_cite;
    private string m_region;
    private string m_codePostal;
    private string m_pays;
    private string m_zoneLivraison;
    private string m_homePhone;
    private string m_officePhone;
    private string m_email;
    private string m_carteDeCredit;
    private string m_proprietaireCarte;
    private string m_numeroCarte;
    private string m_dateLivraison;
    private string m_numeroLivraison;
    private string m_dateExpiration;
    private string m_typeCarte;

    //propriétés(accesseur et modificateur)
    public string Addresse1
    {
        get { return this.m_addresse1; }
        set { this.m_addresse1 = value; }
    }
    //
    public string Addresse2
    {
        get { return this.m_addresse2; }
        set { this.m_addresse2 = value; }
    }
    //
    public string Cite
    {
        get { return this.m_cite; }
        set { this.m_cite = value; }
    }
    //
    public string Region
    {
        get { return this.m_region; }
        set { this.m_region = value; }
    }
    //
    public string CodePostal
    {
        get { return this.m_codePostal; }
        set { this.m_codePostal = value; }
    }
    //
    public string Pays
    {
        get { return this.m_pays; }
        set { this.m_pays = value; }
    }
    //
    public string ZoneLivraison
    {
        get { return this.m_zoneLivraison; }
        set { this.m_zoneLivraison = value; }
    }
    //
    public string HomePhone
    {
        get { return this.m_homePhone; }
        set { this.m_homePhone = value; }
    }
    //
    public string OfficePhone
    {
        get { return this.m_officePhone; }
        set { this.m_officePhone = value; }
    }
    //
    public string Email
    {
        get { return this.m_email; }
        set { this.m_email = value; }
    }
    //
    public string CarteDeCredit
    {
        get { return this.m_carteDeCredit; }
        set { this.m_carteDeCredit = value; }
    }
    //
    public string ProprietaireCarte
    {
        get { return this.m_proprietaireCarte; }
        set { this.m_proprietaireCarte = value; }
    }
    //
    public string NumeroCarte
    {
        get { return this.m_numeroCarte; }
        set { this.m_numeroCarte = value; }
    }
    //
    public string DateDeLivraison
    {
        get { return this.m_dateLivraison; }
        set { this.m_dateLivraison = value; }
    }
    //
    public string NumeroLivraison
    {
        get { return this.m_numeroLivraison; }
        set { this.m_numeroLivraison = value; }
    }
    //
    public string DateExpiration
    {
        get { return this.m_dateExpiration; }
        set { this.m_dateExpiration = value; }
    }
    //
    public string TypeCarte
    {
        get { return this.m_typeCarte; }
        set { this.m_typeCarte = value; }
    }
    //
	public InfosProfile()
	{
        ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;//le profile du user actuel
        Addresse1 = profile.Adresse1;
        Addresse2 = profile.Adresse2;
        Cite = profile.Cite;
        Region = profile.Region;
        CodePostal = profile.CodePostal;
        Pays = profile.Pays;
        ZoneLivraison = (profile.ZoneDeLivraison == null || profile.ZoneDeLivraison == "" ? "1" : profile.ZoneDeLivraison);
        HomePhone = profile.HomePhone;
        OfficePhone = profile.OfficePhone;
        Email = Membership.GetUser(profile.UserName).Email;
        //
        try
        {
            //info sur la carte de crédit
            SecureCard secureCard = new SecureCard(profile.CarteDeCredit);
            CarteDeCredit = secureCard.NumeroCarte;
            ProprietaireCarte = secureCard.ProprietaireCarte;
            NumeroCarte = secureCard.NumeroCarte;
            DateDeLivraison = secureCard.DateDeLivraison;
            NumeroLivraison = secureCard.NumeroLivraison;
            DateExpiration = secureCard.DateExpiration;
            TypeCarte = secureCard.TypeCarte;
        }
        catch
        {
            CarteDeCredit = "Enregistrer une carte de credit";
        }
	}
    //méthode de mise à jour
    public void majProfile()
    {
        ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;
        profile.Adresse1 = Addresse1;
        profile.Adresse2 = Addresse2;
        profile.Cite = Cite;
        profile.Region = Region;
        profile.CodePostal = CodePostal;
        profile.Pays = Pays;
        profile.ZoneDeLivraison = ZoneLivraison;
        profile.HomePhone = HomePhone;
        profile.OfficePhone = OfficePhone;
        profile.CarteDeCredit = CarteDeCredit;
        MembershipUser user = Membership.GetUser(profile.UserName);
        user.Email = Email;
        Membership.UpdateUser(user);
        try
        {
            SecureCard secureCard = new SecureCard(
                ProprietaireCarte, NumeroCarte,
                DateDeLivraison, NumeroLivraison, 
                DateExpiration, TypeCarte);
            profile.CarteDeCredit = secureCard.DonneesCryptE;
        }
        catch
        {
            CarteDeCredit = "Erreur d'enregistrement";
        }
    }
}