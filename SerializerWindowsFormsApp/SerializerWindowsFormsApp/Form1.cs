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
            person.Serialize(outputFileName);
            listOfPeople.Add(person);
            //MessageBox.Show(outputFileName);
            //MessageBox.Show(listOfPeople.IndexOf(person).ToString());
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                Person firstPerson = listOfPeople[0];
                txtName.Text = firstPerson.Name;
                txtAddress.Text = firstPerson.Address;
                txtPhone.Text = firstPerson.PhoneNumber;
            }
            catch (ArgumentOutOfRangeException exc) { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                Person firstPerson = listOfPeople[Person.serialNumber-1];
                txtName.Text = firstPerson.Name;
                txtAddress.Text = firstPerson.Address;
                txtPhone.Text = firstPerson.PhoneNumber;
            }
            catch (ArgumentOutOfRangeException exc) { }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}
