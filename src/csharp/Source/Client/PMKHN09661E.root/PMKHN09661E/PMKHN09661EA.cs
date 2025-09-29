//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リモート伝発設定マスタ データクラス
// プログラム概要   : リモート伝発設定マスタ データクラスデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.08.03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 修 正 日              修正内容 : リモート伝発　余白設定の仕様変更
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RmSlpPrtSt
    /// <summary>
    ///                      リモート伝発設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   リモート伝発設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011.07.21</br>
    /// <br>Genarated Date   :   2011.08.03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RmSlpPrtSt
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

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>PCC自社コード</summary>
        /// <remarks>PMの得意先コード</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>伝票印刷種別</summary>
        /// <remarks>30:納品書160:UOE伝票</remarks>
        private Int32 _slipPrtKind;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>伝票印刷設定用</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>リモート伝発区分</summary>
        /// <remarks>0:発行しない, 1:発行する</remarks>
        private Int32 _rmtSlpPrtDiv;

        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        /// <summary>上余白</summary>
        /// <remarks>上余白</remarks>
        private double _topMargin;

        /// <summary>左余白</summary>
        /// <remarks>左余白</remarks>
        private double _leftMargin;
        // 2011.09.16 zhouzy UPDATE END <<<<<<

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC自社コードプロパティ</summary>
        /// <value>PMの得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC自社コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>伝票印刷種別プロパティ</summary>
        /// <value>30:納品書160:UOE伝票</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>伝票印刷設定用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  RmtSlpPrtDiv
        /// <summary>リモート伝発区分プロパティ</summary>
        /// <value>0:発行しない, 1:発行する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   リモート伝発区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RmtSlpPrtDiv
        {
            get { return _rmtSlpPrtDiv; }
            set { _rmtSlpPrtDiv = value; }
        }
        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        /// public propaty name  :  TopMargin
        /// <summary>上余白プロパティ</summary>
        /// <value>上余白</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上余白プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        /// public propaty name  :  TopMargin
        /// <summary>左余白プロパティ</summary>
        /// <value>左余白</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   左余白プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }
        // 2011.09.16 zhouzy UPDATE END <<<<<<

        /// <summary>
        /// リモート伝発設定マスタコンストラクタ
        /// </summary>
        /// <returns>RmSlpPrtStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RmSlpPrtSt()
        {
        }

        /// <summary>
        /// リモート伝発設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="fileHeaderGuid">GUID</param>
        /// <param name="updEmployeeCode">更新従業員コード</param>
        /// <param name="updAssemblyId1">更新アセンブリID1</param>
        /// <param name="updAssemblyId2">更新アセンブリID2</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="pccCompanyCode">PCC自社コード(PMの得意先コード)</param>
        /// <param name="slipPrtKind">伝票印刷種別(30:納品書160:UOE伝票)</param>
        /// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(伝票印刷設定用)</param>
        /// <param name="rmtSlpPrtDiv">リモート伝発区分(0:発行しない, 1:発行する)</param>
        /// <param name="topMargin">左余白</param>
        /// <param name="leftMargin">左余白</param>
        /// <returns>RmSlpPrtStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RmSlpPrtSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, Int32 slipPrtKind, string slipPrtSetPaperId, Int32 rmtSlpPrtDiv, double topMargin, double leftMargin)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._slipPrtKind = slipPrtKind;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._rmtSlpPrtDiv = rmtSlpPrtDiv;
            this._topMargin = topMargin;
            this._leftMargin = leftMargin;
        }

        /// <summary>
        /// リモート伝発設定マスタ複製処理
        /// </summary>
        /// <returns>RmSlpPrtStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRmSlpPrtStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RmSlpPrtSt Clone()
        {
            return new RmSlpPrtSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._slipPrtKind, this._slipPrtSetPaperId, this._rmtSlpPrtDiv,this._topMargin,this._leftMargin);//@@@@20230303
        }

        /// <summary>
        /// リモート伝発設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRmSlpPrtStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RmSlpPrtSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.RmtSlpPrtDiv == target.RmtSlpPrtDiv)
                 && (this.TopMargin == target.TopMargin)
                 && (this.LeftMargin == target.LeftMargin));
        }

        /// <summary>
        /// リモート伝発設定マスタ比較処理
        /// </summary>
        /// <param name="rmSlpPrtSt1">
        ///                    比較するRmSlpPrtStクラスのインスタンス
        /// </param>
        /// <param name="rmSlpPrtSt2">比較するRmSlpPrtStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RmSlpPrtSt rmSlpPrtSt1, RmSlpPrtSt rmSlpPrtSt2)
        {
            return ((rmSlpPrtSt1.CreateDateTime == rmSlpPrtSt2.CreateDateTime)
                 && (rmSlpPrtSt1.UpdateDateTime == rmSlpPrtSt2.UpdateDateTime)
                 && (rmSlpPrtSt1.LogicalDeleteCode == rmSlpPrtSt2.LogicalDeleteCode)
                 && (rmSlpPrtSt1.InqOriginalEpCd.Trim() == rmSlpPrtSt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (rmSlpPrtSt1.InqOriginalSecCd == rmSlpPrtSt2.InqOriginalSecCd)
                 && (rmSlpPrtSt1.InqOtherEpCd == rmSlpPrtSt2.InqOtherEpCd)
                 && (rmSlpPrtSt1.InqOtherSecCd == rmSlpPrtSt2.InqOtherSecCd)
                 && (rmSlpPrtSt1.PccCompanyCode == rmSlpPrtSt2.PccCompanyCode)
                 && (rmSlpPrtSt1.SlipPrtKind == rmSlpPrtSt2.SlipPrtKind)
                 && (rmSlpPrtSt1.SlipPrtSetPaperId == rmSlpPrtSt2.SlipPrtSetPaperId)
                 && (rmSlpPrtSt1.RmtSlpPrtDiv == rmSlpPrtSt2.RmtSlpPrtDiv)
                 && (rmSlpPrtSt1.TopMargin == rmSlpPrtSt2.TopMargin)
                 && (rmSlpPrtSt1.LeftMargin == rmSlpPrtSt2.LeftMargin));
        }
        /// <summary>
        /// リモート伝発設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のRmSlpPrtStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RmSlpPrtSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.RmtSlpPrtDiv != target.RmtSlpPrtDiv) resList.Add("RmtSlpPrtDiv");
            if (this.TopMargin != target.TopMargin) resList.Add("TopMargin");
            if (this.LeftMargin != target.LeftMargin) resList.Add("LeftMargin");

            return resList;
        }

        /// <summary>
        /// リモート伝発設定マスタ比較処理
        /// </summary>
        /// <param name="rmSlpPrtSt1">比較するRmSlpPrtStクラスのインスタンス</param>
        /// <param name="rmSlpPrtSt2">比較するRmSlpPrtStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RmSlpPrtSt rmSlpPrtSt1, RmSlpPrtSt rmSlpPrtSt2)
        {
            ArrayList resList = new ArrayList();
            if (rmSlpPrtSt1.CreateDateTime != rmSlpPrtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (rmSlpPrtSt1.UpdateDateTime != rmSlpPrtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rmSlpPrtSt1.LogicalDeleteCode != rmSlpPrtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rmSlpPrtSt1.InqOriginalEpCd.Trim() != rmSlpPrtSt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (rmSlpPrtSt1.InqOriginalSecCd != rmSlpPrtSt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (rmSlpPrtSt1.InqOtherEpCd != rmSlpPrtSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (rmSlpPrtSt1.InqOtherSecCd != rmSlpPrtSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (rmSlpPrtSt1.PccCompanyCode != rmSlpPrtSt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (rmSlpPrtSt1.SlipPrtKind != rmSlpPrtSt2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (rmSlpPrtSt1.SlipPrtSetPaperId != rmSlpPrtSt2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (rmSlpPrtSt1.RmtSlpPrtDiv != rmSlpPrtSt2.RmtSlpPrtDiv) resList.Add("RmtSlpPrtDiv");
            if (rmSlpPrtSt1.TopMargin != rmSlpPrtSt2.TopMargin) resList.Add("TopMargin");
            if (rmSlpPrtSt1.LeftMargin != rmSlpPrtSt2.LeftMargin) resList.Add("LeftMargin");

            return resList;
        }
    }
}
