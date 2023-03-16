using System;

namespace Laboratory_1_class
{
    public class Employment
    {
        public string DateOfReceipt;
        public string Name;
        public string DateOfDismissal;
        
        public Employment(string a, string b, string c)
        {
            DateOfReceipt = a;
            Name = b;
            DateOfDismissal = c;
        }
        
    }
    
    public class Teacher
    {
        public string Name;
        public string Birthdate;
        public string Institution;
        public string EmploymentRecordDescription;
        public string SubjectName;
        public Employment[] Employments;
        
        public Teacher(string a, string b, string c, string d, string e, Employment[] f)
        {
            Name = a;
            Birthdate = b;
            Institution = c;
            EmploymentRecordDescription = d;
            SubjectName = e;
            Employments = f;
        }
    }
    public class Class1
    {
        public static Teacher[] Teachers;
        
        public static void Main()
        {
            Menu();
        }
        public static void Menu(string text = "")
        {
            Console.Clear();
            if (Teachers == null)
            {
                Console.WriteLine("МЕНЮ\n\n" +
                                  "1. Заполнить учителей\n" +
                                  "2. Выборки\n" +
                                  "3. Выход\n" +
                                  $"{text}\n");
            }
            else
            {
                Console.WriteLine("МЕНЮ\n\n" +
                                  "1. Добавить учителя\n" +
                                  "2. Выборки\n" +
                                  "3. Выход\n" +
                                  $"{text}\n");
            }
            Console.Write("Выберите действие: ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Fill();
                    goto default;
                case ConsoleKey.D2:
                    Console.Clear();
                    Output();
                    goto default;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Вы успешно вышли!");
                    goto default;
                default:
                    break;
            }
        }

        public static void Fill()
        {
            int start = 0;
            int finish = 0;
            Console.WriteLine("Введите количество учителей:");
            if (Teachers == null)
            {
                Teachers = new Teacher[Convert.ToInt32(Console.ReadLine())];
                start = 0; 
                finish = Teachers.Length;
            }
            else
            {
                start = Teachers.Length;
                var previsiousTeachers = Teachers;
                Teachers = new Teacher[start + Convert.ToInt32(Console.ReadLine())];
                previsiousTeachers.CopyTo(Teachers, 0);
                finish = Teachers.Length;
            }
            for (int i = start; i < finish; i++)
            {
                Console.Clear();
                Console.WriteLine("Введите ФИО учителя:");
                var name = Console.ReadLine();
                Console.WriteLine("Введите дату рождения:");
                var dateOfBithday = Console.ReadLine();
                Console.WriteLine("Введите наименования организации, где учитель получил образование:");
                var education = Console.ReadLine();
                Console.WriteLine("Введите описание трудовой книжки учителя:");
                var description = Console.ReadLine();
                Console.WriteLine("Введите наименование предмета, который ведёт учитель: ");
                var nameItem = Console.ReadLine();
                Console.WriteLine("Хотите ли вы заполнить трудовую книжку учителя?\n" +
                                  "1 - Да\n" +
                                  "2 - Нет");
                Employment[] employments = new Employment[0];
                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    while (Console.ReadKey().Key != ConsoleKey.D2)
                    {
                        Employment[] employmentResult = AddObjectEmployment(employments);
                        employments = employmentResult;
                        Console.WriteLine("Хотите добавить еще одну организацию:\n" +
                                          "1 - Да\n" +
                                          "2 - Нет");
                    }
                }
                Teachers[i] = new Teacher(name, dateOfBithday, education, description, nameItem, employments);
                Console.Clear();
            }
            Console.Clear();
            Menu("\nВы успешно добавили нового учителя(ей)!");
        }

        public static Employment[] AddObjectEmployment(Employment[] employments)
        {
            Console.Clear();
            Employment[] result = new Employment[employments.Length + 1];
            employments.CopyTo(result, 0);
            Console.WriteLine("\nВведите год поступления: ");
            var firstYear = Console.ReadLine();
            Console.WriteLine("Введите наименование организации: ");
            var nameObject = Console.ReadLine();
            Console.WriteLine("Введите год увольнения: ");
            var leaveYear = Console.ReadLine();
            result[employments.Length] = new Employment(firstYear, nameObject, leaveYear);
            return result;
        }

        public static void Output()
        {
            Console.Clear();
            if (Teachers == null)
            {
                Console.WriteLine("Ошибка! Вы не добавили ни одного учителя.\n\n" +
                                  "Для возврата нажмите любую клавишу.");
                Console.ReadKey();
                Menu();
            }
            else
            {
                Console.WriteLine("Выберите фильтр:\n" +
                                  "1. По наименованию предмета\n" +
                                  "2. По стажу работы на последнем месте\n" +
                                  "3. По общему стажу работы\n" +
                                  "4. Вывод всех учителей\n" +
                                  "5. Назад");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Введите название предмета:");
                        var filter = Console.ReadLine();
                        Console.Clear();
                        foreach (var varTeacher in Teachers)
                        {
                            if (varTeacher.SubjectName == filter)
                            {
                                Console.WriteLine($"ФИО: {varTeacher.Name}\n" +
                                                  $"Дата рождения: {varTeacher.Birthdate}\n" +
                                                  $"Организация, где учитель получил образование: {varTeacher.Institution}\n" +
                                                  $"Описание трудовой книжки: {varTeacher.EmploymentRecordDescription}\n" +
                                                  $"Наименование предмета: {varTeacher.SubjectName}\n");
                            }
                        }
                        Console.WriteLine("\nИспользуйте любую кнопку для возврата на предыдущую страницу.");
                        Console.ReadKey();
                        Console.Clear();
                        Output();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Укажите стаж работы: ");
                        var filter_3 = Console.ReadLine();
                        Console.Clear();
                        foreach (var varTeacher in Teachers)
                        {
                            if (varTeacher.Employments != null)
                            {
                                if (Convert.ToInt32(filter_3) == Convert.ToInt32(varTeacher.Employments[varTeacher.Employments.Length - 1].DateOfDismissal) - Convert.ToInt32(varTeacher.Employments[varTeacher.Employments.Length - 1].DateOfReceipt))
                                {
                                    Console.WriteLine($"ФИО: {varTeacher.Name}\n" +
                                                      $"Дата рождения: {varTeacher.Birthdate}\n" +
                                                      $"Организация, где учитель получил образование: {varTeacher.Institution}\n" +
                                                      $"Описание трудовой книжки: {varTeacher.EmploymentRecordDescription}\n" +
                                                      $"Наименование предмета: {varTeacher.SubjectName}\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пусто");
                            }
                        }
                        Console.WriteLine("\nИспользуйте любую кнопку для возврата на предыдущую страницу.");
                        Console.ReadKey();
                        Console.Clear();
                        Output();
                        break;
                        
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Укажите стаж работы: ");
                        var filter_2 = Console.ReadLine();
                        Console.Clear();
                        foreach (var varTeacher in Teachers)
                        {
                            if (varTeacher.Employments != null)
                            {
                                int years = 0;
                                foreach (var employment in varTeacher.Employments)
                                {
                                    years += Convert.ToInt32(employment.DateOfDismissal) - Convert.ToInt32(employment.DateOfReceipt);
                                }

                                if (Convert.ToInt32(filter_2) == years)
                                {
                                    Console.WriteLine($"ФИО: {varTeacher.Name}\n" +
                                                      $"Дата рождения: {varTeacher.Birthdate}\n" +
                                                      $"Организация, где учитель получил образование: {varTeacher.Institution}\n" +
                                                      $"Описание трудовой книжки: {varTeacher.EmploymentRecordDescription}\n" +
                                                      $"Наименование предмета: {varTeacher.SubjectName}\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Пусто");
                            }
                        }
                        Console.WriteLine("\nИспользуйте любую кнопку для возврата на предыдущую страницу.");
                        Console.ReadKey();
                        Console.Clear();
                        Output();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        foreach (var varTeacher in Teachers)
                        {
                            Console.WriteLine($"ФИО: {varTeacher.Name}\n" +
                                              $"Дата рождения: {varTeacher.Birthdate}\n" +
                                              $"Организация, где учитель получил образование: {varTeacher.Institution}\n" +
                                              $"Описание трудовой книжки: {varTeacher.EmploymentRecordDescription}\n" +
                                              $"Наименование предмета: {varTeacher.SubjectName}\n");
                        }
                        Console.WriteLine("\nИспользуйте любую кнопку для возврата на предыдущую страницу.");
                        Console.ReadKey();
                        Console.Clear();
                        Output();
                        break;
                    case ConsoleKey.D5:
                        Menu();
                        break;
                }
            }
        }
    }
}