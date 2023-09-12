using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MiniMap.Core;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddMinimalMap(this IServiceCollection services)
	{
		var assemblies = new Assembly[] { Assembly.GetExecutingAssembly() };
		return services.AddMinimalMap(assemblies);
	}

	public static IServiceCollection AddMinimalMap<T>(this IServiceCollection services)
	{
		var assembly = typeof(T).Assembly;
		return services.AddMinimalMap(assembly);
	}

	public static IServiceCollection AddMinimalMap(this IServiceCollection services, Type typeInAssembly)
	{
		var assembly = typeInAssembly.Assembly;
		return services.AddMinimalMap(assembly);
	}

	public static IServiceCollection AddMinimalMap(this IServiceCollection services, Assembly assembly)
	{
		var assemblies = new Assembly[] { assembly };
		return services.AddMinimalMap(assemblies);
	}

	public static IServiceCollection AddMinimalMap(this IServiceCollection services, IEnumerable<Assembly> assemblies)
	{
		var types = assemblies
			.SelectMany(a => a.GetTypes()
				.Where(t =>
					!t.IsAbstract
					&& typeof(IMinimalMapEndpointBuilder).IsAssignableFrom(t)
					&& t != typeof(IMinimalMapEndpointBuilder)
					&& t.IsPublic
				)
			);

		foreach (var t in types)
		{
			services.AddSingleton(typeof(IMinimalMapEndpointBuilder), t);
		}

		return services;
	}
}