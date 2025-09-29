using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   WarehouseSet
    /// <summary>
    ///                      倉庫マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   倉庫マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class WarehousePrintSet
    {
        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>主管倉庫コード</summary>
        /// <remarks>委託の場合に在庫補充を行う元の倉庫</remarks>
        private string _mainMngWarehouseCd = "";

        /// <summary>主管倉庫名称</summary>
        private string _mainWarehouseName = "";

        /// <summary>在庫一括リマーク</summary>
        /// <remarks>在庫一括発注の時に使用（３桁＋５桁使用）</remarks>
        private string _stockBlnktRemark = "";


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

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  MainMngWarehouseCd
        /// <summary>主管倉庫コードプロパティ</summary>
        /// <value>委託の場合に在庫補充を行う元の倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主管倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainMngWarehouseCd
        {
            get { return _mainMngWarehouseCd; }
            set { _mainMngWarehouseCd = value; }
        }

        /// public propaty name  :  MainWarehouseName
        /// <summary>主管倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主管倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainWarehouseName
        {
            get { return _mainWarehouseName; }
            set { _mainWarehouseName = value; }
        }

        /// public propaty name  :  StockBlnktRemark
        /// <summary>在庫一括リマークプロパティ</summary>
        /// <value>在庫一括発注の時に使用（３桁＋５桁使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫一括リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }

        /// <summary>
        /// 倉庫情報（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public WarehousePrintSet Clone()
        {
            return new WarehousePrintSet(this._warehouseCode, this._warehouseName, this._sectionCode, this._sectionGuideNm, this._customerCode, this._customerSnm, this._mainMngWarehouseCd, this._mainWarehouseName, this._stockBlnktRemark);

        }

        /// <summary>
        /// 倉庫情報（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>WarehouseSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   WarehouseSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public WarehousePrintSet()
        {
        }

        /// <summary>
        /// 倉庫情報（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="WarehouseCode"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="MainMngWarehouseCd"></param>
        /// <param name="MainWarehouseName"></param>
        /// <param name="stockBlnktRemark"></param>
        public WarehousePrintSet(string WarehouseCode, string WarehouseName, string SectionCode, string SectionGuideNm, Int32 CustomerCode, string CustomerSnm, string MainMngWarehouseCd, string MainWarehouseName, string stockBlnktRemark)
        {
            this._warehouseCode = WarehouseCode;
            this._warehouseName = WarehouseName;
            this._sectionCode = SectionCode;
            this._sectionGuideNm = SectionGuideNm;
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._mainMngWarehouseCd = MainMngWarehouseCd;
            this._mainWarehouseName = MainWarehouseName;
            this._stockBlnktRemark = stockBlnktRemark;
        }
    }
}
