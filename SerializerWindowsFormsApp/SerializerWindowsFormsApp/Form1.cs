using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerializerWindowsFormsApp
{
    public partial class Form1 : Form
    {
        List<Person> listOfPeople = new List<Person>();

        public Form1()
        {
            InitializeComponent();          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime recordingDate = DateTime.Now;
            Person person = new Person(txtName.Text, txtAddress.Text, txtPhone.Text, recordingDate);
            string outputFileName = "person" + Person.serialNumber + ".dat";
            //MessageBox.Show(outputFileName);
            person.Serialize(outputFileName);
            listOfPeople.Add(person);
            //MessageBox.Show(listOfPeople.IndexOf(person).ToString());
        }
    }
}
