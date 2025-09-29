//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ通信結果表示ダイアログクラス
// プログラム概要   : ＵＯＥ通信結果表示ダイアログクラス制御を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 鄧潘ハン
// 作 成 日  K2013/11/27 修正内容 : Redmine41421、フタバ個別分　削除ソースのコメント追加の対応
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
//using Broadleaf.Application.Controller;// DEL  K2013/10/27 鄧潘ハン Redmine41421
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// UOE通信結果表示ダイアログクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : UOE通信結果表示ダイアログを表示します。</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/12/13</br>
	/// <br></br>
	/// <br>UpdateNote : </br>
	/// </remarks>
	public class UoeSndRcvResultDialog : System.Windows.Forms.Form
    {
        #region Windowsで生成されたコード(自動追加)
        private Infragistics.Win.Misc.UltraLabel ultraLabel_GUIDE01;
        private RichTextBox richText_ErrorMessage;
        private Infragistics.Win.Misc.UltraButton uButton_Print;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
		private System.ComponentModel.IContainer components = null;

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UoeSndRcvResultDialog));
            this.ultraLabel_GUIDE01 = new Infragistics.Win.Misc.UltraLabel();
            this.richText_ErrorMessage = new System.Windows.Forms.RichTextBox();
            this.uButton_Print = new Infragistics.Win.Misc.UltraButton();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraLabel_GUIDE01
            // 
            appearance97.ForeColorDisabled = System.Drawing.Color.Black;
            appearance97.TextVAlignAsString = "Middle";
            this.ultraLabel_GUIDE01.Appearance = appearance97;
            this.ultraLabel_GUIDE01.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_GUIDE01.Location = new System.Drawing.Point(6, 87);
            this.ultraLabel_GUIDE01.Name = "ultraLabel_GUIDE01";
            this.ultraLabel_GUIDE01.Size = new System.Drawing.Size(313, 24);
            this.ultraLabel_GUIDE01.TabIndex = 1404;
            // 
            // richText_ErrorMessage
            // 
            this.richText_ErrorMessage.BackColor = System.Drawing.Color.White;
            this.richText_ErrorMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richText_ErrorMessage.Location = new System.Drawing.Point(19, 30);
            this.richText_ErrorMessage.Name = "richText_ErrorMessage";
            this.richText_ErrorMessage.ReadOnly = true;
            this.richText_ErrorMessage.Size = new System.Drawing.Size(488, 298);
            this.richText_ErrorMessage.TabIndex = 1405;
            this.richText_ErrorMessage.Text = "○送受信処理\n  回線エラーが発生しました。\n  復旧処理を行って下さい。\n\n  【通信結果】\n  トヨタ部品販売\n  日産部品販売\n\n○仕入データ作成処理\n  " +
                " 仕入データ作成エラーが発生しています。\n   仕入アンマッチリストを出力して下さい。";
            // 
            // uButton_Print
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Center";
            this.uButton_Print.Appearance = appearance3;
            this.uButton_Print.Font = new System.Drawing.Font("ＭＳ ゴシック", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Print.Location = new System.Drawing.Point(19, 344);
            this.uButton_Print.Name = "uButton_Print";
            this.uButton_Print.Size = new System.Drawing.Size(149, 34);
            this.uButton_Print.TabIndex = 1406;
            this.uButton_Print.Text = "回線エラーリスト印刷";
            this.uButton_Print.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Print.Click += new System.EventHandler(this.uButton_Print_Click);
            // 
            // uButton_OK
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Center";
            this.uButton_OK.Appearance = appearance2;
            this.uButton_OK.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_OK.Location = new System.Drawing.Point(408, 344);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(99, 34);
            this.uButton_OK.TabIndex = 1408;
            this.uButton_OK.Text = "ＯＫ";
            this.uButton_OK.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // UoeSndRcvResultDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(528, 400);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.uButton_Print);
            this.Controls.Add(this.richText_ErrorMessage);
            this.Controls.Add(this.ultraLabel_GUIDE01);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UoeSndRcvResultDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通信結果表示";
            this.Shown += new System.EventHandler(this.UoeSndRcvDialog_Shown);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        private List<OrderSndRcvJnl> _orderSndRcvJnlErrorList = null;   // 送受信JNLエラーリスト(帳票印字用)
        private List<string> _changeColorStringList = null;             // 色変更する文字列リスト

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
        # region ▼Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="orderSndRcvJnlErrorList">送受信JNLエラーリスト(帳票用)</param>
        /// <param name="errorMessageList">エラーメッセージ(画面表示用)</param>
        /// <param name="changeColorStringList">色変更する文字列リスト</param>
        public UoeSndRcvResultDialog(List<OrderSndRcvJnl> orderSndRcvJnlErrorList, List<string> errorMessageList, List<string> changeColorStringList)
        {
            // 各コンポーネント初期設定
            InitializeComponent();

            this._orderSndRcvJnlErrorList = orderSndRcvJnlErrorList;
            this._changeColorStringList = changeColorStringList;

            // エラーメッセージ設定
            this.SetDisplayMessage(errorMessageList);

            // ボタン表示
            if (orderSndRcvJnlErrorList.Count == 0)
            {
                this.uButton_Print.Visible = false;
            }
            else
            {
                this.uButton_Print.Visible = true;
            }
        }
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ▼UoeSndRcvDialog_Shown(フォーム表示)
        /// <summary>
        /// フォーム表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void UoeSndRcvDialog_Shown(object sender, EventArgs e)
        {
            if (this.uButton_Print.Visible == true)
            {
                this.uButton_Print.Focus();         // 回線エラーリスト印刷
            }
            else
            {
                this.uButton_OK.Focus();            // OK
            }
        }
        #endregion

        #region ▼uButton_Print_Click(印刷ボタン押下)
        /// <summary>
        /// 印刷ボタン押下
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void uButton_Print_Click(object sender, EventArgs e)
        {
            PMUOE02010UA printForm = new PMUOE02010UA(this._orderSndRcvJnlErrorList);
            SFCMN06002C printInfo = new SFCMN06002C();

            Object printInfoObject = (object)printInfo;

            printForm.Print(ref printInfoObject);
        }
        #endregion

        #region ▼uButton_OK_Click(OKボタン押下)
        /// <summary>
        /// OKボタン押下
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            this.CloseDialog();
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ▼SetDisplayMessage(メッセージ表示)
        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="displayMessageList">表示用メッセージリスト</param>
        /// <remarks>
        /// <br>Note       : リッチテキストに表示用メッセージリストの内容を追加します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void SetDisplayMessage(List<string> displayMessageList)
        {
            // 初期化
            richText_ErrorMessage.Clear();

            int length = 0;
            for (int i = 0; i <= displayMessageList.Count - 1; i++)
            {
                string text = displayMessageList[i] + Environment.NewLine;      //改行を付加

                // 色の変更
                richText_ErrorMessage.SelectionColor = this.SelectionTextColor(displayMessageList[i]);

                // 文字列を追加
                richText_ErrorMessage.AppendText(text);
                length = length + text.Length + 1;
            }
        }
        #endregion

        #region ▼SelectionTextColor(メッセージ色設定)
        /// <summary>
        /// メッセージの色設定
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : _changeColorStringList内にあるメッセージの色を赤に変更します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private Color SelectionTextColor(string text)
        {
            if (this._changeColorStringList.Contains(text))
            {
                return Color.Red;
            }
            else
            {
                return Color.Black;
            }
        }
        # endregion

        # region ▼画面クローズ時処理
        /// <summary>
        /// 画面クローズ処理
        /// </summary>
        public void CloseDialog()
        {
            this.Close();
        }

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }
        # endregion
    }
}
