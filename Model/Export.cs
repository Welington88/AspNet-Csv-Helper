using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace projetoCsvHelper.Model
{
    public class Export
    {
        //com classe
        public void escreverCsv()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "output");

            var lista = new List<ImportCID>() {
                new ImportCID() {
                    CID = "A00",
                    DESCR = "A00   Colera"
                },
                new ImportCID() {
                    CID = "A01",
                    DESCR = "A01   Febres tifoide e paratifoide"
                }
            };

            var di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }

            path = Path.Combine(path,"cid.csv");

            using (var sw = new StreamWriter(path))
            {
                using (var csvWrite = new CsvWriter(sw,CultureInfo.GetCultureInfo("pt-br"))) {
                    csvWrite.WriteRecords(lista);
                }
            }
        }
    }
}
