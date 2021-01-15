using eBookManager.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;

namespace eBookManager
{
    public partial class ImportBooks : Form
    {
        private string _jsonPath;
        private List<StorageSpace> _spaces;
        private enum _storageSpaceSelection { New = -9999, NoSelection = -1 }

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
        }

        private async void ImportBooks_Load(object sender, EventArgs e)
        {
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);
        }

        private HashSet<string> AllowedExtensions => new
            HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        {  ".doc", ".docx", ".pdf", ".epub", ".lit" };
        private enum Extension { doc = 0, docx = 1, pdf = 2, epub = 3, lit = 4 }
    }
}

