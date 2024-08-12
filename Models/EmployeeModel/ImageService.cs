using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

public class ImageService
{
    // Coudinary Service Injection.
    private readonly Cloudinary _cloudinary;

    public ImageService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    // Resolver to upload image into Cloudinary.
    public async Task<string> UploadImageAsync(IFile file)
    {
        try
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.Name, file.OpenReadStream())
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.AbsoluteUri;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // Resolver to delete image from Cloudinary.
    public async Task DeleteImageAsync(string imageUrl)
    {
        try
        {
            // Extract the public ID from the image URL
            var publicId = ExtractPublicIdFromUrl(imageUrl);
            if (string.IsNullOrEmpty(publicId))
            {
                throw new Exception("Invalid image URL");
            }
            var deletionParams = new DeletionParams(publicId);
            var deletionResult = await _cloudinary.DestroyAsync(deletionParams);

            if (deletionResult.Result != "ok")
            {
                throw new Exception($"Failed to delete image: {deletionResult.Error?.Message}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the image: {ex.Message}");
        }
    }

    // Resolver to extract the public ID from the image URL.
    private string ExtractPublicIdFromUrl(string imageUrl)
    {
        var uri = new Uri(imageUrl);
        var segments = uri.Segments;
        if (segments.Length >= 2)
        {
            var publicId = segments[segments.Length - 1];
            return publicId.Split('.')[0];
        }
        return null;
    }
}