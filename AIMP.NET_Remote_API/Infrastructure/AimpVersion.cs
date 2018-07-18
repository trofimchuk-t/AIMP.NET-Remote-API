namespace AIMP.NET.RemoteAPI
{
    public class AimpVersion
    {
        public AimpVersion(int rawValue)
        {
            Build = rawValue & 0xffff;               // LOWORD of LRESULT
            Version = (rawValue >> 16) & 0xffff;     // HIWORD of LRESULT
        }

        public int Version { get; }
        public int Build { get; }

        public override string ToString()
        {
            return $"v{Version / 100}.{Version % 100}, build {Build}";
        }
    }
}
