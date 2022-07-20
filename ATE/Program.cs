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

            aTE.tariffPlan.Add(new TariffPlan("Light plan", 10));
            aTE.tariffPlan.Add(new TariffPlan("Medium plan", 100));
            aTE.tariffPlan.Add(new TariffPlan("Supper plan", 1000));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Компания-оператор АТС.");
                Console.WriteLine();
                Console.WriteLine("Абоненты:");

                if (aTE.subscriber.Count == 0)
                {
                    Console.WriteLine("Абоненты отсутствуют.");
                }
                else
                {
                    for (int int1 = 0; int1 <= aTE.subscriber.Count - 1; int1++)
                    {
                        Console.WriteLine($"{int1} - {aTE.subscriber[int1].Surname} {aTE.subscriber[int1].Name} {aTE.subscriber[int1].MiddleName}. Номер абонента: {aTE.subscriber[int1].PhoneNumber}");

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

                    for (int int1 = 0; int1 <= aTE.tariffPlan.Count-1; int1++)
                    {
                        Console.WriteLine($"{int1}. {aTE.tariffPlan[int1].Name} {aTE.tariffPlan[int1].Price}.");
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("Введите номер тарифного плана:");
                    int NumberTariffPlan;
                    bool boolControl = Int32.TryParse(Console.ReadLine(), out NumberTariffPlan);

                    if ((Surname != "" || Surname != null) && (Name != "" || Name != null) && (MiddleName != "" || MiddleName != null) && (DateOfBirth != "" || DateOfBirth != null) && boolControl != false)
                    {
                        aTE.subscriber.Add(new Subscriber(Surname, Name, MiddleName, DateOnly.Parse(DateOfBirth), aTE.tariffPlan[NumberTariffPlan].Name, aTE.tariffPlan[NumberTariffPlan].Price));

                        aTE.subscriber[0].Event += CalcPhoneNumber;
                        aTE.subscriber[0].EventPhoneNumber(aTE.subscriber);
                        aTE.subscriber[0].Event -= CalcPhoneNumber;
                    }
                    else
                    {
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
                        aTE.subscriber.RemoveAt(NumberSubscriber);
                    }
                    else
                    {
                        Console.WriteLine("Ввод не корректных данных! Нажмите Enter и повторите попытку.");
                        Console.ReadLine();
                    }
                }














            }

            





        }


        public static void CalcPhoneNumber(List<Subscriber> subscriber)
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
                subscriber[subscriber.Count - 1].PhoneNumber = MaxPhoneNumber;
                subscriber[subscriber.Count - 1].ContractNumber = MaxPhoneNumber;
            }

            Console.WriteLine($"Абонент с номером {MaxPhoneNumber} успешно добавлен в базу данных.");
            Console.ReadLine();
        }







    }
}
