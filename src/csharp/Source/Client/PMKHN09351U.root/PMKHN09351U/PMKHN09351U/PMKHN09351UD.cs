//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先一括修正用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先一括修正用のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/11/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CustomerCustomerChangeConstruction
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
        /// 得意先一括修正用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstruction()
        {
            this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
        }

        /// <summary>
        /// 得意先一括修正用ユーザー設定クラス
        /// </summary>
        /// <param name="cellMoveValue">セル移動設定値</param>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstruction(int cellMoveValue)
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
        /// 得意先一括修正用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>得意先一括修正用ユーザー設定クラス</returns>
        public CustomerCustomerChangeConstruction Clone()
        {
            return new CustomerCustomerChangeConstruction(this._cellMoveValue);
        }

        # endregion ■ Properties
    }

    /// <summary>
    /// 得意先一括修正用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先一括修正のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/11/20</br>
    /// <br>Update Note: </br>
    /// <br>2006.11.27 men コンストラクタにてXMLのパスを取得するように改良（在庫部品対応）</br>
    /// </remarks>
    public class CustomerCustomerChangeConstructionAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■ Private Members
        private static CustomerCustomerChangeConstruction _customerSearchConstruction;
        private const string XML_FILE_NAME = "PMKHN09351U_Construction.XML";
        private string _xmlFileName = "";
        # endregion ■ Private Members


        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■ Constructors
        /// <summary>
        /// 得意先一括修正用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstructionAcs()
        {
            this._xmlFileName = XML_FILE_NAME;
            if (_customerSearchConstruction == null)
            {
                _customerSearchConstruction = new CustomerCustomerChangeConstruction();
            }
            this.Deserialize();
        }

        /// <summary>
        /// 得意先一括修正用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <param name="xmlFileName">XMLファイル名</param>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstructionAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_customerSearchConstruction == null)
            {
                _customerSearchConstruction = new CustomerCustomerChangeConstruction();
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
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerCustomerChangeConstruction();
                }
                return _customerSearchConstruction.CellMoveValue;
            }
            set
            {
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerCustomerChangeConstruction();
                }
                _customerSearchConstruction.CellMoveValue = value;
            }
        }
        # endregion ■ Properties


        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■ Public Methods
        /// <summary>
        /// 得意先一括修正用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 980079 鈴木正臣</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_customerSearchConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// 得意先一括修正用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 980079 鈴木正臣</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                _customerSearchConstruction = UserSettingController.DeserializeUserSetting<CustomerCustomerChangeConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
            }
        }
        # endregion ■ Public Methods
    }
}
