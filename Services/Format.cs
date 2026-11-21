namespace SdaTithe.Services;

public static class Format
{
    public static string Rwf(long amount) => amount.ToString("N0") + " RWF";

    public static string? MethodFromLabel(string label) => label switch
    {
        "MTN MoMo" => "MTN",
        "Airtel Money" => "Airtel",
        "Card" => "Card",
        _ => null
    };
}