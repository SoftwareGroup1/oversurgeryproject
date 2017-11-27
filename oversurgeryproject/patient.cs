using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oversurgeryproject
{
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void patient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oversugeryDBDataSet.patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.oversugeryDBDataSet.patient);
            Edit(false);
        }

        private void Edit(bool value)
        {
            txtname.Enabled = value;
            txtgender.Enabled = value;
            txtdob.Enabled = value;
            txtadress.Enabled = value;
            txtnumber.Enabled = value;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Edit(true);
                oversugeryDBDataSet.patient.AddpatientRow(oversugeryDBDataSet.patient.NewpatientRow());
                txtname.Focus();
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oversugeryDBDataSet.patient.RejectChanges();
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit(true);
            txtname.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Edit(false);
            patientBindingSource.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Edit(false);
                patientBindingSource.EndEdit();
                patientTableAdapter.Update(oversugeryDBDataSet.patient);
                dataGridView1.Refresh();
                txtname.Focus();
                MessageBox.Show("New Data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oversugeryDBDataSet.patient.RejectChanges();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)//Enter
            {
                if (MessageBox.Show("Are you sure you want to remove this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    patientBindingSource.RemoveCurrent(); 

            }
        }
    }
}
