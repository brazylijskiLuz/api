using Shared.PublicEnums;

namespace Shared.Service.Implementations.FileManagerExtensions.FileManagerHelper;

public interface IFileManagerHelper
{
    void RemoveLocalImage(ImageType imageType, Guid imageId);
    Task UploadFile(ImageType imageType, Guid imageId);
}