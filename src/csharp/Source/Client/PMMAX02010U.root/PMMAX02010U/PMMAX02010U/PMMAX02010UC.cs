//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品・在庫一括更新
// プログラム概要   : 出品・在庫一括更新
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Application.Common;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 初期化用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 初期化用クラス。</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2016/01/22</br>
    /// </remarks>
    public class PMMAX02010UC
    {
        #region Public Member
        /// <summary>
        /// 設定XMLファイル名
        /// </summary>
        public string XML_FILE_NAME = "UISettings_PMMAX02010U.xml";
        #endregion

        #region Private Member
        // ユーザー設定リスト
        private ExportSalesData _exportSalesDataList;
        #endregion

        # region プロパティ
        /// <summary>
        /// 当面のユーザー
        /// </summary>
        public ExportSalesData ExportSalesDataList
        {
            get { return _exportSalesDataList; }
            set { _exportSalesDataList = value; }
        }
        # endregion

        #region コンストラクタ
        /// <summary>
        /// PMMAX02010UCのコンストラクタ
        /// </summary>
        public PMMAX02010UC()
        {

        }
        #endregion

        # region Public Methods
        /// <summary>
        /// 出品一括更新用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出品一括更新用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // シリアライズ処理
                UserSettingController.SerializeUserSetting(_exportSalesDataList, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// 出品一括更新用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出品一括更新用ユーザー設定デシリアライズ処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._exportSalesDataList = UserSettingController.DeserializeUserSetting<ExportSalesData>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                }
                catch
                {
                    this._exportSalesDataList = new ExportSalesData();
                }
            }
            else
            {
                this._exportSalesDataList = new ExportSalesData();
            }
        }
        # endregion
    }

    #region 出品一括更新用ユーザー設定情報クラス(XML用)
    /// <summary>
    /// 出品一括更新用ユーザー設定情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品一括更新のユーザー設定情報を管理するリスト</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ExportSalesData
    {
        private List<ExportSalesFormSaveItems> _exportSalesDataList;

        /// <summary>
        /// 
        /// </summary>
        public List<ExportSalesFormSaveItems> ExportSalesDataList
        {
            get
            {
                if (_exportSalesDataList == null) _exportSalesDataList = new List<ExportSalesFormSaveItems>();
                return _exportSalesDataList;
            }
            set
            {
                _exportSalesDataList = value;
            }
        }
    }

    /// <summary>
    /// 出品一括更新用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品一括更新のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ExportSalesFormSaveItems
    {
        # region コンストラクタ

        /// <summary>
        /// 得意先電子元帳ユーザー設定情報クラス
        /// </summary>
        public ExportSalesFormSaveItems()
        {

        }

        # endregion // コンストラクタ

        # region プライベート変数

        // 企業コード
        private string _enterPriseCode = "";

        // ログイン拠点コード
        private string _loginSectionCode = "";

        // 部品MAX得意先コード
        private string _maxCustomerCode = "";

        // 倉庫コードリスト
        private string _wareCodeList = "";

        // BLコード
        private string _blCode = "";

        // 部品メーカーコード
        private string _makerCode = "";

        // 中分類コード
        private string _goodsMGroup = "";

        // 商品掛率グループコード
        private string _rateGrpCode = "";

        // 仕入先コード
        private string _supplierCd = "";

        // 売価率下限値
        private int _salesRateLow;

        // 販売単価下限値
        private int _salesPriceLow;

        // チェックリスト出力選択
        private int _checkSelect;

        // チェックリスト出力先
        private string _checkFilePath = "";

        # endregion // プライベート変数

        # region プロパティ

        /// <summary>企業コード</summary>
        public string EnterPriseCode
        {
            get { return this._enterPriseCode; }
            set { this._enterPriseCode = value; }
        }

        /// <summary>ログイン拠点コード</summary>
        public string LoginSectionCode
        {
            get { return this._loginSectionCode; }
            set { this._loginSectionCode = value; }
        }

        /// <summary>部品MAX得意先コード</summary>
        public string MaxCustomerCode
        {
            get { return this._maxCustomerCode; }
            set { this._maxCustomerCode = value; }
        }

        /// <summary>倉庫コードリスト</summary>
        public string WareCodeList
        {
            get { return this._wareCodeList; }
            set { this._wareCodeList = value; }
        }

        /// <summary>BLコード</summary>
        public string BlCode
        {
            get { return this._blCode; }
            set { this._blCode = value; }
        }

        /// <summary>部品メーカーコード</summary>
        public string MakerCode
        {
            get { return this._makerCode; }
            set { this._makerCode = value; }
        }

        /// <summary>中分類コード</summary>
        public string GoodsMGroup
        {
            get { return this._goodsMGroup; }
            set { this._goodsMGroup = value; }
        }

        /// <summary>商品掛率グループコード</summary>
        public string RateGrpCode
        {
            get { return this._rateGrpCode; }
            set { this._rateGrpCode = value; }
        }

        /// <summary>仕入先コード</summary>
        public string SupplierCd
        {
            get { return this._supplierCd; }
            set { this._supplierCd = value; }
        }

        /// <summary>売価率下限値</summary>
        public int SalesRateLow
        {
            get { return this._salesRateLow; }
            set { this._salesRateLow = value; }
        }

        /// <summary>販売単価下限値</summary>
        public int SalesPriceLow
        {
            get { return this._salesPriceLow; }
            set { this._salesPriceLow = value; }
        }

        /// <summary>チェックリスト出力選択</summary>
        public int CheckSelect
        {
            get { return this._checkSelect; }
            set { this._checkSelect = value; }
        }

        /// <summary>チェックリスト出力先</summary>
        public string CheckFilePath
        {
            get { return this._checkFilePath; }
            set { this._checkFilePath = value; }
        }

        # endregion
    }
    #endregion
}
