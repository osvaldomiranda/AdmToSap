using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace AdmToSap
{
    class PreciosDb
    {
        public ListaPrecio upPrecAdm(String json)
        {

            ListaPrecio listprecio = new ListaPrecio();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ListaPrecio));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            frmProductosDgw frmdgv = new frmProductosDgw();

            try
            {
                listprecio = (ListaPrecio)js.ReadObject(ms);
                foreach (var pro in listprecio.Items)
                {
                    frmdgv.dataGridView1.Rows.Add(listprecio.ListName, listprecio.PriceList, pro.CodInt,pro.Price);
                }
                frmdgv.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error de lectura JSON\\" + e.Message);
            }

            return listprecio;


        }
    }
}
