using System;
using System.Runtime.InteropServices;
using ImGuiNET;

namespace EmpiriaGalactica_GUI {
    
    /// <summary>
    /// The entry call of the game.
    /// </summary>
    internal static class EmpiriaGalactica {

        /// <summary>
        /// An window instance.
        /// </summary>
        private static Window _window;

        private static global::EmpiriaGalactica.EmpiriaGalactica _gameInstance;
        
        private static void Main(string[] args) {
            global::EmpiriaGalactica.Managers.DependecyManager.Init();
            _gameInstance = new global::EmpiriaGalactica.EmpiriaGalactica();
            
            _window = new Window();
            _window.Start();
            
        }

        /// <summary>
        /// An window instance.
        /// </summary>
        public static Window Window => _window;
    }
}