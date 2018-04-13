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
        /// <param name="resource">The internal name of the resource to clear.</param>
        public void ClearResource(Resource resource) {
            _resources.Remove(resource.InternalName);
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Used to query an resource by a prototype.
        /// </summary>
        /// <param name="resource">The prototype of the instance.</param>
        public ResourceInstance this[Resource resource] => this[resource.InternalName];

        /// <summary>
        /// Used to query an resource by it's internal name.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        public ResourceInstance this[string name] {
            get {
                // Creating a resource instance if we doesn't have one already
                if (!_resources.ContainsKey(name))
                    _resources.Add(name, new ResourceInstance {
                        SourceResource = EmpiriaGalactica.Resources[name],
                        Amount = 0
                    });
                
                return _resources[name];
            }
            set => _resources[name] = value;
        }

        #endregion
    }
}