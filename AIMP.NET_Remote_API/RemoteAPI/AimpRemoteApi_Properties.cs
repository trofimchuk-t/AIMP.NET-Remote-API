namespace AIMP.NET.RemoteAPI.RemoteAPI
{
    public partial class AimpRemoteNetApi
    {
        #region ========== AIMP Properties ==========

        // + How to:
        //     GET:  SendMessage(Handle, WM_AIMP_PROPERTY, PropertyID | AIMP_RA_PROPVALUE_GET, 0);
        //     SET:  SendMessage(Handle, WM_AIMP_PROPERTY, PropertyID | AIMP_RA_PROPVALUE_SET, NewValue);

        public static int AIMP_RA_PROPVALUE_GET { get { return 0; } }
        public static int AIMP_RA_PROPVALUE_SET { get { return 1; } }

        public static uint AIMP_RA_PROPERTY_MASK { get { return 0xFFFFFFF0; } }

        //==============================================================================
        // Properties ID:
        //==============================================================================
        public enum AimpRemoteProperty
        {
            // !! ReadOnly
            // Returns player version:
            // HiWord: Version ID (for example: 301 -> v3.01)
            // LoWord: Build Number
            AIMP_RA_PROPERTY_VERSION = 0x10,

            // GET: Returns current position of now playing track (in msec)
            // SET: LParam: position (in msec)
            AIMP_RA_PROPERTY_PLAYER_POSITION = 0x20,

            // !! ReadOnly
            // Returns duration of now playing track (in msec)
            AIMP_RA_PROPERTY_PLAYER_DURATION = 0x30,

            // !! ReadOnly
            // Returns current player state
            //  0 = Stopped
            //  1 = Paused
            //  2 = Playing
            AIMP_RA_PROPERTY_PLAYER_STATE = 0x40,

            // GET: Return current volume [0..100] (%)
            // SET: LParam: volume [0..100] (%)
            //      Returns 0, if fails
            AIMP_RA_PROPERTY_VOLUME = 0x50,

            // GET: Return current mute state [0..1]
            // SET: LParam: Mute state [0..1]
            //      Returns 0, if fails
            AIMP_RA_PROPERTY_MUTE = 0x60,

            // GET: Return track repeat state [0..1]
            // SET: LParam: Track Repeat state [0..1]
            //      Returns 0, if fails
            AIMP_RA_PROPERTY_TRACK_REPEAT = 0x70,

            // GET: Return shuffle state [0..1]
            // SET: LParam: shuffle state [0..1]
            //      Returns 0, if fails
            AIMP_RA_PROPERTY_TRACK_SHUFFLE = 0x80,

            // GET: Return radio capture state [0..1]
            // SET: LParam: radio capture state [0..1]
            //      Returns 0, if fails
            AIMP_RA_PROPERTY_RADIOCAP = 0x90,


            AIMP_RA_PROPERTY_VISUAL_FULLSCREEN = 0xA0
        }
        #endregion AIMP Properties
    }
}
