namespace AIMP.NET.RemoteAPI
{
    public enum PlayerState
    {
        Stopped = 0,
        Paused = 1,
        Playing = 2
    }

    public enum AimpPropertyType
    {
        None,
        Mute,
        Duration,
        Position,
        PlayerState,
        RadioCap,
        Repeat,
        Shuffle,
        VisualMode,
        Volume,
    }
}
