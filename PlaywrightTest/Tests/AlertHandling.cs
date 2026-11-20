using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

//namespace PlaywrightTest;
[TestFixture]
public class AlertHandling : BaseTest
{
    const string messageAfterButton = "You successfully clicked an alert";

/*     [SetUp]
    public async Task OpenMainPage()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/");
    } */

    [Test]
    public async Task AlertHandlingSuccessfulMessage()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "JavaScript Alerts" }).ClickAsync();
        Page.Dialog += async (_, dialog) =>
        {
            await dialog.AcceptAsync();
        };
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click for JS Alert" }).ClickAsync();
        Assert.That(await Page.GetByText(messageAfterButton).IsVisibleAsync());
    }
}

