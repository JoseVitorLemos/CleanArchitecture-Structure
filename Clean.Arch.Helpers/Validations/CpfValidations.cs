using System.Text.RegularExpressions;

namespace Clean.Arch.Helpers.Validations;

public class CpfValidations
{
    public static bool IsValid(string cpf)
    {
        string cpfClear = Regex.Replace(cpf, @"[^a-zA-Z0-9]", "");

        if (cpfClear.Length != 11) return false;

        if (new string(cpfClear[0], cpfClear.Length) == cpfClear) return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (10 - i) * (cpfClear[i] - '0');

        int rest = sum % 11;
        int digitValidationOne = rest < 2 ? 0 : 11 - rest;

        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += (11 - i) * (cpfClear[i] - '0');
        }
        rest = sum % 11;
        int digitValidationTwo = rest < 2 ? 0 : 11 - rest;

        return digitValidationOne == (cpfClear[9] - '0') && digitValidationTwo == (cpfClear[10] - '0');
    }
}
