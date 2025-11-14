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

    public void DisplayReport()
    {
        Console.WriteLine($"Student Name: {name}\nStudent Age: {age}");
        Console.WriteLine($"Average Score: {CalculateAverage()}");
    }

    public static Student RequestStudentData()
    {
        try
        {
            Console.WriteLine("Lowkey enter ur name");
            string studentName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Lowkey how old are you");
            bool proper = int.TryParse(Console.ReadLine(), out int studentAge);

            Console.WriteLine("Lowkey how old are you");
            bool properMath = int.TryParse(Console.ReadLine(), out int studentMath);

            Console.WriteLine("Lowkey how old are you");
            bool properScience = int.TryParse(Console.ReadLine(), out int studentScience);

            Console.WriteLine("Lowkey how old are you");
            bool properEnglish = int.TryParse(Console.ReadLine(), out int studentEnglish);

            return new Student(studentName, studentAge, studentMath, studentScience, studentEnglish);
        }
        catch (FormatException)
        {
            Console.WriteLine("Bro come on man enter proper digits");
            return null;
        }
    }
        
    public static void Run()
    {
        Student Yona = RequestStudentData();
        Yona.DisplayReport();
    }

}