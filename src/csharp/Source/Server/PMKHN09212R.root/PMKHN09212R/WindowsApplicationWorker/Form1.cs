using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;


//TEST
using System.IO;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;

        private static System.Windows.Forms.Form _form = null;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private Label label1;
        private static string[] _parameter;

        //TEST
        private ISyncProcess _ISyncProcess = null;
        private IOfferMerge _ISyncInfo = null;
        private string enterpriseCode = string.Empty;
        private Button button1;
        private Button button2;
        private string uniqueCode = string.Empty;

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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(784, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "シンクデータ取得";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(487, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(541, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Location = new System.Drawing.Point(84, 16);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(141, 21);
            this.ultraTextEditor1.TabIndex = 39;
            // 
            // ultraTextEditor2
            // 
            this.ultraTextEditor2.Location = new System.Drawing.Point(12, 187);
            this.ultraTextEditor2.Multiline = true;
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.ultraTextEditor2.Size = new System.Drawing.Size(870, 407);
            this.ultraTextEditor2.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "データサイズ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(784, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(784, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(894, 606);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ultraTextEditor2);
            this.Controls.Add(this.ultraTextEditor1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
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
            /*
            _form = new Form1();
            System.Windows.Forms.Application.Run(_form);
            */
            //*
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
            //*/
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

        
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //TEST
            //_ISyncProcess = MediationSyncProcessDB.GetRemoteObject();
            _ISyncInfo = MediationOfferMergeDB.GetRemoteObject();
            enterpriseCode = "0101150842020000"; // TODO : LSM完了後正式処理を組み込む。            
            uniqueCode = "an";
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            //CheckAndGetSyncData();

        }


        private void CheckAndGetSyncData()
        {
            //int offerDate;
            //string ver = Microsoft.Win32.Registry.GetValue(
            //            @"HKEY_LOCAL_MACHINE\SOFTWARE\Broadleaf\Product\Partsman", "CurrentVersion", "8.10.1.1").ToString(); // TODO
            //_ISyncInfo.GetLastOfferDate(out offerDate);
            //bool ret = _ISyncProcess.CheckSyncData(offerDate, ver);
            //if (ret)
            //{
            //    byte[] syncData;
            //    bool retGetSync;
            //    do
            //    {
            //        retGetSync = _ISyncProcess.GetSyncData(enterpriseCode, uniqueCode, ref offerDate, out syncData);
            //        ArrayList lstQuery = GetQueryList(syncData);
            //        int status = _ISyncInfo.WriteSyncData(lstQuery);
            //        if (status != 0)
            //            break;
            //    } while (retGetSync);
            //}
        }

        private ArrayList GetQueryList(byte[] syncData)
        {
            int offerDate;
            string ver;
            ArrayList lstQuery = new ArrayList();
            char[] splitChar1 = new char[] { ',' };
            char[] splitChar2 = new char[] { '\t' };

            MemoryStream mStream = new MemoryStream(syncData);
            mStream.Position = 0;
            System.IO.Compression.GZipStream gzipStream = new System.IO.Compression.GZipStream(mStream, System.IO.Compression.CompressionMode.Decompress);
            
            byte[] decompressed = new byte[syncData.Length * 2];
            //int bytesRead = gzipStream.Read(decompressed, 0, 100);
            gzipStream.Flush();
            int offset = 0;
            int totalCount = 0;
            gzipStream.ReadByte();
            while (true)
            {
                int bytesRead = gzipStream.Read(decompressed, offset, 1);
                if (bytesRead == 0)
                {
                    break;
                }
                offset += bytesRead;
                totalCount += bytesRead;
            }
            Array.Resize<byte>(ref decompressed, totalCount);
            
            //gzipStream.Flush();
            gzipStream.Dispose();
            MemoryStream memStream = new MemoryStream(decompressed);

            StreamReader sreader = new StreamReader(memStream);
            string readBuffer;

            readBuffer = sreader.ReadLine(); // 提供日付
            offerDate = Convert.ToInt32(readBuffer);

            readBuffer = sreader.ReadLine(); // ターゲットバージョン
            ver = readBuffer;

            //readBuffer = sreader.ReadLine(); // 区分行

            // 削除データ 読込み
            string tableID = string.Empty;
            string whereCond;
            do
            {
                readBuffer = sreader.ReadLine();
                if (readBuffer == string.Empty) // 改行か？
                {
                    readBuffer = sreader.ReadLine(); // テーブルID
                    if (readBuffer == string.Empty)
                        break;

                    tableID = readBuffer;
                }
                else
                {
                    //readBuffer = sreader.ReadLine(); // 削除条件文
                    whereCond = readBuffer;

                    string query = string.Format("DELETE FROM [{0}] WHERE ({1});", tableID, whereCond);
                    lstQuery.Add(query);
                }
            } while (sreader.EndOfStream == false); // 削除データはない場合も最少2行の改行はあるので必ず1回実行

            Dictionary<string, string> queryTemplate = new Dictionary<string, string>(200); // とりあえず200テーブル対応とする。
            while (sreader.EndOfStream == false) // 追加・更新データはない場合があるかもしれませんのでEOFかのチェックが優先
            {
                readBuffer = sreader.ReadLine(); // テーブルID
                tableID = readBuffer;

                readBuffer = sreader.ReadLine(); // カラム情報  
                string template = string.Empty;
                if (queryTemplate.ContainsKey(tableID) == false)
                {
                    string[] columns = readBuffer.Split(splitChar1);
                    template = string.Format("INSERT INTO [{0}] (", tableID);
                    for (int i = 0; i < columns.Length; i++)
                    {
                        template += string.Format("[{0}], ", columns[i]);
                    }
                    template = template.Remove(template.Length - 2);
                    template += ") VALUES (";
                    queryTemplate.Add(tableID, template);
                }
                else
                {
                    template = queryTemplate[tableID];
                }

                do // テーブルID,カラム情報があったら最少1個の追加・更新データはある
                {
                    readBuffer = sreader.ReadLine(); // 追加・更新データ
                    if (readBuffer == string.Empty)
                        break;
                    string query = template;
                    string[] columns = readBuffer.Split(splitChar2);
                    for (int i = 0; i < columns.Length; i++)
                    {
                        query += string.Format("{0}, ", columns[i]);
                    }
                    query = query.Remove(query.Length - 2);
                    query += ");";
                    lstQuery.Add(query);
                } while (sreader.EndOfStream == false);
            }

            return lstQuery;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int day = 0;
            OfferMergeDB offer = new OfferMergeDB();
            offer.GetLastOfferDate(out day);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string enterpriseCode = "0101150842020000";
            OfferMergeDB offer = new OfferMergeDB();
            object obj = null;
            offer.GetLatestHistory(enterpriseCode, out obj);
        }

    }
}
