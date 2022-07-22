using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Balance
    {
        public DateTime DateAdd;
        public double Many;

        public Balance()
        {
            DateAdd = DateTime.Today;
            Many = 0.0;
        }


        public delegate void BalanceAdd(string Result);
        public event BalanceAdd? Add;
        public void CalcBalance(double ManyAdd)
        {
            string Result;

            if(ManyAdd <= 0)
            {
                Result = $"Отсутствует сумма для пополнения!";
                if (Add != null)
                {
                    Add(Result);
                }
            }
            else if (DateAdd >= DateTime.Today.AddDays(-DateTime.Today.Day + 1))
            {
                DateAdd = DateTime.Today;
                Many = Many + ManyAdd;

                Result = $"Ваш баланс пополнен на {ManyAdd}.";
                if (Add != null)
                {
                    Add(Result);
                }
            }
            else
            {
                if(ManyAdd >= (0- Many))
                {
                    DateAdd = DateTime.Today;
                    Many = Many + ManyAdd;

                    Result = $"Ваш баланс пополнен на {ManyAdd}.";
                    if (Add != null)
                    {
                        Add(Result);
                    }
                }
                else
                {
                    Result = $"Суммы не достаточно для пополнения баланса. Требуется минимум {0 - Many}!";
                    if (Add != null)
                    {
                        Add(Result);
                    }
                }
            }
        }
    }
}
