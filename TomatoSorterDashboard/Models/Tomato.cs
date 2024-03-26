using Google.Cloud.Firestore;

namespace TomatoSorterDashboard.Models
{
    [FirestoreData]
    public class Tomato
    {
        [FirestoreProperty]
        public int Id { get; set; }

        [FirestoreProperty]
        public int Ripe { get; set; }

        [FirestoreProperty]
        public int HalfRipe { get; set; }

        [FirestoreProperty]
        public int Unripe { get; set; }

        [FirestoreProperty]
        public int Total { get; set; }

        [FirestoreProperty]
        public int Defect { get; set; }

        [FirestoreProperty]
        public string DateScanned { get; set; }
    }
}
