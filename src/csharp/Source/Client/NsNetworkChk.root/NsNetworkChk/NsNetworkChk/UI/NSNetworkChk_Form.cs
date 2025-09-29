using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using Broadleaf.NSNetworkChk.Data;
using Broadleaf.NSNetworkChk.Net;
using System.Security.Cryptography;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.NSNetworkChk.UI
{
    /// <summary>
    /// NSネットワーク通信テストメインUIクラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	2010.10.21 30469　羅偉傑</br>
    /// <br>                    ①複数プロダクト対応</br>
    /// <br>Update Note		:	2019.01.02 朱宝軍</br>
    /// <br>				:	①AWS通信テスト結果を登録する処理の追加</br>
    /// <br>				:	②AWS通信自動テスト処理の追加</br>
    /// <br>				:	③FTPチェック処理の追加</br>
    /// </remarks>
    public partial class NSNetworkChk_Form :Form
    {
        #region プライベートメンバ
        /// <summary>
        /// 前回実行時間
        /// </summary>
        TimeSpan _sleepTimeSpan = TimeSpan.MinValue;

        /// <summary>
        /// 前回実行結果情報クラスリスト
        /// </summary>
        List<NSNetworkTestInfo> _nSNetworkTestInfoList = null;

        /// <summary>
        /// ツール使用方法PDF
        /// </summary>
        string _operationSheet = "";
        /// <summary>
        /// 設定確認方法PDF
        /// </summary>
        string _confirmationSheet = "";
        /// <summary>
        /// テスト設定ファイル名
        /// </summary>
        string _fileName = "";
        #endregion


        #region Private Member
        /// <summary>
        /// 起動モード(0：手動起動；1：自動起動)
        /// </summary>
        private int _mode = 0;

        /// <summary>
        /// AWS自動テスト情報
        /// </summary>
        private NSNetWorkAutoTestInfo _nSNetWorkAutoTestInfo;

        /// <summary>
        /// AWS通信テスト結果ワーク
        /// </summary>
        private AWSComRsltWork _aWSCommTstRsltWork;

        /// <summary>
        /// テスト日付
        /// </summary>
        private DateTime _checkDateTime;

        /// <summary>
        /// ネットワーク通信処理クラス
        /// </summary>
        private NSNetworkTestAccess _nSNetworkTestAccess = null;

        /// <summary>保存先ファイル名称</summary>
        public const string CT_FILE_NAME = "NSNetworkAutoTest.XML";
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NSNetworkChk_Form()
        {
            InitializeComponent();

            _aWSCommTstRsltWork = new AWSComRsltWork();
            this._nSNetworkTestAccess = new NSNetworkTestAccess();

            this.Text = this.Text + "  Ver" + System.Windows.Forms.Application.ProductVersion;

            InitializeDataGridViewColumn(); //DataGridViewのColumn初期設定
            InitializeDataGridViewRow();    //DataGridViewのRow初期設定
            InitializeFileName();   //comboboxの内容初期設定

            SetControlEvent(this);

            this.Progress_toolStripProgressBar.Visible = false;
            this.Progress_label.Visible = false;



        }
        
        /// <summary>
        ///  自動起動処理
        /// </summary>
        /// <param name="mode">自動起動モード</param>
        /// <remarks>
        /// <br>Note       : 自動起動処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public void AutoNSNetworkTest(int mode)
        {
            this._mode = mode;

            _nSNetWorkAutoTestInfo = new NSNetWorkAutoTestInfo();
            int status = NSNetWorkAutoTestInfo.Deserialize(out _nSNetWorkAutoTestInfo, CT_FILE_NAME);

            if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING || _nSNetWorkAutoTestInfo.AutoStartupDiv == false)
            {
                return;
            }

            // 製品をセットする
            this.comboBox1.Text = _nSNetWorkAutoTestInfo.AutoProductName;

            //自動テスト開始
            backgroundWorker1.RunWorkerAsync();
            _sleepTimeSpan = new TimeSpan(DateTime.Now.AddMinutes(3).Ticks);
        }

        /// <summary>
        /// コンボボックスの内容初期設定
        /// </summary>
        /// <remarks> 
        /// <br>Note			:	</br>
        /// <br>Programer		:	羅　偉傑</br>                            
        /// <br>Date			:	2010.10.21</br>                              
        /// <br>Update Note		:	</br>                
        /// </remarks>
        private void InitializeFileName()
        {
            List<MyComboBoxItemInfo> list = new List<MyComboBoxItemInfo>();
            MyComboBoxItemInfo item;

            int count = Convert.ToInt16(ConfigurationManager.AppSettings.Get("ProductCount"));

            string nameKey = "ProductName_";
            string filePathKey = "File_";

            string nameValue = string.Empty;
            string fileValue = string.Empty;

            try
            {
                string myKey = ConfigurationManager.AppSettings.Get("defaultKey_1");
                string myValue = ConfigurationManager.AppSettings.Get("defaultFalue_1");

                item = new MyComboBoxItemInfo(myKey, myValue);

                list.Add(item);
                {
                    for (int i = 1; i < count + 1; i++)
                    {
                        nameValue = ConfigurationManager.AppSettings.Get(nameKey + i);
                        fileValue = ConfigurationManager.AppSettings.Get(filePathKey + i);
                        if (nameValue != null & fileValue != null)
                        {
                            item = new MyComboBoxItemInfo(nameValue, fileValue);
                            list.Add(item);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIG_NG, NSNetworkTestMsgConst.MSG_TITLE_ERROR);
            }
            
            this.comboBox1.DataSource = list;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "filePath";
        }
        /// <summary>
        /// データグリッドビュー列初期設定
        /// </summary>
        private void InitializeDataGridViewColumn()
        {
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();

            column1.HeaderText = NSNetworkTestMsgConst.TEST_COLUMN_ITEMNAME;
            column1.Name = NSNetworkTestMsgConst.TEST_COLUMN_ITEM;
            column1.Width = 250;

            column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            column2.HeaderText = NSNetworkTestMsgConst.TEST_COLUMN_RESULTNAME;
            column2.Name = NSNetworkTestMsgConst.TEST_COLUMN_RESULT;

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, });

        }

        /// <summary>
        /// データグリッドビュー行初期設定
        /// </summary>
        private void InitializeDataGridViewRow()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Rows.Add(4);
            dataGridView1.Rows[0].Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value = NSNetworkTestMsgConst.TEST_PROXY_SERVER;
            dataGridView1.Rows[1].Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value = NSNetworkTestMsgConst.TEST_WEB_SERVER;
            dataGridView1.Rows[2].Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value = NSNetworkTestMsgConst.TEST_AP_SERVER;
            dataGridView1.Rows[3].Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value = NSNetworkTestMsgConst.TEST_DELIVERY_SERVER;

            dataGridView1.Rows[0].Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.TEST_RESULT_NONE;
            dataGridView1.Rows[1].Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.TEST_RESULT_NONE;
            dataGridView1.Rows[2].Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.TEST_RESULT_NONE;
            dataGridView1.Rows[3].Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.TEST_RESULT_NONE;
        }

        #endregion


        #region コントロールイベント

        #region ボタン押下
        /// <summary>
        /// 実行ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_button_Click(object sender, EventArgs e)
        {
            //既に実行中、3分以内の連続実行は許可しない。
            if( backgroundWorker1.IsBusy || _sleepTimeSpan.Ticks > DateTime.Now.Ticks)
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_CONTINUOSEXECTION_NG, NSNetworkTestMsgConst.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //  コンボボックスに項目を選択しない場合
                if (_fileName == "" | _fileName == "configDefault")
                {
                    MessageBox.Show(NSNetworkTestMsgConst.MSG_SELECT_NG, NSNetworkTestMsgConst.MSG_TITLE_WARNING);
                    return;
                }
                //  テスト設定ファイルが存在しない場合
                if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\" + _fileName))
                {
                    MessageBox.Show(NSNetworkTestMsgConst.MSG_EXISTENCE_NG, NSNetworkTestMsgConst.MSG_TITLE_ERROR);
                    return;
                }
                
                this.ErrorView_button.Enabled = false;
                this.Progress_toolStripProgressBar.Visible = true;
                this.Progress_label.Visible = true;
                this.Progress_label.Text = "0";

                
                
                //テスト開始
                backgroundWorker1.RunWorkerAsync();
                _sleepTimeSpan = new TimeSpan( DateTime.Now.AddMinutes(3).Ticks);
            }
        }

        /// <summary>
        /// 中止ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if( this.backgroundWorker1.IsBusy )
            {
                DialogResult res = MessageBox.Show(NSNetworkTestMsgConst.MSG_IS_PROCESSINGDISCONTINUED, NSNetworkTestMsgConst.MSG_TITLE_CONFIRMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if( res == DialogResult.Yes )
                {
                    //非同期処理の中止
                    this.backgroundWorker1.CancelAsync();
                }
            }
        }

        /// <summary>
        /// 終了ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = DialogResult.Yes;
            if( this.backgroundWorker1.IsBusy )
            {
                //終了確認
                res = MessageBox.Show(NSNetworkTestMsgConst.MSG_ENDCHECK, NSNetworkTestMsgConst.MSG_TITLE_CONFIRMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if(res == DialogResult.Yes )
            {
                this.Close();
            }
        }


        /// <summary>
        /// バージョンボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void バージョンToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Text, NSNetworkTestMsgConst.MSG_TITLE_VERSION, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( this.backgroundWorker1.IsBusy )
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_EXECUTING_LOADSAVE_NG, NSNetworkTestMsgConst.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if( _nSNetworkTestInfoList == null )
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_TESTDATANOTFOUND, NSNetworkTestMsgConst.MSG_TITLE_WARNING, MessageBoxButtons.OK);
                return;
            }

            DialogResult res = MessageBox.Show(NSNetworkTestMsgConst.MSG_RESULTDATASAVE_CHECK, NSNetworkTestMsgConst.MSG_TITLE_CONFIRMATION, MessageBoxButtons.YesNo);
            if( res == DialogResult.Yes )
            {
                string saveFileName = _fileName.Substring(0, 5).Remove(2,1);
                string fileName = string.Format("{0}_{1}_result.dat", saveFileName, DateTime.Now.ToString("yyyyMMddHHmm"));
                //既に同じ名前のファイルがある場合は、名称を変更する。
                if( File.Exists(fileName) )
                {
                    for( int ix = 1; ix < 60; ix++ )
                    {
                        if( !File.Exists(string.Format("{0}_{1}", ix, fileName)) )
                        {
                            fileName = string.Format("{0}_{1}", ix, fileName);
                            break;
                        }
                    }
                }

                //テスト結果出力
                if( NSNetworkTestInfoList_Serialize(_nSNetworkTestInfoList, fileName) )
                {
                    MessageBox.Show(string.Format("{0}\r\n\r\n『{1}\\Result\\{2}』に保存されています。", NSNetworkTestMsgConst.MSG_RESULTDATASAVE_OK, System.Windows.Forms.Application.StartupPath, fileName), NSNetworkTestMsgConst.MSG_TITLE_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(NSNetworkTestMsgConst.MSG_RESULTDATASAVE_NG, NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// 開くボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( this.backgroundWorker1.IsBusy )
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_EXECUTING_LOADSAVE_NG, NSNetworkTestMsgConst.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult res = this.openFileDialog1.ShowDialog();
            if( res == DialogResult.OK )
            {
                bool result = true;
                //テスト項目情報を取得する。
                NSNetworkTestInfoList_Deserialize(out _nSNetworkTestInfoList, this.openFileDialog1.FileName);

                List<NSNetworkTestInfo> proxyTestList = _nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.PROXY; });
                List<NSNetworkTestInfo> webTestList = _nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.WEB; });
                List<NSNetworkTestInfo> apTestList = _nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP; });
                List<NSNetworkTestInfo> bitsTestList = _nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.BITS; });

                //●プロキシテスト・設定取得
                ProxyInfo proxyInfo = _nSNetworkTestInfoList[0].ProxyInfo;
                result = SetProxyServerResult(proxyInfo);
                //●各サーバー種別毎のテスト結果表示
                if( !SetWebServerResult(webTestList) )
                {
                    result = false;
                }
                if( !SetAPServerResult(apTestList) )
                {
                    result = false;
                }
                if( !SetBITSServerResult(bitsTestList) )
                {
                    result = false;
                }


                if( !result )
                {
                    res = MessageBox.Show(NSNetworkTestMsgConst.MSG_RESULTNGSHOW_NG, NSNetworkTestMsgConst.MSG_TITLE_CONFIRMATION, MessageBoxButtons.YesNo);
                    this.ErrorView_button.Enabled = true;
                }
                if( res == DialogResult.Yes )
                {
                    Error_Form fm = new Error_Form(GetResultString());
                    fm.Show();
                }
            }
        }


        /// <summary>
        /// エラー詳細ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorView_button_Click(object sender, EventArgs e)
        {
            Error_Form fm = new Error_Form(GetResultString());
            fm.Show();
        }
        #endregion


        #region ヘルプ関係
        /// <summary>
        /// ツールの使用方法表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentContent_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( _operationSheet == "" )
            {
                try
                {
                    _operationSheet = File.ReadAllLines(Path.Combine(System.Windows.Forms.Application.StartupPath, "pdf.dat"), Encoding.Default)[0];
                }
                catch
                {
                    MessageBox.Show("『pdf.dat』の読込に失敗しました。", NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string fileFullPath = Path.Combine(System.Windows.Forms.Application.StartupPath, _operationSheet);
            if( File.Exists(fileFullPath) )
            {
                try
                {
                    Process.Start(fileFullPath);
                }
                catch
                {
                    MessageBox.Show(string.Format("『{0}』の表示に失敗しました。", _operationSheet), NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(string.Format("『{0}』が見つかりませんでした。", _operationSheet), NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// ネットワーク設定の確認方法表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if( _confirmationSheet == "" )
            {
                try
                {
                    _confirmationSheet = File.ReadAllLines(Path.Combine(System.Windows.Forms.Application.StartupPath, "pdf.dat"), Encoding.Default)[1];
                }
                catch
                {
                    MessageBox.Show("『pdf.dat』の読込に失敗しました。", NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string fileFullPath = Path.Combine(System.Windows.Forms.Application.StartupPath, _confirmationSheet);
            if( File.Exists(fileFullPath) )
            {
                try
                {
                    Process.Start(fileFullPath);
                }
                catch
                {
                    MessageBox.Show(string.Format("『{0}』の表示に失敗しました。", _confirmationSheet), NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(string.Format("『{0}』が見つかりませんでした。", _confirmationSheet), NSNetworkTestMsgConst.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        /// <summary>
        /// 描画範囲にカーソルが入ったときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if( control.Tag != null )
            {
                this.toolStripStatusLabel1.Text = control.Tag.ToString();
            }
        }
        /// <summary>
        /// 描画範囲からカーソルが抜けたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if( control.Tag != null )
            {
                this.toolStripStatusLabel1.Text = string.Empty;
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NSNetworkChk_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = DialogResult.Yes;
            if( this.backgroundWorker1.IsBusy )
            {
                //終了確認
                res = MessageBox.Show(NSNetworkTestMsgConst.MSG_ENDCHECK, NSNetworkTestMsgConst.MSG_TITLE_CONFIRMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if( res == DialogResult.No )
            {
                e.Cancel = true;
            }
        }
        #endregion


        #region プライベートメソッド

        #region データクラス保存、読み込み処理
        /// <summary>
        /// データクラス読み込み
        /// </summary>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool NSNetworkTestInfoList_Deserialize(out List<NSNetworkTestInfo> nSNetworkTestInfoList,string fileName)
        {
            bool result = false;
            nSNetworkTestInfoList = null;
            try
            {
                //using( FileStream fileStream = new FileStream(fileName, FileMode.Open) )
                //{
                //    BinaryFormatter binaryFormatter = new BinaryFormatter();
                //    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(fileStream);
                //}

                byte[] desKey;
                byte[] desIv;
                byte[] resultBytes;
                byte[] dataBytes;

                resultBytes = FileReadProc("", fileName, out desKey, out desIv);
                dataBytes = CompoundDataProc(resultBytes, desKey, desIv);
                using( MemoryStream r = new MemoryStream() )
                {
                    r.Write(dataBytes, 0, dataBytes.Length);
                    r.Position = 0;
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(r);
                }
                result = true;
            }
            catch( Exception ex )
            {
                result = false;
                nSNetworkTestInfoList = null;
                if (this._mode == 0)
                {
                    MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIGLOAD_NG);
                }
            }
            return result;
        }

        /// <summary>
        /// ファイル読込処理
        /// </summary>
        /// <param name="logFilePath">保存ファイルパス</param>
        /// <param name="logFileName">保存ファイル名称</param>
        /// <param name="desKey">暗号化キー</param>
        /// <param name="desIv">暗号化キー</param>
        /// <returns>読込結果</returns>
        private byte[] FileReadProc(string logFilePath, string logFileName, out byte[] desKey, out byte[] desIv)
        {
            desKey = null;
            desIv = null;
            byte[] result = null;

            //フルパス取得
            string logFileFullPath = logFileName;

            ////保存用ディレクトリが無い場合は終了
            ////if (!Directory.Exists(logFilePath))
            ////    return result;

            ////フルパス取得
            ////string logFileFullPath = Path.Combine(logFilePath, logFileName);

            //①画像情報が存在しない場合終了
            if( !File.Exists(logFileFullPath) )
                return result;

            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                //--------------------------------?------------------------------
                RijndaelManaged rijndaelManaged = new RijndaelManaged();

                fs = new FileStream(logFileFullPath, FileMode.Open);
                //①ファイル読み込み
                br = new BinaryReader(fs);
                desKey = br.ReadBytes((int)rijndaelManaged.Key.Length);
                desIv = br.ReadBytes((int)rijndaelManaged.IV.Length);
                result = br.ReadBytes((int)( fs.Length - ( rijndaelManaged.Key.Length + rijndaelManaged.IV.Length ) ));
                //--------------------------------?-------------------------------
                br.Close();
                br = null;
                fs.Close();
                fs = null;
            }
            catch( Exception ex )
            {
                if( br != null )
                    br.Close();
                if( fs != null )
                    fs.Close();
                throw new Exception(string.Format("ファイルの読込に失敗しました。Exception:{0}  FilePath:{1}", ex.Message, logFileFullPath), ex);
            }
            finally
            {
                if( br != null )
                    br.Close();
                if( fs != null )
                    fs.Close();
            }
            return result;
        }
       
        /// <summary>
        /// 複合化処理
        /// </summary>
        /// <param name="data">複合化対象データ</param>
        /// <param name="desKey">暗号化KEY</param>
        /// <param name="desIv">暗号化KEY</param>
        /// <returns>複合結果</returns>
        private byte[] CompoundDataProc(byte[] data, byte[] desKey, byte[] desIv)
        {
            // Trippe DES のサービス プロバイダを生成します
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] destination;

            // 入出力用のストリームを生成します
            using( MemoryStream ms = new MemoryStream() )
            {
                CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateDecryptor(desKey, desIv), CryptoStreamMode.Write);

                // ストリームに暗号化されたデータを書き込みます
                cs.Write(data, 0, data.Length);
                cs.Close();

                // 復号化されたデータを byte 配列で取得します
                destination = ms.ToArray();
                ms.Close();
            }
            return destination;
        }

        /// <summary>
        /// データクラス保存
        /// </summary>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool NSNetworkTestInfoList_Serialize(List<NSNetworkTestInfo> nSNetworkTestInfoList, string fileName)
        {
            bool result = false;
            string resultPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Result");
            //string saveFileName = Path.Combine(resultPath, fileName);

            try
            {
                //if( !Directory.Exists(resultPath) )
                //{
                //    Directory.CreateDirectory(resultPath);
                //}

                using( MemoryStream memoryStream = new MemoryStream() )
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(memoryStream, nSNetworkTestInfoList);

                    byte[] g;
                    byte[] h;
                    byte[] i;

                    i = EncryptionDataProc(memoryStream.ToArray(), out g, out h);
                    FileSaveProc(i, resultPath, fileName, g, h);
                }
                result = true;
            }
            catch( Exception ex )
            {
                MessageBox.Show(NSNetworkTestMsgConst.MSG_CONFIGSAVE_NG);
            }

            return result;
        }

        /// <summary>
        /// 暗号化処理
        /// </summary>
        /// <param name="data">暗号化対象データ</param>
        /// <param name="desKey">暗号化KEY</param>
        /// <param name="desIv">暗号化KEY</param>
        /// <returns>暗号結果</returns>
        private byte[] EncryptionDataProc(byte[] data, out byte[] aesKey, out byte[] aesIv)
        {
            // AES暗号化部品を生成します
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            aesKey = rijndaelManaged.Key;
            aesIv = rijndaelManaged.IV;

            // 入出力用のストリームを生成します
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateEncryptor(aesKey, aesIv), CryptoStreamMode.Write);

            // ストリームに暗号化するデータを書き込みます
            cs.Write(data, 0, data.Length);
            cs.Close();

            // 暗号化されたデータを byte 配列で取得します
            byte[] destination = ms.ToArray();
            ms.Close();

            return destination;
        }

        /// <summary>
        /// ファイル保存処理
        /// </summary>
        /// <param name="encryptionData">保存データ</param>
        /// <param name="logFilePath">保存ファイルパス</param>
        /// <param name="logFileName">保存ファイル名称</param>
        /// <param name="desKey">暗号化キー</param>
        /// <param name="desIv">暗号化キー</param>
        private void FileSaveProc(byte[] encryptionData, string logFilePath, string logFileName, byte[] desKey, byte[] desIv)
        {
            //保存用ディレクトリが無い場合は作成
            if( !Directory.Exists(logFilePath) )
                Directory.CreateDirectory(logFilePath);

            //フルパス取得
            string logFileFullPath = Path.Combine(logFilePath, logFileName);

            //①画像情報が既に存在する場合
            if( File.Exists(logFileFullPath) )
            {
                //②属性を書き込み可能に変更
                File.SetAttributes(logFileFullPath, FileAttributes.Normal);
            }

            //ファイル保存
            FileStream fs = null;
            try
            {
                //③ファイル書き込み
                fs = File.Create(logFileFullPath);
                fs.Write(desKey, 0, desKey.Length);
                fs.Write(desIv, 0, desIv.Length);
                fs.Write(encryptionData, 0, encryptionData.Length);
                fs.Close();
                fs = null;
            }
            catch( Exception ex )
            {
                if( fs != null )
                    fs.Close();
                throw ex;
            }
            finally
            {
                if( fs != null )
                    fs.Close();
            }
        }
			

        #endregion

        #region 非同期処理
        /// <summary>
        /// 非同期処理（開始）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = true;
            //テスト項目情報を取得する。
            List<NSNetworkTestInfo> nSNetworkTestInfoList;
            if (!NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, System.Windows.Forms.Application.StartupPath + "\\" + _fileName))
            {
                e.Cancel = true;
                e.Result = null;
                return;
            }

            //テスト日付を取得する。
            this._checkDateTime = DateTime.Now;

            #region テスト項目毎にリスト分け
            List<NSNetworkTestInfo> proxyTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.PROXY; });
            List<NSNetworkTestInfo> webTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.WEB; });
            List<NSNetworkTestInfo> apTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP; });
            List<NSNetworkTestInfo> bitsTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.BITS; });
            #endregion

            #region プロキシ
            //●プロキシテスト・設定取得
            backgroundWorker1.ReportProgress(0, NSNetworkTestInfo.ServerType.PROXY);
            ProxyInfo proxyInfo = NSNetworkTestAccess.CheckProxy();
            foreach( NSNetworkTestInfo nSNetworkTestInfo in proxyTestList )
            {
                proxyInfo = NSNetworkTestAccess.CheckProxy(nSNetworkTestInfo.NSNetworkTestTargetUri);  
                nSNetworkTestInfo.ProxyInfo = proxyInfo;
                nSNetworkTestInfo.Ex = proxyInfo.Ex;
                if( proxyInfo.Ex != null )
                {
                    WebException webex = (WebException)proxyInfo.Ex;
                    if( webex.Response == null )
                    {
                        //ステータスコードが分からない例外は全て「-1」とする。
                        nSNetworkTestInfo.WebRequestStatusNo = -1;
                    }
                    else
                    {
                        //HTTPリクエストのステータスをセット
                        nSNetworkTestInfo.WebRequestStatusNo = (int)( (HttpWebResponse)webex.Response ).StatusCode;
                    }
                }
            }
            if( proxyInfo.IsProxy == ProxyInfo.ProxyType.USE && proxyInfo.ProxyAuthentication != ProxyInfo.AuthenticationType.NONE )
            {
                //認証が必要なプロキシを利用している時にエラーとする。
                //※認証が必要なしは正常に動作する。
                result = false;
            }

            if( backgroundWorker1.CancellationPending )
            {
                e.Cancel = true;
                e.Result = null;
                return;
            }
            backgroundWorker1.ReportProgress(15, proxyInfo);
            #endregion
            
            #region WEB
            backgroundWorker1.ReportProgress(25, NSNetworkTestInfo.ServerType.WEB);
            if( !TestProc(proxyInfo, webTestList) )
            {
                result = false;
            }
            if( backgroundWorker1.CancellationPending )
            {
                e.Cancel = true;
                e.Result = null;
                return;
            }
            backgroundWorker1.ReportProgress(40, webTestList);
            #endregion

            
            #region AP
            backgroundWorker1.ReportProgress(50, NSNetworkTestInfo.ServerType.AP);
            if( !TestProc(proxyInfo, apTestList) )
            {
                result = false;
            }
            if( backgroundWorker1.CancellationPending )
            {
                e.Cancel = true;
                e.Result = null;
                return;
            }
            backgroundWorker1.ReportProgress(65, apTestList);
            #endregion
            
            #region BITS
            backgroundWorker1.ReportProgress(75, NSNetworkTestInfo.ServerType.BITS);
            if( !TestProc(proxyInfo, bitsTestList) )
            {
                result = false;
            }
            if( backgroundWorker1.CancellationPending )
            {
                e.Cancel = true;
                e.Result = null;
                return;
            }
            backgroundWorker1.ReportProgress(100, bitsTestList);
            #endregion

            e.Result = new object[] { result, nSNetworkTestInfoList };
        }

        /// <summary>
        /// 非同期処理（進行状況通知）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Progress_label.Text = e.ProgressPercentage.ToString();

            if( e.UserState != null )
            {
                if( e.UserState is NSNetworkTestInfo.ServerType )
                {
                    string itemName = "";
                    NSNetworkTestInfo.ServerType serverType = (NSNetworkTestInfo.ServerType)e.UserState;

                    if( serverType == NSNetworkTestInfo.ServerType.PROXY )
                    {
                        itemName = NSNetworkTestMsgConst.TEST_PROXY_SERVER;
                    }
                    else if( serverType == NSNetworkTestInfo.ServerType.WEB )
                    {
                        itemName = NSNetworkTestMsgConst.TEST_WEB_SERVER;
                    }
                    else if( serverType == NSNetworkTestInfo.ServerType.AP )
                    {
                        itemName = NSNetworkTestMsgConst.TEST_AP_SERVER;
                    }
                    else if( serverType == NSNetworkTestInfo.ServerType.BITS )
                    {
                        itemName = NSNetworkTestMsgConst.TEST_DELIVERY_SERVER;
                    }

                    foreach( DataGridViewRow row in this.dataGridView1.Rows )
                    {
                        if( row.Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value.ToString() == itemName )
                        {
                            row.Selected = true;
                            row.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = "処理中...";
                            break;
                        }
                    }
                }

                //●プロキシテスト結果
                else if( e.UserState is ProxyInfo )
                {
                    SetProxyServerResult((ProxyInfo)e.UserState);
                }
                else if( e.UserState is List<NSNetworkTestInfo> )
                {
                    List<NSNetworkTestInfo> nSNetworkTestInfoList = (List<NSNetworkTestInfo>)e.UserState;
                    if( nSNetworkTestInfoList.Count == 0 )
                    {
                        //処理結果がゼロ件の場合
                        return;
                    }

                    //●各サーバー種別毎のテスト結果表示
                    switch( nSNetworkTestInfoList[0].NSNetworkServerType )
                    {
                        case NSNetworkTestInfo.ServerType.WEB:
                            {
                                SetWebServerResult(nSNetworkTestInfoList);
                                break;
                            }
                        case NSNetworkTestInfo.ServerType.AP:
                            {
                                SetAPServerResult(nSNetworkTestInfoList);
                                break;
                            }
                        case NSNetworkTestInfo.ServerType.BITS:
                            {
                                SetBITSServerResult(nSNetworkTestInfoList);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// 非同期処理（処理完了通知）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    _nSNetworkTestInfoList = null;
                    this.Progress_label.Visible = false;
                    this.Progress_toolStripProgressBar.Visible = false;
                    if (this._mode == 0)
                    {
                        MessageBox.Show(NSNetworkTestMsgConst.MSG_EXECUTINGSOPAPPCLOSE_NG, NSNetworkTestMsgConst.MSG_TITLE_WARNING);
                    }
                    this.Close();
                    return;
                }

                object[] result = (object[])e.Result;
                bool status = (bool)result[0];
                //テスト結果をリストに再セットする。
                _nSNetworkTestInfoList = (List<NSNetworkTestInfo>)result[1];

                if (this._mode == 0)
                {
                    //結果表示
                    if (!status)
                    {
                        DialogResult res = MessageBox.Show(NSNetworkTestMsgConst.MSG_RESULTNGSHOW_NG, NSNetworkTestMsgConst.MSG_TITLE_CONFIRMATION, MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            Error_Form fm = new Error_Form(GetResultString());
                            fm.Show();
                        }
                        this.ErrorView_button.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(NSNetworkTestMsgConst.MSG_RESULTOK_OK, NSNetworkTestMsgConst.MSG_TITLE_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Progress_label.Visible = false;
                    this.Progress_toolStripProgressBar.Visible = false;
                }
                else
                {
                    //テスト結果をユーザーDBに登録する
                    int statusResult = WriteDataToDB(_nSNetworkTestInfoList);
                }
            }
            finally
            {
                if (this._mode != 0)
                {
                    //アプリケーション終了
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        #endregion


        private void SetControlEvent(Control parent)
        {
            foreach( Control controls in parent.Controls )
            {
                // 子を持つコンポーネントの場合、子にイベント追加
                if( controls.HasChildren )
                {
                    SetControlEvent(controls);
                }
                else
                {
                    controls.MouseEnter += new EventHandler(this.Control_MouseEnter);
                    controls.MouseLeave += new EventHandler(this.Control_MouseLeave);
                }
            }
        }

        /// <summary>
        /// AWSテスト結果登録処理
        /// </summary>
        /// <param name="nsNetworkTestInfoList">AWSテスト情報クラスのリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ネットワーク通信処理クラスのDB登録処理を利用する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private int WriteDataToDB(List<NSNetworkTestInfo> nsNetworkTestInfoList)
        {
            bool msgDiv;
            string errMsg;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ログイン情報を取得する。
            this._aWSCommTstRsltWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._aWSCommTstRsltWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._aWSCommTstRsltWork.CheckDate = int.Parse(this._checkDateTime.ToString("yyyyMMdd"));
            this._aWSCommTstRsltWork.CheckTime = int.Parse(this._checkDateTime.ToString("HHmmss"));
            this._aWSCommTstRsltWork.ComputerName = System.Environment.MachineName;

            List<NSNetworkTestInfo> nSNetworkTestInfoList = nsNetworkTestInfoList;
            AWSComRsltWork aWSCommTstRsltWork = this._aWSCommTstRsltWork;
            status = this._nSNetworkTestAccess.WriteDBData(nSNetworkTestInfoList, aWSCommTstRsltWork, out msgDiv, out errMsg);

            return status;
        }

        /// <summary>
        /// テスト実行部
        /// </summary>
        /// <param name="proxyInfo"></param>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool TestProc(ProxyInfo proxyInfo, List<NSNetworkTestInfo> nSNetworkTestInfoList)
        {
            bool result = true;
            //各種テストを行う。
            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
            {
                //●テストを行わない。
                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST )
                {
                    nSNetworkTestInfo.CheckResult = false;
                    continue;
                }

                if( backgroundWorker1.CancellationPending )
                {
                    break;
                }
                
                #region Proxy情報
                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS )
                {
                     //BITS（WINHTTP)のプロキシ設定を取得
                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
                }
                else
                {
                    if(WebRequest.DefaultWebProxy.IsBypassed(nSNetworkTestInfo.NSNetworkTestTargetUri) == false)
                    {
                        nSNetworkTestInfo.ProxyInfo = proxyInfo;
                    }
                }

                if( backgroundWorker1.CancellationPending )
                {
                    break;
                }
               
                #endregion

                #region HTTP
                //●HTTPリクエストテストを行う。
                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.HTTPREQUEST )
                {
                    if( NSNetworkTestAccess.HttpRequest(nSNetworkTestInfo) )
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }

                if( backgroundWorker1.CancellationPending )
                {
                    break;
                }
                #endregion

                #region ポート
                //●ポート接続テストを行う。
                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.PORTCONNECT )
                {
                    if( NSNetworkTestAccess.CheckPort(nSNetworkTestInfo) )
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }

                if( backgroundWorker1.CancellationPending )
                {
                    break;
                }
                #endregion

                #region BITS
                //●BITS配信テストを行う。
                if( nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS )
                {
                    //BITS（WINHTTP)のプロキシ設定を取得
                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
                    if( BitsMng.Download(nSNetworkTestInfo) )
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }

                if( backgroundWorker1.CancellationPending )
                {
                    break;
                }
                #endregion

                #region FTP
                //●FTP配信テストを行う。
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.FTPCONNCT)
                {
                    if (NSNetworkTestAccess.FtpRequest(nSNetworkTestInfo, _fileName))
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }

                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                #endregion
            }
            return result;
        }

        #region テスト結果表示
        /// <summary>
        /// テスト結果詳細表示用文字列取得
        /// </summary>
        /// <param name="serverType"></param>
        /// <returns></returns>
        private string GetResultString()
        {
            //Dictionary<NSNetworkTestInfo.ServerType, List<string>> errorDictionary = new Dictionary<NSNetworkTestInfo.ServerType, List<string>>();
            List<NSNetworkTestInfo.ServerType> errorDictionary = new List<NSNetworkTestInfo.ServerType>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach( NSNetworkTestInfo nSNetworkTestInfo in _nSNetworkTestInfoList )
            {
                #region APやWEBごとにプロキシﾁｪｯｸ結果を表示する場合コメントを外す
                //if( nSNetworkTestInfo.CheckResult && nSNetworkTestInfo.ProxyInfo != null && nSNetworkTestInfo.ProxyInfo.ProxyAuthentication != ProxyInfo.AuthenticationType.NONE )
                //{
                //    //認証が必要なプロキシを利用している場合はエラーとする。

                //    if( !errorDictionary.Contains(nSNetworkTestInfo.NSNetworkServerType) )
                //    {
                //        stringBuilder.Append(string.Format("\r\n【{0}】\r\n", NSNetworkTestInfo.GetServerTypeName(nSNetworkTestInfo.NSNethworkServerType)));
                //        errorDictionary.Add(nSNetworkTestInfo.NSNetworkServerType);
                //    }

                //    stringBuilder.Append(string.Format("　■[{0}]\r\n", nSNetworkTestInfo.NSNetworkTestName));
                //    stringBuilder.Append(string.Format("　　 ・[{0}]：{1}\r\n", "407", "プロキシの認証が必要です。"));
                //}
                #endregion

                if( !nSNetworkTestInfo.CheckResult && nSNetworkTestInfo.Ex != null )
                {
                    #region コメントアウト
                    //if( !errorDictionary.ContainsKey(nSNetworkTestInfo.NSNetworkServerType))
                    //{
                    //    stringBuilder.Append(string.Format("\r\n■{0}\r\n", nSNetworkTestInfo.NSNetworkTestName));
                    //    errorDictionary.Add(nSNetworkTestInfo.NSNetworkServerType,  new List<string>());
                    //}

                    //if(!errorDictionary[nSNetworkTestInfo.NSNetworkServerType].Contains(nSNetworkTestInfo.Ex.Message) )
                    //{
                    //    stringBuilder.Append(string.Format("　・[{0}]：{1}\r\n", nSNetworkTestInfo.WebRequestStatusNo, nSNetworkTestInfo.Ex.Message));
                    //    errorDictionary[nSNetworkTestInfo.NSNetworkServerType].Add(nSNetworkTestInfo.Ex.Message);
                    //}
                    #endregion

                    if( !errorDictionary.Contains(nSNetworkTestInfo.NSNetworkServerType) )
                    {
                        stringBuilder.Append(string.Format("\r\n【{0}】\r\n", NSNetworkTestInfo.GetServerTypeName(nSNetworkTestInfo.NSNetworkServerType)));
                        errorDictionary.Add(nSNetworkTestInfo.NSNetworkServerType);
                    }

                    string exMessage = nSNetworkTestInfo.Ex.Message;
                    if( 0 <= nSNetworkTestInfo.Ex.Message.IndexOf("リモート名を解決できませんでした。:") )
                    {
                        try
                        {
                            //ドメインがエラーメッセージに表示されるのでそれを隠蔽する。
                            exMessage = nSNetworkTestInfo.Ex.Message.Split(new char[] { ':' })[0];
                        }
                        catch
                        {
                            //ここのエラーは無視する。
                        }
                    }
                    stringBuilder.Append(string.Format("　■[{0}]\r\n", nSNetworkTestInfo.NSNetworkTestName));
                    stringBuilder.Append(string.Format("　　 ・[{0}]：{1}\r\n", nSNetworkTestInfo.WebRequestStatusNo, exMessage));

                    #region コメントアウト
                    //if( !errorDictionary[nSNetworkTestInfo.NSNetworkServerType].Contains(nSNetworkTestInfo.Ex.Message) )
                    //{
                    //    stringBuilder.Append(string.Format("　・[{0}]：{1}\r\n", nSNetworkTestInfo.WebRequestStatusNo, nSNetworkTestInfo.Ex.Message));
                    //    errorDictionary[nSNetworkTestInfo.NSNetworkServerType].Add(nSNetworkTestInfo.Ex.Message);
                    //}
                    #endregion
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// テスト結果表示（プロキシ用）
        /// </summary>
        /// <returns></returns>
        private bool SetProxyServerResult(ProxyInfo proxyInfo)
        {
            bool result = true;

            DataGridViewRow proxyServerRow = null;
            foreach( DataGridViewRow row in this.dataGridView1.Rows )
            {
                if( row.Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value.ToString() == NSNetworkTestMsgConst.TEST_PROXY_SERVER )
                {
                    proxyServerRow = row;
                    break;
                }
            }

            //プロキシ利用と認証の判定
            if( proxyInfo.IsProxy == ProxyInfo.ProxyType.NOT_USE )
            {
                //プロキシ利用なし
                proxyServerRow.DefaultCellStyle.BackColor = this.dataGridView1.DefaultCellStyle.BackColor;
                proxyServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_OK;
            }
            //else if( proxyInfo.IsProxy == ProxyInfo.ProxyType.FREE_USE )
            //{
            //    //プロキシは設定されているが利用しなくても通信可能

            //}
            else if( proxyInfo.IsProxy == ProxyInfo.ProxyType.USE )
            {
                if( proxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.NONE )
                {                
                    //プロキシ利用有だが、認証無しで接続が可能なときはOKとする
                    proxyServerRow.DefaultCellStyle.BackColor = this.dataGridView1.DefaultCellStyle.BackColor;
                    proxyServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_OK;

                }
                else
                {
                    //プロキシ利用必須
                    proxyServerRow.DefaultCellStyle.BackColor = Color.LightPink;
                    proxyServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_RESULTPROXYCHECK_NG;
                }
            }
            else
            {
                //その他（ここを通る事はありえない）
                proxyServerRow.DefaultCellStyle.BackColor = Color.LightPink;
                proxyServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_RESULTPROXYCHECK_NG;
            }

            return result;
        }

        /// <summary>
        /// テスト結果表示（WEB用）
        /// </summary>
        /// <returns></returns>
        private bool SetWebServerResult(List<NSNetworkTestInfo> nSNetworkTestInfoList)
        {
            bool result = true;

            DataGridViewRow webServerRow = null;
            foreach( DataGridViewRow row in this.dataGridView1.Rows )
            {
                if( row.Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value.ToString() == NSNetworkTestMsgConst.TEST_WEB_SERVER )
                {
                    webServerRow = row;
                    break;
                }
            }

            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
            {
                if( !nSNetworkTestInfo.CheckResult )
                {
                    result = false;
                    break;
                }
            }

            if( result )
            {
                webServerRow.DefaultCellStyle.BackColor = this.dataGridView1.DefaultCellStyle.BackColor;
                webServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_OK;
            }
            else
            {
                webServerRow.DefaultCellStyle.BackColor = Color.LightPink;
                webServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_RESULTNETWORK_NG;
            }

            return result;
        }

        /// <summary>
        /// テスト結果表示（AP用）
        /// </summary>
        /// <returns></returns>
        private bool SetAPServerResult(List<NSNetworkTestInfo> nSNetworkTestInfoList)
        {
            bool result = true;

            DataGridViewRow apServerRow = null;
            foreach( DataGridViewRow row in this.dataGridView1.Rows )
            {
                if( row.Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value.ToString() == NSNetworkTestMsgConst.TEST_AP_SERVER )
                {
                    apServerRow = row;
                    break;
                }
            }

            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
            {
                if( !nSNetworkTestInfo.CheckResult )
                {
                    result = false;
                    break;
                }
            }

            if( result )
            {
                apServerRow.DefaultCellStyle.BackColor = this.dataGridView1.DefaultCellStyle.BackColor;
                apServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_OK;
            }
            else
            {
                apServerRow.DefaultCellStyle.BackColor = Color.LightPink;
                apServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_RESULTNETWORK_NG;
            }

            return result;
        }

        /// <summary>
        /// テスト結果表示（BITS用）
        /// </summary>
        /// <returns></returns>
        private bool SetBITSServerResult(List<NSNetworkTestInfo> nSNetworkTestInfoList)
        {
            bool result = true;

            DataGridViewRow deliServerRow = null;
            foreach( DataGridViewRow row in this.dataGridView1.Rows )
            {
                if( row.Cells[NSNetworkTestMsgConst.TEST_COLUMN_ITEM].Value.ToString() == NSNetworkTestMsgConst.TEST_DELIVERY_SERVER )
                {
                    deliServerRow = row;
                }
            }

            foreach( NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList )
            {
                if( !nSNetworkTestInfo.CheckResult )
                {
                    result = false;
                    break;
                }
            }
            
            if( result )
            {
                deliServerRow.DefaultCellStyle.BackColor = this.dataGridView1.DefaultCellStyle.BackColor;
                deliServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_OK;
            }
            else
            {
                deliServerRow.DefaultCellStyle.BackColor = Color.LightPink;
                deliServerRow.Cells[NSNetworkTestMsgConst.TEST_COLUMN_RESULT].Value = NSNetworkTestMsgConst.MSG_RESULTNETWORK_NG;
            }
            return result;
        }

        #endregion

        /// <summary>
        /// コンボボックスが変更する場合の処理
        /// </summary>
        /// <remarks> 
        /// <br>Note			:	</br>
        /// <br>Programer		:	羅　偉傑</br>                            
        /// <br>Date			:	2010.10.21</br>                              
        /// <br>Update Note		:	</br>                
        /// </remarks>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue.ToString() != "Broadleaf.NSNetworkChk.Data.MyComboBoxItemInfo")
            {
                _fileName = this.comboBox1.SelectedValue.ToString();
            }
        }

        #endregion
       

        #region テスト用ロジック
        /*
        /// <summary>
        /// データクラス作成処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<NSNetworkTestInfo> nSNetworkTestInfoList = new List<NSNetworkTestInfo>();

            NSNetworkTestInfo nSNetworkTestInfo = new NSNetworkTestInfo();

            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト", new Uri("http://www.broadleaf.co.jp")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "認証AP接続テスト", new Uri("http://10.20.150.168/ubawebservice/ubawebservice.asmx")));
            ////nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://10.20.150.168/bauwebservice/bauwebservice.asmx")));

            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://10.20.150.168/bauwebservice/bauwebservice.asx")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("http://10.20.150.207:20001")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://10.20.152.209:20000")));
            ////nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "ユーザAP接続テスト", new Uri("http://10.20.150.207:20000")));
            ////nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "提供AP接続テスト", new Uri("http://10.20.150.209:20000")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.HTTPREQUEST, "画像AP接続テスト", new Uri("http://10.20.150.211:20000")));

            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://10.20.150.130/BAUContents/2e3ee5ce580c45a1a1afb1b23328c15c.zip")));
            ////nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://tsubasa-sfauth")));
            ////nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "変更PG案内AP接続テスト", new Uri("http://tsubasa-sfauth/NSChangeInfo")));



            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.PROXY, NSNetworkTestInfo.TestType.HTTPREQUEST, "プロキシ接続テスト", new Uri("http://www.broadleaf.co.jp")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "認証AP接続テスト", new Uri("http://www32.superfrontman.net/ubawebservice/ubawebservice.asmx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "配信AP接続テスト", new Uri("http://www31.superfrontman.net/bauwebservice/bauwebservice.asmx")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.PORTCONNECT, "ユーザAP接続テスト", new Uri("http://www34.superfrontman.net:20000")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.PORTCONNECT, "提供AP接続テスト", new Uri("http://www33.superfrontman.net:20000")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.AP, NSNetworkTestInfo.TestType.PORTCONNECT, "画像AP接続テスト", new Uri("http://www36.superfrontman.net:20000")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "NSポータルサイト接続テスト", new Uri("http://www35.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "変更PG案内AP接続テスト", new Uri("http://www35.superfrontman.net/NSChangeInfo")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "コンバートAP接続テスト", new Uri("http://www37.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "DPLAP接続テスト", new Uri("http://www42.superfrontman.net")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "TSPAP接続テスト", new Uri("http://www41.superfrontman.net")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXIISAP接続テスト", new Uri("http://www8.vxns.net")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXApacheAP接続テスト", new Uri("http://www.vxns.net")));
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.WEB, NSNetworkTestInfo.TestType.HTTPREQUEST, "VXポータルサイト接続テスト", new Uri("http://www.carpod.jp")));
            nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.ServerType.BITS, NSNetworkTestInfo.TestType.BITS, "配信テスト", new Uri("http://www31.superfrontman.net/BAUContents/df2c9d819fdf4e9a8a282507ed988808.zip")));
            
            
            //nSNetworkTestInfoList.Add(new NSNetworkTestInfo(NSNetworkTestInfo.TestType.FULL_TEST, "テストAP接続テスト",           new Uri("http://www40.superfrontman.net:20000")));


            NSNetworkTestInfoList_Serialize(nSNetworkTestInfoList, "NSNetworkTest.bin");

            MessageBox.Show("完了");
            
        }
        */
        #endregion
        
    }
}