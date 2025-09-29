using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入入力用初期値クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入入力の初期値を管理するクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>2010.01.06 30434 工藤 恵優 MANTIS[0014857] 担当者を保存後も保持する設定を追加</br>
    /// </remarks>
    [Serializable]
    public class StockSlipInputInitData
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _enterpriseCode = "";
        private string _sectionCode = "";
        private int _supplierCode = 0;
        private string _warehouseCode = "";
        private string _stockAgentCode = "";    // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加
        private const string ctXML_FILE_NAME = "MAKON01112A_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 仕入入力用初期値クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入入力用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
        public StockSlipInputInitData()
        {
            //
        }

        /// <summary>
        /// 仕入入力用ユーザー設定クラス
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
		/// <param name="supplierCode">仕入先コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="stockAgentCode">担当者コード</param>
        /// <remarks>
        /// <br>Note       : 仕入入力用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2008.05.21</br>
        /// <br>2010.01.06 30434 工藤 恵優 MANTIS[0014857] 担当者を保存後も保持する設定を追加</br>
        /// </remarks>
        public StockSlipInputInitData(string enterpriseCode, string sectionCode, int supplierCode, string warehouseCode,
            string stockAgentCode   // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加
        )
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
			this._supplierCode = supplierCode;
            this._warehouseCode = warehouseCode;
            this._stockAgentCode = stockAgentCode;  // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加
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

        /// <summary>仕入先コード</summary>
        public int SupplierCode
        {
			get { return this._supplierCode; }
			set { this._supplierCode = value; }
        }

        /// <summary>倉庫コード</summary>
        public string WarehouseCode
        {
            get { return this._warehouseCode; }
            set { this._warehouseCode = value; }
        }

        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
        /// <summary>担当者コード</summary>
        public string StockAgentCode
        {
            get { return this._stockAgentCode; }
            set { this._stockAgentCode = value; }
        }
        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<
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
                try
                {
                    StockSlipInputInitData data = UserSettingController.DeserializeUserSetting<StockSlipInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                    this._enterpriseCode = data.EnterpriseCode;
                    this._sectionCode = data.SectionCode;
                    this._supplierCode = data.SupplierCode;
                    this._warehouseCode = data.WarehouseCode;
                    this._stockAgentCode = data.StockAgentCode; // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));
                }
            }
        }
        # endregion
    }
}