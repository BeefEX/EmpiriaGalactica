using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
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
            foreach (var view in _buttonViews) {
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