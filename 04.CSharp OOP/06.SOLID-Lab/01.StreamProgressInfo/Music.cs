namespace StreamProgressInfo
{
    public class Music : StreamableFile
    {
        private string _artist;
        private string _album;

        public Music(string artist, string album, int length, int bytesSent) : base(length, bytesSent)
        {
            this._artist = artist;
            this._album = album;
        }
    }
}
