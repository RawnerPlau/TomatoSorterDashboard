using Firebase.Database;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Collections;
using System.Globalization;
using TomatoSorterDashboard.Interfaces;
using TomatoSorterDashboard.Models;

namespace TomatoSorterDashboard.Repositories
{
    public class TomatoRepository : ITomatoRepository
    {
        FirestoreDb _db;
     
        public TomatoRepository(FirestoreCredentialInitializer firestoreCredential)
        {
            var projectId = firestoreCredential.ProjectId;
            var client = new FirestoreClientBuilder
            {
                JsonCredentials = firestoreCredential.Serialize()
            }.Build();

           

            _db = FirestoreDb.Create(projectId, client);
            
        }

        public async Task<List<Tomato>> GetAllTomatoes()
        {
            
            Query query = _db.Collection("tomatoes");
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            List<Tomato> tomatoes = new List<Tomato>();

            foreach (DocumentSnapshot document in querySnapshot.Documents)
            {
                Tomato tomato = document.ConvertTo<Tomato>(); // Convert document to Tomato object
                tomatoes.Add(tomato);
            }
            return tomatoes;
        }

        public async Task<Dashboard> GetDashboardValues()
        {

            Query query = _db.Collection("tomatoes");
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            Dashboard dashboardValues = new Dashboard();

            foreach (DocumentSnapshot document in querySnapshot.Documents)
            {
                Tomato data = document.ConvertTo<Tomato>(); // Convert document to Tomato object
                dashboardValues.Unripe += data.UNRIPE;
                dashboardValues.Ripe += data.RIPE;
                dashboardValues.HalfRipe += data.HALFRIPE;
                dashboardValues.Defect += data.DEFECT;
            }
            
            dashboardValues.Total = dashboardValues.HalfRipe + dashboardValues.Ripe + dashboardValues.Unripe;

            return dashboardValues;
        }

        public async Task<Tomato> GetTomatoToday() 
        {
            Tomato recentTomato = new Tomato();

            DocumentReference document = _db.Collection("tomatoes").Document(DateTime.Today.ToString("MM-dd-yy"));
            DocumentSnapshot documentSnapshot = await document.GetSnapshotAsync();
            if (documentSnapshot.Exists)
            {
                Tomato tomato = new Tomato()
                {
                    Id = documentSnapshot.GetValue<int>("id"),
                    //DateScanned = Convert.ToDateTime(documentSnapshot.GetValue<Timestamp>("DateScanned")).ToLocalTime(),
                    TOTAL = documentSnapshot.GetValue<int>("Total"),
                    RIPE = documentSnapshot.GetValue<int>("Ripe"),
                    HALFRIPE = documentSnapshot.GetValue<int>("Half-Ripe"),
                    UNRIPE = documentSnapshot.GetValue<int>("Unripe"),
                    DEFECT = documentSnapshot.GetValue<int>("Defect"),
                    DATESCANNED = documentSnapshot.GetValue<string>("DateScanned")

            };

                recentTomato = tomato;
            }

            return recentTomato;
        }
        
    }
}
