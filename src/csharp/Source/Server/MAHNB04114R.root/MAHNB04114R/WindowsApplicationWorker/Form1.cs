using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Reflection;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using System.IO;
using System.Text;
using System.Globalization;

namespace WindowsApplicationWorker
{
    public partial class Form1 : Form
    {
        private static string[] _parameter;
        private static Form _form = null;

        public Form1()
        {
            InitializeComponent();
            CustomizeComponent();
        }

        private void CustomizeComponent()
        {
            this.Load += new System.EventHandler(this.Form1_Load);

            //enterpriseCode.Text = LoginInfoAcquisition.EnterpriseCode;
            ClearMessage();
        }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;

                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param_csal name="sender"></param_csal>
        /// <param_csal name="e">メッセージ</param_csal>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// FromLoad時イベント
        /// </summary>
        /// <param_csal name="sender"></param_csal>
        /// <param_csal name="e"></param_csal>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            GetRemoteObject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearGrid();
            ClearMessage();
            int status = 0;
            string messageString = String.Empty;

            SalesSlipSearchWork param = CreateRequestParameter();
            object response;
            try
            {
                status = _iro.Search(out response, (object)param, 0, (ConstantManagement.LogicalMode)Convert.ToInt32(LogicalMode.Text));
                if (response != null) ShowResponse((ArrayList)response);
            }
            catch (Exception ex)
            {
                status = ERROR_STATUS;
                messageString = ERROR_PREFIX + ex.Message;
            }

            SetMessage(status, messageString);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearGrid();
            ClearMessage();
            int status = 0;
            string messageString = String.Empty;

            SalesSlipSearchWork param = CreateRequestParameter();
            //object response;
            try
            {
                //int total;
                //bool next;
                //status = _iro.TopSearch(out response, (object)param, out total, out next, ParseInt32(TopN.Text), 0, (ConstantManagement.LogicalMode)Convert.ToInt32(LogicalMode.Text));
                //if (response != null) ShowResponse((ArrayList)response, total);
                //if (next) messageString = "more rows.. ";
            }
            catch (Exception ex)
            {
                status = ERROR_STATUS;
                messageString = ERROR_PREFIX + ex.Message;
            }

            SetMessage(status, messageString);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ClearGrid();
            ClearMessage();
            int status = 0;
            string messageString = String.Empty;

            SalesSlipSearchWork param = CreateRequestParameter();
            try
            {
                int total;
                //status = _iro.SearchCount((object)param, out total, 0, (ConstantManagement.LogicalMode)Convert.ToInt32(LogicalMode.Text));
                //if (status == 0) ShowResponse(total);
            }
            catch (Exception ex)
            {
                status = ERROR_STATUS;
                messageString = ERROR_PREFIX + ex.Message;
            }

            SetMessage(status, messageString);
        }

        private void GetRemoteObject()
        {
            if (_iro == null) _iro = MediationSearchSalesSlipDB.GetSearchSalesSlipDB();
        }

        private SalesSlipSearchWork CreateRequestParameter()
        {
            SalesSlipSearchWork salesSlipSearchWork = new SalesSlipSearchWork();

            salesSlipSearchWork.EnterpriseCode = enterpriseCode.Text;
            salesSlipSearchWork.SalesSlipCd = ParseInt32(salesSlipCd.Text);
            salesSlipSearchWork.AcptAnOdrStatus = ParseInt32(acptAnOdrStatus.Text);
            salesSlipSearchWork.AccRecDivCd = ParseInt32(accRecDivCd.Text);
            salesSlipSearchWork.SalesSlipNumSt = salesSlipNumSt.Text;
            salesSlipSearchWork.SalesSlipNumEd = salesSlipNumEd.Text;
            salesSlipSearchWork.PartySaleSlipNum = PartySaleSlipNum.Text;
            salesSlipSearchWork.SalesDateSt = ParseInt32(salesDateSt.Text);
            salesSlipSearchWork.SalesDateEd = ParseInt32(salesDateEd.Text);
            salesSlipSearchWork.ShipmentDaySt = ParseInt32(ShipmentDaySt.Text);
            salesSlipSearchWork.ShipmentDayEd = ParseInt32(ShipmentDayEd.Text);
            salesSlipSearchWork.SearchSlipDateSt = ParseInt32(searchSlipDateSt.Text);
            salesSlipSearchWork.SearchSlipDateEd = ParseInt32(searchSlipDateEd.Text);
            salesSlipSearchWork.FrontEmployeeCd = frontEmployeeCd.Text;
            salesSlipSearchWork.SalesEmployeeCd = salesEmployeeCd.Text;
            salesSlipSearchWork.SalesInputCode = salesInputCode.Text;
            salesSlipSearchWork.ClaimCode = ParseInt32(claimCode.Text);
            salesSlipSearchWork.CustomerCode = ParseInt32(customerCode.Text);
            salesSlipSearchWork.SectionCode = sectionCode.Text;
            salesSlipSearchWork.GoodsMakerCd = ParseInt32(goodsMakerCd.Text);
            salesSlipSearchWork.GoodsNo = goodsNo.Text;
            salesSlipSearchWork.EstimateDivide = ParseInt32(EstimateDivide.Text);
            


            return salesSlipSearchWork;
        }
        private int GetValue(string text)
        {
            string[] keyvalue = text.Split(':');
            return ParseInt32(keyvalue[0]);
        }
        private void SetMessage(int status, string messageString)
        {
            toolStripStatusLabel1.Text = System.Convert.ToString(status);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    messageString += ERROR_PREFIX + "snapshot too old.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT:
                    messageString += ERROR_PREFIX + "connection timed out.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    messageString += ERROR_PREFIX + "unique constraint violated.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    messageString += "finished.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    messageString += ERROR_PREFIX + "database error.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    messageString += "finished.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    messageString += "no data found.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_OFFLINE:
                    messageString += ERROR_PREFIX + "cannot connect network.";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_WARNING:
                    messageString += WARNING_PREFIX + "database warning.";
                    break;
                default:
                    break;
            }
            toolStripStatusLabel2.Text = messageString;
        }
        private void ClearMessage()
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";
            label5.Text = "";
            label43.Text = "";
            label5.Visible = false;
            label43.Visible = false;
            label6.Visible = false;
            label42.Visible = false;
        }
        private void ClearGrid()
        {
            dataGridView1.DataSource = null;
        }

        private void ShowResponse(ArrayList al, int total)
        {
            ShowResponse(al);
            ShowResponse(total);
        }
        private void ShowResponse(ArrayList al)
        {
            dataGridView1.DataSource = al;
            label43.Text = al.Count.ToString();
            label43.Visible = true;
            label42.Visible = true;
        }
        private void ShowResponse(int total)
        {
            label5.Text = total.ToString();
            label5.Visible = true;
            label6.Visible = true;
        }

        private bool isEmpty(ArrayList al)
        {
            if (al == null) return true;
            if (al.Count == 0) return true;
            return false;
        }
        private Int32 ParseInt32(string str)
        {
            if (String.IsNullOrEmpty(str)) return -1;
            return Int32.Parse(str);
        }
        private Int64 ParseInt64(string str)
        {
            if (String.IsNullOrEmpty(str)) return 0;
            return Int64.Parse(str);
        }
        private Double ParseDouble(string str)
        {
            if (String.IsNullOrEmpty(str)) return 0;
            return Double.Parse(str);
        }
        private DateTime ParseDateTime(string str)
        {
            return DateTime.ParseExact(str, "yyyyMMdd", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
        }

        const int ERROR_STATUS = -99999;
        const string ERROR_PREFIX = "error : ";
        const string WARNING_PREFIX = "warning : ";

        private ISearchSalesSlipDB _iro;

        private void button4_Click(object sender, EventArgs e)
        {

            ClearGrid();
            ClearMessage();
            int status = 0;
            string messageString = String.Empty;

            SalesSlipDetailSearchWork salesSlipDetailSearchWork = new SalesSlipDetailSearchWork();
            salesSlipDetailSearchWork.EnterpriseCode = enterpriseCode.Text;
            salesSlipDetailSearchWork.AcptAnOdrStatus = ParseInt32(acptAnOdrStatus.Text);
            salesSlipDetailSearchWork.SalesSlipNum = salesSlipNumSt.Text;

            object response;
            try
            {
                status = _iro.SearchDetail(out response, (object)salesSlipDetailSearchWork, 0, (ConstantManagement.LogicalMode)Convert.ToInt32(LogicalMode.Text));
                if (response != null) ShowResponse((ArrayList)response);
            }
            catch (Exception ex)
            {
                status = ERROR_STATUS;
                messageString = ERROR_PREFIX + ex.Message;
            }

            SetMessage(status, messageString);
            

        }

    }
}

