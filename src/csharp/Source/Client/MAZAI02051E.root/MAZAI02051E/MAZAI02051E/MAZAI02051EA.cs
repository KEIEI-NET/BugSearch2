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

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 在庫調整確認表抽出クラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 在庫調整確認表UIフォームクラス</br>
    /// <br>Programmer : 97036 amami</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br>UpdateNote : 2007.10.04 980035 金沢 貞義</br>
    /// <br>             ・ DC.NS対応</br>
    /// <br>Update Note: 2010/11/15 tianjw</br>
    /// <br>             ＰＭ．ＮＳ　機能改良Ｑ４</br>
    /// <br></br>
    /// </remarks>
    public class MAZAI02051EA : IExtrProc
    {
		# region Constractor
		/// <summary>
		/// 在庫調整確認表抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表UIクラス</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// <br></br>
		/// </remarks>
        public MAZAI02051EA( object printInfo )
        {
			// 印刷情報クラス
			this._printInfo = printInfo as SFCMN06002C;

			// 抽出条件クラス
			this._extraInfo = this._printInfo.jyoken as ConfirmStockAdjustListCndtn;

			// 在庫調整確認表アクセスクラス
			this._stockAdjustListAcs = new StockAdjustListAcs();
        }
        # endregion

		# region Private Menbers
		/// <summary> 印刷情報クラス </summary>
		private SFCMN06002C _printInfo = null;
		/// <summary> 抽出条件クラス </summary>
		private ConfirmStockAdjustListCndtn _extraInfo = null;
		/// <summary> 在庫調整確認表アクセスクラス </summary>
		private StockAdjustListAcs _stockAdjustListAcs = null;
		# endregion

		# region Private const Menbers
		/// <summary> プログラムID </summary>
		private const string ct_PGID = "MAZAI02051E";
		# endregion


		# region ■ IExtrProc インターフェース
		# region Public Property
		/// <summary> 印刷情報クラスプロパティ </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
		}
		# endregion

		#region Public Method
		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 印刷のメイン処理を行います。</br>
		/// <br>Programmer	: 97036 amami</br>
		/// <br>Date		: 2007.03.14</br>
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
		# endregion
		# endregion

		# region Private Method
		/// <summary>
		/// 抽出処理メイン処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 印刷のメイン処理を行います。</br>
		/// <br>Programmer	: 97036 amami</br>
        /// <br>Date		: 2007.03.14</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>             ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
				// 在庫調整確認データ取得
				status = this._stockAdjustListAcs.SearchConfirmStockAdjust(this._extraInfo, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
					// フィルター文字列
					string strFilter = "";
                    // ---------- UPD 2010/11/15 ----------------------------->>>>>
                    string strSort = "";
                    if (this._extraInfo.OutputSort == 0)
                    {
                        strSort = this.MakeSortingOrderString();
                    }
                    else
                    {
                        strSort = this.MakeSortingOrderString2();
                    }
					// ソート文字列を取得
					//string strSort = this.MakeSortingOrderString();
                    // ---------- UPD 2010/11/15 -----------------------------<<<<<
					// 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
					DataView dv = new DataView(this._stockAdjustListAcs.StockAdjustDs.Tables[MAZAI02054EA.ct_Tbl_StockAdjustDtl], strFilter, strSort, DataViewRowState.CurrentRows);
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
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private string MakeSortingOrderString()
		{
			string sortStr = "";

            // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
            //// 拠点オプションありかつ拠点選択の時
			//if ((this._extraInfo.IsOptSection) && (this._extraInfo.SecCodeList.Length > 1))
			//{
			//	// ソート条件に拠点を追加
			//	this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_SectionCode, 0);
			//}
            // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/07/07 ---------->>>>>
            // 拠点
            this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_SectionCode, 0);

            // 倉庫
            this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_WarehouseCode, 0);
            //--- ADD 2008/07/07 ----------<<<<<

			// ソート用調整日付
			this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_Sort_AdjustDate, 0);

			// 在庫調整伝票番号
			this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_StockAdjustSlipNo, 0);

			// 在庫調整行番号
			this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_StockAdjustRowNo, 0);

			return sortStr;
		}

        // ---------- ADD 2010/11/15 ---------->>>>>
        /// <summary>
        /// ソート文字列作成処理
        /// </summary>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       : ソート文字列を作成します。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2010/11/15</br>
        /// </remarks>
        private string MakeSortingOrderString2()
        {
            string sortStr = "";

            // 倉庫
            this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_WarehouseCode, 0);

            // 棚番
            this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_WarehouseShelfNo, 0);

            // 品番
            this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_GoodsNo, 0);

            // メーカー
            this.MakeSortQuery(ref sortStr, MAZAI02054EA.ct_Col_MakerCode, 0);

            return sortStr;
        }
        // ---------- ADD 2010/11/15 ----------<<<<<

		/// <summary>
		/// ソート用文字列作成処理
		/// </summary>
		/// <param name="colName">列名称</param>
		/// <param name="ascDescDiv">昇順・降順区分[0:昇順, 1:降順]</param>
		/// <param name="strQuery">ソート用文字列</param>
		/// <remarks>
		/// <br>Note       : ソート用の文字列の作成を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
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
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        # endregion
	}
}
