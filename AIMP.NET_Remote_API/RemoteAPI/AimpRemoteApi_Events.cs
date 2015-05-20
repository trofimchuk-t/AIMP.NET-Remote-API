namespace AIMP.NET.RemoteAPI.RemoteAPI
{
    public partial class AimpRemoteNetApi
    {
        // + How to:
        //     Receive Change Notification:
        //       1) You should register notification hook using AIMP_RA_CMD_REGISTER_NOTIFY command
        //       2) When property will change you receive WM_AIMP_NOTIFY message with following params:
        //          WParam: AIMP_RA_NOTIFY_PROPERTY (Notification ID)
        //          LParam: Property ID

        #region ========== AIMP Events ==========

        private const int AIMP_RA_NOTIFY_BASE = 0;

        //==============================================================================
        // Notifications ID for WM_AIMP_NOTIFY message: (Notification ID in WParam)
        //==============================================================================
        public enum AimpRemoteEvent
        {
            AIMP_RA_NOTIFY_TRACK_INFO = AIMP_RA_NOTIFY_BASE + 1,

            // Called, when audio stream starts playing or when an Internet radio station changes the track
            AIMP_RA_NOTIFY_TRACK_START = AIMP_RA_NOTIFY_BASE + 2,

            // Called, when property has been changed
            // LParam: Property ID
            AIMP_RA_NOTIFY_PROPERTY = AIMP_RA_NOTIFY_BASE + 3
        }

        #endregion AIMP Events
    }
}
