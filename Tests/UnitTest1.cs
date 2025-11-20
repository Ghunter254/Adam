using Assignments;
namespace Tests;

public class ApplicantTests
{

    [Theory]
    [InlineData("Sedan", 1000.0)]
    [InlineData("SUV", 1200.0)]
    [InlineData("Sport", 1800.0)]
    [InlineData("Truck", 1400.0)]     // Should hit default
    [InlineData("Bicycle", 1400.0)]   // Should hit default
    public void CalculateBasePremium_ReturnsCorrectAmount(string vehicleType, double expectedPremium)
    {
        var applicant = new Applicant("Test User", 30, vehicleType, 5);

        double actualPremium = applicant.CalculateBasePremium();

        // Assert
        Assert.Equal(expectedPremium, actualPremium);
    }

    // ---------------------------------------------------------
    // TEST 2: CHECKING THE RISK FACTOR (IF / ELSE IF)
    // ---------------------------------------------------------
    [Theory]
    // SCENARIO A: HIGH RISK (Age < 25 OR Years < 2) -> Expect 1.8
    [InlineData(20, 5, 1.8)] // Young, but experienced
    [InlineData(30, 1, 1.8)] // Old enough, but new driver
    [InlineData(18, 0, 1.8)] // Young and new

    // SCENARIO B: MEDIUM RISK (Age 25-40) -> Expect 1.2
    // Note: They only reach here if they have > 2 years driving
    [InlineData(25, 5, 1.2)] // Lower bound edge case
    [InlineData(30, 5, 1.2)] // Middle
    [InlineData(39, 5, 1.2)] // Upper bound edge case

    // SCENARIO C: LOW RISK (Everyone else) -> Expect 1.0
    [InlineData(40, 10, 1.0)] // Edge case
    [InlineData(50, 20, 1.0)] // Standard older driver
    public void CalculateRiskFactor_ReturnsCorrectMultiplier(int age, int yearsDriving, double expectedRisk)
    {
        // Arrange
        var applicant = new Applicant("Test User", age, "Sedan", yearsDriving);

        // Act
        double actualRisk = applicant.CalculateRiskFactor();

        // Assert
        Assert.Equal(expectedRisk, actualRisk);
    }

    // ---------------------------------------------------------
    // TEST 3: CHECKING LOGIC FLOW
    // ---------------------------------------------------------
    [Fact]
    public void Applicant_FieldsAreSetCorrectly_OnConstruction()
    {
        // Arrange
        string expectedName = "John Doe";
        int expectedAge = 35;
        string expectedVehicle = "SUV";
        int expectedYears = 10;

        // Act
        var app = new Applicant(expectedName, expectedAge, expectedVehicle, expectedYears);

        // Assert
        Assert.Equal(expectedName, app.name);
        Assert.Equal(expectedAge, app.age);
        Assert.Equal(expectedVehicle, app.vehicleType);
        Assert.Equal(expectedYears, app.yearsDriving);
    }
}