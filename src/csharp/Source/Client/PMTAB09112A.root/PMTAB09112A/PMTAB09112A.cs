//**********************************************************************//
// システム         ：.NSシリーズ                                       //
// プログラム名称   ：PMTAB全体設定（拠点別）マスタ                     //
// プログラム概要   ：PMTAB全体設定（拠点別）の登録・修正・削除を行う   //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 管理番号  10902622-01     作成担当：許培珠
// 修正日    2013/05/31　    修正内容：新規作成
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// タブレット全体設定マスタ(得意先別)テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : タブレット全体設定マスタ(得意先別)テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 許培珠</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PmTabTtlStCustAcs 
    {
        # region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        IPmTabTtlStCustDB _ipmTabTtlStCustDB = null;

        // ガイド設定ファイル名
        private const string GUIDE_XML_FILENAME = "PMTABTTLSTCUSTGUIDEPARENT.XML";   // XMLファイル名

        // ガイドパラメータ
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // 企業コード

        // ガイド項目タイプ
        private const string GUIDE_TYPE_STR = "System.String";              // String型

        // ガイド項目名
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";                // 得意先コード
        private const string GUIDE_CUSTOMERCODENM_TITLE = "CustomerGuideNm";                // 得意先名称

        # endregion

        # region Constructor

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PmTabTtlStCustAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._ipmTabTtlStCustDB = (IPmTabTtlStCustDB)MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStCustDB = null;
            }
            
        }

        # endregion

        #region GetOnlineMode

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._ipmTabTtlStCustDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)登録・更新処理
        /// </summary>
        /// <param name="pmTabTtlStCust">タブレット全体設定マスタ(得意先別)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)情報の登録・更新を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Write(ref PmTabTtlStCust pmTabTtlStCust)
        {
            // タブレット全体設定マスタ(得意先別)クラスからタブレット全体設定マスタ(得意先別)ワーカークラスにメンバコピー
            PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);

            ArrayList paraList = new ArrayList();

            paraList.Add(pmTabTtlStCustWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //タブレット全体設定マスタ(得意先別)書き込み
                status = this._ipmTabTtlStCustDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    pmTabTtlStCustWork = (PmTabTtlStCustWork)paraList[0];

                    // クラス内メンバコピー
                    pmTabTtlStCust = CopyToSubSectionFromSubSectionWork(pmTabTtlStCustWork);

                }
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)論理削除処理
        /// </summary>
        /// <param name="pmTabTtlStCust">タブレット全体設定マスタ(得意先別)オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)情報の論理削除を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int LogicalDelete(ref PmTabTtlStCust pmTabTtlStCust)
        {
            int status = 0;

            try
            {
                // タブレット全体設定マスタ(得意先別)変換
                ArrayList paraLst = new ArrayList();
                PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);
                paraLst.Add(pmTabTtlStCustWork);
                object paraObj = paraLst;

                // 論理削除
                status = this._ipmTabTtlStCustDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStCustWork = (PmTabTtlStCustWork)paraLst[0];
                    // クラス内メンバコピー
                    pmTabTtlStCust = CopyToSubSectionFromSubSectionWork(pmTabTtlStCustWork);

                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStCustDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)論理削除復活処理
        /// </summary>
        /// <param name="pmTabTtlStCust">タブレット全体設定マスタ(得意先別)オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)情報の復活を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Revival(ref PmTabTtlStCust pmTabTtlStCust)
        {
            try
            {
                PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(pmTabTtlStCustWork);

                object paraObj = paraLst;

                // 復活処理
                int status = this._ipmTabTtlStCustDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStCustWork = (PmTabTtlStCustWork)paraLst[0];
                    // クラス内メンバコピー
                    pmTabTtlStCust = CopyToSubSectionFromSubSectionWork(pmTabTtlStCustWork);

                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStCustDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)物理削除処理
        /// </summary>
        /// <param name="pmTabTtlStCust">タブレット全体設定マスタ(得意先別)オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)情報の物理削除を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete(PmTabTtlStCust pmTabTtlStCust)
        {
            try
            {
                PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(pmTabTtlStCustWork);

                // タブレット全体設定マスタ(得意先別)物理削除
                int status = this._ipmTabTtlStCustDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStCustDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)全検索処理(得意先絞込み)（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="customercode">得意先コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当得意先での全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string customercode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, customercode, 0, null);
        }

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// タブレット全体設定マスタ(得意先別)検索処理(得意先絞込み)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSubSectionがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customercode">得意先コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevSubSection">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)の検索処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string customercode, ConstantManagement.LogicalMode logicalMode, PmTabTtlStCust prevSubSection)
        {
            // 初期化
            retList = new ArrayList();
            retTotalCnt = 0;

            // 戻り値リスト
            ArrayList wkList = new ArrayList();
            
            // 検索条件セット
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
            if (prevSubSection != null) pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(prevSubSection);

            pmTabTtlStCustWork.EnterpriseCode = enterpriseCode;
            pmTabTtlStCustWork.CustomerCode = ToInt(customercode);

            // Searchパラメータ
            ArrayList paraList = new ArrayList();
            paraList.Add( pmTabTtlStCustWork );
            object paraobj = paraList;

            // 検索
            object retobj = null;

			int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			// リモート
            status_o = this._ipmTabTtlStCustDB.Search(out retobj, paraobj, 0, logicalMode);

            // 検索結果判定
            switch (status_o) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL: 
                    wkList = retobj as ArrayList;

                    if (wkList != null) {
                        foreach (PmTabTtlStCustWork wkLineupWork in wkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((customercode.TrimEnd() == "") || (wkLineupWork.CustomerCode.ToString().TrimEnd() == customercode.TrimEnd()) || (wkLineupWork.CustomerCode == 0) ))
                            {
                                //メンバコピー
                                retList.Add(CopyToSubSectionFromSubSectionWork(wkLineupWork));
                            }
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF: 
                    break;
                default: 
                    return status_o;
            }

            return status_o;
        }

        #endregion

        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバーコピー処理（タブレット全体設定マスタ(得意先別)ワーククラス⇒タブレット全体設定マスタ(得意先別)）
        /// </summary>
        /// <param name="pmTabTtlStCustWork">タブレット全体設定マスタ(得意先別)ワーククラス</param>
        /// <returns>タブレット全体設定マスタ(得意先別)</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)ワーククラスからタブレット全体設定マスタ(得意先別)へメンバーのコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCust CopyToSubSectionFromSubSectionWork(PmTabTtlStCustWork pmTabTtlStCustWork)
        {
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            pmTabTtlStCust.CreateDateTime = pmTabTtlStCustWork.CreateDateTime;
            pmTabTtlStCust.UpdateDateTime = pmTabTtlStCustWork.UpdateDateTime;
            pmTabTtlStCust.FileHeaderGuid = pmTabTtlStCustWork.FileHeaderGuid;
            pmTabTtlStCust.LogicalDeleteCode = pmTabTtlStCustWork.LogicalDeleteCode;
            pmTabTtlStCust.EnterpriseCode = pmTabTtlStCustWork.EnterpriseCode;

            pmTabTtlStCust.LogicalDeleteCode = pmTabTtlStCustWork.LogicalDeleteCode;
            pmTabTtlStCust.CustomerCode = pmTabTtlStCustWork.CustomerCode.ToString();
            pmTabTtlStCust.CustomerNm = pmTabTtlStCustWork.CustomerNm;
            pmTabTtlStCust.BlpSendDiv = pmTabTtlStCustWork.BlpSendDiv;

            return pmTabTtlStCust;
        }

        /// <summary>
        /// クラスメンバーコピー処理（タブレット全体設定マスタ(得意先別)⇒タブレット全体設定マスタ(得意先別)ワーククラス）
        /// </summary>
        /// <param name="pmTabTtlStCust">タブレット全体設定マスタ(得意先別)クラス</param>
        /// <returns>タブレット全体設定マスタ(得意先別)ワーク</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)からタブレット全体設定マスタ(得意先別)ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCustWork CopyToSubSectionWorkFromSubSection(PmTabTtlStCust pmTabTtlStCust)
        {
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();

            pmTabTtlStCustWork.CreateDateTime = pmTabTtlStCust.CreateDateTime;
            pmTabTtlStCustWork.UpdateDateTime = pmTabTtlStCust.UpdateDateTime;
            pmTabTtlStCustWork.EnterpriseCode = pmTabTtlStCust.EnterpriseCode;
            pmTabTtlStCustWork.FileHeaderGuid = pmTabTtlStCust.FileHeaderGuid;

            pmTabTtlStCustWork.LogicalDeleteCode = pmTabTtlStCust.LogicalDeleteCode;
            pmTabTtlStCustWork.CustomerCode = this.ToInt(pmTabTtlStCust.CustomerCode);
            pmTabTtlStCustWork.BlpSendDiv = pmTabTtlStCust.BlpSendDiv;

            return pmTabTtlStCustWork;
        }

        /// <summary>
        /// クラスメンバコピー処理 (ガイド選択データ)
        /// </summary>
        /// <param name="guideData">ガイド選択データ</param>
        /// <returns>マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ガイド選択データからマスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCust CopyToSubSectionFromGuideData(Hashtable guideData)
        {
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            pmTabTtlStCust.CustomerCode = (string)guideData[GUIDE_CUSTOMERCODE_TITLE];                     // 得意先コード

            return pmTabTtlStCust;
        }

        /// <summary>
        /// DataRowコピー処理（タブレット全体設定マスタ(得意先別)クラス⇒ガイド用DataRow）
        /// </summary>
        /// <param name="guideRow">ガイド用DataRow</param>
        /// <param name="pmTabTtlStCust">タブレット全体設定マスタ(得意先別)クラス</param>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(得意先別)クラスからガイド用DataRowへコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void CopyToGuideRowFromSubSection(ref DataRow guideRow, PmTabTtlStCust pmTabTtlStCust)
        {
            guideRow[GUIDE_CUSTOMERCODE_TITLE] = pmTabTtlStCust.CustomerCode;            // 得意先コード
            guideRow[GUIDE_CUSTOMERCODENM_TITLE] = pmTabTtlStCust.CustomerNm;
        }

        #endregion

        #region[ToInt]
        /// <summary>
        /// 文字列→数値　変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt(string text)
        {
            try
            {
                return Convert.ToInt32(text);
            }
            catch
            {
                return 0;
            }
        }
        #endregion 
    }
}
