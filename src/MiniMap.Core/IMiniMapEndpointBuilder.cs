using Microsoft.AspNetCore.Routing;

namespace MiniMap.Core;

public interface IMiniMapEndpointBuilder
{
	void Build(IEndpointRouteBuilder endpointRouteBuilder);
}
