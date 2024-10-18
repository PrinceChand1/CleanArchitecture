using System.Drawing;

namespace CleanArchitecture.Application.Comman.Extensions;
public static class ExtensionMethod
{
    public static string ToCapitalize(this string input) => input switch
    {
        null => null,
        "" => "",
        _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
    };

    public static Image Base64ToImage(this string base64String)
    {
        try
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
