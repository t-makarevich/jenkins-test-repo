using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

public class NestedFrames : BaseTest
{
    [Test]
    public async Task NestedFramesLeftAndRight()
    {
        await Page.GetByRole(AriaRole.Link, new() {Name = "Frames", Exact = true}).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() {Name = "Nested Frames"}).ClickAsync();

        var leftFrame = Page.FrameLocator("frame[name='frame-top']").FrameLocator("frame[name='frame-left']");
        await Expect(leftFrame.Locator("body").GetByText("LEFT")).ToBeVisibleAsync(); //should i use to be visible or to have text?

        var rightFrame = Page.FrameLocator("frame[name='frame-top']").FrameLocator("frame[name='frame-right']");
        await Expect(rightFrame.Locator("body")).ToHaveTextAsync("RIGHT"); //don't feel the difference
    }
}