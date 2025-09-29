using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CarInfoConditionWorkWork
    /// <summary>
    ///                      車輌出荷部品表示検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車輌出荷部品表示検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarInfoConditionWorkWork
    {
        /// <summary>表示区分</summary>
        private Int32 _dispDiv;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>管理番号検索区分</summary>
        private Int32 _carMngCodeDiv;

        /// <summary>売上日付（開始）</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _stSalesDate;

        /// <summary>売上日付（終了）</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _edSalesDate;

        /// <summary>入力日（開始）</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _stInputDate;

        /// <summary>入力日（終了）</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _edInputDate;

        /// <summary>型式</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式検索区分</summary>
        private Int32 _fullModelDiv;

        /// <summary>車輌備考</summary>
        private string _carNote = "";

        /// <summary>車輌備考検索区分</summary>
        private Int32 _carNoteDiv;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品番号検索区分</summary>
        private Int32 _goodsNoDiv;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称検索区分</summary>
        private Int32 _goodsNameDiv;

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _carMngNo;


        /// public propaty name  :  DispDiv
        /// <summary>表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DispDiv
        {
            get { return _dispDiv; }
            set { _dispDiv = value; }
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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  CarMngCodeDiv
        /// <summary>管理番号検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理番号検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngCodeDiv
        {
            get { return _carMngCodeDiv; }
            set { _carMngCodeDiv = value; }
        }

        /// public propaty name  :  StSalesDate
        /// <summary>売上日付（開始）プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StSalesDate
        {
            get { return _stSalesDate; }
            set { _stSalesDate = value; }
        }

        /// public propaty name  :  EdSalesDate
        /// <summary>売上日付（終了）プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdSalesDate
        {
            get { return _edSalesDate; }
            set { _edSalesDate = value; }
        }

        /// public propaty name  :  StInputDate
        /// <summary>入力日（開始）プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StInputDate
        {
            get { return _stInputDate; }
            set { _stInputDate = value; }
        }

        /// public propaty name  :  EdInputDate
        /// <summary>入力日（終了）プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdInputDate
        {
            get { return _edInputDate; }
            set { _edInputDate = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FullModelDiv
        /// <summary>型式検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FullModelDiv
        {
            get { return _fullModelDiv; }
            set { _fullModelDiv = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>車輌備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// public propaty name  :  CarNoteDiv
        /// <summary>車輌備考検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarNoteDiv
        {
            get { return _carNoteDiv; }
            set { _carNoteDiv = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoDiv
        /// <summary>商品番号検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoDiv
        {
            get { return _goodsNoDiv; }
            set { _goodsNoDiv = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameDiv
        /// <summary>商品名称検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNameDiv
        {
            get { return _goodsNameDiv; }
            set { _goodsNameDiv = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
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

        /// public propaty name  :  CarMngNo
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }


        /// <summary>
        /// 車輌出荷部品表示検索条件ワークコンストラクタ
        /// </summary>
        /// <returns>CarInfoConditionWorkWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CarInfoConditionWorkWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CarInfoConditionWorkWork()
        {
        }

    }
}
