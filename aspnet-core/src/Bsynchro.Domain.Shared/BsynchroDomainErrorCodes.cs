namespace Bsynchro;

public static class BsynchroDomainErrorCodes
{
    public static string TransactionHasNoValueError = "Transaction must have either a dposited or a withdrawn value but not neither!";
    public static string TransactionHasWithdrawAndDepositError = "Transaction must have either a dposited or a withdrawn value but not neither!";
    public static string FirstTransactionError = "First Transaction Cannot Have withdrawn value!";
}
