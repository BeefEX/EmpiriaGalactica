using Newtonsoft.Json;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// An instance of a building.
    /// </summary>
    public class BuildingInstance : IModel {
        
        /// <summary>
        /// The level of this building.
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// The prototype class of this building.
        /// </summary>
        [JsonConverter(typeof(JsonToInternalNameConvertor))] // Used to convert it to class reference rather then to an object
        public Building SourceBuilding { get; set; }
    }
}