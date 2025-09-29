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
    /// 品質マスタ提供サービス クライアント プロキシ クラス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "QualityServiceSoap", Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseResType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseReqType))]
    public partial class QualityService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        /// <summary>
        /// 品質マスタ提供サービス
        /// </summary>
        public QualityService()
        {
            // -- UPD 2010/07/30 --------------------------------->>>
            //this.Url = Broadleaf.RCDS.Web.Services.Properties.Settings.Default.QualityServiceURL;
            this.Url = GetRCMarketURL.GetMarketAPURL() + "qualityservice.asmx";
            // -- UPD 2010/07/30 ---------------------------------<<<
        }

        /// <summary>
        /// 品質マスタ一覧取得
        /// </summary>
        /// <param name="GetQualityListReq">SOAPリクエスト</param>
        /// <returns>SOAPレスポンス</returns>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://broadleaf.co.jp/rcds/webservice/GetQualityList", RequestElementName = "GetQualityListReqType", RequestNamespace = "http://broadleaf.co.jp/rcds/webservice/", ResponseElementName = "GetQualityListResType", ResponseNamespace = "http://broadleaf.co.jp/rcds/webservice/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetQualityListRes")]
        public GetQualityListResType GetQualityList(GetQualityListReqType GetQualityListReq)
        {
            object[] results = this.Invoke("GetQualityList", new object[] {
                        GetQualityListReq});
            return ((GetQualityListResType)(results[0]));
        }

        /// <summary>
        /// 品質マスタ一覧取得 (非同期 - 開始)
        /// </summary>
        /// <param name="GetQualityListReq"></param>
        /// <param name="callback"></param>
        /// <param name="asyncState"></param>
        /// <returns></returns>
        public System.IAsyncResult BeginGetQualityList(GetQualityListReqType GetQualityListReq, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetQualityList", new object[] {
                        GetQualityListReq}, callback, asyncState);
        }

        /// <summary>
        /// 品質マスタ一覧取得 (非同期 - 終了)
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public GetQualityListResType EndGetQualityList(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GetQualityListResType)(results[0]));
        }
    }

    /// <summary>
    /// 品質マスタ一覧取得メソッドリクエスト
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetQualityListReqType : RcdsBaseReqType
    {
    }

    /// <summary>
    /// 品質マスタ情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class QualityType
    {
        /// <summary>
        /// 品質コード
        /// </summary>
        public int QualityCode;

        /// <summary>
        /// 品質名称
        /// </summary>
        public string QualityName;

        /// <summary>
        /// 品質記号
        /// </summary>
        public string QualityMark;

        /// <summary>
        /// 表示順位
        /// </summary>
        public int ShowRank;
    }

    /// <summary>
    /// 品質マスタ一覧取得メソッドレスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetQualityListResType : RcdsBaseResType
    {
        /// <summary>
        /// 品質マスタ情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("Quality")]
        public QualityType[] QualityList;

        /// <summary>
        /// 品質マスタ最終更新日時
        /// </summary>
        public string DateTime;
    }
}
