﻿using System;
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

            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from cabezalventas "
            + "where cod_empresa=1 and cod_sucursal=1 and tipo_cargo in (1,2,4,6,7,32,33,34,38,39,41,52,56) "
            + "and nro_abono=0 and anulada='N' and fecha_cierre IS NULL "
            + "order by tipo_cargo, nro_cargo;";

            ConvertAdmSap convertAdmSap = new ConvertAdmSap();

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Document doc = new Document();

                doc.BoObjectType = "";
                doc.CardCode = reader.GetString(reader.GetOrdinal("RUT_CLTE"));
                doc.Cod_Empresa = reader.GetByte(reader.GetOrdinal("COD_EMPRESA"));
                doc.Cod_Sucursal = reader.GetInt32(reader.GetOrdinal("COD_SUCURSAL"));
                doc.Tipo_Cargo = reader.GetByte(reader.GetOrdinal("TIPO_CARGO"));
                doc.Nro_Cargo = reader.GetDecimal(reader.GetOrdinal("NRO_CARGO"));
                doc.Nro_Fiscal = reader.GetDecimal(reader.GetOrdinal("NRO_FISCAL"));
                doc.Caja = reader.GetByte(reader.GetOrdinal("CAJA"));
            
                doc.DocDate = reader.GetDateTime(reader.GetOrdinal("FECHAINGRESO"));
                doc.DocDueDate = reader.GetDateTime(reader.GetOrdinal("FECHA_VEN"));
                doc.TaxDate = reader.GetDateTime(reader.GetOrdinal("FECHA_EM"));
                doc.FolioNumber = reader.GetDecimal(reader.GetOrdinal("NRO_FISCAL")).ToString();
                doc.FolioPrefixString = convertAdmSap.typeDocument(doc.Tipo_Cargo).ToString();
                doc.DiscountPercent = reader.GetOrdinal("DESCUENTOS").ToString();
                doc.Indicator = doc.FolioPrefixString;

                doc.udf.U_SEI_FEBOSID = ""; // codigo que retorna febos
                doc.udf.U_SEI_INREF = ""; // referencias pendientes por adm
                doc.udf.U_SEI_FOREF = ""; // 
                doc.udf.U_SEI_FEREF = "";
                doc.udf.U_SEI_CREF = "";

                doc.items = getItems(doc.Cod_Empresa, doc.Cod_Sucursal, doc.Caja, doc.Tipo_Cargo, doc.Nro_Cargo);

                docs.Add(doc);

                Console.WriteLine("{0} {1}", reader.GetString(reader.GetOrdinal("RUT_CLTE")) + " | ",
                                             reader.GetOrdinal("FECHAINGRESO") + " | ");

            }

            conexion.Close();
            return docs;


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
                item.UnitPrice = reader.GetDouble(reader.GetOrdinal("PRECIO_VENTA_PUBLICO")).ToString();
                item.WarehouseCode = conadmsap.codBodega(reader.GetInt32(reader.GetOrdinal("COD_BODEGA")).ToString());
                item.TaxCode = "IVA"; // TODO recuperar desde la base
                item.DiscountPercent = reader.GetDouble(reader.GetOrdinal("DESCUENTO")).ToString();

                items.Add(item);
            }

            return items;

        }

        public void updateInAdm(String empresa, String sucursal, String tipoCargo, String numCargo, String caja)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand update = new OdbcCommand();
            OdbcCommand update2 = new OdbcCommand();
            update.Connection = conexion;
            update2.Connection = conexion;

            update.CommandText = "update cabezalventas "
                                +"set fecha_cierre = now() "
                                +" where cod_empresa="+empresa
                                +" and cod_sucursal="+sucursal
                                +" and tipo_cargo="+tipoCargo
                                +" and nro_cargo="+numCargo
                                +" and nro_abono=0;";


            OdbcDataReader up = update.ExecuteReader();

            update2.CommandText = "update detalleventas "
                                 +" set fecha_cierre = now()"
                                 +" where cod_empresa="+empresa
                                 +" and cod_sucursal="+sucursal
                                 +" and caja="+caja
                                 +" and TIPO="+tipoCargo
                                 +" and NUMERO="+numCargo+";";
            
            OdbcDataReader up2 = update2.ExecuteReader();
            

        }
    }
}
