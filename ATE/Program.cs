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
                Menu(aTE, 0);

                string? strMenuNumber = Console.ReadLine();

                if (strMenuNumber == "1")
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

                    for (int int1 = 0; int1 <= aTE.TariffPlan.Count - 1; int1++)
                    {
                        Console.WriteLine($"{int1}. {aTE.TariffPlan[int1].Name} {aTE.TariffPlan[int1].Price}.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Введите номер тарифного плана:");
                    int NumberTariffPlan;

                    if (Surname != "" && Surname != null && Name != "" && Name != null && MiddleName != "" && MiddleName != null && DateOfBirth != "" && DateOfBirth != null && Int32.TryParse(Console.ReadLine(), out NumberTariffPlan) && NumberTariffPlan >= 0 && NumberTariffPlan <= aTE.TariffPlan.Count - 1)
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
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Console.ReadLine();
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

                    if (Int32.TryParse(Console.ReadLine(), out NumberSubscriber) && aTE.Subscriber.Select(x => x.PhoneNumber).Contains(NumberSubscriber))
                    {
                        aTE.Subscriber.RemoveAll(x => x.PhoneNumber == NumberSubscriber);
                    }
                    else
                    {
                        Console.WriteLine("Ввод не корректных данных!");
                        Console.WriteLine("Нажмите Enter и повторите попытку.");
                        Console.ReadLine();
                    }
                }








                else if (strMenuNumber == "3")
                {
                    int NumberSubscriber;
                    int MyIndexSubscriber;

                    Console.WriteLine();
                    Console.WriteLine("Введите номер вашего абонента:");

                    if (Int32.TryParse(Console.ReadLine(), out NumberSubscriber) && aTE.Subscriber.Select(x => x.PhoneNumber).Contains(NumberSubscriber))
                    {
                        MyIndexSubscriber = aTE.Subscriber.FindIndex(x => x.PhoneNumber == NumberSubscriber);

                        while (true)
                        {
                            Menu(aTE, 1, MyIndexSubscriber);

                            strMenuNumber = Console.ReadLine();

                            if (strMenuNumber == "1")
                            {
                                aTE.Subscriber[MyIndexSubscriber].PortStatus = true;
                            }
                            else if (strMenuNumber == "2")
                            {
                                aTE.Subscriber[MyIndexSubscriber].PortStatus = false;
                            }
                            else if (strMenuNumber == "3")
                            {


                            }
                            else if (strMenuNumber == "4")
                            {




                            }





                            else if (strMenuNumber == "Exit" || strMenuNumber == "exit")
                            {
                                break;
                            }




                        }
                    }
                    else
                    {
                        Console.ReadLine();
                        Console.WriteLine("Ввод не корректных данных!");
                        Console.WriteLine("Нажмите Enter и повторите попытку.");
                    }


                }
                else if (strMenuNumber == "Exit" || strMenuNumber == "exit")
                {
                    Console.WriteLine();
                    Console.WriteLine("Goodby.");
                    break;
                }
            }
        }





















        public static void Menu(ATE aTE, ushort Index, int MyIndexSubscriber = (-1))
        {
            Console.Clear();
            Console.WriteLine("Automatic telephone exchange.");

            if (Index == 0)
            {
                if (aTE.Subscriber.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Абоненты:");
                    Console.WriteLine("Абоненты отсутствуют.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Абоненты:");

                    for (int int1 = 0; int1 <= aTE.Subscriber.Count - 1; int1++)
                    {
                        if (aTE.Subscriber[int1].PortStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (aTE.Subscriber[int1].PhoneCallStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.WriteLine($"Абонент: {aTE.Subscriber[int1].PhoneNumber}. Порт: {aTE.Subscriber[int1].PortStatus}. Соединение: {aTE.Subscriber[int1].PhoneCallStatus} - {aTE.Subscriber[int1].Surname} {aTE.Subscriber[int1].Name} {aTE.Subscriber[int1].MiddleName} {aTE.Subscriber[int1].DateOfBirth}.");
                    }
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Заключение договора.");
                Console.WriteLine("2 - Расторжение договора.");
                Console.WriteLine("3 - Выбор абонента.");
                Console.WriteLine("Exit - Выход.");
            }
            else if (Index == 1)
            {
                if (aTE.Subscriber.Count == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Абоненты:");
                    Console.WriteLine("Абоненты отсутствуют.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Абоненты:");

                    for (int int1 = 0; int1 <= aTE.Subscriber.Count - 1; int1++)
                    {
                        if (int1 == MyIndexSubscriber)
                        {
                            continue;
                        }

                        if (aTE.Subscriber[int1].PortStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (aTE.Subscriber[int1].PhoneCallStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.WriteLine($"Абонент: {aTE.Subscriber[int1].PhoneNumber}. Порт: {aTE.Subscriber[int1].PortStatus}. Соединение: {aTE.Subscriber[int1].PhoneCallStatus} - {aTE.Subscriber[int1].Surname} {aTE.Subscriber[int1].Name} {aTE.Subscriber[int1].MiddleName} {aTE.Subscriber[int1].DateOfBirth}.");
                    }
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.WriteLine("Ваш абонент:");

                    if (aTE.Subscriber[MyIndexSubscriber].PortStatus)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine($"Абонент: {aTE.Subscriber[MyIndexSubscriber].PhoneNumber}. Порт: {aTE.Subscriber[MyIndexSubscriber].PortStatus}. Соединение: {aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus} - {aTE.Subscriber[MyIndexSubscriber].Surname} {aTE.Subscriber[MyIndexSubscriber].Name} {aTE.Subscriber[MyIndexSubscriber].MiddleName} {aTE.Subscriber[MyIndexSubscriber].DateOfBirth}.");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Открытие порта.");
                Console.WriteLine("2 - Закрытие порта.");
                Console.WriteLine("3 - Звонок.");
                Console.WriteLine("4 - Смена тарифного плана.");
                Console.WriteLine("5 - Фильтр по дате звонков.");
                Console.WriteLine("6 - Фильтр по продолжительности звонков.");
                Console.WriteLine("7 - Фильтр по стоимости звонков.");
                Console.WriteLine("8 - Фильтр по абонентам.");
                Console.WriteLine("Exit - Выход в предыдущее меню.");
            }
        }















        /*
        aTE.Subscriber[aTE.Subscriber.Count - 1].Event += CalcPhoneNumber;
        aTE.Subscriber[aTE.Subscriber.Count - 1].EventPhoneNumber(aTE.Subscriber);
        aTE.Subscriber[aTE.Subscriber.Count - 1].Event -= CalcPhoneNumber;
        */



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
