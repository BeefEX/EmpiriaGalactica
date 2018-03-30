using System.Collections.Generic;
using EmpiriaGalactica.Managers;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// A class representing an galaxy.
    /// </summary>
    public class Galaxy : IModel {
        
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
        /// A list of all empires in this galaxy.
        /// </summary>
        public List<Empire> Empires { get; set; }
        
        /// <summary>
        /// The star systems in this galaxy.
        /// </summary>
        public StarSystemManager StarSystems { get; set; }
    }
}