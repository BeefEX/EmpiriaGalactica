using System.Collections.Generic;
using EmpiriaGalactica.Controllers.UI;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using EmpiriaGalactica.Models.UI.Menus;

namespace EmpiriaGalactica.Controllers {
    public class GameController : IController {

        private IController _currentController;

        private List<IController> _queue;
        
        public GameController() {
            Init();
        }

        public void Init() {
            _queue = new List<IController>();
            CurrentController = new MenuController(new MainMenu());
        }

        public void Update() {
            _currentController.Update();
        }
        
        public void Dispose() {
            _currentController.Dispose();
        }

        public IController CurrentController {
            get => _currentController;
            set {
                _currentController?.Dispose();
                _queue.Add(_currentController);
                _currentController = value;
                _currentController.Init();
                Update();
            }
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
    }
}