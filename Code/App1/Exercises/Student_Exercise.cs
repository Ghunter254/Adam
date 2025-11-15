namespace Assignments;

class Student  //The actual class and shi
{
    //Fields
    public string name;
    public int age;
    public int mathMarks;
    public int scienceMarks;
    public int englishMarks;

    //Constructor
    public Student(string name, int age, int mathMarks, int scienceMarks, int englishMarks)
    {
        this.name = name;
        this.age = age;
        this.mathMarks = mathMarks;
        this.scienceMarks = scienceMarks;
        this.englishMarks = englishMarks;
    }

    public double CalculateAverage()
    // This shi has a "double" identifier since it is an instance method and returns some data and shi
    {
        return (mathMarks + scienceMarks + englishMarks) / 3;
    }

    //Void Method and has no output
    public void DisplayReport()
    {
        Console.WriteLine($"Student Name: {name}\nStudent Age: {age}");
        Console.WriteLine($"Average Score: {CalculateAverage()}");
    }

    //Static method, needs no object reference
    public static Student RequestStudentData()
    {
        try
        {
            Console.WriteLine("Lowkey enter ur name");
            string studentName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Lowkey how old are you");
            int studentAge = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Lowkey what did you get in Math");
            int studentMath = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Lowkey what did you get in Science");
            int studentScience = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Lowkey what did you get in English");
            int studentEnglish = int.Parse(Console.ReadLine() ?? string.Empty);

            return new Student(studentName, studentAge, studentMath, studentScience, studentEnglish);
        }
        catch (FormatException)
        {
            Console.WriteLine("Bro come on man enter proper digits, sasa hizi ni gani.");
            return null;
        }
    }
}
class Main
{
    public static void Run()
    {
        Student Yona = Student.RequestStudentData();
        Yona.DisplayReport();
    }
}