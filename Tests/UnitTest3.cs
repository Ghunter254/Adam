using Xunit;
using Assignments; 

namespace Tests;

public class ShipmentTests
{

    
    [Theory]
    [InlineData("Mars", 8.36)]
    [InlineData("Europa", 8.89)]
    [InlineData("Proxima_B", 13.64)] // Interstellar check
    [InlineData("Moon", 5.58)]
    [InlineData("Pluto", 0.00)]      // He defined default (_) as 0.00
    public void DistanceCoeff_ReturnsCorrectValue(string destination, double expectedCoeff)
    {
        // Arrange
        var shipment = new Shipment(destination, 100, "Regular");

        // Act
        double result = shipment.distanceCoeff();

        // Assert
        Assert.Equal(expectedCoeff, result);
    }



    // Scenario A: Under or Equal to 500 tons (Simple Math: weight * 10)
    [Theory]
    [InlineData(10, 100)]    // 10 * 10
    [InlineData(500, 5000)]  // 500 * 10 (Boundary check)
    public void BaseCargoFee_StandardRate_Under500(int weight, int expectedFee)
    {
        // Arrange
        var shipment = new Shipment("Mars", weight, "Regular");

        // Act
        int result = shipment.baseCargoFee();

        // Assert
        Assert.Equal(expectedFee, result);
    }

    // Scenario B: Over 500 tons (Complex Math: 500*10 + Excess*50)
    // Logic: 5000 + (weight - 500) * 50
    [Theory]
    [InlineData(501, 5050)]   // 5000 + (1 * 50)
    [InlineData(600, 10000)]  // 5000 + (100 * 50)
    public void BaseCargoFee_Surcharge_Over500(int weight, int expectedFee)
    {
        // Arrange
        var shipment = new Shipment("Mars", weight, "Regular");

        // Act
        int result = shipment.baseCargoFee();

        // Assert
        Assert.Equal(expectedFee, result);
    }


    [Theory]
    [InlineData("Regular", 1.0)]
    [InlineData("Fragile", 1.5)]
    [InlineData("Liquid", 6.0)]
    [InlineData("UnknownType", 0.0)] // Default case
    public void CargoModifier_ReturnsCorrectMultiplier(string type, double expectedMod)
    {
        // Arrange
        var shipment = new Shipment("Mars", 100, type);

        // Act
        double result = shipment.cargoModifier();

        // Assert
        Assert.Equal(expectedMod, result);
    }

    
    // If distance > 10.26, add 1000. Otherwise 0.
    
    [Fact]
    public void InterstellarModifier_AddsFee_ForProximaB()
    {
        // Arrange (Proxima_B is 13.64 distance)
        var shipment = new Shipment("Proxima_B", 100, "Regular");

        // Act
        int result = shipment.interstellarModifier();

        // Assert
        Assert.Equal(1000, result);
    }

    [Fact]
    public void InterstellarModifier_NoFee_ForMars()
    {
        // Arrange (Mars is 8.36 distance)
        var shipment = new Shipment("Mars", 100, "Regular");

        // Act
        int result = shipment.interstellarModifier();

        // Assert
        Assert.Equal(0, result);
    }



    // TEST: Negative Weight
    // logic: "if (weight <= 500)" -> True for -100.
    // Calculation: -100 * 10 = -1000 cost.
    // Expected: Should probably return 0 or throw error, but right now it pays the user!
    [Fact]
    public void BaseCargoFee_ShouldNotReturnNegative_ForNegativeWeight()
    {
        // Arrange
        var shipment = new Shipment("Mars", -100, "Regular");

        // Act
        int result = shipment.baseCargoFee();

        // Assert
        // This verifies that we are NOT paying the customer to ship things.
        // If his code returns -1000, this test will FAIL.
        Assert.True(result >= 0, $"Logic Error: Calculated fee was {result}. We shouldn't pay customers to ship items!");
    }

    // TEST: Case Sensitivity
    // Your switch uses "Mars". If user types "mars", it hits default (_) -> 0.
    // This test checks if he handled normalization (Spoiler: He didn't).
    [Fact]
    public void DistanceCoeff_ShouldHandle_LowerCaseInput()
    {
        // Arrange
        var shipment = new Shipment("mars", 100, "Regular"); // Lowercase

        // Act
        double result = shipment.distanceCoeff();

        // Assert
        // If this fails, it means his code requires perfect casing.
        Assert.NotEqual(0.00, result); 
    }
}