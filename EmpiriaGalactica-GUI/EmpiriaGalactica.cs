namespace EmpiriaGalactica_GUI {
    
    /// <summary>
    /// The entry call of the game.
    /// </summary>
    internal static class EmpiriaGalactica {

        #region Members
        
        /// <summary>
        /// An window instance.
        /// </summary>
        private static Window _window;

        private static global::EmpiriaGalactica.EmpiriaGalactica _gameInstance;
        
        #endregion
        
        #region Methods
        
        private static void Main(string[] args) {
            global::EmpiriaGalactica.Managers.DependecyManager.Init();
            _gameInstance = new global::EmpiriaGalactica.EmpiriaGalactica();
            
            _window = new Window();
            _window.Start();
            
        }

        #endregion

        #region Properties

        /// <summary>
        /// An window instance.
        /// </summary>
        public static Window Window => _window;

        #endregion
    }
}