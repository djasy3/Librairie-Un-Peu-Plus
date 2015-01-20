using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;//utilisation de méthode de cryptographie pour les mot de passe des utilisateurs

/// <summary>
/// Description résumée de PasswordHasher
/// </summary>

namespace SecurityLib
{
    public static class PasswordHasher
    {
        //public PasswordHasher()
        //{
            //
            // TODO: Add constructor logic here
            //
        //}
        private static SHA1Managed hasher = new SHA1Managed();//une des methode du

        public static string Hash(string mdp)
        {
            //conversion du mot de passe en tableau de bit
            byte[] mdpBytes = ASCIIEncoding.ASCII.GetBytes(mdp);
            //on génère un hash à partir du tableau de bit contenant le mot de passe
            byte[] mdpHash = hasher.ComputeHash(mdpBytes);
            //on reconverti mdpHashé en string
            return Convert.ToBase64String(mdpHash, 0, mdpHash.Length);
        }
    }
}