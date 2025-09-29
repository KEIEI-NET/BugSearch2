//**********************************************************************//
// System			:	PM.NS									        //
// Sub System		:													//
// Program name		:	当月車検車両一覧表 抽出クラス		            //
//					:	PMSYA02104EA.DLL								//
// Name Space		:	Broadleaf.Application.UIData					//
// Programmer		:	薛祺 											//
// Date				:	2010.04.21										//
//----------------------------------------------------------------------//
// Update Note		:													//
//----------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                  //
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
    /// 当月車検車両一覧表 抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 当月車検車両一覧表抽出クラス</br>
    /// <br>Programmer	: 薛祺</br>
    /// <br>Date		: 2010.04.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class PMSYA02104EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
        /// 当月車検車両一覧抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note        : 当月車検車両一覧UIクラス</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// <br></br>
		/// </remarks>
        public PMSYA02104EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._monthCarInspectListAcs = new MonthCarInspectListAcs();
            this._monthCarInspectListPara = this._printInfo.jyoken as MonthCarInspectListPara;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			// 印刷情報クラス
        private MonthCarInspectListAcs _monthCarInspectListAcs = null;	// 当月車検車両一覧アクセスクラス
        private MonthCarInspectListPara _monthCarInspectListPara = null;	// 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        // クラスID
        private const string ct_PGID = "PMSYA02104E";
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
       /// <br>Programmer : 薛祺</br>
       /// <br>Date		  : 2010.04.21</br>
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
        /// <br>Programmer  : 薛祺</br>
        /// <br>Date		   : 2010.04.21</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {   // データテーブルから、データを検索します
                status = this._monthCarInspectListAcs.SearchMonthCarInspectListProcMain(this._monthCarInspectListPara, out errMsg);
               if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
               {
                   // 印刷データを設定処理
                   this._printInfo.rdData = this._monthCarInspectListAcs.DataSet;
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
        /// <br>Programmer : 薛祺</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}
