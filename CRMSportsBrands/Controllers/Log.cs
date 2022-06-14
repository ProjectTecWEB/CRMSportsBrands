using System;
using System.IO;
namespace CRMSportsBrands.Controllers
{
    public class Log
    {
        private string Path = "";
        

        public Log(string Path)
        {
            this.Path = Path;
        }

        public void Add(string sLog)
        {
            createDirectory();
            string nombre = getNameFile();
            string cadena = "";

            cadena += DateTime.Now + " - " + sLog + Environment.NewLine;
            StreamWriter sw = new StreamWriter(Path+"/"+nombre,true);
            sw.Write(cadena);
            sw.Close();
        }

        #region HELPER
        private string getNameFile() 
        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Day + "_" + DateTime.Now.Month + DateTime.Now.Year + ".txt";
            return nombre;
        }
        private void createDirectory()
        {
            try
            {
                if (Directory.Exists(Path))
                    Directory.CreateDirectory(Path);

                
            }
            catch(DirectoryNotFoundException ex)
            {
            
                    throw new Exception(ex.Message);
                   
            }
        }
        #endregion
    }
}
