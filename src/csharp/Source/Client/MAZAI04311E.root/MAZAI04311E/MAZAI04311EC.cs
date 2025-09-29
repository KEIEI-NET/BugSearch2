using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 在庫受払照会テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫受払照会テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.12.03</br>
    /// <br></br>
    /// <br>Update Note: 2008/07/17 照田 貴志</br>
    /// <br>             PM.NS用に変更。</br>
    /// <br>Update Note: 2008/09/29 照田 貴志</br>
    /// <br>             仕様変更対応。</br>
    /// <br>           : 2008/12/09 照田 貴志</br>
    /// <br>             バグ修正、仕様変更対応</br>
    /// <br>           : 2010/11/15 李占川</br>
    /// <br>             明細の表示順が受払作成日時の昇順になっていない障害の修正</br>
    /// <br>           : </br>
    /// </remarks>
    public class MAZAI04311EC
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockAcPayRef = "Tbl_StockAcPayRef";

        /// <summary> 行番号 </summary>
        public const string ct_Col_RowNo = "RowNo";
        /// <summary> 入出荷日 </summary>
        public const string ct_Col_IoGoodsDay = "IoGoodsDay";
        /// <summary> 受払元伝票区分 </summary>
        public const string ct_Col_AcPaySlipCd = "AcPaySlipCd";
        /// <summary> 受払元伝票番号 </summary>
        public const string ct_Col_AcPaySlipNum = "AcPaySlipNum";
        /// <summary> 受払元行番号 </summary>
        public const string ct_Col_AcPaySlipRowNo = "AcPaySlipRowNo";
        /// <summary> 受払履歴作成日時 </summary>
        public const string ct_Col_AcPayHistDateTime = "AcPayHistDateTime";
        /// <summary> 受払元取引区分 </summary>
        public const string ct_Col_AcPayTransCd = "AcPayTransCd";
        /// <summary> 入力担当者コード </summary>
        public const string ct_Col_InputAgenCd = "InputAgenCd";
        /// <summary> 入力担当者名称 </summary>
        public const string ct_Col_InputAgenNm = "InputAgenNm";
        /// <summary> 相手先伝票番号 </summary>
        public const string ct_Col_CustSlipNo = "CustSlipNo";
        /// <summary> 明細通番 </summary>
        public const string ct_Col_SlipDtlNum = "SlipDtlNum";
        /// <summary> 受払備考 </summary>
        public const string ct_Col_AcPayNote = "AcPayNote";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド名称 </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 棚番 </summary>
        public const string ct_Col_ShelfNo = "ShelfNo";
        /// <summary> 入荷数 </summary>
        public const string ct_Col_ArrivalCnt = "ArrivalCnt";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 定価（税抜，浮動） </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> 仕入単価（税抜，浮動） </summary>
        public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 仕入金額 </summary>
        public const string ct_Col_StockPrice = "StockPrice";
        /// <summary> 仕入在庫数 </summary>
        public const string ct_Col_SupplierStock = "SupplierStock";
        /// <summary> 受注数 </summary>
        public const string ct_Col_AcpOdrCount = "AcpOdrCount";
        /// <summary> 発注数 </summary>
        public const string ct_Col_SalesOrderCount = "SalesOrderCount";
        /// <summary> 移動中仕入在庫数 </summary>
        public const string ct_Col_MovingSupliStock = "MovingSupliStock";
        /// <summary> 出荷数（未計上） </summary>
        public const string ct_Col_NonAddUpShipmCnt = "NonAddUpShipmCnt";
        /// <summary> 入荷数（未計上） </summary>
        public const string ct_Col_NonAddUpArrGdsCnt = "NonAddUpArrGdsCnt";
        /// <summary> 出荷可能数 </summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";
        /// <summary> 受払先名称 </summary>
        public const string ct_Col_AcPayOtherPartyNm = "AcPayOtherPartyNm";
        /// <summary> 受払元伝票区分名称 </summary>
        public const string ct_Col_AcPaySlipNm = "AcPaySlipNm";
        /// <summary> 受払元取引区分名称 </summary>
        public const string ct_Col_AcPayTransNm = "AcPayTransNm";
        /// <summary> 入庫金額 </summary>
        public const string ct_Col_ArrivalPrice = "ArrivalPrice";
        /// <summary> 出庫金額 </summary>
        public const string ct_Col_ShipmentPrice = "ShipmentPrice";
        /// <summary> 繰越数 </summary>
        public const string ct_Col_CarryForwardCnt = "CarryForwardCnt";         // ADD 2008/07/17 T.Shouda
        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";   // ADD 2008/09/29 T.Shouda
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";                         // ADD 2008/12/09 不具合対応[8895]
        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 在庫受払照会テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫受払照会テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        public MAZAI04311EC ()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ テーブルスキーマ設定
        /// <summary>
        /// DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        static public void CreateDataTable ( ref DataTable dt )
        {
            // テーブルが存在するかどうかのチェック
            if ( dt != null )
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable( ct_Tbl_StockAcPayRef );

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;

                # region <Column追加>

                // 行番号
                dt.Columns.Add( ct_Col_RowNo, typeof( Int32 ) );
                dt.Columns[ct_Col_RowNo].DefaultValue = defaultValueOfInt32;

                // 入出荷日
                dt.Columns.Add( ct_Col_IoGoodsDay, typeof( DateTime ) );
                dt.Columns[ct_Col_IoGoodsDay].DefaultValue = defaultValueOfDateTime;

                // 受払元伝票区分
                dt.Columns.Add( ct_Col_AcPaySlipCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipCd].DefaultValue = defaultValueOfInt32;

                // 受払元伝票番号
                dt.Columns.Add( ct_Col_AcPaySlipNum, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNum].DefaultValue = defaultValueOfstring;

                // 受払元行番号
                dt.Columns.Add( ct_Col_AcPaySlipRowNo, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPaySlipRowNo].DefaultValue = defaultValueOfInt32;

                // 受払履歴作成日時
                // --- UPD 2010/11/15 ---------->>>>>
                //dt.Columns.Add( ct_Col_AcPayHistDateTime, typeof( string ) );
                //dt.Columns[ct_Col_AcPayHistDateTime].DefaultValue = defaultValueOfstring;
                dt.Columns.Add(ct_Col_AcPayHistDateTime, typeof(DateTime));
                dt.Columns[ct_Col_AcPayHistDateTime].DefaultValue = defaultValueOfDateTime;
                // --- UPD 2010/11/15  ----------<<<<<

                // 受払元取引区分
                dt.Columns.Add( ct_Col_AcPayTransCd, typeof( Int32 ) );
                dt.Columns[ct_Col_AcPayTransCd].DefaultValue = defaultValueOfInt32;

                // 入力担当者コード
                dt.Columns.Add( ct_Col_InputAgenCd, typeof( string ) );
                dt.Columns[ct_Col_InputAgenCd].DefaultValue = defaultValueOfstring;

                // 入力担当者名称
                dt.Columns.Add( ct_Col_InputAgenNm, typeof( string ) );
                dt.Columns[ct_Col_InputAgenNm].DefaultValue = defaultValueOfstring;

                // 相手先伝票番号
                dt.Columns.Add( ct_Col_CustSlipNo, typeof( string ) );
                dt.Columns[ct_Col_CustSlipNo].DefaultValue = defaultValueOfstring;

                // 明細通番
                dt.Columns.Add( ct_Col_SlipDtlNum, typeof( Int64 ) );
                dt.Columns[ct_Col_SlipDtlNum].DefaultValue = defaultValueOfInt64;

                // 受払備考
                dt.Columns.Add( ct_Col_AcPayNote, typeof( string ) );
                dt.Columns[ct_Col_AcPayNote].DefaultValue = defaultValueOfstring;

                // 拠点コード
                dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
                dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;

                // 拠点ガイド名称
                dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = defaultValueOfstring;

                // 倉庫コード
                dt.Columns.Add( ct_Col_WarehouseCode, typeof( string ) );
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defaultValueOfstring;

                // 倉庫名称
                dt.Columns.Add( ct_Col_WarehouseName, typeof( string ) );
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defaultValueOfstring;

                // 棚番
                dt.Columns.Add( ct_Col_ShelfNo, typeof( string ) );
                dt.Columns[ct_Col_ShelfNo].DefaultValue = defaultValueOfstring;

                /* ---DEL 2008/09/29 仕様変更 --------------------------------------->>>>>
                // 入荷数
                dt.Columns.Add( ct_Col_ArrivalCnt, typeof( Double ) );
                dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfDouble;

                // 出荷数
                dt.Columns.Add( ct_Col_ShipmentCnt, typeof( Double ) );
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfDouble;
                   ---DEL 2008/09/29 ------------------------------------------------<<<<< */
                // ---ADD 2008/09/29 ------------------------------------------------>>>>>
                // 入荷数
                dt.Columns.Add(ct_Col_ArrivalCnt, typeof(string));
                dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defaultValueOfstring;

                // 出荷数
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(string));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfstring;
                // ---ADD 2008/09/29 ------------------------------------------------<<<<<

                // 定価（税抜，浮動）
                dt.Columns.Add( ct_Col_ListPriceTaxExcFl, typeof( Double ) );
                dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defaultValueOfDouble;

                // 仕入単価（税抜，浮動）
                dt.Columns.Add( ct_Col_StockUnitPriceFl, typeof( Double ) );
                dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defaultValueOfDouble;

                // 仕入金額
                dt.Columns.Add( ct_Col_StockPrice, typeof( Int64 ) );
                dt.Columns[ct_Col_StockPrice].DefaultValue = defaultValueOfInt64;

                // 仕入在庫数
                dt.Columns.Add( ct_Col_SupplierStock, typeof( Double ) );
                dt.Columns[ct_Col_SupplierStock].DefaultValue = defaultValueOfDouble;

                // 受注数
                dt.Columns.Add( ct_Col_AcpOdrCount, typeof( Double ) );
                dt.Columns[ct_Col_AcpOdrCount].DefaultValue = defaultValueOfDouble;

                // 発注数
                dt.Columns.Add( ct_Col_SalesOrderCount, typeof( Double ) );
                dt.Columns[ct_Col_SalesOrderCount].DefaultValue = defaultValueOfDouble;

                // 移動中仕入在庫数
                dt.Columns.Add( ct_Col_MovingSupliStock, typeof( Double ) );
                dt.Columns[ct_Col_MovingSupliStock].DefaultValue = defaultValueOfDouble;

                // 出荷数（未計上）
                dt.Columns.Add( ct_Col_NonAddUpShipmCnt, typeof( Double ) );
                dt.Columns[ct_Col_NonAddUpShipmCnt].DefaultValue = defaultValueOfDouble;

                // 入荷数（未計上）
                dt.Columns.Add( ct_Col_NonAddUpArrGdsCnt, typeof( Double ) );
                dt.Columns[ct_Col_NonAddUpArrGdsCnt].DefaultValue = defaultValueOfDouble;

                // 出荷可能数
                dt.Columns.Add( ct_Col_ShipmentPosCnt, typeof( Double ) );
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = defaultValueOfDouble;

                // 受払先名称
                dt.Columns.Add( ct_Col_AcPayOtherPartyNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayOtherPartyNm].DefaultValue = defaultValueOfstring;

                // 受払元伝票区分名称
                dt.Columns.Add( ct_Col_AcPaySlipNm, typeof( string ) );
                dt.Columns[ct_Col_AcPaySlipNm].DefaultValue = defaultValueOfstring;

                // 受払元取引区分名称
                dt.Columns.Add( ct_Col_AcPayTransNm, typeof( string ) );
                dt.Columns[ct_Col_AcPayTransNm].DefaultValue = defaultValueOfstring;

                // 入庫金額
                dt.Columns.Add( ct_Col_ArrivalPrice, typeof( string ) );
                dt.Columns[ct_Col_ArrivalPrice].DefaultValue = defaultValueOfstring;

                // 出庫金額
                dt.Columns.Add( ct_Col_ShipmentPrice, typeof( string ) );
                dt.Columns[ct_Col_ShipmentPrice].DefaultValue = defaultValueOfstring;

                // 繰越数
                dt.Columns.Add(ct_Col_CarryForwardCnt, typeof(Double));                         // ADD 2008/07/17 T.Shouda
                dt.Columns[ct_Col_CarryForwardCnt].DefaultValue = defaultValueOfDouble;         // ADD 2008/07/17 T.Shouda

                // 売上単価（税抜，浮動）
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));                      // ADD 2008/09/29 T.Shouda
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defaultValueOfDouble;      // ADD 2008/09/29 T.Shouda

                // 品番
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));                                 // ADD 2008/12/09 不具合対応[8895]
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;                 // ADD 2008/12/09 不具合対応[8895]

                # endregion
            }
        }
        #endregion
        #endregion
    }
}
