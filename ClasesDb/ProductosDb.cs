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
        public void upProdAdm(String json)
        {
            Producto producto = new Producto();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Producto));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

            try
            {
                producto = (Producto)js.ReadObject(ms);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error de lectura JSON\\" + e.Message);
            }

        }
    }
}
