namespace AdventOfCode2017.Console
{
    public interface ICommand
    {
        void Execute();

        bool HadErrorInCreation();
    }
}