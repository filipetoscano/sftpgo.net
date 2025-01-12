namespace SftpGo;

/// <summary />
public enum FsProviders
{
    /// <summary />
    LocalFilesystem = 0,

    /// <summary />
    S3 = 1,

    /// <summary />
    GoogleCloudStorage = 2,

    /// <summary />
    AzureBlobStorage = 3,

    /// <summary />
    LocalEncryptedFilesystem = 4,

    /// <summary />
    Sftp = 5,

    /// <summary />
    HttpFilesystem = 6,
}