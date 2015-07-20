using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;

namespace AdmToSap
{
    class JournalEntryDb
    {
        ConnectDb con = new ConnectDb();
        public List<JournalEntry> getjournalEntry()
        {

            OdbcConnection conexion = con.getConnect();
            List<  JournalEntry> listjentry = new List<JournalEntry>();
            Empresa empresa = new Empresa();
            empresa = new EmpresaDb().getEmpresaSqlite();

                        OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = " select cod_empresa, cod_sucursal, caja, tipo_pago, monto, fecha_em, glosa "
                                + " from doc_clientes "
                                + " where cod_empresa = " + empresa.cod_empresa
                                + " and cod_sucursal = " + empresa.cod_sucursal
                                + " and tipo_pago in (15,16) "
                                + " and fecha_cierre is NULL; ";
            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                JournalEntry jentry = new JournalEntry();
                jentry.TaxDate = reader.GetDateTime(reader.GetOrdinal("fecha_em"));
                jentry.Amount = reader.GetDouble(reader.GetOrdinal("monto")).ToString();
                jentry.AccountC = "110401002"; // TODO
                jentry.AccountD = "110401002"; // TODO
                jentry.Reference2 = reader.GetString(reader.GetOrdinal("glosa")) ;
                jentry.Memo = reader.GetString(reader.GetOrdinal("glosa"));
                jentry.cod_empresa = empresa.cod_empresa;
                jentry.cod_sucursal = empresa.cod_sucursal;
                jentry.tipo_pago = reader.GetByte(reader.GetOrdinal("TIPO_PAGO"));

                listjentry.Add(jentry);
            }


            return listjentry;
            
        }

        public void updateJEntry(int empresa, int cod_sucursal)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            update.Connection = conexion;

            update.CommandText = "update doc_clientes "
                                 + " set fecha_cierre = now()"
                                 + " where cod_empresa=" + empresa
                                 + " and cod_sucursal=" + cod_sucursal
                                 + " and tipo_pago in (15,16)"
                                 + " and fecha_cierre IS NULL;";


            OdbcDataReader up = update.ExecuteReader();

        }
    }
}
