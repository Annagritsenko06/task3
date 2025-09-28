using System;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

long Gcd(long a, long b)
{
    a = Math.Abs(a);
    b = Math.Abs(b);
    while (b != 0)
    {
        long t = b;
        b = a % b;
        a = t;
    }
    return a;
}

app.MapGet("/app/angritsen_gmail_com", (string x, string y) =>
{
    if (!long.TryParse(x, out long xi) || !long.TryParse(y, out long yi))
        return Results.Text("NaN", "text/plain");

    if (xi <= 0 || yi <= 0)
        return Results.Text("NaN", "text/plain");

    long gcd = Gcd(xi, yi);
    long nok = (xi / gcd) * yi;
    return Results.Text(nok.ToString(), "text/plain");
});

app.Run();
