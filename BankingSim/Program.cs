using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooneyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            #region affichage titre
            Console.WriteLine("LOONEY BANK v0.0.0.04c-redist.2022");
            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region instanciations

            #region instanciation de la banque
            Bank ingBank = new Bank
            {
                Name = "la banque avec le lion moche, là"
            };
            #endregion

            #region instanciation des clients

            Client solidSnake = new Client
            {
                FirstName = "Solid",
                LastName = "Snake",
                BirthDay = new DateTime(1963, 08, 13)
            };

            Client batMan = new Client
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                BirthDay = new DateTime(1951, 06, 22)
            };

            Client bugsBunny = new Client
            {
                FirstName = "Bugs",
                LastName = "Bunny",
                BirthDay = new DateTime(1951, 01, 01)
            };

            Client minnieMouse = new Client
            {
                FirstName = "Minnie",
                LastName = "Mouse",
                BirthDay = new DateTime(1920, 02, 13)
            };

            Client raiden = new Client
            {
                FirstName = "Raiden",
                LastName = "Jack",
                BirthDay = new DateTime(1997, 03, 21)
            };

            Client daffyDuck = new Client
            {
                FirstName = "Daffy",
                LastName = "Duck",
                BirthDay = new DateTime(1952, 03, 05)
            };

            #endregion

            #region instanciation des comptes courants

            CurrentAccount mgs_001 = new CurrentAccount
            {
                AccountID = "MGS-001",
                Owner = solidSnake,
                Balance = 6872.8,
                CreditLine = 2000
            };

            CurrentAccount mgs_002 = new CurrentAccount
            {
                AccountID = "MGS-002",
                Owner = raiden,
                Balance = -238.74,
                CreditLine = 250
            };

            CurrentAccount mgs_003 = new CurrentAccount
            {
                AccountID = "MGS-003",
                Owner = solidSnake,
                Balance = 12.41,
                CreditLine = 0
            };

            CurrentAccount mgs_004 = new CurrentAccount
            {
                AccountID = "MGS-004",
                Owner = solidSnake,
                Balance = 12888.39,
                CreditLine = 0
            };

            CurrentAccount mgs_005 = new CurrentAccount
            {
                AccountID = "MGS-005",
                Owner = raiden,
                Balance = 414.28,
                CreditLine = 500
            };

            CurrentAccount dis_001 = new CurrentAccount
            {
                AccountID = "DIS-001",
                Owner = minnieMouse,
                Balance = 189162000.21,
                CreditLine = 100000000
            };

            CurrentAccount loo_001 = new CurrentAccount
            {
                AccountID = "LOO-001",
                Owner = bugsBunny,
                Balance = 25.98,
                CreditLine = 1250
            };

            CurrentAccount bat_001 = new CurrentAccount
            {
                AccountID = "BAT-001",
                Owner = batMan,
                Balance = 780998.22,
                CreditLine = 100000
            };

            #endregion

            #region instanciation des comptes épargne
            SavingsAccount mgs_006 = new SavingsAccount
            {
                Owner = raiden,
                AccountID = "MGS-006",
                Balance = 320.52
            };

            CurrentAccount loo_002 = new SavingsAccount
            {
                Owner = daffyDuck,
                AccountID = "LOO-002",
                Balance = 799.89
            };
            #endregion

            #endregion

            #region indexeurs de ingBank

            #region addition dans les livres de la banque
            ingBank.AddAccount(bat_001);
            ingBank.AddAccount(mgs_001);
            ingBank.AddAccount(mgs_002);
            ingBank.AddAccount(mgs_003);
            ingBank.AddAccount(mgs_004);
            ingBank.AddAccount(mgs_005);
            ingBank.AddAccount(loo_001);
            ingBank.AddAccount(dis_001);
            #endregion

            #region addition des comptes par ID dans les livres de la banque
            // on remarque que la méthode ByID est complètement redondante
            ingBank.AddAccountByID(bat_001);
            ingBank.AddAccountByID(mgs_001);
            ingBank.AddAccountByID(mgs_002);
            ingBank.AddAccountByID(mgs_003);
            ingBank.AddAccountByID(mgs_004);
            ingBank.AddAccountByID(mgs_005);
            ingBank.AddAccountByID(loo_001);
            ingBank.AddAccountByID(dis_001);
            #endregion

            #region recherche des comptes dans les livres
            Console.WriteLine("Recherche des clients associés aux comptes");
            Console.WriteLine("------------------------------------------");

            // indexation par objet CurrentAccount
            Console.WriteLine($"Le compte {mgs_001.AccountID} appartient à {ingBank[mgs_001].FirstName} {ingBank[mgs_001].LastName} et il vous emmerde. Cela ne nous a pas empêchées de le retrouver par type de compte dans les les livres de sa banque.");

            Console.WriteLine();

            // indexation par string
            Console.WriteLine($"Le compte {loo_001.AccountID} appartient à {ingBank["LOO-001"].FirstName} {ingBank["LOO-001"].LastName} et ça ne l’empêchera pas de manger des carottes. Le fait qu’on le retrouve via le string de son AccountID ne le préoccupe nullement.");
            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine();

            #region test des surcharges d’opérateurs
            Console.WriteLine("Test des surcharges d’opérateurs");
            Console.WriteLine("--------------------------------");

            double? raidenAccountSum = mgs_002 + mgs_005;
            Console.WriteLine();
            double? snakeAccountSum = mgs_001 + mgs_003;
            #endregion

            Console.WriteLine();
            Console.WriteLine();

            #region test des comptes épargne
            Console.WriteLine("Classe SavingsAccount et polymorphisme");
            Console.WriteLine("--------------------------------------");

            mgs_006.Draw(120);
            Console.WriteLine($"Le dernier retrait a été effectué le : {mgs_006.LastDraw}");

            Console.WriteLine();

            loo_002.Draw(250);
            // on ne peut pas accéder à la propriété .LastDraw
            // car par polymorphisme, loo_002 est de type CurrentAccount
            // et non pas SavingsAccount, même s’il est un SavingsAccount
            //Console.WriteLine(loo_002.LastDraw);

            // on doit donc écrire avec un casting explicite
            Console.WriteLine(((SavingsAccount)loo_002).LastDraw);
            #endregion


            // == FIN DU PROGRAMME ==
            Console.ReadLine();

        }
    }
}
