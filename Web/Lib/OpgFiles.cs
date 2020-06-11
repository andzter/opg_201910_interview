using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace opg_201910_interview.Lib
{
    public static class OpgFiles
    {
        public static List<string> ClientFiles(string clientId, string path)
        {
            var lstFiles = new List<string>();
            var rootFolder = Directory.GetCurrentDirectory();
            var filePath = Path.GetFullPath(Path.Combine(rootFolder, path));
            var configPath = Path.GetFullPath(Path.Combine(rootFolder, "ClientSettings"));

            configPath = Path.GetFullPath(Path.Combine(configPath, $"{clientId}.json"));

            var regFormat = "";
            var validfilename = "";
            string[] validfiles;

            using (StreamReader r = new StreamReader(configPath))
            {
                string json = r.ReadToEnd();
                ClientConfig ro = JsonConvert.DeserializeObject<ClientConfig>(json);
                regFormat = ro.Format;
                validfilename = string.Join(",", ro.Files);
                validfiles = ro.Files;
            }

            var files = Directory.GetFiles(filePath);

            

            foreach ( var file in files)
            {
                var f = Path.GetFileName(file);

                if (Regex.Match(f, regFormat, RegexOptions.IgnoreCase).Success)
                {
                    var fname = f.Split('-')[0].Split('_')[0].ToLower();

                    if (validfilename.ToLower().Contains(fname))
                    {
                        int i = Array.IndexOf(validfiles, fname);
                        var dt = f.ToLower().Replace(fname, "").Replace(".xml", "");
                        lstFiles.Add(string.Format("{0}|{1}|{2}", i.ToString(),dt,f));
                    }
                }
            }

            lstFiles.Sort();
            var retFiles = new List<string>();
            foreach ( var f in lstFiles)
            {
                retFiles.Add(f.Split('|')[2]);
            }

            return retFiles;
        }

    }
}
