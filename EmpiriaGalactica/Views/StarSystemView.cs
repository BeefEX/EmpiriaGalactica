using System;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views {
    public class StarSystemView : Panel<StarSystem> {
        
        #region Members

        private static readonly int[] StarLines = {
            1,
            3,
            4,
            5,
            5,
            6,
            6,
            6,
            5,
            5,
            4,
            3,
            1
        };

        private static readonly int[] PlanetLines = {
            3,
            5,
            3
        };
        
        private int _cachedSelectedPlanet = -1;
        
        #endregion
        
        #region Methods

        public StarSystemView(IController controller, StarSystem model) : base(controller, model) {
        }
        
        public override void Update() {
            if (_cachedSelectedPlanet == -1 || ForcedUpdate) {
                InitalDraw();
            } else {
                UpdateDraw();
            }

            ForcedUpdate = false;
            _cachedSelectedPlanet = SelectedPlanet;
        }

        private void UpdateDraw() {
            var size = Bottom - Top;
            var renderer = EmpiriaGalactica.Renderer;
            
            var cachedPosition =
                new Vector(10 + (size.X - 20) / Model.Planets.Count * _cachedSelectedPlanet, size.Y / 2);
            
            if (_cachedSelectedPlanet != -1)
                renderer.DrawRect(Top + cachedPosition - new Vector(4, 3), Top + cachedPosition + new Vector(5, 4),
                    false, Color.White, Color.Black);
            
            var newPosition = new Vector(10 + (size.X - 20) / Model.Planets.Count * SelectedPlanet, size.Y / 2);
            
            renderer.DrawRect(Top + newPosition - new Vector(4, 3), Top + newPosition + new Vector(5, 4), false,
                Color.White, Color.White);
        }
        
        private void InitalDraw() {
            var size = Bottom - Top;
            var renderer = EmpiriaGalactica.Renderer;
            
            
            var starCenter = new Vector(size.X, size.Y / 2);

            // Draw the star
            for (int y = 0; y < StarLines.Length; y++) {
                renderer.PrintText(new string(' ', StarLines[y]),
                    Top + starCenter + new Vector(0, y - StarLines.Length / 2),
                    HorizontalAlign.Right, Color.White,
                    Color.Yellow);
            }
            
            // Draw planets
            var perPlanet = (size.X - 20) / Model.Planets.Count;

            for (int i = 0; i < Model.Planets.Count; i++) {
                var position = new Vector(10 + perPlanet * i, size.Y / 2);
                
                for (int y = 0; y < PlanetLines.Length; y++) {
                    renderer.PrintText(new string(' ', PlanetLines[y]),
                        Top + position + new Vector(0, y - PlanetLines.Length / 2),
                        HorizontalAlign.Center, Color.White,
                        Color.Blue);
                }
                
                if (SelectedPlanet != i)
                    continue;
                
                renderer.DrawRect(Top + position - new Vector(4, 3), Top + position + new Vector(5, 4), false,
                    Color.White, Color.White);
            }
        }

        public override void Dispose() {
            
        }

        #endregion
        
        #region Properties
        
        public int SelectedPlanet { get; set; }
        
        public bool ForcedUpdate { get; set; }
        
        #endregion
    }
}