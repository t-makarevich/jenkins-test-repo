using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

[TestFixture]
public class BaseTest : PageTest
{
    [SetUp]
    public async Task OpenMainPage()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/");
    }
}