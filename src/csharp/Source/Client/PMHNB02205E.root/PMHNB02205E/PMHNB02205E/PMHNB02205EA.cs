//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリストテーブルスキーマ定義クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売価原価アンマッチリストテーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価原価アンマッチリストテーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class RateUnMatchResult
    {
        /// <summary> テーブル名称 </summary>
        public const string Tbl_Result_RateUnMatch = "Tbl_Result_RateUnMatch";

        /// <summary> 作成区分 </summary>
        public const string Col_ProcessKbn = "ProcessKbn";

        /// <summary> 作成区分 </summary>
        public const string Col_UpdateDateTime = "UpdateDateTime";

        /// <summary> 企業コード </summary>
        public const string Col_EnterpriseCode = "EnterpriseCode";

        /// <summary> 削除区分 </summary>
        public const string Col_LogicalDeleteCode = "LogicalDeleteCode";

        /// <summary> 削除区分 </summary>
        public const string Col_LogicalDeleteName = "LogicalDeleteName";

        /// <summary> 拠点コード </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 拠点コード </summary>
        public const string Col_SectionCodeForPrint = "SectionCodeForPrint";

        /// <summary> 拠点名称 </summary>
        public const string Col_SectionName = "SectionName";

        /// <summary> 単価掛率設定区分 </summary>
        public const string Col_UnitRateSetDivCd = "UnitRateSetDivCd";

        /// <summary> 単価種類 </summary>
        public const string Col_UnitPriceKindCd = "UnitPriceKindCd";

        /// <summary> 単価種類 </summary>
        public const string Col_UnitPriceKindNm = "UnitPriceKindNm";

        /// <summary> 掛率設定区分 </summary>
        public const string Col_RateSettingDivide = "RateSettingDivide";

        /// <summary> 掛率設定区分（商品） </summary>
        public const string Col_RateMngGoodsCd = "RateMngGoodsCd";

        /// <summary> 掛率設定名称（商品） </summary>
        public const string Col_RateMngGoodsNm = "RateMngGoodsNm";

        /// <summary> 掛率設定区分（得意先） </summary>
        public const string Col_RateMngCustCd = "RateMngCustCd";

        /// <summary> 掛率設定名称（得意先） </summary>
        public const string Col_RateMngCustNm = "RateMngCustNm";

        /// <summary> 商品メーカーコード </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> 商品メーカー名称 </summary>
        public const string Col_GoodsMakerNm = "GoodsMakerNm";

        /// <summary> 商品番号 </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> 商品名称 </summary>
        public const string Col_GoodsNm = "GoodsNm";

        /// <summary> 商品掛率ランク </summary>
        public const string Col_GoodsRateRank = "GoodsRateRank";

        /// <summary> 商品掛率グループコード </summary>
        public const string Col_GoodsRateGrpCode = "GoodsRateGrpCode";

        /// <summary> BLグループコード </summary>
        public const string Col_BLGroupCode = "BLGroupCode";

        /// <summary> BL商品コード </summary>
        public const string Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> 得意先コード </summary>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> 得意先掛率グループコード </summary>
        public const string Col_CustRateGrpCode = "CustRateGrpCode";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 商品メーカーコード </summary>
        public const string Col_GoodsMakerCdForPrint = "GoodsMakerCdForPrint";

        /// <summary> 商品番号 </summary>
        public const string Col_GoodsNoForPrint = "GoodsNoForPrint";

        /// <summary> 商品掛率ランク </summary>
        public const string Col_GoodsRateRankForPrint = "GoodsRateRankForPrint";

        /// <summary> 商品掛率グループコード </summary>
        public const string Col_GoodsRateGrpCodeForPrint = "GoodsRateGrpCodeForPrint";

        /// <summary> BLグループコード </summary>
        public const string Col_BLGroupCodeForPrint = "BLGroupCodeForPrint";

        /// <summary> BL商品コード </summary>
        public const string Col_BLGoodsCodeForPrint = "BLGoodsCodeForPrint";

        /// <summary> 得意先コード </summary>
        public const string Col_CustomerCodeForPrint = "CustomerCodeForPrint";

        /// <summary> 得意先掛率グループコード </summary>
        public const string Col_CustRateGrpCodeForPrint = "CustRateGrpCodeForPrint";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCdForPrint = "SupplierCdForPrint";

        /// <summary> ロット数 </summary>
        public const string Col_LotCount = "LotCount";

        /// <summary> 価格（浮動） </summary>
        public const string Col_PriceFl = "PriceFl";

        /// <summary> 掛率 </summary>
        public const string Col_RateVal = "RateVal";

        /// <summary> UP率 </summary>
        public const string Col_UpRate = "UpRate";

        /// <summary> 粗利確保率 </summary>
        public const string Col_GrsProfitSecureRate = "GrsProfitSecureRate";

        /// <summary> 単価端数処理単位 </summary>
        public const string Col_UnPrcFracProcUnit = "UnPrcFracProcUnit";

        /// <summary> 単価端数処理区分 </summary>
        public const string Col_UnPrcFracProcDiv = "UnPrcFracProcDiv";

        /// <summary> エラー区分 </summary>
        public const string Col_IsErrRateProtyMng = "IsErrRateProtyMng";

        /// <summary> エラー区分 </summary>
        public const string Col_IsErrGoodsU = "IsErrGoodsU";

        /// <summary> エラー区分 </summary>
        public const string Col_IsAllZero = "IsAllZero";

        /// <summary> 内容 </summary>
        public const string Col_Content = "Content";

        /// <summary>
        /// 売価原価アンマッチリストテーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売価原価アンマッチリストテーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
		/// </remarks>
        public RateUnMatchResult()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static public void CreateDataTableResultRateUnMatch(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_Result_RateUnMatch))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_Result_RateUnMatch].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Tbl_Result_RateUnMatch);

                DataTable dt = ds.Tables[Tbl_Result_RateUnMatch];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                DateTime defValueDateTime = new DateTime();
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_ProcessKbn, typeof(string));
                dt.Columns[Col_ProcessKbn].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdateDateTime, typeof(DateTime));
                dt.Columns[Col_UpdateDateTime].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_EnterpriseCode, typeof(string));
                dt.Columns[Col_EnterpriseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LogicalDeleteCode, typeof(Int32));
                dt.Columns[Col_LogicalDeleteCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_LogicalDeleteName, typeof(string));
                dt.Columns[Col_LogicalDeleteName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionCode, typeof(string));
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionCodeForPrint, typeof(string));
                dt.Columns[Col_SectionCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionName, typeof(string));
                dt.Columns[Col_SectionName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UnitRateSetDivCd, typeof(string));
                dt.Columns[Col_UnitRateSetDivCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UnitPriceKindCd, typeof(string));
                dt.Columns[Col_UnitPriceKindCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UnitPriceKindNm, typeof(string));
                dt.Columns[Col_UnitPriceKindNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateSettingDivide, typeof(string));
                dt.Columns[Col_RateSettingDivide].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngGoodsCd, typeof(string));
                dt.Columns[Col_RateMngGoodsCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngGoodsNm, typeof(string));
                dt.Columns[Col_RateMngGoodsNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngCustCd, typeof(string));
                dt.Columns[Col_RateMngCustCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_RateMngCustNm, typeof(string));
                dt.Columns[Col_RateMngCustNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(string));
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerNm, typeof(string));
                dt.Columns[Col_GoodsMakerNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNm, typeof(string));
                dt.Columns[Col_GoodsNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateRank, typeof(string));
                dt.Columns[Col_GoodsRateRank].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateGrpCode, typeof(string));
                dt.Columns[Col_GoodsRateGrpCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGroupCode, typeof(string));
                dt.Columns[Col_BLGroupCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGoodsCode, typeof(string));
                dt.Columns[Col_BLGoodsCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustomerCode, typeof(string));
                dt.Columns[Col_CustomerCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustRateGrpCode, typeof(string));
                dt.Columns[Col_CustRateGrpCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(string));
                dt.Columns[Col_SupplierCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LotCount, typeof(Double));
                dt.Columns[Col_LotCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_PriceFl, typeof(Double));
                dt.Columns[Col_PriceFl].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_RateVal, typeof(Double));
                dt.Columns[Col_RateVal].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UpRate, typeof(Double));
                dt.Columns[Col_UpRate].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_GrsProfitSecureRate, typeof(Double));
                dt.Columns[Col_GrsProfitSecureRate].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UnPrcFracProcUnit, typeof(Double));
                dt.Columns[Col_UnPrcFracProcUnit].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UnPrcFracProcDiv, typeof(Int32));
                dt.Columns[Col_UnPrcFracProcDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_IsErrRateProtyMng, typeof(string));
                dt.Columns[Col_IsErrRateProtyMng].DefaultValue = defValuestring;

                dt.Columns.Add(Col_IsErrGoodsU, typeof(string));
                dt.Columns[Col_IsErrGoodsU].DefaultValue = defValuestring;

                dt.Columns.Add(Col_IsAllZero, typeof(string));
                dt.Columns[Col_IsAllZero].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Content, typeof(string));
                dt.Columns[Col_Content].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCdForPrint, typeof(string));
                dt.Columns[Col_GoodsMakerCdForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNoForPrint, typeof(string));
                dt.Columns[Col_GoodsNoForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateRankForPrint, typeof(string));
                dt.Columns[Col_GoodsRateRankForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsRateGrpCodeForPrint, typeof(string));
                dt.Columns[Col_GoodsRateGrpCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGroupCodeForPrint, typeof(string));
                dt.Columns[Col_BLGroupCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGoodsCodeForPrint, typeof(string));
                dt.Columns[Col_BLGoodsCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustomerCodeForPrint, typeof(string));
                dt.Columns[Col_CustomerCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CustRateGrpCodeForPrint, typeof(string));
                dt.Columns[Col_CustRateGrpCodeForPrint].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCdForPrint, typeof(string));
                dt.Columns[Col_SupplierCdForPrint].DefaultValue = defValuestring;

            }
        }
    }
}
