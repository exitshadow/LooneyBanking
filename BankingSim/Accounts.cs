using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooneyBank
{
    public class Account
    {
        private string _accountID;
        private double _inAccount;
        private double _creditLine;
        private Client _owner;

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

        public void Draw()
        {

        }
        public void Deposit()
        {

        }
    }
}
