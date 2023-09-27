namespace MVCLab.Models
{
    public class MyTool
    {
        public static string UploadFile(IFormFile myfile, string directory)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", directory, myfile.FileName);
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    myfile.CopyTo(file);
                }
                return myfile.FileName;
            }
            catch { return string.Empty; }
        }
    }
}
