using Google.Cloud.Firestore.V1;
using Google.Cloud.Firestore;
using TomatoSorterDashboard.Interfaces;
using TomatoSorterDashboard.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using Newtonsoft.Json;

namespace TomatoSorterDashboard.Repositories
{
    public class ControlsRepository: IControlsRepository
    {
        FirestoreDb _db;

        public ControlsRepository(FirestoreCredentialInitializer firestoreCredential)
        {
            var projectId = firestoreCredential.ProjectId;
            var client = new FirestoreClientBuilder
            {
                JsonCredentials = firestoreCredential.Serialize()
            }.Build();

            _db = FirestoreDb.Create(projectId, client);
        }

        public async void ToggleSwitch(Toggle data)
        {
            var docRef = _db.Collection("controls").Document("controls");
            await docRef.UpdateAsync(data.Key, data.Value);
            
        }
    }
}
