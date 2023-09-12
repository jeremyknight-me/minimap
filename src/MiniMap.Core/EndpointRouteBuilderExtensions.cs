using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MiniMap.Core;

public static class EndpointRouteBuilderExtensions
{
	public static IEndpointRouteBuilder UseMiniMap(this IEndpointRouteBuilder endpointRouteBuilder)
	{
		var builders = endpointRouteBuilder.ServiceProvider.GetServices<IMiniMapEndpointBuilder>();
		foreach (var builder in builders)
		{
			builder.Build(endpointRouteBuilder);
		}

		return endpointRouteBuilder;
	}
}