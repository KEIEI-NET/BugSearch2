using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Resources;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// CSVチェックツール　フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: CSVチェックツールの画面です。</br>
    /// <br>Programmer  : Miwa Honda</br>
    /// <br>Date        : 2014.08.20</br>
    /// </remarks>
    public partial class PMKHN09950UA : Form
    {
        public PMKHN09950UA()
        {
            InitializeComponent();
        }


        string _fileInfoXml = "PMKHN09950U_FileInfo.XML";
        PMKHN09951A _csvAcs = new PMKHN09951A();

        Dictionary<int, CSVFileInfo> _cSVFileInfoList = null;


        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// </remarks>
        public void PMKHN09950UShow()
        {
            this.Show();

        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// </remarks>
        private void PMKHN09950UA_Load(object sender, EventArgs e)
        {
            bool msgDiv;
            string errMsg;

            // XML作成用　普段はOFF
            //SetCSVFileInfoListInfo();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.MainFolderSelect_button.ImageList = imageList16;
            this.MainFolderSelect_button.Appearance.Image = Size16_Index.STAR1;

            this.SubFolderSelect_button.ImageList = imageList16;
            this.SubFolderSelect_button.Appearance.Image = Size16_Index.STAR1;

            this.OutputFolderSelect_button.ImageList = imageList16;
            this.OutputFolderSelect_button.Appearance.Image = Size16_Index.STAR1;

            // 対象ファイル情報取得処理
            int status = this.GetTargetFileInfo(out msgDiv, out errMsg);
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (msgDiv)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, errMsg, 0, MessageBoxButtons.OK);
                    }
                    Close();
                }
            }
        }

        /// <summary>
        /// 出力開始ボタン
        /// </summary>
        /// <remarks>
        /// <br>Note		: 出力を行います。</br>
        /// </remarks>
        private void Start_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                bool msgDiv = false;
                string dispMsg = "";
                emErrorLevel emlevel;

                // 入力チェック
                if (this.InputCheck() == true)
                    return;

                // データセット処理
                PMKHN09951A_Common.CSVCheckToolPara para = null;
                status = this.SetParaInfo(out para, out  msgDiv, out dispMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // チェック処理開始
                    status = this._csvAcs.CompareFiles(para, out msgDiv, out dispMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        emlevel = emErrorLevel.ERR_LEVEL_INFO;
                        if (!msgDiv)
                            dispMsg = "正常に処理が終了しました。";
                            
                    }
                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                    {
                        emlevel = emErrorLevel.ERR_LEVEL_INFO;
                        if (!msgDiv)
                            dispMsg = "問題が発生したので処理を中断しました。"; 
                    }
                    else //エラー
                    {
                         emlevel = emErrorLevel.ERR_LEVEL_STOPDISP;
                         if (msgDiv)
                             dispMsg = "エラーが発生しました。処理を終了します。";
                    }

                    TMsgDisp.Show(emlevel, this.Name, dispMsg, status, MessageBoxButtons.OK);
                }
                else
                {
                    if (msgDiv)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, dispMsg, 0, MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "CSVチェックに失敗しました。\r\n" + ex, status, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns>true:チェックあり（NGと言うこと）</returns>
        /// <remarks>
        /// <br>Note       : 入力チェックを行います。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private bool InputCheck()
        {
            bool msgDiv = false;
            string dispMsg = "";

            bool result = false;

            try
            {
                // 存在チェックを行います
                if (TargetFile_tComboEditor.Value == null)
                {
                    msgDiv = true;
                    dispMsg = TargetFile_label.Text.Trim() + "を選択してください";
                    TargetFile_tComboEditor.Focus();
                }
                else if (MainCompfile_Edit.Text.Trim() == "")
                {
                    msgDiv = true;
                    dispMsg = MainCompfile_label.Text.Trim() + "を選択してください";
                    MainCompfile_Edit.Focus();
                }
                else if (SubCompfile_Edit.Text.Trim() == "")
                {
                    msgDiv = true;
                    dispMsg = SubCompfile_label.Text.Trim() + "を選択してください";
                    SubCompfile_Edit.Focus();
                }
                else if (Outputfile_Edit.Text.Trim() == "")
                {
                    msgDiv = true;
                    dispMsg = Outputfile_label.Text.Trim() + "を選択してください";
                    Outputfile_Edit.Focus();
                }

            }
            finally
            {
                if (msgDiv)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, dispMsg,  0, MessageBoxButtons.OK);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// パラメータ情報セット処理
        /// </summary>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : パラメータにセットします。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private int SetParaInfo(out  PMKHN09951A_Common.CSVCheckToolPara para ,out bool msgDiv, out string errMsg)
        {
            msgDiv = false;
            errMsg = "";
            CSVFileInfo cSVFileInfo = null;
            int status = 0;

            para = new PMKHN09951A_Common.CSVCheckToolPara();

            //選択しているコンボボックスより情報を取得する
            int targetFileNo = (int)this.TargetFile_tComboEditor.Value;
            bool getSt = this._cSVFileInfoList.TryGetValue(targetFileNo, out cSVFileInfo);
            if (getSt)
            {
                // PrimaryKeyList キーリスト
                string[] stArrayData = cSVFileInfo.PrimaryKey.Split(',');
                para.PrimaryKeyList = new SortedList<int, int>();
                // Listにセットする
                int count = 1;
                foreach (string stData in stArrayData)
                {
                    para.PrimaryKeyList.Add(count, Convert.ToInt32(stData));
                    count++;
                }

                // 対象ファイルメイン
                para.MainFilePath = MainCompfile_Edit.Text;
                // 対象ファイルメイン
                para.MainFileDispName = MainCompfile_label.Text;

                // 対象ファイルサブ
                para.SubFilePathList = new Dictionary<string, string>();
                para.SubFilePathList.Add(SubCompfile_label.Text, SubCompfile_Edit.Text);
                // 出力モード
                para.OutputMode = PMKHN09951A_Common.OutputMode.ctForCompCheck;
                // 比較項目List
                if ((cSVFileInfo.ComparItem == null) || (cSVFileInfo.ComparItem == ""))
                    para.ComparItemList = null;
                else
                {
                    stArrayData = cSVFileInfo.ComparItem.Split(',');
                    foreach (string stData in stArrayData)
                    {
                        para.ComparItemList.Add(Convert.ToInt32(stData));
                    }
                }
                // ソート項目List
                if ((cSVFileInfo.SortItem == null) || (cSVFileInfo.SortItem == ""))
                    para.SortItemList = null;
                else
                {
                    count = 1;
                    para.SortItemList = new SortedList<int, int>();
                    stArrayData = cSVFileInfo.SortItem.Split(',');
                    foreach (string stData in stArrayData)
                    {
                        para.SortItemList.Add(count, Convert.ToInt32(stData));
                        count++;
                    }
                }

                // 出力ファイルパス
                para.OutputFilePath = Outputfile_Edit.Text;

                // ヘッダ有無
                para.HeaderLineExistDiv = cSVFileInfo.HeaderLineExistDiv;

            }
            else
            {
                msgDiv = true;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                errMsg = "画面情報が正しく取得できませんでした。";
            }

            return status;
        }

        /// <summary>
        ///　対象ファイル情報取得処理
        /// </summary>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : 対象ファイル情報を取得します。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private int GetTargetFileInfo(out bool msgDiv, out string errMsg)
        {
            msgDiv = false;
            errMsg = "";
            string msgString = "対象ファイル情報取得処理に失敗しました。";

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            CSVFileInfo[] csvFileInfList = new CSVFileInfo[] { };

            string filePath = ConstantManagement_ClientDirectory.NSCurrentDirectory + "\\" + this._fileInfoXml;

            try
            {
                //XMLが存在の場合
                if (UserSettingController.ExistUserSetting(filePath))
                {
                    //ＸＭＬの読み込み
                    csvFileInfList = (CSVFileInfo[])UserSettingController.DeserializeUserSetting(filePath, typeof(CSVFileInfo[]));
                }
                else
                {
                    msgDiv = true;
                    errMsg = "設定XML（"+ _fileInfoXml + ")が存在しません。\r\n処理を終了します。";
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return status;
                }

                if (this._cSVFileInfoList == null)
                    this._cSVFileInfoList = new Dictionary<int, CSVFileInfo>();
                else
                    this._cSVFileInfoList.Clear();

                //対象ファイル情報の取得
                for (int i = 0; i < csvFileInfList.Length; i++)
                {
                    this._cSVFileInfoList.Add(csvFileInfList[i].CSVFileNo, csvFileInfList[i]);
                    this.TargetFile_tComboEditor.Items.Add(csvFileInfList[i].CSVFileNo, csvFileInfList[i].CSVFileName);
                }

                this.TargetFile_tComboEditor.Value = (int)1;


            }
            catch (Exception)
            {
                msgDiv = true;
                errMsg = msgString;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                return status;
            }

            return status;
        }


        /// <summary>
        /// 比較ファイル選択ガイド
        /// </summary>
        private void FolderSelect_button_Click(object sender, EventArgs e)
        {

            string fileName = "";
            if (sender == this.MainFolderSelect_button)
            {
                fileName = MainCompfile_label.Text.Trim();
            }
            else
            {
                fileName = SubCompfile_label.Text.Trim();
            }

            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            //存在しないファイルの名前が指定されたとき警告を表示する
            ofd.CheckFileExists = true;
            //はじめに表示されるフォルダを指定する
            //ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "CSVファイル(*.CSV)|*.CSV|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択される方
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = fileName + "ファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //複数ファイルは選択ダメ
            ofd.Multiselect = false;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // 比較メイン
                if (sender == this.MainFolderSelect_button)
                {
                    MainCompfile_Edit.Text = ofd.FileName;
                }
                // 比較サブ
                else if (sender == this.SubFolderSelect_button)
                {
                    SubCompfile_Edit.Text = ofd.FileName;
                }

            }

        }

        private void OutputFolderSelect_button_Click(object sender, EventArgs e)
        {

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = "チェック結果.csv";
            //はじめに表示されるフォルダを指定する
            //sfd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "CSVファイル(*.CSV)|*.CSV|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに表示するほう
            sfd.FilterIndex = 1;
            //タイトルを設定する
            sfd.Title = Outputfile_label.Text.Trim() + "を選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                Outputfile_Edit.Text = sfd.FileName;
            }
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //--XML作成用。ふつうは通過しない--
        /// <summary>
        ///　アセンブリ情報取得処理(XML作成用)　※ツールで未使用
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタを取得して、ＣＳＶを作成します。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private void SetCSVFileInfoListInfo()
        {

            CSVFileInfo[] fileInfoList = new CSVFileInfo[] { };

            string filePath = ConstantManagement_ClientDirectory.NSCurrentDirectory + "\\" + this._fileInfoXml;

            //XMLが存在の場合
            if (UserSettingController.ExistUserSetting(filePath))
            {
                List<CSVFileInfo> a = new List<CSVFileInfo>();

                CSVFileInfo fileInfo = new CSVFileInfo();
                fileInfo.CSVFileNo = 1;
                fileInfo.CSVFileName = "請求残高照会";
                fileInfo.PrimaryKey = "1,2,3,4,5";
                fileInfo.ComparItem = null;
                fileInfo.SortItem = null;
                fileInfo.HeaderLineExistDiv = true;

                a.Add(fileInfo);

                // XML書き込み
                UserSettingController.SerializeUserSetting(a, filePath);
            }
        }
    }

    /// public class name:    CSVFileInfo
    /// <summary>
    ///                      CSVファイル情報
    /// </summary>
    /// <remarks>
    /// <br>note             :   CSVファイル情報</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CSVFileInfo
    {

        /// <summary>対象ファイルＮＯ</summary>
        private int _cSVFileNo = 0;

        /// <summary>対象ファイル名称</summary>
        private string _cSVFileName = null;

        /// <summary>プライマリーキー情報</summary>
        private string _primaryKey = null;

        /// <summary>比較項目情報<</summary>
        private string _comparItem = "";

        /// <summary>ソート項目情報</summary>
        private string _sortItem = null;
        
        /// <summary>ヘッダー行有無区分</summary>
        private bool _headerLineExistDiv = false;


        /// public propaty name  :  CSVFileName
        /// <summary>対象ファイルＮＯプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// </remarks>
        public int CSVFileNo
        {
            get { return _cSVFileNo; }
            set { _cSVFileNo = value; }
        }

        /// public propaty name  :  CSVFileName
        /// <summary>対象ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// </remarks>
        public string CSVFileName
        {
            get { return _cSVFileName; }
            set { _cSVFileName = value; }
        }

        /// public propaty name  :  PrimaryKey
        /// <summary>プライマリーキー情報</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プライマリーキー情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        /// public propaty name  :  ComparItem
        /// <summary>比較項目情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   比較項目情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ComparItem
        {
            get { return _comparItem; }
            set { _comparItem = value; }
        }


        /// public propaty name  :  SortItem
        /// <summary>ソート項目情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ソート項目情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SortItem
        {
            get { return _sortItem; }
            set { _sortItem = value; }
        }

        
         /// public propaty name  :  HeaderLineExistDiv
         /// <summary>ヘッダー行有無区分プロパティ</summary>
         /// ----------------------------------------------------------------------
         /// <remarks>
         /// <br>note             :   ヘッダー行有無区分プロパティ</br>
         /// <br>Programer        :   自動生成</br>
         /// </remarks>
         public bool HeaderLineExistDiv
         {
             get { return _headerLineExistDiv; }
             set { _headerLineExistDiv = value; }
         }


    }
}