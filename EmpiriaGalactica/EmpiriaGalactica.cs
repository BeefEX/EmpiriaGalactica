using System;
using EmpiriaGalactica.Buildings;
using EmpiriaGalactica.Managers;
using EmpiriaGalactica.Models;
using Newtonsoft.Json;

namespace EmpiriaGalactica {
    
    public class EmpiriaGalactica {

        public static InstanceManager<IInternalName> PrototypeManager;
        
        public EmpiriaGalactica() {
            PrototypeManager = new InstanceManager<IInternalName>();
            
            var json = JsonConvert.SerializeObject(new BuildingInstance {
                Level = 1,
                SourceBuilding = new Mine()
            });

            var building = JsonConvert.DeserializeObject<BuildingInstance>(json);
            building.SourceBuilding.Update(null);
        }
    }
}