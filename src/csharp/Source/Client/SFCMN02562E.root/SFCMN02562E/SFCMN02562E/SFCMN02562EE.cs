using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OScmBPSCnt
    /// <summary>
    ///                      提供側SCM事業場拠点連結マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供側SCM事業場拠点連結マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2014/7/9</br>
    /// <br>Genarated Date   :   2014/09/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OScmBPSCnt
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>連結先企業コード</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>連結先拠点コード</summary>
        private string _cnectOtherSecCd = "";

        /// <summary>契約先コード</summary>
        private string _contractantCode = "";

        /// <summary>FTC得意先コード</summary>
        private Int32 _fTCCustomerCode;

        /// <summary>連結元企業コード</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>連結元拠点コード</summary>
        private string _cnectOriginalSecCd = "";

        /// <summary>取引先契約先コード</summary>
        private string _transContractantCd = "";

        /// <summary>取引先得意先コード</summary>
        private Int32 _transCustomerCd;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  CnectOtherEpCd
        /// <summary>連結先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherEpCd
        {
            get { return _cnectOtherEpCd; }
            set { _cnectOtherEpCd = value; }
        }

        /// public propaty name  :  CnectOtherSecCd
        /// <summary>連結先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherSecCd
        {
            get { return _cnectOtherSecCd; }
            set { _cnectOtherSecCd = value; }
        }

        /// public propaty name  :  ContractantCode
        /// <summary>契約先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   契約先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ContractantCode
        {
            get { return _contractantCode; }
            set { _contractantCode = value; }
        }

        /// public propaty name  :  FTCCustomerCode
        /// <summary>FTC得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FTC得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FTCCustomerCode
        {
            get { return _fTCCustomerCode; }
            set { _fTCCustomerCode = value; }
        }

        /// public propaty name  :  CnectOriginalEpCd
        /// <summary>連結元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalEpCd
        {
            get { return _cnectOriginalEpCd; }
            set { _cnectOriginalEpCd = value; }
        }

        /// public propaty name  :  CnectOriginalSecCd
        /// <summary>連結元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalSecCd
        {
            get { return _cnectOriginalSecCd; }
            set { _cnectOriginalSecCd = value; }
        }

        /// public propaty name  :  TransContractantCd
        /// <summary>取引先契約先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引先契約先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransContractantCd
        {
            get { return _transContractantCd; }
            set { _transContractantCd = value; }
        }

        /// public propaty name  :  TransCustomerCd
        /// <summary>取引先得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引先得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TransCustomerCd
        {
            get { return _transCustomerCd; }
            set { _transCustomerCd = value; }
        }


        /// <summary>
        /// 提供側SCM事業場拠点連結マスタコンストラクタ
        /// </summary>
        /// <returns>OScmBPSCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPSCntクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OScmBPSCnt()
        {
        }

        /// <summary>
        /// 提供側SCM事業場拠点連結マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="cnectOtherSecCd">連結先拠点コード</param>
        /// <param name="contractantCode">契約先コード</param>
        /// <param name="fTCCustomerCode">FTC得意先コード</param>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cnectOriginalSecCd">連結元拠点コード</param>
        /// <param name="transContractantCd">取引先契約先コード</param>
        /// <param name="transCustomerCd">取引先得意先コード</param>
        /// <returns>OScmBPSCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPSCntクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OScmBPSCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOtherEpCd, string cnectOtherSecCd, string contractantCode, Int32 fTCCustomerCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string transContractantCd, Int32 transCustomerCd)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherSecCd = cnectOtherSecCd;
            this._contractantCode = contractantCode;
            this._fTCCustomerCode = fTCCustomerCode;
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalSecCd = cnectOriginalSecCd;
            this._transContractantCd = transContractantCd;
            this._transCustomerCd = transCustomerCd;

        }

        /// <summary>
        /// 提供側SCM事業場拠点連結マスタ複製処理
        /// </summary>
        /// <returns>OScmBPSCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOScmBPSCntクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OScmBPSCnt Clone()
        {
            return new OScmBPSCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOtherEpCd, this._cnectOtherSecCd, this._contractantCode, this._fTCCustomerCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._transContractantCd, this._transCustomerCd);
        }

        /// <summary>
        /// 提供側SCM事業場拠点連結マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOScmBPSCntクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPSCntクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(OScmBPSCnt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.CnectOtherSecCd == target.CnectOtherSecCd)
                 && (this.ContractantCode == target.ContractantCode)
                 && (this.FTCCustomerCode == target.FTCCustomerCode)
                 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
                 && (this.TransContractantCd == target.TransContractantCd)
                 && (this.TransCustomerCd == target.TransCustomerCd));
        }

        /// <summary>
        /// 提供側SCM事業場拠点連結マスタ比較処理
        /// </summary>
        /// <param name="oScmBPSCnt1">
        ///                    比較するOScmBPSCntクラスのインスタンス
        /// </param>
        /// <param name="oScmBPSCnt2">比較するOScmBPSCntクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPSCntクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(OScmBPSCnt oScmBPSCnt1, OScmBPSCnt oScmBPSCnt2)
        {
            return ((oScmBPSCnt1.CreateDateTime == oScmBPSCnt2.CreateDateTime)
                 && (oScmBPSCnt1.UpdateDateTime == oScmBPSCnt2.UpdateDateTime)
                 && (oScmBPSCnt1.LogicalDeleteCode == oScmBPSCnt2.LogicalDeleteCode)
                 && (oScmBPSCnt1.CnectOtherEpCd == oScmBPSCnt2.CnectOtherEpCd)
                 && (oScmBPSCnt1.CnectOtherSecCd == oScmBPSCnt2.CnectOtherSecCd)
                 && (oScmBPSCnt1.ContractantCode == oScmBPSCnt2.ContractantCode)
                 && (oScmBPSCnt1.FTCCustomerCode == oScmBPSCnt2.FTCCustomerCode)
                 && (oScmBPSCnt1.CnectOriginalEpCd == oScmBPSCnt2.CnectOriginalEpCd)
                 && (oScmBPSCnt1.CnectOriginalSecCd == oScmBPSCnt2.CnectOriginalSecCd)
                 && (oScmBPSCnt1.TransContractantCd == oScmBPSCnt2.TransContractantCd)
                 && (oScmBPSCnt1.TransCustomerCd == oScmBPSCnt2.TransCustomerCd));
        }
        /// <summary>
        /// 提供側SCM事業場拠点連結マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOScmBPSCntクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPSCntクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(OScmBPSCnt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.CnectOtherSecCd != target.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (this.ContractantCode != target.ContractantCode) resList.Add("ContractantCode");
            if (this.FTCCustomerCode != target.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (this.TransContractantCd != target.TransContractantCd) resList.Add("TransContractantCd");
            if (this.TransCustomerCd != target.TransCustomerCd) resList.Add("TransCustomerCd");

            return resList;
        }

        /// <summary>
        /// 提供側SCM事業場拠点連結マスタ比較処理
        /// </summary>
        /// <param name="oScmBPSCnt1">比較するOScmBPSCntクラスのインスタンス</param>
        /// <param name="oScmBPSCnt2">比較するOScmBPSCntクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPSCntクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(OScmBPSCnt oScmBPSCnt1, OScmBPSCnt oScmBPSCnt2)
        {
            ArrayList resList = new ArrayList();
            if (oScmBPSCnt1.CreateDateTime != oScmBPSCnt2.CreateDateTime) resList.Add("CreateDateTime");
            if (oScmBPSCnt1.UpdateDateTime != oScmBPSCnt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (oScmBPSCnt1.LogicalDeleteCode != oScmBPSCnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (oScmBPSCnt1.CnectOtherEpCd != oScmBPSCnt2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (oScmBPSCnt1.CnectOtherSecCd != oScmBPSCnt2.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (oScmBPSCnt1.ContractantCode != oScmBPSCnt2.ContractantCode) resList.Add("ContractantCode");
            if (oScmBPSCnt1.FTCCustomerCode != oScmBPSCnt2.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (oScmBPSCnt1.CnectOriginalEpCd != oScmBPSCnt2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (oScmBPSCnt1.CnectOriginalSecCd != oScmBPSCnt2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (oScmBPSCnt1.TransContractantCd != oScmBPSCnt2.TransContractantCd) resList.Add("TransContractantCd");
            if (oScmBPSCnt1.TransCustomerCd != oScmBPSCnt2.TransCustomerCd) resList.Add("TransCustomerCd");

            return resList;
        }
    }
}
