using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RmSlpPrtStWork
    /// <summary>
    ///                      リモート伝発設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   リモート伝発設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/09/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/9/15  岩本　勇</br>
    /// <br>                 :   12,13を追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RmSlpPrtStWork : IFileHeader
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
        /// <remarks>10:見積書,20:指示書（注文書）,21:承り書,30:納品書,100:ワークシート,110:ボディ寸法図</remarks>
        private Int32 _slipPrtKind;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>伝票印刷設定用</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>リモート伝発区分</summary>
        /// <remarks>0:発行しない, 1:発行する</remarks>
        private Int32 _rmtSlpPrtDiv;

        /// <summary>上余白</summary>
        /// <remarks>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</remarks>
        private Double _topMargin;

        /// <summary>左余白</summary>
        /// <remarks>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</remarks>
        private Double _leftMargin;

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
        /// <value>10:見積書,20:指示書（注文書）,21:承り書,30:納品書,100:ワークシート,110:ボディ寸法図</value>
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

        /// public propaty name  :  TopMargin
        /// <summary>上余白プロパティ</summary>
        /// <value>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上余白プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        /// public propaty name  :  LeftMargin
        /// <summary>左余白プロパティ</summary>
        /// <value>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   左余白プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }


        /// <summary>
        /// リモート伝発設定ワークコンストラクタ
        /// </summary>
        /// <returns>RmSlpPrtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RmSlpPrtStWork()
        {
        }

        /// <summary>
        /// リモート伝発設定ワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="pccCompanyCode">PCC自社コード(PMの得意先コード)</param>
        /// <param name="slipPrtKind">伝票印刷種別(10:見積書,20:指示書（注文書）,21:承り書,30:納品書,100:ワークシート,110:ボディ寸法図)</param>
        /// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(伝票印刷設定用)</param>
        /// <param name="rmtSlpPrtDiv">リモート伝発区分(0:発行しない, 1:発行する)</param>
        /// <param name="topMargin">上余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
        /// <param name="leftMargin">左余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
        /// <returns>RmSlpPrtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RmSlpPrtStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, Int32 slipPrtKind, string slipPrtSetPaperId, Int32 rmtSlpPrtDiv, Double topMargin, Double leftMargin)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();	//@@@@20230303
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
        /// リモート伝発設定ワーク複製処理
        /// </summary>
        /// <returns>RmSlpPrtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRmSlpPrtStWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RmSlpPrtStWork Clone()
        {
            return new RmSlpPrtStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._slipPrtKind, this._slipPrtSetPaperId, this._rmtSlpPrtDiv, this._topMargin, this._leftMargin);//@@@@20230303
        }

        /// <summary>
        /// リモート伝発設定ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のRmSlpPrtStWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(RmSlpPrtStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())	//@@@@20230303
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
        /// リモート伝発設定ワーク比較処理
        /// </summary>
        /// <param name="rmSlpPrtSt1">
        ///                    比較するRmSlpPrtStWorkクラスのインスタンス
        /// </param>
        /// <param name="rmSlpPrtSt2">比較するRmSlpPrtStWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(RmSlpPrtStWork rmSlpPrtSt1, RmSlpPrtStWork rmSlpPrtSt2)
        {
            return ((rmSlpPrtSt1.CreateDateTime == rmSlpPrtSt2.CreateDateTime)
                 && (rmSlpPrtSt1.UpdateDateTime == rmSlpPrtSt2.UpdateDateTime)
                 && (rmSlpPrtSt1.LogicalDeleteCode == rmSlpPrtSt2.LogicalDeleteCode)
                 && (rmSlpPrtSt1.InqOriginalEpCd.Trim() == rmSlpPrtSt2.InqOriginalEpCd.Trim())	//@@@@20230303
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
        /// リモート伝発設定ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のRmSlpPrtStWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(RmSlpPrtStWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
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
        /// リモート伝発設定ワーク比較処理
        /// </summary>
        /// <param name="rmSlpPrtSt1">比較するRmSlpPrtStWorkクラスのインスタンス</param>
        /// <param name="rmSlpPrtSt2">比較するRmSlpPrtStWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(RmSlpPrtStWork rmSlpPrtSt1, RmSlpPrtStWork rmSlpPrtSt2)
        {
            ArrayList resList = new ArrayList();
            if (rmSlpPrtSt1.CreateDateTime != rmSlpPrtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (rmSlpPrtSt1.UpdateDateTime != rmSlpPrtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rmSlpPrtSt1.LogicalDeleteCode != rmSlpPrtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rmSlpPrtSt1.InqOriginalEpCd.Trim() != rmSlpPrtSt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
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

        #region IFileHeader メンバ


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コード</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コード</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }
        #endregion

       
    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RmSlpPrtStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RmSlpPrtStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RmSlpPrtStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RmSlpPrtStWork || graph is ArrayList || graph is RmSlpPrtStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RmSlpPrtStWork).FullName));

            if (graph != null && graph is RmSlpPrtStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RmSlpPrtStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RmSlpPrtStWork[])graph).Length;
            }
            else if (graph is RmSlpPrtStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //PCC自社コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PccCompanyCode
            //伝票印刷種別
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrtKind
            //伝票印刷設定用帳票ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //リモート伝発区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RmtSlpPrtDiv
            //上余白
            serInfo.MemberInfo.Add(typeof(Double)); //TopMargin
            //左余白
            serInfo.MemberInfo.Add(typeof(Double)); //LeftMargin


            serInfo.Serialize(writer, serInfo);
            if (graph is RmSlpPrtStWork)
            {
                RmSlpPrtStWork temp = (RmSlpPrtStWork)graph;

                SetRmSlpPrtStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RmSlpPrtStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RmSlpPrtStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RmSlpPrtStWork temp in lst)
                {
                    SetRmSlpPrtStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RmSlpPrtStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  RmSlpPrtStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRmSlpPrtStWork(System.IO.BinaryWriter writer, RmSlpPrtStWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //PCC自社コード
            writer.Write(temp.PccCompanyCode);
            //伝票印刷種別
            writer.Write(temp.SlipPrtKind);
            //伝票印刷設定用帳票ID
            writer.Write(temp.SlipPrtSetPaperId);
            //リモート伝発区分
            writer.Write(temp.RmtSlpPrtDiv);
            //上余白
            writer.Write(temp.TopMargin);
            //左余白
            writer.Write(temp.LeftMargin);

        }

        /// <summary>
        ///  RmSlpPrtStWorkインスタンス取得
        /// </summary>
        /// <returns>RmSlpPrtStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RmSlpPrtStWork GetRmSlpPrtStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RmSlpPrtStWork temp = new RmSlpPrtStWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //PCC自社コード
            temp.PccCompanyCode = reader.ReadInt32();
            //伝票印刷種別
            temp.SlipPrtKind = reader.ReadInt32();
            //伝票印刷設定用帳票ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //リモート伝発区分
            temp.RmtSlpPrtDiv = reader.ReadInt32();
            //上余白
            temp.TopMargin = reader.ReadDouble();
            //左余白
            temp.LeftMargin = reader.ReadDouble();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>RmSlpPrtStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RmSlpPrtStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RmSlpPrtStWork temp = GetRmSlpPrtStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (RmSlpPrtStWork[])lst.ToArray(typeof(RmSlpPrtStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
