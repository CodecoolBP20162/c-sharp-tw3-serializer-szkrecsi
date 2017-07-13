using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace SerializerWindowsFormsApp
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RecordingDate { get; set; }
        [NonSerialized]
        public static int serialNumber = 0;

        public Person() { }

        public Person(string name, string address, string phoneNumber, DateTime recordingDate)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            RecordingDate = recordingDate;
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
            Stream file = new FileStream(inputFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter formatter = new BinaryFormatter();
            Person objDeserialize = (Person)formatter.Deserialize(file);
            file.Close();
            return objDeserialize;
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
        }
    }
}