using System.Collections;
using System.Collections.Generic;
using EmpiriaGalactica.Models;
using Newtonsoft.Json;

namespace EmpiriaGalactica.Managers {
    
    /// <inheritdoc />
    /// <summary>
    /// Used to store Star Systems indexed by their position.
    /// </summary>
    public class StarSystemManager : IEnumerable<StarSystem> {

        #region Members
        
        /// <summary>
        /// THe items that are registred to this register.
        /// </summary>
        [JsonProperty]
        private readonly Dictionary<string, StarSystem> _registeredItems;
        
        #endregion

        #region Methods

        /// <summary>
        /// Creates a new manager.
        /// </summary>
        public StarSystemManager() {
            _registeredItems = new Dictionary<string, StarSystem>();
        }

        /// <summary>
        /// Adds new items to this register.
        /// </summary>
        /// <param name="items">The items to add</param>
        public void RegisterItems(params StarSystem[] items) {
            foreach (var item in items) {
                _registeredItems.Add(item.Position.ToString(), item);
            }
        }

        /// <summary>
        /// Check if this register contains the specified item.
        /// </summary>
        /// <param name="position">The position to check for.</param>
        /// <returns>Whenever the item was found.</returns>
        public bool Contains(Vector position) => _registeredItems.ContainsKey(position.ToString());

        /// <inheritdoc />
        /// <summary>
        /// Used to enumerate the star systems.
        /// </summary>
        /// <returns>Enumerator containing the star systems.</returns>
        public IEnumerator<StarSystem> GetEnumerator() => _registeredItems.Values.GetEnumerator();

        /// <inheritdoc />
        /// <summary>
        /// Used to enumerate the star systems.
        /// </summary>
        /// <returns>Enumerator containing the star systems.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Properties

        /// <summary>
        /// Used to retrieve an item registred by it's name.
        /// </summary>
        /// <param name="i">The position of the item to retrieve.</param>
        public StarSystem this[Vector i] => _registeredItems[i.ToString()];

        #endregion
    }
}