//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM関連データデータパラメータ
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   IOWriteSCMReadWork
    /// <summary>
    ///                      SCMReadデータ(IOWriteSCMRead)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCMReadデータ(IOWriteSCMRead)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/06/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/02/26 ＳＣＭ既存不具合修正</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteSCMReadWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>問合せ番号</summary>
        /// <remarks>売上伝票番号がセットされていた場合は売上伝票番号優先</remarks>
        private Int64 _inquiryNumber;

        /// <summary>回答区分</summary>
        /// <remarks>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
        private Int32[] _answerDivCds;

        // -- ADD 2010/02/26 ---------------------------->>>
        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ・発注種別</summary>
        private Int32 _inqOrdDivCd = 0;

        /// <summary>問合せ・回答種別</summary>
        private Int32 _inqOrdAnsDivCd = 0;

        /// <summary>更新年月日(以降抽出)</summary>
        /// <remarks>指定年月日以降の更新年月日のデータ抽出(受信処理ScmSearch用)</remarks>
        private DateTime _updateDateOver = DateTime.MinValue;

        /// <summary>受信日時指定区分</summary>
        /// <remarks>1:受信日時がMinValueのデータを抽出(受信処理ScmSearch用)</remarks>
        private Int32 _receiveDTZeroDiv = 0;
        // -- ADD 2010/02/26 ----------------------------<<<

        // 2011/02/18 Add >>>
        /// <summary>キャンセル区分</summary>
        /// <remarks>0:キャンセルなし 1:キャンセルあり</remarks>
        private Int16[] _cancelDivs;
        // 2011/02/18 Add <<<

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティ</summary>
        /// <value>売上伝票番号がセットされていた場合は売上伝票番号優先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  AnswerDivCd
        /// <summary>回答区分プロパティ</summary>
        /// <value>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] AnswerDivCds
        {
            get { return _answerDivCds; }
            set { _answerDivCds = value; }
        }

        // -- ADD 2010/02/26 -------------------->>>
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

        /// public propaty name  :  InqOrdDivCd
        /// <summary>問合せ・発注種別プロパティ</summary>
        /// <value>1:問合せ 2:発注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  InqOrdAnsDivCd
        /// <summary>問発・回答種別プロパティ</summary>
        /// <value>1:問合せ・発注 2:回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発・回答種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOrdAnsDivCd
        {
            get { return _inqOrdAnsDivCd; }
            set { _inqOrdAnsDivCd = value; }
        }

        /// public propaty name  :  UpdateDateOver
        /// <summary>更新年月日(以降抽出)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateOver
        {
            get { return _updateDateOver; }
            set { _updateDateOver = value; }
        }

        /// public propaty name  :  ReceiveDTZeroDiv
        /// <summary>受信日時指定区分プロパティ</summary>
        /// <value>1:受信日時がMinValueのデータを抽出(受信処理ScmSearch用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceiveDTZeroDiv
        {
            get { return _receiveDTZeroDiv; }
            set { _receiveDTZeroDiv = value; }
        }

        // -- ADD 2010/02/26 --------------------<<<

        // 2011/02/18 Add >>>
        /// public propaty name  :  ReceiveDTZeroDiv
        /// <summary>受信日時指定区分プロパティ</summary>
        /// <value>1:受信日時がMinValueのデータを抽出(受信処理ScmSearch用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ・発注種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16[] CancelDivs
        {
            get { return _cancelDivs; }
            set { _cancelDivs = value; }
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// SCMReadデータ(IOWriteSCMRead)ワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteSCMReadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteSCMReadWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteSCMReadWork()
        {
        }

    }
}
