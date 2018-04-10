using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica {
    
    public class EmpiriaGalactica {
        
        public static GameController GameController;

        public static InstanceManager<Building> Buildings;
        public static InstanceManager<Resource> Resources;
        
        public EmpiriaGalactica() {
            
            Buildings = new InstanceManager<Building>();
            
            Buildings.RegisterItems(
                new Building {
                    Name = "Mine",
                    InternalName = "mine1",
                    BaseCost = new List<ResourceInstance>(),
                    Update = planet => planet.Pupulation += 10
                },
                new Building {
                    Name = "Minedsadsads",
                    InternalName = "mine2",
                    BaseCost = new List<ResourceInstance>(),
                    Update = planet => planet.Pupulation += 20
                },
                new Building {
                    Name = "Minedasdasdasdsad",
                    InternalName = "mine3",
                    BaseCost = new List<ResourceInstance>(),
                    Update = planet => planet.Pupulation += 30
                }
            );
            
            Resources = new InstanceManager<Resource>();
            GameController = new GameController();
        }
    }
}