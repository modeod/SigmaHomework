namespace SigmaHomework_7_Task2.Luhn
{
    public interface ILuhnAlgorithm
    {
        bool CheckSumValidate(byte[] cardNumber);
    }
}