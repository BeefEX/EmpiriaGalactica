using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Input;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica {
    
    public class EmpiriaGalactica {

        public static InstanceManager<IInternalName> PrototypeManager;
        public static GameController GameController;
        
        public static IRenderer Renderer;
        public static IInput Input;
        
        public EmpiriaGalactica(IRenderer renderer, IInput input) {
            Renderer = renderer;
            Input = input;
            
            PrototypeManager = new InstanceManager<IInternalName>();
            GameController = new GameController();
        }
    }
}