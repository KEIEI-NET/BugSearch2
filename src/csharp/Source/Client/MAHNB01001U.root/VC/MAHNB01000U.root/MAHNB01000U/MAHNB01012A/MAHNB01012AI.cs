using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BLコード変換マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換マスタの制御全般を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.07.30</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.30 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    public class BLCodeChangeAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Members
        static BLCodeChangeAcs _blCodeChangeAcs;
        private ITbsPartsCdChgDB _iTbsPartsCdChgDB;
        #endregion

        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region ■Public Readonly Members
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        public BLCodeChangeAcs()
        {
            this._iTbsPartsCdChgDB = (ITbsPartsCdChgDB)MediationTbsPartsCdChgDB.GetTbsPartsCodeDB();
        }
        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■Delegete
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties
        ///// <summary>仕入情報プロパティ</summary>
        //public StockTemp StockTemp
        //{
        //    get { return this._stockTemp; }
        //    set { this._stockTemp = value; }
        //}

        ///// <summary>売上明細データ行オブジェクト</summary>
        //public SalesInputDataSet.SalesDetailRow SalesDetailRow
        //{
        //    get { return _salesDetailRow; }
        //    set { _salesDetailRow = value; }
        //}

        ///// <summary>商品連結情報ディクショナリ</summary>
        //public Dictionary<SalesSlipInputAcs.GoodsInfoKey, GoodsUnitData> GoodsUnitDataInfo
        //{
        //    get { return this._goodsUnitDataInfo; }
        //    set { this._goodsUnitDataInfo = value; }
        //}
        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Enums
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods
        /// <summary>
        /// BLコード変換マスタ検索処理
        /// </summary>
        /// <param name="?"></param>
        /// <param name="paraTbsPartsCdChgWork"></param>
        /// <returns></returns>
        public int Search(out List<TbsPartsCdChgWork> retTbsPartsCdChgWorkList, TbsPartsCdChgWork paraTbsPartsCdChgWork)
        {
            ArrayList al = new ArrayList();
            al.Add(paraTbsPartsCdChgWork);
            object parabyte = al;
            object objtbsPartsCode;
            ArrayList retTbsPartsCodeArrayList;
            retTbsPartsCdChgWorkList = null;

            int status = _iTbsPartsCdChgDB.Search(out objtbsPartsCode, parabyte);

            if (objtbsPartsCode != null)
            {
                retTbsPartsCodeArrayList = (ArrayList)objtbsPartsCode;
                retTbsPartsCdChgWorkList = new List<TbsPartsCdChgWork>((TbsPartsCdChgWork[])retTbsPartsCodeArrayList.ToArray(typeof(TbsPartsCdChgWork)));
            }

            return status;
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        #endregion

        // ===================================================================================== //
        // スタティックメソッド
        // ===================================================================================== //
        #region ■Static Methods
        #endregion

    }
}
