namespace CommandPattern.Commands
{
    public abstract class Command
    {
        protected Command(char @operator, decimal parameter) 
        {
            this.Operator = @operator;
            this.Parameter = parameter;
        }

        public char Operator { get; set; }
        public decimal Parameter { get; set; }

        public abstract decimal ExecuteCommand(decimal currentResult);
        public abstract decimal UndoCommand(decimal currentResult);
    }
}
