using System;

namespace EmpiriaGalactica.Models.UI {
    public class Button : IModel {

        public string Title { get; set; }
        
        public bool Selected { get; set; }

        public Action OnClick { get; set; }
    }
}