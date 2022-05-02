using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pkBack
{
    public class Bandeja
    {

        public item_config ItemConfig = new item_config();
        public item_mensaje ItemMensaje = new item_mensaje();
        public item_bandeja ItemBandeja = new item_bandeja();

        public void getBandeja() {

            switch (ItemBandeja.v_tipo_bd) {
                case
                    TipoBD.mySQL:
                    getBandeja_mySQL();
                    break;
                case TipoBD.mySQlpg:
                    break;
            }
        }

        private void getBandeja_mySQL()
        {

            ItemMensaje.v_name = "getBandeja_mySQL";
            string query = "";

            MySqlConnection myCon = new MySqlConnection();
            myCon.ConnectionString = ItemConfig.v_string_connection;
            myCon.Open();

            // conexion
            if (myCon.State != ConnectionState.Open)
            {
                ItemMensaje.v_error_mensaje = "No es posible la conexion";
                ItemMensaje.Graba_Error_en_BD(ItemConfig);
                return;
            }

            try
            {

                query = "select c_nombre,c_tabla,c_accion,c_campo_max,c_where,c_order,c_campos from back_bandeja where ";
                query += "ic_cod_ban = " + ItemBandeja.ic_cod_ban + "";

                MySqlCommand myCmd_read = new MySqlCommand(query, myCon);
                MySqlDataReader myReader = myCmd_read.ExecuteReader();

                if (myReader.HasRows)
                {

                    if (myReader.Read()) 
                    {
                        ItemBandeja.c_nombre = static_back.getField_String(myReader, 0);
                        ItemBandeja.c_tabla = static_back.getField_String(myReader, 1);
                        ItemBandeja.c_accion = static_back.getField_String(myReader, 2);
                        ItemBandeja.c_campo_max = static_back.getField_String(myReader, 3);
                        if(static_back.getField_String(myReader, 4) != "" && ItemBandeja.c_where != "")
                        {
                            ItemBandeja.c_where = static_back.getField_String(myReader, 4) + " AND " + ItemBandeja.c_where;
                        }
                        else
                        {
                            ItemBandeja.c_where = static_back.getField_String(myReader, 4) + ItemBandeja.c_where;
                        }
                        ItemBandeja.c_order = static_back.getField_String(myReader, 5);
                        ItemBandeja.c_campos = static_back.getField_String(myReader, 6);
                    }

                    
                }

                myReader.Close();
                

                switch (ItemBandeja.c_accion)
                {
                    case "select":

                        select_mySQL(myCon);
                        break;

                    case "delete":

                        delete_mySQL(myCon);
                        break;

                    case "insert":

                        insert_mySQL(myCon);
                        break;

                    case "update":

                        update_mySQL(myCon);
                        break;
                        
                }

                myCon.Close();

            }
            catch (Exception ex)
            {
                ItemMensaje.v_bd_query = query;
                ItemMensaje.v_exception = ex.Message.ToString();
                //ItemMensaje.Graba_Error_en_BD(ItemConfig);
            }
        }

       
        private string select_mySQL(MySqlConnection currentCon)
        {
            string query = "SELECT " + ItemBandeja.c_campos + " FROM " + ItemBandeja.c_tabla;
            if (ItemBandeja.c_where != "")
            {
                query += " WHERE " + ItemBandeja.c_where;
            }
            if (ItemBandeja.c_order != "")
            {
                query += " ORDER BY " + ItemBandeja.c_order;
            }

            try{

                MySqlCommand myCmd_read = new MySqlCommand(query, currentCon);
                MySqlDataReader myReader = myCmd_read.ExecuteReader();

                string json = JsonReader(myReader);

                return json;
            }
            catch (Exception ex)
            {
                ItemMensaje.v_bd_query = query;
                ItemMensaje.v_exception = ex.Message.ToString();
                //ItemMensaje.Graba_Error_en_BD(ItemConfig);
                return "";
            }
        }

        private string JsonReader(MySqlDataReader reader)
        {
            string sb = "[";

            if (reader == null || reader.FieldCount == 0)
            {
                return "null";
            }

            int rowCount = 0;

            while (reader.Read())
            {
                sb += "{";

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sb += "\"" + reader.GetName(i) + "\":";

                    if(reader.GetDataTypeName(i).ToLower() == "integer" || reader.GetDataTypeName(i).ToLower() == "decimal")
                    {
                        sb += reader.GetValue(i);
                    }
                    else
                    {
                        sb += "\"" + reader.GetValue(i) + "\"";
                    }

                    sb += ",";
                    sb +=  "\n";
                }

                if (reader.FieldCount > 0)
                    sb = sb.Substring(0,sb.Length - 2);

                sb += "},";
                
                sb += "\n";

                rowCount++;
            }

            if (rowCount > 0)
                sb = sb.Substring(0,sb.Length - 2);

            sb += "]";

            return sb;
        }

        private void delete_mySQL(MySqlConnection currentCon)
        {
            string query = "DELETE FROM " + ItemBandeja.c_tabla + " WHERE " + ItemBandeja.c_where;

            try
            {
                MySqlCommand myCmd = new MySqlCommand(query, currentCon);
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ItemMensaje.v_bd_query = query;
                ItemMensaje.v_exception = ex.Message.ToString();
                //ItemMensaje.Graba_Error_en_BD(ItemConfig);
            }

        }

        private void insert_mySQL(MySqlConnection currentCon)
        {
            string query = "INSERT INTO " + ItemBandeja.c_tabla + " (" + ItemBandeja.c_campos;
            query += ") VALUES (" + ItemBandeja.c_valores + ")";

            try
            {
                MySqlCommand myCmd = new MySqlCommand(query, currentCon);
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ItemMensaje.v_bd_query = query;
                ItemMensaje.v_exception = ex.Message.ToString();
                //ItemMensaje.Graba_Error_en_BD(ItemConfig);
            }

        }

        private void update_mySQL(MySqlConnection currentCon)
        {
            string query = "UPDATE " + ItemBandeja.c_tabla + " SET " + ItemBandeja.c_valores;
            query += " WHERE " + ItemBandeja.c_where;

            try
            {
                MySqlCommand myCmd = new MySqlCommand(query, currentCon);
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ItemMensaje.v_bd_query = query;
                ItemMensaje.v_exception = ex.Message.ToString();
                //ItemMensaje.Graba_Error_en_BD(ItemConfig);
            }

        }
    }
}
