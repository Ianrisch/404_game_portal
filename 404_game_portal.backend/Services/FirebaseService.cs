using Firebase.Auth;
using Firebase.Storage;

namespace _404_game_portal.backend.Services;

public interface IFirebaseService
{
    Task<string> UploadImage(string path, string newFileName, IFormFile file);
}

public class FirebaseService : IFirebaseService
{
    private readonly FirebaseStorage _firebaseStorage = new(
        "gameportal-9d72f.appspot.com"
    );

    public async Task<string> UploadImage(string path, string newFileName, IFormFile file)
    {
        var uplaodTask = _firebaseStorage
            .Child(path)
            .Child(newFileName + file.ContentType)
            .PutAsync(file.OpenReadStream());

        uplaodTask.Progress.ProgressChanged += (s, e) =>
        {
            Console.WriteLine($"Progress: {e.Percentage} %");
        };

        var result = await uplaodTask;

        return result;
    }
}