using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace projetoCsvHelper.Model
{
    public class Import
    {
        //com classe
        public void lerCsvComClasse()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "input", "cid.csv");

            var fi = new FileInfo(path);

            if (!fi.Exists)
            {
                throw new FileNotFoundException($"Arquivo {path} Não Existe...");
            }

            using (var sr = new StreamReader(fi.FullName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture) {
                    Delimiter = ";"
                };
                var csvReader = new CsvReader(sr, csvConfig);

                var registros = csvReader.GetRecords<ImportCID>();
                foreach (var registro in registros)
                {
                    Console.WriteLine($"CID: {registro.CID}");
                    Console.WriteLine($"Descrição: {registro.DESCR}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }

        // sem classe
        public void lerCsvDynamic() {
            var path = Path.Combine(Environment.CurrentDirectory, "input", "cid.csv");

            var fi = new FileInfo(path);

            if (!fi.Exists)
            {
                throw new FileNotFoundException($"Arquivo {path} Não Existe...");
            }

            using (var sr = new StreamReader(fi.FullName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture);
                var csvReader = new CsvReader(sr, csvConfig);

                var registros = csvReader.GetRecords<dynamic>();
                foreach (var registro in registros)
                {
                    Console.WriteLine($"CID: {registro.CID}");
                    Console.WriteLine($"Descrição: {registro.DESCR}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
    }
}
