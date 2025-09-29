using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierCheckOrderCndtn
    /// <summary>
    ///                      仕入チェック処理抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入チェック処理抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SupplierCheckOrderCndtn
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
        /// <remarks>0:全て 1:仕入 2:返品 3:訂正 4:削除</remarks>
        private Int32 _slipDiv;

        /// <summary>チェック区分</summary>
        /// <remarks>0:全て 1:未チェック 2:チェック済み </remarks>
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

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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
        /// <value>0:全て 1:仕入 2:返品 3:訂正 4:削除</value>
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
        /// <value>0:全て 1:未チェック 2:チェック済み </value>
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

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// 仕入チェック処理抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SupplierCheckOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckOrderCndtn()
        {
        }

        /// <summary>
        /// 仕入チェック処理抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="procDiv">処理区分(0:日次 1:締次)</param>
        /// <param name="slipDiv">伝票区分(0:全て 1:仕入 2:返品 3:訂正 4:削除)</param>
        /// <param name="checkDiv">チェック区分(0:全て 1:未チェック 2:チェック済み )</param>
        /// <param name="st_StockDate">開始仕入日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="ed_StockDate">終了仕入日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="st_InputDay">開始入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="ed_InputDay">終了入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="st_SupplierSlipNo">開始仕入伝票番号(発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる)</param>
        /// <param name="ed_SupplierSlipNo">終了仕入伝票番号(発注伝票番号、仕入伝票番号、入荷伝票番号を兼ねる)</param>
        /// <param name="st_PartySaleSlipNum">開始相手先伝票番号(仕入先伝票番号に使用する)</param>
        /// <param name="ed_PartySaleSlipNum">終了相手先伝票番号(仕入先伝票番号に使用する)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SupplierCheckOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckOrderCndtn(string enterpriseCode, string sectionCode, Int32 supplierCd, Int32 procDiv, Int32 slipDiv, Int32 checkDiv, Int32 st_StockDate, Int32 ed_StockDate, Int32 st_InputDay, Int32 ed_InputDay, Int32 st_SupplierSlipNo, Int32 ed_SupplierSlipNo, string st_PartySaleSlipNum, string ed_PartySaleSlipNum, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            this._procDiv = procDiv;
            this._slipDiv = slipDiv;
            this._checkDiv = checkDiv;
            this._st_StockDate = st_StockDate;
            this._ed_StockDate = ed_StockDate;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._st_SupplierSlipNo = st_SupplierSlipNo;
            this._ed_SupplierSlipNo = ed_SupplierSlipNo;
            this._st_PartySaleSlipNum = st_PartySaleSlipNum;
            this._ed_PartySaleSlipNum = ed_PartySaleSlipNum;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 仕入チェック処理抽出条件クラス複製処理
        /// </summary>
        /// <returns>SupplierCheckOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSupplierCheckOrderCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SupplierCheckOrderCndtn Clone()
        {
            return new SupplierCheckOrderCndtn(this._enterpriseCode, this._sectionCode, this._supplierCd, this._procDiv, this._slipDiv, this._checkDiv, this._st_StockDate, this._ed_StockDate, this._st_InputDay, this._ed_InputDay, this._st_SupplierSlipNo, this._ed_SupplierSlipNo, this._st_PartySaleSlipNum, this._ed_PartySaleSlipNum, this._enterpriseName);
        }

        /// <summary>
        /// 仕入チェック処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSupplierCheckOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SupplierCheckOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.ProcDiv == target.ProcDiv)
                 && (this.SlipDiv == target.SlipDiv)
                 && (this.CheckDiv == target.CheckDiv)
                 && (this.St_StockDate == target.St_StockDate)
                 && (this.Ed_StockDate == target.Ed_StockDate)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.St_SupplierSlipNo == target.St_SupplierSlipNo)
                 && (this.Ed_SupplierSlipNo == target.Ed_SupplierSlipNo)
                 && (this.St_PartySaleSlipNum == target.St_PartySaleSlipNum)
                 && (this.Ed_PartySaleSlipNum == target.Ed_PartySaleSlipNum)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 仕入チェック処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="supplierCheckOrderCndtn1">
        ///                    比較するSupplierCheckOrderCndtnクラスのインスタンス
        /// </param>
        /// <param name="supplierCheckOrderCndtn2">比較するSupplierCheckOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SupplierCheckOrderCndtn supplierCheckOrderCndtn1, SupplierCheckOrderCndtn supplierCheckOrderCndtn2)
        {
            return ((supplierCheckOrderCndtn1.EnterpriseCode == supplierCheckOrderCndtn2.EnterpriseCode)
                 && (supplierCheckOrderCndtn1.SectionCode == supplierCheckOrderCndtn2.SectionCode)
                 && (supplierCheckOrderCndtn1.SupplierCd == supplierCheckOrderCndtn2.SupplierCd)
                 && (supplierCheckOrderCndtn1.ProcDiv == supplierCheckOrderCndtn2.ProcDiv)
                 && (supplierCheckOrderCndtn1.SlipDiv == supplierCheckOrderCndtn2.SlipDiv)
                 && (supplierCheckOrderCndtn1.CheckDiv == supplierCheckOrderCndtn2.CheckDiv)
                 && (supplierCheckOrderCndtn1.St_StockDate == supplierCheckOrderCndtn2.St_StockDate)
                 && (supplierCheckOrderCndtn1.Ed_StockDate == supplierCheckOrderCndtn2.Ed_StockDate)
                 && (supplierCheckOrderCndtn1.St_InputDay == supplierCheckOrderCndtn2.St_InputDay)
                 && (supplierCheckOrderCndtn1.Ed_InputDay == supplierCheckOrderCndtn2.Ed_InputDay)
                 && (supplierCheckOrderCndtn1.St_SupplierSlipNo == supplierCheckOrderCndtn2.St_SupplierSlipNo)
                 && (supplierCheckOrderCndtn1.Ed_SupplierSlipNo == supplierCheckOrderCndtn2.Ed_SupplierSlipNo)
                 && (supplierCheckOrderCndtn1.St_PartySaleSlipNum == supplierCheckOrderCndtn2.St_PartySaleSlipNum)
                 && (supplierCheckOrderCndtn1.Ed_PartySaleSlipNum == supplierCheckOrderCndtn2.Ed_PartySaleSlipNum)
                 && (supplierCheckOrderCndtn1.EnterpriseName == supplierCheckOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// 仕入チェック処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSupplierCheckOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SupplierCheckOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.ProcDiv != target.ProcDiv) resList.Add("ProcDiv");
            if (this.SlipDiv != target.SlipDiv) resList.Add("SlipDiv");
            if (this.CheckDiv != target.CheckDiv) resList.Add("CheckDiv");
            if (this.St_StockDate != target.St_StockDate) resList.Add("St_StockDate");
            if (this.Ed_StockDate != target.Ed_StockDate) resList.Add("Ed_StockDate");
            if (this.St_InputDay != target.St_InputDay) resList.Add("St_InputDay");
            if (this.Ed_InputDay != target.Ed_InputDay) resList.Add("Ed_InputDay");
            if (this.St_SupplierSlipNo != target.St_SupplierSlipNo) resList.Add("St_SupplierSlipNo");
            if (this.Ed_SupplierSlipNo != target.Ed_SupplierSlipNo) resList.Add("Ed_SupplierSlipNo");
            if (this.St_PartySaleSlipNum != target.St_PartySaleSlipNum) resList.Add("St_PartySaleSlipNum");
            if (this.Ed_PartySaleSlipNum != target.Ed_PartySaleSlipNum) resList.Add("Ed_PartySaleSlipNum");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 仕入チェック処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="supplierCheckOrderCndtn1">比較するSupplierCheckOrderCndtnクラスのインスタンス</param>
        /// <param name="supplierCheckOrderCndtn2">比較するSupplierCheckOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SupplierCheckOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SupplierCheckOrderCndtn supplierCheckOrderCndtn1, SupplierCheckOrderCndtn supplierCheckOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (supplierCheckOrderCndtn1.EnterpriseCode != supplierCheckOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (supplierCheckOrderCndtn1.SectionCode != supplierCheckOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (supplierCheckOrderCndtn1.SupplierCd != supplierCheckOrderCndtn2.SupplierCd) resList.Add("SupplierCd");
            if (supplierCheckOrderCndtn1.ProcDiv != supplierCheckOrderCndtn2.ProcDiv) resList.Add("ProcDiv");
            if (supplierCheckOrderCndtn1.SlipDiv != supplierCheckOrderCndtn2.SlipDiv) resList.Add("SlipDiv");
            if (supplierCheckOrderCndtn1.CheckDiv != supplierCheckOrderCndtn2.CheckDiv) resList.Add("CheckDiv");
            if (supplierCheckOrderCndtn1.St_StockDate != supplierCheckOrderCndtn2.St_StockDate) resList.Add("St_StockDate");
            if (supplierCheckOrderCndtn1.Ed_StockDate != supplierCheckOrderCndtn2.Ed_StockDate) resList.Add("Ed_StockDate");
            if (supplierCheckOrderCndtn1.St_InputDay != supplierCheckOrderCndtn2.St_InputDay) resList.Add("St_InputDay");
            if (supplierCheckOrderCndtn1.Ed_InputDay != supplierCheckOrderCndtn2.Ed_InputDay) resList.Add("Ed_InputDay");
            if (supplierCheckOrderCndtn1.St_SupplierSlipNo != supplierCheckOrderCndtn2.St_SupplierSlipNo) resList.Add("St_SupplierSlipNo");
            if (supplierCheckOrderCndtn1.Ed_SupplierSlipNo != supplierCheckOrderCndtn2.Ed_SupplierSlipNo) resList.Add("Ed_SupplierSlipNo");
            if (supplierCheckOrderCndtn1.St_PartySaleSlipNum != supplierCheckOrderCndtn2.St_PartySaleSlipNum) resList.Add("St_PartySaleSlipNum");
            if (supplierCheckOrderCndtn1.Ed_PartySaleSlipNum != supplierCheckOrderCndtn2.Ed_PartySaleSlipNum) resList.Add("Ed_PartySaleSlipNum");
            if (supplierCheckOrderCndtn1.EnterpriseName != supplierCheckOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
