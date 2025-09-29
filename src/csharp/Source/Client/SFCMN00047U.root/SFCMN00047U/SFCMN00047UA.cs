using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Runtime.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// システム・ログインUI制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : システム・ログインUI制御クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2008.08.28</br>
    /// <br></br>
    /// <br>Update Note: 2009.01.16 鹿野　幸生</br>
    /// </remarks>
    public partial class SFCMN00047UAF : Form
    {
        public bool _Finish = false;
        public bool _Visible = false;
        public bool _SpecialKilled = false;                                     //  2009.01.16  追加
        public string _KilledReason = "";                                       //  2009.01.16  追加
       
        private NsLoginControler _nsc = new NsLoginControler();

        /// <summary>
        /// システム・ログイン制御UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : システム・ログイン制御UIクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2008.08.28</br>
        /// </remarks>
        public SFCMN00047UAF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード1時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_Load(object sender, EventArgs e)
        {
            this.Visible = false; // フォームの表示

            // 2015/08/07 UPD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
            // TTraynotifyIcon.Text = "NSログイン制御";
            TTraynotifyIcon.Text = "NSログイン制御（Partsman）";
            // 2015/08/07 UPD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する --------<<<<<<<<<<
            TTraynotifyIcon.BalloonTipText = TTraynotifyIcon.Text;
            TTraynotifyIcon.BalloonTipTitle = TTraynotifyIcon.Text;
            TTraynotifyIcon.ContextMenuStrip = mnuMain;
            TTraynotifyIcon.Visible = true;

            //  終了イベントを監視
            _nsc.ProcessKilling += new EventHandler<ProcessKillEventArgs>(_nsc_ProcessKilling);

            _nsc.StartControl(this);

        }

        void _nsc_ProcessKilling(object sender, ProcessKillEventArgs e)
        {

            // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
            // SCMポップアップのプロセスが実行中の場合は強制終了する。
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcessesByName("PMSCM00005U");
            foreach (System.Diagnostics.Process process in processList)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // process終了中、終了済の場合、exceptionが発生した際の次ループ用
                }
            }
            // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する --------<<<<<<<<<<
            if ((e.Reason.IndexOf("RESUME") >= 0) || (e.Reason.IndexOf("LIMITDATE") >= 0))
            {
                _SpecialKilled = true;
                _KilledReason = e.ReasonMessage;
            }
            
        }

        /// <summary>
        /// フォームクローズ前イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Finish == true)
            {
                // アイコンをトレイから取り除く
                TTraynotifyIcon.Visible = false;
            }
            else
            {
                //  タスクトレイに仕舞う
                e.Cancel = true;
                Visible = false;
                _Visible = false;

            }

        }

        /// <summary>
        /// 表示メニュークリック時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuShow_Click(object sender, EventArgs e)
        {

            _Visible = true;
            Visible = true;

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal; // 最小化をやめる
            }

            //  途中経過報告
            string actionType = "";
            string startDate = "";
            string onTheWayTime = "";
            string endDate = "";

            _nsc.GetStatus(ref actionType, ref startDate, ref onTheWayTime, ref endDate);

            if (actionType.IndexOf("Date") > -1)
            {

                lblMsg.Text = "システムメンテナンスが\n\n   【" + endDate + "】\n\nに予定されています。\n\nもし、上記の時点でログインしている場合、\n自動的にログオフされますのでご注意ください。";
            }
            else
            {
                lblMsg.Text = "NS企業ログインから　" + onTheWayTime + " 経過しています。\n\nこのままログオフしない場合、\n\n   【" + endDate + "】\n\nに自動ログオフされます。";
            }

            //  メッセージに合わせてフォームサイズ調整
            SetClientSizeCore(lblMsg.Size.Width + (lblMsg.Left * 2), lblMsg.Size.Height + (lblMsg.Top * 2));

            //  表示
            Show();

            // フォームをアクティブにする
            Activate();
        }

        /// <summary>
        /// フォームアクティブ時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_Activated(object sender, EventArgs e)
        {
            //  非表示設定なら、隠れたまま
            if (_Visible == false)
            {
                this.Visible = false; // フォームの表示
            }

        }

        /// <summary>
        /// フォームリサイズ時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00047UAF_Resize(object sender, EventArgs e)
        {
            //  最小化指定なら、タスクトレイに隠れる
            if (WindowState == FormWindowState.Minimized)
            {
                _Visible = false;
                Visible = false;
            }
        }

        /// <summary>
        /// フォーム終了メソッド(Program.csからコール)
        /// </summary>
        /// <remarks>
        /// <br>Note       :ユーザーアイテム取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2008.08.29</br>
        /// </remarks>
        public void CloseWindow()
        {
            _Finish = true;
            Close();
        }

    }
}