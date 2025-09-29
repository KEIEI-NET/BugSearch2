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
using Broadleaf.Application.Common;
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

        // �� �C��
        private IEmployeeDtlDB _RemoteObject = null;

        
        // �� �C��
        private EmployeeDtlWork _Condition = new EmployeeDtlWork();


        private DataTable _Conditions = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            // �C���^�[�t�F�[�X�擾 �� �C��
            this._RemoteObject = MediationEmployeeDtlDB.GetEmployeeDtlDB();

            this._Conditions = new DataTable("Condition");

            // �����������̓t�B�[���h�𐶐�
            foreach (PropertyInfo pInfo in _Condition.GetType().GetProperties())
            {
                this._Conditions.Columns.Add(new DataColumn(pInfo.Name, pInfo.PropertyType));
            }

            dataGridView1.DataSource = this._Conditions;

            // �_���폜�敪�ݒ�
            comboBox1.DataSource = Enum.GetValues(typeof(Broadleaf.Library.Resources.ConstantManagement.LogicalMode));
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// �X�e�[�^�X�\��
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
        /// �������ʕ\��
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
                    
                    // �����������̓t�B�[���h��ݒ�
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
        /// ���������ݒ菈��
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

                // �����������̓t�B�[���h��ݒ�
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
        /// ���������N���A����
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
            // Read ����
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                // �� �C��
                EmployeeDtlWork dataWork = al[0] as EmployeeDtlWork;

                if (dataWork != null)
                {
                    byte[] parabyte = XmlByteSerializer.Serialize(dataWork);

                    int st = this._RemoteObject.Read(ref parabyte, 0);

                    this.SetStatusCode(st);

                    // �� �C��
                    dataWork = (EmployeeDtlWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeDtlWork));
                    if (dataWork != null)
                    {
                        al.Clear();
                        al.Add(dataWork);
                        this.SetResultData(al);
                    }
                }
                else
                {
                    MessageBox.Show("�����������s���ł�");
                }
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete ����
            //this.GetCondition(out al);
            EmployeeDtlWork[] trarray = (EmployeeDtlWork[])( (ArrayList)dataGridView2.DataSource ).ToArray(typeof(EmployeeDtlWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            if (parabyte != null)
            {
                // �� �C��
                //EmployeeDtlWork dataWork = al[0] as EmployeeDtlWork;

                if (parabyte != null)
                {
                    //byte[] parabyte = XmlByteSerializer.Serialize(parabyte);

                    int st = this._RemoteObject.Delete(parabyte);
                    this.SetStatusCode(st);
                    this.SetResultData(null);
                }
                else
                {
                    MessageBox.Show("�����������s���ł�");
                }
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Search ����
            ArrayList al = null;
            this.GetCondition(out al);

            if (al.Count > 0)
            {
                // �� �C��
                EmployeeDtlWork dataWork = al[0] as EmployeeDtlWork;

                if (dataWork != null)
                {
                    object objectRet;

                    int st = this._RemoteObject.Search(out objectRet, (object)dataWork, 0, (Broadleaf.Library.Resources.ConstantManagement.LogicalMode)comboBox1.SelectedValue);

                    this.SetStatusCode(st);
                    this.SetResultData(objectRet as ArrayList);
                }
                else
                {
                    MessageBox.Show("�����������s���ł�");
                }
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Write ����
            ArrayList al = null;
            this.GetCondition(out al);

            //object objCondition = dataGridView1.DataSource;
            if (al.Count > 0)
            //if (objCondition != null)
            {
                object objAl = al;
                int st = this._RemoteObject.Write(ref objAl);
                this.SetStatusCode(st);
                this.SetResultData(objAl as ArrayList);
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // LogicalDelete ����
            ArrayList al = null;
            this.GetCondition(out al);
            object objCondition = dataGridView2.DataSource;

            if (objCondition != null)
            {
                //object objAl = al;
                int st = this._RemoteObject.LogicalDelete(ref objCondition);
                this.SetStatusCode(st);
                this.SetResultData(objCondition as ArrayList);
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // RevivalLogicalDelete ����
            ArrayList al = null;
            this.GetCondition(out al);

            object objCondition = dataGridView2.DataSource;

            if (objCondition != null)
            {
                //object objAl = al;
                int st = this._RemoteObject.RevivalLogicalDelete(ref objCondition);
                this.SetStatusCode(st);
                this.SetResultData(objCondition as ArrayList);
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ResultToCondition();
        }

        private void button8_Click( object sender, EventArgs e )
        {
            // GridWrite ����
            //ArrayList al = null;
            object objCondition = dataGridView2.DataSource;
            if (objCondition != null)
            {
                int st = this._RemoteObject.Write(ref objCondition);
                this.SetStatusCode(st);
                this.SetResultData(objCondition as ArrayList);
            }
            else
            {
                MessageBox.Show("������������͂��ĉ�����");
            }

        }

    }
}