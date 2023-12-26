using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public enum Stages
    {
        elementary,
        secondary,
        higher
    }

    public class Student
    {
        private static char nextName = 'A';
        public string FIO { get; set; }
        public int Grade { get; set; }
        public double Perfomance { get; set; }
        public Stages Stage { get; set; }
        /*public static int numberOfStudent;*/

        public Student()
        {
            FIO = nextName.ToString();
            nextName++;
            Grade = 1;
            Perfomance = 5;
            Stage = Stages.elementary;
        }

        public Student(string fio, int grade, double perfomance)
        {
            if (grade < 1 || grade > 11)
            {
                throw new Exception($"Некорректно задан класс обучаюющегося");
            }
            if (perfomance < 0 || perfomance > 5)
            {
                throw new Exception($"Некорректно задана средняя успеваемость обучающегося");
            }
            if (grade <= 4)
            {
                Stage = Stages.elementary;
            }
            else
            {
                if (grade > 4 && grade <= 8)
                {
                    Stage = Stages.secondary;
                }
                else
                {
                    if (grade > 8 && grade <= 11)
                    {
                        Stage = Stages.higher;
                    }
                }
            }
            
            FIO = fio;
            Grade = grade;
            Perfomance = perfomance;
            /*Stage = Stages.elementary;*/
            
            
        }

        public void Pass()
        {
            if (Grade < 11)
            {
                Grade++;
                if (Grade > 4 && Grade <= 8)
                {
                    Stage = Stages.secondary;
                }
                else
                {
                    if (Grade > 8 && Grade <= 11)
                    {
                        Stage = Stages.higher;
                    }
                }
            }

        }

        public override string ToString()
        {
            if (this.Stage == Stages.elementary)
            {
                return $"{FIO}, младшая школа, {Grade} класс, {Perfomance} балла";
            }
            if (this.Stage == Stages.secondary)
            {
                return $"{FIO}, средняя школа, {Grade} класс, {Perfomance} балла";
            }
                

            return $"{FIO}, старшая школа, {Grade} класс, {Perfomance} балла";
        }
    }

    public class School
    {
        public string Name { get; set; }
        public List<Student> listStudents { get; set; }

        public School(string name)
        {
            Name = name;
            listStudents = new List<Student>();
        }

        public void Add(Student student)
        {
            listStudents.Add(student);
        }

        public override string ToString()
        {
            string result = "";
            int index = 1;
            foreach (var student in listStudents)
            {
                result += $"{index}. {student}\n";
                
                index++;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student studA = new Student();
            Student studB = new Student();
            Student studAbaev = new Student("Абаев Георгий", 7, 3.4);
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Console.WriteLine(studA);
            Console.WriteLine(studB);
            Console.WriteLine(studAbaev);
            Console.WriteLine(studBagaev);
            studBagaev.Pass();
            Console.WriteLine(studBagaev);

            School school = new School("ФизМат");
            school.Add(studA);
            school.Add(studB);
            school.Add(studAbaev);
            school.Add(studBagaev);
            Console.WriteLine(school);
        }
    }
}
