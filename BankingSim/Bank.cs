using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooneyBank
{
    public class Bank
    {
        #region champs et propriétés non-indexeurs
        private string _name;
        public string Name
        {
            get { return _name; }
            set  { _name = value; }
        }
        #endregion

        #region champs, propriétés et méthodes indexeurs
        /// <summary>
        // les champs de type indexeurs permettent d’itérer dans les champs
        // et d’effectuer des recherches dedans exactement comme des
        // tableaux et collections dans des variables sans objet.

        // ici on a pris un dictionnaire pour avoir accès aux collections
        // génériques et à la simplicité d’usage sans devoir prédéfinir
        // une longueur de tableau, mais c’est tout à fait possible de faire
        // pareil juste avec un arraList[] typé et normal.

        // le fait de placer un indexeur permet de retrouver une propriété en
        // appelant l’index sur l’objet et non pas sur une de ses propriétés.

        // on peut mettre autant d’indexeurs qu’on veut du moment que le type
        // de leur index n’est pas le même, ex:
        // bankBooks[CurrentAccount]   par type CurrentAccount
        // bankBooks[123]       par type int
        // bankBooks["AAA-000"] par type string

        // le programme se fiche éperdument de savoir si c’est un array[],
        // une List<> ou un Dict<>.

        // Ce qui compte c’est que ce qui est mis entre les crochets d’index []
        // est essentiellement différent, c’est à dire que la *signature*
        // soit différente — c’est avec la signature qu’il recherche
        // l’indexation correspondante.
        /// </summary>

        #region champs privés
        // un champ dico qui reprend tous les comptes de la banque
        // par type d’objet CurrentAccount et Client
        private Dictionary<CurrentAccount, Client> _accountsBook = new Dictionary<CurrentAccount, Client>();

        // un champ dico qui reprend tous les comptes de la banque
        // par leur _accountID et Client
        private Dictionary<string, Client> _accountsBookByID = new Dictionary<string, Client>();
        #endregion

        #region propriétés publiques
        // propriété pour retrouver les clients à partir d’un objet CurrentAccount
        // càd la signature de cet index d’objet est de type CurrentAccount
        public Client this[CurrentAccount key]
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
        // càd la signature de cet index d’objet est de type string
        public Client this[string key]
        {
            get
            {
                Client client;
                _accountsBookByID.TryGetValue(key, out client);
                return client;
            }
        }
        #endregion

        #region méthodes de population des champs
        // méthode pour ajouter un compte via son _accountID
        public void AddAccountByID(CurrentAccount account)
        {
            _accountsBookByID.Add(account.AccountID, account.Owner);
        }

        // méthode pour ajouter un objet CurrentAccount tout entier
        public void AddAccount(CurrentAccount account)
        {
            _accountsBook.Add(account, account.Owner);
        }
        #endregion

        #endregion

        #region surcharge d’opérateurs
        // ici j’ai pas compris comment on était supposés faire avec une surcharge d’opérateurs?!
        // donc juste une méthode normale
        public double HowRichYouAre(Client client)
        {
            double result = 0;
            List<CurrentAccount> accounts = new List<CurrentAccount>();

            // retourner tous les comptes appairés au client dans une liste
            foreach (KeyValuePair<CurrentAccount, Client> item in _accountsBook)
            {
                if (item.Value == client)
                {
                    accounts.Add(item.Key);
                }
            }

            // additioner la valeur sur chaque compte retourné
            foreach (CurrentAccount account in accounts)
            {
                result += account.Balance;
            }

            return result;
        }
        #endregion
    }
}
