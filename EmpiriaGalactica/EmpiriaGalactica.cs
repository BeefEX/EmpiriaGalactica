using System;
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
            
            Resources = new InstanceManager<Resource>();
            
            Resources.RegisterItems(
                new Resource {
                    Name = "Ore",
                    BaseCost = 10,
                    InternalName = "resource/ore"
                },
                new Resource {
                    Name = "Metal",
                    BaseCost = 10,
                    InternalName = "resource/metal"
                },
                new Resource {
                    Name = "Oil",
                    BaseCost = 10,
                    InternalName = "resource/oil"
                },
                new Resource {
                    Name = "Fuel",
                    BaseCost = 10,
                    InternalName = "resource/fuel"
                });
            
            
            Buildings = new InstanceManager<Building>();
            
            Buildings.RegisterItems(
                
                // Sources
                new Building {
                    Name = "Mine",
                    InternalName = "building/mine",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 100
                        }
                    },
                    Update = (planet, instance) => planet.Owner.Resources["resource/ore"] += 25 * instance.Level
                },
                new Building {
                    Name = "Oil field",
                    InternalName = "building/oilfield",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 350
                        }
                    },
                    Update = (planet, instance) => planet.Owner.Resources["resource/oil"] += 15 * instance.Level
                },
                
                // Processing
                new Building {
                    Name = "Smelter",
                    InternalName = "building/smelter",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 125
                        }
                    },
                    Update = (planet, instance) => {
                        var resources = planet.Owner.Resources;

                        var needed = 25 * instance.Level;
                        
                        var ore = resources["resource/ore"].Amount > needed? needed:  resources["resource/ore"].Amount;

                        resources["resource/ore"] -= ore;
                        resources["resource/metal"] += (int) Math.Floor(ore / 2f);
                    }
                },
                new Building {
                    Name = "Oil rafinery",
                    InternalName = "building/refinery",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 550
                        }
                    },
                    Update = (planet, instance) => {
                        var resources = planet.Owner.Resources;

                        var needed = 10 * instance.Level;
                        
                        var oil = resources["resource/oil"].Amount > needed? needed:  resources["resource/oil"].Amount;

                        resources["resource/oil"] -= oil;
                        resources["resource/fuel"] += (int) Math.Floor(oil / 4f);
                    }
                },
                
                // Factories
                new Building {
                    Name = "Fighter factory",
                    InternalName = "building/fighterfactory",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 425
                        }
                    },
                    Update = (planet, instance) => {
                        var resources = planet.Owner.Resources;

                        var metal = resources["resource/metal"].Amount / (50 / instance.Level);
                        var fuel = resources["resource/fuel"].Amount / (15 / instance.Level);

                        if (metal < 1 || fuel < 1)
                            return;

                        resources["resource/metal"] -= 50 / instance.Level;
                        resources["resource/fuel"] -= 15 / instance.Level;
                        
                        Console.WriteLine("fighter built ...");
                    }
                }
                
                /*, // Unused for now
                new Building {
                    Name = "Solar power plant",
                    InternalName = "building/solarpowerplant",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 100
                        }
                    },
                    Update = (planet, instance) => { }
                },
                new Building {
                    Name = "Nuclear power plant",
                    InternalName = "building/nuclearpowerplant",
                    BaseCost = new List<ResourceInstance> {
                        new ResourceInstance {
                            SourceResource = Resources["resource/metal"],
                            Amount = 500
                        }
                    },
                    Update = (planet, instance) => { }
                }*/
            );
            
            
            GameController = new GameController();
        }
    }
}