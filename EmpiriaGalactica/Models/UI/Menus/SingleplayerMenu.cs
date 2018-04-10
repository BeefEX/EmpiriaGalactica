using System.Collections.Generic;
using System.IO;
using EmpiriaGalactica.Controllers;
using EmpiriaGalactica.Controllers.UI;
using EmpiriaGalactica.Controllers.ViewControllers;
using EmpiriaGalactica.Managers;
using Newtonsoft.Json;

namespace EmpiriaGalactica.Models.UI.Menus {
    public class SingleplayerMenu : Menu {
        public SingleplayerMenu() {
            Buttons = new List<Button>(new [] {
                new Button {
                    Title = "New game",
                    OnClick = () => {
                        
                        
                        //EmpiriaGalactica.GameController.CurrentController = new GalaxyViewController(game);
                    }
                },
                new Button {
                    Title = "Load game"
                },
                new Button {
                    Title = "Back",/*
                    OnClick = () => EmpiriaGalactica.GameController.PopBack()*/
                }
            });
        }
    }
}