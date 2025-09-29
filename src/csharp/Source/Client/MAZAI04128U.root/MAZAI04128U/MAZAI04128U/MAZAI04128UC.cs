using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 移動在庫明細データテーブル列表示コントロールクラス
    /// </summary>
    internal class StockMoveDetailRowVisibleControl
    {
        private Dictionary<StockMoveDetailColStatusKey, bool> _statusDictionary = new Dictionary<StockMoveDetailColStatusKey, bool>();

        /// <summary>
        /// 列表示非表示設定値追加処理
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="statusType">ステータスタイプ</param>
        /// <param name="value">値</param>
        /// <param name="hidden">表示非表示設定値</param>
        internal void Add(string colName, StatusType statusType, int value, bool hidden)
        {
            StockMoveDetailColStatusKey key = new StockMoveDetailColStatusKey(colName, statusType, value);

            if (this._statusDictionary.ContainsKey(key))
            {
                this._statusDictionary[key] = hidden;
            }
            else
            {
                this._statusDictionary.Add(key, hidden);
            }
        }

        /// <summary>
        /// 列表示非表示設定値取得処理
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="statusType">ステータスタイプ</param>
        /// <param name="value">値</param>
        /// <param name="hidden">表示非表示設定値</param>
        /// <returns>0:取得可能 0以外:取得失敗</returns>
        internal int GetHidden(string colName, StatusType statusType, int value, out bool hidden)
        {
            StockMoveDetailColStatusKey key = new StockMoveDetailColStatusKey(colName, statusType, value);

            if (this._statusDictionary.ContainsKey(key))
            {
                hidden = this._statusDictionary[key];
                return 0;
            }
            else
            {
                hidden = true;
                return -1;
            }
        }
    }

    /// <summary>
    /// 移動在庫明細データテーブル列ステータスキー構造体
    /// </summary>
    internal struct StockMoveDetailColStatusKey
    {
        string _colName;
        StatusType _statusType;
        int _value;

        /// <summary>
        /// 移動在庫明細データテーブル列ステータスキー構造体コンストラクタ
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="statusType">ステータスタイプ</param>
        /// <param name="value">値</param>
        internal StockMoveDetailColStatusKey(string colName, StatusType statusType, int value)
        {
            this._colName = colName;
            this._statusType = statusType;
            this._value = value;
        }

        /// <summary>列名称プロパティ</summary>
        internal string ColName
        {
            get { return _colName; }
            set { _colName = value; }
        }

        /// <summary>ステータスタイププロパティ</summary>
        internal StatusType StatusType
        {
            get { return _statusType; }
            set { _statusType = value; }
        }

        /// <summary>値プロパティ</summary>
        internal int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    /// <summary>
    /// コンボエディタデータ取得タイプ
    /// </summary>
    internal enum StatusType : int
    {
        Default = 0,
        StockGoodsCd = 1,
        ProductNumberInput = 2
    }
}
