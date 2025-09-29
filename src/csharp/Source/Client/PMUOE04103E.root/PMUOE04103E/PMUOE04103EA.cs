using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 発注回答情報テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注回答情報テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/06</br>
    /// <br>UpdateNote : 2008/12/18 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>             ①ホンダの表示方法変更</br>
    /// <br></br>
    /// <br>UpdateNote : 2012/07/13 30517 夏野 駿希</br>
    /// <br>             仕入原価を小数点以下表示可能に修正</br>
    /// </remarks>
    public class PMUOE04103EA
    {
        #region ■Public定数
        /// <summary> テーブル名称(発注先単位) </summary>
        public const string ct_Tbl_OrderAnsSupplier = "Tbl_OrderAnsSupplier";
        /// <summary> テーブル名称(明細単位) </summary>
        public const string ct_Tbl_OrderAnsDetail = "Tbl_OrderAnsDetail";
        /// <summary> 明細のグループ名称 </summary>
        public const string ct_Grp_OrderAnsDeltail = "Grp_OrderAnsDetail";

        // 発注先(明細以外)情報
        /// <summary> 発注日 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> 発注番号 </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> UOE発注先名称 </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOEリマーク1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOEリマーク2 </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> 納品区分名称 </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> フォロー納品区分名称 </summary>
        public const string ct_Col_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";
        /// <summary> 拠点 </summary>
        public const string ct_Col_UOEResvdSectionNm = "UOEResvdSectionNm";
        /// <summary> 依頼者 </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> グリッドヘッダー可変名称1 </summary>
        public const string ct_Col_GridHeadVariableName1 = "GridHeadVariableName1";
        /// <summary> グリッドヘッダー可変名称2 </summary>
        public const string ct_Col_GridHeadVariableName2 = "GridHeadVariableName2";
        /// <summary> グリッドヘッダー可変名称3 </summary>
        public const string ct_Col_GridHeadVariableName3 = "GridHeadVariableName3";
        /// <summary> グリッドヘッダー可変名称4 </summary>
        public const string ct_Col_GridHeadVariableName4 = "GridHeadVariableName4";
        /// <summary> グリッドヘッダー可変名称5 </summary>
        public const string ct_Col_GridHeadVariableName5 = "GridHeadVariableName5";
        /// <summary> グリッドヘッダー可変名称6 </summary>
        public const string ct_Col_GridHeadVariableName6 = "GridHeadVariableName6";
        /// <summary> グリッドヘッダー出荷数名称1(可変名称1に対応) </summary>
        public const string ct_Col_GridHeadShipmentCntName1 = "GridHeadShipmentCntName1";
        /// <summary> グリッドヘッダー出荷数名称2(可変名称2に対応) </summary>
        public const string ct_Col_GridHeadShipmentCntName2 = "GridHeadShipmentCntName2";
        /// <summary> グリッドヘッダー出荷数名称3(可変名称3に対応) </summary>
        public const string ct_Col_GridHeadShipmentCntName3 = "GridHeadShipmentCntName3";
        /// <summary> グリッドヘッダー出荷数名称4(可変名称4に対応) </summary>
        public const string ct_Col_GridHeadShipmentCntName4 = "GridHeadShipmentCntName4";
        /// <summary> グリッドヘッダー出荷数名称5(可変名称5に対応) </summary>
        public const string ct_Col_GridHeadShipmentCntName5 = "GridHeadShipmentCntName5";
        /// <summary> システム区分名称 </summary>
        public const string ct_Col_SystemDivName = "SystemDivName";

        // 明細情報(グリッド用)
        /// <summary> UOE発注行番号 </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> 代替品番 </summary>
        public const string ct_Col_SubstPartsNo = "SubstPartsNo";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> メーカー </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> 空白1 </summary>
        public const string ct_Col_Blank1 = "Blank1";
        /// <summary> 定価 </summary>
        public const string ct_Col_ListPrice = "ListPrice";
        /// <summary> 拠点伝票 </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> BO伝票1 </summary>
        public const string ct_Col_BOSlipNo1 = "BOSlipNo1";
        /// <summary> BO伝票2 </summary>
        public const string ct_Col_BOSlipNo2 = "BOSlipNo2";
        /// <summary> BO伝票3 </summary>
        public const string ct_Col_BOSlipNo3 = "BOSlipNo3";
        /// <summary> BO管理番号 </summary>
        public const string ct_Col_BOManagementNo = "BOBOManagementNoNo";
        /// <summary> 空白2 </summary>
        public const string ct_Col_Blank2 = "Blank2";
        /// <summary> 代替 </summary>
        public const string ct_Col_UOESubstMark = "UOESubstMark";
        /// <summary> コメント項目 </summary>
        public const string ct_Col_Comment = "Comment";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> BO区分 </summary>
        public const string ct_Col_BOCode = "BOCode";
        /// <summary> 原価単価 </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> UOE拠点出庫数 </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> BO出庫数1 </summary>
        public const string ct_Col_BOShipmentCnt1 = "BOShipmentCnt1";
        /// <summary> BO出庫数2 </summary>
        public const string ct_Col_BOShipmentCnt2 = "BOShipmentCnt2";
        /// <summary> BO出庫数3 </summary>
        public const string ct_Col_BOShipmentCnt3 = "BOShipmentCnt3";
        /// <summary> EO引当数 </summary>
        public const string ct_Col_EOAlwcCount = "EOAlwcCount";
        /// <summary> メーカーフォロー数 </summary>
        public const string ct_Col_MakerFollowCnt = "MakerFollowCnt";
        /// <summary> 残 </summary>
        public const string ct_Col_RemainderCount = "RemainderCount";
        /// <summary> 倉庫・棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 前景色 </summary>
        public const string ct_Col_ForeColor = "ForeColor";
        #endregion

        #region ■ Constructor
        /// <summary>
        /// 発注回答グリッド用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注回答情報テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        public PMUOE04103EA()
        {
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// DataSetテーブルスキーマ設定(発注先単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        static public void CreateDataTableSupplier(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーのみ行う。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_OrderAnsSupplier);

            string defaultValueOfstring = string.Empty;

            // 発注日
            dt.Columns.Add(ct_Col_SalesDate, typeof(string));
            dt.Columns[ct_Col_SalesDate].DefaultValue = defaultValueOfstring;
            // 発注番号
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(string));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defaultValueOfstring;
            // UOE発注先名称
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;
            // UOEリマーク1
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defaultValueOfstring;
            // UOEリマーク2
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defaultValueOfstring;
            // 納品区分名称
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defaultValueOfstring;
            // フォロー納品区分名称
            dt.Columns.Add(ct_Col_FollowDeliGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDivNm].DefaultValue = defaultValueOfstring;
            // 拠点
            dt.Columns.Add(ct_Col_UOEResvdSectionNm, typeof(string));
            dt.Columns[ct_Col_UOEResvdSectionNm].DefaultValue = defaultValueOfstring;
            // 依頼者
            dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー可変名称1
            dt.Columns.Add(ct_Col_GridHeadVariableName1, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName1].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー可変名称2
            dt.Columns.Add(ct_Col_GridHeadVariableName2, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName2].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー可変名称3
            dt.Columns.Add(ct_Col_GridHeadVariableName3, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName3].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー可変名称4
            dt.Columns.Add(ct_Col_GridHeadVariableName4, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName4].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー可変名称5
            dt.Columns.Add(ct_Col_GridHeadVariableName5, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName5].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー可変名称6
            dt.Columns.Add(ct_Col_GridHeadVariableName6, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName6].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー出荷数名称1
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName1, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName1].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー出荷数名称2
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName2, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName2].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー出荷数名称3
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName3, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName3].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー出荷数名称4
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName4, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName4].DefaultValue = defaultValueOfstring;
            // グリッドヘッダー出荷数名称5
            dt.Columns.Add(ct_Col_GridHeadShipmentCntName5, typeof(string));
            dt.Columns[ct_Col_GridHeadShipmentCntName5].DefaultValue = defaultValueOfstring;
            // システム区分名称
            dt.Columns.Add(ct_Col_SystemDivName, typeof(string));
            dt.Columns[ct_Col_SystemDivName].DefaultValue = defaultValueOfstring;
        }

        /// <summary>
        /// DataSetテーブルスキーマ設定(明細単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        static public void CreateDataTableDetail(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーのみ行う。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_OrderAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Int64 defaultValueOfInt64 = 0;

            // 発注行番号
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // 代替品番
            dt.Columns.Add(ct_Col_SubstPartsNo, typeof(string));
            dt.Columns[ct_Col_SubstPartsNo].DefaultValue = defaultValueOfstring;
            // 品番
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // メーカー
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // 空白1
            dt.Columns.Add(ct_Col_Blank1, typeof(string));
            dt.Columns[ct_Col_Blank1].DefaultValue = defaultValueOfstring;
            // 定価
            dt.Columns.Add(ct_Col_ListPrice, typeof(Int64));
            dt.Columns[ct_Col_ListPrice].DefaultValue = defaultValueOfInt64;
            // 拠点伝票
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defaultValueOfstring;
            // BO伝票1
            dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));
            dt.Columns[ct_Col_BOSlipNo1].DefaultValue = defaultValueOfstring;
            // BO伝票2
            dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));
            dt.Columns[ct_Col_BOSlipNo2].DefaultValue = defaultValueOfstring;
            // BO伝票3
            dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));
            dt.Columns[ct_Col_BOSlipNo3].DefaultValue = defaultValueOfstring;
            // BO管理番号
            dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));
            dt.Columns[ct_Col_BOManagementNo].DefaultValue = defaultValueOfstring;
            // 空白2
            dt.Columns.Add(ct_Col_Blank2, typeof(string));
            dt.Columns[ct_Col_Blank2].DefaultValue = defaultValueOfstring;
            // 代替
            dt.Columns.Add(ct_Col_UOESubstMark, typeof(string));
            dt.Columns[ct_Col_UOESubstMark].DefaultValue = defaultValueOfstring;
            // コメント
            dt.Columns.Add(ct_Col_Comment, typeof(string));
            dt.Columns[ct_Col_Comment].DefaultValue = defaultValueOfstring;
            // 品名
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
            // 数量
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Int64));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfInt64;
            // BO区分
            dt.Columns.Add(ct_Col_BOCode, typeof(string));
            dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfstring;
            // 原価単価
            // upd 2012/07/13 >>>
            //dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Int64));
            //dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defaultValueOfInt64;
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = 0.0;
            // upd 2012/07/13 <<<
            /* --- DEL 2008/12/18 ① --------------------------------------------------->>>>>
            // UOE拠点出庫数
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int64));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfInt64;
            // BO出庫数1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(Int64));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defaultValueOfInt64;
            // BO出庫数2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(Int64));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defaultValueOfInt64;
            // BO出庫数3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(Int64));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defaultValueOfInt64;
            // EO引当数
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(Int64));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defaultValueOfInt64;
            // メーカーフォロー数
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(Int64));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defaultValueOfInt64;
            // 残
            dt.Columns.Add(ct_Col_RemainderCount, typeof(Int64));
            dt.Columns[ct_Col_RemainderCount].DefaultValue = defaultValueOfInt64;
               --- DEL 2008/12/18 ① ---------------------------------------------------<<<<< */
            // --- DEL 2008/12/18 ① --------------------------------------------------->>>>> 
            // UOE拠点出庫数
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(string));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfstring;
            // BO出庫数1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(string));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defaultValueOfstring;
            // BO出庫数2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(string));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defaultValueOfstring;
            // BO出庫数3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(string));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defaultValueOfstring;
            // EO引当数
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(string));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defaultValueOfstring;
            // メーカーフォロー数
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(string));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defaultValueOfstring;
            // 残
            dt.Columns.Add(ct_Col_RemainderCount, typeof(string));
            dt.Columns[ct_Col_RemainderCount].DefaultValue = defaultValueOfstring;
            // --- DEL 2008/12/18 ① ---------------------------------------------------<<<<<
            // 倉庫・棚番
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defaultValueOfstring;
            // 前景色
            dt.Columns.Add(ct_Col_ForeColor, typeof(string));
            dt.Columns[ct_Col_ForeColor].DefaultValue = defaultValueOfstring;
        }
        #endregion
    }
}
