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
            public static string FizzBizzString = App.FizzBizzValues.FizzBizz;
            public static string FizzString = App.FizzBizzValues.Fizz;
            public static string BizzString = App.FizzBizzValues.Bizz;
            public static string PozzString = App.FizzBizzValues.Pozz;
            private static bool _obscene;

            public static void ToggleObscenities()
            {
                if (_obscene)
                {
                    FizzBizzString = App.FizzBizzValues.FizzBizz;
                    FizzString = App.FizzBizzValues.Fizz;
                    BizzString = App.FizzBizzValues.Bizz;
                    PozzString = App.FizzBizzValues.Pozz;
                    _obscene = false;
                }
                else
                {
                    FizzBizzString = App.FizzBizzValues.FuckYou;
                    FizzString = App.FizzBizzValues.Fuck;
                    BizzString = App.FizzBizzValues.You;
                    PozzString = App.FizzBizzValues.ItsShitty;
                    _obscene = true;
                }
            }
        }


    }
}
