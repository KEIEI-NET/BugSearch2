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
using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button button3;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;

        private HolidaySettingWork _holidaySettingWork = null;

        //private CarrierWork _prevCarrierWork = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;

        private IHolidaySettingDB iHolidaySettingDB = null;

        private static string[] _parameter;
        private TextBox textBox3;
        private Label label2;
        private TextBox textBox4;
        private Label label3;
        private DataGrid dataGrid2;
        private DataGrid dataGrid3;
        private Button button1;
        private static System.Windows.Forms.Form _form = null;

        public Form1()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0113180842030000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "拠点コード";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 466);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(560, 132);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(135, 418);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "SearchSec";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 138);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Search条件設定";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(130, 68);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "1";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(70, 418);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(288, 418);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(16, 418);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(48, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(360, 418);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(432, 418);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(504, 418);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(130, 90);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(248, 19);
            this.textBox3.TabIndex = 40;
            this.textBox3.Text = "1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "適用年月日開始";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(130, 112);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(248, 19);
            this.textBox4.TabIndex = 42;
            this.textBox4.Text = "1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 43;
            this.label3.Text = "適用年月日終了";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(32, 167);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(496, 77);
            this.dataGrid2.TabIndex = 44;
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(32, 285);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(496, 77);
            this.dataGrid3.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "SearchSec条件設定";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(592, 612);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

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

        private void button1_Click(object sender, System.EventArgs e)
        {
            //			if (_ejibaiRtDtWork == null) _ejibaiRtDtWork = new EjibaiRtDtWork();
            _holidaySettingWork = new HolidaySettingWork();
            _holidaySettingWork.EnterpriseCode = textBox1.Text;
            //_ejibaiRtDtWork.SectionCode = textBox2.Text;
            //_ejibaiRtDtWork.RecordReadKey = Convert.ToInt32(textBox3.Text);
            //_ejibaiRtDtWork.NewOrModifiRatioCd = Convert.ToInt32(textBox4.Text);
            //_ejibaiRtDtWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_holidaySettingWork);

            object retList = null;
            object paraObj = _holidaySettingWork;

            int status = iHolidaySettingDB.Read(ref parabyte, 0);
            //int status = IcarrierDB.Read(paraObj, out retList);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                /*
                // XMLの読み込み
                _carrierWork = (CarrierWork)XmlByteSerializer.Deserialize(parabyte, typeof(CarrierWork));

                Text = "該当データ有り";
                textBox1.Text = _carrierWork.EnterpriseCode.ToString();
                //textBox2.Text = _ejibaiRtDtWork.SectionCode.ToString();
                //textBox3.Text = _ejibaiRtDtWork.CheckResultDivCd1.ToString();
                //textBox4.Text = _ejibaiRtDtWork.NewOrModifiRatioCd.ToString();
                //textBox5.Text = _ejibaiRtDtWork.BodyPaintKindCd.ToString();
                textBox7.Text = _carrierWork.LogicalDeleteCode.ToString();
                */

                Text = "該当データ有り";
                CustomSerializeArrayList customArray = retList as CustomSerializeArrayList;
                foreach (object obj in customArray)
                {
                    if (obj is HolidaySettingWork)
                    {
                        HolidaySettingWork holidaySettingWork1 = obj as HolidaySettingWork;
                        //MakerWork makerWork1 = obj as MakerWork;
                    }
                }
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //ImakerDB = MediationMakerDB.GetMakerDB();
            iHolidaySettingDB = MediationHolidaySettingDB.GetHolidaySettingDB();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            HolidaySettingWork holidaySettingWork = new HolidaySettingWork();
            //MakerWork makerInsWork = new MakerWork();
            holidaySettingWork.EnterpriseCode = textBox1.Text;
            //makerInsWork.EnterpriseCode = textBox1.Text;

            ArrayList al = new ArrayList();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(holidaySettingWork);
            //byte[] retbyte;

            int status = 0;// IejibairtdtDB.Search(out retbyte, parabyte, 0, 0);
            //listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                //EjibaiRtDtWork[] ew = (EjibaiRtDtWork[])XmlByteSerializer.Deserialize(retbyte,typeof(EjibaiRtDtWork[]));

                //Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";

                //for(int i = 0;i<ew.Length;i++)
                //{
                //    ejibaiRtDtInsWork = (EjibaiRtDtWork)ew[i];
                //    listBox1.Items.Add(ejibaiRtDtInsWork.ToString());
                //    listBox1.Update();
                //}
                //if (checkBox1.Checked) XmlByteSerializer.Serialize(ew,"c:\\testList.xml");	
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            object parabyte = dataGrid3.DataSource;
            object objsyncServerService;


            //int status = ImakerDB.Search(out objmaker, parabyte, 0, 0);
            int status = iHolidaySettingDB.SearchSecList(out objsyncServerService, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objsyncServerService).Count.ToString() + "件";

                dataGrid1.DataSource = objsyncServerService;
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            if (_holidaySettingWork == null) _holidaySettingWork = new HolidaySettingWork();

            //_makerWork.EnterpriseCode = textBox1.Text;
            _holidaySettingWork.EnterpriseCode = textBox1.Text;
            //_ejibaiRtDtWork.SectionCode = textBox2.Text;
            //_ejibaiRtDtWork.RecordReadKey = Convert.ToInt32(textBox3.Text);
            //_ejibaiRtDtWork.NewOrModifiRatioCd = Convert.ToInt32(textBox4.Text);
            //_ejibaiRtDtWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

            _holidaySettingWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);
            //_makerWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

            ArrayList al = new ArrayList();
            //al.Add(_makerWork);
            al.Add(_holidaySettingWork);
            //byte[] parabyte = XmlByteSerializer.Serialize(_ejibaiRtDtWork);

            object obj = al;

            int status =  iHolidaySettingDB.Write(ref obj);
            if (status != 0)
            {
                Text = "更新失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "更新成功";
                //_ejibaiRtDtWork = (EjibaiRtDtWork)XmlByteSerializer.Deserialize(parabyte,typeof(EjibaiRtDtWork));
                dataGrid1.DataSource = obj;
            }
        }


        private void button6_Click(object sender, System.EventArgs e)
        {
            byte[] parabyte = XmlByteSerializer.Serialize(_holidaySettingWork);
            int status = 0;// IejibairtdtDB.LogicalDelete(ref parabyte);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
                else
                {
                    MessageBox.Show("何でか削除不可　status=" + status.ToString());
                }
            }
            else
            {
                Text = "削除成功";
                // XMLの読み込み
                _holidaySettingWork = (HolidaySettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(HolidaySettingWork));
                textBox7.Text = _holidaySettingWork.LogicalDeleteCode.ToString();

                //_makerWork = (MakerWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerWork));
                //textBox7.Text = _makerWork.LogicalDeleteCode.ToString();

            }
        }

        private void button9_Click(object sender, System.EventArgs e)
        {

            dataGrid2.DataSource = null;
            ArrayList al = new ArrayList();

            _holidaySettingWork = new HolidaySettingWork();
            //_makerWork = new MakerWork();
            _holidaySettingWork.EnterpriseCode = textBox1.Text;
            _holidaySettingWork.SectionCode = textBox2.Text;

            //_holidaySettingWork.ApplyStaDate = DateTime.Now;
            //_holidaySettingWork.ApplyEndDate = DateTime.Now;

            _holidaySettingWork.ApplyStaDate = DateTime.MinValue;
            _holidaySettingWork.ApplyEndDate = DateTime.MaxValue;

            al.Add(_holidaySettingWork);

            dataGrid2.DataSource = al;

        
        }

        /// <summary>
        /// 件数指定リード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, System.EventArgs e)
        {
        }

        private void button12_Click(object sender, System.EventArgs e)
        {
            //_ejibaiRtDtWork = new EjibaiRtDtWork();
            _holidaySettingWork.EnterpriseCode = textBox1.Text;
            //_makerWork.EnterpriseCode = textBox1.Text;
            //_ejibaiRtDtWork.SectionCode = textBox2.Text;
            //_ejibaiRtDtWork.RecordReadKey = Convert.ToInt32(textBox3.Text);

            //MakerWork[] paraarray = new MakerWork[] { _makerWork };
            HolidaySettingWork[] paraarray = new HolidaySettingWork[] { _holidaySettingWork };

            byte[] parabyte = XmlByteSerializer.Serialize(paraarray);
            //int status = ImakerDB.Delete(parabyte);
            int status = iHolidaySettingDB.Delete(parabyte);

            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
            }
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            //byte[] parabyte = XmlByteSerializer.Serialize(_makerWork);
            byte[] parabyte = XmlByteSerializer.Serialize(_holidaySettingWork);
            int status = 0;// IejibairtdtDB.RevivalLogicalDelete(ref parabyte);
            if (status != 0)
            {
                Text = "復活失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
                else
                {
                    MessageBox.Show("何でか復活不可　status=" + status.ToString());
                }
            }
            else
            {
                Text = "復活成功";
                // XMLの読み込み
                //_makerWork = (MakerWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerWork));
                _holidaySettingWork = (HolidaySettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(HolidaySettingWork));
                //textBox7.Text = _makerWork.LogicalDeleteCode.ToString();
                textBox7.Text = _holidaySettingWork.LogicalDeleteCode.ToString();
            }

        }

        private void button8_Click(object sender, System.EventArgs e)
        {

            object parabyte = dataGrid2.DataSource;
            object objsyncServerService;


            //int status = ImakerDB.Search(out objmaker, parabyte, 0, 0);
            int status = iHolidaySettingDB.Search(out objsyncServerService, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objsyncServerService).Count.ToString() + "件";

                dataGrid1.DataSource = objsyncServerService;
            }
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            object objholidaySettingWork = dataGrid1.DataSource;

            int status = iHolidaySettingDB.Write(ref objholidaySettingWork);
            if (status != 0)
            {
                Text = "更新失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "更新成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objholidaySettingWork;
            }
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            //MakerWork makerWork = new MakerWork();
            HolidaySettingWork holidaySettingWork = new HolidaySettingWork();
            //makerWork.EnterpriseCode = textBox1.Text;
            holidaySettingWork.EnterpriseCode = textBox1.Text;
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            //al.Add(makerWork);
            al.Add(holidaySettingWork); 
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        private void button13_Click(object sender, System.EventArgs e)
        {

            object objholidaySettingWork = dataGrid1.DataSource;

            int status = iHolidaySettingDB.LogicalDelete(ref objholidaySettingWork);

            if (status != 0)
            {
                Text = "論理削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "論理削除成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objholidaySettingWork;
            }
        }

        private void button15_Click(object sender, System.EventArgs e)
        {

            object objgholidaySettingWork = dataGrid1.DataSource;

            //int status = IlgoodsganreDB.Delete(ref objgoodsganreWork);


            HolidaySettingWork[] trarray = (HolidaySettingWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(HolidaySettingWork));
            //MakerWork[] trarray = (MakerWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(MakerWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            //int status = ImakerDB.Delete(parabyte);
            int status = iHolidaySettingDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再削除してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
                dataGrid1.DataSource = null;
                //dataGrid1.DataSource = objejibaiRtDtWork;
            }
        }

        private void button16_Click(object sender, System.EventArgs e)
        {
            //_makerWork = new MakerWork();
            //_makerWork.EnterpriseCode = textBox1.Text;

            _holidaySettingWork = new HolidaySettingWork();
            _holidaySettingWork.EnterpriseCode = textBox1.Text;

            //_ejibaiRtDtWork.SectionCode = Convert.ToInt32( textBox2.Text );

            ArrayList al = new ArrayList();

            //al.Add(_makerWork);
            al.Add(_holidaySettingWork);
            object parabyte = al;
            //object objmaker;

            int status = 0;// IejibairtdtDB.SearchHeaderCode(out objejibaiRtDt, parabyte, 0, 0);
            //listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                //Text = "該当データ有り  HIT "+((ArrayList)objejibaiRtDt).Count.ToString()+"件";

                //dataGrid1.DataSource = objejibaiRtDt;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            object objholidaySettingWork = dataGrid1.DataSource;

            int status = iHolidaySettingDB.RevivalLogicalDelete(ref objholidaySettingWork);
            //int status = ImakerDB.RevivalLogicalDelete(ref objmakerWork); 
            if (status != 0)
            {
                Text = "復活失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "復活成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objholidaySettingWork;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGrid3.DataSource = null;
            ArrayList al = new ArrayList();

            HolidaySettingSearchWork _holidaySettingSearchWork = new HolidaySettingSearchWork();
            //_makerWork = new MakerWork();
            _holidaySettingSearchWork.EnterpriseCode = textBox1.Text;
            string[] st = new string[2];
            st[0] = "000001";
            st[1] = "500";

            _holidaySettingSearchWork.SectionCodeList = st;

            //_holidaySettingWork.ApplyStaDate = DateTime.Now;
            //_holidaySettingWork.ApplyEndDate = DateTime.Now;

            _holidaySettingSearchWork.ApplyStaDate = DateTime.MinValue;
            _holidaySettingSearchWork.ApplyEndDate = DateTime.MaxValue;

            al.Add(_holidaySettingSearchWork);

            dataGrid3.DataSource = al;


        }

    }
}
