namespace Recharge
{
    public abstract class Worker
    {
        private string _id;
        private int _workingHours;

        public Worker(string id)
        {
            this._id = id;
        }

        public void Work(int hours)
        {
            this._workingHours += hours;
        }
    }
}
