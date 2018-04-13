using EmpiriaGalactica_GUI.Views;
using ImGuiOpenTK;

namespace EmpiriaGalactica_GUI {
    
    public class Window : ImGuiOpenTKWindow {
        
        #region Methods
        
        public Window() : base("EmpiriaGalactica") {
            GalaxyView.InitTextures();
            StarSystemView.InitTextures();
        }

        public override void ImGuiLayout() {
            global::EmpiriaGalactica.EmpiriaGalactica.GameController.Update();
        }
        
        #endregion
    }
}