using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Numerics;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.ViewControllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using ImGuiNET;

namespace EmpiriaGalactica_GUI.Views {
    
    /// <summary>
    /// Renders an glaxy using ImGui and OpenGL.
    /// </summary>
    /// <inheritdoc />
    [Implements(typeof(global::EmpiriaGalactica.Views.GalaxyView))]
    public class GalaxyView : global::EmpiriaGalactica.Views.GalaxyView {
        
        #region Members

        /// <summary>
        /// The texture to use for the star systems.
        /// </summary>
        private static GlTexture _texture;
        
        #endregion
        
        #region Methods

        /// <summary>
        /// Used to load the textures required for this view.
        /// </summary>
        public static void InitTextures() {
            _texture = new GlTexture(new Bitmap("assets/starSystem.png"));
        }
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="controller">Controller this view has to report to.</param>
        /// <param name="model">The model this view is rendering.</param>
        public GalaxyView(IController controller, Galaxy model) : base(controller, model) { }
        
        /// <inheritdoc />
        public override void Update() {
            var i = 0;

            StarSystem hovered = null;
            
            foreach (var starSystem in Model.StarSystems) {
                
                ImGui.SetNextWindowPos(new Vector2(starSystem.Position.X * 30, starSystem.Position.Y * 30), Condition.Always, Vector2.Zero);

                bool tmp = true;
                
                ImGui.PushStyleVar(StyleVar.WindowPadding, Vector2.Zero);

                ImGui.BeginWindow($"system{i}",
                    ref tmp,
                    0.0f,
                    WindowFlags.NoMove |
                    WindowFlags.NoResize |
                    WindowFlags.NoTitleBar |
                    WindowFlags.NoScrollWithMouse |
                    WindowFlags.NoBringToFrontOnFocus);

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
                ImGui.PushStyleColor(ColorTarget.ButtonActive, Vector4.Zero);

                if (ImGui.IsItemHovered(HoveredFlags.Default))
                    hovered = starSystem;

                if (clicked)
                    Controller.OnCommand(new Command("Click", starSystem));
                
                ImGui.EndWindow();
                i++;
            }

            if (hovered != null)
                Controller.OnCommand(new Command("HoverStart", hovered));
            else
                Controller.OnCommand(new Command("HoverEnd"));
        }

        /// <inheritdoc />
        public override void Dispose() { }
        
        #endregion
        
    }
}