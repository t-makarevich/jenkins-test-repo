using Microsoft.Playwright;

public class ElementState : BaseTest
{
    string text = "random text";
    [Test]
    public async Task ElemmentStateChecks()
    {
        await Page.GetByRole(AriaRole.Link, new() {Name = "Dynamic Controls"}).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() {Name = "Enable"}).ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Textbox)).ToBeEnabledAsync();

        await Page.GetByRole(AriaRole.Textbox).FillAsync(text);
        await Expect(Page.GetByRole(AriaRole.Textbox)).ToHaveValueAsync(text);
    }
}