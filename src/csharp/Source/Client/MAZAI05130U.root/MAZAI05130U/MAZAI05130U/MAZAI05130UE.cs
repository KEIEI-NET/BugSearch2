//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸入力品番検索画面クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070149-00  作成担当 : 陳嘯
// 作 成 日  2015/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070149-00  作成担当 : 河原林　一生
// 修 正 日  2015/05/25  修正内容 : Redmine#45746 
//　　　　　　　　　　　　　　　　　・品番検索画面の確定ボタンを削除
//　　　　　　　　　　　　　　　　　・品番検索画面の終了ボタン(ALT+X)を戻るボタン(F11)に変更
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinToolbars;
using System.Collections;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 棚卸入力品番検索画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Programer  : 陳嘯</br>
    /// <br>Note       : 品番検索を行うクラスです</br>
    /// <br>Date       : 2015/04/28</br>
    /// <br>管理番号   : 11070149-00 2015/04/28 品番検索を追加</br>
    /// </remarks>
    public partial class MAZAI05130UE : Form
    {
        #region Constructor
        /// <summary>
        /// 棚卸入力品番検索画面クラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Programer	: 陳嘯</br>
        /// <br>Note		: 棚卸入力品番検索画面クラスのインスタンスを初期化します</br>
        /// <br>Date        : 2015/04/28</br>
        /// <br>管理番号    : 11070149-00 2015/04/28 品番検索を追加</br>
        /// </remarks>
        public MAZAI05130UE()
        {
            InitializeComponent(); // 棚卸入力品番検索画面初期化
            this.tEdit_GoodsNo.Focus(); // フォーカスをセット
        }
        #endregion

        #region PrivateMember
        #endregion

        #region PublicMethod
        private UltraGrid _tempUltraGrid;　// 父画面のGridデータ

        /// <summary>
        /// 父画面のGridデータ
        /// </summary>
        public UltraGrid UltraGrid
        {
            get { return _tempUltraGrid; }
            set { _tempUltraGrid = value; }
        }

        /// <summary>
        /// 画面起動処理
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Note       : 引数を元に画面の起動を行います</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>管理番号   : 11070149-00 2015/04/28 品番検索を追加</br>
        /// </remarks>
        public void ShowEditor()
        {
            this.timer1.Enabled = true;
            // 画面初期設定処理
            ScreenInitialSetting();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定処理を行います</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 品番検索を追加</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            this.tEdit_GoodsNo.Clear(); // 品番検索入力クリア
        }
        #endregion

        #region Event

        #region FormLoad

        /// <summary>
        /// Active行検索
        /// </summary>
        /// <param name="startNo">開始番号</param>
        /// <param name="endNo">終了番号</param>
        private bool FindActiveRowByGoodsNo(int startNo, int endNo)
        {
            bool dataFind = false;　// 品番検索フラグ（TRUE: 同じ品番がある　FALSE:同じ品番がなし）
            UltraGridRow[] rows = this.UltraGrid.Rows.GetFilteredInNonGroupByRows();
            for (int i = startNo; i < endNo; i++)
            {
                if (rows[i].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().StartsWith(tEdit_GoodsNo.Text))
                {
                    // Active行設定処理を行う
                    rows[i].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                    // 同じ品番がある
                    dataFind = true;
                    break;
                }
            }
            return dataFind;
        }

        /// <summary>
        /// Form.Load イベント (MAZAI05130UDA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが初めて表示される直前に発生します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 品番検索を追加</br>
        /// </remarks>
        private void MAZAI05130UDA_Load(object sender, EventArgs e)
        {
            this.tEdit_GoodsNo.Focus(); // フォーカス設定
        }

        /// <summary>
        /// 品番検索確認
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品番検索確認のクリックイベント</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>管理番号   : 11070149-00 2015/04/28 品番検索確認を追加する</br>
        /// </remarks>
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // 品番検索確認
            this.tEdit_GoodsNo.Focus(); //フォーカス設定
            bool dataFind = false; // 品番検索なし
            int activerow = -1; // Active行初期化

            // 品番入力はヌルの場合、もう一度入力
            if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText.TrimEnd()))
            {
                return;
            }
            UltraGridRow[] rows = this.UltraGrid.Rows.GetFilteredInNonGroupByRows();

            if (UltraGrid.ActiveCell == null)
            {
                // 第一行から検索
                dataFind = FindActiveRowByGoodsNo(0, rows.Length);
            }
            else
            {
                // Active行番号
                for (int i = 0; i < rows.Length; i++)
                {
                    if (UltraGrid.ActiveRow.Index == rows[i].Index)
                    {
                        activerow = i;　// Active行番号
                        break;
                    }
                }

                // データがなし
                if (activerow == -1)
                {
                    // 第一行から検索
                    dataFind = FindActiveRowByGoodsNo(0, rows.Length);
                }
                else
                {

                    // Active行以下品番検索
                    dataFind = FindActiveRowByGoodsNo(activerow + 1, rows.Length);

                    // Active行以上品番検索
                    if (dataFind == false)
                    {
                        dataFind = FindActiveRowByGoodsNo(0, activerow + 1);
                    }
                }
            }

            // 品番検索なし場合、エラーメッセージを表示する
            if (dataFind == false)
            {
                this.MsgDispProc("該当するデータがありません。", emErrorLevel.ERR_LEVEL_INFO);
            }
        }

        /// <summary>
        /// 品番検索関じる
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品番検索関じるのクリックイベント</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : 2015/04/28</br>
        /// <br>管理番号   : 11070149-00 2015/04/28 品番検索関じるを追加する</br>
        /// </remarks>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // 品番検索関じる
            this.DialogResult = DialogResult.Cancel;   // 品番検索キャンセル
            this.Close();              // 品番検索画面閉じる
        }
        #endregion

        /// <summary>
        /// 品番フォーカスセット処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        /// <remarks>
        /// <br>Note       : 品番フォーカスをセットする</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : 2015/04/28</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tEdit_GoodsNo.Focus();     // 品番フォーカス設定
            this.timer1.Enabled = false;
        }
        #endregion

        /// <summary>
        /// アローキーコントロール
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                switch (e.Key)
                {
                    // Enter キーの処理
                    case Keys.Enter:
                        switch (e.PrevCtrl.Name)
                        {
                            case "tEdit_GoodsNo":
                                // 画面閉じる
                                this.ConfirmButton_Click(null, null);

                                // Enterキーを押した場合、フォーカス移動できない。
                                e.NextCtrl = this.tEdit_GoodsNo;
                                break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        ///  キー押下イベント処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MAZAI05130UE_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)                         // --- DEL 河原林　一生 2015/05/25 Redmine#45746
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F11)  // --- ADD 河原林　一生 2015/05/25 Redmine#45746 
            {
                // 品番検索画面閉じる
                this.Close();
            }
        }

        #region ◎ メッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string message, emErrorLevel iLevel)
        {
            // メッセージ表示
            return TMsgDisp.Show(
                this,                            // 親ウィンドウフォーム
                iLevel,                             // エラーレベル
                this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
                message,                            // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OK);             // 表示するボタン
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="msg">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="proc">発生元メソッドID</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <remarks>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, emErrorLevel iLevel)
        {
            return TMsgDisp.Show(
                iLevel,						        //エラーレベル
                "MAZAI05130UE",                      //UNIT　ID
                "棚卸入力",                            //プログラム名称
                proc,                               //プロセスID
                "",                                 //オペレーション
                msg,                                //メッセージ
                status,                             //ステータス
                null,                               //オブジェクト
                MessageBoxButtons.OK,               //ダイアログボタン指定
                MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
                );
        }

        /// <summary>
        /// エラーMSG表示処理(Exception)
        /// </summary>
        /// <param name="msg">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="proc">発生元メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <remarks>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, Exception ex, emErrorLevel iLevel)
        {
            return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
        }
        #endregion
    }
}