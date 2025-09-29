using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 委託在庫補充処理表抽出クラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 委託在庫補充処理表UIフォームクラス</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/11/12</br>
    /// </remarks>
    public class PMZAI02068EA : IExtrProc
    {
        # region ■ Constants

        /// <summary> プログラムID </summary>
        private const string ct_PGID = "PMZAI02068E";

        # endregion ■ Constants


        # region ■ Private Members

        /// <summary> 印刷情報クラス </summary>
        private SFCMN06002C _printInfo = null;

        /// <summary> 抽出条件クラス </summary>
        private TrustStockOrderCndtn _extraInfo = null;

        /// <summary> 委託在庫補充処理表アクセスクラス </summary>
        private TrustStockOrderAcs _trustStockOrderAcs = null;

        # endregion ■ Private Members


        # region ■ Constractor

        /// <summary>
		/// 委託在庫補充処理表抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 委託在庫補充処理表UIクラス</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
        public PMZAI02068EA( object printInfo )
        {
			// 印刷情報クラス
			this._printInfo = printInfo as SFCMN06002C;

			// 抽出条件クラス
            this._extraInfo = this._printInfo.jyoken as TrustStockOrderCndtn;

			// 委託在庫補充処理表アクセスクラス
            this._trustStockOrderAcs = new TrustStockOrderAcs();
        }

        # endregion ■ Constractor


        # region ■ IExtrProc インターフェース
        /// <summary> 印刷情報クラスプロパティ </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
		/// 抽出処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 印刷のメイン処理を行います。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/11/12</br>
		/// </remarks>
        public int ExtrPrintData()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA form = new SFCMN00299CA();

            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            
			try
			{
				// ダイアログ表示
                form.Show();
				// 抽出処理実行
                status = this.ExtraProc();
            }
            finally
            {
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        # endregion  ■ IExtrProc インターフェース


        # region ■ Private Methods
        /// <summary>
		/// 抽出処理メイン処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 印刷のメイン処理を行います。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/11/12</br>
		/// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
				// 在庫調整確認データ取得
                // 更新処理を行った後の場合、データは既に取得済みなので、処理を行わない
                if (this._printInfo.rdData == null)
                {
                    DataTable dataTable;
                    status = this._trustStockOrderAcs.Search(this._extraInfo, out dataTable, out errMsg);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // フィルター文字列
                        string strFilter = "";
                        // ソート文字列を取得
                        string strSort = MakeSortingOrderString();

                        // 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
                        DataView dv = new DataView(dataTable, strFilter, strSort, DataViewRowState.CurrentRows);
                        if (dv.Count > 0)
                        {
                            // データをセット
                            this._printInfo.rdData = dv;
                        }
                        // 該当データ無し
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
            }
            return status;
		}

		/// <summary>
		/// ソート文字列作成処理
		/// </summary>
		/// <returns>ソート文字列</returns>
		/// <remarks>
		/// <br>Note       : ソート文字列を作成します。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		public static string MakeSortingOrderString()
		{
			string sortStr = "";

            // 委託先倉庫コード
            MakeSortQuery(ref sortStr, PMZAI02069EA.ct_Col_AfWarehouseCode, 0);

            // メーカー
            MakeSortQuery(ref sortStr, PMZAI02069EA.ct_Col_MakerCode, 0);

            // 品番
            MakeSortQuery(ref sortStr, PMZAI02069EA.ct_Col_GoodsNo, 0);

			return sortStr;
		}

		/// <summary>
		/// ソート用文字列作成処理
		/// </summary>
		/// <param name="colName">列名称</param>
		/// <param name="ascDescDiv">昇順・降順区分[0:昇順, 1:降順]</param>
		/// <param name="strQuery">ソート用文字列</param>
		/// <remarks>
		/// <br>Note       : ソート用の文字列の作成を行います。</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/11/12</br>
		/// </remarks>
		private static void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
		{
			if (strQuery == null)
			{
				strQuery = "";
			}

			if (strQuery == "")
			{
				strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
			}
			else
			{
				strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
			}
		}

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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        # endregion ■ Private Methods
    }
}
