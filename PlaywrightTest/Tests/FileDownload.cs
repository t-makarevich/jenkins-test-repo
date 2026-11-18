using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

[TestFixture]
public class FileDownload : BaseTest
{
    public string path = @"C:\Users\t3.makarevich\csharpProjects\trainings\tasks_before_exams\PlaywrightTest\tempFiles\";
    [SetUp]
    public async Task SetDownloadDirectory()
    {
        Directory.CreateDirectory(path);
    }
    [Test]
    public async Task FileDownloadSuccessful()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "File Download", Exact = true }).ClickAsync();
        Assert.That(await Page.GetByRole(AriaRole.Link, new() { Name = "test.txt" })
            .Filter(new() { HasNotText = "-" })
            .Filter(new() {HasNotText = "manual"}) //added this part because apparently while preparing for next task, I uploaded a new file 
            .IsVisibleAsync());

        var waitForDownloadTask = Page.WaitForDownloadAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "test.txt" })
            .Filter(new() { HasNotText = "-" })
            .Filter(new() {HasNotText = "manual"}) //same as above, to avoid strictness
            .ClickAsync();
        var download = await waitForDownloadTask;

        await download.SaveAsAsync(path + download.SuggestedFilename);
        Assert.That(download.SuggestedFilename, Is.EqualTo("test.txt"));
    }
    
    [TearDown]
    public async Task ClearTempDirectory()
    {
        Directory.Delete(path, recursive: true);
    }
}