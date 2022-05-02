using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkBack
{
    public static class static_back
    {


        public static String getField_String(MySqlDataReader sqlReader, Int32 index)
        {

            String field = "";

            try
            {

                if (sqlReader.IsDBNull(index) == false)
                {

                    field = sqlReader.GetString(index);
                }

                return field;
            }

            catch (Exception ex)
            {
                //static_quotation.myError.SaveException("QuotationDB.getField_String.Exception", ex.Message.ToString());
                return field;
            }
        }


        public static Int32 getField_Int32(MySqlDataReader sqlReader, Int32 index)
        {

            Int32 field = 0;

            try
            {
                if (sqlReader.IsDBNull(index) == false)
                {

                    field = sqlReader.GetInt32(index);
                }

                return field;
            }
            catch (Exception ex)
            {
                //static_quotation.myError.SaveException("QuotationDB.getField_Int32.Exception", ex.Message.ToString());
                return 0;
            }
        }

    }
}
