//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン）（ＢＬｺｰﾄﾞ指定）
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）（ＢＬｺｰﾄﾞ指定）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/09/26  修正内容 : Redmine#14492対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率設定マスタメン画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率設定マスタメン画面用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2010/08/12</br>
    /// <br>Update Note : 2010/09/26 呉元嘯 仕様連絡 #14492対応</br>
    /// </remarks>
    public partial class PMKHN09474UB : Form
    {
        #region ■ Private Members
        private ImageList _imageList16 = null;
        private int _cellMove;
        private RateProtyMngBlCdConstructionAcs _rateProtyMngBlCdConstructionAcs;
        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// 掛率設定マスタメン画面用ユーザー設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン画面用ユーザー設定クラスの初期処理を行います。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09474UB()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;

            this._rateProtyMngBlCdConstructionAcs = new RateProtyMngBlCdConstructionAcs();
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
        /// <br>Note        : メッセージボックスを表示します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         "PMKHN09474U",                     // アセンブリID
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br>Update Note : 2010/09/26 呉元嘯 仕様連絡 #14492対応</br>
        /// </remarks>
        private void PMKHN09474UB_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.UNDO;

            this.tComboEditor_CellMove.Value = this._rateProtyMngBlCdConstructionAcs.CellMove;
            this._cellMove = this._rateProtyMngBlCdConstructionAcs.CellMove;// ADD 2010/09/26

        }
        /// <summary>
        /// Button_Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.tComboEditor_CellMove.Value != null)
            {
                this._rateProtyMngBlCdConstructionAcs.CellMove = (int)this.tComboEditor_CellMove.Value;
            }
            this._rateProtyMngBlCdConstructionAcs.Serialize();

            this._cellMove = (int)this.tComboEditor_CellMove.Value;

        }
        /// <summary>
        /// Button_Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion ■ Control Events

    }
}