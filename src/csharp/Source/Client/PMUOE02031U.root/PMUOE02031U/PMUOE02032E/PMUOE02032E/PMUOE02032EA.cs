//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リストデータクラス
// プログラム概要   : 送信前リストデータクラスを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/09/11  修正内容 : MAHNB02011E：入金確認表を参考に新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 送信前リスト抽出クラス
    /// </summary>
    public sealed class PMUOE02032EA : IExtrProc
    {
        #region <IExtrProc メンバ/>

        #region <印刷情報/>

        /// <summary>印刷情報</summary>
        private SFCMN06002C _printInfo;
        /// <summary>
        /// 印刷情報のアクセサ
        /// </summary>
        /// <value>印刷情報</value>
        public SFCMN06002C Printinfo
        {
            get { return _printInfo; }
            set { _printInfo = value; }
        }

        #endregion  // <印刷情報/>

        #region <抽出処理/>

        /// <summary>
        /// 抽出処理を行います。
        /// </summary>
        /// <returns>結果コード</returns>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出中画面部品を生成
            Broadleaf.Windows.Forms.SFCMN00299CA extractingForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
            {
                // 表示文字を設定
                extractingForm.Title    = "抽出中";                     // LITERAL:
                extractingForm.Message  = "現在、データを抽出中です。"; // LITERAL:
            }
            try
            {
                extractingForm.Show();  // ダイアログ表示
                status = ExtraProc();   // 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                extractingForm.Close();
                Printinfo.status = status;
            }

            return status;
        }

        /// <summary>
        /// 抽出処理を行います。
        /// </summary>
        /// <returns>結果コード</returns>
        private int ExtraProc()
        {
            const string PG_ID = "PMUOE02032E"; // HACK:プログラムID

            string errMsg = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                status = SendBeforeAcs.SearchSendBeforeList(ExtraInfo, out errMsg);
                if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
                {
                    // 印刷データを印刷情報に設定
                    Printinfo.rdData = SendBeforeAcs.SearchedResult;
                }
            }
            catch (Exception e)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    PG_ID,
                    e.Message,
                    status,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1
                );
            }
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        break;

                    default:
                    {
                        // ステータスが以上のときはメッセージを表示
                        TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            PG_ID,
                            errMsg,
                            status,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        break;
                    }
                }
            }

            return status;
        }

        #endregion  // <抽出処理/>

        #endregion  // <IExtrProc メンバ/>

        #region <抽出条件/>

        /// <summary>抽出条件</summary>
        private readonly SendBeforeOrderCondition _extraInfo;
        /// <summary>
        /// 抽出条件を取得します。
        /// </summary>
        /// <value>抽出条件</value>
        public SendBeforeOrderCondition ExtraInfo { get { return _extraInfo; } }

        #endregion  // <抽出条件

        #region <送信前リストアクセス/>

        /// <summary>送信前リストアクセス</summary>
        private readonly SendBeforeAcs _sendBeforeAcs;
        /// <summary>
        /// 送信前リストアクセスを取得します。
        /// </summary>
        /// <value>送信前リストアクセス</value>
        private SendBeforeAcs SendBeforeAcs { get { return _sendBeforeAcs; } }

        #endregion  // <送信前リストアクセス/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報</param>
        public PMUOE02032EA(object printInfo)
        {
            // 印刷情報
            _printInfo = printInfo as SFCMN06002C;
            _extraInfo = _printInfo.jyoken as SendBeforeOrderCondition;
            _sendBeforeAcs = new SendBeforeAcs();
        }

        #endregion  // <Constructor/>
    }
}
