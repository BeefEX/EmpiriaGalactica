using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    public class StarSystemInfoView : Panel<StarSystem> {
        
        public StarSystemInfoView(IController controller, StarSystem model) : base(controller, model) { }
        
        public override void Update() {
            var renderer = EmpiriaGalactica.Renderer;
            
            renderer.DrawRect(Top + new Vector(0, 1), Bottom, false, Color.Black, Color.White);
            
            renderer.PrintText("Name: " + Model.Name, Top + new Vector(2, 3), HorizontalAlign.Left, Color.White, Color.Black);

            renderer.PrintText("Number of planets: " + Model.Planets.Count, Top + new Vector(2, 5), HorizontalAlign.Left, Color.White, Color.Black);
        }

        public override void Dispose() { }
    }
}