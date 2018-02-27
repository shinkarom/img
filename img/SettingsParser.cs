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
        public bool IsEnabled;

        public Path(string name, bool isEnabled)
        {
            Name = name;
            IsEnabled = isEnabled;
        }
    }

    public class ImgSettings
    {
        public List<Path> Paths;
        public bool DisableBack = false;
        public bool ShowToolTip = false;

        public ImgSettings()
        {
            Paths = new List<Path>();
        }
    }

    public class SettingsParser
    {
        private const string disablebackstr = "disableback";
        private const string showtooltipstr = "showtooltip";
        public string FileName;

        public ImgSettings sets;

        public void ProcessToController(ImgController contr)
        {
            foreach (var item in sets.Paths)
                if (item.IsEnabled)
                    contr.AddPath(item.Name);
        }

        private bool LoadOption(XmlNode option) => option.Attributes.GetNamedItem("value").Value == "true";

        private bool NodeIsOption(XmlNode node, string optionname) => node.Attributes.GetNamedItem("name").Value == optionname;

        public void LoadFromFile(string filename)
        {
            this.FileName = filename;
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            var pathslist = doc.DocumentElement.SelectNodes("//path");
            foreach (XmlNode curpath in pathslist)
            {
                var p = new Path(curpath.InnerText, curpath.Attributes.GetNamedItem("enabled").Value == "true");
                sets.Paths.Add(p);

            }
            var optionsx = doc.DocumentElement.SelectNodes("//option");
            foreach (XmlNode item in optionsx)
            {
                if (NodeIsOption(item, disablebackstr))
                    sets.DisableBack = LoadOption(item);
                if (NodeIsOption(item, showtooltipstr))
                    sets.ShowToolTip = LoadOption(item);
            }
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            var declx = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(declx);
            var rootx = doc.CreateElement("settings");
            doc.AppendChild(rootx);
            foreach (var path in sets.Paths)
            {
                var pathx = doc.CreateElement("path");
                pathx.SetAttribute("enabled", path.IsEnabled ? "true" : "false");
                pathx.InnerText = path.Name;
                rootx.AppendChild(pathx);
            }
            var allowbackx = doc.CreateElement("option");
            allowbackx.SetAttribute("name", disablebackstr);
            allowbackx.SetAttribute("value", sets.DisableBack ? "true" : "false");
            rootx.AppendChild(allowbackx);
            //
            var showtooltipx = doc.CreateElement("option");
            showtooltipx.SetAttribute("name", showtooltipstr);
            showtooltipx.SetAttribute("value", sets.ShowToolTip ? "true" : "false");
            rootx.AppendChild(showtooltipx);
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
