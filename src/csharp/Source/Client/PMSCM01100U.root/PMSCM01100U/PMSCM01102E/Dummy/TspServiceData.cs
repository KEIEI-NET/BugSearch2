using System;
using System.Xml.Serialization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(TspServiceData))]
    public class TspServiceData
    {
        /// <summary></summary>
        public TspSdRvDt TspSdRvData;
        /// <summary></summary>
        public TspSdRvDtl[] TspSdRvDtlDataList;

        /// <summary>
        /// 
        /// </summary>
        public TspServiceData() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tspSdRvData"></param>
        /// <param name="tspSdRvDtlList"></param>
        public TspServiceData(TspSdRvDt tspSdRvData, TspSdRvDtl[] tspSdRvDtlList) { }
    }
}
