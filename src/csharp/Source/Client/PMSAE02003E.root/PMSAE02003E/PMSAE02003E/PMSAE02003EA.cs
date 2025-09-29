//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス商品コード変換マスタ（印刷） 抽出クラス
// プログラム概要   : オートバックス商品コード変換マスタ（印刷） 抽出クラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// オートバックス商品コード変換マスタ（印刷） 抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : オートバックス商品コード変換マスタ（印刷） 抽出クラス</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// <br>           : </br>
    /// </remarks>
    public class PMSAE02003EA : IExtrProc
    {
        #region ■ Constructor
        /// <summary>
        /// オートバックス商品コード変換マスタ（印刷） 抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オートバックス商品コード変換マスタ（印刷） 抽出クラスUIクラス</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.05</br>
        /// <br></br>
        /// </remarks>
        public PMSAE02003EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			                        // 印刷情報クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMSAE02003E";
        #endregion ■ private const

        #region ■ IExtrProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// 印刷情報クラスプロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";

            try
            {
                form.Show();			    // ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IExtrProc メンバ

        #region ■ Private Method
        #region ◆ 抽出メイン処理
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private int ExtraProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if ((this._printInfo.rdData as DataView).Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }


            return status;
        }
        #endregion ◆ 抽出メイン処理

        #region ◆ エラーメッセージ表示
        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}
