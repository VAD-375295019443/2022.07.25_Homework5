using ATE;
using System;
using System.Linq;

namespace ATE
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ATE aTE = new ATE();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Компания-оператор АТС.");
                Console.WriteLine();
                Console.WriteLine("Абоненты:");

                if (aTE.Subscriber.Count == 0)
                {
                    Console.WriteLine("Абоненты отсутствуют.");
                }
                else
                {
                    for (int int1 = 0; int1 <= aTE.Subscriber.Count - 1; int1++)
                    {
                        Console.WriteLine($"Номер абонента: {aTE.Subscriber[int1].PhoneNumber} - {aTE.Subscriber[int1].Surname} {aTE.Subscriber[int1].Name} {aTE.Subscriber[int1].MiddleName}.");

                    }
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Заключение договора.");
                Console.WriteLine("2 - Расторжение договора.");
                Console.WriteLine("3 - Выбор абонента.");
                Console.WriteLine("Exit - Выход.");

                string? strMenuNumber = Console.ReadLine();

                if(strMenuNumber == "1")
                {
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
                    Console.WriteLine();

                    for (int int1 = 0; int1 <= aTE.TariffPlan.Count-1; int1++)
                    {
                        Console.WriteLine($"{int1}. {aTE.TariffPlan[int1].Name} {aTE.TariffPlan[int1].Price}.");
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("Введите номер тарифного плана:");
                    int NumberTariffPlan;
                    bool boolControl = Int32.TryParse(Console.ReadLine(), out NumberTariffPlan);

                    if ((Surname != "" || Surname != null) && (Name != "" || Name != null) && (MiddleName != "" || MiddleName != null) && (DateOfBirth != "" || DateOfBirth != null) && boolControl != false)
                    {
                        int PhoneNumber;

                        if (aTE.Subscriber.Count == 0)
                        {
                            PhoneNumber = 11111;
                        }
                        else
                        {
                            PhoneNumber = aTE.Subscriber.Max(z => z.PhoneNumber) + 1;

                        }

                        aTE.Subscriber.Add(new Subscriber(Surname, Name, MiddleName, DateOnly.Parse(DateOfBirth), PhoneNumber, aTE.TariffPlan[NumberTariffPlan].Name, aTE.TariffPlan[NumberTariffPlan].Price));
                        
                        Console.WriteLine($"Абонент с номером {PhoneNumber} успешно добавлен в базу данных.");
                        Console.ReadLine();






                        /*
                        aTE.Subscriber[aTE.Subscriber.Count - 1].Event += CalcPhoneNumber;
                        aTE.Subscriber[aTE.Subscriber.Count - 1].EventPhoneNumber(aTE.Subscriber);
                        aTE.Subscriber[aTE.Subscriber.Count - 1].Event -= CalcPhoneNumber;
                        */
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ввод не корректных данных! Нажмите Enter и повторите попытку.");
                        Console.ReadLine();
                            
                    }

                    
                }
                else if (strMenuNumber == "2")
                {
                    int NumberSubscriber;
                    Console.WriteLine();
                    Console.WriteLine("Введите номер абонента:");
                    bool boolControl = Int32.TryParse(Console.ReadLine(), out NumberSubscriber);

                    if (boolControl != false)
                    {
                        aTE.Subscriber.RemoveAt(NumberSubscriber);
                    }
                    else
                    {
                        Console.WriteLine("Ввод не корректных данных! Нажмите Enter и повторите попытку.");
                        Console.ReadLine();
                    }
                }














            }

            





        }













        public static void CalcPhoneNumber(List<Subscriber> Subscriber)
        {
            int MaxPhoneNumber;

            if (Subscriber.Count == 0)
            {
                MaxPhoneNumber = 11111;
                Subscriber[0].PhoneNumber = MaxPhoneNumber;
            }
            else
            {
                MaxPhoneNumber = Subscriber.Max(x => x.PhoneNumber) + 1;
                Subscriber[Subscriber.Count - 1].PhoneNumber = MaxPhoneNumber;
            }

            Console.WriteLine($"Абонент с номером {MaxPhoneNumber} успешно добавлен в базу данных.");
            Console.ReadLine();
        }







    }
}
