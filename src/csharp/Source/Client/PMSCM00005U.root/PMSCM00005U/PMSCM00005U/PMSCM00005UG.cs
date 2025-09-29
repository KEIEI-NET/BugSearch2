using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    #region 2012/04/24 TERASAKA DEL STA
    //    /// <summary>
    //    /// SCMのPushサーバーへパブリッシュ用データクラス
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>note             :   SCMのPushサーバーへパブリッシュ用データクラスです。</br>
    //    /// <br>Programmer       :   ZHANGYH</br>
    //    /// <br>Date             :   2011.07.12</br>
    //    /// </remarks>
    //    [Serializable]
    //    public class ScmPushData
    //    {
    //        /// <summary>送信元の企業コード</summary>
    //        private string _origEnterpriseCode;
    //
    //        /// <summary>送信元の拠点コード</summary>
    //        private string _origSectionCode;
    //
    //        /// <summary>返答フラグ</summary>
    //        /// <remarks>PM.NS側、SF.NSのPublishデータを受信したら、この回答フラグをTrueを設定して、SF.NSへ通知します</remarks>
    //        private bool _isReply;
    //
    //        #region property method
    //        /// <summary>
    //        /// 送信元の企業コード
    //        /// </summary>
    //        public string OrigEnterpriseCode
    //        {
    //            get
    //            {
    //                return _origEnterpriseCode;
    //            }
    //            set
    //            {
    //                _origEnterpriseCode = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 送信元の拠点コード
    //        /// </summary>
    //        public string OrigSectionCode
    //        {
    //            get
    //            {
    //                return _origSectionCode;
    //            }
    //            set
    //            {
    //                _origSectionCode = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 返答フラグ
    //        /// </summary>
    //        public bool IsReply
    //        {
    //            get
    //            {
    //                return _isReply;
    //            }
    //            set
    //            {
    //                _isReply = value;
    //            }
    //        }
    //
    //        #endregion property method
    //    }
    //
    //    /// <summary>
    //    /// SCMのPushサーバーへパブリッシュ用データクラス(リモート伝票発行用)
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>note             :   SCMのPushサーバーへパブリッシュ用データクラスです。(リモート伝票発行用)</br>
    //    /// <br>Programmer       :   ZHOUZY</br>
    //    /// <br>Date             :   2011.07.12</br>
    //    /// </remarks>
    //    [Serializable]
    //    public class ScmPushDataScmRtPrtDt {
    //
    //        /// <summary>問合せ元企業コード</summary>
    //        private string _inqOriginalEpCd;
    //
    //        /// <summary>問合せ元拠点コード</summary>
    //        private string _inqOriginalSecCd;
    //
    //        /// <summary>問合せ先企業コード</summary>
    //        private string _inqOtherEpCd;
    //
    //        /// <summary>問合せ先拠点コード</summary>
    //        private string _inqOtherSecCd;
    //
    //        //zhouzy update 2011.09.13 begin
    //        ///// <summary>問合せ番号</summary>
    //        //private Int64 _inquiryNumber;
    //
    //        /// <summary>更新年月日</summary>
    //        private Int32 _updateDate;
    //
    //        /// <summary>更新時分秒ミリ秒</summary>
    //        private Int32 _updateTime;
    //
    //        /// <summary>伝票印刷種別</summary>
    //        private Int32 _slipPrtKind;
    //
    //        /// <summary>売上伝票番号</summary>
    //        private string _salesSlipNum;
    //
    //        //zhouzy update 2011.09.13 end
    //
    //        ///// <summary>返答フラグ</summary>
    //        ///// <remarks>PM.NS側、SF.NSのPublishデータを受信したら、この回答フラグをTrueを設定して、SF.NSへ通知します</remarks>
    //        //private bool _isReply;
    //
    //        #region property method
    //        /// <summary>
    //        /// 問合せ元企業コード
    //        /// </summary>
    //        public string InqOriginalEpCd
    //        {
    //            get
    //            {
    //                return _inqOriginalEpCd;
    //            }
    //            set
    //            {
    //                _inqOriginalEpCd = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 問合せ元拠点コード
    //        /// </summary>
    //        public string InqOriginalSecCd
    //        {
    //            get
    //            {
    //                return _inqOriginalSecCd;
    //            }
    //            set
    //            {
    //                _inqOriginalSecCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// 問合せ先企業コード
    //        /// </summary>
    //        public string InqOtherEpCd
    //        {
    //            get
    //            {
    //                return _inqOtherEpCd;
    //            }
    //            set
    //            {
    //                _inqOtherEpCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// 問合せ先拠点コード
    //        /// </summary>
    //        public string InqOtherSecCd
    //        {
    //            get
    //            {
    //                return _inqOtherSecCd;
    //            }
    //            set
    //            {
    //                _inqOtherSecCd = value;
    //            }
    //        }
    //
    //
    //        //zhouzy update 2011.09.13 begin
    //        ///// <summary>
    //        ///// 問合せ番号
    //        ///// </summary>
    //        //public Int64 InquiryNumber
    //        //{
    //        //    get
    //        //    {
    //        //        return _inquiryNumber;
    //        //    }
    //        //    set
    //        //    {
    //        //        _inquiryNumber = value;
    //        //    }
    //        //}
    //
    //        /// <summary>
    //        /// 更新年月日
    //        /// </summary>
    //        public Int32 UpdateDate
    //        {
    //            get
    //            {
    //                return _updateDate;
    //            }
    //            set
    //            {
    //                _updateDate = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 更新時分秒ミリ秒
    //        /// </summary>
    //        public Int32 UpdateTime
    //        {
    //            get
    //            {
    //                return _updateTime;
    //            }
    //            set
    //            {
    //                _updateTime = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 伝票印刷種別
    //        /// </summary>
    //        public Int32 SlipPrtKind
    //        {
    //            get
    //            {
    //                return _slipPrtKind;
    //            }
    //            set
    //            {
    //                _slipPrtKind = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 売上伝票番号
    //        /// </summary>
    //        public string SalesSlipNum
    //        {
    //            get
    //            {
    //                return _salesSlipNum;
    //            }
    //            set
    //            {
    //                _salesSlipNum = value;
    //            }
    //        }
    //        //zhouzy update 2011.09.13 end
    //
    //        ///// <summary>
    //        ///// 返答フラグ
    //        ///// </summary>
    //        //public bool IsReply
    //        //{
    //        //    get
    //        //    {
    //        //        return _isReply;
    //        //    }
    //        //    set
    //        //    {
    //        //        _isReply = value;
    //        //    }
    //        //}
    //
    //        #endregion property method
    //    }
    //
    //    /// <summary>
    //    /// SCMのPushサーバーへパブリッシュ用データクラス(メッセージ送信用)
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>note             :   SCMのPushサーバーへパブリッシュ用データクラスです。(メッセージ送信用)</br>
    //    /// <br>Programmer       :   HUANGHX</br>
    //    /// <br>Date             :   2011.07.12</br>
    //    /// </remarks>
    //    [Serializable]
    //    public class ScmPushDataScmPccMailDt
    //    {
    //
    //        /// <summary>問合せ元企業コード</summary>
    //        private string _inqOriginalEpCd;
    //
    //        /// <summary>問合せ元拠点コード</summary>
    //        private string _inqOriginalSecCd;
    //
    //        /// <summary>問合せ先企業コード</summary>
    //        private string _inqOtherEpCd;
    //
    //        /// <summary>問合せ先拠点コード</summary>
    //        private string _inqOtherSecCd;
    //
    //        /// <summary>更新年月日</summary>
    //        /// <remarks>YYYYMMDD</remarks>
    //        private Int32 _updateDate;
    //
    //        /// <summary>更新時分秒ミリ秒</summary>
    //        /// <remarks>HHMMSSXXX</remarks>
    //        private Int32 _updateTime;
    //
    //        /// <summary>PCCメール件名</summary>
    //        /// <remarks>(半角全角混在)</remarks>
    //        private string _pccMailTitle = "";
    //
    //        /// <summary>PCCメール本文</summary>
    //        /// <remarks>(半角全角混在)</remarks>
    //        private string _pccMailDocCnts = "";
    //
    //        #region property method
    //        /// <summary>
    //        /// 問合せ元企業コード
    //        /// </summary>
    //        public string InqOriginalEpCd
    //        {
    //            get
    //            {
    //                return _inqOriginalEpCd;
    //            }
    //            set
    //            {
    //                _inqOriginalEpCd = value;
    //            }
    //        }
    //
    //        /// <summary>
    //        /// 問合せ元拠点コード
    //        /// </summary>
    //        public string InqOriginalSecCd
    //        {
    //            get
    //            {
    //                return _inqOriginalSecCd;
    //            }
    //            set
    //            {
    //                _inqOriginalSecCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// 問合せ先企業コード
    //        /// </summary>
    //        public string InqOtherEpCd
    //        {
    //            get
    //            {
    //                return _inqOtherEpCd;
    //            }
    //            set
    //            {
    //                _inqOtherEpCd = value;
    //            }
    //        }
    //
    //
    //        /// <summary>
    //        /// 問合せ先拠点コード
    //        /// </summary>
    //        public string InqOtherSecCd
    //        {
    //            get
    //            {
    //                return _inqOtherSecCd;
    //            }
    //            set
    //            {
    //                _inqOtherSecCd = value;
    //            }
    //        }
    //
    //        /// public propaty name  :  UpdateDate
    //        /// <summary>更新年月日プロパティ</summary>
    //        /// <value>YYYYMMDD</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   更新年月日プロパティ</br>
    //        /// <br>Programer        :   自動生成</br>
    //        /// </remarks>
    //        public Int32 UpdateDate
    //        {
    //            get { return _updateDate; }
    //            set { _updateDate = value; }
    //        }
    //
    //        /// public propaty name  :  UpdateTime
    //        /// <summary>更新時分秒ミリ秒プロパティ</summary>
    //        /// <value>HHMMSSXXX</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   更新時分秒ミリ秒プロパティ</br>
    //        /// <br>Programer        :   自動生成</br>
    //        /// </remarks>
    //        public Int32 UpdateTime
    //        {
    //            get { return _updateTime; }
    //            set { _updateTime = value; }
    //        }
    //
    //        /// public propaty name  :  PccMailTitle
    //        /// <summary>PCCメール件名プロパティ</summary>
    //        /// <value>(半角全角混在)</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   PCCメール件名プロパティ</br>
    //        /// <br>Programer        :   自動生成</br>
    //        /// </remarks>
    //        public string PccMailTitle
    //        {
    //            get { return _pccMailTitle; }
    //            set { _pccMailTitle = value; }
    //        }
    //
    //        /// public propaty name  :  PccMailDocCnts
    //        /// <summary>PCCメール本文プロパティ</summary>
    //        /// <value>(半角全角混在)</value>
    //        /// ----------------------------------------------------------------------
    //        /// <remarks>
    //        /// <br>note             :   PCCメール本文プロパティ</br>
    //        /// <br>Programer        :   自動生成</br>
    //        /// </remarks>
    //        public string PccMailDocCnts
    //        {
    //            get { return _pccMailDocCnts; }
    //            set { _pccMailDocCnts = value; }
    //        }
    //
    //        #endregion property method
    //    }
    #endregion
}
