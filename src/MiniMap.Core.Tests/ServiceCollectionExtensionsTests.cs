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
		this.AssertCollection();
	}

	[Fact]
	public void AddMiniMap_TypeInAssembly()
	{
		services.AddMiniMap(typeof(TestMiniMapEndpointBuilder));
		this.AssertCollection();
	}

	[Fact]
	public void AddMiniMap_Assembly()
	{
		services.AddMiniMap(typeof(TestMiniMapEndpointBuilder).Assembly);
		this.AssertCollection();
	}

	[Fact]
	public void AddMiniMap_Assemblies()
	{
		services.AddMiniMap(new[] { typeof(TestMiniMapEndpointBuilder).Assembly });
		this.AssertCollection();
	}

	private void AssertCollection()
	{
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
}
