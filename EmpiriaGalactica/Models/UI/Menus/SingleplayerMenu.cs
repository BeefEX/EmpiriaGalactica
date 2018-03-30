using System.Collections.Generic;
using System.IO;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.UI;
using EmpiriaGalactica.Managers;
using Newtonsoft.Json;

namespace EmpiriaGalactica.Models.UI.Menus {
    public class SingleplayerMenu : Menu {
        public SingleplayerMenu() {
            Buttons = new List<Button>(new [] {
                new Button {
                    Title = "New game",
                    OnClick = () => {
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

                        var game = new Galaxy {
                            Name = "Test galaxy",
                            Empires = new List<Empire>(new[] {
                                emp
                            }),
                            StarSystems = sys
                        };
                        
                        EmpiriaGalactica.GameController.CurrentController = new GalaxyViewController(game);
                    }
                },
                new Button {
                    Title = "Load game"
                },
                new Button {
                    Title = "Back",
                    OnClick = () => EmpiriaGalactica.GameController.PopBack()
                }
            });
        }
    }
}