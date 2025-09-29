using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWork
{
    public partial class Form1 : Form
    {
        IStockTransListResultDB stockTransListResultDB = null;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
            textBox2.Text = "000001";
            textBox7.Text = "0";
            textBox8.Text = "200704";
            textBox9.Text = "200803";
            textBox10.Text = "1";
            textBox11.Text = "200704";
            textBox12.Text = "200803";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockTransListResultDB = MediationStockTransListResultDB.GetStockTransListResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockTransListCndtnWork stockTransListCndtnWork = null;

            stockTransListCndtnWork = new StockTransListCndtnWork();

            // ��ƃR�[�h
            stockTransListCndtnWork.EnterpriseCode = textBox1.Text;

            //���_�ʏW�v�敪�v���p�e�B
            //0:�S�ЏW�v�^1:���_�ʏW�v
            stockTransListCndtnWork.GroupBySectionDiv = 1;

            //���[�W�v�敪�v���p�e�B
            //�i�\�����ځj0:���i�ʁ^1:�d����ʁ^2:�S���ҕ�
            stockTransListCndtnWork.PrintSelectDiv = 2;

            // ���_�R�[�h
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            //SectionCodes[1] = "000002";
            stockTransListCndtnWork.AddUpSecCodes = SectionCodes;

            //�J�n������
            stockTransListCndtnWork.St_ThisYearMonth = Convert.ToInt32(textBox8.Text);

            //�I��������
            stockTransListCndtnWork.Ed_ThisYearMonth = Convert.ToInt32(textBox9.Text);

            //�W�v�P��
            //0:���i�R�[�h  1:BL�R�[�h  2:���Е��ރR�[�h  3:���i�敪�ڍ׃R�[�h  4:�ڍ׋敪�R�[�h  5:���i�敪�O���[�v�R�[�h  6:���[�J�[�R�[�h</value>
            //salesRsltListCndtnWork.TtlType = 0;
            stockTransListCndtnWork.SummaryUnit = 0;

            //�݌Ɏ��敪�v���p�e�B
            //0:���v 1:�݌� 2:���
            stockTransListCndtnWork.StockOrderDiv = 0;

            //�]�ƈ��R�[�h
            stockTransListCndtnWork.St_EmployeeCode = "";
            stockTransListCndtnWork.Ed_EmployeeCode = "";

            //���Ӑ�R�[�h
            stockTransListCndtnWork.St_SupplierCd = 0;
            stockTransListCndtnWork.Ed_SupplierCd = 0;

            //���[�J�[�R�[�h
            stockTransListCndtnWork.St_GoodsMakerCd = 0;
            stockTransListCndtnWork.Ed_GoodsMakerCd = 0;

            //���i�ԍ�
            stockTransListCndtnWork.St_GoodsNo = "";
            stockTransListCndtnWork.Ed_GoodsNo = "";

            //BL���i�R�[�h
            stockTransListCndtnWork.St_BLGoodsCode = 0;
            stockTransListCndtnWork.Ed_BLGoodsCode = 0;

            //���i�敪�O���[�v�R�[�h
            stockTransListCndtnWork.St_LargeGoodsGanreCode = "";
            stockTransListCndtnWork.Ed_LargeGoodsGanreCode = "";

            //���i�敪�R�[�h
            stockTransListCndtnWork.St_MediumGoodsGanreCode = "";
            stockTransListCndtnWork.Ed_MediumGoodsGanreCode = "";

            //���i�敪�ڍ׃R�[�h
            stockTransListCndtnWork.St_DetailGoodsGanreCode = "";
            stockTransListCndtnWork.Ed_DetailGoodsGanreCode = "";

            //���Е��ރR�[�h
            stockTransListCndtnWork.St_EnterpriseGanreCode = 0;
            stockTransListCndtnWork.Ed_EnterpriseGanreCode = 0;

            //�d����R�[�h
            stockTransListCndtnWork.St_SupplierCd = 0;
            stockTransListCndtnWork.Ed_SupplierCd = 0;

            //�o�א�
            stockTransListCndtnWork.St_TotalStockCount = 1.0;
            stockTransListCndtnWork.Ed_TotalStockCount = 99999999.0;


            //�W�v�敪
            //salesRsltListCndtnWork.TotalType = textBox10.Text == "" ? 0 : Convert.ToInt32(textBox10.Text);


            ArrayList al = new ArrayList();
            al.Add(stockTransListCndtnWork);
            dataGridView2.DataSource = al;

            Search();


        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = stockTransListResultDB.Search(out objResult, objParam);
                if (status != 0)
                {
                    Text = "�Y���f�[�^����";
                }
                else
                {
                    // XML�̓ǂݍ���
                    Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)objResult).Count.ToString() + "��";

                    if (objResult != null)
                    {
                        dataGridView1.DataSource = objResult;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}