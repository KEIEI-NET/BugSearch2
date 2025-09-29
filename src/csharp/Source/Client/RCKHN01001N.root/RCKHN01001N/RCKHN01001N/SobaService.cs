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
    /// 相場情報提供サービス クライアント プロキシ クラス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "SobaServiceSoap", Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseResType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RcdsBaseReqType))]
    public partial class SobaService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        /// <summary>
        /// 相場情報提供サービス
        /// </summary>
        public SobaService()
        {
            // -- UPD 2010/07/30 ------------------------------->>>
            //this.Url = Broadleaf.RCDS.Web.Services.Properties.Settings.Default.SobaServiceURL;
            this.Url = GetRCMarketURL.GetMarketAPURL() + "sobaservice.asmx";
            // -- UPD 2010/07/30 -------------------------------<<<
        }

        /// <summary>
        /// 相場情報取得
        /// </summary>
        /// <param name="GetSobaReq">SOAPリクエスト</param>
        /// <returns>SOAPレスポンス</returns>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://broadleaf.co.jp/rcds/webservice/GetSoba", RequestElementName = "GetSobaReqType", RequestNamespace = "http://broadleaf.co.jp/rcds/webservice/", ResponseElementName = "GetSobaResType", ResponseNamespace = "http://broadleaf.co.jp/rcds/webservice/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetSobaRes")]
        public GetSobaResType GetSoba(GetSobaReqType GetSobaReq)
        {
            object[] results = this.Invoke("GetSoba", new object[] {
                        GetSobaReq});
            return ((GetSobaResType)(results[0]));
        }

        /// <summary>
        /// 相場情報取得 (非同期 - 開始)
        /// </summary>
        /// <param name="GetSobaReq"></param>
        /// <param name="callback"></param>
        /// <param name="asyncState"></param>
        /// <returns></returns>
        public System.IAsyncResult BeginGetSoba(GetSobaReqType GetSobaReq, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetSoba", new object[] {
                        GetSobaReq}, callback, asyncState);
        }

        /// <summary>
        /// 相場情報取得 (非同期 - 終了)
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public GetSobaResType EndGetSoba(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((GetSobaResType)(results[0]));
        }
    }

    /// <summary>
    /// 相場情報取得メソッドリクエスト
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetSobaReqType : RcdsBaseReqType
    {
        /// <summary>
        /// BLコード情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("BLCode")]
        public BLCodeType[] BLCodeList;

        /// <summary>
        /// 関連型式
        /// </summary>
        public string Model;

        /// <summary>
        /// 地区コード
        /// </summary>
        public int AreaCode;

        /// <summary>
        /// 種別コード
        /// </summary>
        public int KindCode;

        /// <summary>
        /// 品質コード
        /// </summary>
        public int QualityCode;

        /// <summary>
        /// マスタ取得日時情報
        /// </summary>
        public MtDateTimeType MtDateTime;
    }

    /// <summary>
    /// BLコード情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class BLCodeType
    {
        /// <summary>
        /// BLコード
        /// </summary>
        public string BLCode;
    }

    /// <summary>
    /// マスタ更新情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class MtFlagType
    {
        /// <summary>
        /// 地区マスタ更新フラグ (0:更新なし 1:更新あり)
        /// </summary>
        public int AreaFlag;

        /// <summary>
        /// 種別マスタ更新フラグ (0:更新なし 1:更新あり)
        /// </summary>
        public int KindFlag;

        /// <summary>
        /// 品質マスタ更新フラグ (0:更新なし 1:更新あり)
        /// </summary>
        public int QualityFlag;
    }

    /// <summary>
    /// 相場情報取得メソッドレスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class SobaType
    {
        /// <summary>
        /// BLコード
        /// </summary>
        public string BLCode;

        /// <summary>
        /// 算術平均相場
        /// </summary>
        public int Avg;

        /// <summary>
        /// 標準偏差相場
        /// </summary>
        public int StdDev;

        /// <summary>
        /// 最安価格
        /// </summary>
        public int Min;

        /// <summary>
        /// 最高価格
        /// </summary>
        public int Max;

        /// <summary>
        /// 該当件数
        /// </summary>
        public int Cnt;
    }

    /// <summary>
    /// 相場情報取得メソッドレスポンス
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class GetSobaResType : RcdsBaseResType
    {
        /// <summary>
        /// 相場情報
        /// </summary>
        [System.Xml.Serialization.XmlArrayItemAttribute("Soba")]
        public SobaType[] SobaList;

        /// <summary>
        /// マスタ更新情報
        /// </summary>
        public MtFlagType MtFlag;
    }

    /// <summary>
    /// マスタ取得日時情報
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://broadleaf.co.jp/rcds/webservice/")]
    public partial class MtDateTimeType
    {
        /// <summary>
        /// 地区マスタ取得日時 (YYYYMMDDHHNNSS形式)
        /// </summary>
        public string AreaDateTime;

        /// <summary>
        /// 種別マスタ取得日時 (YYYYMMDDHHNNSS形式)
        /// </summary>
        public string KindDateTime;

        /// <summary>
        /// 品質マスタ取得日時 (YYYYMMDDHHNNSS形式)
        /// </summary>
        public string QualityDateTime;
    }
}
