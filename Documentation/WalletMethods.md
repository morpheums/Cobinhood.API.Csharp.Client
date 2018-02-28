# Wallet Methods
## Get Wallet Balances
Get balances of the current user.
### Example:
 
```c#
    var walletBalances = cobinhoodClient.GetWalletBalances().Result;
```
### Method Signature:

```c#
    public async Task<WalletBalancesInfo> GetWalletBalances()
```

## Get Ledger Entries
Get balance history for the current user.
### Example:
 
```c#
    var ledgerEntries = cobinhoodClient.GetLedgerEntries("ETH").Result;
```
### Method Signature:

```c#
    public async Task<LedgerEntriesInfo> GetLedgerEntries(string currency = "", int? limit = null, int? page = null)
```

## Get Deposit Addresses
Get Wallet Deposit Addresses.
### Example:
 
```c#
    var depositAddrresses = cobinhoodClient.GetDepositAddresses().Result;
```
### Method Signature:

```c#
    public async Task<DepositAddressesInfo> GetDepositAddresses(string currency = "")
```

## Get Withdrawal Addresses
Get Wallet Withdrawal Addresses.
### Example:
 
```c#
    var withdrawalAddresses = cobinhoodClient.GetWithdrawalAddresses("ETH").Result;
```
### Method Signature:

```c#
    public async Task<WithdrawalAddressesInfo> GetWithdrawalAddresses(string currency = "")
```

## Get Withdrawal
Get Withdrawal Information.
### Example:
 
```c#
    var withdrawalInfo = cobinhoodClient.GetWithdrawal("62056df2d4cf8fb9b15c7238b89a1438").Result;
```
### Method Signature:

```c#
    public async Task<WithdrawalInfo> GetWithdrawal(string withdrawalId)
```

## Get All Withdrawals
Get All Withdrawals.
### Example:
 
```c#
    var withdrawalsInfo = cobinhoodClient.GetAllWithdrawals("ETH").Result;
```
### Method Signature:

```c#
    public async Task<AllWithdrawalInfo> GetAllWithdrawals(string currency = "", WithdrawalStatus withdrawalStatus = WithdrawalStatus.All, int? limit = null, int? page = null)
```

## Get Deposit
Get Deposit Information.
### Example:
 
```c#
    var depositInfo = cobinhoodClient.GetDeposit("00227f3d-02d7-47cb-8cbc-7768ee04815f").Result;
```
### Method Signature:

```c#
    public async Task<DepositInfo> GetDeposit(string depositId)
```

## Get All Deposits
Get All Deposits.
### Example:
 
```c#
    var depositsInfo = cobinhoodClient.GetAllDeposits().Result;
```
### Method Signature:

```c#
    public async Task<AllDepositsInfo> GetAllDeposits()
```