using Assignments;
namespace Tests;

public class ValidationTests
{

    [Fact]
    public void Applicant_ShouldNotAllow_YearsDriving_GreaterThan_Age()
    {
        // Arrange
        int age = 20;
        int yearsDriving = 25; // Impossible!

        Assert.Throws<ArgumentException>(() => 
        {
            new Applicant("Time Traveler", age, "Sedan", yearsDriving);
        });
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(-1)]
    public void Applicant_ShouldNotAllow_NegativeAge(int negativeAge)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
        {
            new Applicant("Negative Man", negativeAge, "Sedan", 5);
        });
    }

    [Fact]
    public void Applicant_ShouldReject_UnderageDrivers()
    {
        // Arrange
        int age = 5; 
        int yearsDriving = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
        {
            new Applicant("Baby Driver", age, "Sedan", yearsDriving);
        });
    }
}