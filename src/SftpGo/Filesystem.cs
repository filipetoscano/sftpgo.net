using System.Text.Json.Serialization;

namespace SftpGo;

/// <summary />
public class Filesystem
{
    /// <summary />
    public FilesystemProvider Provider { get; set; }

    /// <summary />
    [JsonPropertyName( "osconfig" )]
    public LocalFilesystem? Local { get; set; }

    /// <summary />
    [JsonPropertyName( "s3config" )]
    public AwsS3Filesystem? AwsS3 { get; set; }

    /// <summary />
    [JsonPropertyName( "gcsconfig" )]
    public GoogleCloudStorageFilesystem? GoogleCloudStorage { get; set; }

    /// <summary />
    [JsonPropertyName( "azblobconfig" )]
    public AzureBlobStorageFilesystem? AzureBlobStorage { get; set; }

    /// <summary />
    [JsonPropertyName( "cryptconfig" )]
    public LocalEncryptedFilesystem? LocalEncrypted { get; set; }

    /// <summary />
    [JsonPropertyName( "sftpconfig" )]
    public SftpFilesystem? Sftp { get; set; }

    /// <summary />
    [JsonPropertyName( "ftpconfig" )]
    public FtpFilesystem? Ftp { get; set; }

    /// <summary />
    [JsonPropertyName( "httpconfig" )]
    public HttpFilesystem? Http { get; set; }
}


/// <summary />
public class LocalFilesystem
{
    // TODO
}


/// <summary />
public class AwsS3Filesystem
{
    // TODO
}


/// <summary />
public class GoogleCloudStorageFilesystem
{
    // TODO
}


/// <summary />
public class AzureBlobStorageFilesystem
{
    // TODO
}


/// <summary />
public class LocalEncryptedFilesystem
{
    // TODO
}


/// <summary />
public class SftpFilesystem
{
    // TODO
}


/// <summary />
public class FtpFilesystem
{
    // TODO
}


/// <summary />
public class HttpFilesystem
{
    // TODO
}