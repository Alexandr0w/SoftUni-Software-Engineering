namespace StreamProgressInfo
{
    public class File : StreamableFile
    {
        private string _name;

        public File(string name, int length, int bytesSent) : base(length, bytesSent)
        {
            this._name = name;
        }

        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
