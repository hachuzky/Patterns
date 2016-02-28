using System;
using System.Collections.Generic;
using System.Text;
namespace Client
{
    public interface IServiceA
    {
        void Execute();
    }

    public class ServiceA : IServiceA
    {
        public void Execute()
        {
            Console.WriteLine("A service called.");
        }
    }

    public interface IServiceB
    {
        void Execute();
    }

    public class ServiceB : IServiceB
    {
        public void Execute()
        {
            Console.WriteLine("B service called.");
        }
    }

    public interface IService
    {
        T GetService<T>();
    }
    public class ServiceLocator : IService
    {
        public Dictionary<object, object> servicecontainer = null;
        public ServiceLocator()
        {
            servicecontainer = new Dictionary<object, object>();
            servicecontainer.Add(typeof(IServiceA), new ServiceA());
            servicecontainer.Add(typeof(IServiceB), new ServiceB());
        }
        public T GetService<T>()
        {
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator loc = new ServiceLocator();
            IServiceA Aservice = loc.GetService<IServiceA>();
            Aservice.Execute();

            IServiceB Bservice = loc.GetService<IServiceB>();
            Bservice.Execute();

            Console.ReadLine();
        }
    }
}