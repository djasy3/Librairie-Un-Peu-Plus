using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// Description résumée de StringEncryptor
/// méthodes de cryptage et de décryptage pour la sauvegarde des données sensibles de la carte de crédits
/// </summary>
/// 
namespace SecurityLib
{
    public static class StringEncryptor
    {
        //public StringEncryptor()
        //{
            //
            // TODO: Add constructor logic here
            //
        //}
        
        //méthode de cryptage des données
        public static string Encrypt(string srcDeDonnees)
        {
            //on définit les clés et on initialise les vecteurs
            byte[] key = new byte[] {1,2,3,4,5,6,7,8 };
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };//vecteur
            try
            {
                //on convertit les données en tableau de bit
                byte[] srcDonneesByte = ASCIIEncoding.ASCII.GetBytes(srcDeDonnees);
                //obtenir le flux de données cible
                MemoryStream tempStream = new MemoryStream();
                //on obtient le flux de cryptage et le flux de décryptage
                DESCryptoServiceProvider m_encryptor = new DESCryptoServiceProvider();
                CryptoStream m_encryptionStream = new CryptoStream(tempStream, m_encryptor.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                //on encrypte les données
                m_encryptionStream.Write(srcDonneesByte, 0, srcDonneesByte.Length);
                m_encryptionStream.FlushFinalBlock();
                //on met les données dans un tableau des bit
                byte[] DonneesBytesEncriptE = tempStream.GetBuffer();
                // on convertit les données cryptées sous une chaine de caractères
                return Convert.ToBase64String(DonneesBytesEncriptE, 0, (int)tempStream.Length);
            }
            catch
            {
                throw new StringEncryptorException("Impossible de crypter les données"); ;
            }
        }
        //méthode de décryptage
        public static string Decrypt(string srcDeDonnees)
        {
            //on définit les clés et on initialise les vecteurs
            byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };//vecteur
            try
            {
                //on convertit les données en un tableau des bits
                byte[] donneesBytesEncryptE = Convert.FromBase64String(srcDeDonnees);
                // on obtient la source de flux des données et on le remplit(tableau)
                MemoryStream tempStream = new MemoryStream(donneesBytesEncryptE, 0, donneesBytesEncryptE.Length);

                //on obtient le decrypteur et le flux de decryption
                DESCryptoServiceProvider m_decrypteur = new DESCryptoServiceProvider();
                CryptoStream m_descryteurStream = new CryptoStream(tempStream, m_decrypteur.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                //on décrypte les données
                StreamReader m_allDataReader = new StreamReader(m_descryteurStream);
                //on retourne le résultat
                return m_allDataReader.ReadToEnd();
            }
            catch
            {
                throw new StringEncryptorException("Impossible de décrypter les données");
            }
        }
    }
}