using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Models;

namespace EmpiriaGalactica.Views {
    
    /// <summary>
    /// Panel are limited to a specific screen portion specified by the two corners. 
    /// </summary>
    /// <typeparam name="T">The models this panel will be rendering.</typeparam>
    public abstract class Panel<T> : View<T> where T : IModel {
        
        #region Members

        /// <summary>
        /// The top left corner of the panel.
        /// </summary>
        private Vector _top;
        
        /// <summary>
        /// The top right conrenr of the panel.
        /// </summary>
        private Vector _bottom;
        
        #endregion
        
        #region Methods
        
        /// <inheritdoc cref="View{TModel}"/>
        protected Panel(IController controller, T model) : base(controller, model) { }
        
        #endregion
        
        #region Properties

        /// <summary>
        /// The top-left conrener of the panel.
        /// </summary>
        public Vector Top {
            get => _top;
            set => _top = value;
        }

        /// <summary>
        /// The bottom-right corner of the panel.
        /// </summary>
        public Vector Bottom {
            get => _bottom;
            set => _bottom = value;
        }

        #endregion
        
    }
}