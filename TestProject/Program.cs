string[,] items =
{
    {"Pliers", "$12,50", "true"},
    {"Hammer", "$25,00", "false"},
    {"Screwdriver", "$8,20", "true"}
};

//display input info
for (int i = 0; i < items.GetLength(0); i++)
{
    Console.WriteLine($"Item {i+1}: Name = \"{items[i,0]}\", Price = \"{items[i,1]}\", InStock = {items[i,2]}");
}

Console.WriteLine($"Total Cost: {CalculateAvailableTotal(items):N2}");

decimal CalculateAvailableTotal(string[,] items)
{
    decimal totalCost = 0;
    for (int i = 0; i < items.GetLength(0); i++)
    {
        bool inStock = bool.Parse(items[i,2]);
        decimal itemPrice = decimal.Parse(items[i,1].Trim('$'));
        if ((inStock) /*&& (itemPrice > 10.00m)*/)
        {
            totalCost += itemPrice;
            Console.WriteLine($"Item: {items[i,0]} | Price: {itemPrice:N1}");
        }
    }
    return totalCost;
}