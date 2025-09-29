using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkChk.Data
{
    public class MyComboBoxItemInfo
    {
        private string _name;
        private string _filePath;

        public MyComboBoxItemInfo(string name, string filePath)
        {
            this._name = name;
            this._filePath = filePath;
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string FilePath
        {
            set { _filePath = value; }
            get { return _filePath; }
        }
    }
}
