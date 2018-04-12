using System;
using System.Collections.Generic;
using System.IO;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica_GUI.GlUtils;
using EmpiriaGalactica_GUI.Views;
using ImGuiNET;
using ImGuiOpenTK;
using OpenTK;
using OpenTK.Input;
using Bitmap = System.Drawing.Bitmap;
using Vector2 = System.Numerics.Vector2;
using Vector4 = System.Numerics.Vector4;

namespace EmpiriaGalactica_GUI {
    
    public class Window : ImGuiOpenTKWindow {
        
        #region Members
        
        private KeyboardState _keyboardState, _lastKeyboardState;

        #endregion
        
        #region Methods
        
        public Window() : base("EmpiriaGalactica") {
            GalaxyView.InitTextures();
            StarSystemView.InitTextures();
        }

        public override void ImGuiLayout() {
            global::EmpiriaGalactica.EmpiriaGalactica.GameController.Update();
        }


        protected override void OnUpdateFrame(FrameEventArgs e) {
            _keyboardState = OpenTK.Input.Keyboard.GetState();
            
            _lastKeyboardState = _keyboardState;
        }

        public new bool KeyPress(Key key) {
            return _keyboardState [key] && _keyboardState [key] != _lastKeyboardState [key];
        }
        
        #endregion
    }
}