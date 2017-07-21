using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AeroflyTFWGenerator
{
    public partial class MainForm : Form
    {
        private ArrayList _metadata = new ArrayList();

        /// <summary>
        /// Standard form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parses a collection of lines with comma-seperated values
        /// </summary>
        /// <param name="lines">All lines to be parsed</param>
        /// <returns>A collection of arrays containing the values in each line</returns>
        private static ArrayList ParseCSV(IEnumerable<string> lines)
        {
            var values = new ArrayList();
            foreach (var line in lines)
            {
                values.Add(line.Split(','));
            }
            return values;
        }

        /// <summary>
        /// Shows a folder picker dialog to let the user select an output directory for the TFW files
        /// </summary>
        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            CommonFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtOutputDir.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Lets the user browse for a metadata file, and stores its path
        /// </summary>
        private void btnMetadataBrowse_Click(object sender, EventArgs e)
        {
            if (openMetadata.ShowDialog() == DialogResult.OK)
            {
                txtMetadataFile.Text = openMetadata.FileName;
                _metadata = ParseCSV(File.ReadAllLines(openMetadata.FileName));
            }
        }

        /// <summary>
        /// Adds image files to the ListView
        /// </summary>
        private void btnImagesAdd_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                var exists = false; // whether any of the selected images already exist in the list
                var files = openImage.FileNames; // files selected by the user

                foreach (var file in files)
                {
                    if (listImages.Items.Cast<ListViewItem>().All(item => item.Name != file))
                    {
                        var lvi = new ListViewItem
                        {
                            Name = file,
                            Text = Path.GetFileName(file),
                            ToolTipText = file
                        };

                        listImages.Items.Add(lvi);
                    }
                    else
                    {
                        exists = true;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("Some of the added files were already in the list. Any new files have been added.",
                        "File already exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Removes all selected images from the list
        /// </summary>
        private void btnImagesRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selected in listImages.SelectedItems)
            {
                listImages.Items.Remove(selected);
            }
        }

        /// <summary>
        /// When the delete key is released, removes all selected images from the list
        /// </summary>
        private void listImages_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                foreach (ListViewItem selected in listImages.SelectedItems)
                {
                    listImages.Items.Remove(selected);
                }
            }
        }

        /// <summary>
        /// Creates a TFW file for each image in the list, according to the following specification:
        /// Line #  | Content
        /// 0       | 3.75/60/width of the image in pixels
        /// 1       | 0
        /// 2       | 0
        /// 3       | -3.75/60/height of the image in pixels
        /// 4       | first coordinate of BoundingBox
        /// 5       | fourth coordinate of BoundingBox
        /// with the filename the same as the image, but with extension .tfw
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtOutputDir.Text))
            {
                MessageBox.Show("The output directory does not exist.", "Wrong output directory", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(txtMetadataFile.Text))
            {
                MessageBox.Show("The metadata file does not exist.", "Wrong metadata file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listImages.Items.Count == 0)
            {
                MessageBox.Show("Please add some images to the list.", "No images", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var writeCount = 0;
            var ignoreCount = 0;

            foreach (ListViewItem item in listImages.Items)
            {
                var lines = new string[6];
                var fileName = Path.GetFileNameWithoutExtension(item.Text);
                var width = 0f;
                var height = 0f;

                // Get the width and height of the image
                using (var file = new FileStream(item.Name, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (var img = Image.FromStream(stream: file,
                            useEmbeddedColorManagement: false,
                            validateImageData: false))
                        {
                            width = img.PhysicalDimension.Width;
                            height = img.PhysicalDimension.Height;
                        }
                    }
                    catch (ArgumentException)
                    {
                        // If we cannot load the image, ignore it
                        ignoreCount++;
                        continue;
                    }
                }

                // Find the line in metadata corresponding to this image
                var lineIndex = -1;
                for (var i = 0; i < _metadata.Count; i++)
                {
                    if (((string[]) _metadata[i])[1] == fileName)
                    {
                        lineIndex = i;
                        break;
                    }
                }

                if (lineIndex == -1)
                {
                    // If this image is not found in metadata, ignore it
                    ignoreCount++;
                    continue;
                }

                // Lines to be written in TFW
                lines[0] = (3.75 / 60 / width).ToString("0.####################");
                lines[1] = "0";
                lines[2] = "0";
                lines[3] = (-3.75 / 60 / height).ToString("0.####################");
                lines[4] = ((string[])_metadata[lineIndex])[3].Replace("\"\"", "");
                lines[5] = ((string[])_metadata[lineIndex])[6].Replace("\"\"", "");

                // Write lines to file
                File.WriteAllLines(Path.Combine(txtOutputDir.Text, fileName + ".tfw"), lines);
                writeCount++;
            }

            // Report when finished
            if (ignoreCount == 0)
            {
                MessageBox.Show($"Wrote {writeCount} file(s).", "Generation success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $"Some images could not be found in the selected metadata file. Wrote {writeCount} and ignored {ignoreCount} file(s).",
                    "Metadata not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}