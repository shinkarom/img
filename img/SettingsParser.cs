using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace img
{

    public struct Path
    {
        public string Name;
        public bool IsActive;

        public Path(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }
    }

    public class ImgSettings
    {
        public List<Path> Paths;

        public ImgSettings()
        {
            Paths = new List<Path>();
        }
    }

    public class SettingsParser
    {
        private string FileName;

        public ImgSettings sets;

        public void ProcessToController(ImgController contr)
        {
            foreach (var item in sets.Paths)
                if (item.IsActive)
                    contr.AddPath(item.Name);
        }

        public void LoadFromFile(string filename)
        {
            this.FileName = filename;
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            var pathslist = doc.DocumentElement.SelectNodes("//paths/path");
            foreach (XmlNode curpath in pathslist)
            {
                var p = new Path(curpath.InnerText, curpath.Attributes.GetNamedItem("active").Value == "true");
                sets.Paths.Add(p);

            }
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            var declx = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declx);
            var rootx = doc.CreateElement("settings");
            doc.AppendChild(rootx);
            var pathsx = doc.CreateElement("paths");
            rootx.AppendChild(pathsx);
            foreach (var path in sets.Paths)
            {
                var pathx = doc.CreateElement("path");
                pathx.SetAttribute("active", path.IsActive ? "true" : "false");
                pathx.InnerText = path.Name;
                pathsx.AppendChild(pathx);
            }
            doc.Save(FileName);
        }

        public SettingsParser(string filename)
        {
            sets = new ImgSettings();

            LoadFromFile(filename);
        }

        public SettingsParser()
        {
            sets = new ImgSettings();
        }
    }
}
