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
    public partial class AddTeacherForm : Form
    {
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            teacherGrid.Rows.Add(classtxt.Text,teachernamestxt.Text,teacherlasttxt.Text,teacherdobtxt.Text,
                                   teacheraddresstxt.Text,teacherphonetxt.Text,teacheridtxt.Text);
          cleanfield();
        }

        private void cleanfield()
        {
            classtxt.Clear();
            teachernamestxt.Clear();
            teacherlasttxt.Clear();
            teacherdobtxt.Clear();
            teacheraddresstxt.Clear();
            teacherphonetxt.Clear();
            teacheridtxt.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Delete;
            Delete = MessageBox.Show("¿Seguro deseas Eliminar?", " Borrar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Delete == DialogResult.Yes)
            {
                deleteItem();
            }

        }

        private void deleteItem()
        {
            foreach (DataGridViewRow item in this.teacherGrid.SelectedRows)
            {
                teacherGrid.Rows.RemoveAt(item.Index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Delete;
            Delete = MessageBox.Show("¿Seguro deseas Resetear la Tabla?", " Borrar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Delete == DialogResult.Yes)
            {
                deleteItem();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            importing();
        }

        private void importing()
        {
            teacherGrid.SelectAll();
            DataObject copydata = teacherGrid.GetClipboardContent();
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
        private void button3_Click(object sender, EventArgs e)
        {
            int height = teacherGrid.Height;
            teacherGrid.Height = teacherGrid.RowCount * teacherGrid.RowTemplate.Height * 2;
            bitmap = new Bitmap(teacherGrid.Width, teacherGrid.Height);
            teacherGrid.DrawToBitmap(bitmap, new Rectangle(0, 0, teacherGrid.Width, teacherGrid.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            teacherGrid.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
