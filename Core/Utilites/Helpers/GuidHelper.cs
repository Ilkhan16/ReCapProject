namespace Core.Utilities.Helpers.GuidHelperr;

public class GuidHelper
{
    public static string CreateGuid()
    {
        return Guid.NewGuid().ToString();
    }
}