using StudentSearchPerformanceTest;
using System.Collections;
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int numStudents = 1000000; // npr. 1M studenata 
        var students = new List<Student>();

        Random random = new Random();

        for (int i = 0; i < numStudents; i++)
        {
            students.Add(new Student(i, "Name" + i, "Surname" + i));
        }

        //lista
        var list = new List<Student>(students);
        SearchPerformanceList(list);

        //niz
        var array = students.ToArray();
        SearchPerformanceArray(array);

        //HashSet
        var hashSet = new HashSet<Student>(students);
        SearchPerformanceHashSet(hashSet);

        //mapa
        var dictionary = new Dictionary<int, Student>();
        foreach (var student in students)
        {
            dictionary.Add(student.Jmbg, student);
        }
        SearchPerformanceDictionary(dictionary);
    }


    //List<T>.Find - prolazi kroz svaki element liste O(n), linearna pretraga 
    static void SearchPerformanceList(List<Student> studentsList)
    {
        // Pronalaženje studenta sa nasumičnim JMBG-om
        Random random = new Random();
        int randomJMBG = random.Next(0, 1000000);

        // Start meranja vremena
        Stopwatch stopwatch = Stopwatch.StartNew();
        var student = studentsList.Find(s => s.Jmbg == randomJMBG);

        // Zaustavljanje vremena
        stopwatch.Stop();

        if (student != null)
        {
            Console.WriteLine($"[LIST] Pronađen student: {student.Name} {student.Surname}, JMBG: {student.Jmbg}. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine($"[LIST] Student sa JMBGO-om {randomJMBG} nije pronađen. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    //Array.Find - prolazi svaki element O(n)
    //Brze je od liste
    static void SearchPerformanceArray(Student[] studentsArray)
    {
        // Pronalaženje studenta sa nasumičnim JMBG-om
        Random random = new Random();
        int randomJMBG = random.Next(0, 1000000);

        // Start meranja vremena
        Stopwatch stopwatch = Stopwatch.StartNew();
        var student = Array.Find(studentsArray, s => s.Jmbg == randomJMBG); //ili preko for..

        // Zaustavljanje vremena
        stopwatch.Stop();

        if (student != null)
        {
            Console.WriteLine($"[ARRAY] Pronađen student: {student.Name} {student.Surname}, JMBG: {student.Jmbg}. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine($"[ARRAY] Student sa JMBGO-om {randomJMBG} nije pronađen. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
    //Brze od liste i niza 
    //zbog optimizovanog skladistenja elemenata i brze pretrage 
    static void SearchPerformanceHashSet(HashSet<Student> studentsSet)
    {
        // Pronalaženje studenta sa nasumičnim JMBG-om
        Random random = new Random();
        int randomJMBG = random.Next(0, 1000000);

        // Start meranja vremena
        Stopwatch stopwatch = Stopwatch.StartNew();
        var student = studentsSet.FirstOrDefault(s => s.Jmbg == randomJMBG);

        // Zaustavljanje vremena
        stopwatch.Stop();

        if (student != null)
        {
            Console.WriteLine($"[HASHSET] Pronađen student: {student.Name} {student.Surname}, JMBG: {student.Jmbg}. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine($"[HASHSET] Student sa JMBGO-om {randomJMBG} nije pronađen. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    //najbrze jer korisi has mapu slozenost O(1) - pretraga na osnovu key, dirketan pristup elementu 
    static void SearchPerformanceDictionary(Dictionary<int, Student> studentsMap)
    {
        // Pronalaženje studenta sa nasumičnim JMBG-om
        Random random = new Random();
        int randomJMBG = random.Next(0, 1000000);

        // Start meranja vremena
        Stopwatch stopwatch = Stopwatch.StartNew();

        bool found = studentsMap.TryGetValue(randomJMBG, out Student student);  //funckija ?

        // Zaustavljanje vremena
        stopwatch.Stop();

        if (found)
        {
            Console.WriteLine($"[DICTIONARY] Pronađen student: {student!.Name} {student.Surname}, JMBG: {student.Jmbg}. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine($"[DICTIONARY] Student sa JMBGO-om {randomJMBG} nije pronađen. Trajanje: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
    //HasSet<T> podaci se cuvaju u strukturi podataka -  HESH TABELA
    //brz pristup podacima koriscenjem hesh funkcije 
    //hesh funkcija - algoritam koji prima objekat kao ulaz i generise JEDINSTVENU numericku vrednost - HESH VREDNOST
    //hesh vrednost koristi se za odredjivanje gde ce objekat biti smesten u hash tabeli 
    //u teoriji hash funckija jedistvena za svaki objekat 
    //Has vrednost se koristi da direktno odredi INDEKS I POZICIJU u hash tabeli - O(1)
    //Objekat mora da ima imaplementirano GetHashCode()!!! - za generisanje hesh vrednosti objekta
    //Ako objekti nisu dobro rasporedjeni u has tabeli i nemaju jedinstevene hesh vrednosti - pretaraga je O(n)
}
