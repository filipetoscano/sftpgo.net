namespace SftpGo;

/// <summary />
public enum FilesystemProvider
{
    /// <summary />
    None = -1,

    /// <summary />
    Local = 0,

    /// <summary />
    AwsS3 = 1,

    /// <summary />
    GoogleCloudStorage = 2,

    /// <summary />
    AzureBlobStorage = 3,

    /// <summary />
    LocalEncrypted = 4,

    /// <summary />
    Sftp = 5,

    /// <summary />
    Http = 6,

    /// <summary />
    Ftp = 7,
}