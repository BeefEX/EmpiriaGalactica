using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views {
    public class StarSystemView : global::EmpiriaGalactica.Views.StarSystemView {
        
        #region Members
        
        private static Dictionary<Planet.PlanetBiome, List<GlTexture>> _planetTextures;
        
        #endregion
        
        #region Methods
        
        
        public static void InitTextures() {
            _planetTextures = new Dictionary<Planet.PlanetBiome, List<GlTexture>>();

            foreach (Planet.PlanetBiome biome in Enum.GetValues(typeof(Planet.PlanetBiome))) {
                _planetTextures.Add(biome, new List<GlTexture>());
            }
            
            _planetTextures[Planet.PlanetBiome.Humid].Add(new GlTexture(new Bitmap("assets/planet3.png")));
            _planetTextures[Planet.PlanetBiome.Humid].Add(new GlTexture(new Bitmap("assets/planet6.png")));
            _planetTextures[Planet.PlanetBiome.Humid].Add(new GlTexture(new Bitmap("assets/planet7.png")));
            
            _planetTextures[Planet.PlanetBiome.Hot].Add(new GlTexture(new Bitmap("assets/planet1.png")));
            _planetTextures[Planet.PlanetBiome.Hot].Add(new GlTexture(new Bitmap("assets/planet2.png")));
            _planetTextures[Planet.PlanetBiome.Hot].Add(new GlTexture(new Bitmap("assets/planet4.png")));
        }
        
        public StarSystemView(IController controller, StarSystem model) : base(controller, model) { }
        
        public override void Update() {
            int perPlanet = EmpiriaGalactica.Window.Width / (Model.Planets.Count + 1);
            int height = EmpiriaGalactica.Window.Height / 2;
            
            for (var index = 0; index < Model.Planets.Count; index++) {
                var modelPlanet = Model.Planets[index];
                ImGui.SetNextWindowPos(new Vector2(perPlanet * (index + 0.5f), height), Condition.Always, Vector2.Zero);

                bool tmp = true;

                ImGui.BeginWindow($"planet{index}",
                    ref tmp,
                    0.0f,
                    WindowFlags.NoMove |
                    WindowFlags.NoResize |
                    WindowFlags.NoTitleBar |
                    WindowFlags.NoScrollWithMouse |
                    WindowFlags.NoBringToFrontOnFocus);
                ImGui.PushStyleVar(StyleVar.WindowPadding, Vector2.Zero);

                ImGui.Image(
                    new IntPtr(_planetTextures[modelPlanet.Biome][0].TextureId),
                    new Vector2(100),
                    Vector2.One,
                    Vector2.Zero,
                    Vector4.One,
                    Vector4.Zero);

                ImGui.EndWindow();
            }
        }

        public override void Dispose() {
        }
        
        #endregion
        
        #region Properties
        
        #endregion
        
        #region Operators
        
        #endregion
        

    }
}