using System.Collections.Generic;

namespace AdventOfCode2017.Eight
{
    public interface IRegisterCommand
    {
        void Execute(Register register);

        Register AppliesToRegister(List<Register> registers);

        bool IsApplicable(List<Register> registers);
    }
}