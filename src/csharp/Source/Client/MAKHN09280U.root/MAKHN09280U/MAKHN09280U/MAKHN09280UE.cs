//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 商品在庫マスタ
// プログラム概要   : 商品在庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : caohh
// 修 正 日  2011/08/02  修正内容 : NSユーザー改良要望一覧連番265の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangy3
// 修 正 日  2012/12/01  修正内容 : 2013/01/16配信分障害報告#33231 商品在庫マスタ
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///  商品在庫マスタ画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 連番265 商品在庫マスタ画面のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/02</br>
    /// <br>UpdateNote : 2012/12/01 zhangy3</br>
    /// <br>           : 2013/01/16配信分</br>
    /// <br>           : Redmine#33231 商品在庫マスタ</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsStockInputConstruction
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private int _saveInfoDiv;
        private int _goodsNoMakerInfo;
        private int _goodsInfo;
        private int _priceInfo;
        private int _unitPriceInfo;
        private int _stockInfo;
        private int _activeMode;//Add 2012/12/01 zhangy3 for Redmine#33231

        private const int DEFAULT_SAVEINFODIV = 0;
        private const int DEFAULT_GOODSNOMAKERINFO = 0;
        private const int DEFAULT_GOODSINFO = 0;
        private const int DEFAULT_PRICEINFO = 0;
        private const int DEFAULT_UNITPRICEINFO = 0;
        private const int DEFAULT_STOCKINFO = 0;
        private const int DEFAULT_ACTIVEMODE = 0;//Add 2012/12/01 zhangy3 for Redmine#33231
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 商品在庫マスタ画面用ユーザー設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 連番265 商品在庫マスタ画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// </remarks>
        public GoodsStockInputConstruction()
        {
            this._saveInfoDiv = DEFAULT_SAVEINFODIV;
            this._goodsNoMakerInfo = DEFAULT_GOODSNOMAKERINFO;
            this._goodsInfo = DEFAULT_GOODSINFO;
            this._priceInfo = DEFAULT_PRICEINFO;
            this._unitPriceInfo = DEFAULT_UNITPRICEINFO;
            this._stockInfo = DEFAULT_STOCKINFO;
            this._activeMode = DEFAULT_ACTIVEMODE;//Add 2012/12/01 zhangy3 for Redmine#33231
        }

        /// <summary>
		/// 商品在庫マスタ画面用ユーザー設定クラス
		/// </summary>
		/// <remarks>
        /// <br>Note       : 連番265 商品在庫マスタ画面用ユーザー設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
		/// </remarks>
        //public GoodsStockInputConstruction(int saveInfoDiv, int goodsNoMakerInfo, int goodsInfo, int priceInfo, int unitPriceInfo, int stockInfo)//Del 2012/12/01 zhangy3 for Redmine#33231
        public GoodsStockInputConstruction(int saveInfoDiv, int goodsNoMakerInfo, int goodsInfo, int priceInfo, int unitPriceInfo, int stockInfo, int activeMode)
		{
            this._saveInfoDiv = saveInfoDiv;
            this._goodsNoMakerInfo = goodsNoMakerInfo;
            this._goodsInfo = goodsInfo;
            this._priceInfo = priceInfo;
            this._unitPriceInfo = unitPriceInfo;
            this._stockInfo = stockInfo;
            this._activeMode = activeMode;//Add 2012/12/01 zhangy3 for Redmine#33231
		}
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>保存前情報区分プロパティ</summary>
        public int SaveInfoDiv
        {
            get { return this._saveInfoDiv; }
            set { this._saveInfoDiv = value; }
        }

        /// <summary>品番・メーカー情報プロパティ</summary>
        public int GoodsNoMakerInfo
        {
            get { return this._goodsNoMakerInfo; }
            set { this._goodsNoMakerInfo = value; }
        }

        /// <summary>商品情報プロパティ</summary>
        public int GoodsInfo
        {
            get { return this._goodsInfo; }
            set { this._goodsInfo = value; }
        }

        /// <summary>価格情報プロパティ</summary>
        public int PriceInfo
        {
            get { return this._priceInfo; }
            set { this._priceInfo = value; }
        }

        /// <summary>単品売価プロパティ</summary>
        public int UnitPriceInfo
        {
            get { return this._unitPriceInfo; }
            set { this._unitPriceInfo = value; }
        }

        /// <summary>在庫情報ロパティ</summary>
        public int StockInfo
        {
            get { return this._stockInfo; }
            set { this._stockInfo = value; }
        }
        // --- Add 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
        /// <summary>起動方式</summary>
        public int ActiveMode
        {
            get { return this._activeMode; }
            set { this._activeMode = value; }
        }
        // --- Add 2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
        # endregion

        /// <summary>
        /// 商品在庫マスタ画面用ユーザー設定クラス複製処理
        /// </summary>
        /// <returns>商品在庫マスタ画面用ユーザー設定クラス</returns>
        public GoodsStockInputConstruction Clone()
        {
            //return new GoodsStockInputConstruction(this._saveInfoDiv, this._goodsNoMakerInfo, this._goodsInfo, this._priceInfo, this._unitPriceInfo, this._stockInfo);//Del 2012/12/01 zhangy3 for Redmine#33231
            return new GoodsStockInputConstruction(this._saveInfoDiv, this._goodsNoMakerInfo, this._goodsInfo, this._priceInfo, this._unitPriceInfo, this._stockInfo, this._activeMode);//Add 2012/12/01 zhangy3 for Redmine#33231
        }
    }

    /// <summary>
    /// 商品在庫マスタ画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 連番265 商品在庫マスタ画面のユーザー設定情報を管理するクラスです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/02</br>
    /// <br>Update Note: 2012/12/01 zhangy3　</br>
    /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
    /// <br></br>
    /// </remarks>
    public class GoodsStockInputConstructionAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private static GoodsStockInputConstruction _goodsStockInputConstruction;
        private const string XML_FILE_NAME = "MAKHN09280U_Construction.XML";
        private const int DEFAULT_KEEPONINFO = 0;
        private List<int> _keepOnInfo;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 商品在庫マスタ画面用ユーザー設定クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 連番265 商品在庫マスタ画面用ユーザー設定クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// </remarks>
        public GoodsStockInputConstructionAcs()
        {
            if (_goodsStockInputConstruction == null)
            {
                _goodsStockInputConstruction = new GoodsStockInputConstruction();
            }

            _keepOnInfo = new List<int>();
            //for (int i = 0; i < 5; i++) //Del 2012/12/01 zhangy3 for Redmine#33231
            for (int i = 0; i < 6; i++) //Add 2012/12/01 zhangy3 for Redmine#33231
            {
                _keepOnInfo.Add(DEFAULT_KEEPONINFO);
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>保存前情報区分プロパティ</summary>
        public int SaveInfoDiv
        {
            get
            {
                if (_goodsStockInputConstruction == null)
                {
                    _goodsStockInputConstruction = new GoodsStockInputConstruction();
                }
                return _goodsStockInputConstruction.SaveInfoDiv;
            }
            set
            {
                if (_goodsStockInputConstruction == null)
                {
                    _goodsStockInputConstruction = new GoodsStockInputConstruction();
                }
                _goodsStockInputConstruction.SaveInfoDiv = value;
            }
        }

        /// <summary>保存前情報保持プロパティ</summary>
        public List<int> KeepOnInfo
        {
            get
            {
                return this._keepOnInfo;
            }
            set
            {
                this._keepOnInfo = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// 商品在庫マスタ画面用ユーザー設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 連番265 商品在庫マスタ画面用ユーザー設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// </remarks>
        public void Serialize()
        {
            if (_keepOnInfo.Count > 0) 
            {
                _goodsStockInputConstruction.GoodsNoMakerInfo = _keepOnInfo[0];
                _goodsStockInputConstruction.GoodsInfo = _keepOnInfo[1];
                _goodsStockInputConstruction.PriceInfo = _keepOnInfo[2];
                _goodsStockInputConstruction.UnitPriceInfo = _keepOnInfo[3];
                _goodsStockInputConstruction.StockInfo = _keepOnInfo[4];
                _goodsStockInputConstruction.ActiveMode = _keepOnInfo[5];//Add 2012/12/01 zhangy3 for Redmine#33231
            }
            UserSettingController.SerializeUserSetting(_goodsStockInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
        }

        /// <summary>
        /// 商品在庫マスタ画面用ユーザー設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 連番265 商品在庫マスタ画面用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/02</br>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _goodsStockInputConstruction = UserSettingController.DeserializeUserSetting<GoodsStockInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                _keepOnInfo = new List<int>();
                _keepOnInfo.Add(_goodsStockInputConstruction.GoodsNoMakerInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.GoodsInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.PriceInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.UnitPriceInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.StockInfo);
                _keepOnInfo.Add(_goodsStockInputConstruction.ActiveMode);//Add 2012/12/01 zhangy3 for Redmine#33231
            }
        }
        # endregion
    }
}
