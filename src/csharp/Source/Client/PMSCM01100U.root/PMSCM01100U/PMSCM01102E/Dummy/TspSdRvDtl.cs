using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 
    /// </summary>
    public class TspSdRvDtl
    {
        /// <summary>
        /// 
        /// </summary>
        public TspSdRvDtl() { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createDateTime"></param>
        /// <param name="updateDateTime"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="fileHeaderGuid"></param>
        /// <param name="updEmployeeCode"></param>
        /// <param name="updAssemblyId1"></param>
        /// <param name="updAssemblyId2"></param>
        /// <param name="logicalDeleteCode"></param>
        /// <param name="pmEnterpriseCode"></param>
        /// <param name="tspCommNo"></param>
        /// <param name="tspCommCount"></param>
        /// <param name="tspCommRowNo"></param>
        /// <param name="deliveredGoodsDiv"></param>
        /// <param name="handleDivCode"></param>
        /// <param name="partsShape"></param>
        /// <param name="delivrdGdsConfCd"></param>
        /// <param name="deliGdsCmpltDueDate"></param>
        /// <param name="tbsPartsCode"></param>
        /// <param name="pmPartsNameKana"></param>
        /// <param name="salesOrderCount"></param>
        /// <param name="deliveredGoodsCount"></param>
        /// <param name="partsNoWithHyphen"></param>
        /// <param name="pmPartsMakerCode"></param>
        /// <param name="purePartsMakerCode"></param>
        /// <param name="purePrtsNoWithHyphen"></param>
        /// <param name="listPrice"></param>
        /// <param name="unitPrice"></param>
        /// <param name="pmDtlTakeinDivCd"></param>
        /// <param name="enterpriseName"></param>
        /// <param name="updEmployeeName"></param>
        public TspSdRvDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, int logicalDeleteCode, string pmEnterpriseCode, int tspCommNo, int tspCommCount, int tspCommRowNo, int deliveredGoodsDiv, int handleDivCode, int partsShape, int delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, int tbsPartsCode, string pmPartsNameKana, double salesOrderCount, double deliveredGoodsCount, string partsNoWithHyphen, int pmPartsMakerCode, int purePartsMakerCode, string purePrtsNoWithHyphen, long listPrice, long unitPrice, int pmDtlTakeinDivCd, string enterpriseName, string updEmployeeName) { }

        /// <summary></summary>
        public DateTime CreateDateTime { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public string CreateDateTimeAdFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string CreateDateTimeAdInFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string CreateDateTimeJpFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string CreateDateTimeJpInFormal { get { return ""; } set { } }
        /// <summary></summary>
        public DateTime DeliGdsCmpltDueDate { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public string DeliGdsCmpltDueDateAdFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string DeliGdsCmpltDueDateAdInFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string DeliGdsCmpltDueDateJpFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string DeliGdsCmpltDueDateJpInFormal { get { return ""; } set { } }
        /// <summary></summary>
        public double DeliveredGoodsCount { get { return 0; } set { } }
        /// <summary></summary>
        public int DeliveredGoodsDiv { get { return 0; } set { } }
        /// <summary></summary>
        public int DelivrdGdsConfCd { get { return 0; } set { } }
        /// <summary></summary>
        public string EnterpriseCode { get { return ""; } set { } }
        /// <summary></summary>
        public string EnterpriseName { get { return ""; } set { } }
        /// <summary></summary>
        public Guid FileHeaderGuid { get { return Guid.Empty; } set { } }
        /// <summary></summary>
        public int HandleDivCode { get { return 0; } set { } }
        /// <summary></summary>
        public long ListPrice { get { return 0; } set { } }
        /// <summary></summary>
        public int LogicalDeleteCode { get { return 0; } set { } }
        /// <summary></summary>
        public string PartsNoWithHyphen { get { return ""; } set { } }
        /// <summary></summary>
        public int PartsShape { get { return 0; } set { } }
        /// <summary></summary>
        public int PmDtlTakeinDivCd { get { return 0; } set { } }
        /// <summary></summary>
        public string PmEnterpriseCode { get { return ""; } set { } }
        /// <summary></summary>
        public int PmPartsMakerCode { get { return 0; } set { } }
        /// <summary></summary>
        public string PmPartsNameKana { get { return ""; } set { } }
        /// <summary></summary>
        public int PurePartsMakerCode { get { return 0; } set { } }
        /// <summary></summary>
        public string PurePrtsNoWithHyphen { get { return ""; } set { } }
        /// <summary></summary>
        public double SalesOrderCount { get { return 0; } set { } }
        /// <summary></summary>
        public int TbsPartsCode { get { return 0; } set { } }
        /// <summary></summary>
        public int TspCommCount { get { return 0; } set { } }
        /// <summary></summary>
        public int TspCommNo { get { return 0; } set { } }
        /// <summary></summary>
        public int TspCommRowNo { get { return 0; } set { } }
        /// <summary></summary>
        public long UnitPrice { get { return 0; } set { } }
        /// <summary></summary>
        public string UpdAssemblyId1 { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdAssemblyId2 { get { return ""; } set { } }
        /// <summary></summary>
        public DateTime UpdateDateTime { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public string UpdateDateTimeAdFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdateDateTimeAdInFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdateDateTimeJpFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdateDateTimeJpInFormal { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdEmployeeCode { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdEmployeeName { get { return ""; } set { } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TspSdRvDtl Clone() { return null; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ArrayList Compare(TspSdRvDtl target) { return null; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspSdRvDtl1"></param>
        /// <param name="tspSdRvDtl2"></param>
        /// <returns></returns>
        public static ArrayList Compare(TspSdRvDtl tspSdRvDtl1, TspSdRvDtl tspSdRvDtl2) { return null; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Equals(TspSdRvDtl target) { return false; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspSdRvDtl1"></param>
        /// <param name="tspSdRvDtl2"></param>
        /// <returns></returns>
        public static bool Equals(TspSdRvDtl tspSdRvDtl1, TspSdRvDtl tspSdRvDtl2) { return false; }
    }
}
