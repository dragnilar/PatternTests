namespace DependencyInjectionTest.Classes
{
    class ClassOne : IClassOne
    {
        public string SomeString { get; set; }

        public ClassOne()
        {
            SomeString = "I am the default string for Class One's SomeString";
        }
    }
}
