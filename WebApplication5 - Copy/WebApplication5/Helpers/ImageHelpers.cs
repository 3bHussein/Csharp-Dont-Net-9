namespace WebApplication5.Helpers
{
    public static class ImageHelpers
    {

        public static string ConvertMainImage(this string imageBase64, IWebHostEnvironment environment)
        {
            var array = Convert.FromBase64String(imageBase64.Split(";base64,")[1]);
            string imageName = Guid.NewGuid().ToString() + ".png";
            using (FileStream file = new FileStream($"{environment.WebRootPath}//images//{imageName}", FileMode.CreateNew, FileAccess.Write))
            {
                file.Write(array, 0, array.Length);
            }
            return imageName;

        }
    }
}
