## How to document code

Document your code with xml(///summary), example:
```c#
/// <summary>
/// Defines a repository responsible for generating predictions based on a given model file
/// </summary>
public interface IPredictionRepository
{
    /// <summary>
    /// Gets the model type associated with this prediction repository
    /// </summary>
    public ModelType ForModelType { get; }

    /// <summary>
    /// Generates predictions based on the specified settings and model file
    /// </summary>
    /// <param name="predictionSettings">Prediction settings matching the model type</param>
    /// <param name="modelFile">The model file used for predictions</param>
    /// <returns>A list of predictions</returns>
    public List<Prediction> GetPredictions(IPredictionSettings predictionSettings, MemoryStream modelFile);
}
``` 

## This will help you generate documentation for your project using [DocFX](https://dotnet.github.io/docfx/) locally.

### Install DocFX

You can install DocFX globally via NuGet. Run the following command:

```bash
dotnet tool install -g docfx
```

### Run DocFX

Navigate to the root directory of your project and run command:

```bash
docfx docfx.json --serve
```