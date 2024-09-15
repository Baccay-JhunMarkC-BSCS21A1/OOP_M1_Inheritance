using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InheritanceForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", DataPropertyName = "ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "FirstName", HeaderText = "First Name", DataPropertyName = "FirstName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "LastName", HeaderText = "Last Name", DataPropertyName = "LastName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Section", HeaderText = "Section", DataPropertyName = "Section" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Yearlvl", HeaderText = "Year Level", DataPropertyName = "Yearlvl" });
            dataGridView1.DataSource = InventoryManagement.GetItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog(this);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = InventoryManagement.GetItems();
            dataGridView1.Refresh();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchTxt.Text.ToLower(); 
            var filteredList = InventoryManagement.GetItems()
                .Where(s => s.FirstName.ToLower().Contains(searchText) ||
                            s.LastName.ToLower().Contains(searchText) ||
                            s.Section.ToLower().Contains(searchText) ||
                            s.Yearlvl.ToString().Contains(searchText))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredList;
            dataGridView1.Refresh();
        }
    }

    internal class Student
    {
        public int ID { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Section { get; internal set; }
        public int Yearlvl { get; internal set; }
    }

    internal static class InventoryManagement
    {
        static List<Student> people = new List<Student>();

        public static void AddItem(string Fname, string Ln, string section, int ylvl)
        {
            people.Add(new Student
            {
                ID = people.Count + 1,
                FirstName = Fname,
                LastName = Ln,
                Section = section,
                Yearlvl = ylvl
            });
        }

        public static List<Student> GetItems()
        {
            return people;
        }
    }
}
