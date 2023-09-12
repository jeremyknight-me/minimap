using Microsoft.Extensions.DependencyInjection;
using MiniMap.Core.Tests.TestUtils;

namespace MiniMap.Core.Tests;

public class ServiceCollectionExtensionsTests
{
	private readonly IServiceCollection services = new ServiceCollection();

	[Fact]
	public void AddMiniMap_GenericTypeInAssembly()
	{
		services.AddMiniMap<TestMiniMapEndpointBuilder>();
		Assert.Equal(1, services.Count);
		Assert.Collection(services,
			s =>
			{
				Assert.Equal(ServiceLifetime.Singleton, s.Lifetime);
				Assert.Equal(typeof(IMiniMapEndpointBuilder), s.ServiceType);
				Assert.Equal(typeof(TestMiniMapEndpointBuilder), s.ImplementationType);
			}
		);
	}

	[Fact]
	public void AddMiniMap_TypeInAssembly()
	{
	}

	[Fact]
	public void AddMiniMap_Assembly()
	{
	}

	[Fact]
	public void AddMiniMap_Assemblies()
	{
	}
}
