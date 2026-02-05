using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// URL повторяет e-mail: izzatulla.unusov@gmail.com
app.MapGet("/izzatulla_unusov_gmail_com", (HttpContext ctx) =>
{
    string x = ctx.Request.Query["x"];
    string y = ctx.Request.Query["y"];

    // Проверка: натуральные числа
    if (!long.TryParse(x, out long a) ||
        !long.TryParse(y, out long b) ||
        a <= 0 || b <= 0)
    {
        return Results.Text("NaN");
    }

    // НОД (алгоритм Евклида)
    static long Gcd(long m, long n)
    {
        while (n != 0)
        {
            long temp = n;
            n = m % n;
            m = temp;
        }
        return m;
    }

    long gcd = Gcd(a, b);

    // Защита от переполнения
    long lcm = (a / gcd) * b;

    return Results.Text(lcm.ToString());
});

app.Run();
