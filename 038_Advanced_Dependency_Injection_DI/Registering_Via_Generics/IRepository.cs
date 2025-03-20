namespace _038_Advanced_Dependency_Injection_DI.Registering_Via_Generics
{
    public interface IRepository<T>
    {
        void Add(T entity);
    }

}
