using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Importacion
{
    public partial class FrmInicio : Form
    {
        private string dbPath = "datos_importados.db";
        private string tableName = "";

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos compatibles (*.csv;*.txt;*.xml)|*.csv;*.txt;*.xml";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                dtgDatos.Columns.Clear();
                dtgDatos.Rows.Clear();

                switch (extension)
                {
                    case ".csv":
                    case ".txt":
                        CargarDesdeCSV(filePath);
                        break;
                    case ".xml":
                        CargarDesdeXML(filePath);
                        break;
                    default:
                        MessageBox.Show("Formato no soportado.");
                        break;
                }
            }
        }

        private void CargarDesdeCSV(string ruta)
        {
            string[] lineas = File.ReadAllLines(ruta);
            if (lineas.Length == 0)
            {
                MessageBox.Show("El archivo está vacío.");
                return;
            }

            char delimitador = lineas[0].Contains(";") ? ';' : ',';

            string[] columnas = lineas[0].Split(delimitador);

            dtgDatos.Columns.Clear();
            dtgDatos.Rows.Clear();

            foreach (string columna in columnas)
            {
                dtgDatos.Columns.Add(columna.Trim(), columna.Trim());
            }

            for (int i = 1; i < lineas.Length; i++)
            {
                string[] celdas = lineas[i].Split(delimitador);

                if (celdas.Length == columnas.Length)
                {
                    dtgDatos.Rows.Add(celdas);
                }
            }
        }


        private void CargarDesdeXML(string ruta)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(ruta);

            if (ds.Tables.Count > 0)
            {
                dtgDatos.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("El archivo XML no contiene datos reconocibles.");
            }
        }

        private string ObtenerNombreTabla()
        {
            if (string.IsNullOrWhiteSpace(txtNombreTabla.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre para la tabla.", "Nombre requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreTabla.Focus();
                    return "";
                }
                return txtNombreTabla.Text;
        }

        private void btnGuardarDB_Click(object sender, EventArgs e)
        {
            if (dtgDatos.Rows.Count == 0 || dtgDatos.Columns.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreTabla = ObtenerNombreTabla();
            if (string.IsNullOrWhiteSpace(nombreTabla))
            {
                return;
            }

            tableName = nombreTabla;

            try
            {
                // Verificar si la base de datos existe, si no, crearla
                CrearBaseDeDatosSiNoExiste();

                // Crear la tabla si no existe
                CrearTablaSiNoExiste();

                // Guardar los datos en la tabla
                GuardarDatosEnTabla();

                MessageBox.Show($"Datos guardados con éxito en la tabla '{tableName}'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearBaseDeDatosSiNoExiste()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
        }

        private void CrearTablaSiNoExiste()
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                string createTableQuery = $"CREATE TABLE IF NOT EXISTS {tableName} (";

                createTableQuery += "ID INTEGER PRIMARY KEY AUTOINCREMENT, ";

                for (int i = 0; i < dtgDatos.Columns.Count; i++)
                {
                    string columnName = dtgDatos.Columns[i].Name.Replace(" ", "_");

                    createTableQuery += $"{columnName} TEXT";

                    if (i < dtgDatos.Columns.Count - 1)
                    {
                        createTableQuery += ", ";
                    }
                }

                createTableQuery += ")";

                // Ejecutar la creación de la tabla
                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private void GuardarDatosEnTabla()
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = $"INSERT INTO {tableName} (";

                        for (int i = 0; i < dtgDatos.Columns.Count; i++)
                        {
                            string columnName = dtgDatos.Columns[i].Name.Replace(" ", "_");
                            insertQuery += columnName;

                            if (i < dtgDatos.Columns.Count - 1)
                            {
                                insertQuery += ", ";
                            }
                        }

                        insertQuery += ") VALUES (";

                        for (int i = 0; i < dtgDatos.Columns.Count; i++)
                        {
                            insertQuery += $"@p{i}";

                            if (i < dtgDatos.Columns.Count - 1)
                            {
                                insertQuery += ", ";
                            }
                        }

                        insertQuery += ")";

                        using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                        {
                            for (int i = 0; i < dtgDatos.Columns.Count; i++)
                            {
                                cmd.Parameters.Add(new SQLiteParameter($"@p{i}"));
                            }

                            // Insertar cada fila de datos
                            foreach (DataGridViewRow row in dtgDatos.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int i = 0; i < dtgDatos.Columns.Count; i++)
                                    {
                                        var value = row.Cells[i].Value;
                                        cmd.Parameters[$"@p{i}"].Value = value ?? DBNull.Value;
                                    }

                                    // Ejecutar la inserción
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                conn.Close();
            }
        }
    }
}

