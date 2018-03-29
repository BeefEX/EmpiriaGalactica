namespace EmpiriaGalactica {
    
    /// <summary>
    /// Contains all logic related to rendering a single object.
    /// </summary>
    public abstract class View<TModel> where TModel : IModel {

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
        
        #endregion

        #region Properties

        /// <summary>
        /// The controller this View will report to.
        /// </summary>
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