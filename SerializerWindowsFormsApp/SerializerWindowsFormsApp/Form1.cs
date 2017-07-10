using System;
using System.Windows.Forms;

namespace SerializerWindowsFormsApp
{
    public partial class Form1 : Form
    {
        //Person person = new Person();
        DateTime recordingDate = new DateTime(1980, 8, 17);
        Person person = new Person("John", "Budapest", "123-4567", new DateTime(1980, 8, 17));

        public Form1()
        {
            InitializeComponent();          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string outputFileName = "person" + person.serialNumber + ".dat";
            //MessageBox.Show(outputFileName);
            person.Serialize(outputFileName);
        }
    }
}
