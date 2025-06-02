using Modelo;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

static void FillCostumerData()
{
    for (int i = 0; i < 10; i++)
    {
        Customer customer = new()
        {
            Id = i,
            Name = $"Customer {i}",
            HomeAddres = new Address()
            {
                AddressType = "Casa",
                City = "Videira",
                Country = "HU3HU3BR",
                State = "SC",
                PostalCode = "89650-000",
                Street1 = "Rua da minha casa",
                Street2 = "Sua casa"
            }
        };

        CustomerData.Customers.Add(customer);
    }
}