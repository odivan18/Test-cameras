using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_cameras
{
    public class Camera
    {
        public string name { get; set; }
        public string id { get; set; }

        public Camera()
        {
            name = "defaultName";
            id = "defaultID";
        }
        public Camera(string newName, string newID)
        {
            name = newName;
            id = newID;
        }
        public Camera(string[] props)
        { 
            name = props[(int)DataGridColumns.CameraName];
            id = props[(int)DataGridColumns.ID];
        }

        public string ToStringForTxtFile()
        {
            if ((id == null) || (name == null))
                throw new Exception("Ошибка перефода камеры в текстоый формат для файла");

            var textToFile = new StringBuilder();
            textToFile.Append(id).Append("@").Append(name).Append('\n');

            return textToFile.ToString();
        }

        
    }
}
