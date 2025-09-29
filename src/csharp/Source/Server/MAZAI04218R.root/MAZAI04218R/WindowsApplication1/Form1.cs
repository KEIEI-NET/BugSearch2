using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using System.Reflection;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private IInventInputSearchDB IinventInputSearchDB = null;
        private InventInputSearchCndtnWork inventInputSearchCndtnWork = null;
        private static System.Windows.Forms.Form _form = null;
        private static string[] _parameter;

        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;

        }
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
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
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
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

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IinventInputSearchDB = MediationInventInputSearchDB.GetInventInputSearchDB();
        }

        // Search
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            dataGridView1.DataSource = null;
            inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
            object retobj = null;

            inventInputSearchCndtnWork.EnterpriseCode = tb1.Text;
            inventInputSearchCndtnWork.St_SectionCode = StSec.Text;
            inventInputSearchCndtnWork.Ed_SectionCode = EdSec.Text;
            inventInputSearchCndtnWork.St_MakerCode = Convert.ToInt32(tb3.Text);
            inventInputSearchCndtnWork.Ed_MakerCode = Convert.ToInt32(tb4.Text);
            inventInputSearchCndtnWork.St_GoodsNo = tb5.Text;
            inventInputSearchCndtnWork.Ed_GoodsNo = tb6.Text;
            inventInputSearchCndtnWork.St_BLGoodsCode = Convert.ToInt32(tb7.Text);
            inventInputSearchCndtnWork.Ed_BLGoodsCode = Convert.ToInt32(tb8.Text);
            inventInputSearchCndtnWork.St_EnterpriseGanreCode = Convert.ToInt32(tb9.Text);
            inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = Convert.ToInt32(tb10.Text);           
            inventInputSearchCndtnWork.St_WarehouseCode = tb15.Text;
            inventInputSearchCndtnWork.Ed_WarehouseCode = tb16.Text;
            inventInputSearchCndtnWork.WarehouseDiv = comboBox1.SelectedIndex;
            inventInputSearchCndtnWork.WarehouseCd01 = WH01.Text;
            inventInputSearchCndtnWork.WarehouseCd02 = WH02.Text;
            inventInputSearchCndtnWork.WarehouseCd03 = WH03.Text;
            inventInputSearchCndtnWork.WarehouseCd04 = WH04.Text;
            inventInputSearchCndtnWork.WarehouseCd05 = WH05.Text;
            inventInputSearchCndtnWork.WarehouseCd06 = WH06.Text;
            inventInputSearchCndtnWork.WarehouseCd07 = WH07.Text;
            inventInputSearchCndtnWork.WarehouseCd08 = WH08.Text;
            inventInputSearchCndtnWork.WarehouseCd09 = WH09.Text;
            inventInputSearchCndtnWork.WarehouseCd10 = WH10.Text;

            inventInputSearchCndtnWork.St_BLGroupCode = Convert.ToInt32(tb21.Text);
            inventInputSearchCndtnWork.Ed_BLGroupCode = Convert.ToInt32(tb22.Text);
            inventInputSearchCndtnWork.St_SupplierCd = Convert.ToInt32(tb23.Text);
            inventInputSearchCndtnWork.Ed_SupplierCd = Convert.ToInt32(tb24.Text);
            inventInputSearchCndtnWork.St_InventorySeqNo = Convert.ToInt32(tb25.Text);
            inventInputSearchCndtnWork.Ed_InventorySeqNo = Convert.ToInt32(tb26.Text);
            inventInputSearchCndtnWork.DifCntExtraDiv = Convert.ToInt32(tb27.Text);
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = Convert.ToInt32(tb28.Text);
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = Convert.ToInt32(tb29.Text);
            inventInputSearchCndtnWork.TargetDateExtraDiv = Convert.ToInt32(tb33.Text);
            inventInputSearchCndtnWork.CalcStockAmountDiv = 1;
            inventInputSearchCndtnWork.CalcStockAmountDate = DateTime.MinValue;
            inventInputSearchCndtnWork.SelectedPaperKind = Convert.ToInt32(SelectP.Text);
            inventInputSearchCndtnWork.St_WarehouseShelfNo = StTana.Text;
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = EdTana.Text;
            

            object paraobj = inventInputSearchCndtnWork;

            int status = IinventInputSearchDB.Search(out retobj, paraobj,0,0);

            if (status != 0)
            {
                Text = "該当データなし ST=" + Convert.ToString(status);
            }
            else
            {
                //#Text = "該当データ有  HIT" + ((ArrayList)retobj).Count.ToString() + "件";

                ArrayList retBfArray = (ArrayList)retobj;
                retBfArray = (ArrayList)retBfArray[0];
                Text = "該当データ有  HIT" + retBfArray.Count.ToString() + "件";
                ArrayList retAfArray = new ArrayList();
                for (int i = 0; i < retBfArray.Count; i++)
                {
                    retAfArray.Add(retBfArray[i]);
                }
                dataGridView1.DataSource = retAfArray;
            }

            end = DateTime.Now;
            label34.Text = Convert.ToString((end - start).TotalSeconds);
        }

        // SearchCount
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            Text = null;
            int count = 0;
            inventInputSearchCndtnWork = new InventInputSearchCndtnWork();

            inventInputSearchCndtnWork.EnterpriseCode = tb1.Text;
            inventInputSearchCndtnWork.St_SectionCode = StSec.Text;
            inventInputSearchCndtnWork.Ed_SectionCode = EdSec.Text;
            inventInputSearchCndtnWork.St_MakerCode = Convert.ToInt32(tb3.Text);
            inventInputSearchCndtnWork.Ed_MakerCode = Convert.ToInt32(tb4.Text);
            inventInputSearchCndtnWork.St_GoodsNo = tb5.Text;
            inventInputSearchCndtnWork.Ed_GoodsNo = tb6.Text;
            inventInputSearchCndtnWork.St_BLGoodsCode = Convert.ToInt32(tb7.Text);
            inventInputSearchCndtnWork.Ed_BLGoodsCode = Convert.ToInt32(tb8.Text);
            inventInputSearchCndtnWork.St_EnterpriseGanreCode = Convert.ToInt32(tb9.Text);
            inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = Convert.ToInt32(tb10.Text);
            inventInputSearchCndtnWork.St_WarehouseCode = tb15.Text;
            inventInputSearchCndtnWork.Ed_WarehouseCode = tb16.Text;
            inventInputSearchCndtnWork.WarehouseDiv = comboBox1.SelectedIndex;
            inventInputSearchCndtnWork.WarehouseCd01 = WH01.Text;
            inventInputSearchCndtnWork.WarehouseCd02 = WH02.Text;
            inventInputSearchCndtnWork.WarehouseCd03 = WH03.Text;
            inventInputSearchCndtnWork.WarehouseCd04 = WH04.Text;
            inventInputSearchCndtnWork.WarehouseCd05 = WH05.Text;
            inventInputSearchCndtnWork.WarehouseCd06 = WH06.Text;
            inventInputSearchCndtnWork.WarehouseCd07 = WH07.Text;
            inventInputSearchCndtnWork.WarehouseCd08 = WH08.Text;
            inventInputSearchCndtnWork.WarehouseCd09 = WH09.Text;
            inventInputSearchCndtnWork.WarehouseCd10 = WH10.Text;

            inventInputSearchCndtnWork.St_InventorySeqNo = Convert.ToInt32(tb25.Text);
            inventInputSearchCndtnWork.Ed_InventorySeqNo = Convert.ToInt32(tb26.Text);
            inventInputSearchCndtnWork.DifCntExtraDiv = Convert.ToInt32(tb27.Text);
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = Convert.ToInt32(tb28.Text);
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = Convert.ToInt32(tb29.Text);
            inventInputSearchCndtnWork.TargetDateExtraDiv = Convert.ToInt32(tb33.Text);
            inventInputSearchCndtnWork.St_BLGroupCode = Convert.ToInt32(tb21.Text);
            inventInputSearchCndtnWork.Ed_BLGroupCode = Convert.ToInt32(tb22.Text);
            inventInputSearchCndtnWork.St_SupplierCd = Convert.ToInt32(tb23.Text);
            inventInputSearchCndtnWork.Ed_SupplierCd = Convert.ToInt32(tb24.Text);
            inventInputSearchCndtnWork.SelectedPaperKind = Convert.ToInt32(SelectP.Text);
            inventInputSearchCndtnWork.St_WarehouseShelfNo = StTana.Text;
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = EdTana.Text;

            
            object paraobj = inventInputSearchCndtnWork;

            int status = IinventInputSearchDB.SearchCount(out count, paraobj,0,0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                Text = count.ToString();
            }
            else Text = "該当なし ST=" + Convert.ToString(status);

            end = DateTime.Now;
            label34.Text = Convert.ToString((end - start).TotalSeconds);
        }

        // SearchPrint
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            dataGridView1.DataSource = null;
            inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
            object retobj = null;
            inventInputSearchCndtnWork.EnterpriseCode = tb1.Text;
            inventInputSearchCndtnWork.St_SectionCode = StSec.Text;
            inventInputSearchCndtnWork.Ed_SectionCode = EdSec.Text;
            inventInputSearchCndtnWork.St_MakerCode = Convert.ToInt32(tb3.Text);
            inventInputSearchCndtnWork.Ed_MakerCode = Convert.ToInt32(tb4.Text);
            inventInputSearchCndtnWork.St_GoodsNo = tb5.Text;
            inventInputSearchCndtnWork.Ed_GoodsNo = tb6.Text;
            inventInputSearchCndtnWork.St_BLGoodsCode = Convert.ToInt32(tb7.Text);
            inventInputSearchCndtnWork.Ed_BLGoodsCode = Convert.ToInt32(tb8.Text);
            inventInputSearchCndtnWork.St_EnterpriseGanreCode = Convert.ToInt32(tb9.Text);
            inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = Convert.ToInt32(tb10.Text);
            inventInputSearchCndtnWork.St_WarehouseCode = tb15.Text;
            inventInputSearchCndtnWork.Ed_WarehouseCode = tb16.Text;
            inventInputSearchCndtnWork.WarehouseDiv = comboBox1.SelectedIndex;
            inventInputSearchCndtnWork.WarehouseCd01 = WH01.Text;
            inventInputSearchCndtnWork.WarehouseCd02 = WH02.Text;
            inventInputSearchCndtnWork.WarehouseCd03 = WH03.Text;
            inventInputSearchCndtnWork.WarehouseCd04 = WH04.Text;
            inventInputSearchCndtnWork.WarehouseCd05 = WH05.Text;
            inventInputSearchCndtnWork.WarehouseCd06 = WH06.Text;
            inventInputSearchCndtnWork.WarehouseCd07 = WH07.Text;
            inventInputSearchCndtnWork.WarehouseCd08 = WH08.Text;
            inventInputSearchCndtnWork.WarehouseCd09 = WH09.Text;
            inventInputSearchCndtnWork.WarehouseCd10 = WH10.Text;
            inventInputSearchCndtnWork.St_InventorySeqNo = Convert.ToInt32(tb25.Text);
            inventInputSearchCndtnWork.Ed_InventorySeqNo = Convert.ToInt32(tb26.Text);
            inventInputSearchCndtnWork.DifCntExtraDiv = Convert.ToInt32(tb27.Text);
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = Convert.ToInt32(tb28.Text);
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = Convert.ToInt32(tb29.Text);
            inventInputSearchCndtnWork.TargetDateExtraDiv = Convert.ToInt32(tb33.Text);
            inventInputSearchCndtnWork.CalcStockAmountDiv = 1;
            inventInputSearchCndtnWork.CalcStockAmountDate = DateTime.MinValue;
            inventInputSearchCndtnWork.St_BLGroupCode = Convert.ToInt32(tb21.Text);
            inventInputSearchCndtnWork.Ed_BLGroupCode = Convert.ToInt32(tb22.Text);
            inventInputSearchCndtnWork.St_SupplierCd = Convert.ToInt32(tb23.Text);
            inventInputSearchCndtnWork.Ed_SupplierCd = Convert.ToInt32(tb24.Text);
            inventInputSearchCndtnWork.St_WarehouseShelfNo = StTana.Text;
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = EdTana.Text;
            inventInputSearchCndtnWork.SelectedPaperKind = Convert.ToInt32(SelectP.Text);
            inventInputSearchCndtnWork.LendExtraDiv = Convert.ToInt32(LEDiv.Text);
            inventInputSearchCndtnWork.DelayPaymentDiv = Convert.ToInt32(DPDiv.Text);
            inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(Convert.ToInt32(IDATE.Text));
            
            object paraobj = inventInputSearchCndtnWork;

            int status = IinventInputSearchDB.SearchPrint(out retobj, paraobj, 0, 0);

            if (status != 0)
            {
                Text = "該当データなし ST=" + Convert.ToString(status);
            }
            else
            {
                //#Text = "該当データ有  HIT" + ((ArrayList)retobj).Count.ToString() + "件";
                ArrayList retBfArray = (ArrayList)retobj;
                retBfArray = (ArrayList)retBfArray[0];
                Text = "該当データ有  HIT" + retBfArray.Count.ToString() + "件";
                ArrayList retAfArray = new ArrayList();
                for (int i = 0; i < retBfArray.Count; i++)
                {
                    retAfArray.Add(retBfArray[i]);
                }
                dataGridView1.DataSource = retAfArray;
            }

            end = DateTime.Now;
            label34.Text = Convert.ToString((end - start).TotalSeconds);
        }

        private void tb15_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb16_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                tb15.Enabled = true;
                tb16.Enabled = true;
                WH01.Enabled = false;
                WH02.Enabled = false;
                WH03.Enabled = false;
                WH04.Enabled = false;
                WH05.Enabled = false;
                WH06.Enabled = false;
                WH07.Enabled = false;
                WH08.Enabled = false;
                WH09.Enabled = false;
                WH10.Enabled = false;
                WH01.Text = "";
                WH02.Text = "";
                WH03.Text = "";
                WH04.Text = "";
                WH05.Text = "";
                WH06.Text = "";
                WH07.Text = "";
                WH08.Text = "";
                WH09.Text = "";
                WH10.Text = "";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                tb15.Enabled = false;
                tb16.Enabled = false;
                WH01.Enabled = true;
                WH02.Enabled = true;
                WH03.Enabled = true;
                WH04.Enabled = true;
                WH05.Enabled = true;
                WH06.Enabled = true;
                WH07.Enabled = true;
                WH08.Enabled = true;
                WH09.Enabled = true;
                WH10.Enabled = true;
                WH01.Text = "0001";
                WH02.Text = "0002";
                WH03.Text = "0003";
                WH04.Text = "0004";
                WH05.Text = "0005";
                WH06.Text = "0006";
                WH07.Text = "0007";
                WH08.Text = "0008";
                WH09.Text = "0009";
                WH10.Text = "0010";

            }

        }
    }
}