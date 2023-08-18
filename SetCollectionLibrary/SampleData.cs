namespace SetCollectionWpf;

public class SampleData
{
    
    public static SampleData Current = new SampleData();

    public List<Person> People = new List<Person>()
    {
        // dropdown list3 - reading, driving, cooking
        new Person(1, "Sarah", "Reading", "Female"),    
        new Person(2, "Arthur", "Driving", "Male"),
        new Person(3, "Jessica", "Running", "Female"),
        new Person(4, "Leo", "Reading", "Male"),
        new Person(5, "Tom", "Cooking", "Male"),
        new Person(6, "Jim", "Reading", "Male"),
        new Person(7, "Harry", "Reading", "Male"),
        new Person(8, "Elizabeth", "Reading", "Female"),
        new Person(9, "Selena", "Driving", "Female"),
        new Person(10, "Loretta", "Running", "Female"),
        new Person(11, "Angela", "Reading", "Female"),
        new Person(12, "Bob", "Cooking", "Male"),
        new Person(13, "Susan", "Reading", "Female"),
        new Person(14, "Luci", "Reading", "Female")
    };
}
