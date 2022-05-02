using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkBack
{
    public class item_mensaje
    {

        private string v_name_ = "";
        public string v_name { get { return v_name_; } set { v_name_ = value; } }

        //
        private object v_object_in_ = new object();
        public object v_object_in { get { return v_object_in_; } set { v_object_in_ = value; } }

        // error
        private String v_exception_ = "";
        public String v_exception { get { return v_exception_; } set { v_exception_ = value; } }
        //
        private Boolean v_error_ = false;
        public Boolean v_error { get { return v_error_; } set { v_error_ = value; } }
        //
        public string v_error_mensaje_ = "";
        public string v_error_mensaje { get { return v_error_mensaje_; } set { v_error_mensaje_ = value; } }

        // base de datos
        private string v_bd_query_ = "";
        public string v_bd_query { get { return v_bd_query_; } set { v_bd_query_ = value; } }

        //
        private string v_comentario_ = "";
        public string v_comentario { get { return v_comentario_; } set { v_comentario_ = value; } }
        //
        //out
        private item_out v_item_out_ = new item_out();
        public item_out v_item_out { get { return v_item_out_; } set { v_item_out_ = value; } }

        public void Graba_Mensaje_en_BD(item_config ItemConfig)
        {
            v_error = false;

            //if (ItemConfig.v_graba_funcion != "n")
            //{
            //    Graba_en_BD(ItemConfig);
            //}

        }

        public void Graba_Error_en_BD(item_config ItemConfig)
        {
            v_error = true;

            //if (ItemConfig.v_graba_error != "n")
            //{
            //    Graba_en_BD(ItemConfig);
            //}
        }

        private void Graba_en_BD(item_config ItemConfig)
        {

            //string query = "";

            //MySqlConnection myCon = new MySqlConnection();
            //myCon.ConnectionString = ItemConfig.v_string_connection;
            //myCon.Open();

            //// conexion
            //if (myCon.State != ConnectionState.Open)
            //{
            //    return;
            //}

            //try
            //{

            //    query = "INSERT INTO mensajes ";
            //    query += "(`id`,`c_name`,`f_date`,`j_object_in`,`j_exception`,`b_error`,`c_error_mensaje`,`j_config`, ";
            //    query += " `c_bd_query`,`c_comentario`,`j_object_out` ";
            //    query += ") VALUES (";

            //    query += "0";
            //    query += ",'" + v_name + "'";
            //    query += ",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            //    query += ",'" + "" + "'"; // JsonConvert.SerializeObject(v_object_in_)
            //    query += ",'" + v_exception.Replace("'", "") + "'";
            //    query += "," + v_error;
            //    query += ",'" + v_error_mensaje + "'";
            //    query += ",'" + JsonConvert.SerializeObject(ItemConfig) + "'";
            //    query += ",'" + v_bd_query.Replace("'", "") + "'";
            //    query += ",'" + v_comentario + "'";
            //    query += ",'" + "" + "'";    // JsonConvert.SerializeObject(v_item_out)
            //    query += ")";
            //    MySqlCommand myCmdExec_Insert = new MySqlCommand(query, myCon);
            //    myCmdExec_Insert.ExecuteNonQuery();

            //    myCon.Close();
            //    MySqlConnection.ClearPool(myCon);

            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}

        }

    }
}
