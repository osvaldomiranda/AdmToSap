using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;


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
            doc.Nro_Cargo = reader.GetDecimal(reader.GetOrdinal("NRO_CARGO"));
            doc.Nro_Fiscal = reader.GetDecimal(reader.GetOrdinal("NRO_FISCAL"));
            doc.Caja = reader.GetByte(reader.GetOrdinal("CAJA"));
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
            
            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
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
            doc.udf.U_SEI_INREF = ""; // TODO referencias pendientes por adm
            doc.udf.U_SEI_FOREF = ""; // 
            doc.udf.U_SEI_FEREF = "";
            doc.udf.U_SEI_CREF = "";

            if (reader.GetInt32(reader.GetOrdinal("TIPO_ABONO")) == 61)
            {
                doc.items = getItems(doc.Cod_Empresa, doc.codSucursalAbono, doc.Caja, doc.tipoAbono, doc.numAbono);
            }
            else
            {
                doc.items = getItems(doc.Cod_Empresa, doc.Cod_Sucursal, doc.Caja, doc.Tipo_Cargo, doc.Nro_Cargo);
            }



            Console.WriteLine("{0} {1}", reader.GetString(reader.GetOrdinal("RUT_CLTE")) + " | ",
                             reader.GetOrdinal("FECHAINGRESO") + " | ");
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

                item.ItemCode = reader.GetInt32(reader.GetOrdinal("COD_ART")).ToString(); // TODO codigo SAP 
                item.Quantity = reader.GetDouble(reader.GetOrdinal("CANTIDAD")).ToString();
                item.UnitPrice = reader.GetDouble(reader.GetOrdinal("PRECIO_UNITARIO")).ToString();
                item.WarehouseCode = conadmsap.codBodega(reader.GetInt32(reader.GetOrdinal("COD_BODEGA")).ToString());
                item.TaxCode = "IVA"; // TODO recuperar desde la base
                item.DiscountPercent = reader.GetDouble(reader.GetOrdinal("DESCUENTO")).ToString();

                items.Add(item);
            }

            return items;

        }

        public void updateInAdm(CabezalVentaAdm cvadm)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            OdbcCommand update2 = new OdbcCommand();
            update.Connection = conexion;
            update2.Connection = conexion;

            update.CommandText = "update cabezalventas "
                                +"set fecha_cierre = now(), ID_SAP = '" + cvadm.ID_SAP+"'"
                                +" where cod_empresa="+ cvadm.COD_EMPRESA
                                +" and cod_sucursal="+ cvadm.COD_SUCURSAL
                                +" and tipo_cargo="+ cvadm.TIPO_CARGO
                                +" and nro_cargo="+ cvadm.NRO_CARGO
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
}
