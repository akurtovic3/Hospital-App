using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    sealed public class Anamneza
    {
        private string ranijebolesti;
        private string alergije;
        private string sadasnjebolesti;
        private string porodicnostanje;
        private string zakljucakdoktora;
        public string Ranijebolesti { get => ranijebolesti; set => ranijebolesti = value; }
        public string Alergije { get => alergije; set => alergije = value; }
        public string Sadasnjebolesti { get => sadasnjebolesti; set => sadasnjebolesti = value; }
        public string Porodicnostanje { get => porodicnostanje; set => porodicnostanje = value; }
        public string Zakljucakdoktora { get => zakljucakdoktora; set => zakljucakdoktora = value; }

        public Anamneza(string ranijebolesti, string alergije, string sadasnjebolesti, string porodicnostanje, string zakljucakdoktora)
        {
            this.Ranijebolesti = ranijebolesti;
            this.Alergije = alergije;
            this.Sadasnjebolesti = sadasnjebolesti;
            this.Porodicnostanje = porodicnostanje;
            this.Zakljucakdoktora = zakljucakdoktora;
        }
        public Anamneza()
        {
        }
        public string ispisiAnamnezu()
        {
            return "Anamneza:\n    Ranije bolesti: " + ranijebolesti + "\n    Alergije: " + alergije + "\n    Sadasnje bolesti: " + sadasnjebolesti + "\n    Porodicno stanje: " + porodicnostanje + "\n    Zakljucak doktora: " + zakljucakdoktora;
        }
    }
}
