namespace EmpiriaGalactica.Commands {
    
    /// <summary>
    /// Used to indicate a class is able to recieve commands.
    /// </summary>
    public interface ICommandable {

        /// <summary>
        /// Called from outside to send command to this object.
        /// </summary>
        /// <param name="command">The command object.</param>
        void OnCommand(Command command);
    }
}