using JetBrains.Annotations;

namespace ReSharperReproducer
{
    public class Reproducer
    {
#nullable enable

        public void Broken(object? obj)
        {
            DoSomething(obj); // <-- should produce a "Possible 'null' assignment to non-nullable entity" warning
        }

#nullable disable

        public void Works([CanBeNull] object obj)
        {
            DoSomething(obj); // <-- does produce this warning
        }

#nullable restore

        public void DoSomething<T>([NotNull] T input)
        {

        }
    }
}
