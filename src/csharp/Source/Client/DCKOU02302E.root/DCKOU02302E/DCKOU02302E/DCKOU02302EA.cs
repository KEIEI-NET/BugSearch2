using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 入荷一覧表抽出抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷一覧表UIフォームクラス</br>
    /// <br>Programmer : 30191 馬淵 愛</br>
    /// <br>Date       : 2008.02.05</br>
    /// <br>UpdateNote : 仕様変更に伴う変更。</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date	   : 2008/06/25</br>    
    /// <br></br>
    /// </remarks>
    public class DCKOU02302EA : IExtrProc
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 入荷一覧表抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷一覧表UIクラス</br>
        /// <br>Programmer : 30191 馬淵 愛</br>
        /// <br>Date       : 2008.02.05</br>
        /// <br></br>
        /// </remarks>
        public DCKOU02302EA()
        {
        }

        /// <summary>
        /// 入荷一覧表抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷一覧表UIクラス</br>
        /// <br>Programmer : 30191 馬淵 愛</br>
        /// <br>Date       : 2008.02.05</br>
        /// <br></br>
        /// </remarks>
        public DCKOU02302EA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
			this._extraInfo = this._printInfo.jyoken as ExtrInfo_DCKOU02304E;
			this._salesTableListAcs = new DCKOU02306A();
        }
        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;

		private DCKOU02306A _salesTableListAcs = null;        // 入荷一覧表アクセスクラス
		private ExtrInfo_DCKOU02304E _extraInfo = null;            // 抽出条件クラス

		private string _PGID = "DCKOU02302EA";

        #endregion

        // ===============================================================================
        // IExtrProc 実装部
        // ===============================================================================
        #region IExtrProc メンバ

        /// <summary> 印刷情報クラスプロパティ </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        public int ExtrPrintData()
        {
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            pd.Title = "抽出中";
            pd.Message = "現在、データ抽出中です。";

            try
            {
                pd.Show();
                status = this.ExtraProc();
            }
            finally
            {
                pd.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        #endregion

        // ===============================================================================
        // 内部使用関数
        // ===============================================================================
        #region private methods
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        private int ExtraProc()
        {
            int result = (int)Broadleaf.Library.Resources.ConstantManagement.MethodResult.ctFNC_ERROR;
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            string message = "";

            try
            {
//                this._extraInfo.ExtraDivCd = GetOutputCondDiv(this._printInfo.prpid);
                status = this._salesTableListAcs.Search(this._extraInfo, out message, 0);
                if (status == 0)
                {
                    this._printInfo.rdData = this._salesTableListAcs._printDataSet;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                    MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this._PGID, message, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                }
            }
            return result;
        }

//        /// <summary>
//        /// 出力条件区分取得処理
//        /// </summary>
//        private int GetOutputCondDiv(string prpid)
//        {
//            int result = -1;
//
//            switch (prpid)
//            {
//                case "DCHNB04152P_01A4C":
//                    {
//                        // 入荷一覧表
//                        result = 0;
//                        break;
//                    }
//            }
//
//            return result;
//        }

        #endregion


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
        /// <br>Programmer : 30191 馬淵 愛</br>
        /// <br>Date       : 2008.02.05</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            //return TMsgDisp.Show(iLevel, "入荷一覧表抽出処理", iMsg, iSt, iButton, iDefButton);  // DEL 2008/06/25
            return TMsgDisp.Show(iLevel, "入荷確認表抽出処理", iMsg, iSt, iButton, iDefButton);  // DEL 2008/06/25
        }
    }
}
