using System;
using System.Collections.Generic;

/// <summary>
/// Description résumée de SourcesDonneesProfile
/// </summary>
public class SourcesDonneesProfile
{
	public SourcesDonneesProfile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //
    List<InfosProfile> m_donnees = new List<InfosProfile>();

    public List<InfosProfile> GetDonnees()
    {
        m_donnees.Add(new InfosProfile());
        return m_donnees;
    }
    //méthode pour la mise à jour
    public void MajDonnees(InfosProfile data)
    {
        data.majProfile();
    }
}