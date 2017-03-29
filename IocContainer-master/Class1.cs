using System;
using System.Collections.Generic;
using System.Linq;

namespace IoCContainer
{
    public class SimpleIocContainer : IContainer
    {
        private readonly IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();
        public void Register<TTypeToResolve, TConcrete>()
        {
            Register<TTypeToResolve, TConcrete>(LifeCycle.Transient);
        }

        public void Register<TTypeToResolve, TConcrete>(LifeCycle lifeCycle)
        {
            registeredObjects.Add(new RegisteredObject(typeof(TTypeToResolve), typeof(TConcrete), lifeCycle));
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type typeToResolve)
        {
            throw new NotImplementedException();
        }

        private object ResolveObject(Type typeToResolve)
        {
            var registered = registeredObjects.FirstOrDefault(r => r.TypeToResolve == typeToResolve);
            if(registered == null) throw new ObjectTypeNotRegisteredException(typeToResolve.Name);    
            return GetInstance(registered);
        }

        private object GetInstance(RegisteredObject registered)
        {
            if(registered.Instance == null || registered.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(registered);
                registered.CreateInstance(parameters.ToArray());
            }
            return registered.Instance;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registered)
        {
            var info = registered.ConcreteType.GetConstructors().First();
            foreach(var parameter in info.GetParameters())
                yield return ResolveObject(parameter.ParameterType);
        }
    }
}
