﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.ViewControllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.StarSystemView))]
    public class StarSystemView : global::EmpiriaGalactica.Views.StarSystemView {
        
        #region Members
        
        private static Dictionary<Planet.PlanetBiome, List<GlTexture>> _planetTextures;
        private static GlTexture _personIcon;
        private static GlTexture _energyIcon;
        
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
            
            _personIcon = new GlTexture(new Bitmap("assets/icons/person.png"));
            _energyIcon = new GlTexture(new Bitmap("assets/icons/energy.png"));
        }
        
        public StarSystemView(IController controller, StarSystem model) : base(controller, model) { }
        
        public override void Update() {
            ImGui.PushStyleColor(ColorTarget.Button, Vector4.Zero);
            ImGui.PushStyleColor(ColorTarget.ButtonHovered, Vector4.Zero);
            ImGui.PushStyleColor(ColorTarget.ButtonActive, Vector4.Zero);
            
            int perPlanet = EmpiriaGalactica.Window.Width / (Model.Planets.Count + 1);
            int height = EmpiriaGalactica.Window.Height / 2 - 25;
            
            for (var index = 0; index < Model.Planets.Count; index++) {
                var planet = Model.Planets[index];
                ImGui.SetNextWindowPos(new Vector2(perPlanet * (index + 0.5f), height), Condition.Always, Vector2.Zero);

                bool tmp = true;

                ImGui.PushStyleVar(StyleVar.WindowPadding, Vector2.Zero);
                ImGui.BeginWindow($"planet{index}",
                    ref tmp,
                    0.0f,
                    WindowFlags.NoMove |
                    WindowFlags.NoResize |
                    WindowFlags.NoTitleBar |
                    WindowFlags.NoScrollWithMouse |
                    WindowFlags.NoBringToFrontOnFocus);

                var pressed = ImGui.ImageButton(
                    new IntPtr(_planetTextures[planet.Biome][0].TextureId),
                    new Vector2(100),
                    Vector2.One,
                    Vector2.Zero,
                    0,
                    Vector4.Zero,
                    Vector4.One);
                
                if (pressed)
                    Controller.OnCommand(new Command("Click", planet)); 

                ImGui.EndWindow();
                
                ImGui.SetNextWindowPos(new Vector2(perPlanet * (index + 0.5f), height - 100), Condition.Always, Vector2.Zero);

                ImGui.PushStyleVar(StyleVar.WindowPadding, new Vector2(10, 10));
                ImGui.BeginWindow($"planet{index}-tooltip",
                    ref tmp,
                    1.0f,
                    WindowFlags.NoMove |
                    WindowFlags.NoResize |
                    WindowFlags.NoTitleBar |
                    WindowFlags.NoScrollWithMouse |
                    WindowFlags.NoBringToFrontOnFocus |
                    WindowFlags.AlwaysAutoResize);

                ImGui.Text(planet.Name);
                
                ImGui.SameLine();
                ImGui.Dummy(10, 0);
                
                ImGui.SameLine();
                ImGui.Text($"{planet.Pupulation}x");
                ImGui.SameLine();
                ImGui.Image(
                    new IntPtr(_energyIcon.TextureId),
                    new Vector2(15),
                    Vector2.Zero,
                    Vector2.One,
                    Vector4.One,
                    Vector4.Zero);

                ImGui.EndWindow();
            }
            
            ImGui.PopStyleColor(3);
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