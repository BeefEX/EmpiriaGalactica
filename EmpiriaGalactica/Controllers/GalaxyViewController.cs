using EmpiriaGalactica.Input;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;
using EmpiriaGalactica.Views;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers {
    public class GalaxyViewController : IController {
        
        #region Members

        private Galaxy _galaxy;
        
        private GalaxyView _galaxyView;
        private GalaxyInfoView _galaxyInfoView;
        private StarSystemInfoView _starSystemInfoView;
        
        #endregion
        
        #region Methods
        
        public GalaxyViewController(Galaxy galaxy) {
            _galaxy = galaxy;

            _galaxyView = new GalaxyView(this, _galaxy) {SelectedSystem = new Vector()};

            _galaxyInfoView = new GalaxyInfoView(this, _galaxy);
            
            _starSystemInfoView = new StarSystemInfoView(this, _galaxy.StarSystems[_galaxyView.SelectedSystem]);
            
            EmpiriaGalactica.Input.KeyDown += InputOnKeyDown;
        }


        public void Update() {
            EmpiriaGalactica.Renderer.Clear(Color.Black);
            var screenSize = EmpiriaGalactica.Renderer.GetGridSize();
            
            _galaxyView.Top = new Vector(0, 1);
            _galaxyView.Bottom = screenSize - new Vector(screenSize.X / 3, 0);
            
            _galaxyInfoView.Top = new Vector(screenSize.X - screenSize.X / 3, 0);
            _galaxyInfoView.Bottom = new Vector(screenSize.X, screenSize.Y / 4);
            
            _starSystemInfoView.Top = new Vector(screenSize.X - screenSize.X / 3, screenSize.Y / 4);
            _starSystemInfoView.Bottom = new Vector(screenSize.X, screenSize.Y);
            
            _galaxyView.ForcedUpdate = true;
            _galaxyView.Update();
            _galaxyInfoView.Update();
            _starSystemInfoView.Update();
        }
        
        public void Dispose() {
            _galaxyView.Dispose();
            _galaxyInfoView.Dispose();
            _starSystemInfoView.Dispose();

            EmpiriaGalactica.Input.KeyDown -= InputOnKeyDown;
        }
        
        private void InputOnKeyDown(object sender, KeyboardArgs e) {
            if (e.Key == "LeftArrow")
                _galaxyView.SelectedSystem.X--;
            else if (e.Key == "RightArrow")
                _galaxyView.SelectedSystem.X++;
            else if (e.Key == "UpArrow")
                _galaxyView.SelectedSystem.Y--;
            else if (e.Key == "DownArrow")
                _galaxyView.SelectedSystem.Y++;
            else if (e.Key == "Enter") {
                EmpiriaGalactica.GameController.CurrentController =
                    new StarSystemViewController(_galaxy.StarSystems[_galaxyView.SelectedSystem]);
                return;
            }

            _galaxyView.ForcedUpdate = false;
            _galaxyView.Update();

            _starSystemInfoView.Model = _galaxy.StarSystems[_galaxyView.SelectedSystem];
            
            _starSystemInfoView.Update();
        }
        
        #endregion
        
        #region Properties
        
        #endregion
    }
}