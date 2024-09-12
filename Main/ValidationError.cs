namespace Main;

public class ValidationError
{
    private string message;

    protected ValidationError(string message)
    {
        this.message = message;
    }

    public static ValidationError InvalidLength =
        new ValidationError("Please enter odd move number.");

    public static ValidationError InvalidArguments =
        new ValidationError("All moves must be distinct.");

    public override string ToString()
    {
        return string.Join("\n",
            "Argument error.",
            message);
    }
}
