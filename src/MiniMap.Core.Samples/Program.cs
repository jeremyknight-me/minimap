using MiniMap.Core.Samples.Modules.Vanilla; // needs access to every module

namespace MiniMap.Core.Samples;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var services = builder.Services;

		services.AddAuthorization();

		services.AddMiniMap(); // adds all endpoint builders to DI

		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.UseMiniMap(); // calls all endpoint builders to define all endpoint routes

		// one line per module is needed
		app.UseVanillaEndpoints();

		app.Run();
	}
}
