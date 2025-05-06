using Mages.Core;

namespace FlexibleModules;

class EndpointDef
{
    public required string Method { get; set; }

    public required string Path { get; set; }

    public required Function Handler { get; set; }
}
