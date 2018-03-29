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
            EmpiriaGalactica.Renderer.DrawRect(new Vector(10, 10), new Vector(20, 14), false, Color.Black, Color.White);
        }

        public override void Dispose() {
            
        }
        
        #endregion
    }
}