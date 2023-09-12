using Microsoft.AspNetCore.Routing;

namespace MiniMap.Core;

public interface IMinimalMapEndpointBuilder
{
	void Build(IEndpointRouteBuilder endpointRouteBuilder);
}
