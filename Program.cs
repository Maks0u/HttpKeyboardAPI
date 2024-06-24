using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using HttpKeyboardAPI;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
  serverOptions.ListenLocalhost(5000);
});

var app = builder.Build();

app.MapGet("/health", () => Results.Ok("OK"));

app.MapGet("/keycodes", () => Results.Json(KeyCodes.Codes));

app.MapPost("/keypress", async (HttpContext context) =>
{
  try
  {
    var keyCombination = await JsonSerializer.DeserializeAsync<KeyCombination>(context.Request.Body);

    if (keyCombination == null || keyCombination.Keys.Count == 0)
    {
      return Results.BadRequest("Bad request");
    }

    var keyCodes = keyCombination.Keys
      .Where(key => KeyCodes.Codes.ContainsKey(key.ToUpper()))
      .Select(key => KeyCodes.Codes[key.ToUpper()])
      .ToList();

    if (keyCodes.Count == 0)
    {
      return Results.BadRequest("No valid keys found in the request");
    }

    KeyPressSimulator.PressKeys(keyCodes);
    return Results.Ok("OK");
  }
  catch (JsonException)
  {
    return Results.BadRequest("Invalid JSON format");
  }

});

app.Run();
