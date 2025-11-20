/* 
    I now believe you are ready to handle this exciting task.
     EXERCISE: Simple Grade Calculator and Scholarship Eligibility

    The GOAL:
    Create a console application that:
      1. Collects a student's details and scores for three subjects.
      2. Calculates the student's average score.
      3. Determines whether the student qualifies for a scholarship based on rules.

    Concepts You MUST Use only concepts we have covered so far. These include:"
        - Variables & Data Types
        - Console Input / Output
        - Classes & Constructors
        - Methods (Instance methods)
        - int.TryParse for safe number input
        - if / else conditionals

    Do NOT use:
        - Loops
        - Arrays
        - Properties (public getters/setters)
        - switch statements
        - Lists or advanced syntax
        - External libraries

    Now i will give you some guidance on the sort of classes you need to create.
    -------------------------------------------------------------------
    
    COMPONENT 1: Subject Class
    - Represents one subject and its score.
    - Must contain:
        • Private fields: subject name (string), score (int)
        • Constructor to assign these fields
        • Method GetScore() → returns the score (int)
    -------------------------------------------------------------------
    COMPONENT 2: Student Class
    - Represents the student and their academic status.
    - Must contain:
        • Private fields: student name (string), attendance percentage (int)
        • Constructor to assign these fields
        • Method CalculateAverage(Subject s1, Subject s2, Subject s3)
            → returns the average score (double)
        • Method CheckScholarshipEligibility(double avgScore)
            → prints eligibility result using the rules below

    SCHOLARSHIP RULES:
        If average >= 85 AND attendance >= 90:
            Output: "Student is Eligible for a Full Scholarship!"
        Else if average >= 70 AND attendance >= 80:
            Output: "Student is Eligible for a Partial Scholarship."
        Else:
            Output: "Student is NOT Eligible for any scholarship."

    -------------------------------------------------------------------
    COMPONENT 3: Program (Run Method)
    Steps to perform:
        1. Ask user to input Student Name.
        2. Ask user to input Attendance Percentage → use int.TryParse.
        3. Ask user for THREE subjects and their scores → use TryParse again.
        4. If any parsing fails → print "Invalid input" and exit.
        5. Create:
            - One Student object
            - Three Subject objects
        6. Call CalculateAverage → store result
        7. Call CheckScholarshipEligibility → pass the average
    -------------------------------------------------------------------

    ✅ Example Output (Format can vary):
        Enter student name: Adam
        Enter attendance: 92
        Enter score for Math: 87
        Enter score for Science: 91
        Enter score for History: 85
        Average Score: 87.67
        Student is Eligible for a Full Scholarship!

    Aim for CLEAN, CLEAR, and READABLE CODE.
    No advanced tricks. No shortcuts. Just solid fundamentals.
*/
