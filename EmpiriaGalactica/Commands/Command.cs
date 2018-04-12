namespace EmpiriaGalactica.Commands {
    
    /// <summary>
    /// Base class of commands.
    /// </summary>
    public class Command {

        #region Members

        /// <summary>
        /// Label of this command.
        /// </summary>
        private readonly string _label;

        /// <summary>
        /// Parameters of this command.
        /// </summary>
        private readonly object[] _parameters;

        #endregion
        
        #region Methods
        
        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="label">The label of this command.</param>
        /// <param name="parameters">The parameters of this command.</param>
        public Command(string label, params object[] parameters) {
            _label = label;
            _parameters = parameters;
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Label of this command.
        /// </summary>
        public string Label => _label;

        /// <summary>
        /// Parameters this command is holding.
        /// </summary>
        public object[] Parameters => _parameters;

        #endregion
    }
}