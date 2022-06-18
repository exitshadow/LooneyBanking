using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooneyBank
{
    public class Bank
    {
        private string _name;

        // un dico qui reprend tous les comptes de la banque
        // par type d’objet Account et Client
        private Dictionary<Account, Client> _accountsBook = new Dictionary<Account, Client>();

        // un dico qui reprend tous les comptes de la banque
        // par leur _accountID et Client
        private Dictionary<string, Client> _accountsBookByID = new Dictionary<string, Client>();


        // propriété pour retrouver les clients à partir d’un objet Account
        public Client this[Account key]
        {
            get
            {
                Client client;
                _accountsBook.TryGetValue(key, out client);
                return client;
            }
            set
            {
                _accountsBook[key] = value;
            }
        }

        // propriété pour retrouver le client sur base d’un _accountID
        public Client this[string key]
        {
            get
            {
                Client client;
                _accountsBookByID.TryGetValue(key, out client);
                return client;
            }
        }
        
        // méthode pour ajouter un compte via son _accountID
        public void AddAccountByID(Account account)
        {
            _accountsBookByID.Add(account.AccountID, account.Owner);
        }

        // méthode pour ajouter un objet Account tout entier
        public void AddAccount(Account account)
        {
            _accountsBook.Add(account, account.Owner);
        }
    }
}
