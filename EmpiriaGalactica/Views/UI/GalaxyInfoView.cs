using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    public class GalaxyInfoView : Panel<Galaxy> {
        
        #region Methods
        
        public GalaxyInfoView(IController controller, Galaxy model) : base(controller, model) { }
        
        public override void Update() {
            var renderer = EmpiriaGalactica.Renderer;
            
            renderer.DrawRect(Top + new Vector(0, 1), Bottom, false, Color.Black, Color.White);
            
            renderer.PrintText("Name: " + Model.Name, Top + new Vector(2, 3), HorizontalAlign.Left, Color.White, Color.Black);

            renderer.PrintText("Empires:", Top + new Vector(2, 5), HorizontalAlign.Left, Color.White, Color.Black);
            
            for (var i = 0; i < Model.Empires.Count; i++) {
                var empire = Model.Empires[i];
                renderer.PrintText("Empire name: " + empire.Name, Top + new Vector(4, 7 + i * 2), HorizontalAlign.Left, Color.White, Color.Black);
            }
        }

        public override void Dispose() { }
        
        #endregion
    }
}