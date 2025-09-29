//**********************************************************************//
// System			:	PM.NS									        //
// Sub System		:													//
// Program name		:	手形確認表 データクラス		                    //
//					:	PMTEG02001EA.DLL								//
// Name Space		:	Broadleaf.Application.UIData					//
// Programmer		:	張義 											//
// Date				:	2010.05.05										//
//----------------------------------------------------------------------//
// Update Note		:													//
//----------------------------------------------------------------------//
//                 Copyright(c)2010 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 手形確認表 データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 手形確認表UIフォームクラス</br>
    /// <br>Programmer	: 張義</br>
    /// <br>Date		: 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class PMTEG02001EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
        /// 手形確認表一覧抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note        : 手形確認表一覧UIクラス</br>
        /// <br>Programmer	: 張義</br>
        /// <br>Date		: 2010.05.05</br>
        /// <br></br>
		/// </remarks>
        public PMTEG02001EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._tegataConfirmReportAcs = new TegataConfirmReportAcs();
            this._tegataConfirmReport = this._printInfo.jyoken as TegataConfirmReport;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			// 印刷情報クラス
        private TegataConfirmReportAcs _tegataConfirmReportAcs = null;		// 手形確認表一覧アクセスクラス
        private TegataConfirmReport _tegataConfirmReport = null;	// 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        // クラスID
        private const string ct_PGID = "PMTEG02001E";
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
        /// <br>Programmer : 張義</br>
        /// <br>Date		  : 2010.05.05</br>
        /// </remarks>
        public int ExtrPrintData()
        {
           int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
           // 抽出中画面部品のインスタンスを作成
           Broadleaf.Windows.Forms.SFCMN00299CA form = new SFCMN00299CA();
           // 表示文字を設定
           form.Title = "抽出中";
           form.Message = "現在、データを抽出中です。";

           try
           {
               form.Show();			// ダイアログ表示
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
        /// <br>Programmer  : 張義</br>
        /// <br>Date		   : 2010.05.05</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {   // データテーブルから、データを検索します
                status = this._tegataConfirmReportAcs.SearchTegataConfirmReportProcMain(this._tegataConfirmReport, out errMsg);
               if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
               {
                   // 印刷データを設定処理
                   this._printInfo.rdData = this._tegataConfirmReportAcs.DataSet;
               }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            // ステータスが以上のときはメッセージを表示
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                       MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
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
        /// <br>Programmer : 張義</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}
