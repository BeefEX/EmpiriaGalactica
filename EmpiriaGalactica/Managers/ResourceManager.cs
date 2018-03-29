using System.Collections.Generic;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Managers {
    
    /// <summary>
    /// Manages mutiple resource instances.
    /// </summary>
    public class ResourceManager {

        #region Members
        
        /// <summary>
        /// Used to store the resources internally.
        /// </summary>
        private readonly Dictionary<string, ResourceInstance> _resources;

        #endregion
        
        #region Methods
        
        /// <summary>
        /// Creates a new resource manager. 
        /// </summary>
        public ResourceManager() {
            _resources = new Dictionary<string, ResourceInstance>();
        }

        /// <summary>
        /// Used to remove an resource from the list.
        /// </summary>
        /// <param name="name">The internal name of the resource to clear.</param>
        public void ClearResource(string name) {
            _resources.Remove(name);
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Used to query an resource by it's internal name.
        /// </summary>
        /// <param name="name">Th ename of the resource.</param>
        public ResourceInstance this[string name] => _resources[name];

        #endregion
    }
}