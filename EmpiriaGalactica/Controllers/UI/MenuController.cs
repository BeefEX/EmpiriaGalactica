using System;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Models.UI;

namespace EmpiriaGalactica.Controllers.UI {
    public class MenuController : IController {
        
        #region Members

        //private readonly MenuView _view;
        private int _selected;
        
        #endregion
        
        #region Methods

        public MenuController(Menu menu) {
            //_view = new MenuView(this, menu);
        }

        public void Init() {
            _selected = 0;
            //_view.Model.Buttons[_selected].Selected = true;
            
            //EmpiriaGalactica.Input.KeyDown += OnInputOnKeyDown;
        }

        public void Update() {
            //EmpiriaGalactica.Renderer.Clear(Color.Black);
            //_view.Update();
        }
        
        public void Dispose() {
            //EmpiriaGalactica.Input.KeyDown -= OnInputOnKeyDown;
        }

        /*
        private void OnInputOnKeyDown(object sender, KeyboardArgs args) {
            /*
            _view.Model.Buttons[_selected].Selected = false;

            if (args.Key == "DownArrow")
                _selected++;
            else if (args.Key == "UpArrow")
                _selected--;
            else if (args.Key == "Enter")
                _view.Model.Buttons[_selected].OnClick?.Invoke();
            else if (args.Key == "Escape")
                EmpiriaGalactica.GameController.PopBack();

            if (_selected < 0)
                _selected += _view.Model.Buttons.Count;
            
            _selected %= _view.Model.Buttons.Count;

            _view.Model.Buttons[_selected].Selected = true;
            
            EmpiriaGalactica.GameController.Update();
         
        }
        */
        
        public void OnCommand(Command command) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Properties

        public bool HasParent => false;
        public IController Parent => null;

        #endregion

    }
}