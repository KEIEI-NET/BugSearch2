using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
    public partial class Form1 : Form
    {
        private class enumValue
        {
            private string _name;
            private int _value;

            public enumValue(string name, int value)
            {
                this._name = name;
                this._value = value;
            }

            public string Name
            {
                get { return this._name; }
            }

            public int Value
            {
                get { return this._value; }
            }
        }

        // ※ 修正
        private IRateProtyMngDB _RemoteObject = null;
        
        // ※ 修正
        private RateProtyMngWork _Condition = new RateProtyMngWork();

        private DataTable _Conditions = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            // インターフェース取得 ※ 修正
            this._RemoteObject = MediationRateProtyMngDB.GetRateProtyMngDB();
                
            this._Conditions = new DataTable("Condition");

            // 検索条件入力フィールドを生成
            foreach (PropertyInfo pInfo in _Condition.GetType().GetProperties())
            {
                this._Conditions.Columns.Add(new DataColumn(pInfo.Name, pInfo.PropertyType));
            }

            dataGridView1.DataSource = this._Conditions;

            // 論理削除区分設定
            comboBox1.DataSource = Enum.GetValues(typeof(Broadleaf.Library.Resources.ConstantManagement.LogicalMode));
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// ステータス表示
        /// </summary>
        /// <param name="st"></param>
        private void SetStatusCode(int st)
        {
            string stname = "";
            try
            {
                stname = Enum.GetName(typeof(Broadleaf.Library.Resources.ConstantManagement.DB_Status), st);
            }
            catch
            {

            }

            this.lblStatusCd.Text = string.Format("status = {0}({1})", stname, st.ToString());
        }

        /// <summary>
        /// 処理結果表示
        /// </summary>
        /// <param name="retdat"></param>
        private void SetResultData(ArrayList retdat)
        {
            dataGridView2.DataSource = retdat;
        }

        private void ResultToCondition()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                this._Conditions.Clear();

                foreach (DataGridViewRow dgrv in dataGridView2.SelectedRows)
                {
                    DataRow addRow = this._Conditions.NewRow();
                    
                    // 検索条件入力フィールドを設定
                    foreach (PropertyInfo pInfo in this._Condition.GetType().GetProperties())
                    {
                        if (!(dgrv.Cells[pInfo.Name].Value is System.DBNull))
                        {
                            addRow[pInfo.Name] = dgrv.Cells[pInfo.Name].Value;
                        }
                    }

                    this._Conditions.Rows.Add(addRow);
                }
            }
        }

        /// <summary>
        /// 処理条件設定処理
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        private int GetCondition(out ArrayList conditions)
        {
            int ConditionCount = this._Conditions.Rows.Count;

            conditions = new ArrayList();

            foreach (DataRow dr in this._Conditions.Rows)
            {
                object newInstance = System.Activator.CreateInstance(this._Condition.GetType(), System.Reflection.BindingFlags.CreateInstance, null, null, null);

                // 検索条件入力フィールドを設定
                foreach (PropertyInfo pInfo in newInstance.GetType().GetProperties())
                {
                    if (!(dr[pInfo.Name] is System.DBNull))
                    {
                        pInfo.SetValue(newInstance, dr[pInfo.Name], null);
                    }
                }

                conditions.Add(newInstance);
            }

            return ConditionCount;
        }

        /// <summary>
        /// 処理条件クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            this._Conditions.Clear();
            this.SetStatusCode(0);
            this.dataGridView2.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Read 処理
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                // ※ 修正
                RateProtyMngWork dataWork = al[0] as RateProtyMngWork;

                if (dataWork != null)
                {
                    byte[] parabyte = XmlByteSerializer.Serialize(dataWork);

                    int st = this._RemoteObject.Read(ref parabyte, 0);

                    this.SetStatusCode(st);

                    // ※ 修正
                    dataWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateProtyMngWork));
                    if (dataWork != null)
                    {
                        al.Clear();
                        al.Add(dataWork);
                        this.SetResultData(al);
                    }
                }
                else
                {
                    MessageBox.Show("処理条件が不正です");
                }
            }
            else
            {
                MessageBox.Show("処理条件を入力して下さい");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete 処理
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                // ※ 修正
                RateProtyMngWork dataWork = al[0] as RateProtyMngWork;

                if (dataWork != null)
                {
                    byte[] parabyte = XmlByteSerializer.Serialize(dataWork);

                    int st = this._RemoteObject.Delete(parabyte);
                    this.SetStatusCode(st);
                    this.SetResultData(null);
                }
                else
                {
                    MessageBox.Show("処理条件が不正です");
                }
            }
            else
            {
                MessageBox.Show("処理条件を入力して下さい");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Search 処理
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                // ※ 修正
                RateProtyMngWork dataWork = al[0] as RateProtyMngWork;

                if (dataWork != null)
                {
                    object objectRet;

                    int st = this._RemoteObject.Search(out objectRet, (object)dataWork, 0, (Broadleaf.Library.Resources.ConstantManagement.LogicalMode)comboBox1.SelectedValue);

                    this.SetStatusCode(st);
                    this.SetResultData(objectRet as ArrayList);
                }
                else
                {
                    MessageBox.Show("処理条件が不正です");
                }
            }
            else
            {
                MessageBox.Show("処理条件を入力して下さい");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Write 処理
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                object objAl = al;
                int st = this._RemoteObject.Write(ref objAl);
                this.SetStatusCode(st);
                this.SetResultData(objAl as ArrayList);
            }
            else
            {
                MessageBox.Show("処理条件を入力して下さい");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // LogicalDelete 処理
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                object objAl = al;
                int st = this._RemoteObject.LogicalDelete(ref objAl);
                this.SetStatusCode(st);
                this.SetResultData(objAl as ArrayList);
            }
            else
            {
                MessageBox.Show("処理条件を入力して下さい");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // RevivalLogicalDelete 処理
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                object objAl = al;
                int st = this._RemoteObject.RevivalLogicalDelete(ref objAl);
                this.SetStatusCode(st);
                this.SetResultData(objAl as ArrayList);
            }
            else
            {
                MessageBox.Show("処理条件を入力して下さい");
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ResultToCondition();
        }

    }
}