using System;
using System.Collections.Generic;
using EmpiriaGalactica.Commands;
using EmpiriaGalactica.Controllers.ViewControllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI.Menus;

namespace EmpiriaGalactica.Controllers {
    
    public class GameController : IController {

        #region Members
        
        /// <summary>
        /// The currently active view controller.
        /// </summary>
        private IViewController _currentController;

        /// <summary>
        /// Queue of inactive controllers to allow <see cref="PopBack"/> method. 
        /// </summary>
        private List<IViewController> _queue;

        /// <summary>
        /// The game this controller is controlling.
        /// </summary>
        private Game _game;
        
        #endregion
        
        #region Methods
        
        public GameController() {
            Init();
        }

        public void Init() {
            _queue = new List<IViewController>();
            
            CurrentController = new MenuViewController(new MainMenu());
        }

        public void Update() {
            _currentController.Update();
        }


        public void Dispose() {
            _currentController.Dispose();
        }
        
        public void PopBack() {
            
            // Exit if nothing to pop back.
            if (_queue.Count == 1)
                return;
            
            // Get the last controller in the stack
            var controller = _queue[_queue.Count - 1];
            
            // Remove it from the stack
            _queue.RemoveAt(_queue.Count - 1);
            
            // Prepare to replace the current view
            _currentController.Dispose();
            
            // Replace the current view
            _currentController = controller;
            
            // Initialize the new controller
            _currentController.Init();
            
            // Update the new view
            Update();
        }
        
        /// <inheritdoc />
        public void OnCommand(Command command) { }
        
        #endregion

        #region Properties
        
        /// <summary>
        /// Used to push a new controller onto the stack.
        /// </summary>
        public IViewController CurrentController {
            get => _currentController;
            set {
                if (_currentController?.GetType() == typeof(OverlayViewController)) {
                    ((OverlayViewController) _currentController).ChildViewController = value;
                    return;
                }

                _currentController?.Dispose();
                _queue.Add(_currentController);
                _currentController = value;
                _currentController.Init();
            }
        }

        /// <summary>
        /// The game this controller is controlling.
        /// </summary>
        public Game Game {
            get => _game;
            set => _game = value;
        }

        /// <inheritdoc />
        public bool HasParent => false;

        /// <inheritdoc />
        public IController Parent => null;

        #endregion
    }
}
