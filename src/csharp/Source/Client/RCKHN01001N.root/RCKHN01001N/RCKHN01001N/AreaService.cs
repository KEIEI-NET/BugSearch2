namespace Broadleaf.RCDS.Web.Services
{
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Configuration;
    using Broadleaf.Application.Resources;  // 2010/07/30 ADD
    using Broadleaf.Application.Common;     // 2010/07/30 ADD

    /// <summary>
    /// 地区マスタ提供サービス クライアント プロキシ クラス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "AreaServiceSoap", Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseResType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseReqType))]
    public partial class AreaService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        /// <summary>
        /// 地区マスタ提供サービス
        /// </summary>
        public AreaService()
        {
            // -- UPD 2010/07/30 ----------------------------------->>>
            //this.Url = Broadleaf.RCDS.Web.Services.Properties.Settings.Default.AreaServiceURL;
            this.Url = GetRCMarketURL.GetMarketAPURL() + "areaservice.asmx";
            // -- UPD 2010/07/30 -----------------------------------<<<
        }

        /// <summary>
        /// 地区マスタ一覧取得
        /// </summary>
        /// <param name="GetAreaListReq">SOAPリクエスト</param>
        /// <returns>SOAPレスポンス</returns>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://broadleaf.co.jp/rcds/webservice/GetAreaList", RequestElementName = "GetAreaListReqType", RequestNamespace = "http://broadleaf.co.jp/rcds/webservice/", ResponseElementName = "GetAreaListResType", ResponseNamespace = "http://broadleaf.co.jp/rcds/webservice/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetAreaListRes")]
        public GetAreaListResType GetAreaList(GetAreaListReqType GetAreaListReq)
        {
            object[] results = this.Invoke("GetAreaList", new object[] {
                        GetAreaListReq});
            return ((GetAreaListResType)(results[0]));
        }

        /// <summary>
        /// 地区マスタ一覧取得 (非同期 - 開始)
        /// </summary>
        /// <param name="GetAreaListReq"></param>
        /// <param name="callback"></param>
        /// <param name="asyncState"></param>
        /// <returns></returns>
        public System.IAsyncResult BeginGetAreaList(GetAreaListReqType GetAreaListReq, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetAreaList", new object[] {
                        GetAreaListReq}, callback, asyncState);
        }

        /// <summary>
        /// 地区マスタ一覧取得 (非同期 - 終了) 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public GetAreaListResType EndGetAreaList(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GetAreaListResType)(results[0]));
        }
    }

    /// <summary>
    /// 地区マスタ一覧取得メソッドリクエスト
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetAreaListReqType : RcdsBaseReqType
    {
    }

    /// <summary>
    /// 地区マスタ情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class AreaType
    {
        /// <summary>
        /// 地区コード
        /// </summary>
        public int AreaCode;

        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName;

        /// <summary>
        /// 表示順位
        /// </summary>
        public int ShowRank;
    }

    /// <summary>
    /// 地区マスタ一覧取得メソッドレスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetAreaListResType : RcdsBaseResType
    {
        /// <summary>
        /// 地区マスタ情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("Area")]
        public AreaType[] AreaList;

        /// <summary>
        /// 地区マスタ最終更新日時
        /// </summary>
        public string DateTime;
    }

    // -- ADD 2010/07/30 ----------------------------------------->>>
    /// <summary>
    /// 接続先取得用メソッド
    /// </summary>
    internal class GetRCMarketURL
    {
        public static string GetMarketAPURL()
        {
            return LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_MarketAP)
                  + LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_MarketAP,ConstantManagement_SF_PRO.IndexCode_Soba_WebPath);
        }
    }
    // -- ADD 2010/07/30 -----------------------------------------<<<

}
