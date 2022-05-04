namespace SpecFlowProjectTesting.StepDefinitions
{
    [Binding]
    public sealed class ProductStepDefiniton
    {
        private readonly ScenarioContext _scenarioContext;
        private const string BASE_URL = "https://localhost:4440/api/v1/Product";

        ProductStepDefiniton(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


    }
}