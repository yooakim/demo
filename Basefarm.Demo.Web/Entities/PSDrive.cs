namespace Basefarm.Demo.Web.Entities
{
    public class PSDrive
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string Name { get; set; }
        public string Root { get; set; }
        public long Used { get; set; }
        public long Free { get; set; }

    }
}
