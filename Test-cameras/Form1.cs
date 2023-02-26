using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

using System.IO;

//Налюбое действие думать какая сущность ее вполняет, и, если ее нет, создать новый класс

namespace Test_cameras
{
    public enum DataGridColumns
    {
        ID,
        CameraName
    }

    public partial class Form1 : Form
    {
        string httpAddress = "http://suv.kaminplus.ru:21012/rsapi/cameras";
        string localFilePath = "D:/учебка/рабочая/Test-cameras2/Test-cameras/fileek.txt";

        CameraShowStrategy strategy;

        public Form1()
        {
            InitializeComponent();

            strategy = new CameraShowStrategy();

            serverInfoLabel.Text = $"Сервер \n{httpAddress}";

            cameraListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            InitialTryFill();
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                connectionInfoLabel.Text = "Подключение";
                SetButtonsPresableStatus(false);

                FillDataGrid(await strategy.GetSortedCameraList(new HttpAuthData(loginTextBox.Text, passworTextBox.Text, httpAddress)));

                connectionInfoLabel.Text = "Готово";
            }
            catch(Exception ex)
            {
                connectionInfoLabel.Text = "Ошибка";
                MessageBox.Show(ex.Message);
            }
            finally
            {                
                SetButtonsPresableStatus(true);
            }      
        }

        //блокировка всех кнопок на ремя подключения
        private void SetButtonsPresableStatus(bool status)
        {
            foreach (Control control in this.Controls)
                if (control.Name != cancelConnectButton.Name)
                    control.Enabled = status;
        }

        private void FillDataGrid(List<Camera> cameras)
        {
            if (cameras == null)
                throw new Exception("Не удалось заполнить таблицу, т.к массив камер не создан");

            cameraListDataGridView.Rows.Clear();

            foreach (Camera camera in cameras)
            {
                cameraListDataGridView.Rows.Add(camera.id, camera.name);
            }

            cameraListDataGridView.Rows[0].Selected = false;
        }

        private void cancelConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                strategy.tokenHolder.Cancel();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                strategy.SaveCamerasToFile(localFilePath, FillCameraListFromPickedInDG());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<Camera> FillCameraListFromPickedInDG()
        {
            if (cameraListDataGridView.Rows.Count == 0)
                throw new Exception("Таблица пуста");

            var cameras = new List<Camera>();

            if (cameraListDataGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < cameraListDataGridView.Rows.Count; i++)
                {
                    if (cameraListDataGridView.Rows[i].Selected)
                    {
                        string id = cameraListDataGridView.Rows[i].Cells[(int)DataGridColumns.ID].Value.ToString();
                        string name = cameraListDataGridView.Rows[i].Cells[(int)DataGridColumns.CameraName].Value.ToString();

                        cameras.Add(new Camera(name, id));
                    }
                }
            }
            else
            {
                for (int i = 0; i < cameraListDataGridView.Rows.Count; i++)
                {
                    string id = cameraListDataGridView.Rows[i].Cells[(int)DataGridColumns.ID].Value.ToString();
                    string name = cameraListDataGridView.Rows[i].Cells[(int)DataGridColumns.CameraName].Value.ToString();

                    cameras.Add(new Camera(name, id));
                }
            }

            return cameras;
        } 
        
        private void InitialTryFill()
        {
            try
            {
                FillDataGrid(strategy.LoadCamerasFromFile(localFilePath));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            cameraListDataGridView.Rows[0].Selected = false;
        }
    }    
}
