using System.Numerics;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using ImGuiNET;
using OpenTK.Graphics.OpenGL;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.Overlay.OverlayView))]
    public class OverlayView : global::EmpiriaGalactica.Views.UI.Overlay.OverlayView {
        
        #region Methods
        
        public OverlayView(IController controller, Game model) : base(controller, model) {
            
        }

        public override unsafe void Update() {
            ImGui.SetNextWindowSize(new Vector2(EmpiriaGalactica.Window.Width, 20), Condition.Always);
            ImGui.SetNextWindowPos(Vector2.Zero, Condition.Always, Vector2.Zero);
            
            ImGui.PushStyleVar(StyleVar.WindowRounding, 0f);
            
            ImGui.PushStyleVar(StyleVar.WindowPadding, new Vector2(4));
            
            ImGui.BeginWindow("overlay",
                WindowFlags.NoCollapse |
                WindowFlags.NoFocusOnAppearing |
                WindowFlags.NoMove |
                WindowFlags.NoScrollbar |
                WindowFlags.NoTitleBar |
                WindowFlags.NoResize);
            
            if (ImGui.Button("Back##menu00000")) {
                global::EmpiriaGalactica.EmpiriaGalactica.GameController.PopBack();
            }
            
            ImGui.EndWindow();

            ImGui.SetNextWindowPos(new Vector2(0, EmpiriaGalactica.Window.Height - 200), Condition.Always, Vector2.Zero);
            
            ImGui.SetNextWindowSize(new Vector2(100, 200), Condition.Always);

            ImGui.BeginWindow("Resources:",
                WindowFlags.NoCollapse |
                WindowFlags.NoFocusOnAppearing |
                WindowFlags.NoMove |
                WindowFlags.NoScrollbar |
                WindowFlags.NoResize);
            
            foreach (var resource in Model.CurrentPlayer.Resources.Resources) {
                ImGui.PushStyleColor(ColorTarget.Text, new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
                
                ImGui.Text($"{resource.SourceResource.Name}: ");
                
                ImGui.PopStyleColor();
                    
                ImGui.SameLine();
                
                ImGui.Text(resource.Amount.ToString());
                
            }
            
            ImGui.EndWindow();
            
            ImGui.PopStyleVar(2);
            
            ImGui.PushStyleVar(StyleVar.WindowRounding, 7f);
        }

        public override void Dispose() {
            
        }

        #endregion
    }
}