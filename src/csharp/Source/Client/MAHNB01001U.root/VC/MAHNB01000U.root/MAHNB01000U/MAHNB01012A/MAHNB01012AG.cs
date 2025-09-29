using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上入力用初期値クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値を管理するクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    [Serializable]
    public class SalesSlipInputInitData
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _enterpriseCode = string.Empty;
        private string _sectionCode = string.Empty;
        private int _customerCode = 0;
        private const string ctXML_FILE_NAME = "MAHNB01012A_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 売上入力用初期値クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上入力用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public SalesSlipInputInitData()
        {
            //
        }

        /// <summary>
        /// 売上入力用ユーザー設定クラス
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <remarks>
        /// <br>Note       : 売上入力用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public SalesSlipInputInitData(string enterpriseCode, string sectionCode, int customerCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>企業コード</summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>拠点コード</summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>得意先コード</summary>
        public int CustomerCode
        {
            get { return this._customerCode; }
            set { this._customerCode = value; }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// シリアライズ処理
        /// </summary>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(this, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));
        }

        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME)))
            {
                SalesSlipInputInitData data = UserSettingController.DeserializeUserSetting<SalesSlipInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                this._enterpriseCode = data.EnterpriseCode;
                this._sectionCode = data.SectionCode;
                this._customerCode = data.CustomerCode;
            }
        }
        # endregion
    }
}