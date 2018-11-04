# ManagementSoftware-OOP-ProjectDBS
Dublin Business School has decided to implement a new management software package for their system; 
your task is to present the solution in Console format or GUI format.


Assessment
The following is the assignment as set out for the module of Object Oriented Programming (OOP). 

It is an individual assignment. 

Total: 90 marks

The following table illustrates the allocation for each individual part of the assignment.

Task	Part	Breakdown of Marks
Task 1 	Development of a software app project in C# with appropriate comments	50 marks
Task 2	Innovation/Technical Merit	20 marks
Task 3	Testing	20 marks

 
Assessment Specification
Dublin Business School has decided to implement a new management software package for their system; your task is to present the solution in Console format or GUI format.

Your program should provide a Console-based UI or a form-based GUI that allow for services such as 
	Add student
	Add lecturer
	Search lecturer or student
	Show the details of all enrolled students
	Show the details of all lecturers							  (15 marks)

Create an inheritance hierarchy for this application, below are the required classes to use in your application. Use appropriate data types while developing the classes.

1.	 College Class (this is the entry point to the programme)

2.	Person Class
	A class Person with attributes PPSN, Name, Address, Phone and Email.		

3.	Student Class (should inherit the functionality of base class Person)
	A class Student which inherits from Person with attributes Status and StudentId. A student’s status can either be a Postgrad or an Undergrad.
	Create a constructor for Student such that all attributes belonging to a Student can be assigned via the constructor.

4.	Staff Class (should inherit the functionality of base class Person)
	Create a class Staff that inherits from Person with an attribute of Id, Salary.

5.	Lecturer Class (should inherit the functionality of base class Staff)
	Create a class Lecturer which inherits from Staff with an attribute of SubjectArea and Subjects Taught (List)
	You can include Teaching Experience/work experience (optional)
	Create a constructor for Lecturer such that all attributes belonging to a Lecturer can be assigned via the constructor.
  (25 marks)

Other features include:									
	At least one implementation of an overridden ToString() method. 
	Demonstration of the development and use of one more overridden method.
	Demonstrate the use of overloading (other than constructor overloading).
 	(10 marks)

Innovation

You can enhance the functionality of your application by writing additional code. You have to decide on the additions to make the program better.  

Include a paragraph in your documentation on innovation that you applied to your code.

Note: Do not include database functionality. 
(20 marks)
Testing
	Create unit tests in C# to test at least four functions in classes.
	Write a paragraph to explain which functions you have tested.

(20 marks)

