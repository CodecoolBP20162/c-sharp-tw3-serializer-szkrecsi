using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SerializerWindowsFormsApp
{
    public partial class Form1 : Form
    {
        List<Person> listOfPeople = new List<Person>();
  
        public Form1()
        {
            InitializeComponent();
            getFirstPerson();
        }

        private void getFirstPerson()
        {
            string firstFile = @"person1.dat";
            if (File.Exists(firstFile)) {
                Person firstPerson = Person.Deserialize(firstFile);
                txtName.Text = firstPerson.Name;
                txtName.ForeColor = Color.Red;
                txtAddress.Text = firstPerson.Address;
                txtAddress.ForeColor = Color.Red;
                txtPhone.Text = firstPerson.PhoneNumber;
                txtPhone.ForeColor = Color.Red;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime recordingDate = DateTime.Now;
            Person person = new Person(txtName.Text, txtAddress.Text, txtPhone.Text, recordingDate);
            string outputFileName = "person" + Person.serialNumber + ".dat";
            person.Serialize(outputFileName);
            listOfPeople.Add(person);
            txtName.Tag = Person.serialNumber;
            MessageBox.Show(String.Format("Person saved! {0}SerialNumber is {1}", Environment.NewLine, txtName.Tag.ToString()), "Saved Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtName.ForeColor = Color.Black;
            txtAddress.ForeColor = Color.Black;
            txtPhone.ForeColor = Color.Black;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                Person firstPerson = listOfPeople[0];
                txtName.Text = firstPerson.Name;
                txtAddress.Text = firstPerson.Address;
                txtPhone.Text = firstPerson.PhoneNumber;
                txtName.Tag = 0;
            }
            catch (ArgumentOutOfRangeException exc) { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                Person lastPerson = listOfPeople[Person.serialNumber-1];
                txtName.Text = lastPerson.Name;
                txtAddress.Text = lastPerson.Address;
                txtPhone.Text = lastPerson.PhoneNumber;
                txtName.Tag = Person.serialNumber;
            }
            catch (ArgumentOutOfRangeException exc) { }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            { 
                int personID = Convert.ToInt32(txtName.Tag.ToString());
                Person previousPerson = listOfPeople[personID - 2];
                txtName.Text = previousPerson.Name;
                txtAddress.Text = previousPerson.Address;
                txtPhone.Text = previousPerson.PhoneNumber;
                txtName.Tag = personID - 1;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is NullReferenceException)
                {
                    MessageBox.Show(String.Format("Could not find this item: {0}Previous Person", Environment.NewLine), "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                throw;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int personID = Convert.ToInt32(txtName.Tag.ToString());
                Person nextPerson = listOfPeople[personID];
                txtName.Text = nextPerson.Name;
                txtAddress.Text = nextPerson.Address;
                txtPhone.Text = nextPerson.PhoneNumber;
                txtName.Tag = personID + 1;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is NullReferenceException)
                {
                    MessageBox.Show(String.Format("Could not find this item: {0}Next Person", Environment.NewLine), "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                throw;
            }
        }
    }
}