using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace AdmToSap
{
    class ProductosDb
    {
        public Producto upProdAdm(String json)
        {
            Producto producto = new Producto();
            List<Producto> listaproducto = new List<Producto>();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Producto));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            frmProductosDgw frmdgv = new frmProductosDgw();

            try
            {
                producto = (Producto)js.ReadObject(ms);
                foreach (var pro in producto.Items)
                {
                  frmdgv.dataGridView1.Rows.Add(pro.Grupo,pro.CodBarra, pro.CodInt, pro.Nombre);
                }
                frmdgv.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error de lectura JSON\\" + e.Message);
            }

            return producto;
            

        }

        public Producto upInvAdm(String json)
        {
            Producto producto = new Producto();
            List<Producto> listaproducto = new List<Producto>();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Producto));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            frmProductosDgw frmdgv = new frmProductosDgw();

            try
            {
                producto = (Producto)js.ReadObject(ms);
                foreach (var pro in producto.Items)
                {
                    frmdgv.dataGridView1.Rows.Add(pro.CodInt, pro.OnHand);
                }
                frmdgv.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error de lectura JSON\\" + e.Message);
            }

            return producto;


        }



    }
}
