using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace lab2
{
    public partial class Form1 : Form
    {
        public readonly ICategoriesCrud _categoriesCrud;

        public Form1()
        {
            InitializeComponent();
            _categoriesCrud = new DapperContribCategoriesCrud();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _categoriesCrud.GetAllCategories();
        }

        private void insertCategory_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;

            _categoriesCrud.InsertCategory(title, description);
            dataGridView1.DataSource = _categoriesCrud.GetAllCategories();
        }

        private void updateCategory_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _categoriesCrud.UpdateCategory(id, title, description);
            dataGridView1.DataSource = _categoriesCrud.GetAllCategories();
        }

        private void deleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                _categoriesCrud.DeleteCategory(id);
                dataGridView1.DataSource = _categoriesCrud.GetAllCategories();
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"Exception message: {exception.Message}");
            }
        }

    }
}