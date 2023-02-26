using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace Test_cameras
{
    class Strategy
    {
        Transformer transformer;
        HttpRequester httpRequester;
        public CancellationTokenHolder tokenHolder;

        public Strategy()
        {
            transformer = new Transformer();
            httpRequester = new HttpRequester();
            tokenHolder = new CancellationTokenHolder();
        }

        public async Task<List<Camera>> GetSortedCameraList(HttpAuthData authData)
        {
            if (authData == null)
            {
                throw new Exception("Нет даннх для получения списка камер при аутентификации на сервере");
            }                

            tokenHolder.TokenRefresh();
            HttpResponseMessage httpResponse = await httpRequester.ReponseByAuth(authData, tokenHolder.GetToken());
            List<Camera> cameras = await transformer.HttpResponseToCameraList(httpResponse, tokenHolder.GetToken());
            cameras.Sort(Camera.CompareByName);

            return cameras;
        }

        public void SaveCamerasToFile(string path, List<Camera> cameras)
        {
            if (path == null)
            {
                throw new Exception("Несозданный путь к файлу");
            }                
            if (cameras == null)
            {
                throw new Exception("Нет камер к записи в файл");
            }                

            var textToFile = new StringBuilder();
            foreach (Camera cam in cameras)
            {
                textToFile.Append(cam.ToStringForTxtFile());
            }

            File.WriteAllText(path, textToFile.ToString());
        }

        public List<Camera> LoadCamerasFromFile(string path)
        {
            if (path == null)
            {
                throw new Exception("Попытка открытия файла по нечитаемому адресу");
            }

            if (File.Exists(path))
            {
                var cameras = new List<Camera>();

                foreach (string line in File.ReadLines(path))
                {
                    if (FileLineCheck(line))
                    {
                        string[] cameraProps = line.Split('@');
                        cameras.Add(new Camera(cameraProps));
                    }
                    else
                    {
                        throw new Exception("Не удалось прочесть фалй");
                    }
                }

                return cameras;
            }
            else
            {
                throw new Exception("Попытка открытия несущестующего файла");
            }
        }

        private bool FileLineCheck(string line)
        {
            if (line.Contains('@'))
                return true;

            return false;
        }
    }
}
