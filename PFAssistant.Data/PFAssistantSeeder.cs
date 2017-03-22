using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFAssistant.Data
{
    public class PFAssistantSeeder
    {
        PFAssistantContext _context;

        public PFAssistantSeeder(PFAssistantContext context)
        {
            _context = context;
        }

        private void SeedSpells()
        {
            // TODO: update file location
            var rawData = ParseXls(@"..\..\spell_full.xls", "Updated_29Jan2017");
            var rows = rawData.Rows.Cast<DataRow>();
        }

        public static DataTable ParseXls(string path, string sheet)
        {
            var fileName = string.Format(path, Directory.GetCurrentDirectory());
            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", fileName);
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}
