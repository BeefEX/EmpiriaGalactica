using System;
using System.Collections.Generic;
using System.IO;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using EmpiriaGalactica_GUI.Views;
using ImGuiNET;
using ImGuiOpenTK;
using Bitmap = System.Drawing.Bitmap;
using Vector2 = System.Numerics.Vector2;
using Vector4 = System.Numerics.Vector4;

namespace EmpiriaGalactica_GUI {
    
    public class Window : ImGuiOpenTKWindow {

        private readonly GalaxyView _view;
        
        public Window() : base("EmpiriaGalactica") {
            GalaxyView.InitTextures();
            StarSystemView.InitTextures();
            
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

            var game = new Galaxy {
                Name = "Test galaxy",
                Empires = new List<Empire>(new[] {
                    emp
                }),
                StarSystems = sys
            };
            
            _view = new GalaxyView(null, game);
        }

        public override void ImGuiLayout() {
            _view.Update();
        }
    }
}