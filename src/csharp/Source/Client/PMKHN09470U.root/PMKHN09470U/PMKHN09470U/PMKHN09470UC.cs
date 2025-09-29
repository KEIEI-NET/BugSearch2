//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/09/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率設定マスタメン用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率設定マスタメン用のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer	: 朱 猛</br>
    /// <br>Date		: 2010/09/29</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RateProtyMngConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Members
        private int _cellMoveValue;

        private const int DEFAULT_CELLMOVE_VALUE = 0;
        # endregion ■ Private Members


        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■ Constructors
        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/09/29</br>
        /// </remarks>
        public RateProtyMngConstruction()
        {
            this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
        }

        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/09/29</br>
        /// </remarks>
        public RateProtyMngConstruction(int cellMoveValue)
        {
            this._cellMoveValue = cellMoveValue;
        }
        # endregion ■ Constructors


        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■ Properties
        /// <summary>セル移動設定プロパティ</summary>
        public int CellMoveValue
        {
            get { return this._cellMoveValue; }
            set { this._cellMoveValue = value; }
        }

        /// <summary>
        /// 掛率設定マスタメン用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>掛率設定マスタメン用ユーザー設定クラス</returns>
        public RateProtyMngConstruction Clone()
        {
            return new RateProtyMngConstruction(this._cellMoveValue);
        }

        # endregion ■ Properties
    }
}
