using School.Common;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== Демонстрація CRUD сервісу для School ===\n");

// Підписка на події
Student.StudentEnrolled += (student) => Console.WriteLine($"[ПОДІЯ] Студент зарахований: {student.GetFullName()}");
Grade.GradeAssigned += (grade) => Console.WriteLine($"[ПОДІЯ] Оцінку виставлено: {grade.Score} балів");

Console.WriteLine("\n--- 1. Створення CRUD сервісів ---");
var studentService = new CrudService<Student>(s => s.Id);
var teacherService = new CrudService<Teacher>(t => t.Id);
var courseService = new CrudService<Course>(c => c.Id);
var gradeService = new CrudService<Grade>(g => g.Id);

Console.WriteLine("Сервіси створено успішно!\n");

Console.WriteLine("\n--- 2. Створення об'єктів Teacher ---");
var teacher1 = new Teacher("Іван", "Петренко", new DateTime(1975, 5, 15), "Математика", "Професор", 25000m);
var teacher2 = new Teacher("Марія", "Коваленко", new DateTime(1980, 8, 20), "Фізика", "Доцент", 20000m);

teacherService.Create(teacher1);
teacherService.Create(teacher2);

Console.WriteLine($"\nВсього створено Person об'єктів: {Person.GetTotalPersonsCreated()}");

Console.WriteLine("\n--- 3. Створення об'єктів Student ---");
var student1 = new Student("Олексій", "Шевченко", new DateTime(2003, 3, 10), "ST2023001", 2, 4.8);
var student2 = new Student("Анна", "Мельник", new DateTime(2004, 7, 25), "ST2023002", 1, 4.2);
var student3 = new Student("Дмитро", "Сидоренко", new DateTime(2003, 11, 5), "ST2023003", 2, 3.9);

studentService.Create(student1);
studentService.Create(student2);
studentService.Create(student3);

// Демонстрація методу розширення
Console.WriteLine($"\nІніціали першого студента (метод розширення): {student1.GetInitials()}");
Console.WriteLine($"Резюме студента (метод розширення): {student1.GetStudentSummary()}");

// Виклик події
student1.Enroll();

Console.WriteLine("\n--- 4. Створення об'єктів Course ---");
var course1 = new Course("Вища математика", 5, teacher1.Id);
var course2 = new Course("Загальна фізика", 4, teacher2.Id);
var course3 = new Course("Програмування C#", 6, teacher1.Id);

courseService.Create(course1);
courseService.Create(course2);
courseService.Create(course3);

Console.WriteLine($"\nВсього створено курсів: {Course.GetTotalCoursesCreated()}");

Console.WriteLine("\n--- 5. Виведення всіх об'єктів ---");
Console.WriteLine("\n5.1 Викладачі:");
foreach (var teacher in teacherService.ReadAll())
{
    Console.WriteLine($"  - {teacher}");
}

Console.WriteLine("\n5.2 Студенти:");
foreach (var student in studentService.ReadAll())
{
    Console.WriteLine($"  - {student}");
    Console.WriteLine($"    Відмінник: {student.IsHonorStudent()}");
}

Console.WriteLine("\n5.3 Курси:");
foreach (var course in courseService.ReadAll())
{
    Console.WriteLine($"  - {course}");
    Console.WriteLine($"    Інформація: {course.GetCourseInfo()}");
}

Console.WriteLine("\n--- 6. Читання конкретного об'єкта ---");
var foundStudent = studentService.Read(student1.Id);
Console.WriteLine($"Знайдено студента: {foundStudent.GetFullName()}");

var foundTeacher = teacherService.Read(teacher1.Id);
Console.WriteLine($"Знайдено викладача: {foundTeacher.GetFullName()}");

Console.WriteLine("\n--- 7. Оновлення об'єкта ---");
Console.WriteLine($"Зарплата викладача {teacher1.GetFullName()} до оновлення: {teacher1.Salary:N2} ₴");
teacher1.IncreaseSalary(10);
teacherService.Update(teacher1);
Console.WriteLine($"Зарплата після оновлення: {teacher1.Salary:N2} ₴");

Console.WriteLine($"\nGPA студента {student2.GetFullName()} до оновлення: {student2.GPA}");
student2.GPA = 4.6;
studentService.Update(student2);
Console.WriteLine($"GPA після оновлення: {student2.GPA}");
Console.WriteLine($"Новий статус: {student2.GetAcademicStatus()}");

Console.WriteLine("\n--- 8. Створення та призначення оцінок ---");
var grade1 = new Grade(student1.Id, course1.Id, 95);
var grade2 = new Grade(student1.Id, course2.Id, 88);
var grade3 = new Grade(student2.Id, course1.Id, 92);

gradeService.Create(grade1);
gradeService.Create(grade2);
gradeService.Create(grade3);

// Виклик події
grade1.Assign();

Console.WriteLine("\nВсі оцінки:");
foreach (var grade in gradeService.ReadAll())
{
    Console.WriteLine($"  - {grade}");
    Console.WriteLine($"    Складено: {grade.IsPassing()}");
}

// Статичний метод Grade
Console.WriteLine($"\nСередній бал: {Grade.CalculateAverageScore(gradeService.ReadAll()):F2}");

Console.WriteLine("\n--- 9. Видалення об'єкта ---");
Console.WriteLine($"Студентів до видалення: {studentService.ReadAll().Count()}");
studentService.Remove(student3);
Console.WriteLine($"Студентів після видалення: {studentService.ReadAll().Count()}");

Console.WriteLine("\nВсі студенти після видалення:");
foreach (var student in studentService.ReadAll())
{
    Console.WriteLine($"  - {student.GetFullName()}");
}

Console.WriteLine("\n--- 10. Демонстрація статичних методів ---");
Console.WriteLine($"Мінімальна зарплата викладача: {Teacher.MinimumSalary:N2} ₴");
Console.WriteLine($"Річна зарплата викладача: {Teacher.CalculateAnnualSalary(teacher1.Salary):N2} ₴");
Console.WriteLine($"Викладач є старшим: {teacher1.IsSeniorTeacher()}");

Console.WriteLine("\n--- 11. Демонстрація методу розширення для string ---");
string testString = "програмування на C#";
Console.WriteLine($"Оригінальний рядок: '{testString}'");
Console.WriteLine($"Title Case (метод розширення): '{testString.ToTitleCase()}'");

Console.WriteLine("\n=== Демонстрація завершена ===");
Console.WriteLine($"\nПідсумок:");
Console.WriteLine($"  - Всього створено персон: {Person.GetTotalPersonsCreated()}");
Console.WriteLine($"  - Всього створено курсів: {Course.GetTotalCoursesCreated()}");
Console.WriteLine($"  - Студентів у системі: {studentService.ReadAll().Count()}");
Console.WriteLine($"  - Викладачів у системі: {teacherService.ReadAll().Count()}");
Console.WriteLine($"  - Курсів у системі: {courseService.ReadAll().Count()}");
Console.WriteLine($"  - Оцінок у системі: {gradeService.ReadAll().Count()}");

