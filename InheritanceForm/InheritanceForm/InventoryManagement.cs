using InheritanceForm;
using System.Collections.Generic;

internal static class InventoryManagement
{
    static List<Student> people = new List<Student>();


    public static void AddItem(string Fname, string Ln, string section, int ylvl)
    {

        people.Add(new Student
        {
            ID = people.Count + 1,
            FirstName = Fname,
            LastName = Ln,
            Section = section,
            Yearlvl = ylvl
        });
    }


    public static List<Student> GetItems()
    {
        return people;
    }
    internal class Student
    {
        public int ID { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Section { get; internal set; }
        public int Yearlvl { get; internal set; }
    }
}
