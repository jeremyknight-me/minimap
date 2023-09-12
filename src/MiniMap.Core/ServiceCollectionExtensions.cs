using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MiniMap.Core;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddMiniMap(this IServiceCollection services)
	{
		var assemblies = new Assembly[] { Assembly.GetExecutingAssembly() };
		return services.AddMiniMap(assemblies);
	}

	public static IServiceCollection AddMiniMap<T>(this IServiceCollection services) 
		=> services.AddMiniMap(typeof(T));

	public static IServiceCollection AddMiniMap(this IServiceCollection services, Type typeInAssembly)
	{
		var assembly = typeInAssembly.Assembly;
		return services.AddMiniMap(assembly);
	}

	public static IServiceCollection AddMiniMap(this IServiceCollection services, Assembly assembly)
	{
		var assemblies = new Assembly[] { assembly };
		return services.AddMiniMap(assemblies);
	}

	public static IServiceCollection AddMiniMap(this IServiceCollection services, IEnumerable<Assembly> assemblies)
	{
		var types = assemblies
			.SelectMany(a => a.GetTypes()
				.Where(t =>
					!t.IsAbstract
					&& typeof(IMiniMapEndpointBuilder).IsAssignableFrom(t)
					&& t != typeof(IMiniMapEndpointBuilder)
					&& t.IsPublic
				)
			);

		foreach (var t in types)
		{
			services.AddSingleton(typeof(IMiniMapEndpointBuilder), t);
		}

		return services;
	}
}