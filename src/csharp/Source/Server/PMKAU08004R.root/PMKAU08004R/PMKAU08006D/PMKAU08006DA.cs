using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      自由帳票請求書データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票請求書データワークヘッダファイル</br>
    /// <br>Programmer       :   22018 鈴木正臣</br>
    /// <br>Date             :   2008/6/12</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.15  22018 鈴木 正臣</br>
    /// <br>           : 請求書(総括)に対応する為、変更。</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePBillParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票印刷種別(50:合計請求書,60:明細請求書,70:伝票合計請求書,80:領収書)</summary>
        private int _slipPrtKind;
        /// <summary>請求キーリスト</summary>
        private List<FrePBillParaKey> _frePBillParaKeyList;
        // --- ADD m.suzuki 2010/02/15 ---------->>>>>
        /// <summary>得意先総括使用フラグ</summary>
        private bool _useSumCust;
        // --- ADD m.suzuki 2010/02/15 ----------<<<<<

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 伝票印刷種別 (50:合計請求書,60:明細請求書,70:伝票合計請求書,80:領収書)
        /// </summary>
        public int SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }
        /// <summary>
        /// 請求書キーリスト
        /// </summary>
        public List<FrePBillParaKey> FrePBillParaKeyList
        {
            get 
            {
                if ( _frePBillParaKeyList == null )
                {
                    _frePBillParaKeyList = new List<FrePBillParaKey>();
                }
                return _frePBillParaKeyList; 
            }
            set { _frePBillParaKeyList = value; }
        }
        // --- ADD m.suzuki 2010/02/15 ---------->>>>>
        /// <summary>
        /// 得意先総括使用フラグ
        /// </summary>
        public bool UseSumCust
        {
            get { return _useSumCust; }
            set { _useSumCust = value; }
        }
        // --- ADD m.suzuki 2010/02/15 ----------<<<<<

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrePBillParaWork()
        {
        }

        # region [請求書キー構造体]
        /// <summary>
        /// 請求書キー構造体
        /// </summary>
        [Serializable]
        public struct FrePBillParaKey
        {
            /// <summary>計上拠点コード</summary>
            private string _addUpSecCode;
            /// <summary>請求先コード</summary>
            private int _claimCode;
            /// <summary>実績拠点コード</summary>
            private string _resultsSectCd;
            /// <summary>得意先コード</summary>
            private int _customerCode;
            /// <summary>計上年月日</summary>
            private DateTime _addUpDate;
            /// <summary>
            /// 計上拠点コード
            /// </summary>
            /// <remarks>99</remarks>
            public string AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }
            /// <summary>
            /// 請求先コード
            /// </summary>
            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            /// <summary>
            /// 実績拠点コード
            /// </summary>
            public string ResultsSectCd
            {
                get { return _resultsSectCd; }
                set { _resultsSectCd = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// 計上年月日
            /// </summary>
            /// <remarks>yyyymmdd</remarks>
            public DateTime AddUpDate
            {
                get { return _addUpDate; }
                set { _addUpDate = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="addUpSecCode">計上拠点コード</param>
            /// <param name="claimCode">請求先コード</param>
            /// <param name="resultsSectCd">実績拠点コード</param>
            /// <param name="customerCode">得意先コード</param>
            /// <param name="addUpDate">計上年月日</param>
            public FrePBillParaKey( string addUpSecCode, int claimCode, string resultsSectCd, int customerCode, DateTime addUpDate )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
                _resultsSectCd = resultsSectCd;
                _customerCode = customerCode;
                _addUpDate = addUpDate;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="addUpSecCode">計上拠点コード</param>
            /// <param name="claimCode">請求先コード</param>
            /// <param name="resultsSectCd">実績拠点コード</param>
            /// <param name="customerCode">得意先コード</param>
            /// <param name="addUpDate">計上年月日</param>
            public FrePBillParaKey( string addUpSecCode, int claimCode, string resultsSectCd, int customerCode, int addUpDate )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
                _resultsSectCd = resultsSectCd;
                _customerCode = customerCode;
                _addUpDate = GetDateTime( addUpDate );
            }
            /// <summary>
            /// 計上年月日LongDate取得
            /// </summary>
            /// <returns></returns>
            public int GetAddUpDateLongDate()
            {
                return (_addUpDate.Year * 10000 + _addUpDate.Month * 100 + _addUpDate.Day);
            }
            /// <summary>
            /// 計上年月日LongDateセット
            /// </summary>
            /// <param name="longDate"></param>
            public void SetAddUpDateLongDate( int longDate )
            {
                _addUpDate = GetDateTime( longDate );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public string CreateKey()
            {
                return string.Format( "{0}-{1:D8}-{2}-{3:D8}-{4:yyyyMMdd}", _addUpSecCode, _claimCode, _resultsSectCd, _customerCode, _addUpDate );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            /// <summary>
            /// 日付変換処理
            /// </summary>
            /// <param name="longDate"></param>
            /// <returns></returns>
            private static DateTime GetDateTime( int longDate )
            {
                try
                {
                    return new DateTime( longDate / 10000, (longDate / 100) % 100, longDate % 100 );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }
        # endregion
    }

}
