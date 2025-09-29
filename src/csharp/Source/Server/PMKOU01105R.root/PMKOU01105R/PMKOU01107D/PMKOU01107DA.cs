using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SupplierCheckOrderCndtnWork
    /// <summary>
    ///                      仕入チェック処理(明細)抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入チェック処理(明細)抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SupplierCheckOrderCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>処理区分</summary>
        /// <remarks>0:日次 1:締次</remarks>
        private Int32 _procDiv;

        /// <summary>伝票区分</summary>
        /// <remarks>0:全て 1:仕入 2:返品</remarks>
        private Int32 _slipDiv;

        /// <summary>チェック区分</summary>
        /// <remarks>0:未チェック 1:チェック済み</remarks>
        private Int32 _checkDiv;

        /// <summary>開始仕入日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _st_StockDate;

        /// <summary>終了仕入日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _ed_StockDate;

        /// <summary>開始入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _st_InputDay;

        /// <summary>終了入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _ed_InputDay;

        /// <summary>開始仕入伝票番号</summary>
        /// <remarks>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</remarks>
        private Int32 _st_SupplierSlipNo;

        /// <summary>終了仕入伝票番号</summary>
        /// <remarks>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</remarks>
        private Int32 _ed_SupplierSlipNo;

        /// <summary>開始相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _st_PartySaleSlipNum = "";

        /// <summary>終了相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _ed_PartySaleSlipNum = "";


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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>0:日次 1:締次</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  SlipDiv
        /// <summary>伝票区分プロパティ</summary>
        /// <value>0:全て 1:仕入 2:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipDiv
        {
            get { return _slipDiv; }
            set { _slipDiv = value; }
        }

        /// public propaty name  :  CheckDiv
        /// <summary>チェック区分プロパティ</summary>
        /// <value>0:未チェック 1:チェック済み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckDiv
        {
            get { return _checkDiv; }
            set { _checkDiv = value; }
        }

        /// public propaty name  :  St_StockDate
        /// <summary>開始仕入日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_StockDate
        {
            get { return _st_StockDate; }
            set { _st_StockDate = value; }
        }

        /// public propaty name  :  Ed_StockDate
        /// <summary>終了仕入日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_StockDate
        {
            get { return _ed_StockDate; }
            set { _ed_StockDate = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>開始入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>終了入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  St_SupplierSlipNo
        /// <summary>開始仕入伝票番号プロパティ</summary>
        /// <value>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierSlipNo
        {
            get { return _st_SupplierSlipNo; }
            set { _st_SupplierSlipNo = value; }
        }

        /// public propaty name  :  Ed_SupplierSlipNo
        /// <summary>終了仕入伝票番号プロパティ</summary>
        /// <value>発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierSlipNo
        {
            get { return _ed_SupplierSlipNo; }
            set { _ed_SupplierSlipNo = value; }
        }

        /// public propaty name  :  St_PartySaleSlipNum
        /// <summary>開始相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_PartySaleSlipNum
        {
            get { return _st_PartySaleSlipNum; }
            set { _st_PartySaleSlipNum = value; }
        }

        /// public propaty name  :  Ed_PartySaleSlipNum
        /// <summary>終了相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_PartySaleSlipNum
        {
            get { return _ed_PartySaleSlipNum; }
            set { _ed_PartySaleSlipNum = value; }
        }


        /// <summary>
        /// 仕入チェック処理(明細)抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>SupplierCheckOrderCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckOrderCndtnWork()
        {
        }

    }
}




