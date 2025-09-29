namespace Broadleaf.RCDS.Web.Services
{
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Configuration;

    /// <summary>
    /// 部品詳細URL通知サービス クライアント プロキシ クラス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "PartsDetailURLServiceSoap", Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseResType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseReqType))]
    public partial class PartsDetailURLService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        /// <summary>
        /// 部品詳細URL通知サービス
        /// </summary>
        public PartsDetailURLService()
        {
            // -- UPD 2010/07/30 ---------------------------->>>
            //this.Url = Broadleaf.RCDS.Web.Services.Properties.Settings.Default.PartsDetailURLServiceURL;
            this.Url = GetRCMarketURL.GetMarketAPURL() + "partsdetailurlservice.asmx";
            // -- UPD 2010/07/30 ----------------------------<<<
        }

        /// <summary>
        /// URL取得
        /// </summary>
        /// <param name="GetURLReq">SOAPリクエスト</param>
        /// <returns>SOAPレスポンス</returns>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://broadleaf.co.jp/rcds/webservice/GetURL", RequestElementName = "GetURLReqType", RequestNamespace = "http://broadleaf.co.jp/rcds/webservice/", ResponseElementName = "GetURLResType", ResponseNamespace = "http://broadleaf.co.jp/rcds/webservice/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetURLRes")]
        public GetURLResType GetURL(GetURLReqType GetURLReq)
        {
            object[] results = this.Invoke("GetURL", new object[] {
                        GetURLReq});
            return ((GetURLResType)(results[0]));
        }

        /// <summary>
        /// URL取得 (非同期 - 開始)
        /// </summary>
        /// <param name="GetURLReq"></param>
        /// <param name="callback"></param>
        /// <param name="asyncState"></param>
        /// <returns></returns>
        public System.IAsyncResult BeginGetURL(GetURLReqType GetURLReq, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetURL", new object[] {
                        GetURLReq}, callback, asyncState);
        }

        /// <summary>
        /// URL取得 (非同期 - 終了)
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public GetURLResType EndGetURL(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GetURLResType)(results[0]));
        }
    }

    /// <summary>
    /// URL取得メソッドリクエスト
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetURLReqType : RcdsBaseReqType
    {
        /// <summary>
        /// PS番号情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("PSNo")]
        public PSNoType[] PSNoList;
    }

    /// <summary>
    /// PS番号情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class PSNoType
    {
        /// <summary>
        /// PS番号
        /// </summary>
        public int PSNo;
    }

    /// <summary>
    /// URL情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class URLType
    {
        /// <summary>
        /// 部品詳細表示URL
        /// </summary>
        public string URL;
    }

    /// <summary>
    /// URL取得メソッドレスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetURLResType : RcdsBaseResType
    {
        /// <summary>
        /// URL情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("URL")]
        public URLType[] URLList;
    }
}
