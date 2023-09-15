using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MiniMap.Core;

public static class EndpointRouteBuilderExtensions
{
	public static IEndpointRouteBuilder UseMiniMap(this IEndpointRouteBuilder endpointRouteBuilder)
	{
		var builders = endpointRouteBuilder.ServiceProvider
			.GetService<IEnumerable<IMiniMapEndpointBuilder>>()
				?? Array.Empty<IMiniMapEndpointBuilder>();
		foreach (var builder in builders)
		{
			builder.Build(endpointRouteBuilder);
		}

		return endpointRouteBuilder;
	}
}