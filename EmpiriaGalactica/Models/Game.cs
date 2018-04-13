namespace EmpiriaGalactica.Models {
    
    /// <summary>
    /// Stores all data related to a savegame.
    /// </summary>
    public class Game : IModel {

        /// <summary>
        /// The currently playing player.
        /// </summary>
        public Empire CurrentPlayer { get; set; }
        
        /// <summary>
        /// Number of the current turn of the game.
        /// </summary>
        public int CurrentTurn { get; set; }
        
        /// <summary>
        /// The galaxy of this savegame.
        /// </summary>
        public Galaxy Galaxy { get; set; }
    }
}