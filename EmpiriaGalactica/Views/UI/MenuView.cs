using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI;

namespace EmpiriaGalactica.Views.UI {
    public class MenuView : View<Menu> {

        private readonly List<ButtonView> _buttonViews;
        
        public MenuView(IController controller, Menu model) : base(controller, model) {
            _buttonViews = new List<ButtonView>();

            foreach (var button in Model.Buttons) {
                _buttonViews.Add(new ButtonView(controller, button));
            }
        }

        public override void Update() {
            var screenSize = EmpiriaGalactica.Renderer.GetGridSize();
            var padding = screenSize.Y / Model.Buttons.Count / 2;
            
            for (var i = 0; i < _buttonViews.Count; i++) {
                var view = _buttonViews[i];
                view.Position = new Vector(screenSize.X / 2, (i + 1) * padding);
                view.Update();
            }
        }

        public override void Dispose() {
            foreach (var view in _buttonViews) {
                view.Dispose();
            }
        }
    }
}