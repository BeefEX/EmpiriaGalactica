using System.Numerics;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.Overlay.OverlayView))]
    public class OverlayView : global::EmpiriaGalactica.Views.UI.Overlay.OverlayView {
        
        #region Methods
        
        public OverlayView(IController controller, Game model) : base(controller, model) {
            
        }

        public override void Update() {
            ImGui.SetNextWindowSize(new Vector2(EmpiriaGalactica.Window.Width, 20), Condition.Always);
            ImGui.SetNextWindowPos(Vector2.Zero, Condition.Always, Vector2.Zero);
            
            ImGui.PushStyleVar(StyleVar.WindowRounding, 0f);
            
            ImGui.BeginWindow("overlay",
                WindowFlags.NoCollapse |
                WindowFlags.NoFocusOnAppearing |
                WindowFlags.NoMove |
                WindowFlags.NoScrollbar |
                WindowFlags.NoTitleBar |
                WindowFlags.NoResize);

            if (ImGui.Button("Menu##menu00000")) {
                
            }
            
            ImGui.EndWindow();
            
            ImGui.PopStyleVar();
        }

        public override void Dispose() {
            
        }

        #endregion
    }
}