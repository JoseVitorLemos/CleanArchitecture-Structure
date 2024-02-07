using System.Text.RegularExpressions;

namespace Clean.Arch.Helpers.Validations;

public class CpfValidations
{
    public static bool IsValid(string cpf)
    {
        string cpfClear = Regex.Replace(cpf, @"[^\w]", "");

        if (cpfClear.Length != 11) return false;

        if (new string(cpfClear[0], cpfClear.Length) == cpfClear) return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (10 - i) * (cpfClear[i] - '0');

        int resto = sum % 11;
        int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += (11 - i) * (cpfClear[i] - '0');
        }
        resto = sum % 11;
        int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

        return digitoVerificador1 == (cpfClear[9] - '0') && digitoVerificador2 == (cpfClear[10] - '0');
    }
}
