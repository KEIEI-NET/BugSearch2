using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Propose_Para_SCM
    /// <summary>
    ///                      提案商品起動パラメータクラス（SCM企業拠点連結）
    /// </summary>
    /// <remarks>
    /// <br>note             :   提案商品起動パラメータクラス（SCM企業拠点連結）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/5/24</br>
    /// <br>Genarated Date   :   2016/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2016/6/2  中村仁</br>
    /// <br>                 :   連結元企業名称</br>
    /// <br>                 :   連結先企業名称</br>
    /// <br>                 :   を追加</br>
    /// </remarks>
    public class Propose_Para_SCM
    {
        /// <summary>連結元企業コード</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>連結元企業名称</summary>
        private string _cnectOriginalEpNm = "";

        /// <summary>連結元拠点コード</summary>
        private string _cnectOriginalSecCd = "";

        /// <summary>連結元拠点ガイド名称</summary>
        private string _cnectOriginalSecNm = "";

        /// <summary>連結先企業コード</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>連結先企業名称</summary>
        private string _cnectOtherEpNm = "";

        /// <summary>連結先拠点コード</summary>
        private string _cnectOtherSecCd = "";

        /// <summary>連結先拠点ガイド名称</summary>
        private string _cnectOtherSecNm = "";

        /// <summary>識別区分</summary>
        /// <remarks>0:連結有効 1:連結無効</remarks>
        private Int32 _discDivCd;

        /// <summary>通信方式(SCM)</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int16 _scmCommMethod;

        /// <summary>通信方式(PCC-UOE)</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int16 _pccUoeCommMethod;

        /// <summary>通信方式(RC-SCM)</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int16 _rcScmCommMethod;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>優先表示システム</summary>
        /// <remarks>10：PMを優先表示、11：RCを優先表示</remarks>
        private Int16 _prDispSystem;

        /// <summary>タブレット使用区分</summary>
        /// <remarks>0：使用しない,1：使用する</remarks>
        private Int32 _tabUseDiv;

        /// <summary>新旧切替ステータス</summary>
        /// <remarks>0:旧,1:新</remarks>
        private Int32 _oldNewStatus;

        /// <summary>通常/手動ステータス</summary>
        /// <remarks>0:通常,1:手動</remarks>
        private Int32 _usualMnalStatus;

        /// <summary>パーツマンDBID</summary>
        /// <remarks>パーツマン拠点DBサーバーのID</remarks>
        private string _pmDBId = "";

        /// <summary>パーツマンアップロード区分</summary>
        /// <remarks>0:なし,1:アップロード済み</remarks>
        private Int32 _pmUploadDiv;


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

        /// public propaty name  :  CnectOriginalEpNm
        /// <summary>連結元企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalEpNm
        {
            get { return _cnectOriginalEpNm; }
            set { _cnectOriginalEpNm = value; }
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

        /// public propaty name  :  CnectOriginalSecNm
        /// <summary>連結元拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalSecNm
        {
            get { return _cnectOriginalSecNm; }
            set { _cnectOriginalSecNm = value; }
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

        /// public propaty name  :  CnectOtherEpNm
        /// <summary>連結先企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherEpNm
        {
            get { return _cnectOtherEpNm; }
            set { _cnectOtherEpNm = value; }
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

        /// public propaty name  :  CnectOtherSecNm
        /// <summary>連結先拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherSecNm
        {
            get { return _cnectOtherSecNm; }
            set { _cnectOtherSecNm = value; }
        }

        /// public propaty name  :  DiscDivCd
        /// <summary>識別区分プロパティ</summary>
        /// <value>0:連結有効 1:連結無効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   識別区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DiscDivCd
        {
            get { return _discDivCd; }
            set { _discDivCd = value; }
        }

        /// public propaty name  :  ScmCommMethod
        /// <summary>通信方式(SCM)プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信方式(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ScmCommMethod
        {
            get { return _scmCommMethod; }
            set { _scmCommMethod = value; }
        }

        /// public propaty name  :  PccUoeCommMethod
        /// <summary>通信方式(PCC-UOE)プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信方式(PCC-UOE)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PccUoeCommMethod
        {
            get { return _pccUoeCommMethod; }
            set { _pccUoeCommMethod = value; }
        }

        /// public propaty name  :  RcScmCommMethod
        /// <summary>通信方式(RC-SCM)プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信方式(RC-SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 RcScmCommMethod
        {
            get { return _rcScmCommMethod; }
            set { _rcScmCommMethod = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  PrDispSystem
        /// <summary>優先表示システムプロパティ</summary>
        /// <value>10：PMを優先表示、11：RCを優先表示</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先表示システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PrDispSystem
        {
            get { return _prDispSystem; }
            set { _prDispSystem = value; }
        }

        /// public propaty name  :  TabUseDiv
        /// <summary>タブレット使用区分プロパティ</summary>
        /// <value>0：使用しない,1：使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   タブレット使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TabUseDiv
        {
            get { return _tabUseDiv; }
            set { _tabUseDiv = value; }
        }

        /// public propaty name  :  OldNewStatus
        /// <summary>新旧切替ステータスプロパティ</summary>
        /// <value>0:旧,1:新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新旧切替ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OldNewStatus
        {
            get { return _oldNewStatus; }
            set { _oldNewStatus = value; }
        }

        /// public propaty name  :  UsualMnalStatus
        /// <summary>通常/手動ステータスプロパティ</summary>
        /// <value>0:通常,1:手動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通常/手動ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UsualMnalStatus
        {
            get { return _usualMnalStatus; }
            set { _usualMnalStatus = value; }
        }

        /// public propaty name  :  PmDBId
        /// <summary>パーツマンDBIDプロパティ</summary>
        /// <value>パーツマン拠点DBサーバーのID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パーツマンDBIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmDBId
        {
            get { return _pmDBId; }
            set { _pmDBId = value; }
        }

        /// public propaty name  :  PmUploadDiv
        /// <summary>パーツマンアップロード区分プロパティ</summary>
        /// <value>0:なし,1:アップロード済み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パーツマンアップロード区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PmUploadDiv
        {
            get { return _pmUploadDiv; }
            set { _pmUploadDiv = value; }
        }


        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）コンストラクタ
        /// </summary>
        /// <returns>Propose_Para_SCMクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Para_SCMクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Propose_Para_SCM()
        {
        }

        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）コンストラクタ
        /// </summary>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cnectOriginalEpNm">連結元企業名称</param>
        /// <param name="cnectOriginalSecCd">連結元拠点コード</param>
        /// <param name="cnectOriginalSecNm">連結元拠点ガイド名称</param>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="cnectOtherEpNm">連結先企業名称</param>
        /// <param name="cnectOtherSecCd">連結先拠点コード</param>
        /// <param name="cnectOtherSecNm">連結先拠点ガイド名称</param>
        /// <param name="discDivCd">識別区分(0:連結有効 1:連結無効)</param>
        /// <param name="scmCommMethod">通信方式(SCM)(0:しない,1:する)</param>
        /// <param name="pccUoeCommMethod">通信方式(PCC-UOE)(0:しない,1:する)</param>
        /// <param name="rcScmCommMethod">通信方式(RC-SCM)(0:しない,1:する)</param>
        /// <param name="displayOrder">表示順位</param>
        /// <param name="prDispSystem">優先表示システム(10：PMを優先表示、11：RCを優先表示)</param>
        /// <param name="tabUseDiv">タブレット使用区分(0：使用しない,1：使用する)</param>
        /// <param name="oldNewStatus">新旧切替ステータス(0:旧,1:新)</param>
        /// <param name="usualMnalStatus">通常/手動ステータス(0:通常,1:手動)</param>
        /// <param name="pmDBId">パーツマンDBID(パーツマン拠点DBサーバーのID)</param>
        /// <param name="pmUploadDiv">パーツマンアップロード区分(0:なし,1:アップロード済み)</param>
        /// <returns>Propose_Para_SCMクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Para_SCMクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Propose_Para_SCM(string cnectOriginalEpCd, string cnectOriginalEpNm, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherEpNm, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int16 rcScmCommMethod, Int32 displayOrder, Int16 prDispSystem, Int32 tabUseDiv, Int32 oldNewStatus, Int32 usualMnalStatus, string pmDBId, Int32 pmUploadDiv)
        {
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalEpNm = cnectOriginalEpNm;
            this._cnectOriginalSecCd = cnectOriginalSecCd;
            this._cnectOriginalSecNm = cnectOriginalSecNm;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherEpNm = cnectOtherEpNm;
            this._cnectOtherSecCd = cnectOtherSecCd;
            this._cnectOtherSecNm = cnectOtherSecNm;
            this._discDivCd = discDivCd;
            this._scmCommMethod = scmCommMethod;
            this._pccUoeCommMethod = pccUoeCommMethod;
            this._rcScmCommMethod = rcScmCommMethod;
            this._displayOrder = displayOrder;
            this._prDispSystem = prDispSystem;
            this._tabUseDiv = tabUseDiv;
            this._oldNewStatus = oldNewStatus;
            this._usualMnalStatus = usualMnalStatus;
            this._pmDBId = pmDBId;
            this._pmUploadDiv = pmUploadDiv;

        }

        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）複製処理
        /// </summary>
        /// <returns>Propose_Para_SCMクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPropose_Para_SCMクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Propose_Para_SCM Clone()
        {
            return new Propose_Para_SCM(this._cnectOriginalEpCd, this._cnectOriginalEpNm, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherEpNm, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._rcScmCommMethod, this._displayOrder, this._prDispSystem, this._tabUseDiv, this._oldNewStatus, this._usualMnalStatus, this._pmDBId, this._pmUploadDiv);
        }

        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）比較処理
        /// </summary>
        /// <param name="target">比較対象のPropose_Para_SCMクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Para_SCMクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(Propose_Para_SCM target)
        {
            return ((this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalEpNm == target.CnectOriginalEpNm)
                 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
                 && (this.CnectOriginalSecNm == target.CnectOriginalSecNm)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.CnectOtherEpNm == target.CnectOtherEpNm)
                 && (this.CnectOtherSecCd == target.CnectOtherSecCd)
                 && (this.CnectOtherSecNm == target.CnectOtherSecNm)
                 && (this.DiscDivCd == target.DiscDivCd)
                 && (this.ScmCommMethod == target.ScmCommMethod)
                 && (this.PccUoeCommMethod == target.PccUoeCommMethod)
                 && (this.RcScmCommMethod == target.RcScmCommMethod)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.PrDispSystem == target.PrDispSystem)
                 && (this.TabUseDiv == target.TabUseDiv)
                 && (this.OldNewStatus == target.OldNewStatus)
                 && (this.UsualMnalStatus == target.UsualMnalStatus)
                 && (this.PmDBId == target.PmDBId)
                 && (this.PmUploadDiv == target.PmUploadDiv));
        }

        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）比較処理
        /// </summary>
        /// <param name="propose_Para_SCM1">
        ///                    比較するPropose_Para_SCMクラスのインスタンス
        /// </param>
        /// <param name="propose_Para_SCM2">比較するPropose_Para_SCMクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Para_SCMクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(Propose_Para_SCM propose_Para_SCM1, Propose_Para_SCM propose_Para_SCM2)
        {
            return ((propose_Para_SCM1.CnectOriginalEpCd == propose_Para_SCM2.CnectOriginalEpCd)
                 && (propose_Para_SCM1.CnectOriginalEpNm == propose_Para_SCM2.CnectOriginalEpNm)
                 && (propose_Para_SCM1.CnectOriginalSecCd == propose_Para_SCM2.CnectOriginalSecCd)
                 && (propose_Para_SCM1.CnectOriginalSecNm == propose_Para_SCM2.CnectOriginalSecNm)
                 && (propose_Para_SCM1.CnectOtherEpCd == propose_Para_SCM2.CnectOtherEpCd)
                 && (propose_Para_SCM1.CnectOtherEpNm == propose_Para_SCM2.CnectOtherEpNm)
                 && (propose_Para_SCM1.CnectOtherSecCd == propose_Para_SCM2.CnectOtherSecCd)
                 && (propose_Para_SCM1.CnectOtherSecNm == propose_Para_SCM2.CnectOtherSecNm)
                 && (propose_Para_SCM1.DiscDivCd == propose_Para_SCM2.DiscDivCd)
                 && (propose_Para_SCM1.ScmCommMethod == propose_Para_SCM2.ScmCommMethod)
                 && (propose_Para_SCM1.PccUoeCommMethod == propose_Para_SCM2.PccUoeCommMethod)
                 && (propose_Para_SCM1.RcScmCommMethod == propose_Para_SCM2.RcScmCommMethod)
                 && (propose_Para_SCM1.DisplayOrder == propose_Para_SCM2.DisplayOrder)
                 && (propose_Para_SCM1.PrDispSystem == propose_Para_SCM2.PrDispSystem)
                 && (propose_Para_SCM1.TabUseDiv == propose_Para_SCM2.TabUseDiv)
                 && (propose_Para_SCM1.OldNewStatus == propose_Para_SCM2.OldNewStatus)
                 && (propose_Para_SCM1.UsualMnalStatus == propose_Para_SCM2.UsualMnalStatus)
                 && (propose_Para_SCM1.PmDBId == propose_Para_SCM2.PmDBId)
                 && (propose_Para_SCM1.PmUploadDiv == propose_Para_SCM2.PmUploadDiv));
        }
        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）比較処理
        /// </summary>
        /// <param name="target">比較対象のPropose_Para_SCMクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Para_SCMクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(Propose_Para_SCM target)
        {
            ArrayList resList = new ArrayList();
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalEpNm != target.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (this.CnectOriginalSecNm != target.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.CnectOtherEpNm != target.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (this.CnectOtherSecCd != target.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (this.CnectOtherSecNm != target.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
            if (this.DiscDivCd != target.DiscDivCd) resList.Add("DiscDivCd");
            if (this.ScmCommMethod != target.ScmCommMethod) resList.Add("ScmCommMethod");
            if (this.PccUoeCommMethod != target.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            if (this.RcScmCommMethod != target.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.PrDispSystem != target.PrDispSystem) resList.Add("PrDispSystem");
            if (this.TabUseDiv != target.TabUseDiv) resList.Add("TabUseDiv");
            if (this.OldNewStatus != target.OldNewStatus) resList.Add("OldNewStatus");
            if (this.UsualMnalStatus != target.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (this.PmDBId != target.PmDBId) resList.Add("PmDBId");
            if (this.PmUploadDiv != target.PmUploadDiv) resList.Add("PmUploadDiv");

            return resList;
        }

        /// <summary>
        /// 提案商品起動パラメータクラス（SCM企業拠点連結）比較処理
        /// </summary>
        /// <param name="propose_Para_SCM1">比較するPropose_Para_SCMクラスのインスタンス</param>
        /// <param name="propose_Para_SCM2">比較するPropose_Para_SCMクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Propose_Para_SCMクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(Propose_Para_SCM propose_Para_SCM1, Propose_Para_SCM propose_Para_SCM2)
        {
            ArrayList resList = new ArrayList();
            if (propose_Para_SCM1.CnectOriginalEpCd != propose_Para_SCM2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (propose_Para_SCM1.CnectOriginalEpNm != propose_Para_SCM2.CnectOriginalEpNm) resList.Add("CnectOriginalEpNm");
            if (propose_Para_SCM1.CnectOriginalSecCd != propose_Para_SCM2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (propose_Para_SCM1.CnectOriginalSecNm != propose_Para_SCM2.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
            if (propose_Para_SCM1.CnectOtherEpCd != propose_Para_SCM2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (propose_Para_SCM1.CnectOtherEpNm != propose_Para_SCM2.CnectOtherEpNm) resList.Add("CnectOtherEpNm");
            if (propose_Para_SCM1.CnectOtherSecCd != propose_Para_SCM2.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (propose_Para_SCM1.CnectOtherSecNm != propose_Para_SCM2.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
            if (propose_Para_SCM1.DiscDivCd != propose_Para_SCM2.DiscDivCd) resList.Add("DiscDivCd");
            if (propose_Para_SCM1.ScmCommMethod != propose_Para_SCM2.ScmCommMethod) resList.Add("ScmCommMethod");
            if (propose_Para_SCM1.PccUoeCommMethod != propose_Para_SCM2.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            if (propose_Para_SCM1.RcScmCommMethod != propose_Para_SCM2.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (propose_Para_SCM1.DisplayOrder != propose_Para_SCM2.DisplayOrder) resList.Add("DisplayOrder");
            if (propose_Para_SCM1.PrDispSystem != propose_Para_SCM2.PrDispSystem) resList.Add("PrDispSystem");
            if (propose_Para_SCM1.TabUseDiv != propose_Para_SCM2.TabUseDiv) resList.Add("TabUseDiv");
            if (propose_Para_SCM1.OldNewStatus != propose_Para_SCM2.OldNewStatus) resList.Add("OldNewStatus");
            if (propose_Para_SCM1.UsualMnalStatus != propose_Para_SCM2.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (propose_Para_SCM1.PmDBId != propose_Para_SCM2.PmDBId) resList.Add("PmDBId");
            if (propose_Para_SCM1.PmUploadDiv != propose_Para_SCM2.PmUploadDiv) resList.Add("PmUploadDiv");

            return resList;
        }
    }
}
