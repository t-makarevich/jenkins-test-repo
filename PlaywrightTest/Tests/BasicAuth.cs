using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

[TestFixture]
public class BasicAuth : BaseTest
{
    const string successMessage = "Congratulations! You must have the proper credentials.";
    public override BrowserNewContextOptions ContextOptions() //how to remember that whaaaaaaaaat T.T
    {
        return new BrowserNewContextOptions()
        {
            HttpCredentials = new HttpCredentials
            {
                Username = "admin",
                Password = "admin"
            }
        };
}

    [SetUp]
    public async Task SaveAuth()
    {
        await Context.StorageStateAsync(new()
        {
            Path = "../../../.auth/state.json"
        });
    } 

    [Test]
    public async Task BasicAuthSuccess()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Basic Auth" }).ClickAsync();
        await Page.WaitForLoadStateAsync();
        //Assert.That(await Page.GetByText(successMessage).IsVisibleAsync()); //why does Assert.That fail, but Expect does not? They do the same thing?????
        await Expect(Page.GetByText(successMessage)).ToBeVisibleAsync();
    }
}