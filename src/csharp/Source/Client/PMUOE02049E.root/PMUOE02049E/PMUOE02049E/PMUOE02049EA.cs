using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 発行確認一覧表用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 発行確認一覧表用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 30009 渋谷 大輔</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br>Programmer : 30009 渋谷 大輔</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// </remarks>
	public class PMUOE02049EA
	{
		# region Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_PublicationConfDtl  = "Tbl_PublicationConfDtl";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode         = "SectionCode";

        /// <summary> 拠点ガイド名称 </summary>
        public const string ct_Col_SectionGuideNm      = "SectionGuideNm";

        /// <summary> オンライン番号 </summary>
        public const string ct_Col_OnlineNo            = "OnlineNo";

        /// <summary> オンライン行番号 </summary>
        public const string ct_Col_OnlineRowNo         = "OnlineRowNo";

        /// <summary> システム区分 </summary>
        public const string ct_Col_SystemDivCd         = "SystemDivCd";

        /// <summary> システム区分名称 </summary>
        public const string ct_Col_SystemDivName       = "SystemDivName";

        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo             = "GoodsNo";

        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode       = "WarehouseCode";

        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo    = "WarehouseShelfNo";

        /// <summary> 定価（浮動） </summary>
        public const string ct_Col_ListPrice           = "ListPrice";

        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt    = "AcceptAnOrderCnt";

        /// <summary> UOE拠点出庫数 </summary>
        public const string ct_Col_UOESectOutGoodsCnt  = "UOESectOutGoodsCnt";

        /// <summary> BO出庫数1 </summary>
        public const string ct_Col_BOShipmentCnt1      = "BOShipmentCnt1";

        /// <summary> BO出庫数2 </summary>
        public const string ct_Col_BOShipmentCnt2      = "BOShipmentCnt2";

        /// <summary> BO出庫数3 </summary>
        public const string ct_Col_BOShipmentCnt3      = "BOShipmentCnt3";

        /// <summary> メーカーフォロー数 </summary>
        public const string ct_Col_MakerFollowCnt      = "MakerFollowCnt";

        /// <summary> EO引当数 </summary>
        public const string ct_Col_EOAlwcCount         = "EOAlwcCount";

        /// <summary> UOE発注先名称 </summary>
        public const string ct_Col_UOESupplierName     = "UOESupplierName";

        /// <summary> 受信日付 </summary>
        public const string ct_Col_ReceiveDate         = "ReceiveDate";

        /// <summary> ＵＯＥリマーク1 </summary>
        public const string ct_Col_UoeRemark1          = "UoeRemark1";

        /// <summary> ＵＯＥリマーク2 </summary>
        public const string ct_Col_UoeRemark2          = "UoeRemark2";

        /// <summary> 回答品番 </summary>
        public const string ct_Col_AnswerPartsNo       = "AnswerPartsNo";

        /// <summary> 回答品名 </summary>
        public const string ct_Col_AnswerPartsName     = "AnswerPartsName";

        /// <summary> 回答定価 </summary>
        public const string ct_Col_AnswerListPrice     = "AnswerListPrice";

        /// <summary> 回答原価単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> UOE拠点伝票番号 </summary>
        public const string ct_Col_UOESectionSlipNo    = "UOESectionSlipNo";

        /// <summary> BO伝票番号1 </summary>
        public const string ct_Col_BOSlipNo1           = "BOSlipNo1";

        /// <summary> BO伝票番号2 </summary>
        public const string ct_Col_BOSlipNo2           = "BOSlipNo2";

        /// <summary> BO伝票番号3 </summary>
        public const string ct_Col_BOSlipNo3           = "BOSlipNo3";

        /// <summary> BO管理番号 </summary>
        public const string ct_Col_BOManagementNo      = "BOManagementNo";

        /// <summary> チェック内容名称 </summary>
        public const string ct_Col_CheckCntsNm         = "CheckCntsNm";

        /// <summary> フリーカラム１ </summary>
        public const string ct_Col_FreeColumn1         = "FreeColumn1";

        /// <summary> フリーカラム１名称 </summary>
        public const string ct_Col_FreeColumn1Nm       = "FreeColumn1Nm";

        /// <summary> フリーカラム２ </summary>
        public const string ct_Col_FreeColumn2         = "FreeColumn2";

        /// <summary> フリーカラム２名称 </summary>
        public const string ct_Col_FreeColumn2Nm       = "FreeColumn2Nm";

        
        
        // --- DataTable項目フォーマット形式 --- //
        /// <summary>共通 表示用日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";
        # endregion Public Const

        # region Constructor
        /// <summary>
		/// 発行確認一覧表用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発行確認一覧表用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public PMUOE02049EA()
		{
		}
		# endregion

		# region Static Public Method
		/// <summary>
		/// 発行確認一覧表DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : 発行確認一覧表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        static public void CreateDataTablePublicationConfDtl(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_PublicationConfDtl))
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_PublicationConfDtl].Clear();
			}
			else
			{
				// スキーマ設定
                ds.Tables.Add(ct_Tbl_PublicationConfDtl);
                DataTable dt = ds.Tables[ct_Tbl_PublicationConfDtl];

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));         // 拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));      // 拠点名称
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

                dt.Columns.Add(ct_Col_OnlineNo, typeof(int));               // オンライン番号
                dt.Columns[ct_Col_OnlineNo].DefaultValue = 0;

                dt.Columns.Add(ct_Col_OnlineRowNo, typeof(int));	    	// オンライン行番号
                dt.Columns[ct_Col_OnlineRowNo].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SystemDivName, typeof(string));		// システム区分
                dt.Columns[ct_Col_SystemDivName].DefaultValue = "";

                dt.Columns.Add(ct_Col_SystemDivCd, typeof(int));			// システム区分
                dt.Columns[ct_Col_SystemDivCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));             // 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));       // 倉庫コード
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));    // 倉庫棚番
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_ListPrice, typeof(double));           // 定価（浮動）
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(double));    // 受注数量
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(int));     // UOE拠点出庫数
                dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(int));         // BO出庫数1
                dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(int));         // BO出庫数2
                dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = 0;

                dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(int));         // BO出庫数3
                dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(int));         // メーカーフォロー数
                dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_EOAlwcCount, typeof(int));            // EO引当数
                dt.Columns[ct_Col_EOAlwcCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));     // UOE発注先名称
                dt.Columns[ct_Col_UOESupplierName].DefaultValue = "";

                dt.Columns.Add(ct_Col_ReceiveDate, typeof(DateTime));            // 受信日付
                dt.Columns[ct_Col_ReceiveDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));          // ＵＯＥリマーク1
                dt.Columns[ct_Col_UoeRemark1].DefaultValue = "";

                dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));          // ＵＯＥリマーク2
                dt.Columns[ct_Col_UoeRemark2].DefaultValue = "";

                dt.Columns.Add(ct_Col_AnswerPartsNo, typeof(string));       // 回答品番
                dt.Columns[ct_Col_AnswerPartsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_AnswerPartsName, typeof(string));     // 回答品名
                dt.Columns[ct_Col_AnswerPartsName].DefaultValue = "";

                dt.Columns.Add(ct_Col_AnswerListPrice, typeof(double));     // 回答定価
                dt.Columns[ct_Col_AnswerListPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(double)); // 回答原価単価
                dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = 0;

                dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));    // UOE拠点伝票番号
                dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));           // BO伝票番号1
                dt.Columns[ct_Col_BOSlipNo1].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));           // BO伝票番号2
                dt.Columns[ct_Col_BOSlipNo2].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));           // BO伝票番号3
                dt.Columns[ct_Col_BOSlipNo3].DefaultValue = "";

                dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));      // BO管理番号
                dt.Columns[ct_Col_BOManagementNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_CheckCntsNm, typeof(string));  　     // チェック内容名称
                dt.Columns[ct_Col_CheckCntsNm].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn1, typeof(string));         // フリーカラム１
                dt.Columns[ct_Col_FreeColumn1].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn1Nm, typeof(string));       // フリーカラム１名称
                dt.Columns[ct_Col_FreeColumn1Nm].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn2, typeof(string));         // フリーカラム２
                dt.Columns[ct_Col_FreeColumn2].DefaultValue = "";

                dt.Columns.Add(ct_Col_FreeColumn2Nm, typeof(string));       // フリーカラム２名称
                dt.Columns[ct_Col_FreeColumn2Nm].DefaultValue = "";

			}
		}

		/// <summary>
        /// システム区分名称取得処理
		/// </summary>
        /// <param name="systemDivCd">システム区分</param>
        /// <returns>システム区分名称</returns>
		/// <remarks>
        /// <br>Note       : システム区分名称の取得を行います。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        static public string GetSystemDivNm(int systemDivCd)
        {
            string systemDivNm = "";
            switch (systemDivCd)
            {
                // 2009.01.13 UPD 不要な区分の削除>>>>>>>>>>>>>>>>>>>>>>>>>>>
                case 0: systemDivNm = "手入力"; break;
                case 1: systemDivNm = "伝発"; break;
                case 2: systemDivNm = "検索"; break;
                case 3: systemDivNm = "一括"; break;
                case 4: systemDivNm = "補充"; break;
                //case 9: systemDivNm = "全て"; break;
                case 9: systemDivNm = "伝発以外"; break;
                // 2009.01.13 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return systemDivNm;
        }

        # endregion
	}
}
