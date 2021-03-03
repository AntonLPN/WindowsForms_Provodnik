using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Provodnik
{
    public partial class Form1 : Form
    {
        private TreeNode driveNode;
        private string adres;
        private string[] folder;
        public Form1()
        {
            InitializeComponent();
            adres = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                driveNode = new TreeNode();
                driveNode.Text = driveInfo.Name;
                driveNode.Name = driveInfo.Name;
                //добавляем диски
                this.treeView1.Nodes.Add(driveNode);

                folder = Directory.GetDirectories(driveInfo.Name);
                //добавляем папки 
                for (int i = 0; i < folder.Length; i++)
                {
                    this.treeView1.Nodes[driveNode.Name].Nodes.Add(folder[i]);

                }

            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            this.treeView2.Nodes.Clear();

            string path = this.treeView1.SelectedNode.Text;
            //добаляем в текст бокс полный путь
            adres = path;
            this.textBox1.Text = adres;

            string[] files = Directory.GetFiles(path);
            string[] folder2 = Directory.GetDirectories(path);

            this.treeView2.Nodes.Add("РАЗДЕЛ ПАПКИ");
            if (folder2.Length == 0)
            {
                this.treeView2.Nodes.Add("Папки отсутвуют");
            }
            else
            {
                for (int i = 0; i < folder2.Length; i++)
                {
                    this.treeView2.Nodes.Add(folder2[i]);

                }
            }


            string[] file = Directory.GetFiles(path);
            this.treeView2.Nodes.Add("РАЗДЕЛ ФАЙЛЫ");
            if (file.Length == 0)
            {
                this.treeView2.Nodes.Add("Файлы отсутвуют");
            }
            else
            {
                for (int i = 0; i < file.Length; i++)
                {
                    this.treeView2.Nodes.Add(file[i]);
                }
            }
        }

        private void treeView2_DoubleClick(object sender, EventArgs e)
        {
            string path2 = this.treeView2.SelectedNode.Text;
            //заносим в текст бокс адрес
            this.adres = path2;
            this.textBox1.Text = adres;
            string[] files3 = Directory.GetFiles(path2);
            string[] folder3 = Directory.GetDirectories(path2);
            this.treeView2.Nodes.Clear();
            this.treeView2.Nodes.Add("РАЗДЕЛ ПАПКИ");
            if (folder3.Length == 0)
            {
                this.treeView2.Nodes.Add("Папки отсутвуют");
            }
            else
            {
                for (int i = 0; i < folder3.Length; i++)
                {
                    this.treeView2.Nodes.Add(folder3[i]);

                }
            }


            string[] file = Directory.GetFiles(path2);
            this.treeView2.Nodes.Add("РАЗДЕЛ ФАЙЛЫ");
            if (file.Length == 0)
            {
                this.treeView2.Nodes.Add("Файлы отсутвуют");
            }
            else
            {
                for (int i = 0; i < files3.Length; i++)
                {
                    this.treeView2.Nodes.Add(file[i]);
                }
            }
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void programInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Property of Kudriashov Anton\nCreated 15.11.2020\nHome work #7", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void closeProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаем папку
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            string adres2 = folderBrowserDialog.SelectedPath;
            if (adres2!=string.Empty)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(adres2);

                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                //заносим в текст бокс адрес
                //если папка создана в той дериктори которое отображает второе окно то отображаем изменение
                //НЕМНОГО ЗАКОЛХОЗИЛ НАДО БЫЛО ЭТО СДЕЛАТЬ ОТДЕЛЬНЫМ МЕТОДОМ ЧТО БЫ НЕ ПЕРЕПИСЫВАТЬ КОД НО ДЛЯ ПРИМЕРА СОЙДЕТ
                this.textBox1.Text = adres;
                string[] files3 = Directory.GetFiles(adres);
                string[] folder3 = Directory.GetDirectories(adres);
                this.treeView2.Nodes.Clear();
                this.treeView2.Nodes.Add("РАЗДЕЛ ПАПКИ");
                if (folder3.Length == 0)
                {
                    this.treeView2.Nodes.Add("Папки отсутвуют");
                }
                else
                {
                    for (int i = 0; i < folder3.Length; i++)
                    {
                        this.treeView2.Nodes.Add(folder3[i]);

                    }
                }


                string[] file = Directory.GetFiles(adres);
                this.treeView2.Nodes.Add("РАЗДЕЛ ФАЙЛЫ");
                if (file.Length == 0)
                {
                    this.treeView2.Nodes.Add("Файлы отсутвуют");
                }
                else
                {
                    for (int i = 0; i < files3.Length; i++)
                    {
                        this.treeView2.Nodes.Add(file[i]);
                    }
                }
            }
          
            
            


           
        }
    }
}
