using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

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

            List<string> stringAttributes = new List<string>();

            foreach (object item in attributes)
            {
                stringAttributes.Add(item.ToString());
            }

            comboBoxAttributes.Items.AddRange(stringAttributes.ToArray());

            if (comboBoxAttributes.Items.Count > 0)
            {
                comboBoxAttributes.SelectedIndex = 0;
            }
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

        private void buttonSetAttribute_Click(object sender, EventArgs e)
        {

        }
    }
}
