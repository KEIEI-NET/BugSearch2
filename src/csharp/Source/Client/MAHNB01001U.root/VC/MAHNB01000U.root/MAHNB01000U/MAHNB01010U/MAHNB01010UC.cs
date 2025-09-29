using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上明細データテーブル列表示コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上明細データテーブルの列表示を行うコントロールクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    internal class SalesDetailRowVisibleControl
    {
        private Dictionary<SalesDetailColStatusKey, bool> _statusDictionary = new Dictionary<SalesDetailColStatusKey, bool>();

        /// <summary>
        /// 列表示非表示設定値追加処理
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="statusType">ステータスタイプ</param>
        /// <param name="value">値</param>
        /// <param name="hidden">表示非表示設定値</param>
        internal void Add(string colName, StatusType statusType, int value, bool hidden)
        {
            SalesDetailColStatusKey key = new SalesDetailColStatusKey(colName, statusType, value);

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
        /// <param name="visible">表示非表示設定値</param>
        /// <returns>0:取得可能 0以外:取得失敗</returns>
        internal int GetHidden(string colName, StatusType statusType, int value, out bool hidden)
        {
            SalesDetailColStatusKey key = new SalesDetailColStatusKey(colName, statusType, value);

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
    /// 売上明細データテーブル列ステータスキー構造体
    /// </summary>
    internal struct SalesDetailColStatusKey
    {
        string _colName;
        StatusType _statusType;
        int _value;

        /// <summary>
        /// 売上明細データテーブル列ステータスキー構造体コンストラクタ
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="statusType">ステータスタイプ</param>
        /// <param name="value">値</param>
        internal SalesDetailColStatusKey(string colName, StatusType statusType, int value)
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
        SalesGoodsCd = 1,
        ProductNumberInput = 2,
        AcptAnOdrStatus = 3,
        AcptAnOdrStatusAndSalesSlipCd = 4,
        InputChange = 5
    }
}
