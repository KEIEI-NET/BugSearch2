//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CarShipRsltListCndtn
    /// <summary>
    ///                      車輌別出荷実績表抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   車輌別出荷実績表抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/9/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CarShipRsltListCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>選択拠点コード</summary>
        private string[] _sectionCodeList;

        /// <summary>集計方法</summary>
        /// <remarks>0:実績表 1:リスト</remarks>
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

        /// <summary>品番出力</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private GoodsNoPrintState _goodsNoPrint;

        /// <summary>原価・粗利出力</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private CostGrossPrintState _costGrossPrint;

        /// <summary>改頁</summary>
        /// <remarks>0:なし 1:車輌</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>明細単位</summary>
        /// <remarks>0：品番 1：BLコード 2：グループコード </remarks>
        private DetailDataValueState _detailDataValue;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;
   
        /// <summary>開始管理番号コード</summary>
        private string _carMngCodeSt;

        /// <summary>終了管理番号コード</summary>
        private string _carMngCodeEd;

        /// <summary>開始BLグループコード</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>終了BLグループコード</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始品番</summary>
        private string _goodsNoSt = "";

        /// <summary>終了品番</summary>
        private string _goodsNoEd = "";

        /// <summary>車輌備考</summary>
        private string _slipNoteCar = "";

        /// <summary>車輌抽出区分</summary>
        /// <remarks>0:と一致 1:で始まる 2:を含む 3:で終わる </remarks>
        private CarOutDivState _carOutDiv;

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

        /// public propaty name  :  GoodsNoPrint
        /// <summary>品番出力プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番出力プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsNoPrintState GoodsNoPrint
        {
            get { return _goodsNoPrint; }
            set { _goodsNoPrint = value; }
        }

        /// public propaty name  :  CostGrossPrint
        /// <summary>原価・粗利出力プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価・粗利出力プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CostGrossPrintState CostGrossPrint
        {
            get { return _costGrossPrint; }
            set { _costGrossPrint = value; }
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

        /// public propaty name  :  DetailDataValue
        /// <summary>明細単位プロパティ</summary>
        /// <value>0：品番 1：BLコード 2：グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DetailDataValueState DetailDataValue
        {
            get { return _detailDataValue; }
            set { _detailDataValue = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  CarMngCodeSt
        /// <summary>開始管理番号コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始管理番号コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCodeSt
        {
            get { return _carMngCodeSt; }
            set { _carMngCodeSt = value; }
        }

        /// public propaty name  :  CarMngCodeEd
        /// <summary>終了管理番号コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了管理番号コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCodeEd
        {
            get { return _carMngCodeEd; }
            set { _carMngCodeEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>開始グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>終了グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
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

        /// public propaty name  :  GoodsNoSt
        /// <summary>開始品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  SlipNoteCar
        /// <summary>車輌備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNoteCar
        {
            get { return _slipNoteCar; }
            set { _slipNoteCar = value; }
        }

        /// public propaty name  :  CarOutDiv
        /// <summary>車輌抽出区分プロパティ</summary>
        /// <value>0:と一致 1:で始まる 2:を含む 3:で終わる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarOutDivState CarOutDiv
        {
            get { return _carOutDiv; }
            set { _carOutDiv = value; }
        }

        /// <summary>
        /// 集計方法　列挙型
        /// </summary>
        public enum GroupBySectionDivState
        {
            /// <summary>実績表</summary>
            ByRslt = 0,
            /// <summary>リスト</summary>
            ByList = 1,
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
        /// 品番出力　列挙型
        /// </summary>
        public enum GoodsNoPrintState
        {
            /// <summary>なし</summary>
            No = 0,
            /// <summary>あり</summary>
            Yes = 1,
        }
        
 　　　 /// <summary>
        /// 原価・粗利出力　列挙型
        /// </summary>
        public enum CostGrossPrintState
        {
            /// <summary>なし</summary>
            No = 0,
            /// <summary>あり</summary>
            Yes = 1,
        }

        /// <summary>
        /// 改頁　列挙型
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>なし</summary>
            No = 0,
            /// <summary>車輌</summary>
            Car = 1,
        }

        /// <summary>
        /// 明細単位　列挙型
        /// </summary>
        public enum DetailDataValueState
        {
            /// <summary>品番</summary>
            GoodsNo = 0,
            /// <summary>BLコード</summary>
            BLCode = 1,
            /// <summary>グループコード</summary>
            GroupCode = 2,
        }

        /// <summary>
        /// 車輌抽出区分　列挙型
        /// </summary>
        public enum CarOutDivState
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
                    case GroupBySectionDivState.ByRslt:
                        return ct_groupBySectionDivState_ByRslt;
                    case GroupBySectionDivState.ByList:
                        return ct_groupBySectionDivState_ByList;
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
        /// 品番出力　名称取得
        /// </summary>
        public string GoodsNoPrintName
        {
            get
            {
                switch (this._goodsNoPrint)
                {
                    case GoodsNoPrintState.No:
                        return ct_comm_No;
                    case GoodsNoPrintState.Yes:
                        return ct_comm_Yes;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 原価・粗利出力　名称取得
        /// </summary>
        public string CostGrossPrintName
        {
            get
            {
                switch (this._costGrossPrint)
                {
                    case CostGrossPrintState.No:
                        return ct_comm_No;
                    case CostGrossPrintState.Yes:
                        return ct_comm_Yes;
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
                    case NewPageDivState.Car:
                        return ct_comm_Car;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 車輌抽出区分　名称取得
        /// </summary>
        public string CarOutDivName
        {
            get
            {
                switch (this._carOutDiv)
                {
                    case CarOutDivState.Same:
                        return ct_carOutDivState_Same;
                    case CarOutDivState.First:
                        return ct_carOutDivState_First;
                    case CarOutDivState.Middle:
                        return ct_carOutDivState_Middle;
                    case CarOutDivState.Last:
                        return ct_carOutDivState_Last;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 明細単位　名称取得
        /// </summary>
        public string DetailDataValueName
        {
            get
            {
                switch (this._detailDataValue)
                {
                    case DetailDataValueState.GoodsNo:
                        return ct_detailDataValue_GoodsNo;
                    case DetailDataValueState.BLCode:
                        return ct_detailDataValue_BLCode;
                    case DetailDataValueState.GroupCode:
                        return ct_detailDataValue_GroupCode;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>line number</summary>
        public const int ct_Line_Num = 25;
        /// <summary>集計方法　実績表</summary>
        public const string ct_groupBySectionDivState_ByRslt = "実績表";
        /// <summary>集計方法　リスト</summary>
        public const string ct_groupBySectionDivState_ByList = "リスト";
        /// <summary>在庫取寄指定区分　合計</summary>
        public const string ct_rsltTtlDivState_Sum = "全て";
        /// <summary>在庫取寄指定区分　在庫</summary>
        public const string ct_rsltTtlDivState_Stock = "在庫";
        /// <summary>在庫取寄指定区分　取寄</summary>
        public const string ct_rsltTtlDivState_Order = "取寄";
        /// <summary>車輌抽出区分　と一致 </summary>
        public const string ct_carOutDivState_Same = "と一致";
        /// <summary>車輌抽出区分　で始まる </summary>
        public const string ct_carOutDivState_First = "で始まる";
        /// <summary>車輌抽出区分　を含む </summary>
        public const string ct_carOutDivState_Middle = "を含む";
        /// <summary>車輌抽出区分　で終わる</summary>
        public const string ct_carOutDivState_Last = "で終わる";
        /// <summary>なし</summary>
        public const string ct_comm_No = "なし";
        /// <summary>あり</summary>
        public const string ct_comm_Yes = "あり";
        /// <summary>車輌</summary>
        public const string ct_comm_Car = "車輌";
        /// <summary>明細単位 品番</summary>
        public const string ct_detailDataValue_GoodsNo = "品番";
        /// <summary>明細単位 BLコード</summary>
        public const string ct_detailDataValue_BLCode = "BLコード";
        /// <summary>明細単位 グループコード</summary>
        public const string ct_detailDataValue_GroupCode = "グループコード";


        # region ■ Constructor ■
        /// <summary>
        /// 売上実績表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SalesRsltListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRsltListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarShipRsltListCndtn()
        {
        }
        # endregion ■ Constructor ■
    }
}
