namespace CommandPattern.Commands
{
    public class MinusCommand : Command
    {
        public MinusCommand(decimal parameter) : base('-', parameter)
        {
        }

        public override decimal ExecuteCommand(decimal currentResult)
        {
            return currentResult - Parameter;
        }

        public override decimal UndoCommand(decimal currentResult)
        {
            return currentResult + Parameter;
        }
    }
}
