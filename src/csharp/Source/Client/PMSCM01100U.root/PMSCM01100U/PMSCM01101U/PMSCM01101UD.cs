//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : ログ表示画面
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田 誠
// 作 成 日  2011/06/01  修正内容 : ログの暗号化に伴い、表示画面を新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ログ表示画面フォーム
    /// </summary>
    public partial class PMSCM01101UD : Form
    {
        private string _LogFilePath = string.Empty;
        private string _FileNameFormat = string.Empty;
        private DateTime _prevDate;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_SETREDRAW = 0x000B;
        private const int Win32False = 0;
        private const int Win32True = 1;

        /// <summary>
        /// DateTimePicker を ToolStrip に配置する為のコントロール ホスト
        /// </summary>
        private ToolStripControlHost toolStripDateTimePicker;

        /// <summary>
        /// PMSCM01101UDコンストラクタ
        /// </summary>
        /// <param name="path">ログ保存先パスを設定</param>
        /// <param name="format">ログファイル名の書式を設定</param>
        public PMSCM01101UD(string path, string format)
        {
            InitializeComponent();
            _LogFilePath = path;
            _FileNameFormat = format;

            toolStripDateTimePicker = new ToolStripControlHost(dateTimePicker1);
            toolStrip1.Items.Insert(1, toolStripDateTimePicker);

            toolStrip1.ImageList = IconResourceManagement.ImageList32;
            toolStrip1.Items["tsbRefresh"].ImageIndex = (int)Size32_Index.RENEWAL;

            _prevDate = DateTime.Now;
        }

        /// <summary>
        /// ログ画面を表示します
        /// </summary>
        public new void Show()
        {
            base.Show();

            System.Windows.Forms.Application.DoEvents();

            // ログの表示
            // 画面再表示の場合は前回表示していたログを再読込します。
            this.LoadLogFile(_prevDate, true);
        }

        /// <summary>
        /// ログファイルを読み込み、復号化して表示します。
        /// </summary>
        /// <param name="targetDate">表示するログファイルの日付を設定</param>
        /// <param name="update">更新表示フラグ</param>
        private void LoadLogFile(DateTime targetDate, bool update)
        {
            // 前回表示したログファイル(年月)と比較し、異なっている場合にのみファイルを読み込み直します。
            // 但し update が true の場合は無条件で読込み直します。
            // ※カレンダーで日(同一年月)を変える度にファイルを読み込むのは非効率な為
            bool reload = !_prevDate.ToString("yyyyMM").Equals(targetDate.ToString("yyyyMM")) || update;

            _prevDate = targetDate;

            if (reload)
            {
                string strLog = string.Empty;

                try
                {
                    string file = String.Format(_FileNameFormat, targetDate);
                    string path = Path.Combine(_LogFilePath, file);

                    // ログファイルの読込
                    // ログファイルは PMSCM01103A.DLL 側が開いているので、FileShare.ReadWrite を指定して開く必要がある
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024, FileOptions.SequentialScan))
                    {
                        using (TextReader txtReader = new StreamReader(fs, Encoding.GetEncoding("shift-jis")))
                        {
                            StringBuilder sbLog = new StringBuilder(1024);

                            while (txtReader.Peek() > -1)
                            {
                                // Base64による復号化
                                byte[] bin = Convert.FromBase64String(txtReader.ReadLine());
                                sbLog.Append(Encoding.GetEncoding("shift-jis").GetString(bin));
                                sbLog.Append(Environment.NewLine);
                            }

                            strLog = sbLog.ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    // 例外はそのまま表示する(開発者が使用する要素が強いので)
                    strLog = e.Message;
                }

                this.tbxLogDisplay.Text = strLog;
            }

            // ログを追い易くする為、該当日付にキャレットを移動する
            int index = this.tbxLogDisplay.Text.IndexOf(string.Format("{0:yyyy/MM/dd}", targetDate));

            if (index > -1)
            {
                this.tbxLogDisplay.SelectionStart = index;
                this.tbxLogDisplay.SelectionLength = 10;
                this.tbxLogDisplay.ScrollToCaret();
            }
        }

        /// <summary>
        /// ログ表示画面フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMSCM01101UD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender == this)
            {
                e.Cancel = true;
                
                // 通常は閉じずに(解放せずに)非表示とする。
                this.Hide();
            }
        }

        /// <summary>
        /// ログ表示画面フォームのKeyDownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMSCM01101UD_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキー押下により、ログ表示画面を非表示にする。
            if (e.KeyData == Keys.Escape)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// DateTimePickerのValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // ログファイルを読み込み直す、但し現在開いているファイルと
            // 対象年月が同じ場合は読込み直さず、キャレットの移動のみとする。
            this.LoadLogFile(dateTimePicker1.Value, false);
        }

        /// <summary>
        /// 更新ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            // 最新情報に更新する
            this.LoadLogFile(dateTimePicker1.Value, true);
        }
    }
}