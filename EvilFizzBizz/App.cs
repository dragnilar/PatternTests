namespace EvilFizzBizz
{
    public static class App
    {
        private static class FizzBizzValues
        {
            public const string Fizz = "Fizz";
            public const string Bizz = "Bizz";
            public const string FizzBizz = "Fizz Bizz!";
            public const string Pozz = "Pozz!";


            public const string Fuck = "Fuck";
            public const string You = "You";
            public const string FuckYou = "Fuck Yo Fizz Bizz";
            public const string ItsShitty = ", Its Shit";
        }

        public static class Config
        {
            public static string FizzBizzString = FizzBizzValues.FizzBizz;
            public static string FizzString = FizzBizzValues.Fizz;
            public static string BizzString = FizzBizzValues.Bizz;
            public static string PozzString = FizzBizzValues.Pozz;
            private static bool _obscene;

            public static void ToggleObscenities()
            {
                if (_obscene)
                {
                    FizzBizzString = FizzBizzValues.FizzBizz;
                    FizzString = FizzBizzValues.Fizz;
                    BizzString = FizzBizzValues.Bizz;
                    PozzString = FizzBizzValues.Pozz;
                    _obscene = false;
                }
                else
                {
                    FizzBizzString = FizzBizzValues.FuckYou;
                    FizzString = FizzBizzValues.Fuck;
                    BizzString = FizzBizzValues.You;
                    PozzString = FizzBizzValues.ItsShitty;
                    _obscene = true;
                }
            }
        }
    }
}