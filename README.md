# Patchable

## About Project
The project contains implementations of two model binders.
- `ComposableModelBinder` allows to combine data in one model from different source: the body, the route and the query string to the HTTP request.
- `PatchableModelBinder` allows to access the list of properties which were passed in the HTTP request. `PatchableModelBinder` inherits `ComposableModelBinder`.

## How to use
- To enable these binders you just need to add this code in your pipeline:
```csharp
builder.Services.AddControllers(options => options.AddPatchable());
```
- Inherit a model from the <see cref="IComposable"/> if you need a model that binds to parameters from the body, the route and the query string of the HTTP request in one object. The data will bind with priority. The priority from the lowest to highest is the body, the route, and the query string.
```csharp
public record class PostBookRequestDto(string Title, string Description, string[] Authors) : IComposable
{
  public PostBookRequestDto() : this(string.Empty, string.Empty, Array.Empty<string>()) { }
}
```
- Inherit a model from the <see cref="IPatchable"/> if you need a model that binds to parameters from the body, the route and the query string of the HTTP request in one object and/or a list of properties that have been populated from the HTTP request.
```csharp
public record class PatchBookRequestDto(Guid BookId, string Title, string Description, string[] Authors) : IPatchable
{
  public PatchBookRequestDto() : this(Guid.Empty, string.Empty, string.Empty, Array.Empty<string>()) { }

  public string[] Properties { get; set; } = Array.Empty<string>();
}
```

For more information you might see [a sample](https://github.com/dennisshevtsov/patchable/tree/main/sample/Patchable.Sample). This sample contains a JMeter [test](https://github.com/dennisshevtsov/patchable/blob/main/sample/Patchable.Sample/Test/api-test.jmx) which can be run to check the API.
