using SdaTithe.Models;
namespace SdaTithe.Services;

public static class Session
{
    public static User? Current { get; set; }
}