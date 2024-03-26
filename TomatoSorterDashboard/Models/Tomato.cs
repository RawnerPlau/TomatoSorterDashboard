namespace TomatoSorterDashboard.Models
{
    public class Tomato
    {
        public int Id { get; set; }
        public int Ripe { get; set; }
        public int HalfRipe { get; set; }
        public int Unripe { get; set; }
        public int Total { get; set; }
        public int Defect { get; set; }
        public DateTime DateScanned { get; set; }
    }
}
