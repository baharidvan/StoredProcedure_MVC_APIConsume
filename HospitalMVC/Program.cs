var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient();
var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
 