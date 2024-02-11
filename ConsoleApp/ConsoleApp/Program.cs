namespace ConsoleApp
{
    internal class DelegatesTraining
    {
        public delegate void Display(string message);
        public delegate string Display2(string message);

        public static void Main(string[] args)
        {
            Console.WriteLine("hwllo world");

            Func<int, int, int> testFunc = (a, b) => { return a + b; };

            Calc((x, y) => { return x * y; }, 5, 3);

            Console.WriteLine(testFunc(1, 2));

            Console.WriteLine("=========================");

            Display d = ShowMessage;
            d += WriteMessage;
            d("hello");
            Console.WriteLine(d.Method);
            Console.WriteLine("=========================");

            test((x) =>
            {
                return $"from delegate param = {x}";
            },1,2);

            Action<string> Act = test;
            Act += test2;
            Act("hello");
        }

        private static void test(string obj)
        {
            Console.WriteLine($"Action1 received = {obj}");
        }

        private static void test2(string obj)
        {
            Console.WriteLine($"Action2 received = {obj}");
        }

        private static void Calc(Func<int, int, int> testFunc, int a, int b)
        {

            Console.WriteLine(testFunc(a, b));
        }

        public static void ShowMessage(string a)
        {
            Console.WriteLine($"Display = {a}");
        }

        public static void WriteMessage(string a)
        {
            Console.WriteLine($"Display = {a} ***");
        }

        public static void test(Display2 d, int a, int b)
        {
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            var result = d($"received {a} {b}");
            Console.WriteLine(result);
        }
    }
}