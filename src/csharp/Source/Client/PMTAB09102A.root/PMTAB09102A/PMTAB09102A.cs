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
    /// タブレット全体設定マスタ(拠点別)テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : タブレット全体設定マスタ(拠点別)テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 許培珠</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PmTabTtlStSecAcs
    {
        # region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        IPmTabTtlStSecDB _ipmTabTtlStSecDB = null;

        // ガイド設定ファイル名
        private const string GUIDE_XML_FILENAME = "PMTABTTLSTSECGUIDEPARENT.XML";   // XMLファイル名

        // ガイドパラメータ
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // 企業コード

        // ガイド項目タイプ
        private const string GUIDE_TYPE_STR = "System.String";              // String型

        // ガイド項目名
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";                // 拠点コード
        private const string GUIDE_SECTIONNM_TITLE = "SectionGuideNm";                // 拠点名称

        private SecInfoAcs   _secInfoAcs; // 拠点情報アクセスクラス
        
        # endregion

        # region Constructor

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PmTabTtlStSecAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._ipmTabTtlStSecDB = (IPmTabTtlStSecDB)MediationPmTabTtlStSecDB.GetPmTabTtlStSecDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStSecDB = null;
            }
            
            this._secInfoAcs = new SecInfoAcs(1); // リモート
            this._secInfoAcs.ResetSectionInfo();
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
            if (this._ipmTabTtlStSecDB == null)
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
        /// タブレット全体設定マスタ(拠点別)登録・更新処理
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)情報の登録・更新を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Write(ref PmTabTtlStSec pmTabTtlStSec)
        {
            // タブレット全体設定マスタ(拠点別)クラスからタブレット全体設定マスタ(拠点別)ワーカークラスにメンバコピー
            PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);

            ArrayList paraList = new ArrayList();

            paraList.Add(pmTabTtlStSecWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //タブレット全体設定マスタ(拠点別)書き込み
                status = this._ipmTabTtlStSecDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    pmTabTtlStSecWork = (PmTabTtlStSecWork)paraList[0];

                    // クラス内メンバコピー
                    pmTabTtlStSec = CopyToSubSectionFromSubSectionWork(pmTabTtlStSecWork);

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
        /// タブレット全体設定マスタ(拠点別)論理削除処理
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)情報の論理削除を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int LogicalDelete(ref PmTabTtlStSec pmTabTtlStSec)
        {
            int status = 0;

            try
            {
                // タブレット全体設定マスタ(拠点別)変換
                ArrayList paraLst = new ArrayList();
                PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);
                paraLst.Add(pmTabTtlStSecWork);
                object paraObj = paraLst;

                // 論理削除
                status = this._ipmTabTtlStSecDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStSecWork = (PmTabTtlStSecWork)paraLst[0];
                    // クラス内メンバコピー
                    pmTabTtlStSec = CopyToSubSectionFromSubSectionWork(pmTabTtlStSecWork);

                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStSecDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)論理削除復活処理
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)情報の復活を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Revival(ref PmTabTtlStSec pmTabTtlStSec)
        {
            try
            {
                PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(pmTabTtlStSecWork);

                object paraObj = paraLst;

                // 復活処理
                int status = this._ipmTabTtlStSecDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStSecWork = (PmTabTtlStSecWork)paraLst[0];
                    // クラス内メンバコピー
                    pmTabTtlStSec = CopyToSubSectionFromSubSectionWork(pmTabTtlStSecWork);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStSecDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)物理削除処理
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)情報の物理削除を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete(PmTabTtlStSec pmTabTtlStSec)
        {
            try
            {
                PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(pmTabTtlStSecWork);

                // タブレット全体設定マスタ(拠点別)物理削除
                int status = this._ipmTabTtlStSecDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._ipmTabTtlStSecDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)全検索処理(拠点絞込み)（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">拠点コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null);
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// タブレット全体設定マスタ(拠点別)検索処理(拠点絞込み)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSubSectionがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevSubSection">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)の検索処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, PmTabTtlStSec prevSubSection)
        {
            // 初期化
            retList = new ArrayList();
            retTotalCnt = 0;

            // 戻り値リスト
            ArrayList wkList = new ArrayList();
            
            // 検索条件セット
            PmTabTtlStSecWork pmTabTtlStSecWork = new PmTabTtlStSecWork();
            if (prevSubSection != null) pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(prevSubSection);

            pmTabTtlStSecWork.EnterpriseCode = enterpriseCode;
            pmTabTtlStSecWork.SectionCode = sectionCode;

            // Searchパラメータ
            ArrayList paraList = new ArrayList();
            paraList.Add( pmTabTtlStSecWork );
            object paraobj = paraList;

            // 検索
            object retobj = null;

			int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			// リモート
            status_o = this._ipmTabTtlStSecDB.Search(out retobj, paraobj, 0, logicalMode);

            // 検索結果判定
            switch (status_o) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL: 
                    wkList = retobj as ArrayList;

                    if (wkList != null) {
                        foreach (PmTabTtlStSecWork wkLineupWork in wkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == ""))) 
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

        #region 拠点名称取得 Methods
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionName = "全社共通";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionName = secInfoSet.SectionGuideNm.Trim();
                            return sectionName;
                        }
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        #endregion

        #region 拠点が存在するかをチェック Methods
        /// <summary>
        /// 拠点が存在するかをチェック
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>flag</returns>
        /// <remarks>
        /// <br>Note       : 拠点が存在するかをチェック</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public bool SectionExistCheck(string sectionCode)
        {
            bool sectionExist = false;

            if (sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionExist = true;
                return sectionExist;
            }
            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionExist = true;
                        }
                    }
                }
            }
            catch
            {
                sectionExist = false;
            }

            return sectionExist;
        }
        #endregion

        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバーコピー処理（タブレット全体設定マスタ(拠点別)ワーククラス⇒タブレット全体設定マスタ(拠点別)）
        /// </summary>
        /// <param name="pmTabTtlStSecWork">タブレット全体設定マスタ(拠点別)ワーククラス</param>
        /// <returns>タブレット全体設定マスタ(拠点別)</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)ワーククラスからタブレット全体設定マスタ(拠点別)へメンバーのコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStSec CopyToSubSectionFromSubSectionWork(PmTabTtlStSecWork pmTabTtlStSecWork)
        {
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            pmTabTtlStSec.CreateDateTime = pmTabTtlStSecWork.CreateDateTime;
            pmTabTtlStSec.UpdateDateTime = pmTabTtlStSecWork.UpdateDateTime;
            pmTabTtlStSec.FileHeaderGuid = pmTabTtlStSecWork.FileHeaderGuid;
            pmTabTtlStSec.LogicalDeleteCode = pmTabTtlStSecWork.LogicalDeleteCode;
            pmTabTtlStSec.EnterpriseCode = pmTabTtlStSecWork.EnterpriseCode;

            pmTabTtlStSec.LogicalDeleteCode = pmTabTtlStSecWork.LogicalDeleteCode;
            pmTabTtlStSec.SectionCode = pmTabTtlStSecWork.SectionCode;
            pmTabTtlStSec.CashRegisterNo = pmTabTtlStSecWork.CashRegisterNo;
            pmTabTtlStSec.LiPriSelPrtGdsNoDiv = pmTabTtlStSecWork.LiPriSelPrtGdsNoDiv;

            return pmTabTtlStSec;
        }

        /// <summary>
        /// クラスメンバーコピー処理（タブレット全体設定マスタ(拠点別)⇒タブレット全体設定マスタ(拠点別)ワーククラス）
        /// </summary>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)クラス</param>
        /// <returns>タブレット全体設定マスタ(拠点別)ワーク</returns>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)からタブレット全体設定マスタ(拠点別)ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStSecWork CopyToSubSectionWorkFromSubSection(PmTabTtlStSec pmTabTtlStSec)
        {
            PmTabTtlStSecWork pmTabTtlStSecWork = new PmTabTtlStSecWork();

            pmTabTtlStSecWork.CreateDateTime = pmTabTtlStSec.CreateDateTime;
            pmTabTtlStSecWork.UpdateDateTime = pmTabTtlStSec.UpdateDateTime;
            pmTabTtlStSecWork.EnterpriseCode = pmTabTtlStSec.EnterpriseCode;
            pmTabTtlStSecWork.FileHeaderGuid = pmTabTtlStSec.FileHeaderGuid;

            pmTabTtlStSecWork.LogicalDeleteCode = pmTabTtlStSec.LogicalDeleteCode;
            pmTabTtlStSecWork.SectionCode = pmTabTtlStSec.SectionCode;
            pmTabTtlStSecWork.CashRegisterNo = pmTabTtlStSec.CashRegisterNo;
            pmTabTtlStSecWork.LiPriSelPrtGdsNoDiv = pmTabTtlStSec.LiPriSelPrtGdsNoDiv;

            return pmTabTtlStSecWork;
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
        private PmTabTtlStSec CopyToSubSectionFromGuideData(Hashtable guideData)
        {
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            pmTabTtlStSec.SectionCode = (string)guideData[GUIDE_SECTIONCODE_TITLE];                     // 拠点コード

            return pmTabTtlStSec;
        }

        /// <summary>
        /// DataRowコピー処理（タブレット全体設定マスタ(拠点別)クラス⇒ガイド用DataRow）
        /// </summary>
        /// <param name="guideRow">ガイド用DataRow</param>
        /// <param name="pmTabTtlStSec">タブレット全体設定マスタ(拠点別)クラス</param>
        /// <remarks>
        /// <br>Note       : タブレット全体設定マスタ(拠点別)クラスからガイド用DataRowへコピーを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void CopyToGuideRowFromSubSection(ref DataRow guideRow, PmTabTtlStSec pmTabTtlStSec)
        {
            guideRow[GUIDE_SECTIONCODE_TITLE] = pmTabTtlStSec.SectionCode;            // 拠点コード
            guideRow[GUIDE_SECTIONNM_TITLE] = this.GetSectionName(pmTabTtlStSec.SectionCode);
        }

        #endregion
      
    }
}
