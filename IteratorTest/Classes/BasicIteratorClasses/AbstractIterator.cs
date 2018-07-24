namespace IteratorTest.Classes.BasicIteratorClasses
{
    public abstract class AbstractIterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
}