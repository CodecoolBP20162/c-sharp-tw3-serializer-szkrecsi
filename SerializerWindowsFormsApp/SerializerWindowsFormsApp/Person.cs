using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerializerWindowsFormsApp
{

    [Serializable]
    public class Person : IDeserializationCallback
    {
        private string name;
        private string address;
        private string phoneNumber;
        public DateTime recordingDate;
        [NonSerialized]
        public static int serialNumber = 0;

        public Person() { }

        public Person(string name, string address, string phoneNumber, DateTime recordingDate)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.recordingDate = recordingDate;
            serialNumber++;
        }

        public void Serialize(string outputFileName)
        {
            Stream file = new FileStream(outputFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, this);
            file.Close();   
        }

        public static Person Deserialize(string inputFileName)
        {
            Stream file = new FileStream("SerializeBinFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter formatter = new BinaryFormatter();
            Person objDeserialize = (Person)formatter.Deserialize(file);
            file.Close();

            Console.WriteLine("Deserialize:");
            Console.WriteLine("Name: {0}", objDeserialize.name);
            Console.WriteLine("Address: {0}", objDeserialize.address);
            Console.WriteLine("Phone number: {0}", objDeserialize.phoneNumber);
            Console.WriteLine("Data recording: {0}", objDeserialize.recordingDate);
            
            Console.ReadKey();
            return objDeserialize;
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
        }
    }
}