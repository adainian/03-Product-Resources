using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        //Arrange
        string productName = "Banana";
        double productPrice = 100;
        int productQuantity = 10;

        string expectedInventory = $"Product Inventory:{Environment.NewLine}{productName} - Price: ${productPrice:f2} - Quantity: {productQuantity}";

        //Act
        this._inventory.AddProduct(productName, productPrice, productQuantity);

        string result = this._inventory.DisplayInventory();

        //Assert
        Assert.AreEqual(expectedInventory, result);
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        //Arrange
        string expected = "Product Inventory:";

        //Act
        string result = this._inventory.DisplayInventory();

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        //Arrange
        string firstproductName = "Tuna";
        double firstproductPrice = 100;
        int firstproductQuantity = 10;

        string secondproductName = "Rice";
        double secondproductPrice = 10;
        int secondproductQuantity = 5;

        string expectedOutput = $"Product Inventory:{Environment.NewLine}" +
            $"{firstproductName} - Price: ${firstproductPrice:f2} - Quantity: " +
            $"{firstproductQuantity}{Environment.NewLine}{secondproductName} - Price: " +
            $"${secondproductPrice:f2} - Quantity: {secondproductQuantity}";

        //Act
        this._inventory.AddProduct(firstproductName, firstproductPrice, firstproductQuantity);
        this._inventory.AddProduct(secondproductName, secondproductPrice, secondproductQuantity);

        string result = this._inventory.DisplayInventory();

        //Assert
        Assert.AreEqual(expectedOutput, result);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        //Arrange

        //Act
        double result = this._inventory.CalculateTotalValue();

        //Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        //Arrange
        string firstproductName = "Bread";
        double firstproductPrice = 100;
        int firstproductQuantity = 2;

        string secondproductName = "Sushi";
        double secondproductPrice = 10;
        int secondproductQuantity = 5;

        double expectedTotalSum = 250;

        //Act
        this._inventory.AddProduct(firstproductName, firstproductPrice, firstproductQuantity);
        this._inventory.AddProduct(secondproductName, secondproductPrice, secondproductQuantity);

        double result = this._inventory.CalculateTotalValue();

        //Assert
        Assert.AreEqual(expectedTotalSum, result);
    }
}
