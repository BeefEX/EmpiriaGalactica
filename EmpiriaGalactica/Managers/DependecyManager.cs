using System;
using System.Collections.Generic;
using System.Reflection;

namespace EmpiriaGalactica.Managers {
    
    /// <summary>
    /// Manages dependencies between assemblies.
    /// </summary>
    public static class DependecyManager {

        #region Members
        
        /// <summary>
        /// The mappings of types.
        /// </summary>
        private static readonly Dictionary<Type, Type> Mappings = new Dictionary<Type, Type>();

        /// <summary>
        /// Whenever the Init methodd was already called.
        /// </summary>
        private static bool _initDone;

        #endregion
        
        #region Methods
        
        /// <summary>
        /// Use to initialize the manager.
        /// </summary>
        /// <exception cref="Exception">Thrown if the method was already called.</exception>
        public static void Init() {

            if (_initDone) {
                _initDone = true;
                throw new Exception("Tried to reinitialize DpendecnyManager.");
            }

            var assembly = Assembly.GetEntryAssembly();
            
            
            foreach(var type in assembly.GetTypes()) {
                if (type.GetCustomAttributes(typeof(Implements), true).Length > 0) {
                    Mappings.Add(((Implements) type.GetCustomAttributes(typeof(Implements), true)[0]).Implementing, type);
                }
            }
        }
        
        /// <summary>
        /// Used to get an instance of a mapped type.
        /// </summary>
        /// <param name="parameters">The parameters to pass to the type.</param>
        /// <typeparam name="T">The type to get an instance of.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        /// <exception cref="Exception">Thrown if the type is not mapped to anything.</exception>
        public static T GetInstance<T>(params object[] parameters) {
            if (!Mappings.ContainsKey(typeof(T)))
                throw new Exception($"Type ${typeof(T).Name}");

            return (T) Activator.CreateInstance(Mappings[typeof(T)], parameters);
        }
        
        #endregion

    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class Implements : Attribute {

        #region Members
        
        /// <summary>
        /// The type the decorated type is implementing.
        /// </summary>
        private readonly Type _implementing;
        
        #endregion
        
        #region Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Used to signal that a type is an implementation of a different one.
        /// </summary>
        /// <param name="type">The type this one implements.</param>
        public Implements(Type type) {
            _implementing = type;
        }
        
        #endregion
        
        #region Properties

        /// <summary>
        /// The implemented type.
        /// </summary>
        public Type Implementing => _implementing;
        
        #endregion
    }
}