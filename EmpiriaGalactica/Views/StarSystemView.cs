using System;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views {
    public class StarSystemView : Panel<StarSystem> {
        
        #region Members

        private static int[] _starLines = new[] {
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

        private bool _initalDrawDone;
        
        #endregion
        
        #region Methods

        public StarSystemView(IController controller, StarSystem model) : base(controller, model) {
            _initalDrawDone = false;
        }
        
        public override void Update() {
            if (!_initalDrawDone) {
                InitalDraw();
                _initalDrawDone = true;
            } else {
                UpdateDraw();
            }
        }

        private void UpdateDraw() {
            
        }
        
        private void InitalDraw() {
            var size = Bottom - Top;
            var renderer = EmpiriaGalactica.Renderer;
            
            
            var starCenter = new Vector(size.X, size.Y / 2);

            // Draw the star
            for (int y = 0; y < _starLines.Length; y++) {
                renderer.PrintText(new string(' ', _starLines[y]),
                    Top + starCenter + new Vector(0, y - _starLines.Length / 2),
                    HorizontalAlign.Right, Color.White,
                    Color.Yellow);
            }
            
            // Draw planets
            
        }

        public override void Dispose() {
            
        }

        #endregion
        
        #region Properties
        
        #endregion
    }
}