using System;
using System.Threading;
using EmpiriaGalactica.Input;

namespace EmpiriaGalactica_CLI {
    public class CliInput : IInput {
        
        public event EventHandler<KeyboardArgs> KeyDown;

        public CliInput() {
            new Thread(() => {
                while (true) {
                    KeyDown?.Invoke(this, new KeyboardArgs(Console.ReadKey().Key.ToString()));
                }
            }).Start();
        }
    }
}