class ServiceResponse
{
    public List<ServiceResponseItem>? Items { get; set; } 
}

class ServiceResponseItem
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? Link { get; set; }
}
