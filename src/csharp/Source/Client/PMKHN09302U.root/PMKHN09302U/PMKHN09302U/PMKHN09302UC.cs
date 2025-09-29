using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///  掛率マスタ画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>NSユーザー改良要望一覧連番265の対応</br>
    /// <br>Note       : 掛率マスタ画面のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : caohh 連番265</br>
    /// <br>Date       : 2011/08/05</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RateInputConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private int _saveInfoDiv;
        private const int DEFAULT_SAVEINFODIV = 0;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 掛率マスタ画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public RateInputConstruction()
        {
            this._saveInfoDiv = DEFAULT_SAVEINFODIV;
        }

        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラス
		/// </summary>
		/// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 掛率マスタ画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
		/// </remarks>
        public RateInputConstruction(int saveInfoDiv)
		{
            this._saveInfoDiv = saveInfoDiv;
		}
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>保存前情報区分プロパティ</summary>
        public int SaveInfoDiv
        {
            get { return this._saveInfoDiv; }
            set { this._saveInfoDiv = value; }
        }
        # endregion

        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>掛率マスタ画面用ユーザー設定クラス</returns>
        public RateInputConstruction Clone()
        {
            return new RateInputConstruction(this._saveInfoDiv);
        }
    }

    /// <summary>
    /// 掛率マスタ画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>NSユーザー改良要望一覧連番265の対応</br>
    /// <br>Note       :掛率マスタ画面のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/05</br>
    /// <br></br>
    /// </remarks>
    public class RateInputConstructionAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private static RateInputConstruction _rateInputConstruction;
        private const string XML_FILE_NAME = "PMKHN09300U_Construction.XML";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 掛率マスタ画面用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public RateInputConstructionAcs()
        {
            if (_rateInputConstruction == null)
            {
                _rateInputConstruction = new RateInputConstruction();
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>保存前情報区分プロパティ</summary>
        public int SaveInfoDiv
        {
            get
            {
                if (_rateInputConstruction == null)
                {
                    _rateInputConstruction = new RateInputConstruction();
                }
                return _rateInputConstruction.SaveInfoDiv;
            }
            set
            {
                if (_rateInputConstruction == null)
                {
                    _rateInputConstruction = new RateInputConstruction();
                }
                _rateInputConstruction.SaveInfoDiv = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 掛率マスタ画面用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_rateInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
        }

        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 掛率マスタ画面用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _rateInputConstruction = UserSettingController.DeserializeUserSetting<RateInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
        }
        # endregion
    }
}
