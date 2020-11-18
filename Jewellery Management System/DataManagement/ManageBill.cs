using Jewellery_Management_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Jewellery_Management_System.DataManagement
{
    public class ManageBill
    {
        public static BillDetails GetBill(int id)
        {
            string FileName = @"./DataManagement/Bills/";
            FileName += id.ToString() + ".bin";
            if (File.Exists(FileName))
            {
                Stream openStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                BillDetails billDetails = (BillDetails)deserializer.Deserialize(openStream);
                openStream.Close();
                return billDetails;
            }
            else
            {
                return null;
            }
        }
        public static void CreateBill(BillDetails billDetails)
        {
            string FileName = @"./DataManagement/Bills/";
            FileName += billDetails.bill.BillId.ToString() + ".bin";
            Stream SaveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, billDetails);
            SaveFileStream.Close();
        }
    }
}
