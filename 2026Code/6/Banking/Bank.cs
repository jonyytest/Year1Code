class Bank
{
    private List<Account> _accounts;
    public Bank()
    {
        _accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public Account GetAccount(String name)
    {
        for (int i = 0; i < _accounts.Count; i++)
        {
            if (_accounts[i]._Name() == name) return _accounts[i];
        }
        return null;
    }

    public void ExecuteTransaction(DepositTransaction transaction)
    {
        transaction.Execute();
    }

    public void ExecuteTransaction(WithdrawTransaction transaction)
    {
        transaction.Execute();
    }

    public void ExecuteTransaction(TransferTransaction transaction)
    {
        transaction.Execute();
    }

}