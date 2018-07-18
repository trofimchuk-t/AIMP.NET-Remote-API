using System;

namespace AIMP.NET.RemoteAPI
{
    public class AimpTrackInfo
    {
        private static AimpTrackInfo emptyAimpTrackInfo;

        public bool Active { get; set; }
        public int BitRate { get; set; }
        public int SampleRate { get; set; }
        public int Channels { get; set; }
        public TimeSpan Duration { get; set; }
        public long FileSize { get; set; }
        public int FileMark { get; set; }
        public int TrackNumber { get; set; }

        public string Year { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string FileName { get; set; }
        public string Genre { get; set; }

        public static AimpTrackInfo EmptyAimpTrackInfo
        { get { return emptyAimpTrackInfo ?? (emptyAimpTrackInfo = new AimpTrackInfo()); } }
    }
}
