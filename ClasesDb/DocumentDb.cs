using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data.SQLite;


namespace AdmToSap
{
    class DocumentDb
    {
        ConnectDb con = new ConnectDb();
        public List<Document> getDocuments()
        {
            OdbcConnection conexion = con.getConnect();
            List<Document> docs = new List<Document>();
            Empresa empresa = new Empresa();
            empresa = new EmpresaDb().getEmpresaSqlite();
         
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas "
            + "where cod_empresa= "+ empresa.cod_empresa+" and cod_sucursal= "+empresa.cod_sucursal+" and tipo_cargo in (1,2,4,6,7,32,33,34,38,39,41,52,56) "
            + "and tipo_abono = 0 and anulada='N' and fecha_cierre IS NULL "
            + "order by tipo_cargo, nro_cargo;";
            OdbcDataReader reader = select.ExecuteReader();
            // cargo facturas
            while (reader.Read())
            {
                Document doc = cabezalDoc(reader);
                docs.Add(doc);
            }

            // Cargo las Notas de  Credito
            OdbcCommand select2 = new OdbcCommand();
            select2.Connection = conexion;
            select2.CommandText = "select * from cabezalventas "
            + "where cod_empresa= " + empresa.cod_empresa + " and cod_sucursal_abono = " + empresa.cod_sucursal 
            + " and tipo_abono in (22,61) and fecha_cierre IS NULL "
            + "and tipodefactura > 0 and anulada='N';";
            OdbcDataReader reader2 = select2.ExecuteReader();
            while (reader2.Read())
            {
                Document doc = cabezalDoc(reader2);
                docs.Add(doc);
            }
            conexion.Close();
            return docs;
        }

        public Document cabezalDoc(OdbcDataReader reader)
        {
            ConvertAdmSap convertAdmSap = new ConvertAdmSap();
            Document doc = new Document();
            
            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                doc.BoObjectType = convertAdmSap.tipoInvoiceSap(reader.GetInt32(reader.GetOrdinal("TIPO_ABONO"))).ToString(); ;
            }
            else
            {
                doc.BoObjectType = convertAdmSap.tipoInvoiceSap(reader.GetByte(reader.GetOrdinal("TIPO_CARGO"))).ToString(); ;
            }

            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                doc.DocumentSubType = convertAdmSap.DocumentSubType(reader.GetInt32(reader.GetOrdinal("TIPO_ABONO"))).ToString(); ;
            }
            else
            {
                doc.DocumentSubType = convertAdmSap.DocumentSubType(reader.GetByte(reader.GetOrdinal("TIPO_CARGO"))).ToString(); ;
            }

            doc.CardCode = reader.GetString(reader.GetOrdinal("RUT_CLTE"));
            doc.Cod_Empresa = reader.GetByte(reader.GetOrdinal("COD_EMPRESA"));
            doc.Cod_Sucursal = reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL"));
            doc.Tipo_Cargo = reader.GetByte(reader.GetOrdinal("TIPO_CARGO"));
            if (reader.GetByte(reader.GetOrdinal("TIPO_CARGO")) == 7)
            {
                doc.Nro_Cargo = reader.GetDecimal(reader.GetOrdinal("NRO_FISCAL"));
            }
            else
            {
                doc.Nro_Cargo = reader.GetDecimal(reader.GetOrdinal("NRO_CARGO"));
            }

            doc.Caja = reader.GetByte(reader.GetOrdinal("CAJA"));
            doc.SalesPersonCode  = convertAdmSap.getSalesPersonCode(reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL")));
            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                doc.COGSCostingCode = reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL_ABONO"));
            }
            else
            {
                doc.COGSCostingCode = reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL"));
            }

            doc.codSucursalAbono = reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL_ABONO"));
            doc.tipoAbono = reader.GetInt32(reader.GetOrdinal("TIPO_ABONO"));
            doc.numAbono = reader.GetInt32(reader.GetOrdinal("NRO_ABONO"));
            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                doc.FolioNumber = reader.GetInt32(reader.GetOrdinal("NRO_ABONO")).ToString();
            }
            else
            {
                doc.FolioNumber = reader.GetDecimal(reader.GetOrdinal("NRO_FISCAL")).ToString();
            }
            doc.DocDate = reader.GetDateTime(reader.GetOrdinal("FECHAINGRESO"));
            doc.DocDueDate = reader.GetDateTime(reader.GetOrdinal("FECHA_VEN"));            
            doc.TaxDate = reader.GetDateTime(reader.GetOrdinal("FECHA_EM"));
            doc.DocTotal = reader.GetDouble(reader.GetOrdinal("MONTO"));

            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61 || reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 22)
            {
                doc.FolioPrefixString = convertAdmSap.typeDocument(doc.tipoAbono).ToString();
            }
            else
            {
                doc.FolioPrefixString = convertAdmSap.typeDocument(doc.Tipo_Cargo).ToString();
            }
            doc.DiscountPercent = reader.GetString(reader.GetOrdinal("DESCUENTOS"));
            doc.Indicator = doc.FolioPrefixString;
            doc.udf.U_SEI_FEBOSID = reader.IsDBNull(reader.GetOrdinal("id_febos")) ? String.Empty : reader.GetString(reader.GetOrdinal("id_febos")); // TODO codigo que retorna febos
            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                Referencia referencia = new Referencia();
                referencia = this.getReferencia(doc.numAbono);

                doc.udf.U_SEI_INREF = referencia.tipoDoc; // TODO referencias pendientes por adm
                doc.udf.U_SEI_FOREF = referencia.folioDoc; // 
                doc.udf.U_SEI_FEREF = referencia.fechaDoc;
                doc.udf.U_SEI_CREF = referencia.condicionDoc;
            }



            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                doc.items = getItems(doc.Cod_Empresa, doc.codSucursalAbono, doc.Caja, doc.tipoAbono, doc.numAbono);
            }
            else
            {
               

                doc.items = getItems(doc.Cod_Empresa, doc.Cod_Sucursal, doc.Caja, doc.Tipo_Cargo, reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")));
                if (doc.Tipo_Cargo == 52)
                {
                     doc.ToWarehouse = doc.items[0].ToWarehouse;
                     doc.FromWarehouse = doc.items[0].FromWarehouse;
                }
            }
        

            Console.WriteLine("RUT:  {0} NUMERO CARGO: {1}  NUMERO ABONO: {2} TIPO CARGO {3} ", reader.GetString(reader.GetOrdinal("RUT_CLTE")) + " | ",
                                         
                                            reader.GetDecimal(reader.GetOrdinal("NRO_CARGO")).ToString() + " | ",
                                            reader.GetInt32(reader.GetOrdinal("NRO_ABONO")).ToString() + " | " , 
                                            doc.Tipo_Cargo + " | ");
            return doc;
            }

        public List<Item> getItems(Byte codEmpresa, int codSucursal, int caja, int tipo, decimal numero )
        {

            OdbcConnection conexion = con.getConnect();
            List<Item> items = new List<Item>();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from detalleventas"
                + " where COD_EMPRESA = " + codEmpresa
                + " and COD_SUCURSAL = " + codSucursal
                + " and CAJA = " + caja
                + " and TIPO = " + tipo
                + " and NUMERO = " + numero +";";

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {

                    Item item = new Item();
                    ConvertAdmSap conadmsap = new ConvertAdmSap();
                    // si el cod_art es igual a cero agregar la descripción ItemDescription
                    if (reader.GetInt32(reader.GetOrdinal("COD_ART")) == 0)
                    {
                        item.ItemDescription = reader.GetString(reader.GetOrdinal("DESCRIPCION"));
                        item.Quantity = "0";
                    }
                    else
                    {
                        item.Quantity = reader.GetDouble(reader.GetOrdinal("CANTIDAD")).ToString();
                    }
                    item.ItemCode = reader.GetInt32(reader.GetOrdinal("COD_ART")).ToString();                    
                    item.UnitPrice = reader.GetDouble(reader.GetOrdinal("PRECIO_UNITARIO")).ToString();
                    item.WarehouseCode = conadmsap.codBodega(reader.GetInt32(reader.GetOrdinal("COD_BODEGA")).ToString());
                    if (reader.GetByte(reader.GetOrdinal("TIPO")) == 52)
                    {
                        item.FromWarehouse = conadmsap.codBodega(reader.GetInt32(reader.GetOrdinal("COD_BODEGA")).ToString());
                        item.ToWarehouse = conadmsap.codBodega(reader.GetInt32(reader.GetOrdinal("COD_BODEGA_DESTINO")).ToString());
                    }

                    item.TaxCode = "IVA"; 
                    item.DiscountPercent = reader.GetDouble(reader.GetOrdinal("DESCUENTO")).ToString();

                    items.Add(item);
                
            }

            return items;

        }

        public Referencia getReferencia(int nroAbono)
        {
            OdbcConnection conexion = con.getConnect();
            Empresa empresa = new Empresa();
            empresa = new EmpresaDb().getEmpresaSqlite();
            Referencia referencia = new Referencia();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas "
            + "where cod_empresa= " + empresa.cod_empresa + " and cod_sucursal= " + empresa.cod_sucursal + " and tipo_abono = 61 "
            + "and tipo_abono < 0 "
            + "and anulada='N' "
            + "and nro_cargo ="  + nroAbono + " "
            + "and fecha_cierre IS NULL ";

            OdbcDataReader reader = select.ExecuteReader();
            // cargo Referencias
            while (reader.Read())
            {
                referencia.tipoDoc = reader.GetString(reader.GetOrdinal("TIPO_CARGO"));
                referencia.folioDoc = reader.GetString(reader.GetOrdinal("NRO_CARGO")); 
                referencia.fechaDoc = reader.GetString(reader.GetOrdinal("FECHA_EM")); 
               // referencia.condicionDoc = reader.GetString(reader.GetOrdinal("TIPO_CARGO")); TODO Marciano tiene que agregar columna
                
              

            }
            return referencia;
        }

        public void updateInAdm(CabezalVentaAdm cvadm)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            OdbcCommand update2 = new OdbcCommand();
            update.Connection = conexion;
            update2.Connection = conexion;
            String folio = " and nro_cargo=" + cvadm.NRO_CARGO;
            if(cvadm.TIPO_CARGO == "7")
                folio = " and nro_fiscal=" + cvadm.NRO_CARGO;
            update.CommandText = "update cabezalventas "
                                +"set fecha_cierre = now(), ID_SAP = '" + cvadm.ID_SAP+"'"
                                +" where cod_empresa="+ cvadm.COD_EMPRESA
                                +" and cod_sucursal="+ cvadm.COD_SUCURSAL
                                + " and tipo_cargo="+ cvadm.TIPO_CARGO
                                +  folio
                                +" and nro_abono=0;";


            OdbcDataReader up = update.ExecuteReader();

            update2.CommandText = "update detalleventas "
                                 +" set fecha_cierre = now()"
                                 +" where cod_empresa="+ cvadm.COD_EMPRESA
                                 +" and cod_sucursal="+ cvadm.COD_SUCURSAL
                                 +" and caja="+ cvadm.CAJA
                                 +" and TIPO="+ cvadm.TIPO_CARGO
                                 +" and NUMERO="+ cvadm.NRO_CARGO+";";
            
            OdbcDataReader up2 = update2.ExecuteReader();
            

        }

        public void updateCabezNCAdm(String empresa, String codSucAbono, String tipoAbono, String numAbono)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            update.Connection = conexion;


            update.CommandText = "update cabezalventas "
                                + "set fecha_cierre = now() "
                                + " where cod_empresa=" + empresa
                                + " and cod_sucursal_abono=" + codSucAbono
                                + " and tipo_abono=" + tipoAbono
                                + " and nro_abono=" + numAbono
                                + " and tipodefactura > 0;";


            OdbcDataReader up = update.ExecuteReader();



        }

        // Actualiza detalle Notas  de credito
        public void updateDetNCAdm(String empresa, String sucursal, String caja, String tipoCargo, String numCargo)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            update.Connection = conexion;

            update.CommandText = "update detalleventas "
                                 + " set fecha_cierre = now()"
                                 + " where cod_empresa=" + empresa
                                 + " and cod_sucursal=" + sucursal
                                 + " and caja=" + caja
                                 + " and TIPO=" + tipoCargo
                                 + " and NUMERO=" + numCargo + ";";


            OdbcDataReader up = update.ExecuteReader();

        }

        public String getCardCode(String cod_suc)
        {

            String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
            String carcode = String.Empty;
            SQLiteConnection myConn = new SQLiteConnection(strConn);
            myConn.Open();
            String sql1 = "SELECT * FROM sucursales where cod_adm = " + cod_suc;
            SQLiteCommand command = new SQLiteCommand(sql1, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                carcode = reader.GetString(reader.GetOrdinal("cardcode"));
            }

            myConn.Close();


            return carcode;
        }
            
    }

    // clase para cargar los campos de la tabla cabezalventas ADM
    class CabezalVentaAdm
    {
        public string COD_EMPRESA { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string TIPO_CARGO { get; set; }
        public string NRO_CARGO { get; set; }
        public string CAJA { get; set; }
        public string ID_SAP { get; set; } 

    }

    class Referencia
    {
        public string tipoDoc { get; set; }
        public string folioDoc { get; set; }
        public string fechaDoc { get; set; }
        public string condicionDoc { get; set; }

    }
}
