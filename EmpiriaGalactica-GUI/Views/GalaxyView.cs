using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Numerics;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views {
    
    [Implements(typeof(global::EmpiriaGalactica.Views.GalaxyView))]
    public class GalaxyView : global::EmpiriaGalactica.Views.GalaxyView {
        
        #region Members

        private static GlTexture _texture;
        
        #endregion
        
        #region Methods

        public static void InitTextures() {
            _texture = new GlTexture(new Bitmap("assets/starSystem.png"));
        }
        
        public GalaxyView(IController controller, Galaxy model) : base(controller, model) { }
        
        public override void Update() {

            var i = 0;
            
            foreach (var starSystem in Model.StarSystems) {
                
                ImGui.SetNextWindowPos(new Vector2(starSystem.Position.X * 30, starSystem.Position.Y * 30), Condition.Always, Vector2.Zero);

                bool tmp = true;

                ImGui.BeginWindow($"system{i}",
                    ref tmp,
                    0.0f,
                    WindowFlags.NoMove |
                    WindowFlags.NoResize |
                    WindowFlags.NoTitleBar |
                    WindowFlags.NoScrollWithMouse |
                    WindowFlags.NoBringToFrontOnFocus);
                ImGui.PushStyleVar(StyleVar.WindowPadding, Vector2.Zero);

                var clicked = ImGui.ImageButton(
                    new IntPtr(_texture.TextureId),
                    new Vector2(20),
                    Vector2.One,
                    Vector2.Zero,
                    0,
                    Vector4.Zero,
                    Vector4.One);
                ImGui.PushStyleColor(ColorTarget.Button, Vector4.Zero);
                ImGui.PushStyleColor(ColorTarget.ButtonHovered, Vector4.Zero);

                if (clicked)
                    Console.WriteLine(starSystem.Position);
                
                ImGui.EndWindow();
                i++;
            }
        }

        public override void Dispose() {
            
        }
        
        #endregion
        
        #region Properties
        
        #endregion
        
        #region Operators
        
        #endregion
        
    }
}