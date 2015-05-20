namespace AIMP.NET.RemoteAPI.RemoteAPI
{
    public partial class AimpRemoteNetApi
    {
        #region ========== AIMP Commands ==========

        //==============================================================================
        // Commands ID for WM_AIMP_COMMAND message: (Command ID must be defined in WParam)
        //==============================================================================

        private const int AIMP_RA_CMD_BASE = 10;

        public enum AimpRemoteCommand
        {
            // LParam: Window Handle, which will receive WM_AIMP_NOTIFY message from AIMP
            // See description for WM_AIMP_NOTIFY message for details
            AIMP_RA_CMD_REGISTER_NOTIFY = AIMP_RA_CMD_BASE + 1,

            // LParam: Window Handle
            AIMP_RA_CMD_UNREGISTER_NOTIFY = AIMP_RA_CMD_BASE + 2,

            // Start / Resume playback
            // See AIMP_RA_PROPERTY_PLAYER_STATE
            AIMP_RA_CMD_PLAY = AIMP_RA_CMD_BASE + 3,

            // Pause / Start playback
            // See AIMP_RA_PROPERTY_PLAYER_STATE
            AIMP_RA_CMD_PLAYPAUSE = AIMP_RA_CMD_BASE + 4,

            // Pause / Resume playback
            // See AIMP_RA_PROPERTY_PLAYER_STATE
            AIMP_RA_CMD_PAUSE = AIMP_RA_CMD_BASE + 5,

            // Stop playback
            // See AIMP_RA_PROPERTY_PLAYER_STATE
            AIMP_RA_CMD_STOP = AIMP_RA_CMD_BASE + 6,

            // Next Track
            AIMP_RA_CMD_NEXT = AIMP_RA_CMD_BASE + 7,

            // Previous Track
            AIMP_RA_CMD_PREV = AIMP_RA_CMD_BASE + 8,

            // Next Visualization
            AIMP_RA_CMD_VISUAL_NEXT = AIMP_RA_CMD_BASE + 9,

            // Previous Visualization
            AIMP_RA_CMD_VISUAL_PREV = AIMP_RA_CMD_BASE + 10,

            // Close the program
            AIMP_RA_CMD_QUIT = AIMP_RA_CMD_BASE + 11,

            // Execute "Add files" dialog
            AIMP_RA_CMD_ADD_FILES = AIMP_RA_CMD_BASE + 12,

            // Execute "Add folders" dialog
            AIMP_RA_CMD_ADD_FOLDERS = AIMP_RA_CMD_BASE + 13,

            // Execute "Add Playlists" dialog
            AIMP_RA_CMD_ADD_PLAYLISTS = AIMP_RA_CMD_BASE + 14,

            // Execute "Add URL" dialog
            AIMP_RA_CMD_ADD_URL = AIMP_RA_CMD_BASE + 15,

            // Execute "Open Files" dialog
            AIMP_RA_CMD_OPEN_FILES = AIMP_RA_CMD_BASE + 16,

            // Execute "Open Folders" dialog
            AIMP_RA_CMD_OPEN_FOLDERS = AIMP_RA_CMD_BASE + 17,

            // Execute "Open Playlist" dialog
            AIMP_RA_CMD_OPEN_PLAYLISTS = AIMP_RA_CMD_BASE + 18,

            // AlbumArt Request
            AIMP_RA_CMD_GET_ALBUMART = AIMP_RA_CMD_BASE + 19,

            // Start First Visualization
            AIMP_RA_CMD_VISUAL_START = AIMP_RA_CMD_BASE + 20,

            // Stop Visualization
            AIMP_RA_CMD_VISUAL_STOP = AIMP_RA_CMD_BASE + 21
        }
        #endregion AIMP Commands
    }
}
