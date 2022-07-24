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
                        int NumberSubscriber;

                        if (aTE.Subscriber.Count == 0)
                        {
                            NumberSubscriber = 11111;
                        }
                        else
                        {
                            NumberSubscriber = aTE.Subscriber.Max(z => z.NumberSubscriber) + 1;

                        }

                        aTE.Subscriber.Add(new Subscriber(Surname, Name, MiddleName, DateOnly.Parse(DateOfBirth), NumberSubscriber, aTE.TariffPlan[NumberTariffPlan].Name, aTE.TariffPlan[NumberTariffPlan].Price));

                        Console.WriteLine($"Абонент с номером {NumberSubscriber} успешно добавлен в базу данных.");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ввод не корректных данных!");
                        Console.WriteLine("Нажмите Enter и повторите попытку.");
                        Console.ReadLine();
                    }
                }
                else if (strMenuNumber == "2")
                {
                    int NumberSubscriber;
                    Console.WriteLine();
                    Console.WriteLine("Введите номер абонента:");

                    if (Int32.TryParse(Console.ReadLine(), out NumberSubscriber) && aTE.Subscriber.Select(x => x.NumberSubscriber).Contains(NumberSubscriber))
                    {
                        aTE.Subscriber.RemoveAll(x => x.NumberSubscriber == NumberSubscriber);
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
                    int MyNumberSubscriber;
                    int MyIndexSubscriber;

                    Console.WriteLine();
                    Console.WriteLine("Введите номер вашего абонента:");

                    if (Int32.TryParse(Console.ReadLine(), out MyNumberSubscriber) && aTE.Subscriber.Select(x => x.NumberSubscriber).Contains(MyNumberSubscriber))
                    {
                        MyIndexSubscriber = aTE.Subscriber.FindIndex(x => x.NumberSubscriber == MyNumberSubscriber);

                        while (true)
                        {
                            Menu(aTE, 1, MyIndexSubscriber);
                            strMenuNumber = Console.ReadLine();

                            if (strMenuNumber == "1")
                            {
                                aTE.Subscriber[MyIndexSubscriber].OnOff += InfoPortStatus;
                                aTE.Subscriber[MyIndexSubscriber].CalcPortStatus();
                                aTE.Subscriber[MyIndexSubscriber].OnOff -= InfoPortStatus;
                            }
                            else if (strMenuNumber == "2")
                            {
                                if (aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.CallStatus == true)
                                {
                                    aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.Off += InfoCallStatusOff;
                                    aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.CalcCallStatusOff(aTE, MyIndexSubscriber);
                                    aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.Off -= InfoCallStatusOff;
                                    continue;
                                }
                                
                                if (aTE.Subscriber[MyIndexSubscriber].PortStatus == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Ваш телефон не подключен к сети! Измените статус порта.");
                                    Console.WriteLine("Для продолжения нажмите Enter.");
                                    Console.ReadLine();
                                    continue;
                                }
                                
                                Console.WriteLine();
                                Console.WriteLine("Введите номер абонента, которому вы воните:");

                                if (Int32.TryParse(Console.ReadLine(), out int DialedNumberSubscriber) == false)
                                {
                                    ErrorInfo(); continue;
                                }

                                if (MyNumberSubscriber == DialedNumberSubscriber || aTE.Subscriber.Select(x => x.NumberSubscriber).Contains(DialedNumberSubscriber) == false)
                                {
                                    ErrorInfo(); continue;
                                }

                                int DialedIndexSubscriber = aTE.Subscriber.FindIndex(x => x.NumberSubscriber == DialedNumberSubscriber);

                                if (aTE.Subscriber[DialedIndexSubscriber].PhoneCallStatus.CallStatus == true)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Абонент, которому вы звоните, занят! Перезвоните позже.");
                                    Console.WriteLine("Для продолжения нажмите Enter.");
                                    Console.ReadLine();
                                    continue;
                                }

                                if (aTE.Subscriber[DialedIndexSubscriber].PortStatus == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Телефон абонента, которому вы звоните не подключен к сети! Требуется изменить статус порта.");
                                    Console.WriteLine("Для продолжения нажмите Enter.");
                                    Console.ReadLine();
                                    continue;
                                }

                                aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.On += InfoCallStatusOn;
                                aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.CalcCallStatusOn(aTE, DialedIndexSubscriber);
                                aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.On -= InfoCallStatusOn;
                            }
                            else if (strMenuNumber == "3")
                            {
                                aTE.Subscriber[MyIndexSubscriber].TariffPlan.Replace += CalcTariffPlanReplace;
                                aTE.Subscriber[MyIndexSubscriber].TariffPlan.CalcTariffPlanReplace(aTE, MyIndexSubscriber);
                                aTE.Subscriber[MyIndexSubscriber].TariffPlan.Replace -= CalcTariffPlanReplace;
                            }
                            else if (strMenuNumber == "4")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Введите сумму пополнения баланса:");

                                if (double.TryParse(Console.ReadLine(), out double Many))
                                {
                                    aTE.Subscriber[MyIndexSubscriber].Balance.Add += InfoBalance;
                                    aTE.Subscriber[MyIndexSubscriber].Balance.CalcBalance(Many);
                                    aTE.Subscriber[MyIndexSubscriber].Balance.Add -= InfoBalance;
                                }
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
                        Console.ReadLine();
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
                        if (aTE.Subscriber[int1].PhoneCallStatus.CallStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (aTE.Subscriber[int1].PortStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }

                        if (int1 > 0)
                        {
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Абонент: {aTE.Subscriber[int1].NumberSubscriber}.");
                        Console.WriteLine($"Ф.И.О: {aTE.Subscriber[int1].Surname} {aTE.Subscriber[int1].Name} {aTE.Subscriber[int1].MiddleName} {aTE.Subscriber[int1].DateOfBirth}.");
                        Console.WriteLine($"Баланс: {aTE.Subscriber[int1].Balance.Many}. Дата последнего пополнения: {aTE.Subscriber[int1].Balance.DateAdd}.");
                        Console.WriteLine($"Состояние порта: {aTE.Subscriber[int1].PortStatus}.");
                        Console.WriteLine($"Состояние соединения: {aTE.Subscriber[int1].PhoneCallStatus.CallStatus}.");
                        Console.WriteLine($"Тариф: {aTE.Subscriber[int1].TariffPlan.Name}. Цена: {aTE.Subscriber[int1].TariffPlan.Price}. Дата смены тарифа: {aTE.Subscriber[int1].TariffPlan.Date}.");
                        Console.ResetColor();
                    }
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
                
                Console.WriteLine();
                Console.WriteLine("Абоненты:");

                for (int int1 = 0; int1 <= aTE.Subscriber.Count - 1; int1++)
                {
                    if (int1 == MyIndexSubscriber)
                    {
                        continue;
                    }

                    if (aTE.Subscriber[int1].PhoneCallStatus.CallStatus)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (aTE.Subscriber[int1].PortStatus)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    if (MyIndexSubscriber == 0)
                    {
                        if (int1 >= 2)
                        {
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if (int1 >= 1)
                        {
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine($"Абонент: {aTE.Subscriber[int1].NumberSubscriber}.");
                    Console.WriteLine($"Ф.И.О: {aTE.Subscriber[int1].Surname} {aTE.Subscriber[int1].Name} {aTE.Subscriber[int1].MiddleName} {aTE.Subscriber[int1].DateOfBirth}.");
                    Console.WriteLine($"Баланс: {aTE.Subscriber[int1].Balance.Many}. Дата последнего пополнения: {aTE.Subscriber[int1].Balance.DateAdd}.");
                    Console.WriteLine($"Состояние порта: {aTE.Subscriber[int1].PortStatus}.");
                    Console.WriteLine($"Состояние соединения: {aTE.Subscriber[int1].PhoneCallStatus.CallStatus}.");
                    Console.WriteLine($"Тариф: {aTE.Subscriber[int1].TariffPlan.Name}. Цена: {aTE.Subscriber[int1].TariffPlan.Price}. Дата смены тарифа: {aTE.Subscriber[int1].TariffPlan.Date}.");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("Ваш абонент:");

                if (aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.CallStatus)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (aTE.Subscriber[MyIndexSubscriber].PortStatus)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine($"Абонент: {aTE.Subscriber[MyIndexSubscriber].NumberSubscriber}.");
                Console.WriteLine($"Ф.И.О: {aTE.Subscriber[MyIndexSubscriber].Surname} {aTE.Subscriber[MyIndexSubscriber].Name} {aTE.Subscriber[MyIndexSubscriber].MiddleName} {aTE.Subscriber[MyIndexSubscriber].DateOfBirth}.");
                Console.WriteLine($"Баланс: {aTE.Subscriber[MyIndexSubscriber].Balance.Many}. Дата последнего пополнения: {aTE.Subscriber[MyIndexSubscriber].Balance.DateAdd}.");
                Console.WriteLine($"Состояние порта: {aTE.Subscriber[MyIndexSubscriber].PortStatus}.");
                Console.WriteLine($"Состояние соединения: {aTE.Subscriber[MyIndexSubscriber].PhoneCallStatus.CallStatus}.");
                Console.WriteLine($"Тариф: {aTE.Subscriber[MyIndexSubscriber].TariffPlan.Name}. Цена: {aTE.Subscriber[MyIndexSubscriber].TariffPlan.Price}. Дата смены тарифа: {aTE.Subscriber[MyIndexSubscriber].TariffPlan.Date}.");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню:");
                Console.WriteLine("1 - Порт On/Off.");
                Console.WriteLine("2 - Звонок On/Off.");
                Console.WriteLine("3 - Смена тарифного плана.");
                Console.WriteLine("4 - Пополнение баланса.");
                Console.WriteLine("5 - Фильтр по дате звонков.");
                Console.WriteLine("6 - Фильтр по продолжительности звонков.");
                Console.WriteLine("7 - Фильтр по стоимости звонков.");
                Console.WriteLine("8 - Фильтр по абонентам.");
                Console.WriteLine("Exit - Выход в предыдущее меню.");
            }
        }


        public static void InfoPortStatus(string Result)
        {
            Console.WriteLine();
            Console.WriteLine(Result);
            Console.WriteLine("Для продолжения нажмите Enter.");
            Console.ReadLine();
        }


        public static void InfoCallStatusOn(int DialedNumberSubscriber, string DialedNameSubscriber)
        {
            Console.WriteLine();
            Console.WriteLine($"Соединение c абонентом {DialedNumberSubscriber} ({DialedNameSubscriber}) установлено!");
            Console.WriteLine("Для продолжения нажмите Enter.");
            Console.ReadLine();
        }


        public static void InfoCallStatusOff(ATE aTE, int MyNumberSubscriber, string MyNameSubscriber, int DialedNumberSubscriber, string DialedNameSubscriber, DateTime CallDateStart, DateTime CallDateStop, Double Price)
        {
            TimeSpan CallDuration = CallDateStop - CallDateStart;
            double SecondDifference = CallDuration.TotalSeconds;
            int NumberOfSeconds = (int)SecondDifference;

            double Cost = NumberOfSeconds * Price;

            aTE.Magazine.Add(new Magazine(MyNumberSubscriber, MyNameSubscriber, DialedNumberSubscriber, DialedNameSubscriber, CallDateStart, CallDateStop, CallDuration, Price, Cost));

            aTE.Subscriber[aTE.Subscriber.FindIndex(x => x.NumberSubscriber == MyNumberSubscriber)].Balance.Many -= Cost;

            Console.WriteLine();
            Console.WriteLine($"Соединение c абонентом {DialedNumberSubscriber} ({DialedNameSubscriber}) завершено! Длительность: {CallDuration}sec, стоимость: {Cost}.");
            Console.WriteLine("Для продолжения нажмите Enter.");
            Console.ReadLine();
        }


        public static void InfoBalance(string Result)
        {
            Console.WriteLine();
            Console.WriteLine(Result);
            Console.WriteLine("Для продолжения нажмите Enter.");
            Console.ReadLine();
        }


        public static void CalcTariffPlanReplace(ATE aTE, int MyIndexSubscriber)
        {
            if (aTE.Subscriber[MyIndexSubscriber].TariffPlan.Date < aTE.Subscriber[MyIndexSubscriber].TariffPlan.Date.AddMonths(1))
            {
                Console.WriteLine();
                Console.WriteLine($"Вы сможете сменить тарифный план не ранеее чем {aTE.Subscriber[MyIndexSubscriber].TariffPlan.Date.AddMonths(1)}!");
                Console.WriteLine("Для продолжения нажмите Enter.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                for (int int1 = 0; int1 <= aTE.TariffPlan.Count - 1; int1++)
                {
                    Console.WriteLine($"{int1}. {aTE.TariffPlan[int1].Name} {aTE.TariffPlan[int1].Price}.");
                }

                Console.WriteLine();
                Console.WriteLine("Введите номер тарифного плана:");
                int NumberTariffPlan;

                if (Int32.TryParse(Console.ReadLine(), out NumberTariffPlan) && NumberTariffPlan >= 0 && NumberTariffPlan <= aTE.TariffPlan.Count - 1)
                {
                    aTE.Subscriber[MyIndexSubscriber].TariffPlan.Date = DateTime.Now;
                    aTE.Subscriber[MyIndexSubscriber].TariffPlan.Name = aTE.TariffPlan[NumberTariffPlan].Name;
                    aTE.Subscriber[MyIndexSubscriber].TariffPlan.Price = aTE.TariffPlan[NumberTariffPlan].Price;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ввод не корректных данных!");
                    Console.WriteLine("Нажмите Enter и повторите попытку.");
                    Console.ReadLine();
                }
            }
        }


        public static void ErrorInfo()
        {
            Console.WriteLine("Ввод не корректных данных!");
            Console.WriteLine("Нажмите Enter и повторите попытку.");
            Console.ReadLine();
        }







    }
}
