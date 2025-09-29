//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMNSインポート待機画面
// プログラム概要   : PM.NSのインポート時に待機モードを追加しPM7SP側の終了ファイルを
//                  : 監視して自動で取り込めるようにします。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
						

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMNSインポート待機フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : PMNSインポート待機フォームクラスです。</br>
    /// <br>Programmer  : 張勇</br>
    /// <br>Date        : 2012/11/09</br>
    /// </remarks>
    public partial class PMKHN08000UB : Form
    {
        #region ■ コンストラクタ ■
        /// <summary>
        /// PMNSインポート待機フォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : PMNSインポート待機のインスタンスを生成します。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        public PMKHN08000UB(string convPath,bool convertRowSelectedFlg)
        {
            InitializeComponent();
            this._serverPath = convPath;
            if (!this._serverPath.EndsWith("\\"))
            {
                this._serverPath += "\\";
            }
            this.convertRowSelectedFlg = convertRowSelectedFlg;
        }

        #endregion

        #region  ■ Private Members

        private bool convertRowSelectedFlg = true;//コンバート対象を選択したフラグ
        private int _preSelType = 0;//インポートファイル
        private string _serverPath;//インポート元格納パス
        private string[] _fileLst;//ファイルリスト
        private Dictionary<int, string> Dic_DelModel = new Dictionary<int, string>();//削除メッセッジの集合
        private const string ctPGID = "PMKHN08000UB";//PGID
        private string EndFileName = "ConvertEnd.csv"; //終了ファイル
        private string Message_Info = "既存エクスポート終了ファイルが存在します。\r\nインポート処理をすぐに開始しますか？";//メッセッジ
        private string DelModel0 = "ＮＳインポート画面指定条件に従い削除します。";//削除メッセッジ
        private string DelModel1 = "インポート処理を行うものを画面指定条件に従い削除します。";//削除メッセッジ
        private string Message_NoSelect = "コンバート対象を選んで下さい。";

        #endregion 

        # region ■ Public Properties

        /// <summary>
        /// ファイルリスト
        /// </summary>
        public string[] FileLst
        {
            get
            {
                return this._fileLst;
            }
            set
            {
                this._fileLst = value;
            }
        }

        /// <summary>
        /// 処理のモジュッル
        /// </summary>
        public int SelModelType
        {
            get
            {
                return this._preSelType;
            }
            set
            {
                this._preSelType = value;
            }
        }

        # endregion

        #region  ■ Private Methods

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化処理。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void InitConstruction()
        {
            Dic_DelModel.Add(0, DelModel0);
            Dic_DelModel.Add(1, DelModel1);
            this.comb_FileImport.SelectedIndex = 0;
            ultraLabel_Message.Visible = false;
            this.comb_FileImport.Focus();
        }

        /// <summary>
        /// 終了ファイルが存在するかどうか
        /// </summary>
        /// <returns>ture:存在,false:存在しません</returns>
        /// <remarks>
        /// <br>Note       : 終了ファイルが存在しますか。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private bool IsEndFileExcisted()
        {
            //監視のパス
            string path = this._serverPath + EndFileName;
            //フォルダを監視する
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ConvertEnd.csvが指定フォルダに移動する
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ConvertEnd.csvが指定フォルダに移動する。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private bool FileReName()
        {
            try
            {
                string newFileNm = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileDir = this._serverPath+"\\" + newFileNm+"\\";
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                Directory.Move(this._serverPath + EndFileName, fileDir + EndFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ConvertEnd.csvの内容を読み込み
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ConvertEnd.csvの内容を読み込み。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private bool FileRead()
        {
            try
            {
                StringBuilder strBulider = new StringBuilder();
                FileStream fileStream = new FileStream(this._serverPath + EndFileName, FileMode.Open);
                StreamReader stream = new StreamReader(fileStream);
                string str = stream.ReadLine();
                while (!string.IsNullOrEmpty(str))
                {
                    strBulider.Append(str);
                    str = stream.ReadLine();
                }
                str = strBulider.ToString();
                stream.Close();
                if (!string.IsNullOrEmpty(str))
                {

                    List<string> lst = new List<string>();
                    lst.AddRange(str.Split(','));
                    this._fileLst = lst.FindAll(delegate(string x)
                     {
                         if (string.IsNullOrEmpty(x))
                         {
                             return false;
                         }
                         else
                         {
                             return true;
                         }
                     }).ToArray();
                }
                stream.Close();
                fileStream.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region ■ イベント

        /// <summary>
        /// 画面のロード
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 画面をロードする。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void PmNsWait_Load(object sender, EventArgs e)
        {
            InitConstruction();
        }

        /// <summary>
        /// 定時処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 定時　イベント処理。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void timer_StartWait_Tick(object sender, EventArgs e)
        {
            if (IsEndFileExcisted())
            {
                timer_StartWait.Enabled = false;
                if (FileRead())
                {
                    if (FileReName())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ultraLabel_Message.Visible = false;
                    }
                }
                else
                {
                    ultraLabel_Message.Visible = false;
                }
            }
        }

        /// <summary>
        /// 待機ボタンのイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       :  待機ボタンのイベント。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void ultraButton_Wait_Click(object sender, EventArgs e)
        {
            DialogResult result;
            bool flg = true;
            if (this.comb_FileImport.SelectedIndex == 0)
            {
                if (!convertRowSelectedFlg)
                {
                    TMsgDisp.Show(
                                 this, 								            // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                 ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                 Message_NoSelect,     // 表示するメッセージ
                                 0, 									            // ステータス値
                                 MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            ultraLabel_Message.Visible = true;
            try
            {
                //終了ファイルが存在するかどうか
                if (IsEndFileExcisted())
                {
                    result = TMsgDisp.Show(
                                 this, 								            // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_QUESTION, 		    // エラーレベル
                                 ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                 Message_Info,     // 表示するメッセージ
                                 0, 									            // ステータス値
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        //ConvertEnd.csvの内容を読み込み
                        if (FileRead())
                        {
                            //ConvertEnd.csvを更名する
                            if (FileReName())
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                flg = false;
                            }
                        }
                        else
                        {
                            flg = false;
                        }
                    }
                    else
                    {
                        //ConvertEnd.csvを更名する
                        if(FileReName())
                            this.timer_StartWait.Enabled = true;
                        else
                            flg = false;
                    }
                }
                else
                {
                    this.timer_StartWait.Enabled = true;
                }
                ultraLabel_Message.Visible = flg;
            }
            catch
            {

            }
        }

        /// <summary>
        /// キャンセルボタンのイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キャンセルボタンのイベント。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void ultraButton_Cancel_Click(object sender, EventArgs e)
        {
            
            ultraLabel_Message.Visible = false;
            this.timer_StartWait.Enabled = false;
        }

        /// <summary>
        /// インポートファイルのIndex変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : インポートファイルのIndex変更イベント。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void comb_FileImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._preSelType = this.comb_FileImport.SelectedIndex;
            ultraLabel_DelText.Text = Dic_DelModel[this._preSelType].ToString();
        }

        #endregion 
    }
}