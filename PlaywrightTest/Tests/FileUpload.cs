using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System.IO;

public class FileUpload : BaseTest
{
    string path = @"C:\Users\t3.makarevich\csharpProjects\trainings\tasks_before_exams\PlaywrightTest\tempUploadFiles\";
    string fileName = "testFile.txt";
    
    [SetUp]
    public async Task SetUploadDirectory()
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + fileName, "This is the uploaded test file.");
    }

    [Test]
    public async Task FileUploadSuccess()
    {
        await Page.GetByRole(AriaRole.Link, new() {Name = "File Upload", Exact = true}).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() {Name = "Choose File"}).SetInputFilesAsync(path+fileName);
        await Page.GetByRole(AriaRole.Button, new() {Name = "Upload"}).ClickAsync();
        await Expect(Page.GetByText(fileName)).ToBeVisibleAsync();
    }

    [TearDown]
    public async Task ClearUploadDirectory()
    {
        Directory.Delete(path, recursive: true);
    }
}