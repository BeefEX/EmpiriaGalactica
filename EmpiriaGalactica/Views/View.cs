using System;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views {

    public interface IView {
        
        #region Methods
        
        /// <summary>
        /// Used to update the view.
        /// </summary>
        void Update();

        /// <summary>
        /// Used to dispose the view.
        /// </summary>
        void Dispose();
        
        #endregion

        #region Properties

        /// <summary>
        /// The controller this View will report to.
        /// </summary>
        IController Controller { get; set; }
        
        #endregion
    }
    
    /// <summary>
    /// Contains all logic related to rendering a single object.
    /// </summary>
    public abstract class View<TModel> : IView where TModel : IModel {

        #region Members
        
        /// <summary>
        /// The controller this View will report to.
        /// </summary>
        private IController _controller;

        /// <summary>
        /// The model this view will take data from.
        /// </summary>
        private TModel _model;
        
        #endregion
        
        #region Methods
        
        /// <summary>
        /// Creates a new view with the provided properties.
        /// </summary>
        /// <param name="controller">The controller this view whould be initialized to.</param>
        /// <param name="model">The model this view should be initialized to.</param>
        protected View(IController controller, TModel model) {
            _controller = controller;
            _model = model;
        }

        /// <inheritdoc />
        public abstract void Update();

        /// <inheritdoc />
        public abstract void Dispose();
        
        #endregion

        #region Properties

        /// <inheritdoc />
        public IController Controller {
            get => _controller;
            set => _controller = value;
        }

        /// <summary>
        /// The model this view will take data from.
        /// </summary>
        public TModel Model {
            get => _model;
            set => _model = value;
        }

        #endregion
    }
}