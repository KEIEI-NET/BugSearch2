using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Library.Windows.Forms
{
    class CmbDataContainer
    {
        private string _keyMember;
        private string _displayMember;

        public string KeyMember
        {
            get { return _keyMember; }
            //set { _keyMember = value; }
        }

        public string DisplayMember
        {
            get { return _displayMember; }
            //set { _displayMember = value; }
        }

        public static ArrayList GetList(DataTable tbl, string keyCol, string ValCol)
        {
            List<string> lstKey = new List<string>();
            ArrayList list = new ArrayList();
            int cnt = tbl.Rows.Count;
            CmbDataContainer dat = new CmbDataContainer();
            dat._keyMember = string.Empty;
            dat._displayMember = string.Empty;
            list.Add(dat);
            for (int i = 0; i < cnt; i++)
            {
                dat = new CmbDataContainer();
                string key = tbl.Rows[i][keyCol].ToString();
                string val = tbl.Rows[i][ValCol].ToString();
                dat._keyMember = key;
                if (val == string.Empty)
                {
                    dat._displayMember = key;
                }
                else
                {
                    dat._displayMember = key.Trim() + " : " + val;
                }
                if (lstKey.Contains(key) == false)
                {
                    list.Add(dat);
                    lstKey.Add(key);
                }
            }
            return list;
        }

    }
}
