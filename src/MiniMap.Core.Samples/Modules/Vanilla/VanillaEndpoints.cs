namespace MiniMap.Core.Samples.Modules.Vanilla;

public static class VanillaEndpoints
{
	internal static void UseVanillaEndpoints(this IEndpointRouteBuilder app)
	{
		var summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		app.MapGet("/vanilla/weatherforecast", (HttpContext httpContext) =>
		{
			var forecast = Enumerable.Range(1, 5).Select(index =>
				new WeatherForecast
				{
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = summaries[Random.Shared.Next(summaries.Length)]
				})
				.ToArray();
			return forecast;
		})
		.WithOpenApi();
	}
}
