using SpotiUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpotiBackend
{
    public abstract class DbContext
    {
        string _path; // Solitamente la configurazione per accedere al DataSrc
        protected DbContext(string path)
        {
            _path = path;
        }
        public DbContext()
        {

        }
        protected List<T> ReadFromCsv<T>(string path) where T : class, new()
        {
            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                return CreateObject<T>(lines);
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Errore durante la lettura del file CSV.");
                Logger.LogError(ex);
                throw new Exception("Errore durante la lettura del file CSV.", ex);
            }
        }
        public static List<T> CreateObject<T>(List<string> lines) where T : class, new()
        {
            List<T> list = new List<T>();
            string[] headers = lines.ElementAt(0).Split(',');
            lines.RemoveAt(0); // Rimuovo la prima riga (nome colonne) del mio datasource
            bool corretto = false;
            bool p = true;
            T entry = new T(); // Creo istanza per poter estrarre le properties
            PropertyInfo[] prop = entry
                            .GetType() // Prendo il tipo
                                    .GetProperties(); // Prendo le sue properties 

            if (true)
            {
                for (int i = 0; i < headers.Length; i++) // Ciclo le properties dell'oggetto  T
                {
                    PropertyInfo prp = entry.GetType().GetProperty(headers[i]);
                    if (prp is not null) // ciclo le colonne e le properties insieme
                    {
                        corretto = true;
                    }
                    else p = false; // S eha fallito almeno una volta, setto a false
                }
            }
            if (corretto && p)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    int j = 0;
                    string[] columns = lines[i].Split(',');
                    entry = new T();

                    foreach (var item in headers)
                    {


                        var e = entry.GetType().GetProperty(headers[j]);
                        if (e != null)
                        {
                            Type targetType = Nullable.GetUnderlyingType(e.PropertyType) ?? e.PropertyType;

                            //var t = Convert.ChangeType(col, entry.GetType().GetProperty(headers[j].Trim()).PropertyType);
                            //e.SetValue(entry, t);


                            // Custom conversion for nullable types  
                            var isNull = columns[j] == null ? true : false;
                            var isEmpty = string.IsNullOrEmpty(columns[j]) ? true : false;
                            var data = columns[j];

                            object convertedValue = (columns[j] == null || columns[j].Trim().Equals(string.Empty)) ? null : Convert.ChangeType(columns[j], targetType);
                            e.SetValue(entry, convertedValue);
                        }
                        j++;
                    }
                    list.Add(entry);

                }

            }
            else
            {
                Console.WriteLine("le proprietà nel file non corrispondono a proprietà oggetto");
                Logger.LogInfo("La struttura del file CSV non è corretta.");
                throw new InvalidOperationException("La struttura del file CSV non è corretta.");
            }

            return list;
        }
        public void WriteData<T>(IEnumerable<T> data)
        {

            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = data.GetEnumerator().GetType().GetProperties();

            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
            foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in data)
            {

                sb = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(_path, list);
        }
        public void WriteExistData<T>(IEnumerable<T> data)
        {

            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = data.GetEnumerator().GetType().GetProperties();

            foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in data)
            {

                sb = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(_path, list);
        }

    }
}
