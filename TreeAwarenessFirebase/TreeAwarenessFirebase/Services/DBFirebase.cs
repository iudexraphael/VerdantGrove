using TreeAwarenessFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAwarenessFirebase.Services
{

    public class DBFirebase
    {

        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://treeawareness-3775a-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<TreeInfo> getTree()
        {
            var treeData = client
                .Child("TreeInfo")
                .AsObservable<TreeInfo>()
                .AsObservableCollection();

            return treeData;
        }


        public async Task AddTree(
            int treeCode,
            string name,
            string initialIdentification,
            string notes,
            string gpsCoordinates,
            string location,
            string landmark,
            string height,
            string canopy
            )
        {
            TreeInfo tree = new TreeInfo()
            {
                TreeCode = treeCode,
                Name = name,
                InitialIdentification = initialIdentification,
                Notes = notes,
                GPSCoordinates = gpsCoordinates,
                Location = location,
                Landmark = landmark,
                Height = height,
                Canopy = canopy

            };

            await client.Child("TreeInfo").PostAsync(tree);
        }
        public async Task DeleteTree(int treeCode,
            string name,
            string initialIdentification,
            string notes,
            string gpsCoordinates,
            string location,
            string landmark,
            string height,
            string canopy
            )
        {
            var toDeleteTree = (await client
                 .Child("TreeInfo")
                 .OnceAsync<TreeInfo>()).FirstOrDefault
                 (a => a.Object.TreeCode == treeCode
                 || a.Object.Name == name
                 || a.Object.InitialIdentification == initialIdentification
                 || a.Object.Notes == notes
                 || a.Object.GPSCoordinates == gpsCoordinates
                 || a.Object.Location == location
                 || a.Object.Landmark == landmark
                 || a.Object.Height == height
                 || a.Object.Canopy == canopy
                 );

            await client.Child("TreeInfo").Child(toDeleteTree.Key).DeleteAsync();

        }
        public async Task UpdateTree(int treeCode,
            string name,
            string initialIdentification,
            string notes,
            string gpsCoordinates,
            string location,
            string landmark,
            string height,
            string canopy
            )
        {
            var toUpdateTree = (await client
                .Child("TreeInfo")
                .OnceAsync<TreeInfo>()).FirstOrDefault
                (a => a.Object.TreeCode == treeCode
                 || a.Object.Name == name
                 || a.Object.InitialIdentification == initialIdentification
                 || a.Object.Notes == notes
                 || a.Object.GPSCoordinates == gpsCoordinates
                 || a.Object.Location == location
                 || a.Object.Landmark == landmark
                 || a.Object.Height == height
                 || a.Object.Canopy == canopy
                 );

            TreeInfo e = new TreeInfo()
            {
                TreeCode = treeCode,
                Name = name,
                InitialIdentification = initialIdentification,
                Notes = notes,
                GPSCoordinates = gpsCoordinates,
                Location = location,
                Landmark = landmark,
                Height = height,
                Canopy = canopy

            };
            await client
                .Child("TreeInfo")
                .Child(toUpdateTree.Key)
                .PutAsync(e);
        }
        public ObservableCollection<UserMessages> getMessage()
        {
            var userData = client
                .Child("UserMessages")
                .AsObservable<UserMessages>()
                .AsObservableCollection();

            return userData;
        }

        public async Task AddMessage(
            int messageID,
            string username,
            string comment,
            string image

            )
        {
            UserMessages message = new UserMessages()
            {
                MessageID = messageID,
                Username = username,
                Comment = comment
            


            };

            await client.Child("UserMessages").PostAsync(message);
        }
        public async Task DeleteMessage(
          int messageID,
          string username,
          string comment
          

          )
        {
            var toDeleteMessage = (await client
                 .Child("UserMessages")
                 .OnceAsync<UserMessages>()).FirstOrDefault
                 (a => a.Object.MessageID == messageID
                 || a.Object.Username == username
                 || a.Object.Comment == comment
                 

                 );
            await client.Child("UserMessages").Child(toDeleteMessage.Key).DeleteAsync();

        }

        public async Task UpdateMessage(
          int messageID,
          string username,
          string comment
         
          )
        {
            var toUpdateTree = (await client
                 .Child("UserMessages")
                 .OnceAsync<UserMessages>()).FirstOrDefault
                 (a => a.Object.MessageID == messageID
                 || a.Object.Username == username
                 || a.Object.Comment == comment
                
                 );

            UserMessages e = new UserMessages()
            {
                MessageID = messageID,
                Username = username,
                Comment = comment,
             

            };
            await client
                .Child("UserMessages")
                .Child(toUpdateTree.Key)
                .PutAsync(e);
        }
    }
}


 