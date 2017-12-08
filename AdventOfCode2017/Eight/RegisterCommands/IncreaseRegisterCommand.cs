using System.Collections.Generic;

namespace AdventOfCode2017.Eight.RegisterCommands
{
    public class IncreaseRegisterCommand : IRegisterCommand
    {
        private readonly RegisterCommandAttributes _attribs;

        public IncreaseRegisterCommand(RegisterCommandAttributes attribs)
        {
            _attribs = attribs;
        }

        public bool IsApplicable(List<Register> registers)
        {
            int registerValue = registers.Find(r => r.Name == _attribs.ConditionName).Value;
            return ConditionEvaluator.IsConditionTrue(registerValue, _attribs.ConditionEvaluator, _attribs.ConditionTest);
        }

        public Register AppliesToRegister(List<Register> registers)
        {
            return registers.Find(r => r.Name == _attribs.RegisterName);
        }

        public void Execute(Register register)
        {
            register.Value += _attribs.Modifier;
        }
    }
}