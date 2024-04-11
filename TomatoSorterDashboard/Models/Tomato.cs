using Google.Cloud.Firestore;

namespace TomatoSorterDashboard.Models
{
    [FirestoreData]
    public class Tomato
    {
        [FirestoreProperty]
        public int Id { get; set; }

        [FirestoreProperty]
        public int RIPE { get; set; }

        [FirestoreProperty]
        public int HALFRIPE { get; set; }

        [FirestoreProperty]
        public int UNRIPE { get; set; }

        [FirestoreProperty]
        public int TOTAL { get; set; }

        [FirestoreProperty]
        public int DEFECT { get; set; }

        [FirestoreProperty]
        public string DATESCANNED { get; set; }
    }
}
