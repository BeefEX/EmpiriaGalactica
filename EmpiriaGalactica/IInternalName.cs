namespace EmpiriaGalactica {
    
    /// <summary>
    /// Used to mark all indexable items.
    /// </summary>
    public interface IInternalName {
        
        /// <summary>
        /// The internal name of this item.
        /// </summary>
        string InternalName { get; }
    }
}