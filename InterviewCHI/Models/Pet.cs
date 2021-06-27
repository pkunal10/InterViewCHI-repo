using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCHI.Models
{
    public class Pet
    {
        
        public enum Gender
        {
            Male = 'M',
            Female = 'F'
        }

        public interface IPet
        {
            int ID { get; set; }
            string Name { get; set; }
            DateTime DateOfBirth { get; set; }
            Gender Gender { get; set; }

            string Speak();
        }

        public abstract class PetBase : IPet
        {
            public abstract int ID { get; set; }
            public abstract string Name { get; set; }
            public abstract DateTime DateOfBirth { get; set; }
            public abstract Gender Gender { get; set; }
            public abstract string Type { get; }
            public abstract string Speak();
            public string Reverse = "";

            //public virtual bool IsNameAPalindrome(string text)
            //{           

            //    for (int i = text.Length - 1; i >= 0; i--)
            //    {
            //        Reverse += text[i];
            //    }
            //    if (text == Reverse)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}

            public virtual bool IsNameAPalindrome
            {

                get
                {

                    for (int i = Name.Length - 1; i >= 0; i--)
                    {
                        Reverse += Name[i];
                    }
                    if (Name.ToLower() == Reverse.ToLower())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public virtual int Age
            {
                get
                {

                    int age = DateTime.Now.Year - DateOfBirth.Year;
                    if ((DateOfBirth.Month > DateTime.Now.Month) || (DateOfBirth.Month == DateTime.Now.Month && DateOfBirth.Day > DateTime.Now.Day))
                    {
                        age = age - 1;
                    }
                    return age;
                }
            }
        }

        public class Bird : PetBase
        {
            public override int ID { get; set; }
            public override string Name { get; set; }
            public override DateTime DateOfBirth { get; set; }
            public override Gender Gender { get; set; }

            public float Wingspan { get; set; }
            public override string Type { get { return "Bird"; } }

            public override string Speak()
            {
                return "Chirp!";
            }
        }

        public class Cat : PetBase
        {
            public override int ID { get; set; }
            public override string Name { get; set; }
            public override DateTime DateOfBirth { get; set; }
            public override Gender Gender { get; set; }
            public override string Type { get { return "Cat"; } }

            public override string Speak()
            {
                return "Meow!";
            }
        }

        public class Dog : PetBase
        {
            public override int ID { get; set; }
            public override string Name { get; set; }
            public override DateTime DateOfBirth { get; set; }
            public override Gender Gender { get; set; }
            public override string Type { get { return "Dog"; } }

            public override string Speak()
            {
                return "Whoof!";
            }
        }

        public class House : List<PetBase>
        {
            public List<PetBase> AddTestData()
            {
                List<PetBase> petList = new List<PetBase>();
                petList.Add(new Cat()
                {
                    ID = this.Count + 1,
                    Name = "Gracie",
                    DateOfBirth = new DateTime(2016, 09, 28),
                    Gender = Gender.Female
                });

                petList.Add(new Cat()
                {
                    ID = this.Count + 1,
                    Name = "Patches",
                    DateOfBirth = new DateTime(2015, 01, 09),
                    Gender = Gender.Male
                });

                petList.Add(new Bird()
                {
                    ID = this.Count + 1,
                    Name = "Izzi",
                    DateOfBirth = new DateTime(2018, 06, 03),
                    Gender = Gender.Female,
                    Wingspan = 10.0f,
                });

                petList.Add(new Dog()
                {
                    ID = this.Count + 1,
                    Name = "Missy",
                    DateOfBirth = new DateTime(2016, 03, 05),
                    Gender = Gender.Female
                });
                return petList;
            }
        }
    }
}
