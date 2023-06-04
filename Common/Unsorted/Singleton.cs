namespace Common.Unsorted
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> instance = new(() => Activator.CreateInstance(typeof(T), true) as T);
        public static T Instance => instance.Value;
    }
}
