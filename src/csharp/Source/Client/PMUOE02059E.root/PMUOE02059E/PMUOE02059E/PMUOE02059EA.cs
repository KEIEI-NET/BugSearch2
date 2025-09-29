using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 復旧データ一覧表 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 復旧データ一覧表のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMUOE02059EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_RecoveryDataOrder = "ct_Tbl_RecoveryDataOrder";

        // 拠点コード
        public const string ct_Col_SectionCode = "SectionCode";
        // 拠点ガイド略称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        // UOE発注先コード
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        // UOE発注先名称
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        // オンライン番号
        public const string ct_Col_OnlineNo = "OnlineNo";
        // 商品番号
        public const string ct_Col_GoodsNo = "GoodsNo";
        // 商品名称
        public const string ct_Col_GoodsName = "GoodsName";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        // 受注数量
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        // BO区分
        public const string ct_Col_BoCode = "BoCode";
        // ＵＯＥリマーク１
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        // データ送信区分
        public const string ct_Col_DataSendCode = "DataSendCode";
        // オンライン行番号
        public const string ct_Col_OnlineRowNo = "OnlineRowNo";
        // システム区分
        public const string ct_Col_SystemDivCd = "SystemDivCd";

        // リモート抽出結果以外の項目
        // 抽出条件
        public const string ct_Col_ExtractCondition = "ExtractCondition";
        // システム区分名称
        public const string ct_Col_SystemDivName = "SystemDivName";
        // エラー内容(データ送信区分名称)
        public const string ct_Col_DataSendName = "DataSendName";

        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMUOE02059EA()
        {
        }

        #endregion

        #region ■ publicメソッド
        /// <summary>
        /// 復旧データ一覧表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 復旧データ一覧表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        static public void CreateDataTable(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable(ct_Tbl_RecoveryDataOrder);

                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // UOE発注先コード
                dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
                dt.Columns[ct_Col_UOESupplierCd].DefaultValue = 0;

                // UOE発注先名称
                dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
                dt.Columns[ct_Col_UOESupplierName].DefaultValue = string.Empty;

                // オンライン番号
                dt.Columns.Add(ct_Col_OnlineNo, typeof(Int32));
                dt.Columns[ct_Col_OnlineNo].DefaultValue = 0;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                // 商品名称
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = string.Empty;

                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                // 受注数量
                dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(double));
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = 0;

                // BO区分
                dt.Columns.Add(ct_Col_BoCode, typeof(string));
                dt.Columns[ct_Col_BoCode].DefaultValue = string.Empty;

                // ＵＯＥリマーク１
                dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
                dt.Columns[ct_Col_UoeRemark1].DefaultValue = string.Empty;

                // データ送信区分
                dt.Columns.Add(ct_Col_DataSendCode, typeof(Int32));
                dt.Columns[ct_Col_DataSendCode].DefaultValue = 0;

                // オンライン行番号
                dt.Columns.Add(ct_Col_OnlineRowNo, typeof(Int32));
                dt.Columns[ct_Col_OnlineRowNo].DefaultValue = 0;

                // システム区分
                dt.Columns.Add(ct_Col_SystemDivCd, typeof(Int32));
                dt.Columns[ct_Col_SystemDivCd].DefaultValue = 0;

                // 抽出条件
                dt.Columns.Add(ct_Col_ExtractCondition, typeof(string));
                dt.Columns[ct_Col_ExtractCondition].DefaultValue = string.Empty;
                
                // システム区分名称
                dt.Columns.Add(ct_Col_SystemDivName, typeof(string));
                dt.Columns[ct_Col_SystemDivName].DefaultValue = string.Empty;
                
                // エラー内容(データ送信区分名称)
                dt.Columns.Add(ct_Col_DataSendName, typeof(string));
                dt.Columns[ct_Col_DataSendName].DefaultValue = string.Empty;
            }
        }
        #endregion
    }
}
