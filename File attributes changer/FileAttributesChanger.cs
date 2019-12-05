using System;
using System.IO;
using System.Windows.Forms;

namespace File_attributes_changer
{
    public partial class FileAttributesChanger : Form
    {
        private string selectedFilePath;

        private string labelSelectText;
        private string labelAttributesText;

        public FileAttributesChanger()
        {
            InitializeComponent();
        }

        private void FileAttributesChanger_Load(object sender, EventArgs e)
        {
            labelSelectText = "File: ";
            labelAttributesText = "File attributes: ";

            var attributes = Enum.GetValues(typeof(FileAttributes));

            comboBoxAttributes.DataSource = attributes;
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();

                fd.ShowDialog();

                if (string.IsNullOrEmpty(fd.FileName))
                {
                    throw new Exception("File not selected");
                }

                updateFileInfo(fd.FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSetAttribute_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxAttributes.Items.Count == 0)
                {
                    throw new Exception("No attributes in list");
                }

                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    throw new Exception("File not selected");
                }

                File.SetAttributes(selectedFilePath, (FileAttributes)comboBoxAttributes.SelectedItem);

                updateFileInfo(selectedFilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateFileInfo(string pathToFile)
        {
            if(!File.Exists(pathToFile))
            {
                throw new Exception("File not exists");
            }

            labelSelectedFile.Text = $"{labelSelectText}{Path.GetFileName(pathToFile)}";

            FileAttributes attributes = File.GetAttributes(pathToFile);

            labelAttributes.Text = $"{labelAttributesText}{attributes}";

            selectedFilePath = pathToFile;
        }
    }
}
