using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace RemoteTestApplication
{
    public partial class Form1 : Form
    {
        private static System.Windows.Forms.Form _form = null;
        private static string[] _parameter;

        private CarSearchController _CarSearchController = null;
        //private PMKEN01010E dat = new PMKEN01010E();

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
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。
                //出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode,
                                    new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "Form1", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// Form1 コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            _CarSearchController = new CarSearchController();
            button3_Click(null, null);
        }

        /// <summary>
        /// Form1 デストラクタ
        /// </summary>
        ~Form1()
        {
            _CarSearchController = null;
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = dat.CarKindInfo;
            //dataGridView2.DataSource = dat.CarModelInfo;
        }


        /// <summary>
        /// 検索条件クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            txtMakerCd.Clear();
            txtModel.Clear();
            txtModelSubCd.Clear();
            txtKatasiki.Clear();
            txtRui1.Clear();
            txtRui2.Clear();
            label2.Text = "";
            label5.Text = "";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarSearchCondition con = new CarSearchCondition();
            PMKEN01010E dat = new PMKEN01010E();

            int makerCd, modelCd, modelSubCd, modelDesignationNo, categoryNo;

            if (int.TryParse(txtMakerCd.Text, out makerCd))
                con.MakerCode = makerCd;
            if (int.TryParse(txtModel.Text, out modelCd))
                con.ModelCode = modelCd;
            if (int.TryParse(txtModelSubCd.Text, out modelSubCd))
                con.ModelSubCode = modelSubCd;
            if (int.TryParse(txtRui1.Text, out modelDesignationNo))
                con.ModelDesignationNo = modelDesignationNo;
            if (int.TryParse(txtRui2.Text, out categoryNo))
                con.CategoryNo = categoryNo;
            con.ModelPlate = txtPlate.Text;
            con.CarModel.FullModel = txtKatasiki.Text;

            if (rdoEngine.Checked)
                con.Type = CarSearchType.csEngineModel;
            if (rdoKatasiki.Checked)
                con.Type = CarSearchType.csModel;
            if (rdoPlate.Checked)
                con.Type = CarSearchType.csPlate;
            if (rdoRuibetu.Checked)
                con.Type = CarSearchType.csCategory;

            if (dataGridView1.DataSource != null)
            {
                dat.CarKindInfo = (PMKEN01010E.CarKindInfoDataTable)dataGridView1.DataSource;
            }
            if (dataGridView2.DataSource != null)
            {
                dat.CarModelInfo = (PMKEN01010E.CarModelInfoDataTable)dataGridView2.DataSource;
            }

            try
            {
                _CarSearchController.Search(con, ref dat);

                dataGridView1.SuspendLayout();
                dataGridView2.SuspendLayout();

                dataGridView1.DataSource = dat.CarKindInfo;
                dataGridView2.DataSource = dat.CarModelInfo;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataGridView1.ResumeLayout();
                dataGridView2.ResumeLayout();
            }
        }

    }
}