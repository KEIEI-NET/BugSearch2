//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷実績表
// プログラム概要   : 型式別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhshh
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ModelShipRsltListCndtn
    /// <summary>
    ///                      型式別出荷実績表抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   型式別出荷実績表抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ModelShipRsltListCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>選択拠点コード</summary>
        private string[] _sectionCodeList;

        /// <summary>集計方法</summary>
        /// <remarks>0:全社 1:拠点毎</remarks>
        private GroupBySectionDivState _groupBySectionDiv;

        /// <summary>売上日(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateSt;

        /// <summary>売上日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateEd;

        /// <summary>入力日(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDateSt;

        /// <summary>入力日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDateEd;
        
        /// <summary>在庫取寄せ区分</summary>
        /// <remarks>0:全て 1:在庫, 2:取寄せ</remarks>
        private RsltTtlDivState _rsltTtlDiv;

        /// <summary>改頁</summary>
        /// <remarks>0:しない 1:拠点 2:型式</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>車種メーカーコード（開始）</summary>
        private Int32 _carMakerCodeSt;

        /// <summary>車種メーカーコード（終了）</summary>
        private Int32 _carMakerCodeEd;

        /// <summary>車種コード（開始）</summary>
        private Int32 _carModelCodeSt;

        /// <summary>車種コード（終了）</summary>
        private Int32 _carModelCodeEd;

        /// <summary>車種サブコード（開始）</summary>
        private Int32 _carModelSubCodeSt;

        /// <summary>車種サブコード（終了）</summary>
        private Int32 _carModelSubCodeEd;

        /// <summary>代表型式</summary>
        private string _modelName;

        /// <summary>代表型式抽出区分</summary>
        /// <remarks>0:と一致 1:で始まる 2:を含む 3:で終わる </remarks>
        private ModelOutDivState _modelOutDiv;

        /// <summary>メーカー開始</summary>
        private Int32 _makerCodeSt;

        /// <summary>メーカー終了</summary>
        private Int32 _makerCodeEd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode;

        /// <summary>倉庫名</summary>
        private string _warehouseName;
        
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCodeList
        /// <summary>選択拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// public propaty name  :  GroupBySectionDiv
        /// <summary>集計方法プロパティ</summary>
        /// <value>0:実績表 1:リスト</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GroupBySectionDivState GroupBySectionDiv
        {
            get { return _groupBySectionDiv; }
            set { _groupBySectionDiv = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>売上日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>売上日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  InputDateSt
        /// <summary>入力日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDateSt
        {
            get { return _inputDateSt; }
            set { _inputDateSt = value; }
        }

        /// public propaty name  :  InputDateEd
        /// <summary>入力日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDateEd
        {
            get { return _inputDateEd; }
            set { _inputDateEd = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>在庫取寄せ区分プロパティ</summary>
        /// <value>0:全て 1:在庫, 2:取寄せ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltTtlDivState RsltTtlDiv
        {
            get { return _rsltTtlDiv; }
            set { _rsltTtlDiv = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>改頁プロパティ</summary>
        /// <value>0:なし 1:車輌</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NewPageDivState NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  CarMakerCodeSt
        /// <summary>車種メーカーコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種メーカーコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCodeSt
        {
            get { return _carMakerCodeSt; }
            set { _carMakerCodeSt = value; }
        }

        /// public propaty name  :  CarMakerCodeEd
        /// <summary>車種メーカーコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種メーカーコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCodeEd
        {
            get { return _carMakerCodeEd; }
            set { _carMakerCodeEd = value; }
        }

        /// public propaty name  :  CarModelCodeSt
        /// <summary>車種コード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelCodeSt
        {
            get { return _carModelCodeSt; }
            set { _carModelCodeSt = value; }
        }

        /// public propaty name  :  CarModelCodeEd
        /// <summary>車種コード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelCodeEd
        {
            get { return _carModelCodeEd; }
            set { _carModelCodeEd = value; }
        }

        /// public propaty name  :  CarModelSubCodeSt
        /// <summary>車種サブコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelSubCodeSt
        {
            get { return _carModelSubCodeSt; }
            set { _carModelSubCodeSt = value; }
        }

        /// public propaty name  :  CarModelSubCodeEd
        /// <summary>車種サブコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelSubCodeEd
        {
            get { return _carModelSubCodeEd; }
            set { _carModelSubCodeEd = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>代表型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代表型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  MakerCodeSt
        /// <summary>メーカー開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCodeSt
        {
            get { return _makerCodeSt; }
            set { _makerCodeSt = value; }
        }

        /// public propaty name  :  MakerCodeEd
        /// <summary>メーカー終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCodeEd
        {
            get { return _makerCodeEd; }
            set { _makerCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  CarOutDiv
        /// <summary>代表型式抽出区分プロパティ</summary>
        /// <value>0:と一致 1:で始まる 2:を含む 3:で終わる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代表型式抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelOutDivState ModelOutDiv
        {
            get { return _modelOutDiv; }
            set { _modelOutDiv = value; }
        }

        /// <summary>
        /// 集計方法　列挙型
        /// </summary>
        public enum GroupBySectionDivState
        {
            /// <summary>全社</summary>
            ByAllCompany = 0,
            /// <summary>拠点毎</summary>
            BySection = 1,
        }

        /// <summary>
        /// 在庫取寄せ区分　列挙型
        /// </summary>
        public enum RsltTtlDivState
        {
            /// <summary>全て</summary>
            Sum = 0,
            /// <summary>在庫</summary>
            Stock = 1,
            /// <summary>取寄</summary>
            Order = 2,
        }

        /// <summary>
        /// 改頁　列挙型
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>しない</summary>
            No = 0,
            /// <summary>拠点</summary>
            Section = 1,
            /// <summary>型式</summary>
            Model = 2,
        }

        /// <summary>
        /// 代表型式抽出区分　列挙型
        /// </summary>
        public enum ModelOutDivState
        {
            /// <summary>と一致</summary>
            Same = 0,
            /// <summary>で始まる</summary>
            First = 1,
            /// <summary>を含む</summary>
            Middle = 2,
            /// <summary>で終わる</summary>
            Last = 3,
        }

        /// <summary>
        /// 集計方法　名称取得
        /// </summary>
        public string GroupBySectionDivName
        {
            get
            {
                switch (this._groupBySectionDiv)
                {
                    case GroupBySectionDivState.ByAllCompany:
                        return ct_groupBySectionDivState_ByAllCompany;
                    case GroupBySectionDivState.BySection:
                        return ct_groupBySectionDivState_BySection;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 在庫取寄区分　名称取得
        /// </summary>
        public string RsltTtlDivName
        {
            get
            {
                switch (this._rsltTtlDiv)
                {
                    case RsltTtlDivState.Sum:
                        return ct_rsltTtlDivState_Sum;
                    case RsltTtlDivState.Stock:
                        return ct_rsltTtlDivState_Stock;
                    case RsltTtlDivState.Order:
                        return ct_rsltTtlDivState_Order;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 改頁　名称取得
        /// </summary>
        public string NewPageDivName
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.No:
                        return ct_comm_No;
                    case NewPageDivState.Section:
                        return ct_comm_Section;
                    case NewPageDivState.Model:
                        return ct_comm_Model;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 代表型式抽出区分　名称取得
        /// </summary>
        public string ModelOutDivName
        {
            get
            {
                switch (this._modelOutDiv)
                {
                    case ModelOutDivState.Same:
                        return ct_modelOutDivState_Same;
                    case ModelOutDivState.First:
                        return ct_modelOutDivState_First;
                    case ModelOutDivState.Middle:
                        return ct_modelOutDivState_Middle;
                    case ModelOutDivState.Last:
                        return ct_modelOutDivState_Last;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>line number</summary>
        public const int ct_Line_Num = 25;
        /// <summary>集計方法　全社</summary>
        public const string ct_groupBySectionDivState_ByAllCompany = "全社";
        /// <summary>集計方法　拠点毎</summary>
        public const string ct_groupBySectionDivState_BySection = "拠点毎";
        /// <summary>在庫取寄指定区分　合計</summary>
        public const string ct_rsltTtlDivState_Sum = "全て";
        /// <summary>在庫取寄指定区分　在庫</summary>
        public const string ct_rsltTtlDivState_Stock = "在庫";
        /// <summary>在庫取寄指定区分　取寄</summary>
        public const string ct_rsltTtlDivState_Order = "取寄";
        /// <summary>代表型式抽出区分　と一致 </summary>
        public const string ct_modelOutDivState_Same = "と一致";
        /// <summary>代表型式抽出区分　で始まる </summary>
        public const string ct_modelOutDivState_First = "で始まる";
        /// <summary>代表型式抽出区分　を含む </summary>
        public const string ct_modelOutDivState_Middle = "を含む";
        /// <summary>代表型式抽出区分　で終わる</summary>
        public const string ct_modelOutDivState_Last = "で終わる";
        /// <summary>しない</summary>
        public const string ct_comm_No = "しない";
        /// <summary>拠点</summary>
        public const string ct_comm_Section = "拠点";
        /// <summary>型式</summary>
        public const string ct_comm_Model = "型式";

        # region ■ Constructor ■
        /// <summary>
        /// 売上実績表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SalesRsltListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRsltListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelShipRsltListCndtn()
        {
        }
        # endregion ■ Constructor ■
    }
}
