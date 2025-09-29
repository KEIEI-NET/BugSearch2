//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2010/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/09/29  修正内容 : Redmine14492対応
//----------------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections.Generic; // ADD 2010/09/29

namespace Broadleaf.Windows.Forms
{
    // ---DEL 2010/09/29 -------------------->>>
    ///// <summary>
    ///// 掛率設定マスタメン用ユーザー設定クラス
    ///// </summary>
    ///// <remarks>
    ///// <br>Note        : 掛率設定マスタメン用のユーザー設定情報を管理するクラスです。</br>
    ///// <br>Programmer	: 楊明俊</br>
    ///// <br>Date		: 2010/08/12</br>
    ///// <br></br>
    ///// </remarks>
    //[Serializable]
    //public class RateProtyMngConstruction
    //{
    //    // ===================================================================================== //
    //    // プライベート変数
    //    // ===================================================================================== //
    //    # region ■ Private Members
    //    private int _cellMoveValue;

    //    private const int DEFAULT_CELLMOVE_VALUE = 0;
    //    # endregion ■ Private Members


    //    // ===================================================================================== //
    //    // コンストラクタ
    //    // ===================================================================================== //
    //    # region ■ Constructors
    //    /// <summary>
    //    /// 掛率設定マスタメン用ユーザー設定クラス
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
    //    /// <br>Programmer	: 楊明俊</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngConstruction()
    //    {
    //        this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
    //    }

    //    /// <summary>
    //    /// 掛率設定マスタメン用ユーザー設定クラス
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
    //    /// <br>Programmer	: 楊明俊</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngConstruction(int cellMoveValue)
    //    {
    //        this._cellMoveValue = cellMoveValue;
    //    }
    //    # endregion ■ Constructors


    //    // ===================================================================================== //
    //    // プロパティ
    //    // ===================================================================================== //
    //    # region ■ Properties
    //    /// <summary>セル移動設定プロパティ</summary>
    //    public int CellMoveValue
    //    {
    //        get { return this._cellMoveValue; }
    //        set { this._cellMoveValue = value; }
    //    }

    //    /// <summary>
    //    /// 掛率設定マスタメン用ユーザー設定クラス複製処理
    //    /// </summary>
    //    /// <returns>掛率設定マスタメン用ユーザー設定クラス</returns>
    //    public RateProtyMngConstruction Clone()
    //    {
    //        return new RateProtyMngConstruction(this._cellMoveValue);
    //    }

    //    # endregion ■ Properties
    //}
    // ---DEL 2010/09/29 --------------------<<<

    /// <summary>
    /// 掛率設定マスタメン用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率設定マスタメンのユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer	: 楊明俊</br>
    /// <br>Date		: 2010/08/12</br>
    /// </remarks>
    public class RateProtyMngConstructionAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Members
        private static RateProtyMngConstruction _rateProtyMngConstruction;
        //private const string XML_FILE_NAME = "PMKHN09473U_Construction.XML"; // DEL 2010/09/29
        private const string XML_FILE_NAME = "PMKHN09470U_Construction.XML"; // ADD 2010/09/29
        private string _xmlFileName = "";
        # endregion ■ Private Members


        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■ Constructors
        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngConstructionAcs()
        {
            this._xmlFileName = XML_FILE_NAME;
            if (_rateProtyMngConstruction == null)
            {
                _rateProtyMngConstruction = new RateProtyMngConstruction();
            }
            this.Deserialize();
        }

        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngConstructionAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_rateProtyMngConstruction == null)
            {
                _rateProtyMngConstruction = new RateProtyMngConstruction();
            }
            this.Deserialize();
        }
        # endregion ■ Constructors


        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region ■ Event
        /// <summary>データ変更後発生イベント</summary>
        public static event EventHandler DataChanged;
        # endregion ■ Event


        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■ Properties
        /// <summary>セル移動設定値プロパティ</summary>
        public int CellMove
        {
            get
            {
                if (_rateProtyMngConstruction == null)
                {
                    _rateProtyMngConstruction = new RateProtyMngConstruction();
                }
                return _rateProtyMngConstruction.CellMoveValue;
            }
            set
            {
                if (_rateProtyMngConstruction == null)
                {
                    _rateProtyMngConstruction = new RateProtyMngConstruction();
                }
                _rateProtyMngConstruction.CellMoveValue = value;
            }
        }
        # endregion ■ Properties


        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■ Public Methods
        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率設定マスタメン用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_rateProtyMngConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                _rateProtyMngConstruction = UserSettingController.DeserializeUserSetting<RateProtyMngConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
            }
        }
        # endregion ■ Public Methods
    }
}
