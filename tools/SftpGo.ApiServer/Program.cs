namespace SftpGo.ApiServer;

/// <summary />
public partial class Program
{
    /// <summary />
    public static void Main( string[] args )
    {
        /*
         * 
         */
        var builder = WebApplication.CreateBuilder( args );

        builder.Services.AddControllers();
        builder.Services.AddOptions();


        /*
         * 
         */
        var app = builder.Build();

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}