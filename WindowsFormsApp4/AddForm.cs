using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddForm : Form
    {
        private bool guest;

        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем значения полей ввода
            string documentNumber = textBox1.Text;
            string documentType = textBox2.Text;
            string issueDate = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            string lastName = textBox3.Text;
            string firstName = textBox4.Text;

            // Формируем строку с данными о документе
            string documentData = $"{documentNumber};{documentType};{issueDate};{lastName};{firstName}";

            try
            {
                // Задайте путь к файлу для сохранения данных
                string dataFilePath = @"C:\user\documents.txt";

                // Записываем данные в файл
                using (StreamWriter writer = new StreamWriter(dataFilePath, true))
                {
                    writer.WriteLine(documentData);
                    writer.Flush();
                }

                // Очищаем поля ввода после добавления
                textBox1.Clear();
                textBox2.Clear();
                dateTimePicker1.Value = DateTime.Now;
                textBox3.Clear();
                textBox4.Clear();

                // Оповещаем пользователя об успешном добавлении
                MessageBox.Show("Документ успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении документа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm addForm = new MainForm(guest);
            addForm.Show();
            this.Hide();
        }
    }
}
