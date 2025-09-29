//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信結果表示 
// プログラム概要   : 送信結果表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : guomm
// 作 成 日  2013/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/08/07  修正内容 : Redmine#39695 抽出結果無時の結果画面表示の変更対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信結果UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信結果UIフォームクラスです。</br>
    /// <br>Programmer  : guomm</br>
    /// <br>Date        : 2013/06/26</br>
    /// <br>UpdateNote  : 2013/08/07 田建委</br>
    /// <br>            : Redmine#39695 抽出結果無時の結果画面表示の変更対応</br>
    /// </remarks>
    public partial class PMSAE04010UA : Form
    {
        #region ■ Private Members ■
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton; // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel; // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginName; // ログイン担当者

        private const string COL_STATUS1 = "完了";
        private const string COL_STATUS2 = "失敗";
        private const string COL_STATUS3 = "送信対象なし"; // ADD 田建委 2013/08/07 Redmine#39695
        private const string COL_ZERO = "0";
        private const string COL_FORMAT = "#,###";
        #endregion ■ Private Members ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信結果フォームクラスです。</br>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        /// </remarks>
        public PMSAE04010UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
            this._loginName = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager1.Tools["LabelTool_LoginName"];
        }
        # endregion ■ コンストラクタ ■

        #region ■ イベント ■
        /// <summary>
        /// PMSAE04010UA_Loadイベント
        /// </summary>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        private void PMSAE04010UA_Load(object sender, EventArgs e)
        {
            this.ButtonInitialSeting();
        }

        /// <summary>
        /// tToolbarsManager1_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        private void tToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
            }
        }
        #endregion ■ イベント ■

        #region ■ Public Methods ■
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="status"> 送信結果 </param>
        /// <param name="time"> 送信時間 </param>
        /// <param name="number"> 送信伝票枚数 </param>
        /// <param name="detNum"> 送信伝票明細数 </param>
        /// <param name="sumMoney"> 送信伝票合計金額 </param>
        /// <param name="errMsg"> エラーメッセージ </param>
        /// <remarks>
        /// <br>Note        : 画面表示処理する。</br>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        /// <br>UpdateNote  : 2013/08/07 田建委</br>
        /// <br>            : Redmine#39695 抽出結果無時の結果画面表示の変更対応</br>
        /// </remarks>
        public void ShowDialog(int status, string time, int number, int detNum, Int64 sumMoney, string errMsg)
        {
            // 送信結果
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.uLabel_Result.Text = COL_STATUS1;
            }
            //--- ADD 田建委 2013/08/07 Redmine#39695 --->>>>>
            else if (status == 2)
            {
                this.uLabel_Result.Text = COL_STATUS3;
            }
            //--- ADD 田建委 2013/08/07 Redmine#39695 ---<<<<<
            else
            {
                this.uLabel_Result.Text = COL_STATUS2;
            }

            // 送信時間
            this.uLabel_Time.Text = time;

            // 送信伝票枚数
            if (number != 0)
            {
                this.ultraLabel_Num.Text = number.ToString(COL_FORMAT);
            }
            else
            {
                this.ultraLabel_Num.Text = COL_ZERO;
            }

            // 送信伝票明細数
            if (detNum != 0)
            {
                this.ultraLabel_DetNum.Text = detNum.ToString(COL_FORMAT);
            }
            else
            {
                this.ultraLabel_DetNum.Text = COL_ZERO;
            }

            // 送信伝票合計金額
            if (sumMoney != 0)
            {
                this.ultraLabel_Sum.Text = sumMoney.ToString(COL_FORMAT);
            }
            else
            {
                this.ultraLabel_Sum.Text = COL_ZERO;
            }

            // 画面表示
            this.ShowDialog();
        }
        #endregion ■ Public Methods ■

        #region ■ Private Methods ■
        /// <summary>
        /// ボタン初期設定
        /// </summary>
        /// <br>Note        : ボタン初期設定する。</br>
        /// <br>Programmer  : guomm</br>
        /// <br>Date        : 2013/06/26</br>
        private void ButtonInitialSeting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion ■ Private Methods ■
    }
}