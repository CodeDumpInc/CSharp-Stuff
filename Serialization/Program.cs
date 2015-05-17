using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

public class Person
    : ISerializable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("FirstName", this.FirstName);
        info.AddValue("LastName", this.LastName);
    }

    public Person()
    {
    }

    public Person(string FirstName, string LastName)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Max", "Power");

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));

                //Serialization
                Stream outStream = new FileStream("Person.xml", FileMode.Create);
                serializer.Serialize(outStream, person);
                outStream.Close();

                //Deserialization
                Stream inStream = new FileStream("Person.xml", FileMode.Open);
                Person readPerson = (Person) serializer.Deserialize(inStream);

                Console.WriteLine("Deserialized: " + readPerson);
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
