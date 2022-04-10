using projetoCsvHelper.Model;

namespace projetoCsvHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Import import = new Import();
            //import.lerCsvDynamic();
            import.lerCsvComClasse();

            Export export = new Export();
            export.escreverCsv();
        }
    }
}
