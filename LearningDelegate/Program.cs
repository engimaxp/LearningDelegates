using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace LearningDelegate
{
    class Program
    {
        private delegate string GetAString();
        struct Currency
        {
            public uint Dollars;
            public ushort Cents;
            public Currency(uint dollars, ushort cents)
            {
                this.Dollars = dollars;
                this.Cents = cents;
            }
            public override string ToString()
            {
                return string.Format("${0}.{1,2:00}",Dollars,Cents);
            }
            public static string GetCurrencyUnit() { return "Dolar"; }
            public static explicit operator Currency(float value)
            {
                checked {
                    uint dollars = (uint)value;
                    ushort cents = (ushort)((value - dollars) * 100);
                    return new Currency(dollars, cents);
                }
            }
            public static implicit operator float(Currency value)
            {
                return value.Dollars + (value.Cents / 100.0f);
            }
            public static implicit operator Currency(uint value)
            {
                return new Currency(value, 0);
            }
            public static implicit operator uint(Currency value)
            {
                return value.Dollars;
            }
        }
        class MathOp
        {
            public static void Cheng2(double value)
            {
                Console.WriteLine("Value is {0},result of operation is {1}", value, value * 2);
            }
            public static void Square(double value)
            { 
                Console.WriteLine("Value is {0},result of operation is {1}", value, value * value);
            }

        }
        delegate double doubleop(double x);
        static void ProDisplay(doubleop a, double value)
        {
            Console.WriteLine("Value is {0},result of operation is {1}",value,a(value));
        }
        public class CarInfoEventArgs : EventArgs
        {
            public CarInfoEventArgs(string car)
            {
                this.Car = car;
            }
            public string Car { get; private set; }
        }
        public class CarDealer
        {
            public event EventHandler<CarInfoEventArgs> NewCarInfo;
            public void NewCar(string car)
            {
                Console.WriteLine("CarDealer,new car {0}",car);
                RaiseNewCarInfo(car);
            }
            protected virtual void RaiseNewCarInfo(string car)
            {
                EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
                if (newCarInfo != null)
                {
                    newCarInfo(this, new CarInfoEventArgs(car));
                }
            }
        }
        public class Consumer
        {
            private string name;
            public Consumer(string name)
            {
                this.name = name;
            }
            public void NewCarIsHere(object sender, CarInfoEventArgs e)
            {
                Console.WriteLine("{0}: car {1} is new",name,e.Car);
            }
        }
        static void Main(string[] args)
        {

            var dealer = new CarDealer();

            var michael = new Consumer("Michael");



            //dealer.NewCarInfo += michael.NewCarIsHere;

            //dealer.NewCar("Ferrari");

            //var sebastian = new Consumer("sebastian");
            //dealer.NewCarInfo += sebastian.NewCarIsHere;

            //dealer.NewCar("Mercedes");

            //dealer.NewCarInfo -= michael.NewCarIsHere;

            //dealer.NewCar("Red Bull");

            //int x = 40;
            //GetAString firstStringMethod = new GetAString(x.ToString);
            //Console.WriteLine("String is {0}",firstStringMethod());
            //Console.ReadLine();

            //Currency balance = new Currency(34, 50);
            //firstStringMethod = balance.ToString;
            //Console.WriteLine("string is {0}",firstStringMethod());

            //firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            //Console.WriteLine("string is {0}", firstStringMethod()); 
            //Action<double> ops1 = MathOp.Cheng2;
            //Action<double> ops2 = MathOp.Square;
            //Action<double> ops3 = ops1 + ops2;
            //Action<double> ops4 = param =>
            //{
            //    Console.WriteLine("Value is {0},result of operation is {1}",param,param+33);
            //};
            //ops1(7.94);
            //ops2(7.94);
            //ops3(7.94);
            //ops4(7.94);
                //Console.WriteLine("Value is {0},result of operation is {1}", 2.0, ops[i](2.0));
                //Console.WriteLine("Value is {0},result of operation is {1}", 7.94, ops[i](7.94));
                //Console.WriteLine("Value is {0},result of operation is {1}", 1.414, ops[i](1.414));



            //var values = new List<int>() { 10, 20, 30 };
            //var funcs = new List<Func<int>>();
            //foreach (var val in values)
            //{
            //    funcs.Add(() => val);
            //}
            //foreach (var f in funcs)
            //{
            //    Console.WriteLine(f());
            //}





                Console.ReadLine();

        }
    }
}
