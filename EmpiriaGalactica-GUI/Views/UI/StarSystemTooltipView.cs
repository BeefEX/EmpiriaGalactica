using System.Numerics;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views.UI {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.UI.StarSystemTooltipView))]
    public class StarSystemTooltipView : global::EmpiriaGalactica.Views.UI.StarSystemTooltipView {
        
        #region Methods

        /// <inheritdoc />
        public StarSystemTooltipView(IController controller, StarSystem model) : base(controller, model) { }

        /// <inheritdoc />
        public override void Update() {
            var mousePos = ImGui.GetIO().MousePosition;

            ImGui.SetNextWindowPos(mousePos + new Vector2(10, 0), Condition.Always, Vector2.Zero);
            
            ImGui.PushStyleVar(StyleVar.WindowPadding, new Vector2(20, 10));

            bool tmp = true;
            
            ImGui.BeginWindow(
                "StarSystemInfo",
                ref tmp,
                1.0f,
                WindowFlags.NoCollapse |
                WindowFlags.NoMove |
                WindowFlags.NoTitleBar |
                WindowFlags.NoInputs |
                WindowFlags.NoSavedSettings |
                WindowFlags.AlwaysAutoResize);
            
            ImGui.PushStyleColor(ColorTarget.Text, new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
            ImGui.Text("Name:");
            ImGui.SameLine();
            ImGui.PushStyleColor(ColorTarget.Text, Vector4.One);
            ImGui.Text($"{Model.Name}");
            
            ImGui.PushStyleColor(ColorTarget.Text, new Vector4(0.5f, 0.5f, 0.5f, 1.0f));
            ImGui.Text("Number of planets: ");
            ImGui.SameLine();
            ImGui.PushStyleColor(ColorTarget.Text, Vector4.One);
            ImGui.Text($"{Model.Planets.Count.ToString()}");
            
            ImGui.EndWindow();
        }

        /// <inheritdoc />
        public override void Dispose() { }

        #endregion
    }
}