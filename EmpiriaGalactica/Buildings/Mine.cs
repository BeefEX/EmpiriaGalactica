using System;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Buildings {
    public class Mine : Building {
        
        public override void Update(Planet planet) {
            Console.WriteLine("Mining ...");
        }
    }
}