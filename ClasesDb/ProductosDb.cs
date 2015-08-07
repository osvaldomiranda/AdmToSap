using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SQLite;

namespace AdmToSap
{
    class ProductosDb
    {
        
        String strConn = @"Data Source=C:/admtosap/DataB.sqlite;Pooling=true;FailIfMissing=false;Version=3";
        ConnectDb con = new ConnectDb();

        public void insertProdAdm(String json, frmMain frMain)
        {
            Producto producto = new Producto();
            List<Producto> listaproducto = new List<Producto>();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Producto));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DateTime thisDay = DateTime.Now;
            String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);
            try
            {
                producto = (Producto)js.ReadObject(ms);
                foreach (var pro in producto.Items)
                {
                    // TODO insert en adm si el rpoducto es nuevo y update si esta modificado
                    if (getPluAdm(pro.CodInt) != pro.CodInt)
                    {

                               OdbcConnection conexion = con.getConnect();
                               OdbcCommand insert = new OdbcCommand();
                               insert.Connection = conexion;
     

                        insert.CommandText = "insert into productos "
                                    + "(cod_empresa,cod_art,fecha_ingreso,fecha_ultmov,estado,descripcion,descripcion_corta,"
                                    + "descripcion_larga,rubro,familia,subfamilia,unidad_lista,simbolo_un_lista,moneda_venta, unidad_compra,"
                                    + "simbolo_un_compra,moneda_compra,cod_iva,cod_impto_adic1,cod_impto_adic2,origen,cod_marca,cubicaje,peso_neto,peso_bruto,"
                                    + "piezas_caja,unidad_fleje,costo_compra,ultimo_costo,costo_adicional,flete,tipo_fletevta,fletevta,"
                                    + "descuento,costo_prom,costo_reposicion,fob,cif,dum14,simbolo_stock,propiedad,tipo,tipo_promocion,ticket_atencion,cod_encuesta,"
                                    + "cod_popup,cod_envase,dias_duracion,cod_balanza,tara,cantidad_x_pieza,foto)"
                                    + "values"
                                    + "(1,"                                 // cod_empresa
                                    + pro.CodInt + ","                      // cod_art
                                    + "'" + fecha + "',"                    // fecha_ingreso
                                    + "'"+fecha+"',"                        // fecha_ultmov
                                    + " 2,"                                 // estado
                                    + "'" + pro.Nombre + "',"               // descripcion
                                    + "' ',"                                // descripcion_corta
                                    + "'" + pro.DescripcionCorta + "',"     // descripcion_larga
                                    + getRubro(pro.Grupo) + ","             // rubro
                                    + getFamilia(getRubro(pro.Grupo).ToString(), pro.Grupo) + ","             // familia
                                    + "1,"                                  // subfamilia
                                    + "1,"                                  // unidad_lista
                                    + "'"+ pro.SUventa+"',"                              // simbolo_un_lista
                                    + "1,"                                  // moneda_venta
                                    + "1,"                                  // unidad_compra
                                    + "'"+pro.SUcompra+"',"                              // simbolo_un_compra
                                    + "1,"                                  // moneda_compra
                                    + "1,"                                  // cod_iva
                                    + "0,"                                  // cod_impto_adic1
                                    + "0,"                                  // cod_impto_adic2
                                    + "1,"                                  // origen
                                    + "1,"                                  // cod_marca
                                    + "0,"                                  // cubicaje
                                    + "0,"                                  // peso_neto
                                    + "0,"                                  // peso_bruto
                                    + "0,"                                  // piezas_caja
                                    + "'UNIDAD',"                           // unidad_fleje
                                    + ""+pro.CostoUC+","                                  // costo_compra
                                    + ""+pro.CostoUC+","                                  // ultimo_costo
                                    + "0,"                                  // costo_adicional
                                    + "0,"                                  // flete
                                    + "0,"                                  // tipo_fletevta
                                    + "0,"                                  // fletevta
                                    + "' ',"                                // descuento
                                    + "0,"                                  // costo_prom
                                    + "0,"                                  // costo_reposicion
                                    + "0,"                                  // fob
                                    + "0,"                                  // cif
                                    + "' ',"                                // dum14
                                    + "'"+ pro.SUventa+"',"                              // simbolo_stock
                                    + "1,"                                  // propiedad
                                    + "1,"                                  // tipo
                                    + "0,"                                  // tipo_promocion
                                    + "0,"                                  // ticket_atencion
                                    + "0,"                                  // cod_encuesta
                                    + "0,"                                  // cod_popup
                                    + "0,"                                  // cod_envase
                                    + "0,"                                  // dias_duracion
                                    + "0,"                                  // cod_balanza
                                    + "0,"                                  // tara
                                    + "0,"                                  // cantidad_x_pieza
                                    + "' ')";                               // foto

                        OdbcDataReader inserts = insert.ExecuteReader();
                       insertUnidArticulo(pro.CodInt);
                       insertPrecios(pro.CodInt);
                       insertCodBarra(pro.CodInt,pro.CodBarra);
                       //insertCatalogo(pro.CodInt, pro.CodCatalog); TODO falta codigo catalogo sap
                       
                        frMain.listBoxLog.Items.Insert(0, "GRUPO: " + pro.Grupo + " - PLU: " + pro.CodInt + " - NOMBRE: " + pro.Nombre + "ESTADO: Producto Nuevo Agregado");
                        pro.estadoResponce = "Producto Nuevo Agregado";
                        conexion.Close();
                        //TODO para el update
                        // frMain.listBoxLog.Items.Insert(0, "GRUPO: " + pro.Grupo + " - PLU: " + pro.CodInt + " - NOMBRE: " + pro.Nombre + "ESTADO: Actualizado en ADM");
                        // pro.estadoResponce = "Actualizado en adm";
                    }
                  

                  
                }
                // agrego los datos a sqlite
                this.insertSqlite(producto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error de lectura JSON\\" + e.Message);
            }
            

        }

        public void insertUnidArticulo(String codArt)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand insert = new OdbcCommand();
            insert.Connection = conexion;
            insert.CommandText = "insert into unidadarticulo (cod_empresa, cod_art, cod_unidad, factor)values (1, "+codArt+",1,1)";
            OdbcDataReader inserts = insert.ExecuteReader();
            //conexion.Close();

        }

        public void insertPrecios(String codArt)
        {
            DateTime thisDay = DateTime.Now;
            String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);
            OdbcConnection conexion = con.getConnect();
            OdbcCommand insert = new OdbcCommand();
            insert.Connection = conexion;
            insert.CommandText = "insert into precios ("
                +"cod_empresa,cod_lista,cod_art,margen_ant1,margen1,precio_ant1,precio1,impprecio_ant1,impprecio1,"
                +"unidad1,margen_ant2,margen2,precio_ant2,precio2,impprecio_ant2,impprecio2,unidad2,margen_ant3,margen3,precio_ant3,"
                +"precio3,impprecio_ant3,impprecio3,fecha_act_ant,fecha_act,flagprecio,cod_mon,com_porc1,com_dinero1,com_porc2,com_dinero2,"
                +"com_porc3,com_dinero3,com_activa "
                +") values("
                + "1,"                       // cod_empresa
                + "1,"                       // cod_lista - Código de la lista de precios (1 = “BASICA”) de ADM
                + codArt + ","               // cod_art Código del nuevo producto enviado por SAP
                + "0,"                       //   
                + "0,"                       // 
                + "0,"                       // 
                + "0,"                       // Valor Neto del precio de venta
                + "0,"                       // Valor del precio de venta del producto (con IVA)
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "'2015-07-07 14:56:29',"   // = null
                + "'" + fecha + "',"         // Fecha del día en el formato ‘2015-07-07 00:00:00’
                + "'N',"                     //
                + "1,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "0,"                       //
                + "'N')";                    //
            
            OdbcDataReader inserts = insert.ExecuteReader();
           // conexion.Close();
        }

        public void insertStock(String json, frmMain frMain)
        {
            Producto producto = new Producto();
            List<Producto> listaproducto = new List<Producto>();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Producto));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            Empresa empresa = new Empresa();
            empresa = new EmpresaDb().getEmpresaSqlite();
            EmpresaDb empresaDb = new EmpresaDb();
                        try
            {
                producto = (Producto)js.ReadObject(ms);
                foreach (var pro in producto.Items)
                {
                    if (getPluAdm(pro.CodInt) != pro.CodInt)
                    {
                        OdbcConnection conexion = con.getConnect();
                        OdbcCommand insert = new OdbcCommand();
                        insert.Connection = conexion;

                        insert.CommandText = "insert into bodegastock ("
                                            + "cod_empresa,"
                                            + "cod_sucursal,"
                                            + "cod_bodega,"
                                            + "cod_art,"
                                            + "stock,"
                                            + "critico "
                                            + " ) values ("
                                            + ""+empresa.cod_empresa+","                          // Codigo de la empresa configurada o de trabajo
                                            + ""+empresa.cod_sucursal+","                          // Códgio de la sucursal configurada o de trabajo
                                            + "" + empresaDb.getBodega(empresa.cod_sucursal) + ","                          // Código de la bodega de trabajo configurada
                                            + pro.CodInt + ","                  // Código del producto entregado en el campo CODINT por SAP
                                            + "0,"                          // Valor cero para el producto nuevo
                                            + "0)";                         // Valor cero para el producto nuevo
                        OdbcDataReader inserts = insert.ExecuteReader();
                        conexion.Close();

                        frMain.listBoxLog.Items.Insert(0, "PLU: " + pro.CodInt + " - STOCK: " + pro.OnHand);
                    }
                    else
                    {
                        OdbcConnection conexion = con.getConnect();
                        OdbcCommand insert = new OdbcCommand();
                        insert.Connection = conexion;
                        insert.CommandText = "update bodegastock set stock = " + pro.OnHand + " "
                                           + "where cod_art = " + pro.CodInt + " " 
                                           + "and COD_BODEGA = "+ empresaDb.getBodega(empresa.cod_sucursal) + ";";

                        OdbcDataReader inserts = insert.ExecuteReader();
                        conexion.Close();
                        frMain.listBoxLog.Items.Insert(0, "PLU: " + pro.CodInt + " - STOCK: " + pro.OnHand);
                        pro.estadoResponce = "Actualizado en adm";

                    }

                }
                // agrego los datos a sqlite
                this.insertSqlite(producto);
            }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            MessageBox.Show("Error de lectura JSON\\" + e.Message);
                        }
           // conexion.Close();
        }

        public void insertCodBarra(String codArt, String codBarra)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand insert = new OdbcCommand();
            insert.Connection = conexion;
            insert.CommandText = "Insert Into CodigosDeBarra (Cod_Empresa, Cod_Art, Cod_Barra) Values (1, " + codArt + ", '" + codBarra + "')";
            OdbcDataReader inserts = insert.ExecuteReader();
           // conexion.Close();
        }

        public void insertCatalogo(String codArt, String codCatalogo)
        {
            OdbcConnection conexion = con.getConnect();
            OdbcCommand insert = new OdbcCommand();
            insert.Connection = conexion;
            insert.CommandText = "(Cod_Empresa, Cod_Art, Cod_Catalogo) Values (1, "+codArt+","+codCatalogo+")";
            OdbcDataReader inserts = insert.ExecuteReader();
        }

        public int getRubro(String nomRubro)
        {
            int codRubro = 0;
            OdbcConnection conexion = con.getConnect();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from rubros"
                + " where COD_EMPRESA = 1 "
                + " and DESCRIPCION = '" + nomRubro + "';"; 

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {


                codRubro = reader.GetInt32(reader.GetOrdinal("RUBRO")); // TODO codigo SAP 

            }

           // conexion.Close();
            return codRubro;
        }

        public int getFamilia(String codRubro,String nomFamilia)
        {
            int codFamilia = 0;
            OdbcConnection conexion = con.getConnect();
            OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from familias"
                + " where COD_EMPRESA = 1 "
                + " and rubro = " + codRubro
                + " and DESCRIPCION = '" + nomFamilia + "';";

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {


                codFamilia = reader.GetInt32(reader.GetOrdinal("FAMILIA")); 

            }

           // conexion.Close();
            return codFamilia;
        }

        public void insertSqlite(Producto producto)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                 String fecha = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                SQLiteConnection myConn = new SQLiteConnection(strConn);
                myConn.Open();

                foreach( var prod in producto.Items)
                {
                string sql = "insert into resp_productos "
                            + "values ('"
                            +  prod.Grupo + "' , '"
                            +  prod.CodInt + "' , '"
                            +  prod.Codigo + "' , '"
                            +  prod.CodProv + "' , '"
                            +  prod.CodBarra + "','"
                            +  prod.CodCatalog + "','"
                            +  prod.Nombre + "','"
                            +  prod.UniCompra + "','"
                            +  prod.UniVenta + "','"
                            +  prod.CostoUC + "','"
                            +  prod.DescripcionCorta + "','"
                            +  prod.SUcompra + "','"
                            +  prod.SUventa + "','"
                            +  prod.RutProv + "','"
                            +  prod.PorcIVA + "','"
                            +  prod.Precio1 + "','"
                            +  prod.Precio2 + "','"
                            +  prod.Precio3 + "','"
                            +  prod.OnHand + "','"
                            + prod.estadoResponce + "','"
                            + thisDay.ToString() + "');";

                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

            
                }
                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
 
        }

        public String getPluAdm(String plu)
        {
            String plu1 = String.Empty;
            OdbcConnection conexion = con.getConnect();
             OdbcCommand select = new OdbcCommand();
            select.Connection = conexion;
            select.CommandText = "select * from productos"
                + " where cod_art = "+plu+";";

            OdbcDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {


                plu1 = reader.GetInt32(reader.GetOrdinal("cod_art")).ToString(); // TODO codigo SAP 

            }

            return plu1;
        }





    }
}
