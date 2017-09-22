using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Sql_to_CS_Class_Generator
{
    public partial class frnClassGenerator : Form
    {
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            SaveSettings();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            SaveSettings();
        }

        public frnClassGenerator()
        {
            InitializeComponent();
            CheckSettingsFile();
            LoadSettings();
        }

        private void CheckSettingsFile()
        {
            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                GetType().FullName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var full_path = Path.Combine(folder, Settings.FileName);
            if (!File.Exists(full_path))
            {
                File.WriteAllText(full_path, ObjectToXmlHelper.ToXml(new Settings()));
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (ValidationInput())
            {
                Generate();
            }
            else
            {
                var result = MessageBox.Show(
                    @"Some of the input fields was not filled in.", 
                    @"Validation exception", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
            SaveSettings();
        }

        private bool ValidationInput()
        {
            //var isSetServer = string.IsNullOrEmpty(txtServer.Text);
            //var isSetDatabase = string.IsNullOrEmpty(txtDatabase.Text);
            //var isSetUsername = string.IsNullOrEmpty(txtUsername.Text);
            //var isSetPassword = string.IsNullOrEmpty(txtPassword.Text);
            //var isSetClassName = string.IsNullOrEmpty(txtClassName.Text);
            //var isSetSql = string.IsNullOrEmpty(txtSql.Text);
            return new List<bool>
            {
                !string.IsNullOrEmpty(txtServer.Text),
                !string.IsNullOrEmpty(txtDatabase.Text),
                !string.IsNullOrEmpty(txtUsername.Text),
                !string.IsNullOrEmpty(txtPassword.Text),
                !string.IsNullOrEmpty(txtClassName.Text),
                !string.IsNullOrEmpty(txtSql.Text),
            }.TrueForAll(i => i);
        }

        private void Generate()
        {
            if (rbGenerateToClipboard.Checked)
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = txtServer.Text,
                    InitialCatalog = txtDatabase.Text,
                    UserID = txtUsername.Text,
                    Password = txtPassword.Text,
                };
                string class_code;
                using (var connection = new SqlConnection(builder.ConnectionString))
                {
                    class_code = new Class_Generator()
                        .GeneratorPocoClass(
                            connection,
                            txtClassName.Text,
                            txtSql.Text);
                }
                Clipboard.SetText(class_code);
            }
            else if (rbGenerateToFile.Checked)
            {
                var dialog = new SaveFileDialog
                {
                    Filter = @"C# code file|*.cs",
                };
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = txtServer.Text,
                        InitialCatalog = txtDatabase.Text,
                        UserID = txtUsername.Text,
                        Password = txtPassword.Text,
                    };
                    using (var connection = new SqlConnection(builder.ConnectionString))
                    {
                        var class_code = new Class_Generator()
                            .GeneratorPocoClass(
                                connection,
                                txtClassName.Text,
                                txtSql.Text);
                        File.WriteAllText(dialog.FileName, class_code);
                    }
                }
            }
            else if (rbGenerateToNewWindow.Checked)
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = txtServer.Text,
                    InitialCatalog = txtDatabase.Text,
                    UserID = txtUsername.Text,
                    Password = txtPassword.Text,
                };
                string class_code;
                using (var connection = new SqlConnection(builder.ConnectionString))
                {
                    class_code = new Class_Generator()
                        .GeneratorPocoClass(
                            connection,
                            txtClassName.Text,
                            txtSql.Text);
                }
                new Form
                {
                    Controls =
                    {
                        new TextBox
                        {
                            Text = class_code,
                            Dock = DockStyle.Fill,
                            WordWrap = true,
                            Multiline = true,
                        }
                    }
                }.ShowDialog(this);
            }
        }

        private void SaveSettings()
        {
            var xml = ObjectToXmlHelper.ToXml(new Settings
            {
                Server = txtServer.Text,
                Database = txtDatabase.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                ClassName = txtClassName.Text,
                GenerateTo = GetGenerateTo(),
            });
            var full_path = Path.Combine(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                GetType().FullName),
                Settings.FileName);
            File.WriteAllText(full_path, xml);
        }

        private void LoadSettings()
        {
            var full_path = Path.Combine(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                GetType().FullName),
                Settings.FileName);
            var xml = File.ReadAllText(full_path);
            var settings = ObjectToXmlHelper.ToObject<Settings>(xml);
            if (settings != null)
            {
                txtServer.Text = settings.Server;
                txtDatabase.Text = settings.Database;
                txtUsername.Text = settings.Username;
                txtPassword.Text = settings.Password;
                txtClassName.Text = settings.ClassName;
                SetGenerateTo(settings.GenerateTo);
            }
        }

        private GenerateTo GetGenerateTo()
        {
            if (rbGenerateToClipboard.Checked)
            {
                return GenerateTo.Clipboard;
            }
            else if (rbGenerateToFile.Checked)
            {
                return GenerateTo.File;
            }
            else if (rbGenerateToNewWindow.Checked)
            {
                return GenerateTo.NewWindow;
            }
            else
            {
                return GenerateTo.Clipboard;
            }
        }

        private void SetGenerateTo(GenerateTo generateTo)
        {
            switch (generateTo)
            {
                case GenerateTo.Clipboard:
                    rbGenerateToClipboard.Checked = true;
                    break;
                case GenerateTo.File:
                    rbGenerateToFile.Checked = true;
                    break;
                case GenerateTo.NewWindow:
                    rbGenerateToNewWindow.Checked = true;
                    break;
                default:
                    rbGenerateToClipboard.Checked = true;
                    break;
            }
        }

    }
}
