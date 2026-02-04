using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Ссылка должна повторять e-mail: izzatulla.unusov@gmail.com
// Все символы кроме букв и цифр заменены на "_"
app.MapGet("/izzatulla_unusov_gmail_com", (HttpContext ctx) =>
{
    // Берем параметры x и y из URL
    string x = ctx.Request.Query["x"];
    string y = ctx.Request.Query["y"];

    // Проверяем, что это натуральные числа (>0)
    if (!int.TryParse(x, out int a) || !int.TryParse(y, out int b) || a <= 0 || b <= 0)
    {
        return Results.Text("NaN");
    }

    // Функция для НОД
    int Gcd(int m, int n)
    {
        while (n != 0)
        {
            int temp = n;
            n = m % n;
            m = temp;
        }
        return m;
    }

    // Вычисляем НОК
    int lcm = a / Gcd(a, b) * b;

    // Возвращаем только строку с цифрами
    return Results.Text(lcm.ToString());
});

// Запуск сервера
app.Run();
