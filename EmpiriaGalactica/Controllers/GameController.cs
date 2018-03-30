using System.Collections.Generic;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI.Menus;

namespace EmpiriaGalactica.Controllers {
    public class GameController : IController {

        private IController _currentController;
        
        public GameController() {
            //_currentController = new MenuController(new MainMenu());
            
            var emp = new Empire {
                Name = "Test empire"
            };
            
            var sys = new StarSystemManager();
            for (int x = 0; x < 16; x++) {
                for (int y = 0; y < 16; y++) {
                    sys.RegisterItems(new StarSystem {
                        Position = new Vector(x, y),
                        Name = "test name - " + x + "-" + y,
                        Planets = new List<Planet>(new [] {
                            new Planet {
                                Name = "test",
                                Biome = Planet.PlanetBiome.Humid,
                                Buildings = new List<Building>(),
                                Pupulation = 15400,
                                Radius = 50,
                                Owner = emp
                            },
                            new Planet {
                                Name = "test",
                                Biome = Planet.PlanetBiome.Humid,
                                Buildings = new List<Building>(),
                                Pupulation = 15400,
                                Radius = 50,
                                Owner = emp
                            },
                            new Planet {
                                Name = "test",
                                Biome = Planet.PlanetBiome.Humid,
                                Buildings = new List<Building>(),
                                Pupulation = 15400,
                                Radius = 50,
                                Owner = emp
                            },
                            new Planet {
                                Name = "test",
                                Biome = Planet.PlanetBiome.Humid,
                                Buildings = new List<Building>(),
                                Pupulation = 15400,
                                Radius = 50,
                                Owner = emp
                            }
                        })
                    });
                }
            }
            
            _currentController = new GalaxyViewController(new Galaxy {
                Name = "Test galaxy",
                Empires = new List<Empire>(new [] {
                    emp
                }),
                StarSystems = sys
            });
        }

        public void Update() {
            _currentController.Update();
        }
        
        public void Dispose() {
            _currentController.Dispose();
        }

        public IController CurrentController {
            get => _currentController;
            set {
                _currentController.Dispose();
                _currentController = value;
                Update();
            }
        }
    }
}