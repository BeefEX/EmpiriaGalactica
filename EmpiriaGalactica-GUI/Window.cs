using System;
using System.Collections.Generic;
using System.IO;
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

        private readonly GlTexture _texture;

        private readonly StarSystemView _view;
        
        public Window() : base("EmpiriaGalactica") {
            StarSystemView.InitTextures();
        
            /*
            var stream = new FileStream("test.png", FileMode.Open);
            stream.Seek(0, SeekOrigin.Begin);
            _texture = new GlTexture(new Bitmap(stream));
            */
            
            _view = new StarSystemView(null, new StarSystem {
                Name = "test",
                Position = new Vector(10, 10),
                Planets = new List<Planet> {
                    new Planet {
                        Biome = Planet.PlanetBiome.Humid
                    },
                    new Planet {
                        Biome = Planet.PlanetBiome.Hot
                    },
                    new Planet {
                        Biome = Planet.PlanetBiome.Humid
                    }
                }
            });
        }

        public override void ImGuiLayout() {
            
            _view.Update();
            
            ImGui.BeginWindow("test");
            ImGui.Text("this is a text");
            ImGui.EndWindow();
        }
    }
}