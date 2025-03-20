namespace _038_Advanced_Dependency_Injection_DI.Registering_Via_Generics
{
    public class Repository<T> : IRepository<T>
    {
        public void Add(T entity)
        {
            // Generic repository logic
        }
    }

}
