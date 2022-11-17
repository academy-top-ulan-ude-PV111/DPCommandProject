using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCommandProject
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver
    class MusicCenter
    {
        public void OnPower()
        {
            Console.WriteLine("Music center on");
        }

        public void OffPower()
        {
            Console.WriteLine("Music center off");
        }
    }

    class CenterMusicOnCommand : ICommand
    {
        MusicCenter center;

        public CenterMusicOnCommand(MusicCenter center)
        {
            this.center = center;
        }

        public void Execute()
        {
            center.OnPower();
        }

        public void Undo()
        {
            center.OffPower();
        }
    }

    // Invoker
    class PultControl
    {
        public ICommand Command { set; private get; }
        public PultControl() {}

        public void PressStart()
        {
            Command.Execute();
        }

        public void PressFinish()
        {
            Command.Undo();
        }

    }

    // Receiver
    class WashigMachine
    {
        public void WashingPrepare(int weight)
        {
            Console.WriteLine($"Белье {weight} кг, загружается");
        }

        public void WashingDo(int time)
        {
            Console.WriteLine($"Белье стирается {time} минут");
        }

        public void WashingStop()
        {
            Console.WriteLine($"Белье постиралось");
        }
    }

    class WashingMachineCommand : ICommand
    {
        WashigMachine machine;
        int weight;
        int time;

        public WashingMachineCommand(WashigMachine machine, int weight, int time)
        {
            this.machine = machine;
            this.weight = weight;
            this.time = time;
        }

        public void Execute()
        {
            machine.WashingPrepare(weight);
            machine.WashingDo(time);
        }

        public void Undo()
        {
            machine.WashingStop();
        }
    }
}
