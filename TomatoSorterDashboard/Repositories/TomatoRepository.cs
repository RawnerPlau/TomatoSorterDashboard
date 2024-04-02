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
            Console.Write("xcxcx");
            return tomatoes;
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
                    Total = documentSnapshot.GetValue<int>("Total"),
                    Ripe = documentSnapshot.GetValue<int>("Ripe"),
                    HalfRipe = documentSnapshot.GetValue<int>("Half-Ripe"),
                    Unripe = documentSnapshot.GetValue<int>("Unripe"),
                    Defect = documentSnapshot.GetValue<int>("Defect"),
                    DateScanned = documentSnapshot.GetValue<string>("DateScanned")

            };

                recentTomato = tomato;
            }

            return recentTomato;
        }
        
    }
}
