using System.Collections.Generic;

namespace EmpiriaGalactica.Managers {
    public class InstanceManager<T> where T : IInternalName {

        #region Members
        
        /// <summary>
        /// THe items that are registred to this register.
        /// </summary>
        private readonly Dictionary<string, T> _registeredItems;
        
        #endregion

        #region Methods

        /// <summary>
        /// Creates a new register.
        /// </summary>
        public InstanceManager() {
            _registeredItems = new Dictionary<string, T>();
        }

        /// <summary>
        /// Adds new items to this register.
        /// </summary>
        /// <param name="items">The items to add</param>
        public void RegisterItems(params T[] items) {
            foreach (var item in items) {
                _registeredItems.Add(item.InternalName, item);
            }
        }

        /// <summary>
        /// Check if this register contains the specified item.
        /// </summary>
        /// <param name="name">Name of the item to check for.</param>
        /// <returns>Whenever the item was found.</returns>
        public bool Contains(string name) {
            return _registeredItems.ContainsKey(name);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Used to retrieve an item registred by it's name.
        /// </summary>
        /// <param name="i">The name of the item to retrieve.</param>
        public T this[string i] => _registeredItems[i];

        #endregion
        
    }
}