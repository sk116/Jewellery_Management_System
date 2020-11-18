using Jewellery_Management_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Jewellery_Management_System.DataManagement
{
    public class ManageOwner
    {
        const string FileName = @"./DataManagement/SavedOwner.bin";
        public static Owner GetOwner()
        {
            if (File.Exists(FileName))
            {
                Stream openStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Owner owner = (Owner)deserializer.Deserialize(openStream);
                openStream.Close();
                return owner;
            }
            else
            {
                return null;
            }
        }
        public static void CreateOwner(Owner owner)
        {
            Stream SaveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, owner);
            SaveFileStream.Close();
        }
    }
}
