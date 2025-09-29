using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 回線エラーリスト　抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 回線エラーリスト　抽出クラス</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/04</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE02011EA : IExtrProc
    {
        #region ■定数、変数、構造体
        // 定数
        private const string PG_ID = "PMUOE02011E";

        // 変数
        private SFCMN06002C _printInfo = null;			            // 印刷情報クラス
        private CircuitErrorListAcs _circuitErrorListAcs = null;    // 回線エラーリストアクセスクラス
        #endregion

        #region ■Constructor
        /// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : コンストラクタ</br>
		/// <br>Programmer : 照田 貴志</br>
		/// <br>Date       : 2008/11/04</br>
		/// <br></br>
		/// </remarks>
        public PMUOE02011EA( object printInfo )
        {
            // 印刷情報取得
            // ※この時点ですでにprintInfo.rdDataにデータが入っている
            // 形式はList<OrderSndRcvJnl>
            // アクセスクラスに渡してDataSet形式に変換をかけて呼び出し元に返す
            this._printInfo = printInfo as SFCMN06002C;

            // インスタンス作成
            this._circuitErrorListAcs = new CircuitErrorListAcs((List<OrderSndRcvJnl>)this._printInfo.rdData);
       }
        #endregion ■Constructor - end

        #region ■Public
        #region ▼IExtrProcインターフェイス用プロパティ
        /// <summary> 印刷情報クラスプロパティ </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion

        #region ▼ExtrPrintData(印刷データ抽出)
        /// <summary>
        /// 印刷データ抽出
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷データの抽出を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
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
        #endregion ■Public - end

        #region ■Private
        #region ▼ ExtraProc(印刷データ抽出処理)
        /// <summary>
        /// 印刷データ抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷データの抽出を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = this._circuitErrorListAcs.SearchMain(out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 印刷用データ取得
                    this._printInfo.rdData = this._circuitErrorListAcs.circuitErrorListDataView;
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PG_ID, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PG_ID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
            }
            return status;
        }
        #endregion
        #endregion ■Private - end

	}
}
