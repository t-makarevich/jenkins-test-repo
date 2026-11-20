using System.Globalization;
using Microsoft.Playwright;

public class ListOfElements : BaseTest
{
    decimal actualSum;
    decimal expectedSum;

    [SetUp]
    public void StartFromZero()
    {
        actualSum = 0;
        expectedSum = 251;
    }

    [Test]
    public async Task Tables()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Sortable Data Tables" }).ClickAsync();
        var allDues = Page.Locator("#table1").GetByRole(AriaRole.Cell, new() { Name = "$" });
        await allDues.First.WaitForAsync(); //to give enough time to succeed in headless mode :/
        var count = await allDues.CountAsync();
        //Console.WriteLine(count); //for debug purposes
        for (int i = 0; i < count; i++)
        {
            string currentDueString = await allDues.Nth(i).InnerTextAsync();
            decimal currentDue = decimal.Parse(currentDueString.Substring(1).Replace('.', ','));
            actualSum += currentDue;
            Console.WriteLine(actualSum); //for debug purposes
        }
        
        //Console.WriteLine(actualSum); //for debug purposes
        Assert.That(actualSum, Is.EqualTo(expectedSum));
    }

    [TearDown]
    public void EndWithZerio()
    {
        actualSum = 0;
        expectedSum = 0;
    }
}