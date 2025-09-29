using System;
using System.Data;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// UOE回答　データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE回答表示に関するテーブルスキーマ/グリッドデータの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/10</br>
    /// <br>             2008/12/10 照田 貴志　BO区分の型Int32→String変更</br>
    /// </remarks>
    public class PMUOE04202EA
    {
        #region ■Public定数
        /// <summary> テーブル名称(明細情報) </summary>
        public const string ct_Tbl_UOEReply = "Tbl_UOEReply";

        // 明細情報(グリッド用)
        /// <summary> No </summary>
        public const string ct_Col_No = "No";
        /// <summary> 選択 </summary>
        public const string ct_Col_SelectFlg = "SelectFlg";
        /// <summary> 受信日時 </summary>
        public const string ct_Col_ReceiveDate = "ReceiveDate";
        /// <summary> 受信時刻 </summary>
        public const string ct_Col_ReceiveTime = "ReceiveTime";
        /// <summary> 発注回答番号 </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> 発注回答行番号 </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> 発注先コード </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> 発注先名称 </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOE納品区分 </summary>
        public const string ct_Col_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";
        /// <summary> フォロー納品区分 </summary>
        public const string ct_Col_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";
        /// <summary> BO区分 </summary>
        public const string ct_Col_BOCode = "BOCode";
        /// <summary> 依頼者コード </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> 依頼者名称 </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> メーカー </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> リマーク1 </summary>
        public const string ct_Col_UOERemark1 = "UOERemark1";
        /// <summary> リマーク2 </summary>
        public const string ct_Col_UOERemark2 = "UOERemark2";
        /// <summary> 発注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 拠点出庫数 </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> 拠点伝票番号 </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> フォロー1 </summary>
        public const string ct_Col_BOShipmentCnt1 = "BOShipmentCnt1";
        /// <summary> フォロー伝票番号1 </summary>
        public const string ct_Col_BOSlipNo1 = "BOSlipNo1";
        /// <summary> フォロー2 </summary>
        public const string ct_Col_BOShipmentCnt2 = "BOShipmentCnt2";
        /// <summary> フォロー伝票番号2 </summary>
        public const string ct_Col_BOSlipNo2 = "BOSlipNo2";
        /// <summary> フォロー3 </summary>
        public const string ct_Col_BOShipmentCnt3 = "BOShipmentCnt3";
        /// <summary> フォロー伝票番号3 </summary>
        public const string ct_Col_BOSlipNo3 = "BOSlipNo3";
        /// <summary> メーカーフォロー数 </summary>
        public const string ct_Col_MakerFollowCnt = "MakerFollowCnt";
        /// <summary> 定価 </summary>
        public const string ct_Col_ListPrice = "ListPrice";
        /// <summary> 仕切単価 </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> 代替区分 </summary>
        public const string ct_Col_UOESubstMark = "UOESubstMark";
        /// <summary> 層別(日産) </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> EO管理番号(日産) </summary>
        public const string ct_Col_BOManagementNo = "BOManagementNo";
        /// <summary> EO発注数(日産) </summary>
        public const string ct_Col_EOAlwcCount = "EOAlwcCount";
        /// <summary> 拠点コード(ﾏﾂﾀﾞ) </summary>
        public const string ct_Col_MazdaUOEShipSectCd1 = "MazdaUOEShipSectCd1";
        /// <summary> フォローコード1(ﾏﾂﾀﾞ) </summary>
        public const string ct_Col_MazdaUOEShipSectCd2 = "MazdaUOEShipSectCd2";
        /// <summary> フォローコード2(ﾏﾂﾀﾞ) </summary>
        public const string ct_Col_MazdaUOEShipSectCd3 = "MazdaUOEShipSectCd3";
        /// <summary> エラーメッセージ </summary>
        public const string ct_Col_LineErrorMessage = "LineErrorMessage";
        /// <summary> 出荷元コード(ﾎﾝﾀﾞ) </summary>
        public const string ct_Col_SourceShipment = "SourceShipment";
        /// <summary> 拠点コード(※帳票用項目) </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点名称(※帳票用項目) </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> 表示文字色 </summary>
        public const string ct_Col_ForeColor = "ForeColor";
        #endregion

        #region ■ Constructor
        /// <summary>
        /// 回答グリッド用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 回答情報テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04202EA()
        {
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// DataSetテーブルスキーマ設定(明細単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
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

            dt = new DataTable(ct_Tbl_UOEReply);

            string defaultValueOfstring = string.Empty;
            double defaultValueOfDouble = 0;
            Int32 defaultValueOfInt32 = 0;
            bool defaultValueOfBool = false;

            #region カラム設定
            // No
            dt.Columns.Add(ct_Col_No, typeof(Int32));
            dt.Columns[ct_Col_No].DefaultValue = defaultValueOfInt32;
            // 選択
            dt.Columns.Add(ct_Col_SelectFlg, typeof(bool));
            dt.Columns[ct_Col_SelectFlg].DefaultValue = defaultValueOfBool;
            // 受信日時
            dt.Columns.Add(ct_Col_ReceiveDate, typeof(string));
            dt.Columns[ct_Col_ReceiveDate].DefaultValue = defaultValueOfstring;
            // 受信時刻
            dt.Columns.Add(ct_Col_ReceiveTime, typeof(string));
            dt.Columns[ct_Col_ReceiveTime].DefaultValue = defaultValueOfstring;
            // 発注回答番号
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(string));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defaultValueOfstring;
            // 発注回答行番号
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // 発注先コード
            dt.Columns.Add(ct_Col_UOESupplierCd, typeof(string));
            dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defaultValueOfstring;
            // 発注先名称
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;
            // UOE納品区分
            dt.Columns.Add(ct_Col_UOEDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_UOEDeliGoodsDiv].DefaultValue = defaultValueOfstring;
            // フォロー納品区分
            dt.Columns.Add(ct_Col_FollowDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDiv].DefaultValue = defaultValueOfstring;
            // BO区分
            /* ---DEL 2008/12/10 型変更--------------------------------->>>>>
            //dt.Columns.Add(ct_Col_BOCode, typeof(Int32));
            //dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfInt32;
               ---DEL 2008/12/10 型変更---------------------------------<<<<< */
            // ---ADD 2008/12/10 --------------------------------------->>>>>
            dt.Columns.Add(ct_Col_BOCode, typeof(string));
            dt.Columns[ct_Col_BOCode].DefaultValue = defaultValueOfstring;
            // ---ADD 2008/12/10 ---------------------------------------<<<<<
            // 依頼者コード
            dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
            dt.Columns[ct_Col_EmployeeCode].DefaultValue = defaultValueOfstring;
            // 依頼者名称
            dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = defaultValueOfstring;
            // 得意先コード
            dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfstring;
            // 得意先名称
            dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
            dt.Columns[ct_Col_CustomerSnm].DefaultValue = defaultValueOfstring;
            // 品番
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // メーカー
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // 品名
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
            // リマーク1
            dt.Columns.Add(ct_Col_UOERemark1, typeof(string));
            dt.Columns[ct_Col_UOERemark1].DefaultValue = defaultValueOfstring;
            // リマーク2
            dt.Columns.Add(ct_Col_UOERemark2, typeof(string));
            dt.Columns[ct_Col_UOERemark2].DefaultValue = defaultValueOfstring;
            // 発注数量
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;
            // 拠点出庫数
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfInt32;
            // 拠点伝票番号
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defaultValueOfstring;
            // フォロー1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defaultValueOfInt32;
            // フォロー伝票番号1
            dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));
            dt.Columns[ct_Col_BOSlipNo1].DefaultValue = defaultValueOfstring;
            // フォロー2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defaultValueOfInt32;
            // フォロー伝票番号2
            dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));
            dt.Columns[ct_Col_BOSlipNo2].DefaultValue = defaultValueOfstring;
            // フォロー3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defaultValueOfInt32;
            // フォロー伝票番号3
            dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));
            dt.Columns[ct_Col_BOSlipNo3].DefaultValue = defaultValueOfstring;
            // メーカーフォロー数
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(Int32));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defaultValueOfInt32;
            // 定価
            dt.Columns.Add(ct_Col_ListPrice, typeof(Double));
            dt.Columns[ct_Col_ListPrice].DefaultValue = defaultValueOfDouble;
            // 仕切単価
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defaultValueOfDouble;
            // 代替区分
            dt.Columns.Add(ct_Col_UOESubstMark, typeof(string));
            dt.Columns[ct_Col_UOESubstMark].DefaultValue = defaultValueOfstring;
            // 層別(日産)
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defaultValueOfstring;
            // EO管理番号(日産)
            dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));
            dt.Columns[ct_Col_BOManagementNo].DefaultValue = defaultValueOfstring;
            // EO発注数(日産)
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(Int32));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defaultValueOfInt32;
            // 拠点コード(マツダ)
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd1, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd1].DefaultValue = defaultValueOfstring;
            // フォローコード1(マツダ)
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd2, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd2].DefaultValue = defaultValueOfstring;
            // フォローコード2(マツダ)
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd3, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd3].DefaultValue = defaultValueOfstring;
            // エラーメッセージ
            dt.Columns.Add(ct_Col_LineErrorMessage, typeof(string));
            dt.Columns[ct_Col_LineErrorMessage].DefaultValue = defaultValueOfstring;
            // 出荷元コード(ホンダ)
            dt.Columns.Add(ct_Col_SourceShipment, typeof(string));
            dt.Columns[ct_Col_SourceShipment].DefaultValue = defaultValueOfstring;
            // 拠点コード(※帳票用項目)
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 拠点名称(※帳票用項目)
            dt.Columns.Add(ct_Col_SectionName, typeof(string));
            dt.Columns[ct_Col_SectionName].DefaultValue = defaultValueOfstring;
            // 表示文字色
            dt.Columns.Add(ct_Col_ForeColor, typeof(string));
            dt.Columns[ct_Col_ForeColor].DefaultValue = defaultValueOfstring;
            #endregion

            // 主キー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_No]};
        }
        #endregion
    }
}
