//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先一括修正画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先一括修正画面用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/11/20</br>
    /// </remarks>
    public partial class PMKHN09351UC : Form
    {
        #region ■ Private Member

        private ImageList _imageList16 = null;
        private CustomerCustomerChangeConstructionAcs _customerCustomerChangeConstructionAcs;

        private int _cellMove;

        #endregion ■ Private Member


        #region ■ Constructor

        /// <summary>
        /// 得意先一括修正画面用ユーザー設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正画面用ユーザー設定クラスの初期処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09351UC()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._customerCustomerChangeConstructionAcs = new CustomerCustomerChangeConstructionAcs();

            this._cellMove = 0;

            // コンボボックス設定
            this.tComboEditor_CellMove.Items.Clear();
            this.tComboEditor_CellMove.Items.Add(0, "右");
            this.tComboEditor_CellMove.Items.Add(1, "下");
            this.tComboEditor_CellMove.Value = 0;
        }

        #endregion ■ Constructor


        #region ■ Public Property

        /// <summary>
        /// セル移動プロパティ
        /// </summary>
        public int CellMove
        {
            get
            {
                return _cellMove;
            }
        }

        #endregion ■ Public Property


        #region ■ Private Methods

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         "PMKHN09351U",                     // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        #endregion ■ Private Methods


        #region ■ Control Events
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void MAZAI04350UC_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.UNDO;

            this.tComboEditor_CellMove.Value = this._customerCustomerChangeConstructionAcs.CellMove;
        }

        /// <summary>
        /// Button_Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.tComboEditor_CellMove.Value != null)
            {
                this._customerCustomerChangeConstructionAcs.CellMove = (int)this.tComboEditor_CellMove.Value;
            }
            this._customerCustomerChangeConstructionAcs.Serialize();

            this._cellMove = (int)this.tComboEditor_CellMove.Value;
        }

        /// <summary>
        /// Button_Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion ■ Control Events
    }
}