//****************************************************************************//
// システム         :  PM.NS
// プログラム名称   ： SCM企業連結データアクセスクラス
// プログラム概要   ： 
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2011/05/25  修正内容 : 新規作成(PM用に修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745　吉岡
// 更 新 日  2013/05/24  修正内容 : 2013/06/18配信予定　SCM№10533対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30973　鹿庭
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Web.Services;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	class SFCMN02563AC
	{
		/// <summary>
		/// クラスコピー処理（SCM企業連結データクラス→SCM企業連結ワーククラス）
		/// </summary>
		/// <param name="scmEpCnect">SCM企業連結データクラス</param>
		/// <returns>SCM企業連結ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : SCM企業連結データクラス→SCM企業連結ワーククラスにメンバのコピーを行います。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
		/// <br>Date       : 2009.06.02</br>
		/// </remarks>
		internal static ScmEpCnectWork CopyScmEpCnectToScmEpCnectWork(ScmEpCnect scmEpCnect)
		{
			ScmEpCnectWork scmEpCnectWork = new ScmEpCnectWork();

			scmEpCnectWork.CreateDateTime = scmEpCnect.CreateDateTime;
			scmEpCnectWork.UpdateDateTime = scmEpCnect.UpdateDateTime;
			scmEpCnectWork.LogicalDeleteCode = scmEpCnect.LogicalDeleteCode;
			scmEpCnectWork.CnectOriginalEpCd = scmEpCnect.CnectOriginalEpCd;
			scmEpCnectWork.CnectOriginalEpNm = scmEpCnect.CnectOriginalEpNm;
			scmEpCnectWork.CnectOtherEpCd = scmEpCnect.CnectOtherEpCd;
			scmEpCnectWork.CnectOtherEpNm = scmEpCnect.CnectOtherEpNm;
			scmEpCnectWork.DiscDivCd = scmEpCnect.DiscDivCd;

			return scmEpCnectWork;
		}

		/// <summary>
		/// クラスコピー処理（SCM企業連結ワーククラス→SCM企業連結データクラス）
		/// </summary>
		/// <param name="scmEpCnect">SCM企業連結ワーククラス</param>
		/// <returns>SCM企業連結データクラス</returns>
		/// <remarks>
		/// <br>Note       : SCM企業連結ワーククラス→SCM企業連結データクラスにメンバのコピーを行います。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
		/// <br>Date       : 2009.06.02</br>
		/// </remarks>
		internal static ScmEpCnect CopyScmEpCnectWorkToScmEpCnect(ScmEpCnectWork scmEpCnectWork)
		{
			ScmEpCnect scmEpCnect = new ScmEpCnect();

			scmEpCnect.CreateDateTime = scmEpCnectWork.CreateDateTime;
			scmEpCnect.UpdateDateTime = scmEpCnectWork.UpdateDateTime;
			scmEpCnect.LogicalDeleteCode = scmEpCnectWork.LogicalDeleteCode;
			scmEpCnect.CnectOriginalEpCd = scmEpCnectWork.CnectOriginalEpCd;
			scmEpCnect.CnectOriginalEpNm = scmEpCnectWork.CnectOriginalEpNm;
			scmEpCnect.CnectOtherEpCd = scmEpCnectWork.CnectOtherEpCd;
			scmEpCnect.CnectOtherEpNm = scmEpCnectWork.CnectOtherEpNm;
			scmEpCnect.DiscDivCd = scmEpCnectWork.DiscDivCd;

            return scmEpCnect;
		}

		/// <summary>
		/// クラスコピー処理（SCM企業拠点連結データクラス→SCM企業拠点連結ワーククラス）
		/// </summary>
		/// <param name="scmEpScCnt">SCM企業拠点連結データクラス</param>
		/// <returns>SCM企業拠点連結ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : SCM企業拠点連結データクラス→SCM企業拠点連結ワーククラスにメンバのコピーを行います。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2009.06.02</br>
        /// <br>Note       : 通信方式項目追加</br>
        /// <br>Programmer : x_zhuxk</br>
        /// <br>Date       : 2011.08.12</br>
        /// <br>Note       : PCCUOE</br>
		/// </remarks>
		internal static ScmEpScCntWork CopyScmEpScCntToScmEpScCntWork(ScmEpScCnt scmEpScCnt)
		{
			ScmEpScCntWork scmEpScCntWork = new ScmEpScCntWork();

			scmEpScCntWork.CreateDateTime = scmEpScCnt.CreateDateTime;
			scmEpScCntWork.UpdateDateTime = scmEpScCnt.UpdateDateTime;
			scmEpScCntWork.LogicalDeleteCode = scmEpScCnt.LogicalDeleteCode;
			scmEpScCntWork.CnectOriginalEpCd = scmEpScCnt.CnectOriginalEpCd;
			scmEpScCntWork.CnectOriginalSecCd = scmEpScCnt.CnectOriginalSecCd;
			scmEpScCntWork.CnectOriginalSecNm = scmEpScCnt.CnectOriginalSecNm;
			scmEpScCntWork.CnectOtherEpCd = scmEpScCnt.CnectOtherEpCd;
			scmEpScCntWork.CnectOtherSecCd = scmEpScCnt.CnectOtherSecCd;
			scmEpScCntWork.CnectOtherSecNm = scmEpScCnt.CnectOtherSecNm;
			scmEpScCntWork.DiscDivCd = scmEpScCnt.DiscDivCd;
            scmEpScCntWork.ScmCommMethod = scmEpScCnt.ScmCommMethod;//ADD BY x_zhuxk ON 2011.08.12
            scmEpScCntWork.PccUoeCommMethod = scmEpScCnt.PccUoeCommMethod;//ADD BY x_zhuxk ON 2011.08.12
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 --------------------------------->>>>>
            scmEpScCntWork.TabUseDiv = scmEpScCnt.TabUseDiv;
            scmEpScCntWork.OldNewStatus = scmEpScCnt.OldNewStatus;
            scmEpScCntWork.UsualMnalStatus = scmEpScCnt.UsualMnalStatus;
            scmEpScCntWork.PmDBId = scmEpScCnt.PmDBId;
            scmEpScCntWork.PmUploadDiv = scmEpScCnt.PmUploadDiv;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ---------------------------------<<<<<

			return scmEpScCntWork;
		}

		/// <summary>
		/// クラスコピー処理（SCM企業拠点連結ワーククラス→SCM企業拠点連結データクラス）
		/// </summary>
		/// <param name="scmEpScCntWork">SCM企業拠点連結ワーククラス</param>
		/// <returns>SCM企業拠点連結データクラス</returns>
		/// <remarks>
		/// <br>Note       : SCM企業拠点連結ワーククラス→SCM企業拠点連結データクラスにメンバのコピーを行います。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2009.06.02</br>
        /// <br>Note       : 通信方式項目追加</br>
        /// <br>Programmer : x_zhuxk</br>
        /// <br>Date       : 2011.08.12</br>
        /// <br>Note       : PCCUOE</br>
		/// </remarks>
		internal static ScmEpScCnt CopyScmEpScCntWorkToScmEpScCnt(ScmEpScCntWork scmEpScCntWork)
		{
			ScmEpScCnt scmEpScCnt = new ScmEpScCnt();

			scmEpScCnt.CreateDateTime = scmEpScCntWork.CreateDateTime;
			scmEpScCnt.UpdateDateTime = scmEpScCntWork.UpdateDateTime;
			scmEpScCnt.LogicalDeleteCode = scmEpScCntWork.LogicalDeleteCode;
			scmEpScCnt.CnectOriginalEpCd = scmEpScCntWork.CnectOriginalEpCd;
			scmEpScCnt.CnectOriginalSecCd = scmEpScCntWork.CnectOriginalSecCd;
			scmEpScCnt.CnectOriginalSecNm = scmEpScCntWork.CnectOriginalSecNm;
			scmEpScCnt.CnectOtherEpCd = scmEpScCntWork.CnectOtherEpCd;
			scmEpScCnt.CnectOtherSecCd = scmEpScCntWork.CnectOtherSecCd;
			scmEpScCnt.CnectOtherSecNm = scmEpScCntWork.CnectOtherSecNm;
			scmEpScCnt.DiscDivCd = scmEpScCntWork.DiscDivCd;
            scmEpScCnt.ScmCommMethod = scmEpScCntWork.ScmCommMethod;//ADD BY x_zhuxk ON 2011.08.12
            scmEpScCnt.PccUoeCommMethod = scmEpScCntWork.PccUoeCommMethod;//ADD BY x_zhuxk ON 2011.08.12
            // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
            scmEpScCnt.TabUseDiv = scmEpScCntWork.TabUseDiv;
            // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 --------------------------------->>>>>
            scmEpScCntWork.OldNewStatus = scmEpScCntWork.OldNewStatus;
            scmEpScCntWork.UsualMnalStatus = scmEpScCntWork.UsualMnalStatus;
            scmEpScCntWork.PmDBId = scmEpScCntWork.PmDBId;
            scmEpScCntWork.PmUploadDiv = scmEpScCntWork.PmUploadDiv;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ---------------------------------<<<<<


			return scmEpScCnt;
		}


        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// クラスコピー処理（SCM企業拠点連結データクラス→SCM企業拠点連結ワーククラス）
        /// </summary>
        /// <param name="scmEpScCnt">SCM企業拠点連結データクラス</param>
        /// <returns>SCM企業拠点連結ワーククラス</returns>
        /// <remarks>
        internal static Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork CopyScmEpScCntToScmEpScCntWork2(ScmEpScCnt scmEpScCnt)
        {
            Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork = new Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork();

            scmEpScCntWork.CreateDateTime = scmEpScCnt.CreateDateTime;
            scmEpScCntWork.UpdateDateTime = scmEpScCnt.UpdateDateTime;
            scmEpScCntWork.LogicalDeleteCode = scmEpScCnt.LogicalDeleteCode;
            scmEpScCntWork.CnectOriginalEpCd = scmEpScCnt.CnectOriginalEpCd;
            scmEpScCntWork.CnectOriginalSecCd = scmEpScCnt.CnectOriginalSecCd;
            scmEpScCntWork.CnectOriginalSecNm = scmEpScCnt.CnectOriginalSecNm;
            scmEpScCntWork.CnectOtherEpCd = scmEpScCnt.CnectOtherEpCd;
            scmEpScCntWork.CnectOtherSecCd = scmEpScCnt.CnectOtherSecCd;
            scmEpScCntWork.CnectOtherSecNm = scmEpScCnt.CnectOtherSecNm;
            scmEpScCntWork.DiscDivCd = scmEpScCnt.DiscDivCd;
            scmEpScCntWork.ScmCommMethod = scmEpScCnt.ScmCommMethod;
            scmEpScCntWork.PccUoeCommMethod = scmEpScCnt.PccUoeCommMethod;
            scmEpScCntWork.RcScmCommMethod = scmEpScCnt.RcScmCommMethod;
            scmEpScCntWork.PrDispSystem = scmEpScCnt.PrDispSystem;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 --------------------------------->>>>>
            scmEpScCntWork.TabUseDiv = scmEpScCnt.TabUseDiv;
            scmEpScCntWork.OldNewStatus = scmEpScCnt.OldNewStatus;
            scmEpScCntWork.UsualMnalStatus = scmEpScCnt.UsualMnalStatus;
            scmEpScCntWork.PmDBId = scmEpScCnt.PmDBId;
            scmEpScCntWork.PmUploadDiv = scmEpScCnt.PmUploadDiv;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ---------------------------------<<<<<

            return scmEpScCntWork;
        }
        /// <summary>
        /// クラスコピー処理（SCM企業拠点連結ワーククラス→SCM企業拠点連結データクラス）
        /// </summary>
        /// <param name="scmEpScCntWork">SCM企業拠点連結ワーククラス</param>
        /// <returns>SCM企業拠点連結データクラス</returns>
        /// <remarks>
        /// <br>Note       : SCM企業拠点連結ワーククラス→SCM企業拠点連結データクラスにメンバのコピーを行います。</br>
        /// </remarks>
        internal static ScmEpScCnt CopyScmEpScCntWorkToScmEpScCnt(Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork)
        {
            ScmEpScCnt scmEpScCnt = new ScmEpScCnt();

            scmEpScCnt.CreateDateTime = scmEpScCntWork.CreateDateTime;
            scmEpScCnt.UpdateDateTime = scmEpScCntWork.UpdateDateTime;
            scmEpScCnt.LogicalDeleteCode = scmEpScCntWork.LogicalDeleteCode;
            scmEpScCnt.CnectOriginalEpCd = scmEpScCntWork.CnectOriginalEpCd;
            scmEpScCnt.CnectOriginalSecCd = scmEpScCntWork.CnectOriginalSecCd;
            scmEpScCnt.CnectOriginalSecNm = scmEpScCntWork.CnectOriginalSecNm;
            scmEpScCnt.CnectOtherEpCd = scmEpScCntWork.CnectOtherEpCd;
            scmEpScCnt.CnectOtherSecCd = scmEpScCntWork.CnectOtherSecCd;
            scmEpScCnt.CnectOtherSecNm = scmEpScCntWork.CnectOtherSecNm;
            scmEpScCnt.DiscDivCd = scmEpScCntWork.DiscDivCd;
            scmEpScCnt.ScmCommMethod = scmEpScCntWork.ScmCommMethod;
            scmEpScCnt.PccUoeCommMethod = scmEpScCntWork.PccUoeCommMethod;
            scmEpScCnt.RcScmCommMethod = scmEpScCntWork.RcScmCommMethod;
            scmEpScCnt.PrDispSystem = scmEpScCntWork.PrDispSystem;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 --------------------------------->>>>>
            scmEpScCnt.TabUseDiv = scmEpScCntWork.TabUseDiv;
            scmEpScCnt.OldNewStatus = scmEpScCntWork.OldNewStatus;
            scmEpScCnt.UsualMnalStatus = scmEpScCntWork.UsualMnalStatus;
            scmEpScCnt.PmDBId = scmEpScCntWork.PmDBId;
            scmEpScCnt.PmUploadDiv = scmEpScCntWork.PmUploadDiv;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ---------------------------------<<<<<
            return scmEpScCnt;
        }
        /// <summary>
        /// クラスコピー処理（SCM企業連結ワーククラス→SCM企業連結データクラス）
        /// </summary>
        /// <param name="scmEpCnectWork">SCM企業連結ワーククラス</param>
        /// <returns>SCM企業連結データクラス</returns>
        /// <remarks>
        /// <br>Note       : SCM企業連結ワーククラス→SCM企業連結データクラスにメンバのコピーを行います。</br>
        /// </remarks>
        internal static ScmEpCnect CopyScmEpCnectWorkToScmEpCnect(Broadleaf.Application.Remoting.ParamData.ScmEpCnectWork scmEpCnectWork)
        {
            ScmEpCnect scmEpCnect = new ScmEpCnect();

            scmEpCnect.CreateDateTime = scmEpCnectWork.CreateDateTime;
            scmEpCnect.UpdateDateTime = scmEpCnectWork.UpdateDateTime;
            scmEpCnect.LogicalDeleteCode = scmEpCnectWork.LogicalDeleteCode;
            scmEpCnect.CnectOriginalEpCd = scmEpCnectWork.CnectOriginalEpCd;
            scmEpCnect.CnectOriginalEpNm = scmEpCnectWork.CnectOriginalEpNm;
            scmEpCnect.CnectOtherEpCd = scmEpCnectWork.CnectOtherEpCd;
            scmEpCnect.CnectOtherEpNm = scmEpCnectWork.CnectOtherEpNm;
            scmEpCnect.DiscDivCd = scmEpCnectWork.DiscDivCd;

            return scmEpCnect;
        }
        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2014.09.10 ins by Ryo. -start- > > > > >
        /// <summary>
        /// クラスコピー処理（提供側SCM事業場拠点連結ワーククラス→提供側SCM事業場拠点連結データクラス）
        /// </summary>
        /// <param name="oScmBPSCntWorks">提供側SCM事業場拠点連結ワーククラス</param>
        /// <returns>提供側SCM事業場拠点連結データクラス</returns>
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場拠点連結ワーククラス→提供側SCM事業場拠点連結データクラスにメンバのコピーを行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.10</br>
        /// </remarks>
        internal static OScmBPSCnt CopyOScmBPSCntWorkToOScmBPSCnt(Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork oScmBPSCntWork)
        {
            OScmBPSCnt oScmBPSCnt = new OScmBPSCnt();

            oScmBPSCnt.CreateDateTime = oScmBPSCntWork.CreateDateTime;
            oScmBPSCnt.UpdateDateTime = oScmBPSCntWork.UpdateDateTime;
            oScmBPSCnt.LogicalDeleteCode = oScmBPSCntWork.LogicalDeleteCode;
            oScmBPSCnt.CnectOtherEpCd = oScmBPSCntWork.CnectOtherEpCd;
            oScmBPSCnt.CnectOtherSecCd = oScmBPSCntWork.CnectOtherSecCd;
            oScmBPSCnt.ContractantCode = oScmBPSCntWork.ContractantCode;
            oScmBPSCnt.FTCCustomerCode = oScmBPSCntWork.FTCCustomerCode;
            oScmBPSCnt.CnectOriginalEpCd = oScmBPSCntWork.CnectOriginalEpCd;
            oScmBPSCnt.CnectOriginalSecCd = oScmBPSCntWork.CnectOriginalSecCd;
            oScmBPSCnt.TransContractantCd = oScmBPSCntWork.TransContractantCd;
            oScmBPSCnt.TransCustomerCd = oScmBPSCntWork.TransCustomerCd;

            return oScmBPSCnt;
        }

        /// <summary>
        /// クラスコピー処理（提供側SCM事業場連結ワーククラス→提供側SCM事業場連結データクラス）
        /// </summary>
        /// <param name="oScmBPCntWorks">提供側SCM事業場連結ワーククラス</param>
        /// <returns>提供側SCM事業場連結データクラス</returns>
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場連結ワーククラス→提供側SCM事業場連結データクラスにメンバのコピーを行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.10</br>
        /// </remarks>
        internal static OScmBPCnt CopyOScmBPCntWorkToOScmBPCnt(Broadleaf.Application.Remoting.ParamData.OScmBPCntWork oScmBPCntWork)
        {
            OScmBPCnt oScmBPCnt = new OScmBPCnt();

            oScmBPCnt.CreateDateTime = oScmBPCntWork.CreateDateTime;
            oScmBPCnt.UpdateDateTime = oScmBPCntWork.UpdateDateTime;
            oScmBPCnt.LogicalDeleteCode = oScmBPCntWork.LogicalDeleteCode;
            oScmBPCnt.ContractantCode = oScmBPCntWork.ContractantCode;
            oScmBPCnt.FTCCustomerCode = oScmBPCntWork.FTCCustomerCode;
            oScmBPCnt.BLUserCode1 = oScmBPCntWork.BLUserCode1;
            oScmBPCnt.BLUserCode2 = oScmBPCntWork.BLUserCode2;
            oScmBPCnt.CnectOtherEpCd = oScmBPCntWork.CnectOtherEpCd;
            oScmBPCnt.ContractantName = oScmBPCntWork.ContractantName;
            oScmBPCnt.FTCCustomerName = oScmBPCntWork.FTCCustomerName;
            oScmBPCnt.TransContractantCd = oScmBPCntWork.TransContractantCd;
            oScmBPCnt.TransCustomerCd = oScmBPCntWork.TransCustomerCd;
            oScmBPCnt.TransBLUserCode1 = oScmBPCntWork.TransBLUserCode1;
            oScmBPCnt.TransBLUserCode2 = oScmBPCntWork.TransBLUserCode2;
            oScmBPCnt.CnectOriginalEpCd = oScmBPCntWork.CnectOriginalEpCd;
            oScmBPCnt.TransContractantNm = oScmBPCntWork.TransContractantNm;
            oScmBPCnt.TransCustomerNm = oScmBPCntWork.TransCustomerNm;
            oScmBPCnt.CooprtDataUpdateDiv = oScmBPCntWork.CooprtDataUpdateDiv;

            return oScmBPCnt;
        }

        /// <summary>
        /// クラスコピー処理（連結元NS拠点情報ワーククラス→連結元NS拠点情報データクラス）
        /// </summary>
        /// <param name="oScmBPCntWorks">連結元NS拠点情報ワーククラス</param>
        /// <returns>連結元NS拠点情報データクラス</returns>
        /// <remarks>
        /// <br>Note       : 連結元NS拠点情報ワーククラス→連結元NS拠点情報データクラスにメンバのコピーを行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.10</br>
        /// </remarks>
        internal static CnectOrgNSSecInfo CopyCnectOrgNSSecInfoWorkToCnectOrgNSSecInfo(Broadleaf.Application.Remoting.ParamData.CnectOrgNSSecInfoWork cnectOrgNSSecInfoWork)
        {
            CnectOrgNSSecInfo cnectOrgNSSecInfo = new CnectOrgNSSecInfo();

            cnectOrgNSSecInfo.CnectOriginalEpCd = cnectOrgNSSecInfoWork.CnectOriginalEpCd;
            cnectOrgNSSecInfo.CnectOriginalSecCd = cnectOrgNSSecInfoWork.CnectOriginalSecCd;
            cnectOrgNSSecInfo.CnectOriginalSecGNm = cnectOrgNSSecInfoWork.CnectOriginalSecGNm;

            return cnectOrgNSSecInfo;
        }

        /// <summary>
        /// クラスコピー処理（提供側SCM事業場拠点連結データクラス→提供側SCM事業場拠点連結ワーククラス）
        /// </summary>
        /// <param name="oScmBPSCnt">提供側SCM事業場拠点連結データクラス</param>
        /// <returns>提供側SCM事業場拠点連結ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場拠点連結データクラス→提供側SCM事業場拠点連結ワーククラスにメンバのコピーを行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.10</br>
        /// </remarks>
        internal static Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork CopyOScmBPSCntToOScmBPSCntWork(OScmBPSCnt oScmBPSCnt)
        {
            Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork oScmBPSCntWork = new Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork();

            oScmBPSCntWork.CreateDateTime     = oScmBPSCnt.CreateDateTime;
            oScmBPSCntWork.UpdateDateTime     = oScmBPSCnt.UpdateDateTime;
            oScmBPSCntWork.LogicalDeleteCode  = oScmBPSCnt.LogicalDeleteCode;
            oScmBPSCntWork.CnectOtherEpCd     = oScmBPSCnt.CnectOtherEpCd;
            oScmBPSCntWork.CnectOtherSecCd    = oScmBPSCnt.CnectOtherSecCd;
            oScmBPSCntWork.ContractantCode    = oScmBPSCnt.ContractantCode;
            oScmBPSCntWork.FTCCustomerCode    = oScmBPSCnt.FTCCustomerCode;
            oScmBPSCntWork.CnectOriginalEpCd  = oScmBPSCnt.CnectOriginalEpCd;
            oScmBPSCntWork.CnectOriginalSecCd = oScmBPSCnt.CnectOriginalSecCd;
            oScmBPSCntWork.TransContractantCd = oScmBPSCnt.TransContractantCd;
            oScmBPSCntWork.TransCustomerCd    = oScmBPSCnt.TransCustomerCd;

            return oScmBPSCntWork;
        }

        /// <summary>
        /// クラスコピー処理（提供側SCM事業場連結データクラス→提供側SCM事業場連結ワーククラス）
        /// </summary>
        /// <param name="oScmBPCnt">提供側SCM事業場連結データクラス</param>
        /// <returns>提供側SCM事業場連結ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場連結データクラス→提供側SCM事業場連結ワーククラスにメンバのコピーを行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.10</br>
        /// </remarks>
        internal static Broadleaf.Application.Remoting.ParamData.OScmBPCntWork CopyOScmBPCntToOScmBPCntWork(OScmBPCnt oScmBPCnt)
        {
            Broadleaf.Application.Remoting.ParamData.OScmBPCntWork oScmBPCntWork = new Broadleaf.Application.Remoting.ParamData.OScmBPCntWork();

            oScmBPCntWork.CreateDateTime      = oScmBPCnt.CreateDateTime;
            oScmBPCntWork.UpdateDateTime      = oScmBPCnt.UpdateDateTime;
            oScmBPCntWork.LogicalDeleteCode   = oScmBPCnt.LogicalDeleteCode;
            oScmBPCntWork.ContractantCode     = oScmBPCnt.ContractantCode;
            oScmBPCntWork.FTCCustomerCode     = oScmBPCnt.FTCCustomerCode;
            oScmBPCntWork.BLUserCode1         = oScmBPCnt.BLUserCode1;
            oScmBPCntWork.BLUserCode2         = oScmBPCnt.BLUserCode2;
            oScmBPCntWork.CnectOtherEpCd      = oScmBPCnt.CnectOtherEpCd;
            oScmBPCntWork.ContractantName     = oScmBPCnt.ContractantName;
            oScmBPCntWork.FTCCustomerName     = oScmBPCnt.FTCCustomerName;
            oScmBPCntWork.TransContractantCd  = oScmBPCnt.TransContractantCd;
            oScmBPCntWork.TransCustomerCd     = oScmBPCnt.TransCustomerCd;
            oScmBPCntWork.TransBLUserCode1    = oScmBPCnt.TransBLUserCode1;
            oScmBPCntWork.TransBLUserCode2    = oScmBPCnt.TransBLUserCode2;
            oScmBPCntWork.CnectOriginalEpCd   = oScmBPCnt.CnectOriginalEpCd;
            oScmBPCntWork.TransContractantNm  = oScmBPCnt.TransContractantNm;
            oScmBPCntWork.TransCustomerNm     = oScmBPCnt.TransCustomerNm;
            oScmBPCntWork.CooprtDataUpdateDiv = oScmBPCnt.CooprtDataUpdateDiv;

            return oScmBPCntWork;
        }
        // 2014.09.10 ins by Ryo. -e n d- < < < < <

		#region 2011.05.26 Hiroki Hashimoto Add
		/// <summary>
		/// クラスコピー処理（SCM連結元拠点別設定データワーククラス→SCM連結元拠点別設定データクラス）
		/// </summary>
		/// <param name="ScmCnctSetWork">SCM連結元拠点別設定データワーククラス</param>
		/// <returns>SCM連結元拠点別設定データクラス</returns>
		/// <remarks>
		/// <br>Note       : SCM連結元拠点別設定データワーククラス→SCM連結元拠点別設定データクラスにメンバのコピーを行います。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
		/// <br>Date       : 2011.05.26</br>
		/// </remarks>
		internal static ScmCnctSet CopyScmCnctSetWorkToScmCnctSet(ScmCnctSetWork scmCnctSetWork)
		{
			ScmCnctSet scmCnctSet = new ScmCnctSet();
			scmCnctSet.CreateDateTime = scmCnctSetWork.CreateDateTime;
			scmCnctSet.UpdateDateTime = scmCnctSetWork.UpdateDateTime;
			scmCnctSet.LogicalDeleteCode = scmCnctSetWork.LogicalDeleteCode;
			scmCnctSet.CnectOriginalEpCd = scmCnctSetWork.CnectOriginalEpCd;
			scmCnctSet.CnectOriginalSecCd = scmCnctSetWork.CnectOriginalSecCd;
			scmCnctSet.PMInstNoHdlDivCd = scmCnctSetWork.PMInstNoHdlDivCd;
			
			return scmCnctSet;
		}

		/// <summary>
		/// クラスコピー処理（SCM連結元拠点別設定データクラス→SCM連結元拠点別設定データワーククラス）
		/// </summary>
		/// <param name="ScmCnctSet">SCM連結元拠点別設定データクラス</param>
		/// <returns>SCM連結元拠点別設定データワーククラス</returns>
		/// <remarks>
		/// <br>Note       : SCM連結元拠点別設定データクラス→SCM連結元拠点別設定データワーククラスにメンバのコピーを行います。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
		/// <br>Date       : 2011.05.26</br>
		/// </remarks>
		internal static ScmCnctSetWork CopyScmCnctSetToScmCnctSetWork(ScmCnctSet scmCnctSet)
		{
			ScmCnctSetWork scmCnctSetWork = new ScmCnctSetWork();
			scmCnctSetWork.CreateDateTime = scmCnctSet.CreateDateTime;
			scmCnctSetWork.UpdateDateTime = scmCnctSet.UpdateDateTime;
			scmCnctSetWork.LogicalDeleteCode = scmCnctSet.LogicalDeleteCode;
			scmCnctSetWork.CnectOriginalEpCd = scmCnctSet.CnectOriginalEpCd;
			scmCnctSetWork.CnectOriginalSecCd = scmCnctSet.CnectOriginalSecCd;
			scmCnctSetWork.PMInstNoHdlDivCd = scmCnctSet.PMInstNoHdlDivCd;
			
			return scmCnctSetWork;
		}
		#endregion


		/// <summary>
		/// 論理削除区分コンバート処理
		/// </summary>
		/// <param name="cmLogicalMode">論理削除区分</param>
		/// <returns>論理削除区分（Web用）</returns>
		/// <remarks>
		/// <br>Note		: Webで使用可能な論理削除区分に変更します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		internal static LogicalMode ConvertLogicalMode(ConstantManagement.LogicalMode cmLogicalMode)
		{
			LogicalMode logicalMode;
			switch (cmLogicalMode)
			{
				case ConstantManagement.LogicalMode.GetData0:
					{
						logicalMode = LogicalMode.GetData0;
						break;
					}
				case ConstantManagement.LogicalMode.GetData01:
					{
						logicalMode = LogicalMode.GetData01;
						break;
					}
				case ConstantManagement.LogicalMode.GetData012:
					{
						logicalMode = LogicalMode.GetData012;
						break;
					}
				case ConstantManagement.LogicalMode.GetData1:
					{
						logicalMode = LogicalMode.GetData1;
						break;
					}
				case ConstantManagement.LogicalMode.GetData2:
					{
						logicalMode = LogicalMode.GetData2;
						break;
					}
				case ConstantManagement.LogicalMode.GetData3:
					{
						logicalMode = LogicalMode.GetData3;
						break;
					}
				default:
					{
						logicalMode = LogicalMode.GetDataAll;
						break;
					}
			}
			return logicalMode;
		}

    }
}
