using System;

namespace EmpiriaGalactica.Controllers {
    public interface IController : IDisposable {

        void Init();
        
        void Update();

    }
}