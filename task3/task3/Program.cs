using System;
using System.Numerics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();

BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        var t = b;
        b = a % b;
        a = t;
    }
    return a;
}

app.MapGet("/app/vugorenko2000_gmail_com", (string x, string y) =>
{
    if (!BigInteger.TryParse(x, out var xi) || !BigInteger.TryParse(y, out var yi))
        return Results.Text("NaN", "text/plain");

    if (xi <= 0 || yi <= 0)
        return Results.Text("NaN", "text/plain");

    var gcd = Gcd(xi, yi);
    var lcm = (xi / gcd) * yi;

    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();

