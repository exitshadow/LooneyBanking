using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooneyBank
{
    public interface ICustomer
    {
        double Balance { get; }

    }

    public interface IBanker : ICustomer
    {
        string AccountID { get; }
        Client Owner { get; }

        void ApplyInterests();
    }

    public abstract class Account : ICustomer, IBanker
    {
        #region champs privés
        private string _accountID;
        private double _balance;
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

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; } // à éliminer mais permettre au constructeur d’accéder à _balance
        }

        public double CreditLine
        {
            get { return _creditLine; }
            set { _creditLine = value; }
        }
        #endregion

        #region méthodes virtuelles et abstraites
        public virtual void Draw(double amount)
        {
            if (amount > 0 && amount < _balance)
            {
                _balance -= amount;
                Console.WriteLine($"{_owner.FirstName} a retiré {amount}. Il lui reste {_balance} sur le compte {_accountID}.");
            }
            else if (amount <= 0) { Console.WriteLine("Cette opération n’a aucun sens."); }
            else if (amount > _balance) { Console.WriteLine($"Le solde du compte {_accountID} est insuffisant."); }
        }
        protected abstract double CalculateInterests();
        // ici elle demande à implémenter la méthode sur les parts héritées

        #region vieille solution qui permettait de fonctionner pour les deux cas d'héritage
        //protected double CalculateInterests()
        //{
        //    double interestRate;

        //    if (this is CurrentAccount && _balance >= 0) { interestRate = .03; }
        //    else if (this is CurrentAccount && _balance < 0) { interestRate = .0975; }
        //    else { interestRate = 0.045; }

        //    return interestRate * _balance;
        //}
        #endregion
        #endregion

        #region méthodes classiques
        public void Deposit(double amount)
        {
            if (amount <= 0) { Console.WriteLine("Cette opération n’a aucun sens."); }
            else
            {
                _balance += amount;
                Console.WriteLine($"{_owner.FirstName} a déposé {amount}. Il y a maintenant {amount} sur le compte {_accountID}");
            }
        }

        #endregion

        #region surcharges d’opérateurs
        /// <summary>
        // cette méthode fait en sorte que si on fait aaa_000 + bbb_111,
        // au lieu d’essayer d’ajouter les deux objets ensemble (ce qui n’a
        // pas vraiment de sens), il va additionner les valeurs _balance
        // et renvoyer le résultat, qu’on pourra stocker dans une variable.

        // comme dans toute méthode on peut ajouter toutes les procédures
        // qu’on veut, ici il y a quelques Console.WriteLine() pour compléter
        // les fonctionnalités.
        /// </summary>
        public static Nullable<double> operator +(Account a1, Account a2)
        {
            if (a1._balance >= 0 && a2._balance >= 0)
            {
                Console.WriteLine($"La somme des comptes {a1._accountID} et {a2._accountID} est de {a1._balance + a2._balance}");
                if (a1._owner == a2._owner)
                {
                    Console.WriteLine($"{a1._owner.FirstName} est riche!");
                }
                return a1._balance + a2._balance;
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

        #region implémentation des interfaces
        public void ApplyInterests()
        {
            _balance += CalculateInterests();
        }
        #endregion
    }

    public class CurrentAccount : Account
    {
        protected override double CalculateInterests()
        {
            // throw new NotImplementedException();
            // c'est VS qui par prévoyance ajoute ça dans le code au cas où on ne remplit rien
            // pour ne pas tout casser le flow et mettre des erreurs qui empêchent la compilation

            double interestRate;
            if (Balance >= 0) { interestRate = .03; }
            else { interestRate = .0975; }

            return Balance * interestRate;
        }
    }

    public class SavingsAccount : Account
    {
        private DateTime _lastDraw;
        public DateTime LastDraw { get { return _lastDraw; } }

        public override void Draw(double amount)
        {
            // reprend tout le code de la méthode parente
            base.Draw(amount);
            
            // ajoute la fonctionnalité qu’on veut
            _lastDraw = DateTime.Now;

            // note: on aurait aussi pu réécrire toute la fonction
            // mais il aurait fallu faire passer _balance en protected
            // au lieu de private.
            // en faisant appel à base.Draw(), on peut simplement laisser
            // la classe parente s’occuper du calcul, et juste ajouter la
            // petite procédure supplémentaire.

        }

        protected override double CalculateInterests()
        {
            return Balance * .045;
        }
    }
}
