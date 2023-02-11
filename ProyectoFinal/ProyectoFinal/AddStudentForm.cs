using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentGrid.Rows.Add(studentIdtxt.Text,studentNametxt.Text,studentLasttxt.Text,studentDobtxt.Text,
                studentAddresstxt.Text,studentPhonetxt.Text,gradotxt.Text);
            cleanFields();
        }

        private void cleanFields()
        {
            studentIdtxt.Clear(); studentNametxt.Clear(); studentLasttxt.Clear(); studentDobtxt.Clear();
            studentAddresstxt.Clear(); studentPhonetxt.Clear(); gradotxt.Clear();
        }
        private void deleteItem()
        {
            foreach (DataGridViewRow item in this.studentGrid.SelectedRows)
            {
                studentGrid.Rows.RemoveAt(item.Index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Delete;
            Delete = MessageBox.Show("¿Seguro deseas Eliminar?", " Borrar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Delete == DialogResult.Yes)
            {
                deleteItem();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Delete;
            Delete = MessageBox.Show("¿Seguro deseas Resetear la Tabla?", " Borrar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Delete == DialogResult.Yes)
            {
                deleteItem();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            studentGrid.SelectAll();
            DataObject copydata = studentGrid.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        Bitmap bitmap;
        private void button4_Click(object sender, EventArgs e)
        {
            int height = studentGrid.Height;
            studentGrid.Height = studentGrid.RowCount * studentGrid.RowTemplate.Height * 2;
            bitmap = new Bitmap(studentGrid.Width, studentGrid.Height);
            studentGrid.DrawToBitmap(bitmap, new Rectangle(0,0, studentGrid.Width, studentGrid.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            studentGrid.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap,0,0);
        }
    }
}
