namespace CommandPattern.Commands
{
    public class PlusCommand : Command
    {
        public PlusCommand(decimal parameter) : base('+', parameter)
        {
        }

        public override decimal ExecuteCommand(decimal currentResult)
        {
            return currentResult + Parameter;
        }

        public override decimal UndoCommand(decimal currentResult)
        {
            return currentResult - Parameter;
        }
    }
}
