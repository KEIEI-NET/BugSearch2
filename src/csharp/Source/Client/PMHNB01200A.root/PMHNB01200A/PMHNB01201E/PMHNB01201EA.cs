using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上データＱＲ送信制御条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データＱＲ送信制御の処理条件クラスです。売上伝票のKEY情報受渡しに使用します。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// </remarks>
    public class SalesQRSendCtrlCndtn
    {
        # region [フィールド]
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票ＫＥＹリスト</summary>
        private List<QRSendCtrlSalesSlipKey> _salesSlipKeyList;
        /// <summary>プログラムパラメータ</summary>
        private string _programParameter;
        /// <summary>再発行区分</summary>
        private bool _reissueDiv;
        /// <summary>追加情報</summary>
        private ArrayList _extrData;
        # endregion

        # region [プロパティ]
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 売上伝票ＫＥＹリスト
        /// </summary>
        public List<QRSendCtrlSalesSlipKey> SalesSlipKeyList
        {
            get 
            {
                if ( _salesSlipKeyList == null )
                {
                    _salesSlipKeyList = new List<QRSendCtrlSalesSlipKey>();
                }
                return _salesSlipKeyList; 
            }
            set 
            { 
                _salesSlipKeyList = value; 
            }
        }
        /// <summary>
        /// プログラムパラメータ
        /// </summary>
	    public string ProgramParameter
	    {
		    get { return _programParameter;}
		    set { _programParameter = value;}
	    }
        /// <summary>
        /// 再発行区分
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        /// <summary>
        /// 追加情報プロパティ（予備）
        /// </summary>
        public ArrayList ExtrData
        {
            get 
            {
                if ( _extrData == null )
                {
                    _extrData = new ArrayList();
                }
                return _extrData; 
            }
            set 
            { 
                _extrData = value; 
            }
        }
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesQRSendCtrlCndtn()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipKeyList">伝票ＫＥＹリスト</param>
        /// <param name="extrData">追加情報</param>
        public SalesQRSendCtrlCndtn( string enterpriseCode, List<QRSendCtrlSalesSlipKey> salesSlipKeyList, string programParameter, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._salesSlipKeyList = salesSlipKeyList;
            this._programParameter = programParameter;
            this._extrData = extrData;
        }
        # endregion

        # region [売上伝票key]
        /// <summary>
        /// 売上伝票ＫＥＹ項目　構造体
        /// </summary>
        public struct QRSendCtrlSalesSlipKey
        {
            private int _acptAnOdrStatus;
            private string _salesSlipNum;

            /// <summary>
            /// 受注ステータス
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// 伝票番号
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus">受注ステータス</param>
            /// <param name="salesSlipNum">伝票番号</param>
            public QRSendCtrlSalesSlipKey( int acptAnOdrStatus, string salesSlipNum )
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="salesSlip">売上伝票</param>
            public QRSendCtrlSalesSlipKey( SalesSlip salesSlip )
            {
                this._acptAnOdrStatus = salesSlip.AcptAnOdrStatus;
                this._salesSlipNum = salesSlip.SalesSlipNum;
            }

        }
        # endregion
    }

}
