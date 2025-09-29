//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタ（掛率優先管理パターン）（品番指定）
// プログラム概要   : 掛率設定マスタ（掛率優先管理パターン）（品番指定）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹
// 作 成 日  2010/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/09/29  修正内容 : Redmine14492対応
//----------------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    // ---DEL 2010/09/29 -------------------->>>
    ///// <summary>
    ///// 掛率設定マスタメン用ユーザー設定クラス
    ///// </summary>
    ///// <remarks>
    ///// <br>Note        : 掛率設定マスタメン用のユーザー設定情報を管理するクラスです。</br>
    ///// <br>Programmer	: 陳艶丹</br>
    ///// <br>Date		: 2010/08/12</br>
    ///// <br></br>
    ///// </remarks>
    //[Serializable]
    //public class RateProtyMngBlCdConstruction
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
    //    /// <br>Programmer	: 陳艶丹</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngBlCdConstruction()
    //    {
    //        this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
    //    }

    //    /// <summary>
    //    /// 掛率設定マスタメン用ユーザー設定クラス
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
    //    /// <br>Programmer	: 陳艶丹</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngBlCdConstruction(int cellMoveValue)
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
    //    public RateProtyMngBlCdConstruction Clone()
    //    {
    //        return new RateProtyMngBlCdConstruction(this._cellMoveValue);
    //    }

    //    # endregion ■ Properties
    //}
    // ---DEL 2010/09/29 --------------------<<<

    /// <summary>
    /// 掛率設定マスタメン用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率設定マスタメンのユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer	: 陳艶丹</br>
    /// <br>Date		: 2010/08/12</br>
    /// </remarks>
    public class RateProtyMngBlCdConstructionAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Members
        //private static RateProtyMngBlCdConstruction _rateProtyMngBlCdConstruction; // DEL 2010/09/29
        private static RateProtyMngConstruction _rateProtyMngBlCdConstruction; // ADD 2010/09/29
        //private const string XML_FILE_NAME = "PMKHN09472U_Construction.XML"; // DEL 2010/09/29
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
        /// <br>Programmer	: 陳艶丹</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngBlCdConstructionAcs()
        {
            this._xmlFileName = XML_FILE_NAME;
            if (_rateProtyMngBlCdConstruction == null)
            {
                //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
            }
            this.Deserialize();
        }

        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 陳艶丹</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngBlCdConstructionAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_rateProtyMngBlCdConstruction == null)
            {
                //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
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
                if (_rateProtyMngBlCdConstruction == null)
                {
                    //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                    _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
                }
                return _rateProtyMngBlCdConstruction.CellMoveValue;
            }
            set
            {
                if (_rateProtyMngBlCdConstruction == null)
                {
                    //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                    _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
                }
                _rateProtyMngBlCdConstruction.CellMoveValue = value;
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
        /// <br>Programmer	: 陳艶丹</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_rateProtyMngBlCdConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

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
        /// <br>Programmer	: 陳艶丹</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                //_rateProtyMngBlCdConstruction = UserSettingController.DeserializeUserSetting<RateProtyMngBlCdConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)); // DEL 2010/09/29
                _rateProtyMngBlCdConstruction = UserSettingController.DeserializeUserSetting<RateProtyMngConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)); // ADD 2010/09/29
            }
        }
        # endregion ■ Public Methods
    }
}
