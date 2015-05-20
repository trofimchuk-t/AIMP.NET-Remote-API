namespace AIMP.NET.RemoteAPI
{
    public class AimpVersion
    {
        public AimpVersion(int rawValue)
        {
            Build = (rawValue & 0xffff);               // LOWORD of LRESULT
            Version = ((rawValue >> 16) & 0xffff);     // HIWORD of LRESULT
        }

        public int Version { get; private set; }
        public int Build { get; private set; }

        public override string ToString()
        {
            return string.Format("v{0}.{1}, build {2}", Version / 100, Version % 100, Build);
        }
    }
}
