using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Rendering;

namespace EmpiriaGalactica {
    
    public class EmpiriaGalactica {

        public static InstanceManager<IInternalName> PrototypeManager;
        public static IRenderer Renderer;
        public static GameController GameController;
        
        public EmpiriaGalactica(IRenderer renderer) {
            PrototypeManager = new InstanceManager<IInternalName>();
            Renderer = renderer;
            GameController = new GameController();
        }
    }
}