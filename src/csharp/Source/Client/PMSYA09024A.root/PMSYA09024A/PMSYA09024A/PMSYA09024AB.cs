//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタアクセスクラス
// プログラム概要   : 車輌管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日 2009/10/10   修正内容 : 障害報告Redmine#537の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 修 正 日  2009/12/24  修正内容 : MANTIS[14822] 車輌管理マスタ キー追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoyh
// 修 正 日  2010/04/27  修正内容 : 受注マスタ（車両）自由検索型式固定番号配列の追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoyh
// 修 正 日  2010/05/20  修正内容 : #7651 自由検索型式固定番号配列がNULLの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 施ヘイ中
// 修 正 日 2010/12/22   修正内容 : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正
//----------------------------------------------------------------------------//
// 管理番号 10704766-00  作成担当 : wangf
// 修 正 日 2011/08/02   修正内容 : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正
//----------------------------------------------------------------------------//
// 管理番号 10801804-00  作成担当 : 脇田 靖之
// 修 正 日 2012/09/18   修正内容 : ①車輌管理マスタを検索後、特定のデータを編集しようとするとフリーズしてしまう件の修正
//                                : ②車輌管理マスタがエラーで保存できなくなる件の修正
//----------------------------------------------------------------------------//
// 管理番号 10900269-00  作成担当 : FSI高橋 文彰
// 修 正 日 2013/03/22   修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 修 正 日 2013/04/19   修正内容 : SCM障害№10521対応 戻り値に登録番号情報を追加する
//----------------------------------------------------------------------------//
// 管理番号  11070091-00 作成担当 : 譚洪
// 修 正 日  2014/08/01  修正内容 : 全体初期値設定マスタデータ取得障害を修正
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;  // Add 2010/04/27
using System.IO;  // Add 2010/04/27

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車輌管理マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌管理マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note : 張莉莉 2009.10.10</br>
    /// <br>            : 障害報告Redmine#537の修正</br>
    /// <br>Update Note : wangf 2011/08/02</br>
    /// <br>            : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
    /// <br>Update Note : 2013/03/22 FSI高橋 文彰</br>
    /// <br>            : SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// </remarks>
    public class CarMngInputAcs : IGeneralGuideData
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private static CarMngInputAcs _carMngInputAcs;
        private AllDefSet _allDefSet;
        private Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable> _colorInfoDic;       // カラー情報
        private Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable> _trimInfoDic;         // トリム情報
        private Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable> _cEqpDspInfoDic;  // 装備情報
        private string _ownSectionCode = "";
        private string _ownSectionName = "";
        private static SecInfoAcs _secInfoAcs;											// 拠点アクセスクラス
        private string _enterpriseCode;
        private string _loginSectionCode;
        private CarSearchController _carSearchController;
        private GoodsAcs _goodsAcs;
        private IWin32Window _owner = null;
        private List<MakerUMnt> _makerUMntList = null;         // メーカーマスタリスト
        private ModelNameUAcs _modelNameUAcs;
        private ICarManagementDB _iCarManagementDB;
        private PMKEN01010E.CarModelInfoDataTable _carInfo; // ADD 2013/03/22
        private int _handleInfoCode; // ADD 2013/03/22
        # endregion

        # region 定数
        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        // ガイド項目名
        # region [ガイド項目]
        private const string GUIDE_ENTERPRISECODE_TITLE = "EnterpriseCode"; // 企業コード
        private const string GUIDE_CARMNGCODE_TITLE = "CarMngCode"; // 管理番号
        private const string GUIDE_MODELFULLNAME_TITLE = "ModelFullName"; // 車種
        private const string GUIDE_FULLMODEL_TITLE = "FullModel"; // 型式
        private const string GUIDE_FRAMENO_TITLE = "FrameNo"; // 車台番号
        private const string GUIDE_NUMBERPLATEFORGUIDE_TITLE = "NumberPlateForGuide"; // 登録番号
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode"; // 得意先コード
        private const string GUIDE_CUSTOMERCODEFORGUIDE_TITLE = "CustomerCodeForGuide"; // 得意先Guide
        private const string GUIDE_CUSTOMERNAME_TITLE = "CustomerName"; // 得意先名
        private const string GUIDE_CARMNGNO_TITLE = "CarMngNo"; // 車輌管理番号
        // -- add wangf 2011/08/02 ---------->>>>>
        private const string GUIDE_CARNOTE_TITLE = "CarNote"; // 車輌備考
        // -- add wangf 2011/08/02 ----------<<<<<
        // ADD 2013/04/19 SCM障害№10521対応 -------------------------------------->>>>>
        private const string GUIDE_NUMBERPLATE1CODE_TITLE = "NumberPlate1Code"; // 陸運事務局登録番号
        private const string GUIDE_NUMBERPLATE1NAME_TITLE = "NumberPlate1Name"; // 陸運事務局名称
        private const string GUIDE_NUMBERPLATE2_TITLE = "NumberPlate2"; // 車両登録番号（種別）
        private const string GUIDE_NUMBERPLATE3_TITLE = "NumberPlate3"; // 車両登録番号（カナ）
        private const string GUIDE_NUMBERPLATE4_TITLE = "NumberPlate4"; // 車両登録番号（プレート番号）
        // ADD 2013/04/19 SCM障害№10521対応 --------------------------------------<<<<<
        # endregion
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>
        /// 自拠点コードプロパティ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自拠点コードプロパティ</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string OwnSectionCode
        {
            get
            {
                if (this._ownSectionCode == "")
                {
                    return this.GetOwnSectionCode();
                }
                else
                {
                    return this._ownSectionCode;
                }
            }
        }

        /// <summary>
        /// 自拠点名称プロパティ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自拠点名称プロパティ</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string OwnSectionName
        {
            get
            {
                if (this._ownSectionName == "")
                {
                    return this.GetOwnSectionName();
                }
                else
                {
                    return this._ownSectionName;
                }
            }
        }
        # endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        # region Enums
        /// <summary>
        /// 車両検索モード
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車両検索モードの列挙体</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public enum SearchCarMode : int
        {
            /// <summary>型式検索</summary>
            FullModelSearch = 1,
            /// <summary>モデルプレート検索</summary>
            ModelPlateSearch = 2,
        }
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region コンストラクタ
        /// <summary>
        /// 車輌管理マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタアクセスクラスコンストラクタを初期化します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarMngInputAcs()
        {
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._colorInfoDic = new Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable>();
            this._trimInfoDic = new Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable>();
            this._cEqpDspInfoDic = new Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable>();
            this._carSearchController = new CarSearchController();
            this._modelNameUAcs = new ModelNameUAcs();
            this._iCarManagementDB = MediationCarManagementDB.GetCarManagementDB();
        }

        /// <summary>
        /// 車輌管理マスタアクセスクラスのインスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタアクセスクラスのインスタンス取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public static CarMngInputAcs GetInstance()
        {
            if (_carMngInputAcs == null)
            {
                _carMngInputAcs = new CarMngInputAcs();
            }

            return _carMngInputAcs;
        }

        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// 全体初期値設定マスタ検索処理
        /// </summary>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定マスタ検索処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }

        /// <summary>
        /// 車輌管理マスタデータ入力で使用する初期データをＤＢより取得します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタデータ入力で使用する初期データをＤＢより取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;  // ADD 2014/08/01 譚洪 Redmine#43125

            // 全体初期値設定マスタ
            if (this._allDefSet == null) // ADD 2014/08/01 譚洪 Redmine#43125
            {
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                //int status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode); // DEL 2014/08/01 譚洪 Redmine#43125
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode); // ADD 2014/08/01 譚洪 Redmine#43125
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
            }

            // 商品アクセスクラス初期処理
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

            // メーカーマスタ
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            return status;
        }

        // ---------- ADD 2014/08/01 譚洪 Redmine#43125 --------- >>>
        /// <summary>
        /// 全体初期値設定マスタをＤＢより取得します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定マスタデータをＤＢより取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int ReadAllDefSetData(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (this._allDefSet == null)
            {
                // 全体初期値設定マスタ
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        // ---------- ADD 2014/08/01 譚洪 Redmine#43125 --------- <<<

        /// <summary>
        /// 選択カラー情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>カラー情報行オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 選択カラー情報取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.ColorCdInfoRow GetSelectColorInfo(Guid carRelationGuid)
        {
            PMKEN01010E.ColorCdInfoRow colorInfoRow = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}={1}", colorInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) colorInfoRow = rows[0];
            }
            return colorInfoRow;
        }

        /// <summary>
        /// 選択トリム情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>トリム情報行オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 選択トリム情報取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.TrimCdInfoRow GetSelectTrimInfo(Guid carRelationGuid)
        {
            PMKEN01010E.TrimCdInfoRow trimInfoRow = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}={1}", trimInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) trimInfoRow = rows[0];
            }
            return trimInfoRow;
        }

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点制御アクセスクラスインスタンスを初期化します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 車両情報キャッシュ（カラー、トリム、装備情報）
        /// </summary>
        /// <param name="extraInfo">車両情報行オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 車両情報キャッシュ（カラー、トリム、装備情報）を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void CacheCarOtherInfo(ref CarMangInputExtraInfo extraInfo)
        {
            // 車両再検索
            PMKEN01010E carInfoDataset = new PMKEN01010E();
            // --- UPD 2012/09/18 Y.Wakita ---------->>>>>
            //CarSearchResultReport result = this.SearchCar(extraInfo.FullModelFixedNoAry, extraInfo.ModelDesignationNo, extraInfo.CategoryNo, ref carInfoDataset);
            CarSearchResultReport result = this.SearchCar(extraInfo, ref carInfoDataset);
            // --- UPD 2012/09/18 Y.Wakita ----------<<<<<
            if ((result != CarSearchResultReport.retError) && (result != CarSearchResultReport.retFailed))
            {
                //this.CacheCarInfo(ref extraInfo, carInfoDataset);
       
                this.CacheColorInfo(extraInfo, carInfoDataset.ColorCdInfo);                         // カラー情報
                this.CacheTrimInfo(extraInfo, carInfoDataset.TrimCdInfo);                           // トリム情報
                this.CacheEquipInfo(extraInfo, carInfoDataset.CEqpDefDspInfo);                      // 装備情報
            }
        }

        // --- ADD 2012/09/18 Y.Wakita ---------->>>>>
        /// <summary>
        /// 車両検索(フル型式固定番号より検索)
        /// </summary>
        /// <param name="extraInfo">車両情報行オブジェクト</param>
        /// <param name="carInfoDataSet">車両検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>型式指定番号および類別区分番号は、類別検索によるフル型式固定番号配列の場合のみ必須</remarks>
        /// <remarks>
        /// <br>Note       : 車両検索(フル型式固定番号より検索)を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarSearchResultReport SearchCar(CarMangInputExtraInfo extraInfo, ref PMKEN01010E carInfoDataSet)
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            if (extraInfo.FullModelFixedNoAry.Length != 0 && extraInfo.FullModelFixedNoAry[0] != 0)
            {
                ret = this._carSearchController.SearchByFullModelFixedNo(extraInfo, ref carInfoDataSet);
            }
            return ret;
        }
        // --- ADD 2012/09/18 Y.Wakita ----------<<<<<

        /// <summary>
        /// 車両検索(フル型式固定番号より検索)
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="modelDesignationNo">型式指定番号(未設定可)</param>
        /// <param name="categoryNo">類別区分番号(未設定可)</param>
        /// <param name="carInfoDataSet">車両検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>型式指定番号および類別区分番号は、類別検索によるフル型式固定番号配列の場合のみ必須</remarks>
        /// <remarks>
        /// <br>Note       : 車両検索(フル型式固定番号より検索)を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarSearchResultReport SearchCar(int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet)
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            if (fullModelFixedNo.Length != 0 && fullModelFixedNo[0] != 0)
            {
                ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, modelDesignationNo, categoryNo, ref carInfoDataSet);
            }
            return ret;
        }

        /// <summary>
        /// 車輌検索(車輌検索抽出条件より検索)
        /// </summary>
        /// <param name="carSearchCondition">車輌検索抽出条件</param>
        /// <param name="carInfoDataSet">車輌検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>
        /// <br>Note       : 車輌検索(車輌検索抽出条件より検索)を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarSearchResultReport SearchCar(CarSearchCondition carSearchCondition, ref PMKEN01010E carInfoDataSet)
        {
            return this._carSearchController.Search(carSearchCondition, ref carInfoDataSet);
        }

        /// <summary>
        /// 車両情報キャッシュ（車両検索情報からキャッシュ）
        /// </summary>
        /// <param name="extraInfo">車両情報行オブジェクト</param>
        /// <param name="searchCarInfo">車両検索結果クラス</param>
        /// <remarks>
        /// <br>Note       : 車両情報キャッシュ（車両検索情報からキャッシュ）を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        public void CacheCarInfo(ref CarMangInputExtraInfo extraInfo, PMKEN01010E searchCarInfo)
        {
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchCarInfo.CarModelUIData; // ＵＩ用型式情報テーブル
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchCarInfo.CarModelInfoSummarized; // 型式情報要約テーブル

            extraInfo.CarRelationGuid = Guid.Empty;
            extraInfo.MakerCode = carModelInfoDataTable[0].MakerCode; // メーカーコード
            extraInfo.MakerFullName = carModelInfoDataTable[0].MakerFullName; // メーカー全角名称
            extraInfo.MakerHalfName = carModelInfoDataTable[0].MakerHalfName; // メーカー半角名称
            extraInfo.ModelCode = carModelInfoDataTable[0].ModelCode; // 車種コード
            extraInfo.ModelSubCode = carModelInfoDataTable[0].ModelSubCode; // 車種サブコード
            extraInfo.ModelFullName = carModelInfoDataTable[0].ModelFullName; // 車種全角名称
            if (extraInfo.ModelFullName.Length > 15) extraInfo.ModelFullName = extraInfo.ModelFullName.Substring(0, 15);
            extraInfo.ModelHalfName = carModelInfoDataTable[0].ModelHalfName; // 車種半角名称
            if (extraInfo.ModelHalfName.Length > 15) extraInfo.ModelHalfName = extraInfo.ModelHalfName.Substring(0, 15);
            extraInfo.SystematicCode = carModelInfoDataTable[0].SystematicCode; // 系統コード
            extraInfo.SystematicName = carModelInfoDataTable[0].SystematicName; // 系統名称
            extraInfo.ProduceTypeOfYearCd = carModelInfoDataTable[0].ProduceTypeOfYearCd; // 生産年式コード
            extraInfo.ProduceTypeOfYearNm = carModelInfoDataTable[0].ProduceTypeOfYearNm; // 生産年式名称
            DateTime sdt;
            DateTime edt;
            int iyy = carModelInfoDataTable[0].StProduceTypeOfYear / 100;
            int imm = carModelInfoDataTable[0].StProduceTypeOfYear % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime(iyy, imm, 1);
            }
            iyy = carModelInfoDataTable[0].EdProduceTypeOfYear / 100;
            imm = carModelInfoDataTable[0].EdProduceTypeOfYear % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime(iyy, imm, 1);
            }
            extraInfo.StProduceTypeOfYear = sdt; // 開始生産年式
            extraInfo.EdProduceTypeOfYear = edt; // 終了生産年式
            extraInfo.ProduceTypeOfYearInput = carModelUIDataTable[0].ProduceTypeOfYearInput; // 生産年式入力
            extraInfo.DoorCount = carModelInfoDataTable[0].DoorCount; // ドア数
            extraInfo.BodyNameCode = carModelInfoDataTable[0].BodyNameCode; // ボディー名コード
            extraInfo.BodyName = carModelInfoDataTable[0].BodyName; // ボディー名称
            extraInfo.ExhaustGasSign = carModelInfoDataTable[0].ExhaustGasSign; // 排ガス記号
            extraInfo.SeriesModel = carModelInfoDataTable[0].SeriesModel; // シリーズ型式
            extraInfo.CategorySignModel = carModelInfoDataTable[0].CategorySignModel; // 型式（類別記号）
            extraInfo.FullModel = carModelInfoDataTable[0].FullModel; // 型式（フル型）
            extraInfo.ModelDesignationNo = carModelUIDataTable[0].ModelDesignationNo; // 型式指定番号
            extraInfo.CategoryNo = carModelUIDataTable[0].CategoryNo; // 類別番号
            extraInfo.FrameModel = carModelInfoDataTable[0].FrameModel; // 車台型式
            extraInfo.FrameNo = carModelUIDataTable[0].FrameNo; // 車台番号
            extraInfo.SearchFrameNo = carModelUIDataTable[0].SearchFrameNo; // 車台番号（検索用）
            extraInfo.StProduceFrameNo = carModelInfoDataTable[0].StProduceFrameNo; // 生産車台番号開始
            extraInfo.EdProduceFrameNo = carModelInfoDataTable[0].EdProduceFrameNo; // 生産車台番号終了
            extraInfo.ModelGradeNm = carModelInfoDataTable[0].ModelGradeNm; // 型式グレード名称
            extraInfo.EngineModelNm = carModelInfoDataTable[0].EngineModelNm; // エンジン型式名称
            extraInfo.EngineDisplaceNm = carModelInfoDataTable[0].EngineDisplaceNm; // 排気量名称
            extraInfo.EDivNm = carModelInfoDataTable[0].EDivNm; // E区分名称
            extraInfo.TransmissionNm = carModelInfoDataTable[0].TransmissionNm; // ミッション名称
            extraInfo.ShiftNm = carModelInfoDataTable[0].ShiftNm; // シフト名称
            extraInfo.WheelDriveMethodNm = carModelInfoDataTable[0].WheelDriveMethodNm; // 駆動方式名称
            extraInfo.AddiCarSpec1 = carModelInfoDataTable[0].AddiCarSpec1; // 追加諸元1
            extraInfo.AddiCarSpec2 = carModelInfoDataTable[0].AddiCarSpec2; // 追加諸元2
            extraInfo.AddiCarSpec3 = carModelInfoDataTable[0].AddiCarSpec3; // 追加諸元3
            extraInfo.AddiCarSpec4 = carModelInfoDataTable[0].AddiCarSpec4; // 追加諸元4
            extraInfo.AddiCarSpec5 = carModelInfoDataTable[0].AddiCarSpec5; // 追加諸元5
            extraInfo.AddiCarSpec6 = carModelInfoDataTable[0].AddiCarSpec6; // 追加諸元6
            extraInfo.AddiCarSpecTitle1 = carModelInfoDataTable[0].AddiCarSpecTitle1; // 追加諸元タイトル1
            extraInfo.AddiCarSpecTitle2 = carModelInfoDataTable[0].AddiCarSpecTitle2; // 追加諸元タイトル2
            extraInfo.AddiCarSpecTitle3 = carModelInfoDataTable[0].AddiCarSpecTitle3; // 追加諸元タイトル3
            extraInfo.AddiCarSpecTitle4 = carModelInfoDataTable[0].AddiCarSpecTitle4; // 追加諸元タイトル4
            extraInfo.AddiCarSpecTitle5 = carModelInfoDataTable[0].AddiCarSpecTitle5; // 追加諸元タイトル5
            extraInfo.AddiCarSpecTitle6 = carModelInfoDataTable[0].AddiCarSpecTitle6; // 追加諸元タイトル6
            extraInfo.RelevanceModel = carModelInfoDataTable[0].RelevanceModel; // 関連型式
            extraInfo.SubCarNmCd = carModelInfoDataTable[0].SubCarNmCd; // サブ車名コード
            extraInfo.ModelGradeSname = carModelInfoDataTable[0].ModelGradeSname; // 型式グレード略称
            extraInfo.BlockIllustrationCd = carModelInfoDataTable[0].BlockIllustrationCd; // ブロックイラストコード
            extraInfo.ThreeDIllustNo = carModelInfoDataTable[0].ThreeDIllustNo; // 3DイラストNo
            extraInfo.PartsDataOfferFlag = carModelInfoDataTable[0].PartsDataOfferFlag; // 部品データ提供フラグ

            // ----- UPD 2010/04/27 ------------------------>>>>>
            //extraInfo.FullModelFixedNoAry = this._carSearchController.GetFullModelFixedNoArray(searchCarInfo.CarModelInfo); // フル型式固定番号配列
            int[] fullAry = new int[0];
            string[] freeAry = new string[0];
            this._carSearchController.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(searchCarInfo.CarModelInfo, out fullAry, out freeAry);
            extraInfo.FullModelFixedNoAry = fullAry;
            extraInfo.FreeSrchMdlFxdNoAry = freeAry;
            // ----- UPD 2010/04/27 ------------------------<<<<<

            this.CacheColorInfo(extraInfo, searchCarInfo.ColorCdInfo);                         // カラー情報
            this.CacheTrimInfo(extraInfo, searchCarInfo.TrimCdInfo);                           // トリム情報
            this.CacheEquipInfo(extraInfo, searchCarInfo.CEqpDefDspInfo);                      // 装備情報

            // ADD 2013/03/22 -------------------->>>>>		        
            extraInfo.DomesticForeignCode = carModelUIDataTable[0].DomesticForeignCode; // 国産/外車区分
            try
            {
                // ハンドル位置情報を既定値(両型式)とする
                // ※ハンドル位置チェックを行わないようにする
                extraInfo.HandleInfoCode = 0; // ハンドル位置情報

                // 型式検索で選択されているすべての行を比較する
                int pos = searchCarInfo.CarModelInfo.HandleInfoCdColumn.Ordinal;
                int state = searchCarInfo.CarModelInfo.SelectionStateColumn.Ordinal;
                foreach (DataRow row in searchCarInfo.CarModelInfo.Rows)
                {
                    // 選択されていない行はスキップする
                    if ((bool)row[state] != true)
                        continue;

                    // ハンドル位置情報をチェックする
                    HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                    if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                        continue;

                    // ハンドル位置を比較する
                    if (extraInfo.HandleInfoCode == 0)
                    {
                        // ハンドル位置情報をセットする
                        extraInfo.HandleInfoCode = (int)posKind;
                    }
                    else if (extraInfo.HandleInfoCode == (int)HandleInfoCdRet.PositionRight && posKind == HandleInfoCdRet.PositionLeft)
                    {
                        // 右/左ハンドル混在の場合は両型式とする
                        extraInfo.HandleInfoCode = 0;
                        break;
                    }
                    else if (extraInfo.HandleInfoCode == (int)HandleInfoCdRet.PositionLeft && posKind == HandleInfoCdRet.PositionRight)
                    {
                        // 右/左ハンドル混在の場合は両型式とする
                        extraInfo.HandleInfoCode = 0;
                        break;
                    }
                }
            }
            catch
            {
                // 例外が発生した場合は両型式(0)のままとする
                // ※ハンドル位置チェックを行わないようにする
                extraInfo.HandleInfoCode = 0; // ハンドル位置情報
            }
            this._handleInfoCode = extraInfo.HandleInfoCode; // ハンドル位置情報キャッシュ
            this._carInfo = searchCarInfo.CarModelInfo; // 型式情報をキャッシュする
            // ADD 2013/03/22 --------------------<<<<<
        }

        /// <summary>
        /// 諸元情報設定処理(車両情報行オブジェクト→諸元情報行オブジェクト)
        /// </summary>
        /// <param name="carSpecRow">諸元情報行オブジェクト</param>
        /// <param name="extraInfo">車両情報行オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 諸元情報設定処理(車両情報行オブジェクト→諸元情報行オブジェクト)を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SetCarSpecFromCarInfoRow(ref CarMngInputDataSet.CarSpecRow carSpecRow, CarMangInputExtraInfo extraInfo)
        {
            if (extraInfo == null) return;

            carSpecRow.ModelGradeNm = extraInfo.ModelGradeNm;                     // グレード
            carSpecRow.BodyName = extraInfo.BodyName;                             // ボディ
            carSpecRow.DoorCount = extraInfo.DoorCount;                           // ドア
            carSpecRow.EDivNm = extraInfo.EDivNm;                                 // Ｅ区分
            carSpecRow.EngineDisplaceNm = extraInfo.EngineDisplaceNm;             // 排気量
            carSpecRow.EngineModelNm = extraInfo.EngineModelNm;                   // エンジン
            carSpecRow.ShiftNm = extraInfo.ShiftNm;                               // シフト
            carSpecRow.TransmissionNm = extraInfo.TransmissionNm;                 // ミッション
            carSpecRow.WheelDriveMethodNm = extraInfo.WheelDriveMethodNm;         // 駆動方式
            carSpecRow.AddiCarSpec1 = extraInfo.AddiCarSpec1;                     // 追加諸元１
            carSpecRow.AddiCarSpec2 = extraInfo.AddiCarSpec2;                     // 追加諸元２ 
            carSpecRow.AddiCarSpec3 = extraInfo.AddiCarSpec3;                     // 追加諸元３
            carSpecRow.AddiCarSpec4 = extraInfo.AddiCarSpec4;                     // 追加諸元４
            carSpecRow.AddiCarSpec5 = extraInfo.AddiCarSpec5;                     // 追加諸元５
            carSpecRow.AddiCarSpec6 = extraInfo.AddiCarSpec6;                     // 追加諸元６
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerName;
        }

        /// <summary>
        /// メーカー名称取得処理(半角カナ名称)
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称取得処理(半角カナ名称)を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetKanaName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerKanaName;
        }

        /// <summary>
        /// 車種名称取得処理
        /// </summary>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車種名称を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetModelFullName(int makerCode, int modelCode, int modelSubCode)
        {
            string retName = string.Empty;
            ModelNameU modelNameU = new ModelNameU();
            modelNameU = this.GetModelInfo(makerCode, modelCode, modelSubCode);
            if (modelNameU != null) retName = modelNameU.ModelFullName;

            return retName;
        }

        /// <summary>
        /// 車種半角名称取得処理
        /// </summary>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車種半角名称を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetModelHalfName(int makerCode, int modelCode, int modelSubCode)
        {
            string retName = string.Empty;
            ModelNameU modelNameU = new ModelNameU();
            modelNameU = this.GetModelInfo(makerCode, modelCode, modelSubCode);
            if (modelNameU != null) retName = modelNameU.ModelHalfName;

            return retName;
        }

        /// <summary>
        /// カラー情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="colorCode">カラーコード</param>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        /// <remarks>
        /// <br>Note       : カラー情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public bool SelectColorInfo(Guid carRelationGuid, string colorCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                ret = this.SelectColorInfo(colorInfoDataTable, colorCode, extraInfo);
            }
            return ret;
        }

        /// <summary>
        /// カラー情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>カラー情報データテーブル</returns>
        /// <remarks>
        /// <br>Note       : カラー情報取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.ColorCdInfoDataTable GetColorInfo(Guid carRelationGuid)
        {
            PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                colorInfoDataTable = this._colorInfoDic[carRelationGuid];
            }
            return colorInfoDataTable;
        }

        /// <summary>
        /// トリム情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>トリム情報データテーブル</returns>
        /// <remarks>
        /// <br>Note       : トリム情報取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.TrimCdInfoDataTable GetTrimInfo(Guid carRelationGuid)
        {
            PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                trimInfoDataTable = this._trimInfoDic[carRelationGuid];
            }
            return trimInfoDataTable;
        }

        /// <summary>
        /// 装備情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>装備情報データテーブル</returns>
        /// <remarks>
        /// <br>Note       : 装備情報取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.CEqpDefDspInfoDataTable GetEquipInfo(Guid carRelationGuid)
        {
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = null;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
            }
            return equipInfoDataTable;
        }

        /// <summary>
        /// トリム情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="trimCode">トリムコード</param>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        /// <remarks>
        /// <br>Note       : トリム情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public bool SelectTrimInfo(Guid carRelationGuid, string trimCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                ret = this.SelectTrimInfo(trimInfoDataTable, trimCode, extraInfo);
            }
            return ret;
        }

        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="equipmentGenreCd"></param>
        /// <param name="selectIndex"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 装備情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public bool SelectEquipInfo(Guid carRelationGuid, string equipmentGenreCd, int selectIndex)
        {
            bool ret = false;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                ret = this.SelectEquipInfo(carRelationGuid, eqpDspInfoDataTable, equipmentGenreCd, selectIndex);
            }
            return ret;
        }

        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="categoryObjAry">装備情報配列</param>
        /// <remarks>
        /// <br>Note       : 装備情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SelectEquipInfo(Guid carRelationGuid, byte[] categoryObjAry)
        {
            if ((this._cEqpDspInfoDic.ContainsKey(carRelationGuid)) && (categoryObjAry != null))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                if (categoryObjAry.Length > 0)
                {
                    // 指定の装備を選択状態にする
                    eqpDspInfoDataTable.SetTableFromByteArray(categoryObjAry);
                }
                else
                {
                    // 全て解除
                    foreach (PMKEN01010E.CEqpDefDspInfoRow row in eqpDspInfoDataTable.Rows)
                    {
                        row.SelectionState = false;
                    }
                }
            }
        }

        /// <summary>
        /// 装備情報対象装備明細選択／解除処理
        /// </summary>
        /// <param name="equipInfoDataTable">トリム情報データテーブル</param>
        /// <param name="key">キー</param>
        /// <param name="state">選択状態</param>
        /// <remarks>
        /// <br>Note       : 装備情報対象装備明細選択／解除処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SettingEquipInfoAllState(PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable, string key, bool state)
        {
            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])equipInfoDataTable.Select(string.Format("{0}='{1}'", equipInfoDataTable.EquipmentGenreNmColumn.ColumnName, key));

            foreach (PMKEN01010E.CEqpDefDspInfoRow row in rows)
            {
                row.SelectionState = state;
            }
        }

        /// <summary>
        /// データの読込処理
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="readMode"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : データの読込処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int ReadDB(ref CarMangInputExtraInfo extraInfo, int readMode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork tempWork = new CarManagementWork();
                tempWork.EnterpriseCode = this._enterpriseCode;
                tempWork.CustomerCode = extraInfo.CustomerCode;
                tempWork.CarMngNo = extraInfo.CarMngNo;
                tempWork.CarMngCode = extraInfo.CarMngCode; // 2009/12/24
                Object objCarMngWork = tempWork as object;
                status = this._iCarManagementDB.Read(ref objCarMngWork, readMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    extraInfo = this.ConvertCarMngWorkToCarMngExtraInfo(objCarMngWork as CarManagementWork);
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// データ登録処理
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : データ登録処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int WriteDB(ref CarMangInputExtraInfo extraInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork work = this.ConvertCarMngExtraInfoToCarMngWork(extraInfo);
                CustomSerializeArrayList workList = new CustomSerializeArrayList();
                workList.Add(work);

                Object objWorkList = workList as object;
                status = this._iCarManagementDB.Write(ref objWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    workList = objWorkList as CustomSerializeArrayList;
                    work = workList[0] as CarManagementWork;

                    extraInfo = this.ConvertCarMngWorkToCarMngExtraInfo(work);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 車両管理マスタ情報の論理削除を解除します
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車両管理マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
       // public int RevivalLogicalDelete(CarMangInputExtraInfo extraInfo, out string errMsg)
        public int RevivalLogicalDelete(ref CarMangInputExtraInfo extraInfo, out string errMsg) // ADD 2009/10/10
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork work = this.ConvertCarMngExtraInfoToCarMngWork(extraInfo);
                ArrayList workList = new ArrayList();
                workList.Add(work);

                Object objWorkList = workList as object;
                status = this._iCarManagementDB.RevivalLogicalDelete(ref objWorkList);
                // ----ADD 2009/10/10 -------->>>>> 
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    workList = objWorkList as ArrayList;
                    work = workList[0] as CarManagementWork;

                    extraInfo = this.ConvertCarMngWorkToCarMngExtraInfo(work);
                }
                // ----ADD 2009/10/10 --------<<<<<

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 車両管理マスタ情報を削除します
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車両管理マスタ情報を削除します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int Delete(CarMangInputExtraInfo extraInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork work = this.ConvertCarMngExtraInfoToCarMngWork(extraInfo);
                CustomSerializeArrayList workList = new CustomSerializeArrayList();
                workList.Add(work);

                Object objWorkList = workList as object;
                status = this._iCarManagementDB.Delete(objWorkList);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 車輌管理ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 車輌管理ガイド用データを取得します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            CarMngGuideParamWork paraWork = new CarMngGuideParamWork();
            bool isDispCustomerInfo = false;
            bool isDispNewRow = false;

            // ガイド用検索条件の設定
            paraWork = this.ConvertHashtableToCarMngGuideParamWork(inParm);

            // 得意先表示フラグ
            if (inParm.ContainsKey("IsDispCustomerInfo"))
            {
                isDispCustomerInfo = (bool)inParm["IsDispCustomerInfo"];
            }

            // 新規登録行表示フラグ
            if (inParm.ContainsKey("IsDispNewRow"))
            {
                isDispNewRow = (bool)inParm["IsDispNewRow"];
            }

            ArrayList retList;
            // 拠点情報設定テーブル読込み
            status = SearchGuide(out retList, paraWork, isDispCustomerInfo, isDispNewRow);
            // -- add wangf 2011/08/02 ---------->>>>>
            retList.Sort(new CarMngInputCompareList());
            // -- add wangf 2011/08/02 ----------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // ガイド初期起動時
                    if (guideList.Tables.Count == 0)
                    {
                        // ガイド用データセット列情報構築
                        this.GuideDataSetColumnConstruction(ref guideList);
                    }
                    // ガイド用データセットの作成
                    this.GetGuideDataSet(ref guideList, retList);

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }
            return status;
        }

        /// <summary>
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
        /// <param name="retList">結果取得アレイリスト</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009/09/07</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList)
        {
            CarMangInputExtraInfo carMangInputExtra = null;
            DataRow guideRow = null;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while (dataCnt < retList.Count)
            {
                carMangInputExtra = (CarMangInputExtraInfo)retList[dataCnt];
                if (carMangInputExtra.LogicalDeleteCode == 0)
                {
                    guideRow = retDataSet.Tables[0].NewRow();
                    // データコピー処理
                    CopyToGuideRowFromCarMangInput(ref guideRow, carMangInputExtra);
                    // データ追加
                    retDataSet.Tables[0].Rows.Add(guideRow);
                }
                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// DataRowコピー処理（仕入先クラス⇒ガイド用DataRow）
        /// </summary>
        /// <param name="guideRow">ガイド用DataRow</param>
        /// <param name="carMangInputExtra">仕入先クラス</param>
        /// <remarks>
        /// <br>Note       : 車輌管理番号クラスからガイド用DataRowへコピーを行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
        /// </remarks>
        private void CopyToGuideRowFromCarMangInput(ref DataRow guideRow, CarMangInputExtraInfo carMangInputExtra)
        {
            # region [データからガイドにセット（自動生成）]
            guideRow[GUIDE_ENTERPRISECODE_TITLE] = carMangInputExtra.EnterpriseCode; // 企業コード
            guideRow[GUIDE_CARMNGCODE_TITLE] = carMangInputExtra.CarMngCode; // 管理番号
            guideRow[GUIDE_MODELFULLNAME_TITLE] = carMangInputExtra.ModelFullName; // 車種
            guideRow[GUIDE_FULLMODEL_TITLE] = carMangInputExtra.FullModel; // 型式
            guideRow[GUIDE_FRAMENO_TITLE] = carMangInputExtra.FrameNo; // 車台番号
            guideRow[GUIDE_NUMBERPLATEFORGUIDE_TITLE] = carMangInputExtra.NumberPlateForGuide; // 登録番号
            guideRow[GUIDE_CUSTOMERCODE_TITLE] = carMangInputExtra.CustomerCode; // 得意先コード
            guideRow[GUIDE_CUSTOMERCODEFORGUIDE_TITLE] = carMangInputExtra.CustomerCodeForGuide; // 得意先Guide
            guideRow[GUIDE_CUSTOMERNAME_TITLE] = carMangInputExtra.CustomerName; // 得意先名
            guideRow[GUIDE_CARMNGNO_TITLE] = carMangInputExtra.CarMngNo; // 車輌管理番号
            // -- add wangf 2011/08/02 ---------->>>>>
            guideRow[GUIDE_CARNOTE_TITLE] = carMangInputExtra.CarNote; // 車輌備考
            // -- add wangf 2011/08/02 ----------<<<<<
            // ADD 2013/04/19 SCM障害№10521対応 ---------------------------------->>>>>
            guideRow[GUIDE_NUMBERPLATE1CODE_TITLE] = carMangInputExtra.NumberPlate1Code; // 陸運事務局登録番号
            guideRow[GUIDE_NUMBERPLATE1NAME_TITLE] = carMangInputExtra.NumberPlate1Name; // 陸運事務局名称
            guideRow[GUIDE_NUMBERPLATE2_TITLE] = carMangInputExtra.NumberPlate2; // 車両登録番号（種別）
            guideRow[GUIDE_NUMBERPLATE3_TITLE] = carMangInputExtra.NumberPlate3; // 車両登録番号（カナ）
            guideRow[GUIDE_NUMBERPLATE4_TITLE] = carMangInputExtra.NumberPlate4; // 車両登録番号（プレート番号）
            // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------<<<<<
            # endregion
        }

        /// <summary>
        /// ガイド用データセット列情報構築処理
        /// </summary>
        /// <param name="guideList">ガイド用データセット</param>>
        /// <remarks>
        /// <br>Note       : ガイド用データセットの列情報を構築します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction(ref DataSet guideList)
        {
            DataTable table = new DataTable();
            # region [ガイド用テーブル生成]
            // 企業コード
            table.Columns.Add(GUIDE_ENTERPRISECODE_TITLE, typeof(string));
            // 管理番号
            table.Columns.Add(GUIDE_CARMNGCODE_TITLE, typeof(string));
            // 車種
            table.Columns.Add(GUIDE_MODELFULLNAME_TITLE, typeof(string));
            // 型式
            table.Columns.Add(GUIDE_FULLMODEL_TITLE, typeof(string));
            //車台番号
            table.Columns.Add(GUIDE_FRAMENO_TITLE, typeof(string));
            //登録番号
            table.Columns.Add(GUIDE_NUMBERPLATEFORGUIDE_TITLE, typeof(string));
            //得意先コード
            table.Columns.Add(GUIDE_CUSTOMERCODE_TITLE, typeof(string));
            //得意先Guide
            table.Columns.Add(GUIDE_CUSTOMERCODEFORGUIDE_TITLE, typeof(string));
            //得意先名
            table.Columns.Add(GUIDE_CUSTOMERNAME_TITLE, typeof(string));
            // 車輌管理番号
            table.Columns.Add(GUIDE_CARMNGNO_TITLE, typeof(string));
            // -- add wangf 2011/08/02 ---------->>>>>
            // 車輌備考
            table.Columns.Add(GUIDE_CARNOTE_TITLE, typeof(string));
            // -- add wangf 2011/08/02 ----------<<<<<
            // ADD 2013/04/19 SCM障害№10521対応 --------------------------->>>>>
            // 陸運事務局登録番号
            table.Columns.Add(GUIDE_NUMBERPLATE1CODE_TITLE, typeof(Int32));
            // 陸運事務局名称
            table.Columns.Add(GUIDE_NUMBERPLATE1NAME_TITLE, typeof(string));
            // 車両登録番号（種別）
            table.Columns.Add(GUIDE_NUMBERPLATE2_TITLE, typeof(string));
            // 車両登録番号（カナ）
            table.Columns.Add(GUIDE_NUMBERPLATE3_TITLE, typeof(string));
            // 車両登録番号（プレート番号）
            table.Columns.Add(GUIDE_NUMBERPLATE4_TITLE, typeof(Int32));
            // ADD 2013/04/19 SCM障害№10521対応 ---------------------------<<<<<
            # endregion
            // テーブルコピー
            guideList.Tables.Add(table.Clone());
        }

        /// <summary>
        /// 車輌管理ガイド起動前データ存在チェック処理
        /// </summary>
        /// <param name="paramInfo">ガイド検索用の条件オブジェクト</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理ガイド起動前データ存在チェック処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int ExecuteGuidBeforeDataCheck(CarMngGuideParamInfo paramInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;
            CarMngGuideParamWork paramWork = this.ConvertCarMngGuideParamInfoToWork(paramInfo);
            // データ存在チェック
            // ガイド用検索条件の設定
            Object carMngGuideWorkObj = paramWork as object;
            Object carMngWorkListObj = (new ArrayList()) as object;
            try
            {
                // リモート検索
                status = this._iCarManagementDB.SearchGuide(carMngGuideWorkObj, out carMngWorkListObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 車輌管理ガイド起動処理
        /// </summary>
        /// <param name="paramInfo">ガイド検索用の条件オブジェクト</param>
        /// <param name="selectedInfo">戻り値</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理ガイド起動処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
        /// </remarks>
        public int ExecuteGuid(CarMngGuideParamInfo paramInfo, out CarMangInputExtraInfo selectedInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            selectedInfo = new CarMangInputExtraInfo();
            try
            {
                string errMsg = string.Empty;

                TableGuideParent tableGuideParent = null;
                Hashtable inObj = new Hashtable();
                Hashtable retObj = new Hashtable();

                // 企業コード
                inObj.Add("EnterpriseCode", paramInfo.EnterpriseCode);
                // 得意先チェックフラグ
                inObj.Add("IsCheckCustomerCode", paramInfo.IsCheckCustomerCode);
                // 得意先コード
                inObj.Add("CustomerCode", paramInfo.CustomerCode);
                // 管理番号チェックフラグ
                inObj.Add("IsCheckCarMngCode", paramInfo.IsCheckCarMngCode);
                // 管理番号
                inObj.Add("CarMngCode", paramInfo.CarMngCode);
                // 車輌管理区分チェック方式
                inObj.Add("CheckCarMngCodeType", paramInfo.CheckCarMngCodeType);
                // 車輌管理区分チェックフラグ
                inObj.Add("IsCheckCarMngDivCd", paramInfo.IsCheckCarMngDivCd);
                // 得意先表示フラグ
                inObj.Add("IsDispCustomerInfo", paramInfo.IsDispCustomerInfo);
                if (paramInfo.IsDispCustomerInfo == true)
                {
                    // 得意先表示あり
                    tableGuideParent = new TableGuideParent("CARMNGINFOGUIDEPARENT.XML");
                }
                else
                {
                    // 得意先表示なし
                    tableGuideParent = new TableGuideParent("CARMNGINFOGUIDEWITHOUTCUSTPARENT.XML");
                }
                // 新規登録行表示フラグ
                inObj.Add("IsDispNewRow", paramInfo.IsDispNewRow);

                // ガイドクリックの場合、データ存在チェックがない
                if (paramInfo.IsGuideClick == true)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    // データ存在チェック
                    status = this.ExecuteGuidBeforeDataCheck(paramInfo);
                }

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // データがない場合、ガイドを起動しない
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                else
                {
                    if (tableGuideParent.Execute(0, inObj, ref retObj))
                    {
                        // 得意先コード
                        selectedInfo.CustomerCode = Convert.ToInt32(retObj[GUIDE_CUSTOMERCODE_TITLE].ToString());
                        // 車輌管理番号
                        selectedInfo.CarMngNo = Convert.ToInt32(retObj[GUIDE_CARMNGNO_TITLE].ToString());
                        // 管理番号
                        selectedInfo.CarMngCode = retObj[GUIDE_CARMNGCODE_TITLE].ToString();
                        // -- add wangf 2011/08/02 ---------->>>>>
                        // 車輌備考
                        selectedInfo.CarNote = retObj[GUIDE_CARNOTE_TITLE].ToString();
                        // -- add wangf 2011/08/02 ----------<<<<<

                        // ADD 2013/04/19 SCM障害№10521対応 ---------------------------------->>>>>
                        // 陸運事務局登録番号
                        selectedInfo.NumberPlate1Code = (int)retObj[GUIDE_NUMBERPLATE1CODE_TITLE];
                        // 陸運事務局名称
                        selectedInfo.NumberPlate1Name = retObj[GUIDE_NUMBERPLATE1NAME_TITLE].ToString();
                        // 車両登録番号（種別）
                        selectedInfo.NumberPlate2 = retObj[GUIDE_NUMBERPLATE2_TITLE].ToString();
                        // 車両登録番号（カナ）
                        selectedInfo.NumberPlate3 = retObj[GUIDE_NUMBERPLATE3_TITLE].ToString();
                        // 車両登録番号（プレート番号）
                        selectedInfo.NumberPlate4 = (int)retObj[GUIDE_NUMBERPLATE4_TITLE];
                        // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------<<<<<

                        // 新規登録の場合
                        if (selectedInfo.CarMngCode != "新規登録")
                        {
                            // 車輌管理マスタの検索
                            status = this.ReadDB(ref selectedInfo, 0, out errMsg);
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                    }
                    // キャンセル
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// カラー情報をクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : カラー情報をクリアします。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void ClearColorInfo()
        {
            this._colorInfoDic.Clear();
        }

        /// <summary>
        /// トリム情報をクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : トリム情報をクリアします。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void ClearTrimInfo()
        {
            this._trimInfoDic.Clear();
        }

        /// <summary>
        /// 装備情報をクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 装備情報をクリアします。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void ClearEquipInfo()
        {
            this._cEqpDspInfoDic.Clear();
        }

        /// <summary>
        /// 装備情報行オブジェクト配列取得
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>装備情報バイト配列</returns>
        /// <remarks>
        /// <br>Note       : 装備情報行オブジェクト配列を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public byte[] GetEquipInfoRows(Guid carRelationGuid)
        {
            byte[] equipInfoRows = new byte[0];
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                // 装備情報データテーブル取得
                PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

                if (equipInfoDataTable != null)
                {
                    // 装備情報バイト配列
                    equipInfoRows = equipInfoDataTable.GetByteArray(true);
                }
            }
            return equipInfoRows;
        }
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Method
        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;
        }

        /// <summary>
        /// 自拠点コード取得処理
        /// </summary>
        /// <returns>自拠点コード</returns>
        /// <remarks>
        /// <br>Note       : 自拠点コードを取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string GetOwnSectionCode()
        {
            this.GetOwnSectionInfo();

            return this._ownSectionCode;
        }

        /// <summary>
        /// 自拠点名称取得処理
        /// </summary>
        /// <returns>自拠点コード</returns>
        /// <remarks>
        /// <br>Note       : 自拠点名称を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string GetOwnSectionName()
        {
            this.GetOwnSectionInfo();

            return this._ownSectionName;
        }

        /// <summary>
        /// 自拠点情報取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 自拠点情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void GetOwnSectionInfo()
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // 自拠点の取得
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

            if (secInfoSet != null)
            {
                this._ownSectionCode = secInfoSet.SectionCode;
                this._ownSectionName = secInfoSet.SectionGuideNm;
            }
        }

        /// <summary>
        /// カラー情報キャッシュ
        /// </summary>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <param name="colorCdInfoDataTable">カラー情報データテーブル</param>
        /// <remarks>
        /// <br>Note       : カラー情報キャッシュを行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CacheColorInfo(CarMangInputExtraInfo extraInfo, PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable)
        {
            if (this._colorInfoDic.ContainsKey(extraInfo.CarRelationGuid)) this._colorInfoDic.Remove(extraInfo.CarRelationGuid);
            this._colorInfoDic.Add(extraInfo.CarRelationGuid, colorCdInfoDataTable);
        }

        /// <summary>
        /// トリム情報キャッシュ
        /// </summary>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <param name="trimCdInfoDataTable">トリム情報データテーブル</param>
        /// <remarks>
        /// <br>Note       : トリム情報キャッシュを行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CacheTrimInfo(CarMangInputExtraInfo extraInfo, PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable)
        {
            if (this._trimInfoDic.ContainsKey(extraInfo.CarRelationGuid)) this._trimInfoDic.Remove(extraInfo.CarRelationGuid);
            this._trimInfoDic.Add(extraInfo.CarRelationGuid, trimCdInfoDataTable);
        }

        /// <summary>
        /// 装備情報キャッシュ
        /// </summary>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <param name="cEqpDefDspInfoDataTable">装備情報データテーブル</param>
        /// <remarks>
        /// <br>Note       : 装備情報キャッシュを行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CacheEquipInfo(CarMangInputExtraInfo extraInfo, PMKEN01010E.CEqpDefDspInfoDataTable cEqpDefDspInfoDataTable)
        {
            if (this._cEqpDspInfoDic.ContainsKey(extraInfo.CarRelationGuid)) this._cEqpDspInfoDic.Remove(extraInfo.CarRelationGuid);
            this._cEqpDspInfoDic.Add(extraInfo.CarRelationGuid, cEqpDefDspInfoDataTable);
        }

        /// <summary>
        /// 車種情報取得処理
        /// </summary>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車種情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private ModelNameU GetModelInfo(int makerCode, int modelCode, int modelSubCode)
        {
            ModelNameU modelNameU = null;

            if ((modelCode == 0) && (modelSubCode == 0)) return modelNameU;

            int status = this._modelNameUAcs.Read(out modelNameU, this._enterpriseCode, makerCode, modelCode, modelSubCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) modelNameU = null;

            return modelNameU;
        }

        /// <summary>
        /// カラー情報選択処理
        /// </summary>
        /// <param name="colorInfoDataTable">カラー情報データテーブル</param>
        /// <param name="colorCode">カラーコード</param>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        /// <remarks>
        /// <br>Note       : カラー情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool SelectColorInfo(PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, string colorCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            this.SettingColorInfoAllState(colorInfoDataTable, false);   // 全明細選択解除
            if (extraInfo != null)
            {
                extraInfo.ColorCode = string.Empty; // カラーコード
                extraInfo.ColorName1 = string.Empty; // カラー名称
            }
            if (colorCode != string.Empty)
            {
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}='{1}'", colorInfoDataTable.ColorCodeColumn.ColumnName, colorCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = rows[0];
                    colorInfoRow.SelectionState = true;
                    if (extraInfo != null)
                    {
                        extraInfo.ColorCode = colorInfoRow.ColorCode; // カラーコード
                        extraInfo.ColorName1 = colorInfoRow.ColorName1; // カラー名称
                    }
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// カラー情報全明細選択／解除処理
        /// </summary>
        /// <param name="colorInfoDataTable">カラー情報データテーブル</param>
        /// <param name="state">選択状態</param>
        /// <remarks>
        /// <br>Note       : カラー情報全明細選択／解除処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingColorInfoAllState(PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, bool state)
        {
            foreach (PMKEN01010E.ColorCdInfoRow colorInfoRow in colorInfoDataTable)
            {
                colorInfoRow.SelectionState = state;
            }
        }

        /// <summary>
        /// トリム情報選択処理
        /// </summary>
        /// <param name="trimInfoDataTable">トリム情報データテーブル</param>
        /// <param name="trimCode">トリムコード</param>
        /// <param name="extraInfo">車輌管理情報</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        /// <remarks>
        /// <br>Note       : トリム情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool SelectTrimInfo(PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, string trimCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            this.SettingTrimInfoAllState(trimInfoDataTable, false); // 全明細選択解除
            if (extraInfo != null)
            {
                extraInfo.TrimCode = string.Empty; // トリムコード
                extraInfo.TrimName = string.Empty; // トリム名称
            }
            if (trimCode != string.Empty)
            {
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}='{1}'", trimInfoDataTable.TrimCodeColumn.ColumnName, trimCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = rows[0];
                    trimInfoRow.SelectionState = true;
                    if (extraInfo != null)
                    {
                        extraInfo.TrimCode = trimInfoRow.TrimCode; // トリムコード
                        extraInfo.TrimName = trimInfoRow.TrimName; // トリム名称
                    }
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// トリム情報全明細選択／解除処理
        /// </summary>
        /// <param name="trimInfoDataTable">トリム情報データテーブル</param>
        /// <param name="state">選択状態</param>
        /// <remarks>
        /// <br>Note       : トリム情報全明細選択／解除処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingTrimInfoAllState(PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, bool state)
        {
            foreach (PMKEN01010E.TrimCdInfoRow trimInfoRow in trimInfoDataTable)
            {
                trimInfoRow.SelectionState = state;
            }
        }

        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="eqpDspInfoDataTable">装備情報データテーブル</param>
        /// <param name="equipmentGenreCd">装備キー</param>
        /// <param name="selectIndex">インデックス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 装備情報選択処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool SelectEquipInfo(Guid carRelationGuid, PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable, string equipmentGenreCd, int selectIndex)
        {
            bool ret = false;

            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])eqpDspInfoDataTable.Select(string.Format("{0}='{1}'", eqpDspInfoDataTable.EquipmentGenreNmColumn.ColumnName, equipmentGenreCd));
            if (rows.Length > 0)
            {
                this.SettingEquipInfoAllState(eqpDspInfoDataTable, equipmentGenreCd, false);
                PMKEN01010E.CEqpDefDspInfoRow equipInfoRow = rows[selectIndex];
                equipInfoRow.SelectionState = true;
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 車両情報行オブジェクトを車両管理ワークオブジェクトから取得
        /// </summary>
        /// <param name="extraInfo">車両情報行オブジェクト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車両情報行オブジェクトを車両管理ワークオブジェクトから取得。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private CarManagementWork ConvertCarMngExtraInfoToCarMngWork(CarMangInputExtraInfo extraInfo)
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.EnterpriseCode = this._enterpriseCode;               // 企業コード
            carManagementWork.CreateDateTime = extraInfo.CreateDateTime;           // 作成日時
            carManagementWork.FileHeaderGuid = extraInfo.FileHeaderGuid;           // GUID
            carManagementWork.UpdateDateTime = extraInfo.UpdateDateTime;           // 更新日付
            carManagementWork.LogicalDeleteCode = extraInfo.LogicalDeleteCode;     // 論理削除区分
            carManagementWork.CustomerCode = extraInfo.CustomerCode;               // 得意先コード
            carManagementWork.CarMngNo = extraInfo.CarMngNo;                       // 車両管理番号
            carManagementWork.CarMngCode = extraInfo.CarMngCode;                   // 車輌管理コード
            carManagementWork.NumberPlate1Code = extraInfo.NumberPlate1Code;       // 陸運事務所番号
            // ---- ADD 2009/10/10 ------>>>>>
            if (extraInfo.NumberPlate1Name.Length > 4)
            {
                carManagementWork.NumberPlate1Name = extraInfo.NumberPlate1Name.Substring(0,4);
            }
            else
            {
                carManagementWork.NumberPlate1Name = extraInfo.NumberPlate1Name;       // 陸運事務局名称
            }
            // ---- ADD 2009/10/10 ------<<<<<
            carManagementWork.NumberPlate2 = extraInfo.NumberPlate2;               // 車両登録番号（種別）
            carManagementWork.NumberPlate3 = extraInfo.NumberPlate3;               // 車両登録番号（カナ）
            carManagementWork.NumberPlate4 = extraInfo.NumberPlate4;               // 車両登録番号（プレート番号）
            carManagementWork.EntryDate = extraInfo.EntryDate;                     // 登録年月日
            carManagementWork.FirstEntryDate = extraInfo.ProduceTypeOfYearInput;   // 初年度
            carManagementWork.MakerCode = extraInfo.MakerCode;                     // メーカーコード
            carManagementWork.MakerFullName = extraInfo.MakerFullName;             // メーカー全角名称
            carManagementWork.MakerHalfName = extraInfo.MakerHalfName;             // メーカー半角名称
            carManagementWork.ModelCode = extraInfo.ModelCode;                     // 車種コード
            carManagementWork.ModelSubCode = extraInfo.ModelSubCode;               // 車種サブコード
            carManagementWork.ModelFullName = extraInfo.ModelFullName;             // 車種全角名称
            carManagementWork.ModelHalfName = extraInfo.ModelHalfName;             // 車種半角名称
            carManagementWork.SystematicCode = extraInfo.SystematicCode;           // 系統コード
            carManagementWork.SystematicName = extraInfo.SystematicName;           // 系統名称
            carManagementWork.ProduceTypeOfYearCd = extraInfo.ProduceTypeOfYearCd; // 生産年式コード
            carManagementWork.ProduceTypeOfYearNm = extraInfo.ProduceTypeOfYearNm; // 生産年式名称
            carManagementWork.StProduceTypeOfYear = extraInfo.StProduceTypeOfYear; // 開始生産年式
            carManagementWork.EdProduceTypeOfYear = extraInfo.EdProduceTypeOfYear; // 終了生産年式
            carManagementWork.DoorCount = extraInfo.DoorCount;                     // ドア数
            carManagementWork.BodyNameCode = extraInfo.BodyNameCode;               // ボディー名コード
            carManagementWork.BodyName = extraInfo.BodyName;                       // ボディー名称
            carManagementWork.ExhaustGasSign = extraInfo.ExhaustGasSign;           // 排ガス記号
            carManagementWork.SeriesModel = extraInfo.SeriesModel;                 // シリーズ型式
            carManagementWork.CategorySignModel = extraInfo.CategorySignModel;     // 型式（類別記号）
            carManagementWork.FullModel = extraInfo.FullModel;                     // 型式（フル型）
            carManagementWork.ModelDesignationNo = extraInfo.ModelDesignationNo;   // 型式指定番号
            carManagementWork.CategoryNo = extraInfo.CategoryNo;                   // 類別番号
            carManagementWork.FrameModel = extraInfo.FrameModel;                   // 車台型式
            carManagementWork.FrameNo = extraInfo.FrameNo;                         // 車台番号
            carManagementWork.SearchFrameNo = extraInfo.SearchFrameNo;             // 車台番号（検索用）
            carManagementWork.StProduceFrameNo = extraInfo.StProduceFrameNo;       // 生産車台番号開始
            carManagementWork.EdProduceFrameNo = extraInfo.EdProduceFrameNo;       // 生産車台番号終了
            carManagementWork.EngineModel = extraInfo.EngineModel;                 // 原動機型式（エンジン）
            carManagementWork.ModelGradeNm = extraInfo.ModelGradeNm;               // 型式グレード名称
            carManagementWork.EngineModelNm = extraInfo.EngineModelNm;             // エンジン型式名称
            carManagementWork.EngineDisplaceNm = extraInfo.EngineDisplaceNm;       // 排気量名称
            carManagementWork.EDivNm = extraInfo.EDivNm;                           // E区分名称
            carManagementWork.TransmissionNm = extraInfo.TransmissionNm;           // ミッション名称
            carManagementWork.ShiftNm = extraInfo.ShiftNm;                         // シフト名称
            carManagementWork.WheelDriveMethodNm = extraInfo.WheelDriveMethodNm;   // 駆動方式名称
            carManagementWork.AddiCarSpec1 = extraInfo.AddiCarSpec1;               // 追加諸元1
            carManagementWork.AddiCarSpec2 = extraInfo.AddiCarSpec2;               // 追加諸元2
            carManagementWork.AddiCarSpec3 = extraInfo.AddiCarSpec3;               // 追加諸元3
            carManagementWork.AddiCarSpec4 = extraInfo.AddiCarSpec4;               // 追加諸元4
            carManagementWork.AddiCarSpec5 = extraInfo.AddiCarSpec5;               // 追加諸元5
            carManagementWork.AddiCarSpec6 = extraInfo.AddiCarSpec6;               // 追加諸元6
            carManagementWork.AddiCarSpecTitle1 = extraInfo.AddiCarSpecTitle1;     // 追加諸元タイトル1
            carManagementWork.AddiCarSpecTitle2 = extraInfo.AddiCarSpecTitle2;     // 追加諸元タイトル2
            carManagementWork.AddiCarSpecTitle3 = extraInfo.AddiCarSpecTitle3;     // 追加諸元タイトル3
            carManagementWork.AddiCarSpecTitle4 = extraInfo.AddiCarSpecTitle4;     // 追加諸元タイトル4
            carManagementWork.AddiCarSpecTitle5 = extraInfo.AddiCarSpecTitle5;     // 追加諸元タイトル5
            carManagementWork.AddiCarSpecTitle6 = extraInfo.AddiCarSpecTitle6;     // 追加諸元タイトル6
            carManagementWork.RelevanceModel = extraInfo.RelevanceModel;           // 関連型式
            carManagementWork.SubCarNmCd = extraInfo.SubCarNmCd;                   // サブ車名コード
            carManagementWork.ModelGradeSname = extraInfo.ModelGradeSname;         // 型式グレード略称
            carManagementWork.BlockIllustrationCd = extraInfo.BlockIllustrationCd; // ブロックイラストコード
            carManagementWork.ThreeDIllustNo = extraInfo.ThreeDIllustNo;           // 3DイラストNo
            carManagementWork.PartsDataOfferFlag = extraInfo.PartsDataOfferFlag;   // 部品データ提供フラグ
            carManagementWork.InspectMaturityDate = extraInfo.InspectMaturityDate; // 車検満期日
            carManagementWork.LTimeCiMatDate = extraInfo.LTimeCiMatDate;           // 前回車検満期日
            carManagementWork.CarInspectYear = extraInfo.CarInspectYear;           // 車検期間
            carManagementWork.Mileage = extraInfo.Mileage;                         // 車両走行距離
            carManagementWork.CarNo = extraInfo.CarNo;                             // 号車
            carManagementWork.FullModelFixedNoAry = extraInfo.FullModelFixedNoAry; // フル型式固定番号配列
            carManagementWork.ColorCode = extraInfo.ColorCode;                     // カラーコード
            carManagementWork.ColorName1 = extraInfo.ColorName1;                   // カラー名称
            carManagementWork.TrimCode = extraInfo.TrimCode;                       // トリムコード
            carManagementWork.TrimName = extraInfo.TrimName;                       // トリム名称
            carManagementWork.CategoryObjAry = this.GetEquipInfoRows(extraInfo.CarRelationGuid); // 装備オブジェクト配列
            carManagementWork.CarAddInfo1 = extraInfo.CarAddInfo1;                 // 追加情報１
            carManagementWork.CarAddInfo2 = extraInfo.CarAddInfo2;                 // 追加情報２
            carManagementWork.CarNote = extraInfo.CarNote;                         // 備考
            // -------- ADD 2010/04/27 ----------------------->>>>>
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, extraInfo.FreeSrchMdlFxdNoAry);
            carManagementWork.FreeSrchMdlFxdNoAry = ms.GetBuffer(); // 自由検索型式固定番号配列
            ms.Close();
            // -------- ADD 2010/04/27 -----------------------<<<<<
            // ADD 2013/03/22 -------------------->>>>>	        
            carManagementWork.DomesticForeignCode = extraInfo.DomesticForeignCode;  // 国産/外車区分
            carManagementWork.HandleInfoCode = extraInfo.HandleInfoCode;  // ハンドル位置情報
            if (extraInfo.DomesticForeignCode == 2)
            {
                // 外車の場合はVINコード(文字列)を格納する為、車台番号（検索用）には0を格納
                carManagementWork.SearchFrameNo = 0;             // 車台番号（検索用）
            }
            // ADD 2013/03/22 --------------------<<<<<
            return carManagementWork;
        }


        /// <summary>
        /// 車両管理ワークオブジェクトを車両情報行オブジェクトから取得
        /// </summary>
        /// <param name="work">車両情報行オブジェクト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車両管理ワークオブジェクトを車両情報行オブジェクトから取得。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>update Note  : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正</br>
        /// <br>             　施ヘイ中</br>
        /// <br>Date       　: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private CarMangInputExtraInfo ConvertCarMngWorkToCarMngExtraInfo(CarManagementWork work)
        {
            CarMangInputExtraInfo extraInfo = new CarMangInputExtraInfo();

            extraInfo.EnterpriseCode = this._enterpriseCode;          // 企業コード
            extraInfo.CreateDateTime = work.CreateDateTime;           // 作成日時
            extraInfo.FileHeaderGuid = work.FileHeaderGuid;           // GUID
            extraInfo.UpdateDateTime = work.UpdateDateTime;           // 更新日付
            extraInfo.LogicalDeleteCode = work.LogicalDeleteCode;     // 論理削除区分
            extraInfo.CustomerCode = work.CustomerCode;               // 得意先コード
            extraInfo.CarMngNo = work.CarMngNo;                       // 車両管理番号
            extraInfo.CarMngCode = work.CarMngCode;                   // 車輌管理コード
            extraInfo.NumberPlate1Code = work.NumberPlate1Code;       // 陸運事務所番号
            // ---- ADD 2009/10/10 ------>>>>>
            if (work.NumberPlate1Name.Length > 4)
            {
                extraInfo.NumberPlate1Name = work.NumberPlate1Name.Substring(0, 4);
            }
            else
            {
                extraInfo.NumberPlate1Name = work.NumberPlate1Name;       // 陸運事務局名称
            }
            // ---- ADD 2009/10/10 ------<<<<<
            extraInfo.NumberPlate2 = work.NumberPlate2;               // 車両登録番号（種別）
            extraInfo.NumberPlate3 = work.NumberPlate3;               // 車両登録番号（カナ）
            extraInfo.NumberPlate4 = work.NumberPlate4;               // 車両登録番号（プレート番号）
            extraInfo.EntryDate = work.EntryDate;                     // 登録年月日
            extraInfo.ProduceTypeOfYearInput = work.FirstEntryDate;   // 初年度
            // 年式
            if (work.FirstEntryDate != 0)
            {
                //extraInfo.FirstEntryDate = DateTime.ParseExact(work.FirstEntryDate.ToString(), "yyyyMM", null);
                extraInfo.FirstEntryDate = work.FirstEntryDate;  // ADD 2009/10/10
            }
            extraInfo.MakerCode = work.MakerCode;                     // メーカーコード
            extraInfo.MakerFullName = work.MakerFullName;             // メーカー全角名称
            extraInfo.MakerHalfName = work.MakerHalfName;             // メーカー半角名称
            extraInfo.ModelCode = work.ModelCode;                     // 車種コード
            extraInfo.ModelSubCode = work.ModelSubCode;               // 車種サブコード
            extraInfo.ModelFullName = work.ModelFullName;             // 車種全角名称
            extraInfo.ModelHalfName = work.ModelHalfName;             // 車種半角名称
            extraInfo.SystematicCode = work.SystematicCode;           // 系統コード
            extraInfo.SystematicName = work.SystematicName;           // 系統名称
            extraInfo.ProduceTypeOfYearCd = work.ProduceTypeOfYearCd; // 生産年式コード
            extraInfo.ProduceTypeOfYearNm = work.ProduceTypeOfYearNm; // 生産年式名称
            extraInfo.StProduceTypeOfYear = work.StProduceTypeOfYear; // 開始生産年式
            extraInfo.EdProduceTypeOfYear = work.EdProduceTypeOfYear; // 終了生産年式
            extraInfo.DoorCount = work.DoorCount;                     // ドア数
            extraInfo.BodyNameCode = work.BodyNameCode;               // ボディー名コード
            extraInfo.BodyName = work.BodyName;                       // ボディー名称
            extraInfo.ExhaustGasSign = work.ExhaustGasSign;           // 排ガス記号
            extraInfo.SeriesModel = work.SeriesModel;                 // シリーズ型式
            extraInfo.CategorySignModel = work.CategorySignModel;     // 型式（類別記号）
            extraInfo.FullModel = work.FullModel;                     // 型式（フル型）
            extraInfo.ModelDesignationNo = work.ModelDesignationNo;   // 型式指定番号
            extraInfo.CategoryNo = work.CategoryNo;                   // 類別番号
            extraInfo.FrameModel = work.FrameModel;                   // 車台型式
            extraInfo.FrameNo = work.FrameNo;                         // 車台番号
            extraInfo.SearchFrameNo = work.SearchFrameNo;             // 車台番号（検索用）
            extraInfo.StProduceFrameNo = work.StProduceFrameNo;       // 生産車台番号開始
            extraInfo.EdProduceFrameNo = work.EdProduceFrameNo;       // 生産車台番号終了
            extraInfo.EngineModel = work.EngineModel;                 // 原動機型式（エンジン）
            extraInfo.ModelGradeNm = work.ModelGradeNm;               // 型式グレード名称
            extraInfo.EngineModelNm = work.EngineModelNm;             // エンジン型式名称
            extraInfo.EngineDisplaceNm = work.EngineDisplaceNm;       // 排気量名称
            extraInfo.EDivNm = work.EDivNm;                           // E区分名称
            extraInfo.TransmissionNm = work.TransmissionNm;           // ミッション名称
            extraInfo.ShiftNm = work.ShiftNm;                         // シフト名称
            extraInfo.WheelDriveMethodNm = work.WheelDriveMethodNm;   // 駆動方式名称
            extraInfo.AddiCarSpec1 = work.AddiCarSpec1;               // 追加諸元1
            extraInfo.AddiCarSpec2 = work.AddiCarSpec2;               // 追加諸元2
            extraInfo.AddiCarSpec3 = work.AddiCarSpec3;               // 追加諸元3
            extraInfo.AddiCarSpec4 = work.AddiCarSpec4;               // 追加諸元4
            extraInfo.AddiCarSpec5 = work.AddiCarSpec5;               // 追加諸元5
            extraInfo.AddiCarSpec6 = work.AddiCarSpec6;               // 追加諸元6
            extraInfo.AddiCarSpecTitle1 = work.AddiCarSpecTitle1;     // 追加諸元タイトル1
            extraInfo.AddiCarSpecTitle2 = work.AddiCarSpecTitle2;     // 追加諸元タイトル2
            extraInfo.AddiCarSpecTitle3 = work.AddiCarSpecTitle3;     // 追加諸元タイトル3
            extraInfo.AddiCarSpecTitle4 = work.AddiCarSpecTitle4;     // 追加諸元タイトル4
            extraInfo.AddiCarSpecTitle5 = work.AddiCarSpecTitle5;     // 追加諸元タイトル5
            extraInfo.AddiCarSpecTitle6 = work.AddiCarSpecTitle6;     // 追加諸元タイトル6
            extraInfo.RelevanceModel = work.RelevanceModel;           // 関連型式
            extraInfo.SubCarNmCd = work.SubCarNmCd;                   // サブ車名コード
            extraInfo.ModelGradeSname = work.ModelGradeSname;         // 型式グレード略称
            extraInfo.BlockIllustrationCd = work.BlockIllustrationCd; // ブロックイラストコード
            extraInfo.ThreeDIllustNo = work.ThreeDIllustNo;           // 3DイラストNo
            extraInfo.PartsDataOfferFlag = work.PartsDataOfferFlag;   // 部品データ提供フラグ
            extraInfo.InspectMaturityDate = work.InspectMaturityDate; // 車検満期日
            extraInfo.LTimeCiMatDate = work.LTimeCiMatDate;           // 前回車検満期日
            extraInfo.CarInspectYear = work.CarInspectYear;           // 車検期間
            extraInfo.Mileage = work.Mileage;                         // 車両走行距離
            extraInfo.CarNo = work.CarNo;                             // 号車
            extraInfo.FullModelFixedNoAry = work.FullModelFixedNoAry; // フル型式固定番号配列
            extraInfo.ColorCode = work.ColorCode;                     // カラーコード
            extraInfo.ColorName1 = work.ColorName1;                   // カラー名称
            extraInfo.TrimCode = work.TrimCode;                       // トリムコード
            extraInfo.TrimName = work.TrimName;                       // トリム名称
            extraInfo.CategoryObjAry = work.CategoryObjAry;           // 装備オブジェクト配列
            extraInfo.CarAddInfo1 = work.CarAddInfo1;                 // 追加情報１
            extraInfo.CarAddInfo2 = work.CarAddInfo2;                 // 追加情報２
            extraInfo.CarNote = work.CarNote;                         // 備考
            // ----- ADD 2010/04/27 ------------------->>>>>
            // ----- UPD 2010/05/20 ------------------->>>>>
            // ----- UPD 2010/12/22 ------------------->>>>>
            //if (null == work.FreeSrchMdlFxdNoAry)
            if (null == work.FreeSrchMdlFxdNoAry || work.FreeSrchMdlFxdNoAry.Length == 0)
            // ----- UPD 2010/12/22 -------------------<<<<<
            {
                extraInfo.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(work.FreeSrchMdlFxdNoAry);
                extraInfo.FreeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms); // 自由検索型式固定番号配列
                ms.Close();
            }
            // --- DEL 2012/09/18 Y.Wakita ---------->>>>>
            //// ----ADD 2010/12/22 ------>>>>>
            //if (null == work.FreeSrchMdlFxdNoAry || work.FreeSrchMdlFxdNoAry.Length == 0)
            //{
            //    extraInfo.FreeSrchMdlFxdNoAry = new string[0];
            //}
            //else
            //{
            //    byte[] bfrom = work.FreeSrchMdlFxdNoAry;
            //    string[] freeAry = new string[bfrom.Length];
            //    for (int i = 0; i < bfrom.Length; i++)
            //    {
            //        freeAry[i] = bfrom[i].ToString();
            //    }
            //    extraInfo.FreeSrchMdlFxdNoAry = freeAry;
            //}
            //// ----ADD 2010/12/22 ------<<<<<
            // --- DEL 2012/09/18 Y.Wakita ----------<<<<<

            // ----- UPD 2010/05/20 -------------------<<<<<
            // ----- ADD 2010/04/27 -------------------<<<<<

            // ADD 2013/03/22 -------------------->>>>>	        
            extraInfo.DomesticForeignCode = work.DomesticForeignCode;          // 国産/外車区分
            extraInfo.HandleInfoCode = work.HandleInfoCode;  // ハンドル位置情報
            this._handleInfoCode = work.HandleInfoCode; // ハンドル位置情報キャッシュをクリアする
            this._carInfo = null; // 型式情報のキャッシュをクリアする(情報読込時/保存時)
            // ADD 2013/03/22 --------------------<<<<<



            return extraInfo;
        }

        /// <summary>
        /// ガイド用の検索条件設定処理
        /// </summary>
        /// <param name="inParm"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ガイド用の検索条件設定処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private CarMngGuideParamWork ConvertHashtableToCarMngGuideParamWork(Hashtable inParm)
        {
            CarMngGuideParamWork paraWork = new CarMngGuideParamWork();
            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                paraWork.EnterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                paraWork.EnterpriseCode = this._enterpriseCode;
            }

            // 得意先チェックフラグ
            if (inParm.ContainsKey("IsCheckCustomerCode"))
            {
                paraWork.IsCheckCustomerCode = (bool)inParm["IsCheckCustomerCode"];
            }

            // 得意先コード
            if (inParm.ContainsKey("CustomerCode"))
            {
                paraWork.CustomerCode = (Int32)inParm["CustomerCode"];
            }

            // 管理番号チェックフラグ
            if (inParm.ContainsKey("IsCheckCarMngCode"))
            {
                paraWork.IsCheckCarMngCode = (bool)inParm["IsCheckCarMngCode"];
            }

            // 管理番号
            if (inParm.ContainsKey("CarMngCode"))
            {
                paraWork.CarMngCode = inParm["CarMngCode"].ToString();
            }

            // 車輌管理区分チェック方式
            if (inParm.ContainsKey("CheckCarMngCodeType"))
            {
                paraWork.CheckCarMngCodeType = (Int32)inParm["CheckCarMngCodeType"];
            }

            // 車輌管理区分チェックフラグ
            if (inParm.ContainsKey("IsCheckCarMngDivCd"))
            {
                paraWork.IsCheckCarMngDivCd = (bool)inParm["IsCheckCarMngDivCd"];
            }

            return paraWork;
        }

        /// <summary>
        /// ガイド用の検索条件設定処理（ワークへ変換）
        /// </summary>
        /// <param name="info">ガイドオブジェクト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ガイド用の検索条件設定処理（ワークへ変換）を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private CarMngGuideParamWork ConvertCarMngGuideParamInfoToWork(CarMngGuideParamInfo info)
        {
            CarMngGuideParamWork work = new CarMngGuideParamWork();

            work.EnterpriseCode = info.EnterpriseCode;
            work.IsCheckCustomerCode = info.IsCheckCustomerCode;
            work.CustomerCode = info.CustomerCode;
            work.IsCheckCarMngCode = info.IsCheckCarMngCode;
            work.CarMngCode = info.CarMngCode;
            work.CheckCarMngCodeType = info.CheckCarMngCodeType;
            work.IsCheckCarMngDivCd = info.IsCheckCarMngDivCd;

            return work;
        }

        /// <summary>
        /// 車輌管理ガイド検索処理（ArrayList用）
        /// </summary>
        /// <param name="ds">取得結果格納用ArrayList</param>
        /// <param name="paraWork">検索条件</param>
        /// <param name="isDispCustomerInfo">得意先表示フラグ</param>
        /// <param name="isDispNewRow">新規登録行表示フラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車輌管理ガイドの検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
        /// </remarks>
        private int SearchGuide(out ArrayList ds, CarMngGuideParamWork paraWork, bool isDispCustomerInfo, bool isDispNewRow)
        {
            ArrayList ar = new ArrayList();
            ds = new ArrayList();

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // "新規登録"表示制御判定
            if (isDispNewRow)
            {
                CarMangInputExtraInfo carMangInfo = new CarMangInputExtraInfo();
                carMangInfo.EnterpriseCode = paraWork.EnterpriseCode;
                carMangInfo.CarMngCode = "新規登録";
                ar.Add(carMangInfo.Clone());
            }

            Object carMngGuideWorkObj = paraWork as object;
            Object carMngWorkListObj = (new ArrayList()) as object;

            // リモート検索
            status = this._iCarManagementDB.SearchGuide(carMngGuideWorkObj, out carMngWorkListObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList carMngWorkList = carMngWorkListObj as ArrayList;
                foreach (CarManagementWork work in carMngWorkList)
                {
                    CarMangInputExtraInfo carMangInfo = new CarMangInputExtraInfo();
                    // 企業コード
                    carMangInfo.EnterpriseCode = work.EnterpriseCode;
                    // 得意先コード
                    carMangInfo.CustomerCode = work.CustomerCode;
                    if (work.CustomerCode != 0)
                    {
                        carMangInfo.CustomerCodeForGuide = work.CustomerCode.ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        carMangInfo.CustomerCodeForGuide = string.Empty;
                    }
                    // 車輌管理番号
                    carMangInfo.CarMngNo = work.CarMngNo;
                    // 管理番号                    
                    carMangInfo.CarMngCode = work.CarMngCode;
                    // 車種
                    carMangInfo.ModelFullName = work.ModelFullName;
                    // 型式
                    carMangInfo.FullModel = work.FullModel;
                    // 車台番号
                    carMangInfo.FrameNo = work.FrameNo;
                    // 登録番号
                    // ADD 2013/04/19 SCM障害№10521対応 ---------------------------------->>>>>
                    carMangInfo.NumberPlate1Code = work.NumberPlate1Code;       // 陸運事務局登録番号
                    carMangInfo.NumberPlate1Name = work.NumberPlate1Name;       // 陸運事務局名称
                    carMangInfo.NumberPlate2 = work.NumberPlate2;               // 車両登録番号（種別）
                    carMangInfo.NumberPlate3 = work.NumberPlate3;               // 車両登録番号（カナ）
                    carMangInfo.NumberPlate4 = work.NumberPlate4;               // 車両登録番号（プレート番号）
                    // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------<<<<<
                    string plate1Name = work.NumberPlate1Name;      // 陸運事務局名称
                    string plate2 = work.NumberPlate2;              // 車両登録番号（種別）
                    string plate3 = work.NumberPlate3;              // 車両登録番号（カナ）
                    string plate4 = work.NumberPlate4 == 0 ? "" : work.NumberPlate4.ToString();   // 車両登録番号（プレート番号）
                    string plateGuideNm = plate1Name.PadRight(4, '　') + plate2.PadLeft(3, ' ') + plate3.PadRight(1, '　') + plate4.PadLeft(4, ' ');
                    carMangInfo.NumberPlateForGuide = plateGuideNm;
                    // -- add wangf 2011/08/02 ---------->>>>>
                    carMangInfo.CarNote = work.CarNote;
                    // -- add wangf 2011/08/02 ----------<<<<<

                    // 得意先名
                    carMangInfo.CustomerName = work.CustomerName;
                    ar.Add(carMangInfo.Clone());
                }
            }

            if (ar.Count != 0)
            {
                ds = ar;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        # endregion

        // --- ADD 2013/03/22 ---------->>>>>
        /// <summary>
        /// ハンドル位置チェック
        /// </summary>
        /// <param name="vinCode">VINコード</param>
        /// <returns>true:一致 false:不一致</returns>
        public bool CompareHandlePosition(string vinCode)
        {
            try
            {
                // VINコードからハンドル位置を取得(右/左ハンドル以外の場合はチェックを行わない)
                HandleInfoCdRet posVin = this._carSearchController.GetHandlePositionFromVinCode(vinCode);
                if (posVin != HandleInfoCdRet.PositionRight && posVin != HandleInfoCdRet.PositionLeft)
                    return true;

                if (this._carInfo != null)
                {
                    // 型式検索で選択されているすべての行を比較する
                    int pos = this._carInfo.HandleInfoCdColumn.Ordinal;
                    int state = this._carInfo.SelectionStateColumn.Ordinal;
                    foreach (DataRow row in this._carInfo.Rows)
                    {
                        // 選択されていない行はスキップする
                        if ((bool)row[state] != true)
                            continue;

                        // 右/左ハンドル以外が1件でもあった場合は処理を中断し、位置のチェックを行わない
                        HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                        if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                            return true;

                        // ハンドル位置を比較する
                        if (posKind == posVin)
                        {
                            // 1件でもハンドル位置が一致している場合、一致とする
                            return true;
                        }
                    }

                    // すべての行のハンドル位置が異なる場合、不一致とする
                    return false;
                }
                else
                {
                    // ハンドル位置情報キャッシュのチェック
                    if (this._handleInfoCode != (int)HandleInfoCdRet.PositionRight && this._handleInfoCode != (int)HandleInfoCdRet.PositionLeft)
                        return true;

                    // ハンドル位置を比較する
                    return this._handleInfoCode == (int)posVin;
                }
            }
            catch
            {
                // 例外が発生した場合はチェックを行わない
            }

            return true;
        }
        // ADD 2013/03/22 --------------------<<<<<
    }


        // -- add wangf 2011/08/02 ---------->>>>>
        /// <summary>
        /// 車輌管理データ比較クラス(車輌管理コード(昇順)、得意先コード(昇順))
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理ガイドの検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>           : PM1107C　NSユーザー改良要望一覧_PM7相違_連番895に修正</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/02</br>
        /// </remarks>
        internal class CarMngInputCompareList : Comparer<CarMangInputExtraInfo>
        {
            public override int Compare(CarMangInputExtraInfo x, CarMangInputExtraInfo y)
            {
                int result = x.CarMngCode.CompareTo(y.CarMngCode);
                if (result != 0)
                {
                    if ("新規登録".Equals(x.CarMngCode))
                        result = -1;
                    if ("新規登録".Equals(y.CarMngCode))
                        result = 1;
                    return result;
                }

                result = x.CustomerCode.CompareTo(y.CustomerCode);
                return result;
            }
        }
        // -- add wangf 2011/08/02 ----------<<<<<
}