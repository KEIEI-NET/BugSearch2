using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 検索見積用初期値クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索見積の初期値を管理するクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.09.25</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EstimateInputInitData
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _enterpriseCode = "";
        private int _customerCode = 0;
        private const string ctXML_FILE_NAME = "PMMIT01012A_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 検索見積用初期値クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索見積用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.25</br>
        /// </remarks>
        public EstimateInputInitData()
        {
            //
        }

        /// <summary>
        /// 検索見積用ユーザー設定クラス
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <remarks>
        /// <br>Note       : 検索見積用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.09.25</br>
        /// </remarks>
        public EstimateInputInitData( string enterpriseCode, int customerCode) 
        {
            this._enterpriseCode = enterpriseCode;
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
                EstimateInputInitData data = UserSettingController.DeserializeUserSetting<EstimateInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                this._enterpriseCode = data.EnterpriseCode;
                this._customerCode = data.CustomerCode;
            }
        }
        # endregion
    }
}