using Newtonsoft.Json;

namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// An instance of resource.
    /// </summary>
    public class ResourceInstance : IModel {
        
        /// <summary>
        /// The amount of the resource in this instance.
        /// </summary>
        public int Amount { get; set; }
        
        /// <summary>
        /// The prototype class of this resource.
        /// </summary>
        [JsonConverter(typeof(JsonToInternalNameConvertor))] // Used to convert it to class reference rather then to an object
        public Resource SourceResource { get; set; }
        
        #region Operators

        public static ResourceInstance operator +(ResourceInstance r, int i) {
            return new ResourceInstance {
                SourceResource = r.SourceResource,
                Amount = r.Amount + i
            };
        }
        
        public static ResourceInstance operator -(ResourceInstance r, int i) {
            return new ResourceInstance {
                SourceResource = r.SourceResource,
                Amount = r.Amount - i
            };
        }
        
        #endregion
    }
}