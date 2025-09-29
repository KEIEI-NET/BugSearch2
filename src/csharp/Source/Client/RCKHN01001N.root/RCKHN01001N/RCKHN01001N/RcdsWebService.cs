namespace Broadleaf.RCDS.Web.Services
{
    /// <summary>
    /// 相場情報提供WEBサービス基底リクエスト
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class RcdsBaseReqType
    {
        /// <summary>
        /// 企業コード
        /// </summary>
        public string UC;

        /// <summary>
        /// アクセスチケット
        /// </summary>
        public string AT;

        /// <summary>
        /// ジェネレーションコード
        /// </summary>
        public string GC;
    }

    /// <summary>
    /// 相場情報提供WEBサービス基底レスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class RcdsBaseResType
    {
    }
}
