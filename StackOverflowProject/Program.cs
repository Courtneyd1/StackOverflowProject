var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("StackExchange", client =>
{
    client.BaseAddress = new Uri("https://api.stackexchange.com/");
    client.DefaultRequestHeaders.UserAgent.ParseAdd(
        "StackOverflowProject/1.0 (+https://stackoverflow.com; development)");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Stackoverflow}/{action=Index}/{id?}");

app.Run();