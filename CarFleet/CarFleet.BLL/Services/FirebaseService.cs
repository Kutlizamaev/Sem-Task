using Firebase.Storage;

namespace CarFleet.BLL.Services
{
    public class FirebaseService
    {
        private static string Bucket = "carfleet-777.appspot.com";

        public async Task UploadFile(FileStream file, string fileName)
        {
            var uploadTask = new FirebaseStorage(Bucket)
                .Child($"{fileName}.jpg")
                .PutAsync(file);

            await uploadTask;
        }
    }
}
