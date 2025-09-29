using System;
using System.Collections;
using System.Xml.Serialization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(TspSdRvDt))]
    public class TspSdRvDt
    {
        /// <summary>
        /// 
        /// </summary>
        public TspSdRvDt() { }
        
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
        /// <param name="orderContentsDivCd"></param>
        /// <param name="instSlipNoStr"></param>
        /// <param name="acceptAnOrderNo"></param>
        /// <param name="dataInputSystem"></param>
        /// <param name="slipNo"></param>
        /// <param name="slipKind"></param>
        /// <param name="commConditionDivCd"></param>
        /// <param name="numberPlate1Code"></param>
        /// <param name="numberPlate1Name"></param>
        /// <param name="numberPlate2"></param>
        /// <param name="numberPlate3"></param>
        /// <param name="numberPlate4"></param>
        /// <param name="modelDesignationNo"></param>
        /// <param name="categoryNo"></param>
        /// <param name="makerCode"></param>
        /// <param name="modelCode"></param>
        /// <param name="modelSubCode"></param>
        /// <param name="modelName"></param>
        /// <param name="carInspectCertModel"></param>
        /// <param name="fullModel"></param>
        /// <param name="frameNo"></param>
        /// <param name="frameModel"></param>
        /// <param name="chassisNo"></param>
        /// <param name="carProperNo"></param>
        /// <param name="produceTypeOfYearNum"></param>
        /// <param name="salesOrderDate"></param>
        /// <param name="salesOrderEmployeeCd"></param>
        /// <param name="salesOrderEmployeeNm"></param>
        /// <param name="salesOrderComment"></param>
        /// <param name="orderSideSystemVerCd"></param>
        /// <param name="tspAnswerDataMngNo"></param>
        /// <param name="tspSlipType"></param>
        /// <param name="acceptAnOrderDate"></param>
        /// <param name="pmSlipNo"></param>
        /// <param name="acceptAnOrderNm"></param>
        /// <param name="tspTotalSlipPrice"></param>
        /// <param name="pmComment"></param>
        /// <param name="pmVersion"></param>
        /// <param name="pmSendDate"></param>
        /// <param name="pmSlipKind"></param>
        /// <param name="pmOriginalSlipNo"></param>
        /// <param name="enterpriseName"></param>
        /// <param name="updEmployeeName"></param>
        /// <param name="dataInputSystemName"></param>
        public TspSdRvDt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, int logicalDeleteCode, string pmEnterpriseCode, int tspCommNo, int tspCommCount, int orderContentsDivCd, string instSlipNoStr, int acceptAnOrderNo, int dataInputSystem, string slipNo, int slipKind, int commConditionDivCd, int numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, int numberPlate4, int modelDesignationNo, int categoryNo, int makerCode, int modelCode, int modelSubCode, string modelName, string carInspectCertModel, string fullModel, string frameNo, string frameModel, string chassisNo, int carProperNo, int produceTypeOfYearNum, DateTime salesOrderDate, string salesOrderEmployeeCd, string salesOrderEmployeeNm, string salesOrderComment, int orderSideSystemVerCd, int tspAnswerDataMngNo, int tspSlipType, DateTime acceptAnOrderDate, int pmSlipNo, string acceptAnOrderNm, long tspTotalSlipPrice, string pmComment, string pmVersion, DateTime pmSendDate, int pmSlipKind, int pmOriginalSlipNo, string enterpriseName, string updEmployeeName, string dataInputSystemName) { }

        /// <summary></summary>
        public DateTime AcceptAnOrderDate { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public string AcceptAnOrderNm { get { return ""; } set { } }
        /// <summary></summary>
        public int AcceptAnOrderNo { get { return 0; } set { } }
        /// <summary></summary>
        public string CarInspectCertModel { get { return ""; } set { } }
        /// <summary></summary>
        public int CarProperNo { get { return 0; } set { } }
        /// <summary></summary>
        public int CategoryNo { get { return 0; } set { } }
        /// <summary></summary>
        public string ChassisNo { get { return ""; } set { } }
        /// <summary></summary>
        public int CommConditionDivCd { get { return 0; } set { } }
        /// <summary></summary>
        public DateTime CreateDateTime { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public int DataInputSystem { get { return 0; } set { } }
        /// <summary></summary>
        public string DataInputSystemName { get { return ""; } set { } }
        /// <summary></summary>
        public string EnterpriseCode { get { return ""; } set { } }
        /// <summary></summary>
        public string EnterpriseName { get { return ""; } set { } }
        /// <summary></summary>
        public Guid FileHeaderGuid { get { return Guid.Empty; } set { } }
        /// <summary></summary>
        public string FrameModel { get { return ""; } set { } }
        /// <summary></summary>
        public string FrameNo { get { return ""; } set { } }
        /// <summary></summary>
        public string FullModel { get { return ""; } set { } }
        /// <summary></summary>
        public string InstSlipNoStr { get { return ""; } set { } }
        /// <summary></summary>
        public int LogicalDeleteCode { get { return 0; } set { } }
        /// <summary></summary>
        public int MakerCode { get { return 0; } set { } }
        /// <summary></summary>
        public int ModelCode { get { return 0; } set { } }
        /// <summary></summary>
        public int ModelDesignationNo { get { return 0; } set { } }
        /// <summary></summary>
        public string ModelName { get { return ""; } set { } }
        /// <summary></summary>
        public int ModelSubCode { get { return 0; } set { } }
        /// <summary></summary>
        public int NumberPlate1Code { get { return 0; } set { } }
        /// <summary></summary>
        public string NumberPlate1Name { get { return ""; } set { } }
        /// <summary></summary>
        public string NumberPlate2 { get { return ""; } set { } }
        /// <summary></summary>
        public string NumberPlate3 { get { return ""; } set { } }
        /// <summary></summary>
        public int NumberPlate4 { get { return 0; } set { } }
        /// <summary></summary>
        public int OrderContentsDivCd { get { return 0; } set { } }
        /// <summary></summary>
        public int OrderSideSystemVerCd { get { return 0; } set { } }
        /// <summary></summary>
        public string PmComment { get { return ""; } set { } }
        /// <summary></summary>
        public string PmEnterpriseCode { get { return ""; } set { } }
        /// <summary></summary>
        public int PmOriginalSlipNo { get { return 0; } set { } }
        /// <summary></summary>
        public DateTime PmSendDate { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public int PmSlipKind { get { return 0; } set { } }
        /// <summary></summary>
        public int PmSlipNo { get { return 0; } set { } }
        /// <summary></summary>
        public string PmVersion { get { return ""; } set { } }
        /// <summary></summary>
        public int ProduceTypeOfYearNum { get { return 0; } set { } }
        /// <summary></summary>
        public string SalesOrderComment { get { return ""; } set { } }
        /// <summary></summary>
        public DateTime SalesOrderDate { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public string SalesOrderEmployeeCd { get { return ""; } set { } }
        /// <summary></summary>
        public string SalesOrderEmployeeNm { get { return ""; } set { } }
        /// <summary></summary>
        public int SlipKind { get { return 0; } set { } }
        /// <summary></summary>
        public string SlipNo { get { return ""; } set { } }
        /// <summary></summary>
        public int TspAnswerDataMngNo { get { return 0; } set { } }
        /// <summary></summary>
        public int TspCommCount { get { return 0; } set { } }
        /// <summary></summary>
        public int TspCommNo { get { return 0; } set { } }
        /// <summary></summary>
        public int TspSlipType { get { return 0; } set { } }
        /// <summary></summary>
        public long TspTotalSlipPrice { get { return 0; } set { } }
        /// <summary></summary>
        public string UpdAssemblyId1 { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdAssemblyId2 { get { return ""; } set { } }
        /// <summary></summary>
        public DateTime UpdateDateTime { get { return DateTime.Now; } set { } }
        /// <summary></summary>
        public string UpdEmployeeCode { get { return ""; } set { } }
        /// <summary></summary>
        public string UpdEmployeeName { get { return ""; } set { } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TspSdRvDt Clone() { return null; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ArrayList Compare(TspSdRvDt target) { return null; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspSdRvDt1"></param>
        /// <param name="tspSdRvDt2"></param>
        /// <returns></returns>
        public static ArrayList Compare(TspSdRvDt tspSdRvDt1, TspSdRvDt tspSdRvDt2) { return null; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Equals(TspSdRvDt target) { return false; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspSdRvDt1"></param>
        /// <param name="tspSdRvDt2"></param>
        /// <returns></returns>
        public static bool Equals(TspSdRvDt tspSdRvDt1, TspSdRvDt tspSdRvDt2) { return false; }
    }
}
