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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
//using Broadleaf.Application.Controller;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace RemoteTestApplication
{
    public partial class Form1 : Form
    {
        private static System.Windows.Forms.Form _form = null;
        private static string[] _parameter;
        private DateTime dtStart, dtEnd;

		private CarModelCondWork carModelCondWork = null;
		private ICarModelCtlDB _ICarModelSearch = null;

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
			carModelCondWork = new CarModelCondWork();
			button3_Click(null, null);
        }

        /// <summary>
        /// Form1 デストラクタ
        /// </summary>
        ~Form1()
        {
			carModelCondWork = null;
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
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            _ICarModelSearch = MediationCarModelCtlDB.GetRemoteObject();
        }

        /// <summary>
        /// 検索条件設定メソッド
        /// </summary>
        private void SetCondition()
        {
            // 車両型式検索条件の設定
//			carModelCondWork.Clear();
            int work = 0;

			//型式
			carModelCondWork.ExhaustGasSign = textBox1.Text;

			carModelCondWork.SeriesModel = textBox2.Text;

			carModelCondWork.CategorySignModel = textBox3.Text;
			
			//類別・型式
            if (textBox4.Text != "") work = int.Parse(textBox4.Text); else work = 0;
			carModelCondWork.ModelDesignationNo = work;
			
            if (textBox5.Text != "") work = int.Parse(textBox5.Text); else work = 0;
			carModelCondWork.CategoryNo = work;

			//エンジン
			carModelCondWork.EngineModelNm = textBox6.Text;

			//コーションプレート
			//textBox7.Text

			//メーカー 車種 サブ車種
			if (textBox8.Text != "") work = int.Parse(textBox8.Text); else work = 0;
			carModelCondWork.MakerCode = work;
			if (textBox9.Text != "") work = int.Parse(textBox9.Text); else work = 0;
			carModelCondWork.ModelCode = work;
			if (textBox10.Text != "") work = int.Parse(textBox10.Text); else work = -1;
			carModelCondWork.ModelSubCode = work;
        }

        /// <summary>
        /// 検索条件クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
//            _CarSearchCondition.Clear();
//            button2.Enabled = false;
            label5.Text = "";
            label6.Text = "";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
			dataGridView1.DataSource = null;
            
            SetCondition();
			ArrayList ModelList = null;
			ArrayList CarKind = null;
			ArrayList colorCdRetWork = null;
			ArrayList trimCdRetWork = null;
			ArrayList cEqpDefDspRetWork = null;
			ArrayList prdTypYearRetWork = null;
			ArrayList categoryEquipmentRetWork = null;
            ArrayList categoryRetWork = null;

            dtStart = DateTime.Now;
			int st = _ICarModelSearch.GetCarCtgyMdl(carModelCondWork, out ModelList, out CarKind, 
                out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork,
                out categoryEquipmentRetWork, out categoryRetWork);


			dtEnd = DateTime.Now;

            if (st == 0)
            {
				label5.Text = string.Format("検索結果 {0}件({1}秒)", ModelList.Count, Convert.ToString((dtEnd - dtStart).TotalSeconds));
                switch (ModelList.Count)
                {
                    case 0:
                        // 車種が１件も存在しない場合
                        MessageBox.Show("検索条件に該当する車両が見つかりません。", "類別検索", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        // 車種が複数存在する場合
                        dataGridView2.DataSource = ModelList;
						dataGridView4.DataSource = CarKind;
						dataGridView5.DataSource = colorCdRetWork;
						dataGridView6.DataSource = trimCdRetWork;
						dataGridView7.DataSource = cEqpDefDspRetWork;
						dataGridView8.DataSource = prdTypYearRetWork;
						dataGridView9.DataSource = categoryEquipmentRetWork;
						break;
                }
            }
            else
            {
                label5.Text = string.Format("検索失敗({0}秒)", Convert.ToString((dtEnd - dtStart).TotalSeconds));
            }
		}

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            
            SetCondition();

			ArrayList ModelList = null;
			ArrayList CarKind = null;
			ArrayList colorCdRetWork = null;
			ArrayList trimCdRetWork = null;
			ArrayList cEqpDefDspRetWork = null;
			ArrayList prdTypYearRetWork = null;
			ArrayList ctgyMdlLnkRetWork = null;
            
            dtStart = DateTime.Now;

			int st = _ICarModelSearch.GetCarModel(carModelCondWork, out ModelList, out CarKind, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);

			dtEnd = DateTime.Now;

            if (st == 0)
            {
                label6.Text = string.Format("検索結果 {0}件({1}秒)", ModelList.Count, Convert.ToString((dtEnd - dtStart).TotalSeconds));
				switch (CarKind.Count)
                {
                    case 0:
                        // 車種が１件も存在しない場合
                        MessageBox.Show("検索条件に該当する車両が見つかりません。", "② 型式検索", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        // 車種が複数存在する場合
                        dataGridView2.DataSource = ModelList;
						dataGridView4.DataSource = CarKind;
						dataGridView5.DataSource = colorCdRetWork;
						dataGridView6.DataSource = trimCdRetWork;
						dataGridView7.DataSource = cEqpDefDspRetWork;
						dataGridView8.DataSource = prdTypYearRetWork;
                        break;
                }
            }
            else
            {
                label6.Text = string.Format("検索失敗({0}秒)", Convert.ToString((dtEnd - dtStart).TotalSeconds));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

		private void button4_Click(object sender, EventArgs e)
		{
			dataGridView3.DataSource = null;

			SetCondition();

			ArrayList ModelList = null;
			ArrayList CarKind = null;
			ArrayList colorCdRetWork = null;
			ArrayList trimCdRetWork = null;
			ArrayList cEqpDefDspRetWork = null;
			ArrayList prdTypYearRetWork = null;


			dtStart = DateTime.Now;

			int st = _ICarModelSearch.GetCarEngine(carModelCondWork, out ModelList, out CarKind, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);

			dtEnd = DateTime.Now;

			if (st == 0)
			{
//				label6.Text = string.Format("検索結果 {0}件({1}秒)", ModelList.Count, Convert.ToString((dtEnd - dtStart).TotalSeconds));
				switch (CarKind.Count)
				{
					case 0:
						// 車種が１件も存在しない場合
						MessageBox.Show("検索条件に該当する車両が見つかりません。", "エンジン検索", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					default:
						// 車種が複数存在する場合
						dataGridView3.DataSource = ModelList;
						dataGridView4.DataSource = CarKind;
						dataGridView5.DataSource = colorCdRetWork;
						dataGridView6.DataSource = trimCdRetWork;
						dataGridView7.DataSource = cEqpDefDspRetWork;
						dataGridView8.DataSource = prdTypYearRetWork;
						break;
				}
			}
			else
			{
//				label6.Text = string.Format("検索失敗({0}秒)", Convert.ToString((dtEnd - dtStart).TotalSeconds));
			}

		}
    }
}