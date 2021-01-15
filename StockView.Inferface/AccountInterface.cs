using System;

namespace StonkView.Inferface
{
    public interface IAccount
    {

    }

    public interface IAccountDAL
    {
        void SetConnection(string connectionString);
        string GetUsername();
        int GetAccountID();
        void CreateAccount(string username, string password, string email);
        int GetAccount(string username, string password);
    }
}
