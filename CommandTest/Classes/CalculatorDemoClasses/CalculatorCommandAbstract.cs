namespace CommandTest.Classes.CalculatorDemoClasses
{
    /// <summary>
    /// This is the abstract representation of the calculator command. It can be inherited to implement different types of commands.
    /// For this example we are only doing one, but certainly more could be implemented if we desired.
    /// </summary>
    public abstract class CalculatorCommandAbstract
    {
        public abstract string Execute();
        public abstract string UnExecute();
        public abstract string Clear();
    }
}