using System;

namespace PayPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            PayPoint _payPoint = new PayPoint(1200.56m);
           // Console.WriteLine(_payPoint.GetMoney());
            _payPoint.GiveMoney += (decimal hesab, int required) => {
                Console.WriteLine($"Teessuf Istediyiniz Mebleg Hesabinizda yoxdur! Movcud Hesab: {hesab}, teleb olunan Mebleg{required}");
            };
            _payPoint.OutMoney(2568);
        }
    }
    public class PayPoint
    {
        public event Action<decimal, int> GiveMoney;
        public decimal Hesab { get; set; }

        public PayPoint(decimal hesab)
        {
            Hesab = hesab;
        }

        public decimal GetMoney()
        {
            return Hesab;
        }

        public void OutMoney(int demand)
        {
            if (Hesab > demand)
            {
                Hesab -= demand;
                Console.WriteLine($"Emeliyyat ugurla yerine yetirildi : Qaliq {Hesab}");
            }
            else
            {
                GiveMoney.Invoke(Hesab, demand);
            }
        }
    }
}
