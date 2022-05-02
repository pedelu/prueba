using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkBack
{
    public class item_out
    {

        private object v_out_object_;
        public object v_out_object { get { return v_out_object_; } set { v_out_object_ = value; } }
        //
        private List<object> v_out_lista_ = new List<object>();
        public List<object> v_out_lista { get { return v_out_lista_; } set { v_out_lista_ = value; } }
        //
        private string v_out_ok_ = "n";
        public string v_out_ok { get { return v_out_ok_; } set { v_out_ok_ = value; } }
        //
        private Int32 v_out_code_ = 0;
        public Int32 v_out_code { get { return v_out_code_; } set { v_out_code_ = value; } }
        //
        private string v_out_name_;
        public string v_out_name { get { return v_out_name_; } set { v_out_name_ = value; } }

    }
}
