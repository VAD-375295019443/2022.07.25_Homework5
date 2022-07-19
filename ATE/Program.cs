using ATE;
using System;
using System.Linq;

namespace ATE
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Subscriber> subscriber = new List<Subscriber>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Компания-оператор АТС.");
                Console.WriteLine();
                Console.WriteLine("Абоненты:");

                if (subscriber.Count == 0)
                {
                    Console.WriteLine("Абоненты отсутствуют.");
                }
                else
                {
                    for (int int1 = 0; int1 <= subscriber.Count - 1; int1++)
                    {
                        Console.WriteLine($"{int1} - {subscriber[int1].Surname} {subscriber[int1].Name} {subscriber[int1].MiddleName}. Номер абонента: {subscriber[int1].PhoneNumber}");

                    }
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Заключение договора.");
                Console.WriteLine("2 - Расторжение договора.");
                Console.WriteLine("3 - Выбор абонента.");
                Console.WriteLine("Exit - Выход.");

                string? strMenuNumber = Console.ReadLine();

                switch(strMenuNumber)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Введите фамилию:");
                        string? Surname = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Введите имя:");
                        string? Name = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Введите отчество:");
                        string? MiddleName = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Введите дату рождения:");
                        string? DateOfBirth = Console.ReadLine();










                        if ((Surname != "" || Surname != null) && (Name != "" || Name != null) && (MiddleName != "" || MiddleName != null) && (DateOfBirth != "" || DateOfBirth != null) &&)
                        {
                            Airline.Add(new claAirline(strNameAirline));
                            F_WriteDatabaseAirplane(DatabaseAirplane); //Перезаписываем коллекцию в файл.
                        }

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    default:
                        break;
                }












                subscriber.Add(new Subscriber("ghg", "ghjgjh", "jhghjghjg", DateOnly.Parse("06.01.2022")));

                subscriber[0].Event += CalcPhoneNumber;
                subscriber[0].EventPhoneNumber();

            
                void CalcPhoneNumber()
                {
                    int MaxPhoneNumber;

                    if (subscriber.Count == 1)
                    {
                        MaxPhoneNumber = 1111111;
                        subscriber[0].PhoneNumber = MaxPhoneNumber;
                        subscriber[0].ContractNumber = MaxPhoneNumber;
                    }
                    else
                    {
                        MaxPhoneNumber = subscriber.Max(x => x.PhoneNumber) + 1;
                        subscriber[subscriber.Count-1].PhoneNumber = MaxPhoneNumber;
                        subscriber[subscriber.Count - 1].ContractNumber = MaxPhoneNumber;
                    }

                    Console.WriteLine($"Абонент с номером {MaxPhoneNumber} успешно добавлен в базу данных.") ;
                }


            }

            





        }





        
    }
}
