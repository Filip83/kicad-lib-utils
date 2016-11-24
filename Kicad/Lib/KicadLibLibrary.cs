using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows;

namespace Kicad.Lib
{
    public class KicadLibLibrary
    {
        public List<KicadLibComponent> Components {get;set;}
        //public List<KicadLibDocu> Documentation { get; set; }
        public String FileName { get; set; }
        public String Version { get; set; }
        public String Version2 { get; set; }

        public KicadLibLibrary()
        {
            Components = new List<KicadLibComponent>();
            //Documentation = new List<KicadLibDocu>();
        }

        public KicadLibLibrary(String fileName)
        {
            ReadFile(fileName);
        }

        public void Clear()
        {
            Version = "EESchema-LIBRARY Version 2.3";
            Version2 = "EESchema-DOCLIB  Version 2.0";
            Components.Clear();
        }
        
        public void ReadFile(String fileName)
        {
            FileName = fileName;
            StreamReader libFile = new StreamReader(FileName);
            Version = libFile.ReadLine();
            Components.Clear();
            do
            {
                KicadLibComponent component = new KicadLibComponent();
                if(component.Parse(libFile))
                    Components.Add(component);
            } while (!libFile.EndOfStream);
            libFile.Close();
            //read documentation file

            FileInfo fInfo = new FileInfo(fileName);
            String docuFile = fInfo.Directory + "\\" + fInfo.Name.Replace(fInfo.Extension,".dcm");
            if (File.Exists(docuFile))
            {
                libFile = new StreamReader(docuFile);
                Version2 = libFile.ReadLine();
                //Documentation.Clear();
                do
                {
                    KicadLibDocu component = new KicadLibDocu();
                    if (component.Parse(libFile))
                    {
                        // Documentation.Add(component);
                        foreach (KicadLibComponent cmp in Components)
                        {
                            if (cmp.Definition.Name == component.CmpName)
                                cmp.Documentation = component;
                        }
                    }
                } while (!libFile.EndOfStream);
                libFile.Close();
            }
            
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter(FileName);
            writer.WriteLine(Version);
            foreach (KicadLibComponent component in Components)
            {
                String outstr = component.ToString();
                writer.Write(outstr);
            }
            writer.Close();

            // Save douc file
            FileInfo fInfo = new FileInfo(FileName);
            String docuFile = fInfo.Directory + "\\" + fInfo.Name.Replace(fInfo.Extension, ".dcm");
            writer = new StreamWriter(docuFile);
            writer.WriteLine(Version2);
            foreach (KicadLibComponent component in Components)
            {
                if (component.Documentation != null)
                {
                    String outstr = component.Documentation.ToString();
                    writer.Write(outstr);
                }
            }
            writer.Close();
        }

        public void Save(String fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(Version);
            foreach (KicadLibComponent component in Components)
            {
                String outstr = component.ToString();
                writer.Write(outstr);
            }
            writer.Close();

            // Save douc file
            FileInfo fInfo = new FileInfo(fileName);
            String docuFile = fInfo.Directory + "\\" + fInfo.Name.Replace(fInfo.Extension, ".dcm");
            writer = new StreamWriter(docuFile);
            writer.WriteLine(Version2);
            foreach (KicadLibComponent component in Components)
            {
                if (component.Documentation != null)
                {
                    String outstr = component.Documentation.ToString();
                    writer.Write(outstr);
                }
            }
            writer.Close();
        }

        public void AddComponent(KicadLibComponent component)
        {
            Components.Add(component);
        }

        public void RemoveAt(int idx)
        {
            Components.RemoveAt(idx);
        }
    }
}
