//****************************************************************************//
// ƒVƒXƒeƒ€         : PM.NSƒVƒŠ[ƒY
// ƒvƒƒOƒ‰ƒ€–¼Ì   : ‚t‚n‚d“`•[ˆóüƒNƒ‰ƒX
// ƒvƒƒOƒ‰ƒ€ŠT—v   : ‚t‚n‚d“`•[ˆóü‚Ì’è‹`‚ğs‚¤
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// —š—ğ
//----------------------------------------------------------------------------//
// ŠÇ—”Ô†  10402071-00 ì¬’S“– : —§‰Ô —T•ã
// ì ¬ “ú  2008/05/26  C³“à—e : V‹Kì¬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// (ˆóü—p)UOE”„ã–¾×ƒNƒ‰ƒX
    /// </summary>
    public class PrtSalesDetail
    {
        // ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        public PrtSalesDetail()
        {
            Clear();
        }
        //‰Šú‰»
        public void Clear()
        {
            prtReceiveTime = 0;
            prtBoCode = "";
            prtUOEDeliGoodsDiv = "";
            prtDeliveredGoodsDivNm = "";
            prtFollowDeliGoodsDiv = "";
            prtFollowDeliGoodsDivNm = "";

            prtAcceptAnOrderCnt = 0;
            prtShipmentCnt = 0;
            prtUOESectOutGoodsCnt = 0;
            prtBOShipmentCnt = 0;
            detailCd = (int)ctDetailCd.ct_Normal;
        }

        /// <summary>(ˆóü—p)óM</summary>
        public Int32 prtReceiveTime = 0;

        /// <summary>(ˆóü—p)BO‹æ•ª</summary>
        public string prtBoCode = "";

        /// <summary>(ˆóü—p)UOE”[•i‹æ•ª</summary>
        public string prtUOEDeliGoodsDiv = "";

        /// <summary>(ˆóü—p)”[•i‹æ•ª–¼Ì</summary>
        public string prtDeliveredGoodsDivNm = "";

        /// <summary>(ˆóü—p)ƒtƒHƒ[”[•i‹æ•ª</summary>
        public string prtFollowDeliGoodsDiv = "";

        /// <summary>(ˆóü—p)ƒtƒHƒ[”[•i‹æ•ª–¼Ì</summary>
        public string prtFollowDeliGoodsDivNm = "";

        /// <summary>(ˆóü—p)ó’”</summary>
        public double prtAcceptAnOrderCnt = 0;

        /// <summary>(ˆóü—p)oŒÉ”</summary>
        public Int32 prtShipmentCnt = 0;

        /// <summary>(ˆóü—p)‹’“_oŒÉ”</summary>
        public Int32 prtUOESectOutGoodsCnt = 0;

        /// <summary>(ˆóü—p)BOoŒÉ”</summary>
        public Int32 prtBOShipmentCnt = 0;


        /// <summary>–¾×í•Ê</summary>
        /// 0:’Êí–¾×
        /// 9:ƒ[ƒ–¾×
        public Int32 detailCd = (int)ctDetailCd.ct_Normal;

        //UOE“`•[í•Ê
        public enum ctDetailCd : int
        {
            ct_Normal = 0, //’Êí–¾×
            ct_Zero = 9,   //ƒ[ƒ–¾×
        }
    }

    /// <summary>
    /// UOE”„ã–¾×ƒNƒ‰ƒX
    /// </summary>
    public class UoeSalesDetail
    {
        // ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        public UoeSalesDetail()
        {
            Clear();
        }

        //‰Šú‰»
        public void Clear()
        {
            salesDetailWork = new SalesDetailWork();
            prtSalesDetail = new PrtSalesDetail();
        }

		/// <summary>”„ã–¾×</summary>
        public SalesDetailWork salesDetailWork = null;

        /// <summary>(ˆóü—p)”„ã–¾×</summary>
        public PrtSalesDetail prtSalesDetail = null; 
    }

    /// <summary>
    /// UOE”„ã“`•[ƒNƒ‰ƒX
    /// </summary>
    public class UoeSales
    {
        // ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        public UoeSales()
        {
            Clear();
        }
        //‰Šú‰»
        public void Clear()
        {
            salesSlipWork = new SalesSlipWork();
            totalCnt = 0;
            slipCd = (int)ctSlipCd.ct_Section;

            if (uoeSalesDetailList == null)
            {
                uoeSalesDetailList = new List<UoeSalesDetail>();
            }
            else
            {
                uoeSalesDetailList.Clear();
            }
        }

		/// <summary>”„ãƒf[ƒ^</summary>
        public SalesSlipWork salesSlipWork = null;
		
        /// <summary>UOE”„ã–¾×</summary>
        public List<UoeSalesDetail> uoeSalesDetailList = null;

        //oŒÉ”‡Œv
        public int totalCnt = 0;

		/// <summary>UOE“`•[í•Êi‡Zj</summary>
        // “`•[í•Êi‡Zj        0:Šm”F“`•[ 1:ƒtƒHƒ[“`•[ 9:ƒ[ƒ“`•[
        // “`•[í•Êi•ÊXF‹¤’Êj  0:Šm”F“`•[ 1:BO1“`•[ 2:BO2“`•[ 3:BO3“`•[ 4:EO“`•[ 5:ƒ[ƒJ[ƒtƒHƒ[“`•[ 9:ƒ[ƒ“`•[
        // “`•[í•Êi•ÊXFƒzƒ“ƒ_j0:Šm”F“`•[ 1:BO1“`•[ 8:‘¼BO“`•[ 9:ƒ[ƒ“`•[
        public Int32 slipCd = (int)ctSlipCd.ct_Section;

        //UOE“`•[í•Ê
        public enum ctSlipCd : int
        {
            ct_Section = 0, //Šm”F“`•[
            ct_BO1 = 1,     //BO1“`•[
            ct_BO2 = 2,     //BO2“`•[
            ct_BO3 = 3,     //BO3“`•[
            ct_EO = 4,      //EO“`•[
            ct_Maker = 5,   //ƒ[ƒJ[ƒtƒHƒ[“`•[
            ct_OtherBO = 8, //‘¼BO“`•[
            ct_Zero = 9,    //ƒ[ƒ“`•[
        }

        //UOE“`•[í•Ê(•¶š—ñ)
        public const string ct_strSection = "_0"; //Šm”F“`•[
        public const string ct_strBO1 = "_1";     //BO1“`•[
        public const string ct_strBO2 = "_2";     //BO2“`•[
        public const string ct_strBO3 = "_3";     //BO3“`•[
        public const string ct_strEO = "_4";      //EO“`•[
        public const string ct_strMaker = "_5";   //ƒ[ƒJ[ƒtƒHƒ[“`•[
        public const string ct_strOtherBO = "_8"; //‘¼BO“`•[
        public const string ct_strZero = "_9";    //ƒ[ƒ“`•[
    }
}
