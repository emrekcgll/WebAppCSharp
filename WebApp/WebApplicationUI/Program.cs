var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
//app.UseStatusCodePages(); //404 sayfa yönlendirmesi
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error","?code={0}"); //Yönlendirilecek error sayfasýnýn belirlenmesi

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
