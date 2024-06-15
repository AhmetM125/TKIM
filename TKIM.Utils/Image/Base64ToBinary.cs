namespace TKIM.Utils.Image;

public static class Base64ToBinary
{
    public static byte[] ConvertBase64ToBinary(string base64)
    {
        var base64WithoutHeader = base64;
        return Convert.FromBase64String(base64WithoutHeader);
    }
}
