//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ： 商品在庫一括登録修正画面
// プログラム概要   ： 商品在庫一括登録修正画面の最大出力件数を追加
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：yangyi
// 修正日    2013/03/13     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当 : yangyi
// 修 正 日  2013/04/19     修正内容 : 20150515配信分の対応、Redmine#35018
//                                     「商品在庫一括修正」のサーバー負荷軽減　その２
//----------------------------------------------------------------------------//

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
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品在庫一括登録修正画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品在庫一括登録修正画面用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer : yangyi</br>
    /// <br>Date       : 2013/03/13</br>
    /// <br>Update Note: 2013/04/18 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// </remarks>
    public partial class PMZAI09201UC : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Members
        private ImageList _imageList16 = null;
        private const string XML_FILE_NAME = "UISetting_PMZAI09201UC.XML";
        //private const string WARNING_MSG = "最大出力件数が多いため、処理が遅くなる可能性があります。" + "\r\n" + "\r\n" + "登録してよろしいですか？"; //DEL yangyi 2013/04/19 Redmine#35018
        private const string WARNING_MSG = "最大出力件数が多いため、処理が遅くなる可能性があります。" + "\r\n" + "\r\n" + "設定してよろしいですか？";   //ADD yangyi 2013/04/19 Redmine#35018
        private const string WARNING_MSG2 = "最大出力件数は1から20000の値を入力して下さい。";   //ADD yangyi 2013/04/19 Redmine#35018
        private const string ERROR_MSG = "入力可能な最大値は 20000 です。";

        private int _maxCount;            //最大出力件数
        # endregion ■ Private Members

        #region ■ Public Property
        /// <summary>
        /// 最大出力件数プロパティ
        /// </summary>
        public int MaxCount
        {
            get
            {
                return _maxCount;
            }
        }
        #endregion ■ Public Property

        #region ■ Constructor
        /// <summary>
        /// 商品在庫一括登録修正画面用ユーザー設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品在庫一括登録修正画面用ユーザー設定クラスの初期処理を行います。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// <br></br>
        /// </remarks>
        public PMZAI09201UC()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            Deserialize();

        }
        #endregion ■ Constructor

        #region ■ Control Events
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void PMZAI09201UC_Load(object sender, EventArgs e)
        {
            this.OK_Button.ImageList = this._imageList16;
            this.OK_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.UNDO;
        }

        /// <summary>
        /// Button_Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // --- ADD yangyi 2013/04/19 for Redmine#35018 ------->>>>>>>>>>>
            if (this.tNedit_MaxCount.GetInt() <=0 )
            {
                //最大出力件数が1～20000件の警告画面を表示します。
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    this.Name,				            // プログラム名称
                    WARNING_MSG2,						// 表示するメッセージ
                    0, 							        // ステータス値
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                //設定画面に戻ります
                this.DialogResult = DialogResult.Retry;
                this.tNedit_MaxCount.Focus();
            }
            else if (this.tNedit_MaxCount.GetInt() >0 && this.tNedit_MaxCount.GetInt() < 5000)
            // --- ADD yangyi 2013/04/19 for Redmine#35018 -------<<<<<<<<<<<
	        {
                //そのまま登録します
	            Serialize(); 
                this.Close();
            }

            else if (this.tNedit_MaxCount.GetInt() >= 5000 && this.tNedit_MaxCount.GetInt() <= 20000)
	        {
                // 警告を表示
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        WARNING_MSG,
                        0,
                        MessageBoxButtons.OKCancel,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.OK)
                {
                    Serialize();
                    this.Close();
                }
                else
                {
                   //設定画面に戻ります
                   this.DialogResult = DialogResult.Retry;
                   this.tNedit_MaxCount.Focus();
                }
                
	        }
            else if (this.tNedit_MaxCount.GetInt() > 20000)
            {
                //最大出力件数が5000件以上のときに警告画面を表示します。
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    this.Name,				            // プログラム名称
                    ERROR_MSG,							// 表示するメッセージ
                    0, 							        // ステータス値
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                //設定画面に戻ります
                this.DialogResult = DialogResult.Retry;
                this.tNedit_MaxCount.Focus();
            }
        }

        /// <summary>
        /// Button_Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォームがロージングされたときに発生します。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void PMZAI09201UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        #endregion ■ Control Events

        #region ■ Private Methods
        /// <summary>
        ///  商品在庫一括登録修正画面用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _maxCount = UserSettingController.DeserializeUserSetting<int>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            else
            {
                //規定値2000
                _maxCount = 2000;
            }
            this.tNedit_MaxCount.SetInt(_maxCount);      
        }

        /// <summary>
        ///  商品在庫一括登録修正画面用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Serialize()
        {
            if (this.tNedit_MaxCount.GetInt() == 0)
            {
                _maxCount = 2000;
            }
            else
            {
                _maxCount = this.tNedit_MaxCount.GetInt();
            }
            
            UserSettingController.SerializeUserSetting(_maxCount, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
        }


        #endregion ■ Private Methods
   }
}


