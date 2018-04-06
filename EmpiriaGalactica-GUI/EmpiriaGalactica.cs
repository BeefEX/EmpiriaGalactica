namespace EmpiriaGalactica_GUI {
    
    /// <summary>
    /// The entry call of the game.
    /// </summary>
    internal static class EmpiriaGalactica {

        /// <summary>
        /// An window instance.
        /// </summary>
        private static Window _window;

        
        private static void Main(string[] args) {
            global::EmpiriaGalactica.Managers.DependecyManager.Init();
            
            _window = new Window();
            _window.Start();
        }
    }
}