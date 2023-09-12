using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MiniMap.Core;

public static class EndpointRouteBuilderExtensions
{
	public static IEndpointRouteBuilder UseMinimalMap(this IEndpointRouteBuilder endpointRouteBuilder)
	{
		var builders = endpointRouteBuilder.ServiceProvider.GetServices<IMinimalMapEndpointBuilder>();
		foreach (var builder in builders)
		{
			builder.Build(endpointRouteBuilder);
		}

		return endpointRouteBuilder;
	}
}