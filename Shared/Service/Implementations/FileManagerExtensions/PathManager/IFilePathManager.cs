using Shared.PublicEnums;

namespace Shared.Service.Implementations.FileManagerExtensions.PathManager;

public interface IFilePathManager
{
    string FactoryOutPutPath(string fileName, ImageType imageType);
    string FactoryFilePath(ImageType imageType, Guid imageId);
    string FactoryLocalFilePath(ImageType imageType, Guid imageId);
}