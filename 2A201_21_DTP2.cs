using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _2A_201_CTP1
{
    public partial class Form1 : Form
    {
        private Database db;

        public Form1()
        {
            InitializeComponent()
        private void Form1_Load(object sender, EventArgs e db = new Database()
            db.Connecter()
            RefreshDataGrid();
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Deconnecter()
        private void btnAjouter_Click(object sender, EventArgs e)
                { 
           
            db.cmd.CommandText = "INSERT INTO Etudiant values(@cin, @nom, @prenom, @age)";

            db.cmd.Connection = db.connection;

            db.cmd.Parameters.Clear();


                    if (numID.Value != 0 && txtNom.Text != "" && txtPrenom.Text != "" && numAge.Value > 18)
                    {
                        db.cmd.Parameters.AddWithValue("@cin", numID.Value);
                        db.cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                        db.cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
                        db.cmd.Parameters.AddWithValue("@age", numAge.Value);

                        db.cmd.ExecuteNonQuery();


                        RefreshDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Merci de remplir tous les champs");
                    }


        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            db.Deconnecter();
            this.Close();
        }



       
        public void RefreshDataGrid()
        {
            db.dataReader = db.GetAll();

            DataTable dataTable = new DataTable();

           
            dataTable.Load(db.dataReader);

            
            dataGridView.DataSource = dataTable;
        }
    }
}

