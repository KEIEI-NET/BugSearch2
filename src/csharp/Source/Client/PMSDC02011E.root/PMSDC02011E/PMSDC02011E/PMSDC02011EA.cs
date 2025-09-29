//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 田建委
// 作 成 日  2019/12/02      修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11675168-00     作成担当 : 陳永康
// 作 成 日  2021/08/03      修正内容 : PMKOBETSU-4115 PDF出力既存障害の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 売上データテキスト抽出クラスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキストUIフォームクラス</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br>UpdateNote : PMKOBETSU-4115 PDF出力既存障害の対応</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2021/08/03</br>
    /// </remarks>
    public class PMSDC02011EA : IExtrProc
    {
        #region ■ Constructor
        /// <summary>
        /// 売上データテキスト抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキストUIクラス</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br></br>
        /// </remarks>
        public PMSDC02011EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._salesCprtAcs = new SalesCprtAcs();
            this._salesHistoryCndtn = this._printInfo.jyoken as SalesCprtCndtnWork;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			        // 印刷情報クラス
        private SalesCprtAcs _salesCprtAcs = null;		// 売上連携データテキストアクセスクラス
        private SalesCprtCndtnWork _salesHistoryCndtn = null;	// 売上連携データテキスト抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMSDC02011E";
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>UpdateNote : PMKOBETSU-4115 PDF出力既存障害の対応</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2021/08/03</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            DataTable printdataTable = new DataTable();
            try
            {
                if (_salesHistoryCndtn.Mode == 0)
                {
                    // --- ADD 陳永康 2021/08/03 PMKOBETSU-4115 PDF出力既存障害の対応 ----->>>>>
                    SalCprtConnectInfoWork connectInfoWork = null;
                    SalCprtConnectInfoWorkAcs connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();

                    // 接続先情報設定マスタ情報取得
                    status = connectInfoWorkAcs.Read(out connectInfoWork, _salesHistoryCndtn.EnterpriseCode, 0, _salesHistoryCndtn.SectionCode, _salesHistoryCndtn.CustomerCode);
                    // --- ADD 陳永康 2021/08/03 PMKOBETSU-4115 PDF出力既存障害の対応 -----<<<<<

                    // 印刷データ取得
                    // --- UPD 陳永康 2021/08/03 PMKOBETSU-4115 PDF出力既存障害の対応 ----->>>>>
                    //status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg);
                    if (connectInfoWork != null && status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        status = this._salesCprtAcs.SearchSalesHistoryProcMain(this._salesHistoryCndtn, out errMsg, connectInfoWork);
                    }
                    // --- ADD 陳永康 2021/08/03 PMKOBETSU-4115 PDF出力既存障害の対応 -----<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 印刷データ取得
                        this._printInfo.rdData = this._salesCprtAcs.GetprintdataTable();
                    }
                }
                else
                {
                    if (this._printInfo.rdData != null)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
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
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }

        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}
