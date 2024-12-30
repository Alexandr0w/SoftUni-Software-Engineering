namespace CommandPattern.Commands
{
    public class MultiplyCommand : Command
    {
        public MultiplyCommand(decimal parameter) : base('*', parameter)
        {
        }

        public override decimal ExecuteCommand(decimal currentResult)
        {
            return currentResult * Parameter;
        }

        public override decimal UndoCommand(decimal currentResult)
        {
            return currentResult / Parameter;
        }
    }
}
