using System;
using System.Collections.Generic;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica.Views.UI {
    public class PanelMenuView : Panel<Menu> {

        private readonly List<PanelButtonView> _buttonViews;
        private int LongestTitle;
        
        public PanelMenuView(IController controller, Menu model) : base(controller, model) {
            _buttonViews = new List<PanelButtonView>();

            foreach (var button in Model.Buttons) {
                _buttonViews.Add(new PanelButtonView(controller, button));
                LongestTitle = Math.Max(LongestTitle, button.Title.Length);
            }
        }

        public override void Update() {
            EmpiriaGalactica.Renderer.DrawRect(Top, Top + new Vector(LongestTitle, _buttonViews.Count + 2), false, Color.Black, Color.White);
            
            for (var i = 0; i < _buttonViews.Count; i++) {
                var view = _buttonViews[i];
                view.Position = Top + new Vector(1, 1 + i);
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