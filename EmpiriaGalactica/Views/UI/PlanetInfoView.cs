using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    public class PlanetInfoView : Panel<Planet> {
        
        #region Members
        
        #endregion
        
        #region Methods

        public PlanetInfoView(IController controller, Planet model) : base(controller, model) {
            
        }
        
        public override void Update() {
            var renderer = EmpiriaGalactica.Renderer;
            
            renderer.DrawRect(Top + new Vector(0, 1), Bottom, false, Color.Black, Color.White);
            
            renderer.PrintText("Name: " + Model.Name, Top + new Vector(2, 3), HorizontalAlign.Left, Color.White, Color.Black);
            
            renderer.PrintText("Planet govener: " + (Model.Owner == null? "Nobody": Model.Owner.Name), Top + new Vector(2, 5), HorizontalAlign.Left, Color.White, Color.Black);

            renderer.PrintText(new string(' ', Bottom.X - Top.X - 2), Top + new Vector(1, 7), HorizontalAlign.Left, Color.Black, Color.Grey);
            
            renderer.PrintText("Biome: " + Model.Biome, Top + new Vector(2, 9), HorizontalAlign.Left, Color.White, Color.Black);
            
            renderer.PrintText("Radius: " + Model.Radius, Top + new Vector(2, 11), HorizontalAlign.Left, Color.White, Color.Black);
            
            renderer.PrintText(new string(' ', Bottom.X - Top.X - 2), Top + new Vector(1, 13), HorizontalAlign.Left, Color.Black, Color.Grey);
            
            renderer.PrintText("Population: " + Model.Pupulation, Top + new Vector(2, 15), HorizontalAlign.Left, Color.White, Color.Black);
            
            renderer.PrintText("Number of buildings: " + Model.Buildings.Count, Top + new Vector(2, 17), HorizontalAlign.Left, Color.White, Color.Black);
        }

        public override void Dispose() {
            
        }

        #endregion
        
        #region Properties
        
        #endregion
    }
}