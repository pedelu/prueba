using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkBack
{


    public enum TipoBD
    {
        mySQL, mySQlpg
    }


    public class item_config
    {


        public string v_string_connection { get; set; }

        public TipoBD v_tipo_bd { get; set; }

        public string v_version
        {
            get { return "12 de agosto 2021"; }
        }


    }
}
