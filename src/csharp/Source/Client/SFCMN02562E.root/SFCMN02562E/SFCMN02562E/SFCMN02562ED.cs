using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OScmBPCnt
    /// <summary>
    ///                      提供側SCM事業場連結マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供側SCM事業場連結マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2014/7/9</br>
    /// <br>Genarated Date   :   2014/09/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OScmBPCnt
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

        /// <summary>契約先コード</summary>
        private string _contractantCode = "";

        /// <summary>FTC得意先コード</summary>
        private Int32 _fTCCustomerCode;

        /// <summary>BLユーザコード1</summary>
        private string _bLUserCode1 = "";

        /// <summary>BLユーザコード2</summary>
        private string _bLUserCode2 = "";

        /// <summary>連結先企業コード</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>契約先名称</summary>
        /// <remarks>企業名称</remarks>
        private string _contractantName = "";

        /// <summary>FTC得意先名称</summary>
        /// <remarks>事業場名称</remarks>
        private string _fTCCustomerName = "";

        /// <summary>取引先契約先コード</summary>
        private string _transContractantCd = "";

        /// <summary>取引先得意先コード</summary>
        private Int32 _transCustomerCd;

        /// <summary>取引先BLユーザコード1</summary>
        private string _transBLUserCode1 = "";

        /// <summary>取引先BLユーザコード2</summary>
        private string _transBLUserCode2 = "";

        /// <summary>連結元企業コード</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>取引先契約先名称</summary>
        /// <remarks>企業名称</remarks>
        private string _transContractantNm = "";

        /// <summary>取引先得意先名称</summary>
        /// <remarks>事業場名称</remarks>
        private string _transCustomerNm = "";

        /// <summary>連携データ更新サービス区分</summary>
        /// <remarks>0:FTC,1:SCM</remarks>
        private Int32 _cooprtDataUpdateDiv;


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

        /// public propaty name  :  BLUserCode1
        /// <summary>BLユーザコード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLユーザコード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLUserCode1
        {
            get { return _bLUserCode1; }
            set { _bLUserCode1 = value; }
        }

        /// public propaty name  :  BLUserCode2
        /// <summary>BLユーザコード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLユーザコード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLUserCode2
        {
            get { return _bLUserCode2; }
            set { _bLUserCode2 = value; }
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

        /// public propaty name  :  ContractantName
        /// <summary>契約先名称プロパティ</summary>
        /// <value>企業名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   契約先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ContractantName
        {
            get { return _contractantName; }
            set { _contractantName = value; }
        }

        /// public propaty name  :  FTCCustomerName
        /// <summary>FTC得意先名称プロパティ</summary>
        /// <value>事業場名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FTC得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FTCCustomerName
        {
            get { return _fTCCustomerName; }
            set { _fTCCustomerName = value; }
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

        /// public propaty name  :  TransBLUserCode1
        /// <summary>取引先BLユーザコード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引先BLユーザコード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransBLUserCode1
        {
            get { return _transBLUserCode1; }
            set { _transBLUserCode1 = value; }
        }

        /// public propaty name  :  TransBLUserCode2
        /// <summary>取引先BLユーザコード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引先BLユーザコード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransBLUserCode2
        {
            get { return _transBLUserCode2; }
            set { _transBLUserCode2 = value; }
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

        /// public propaty name  :  TransContractantNm
        /// <summary>取引先契約先名称プロパティ</summary>
        /// <value>企業名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引先契約先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransContractantNm
        {
            get { return _transContractantNm; }
            set { _transContractantNm = value; }
        }

        /// public propaty name  :  TransCustomerNm
        /// <summary>取引先得意先名称プロパティ</summary>
        /// <value>事業場名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引先得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransCustomerNm
        {
            get { return _transCustomerNm; }
            set { _transCustomerNm = value; }
        }

        /// public propaty name  :  CooprtDataUpdateDiv
        /// <summary>連携データ更新サービス区分プロパティ</summary>
        /// <value>0:FTC,1:SCM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携データ更新サービス区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CooprtDataUpdateDiv
        {
            get { return _cooprtDataUpdateDiv; }
            set { _cooprtDataUpdateDiv = value; }
        }


        /// <summary>
        /// 提供側SCM事業場連結マスタコンストラクタ
        /// </summary>
        /// <returns>OScmBPCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPCntクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OScmBPCnt()
        {
        }

        /// <summary>
        /// 提供側SCM事業場連結マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="contractantCode">契約先コード</param>
        /// <param name="fTCCustomerCode">FTC得意先コード</param>
        /// <param name="bLUserCode1">BLユーザコード1</param>
        /// <param name="bLUserCode2">BLユーザコード2</param>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="contractantName">契約先名称(企業名称)</param>
        /// <param name="fTCCustomerName">FTC得意先名称(事業場名称)</param>
        /// <param name="transContractantCd">取引先契約先コード</param>
        /// <param name="transCustomerCd">取引先得意先コード</param>
        /// <param name="transBLUserCode1">取引先BLユーザコード1</param>
        /// <param name="transBLUserCode2">取引先BLユーザコード2</param>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="transContractantNm">取引先契約先名称(企業名称)</param>
        /// <param name="transCustomerNm">取引先得意先名称(事業場名称)</param>
        /// <param name="cooprtDataUpdateDiv">連携データ更新サービス区分(0:FTC,1:SCM)</param>
        /// <returns>OScmBPCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPCntクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OScmBPCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string contractantCode, Int32 fTCCustomerCode, string bLUserCode1, string bLUserCode2, string cnectOtherEpCd, string contractantName, string fTCCustomerName, string transContractantCd, Int32 transCustomerCd, string transBLUserCode1, string transBLUserCode2, string cnectOriginalEpCd, string transContractantNm, string transCustomerNm, Int32 cooprtDataUpdateDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._contractantCode = contractantCode;
            this._fTCCustomerCode = fTCCustomerCode;
            this._bLUserCode1 = bLUserCode1;
            this._bLUserCode2 = bLUserCode2;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._contractantName = contractantName;
            this._fTCCustomerName = fTCCustomerName;
            this._transContractantCd = transContractantCd;
            this._transCustomerCd = transCustomerCd;
            this._transBLUserCode1 = transBLUserCode1;
            this._transBLUserCode2 = transBLUserCode2;
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._transContractantNm = transContractantNm;
            this._transCustomerNm = transCustomerNm;
            this._cooprtDataUpdateDiv = cooprtDataUpdateDiv;

        }

        /// <summary>
        /// 提供側SCM事業場連結マスタ複製処理
        /// </summary>
        /// <returns>OScmBPCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOScmBPCntクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OScmBPCnt Clone()
        {
            return new OScmBPCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._contractantCode, this._fTCCustomerCode, this._bLUserCode1, this._bLUserCode2, this._cnectOtherEpCd, this._contractantName, this._fTCCustomerName, this._transContractantCd, this._transCustomerCd, this._transBLUserCode1, this._transBLUserCode2, this._cnectOriginalEpCd, this._transContractantNm, this._transCustomerNm, this._cooprtDataUpdateDiv);
        }

        /// <summary>
        /// 提供側SCM事業場連結マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOScmBPCntクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPCntクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(OScmBPCnt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.ContractantCode == target.ContractantCode)
                 && (this.FTCCustomerCode == target.FTCCustomerCode)
                 && (this.BLUserCode1 == target.BLUserCode1)
                 && (this.BLUserCode2 == target.BLUserCode2)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.ContractantName == target.ContractantName)
                 && (this.FTCCustomerName == target.FTCCustomerName)
                 && (this.TransContractantCd == target.TransContractantCd)
                 && (this.TransCustomerCd == target.TransCustomerCd)
                 && (this.TransBLUserCode1 == target.TransBLUserCode1)
                 && (this.TransBLUserCode2 == target.TransBLUserCode2)
                 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.TransContractantNm == target.TransContractantNm)
                 && (this.TransCustomerNm == target.TransCustomerNm)
                 && (this.CooprtDataUpdateDiv == target.CooprtDataUpdateDiv));
        }

        /// <summary>
        /// 提供側SCM事業場連結マスタ比較処理
        /// </summary>
        /// <param name="oScmBPCnt1">
        ///                    比較するOScmBPCntクラスのインスタンス
        /// </param>
        /// <param name="oScmBPCnt2">比較するOScmBPCntクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPCntクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(OScmBPCnt oScmBPCnt1, OScmBPCnt oScmBPCnt2)
        {
            return ((oScmBPCnt1.CreateDateTime == oScmBPCnt2.CreateDateTime)
                 && (oScmBPCnt1.UpdateDateTime == oScmBPCnt2.UpdateDateTime)
                 && (oScmBPCnt1.LogicalDeleteCode == oScmBPCnt2.LogicalDeleteCode)
                 && (oScmBPCnt1.ContractantCode == oScmBPCnt2.ContractantCode)
                 && (oScmBPCnt1.FTCCustomerCode == oScmBPCnt2.FTCCustomerCode)
                 && (oScmBPCnt1.BLUserCode1 == oScmBPCnt2.BLUserCode1)
                 && (oScmBPCnt1.BLUserCode2 == oScmBPCnt2.BLUserCode2)
                 && (oScmBPCnt1.CnectOtherEpCd == oScmBPCnt2.CnectOtherEpCd)
                 && (oScmBPCnt1.ContractantName == oScmBPCnt2.ContractantName)
                 && (oScmBPCnt1.FTCCustomerName == oScmBPCnt2.FTCCustomerName)
                 && (oScmBPCnt1.TransContractantCd == oScmBPCnt2.TransContractantCd)
                 && (oScmBPCnt1.TransCustomerCd == oScmBPCnt2.TransCustomerCd)
                 && (oScmBPCnt1.TransBLUserCode1 == oScmBPCnt2.TransBLUserCode1)
                 && (oScmBPCnt1.TransBLUserCode2 == oScmBPCnt2.TransBLUserCode2)
                 && (oScmBPCnt1.CnectOriginalEpCd == oScmBPCnt2.CnectOriginalEpCd)
                 && (oScmBPCnt1.TransContractantNm == oScmBPCnt2.TransContractantNm)
                 && (oScmBPCnt1.TransCustomerNm == oScmBPCnt2.TransCustomerNm)
                 && (oScmBPCnt1.CooprtDataUpdateDiv == oScmBPCnt2.CooprtDataUpdateDiv));
        }
        /// <summary>
        /// 提供側SCM事業場連結マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOScmBPCntクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPCntクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(OScmBPCnt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.ContractantCode != target.ContractantCode) resList.Add("ContractantCode");
            if (this.FTCCustomerCode != target.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (this.BLUserCode1 != target.BLUserCode1) resList.Add("BLUserCode1");
            if (this.BLUserCode2 != target.BLUserCode2) resList.Add("BLUserCode2");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.ContractantName != target.ContractantName) resList.Add("ContractantName");
            if (this.FTCCustomerName != target.FTCCustomerName) resList.Add("FTCCustomerName");
            if (this.TransContractantCd != target.TransContractantCd) resList.Add("TransContractantCd");
            if (this.TransCustomerCd != target.TransCustomerCd) resList.Add("TransCustomerCd");
            if (this.TransBLUserCode1 != target.TransBLUserCode1) resList.Add("TransBLUserCode1");
            if (this.TransBLUserCode2 != target.TransBLUserCode2) resList.Add("TransBLUserCode2");
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.TransContractantNm != target.TransContractantNm) resList.Add("TransContractantNm");
            if (this.TransCustomerNm != target.TransCustomerNm) resList.Add("TransCustomerNm");
            if (this.CooprtDataUpdateDiv != target.CooprtDataUpdateDiv) resList.Add("CooprtDataUpdateDiv");

            return resList;
        }

        /// <summary>
        /// 提供側SCM事業場連結マスタ比較処理
        /// </summary>
        /// <param name="oScmBPCnt1">比較するOScmBPCntクラスのインスタンス</param>
        /// <param name="oScmBPCnt2">比較するOScmBPCntクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OScmBPCntクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(OScmBPCnt oScmBPCnt1, OScmBPCnt oScmBPCnt2)
        {
            ArrayList resList = new ArrayList();
            if (oScmBPCnt1.CreateDateTime != oScmBPCnt2.CreateDateTime) resList.Add("CreateDateTime");
            if (oScmBPCnt1.UpdateDateTime != oScmBPCnt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (oScmBPCnt1.LogicalDeleteCode != oScmBPCnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (oScmBPCnt1.ContractantCode != oScmBPCnt2.ContractantCode) resList.Add("ContractantCode");
            if (oScmBPCnt1.FTCCustomerCode != oScmBPCnt2.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (oScmBPCnt1.BLUserCode1 != oScmBPCnt2.BLUserCode1) resList.Add("BLUserCode1");
            if (oScmBPCnt1.BLUserCode2 != oScmBPCnt2.BLUserCode2) resList.Add("BLUserCode2");
            if (oScmBPCnt1.CnectOtherEpCd != oScmBPCnt2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (oScmBPCnt1.ContractantName != oScmBPCnt2.ContractantName) resList.Add("ContractantName");
            if (oScmBPCnt1.FTCCustomerName != oScmBPCnt2.FTCCustomerName) resList.Add("FTCCustomerName");
            if (oScmBPCnt1.TransContractantCd != oScmBPCnt2.TransContractantCd) resList.Add("TransContractantCd");
            if (oScmBPCnt1.TransCustomerCd != oScmBPCnt2.TransCustomerCd) resList.Add("TransCustomerCd");
            if (oScmBPCnt1.TransBLUserCode1 != oScmBPCnt2.TransBLUserCode1) resList.Add("TransBLUserCode1");
            if (oScmBPCnt1.TransBLUserCode2 != oScmBPCnt2.TransBLUserCode2) resList.Add("TransBLUserCode2");
            if (oScmBPCnt1.CnectOriginalEpCd != oScmBPCnt2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (oScmBPCnt1.TransContractantNm != oScmBPCnt2.TransContractantNm) resList.Add("TransContractantNm");
            if (oScmBPCnt1.TransCustomerNm != oScmBPCnt2.TransCustomerNm) resList.Add("TransCustomerNm");
            if (oScmBPCnt1.CooprtDataUpdateDiv != oScmBPCnt2.CooprtDataUpdateDiv) resList.Add("CooprtDataUpdateDiv");

            return resList;
        }
    }
}
