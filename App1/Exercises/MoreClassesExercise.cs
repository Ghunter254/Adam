/*
CHECK SOLUTION.CS FILE FOR THE SOLUTION... ONLY USE IT TO MAKE SURE YOU ARE ON THE RIGHT TRACK.
I INTENTIONALLY MADE THE SOLUTION MUCH HARDER THAN WHAT YOU KNOW SO THAT IT ONLY ACTS AS A GUIDE
NOT A DIRECT COPY PASTE FOR THIS EXERCISE.

IGNORE ANYTHING IN THE SOLUTION THAT YOU HAVENT SEEN BEFORE ... JUST STICK TO THE EASY PRINCIPLES
Exercise: Student Grade Report System

Goal:
Create a console application that uses:
- Classes
- Fields 
- Instance methods
- Static methods
- Console input/output
- Validation using try-catch
- A little bit of data processing (average calculation)

Requirements (Follow Step-by-Step)

1) Create a class named "Student".

2) Inside the Student class, create the following FIELDS:
   - string name
   - int age
   - int mathMarks
   - int scienceMarks
   - int englishMarks

   (These must be fields, not properties.)

3) Create a CONSTRUCTOR for the Student class that accepts:
   (string studentName, int studentAge, int math, int science, int english)
   and assigns the values to the class fields.

4) Create an INSTANCE METHOD:
   double CalculateAverage()
   - This method should calculate and return the average of the 3 subject marks.
     (Remember: average = (mathMarks + scienceMarks + englishMarks) / 3.0)

5) Create another INSTANCE METHOD:
   void DisplayReport()
   - This method should:
     - Print the student's name and age.
     - Print the average score (Call CalculateAverage() inside this method).

6) Create two STATIC METHODS inside the Student class:

   a) static Student RequestStudentData()
      - This method should:
        - Ask the user to enter the student's name
        - Ask the user to enter the student's age
        - Ask the user to enter marks for Math, Science, and English
        - Use try-catch to ensure age and marks are valid integers.
        - Return a new Student object with the collected values.

   b) static void Run()
      - This method should:
        - Call RequestStudentData(), store the returned Student object.
        - Call the DisplayReport() method on that object.

7) Inside Program.cs (Main method):
   - Simply call Student.Run()

Notes / Restrictions:
- Do NOT use if statements or loops in this assignment.
- Only use try-catch to handle invalid number input.
- Everything should remain inside a single console application.

Final Program Flow (What the program should do when running):
- Ask user for student information and marks.
- Create a Student object.
- Calculate the average.
- Display the report.

Good luck!
*/
