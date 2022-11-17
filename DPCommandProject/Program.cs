namespace DPCommandProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PultControl control= new PultControl();
            control.Command = new CenterMusicOnCommand(new MusicCenter());

            control.PressStart();
            control.PressFinish();

            control.Command = new WashingMachineCommand(new WashigMachine(), 5, 67);
            control.PressStart();
            control.PressFinish();
        }
    }
}