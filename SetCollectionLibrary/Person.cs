
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCollectionWpf
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Hobby { get; set; } //dropdown list 3
        public string Gender { get; set; } //dropdown list 1

        public Person(int id, string name, string hobby, string gender)
        {
            Id = id;
            Name = name;
            Hobby = hobby;
            Gender = gender;
        }
    }
}
