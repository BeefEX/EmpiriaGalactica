using System.Collections.Generic;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// A class reepresenting an galaxy.
    /// </summary>
    public class Galaxy {
        
        /// <summary>
        /// The name of this galaxy.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The position of this gallaxy.
        /// 
        /// Not used for now.
        /// </summary>
        public Vector Position { get; set; }
        
        /// <summary>
        /// The star systems in this galaxy.
        /// </summary>
        public List<StarSystem> StarSystems { get; set; }
    }
}