using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views {
    public class GalaxyView : Panel<Galaxy> {
        
        #region Members

        private Vector _cachedSelectedSystem;
        
        #endregion
        
        #region Methods

        public GalaxyView(IController controller, Galaxy model) : base(controller, model) {
            SelectedSystem = new Vector();
        }
        
        public override void Update() {
            SelectedSystem.X %= 16;
            SelectedSystem.Y %= 16;

            SelectedSystem.X = SelectedSystem.X < 0 ? SelectedSystem.X + 16 : SelectedSystem.X;
            SelectedSystem.Y = SelectedSystem.Y < 0 ? SelectedSystem.Y + 16 : SelectedSystem.Y;
            
            var renderer = EmpiriaGalactica.Renderer;
            
            if (_cachedSelectedSystem == null || ForcedUpdate)
                DrawInitial();
            else {
                renderer.PrintText("   ", Top + new Vector(_cachedSelectedSystem.X * 6, _cachedSelectedSystem.Y * 3), HorizontalAlign.Left, Color.White, Color.Black);
                renderer.PrintText(" * ", Top + new Vector(_cachedSelectedSystem.X * 6, _cachedSelectedSystem.Y * 3 + 1), HorizontalAlign.Left, Color.White, Color.Black);
                renderer.PrintText("   ", Top + new Vector(_cachedSelectedSystem.X * 6, _cachedSelectedSystem.Y * 3 + 2), HorizontalAlign.Left, Color.White, Color.Black);
                
                renderer.PrintText("/-\\", Top + new Vector(SelectedSystem.X * 6, SelectedSystem.Y * 3), HorizontalAlign.Left, Color.Green, Color.Black);
                renderer.PrintText("|*|", Top + new Vector(SelectedSystem.X * 6, SelectedSystem.Y * 3 + 1), HorizontalAlign.Left, Color.Green, Color.Black);
                renderer.PrintText("\\_/", Top + new Vector(SelectedSystem.X * 6, SelectedSystem.Y * 3 + 2), HorizontalAlign.Left, Color.Green, Color.Black);
            }

            _cachedSelectedSystem = new Vector(SelectedSystem.X, SelectedSystem.Y);
        }

        private void DrawInitial() {
            var renderer = EmpiriaGalactica.Renderer;
            
            for (int x = 0; x < 16; x++) {
                for (int y = 0; y < 16; y++) {
                    var color = Color.White;

                    if (x == SelectedSystem.X && y == SelectedSystem.Y)
                        color = Color.Green;
                    
                    renderer.PrintText(" * ", Top + new Vector(x * 6, y * 3 + 1), HorizontalAlign.Left, color, Color.Black);
                }
            }
        }

        public override void Dispose() { }
        
        #endregion
        
        #region Properties

        public Vector SelectedSystem { get; set; }
        
        public bool ForcedUpdate { get; set; }

        #endregion
    }
}