namespace TKIM.Utils.Image;

public static class Base64ToBinary
{
    public static byte[] ConvertBase64ToBinary(this string base64)
    {
        var base64WithoutHeader = base64.Split(',')[1];
        return Convert.FromBase64String(base64WithoutHeader);
    }
}
