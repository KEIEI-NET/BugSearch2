using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 印刷に使用する構造体クラス
    /// </summary>
    public class PrintCndtn
    {
        #region プライベート変数

        /// <summary>帳票種別</summary>
        private Int32 _layoutType = 0;

        /// <summary>拠点コード</summary>
        private string _sectionCd = "";

        /// <summary>拠点名</summary>
        private string _sectionName = "";

        /// <summary>得意先コード</summary>
        private string _customerCd = "";

        /// <summary>得意先名</summary>
        private string _customerName = "";

        /// <summary>開始日付</summary>
        private DateTime _startDt;

        /// <summary>終了日付</summary>
        private DateTime _endDt;

        /// <summary>締め日</summary>
        private DateTime _totalDt;
        

        /// <summary>前回請求残高</summary>
        private Int64 _lastTimeDemand = 0;

        /// <summary>入金額</summary>
        private Int64 _thisTimeDmdNrml = 0;

        /// <summary>繰越金額</summary>
        private Int64 _forwardedAmount = 0;

        /// <summary>今回売上額</summary>
        private Int64 _thisSalesPriceTotal = 0;

        /// <summary>消費税</summary>
        private Int64 _ofsThisSalesTax = 0;

        /// <summary>税込金額</summary>
        private Int64 _totalAmount = 0;

        /// <summary>請求残高</summary>
        private Int64 _afCalBlc = 0;

        /// <summary>伝票枚数</summary>
        private Int64 _slipCount = 0;

        //-----ADD 2011/10/27----->>>>>
        /// <summary>原価表示区分</summary>
        private Int32 _genKaDispDiv = 0;
        //-----ADD 2011/10/27-----<<<<<
        #endregion // プライベート変数

        #region プロパティ

        /// <summary>拠点コード</summary>
        public Int32 LayoutType
        {
            get { return this._layoutType; }
            set { this._layoutType = value; }
        }

        /// <summary>拠点コード</summary>
        public string SectionCd
        {
            get { return this._sectionCd; }
            set { this._sectionCd = value; }
        }

        /// <summary>拠点名</summary>
        public string SectionName
        {
            get { return this._sectionName; }
            set { this._sectionName = value; }
        }

        /// <summary>得意先コード</summary>
        public string CustomerCd
        {
            get { return this._customerCd; }
            set { this._customerCd = value; }
        }

        /// <summary>得意先名</summary>
        public string CustomerName
        {
            get { return this._customerName; }
            set { this._customerName = value; }
        }

        /// <summary>開始日付</summary>
        public DateTime StartDt
        {
            get { return this._startDt; }
            set { this._startDt = value; }
        }

        /// <summary>終了日付</summary>
        public DateTime EndDt
        {
            get { return this._endDt; }
            set { this._endDt = value; }
        }

        /// <summary>締め日</summary>
        public DateTime TotalDt
        {
            get { return this._totalDt; }
            set { this._totalDt = value; }
        }

        /// <summary>前回請求残高</summary>
        public Int64 LastTimeDemand
        {
            get { return this._lastTimeDemand; }
            set { this._lastTimeDemand = value; }
        }

        /// <summary>入金額</summary>
        public Int64 ThisTimeDmdNrml
        {
            get { return this._thisTimeDmdNrml; }
            set { this._thisTimeDmdNrml = value; }
        }

        /// <summary>繰越金額</summary>
        /// <remarks>前回請求残高 - 入金額</remarks>
        public Int64 ForwardedAmount
        {
            get { return this._forwardedAmount; }
            set { this._forwardedAmount = value; }
        }

        /// <summary>今回売上額</summary>
        public Int64 ThisSalesPriceTotal
        {
            get { return this._thisSalesPriceTotal; }
            set { this._thisSalesPriceTotal = value; }
        }

        /// <summary>消費税</summary>
        public Int64 OfsThisSalesTax
        {
            get { return this._ofsThisSalesTax; }
            set { this._ofsThisSalesTax = value; }
        }

        /// <summary>税込金額</summary>
        /// <remarks>今回売上額 + 消費税</remarks>
        public Int64 TotalAmount
        {
            get { return this._totalAmount; }
            set { this._totalAmount = value; }
        }

        /// <summary>請求残高</summary>
        public Int64 AfCalBlc
        {
            get { return this._afCalBlc; }
            set { this._afCalBlc = value; }
        }

        /// <summary>伝票枚数</summary>
        public Int64 SlipCount
        {
            get { return this._slipCount; }
            set { this._slipCount = value; }
        }

        //-----ADD 2011/10/27----->>>>>
        /// <summary>原価表示区分</summary>
        public Int32 GenKaDispDiv
        {
            get { return this._genKaDispDiv; }
            set { this._genKaDispDiv = value; }
        }
        //-----ADD 2011/10/27-----<<<<<
        #endregion // プロパティ

        #region コンストラクタ

        public PrintCndtn()
        {

        }

        #endregion // コンストラクタ
    }
}
