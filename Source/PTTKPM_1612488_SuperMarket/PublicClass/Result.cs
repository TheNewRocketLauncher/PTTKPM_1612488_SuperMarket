using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicClass
{
    public class Result
    {
        public bool _is_Success { get; set; }
        public string _error { get; set; }
        public object _result { get; set; }

        //public object _result;

        //public object getResult()
        //{
        //    return _result;
        //}

        //public bool setResult(object Object)
        //{
        //    bool result = false;
        //    try
        //    {
        //        _result = Object;
        //        result = true;
        //    }
        //    catch
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        //contruction
        public Result()
        {
            this._is_Success = false;
            this._error = "0";
            this._result = "0";
        }

        public Result(bool issuc, string err, string result)
        {
            this._is_Success = issuc;
            this._error = err;
            this._result = result;
        }
    }
}
