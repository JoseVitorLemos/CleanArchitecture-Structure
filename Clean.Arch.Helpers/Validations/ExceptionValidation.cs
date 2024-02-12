namespace Clean.Arch.Helpers.Validations;

public sealed class ExceptionValidation : Exception
{
    public ExceptionValidation(string error) : base(error) {}

    public static void When(bool hasError, string error)
    {
        if (hasError)
            throw new ExceptionValidation(error);
    }
}
