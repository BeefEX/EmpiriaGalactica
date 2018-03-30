using EmpiriaGalactica.Models;
using EmpiriaGalactica.Rendering;
using EmpiriaGalactica.Views;
using EmpiriaGalactica.Views.UI;

namespace EmpiriaGalactica.Controllers {
    public class StarSystemViewController : IController {
        
        #region Members

        private StarSystem _starSystem;
        
        private StarSystemView _starSystemView;
        private StarSystemInfoView _starSystemInfoView;
        
        #endregion
        
        #region Methods

        public StarSystemViewController(StarSystem starSystem) {
            _starSystem = starSystem;
            
            _starSystemView = new StarSystemView(this, starSystem);
            _starSystemInfoView = new StarSystemInfoView(this, starSystem);
        }

        public void Update() {
            EmpiriaGalactica.Renderer.Clear(Color.Black);
            var screenSize = EmpiriaGalactica.Renderer.GetGridSize();
            
            _starSystemView.Top = new Vector(0, 1);
            _starSystemView.Bottom = screenSize - new Vector(screenSize.X / 3, 0);
            
            _starSystemInfoView.Top = new Vector(screenSize.X - screenSize.X / 3, 0);
            _starSystemInfoView.Bottom = new Vector(screenSize.X, screenSize.Y / 4);
            
            //_starSystemInfoView.Top = new Vector(screenSize.X - screenSize.X / 3, screenSize.Y / 4);
            //_starSystemInfoView.Bottom = new Vector(screenSize.X, screenSize.Y);
            
            _starSystemView.Update();
            //_galaxyInfoView.Update();
            _starSystemInfoView.Update();
        }
        
        public void Dispose() {
            
        }

        #endregion
        
        #region Properties
        
        #endregion
    }
}