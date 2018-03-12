namespace Basefarm.Demo.Web.Entities
{
    public class LogicalDisk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SystemName { get; set; }
        public long FreeSpace { get; set; }
        public long Size { get; set; }
        public bool Compressed { get; set; }
        public int DriveType { get; set; }
        public string FileSystem { get; set; }
        public string MaximumComponentLength { get; set; }
        public int MediaType { get; set; }
        public bool SupportsDiskQuotas { get; set; }
        public bool SupportsFileBasedCompression { get; set; }
        public bool VolumeDirty { get; set; }
        public string VolumeName { get; set; }
        public string VolumeSerialNumber { get; set; }

        public long Used
        {
            get
            {
                if(Size > 0) {
                    return Size - FreeSpace;
                } 
                return 0;
            }
        }

    }
}