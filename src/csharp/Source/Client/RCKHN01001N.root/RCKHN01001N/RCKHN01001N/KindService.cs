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
    /// 種別マスタ提供サービス クライアント プロキシ クラス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "KindServiceSoap", Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseResType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseReqType))]
    public partial class KindService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        /// <summary>
        /// 種別マスタ提供サービス
        /// </summary>
        public KindService()
        {
            // -- UPD 2010/07/30 ----------------------------------->>>
            //this.Url = Broadleaf.RCDS.Web.Services.Properties.Settings.Default.KindServiceURL;
            this.Url = GetRCMarketURL.GetMarketAPURL() + "kindservice.asmx";
            // -- UPD 2010/07/30 -----------------------------------<<<
            
        }

        /// <summary>
        /// 種別マスタ一覧取得
        /// </summary>
        /// <param name="GetKindListReq">SOAPリクエスト</param>
        /// <returns>SOAPレスポンス</returns>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://broadleaf.co.jp/rcds/webservice/GetKindList", RequestElementName = "GetKindListReqType", RequestNamespace = "http://broadleaf.co.jp/rcds/webservice/", ResponseElementName = "GetKindListResType", ResponseNamespace = "http://broadleaf.co.jp/rcds/webservice/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetKindListRes")]
        public GetKindListResType GetKindList(GetKindListReqType GetKindListReq)
        {
            object[] results = this.Invoke("GetKindList", new object[] {
                        GetKindListReq});
            return ((GetKindListResType)(results[0]));
        }

        /// <summary>
        /// 種別マスタ一覧取得 (非同期 - 開始)
        /// </summary>
        /// <param name="GetKindListReq"></param>
        /// <param name="callback"></param>
        /// <param name="asyncState"></param>
        /// <returns></returns>
        public System.IAsyncResult BeginGetKindList(GetKindListReqType GetKindListReq, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetKindList", new object[] {
                        GetKindListReq}, callback, asyncState);
        }

        /// <summary>
        /// 種別マスタ一覧取得 (非同期 - 終了)
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public GetKindListResType EndGetKindList(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GetKindListResType)(results[0]));
        }
    }

    /// <summary>
    /// 種別マスタ一覧取得メソッドリクエスト
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetKindListReqType : RcdsBaseReqType
    {
    }

    /// <summary>
    /// 種別マスタ情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class KindType
    {
        /// <summary>
        /// 種別コード
        /// </summary>
        public int KindCode;

        /// <summary>
        /// 種別名称
        /// </summary>
        public string KindName;

        /// <summary>
        /// 種別記号
        /// </summary>
        public string KindMark;

        /// <summary>
        /// 表示順位
        /// </summary>
        public int ShowRank;
    }

    /// <summary>
    /// 種別マスタ一覧取得メソッドレスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetKindListResType : RcdsBaseResType
    {
        /// <summary>
        /// 種別マスタ情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("Kind")]
        public KindType[] KindList;

        /// <summary>
        /// 種別マスタ最終更新日時
        /// </summary>
        public string DateTime;
    }
}
