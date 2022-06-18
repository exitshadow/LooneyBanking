using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooneyBank
{
    public class Account
    {
        #region champs privés
        private string _accountID;
        private double _inAccount;
        private double _creditLine;
        private Client _owner;
        #endregion

        #region propriétés publiques
        public string AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }

        public Client Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public double InAccount
        {
            get { return _inAccount; }
            set { _inAccount = value; }
        }

        public double CreditLine
        {
            get { return _creditLine; }
            set { _creditLine = value; }
        }
        #endregion

        #region méthodes
        public void Draw()
        {

        }
        public void Deposit()
        {

        }
        #endregion

        #region surcharge d’opérateur
        /// <summary>
        // cette méthode fait en sorte que si on fait aaa_000 + bbb_111,
        // au lieu d’essayer d’ajouter les deux objets ensemble (ce qui n’a
        // pas vraiment de sens), il va additionner les valeurs _inAccount
        // et renvoyer le résultat, qu’on pourra stocker dans une variable.

        // comme dans toute méthode on peut ajouter toutes les procédures
        // qu’on veut, ici il y a quelques Console.WriteLine() pour compléter
        // les fonctionnalités.
        /// </summary>
        public static Nullable<double> operator +(Account a1, Account a2)
        {
            if (a1._inAccount >= 0 && a2._inAccount >= 0)
            {
                Console.WriteLine($"La somme des comptes {a1._accountID} et {a2._accountID} est de {a1._inAccount + a2._inAccount}");
                if (a1._owner == a2._owner)
                {
                    Console.WriteLine($"{a1._owner.FirstName} est riche!");
                }
                return a1._inAccount + a2._inAccount;
            }
            else
            {
                Console.WriteLine("Un des comptes passés en argument est en négatif.");
                if (a1._owner == a2._owner)
                {
                    Console.WriteLine($"{a1._owner.FirstName} va avoir du mal à finir le mois.");
                }
                return null;
            }
        }
        #endregion
    }
}
