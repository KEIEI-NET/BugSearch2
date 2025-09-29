using System;
using System.Xml.Serialization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(TspServiceDataManager))]
    public class TspServiceDataManager
    {
        /// <summary></summary>
        public string AccessTicket;
        /// <summary></summary>
        public string EnterpriseCode;
        /// <summary></summary>
        public string Message;
        /// <summary></summary>
        public int Status;
        /// <summary></summary>
        public TspServiceData[] TspServiceDataList;

        /// <summary>
        /// 
        /// </summary>
        public TspServiceDataManager() { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspServiceData"></param>
        public TspServiceDataManager(TspServiceData tspServiceData) { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspServiceDataList"></param>
        public TspServiceDataManager(TspServiceData[] tspServiceDataList) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int[] GetTspCommNoList() { return null; }

        /// <summary>
        /// 
        /// </summary>
        public TspRequest[] ResultTspRequestList
        {
            get { return null; }
            set { }
        }
    }
}
