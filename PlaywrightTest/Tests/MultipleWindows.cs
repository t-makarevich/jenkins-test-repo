using Microsoft.Playwright;

public class MultipleWindows : BaseTest
{
    [Test]
    public async Task MultipleWindowsTextDisplayed()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Multiple Windows"}).ClickAsync();
        //var newPage = await Page.GetByRole(AriaRole.Link, new() { Name = "Click Here"}).ClickAsync();
        var newPage = await Context.RunAndWaitForPageAsync(async () =>
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = "Click Here" }).ClickAsync();
        });
        await newPage.WaitForLoadStateAsync();
        //await Expect(newPage).ToHaveURLAsync("https://the-internet.herokuapp.com/windows/new"); //are two Expect() bad or not?
        await Expect(newPage.GetByText("New Window" )).ToBeVisibleAsync();
    }
}