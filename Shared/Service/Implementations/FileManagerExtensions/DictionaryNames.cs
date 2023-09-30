using Shared.PublicEnums;

namespace Shared.Service.Implementations.FileManagerExtensions;

public static class DictionaryNames
{
    public static readonly Dictionary<ImageType, string> Dictionary = new()
    {
        { ImageType.Image, "images"}
    };
}