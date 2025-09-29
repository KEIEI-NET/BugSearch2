//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.IO;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 拠点変換設定画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点変換設定画面のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SectionCdInputConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        private ArrayList _secCdCSV;
        private ArrayList _secCdPM;

        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 拠点変換設定画面用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点変換設定画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public SectionCdInputConstruction()
        {

        }

        /// <summary>
        /// 拠点変換設定画面用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点変換設定画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public SectionCdInputConstruction(ArrayList aList, ArrayList bList)
        {
            this._secCdCSV = aList;
            this._secCdPM = bList;

        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>入力方法設定値プロパティ</summary>
        public ArrayList SecCdCSV
        {
            get { return this._secCdCSV; }
            set { this._secCdCSV = value; }
        }
        /// <summary>PMデータリスト</summary>
        public ArrayList SecCdPM
        {
            get { return this._secCdPM; }
            set { this._secCdPM = value; }
        }
        # endregion

        /// <summary>
        /// 拠点変換設定画面用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>拠点変換設定画面用ユーザー設定クラス</returns>
        public SectionCdInputConstruction Clone()
        {
            return new SectionCdInputConstruction(this._secCdCSV,this._secCdPM);
        }
    }

    /// <summary>
    /// 拠点変換設定画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点変換設定画面のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// </remarks>
    public class SectionCdInputConstructionAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private static SectionCdInputConstruction _sectionCdInputConstruction;
        private const string XML_FILE_NAME = "PMKOU02050U_Construction.XML";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 拠点変換設定画面用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点変換設定画面用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public SectionCdInputConstructionAcs()
        {
            if (_sectionCdInputConstruction == null)
            {
                _sectionCdInputConstruction = new SectionCdInputConstruction();
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Event
        /// <summary>データ変更後発生イベント</summary>
        public static event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>入力方法設定値プロパティ</summary>
        public ArrayList InputSecCdCSV
        {
            get
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                return _sectionCdInputConstruction.SecCdCSV;
            }
            set
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                _sectionCdInputConstruction.SecCdCSV = value;
            }
        }
        /// <summary>入力方法設定値プロパティ</summary>
        public ArrayList InputSecCdPM
        {
            get
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                return _sectionCdInputConstruction.SecCdPM;
            }
            set
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                _sectionCdInputConstruction.SecCdPM = value;
            }
        }

        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// 拠点変換設定画面用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点変換設定画面用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_sectionCdInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 拠点変換設定画面用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点変換設定画面用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _sectionCdInputConstruction = UserSettingController.DeserializeUserSetting<SectionCdInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
        }
        # endregion
    }
}
