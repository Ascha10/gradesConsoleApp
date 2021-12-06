using gradesConsoleApp;


List<Lecturer> listOfStudents = new List<Lecturer>();
List<string> listOfStrings = new List<string>();



void LecturerApp(){

    Console.WriteLine("Please Choose Operation");
    Console.WriteLine("1. Add Students");
    Console.WriteLine("2. Grades Avrage");
    Console.WriteLine("3. search by Index");
    int selectedOperation = int.Parse(Console.ReadLine());

    switch (selectedOperation)
    {
        case 1:

            try
            {
                Console.WriteLine("Please Enter Your Name");
                string nameOfLecturer = Console.ReadLine();
                Console.WriteLine("Please Enter Students Number");
                int numberOfStudent = int.Parse(Console.ReadLine());
                Grades(nameOfLecturer, numberOfStudent);
                LecturerApp();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input Please Inset A Number"); 
                LecturerApp();
            }
            break;

        case 2:
            GradesAvrage();
            break;

        case 3:
            searchByIndex("lect3",1);
            break;

        default:
            LecturerApp();
            break;
    }

}

LecturerApp();

void Grades(string nameOfLecturer, int numberOfStudent)
{
    int counter = 0;
    int counterIndex = 0;
    while (counter < numberOfStudent)
    {
        Console.WriteLine("Please Enter The Grades For Each Students");
        int[] grades = new int[] { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
        Console.WriteLine("Please Enter studentName,studentId");
        Lecturer lecturerOne = new Lecturer(nameOfLecturer, Console.ReadLine(), int.Parse(Console.ReadLine()), grades);
        listOfStudents.Add(lecturerOne);
        FileStream fileObject = new FileStream($@"C:\test\Grades\{nameOfLecturer}.txt", FileMode.Append);
        using (StreamWriter writeTo = new StreamWriter(fileObject))
        {
            writeTo.WriteLine($" id:{counterIndex++} lecturerName:{lecturerOne.lecturerName} student:{lecturerOne.student} studentId:{lecturerOne.studentId} grades:{lecturerOne.grades[0]} {lecturerOne.grades[1]} {lecturerOne.grades[2]},");
            //Console.WriteLine($"{lecturerOne.lecturerName} {lecturerOne.student} {lecturerOne.studentId} {lecturerOne.grades[0]} {lecturerOne.grades[1]} {lecturerOne.grades[2]}");
        };
        counter++;
    }
}

void createStudentFromFile(string fileName)
{
    FileStream lecturerFileObject = new FileStream($@"C:\test\Grades\{fileName}.txt", FileMode.Open);
    using (StreamReader readFromLecturer = new StreamReader(lecturerFileObject))
    {

        for (int i = 0; i < readFromLecturer.Peek(); i++)
        {
            listOfStrings.Add(readFromLecturer.ReadLine());
        }
        foreach (string line in listOfStrings)
        {
            Console.WriteLine(line);
        }
    }
}

createStudentFromFile("lect2");


void GradesAvrage()
{
    int sum = 0;
    for (int i = 0; i < listOfStudents[0].grades.Length; i++)
    {
        sum += listOfStudents[i].grades[i];
    }
    Console.WriteLine(sum / listOfStudents[0].grades.Length);
    //Console.WriteLine((listOfStudents[0].grades[0] + listOfStudents[0].grades[1] + listOfStudents[0].grades[2]) / listOfStudents[0].grades.Length);
}

//void searchByIndex(string fileName, int someIndex)
//{
//    FileStream lecturerFileObject = new FileStream($@"C:\test\Grades\{fileName}.txt", FileMode.Open);
//    using (StreamReader readFromLecturer = new StreamReader(lecturerFileObject))
//    {

//        for (int i = 0; i < readFromLecturer.Peek(); i++)
//        {

//            int foundIndexAt = readFromLecturer.ReadLine().IndexOf($"{someIndex}");
//            Console.WriteLine(readFromLecturer.ReadLine().Substring(foundIndexAt)); 
//        }
//    }

//}