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

                labelSelectedFile.Text = $"{labelSelectText}{Path.GetFileName(fd.FileName)}";

                FileAttributes attributes = File.GetAttributes(fd.FileName);

                labelAttributes.Text = $"{labelAttributesText}{attributes}";

                selectedFilePath = fd.FileName;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
