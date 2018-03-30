using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    public class ButtonView : View<Button> {

        #region Methods

        public ButtonView(IController controller, Button model) : base(controller, model) {
            
        }

        public override void Update() {
            EmpiriaGalactica.Renderer.DrawRect(Position - new Vector(Model.Title.Length / 2 + 2, 0),
                Position + new Vector(Model.Title.Length / 2 + 2, 3), Model.Selected, Color.Black, Color.White);
            
            EmpiriaGalactica.Renderer.PrintText(Model.Title, Position + new Vector(0, 1), HorizontalAlign.Center,
                Model.Selected ? Color.Black : Color.White, Model.Selected ? Color.White : Color.Black);
        }

        public override void Dispose() {
            
        }
        
        #endregion
        
        #region Properties

        public Vector Position { get; set; }

        #endregion
    }
}