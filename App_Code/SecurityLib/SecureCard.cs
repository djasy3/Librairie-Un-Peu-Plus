using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

/// <summary>
/// Description résumée de SecureCard
/// </summary>
/// 
namespace SecurityLib
{
    public class SecureCard
    {
        //on définit les propriétés pour la classe qui va stocker les données de la carte de crédit
        private bool EstDecryptE = false;
        private bool EstEncryptE = false;
        private string m_proprietaireCarte;
        private string m_numeroCarte;
        private string m_dateDeLivraison;
        private string m_dateExpiration;
        private string m_numeroLivraison;
        private string m_typeCarte;
        private string m_donneesCryptE;
        private XmlDocument m_xmlDonneesCarte;
        //cstor
        public SecureCard(string newEncryptedData)
        {
            //à utiliser pour les données cryptées
            this.m_donneesCryptE = newEncryptedData;
            this.DecrypterDonnees();
        }
        //csotr
        public SecureCard(string newProprietaire,
            string newNumeroCarte,
            string newDateDeLivraison,
            string newNumeroLivraison,
            string newDateExpiration,
            string newtypeCarte
            )
        {
            //csteur pour utiliser avec les données cryptées
            this.m_proprietaireCarte = newProprietaire;
            this.m_numeroCarte = newNumeroCarte;
            this.m_dateDeLivraison = newDateDeLivraison;
            this.m_numeroLivraison = newNumeroLivraison;
            this.m_dateExpiration = newDateExpiration;
            this.m_typeCarte = newtypeCarte;
            this.CrypterDonnees();
        }
        //méthode de création des documents xml
        private void CreateXml()
        {
            //on encode les détails de la carte comme un document xml
            this.m_xmlDonneesCarte = new XmlDocument();
            XmlElement racineDocument = m_xmlDonneesCarte.CreateElement("DetailsCarte");
            XmlElement child;
            //sous élèment
            child = m_xmlDonneesCarte.CreateElement("ProprietaireCarte");
            child.InnerXml = this.m_proprietaireCarte;
            racineDocument.AppendChild(child);
            //sous élèment
            child = m_xmlDonneesCarte.CreateElement("NumeroCarte");
            child.InnerXml = this.m_numeroCarte;
            racineDocument.AppendChild(child);
            //sous élèment
            child = m_xmlDonneesCarte.CreateElement("DateDeLivraison");
            child.InnerXml = this.m_dateDeLivraison;
            racineDocument.AppendChild(child);
            //sous élèment
            child = m_xmlDonneesCarte.CreateElement("DateExpiration");
            child.InnerXml = this.m_dateExpiration;
            racineDocument.AppendChild(child);
            //sous élèment
            child = m_xmlDonneesCarte.CreateElement("NumeroLivraison");
            child.InnerXml = this.m_numeroLivraison;
            racineDocument.AppendChild(child);
            //sous élèment
            child = m_xmlDonneesCarte.CreateElement("TypeCarte");
            child.InnerXml = this.m_typeCarte;
            racineDocument.AppendChild(child);
            this.m_xmlDonneesCarte.AppendChild(racineDocument);
        }
        //méthode d'extraction
        private void ExtractXml()
        {
            //obtenir les données a partire du document xml
            this.m_proprietaireCarte = m_xmlDonneesCarte.GetElementsByTagName("ProprietaireCarte").Item(0).InnerXml;
            this.m_numeroCarte = m_xmlDonneesCarte.GetElementsByTagName("NumeroCarte").Item(0).InnerXml;
            this.m_dateDeLivraison = m_xmlDonneesCarte.GetElementsByTagName("DateDeLivraison").Item(0).InnerXml;
            this.m_dateExpiration = m_xmlDonneesCarte.GetElementsByTagName("DateExpiration").Item(0).InnerXml;
            this.m_numeroLivraison = m_xmlDonneesCarte.GetElementsByTagName("NumeroLivraison").Item(0).InnerXml;
            this.m_typeCarte = m_xmlDonneesCarte.GetElementsByTagName("TypeCarte").Item(0).InnerXml;
        }
        //méthode de cryptage
        private void CrypterDonnees()
        {
            try
            {
                //mettre les données dans un document xml
                this.CreateXml();
                //on crypte les données
                this.m_donneesCryptE = StringEncryptor.Encrypt(m_xmlDonneesCarte.OuterXml);
                //on définit l'état pour savoir si les données sont cryptées
                this.EstEncryptE = true;
            }
            catch
            {
                throw new StringEncryptorException("Impossible de crypter les données");
            }
        }
        //méthode de décryptage
        private void DecrypterDonnees()
        {
            try
            {
                //on décrypte les données
                this.m_xmlDonneesCarte = new XmlDocument();
                this.m_xmlDonneesCarte.InnerXml = StringEncryptor.Decrypt(this.m_donneesCryptE);
                //on extrait les données du document xml
                this.ExtractXml();
                //on définit l'état pour savoir si les données sont cryptées
                this.EstDecryptE = true;
            }
            catch
            {
                throw new StringEncryptorException("Impossible de décrypter les données");
            }
        }
        //les propriétés
        public string ProprietaireCarte
        {
            get
            {//on vérifie si la donnée était cryptée, si non, on renvoi une exception
                if (this.EstDecryptE)
                    return m_proprietaireCarte;
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
        //numéro de la carte
        public string NumeroCarte
        {
            get
            {
                //vérification
                if (this.EstDecryptE)
                    return "XXXX-XXXX-XXXX-"+m_numeroCarte.Substring(m_numeroCarte.Length -4, 4);
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
        //date de livraison de la carte
        public string DateDeLivraison
        {
            get
            {//vérification
                if (this.EstDecryptE)
                    return m_dateDeLivraison;
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
        //date d'expiration de la carte
        public string DateExpiration
        {
            get
            {//vérification
                if (this.EstDecryptE)
                    return m_dateExpiration;
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
        //numéro de livraison(code cvs)
        public string NumeroLivraison
        {
            get
            {//vérification
                if (this.EstDecryptE)
                    return m_numeroLivraison;
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
        //type de carte
        public string TypeCarte
        {
            get
            {//vérification
                if (this.EstDecryptE)
                    return m_typeCarte;
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
        //données cryptées
        public string DonneesCryptE
        {
            get
            {
                if (this.EstEncryptE)
                    return m_donneesCryptE;
                else
                    throw new SecureCardException("Données non cryptées");
            }
        }
    }
}
