namespace StreamProgressInfo
{
    public abstract class StreamableFile
    {
        public StreamableFile(int length, int bytesSent)
        {

            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
