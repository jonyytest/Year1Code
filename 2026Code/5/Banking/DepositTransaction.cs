class DepositTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed;
    private bool _success;
    private bool _reversed;
    public bool Executed { get { return _executed; } }
    public bool Reversed { get { return _reversed; } }
    public bool Success { get { return _success; } }

    public DepositTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
        _executed = false;
        _success = false;
        _reversed = false;
    }

    public void Print()
    {
        if (_success && !_reversed)
        {
            Console.WriteLine("Deposit Status: Successfully deposited " + _amount.ToString("C") + " into " + _account._Name());
        }
        else if (_reversed)
        {
            Console.WriteLine("Deposit Status: Transaction was successfully reversed.");
        }
    }

    public void Execute()
    {
        if (_executed)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }
        _executed = true;
        
        bool depositResult = _account.Deposit((double)_amount);
        if (!depositResult)
        {
            throw new InvalidOperationException("Insufficient funds or invalid transaction.");
        }
        _success = true;
    }

    public void Rollback()
    {
        if (!_success)
        {
            throw new InvalidOperationException("Cannot rollback a transaction that was not successful.");
        }
        
        if (_reversed)
        {
            throw new InvalidOperationException("Transaction has already been reversed.");
        }
        _account.Withdraw((double)_amount);
        _reversed = true;
    }
}