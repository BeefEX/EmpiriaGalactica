using System;

namespace EmpiriaGalactica_CLI {
    internal static class EmpiriaGalacticaLauncher {

        public static EmpiriaGalactica.EmpiriaGalactica Game;
        
        static void Main(string[] args) {
            Game = new EmpiriaGalactica.EmpiriaGalactica();
        }
    }
}