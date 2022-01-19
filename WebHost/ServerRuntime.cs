namespace WebHost;

public static class ServerRuntime
{
    public static async Task StartAsync()
    {
        var options = new WebApplicationOptions { ApplicationName = "WebHost" };
        
        var builder = WebApplication.CreateBuilder( options );
        
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.WebHost.UseUrls("http://localhost:5051");

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        await app.RunAsync();
    }
}