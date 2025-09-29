using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 車輌管理マスタ検索条件情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売車輌管理マスタ検索条件情報初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/09/07</br>
    /// </remarks>
    public class CarManagementExtractInfo
    {
        # region ■ Private Field

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>得意先コード</summary>
        private int _customerCode;

        /// <summary>得意先コード開始</summary>
        private int _customerCodeSt;

        /// <summary>得意先コード終了</summary>
        private int _customerCodeEd;

        /// <summary>管理番号</summary>
        private string _carMngCode;

        /// <summary>検索区分</summary>
        private int _searchDiv;

        # endregion ■ Private Field

        # region ■ Public Propaty
        /// <summary>
        /// 企業コードプロパティ
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>
        /// 得意先コードプロパティ
        /// </summary>
        public int CustomerCode
        {
            get { return this._customerCode; }
            set { this._customerCode = value; }
        }

        /// <summary>
        /// 得意先コード開始プロパティ
        /// </summary>
        public int CustomerCodeSt
        {
            get { return this._customerCodeSt; }
            set { this._customerCodeSt = value; }
        }

        /// <summary>
        /// 得意先コード終了プロパティ
        /// </summary>
        public int CustomerCodeEd
        {
            get { return this._customerCodeEd; }
            set { this._customerCodeEd = value; }
        }

        /// <summary>
        /// 管理番号プロパティ
        /// </summary>
        public string CarMngCode
        {
            get { return this._carMngCode; }
            set { this._carMngCode = value; }
        }

        /// <summary>
        /// 検索区分終了プロパティ
        /// </summary>
        public int SearchDiv
        {
            get { return this._searchDiv; }
            set { this._searchDiv = value; }
        }
        # endregion ■ Public Propaty

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CarManagementExtractInfo()
        {

        }
        #endregion
    }
}
