using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    class PanelButtonView : View<Button> {
        
        public PanelButtonView(IController controller, Button model) : base(controller, model) { }
        
        public override void Update() {
            EmpiriaGalactica.Renderer.PrintText(Model.Title, Position, HorizontalAlign.Center,
                Model.Selected ? Color.Black : Color.White, Model.Selected ? Color.Grey : Color.Black);
        }

        public override void Dispose() {
            
        }
        
        #region Properties
        
        public Vector Position { get; set; }
        
        #endregion
    }
}