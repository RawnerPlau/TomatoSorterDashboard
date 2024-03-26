using Firebase.Database;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Collections;
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

        public async Task<Tomato> GetOneTomatoDoc() 
        {
            Tomato recentTomato = new Tomato();

            DocumentReference document = _db.Collection("tomatoes").Document("03-26-24");
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
                };

                recentTomato = tomato;
            }

            return recentTomato;
        }
        
    }
}
