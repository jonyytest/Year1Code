class TransferTransaction
{
    private Account _fromAccount;
    private Account _toAccount;
    private decimal _amount;
    private WithdrawTransaction _withdraw;
    private DepositTransaction _deposit;
    private bool _executed;
    private bool _reversed;
    public bool Executed { get { return _executed; } }
    public bool Reversed { get { return _reversed; } }
    public bool Success
    {
        get { return _withdraw.Success && _deposit.Success; }
    }

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _amount = amount;

        _withdraw = new WithdrawTransaction(_fromAccount, _amount);
        _deposit = new DepositTransaction(_toAccount, _amount); 

        _executed = false;
        _reversed = false;
    }

    public void Print()
    {
        _withdraw.Print();
        _deposit.Print();
        if (this.Success && !_reversed)
        {
        Console.WriteLine("Transfer Status: Successfully transferred " + _amount.ToString("C") + " from " + _fromAccount._Name() + " to " + _toAccount._Name());
        }
        else if (_reversed)
        {
            Console.WriteLine("Transfer Status: Transaction was successfully reversed.");
        }
    }

    public void Execute()
    {
        if (_executed)
        {
            throw new InvalidOperationException("Transaction has already been executed.");
        }
        _executed = true;

        try
        {
            _withdraw.Execute();
            if (_withdraw.Success)
            {
                _deposit.Execute();
            }
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Insufficient funds or invalid transaction.");
        }
    }

    public void Rollback()
    {
        if (!this.Success)
        {
            throw new InvalidOperationException("Cannot rollback a transaction that was not successful.");
        }
        
        if (_reversed)
        {
            throw new InvalidOperationException("Transaction has already been reversed.");
        }
        
        try
        {
            _deposit.Rollback();
            _withdraw.Rollback();
            _reversed = true;
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException("Rollback failed: " + ex.Message);
        }
    }
}