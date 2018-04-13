using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.ViewControllers;
using EmpiriaGalactica.Managers;

namespace EmpiriaGalactica.Models.UI.Menus {
    public class SingleplayerMenu : Menu {
        public SingleplayerMenu() {
            Buttons = new List<Button>(new [] {
                new Button {
                    Title = "New game",
                    OnClick = () => {
                        var emp = new Empire {
                            Name = "Test empire",
                            Resources = new ResourceManager()
                        };

                        emp.Resources["resource/metal"] += 1000;

                        var sys = new StarSystemManager();
                        for (int x = 0; x < 16; x++) {
                            for (int y = 0; y < 16; y++) {
                                sys.RegisterItems(new StarSystem {
                                    Position = new Vector(x, y),
                                    Name = "test name - " + x + "-" + y,
                                    Planets = new List<Planet>(new[] {
                                        new Planet {
                                            Name = "test",
                                            Biome = Planet.PlanetBiome.Humid,
                                            Buildings = new List<BuildingInstance>(),
                                            Pupulation = 15400,
                                            Radius = 50,
                                            Owner = emp
                                        },
                                        new Planet {
                                            Name = "test",
                                            Biome = Planet.PlanetBiome.Humid,
                                            Buildings = new List<BuildingInstance>(),
                                            Pupulation = 15400,
                                            Radius = 50,
                                            Owner = emp
                                        },
                                        new Planet {
                                            Name = "test",
                                            Biome = Planet.PlanetBiome.Humid,
                                            Buildings = new List<BuildingInstance>(),
                                            Pupulation = 15400,
                                            Radius = 50,
                                            Owner = emp
                                        },
                                        new Planet {
                                            Name = "test",
                                            Biome = Planet.PlanetBiome.Humid,
                                            Buildings = new List<BuildingInstance>(),
                                            Pupulation = 15400,
                                            Radius = 50,
                                            Owner = emp
                                        }
                                    })
                                });
                            }
                        }

                        var galaxy = new Galaxy {
                            Name = "Test galaxy",
                            Empires = new List<Empire>(new[] {
                                emp
                            }),
                            StarSystems = sys
                        };

                        var galaxyController = new GalaxyController(galaxy);

                        var game = new Game {
                            CurrentPlayer = emp,
                            CurrentTurn = 0,
                            Galaxy = galaxy
                        };

                        var controller = new OverlayViewController(game) {
                            ChildViewController = new GalaxyViewController(galaxyController)
                        };

                        EmpiriaGalactica.GameController.Game = game;
                        
                        EmpiriaGalactica.GameController.CurrentController = controller;
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