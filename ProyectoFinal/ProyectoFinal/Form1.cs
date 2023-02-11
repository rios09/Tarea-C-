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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hidePanels();
        }

        private void hidePanels()
        {
            panelSubMedia1.Visible= false;
        }//OcultarPaneles

        private void hideSubMenus()
        {
           if( panelSubMedia1.Visible== true)
            {
                panelSubMedia1.Visible= false;
            }
           
        }//Ocultar Botones

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenus();
                subMenu.Visible = true;
            } else 
                subMenu.Visible = false;
        }//Cargar Botones

        private void btnMedia_Click(object sender, EventArgs e)//Mostar botones 1
        {
            showSubmenu(panelSubMedia1);
        }

        private void openChildForms(object childForm)// funcion para abrir formularios dentro del un panel contenedor
        {
            if (this.panelContainer.Controls.Count > 0)

            this.panelContainer.Controls.RemoveAt(0);         
                Form cf =childForm as Form;
            cf.TopLevel = false;
            cf.Dock= DockStyle.Fill;
            this.panelContainer.Controls.Add(cf);
            this.panelContainer.Tag = cf;
            cf.Show();
            
        }
        private void button11_Click(object sender, EventArgs e) //Agregar Estudiante
        {
            openChildForms(new AddStudentForm());              
        }
        
        private void button10_Click(object sender, EventArgs e) //Agregar Profesor
        {
            openChildForms(new AddTeacherForm());
        }


        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Exit;
            Exit = MessageBox.Show("¿Seguro deseas Salir?", " Cerrar App", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Exit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }//Salir del App

    }
}
