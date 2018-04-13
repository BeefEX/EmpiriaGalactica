using System.Numerics;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.Overlay.OverlayView))]
    public class OverlayView : global::EmpiriaGalactica.Views.UI.Overlay.OverlayView {
        
        #region Methods
        
        public OverlayView(IController controller, Game model) : base(controller, model) { }

        public override void Update() {
            
            // Top bad
            ImGui.SetNextWindowSize(new Vector2(EmpiriaGalactica.Window.Width, 20), Condition.Always);
            ImGui.SetNextWindowPos(Vector2.Zero, Condition.Always, Vector2.Zero);
            
            ImGui.PushStyleVar(StyleVar.WindowRounding, 0f);
            
            ImGui.PushStyleVar(StyleVar.WindowPadding, new Vector2(4));
            
            ImGui.PushStyleColor(ColorTarget.WindowBg, new Vector4(0, 0, 0, 1));
            
            ImGui.BeginWindow("overlay",
                WindowFlags.NoCollapse |
                WindowFlags.NoFocusOnAppearing |
                WindowFlags.NoMove |
                WindowFlags.NoScrollbar |
                WindowFlags.NoTitleBar |
                WindowFlags.NoResize);
            
            ImGui.Columns(3, "topbar", false);
            
            if (ImGui.Button("Back##menu00000"))
                Controller.OnCommand(new Command("clickBack"));
            
            ImGui.NextColumn();
            
            ImGui.PushStyleColor(ColorTarget.Button, Vector4.Zero);
            ImGui.PushStyleColor(ColorTarget.ButtonHovered, Vector4.Zero);
            ImGui.PushStyleColor(ColorTarget.ButtonActive, Vector4.Zero);
            
            ImGui.Button($"Current player: {Model.CurrentPlayer.Name}", ImGui.GetContentRegionAvailable());
            ImGui.NextColumn();
            
            ImGui.SameLine(ImGui.GetContentRegionAvailableWidth() - 120);
            ImGui.Button($"Current turn: {Model.CurrentTurn}", new Vector2(120, ImGui.GetContentRegionAvailable().Y));
            
            ImGui.PopStyleColor(3);
            
            ImGui.EndWindow();

            
            // Resources window
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
            
            
            // End turn window
            ImGui.PushStyleVar(StyleVar.WindowPadding, Vector2.Zero);
            
            ImGui.SetNextWindowPos(
                new Vector2(
                    EmpiriaGalactica.Window.Width - 100,
                    EmpiriaGalactica.Window.Height - 100),
                Condition.Always,
                Vector2.Zero);
            
            ImGui.SetNextWindowSize(new Vector2(100, 100), Condition.Always);

            ImGui.BeginWindow("nextturn",
                WindowFlags.NoCollapse |
                WindowFlags.NoFocusOnAppearing |
                WindowFlags.NoMove |
                WindowFlags.NoScrollbar |
                WindowFlags.NoResize |
                WindowFlags.NoTitleBar);

            if (ImGui.Button("Next turn", new Vector2(100, 100)))
                Controller.OnCommand(new Command("nextTurn"));
            
            ImGui.EndWindow();
            
            // Styling reset
            ImGui.PopStyleVar(3);
            ImGui.PopStyleColor();
            ImGui.PushStyleVar(StyleVar.WindowRounding, 7f);
        }

        public override void Dispose() { }

        #endregion
    }
}