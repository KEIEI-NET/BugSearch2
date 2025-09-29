using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.IO;  // ADD 2010/07/07
using WinForms = System.Windows.Forms; // ADD 2010/07/07
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車両検索コントローラ
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両検索コントローラクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: 車台番号⇒車台番号、車台番号（検索用）に修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.28</br>        
    /// <br></br>
    /// <br>Update Note: 2009/10/13  22018  鈴木 正臣</br>
    /// <br>           : 見出貼付機能の修正対応（フル型式固定番号＝ゼロの場合の対応）</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/21  22018  鈴木 正臣</br>
    /// <br>           : 見出貼付機能の修正対応（型式検索後に品番入力モードに変更して型式手入力した場合の対応）</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/27  21024　佐々木 健</br>
    /// <br>           : 大型オプションのフラグの誤りを修正(MANTIS[0014520])</br>
    /// <br>           : フル型式固定番号0(部品未収録)はPM7と同様に年式圧縮するように修正(MANTIS[0014519])</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/17  20056　對馬 大輔</br>
    /// <br>           : MANTIS[14559] シリーズ型式と型式(類別記号)のセット方法変更</br>
    /// <br>           : MANTIS[14790] 排ガス記号のセット方法変更</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/04  21024　佐々木 健</br>
    /// <br>           : MANTIS[0014831] 車台型式が複数あった場合の複数車台型式あった場合の絞り込み方法変更 </br>
    /// <br></br>
    /// <br>Update Note: 2010/03/29  20056　對馬 大輔</br>
    /// <br>           : MANTIS[0015220] 年式範囲を正しく表示するように圧縮方法変更</br>
    /// <br>           : MANTIS[0015168] 車輌検索は大型検索オプションを考慮せず、常に大型検索可能とする</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/19  22018　鈴木 正臣</br>
    /// <br>           : 自由検索オプション対応（ユーザーＤＢの自由検索型式マスタから抽出）</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/01  22018　鈴木 正臣</br>
    /// <br>           : 自由検索部品マスメンでの車輌検索に関連して変更</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/25  22008　長内 数馬</br>
    /// <br>           : オフライン対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/15  22018　鈴木 正臣</br>
    /// <br>           : 成果物統合</br>
    /// <br>           :   オフライン対応 2010/05/25 の組込</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/07  22008　長内 数馬</br>
    /// <br>           : MANTIS対応 15715</br>
    /// <br>           :   オフライン処理に関して、SCMを考慮した判定とするように修正</br>
    /// <br></br>
    /// <br>Update Note: 2011/04/04  22008　長内 数馬</br>
    /// <br>           : フル型式検索（SearchByFullModelFixedNo）でフル型式固定番号未指定時は提供の検索をしないように修正</br>
    /// <br></br>
    /// <br>Update Note: 2012/05/28  20056　對馬 大輔</br>
    /// <br>           : SCM改良 No135</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/27  20073　西 毅</br>
    /// <br>           : 類別型式を入力し、型式選択画面が表示される場合に、装備情報がセットされない現象の修正</br>
    /// <br>Update Note: 2012/09/18  脇田 靖之</br>
    /// <br>           : ①車輌管理マスタを検索後、特定のデータを編集しようとするとフリーズしてしまう件の修正</br>
    /// <br>           : ②車輌管理マスタがエラーで保存できなくなる件の修正</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/21 FSI斎藤 和宏</br>
    /// <br>           : 10900269-00 SPK車台番号文字列対応</br>
    /// <br>           : 車両型式マスタから「国産/外車区分」「ハンドル位置情報」を追加で取得するよう修正</br>
    /// </remarks>
    public class CarSearchController
    {
        #region [ メンバー変数定義 ]
        private PMKEN01010E dataSet = null;

        // リモートオブジェクト インターフェース
        private ICarModelCtlDB _ICarModelCtlDB = null;		//車輌検索リモート
        private IColTrmEquInfDB _IColTrmEquInfDB = null;		//カラー・トリム・装備情報リモート
        private IPrdTypYearDB _IPrdTypYearDB = null;
        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        private IFreeSearchModelSearchDB _IFreeSearchModelSearchDB = null;
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
        // --- ADD T.Nishi 2012/07/27 ---------->>>>>
        private ArrayList _equipmentRetWork = null;
        // --- ADD T.Nishi 2012/07/27 ----------<<<<<

        /// <summary>0:大型契約なし 1:大型契約あり</summary>
        private int _bigCarOfferDiv;

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>0:自由検索なし 1:自由検索あり</summary>
        private int _freeSearchDiv;
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

        // 大型検索オプション用大型メーカーリスト
        private List<int> bigMakerList = new List<int>(new int[] { 10, 12, 13, 16 }); // 14：日本フォードは関係ない？

        #endregion

        #region [ コンストラクタ・デストラクタ ]
        /// <summary>
        /// 車両検索コントローラ コンストラクタ
        /// </summary>
        public CarSearchController()
        {
            // 大型提供区分 契約状況
            // 2009/10/27 >>>
            //PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData );
            // 2009/10/27 <<<
            //>>>2010/03/29
            //if (psBigCarOffer == PurchaseStatus.Contract || psBigCarOffer == PurchaseStatus.Trial_Contract)   // 大型契約あり
            //    _bigCarOfferDiv = 1;

            // 車輌検索は、大型オプションに無関係に大型検索を可能とする
            _bigCarOfferDiv = 1;
            //<<<2010/03/29

            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            // 自由検索オプションチェック
            PurchaseStatus psFreeSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch );
            if ( psFreeSearch == PurchaseStatus.Contract || psFreeSearch == PurchaseStatus.Trial_Contract )
            {
                // 自由検索あり
                _freeSearchDiv = 1;
            }
            else
            {
                // 自由検索なし
                _freeSearchDiv = 0;
            }
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            dataSet = new PMKEN01010E();

            //// リモート処理に必要な構成ファイルを読み取り、リモート処理インフラストラクチャを構成する。
            //RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
        }

        /// <summary>
        /// 車両検索コントローラ デストラクタ
        /// </summary>
        ~CarSearchController()
        {
        }
        #endregion

        #region [ 検索処理 ]
        /// <summary>
        /// 車両検索メソッド
        /// </summary>
        /// <param name="_searchCond">車両検索条件</param>
        /// <param name="_carSearchInfo">データセットクラス</param>
        /// <returns></returns>
        public CarSearchResultReport Search(CarSearchCondition _searchCond, ref PMKEN01010E _carSearchInfo)
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            dataSet.Clear();
            bool flgColorTrimSearched = false;

            if (_carSearchInfo.CarModelInfo != null && _carSearchInfo.CarModelInfo.Rows.Count > 0)
            {
                _carSearchInfo.AcceptChanges();
                dataSet.Merge(_carSearchInfo, false);
                ret = ColorTrimSearch();
                flgColorTrimSearched = true;
                // --- ADD T.Nishi 2012/07/27 ---------->>>>>
              #region 車両装備情報設定
                if (_equipmentRetWork != null)
                {
                    foreach (CtgryEquipWork wkSource in _equipmentRetWork)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}",
                            dataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName, wkSource.EquipmentCode,
                            dataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, wkSource.EquipmentGenreCd);
                        PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])dataSet.CEqpDefDspInfo.Select(filter);
                        if (rows.Length > 0)
                        {
                            rows[0].SelectionState = true;
                        }
                    }
                }
              #endregion
                // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            }
            else if (_carSearchInfo.CarKindInfo != null && _carSearchInfo.CarKindInfo.Rows.Count > 0)
            {
                ret = CarModelInfoSearch(_searchCond, ref _carSearchInfo);
            }
            else
            {
                ret = CarKindInfoSearch(_searchCond);
            }

            // Summarizing
            if (ret == CarSearchResultReport.retSingleCarModel || flgColorTrimSearched)
            {
                PMKEN01010E.CarModelInfoRow[] retRows = (PMKEN01010E.CarModelInfoRow[])dataSet.CarModelInfoSummarized.Select("SelectionState = True");
                if (dataSet.CarModelUIData.Rows.Count == 0)
                {
                    if (retRows.Length > 0)
                    {
                        dataSet.CarModelUIData.AddCarModelInfoRowCopy(retRows[0]);
                        dataSet.CarModelUIData[0].ModelDesignationNo = _searchCond.ModelDesignationNo;
                        dataSet.CarModelUIData[0].CategoryNo = _searchCond.CategoryNo;
                        dataSet.CarModelUIData.AcceptChanges();
                    }
                }
                else
                {
                    if (retRows.Length > 0)
                    {
                        dataSet.CarModelUIData.AddCarModelInfoRowCopy(retRows[0]);
                        dataSet.CarModelUIData[1].ModelDesignationNo = _searchCond.ModelDesignationNo;
                        dataSet.CarModelUIData[1].CategoryNo = _searchCond.CategoryNo;
                        // 2009.01.28 >>>
                        //dataSet.CarModelUIData[1].ProduceFrameNoInput = dataSet.CarModelUIData[0].ProduceFrameNoInput;
                        dataSet.CarModelUIData[1].FrameNo= dataSet.CarModelUIData[0].FrameNo;
                        dataSet.CarModelUIData[1].SearchFrameNo = dataSet.CarModelUIData[0].SearchFrameNo;
                        // 2009.01.28 <<<
                        dataSet.CarModelUIData[1].ProduceTypeOfYearInput = dataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                        dataSet.CarModelUIData[0].Delete();
                        dataSet.CarModelUIData.AcceptChanges();
                    }
                }
                PMKEN01010E.CarModelUIDataTable carModelUITable = dataSet.CarModelUIData;
                PMKEN01010E.CarModelUIRow carModelUIRowTmp = dataSet.CarModelUIData[0];
                if (carModelUIRowTmp.AddiCarSpec1 != string.Empty)
                {
                    carModelUITable.AddiCarSpec1Column.Caption = retRows[0].AddiCarSpecTitle1;
                }
                if (carModelUIRowTmp.AddiCarSpec2 != string.Empty)
                {
                    carModelUITable.AddiCarSpec2Column.Caption = retRows[0].AddiCarSpecTitle2;
                }
                if (carModelUIRowTmp.AddiCarSpec3 != string.Empty)
                {
                    carModelUITable.AddiCarSpec3Column.Caption = retRows[0].AddiCarSpecTitle3;
                }
                if (carModelUIRowTmp.AddiCarSpec4 != string.Empty)
                {
                    carModelUITable.AddiCarSpec4Column.Caption = retRows[0].AddiCarSpecTitle4;
                }
                if (carModelUIRowTmp.AddiCarSpec5 != string.Empty)
                {
                    carModelUITable.AddiCarSpec5Column.Caption = retRows[0].AddiCarSpecTitle5;
                }
                if (carModelUIRowTmp.AddiCarSpec6 != string.Empty)
                {
                    carModelUITable.AddiCarSpec6Column.Caption = retRows[0].AddiCarSpecTitle6;
                }
            }
            if (dataSet.CarModelUIData.Rows.Count > 0)
            {
                dataSet.CarModelUIData[0].ModelDesignationNo = _searchCond.ModelDesignationNo;
                dataSet.CarModelUIData[0].CategoryNo = _searchCond.CategoryNo;
            }
            _carSearchInfo = (PMKEN01010E)dataSet.Copy();
            _carSearchInfo.CarSearchCondition = _searchCond;

            // --- ADD m.suzuki 2010/06/01 ---------->>>>>
            // DefaultViewのSort順を設定する(自由検索部品マスメンで使用する為)
            _carSearchInfo.CarModelInfo.DefaultView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", 
                _carSearchInfo.CarModelInfo.FreeSearchSortDivColumn.ColumnName,
                _carSearchInfo.CarModelInfo.FullModelColumn.ColumnName,
                _carSearchInfo.CarModelInfo.ModelGradeNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.BodyNameColumn.ColumnName,
                _carSearchInfo.CarModelInfo.DoorCountColumn.ColumnName,
                _carSearchInfo.CarModelInfo.EngineModelNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.EngineDisplaceNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.EDivNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.TransmissionNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.ShiftNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.WheelDriveMethodNmColumn.ColumnName
            );
            // --- ADD m.suzuki 2010/06/01 ----------<<<<<

            return ret;
        }

        // --- ADD 2012/09/18 Y.Wakita ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_extraInfo">フル型式固定番号配列</param>
        /// <param name="_carSearchInfo">検索結果データクラス</param>
        /// <returns></returns>
        public CarSearchResultReport SearchByFullModelFixedNo(CarMangInputExtraInfo _extraInfo, ref PMKEN01010E _carSearchInfo)
        {
            // ※旧アセンブリとの互換性の為に本メソッドを用意します。
            //   通常はCarSearchConditionを受け取る方(↓)のメソッドを使用して下さい。

            CarSearchCondition carSearchCond = new CarSearchCondition();
            carSearchCond.ModelDesignationNo = _extraInfo.ModelDesignationNo;
            carSearchCond.CategoryNo = _extraInfo.CategoryNo;
            carSearchCond.CarModel.ExhaustGasSign = _extraInfo.ExhaustGasSign;
            carSearchCond.CarModel.SeriesModel = _extraInfo.SeriesModel;
            carSearchCond.CarModel.CategorySign = _extraInfo.CategorySignModel;
            carSearchCond.MakerCode = _extraInfo.MakerCode;
            carSearchCond.ModelCode = _extraInfo.ModelCode;
            carSearchCond.ModelSubCode = _extraInfo.ModelSubCode;

            return SearchByFullModelFixedNo(_extraInfo.FullModelFixedNoAry, carSearchCond, ref _carSearchInfo);
        }
        // --- ADD 2012/09/18 Y.Wakita ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別番号</param>
        /// <param name="_carSearchInfo">検索結果データクラス</param>
        /// <returns></returns>
        public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E _carSearchInfo )
        {
            // ※旧アセンブリとの互換性の為に本メソッドを用意します。
            //   通常はCarSearchConditionを受け取る方(↓)のメソッドを使用して下さい。

            CarSearchCondition carSearchCond = new CarSearchCondition();
            carSearchCond.ModelDesignationNo = modelDesignationNo;
            carSearchCond.CategoryNo = categoryNo;
            return SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref _carSearchInfo );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="carSearchCond">車種検索条件クラス</param>
        /// <param name="_carSearchInfo">検索結果データクラス</param>
        /// <returns></returns>
        public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E _carSearchInfo )
        {
            // ※旧アセンブリとの互換性の為に本メソッドを用意します。
            //   通常はfreeSrchMdlFxdNoを受け取る方(↓)のメソッドを使用して下さい。
            return SearchByFullModelFixedNo( fullModelFixedNo, new string[0], carSearchCond, ref _carSearchInfo );
        }
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="freeSrchMdlFxdNo">自由検索型式固定番号配列</param>
        /// <param name="carSearchCond">車種検索条件クラス</param>
        /// <param name="_carSearchInfo">検索結果データクラス</param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
        ////public CarSearchResultReport SearchByFullModelFixedNo(int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E _carSearchInfo)
        //public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E _carSearchInfo )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD
        public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, string[] freeSrchMdlFxdNo, CarSearchCondition carSearchCond, ref PMKEN01010E _carSearchInfo )
        // --- UPD m.suzuki 2010/04/19 ----------<<<<<
        {
            // -- ADD 2010/05/25 ----------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 -----------------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            // --- ADD T.Nishi 2012/07/27 ---------->>>>>
            _equipmentRetWork = null;
            // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            //結果クラス
            ArrayList kindList = null;

            ArrayList carModelRetList = null;
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList prdTypYearRetWork = null;
            ArrayList categoryEquipmentRetWork = null;
            ArrayList ctgyMdlLnkRetWork = null;
            ArrayList equipmentRetWork = null;

            CarModelCondWork _searchCond = new CarModelCondWork();
            _searchCond.FullModelFixedNos = fullModelFixedNo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
            //_searchCond.ModelDesignationNo = modelDesignationNo;
            //_searchCond.CategoryNo = categoryNo;

            _searchCond.ModelDesignationNo = carSearchCond.ModelDesignationNo;
            _searchCond.CategoryNo = carSearchCond.CategoryNo;

            _searchCond.ExhaustGasSign = carSearchCond.CarModel.ExhaustGasSign;
            _searchCond.SeriesModel = carSearchCond.CarModel.SeriesModel;
            _searchCond.CategorySignModel = carSearchCond.CarModel.CategorySign;
            _searchCond.MakerCode = carSearchCond.MakerCode;
            _searchCond.ModelCode = carSearchCond.ModelCode;
            _searchCond.ModelSubCode = carSearchCond.ModelSubCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD

            if (_ICarModelCtlDB == null)
                _ICarModelCtlDB = MediationCarModelCtlDB.GetRemoteObject();
            // -- UPD 2011/04/04 -------------------------------------------->>>
            //_ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
            //                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
            //                            out equipmentRetWork);

            if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
            {
                _ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                                            out equipmentRetWork);
            }

            if (kindList == null)
            {
                kindList = new ArrayList();
            }
            // -- UPD 2011/04/04 --------------------------------------------<<<

            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            // 自由検索型式取得処理
            //if ( _freeSearchDiv != 0 )
            if ( _freeSearchDiv != 0 && freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0 )
            {
                ArrayList fsKindList;
                ArrayList fsCarModelRetList;
                FreeSearchModelSCndtnWork fsSearchCond = CopyToFSCndtnFromCarModelCond( _searchCond );
                fsSearchCond.FreeSrchMdlFxdNos = freeSrchMdlFxdNo;
                if ( _IFreeSearchModelSearchDB == null )
                {
                    _IFreeSearchModelSearchDB = MediationFreeSearchModelSearchDB.GetRemoteObject();
                }
                _IFreeSearchModelSearchDB.GetCarFullModelNo( fsSearchCond, out fsKindList, out fsCarModelRetList );

                // 車種リスト
                if ( kindList == null && fsKindList != null && fsKindList.Count > 0 )
                {
                    kindList = new ArrayList();
                }
                foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                {
                    AddKindListDistinct( ref kindList, carKindInfo );
                }
                // 型式リスト
                if ( carModelRetList == null && fsCarModelRetList != null && fsCarModelRetList.Count > 0 )
                {
                    carModelRetList = new ArrayList();
                }
                foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                {
                    carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                }
            }
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
            // 
            if ( kindList.Count == 0 )
            {
                if ( (_searchCond.ExhaustGasSign == string.Empty)
                    && (_searchCond.SeriesModel != string.Empty)
                    && (_searchCond.CategorySignModel == string.Empty) )
                {
                    _searchCond.ExhaustGasSign = carSearchCond.CarModel.SeriesModel;
                    _searchCond.SeriesModel = string.Empty;
                    
                    // -- UPD 2011/04/04 --------------------------->>>
                    //_ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                    //                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                    //                            out equipmentRetWork);
                    
                    if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
                    {
                        _ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                                                    out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                                                    out equipmentRetWork);
                    }
                    // -- UPD 2011/04/04 ---------------------------<<<
                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    // 自由検索型式取得処理
                    //if ( _freeSearchDiv != 0 )
                    if ( _freeSearchDiv != 0 && freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0 )
                    {
                        ArrayList fsKindList;
                        ArrayList fsCarModelRetList;
                        FreeSearchModelSCndtnWork fsSearchCond = CopyToFSCndtnFromCarModelCond( _searchCond );
                        fsSearchCond.FreeSrchMdlFxdNos = freeSrchMdlFxdNo;
                        _IFreeSearchModelSearchDB.GetCarFullModelNo( fsSearchCond, out fsKindList, out fsCarModelRetList );

                        // 車種リスト
                        if ( kindList == null && fsKindList != null && fsKindList.Count > 0 )
                        {
                            kindList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                        {
                            AddKindListDistinct( ref kindList, carKindInfo );
                        }
                        // 型式リスト
                        if ( carModelRetList == null && fsCarModelRetList != null && fsCarModelRetList.Count > 0 )
                        {
                            carModelRetList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                        {
                            carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                        }
                    }
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                    if ( kindList.Count > 0 ) // シリーズモデルでなく排ガス記号で検索成功した時、元の検索条件も更新する。
                    {
                        carSearchCond.CarModel.ExhaustGasSign = _searchCond.ExhaustGasSign;
                        carSearchCond.CarModel.SeriesModel = string.Empty;
                    }
                }
                else if ( _searchCond.CategorySignModel == string.Empty )
                {
                    _searchCond.CategorySignModel = carSearchCond.CarModel.SeriesModel;
                    _searchCond.SeriesModel = carSearchCond.CarModel.ExhaustGasSign;
                    _searchCond.ExhaustGasSign = string.Empty;

                    // -- UPD 2011/04/04 -------------------------------------------->>>
                    //_ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                    //                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                    //                            out equipmentRetWork);

                    if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
                    {
                        _ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                                                    out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                                                    out equipmentRetWork);
                    }
                    // -- UPD 2011/04/04 --------------------------------------------<<<

                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    // 自由検索型式取得処理
                    //if ( _freeSearchDiv != 0 )
                    if ( _freeSearchDiv != 0 && freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0 )
                    {
                        ArrayList fsKindList;
                        ArrayList fsCarModelRetList;
                        FreeSearchModelSCndtnWork fsSearchCond = CopyToFSCndtnFromCarModelCond( _searchCond );
                        fsSearchCond.FreeSrchMdlFxdNos = freeSrchMdlFxdNo;
                        _IFreeSearchModelSearchDB.GetCarFullModelNo( fsSearchCond, out fsKindList, out fsCarModelRetList );

                        // 車種リスト
                        if ( kindList == null && fsKindList != null && fsKindList.Count > 0 )
                        {
                            kindList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                        {
                            AddKindListDistinct( ref kindList, carKindInfo );
                        }
                        // 型式リスト
                        if ( carModelRetList == null && fsCarModelRetList != null && fsCarModelRetList.Count > 0 )
                        {
                            carModelRetList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                        {
                            carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                        }
                    }
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                    if ( kindList.Count > 0 ) // シリーズモデルでなく排ガス記号で検索成功した時、元の検索条件も更新する。
                    {
                        carSearchCond.CarModel.ExhaustGasSign = _searchCond.ExhaustGasSign;
                        carSearchCond.CarModel.SeriesModel = _searchCond.SeriesModel;
                        carSearchCond.CarModel.CategorySign = _searchCond.CategorySignModel;
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/21 ADD
            // 検索で該当がなければ型式手入力とみなす。
            if ( kindList.Count == 0 ) return ret;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/21 ADD

            #region 車種情報[CarKindInfoWork]
            // 車種検索結果をDataTableに格納する
            foreach (CarKindInfoWork wkCarKind in kindList)
            {
                PMKEN01010E.CarKindInfoRow row = _carSearchInfo.CarKindInfo.NewCarKindInfoRow();

                row.MakerCode = wkCarKind.MakerCode;
                row.MakerFullName = wkCarKind.MakerFullName;
                row.MakerHalfName = wkCarKind.MakerHalfName;
                row.ModelCode = wkCarKind.ModelCode;
                row.ModelSubCode = wkCarKind.ModelSubCode;
                row.ModelFullName = wkCarKind.ModelFullName;
                row.ModelHalfName = wkCarKind.ModelHalfName;
                row.EngineModelNm = wkCarKind.EngineModelNm;

                if (kindList.Count == 1)
                {
                    row.SelectionState = true;
                }
                else
                {
                    row.SelectionState = false;
                }
                _carSearchInfo.CarKindInfo.AddCarKindInfoRow(row);
            }
            #endregion

            PMKEN01010E.CarModelUIRow newRow = _carSearchInfo.CarModelUIData.NewCarModelInfoRow();
            newRow.MakerCode = _carSearchInfo.CarKindInfo[0].MakerCode;
            newRow.ModelCode = _carSearchInfo.CarKindInfo[0].ModelCode;
            newRow.ModelSubCode = _carSearchInfo.CarKindInfo[0].ModelSubCode;
            newRow.FullModel = string.Empty;
            newRow.DoorCount = 0;
            newRow.EngineModelNm = _carSearchInfo.CarKindInfo[0].EngineModelNm;

            _carSearchInfo.CarModelUIData.AddCarModelInfoRow(newRow);

            # region 車輌情報[CarModelRetWork]
            if (carModelRetList != null)
            {
                ret = CarModelInfoSet(carModelRetList, _carSearchInfo);
                for (int i = 0; i < _carSearchInfo.CarModelInfo.Count; i++)
                {
                    _carSearchInfo.CarModelInfo[i].SelectionState = true;
                }
                if (_carSearchInfo.CarModelInfo.Count > 0)
                // --- UPD 2013/03/21 ---------->>>>>
                    //_carSearchInfo.CarModelUIData[0].FullModel = _carSearchInfo.CarModelInfo[0].FullModel;
                {
                    _carSearchInfo.CarModelUIData[0].FullModel = _carSearchInfo.CarModelInfo[0].FullModel;

                    _carSearchInfo.CarModelUIData[0].DomesticForeignCode = _carSearchInfo.CarModelInfo[0].DomesticForeignCode;
                    _carSearchInfo.CarModelUIData[0].DomesticForeignName = _carSearchInfo.CarModelInfo[0].DomesticForeignName;
                    _carSearchInfo.CarModelUIData[0].HandleInfoCd = _carSearchInfo.CarModelInfo[0].HandleInfoCd;
                    _carSearchInfo.CarModelUIData[0].HandleInfoNm = _carSearchInfo.CarModelInfo[0].HandleInfoNm;
                }
                // --- UPD 2013/03/21 ----------<<<<<

            }
            # endregion

            # region 類別型式情報[CtgyMdlLnkRetWork]
            // 類別型式情報データーセット
            if (ctgyMdlLnkRetWork != null)
            {
                foreach (CtgyMdlLnkRetWork wkSource in ctgyMdlLnkRetWork)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
                    //if (modelDesignationNo == 0 || categoryNo == 0 ||
                    //    (modelDesignationNo == wkSource.ModelDesignationNo && categoryNo == wkSource.CategoryNo))
                    if ( _searchCond.ModelDesignationNo == 0 || _searchCond.CategoryNo == 0 ||
                        (_searchCond.ModelDesignationNo == wkSource.ModelDesignationNo && _searchCond.CategoryNo == wkSource.CategoryNo) )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD
                    {
                        PMKEN01010E.CtgyMdlLnkInfoRow row = _carSearchInfo.CtgyMdlLnkInfo.NewCtgyMdlLnkInfoRow();

                        row.ModelDesignationNo = wkSource.ModelDesignationNo;
                        row.CategoryNo = wkSource.CategoryNo;
                        row.CarProperNo = wkSource.CarProperNo;
                        row.FullModelFixedNo = wkSource.FullModelFixedNo;

                        _carSearchInfo.CtgyMdlLnkInfo.AddCtgyMdlLnkInfoRow(row);
                    }
                }
            }
            # endregion

            # region 生産年式情報[PrdTypYearRetWork]
            // 生産年式情報データーセット
            if (prdTypYearRetWork != null)
            {
                foreach (PrdTypYearRetWork wkSource in prdTypYearRetWork)
                {
                    PMKEN01010E.PrdTypYearInfoRow row = _carSearchInfo.PrdTypYearInfo.NewPrdTypYearInfoRow();

                    row.MakerCode = wkSource.MakerCode;
                    row.FrameModel = wkSource.FrameModel;
                    row.StProduceFrameNo = wkSource.StProduceFrameNo;
                    row.EdProduceFrameNo = wkSource.EdProduceFrameNo;
                    row.ProduceTypeOfYear = wkSource.ProduceTypeOfYear;

                    _carSearchInfo.PrdTypYearInfo.AddPrdTypYearInfoRow(row);
                }
            }
            # endregion

            # region 型式類別情報[CategoryEquipmentRetWork]
            // --- ADD T.Nishi 2012/07/27 ---------->>>>>
            _equipmentRetWork = equipmentRetWork;  //装備情報選択データ退避
            // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            // 型式類別情報データーセット
            if (categoryEquipmentRetWork != null)
            {
                foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                {
                    PMKEN01010E.CategoryEquipmentInfoRow row = _carSearchInfo.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                    row.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                    row.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                    row.EquipmentMngCode = wkSource.EquipmentMngCode;
                    row.EquipmentMngName = wkSource.EquipmentMngName;
                    row.EquipmentCode = wkSource.EquipmentCode;
                    row.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                    row.TbsPartsCode = wkSource.TbsPartsCode;
                    row.EquipmentName = wkSource.EquipmentName;
                    row.EquipmentShortName = wkSource.EquipmentShortName;
                    row.EquipmentIconCode = wkSource.EquipmentIconCode;
                    row.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                    row.EquipmentUnitName = wkSource.EquipmentUnitName;
                    row.EquipmentCnt = wkSource.EquipmentCnt;
                    row.EquipmentComment1 = wkSource.EquipmentComment1;
                    row.EquipmentComment2 = wkSource.EquipmentComment2;

                    _carSearchInfo.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(row);
                }
            }
            # endregion

            ColorTrimSearch(_carSearchInfo);

            #region 車両装備情報設定
            if (equipmentRetWork != null)
            {
                foreach (CtgryEquipWork wkSource in equipmentRetWork)
                {
                    string filter = string.Format("{0}={1} AND {2}={3}",
                        _carSearchInfo.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName, wkSource.EquipmentCode,
                        _carSearchInfo.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, wkSource.EquipmentGenreCd);
                    PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])_carSearchInfo.CEqpDefDspInfo.Select(filter);
                    if (rows.Length > 0)
                    {
                        rows[0].SelectionState = true;
                    }
                }
            }
            #endregion

            return ret;
        }

        # region ■ 車種検索 ■
        private CarSearchResultReport CarKindInfoSearch(CarSearchCondition _searchCond)
        {
            // -- ADD 2010/05/25 ------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 -------------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;

            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if (_searchCond.MakerCode != 0 && _bigCarOfferDiv == 0 && bigMakerList.Contains(_searchCond.MakerCode))
                return CarSearchResultReport.retFailed;

            //条件抽出クラス
            CarModelCondWork carModelCondWork = new CarModelCondWork();

            // --- ADD T.Nishi 2012/07/27 ---------->>>>>
            _equipmentRetWork = null;  //装備情報選択データ初期化
            // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            //結果クラス
            ArrayList kindList = null;

            ArrayList carModelRetList = null;
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList prdTypYearRetWork = null;
            ArrayList categoryEquipmentRetWork = null;
            ArrayList ctgyMdlLnkRetWork = null;
            ArrayList equipmentRetWork = null;
            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            ArrayList fsKindList = null;
            ArrayList fsCarModelRetList = null;
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            try
            {
                _ICarModelCtlDB = MediationCarModelCtlDB.GetRemoteObject();
                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                if ( _freeSearchDiv != 0 )
                {
                    _IFreeSearchModelSearchDB = MediationFreeSearchModelSearchDB.GetRemoteObject();
                }
                // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                //車種
                if (_searchCond.Type != CarSearchType.csCategory)
                {
                    carModelCondWork.MakerCode = _searchCond.MakerCode;
                    carModelCondWork.ModelCode = _searchCond.ModelCode;
                    carModelCondWork.ModelSubCode = _searchCond.ModelSubCode;
                }
                carModelCondWork.SearchMode = 0; // 0 : 車種情報検索

                switch (_searchCond.Type)
                {
                    case CarSearchType.csCategory:      // 類別検索
                        carModelCondWork.ModelDesignationNo = _searchCond.ModelDesignationNo;
                        carModelCondWork.CategoryNo = _searchCond.CategoryNo;

                        // 類別での車種検索をする
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                        //    out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                        //    out equipmentRetWork );
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                                out equipmentRetWork );
                        }
                        else
                        {
                            // 自由検索型式Only⇒検索結果ArrayList初期化
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            categoryEquipmentRetWork = new ArrayList();
                            equipmentRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // 自由検索型式検索
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarCtgyMdl( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                            {
                                AddKindListDistinct( ref kindList, carKindInfo ); // 車種リスト
                            }
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) ); // 型式リスト
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        break;
                    case CarSearchType.csModel:         // 型式検索
                        carModelCondWork.ExhaustGasSign = _searchCond.CarModel.ExhaustGasSign;
                        carModelCondWork.SeriesModel = _searchCond.CarModel.SeriesModel;
                        carModelCondWork.CategorySignModel = _searchCond.CarModel.CategorySign;
                        // 車両型式(シリーズ/フル)での車種検索をする
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                        }
                        else
                        {
                            // 自由検索型式Only⇒検索結果ArrayList初期化
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            ctgyMdlLnkRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // 自由検索型式検索
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                            {
                                AddKindListDistinct( ref kindList, carKindInfo );
                            }
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        if (kindList.Count == 0)
                        {
                            if ((carModelCondWork.ExhaustGasSign == string.Empty)
                                && (carModelCondWork.SeriesModel != string.Empty)
                                && (carModelCondWork.CategorySignModel == string.Empty))
                            {
                                carModelCondWork.ExhaustGasSign = _searchCond.CarModel.SeriesModel;
                                carModelCondWork.SeriesModel = string.Empty;
                                // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                                //_ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                                if ( !_searchCond.FreeSearchModelOnly )
                                {
                                    _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                                }
                                else
                                {
                                    // 自由検索型式Only⇒検索結果ArrayList初期化
                                    carModelRetList = new ArrayList();
                                    kindList = new ArrayList();
                                    colorCdRetWork = new ArrayList();
                                    trimCdRetWork = new ArrayList();
                                    cEqpDefDspRetWork = new ArrayList();
                                    prdTypYearRetWork = new ArrayList();
                                    ctgyMdlLnkRetWork = new ArrayList();
                                }
                                // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                                // 自由検索型式検索
                                if ( _freeSearchDiv != 0 )
                                {
                                    _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                                    foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                                    {
                                        AddKindListDistinct( ref kindList, carKindInfo );
                                    }
                                    foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                                    {
                                        carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                                    }
                                }
                                // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                                
                                if (kindList.Count > 0) // シリーズモデルでなく排ガス記号で検索成功した時、元の検索条件も更新する。
                                {
                                    _searchCond.CarModel.ExhaustGasSign = carModelCondWork.ExhaustGasSign;
                                    _searchCond.CarModel.SeriesModel = string.Empty;
                                }
                            }
                            else if (carModelCondWork.CategorySignModel == string.Empty)
                            {
                                carModelCondWork.CategorySignModel = carModelCondWork.SeriesModel;
                                carModelCondWork.SeriesModel = carModelCondWork.ExhaustGasSign;
                                carModelCondWork.ExhaustGasSign = string.Empty;
                                // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                                //_ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                                if ( !_searchCond.FreeSearchModelOnly )
                                {
                                    _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                                }
                                else
                                {
                                    // 自由検索型式Only⇒検索結果ArrayList初期化
                                    carModelRetList = new ArrayList();
                                    kindList = new ArrayList();
                                    colorCdRetWork = new ArrayList();
                                    trimCdRetWork = new ArrayList();
                                    cEqpDefDspRetWork = new ArrayList();
                                    prdTypYearRetWork = new ArrayList();
                                    ctgyMdlLnkRetWork = new ArrayList();
                                }
                                // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                                // 自由検索型式検索
                                if ( _freeSearchDiv != 0 )
                                {
                                    _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                                    foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                                    {
                                        AddKindListDistinct( ref kindList, carKindInfo );
                                    }
                                    foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                                    {
                                        carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                                    }
                                }
                                // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                                
                                if (kindList.Count > 0) // シリーズモデルでなく排ガス記号で検索成功した時、元の検索条件も更新する。
                                {
                                    _searchCond.CarModel.ExhaustGasSign = carModelCondWork.ExhaustGasSign;
                                    _searchCond.CarModel.SeriesModel = carModelCondWork.SeriesModel;
                                    _searchCond.CarModel.CategorySign = carModelCondWork.CategorySignModel;
                                }
                            }

                        }
                        break;
                    case CarSearchType.csEngineModel:   // エンジン型式検索
                        carModelCondWork.EngineModelNm = _searchCond.EngineModel.ModelNm;
                        // エンジン型式での車種検索をする
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarEngine( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                        }
                        else
                        {
                            // 自由検索型式Only⇒検索結果ArrayList初期化
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // 自由検索型式検索
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarEngine( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                            {
                                AddKindListDistinct( ref kindList, carKindInfo ); // 車種リスト
                            }
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) ); // 型式リスト
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        
                        break;
                    case CarSearchType.csPlate:         // プレート検索
                        carModelCondWork.ModelPlate = _searchCond.ModelPlate;
                        // プレート番号での車種検索をする
                        _ICarModelCtlDB.GetCarPlate(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);
                        break;
                }

                //switch (kindList.Count)
                //{
                //    case 0:
                //        ret = CarSearchResultReport.retFailed;
                //        return ret;
                //    case 1:
                //        if (carModelRetList.Count == 1)
                //        {
                //            ret = CarSearchResultReport.retSingleCarModel;
                //        }
                //        else
                //        {
                //            ret = CarSearchResultReport.retMultipleCarModel;
                //        }
                //        break;
                //    default:
                //        ret = CarSearchResultReport.retMultipleCarKind;
                //        break;
                //}

                #region 車種情報[CarKindInfoWork]
                // 車種検索結果をDataTableに格納する
                foreach (CarKindInfoWork wkCarKind in kindList)
                {
                    if (_bigCarOfferDiv == 0 && bigMakerList.Contains(wkCarKind.MakerCode)) // 大型契約なしで大型メーカーは登録しない。
                        continue;

                    PMKEN01010E.CarKindInfoRow row = dataSet.CarKindInfo.NewCarKindInfoRow();

                    row.MakerCode = wkCarKind.MakerCode;
                    row.MakerFullName = wkCarKind.MakerFullName;
                    row.MakerHalfName = wkCarKind.MakerHalfName;
                    row.ModelCode = wkCarKind.ModelCode;
                    row.ModelSubCode = wkCarKind.ModelSubCode;
                    row.ModelFullName = wkCarKind.ModelFullName;
                    row.ModelHalfName = wkCarKind.ModelHalfName;
                    row.EngineModelNm = wkCarKind.EngineModelNm;

                    dataSet.CarKindInfo.AddCarKindInfoRow(row);
                }
                if (dataSet.CarKindInfo.Count == 0)
                {
                    ret = CarSearchResultReport.retFailed;
                    return ret;
                }
                if (dataSet.CarKindInfo.Count == 1)
                {
                    dataSet.CarKindInfo[0].SelectionState = true;
                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    if (!_searchCond.FreeSearchModelOnly)
                    {
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        #region [ 大型フィルタリングにより車種が1個になった場合型式情報補足処理を行う ]
                        if ( kindList.Count != 1 ) // 車種が1個でないのに車種テーブルには1個しかないのは大型フィルタリングのためなので
                        { // 必要な型式の情報がとれなかったはず。→　型式情報取得処理をここで行う。
                            //車種
                            carModelCondWork.MakerCode = dataSet.CarKindInfo[0].MakerCode;
                            carModelCondWork.ModelCode = dataSet.CarKindInfo[0].ModelCode;
                            carModelCondWork.ModelSubCode = dataSet.CarKindInfo[0].ModelSubCode;
                            carModelCondWork.SearchMode = 1; // 1 : 型式情報検索

                            switch ( _searchCond.Type )
                            {
                                case CarSearchType.csCategory:      // 類別検索
                                    carModelCondWork.ModelDesignationNo = _searchCond.ModelDesignationNo;
                                    carModelCondWork.CategoryNo = _searchCond.CategoryNo;
                                    // 類別での車種検索をする
                                    _ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                        out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                                        out equipmentRetWork );
                                    break;
                                case CarSearchType.csModel:         // 型式検索
                                    carModelCondWork.ExhaustGasSign = _searchCond.CarModel.ExhaustGasSign;
                                    carModelCondWork.SeriesModel = _searchCond.CarModel.SeriesModel;
                                    carModelCondWork.CategorySignModel = _searchCond.CarModel.CategorySign;
                                    // 車両型式(シリーズ/フル)での車種検索をする
                                    _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                                    break;
                                case CarSearchType.csEngineModel:   // エンジン型式検索
                                    carModelCondWork.EngineModelNm = dataSet.CarKindInfo[0].EngineModelNm;
                                    // エンジン型式での車種検索をする
                                    _ICarModelCtlDB.GetCarEngine( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                                    break;
                                case CarSearchType.csPlate:         // プレート検索
                                    carModelCondWork.ModelPlate = _searchCond.ModelPlate;
                                    // プレート番号での車種検索をする
                                    _ICarModelCtlDB.GetCarPlate( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                                    break;
                            }
                            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                            // 自由検索型式取得分をマージする(kindListとcarModelRetListがout指定で上書きされてしまう為)
                            if ( _freeSearchDiv != 0 )
                            {
                                // 車種リスト
                                if ( fsKindList != null )
                                {
                                    foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                                    {
                                        AddKindListDistinct( ref kindList, carKindInfo );
                                    }
                                }
                                // 型式リスト
                                if ( fsCarModelRetList != null )
                                {
                                    foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                                    {
                                        carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                                    }
                                }
                            }
                            // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        }
                        #endregion
                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    }
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                    if (carModelRetList.Count == 1)
                    {
                        ret = CarSearchResultReport.retSingleCarModel;
                    }
                    else
                    {
                        ret = CarSearchResultReport.retMultipleCarModel;
                    }
                }
                #endregion

                # region 入力情報（検索条件）退避
                PMKEN01010E.CarModelUIRow newRow = dataSet.CarModelUIData.NewCarModelInfoRow();
                newRow.MakerCode = _searchCond.MakerCode;
                newRow.ModelCode = _searchCond.ModelCode;
                newRow.ModelSubCode = _searchCond.ModelSubCode;
                newRow.FullModel = _searchCond.CarModel.FullModel;
                newRow.EngineModelNm = _searchCond.EngineModel.ModelNm;
                newRow.DoorCount = 0;

                dataSet.CarModelUIData.AddCarModelInfoRow(newRow);
                # endregion

                if (dataSet.CarKindInfo.Count > 1) // 車種が1個超えるなら型式情報などは設定しない。
                {
                    ret = CarSearchResultReport.retMultipleCarKind;
                    return ret;
                }

                # region 車輌情報[CarModelRetWork]
                if (carModelRetList != null)
                {
                    ret = CarModelInfoSet(carModelRetList);
                }
                # endregion

                # region 類別型式情報[CtgyMdlLnkRetWork]
                // 類別型式情報データーセット
                if (ctgyMdlLnkRetWork != null)
                {
                    foreach (CtgyMdlLnkRetWork wkSource in ctgyMdlLnkRetWork)
                    {
                        PMKEN01010E.CtgyMdlLnkInfoRow row = dataSet.CtgyMdlLnkInfo.NewCtgyMdlLnkInfoRow();

                        row.ModelDesignationNo = wkSource.ModelDesignationNo;
                        row.CategoryNo = wkSource.CategoryNo;
                        row.CarProperNo = wkSource.CarProperNo;
                        row.FullModelFixedNo = wkSource.FullModelFixedNo;

                        dataSet.CtgyMdlLnkInfo.AddCtgyMdlLnkInfoRow(row);
                    }
                }
                # endregion

                # region 生産年式情報[PrdTypYearRetWork]
                // 生産年式情報データーセット
                if (prdTypYearRetWork != null)
                {
                    foreach (PrdTypYearRetWork wkSource in prdTypYearRetWork)
                    {
                        PMKEN01010E.PrdTypYearInfoRow row = dataSet.PrdTypYearInfo.NewPrdTypYearInfoRow();

                        row.MakerCode = wkSource.MakerCode;
                        row.FrameModel = wkSource.FrameModel;
                        row.StProduceFrameNo = wkSource.StProduceFrameNo;
                        row.EdProduceFrameNo = wkSource.EdProduceFrameNo;
                        row.ProduceTypeOfYear = wkSource.ProduceTypeOfYear;

                        dataSet.PrdTypYearInfo.AddPrdTypYearInfoRow(row);
                    }
                }
                # endregion

                # region 型式類別情報[CategoryEquipmentRetWork]
                // 型式類別情報データーセット
                if (categoryEquipmentRetWork != null)
                {
                    foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow row = dataSet.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                        row.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                        row.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                        row.EquipmentMngCode = wkSource.EquipmentMngCode;
                        row.EquipmentMngName = wkSource.EquipmentMngName;
                        row.EquipmentCode = wkSource.EquipmentCode;
                        row.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                        row.TbsPartsCode = wkSource.TbsPartsCode;
                        row.EquipmentName = wkSource.EquipmentName;
                        row.EquipmentShortName = wkSource.EquipmentShortName;
                        row.EquipmentIconCode = wkSource.EquipmentIconCode;
                        row.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                        row.EquipmentUnitName = wkSource.EquipmentUnitName;
                        row.EquipmentCnt = wkSource.EquipmentCnt;
                        row.EquipmentComment1 = wkSource.EquipmentComment1;
                        row.EquipmentComment2 = wkSource.EquipmentComment2;

                        dataSet.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(row);
                    }
                }
                # endregion

                // --- ADD T.Nishi 2012/07/27 ---------->>>>>
                _equipmentRetWork = equipmentRetWork;  //装備情報選択データ退避
                // --- ADD T.Nishi 2012/07/27 ----------<<<<<
                if (ret == CarSearchResultReport.retSingleCarModel)
                {
                    //ColorTrimSearch();
                    if (carModelRetList.Count > 1) // 複数の型式が検索されたが、圧縮された場合はカラー・トリム情報取得処理を行う
                    {
                        ColorTrimSearch();
                    }
                    else
                    {
                        ColorTrimSet(colorCdRetWork, trimCdRetWork, cEqpDefDspRetWork, dataSet);
                        SetSummarizedData(dataSet);
                    }
                    #region 車両装備情報設定
                    if (equipmentRetWork != null)
                    {
                        foreach (CtgryEquipWork wkSource in equipmentRetWork)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}",
                                dataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName, wkSource.EquipmentCode,
                                dataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, wkSource.EquipmentGenreCd);
                            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])dataSet.CEqpDefDspInfo.Select(filter);
                            if (rows.Length > 0)
                            {
                                rows[0].SelectionState = true;
                            }
                        }
                    }
                    #endregion
                }

            }
            catch
            {
                ret = CarSearchResultReport.retError;
            }
            finally
            {
                // 全て DataTable に退避してあるのでクリアする
            }
            return ret;
        }
        # endregion

        #region ■ 型式検索 ■
        private CarSearchResultReport CarModelInfoSearch(CarSearchCondition _searchCond, ref PMKEN01010E _carSearchInfo)
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;

            //条件抽出クラス
            CarModelCondWork carModelCondWork = new CarModelCondWork();

            //結果クラス
            ArrayList carModelRetList = null;
            ArrayList kindList = null;
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList prdTypYearRetWork = null;
            ArrayList categoryEquipmentRetWork = null;
            ArrayList ctgyMdlLnkRetWork = null;
            ArrayList equipmentRetWork = null;
            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            ArrayList fsKindList;
            ArrayList fsCarModelRetList;
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            // 選択状態となっている最初のデータのメーカー・車種・車種サブコードを設定する
            PMKEN01010E.CarKindInfoRow[] rowCarKindInfo = _carSearchInfo.CarKindInfo.Select("SelectionState = True") as PMKEN01010E.CarKindInfoRow[];
            # region ■ 車両検索 ■
            try
            {
                //車種
                carModelCondWork.MakerCode = rowCarKindInfo[0].MakerCode;
                carModelCondWork.ModelCode = rowCarKindInfo[0].ModelCode;
                carModelCondWork.ModelSubCode = rowCarKindInfo[0].ModelSubCode;
                carModelCondWork.SearchMode = 1; // 1 : 型式情報検索

                switch (_searchCond.Type)
                {
                    case CarSearchType.csCategory:      // 類別検索
                        carModelCondWork.ModelDesignationNo = _searchCond.ModelDesignationNo;
                        carModelCondWork.CategoryNo = _searchCond.CategoryNo;
                        // 類別での車種検索をする
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarCtgyMdl(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                        //    out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                        //    out equipmentRetWork);
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                                out equipmentRetWork );
                        }
                        else
                        {
                            // 自由検索ONLY⇒検索結果を初期化
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            categoryEquipmentRetWork = new ArrayList();
                            equipmentRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // 自由検索型式取得
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarCtgyMdl( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        break;
                    case CarSearchType.csModel:         // 型式検索
                        carModelCondWork.ExhaustGasSign = _searchCond.CarModel.ExhaustGasSign;
                        carModelCondWork.SeriesModel = _searchCond.CarModel.SeriesModel;
                        carModelCondWork.CategorySignModel = _searchCond.CarModel.CategorySign;
                        // 車両型式(シリーズ/フル)での車種検索をする
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                        }
                        else
                        {
                            // 自由検索ONLY⇒検索結果を初期化
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            ctgyMdlLnkRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        //if ((kindList.Count == 0)
                        //    && (carModelCondWork.ExhaustGasSign == "")
                        //    && (carModelCondWork.SeriesModel != "")
                        //    && (carModelCondWork.CategorySignModel == ""))
                        //{
                        //    carModelCondWork.ExhaustGasSign = _searchCond.CarModel.SeriesModel;
                        //    carModelCondWork.SeriesModel = "";
                        //    carModelCondWork.CategorySignModel = "";
                        //    _ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                        //}

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // 自由検索型式取得
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        break;
                    case CarSearchType.csEngineModel:   // エンジン型式検索
                        carModelCondWork.EngineModelNm = rowCarKindInfo[0].EngineModelNm;
                        // エンジン型式での車種検索をする
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarEngine(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarEngine( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                        }
                        else
                        {
                            // 自由検索ONLY⇒検索結果を初期化
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // 自由検索型式取得
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarEngine( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        
                        break;
                    case CarSearchType.csPlate:         // プレート検索
                        carModelCondWork.ModelPlate = _searchCond.ModelPlate;
                        // プレート番号での車種検索をする
                        _ICarModelCtlDB.GetCarPlate(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);
                        break;
                }

                # region ■ データセット ■

                # region 車種情報クラス
                if (carModelRetList.Count == 1)
                {
                    ret = CarSearchResultReport.retSingleCarModel;
                }
                else if (carModelRetList.Count > 1)
                {
                    ret = CarSearchResultReport.retMultipleCarModel;
                }
                # region 入力情報（検索条件）退避
                PMKEN01010E.CarModelUIRow newRow = dataSet.CarModelUIData.NewCarModelInfoRow();
                newRow.MakerCode = _carSearchInfo.CarModelUIData[0].MakerCode;
                newRow.ModelCode = _carSearchInfo.CarModelUIData[0].ModelCode;
                newRow.ModelSubCode = _carSearchInfo.CarModelUIData[0].ModelSubCode;
                newRow.FullModel = _carSearchInfo.CarModelUIData[0].FullModel;
                newRow.EngineModelNm = _carSearchInfo.CarModelUIData[0].EngineModelNm;
                newRow.DoorCount = _carSearchInfo.CarModelUIData[0].DoorCount;
                newRow.ModelDesignationNo = _carSearchInfo.CarModelUIData[0].ModelDesignationNo;
                newRow.CategoryNo = _carSearchInfo.CarModelUIData[0].CategoryNo;

                dataSet.CarModelUIData.AddCarModelInfoRow(newRow);
                # endregion

                # endregion

                # region 車輌情報
                if (carModelRetList != null)
                {
                    ret = CarModelInfoSet(carModelRetList);
                }
                # endregion

                # region 類別型式情報
                // 類別型式情報データーセット
                if (ctgyMdlLnkRetWork != null)
                {
                    foreach (CtgyMdlLnkRetWork wkSource in ctgyMdlLnkRetWork)
                    {
                        PMKEN01010E.CtgyMdlLnkInfoRow row = dataSet.CtgyMdlLnkInfo.NewCtgyMdlLnkInfoRow();

                        row.ModelDesignationNo = wkSource.ModelDesignationNo;
                        row.CategoryNo = wkSource.CategoryNo;
                        row.CarProperNo = wkSource.CarProperNo;
                        row.FullModelFixedNo = wkSource.FullModelFixedNo;

                        dataSet.CtgyMdlLnkInfo.AddCtgyMdlLnkInfoRow(row);
                    }
                }
                # endregion

                # region 生産年式情報
                // 生産年式情報データーセット
                if (prdTypYearRetWork != null)
                {
                    foreach (PrdTypYearRetWork wkSource in prdTypYearRetWork)
                    {
                        PMKEN01010E.PrdTypYearInfoRow row = dataSet.PrdTypYearInfo.NewPrdTypYearInfoRow();

                        row.MakerCode = wkSource.MakerCode;
                        row.FrameModel = wkSource.FrameModel;
                        row.StProduceFrameNo = wkSource.StProduceFrameNo;
                        row.EdProduceFrameNo = wkSource.EdProduceFrameNo;
                        row.ProduceTypeOfYear = wkSource.ProduceTypeOfYear;

                        dataSet.PrdTypYearInfo.AddPrdTypYearInfoRow(row);
                    }
                }
                # endregion

                # region 型式類別情報
                // 型式類別情報データーセット
                if (categoryEquipmentRetWork != null)
                {
                    foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow row = dataSet.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                        row.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                        row.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                        row.EquipmentMngCode = wkSource.EquipmentMngCode;
                        row.EquipmentMngName = wkSource.EquipmentMngName;
                        row.EquipmentCode = wkSource.EquipmentCode;
                        row.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                        row.TbsPartsCode = wkSource.TbsPartsCode;
                        row.EquipmentName = wkSource.EquipmentName;
                        row.EquipmentShortName = wkSource.EquipmentShortName;
                        row.EquipmentIconCode = wkSource.EquipmentIconCode;
                        row.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                        row.EquipmentUnitName = wkSource.EquipmentUnitName;
                        row.EquipmentCnt = wkSource.EquipmentCnt;
                        row.EquipmentComment1 = wkSource.EquipmentComment1;
                        row.EquipmentComment2 = wkSource.EquipmentComment2;

                        dataSet.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(row);
                    }
                }
                # endregion

                if (ret == CarSearchResultReport.retSingleCarModel)
                {
                    //ColorTrimSearch();
                    ColorTrimSet(colorCdRetWork, trimCdRetWork, cEqpDefDspRetWork, dataSet);
                    SetSummarizedData(dataSet);
                }
                # endregion
            }
            catch
            {
                ret = CarSearchResultReport.retError;
            }
            finally
            {
            }
            return ret;
            # endregion
        }
        #endregion

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        # region ■ 自由検索関連 ■

        # region [型変換処理]
        /// <summary>
        /// 提供型式検索.検索条件⇒自由検索型式検索.検索条件 変換
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <returns></returns>
        private FreeSearchModelSCndtnWork CopyToFSCndtnFromCarModelCond( CarModelCondWork carModelCondWork )
        {
            FreeSearchModelSCndtnWork fsModelSCndtn = new FreeSearchModelSCndtnWork();

            fsModelSCndtn.CategoryNo = carModelCondWork.CategoryNo;
            fsModelSCndtn.CategorySignModel = carModelCondWork.CategorySignModel;
            fsModelSCndtn.EngineModelNm = carModelCondWork.EngineModelNm;
            fsModelSCndtn.ExhaustGasSign = carModelCondWork.ExhaustGasSign;
            //fsModelSCndtn.FullModelFixedNos = carModelCondWork.FullModelFixedNos;
            fsModelSCndtn.MakerCode = carModelCondWork.MakerCode;
            fsModelSCndtn.ModelCode = carModelCondWork.ModelCode;
            fsModelSCndtn.ModelDesignationNo = carModelCondWork.ModelDesignationNo;
            fsModelSCndtn.ModelPlate = carModelCondWork.ModelPlate;
            fsModelSCndtn.ModelSubCode = carModelCondWork.ModelSubCode;
            fsModelSCndtn.SearchMode = carModelCondWork.SearchMode;
            fsModelSCndtn.SeriesModel = carModelCondWork.SeriesModel;

            return fsModelSCndtn;
        }
        /// <summary>
        /// 自由検索型式検索.車種情報⇒提供型式検索.車種情報 変換
        /// </summary>
        /// <param name="carKindInfo"></param>
        /// <returns></returns>
        private CarKindInfoWork CopyToCarKindInfoFromFSCarKindInfo( FreeSearchModelSCarKindInfoWork carKindInfo )
        {
            CarKindInfoWork retWork = new CarKindInfoWork();

            retWork.EngineModelNm = carKindInfo.EngineModelNm;
            retWork.MakerCode = carKindInfo.MakerCode;
            retWork.MakerFullName = carKindInfo.MakerFullName;
            retWork.MakerHalfName = carKindInfo.MakerHalfName;
            retWork.ModelCode = carKindInfo.ModelCode;
            retWork.ModelFullName = carKindInfo.ModelFullName;
            retWork.ModelHalfName = carKindInfo.ModelHalfName;
            retWork.ModelSubCode = carKindInfo.ModelSubCode;

            return retWork;
        }
        /// <summary>
        /// 自由検索型式検索.型式情報⇒提供型式検索.型式情報 変換
        /// </summary>
        /// <param name="carModelRet"></param>
        /// <returns></returns>
        private CarModelRetWork CopyToCarModelRetFromFSCarModelRet( FreeSearchModelSRetWork carModelRet )
        {
            CarModelRetWorkEx retWork = new CarModelRetWorkEx();

            retWork.MakerCode = carModelRet.MakerCode;
            retWork.MakerFullName = carModelRet.MakerFullName;
            retWork.MakerHalfName = carModelRet.MakerHalfName;
            retWork.ModelCode = carModelRet.ModelCode;
            retWork.ModelSubCode = carModelRet.ModelSubCode;
            retWork.ModelFullName = carModelRet.ModelFullName;
            retWork.ModelHalfName = carModelRet.ModelHalfName;
            retWork.SystematicCode = carModelRet.SystematicCode;
            retWork.SystematicName = carModelRet.SystematicName;
            retWork.ProduceTypeOfYearCd = carModelRet.ProduceTypeOfYearCd;
            retWork.ProduceTypeOfYearNm = carModelRet.ProduceTypeOfYearNm;
            retWork.StProduceTypeOfYear = carModelRet.StProduceTypeOfYear;
            retWork.EdProduceTypeOfYear = carModelRet.EdProduceTypeOfYear;
            retWork.DoorCount = carModelRet.DoorCount;
            retWork.BodyNameCode = carModelRet.BodyNameCode;
            retWork.BodyName = carModelRet.BodyName;
            retWork.CarProperNo = carModelRet.CarProperNo;
            retWork.FullModelFixedNo = carModelRet.FullModelFixedNo;
            retWork.ExhaustGasSign = carModelRet.ExhaustGasSign;
            retWork.SeriesModel = carModelRet.SeriesModel;
            retWork.CategorySignModel = carModelRet.CategorySignModel;
            retWork.FullModel = carModelRet.FullModel;
            retWork.FrameModel = carModelRet.FrameModel;
            retWork.StProduceFrameNo = carModelRet.StProduceFrameNo;
            retWork.EdProduceFrameNo = carModelRet.EdProduceFrameNo;
            retWork.ModelGradeNm = carModelRet.ModelGradeNm;
            retWork.EngineModelNm = carModelRet.EngineModelNm;
            retWork.EngineDisplaceNm = carModelRet.EngineDisplaceNm;
            retWork.EDivNm = carModelRet.EDivNm;
            retWork.TransmissionNm = carModelRet.TransmissionNm;
            retWork.WheelDriveMethodNm = carModelRet.WheelDriveMethodNm;
            retWork.ShiftNm = carModelRet.ShiftNm;
            retWork.AddiCarSpec1 = carModelRet.AddiCarSpec1;
            retWork.AddiCarSpec2 = carModelRet.AddiCarSpec2;
            retWork.AddiCarSpec3 = carModelRet.AddiCarSpec3;
            retWork.AddiCarSpec4 = carModelRet.AddiCarSpec4;
            retWork.AddiCarSpec5 = carModelRet.AddiCarSpec5;
            retWork.AddiCarSpec6 = carModelRet.AddiCarSpec6;
            retWork.AddiCarSpecTitle1 = carModelRet.AddiCarSpecTitle1;
            retWork.AddiCarSpecTitle2 = carModelRet.AddiCarSpecTitle2;
            retWork.AddiCarSpecTitle3 = carModelRet.AddiCarSpecTitle3;
            retWork.AddiCarSpecTitle4 = carModelRet.AddiCarSpecTitle4;
            retWork.AddiCarSpecTitle5 = carModelRet.AddiCarSpecTitle5;
            retWork.AddiCarSpecTitle6 = carModelRet.AddiCarSpecTitle6;
            retWork.RelevanceModel = carModelRet.RelevanceModel;
            retWork.SubCarNmCd = carModelRet.SubCarNmCd;
            retWork.ModelGradeSname = carModelRet.ModelGradeSname;
            retWork.BlockIllustrationCd = carModelRet.BlockIllustrationCd;
            retWork.ThreeDIllustNo = carModelRet.ThreeDIllustNo;
            retWork.PartsDataOfferFlag = carModelRet.PartsDataOfferFlag;

            retWork.FreeSrchMdlFxdNo = carModelRet.FreeSrchMdlFxdNo;

            if ( retWork.StProduceTypeOfYear < 101 ) retWork.StProduceTypeOfYear = 101; // 0001年01月
            if ( retWork.EdProduceTypeOfYear < 101 ) retWork.EdProduceTypeOfYear = 101; // 0001年01月

            return retWork;
        }
        # endregion

        # region [抽出結果リスト操作]
        /// <summary>
        /// 車種リストに「重複しない場合のみ」追加する
        /// </summary>
        /// <param name="kindList"></param>
        /// <param name="carKindInfo"></param>
        private void AddKindListDistinct( ref ArrayList kindList, FreeSearchModelSCarKindInfoWork carKindInfo )
        {
            // 重複チェック
            foreach ( CarKindInfoWork kind in kindList )
            {
                if ( kind.MakerCode == carKindInfo.MakerCode &&
                     kind.ModelCode == carKindInfo.ModelCode &&
                     kind.ModelSubCode == carKindInfo.ModelSubCode )
                {
                    // リスト内に既に存在する車種
                    return;
                }
            }

            // リストに追加
            kindList.Add( CopyToCarKindInfoFromFSCarKindInfo( carKindInfo ) );
        }
        # endregion

        # endregion
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<


        /// <summary>
        /// カラー・トリム設定処理
        /// </summary>
        /// <param name="colorCdRetWork">カラー</param>
        /// <param name="trimCdRetWork">トリム</param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="_carSearchInfo"></param>
        private void ColorTrimSet(ArrayList colorCdRetWork, ArrayList trimCdRetWork, ArrayList cEqpDefDspRetWork, PMKEN01010E _carSearchInfo)
        {
            # region カラー情報
            // カラー情報データーセット
            if (colorCdRetWork != null)
            {
                foreach (Broadleaf.Application.Remoting.ParamData.ColorCdRetWork wkSource in colorCdRetWork)
                {
                    PMKEN01010E.ColorCdInfoRow colorCdRow = _carSearchInfo.ColorCdInfo.NewColorCdInfoRow();
                    colorCdRow.MakerCode = wkSource.MakerCode;
                    colorCdRow.ModelCode = wkSource.ModelCode;
                    colorCdRow.ModelSubCode = wkSource.ModelSubCode;
                    //colorCdRow.SystematicCode = wkSource.SystematicCode;
                    //colorCdRow.ProduceTypeOfYearCd = wkSource.ProduceTypeOfYearCd;
                    colorCdRow.ColorCode = wkSource.ColorCode;
                    colorCdRow.ColorName1 = wkSource.ColorName1;
                    //colorCdRow.ColorCdDupDerivedNo = wkSource.ColorCdDupDerivedNo; // 不要の可能性は？
                    _carSearchInfo.ColorCdInfo.AddColorCdInfoRow(colorCdRow);
                }
            }
            # endregion

            # region トリム情報
            // トリム情報データーセット
            if (trimCdRetWork != null)
            {
                foreach (Broadleaf.Application.Remoting.ParamData.TrimCdRetWork wkSource in trimCdRetWork)
                {
                    PMKEN01010E.TrimCdInfoRow trimCdRow = _carSearchInfo.TrimCdInfo.NewTrimCdInfoRow();
                    trimCdRow.MakerCode = wkSource.MakerCode;
                    trimCdRow.ModelCode = wkSource.ModelCode;
                    trimCdRow.ModelSubCode = wkSource.ModelSubCode;
                    //trimCdRow.SystematicCode = wkSource.SystematicCode;
                    //trimCdRow.ProduceTypeOfYearCd = wkSource.ProduceTypeOfYearCd;
                    trimCdRow.TrimCode = wkSource.TrimCode;
                    trimCdRow.TrimName = wkSource.TrimName;

                    _carSearchInfo.TrimCdInfo.AddTrimCdInfoRow(trimCdRow);
                }
            }
            # endregion

            # region 装備情報
            // 装備情報データーセット
            if (cEqpDefDspRetWork != null)
            {
                foreach (CEqpDefDspRetWork wkSource in cEqpDefDspRetWork)
                {
                    PMKEN01010E.CEqpDefDspInfoRow cEqpRow = _carSearchInfo.CEqpDefDspInfo.NewCEqpDefDspInfoRow();
                    cEqpRow.MakerCode = wkSource.MakerCode;
                    cEqpRow.ModelCode = wkSource.ModelCode;
                    cEqpRow.ModelSubCode = wkSource.ModelSubCode;
                    cEqpRow.SystematicCode = wkSource.SystematicCode;
                    cEqpRow.EquipmentCode = wkSource.EquipmentCode;
                    cEqpRow.EquipmentName = wkSource.EquipmentName;
                    cEqpRow.EquipmentShortName = wkSource.EquipmentShortName;
                    cEqpRow.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                    cEqpRow.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                    cEqpRow.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                    cEqpRow.EquipmentIconCode = wkSource.EquipmentIconCode;

                    _carSearchInfo.CEqpDefDspInfo.AddCEqpDefDspInfoRow(cEqpRow);
                }
            }
            # endregion
        }

        /// <summary>
        /// 選択UIで選択された型式情報の圧縮処理
        /// </summary>
        /// <param name="_carSearchInfo"></param>
        private void SetSummarizedData(PMKEN01010E _carSearchInfo)
        {
            bool flgExhaustGasSign = true;
            bool flgSeriesModel = true;
            PMKEN01010E.CarModelInfoRow[] rowCarModelInfos = _carSearchInfo.CarModelInfo.Select("SelectionState = True") as PMKEN01010E.CarModelInfoRow[];

            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            if ( rowCarModelInfos.Length == 0 ) return;
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            PMKEN01010E.CarModelInfoRow rowCarInfoSum = _carSearchInfo.CarModelInfoSummarized.AddCarModelInfoRowCopy(rowCarModelInfos[0]);
            for (int i = 1; i < rowCarModelInfos.Length; i++)
            {
                PMKEN01010E.CarModelInfoRow rowToComp = rowCarModelInfos[i];
                if (rowCarInfoSum.ProduceTypeOfYearCd != rowToComp.ProduceTypeOfYearCd)
                    rowCarInfoSum.ProduceTypeOfYearCd = 0;
                if (rowCarInfoSum.StProduceTypeOfYear > rowToComp.StProduceTypeOfYear)    // 開始生産年式
                    rowCarInfoSum.StProduceTypeOfYear = rowToComp.StProduceTypeOfYear;
                if (rowCarInfoSum.EdProduceTypeOfYear < rowToComp.EdProduceTypeOfYear)    // 終了生産年式
                    rowCarInfoSum.EdProduceTypeOfYear = rowToComp.EdProduceTypeOfYear;
                if (rowCarInfoSum.StProduceFrameNo > rowToComp.StProduceFrameNo)          // 開始車台番号
                    rowCarInfoSum.StProduceFrameNo = rowToComp.StProduceFrameNo;
                if (rowCarInfoSum.EdProduceFrameNo < rowToComp.EdProduceFrameNo)          // 終了車台番号
                    rowCarInfoSum.EdProduceFrameNo = rowToComp.EdProduceFrameNo;
                if (rowCarInfoSum.ModelGradeNm != rowToComp.ModelGradeNm)                 // 型式グレード名称
                    rowCarInfoSum.ModelGradeNm = string.Empty;
                if (rowCarInfoSum.BodyName != rowToComp.BodyName)                         // ボディー名称
                    rowCarInfoSum.BodyName = string.Empty;
                if (rowCarInfoSum.DoorCount != rowToComp.DoorCount)                       // ドア数
                    rowCarInfoSum.DoorCount = 0;
                if (rowCarInfoSum.EngineModelNm != rowToComp.EngineModelNm)               // エンジン型式名称
                    rowCarInfoSum.EngineModelNm = string.Empty;
                if (rowCarInfoSum.EngineDisplaceNm != rowToComp.EngineDisplaceNm)         // 排気量名称
                    rowCarInfoSum.EngineDisplaceNm = string.Empty;
                if (rowCarInfoSum.EDivNm != rowToComp.EDivNm)                             // E区分名称
                    rowCarInfoSum.EDivNm = string.Empty;
                if (rowCarInfoSum.TransmissionNm != rowToComp.TransmissionNm)             // ミッション名称
                    rowCarInfoSum.TransmissionNm = string.Empty;
                if (rowCarInfoSum.WheelDriveMethodNm != rowToComp.WheelDriveMethodNm)     // 駆動方式名称
                    rowCarInfoSum.WheelDriveMethodNm = string.Empty;
                if (rowCarInfoSum.ShiftNm != rowToComp.ShiftNm)                           // シフト名称
                    rowCarInfoSum.ShiftNm = string.Empty;
                // 2010/01/04 Add >>>
                if (rowCarInfoSum.FrameModel != rowToComp.FrameModel)                     // 車台型式
                    rowCarInfoSum.FrameModel = string.Empty;
                // 2010/01/04 Add <<<
                if (rowCarInfoSum.SystematicCode != rowToComp.SystematicCode)
                    rowCarInfoSum.SystematicCode = 0;
                if (rowCarInfoSum.FullModel != rowToComp.FullModel)                       // 型式
                {   // 型式が違う時、シリーズモデルの共通部を表示するため、以下の処理を行う。
                    rowCarInfoSum.FullModel = string.Empty;

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //int j;
                    //string compFullModel = _carSearchInfo.CarModelUIData[0].FullModel;
                    //for (j = rowCarInfoSum.SeriesModel.Length; j > 0; j--)
                    //{
                    //    if (rowToComp.SeriesModel.Contains(rowCarInfoSum.SeriesModel.Substring(0, j)))
                    //    {
                    //        rowCarInfoSum.SeriesModel = rowCarInfoSum.SeriesModel.Substring(0, j);
                    //        if (j < rowToComp.SeriesModel.Length)
                    //            flgSeriesModel = false; // シリーズ型式の相違あり
                    //        break;
                    //    }
                    //}
                    //if (j == 0)
                    //    rowCarInfoSum.SeriesModel = string.Empty;

                    // シリーズ型式、型式(類別記号)は、両方を１文字列として圧縮する
                    int j;
                    string compFullModel = _carSearchInfo.CarModelUIData[0].FullModel;
                    for (j = rowCarInfoSum.SeriesModel.Length; j > 0; j--)
                    {
                        if (rowToComp.SeriesModel.Contains(rowCarInfoSum.SeriesModel.Substring(0, j)))
                        {
                            rowCarInfoSum.SeriesModel = rowCarInfoSum.SeriesModel.Substring(0, j);
                            if (j < rowToComp.SeriesModel.Length) flgSeriesModel = false; // シリーズ型式の相違あり
                            break;
                        }
                    }

                    string dummyComp = rowToComp.SeriesModel + '-' + rowToComp.CategorySignModel;
                    string dummySum = rowCarInfoSum.SeriesModel + '-' + rowCarInfoSum.CategorySignModel;

                    for (j = dummySum.Length; j > 0; j--)
                    {
                        if (dummyComp.Contains(dummySum.Substring(0, j)))
                        {
                            dummySum = dummySum.Substring(0, j);
                            break;
                        }
                    }
                    if (dummySum.Contains("-"))
                    {
                        string[] temp = dummySum.Split('-');
                        rowCarInfoSum.SeriesModel = temp[0];
                        rowCarInfoSum.CategorySignModel = temp[1];
                    }
                    else
                    {
                        rowCarInfoSum.SeriesModel = dummySum;
                        rowCarInfoSum.CategorySignModel = string.Empty;
                    }
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //for (j = rowCarInfoSum.ExhaustGasSign.Length; j > 0; j--)
                    //{
                    //    if (rowToComp.ExhaustGasSign.Contains(rowCarInfoSum.ExhaustGasSign.Substring(0, j)))
                    //    {
                    //        rowCarInfoSum.ExhaustGasSign = rowCarInfoSum.ExhaustGasSign.Substring(0, j);
                    //        if (j < rowToComp.ExhaustGasSign.Length)
                    //            flgExhaustGasSign = false; // 排ガス記号の相違あり
                    //        break;
                    //    }
                    //}
                    //if (j == 0)
                    //    rowCarInfoSum.ExhaustGasSign = string.Empty;

                    // 排ガス記号は完全一致で対象とする
                    if (rowCarInfoSum.ExhaustGasSign == rowToComp.ExhaustGasSign)
                    {
                        rowCarInfoSum.ExhaustGasSign = rowCarInfoSum.ExhaustGasSign;
                    }
                    else
                    {
                        flgExhaustGasSign = false; // 排ガス記号の相違あり
                        rowCarInfoSum.ExhaustGasSign = string.Empty;
                    }
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //for (j = rowCarInfoSum.CategorySignModel.Length; j > 0; j--)
                    //{
                    //    if (rowToComp.CategorySignModel.Contains(rowCarInfoSum.CategorySignModel.Substring(0, j)))
                    //    {
                    //        rowCarInfoSum.CategorySignModel = rowCarInfoSum.CategorySignModel.Substring(0, j);
                    //        break;
                    //    }
                    //}
                    //if (j == 0)
                    //    rowCarInfoSum.CategorySignModel = string.Empty;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            string fullModel = string.Empty;
            if (rowCarInfoSum.FullModel == string.Empty) // フル型式の圧縮処理が必要
            {
                if (flgSeriesModel)
                {
                    if ((flgExhaustGasSign && rowCarInfoSum.ExhaustGasSign != string.Empty)
                        || rowCarInfoSum.ExhaustGasSign != string.Empty)
                    {
                        fullModel = string.Format("{0}-{1}", rowCarInfoSum.ExhaustGasSign, rowCarInfoSum.SeriesModel);
                    }
                    else
                    {
                        fullModel = rowCarInfoSum.SeriesModel;
                    }
                    if (rowCarInfoSum.CategorySignModel != string.Empty)
                    {
                        fullModel += "-" + rowCarInfoSum.CategorySignModel;
                    }
                }
                else if (flgExhaustGasSign && rowCarInfoSum.ExhaustGasSign != string.Empty)
                {
                    fullModel = rowCarInfoSum.ExhaustGasSign;
                    if (rowCarInfoSum.SeriesModel != string.Empty)
                    {
                        fullModel += "-" + rowCarInfoSum.SeriesModel;
                    }
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 DEL
                    //if ( rowCarInfoSum.ExhaustGasSign != string.Empty )
                    //{
                    //    fullModel = rowCarInfoSum.ExhaustGasSign;
                    //}
                    //else if ( rowCarInfoSum.SeriesModel != string.Empty )
                    //{
                    //    fullModel = rowCarInfoSum.SeriesModel;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 ADD
                    if ( rowCarInfoSum.SeriesModel != string.Empty )
                    {
                        fullModel = rowCarInfoSum.SeriesModel;
                    }
                    else if ( rowCarInfoSum.ExhaustGasSign != string.Empty )
                    {
                        fullModel = rowCarInfoSum.ExhaustGasSign;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 ADD
                }
                //if (_carSearchInfo.CarModelUIData[0].FullModel.Contains(rowCarInfoSum.SeriesModel) ||
                //    rowCarInfoSum.SeriesModel.Contains(_carSearchInfo.CarModelUIData[0].FullModel))
                //{
                //    if (_carSearchInfo.CarModelUIData[0].FullModel.Contains(rowCarInfoSum.ExhaustGasSign)
                //        && _carSearchInfo.CarModelUIData[0].FullModel.Contains("-"))
                //    {
                //        fullModel = string.Format("{0}-{1}-{2}", rowCarInfoSum.ExhaustGasSign, rowCarInfoSum.SeriesModel, rowCarInfoSum.CategorySignModel);
                //    }
                //    else
                //    {
                //        fullModel = rowCarInfoSum.SeriesModel;
                //        if (flgSeriesModel) // SeriesModelが完全一致する場合
                //        {
                //            if (flgExhaustGasSign && rowCarInfoSum.ExhaustGasSign != string.Empty)
                //            {
                //                fullModel = string.Format("{0}-{1}", rowCarInfoSum.ExhaustGasSign, fullModel);
                //            }
                //            if (rowCarInfoSum.CategorySignModel != string.Empty) // 型式（類別記号）の共通分を追加
                //            {
                //                fullModel = string.Format("{0}-{1}", fullModel, rowCarInfoSum.CategorySignModel);
                //            }
                //        }
                //    }
                //}
                //else if (_carSearchInfo.CarModelUIData[0].FullModel.Contains(rowCarInfoSum.ExhaustGasSign))
                //{
                //    fullModel = rowCarInfoSum.ExhaustGasSign;
                //}
                //else
                //{
                //    if (rowCarInfoSum.ExhaustGasSign != string.Empty)
                //    {
                //        fullModel = rowCarInfoSum.ExhaustGasSign + "-";
                //    }
                //    if (rowCarInfoSum.SeriesModel != string.Empty)
                //    {
                //        fullModel += rowCarInfoSum.SeriesModel + "-";
                //    }
                //    if (rowCarInfoSum.CategorySignModel != string.Empty)
                //    {
                //        fullModel += rowCarInfoSum.CategorySignModel;
                //    }
                //}
                if (fullModel.EndsWith("-"))
                {
                    fullModel = fullModel.Remove(fullModel.Length - 1);
                }

                rowCarInfoSum.FullModel = fullModel;
            }
        }

        private CarSearchResultReport ColorTrimSearch()
        {
            return ColorTrimSearch(null);
        }

        private CarSearchResultReport ColorTrimSearch(PMKEN01010E _carSearchInfo)
        {
            // -- ADD 2010/05/25 --------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 ---------------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            PMKEN01010E carInfo = null;
            if (_carSearchInfo == null)
                carInfo = dataSet;
            else
                carInfo = _carSearchInfo;

            //結果クラス
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList categoryEquipmentRetWork = null;

            carInfo.CarModelInfo.AcceptChanges();
            PMKEN01010E.CarModelInfoRow[] rowCarModelInfos = carInfo.CarModelInfo.Select("SelectionState = True") as PMKEN01010E.CarModelInfoRow[];
            if (rowCarModelInfos.Length == 1)
            {
                ret = CarSearchResultReport.retSingleCarModel;
            }
            else // 複数の型式を選んだ場合、要約情報を抽出する。
            {
                ret = CarSearchResultReport.retMultipleCarModel;
            }
            SetSummarizedData(carInfo);
            PMKEN01010E.CarModelInfoRow rowCarInfoSum = carInfo.CarModelInfoSummarized[0];

            List<int> lstSystematicCd = new List<int>();
            List<int> lstProduceYearCd = new List<int>();
            List<int> lstFullModelFixedNo = new List<int>();

            for (int i = 0; i < rowCarModelInfos.Length; i++)
            {
                PMKEN01010E.CarModelInfoRow rowToComp = rowCarModelInfos[i];
                if (lstSystematicCd.Contains(rowToComp.SystematicCode) == false)
                {
                    lstSystematicCd.Add(rowToComp.SystematicCode);
                }
                if (lstProduceYearCd.Contains(rowToComp.ProduceTypeOfYearCd) == false)
                {
                    lstProduceYearCd.Add(rowToComp.ProduceTypeOfYearCd);
                }
                if (lstFullModelFixedNo.Contains(rowToComp.FullModelFixedNo) == false)
                {
                    lstFullModelFixedNo.Add(rowToComp.FullModelFixedNo);
                }
            }

            //引数の設定
            ColTrmEquSearchCondWork colTrmEquSearchCondWork = new ColTrmEquSearchCondWork();
            colTrmEquSearchCondWork.MakerCode = rowCarInfoSum.MakerCode;
            colTrmEquSearchCondWork.ModelCode = rowCarInfoSum.ModelCode;
            if (rowCarInfoSum.ModelSubCode != -1)
            {
                colTrmEquSearchCondWork.ModelSubCode = rowCarInfoSum.ModelSubCode;
            }
            if (lstProduceYearCd.Count > 0)
            {
                colTrmEquSearchCondWork.ProduceTypeOfYearCd = lstProduceYearCd.ToArray();
            }
            if (lstSystematicCd.Count > 0)
            {
                colTrmEquSearchCondWork.SystematicCode = lstSystematicCd.ToArray();
            }
            if (lstFullModelFixedNo.Count > 0)
            {
                colTrmEquSearchCondWork.FullModelFixedNo = lstFullModelFixedNo.ToArray();
            }

            //戻り値の初期化
            object objcolorCdRetWork = null;
            object objtrimCdRetWork = null;
            object objcEqpDefDspRetWork = null;
            object objPrdTypRetWork = null;
            object objcolTrmEquSearchCondWork = colTrmEquSearchCondWork as object;

            // 年式情報処理
            if (carInfo.PrdTypYearInfo.Count == 0)
            {
                PrdTypYearCondWork condWork = new PrdTypYearCondWork();
                _IPrdTypYearDB = MediationPrdTypYearDB.GetRemoteObject();
                condWork.MakerCode = rowCarInfoSum.MakerCode;
                condWork.FrameModel = rowCarInfoSum.FrameModel;
                condWork.StProduceTypeOfYear = rowCarInfoSum.StProduceTypeOfYear;
                condWork.EdProduceTypeOfYear = rowCarInfoSum.EdProduceTypeOfYear;
                _IPrdTypYearDB.SearchPrdTypYearInf(out objPrdTypRetWork, condWork);
                ArrayList prdTypRetWork = objPrdTypRetWork as ArrayList;
                if (prdTypRetWork != null)
                {
                    foreach (PrdTypYearRetWork wkPrdTypYear in prdTypRetWork)
                    {
                        PMKEN01010E.PrdTypYearInfoRow prdTypRow = carInfo.PrdTypYearInfo.NewPrdTypYearInfoRow();
                        prdTypRow.MakerCode = wkPrdTypYear.MakerCode;
                        prdTypRow.FrameModel = wkPrdTypYear.FrameModel;
                        prdTypRow.ProduceTypeOfYear = wkPrdTypYear.ProduceTypeOfYear;
                        prdTypRow.StProduceFrameNo = wkPrdTypYear.StProduceFrameNo;
                        prdTypRow.EdProduceFrameNo = wkPrdTypYear.EdProduceFrameNo;
                        carInfo.PrdTypYearInfo.AddPrdTypYearInfoRow(prdTypRow);
                    }
                }
            }

            //リモート処理の呼び出し
            _IColTrmEquInfDB = MediationColTrmEquInfDB.GetRemoteObject();
            _IColTrmEquInfDB.SearchColTrmEquInf(out objcolorCdRetWork, out objtrimCdRetWork, out objcEqpDefDspRetWork, ref objcolTrmEquSearchCondWork);

            colorCdRetWork = objcolorCdRetWork as ArrayList;
            trimCdRetWork = objtrimCdRetWork as ArrayList;
            cEqpDefDspRetWork = objcEqpDefDspRetWork as ArrayList;

            if (carInfo.CategoryEquipmentInfo.Count == 0 &&
                carInfo.CarModelUIData[0].ModelDesignationNo != 0 && carInfo.CarModelUIData[0].CategoryNo != 0)
            {
                ICategoryEquipmentDB _ICategoryEquipmentDB = MediationCategoryEquipmentDB.GetRemoteObject();
                object objCategoryEquipment = null;
                _ICategoryEquipmentDB.SearchCategoryEquipment(out objCategoryEquipment, carInfo.CarModelUIData[0].ModelDesignationNo, carInfo.CarModelUIData[0].CategoryNo);
                categoryEquipmentRetWork = objCategoryEquipment as ArrayList;

                # region 型式類別情報[CategoryEquipmentRetWork]
                // 型式類別情報データーセット
                if (categoryEquipmentRetWork != null)
                {
                    foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow categoryRow = carInfo.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                        categoryRow.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                        categoryRow.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                        categoryRow.EquipmentMngCode = wkSource.EquipmentMngCode;
                        categoryRow.EquipmentMngName = wkSource.EquipmentMngName;
                        categoryRow.EquipmentCode = wkSource.EquipmentCode;
                        categoryRow.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                        categoryRow.TbsPartsCode = wkSource.TbsPartsCode;
                        categoryRow.EquipmentName = wkSource.EquipmentName;
                        categoryRow.EquipmentShortName = wkSource.EquipmentShortName;
                        categoryRow.EquipmentIconCode = wkSource.EquipmentIconCode;
                        categoryRow.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                        categoryRow.EquipmentUnitName = wkSource.EquipmentUnitName;
                        categoryRow.EquipmentCnt = wkSource.EquipmentCnt;
                        categoryRow.EquipmentComment1 = wkSource.EquipmentComment1;
                        categoryRow.EquipmentComment2 = wkSource.EquipmentComment2;

                        carInfo.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(categoryRow);
                    }
                }
                # endregion
            }
            //carInfo.CarModelInfo = (PMKEN01010E.CarModelInfoDataTable)carInfo.CarModelInfo.Copy();

            //戻り値の設定
            ColorTrimSet(colorCdRetWork, trimCdRetWork, cEqpDefDspRetWork, carInfo);

            return ret;
        }

        private CarSearchResultReport CarModelInfoSet(ArrayList carModelRetList)
        {
            return CarModelInfoSet(carModelRetList, null);
        }

        private CarSearchResultReport CarModelInfoSet(ArrayList carModelRetList, PMKEN01010E _carInfo)
        {
            PMKEN01010E carInfo = null;
            if (_carInfo != null) // フル型式固定番号による検索は内部DataSetでなく、引数のDataSetで処理を行う。
                carInfo = _carInfo;
            else
                carInfo = dataSet;

            CarSearchResultReport ret = CarSearchResultReport.retMultipleCarModel;
            foreach (CarModelRetWork wkCarModel in carModelRetList)
            {
                PMKEN01010E.CarModelInfoRow rowCarModelInfo = carInfo.CarModelInfo.NewCarModelInfoRow();
                rowCarModelInfo.MakerCode = wkCarModel.MakerCode;
                rowCarModelInfo.MakerFullName = wkCarModel.MakerFullName;
                rowCarModelInfo.MakerHalfName = wkCarModel.MakerHalfName;
                rowCarModelInfo.ModelCode = wkCarModel.ModelCode;
                rowCarModelInfo.ModelSubCode = wkCarModel.ModelSubCode;
                rowCarModelInfo.ModelFullName = wkCarModel.ModelFullName;
                rowCarModelInfo.ModelHalfName = wkCarModel.ModelHalfName;
                rowCarModelInfo.SystematicCode = wkCarModel.SystematicCode;
                rowCarModelInfo.SystematicName = wkCarModel.SystematicName;
                rowCarModelInfo.ProduceTypeOfYearCd = wkCarModel.ProduceTypeOfYearCd;
                rowCarModelInfo.ProduceTypeOfYearNm = wkCarModel.ProduceTypeOfYearNm;
                rowCarModelInfo.StProduceTypeOfYear = wkCarModel.StProduceTypeOfYear;
                rowCarModelInfo.EdProduceTypeOfYear = wkCarModel.EdProduceTypeOfYear;
                rowCarModelInfo.DoorCount = wkCarModel.DoorCount;
                rowCarModelInfo.BodyNameCode = wkCarModel.BodyNameCode;
                rowCarModelInfo.BodyName = wkCarModel.BodyName;
                rowCarModelInfo.CarProperNo = wkCarModel.CarProperNo;
                rowCarModelInfo.FullModelFixedNo = wkCarModel.FullModelFixedNo;
                rowCarModelInfo.ExhaustGasSign = wkCarModel.ExhaustGasSign;
                rowCarModelInfo.SeriesModel = wkCarModel.SeriesModel;
                rowCarModelInfo.CategorySignModel = wkCarModel.CategorySignModel;
                rowCarModelInfo.FullModel = wkCarModel.FullModel;
                rowCarModelInfo.FrameModel = wkCarModel.FrameModel;
                rowCarModelInfo.StProduceFrameNo = wkCarModel.StProduceFrameNo;
                rowCarModelInfo.EdProduceFrameNo = wkCarModel.EdProduceFrameNo;
                rowCarModelInfo.ModelGradeNm = wkCarModel.ModelGradeNm;
                rowCarModelInfo.EngineModelNm = wkCarModel.EngineModelNm;
                rowCarModelInfo.EngineDisplaceNm = wkCarModel.EngineDisplaceNm;
                rowCarModelInfo.EDivNm = wkCarModel.EDivNm;
                rowCarModelInfo.TransmissionNm = wkCarModel.TransmissionNm;
                rowCarModelInfo.WheelDriveMethodNm = wkCarModel.WheelDriveMethodNm;
                rowCarModelInfo.ShiftNm = wkCarModel.ShiftNm;
                rowCarModelInfo.AddiCarSpec1 = wkCarModel.AddiCarSpec1;
                rowCarModelInfo.AddiCarSpec2 = wkCarModel.AddiCarSpec2;
                rowCarModelInfo.AddiCarSpec3 = wkCarModel.AddiCarSpec3;
                rowCarModelInfo.AddiCarSpec4 = wkCarModel.AddiCarSpec4;
                rowCarModelInfo.AddiCarSpec5 = wkCarModel.AddiCarSpec5;
                rowCarModelInfo.AddiCarSpec6 = wkCarModel.AddiCarSpec6;
                rowCarModelInfo.AddiCarSpecTitle1 = wkCarModel.AddiCarSpecTitle1;
                rowCarModelInfo.AddiCarSpecTitle2 = wkCarModel.AddiCarSpecTitle2;
                rowCarModelInfo.AddiCarSpecTitle3 = wkCarModel.AddiCarSpecTitle3;
                rowCarModelInfo.AddiCarSpecTitle4 = wkCarModel.AddiCarSpecTitle4;
                rowCarModelInfo.AddiCarSpecTitle5 = wkCarModel.AddiCarSpecTitle5;
                rowCarModelInfo.AddiCarSpecTitle6 = wkCarModel.AddiCarSpecTitle6;
                rowCarModelInfo.RelevanceModel = wkCarModel.RelevanceModel;
                rowCarModelInfo.SubCarNmCd = wkCarModel.SubCarNmCd;
                rowCarModelInfo.ModelGradeSname = wkCarModel.ModelGradeSname;
                rowCarModelInfo.BlockIllustrationCd = wkCarModel.BlockIllustrationCd;
                rowCarModelInfo.ThreeDIllustNo = wkCarModel.ThreeDIllustNo;
                rowCarModelInfo.PartsDataOfferFlag = wkCarModel.PartsDataOfferFlag;
                rowCarModelInfo.SelectionState = false;
                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                if ( wkCarModel is CarModelRetWorkEx )
                {
                    rowCarModelInfo.FreeSrchMdlFxdNo = (wkCarModel as CarModelRetWorkEx).FreeSrchMdlFxdNo;
                    rowCarModelInfo.FreeSearchSortDiv = 0; // 0:自由検索
                }
                else
                {
                    rowCarModelInfo.FreeSrchMdlFxdNo = string.Empty;
                    rowCarModelInfo.FreeSearchSortDiv = 1; // 1:自由検索以外
                }
                // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                rowCarModelInfo.GradeFullName = wkCarModel.GradeFullName; // 2012/05/28

                // --- ADD 2013/03/21 ---------->>>>>
                //国産/外車区分
                rowCarModelInfo.DomesticForeignCode = wkCarModel.DomesticForeignCode;
                //国産/外車区分名称
                rowCarModelInfo.DomesticForeignName = wkCarModel.DomesticForeignName;
                //ハンドル位置
                rowCarModelInfo.HandleInfoCd = wkCarModel.HandleInfoCd;
                //ハンドル位置名称
                rowCarModelInfo.HandleInfoNm = wkCarModel.HandleInfoNm;
                // --- ADD 2013/03/21 ----------<<<<<

                // 車両固有番号が違って、フル型式固定番号が同一型式に関しては圧縮処理を行う
                string select = string.Format("FullModelFixedNo = {0}", rowCarModelInfo.FullModelFixedNo);

                // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                //// 2009/10/27 Add >>>
                //// フル型式固定番号 = 0のデータは、フル型式、車台番号を使用して検索
                //if (rowCarModelInfo.FullModelFixedNo == 0) select += string.Format(" AND {0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}", 
                //    carInfo.CarModelInfo.FullModelColumn.ColumnName, 
                //    rowCarModelInfo.FullModel,
                //    carInfo.CarModelInfo.ModelGradeNmColumn,
                //    rowCarModelInfo.ModelGradeNm,
                //    carInfo.CarModelInfo.StProduceFrameNoColumn.ColumnName, 
                //    rowCarModelInfo.StProduceFrameNo,
                //    carInfo.CarModelInfo.EdProduceFrameNoColumn.ColumnName, 
                //    rowCarModelInfo.EdProduceFrameNo
                //    );
                //// 2009/10/27 Add <<<
                // フル型式固定番号 = 0のデータは、フル型式、グレード、車台番号（開始／終了）、自由検索型式固定番号を使用して検索
                if ( rowCarModelInfo.FullModelFixedNo == 0 )
                {
                    select += string.Format( " AND {0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7} AND {8} = '{9}'",
                      carInfo.CarModelInfo.FullModelColumn.ColumnName,
                      rowCarModelInfo.FullModel,
                      carInfo.CarModelInfo.ModelGradeNmColumn,
                      rowCarModelInfo.ModelGradeNm,
                      carInfo.CarModelInfo.StProduceFrameNoColumn.ColumnName,
                      rowCarModelInfo.StProduceFrameNo,
                      carInfo.CarModelInfo.EdProduceFrameNoColumn.ColumnName,
                      rowCarModelInfo.EdProduceFrameNo,
                      carInfo.CarModelInfo.FreeSrchMdlFxdNoColumn.ColumnName,
                      rowCarModelInfo.FreeSrchMdlFxdNo
                      );
                }
                // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                if (carInfo.CarModelInfo.Select(select).Length == 0)
                {
                    carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                }
                else
                {
                    // 2009/10/27 Add >>>
                    if (rowCarModelInfo.FullModelFixedNo == 0)
                    {
                        PMKEN01010E.CarModelInfoRow[] rows = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                        bool exists = false;
                        foreach (PMKEN01010E.CarModelInfoRow row in rows)
                        {
                            if ((row.ModelGradeNm == rowCarModelInfo.ModelGradeNm) &&               // 型式グレード名称
                                ( row.BodyName == rowCarModelInfo.BodyName ) &&                     // ボディー名称
                                ( row.DoorCount == rowCarModelInfo.DoorCount ) &&                   // ドア数
                                ( row.EngineModelNm == rowCarModelInfo.EngineModelNm ) &&           // エンジン型式名称
                                ( row.EngineDisplaceNm == rowCarModelInfo.EngineDisplaceNm ) &&     // 排気量名称
                                ( row.EDivNm == rowCarModelInfo.EDivNm ) &&                         // E区分名称
                                ( row.TransmissionNm == rowCarModelInfo.TransmissionNm ) &&         // ミッション名称
                                ( row.ShiftNm == rowCarModelInfo.ShiftNm ) &&                       // シフト名称
                                ( row.WheelDriveMethodNm == rowCarModelInfo.WheelDriveMethodNm ) && // 駆動方式名称
                                ( row.AddiCarSpec1 == rowCarModelInfo.AddiCarSpec1 ) &&             // 追加諸元1
                                ( row.AddiCarSpec2 == rowCarModelInfo.AddiCarSpec2 ) &&             // 追加諸元2
                                ( row.AddiCarSpec3 == rowCarModelInfo.AddiCarSpec3 ) &&             // 追加諸元3
                                ( row.AddiCarSpec4 == rowCarModelInfo.AddiCarSpec4 ) &&             // 追加諸元4
                                ( row.AddiCarSpec5 == rowCarModelInfo.AddiCarSpec5 ) &&             // 追加諸元5
                                ( row.AddiCarSpec6 == rowCarModelInfo.AddiCarSpec6 )                // 追加諸元6
                               )
                            {
                                // 年式完全一致（データ重複）
                                if (row.StProduceTypeOfYear == rowCarModelInfo.StProduceTypeOfYear &&
                                    row.EdProduceTypeOfYear == rowCarModelInfo.EdProduceTypeOfYear)
                                {
                                    exists = true;
                                    break;
                                }

                                // 既存データの年式範囲が、対象データの年式範囲内
                                if (row.StProduceTypeOfYear <= rowCarModelInfo.StProduceTypeOfYear &&
                                    row.EdProduceTypeOfYear >= rowCarModelInfo.EdProduceTypeOfYear)
                                {
                                    exists = true;
                                    break;
                                }

                                // 対象データの年式範囲が、既存データの年式範囲内
                                if (rowCarModelInfo.StProduceTypeOfYear <= row.StProduceTypeOfYear &&
                                    rowCarModelInfo.EdProduceTypeOfYear >= row.EdProduceTypeOfYear)
                                {
                                    // 対象データの方が年式の範囲が広いので更新
                                    row.StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                                    row.EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                                    exists = true;
                                    break;
                                }

                                // 既存データの開始年式 < 対象データの開始年式
                                if (row.StProduceTypeOfYear < rowCarModelInfo.StProduceTypeOfYear)
                                {
                                    // 年式が連続か
                                    if (row.EdProduceTypeOfYear == rowCarModelInfo.StProduceTypeOfYear)
                                    {
                                        row.EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                                        exists = true;
                                    }
                                    // 既存データの終了年式 < 対象データの開始年式は、断種後復活されたモデル
                                    else if (row.EdProduceTypeOfYear < rowCarModelInfo.StProduceTypeOfYear)
                                    {
                                        // 別途登録する。
                                        carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                                        exists = true;
                                    }
                                }
                                // 既存データの終了年式 > 対象データの終了年式
                                else if (row.EdProduceTypeOfYear > rowCarModelInfo.EdProduceTypeOfYear)
                                {
                                    // 年式が連続か
                                    if (row.StProduceTypeOfYear == rowCarModelInfo.EdProduceTypeOfYear)
                                    {
                                        row.StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                                        exists = true;
                                    }
                                    // 既存データの開始年式 > 対象データの終了年式は、断種後復活されたモデル
                                    else if (row.StProduceTypeOfYear > rowCarModelInfo.EdProduceTypeOfYear)
                                    {
                                        // 別途登録する。
                                        carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                                        exists = true;
                                    }
                                }
                                break;
                            }
                        }
                        if (!exists) carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                    }
                    else
                    {
                    // 2009/10/27 Add <<<
                        select = string.Format("FullModelFixedNo = {0} AND StProduceTypeOfYear = {1} AND EdProduceTypeOfYear = {2}",
                            rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.StProduceTypeOfYear, rowCarModelInfo.EdProduceTypeOfYear);
                        if (carInfo.CarModelInfo.Select(select).Length == 0) // 年式が完全一致する型式がない場合
                        {
                            select = string.Format("FullModelFixedNo = {0} AND StProduceTypeOfYear < {1}",
                                rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.StProduceTypeOfYear);
                            PMKEN01010E.CarModelInfoRow[] rowst = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                            if (rowst.Length != 0) // 過去の年式のデータがテーブルに既に存在するか？
                            {   // 断種後復活は1回だけと仮定する。### 2回以上断種、復活のモデル対応しません。###
                                if (rowst[0].EdProduceTypeOfYear == rowCarModelInfo.StProduceTypeOfYear) // 年式が連続か
                                {
                                    rowst[0].EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                                }
                                else if (rowst[0].EdProduceTypeOfYear < rowCarModelInfo.StProduceTypeOfYear)
                                {
                                    carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo); // 1回断種後復活されたモデルのため、別途登録する。
                                }
                            }
                            else
                            {
                                select = string.Format("FullModelFixedNo = {0} AND EdProduceTypeOfYear > {1}",
                                    rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.EdProduceTypeOfYear);
                                PMKEN01010E.CarModelInfoRow[] rowed = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                                if (rowed.Length != 0)
                                {
                                    if (rowed[0].StProduceTypeOfYear == rowCarModelInfo.EdProduceTypeOfYear) // 年式が連続か
                                    {
                                        rowed[0].StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                                    }
                                    else if (rowed[0].StProduceTypeOfYear > rowCarModelInfo.EdProduceTypeOfYear)
                                    {
                                        carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo); // 1回断種後復活されたモデルのため、別途登録する。
                                    }
                                }
                            }

                            //>>>2010/03/29
                            // 年式範囲開始が古い場合、古い年式で更新
                            select = string.Format("FullModelFixedNo = {0} AND StProduceTypeOfYear > {1}",
                                rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.StProduceTypeOfYear);
                            rowst = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                            if (rowst.Length != 0)
                            {
                                rowst[0].StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                            }

                            // 年式範囲終了が新しい場合、新しい年式で更新
                            select = string.Format("FullModelFixedNo = {0} AND EdProduceTypeOfYear < {1}",
                                rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.EdProduceTypeOfYear);
                            rowst = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                            if (rowst.Length != 0)
                            {
                                rowst[0].EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                            }
                            //<<<2010/03/29
                        }
                    }   // 2009/10/27 Add
                }
            }
            // 2009/10/27 Add >>>
            // フル型式固定番号＝０データの再圧縮
            this.CompressFullModelFixedNoZero(carInfo);
            // 2009/10/27 Add <<<
            if (carInfo.CarModelInfo.Rows.Count == 1)
            {
                carInfo.CarModelInfo[0].SelectionState = true;
                ret = CarSearchResultReport.retSingleCarModel;
            }

            return ret;
        }
        #endregion

        #region [ 装備情報UIデータ取得 ]
#if EQUIPINFO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public Dictionary<string, ValueList> GetEquipUIInfo()
        {
            PMKEN01010E.CEqpDefDspInfoDataTable eqpInfoTable = dat.CEqpDefDspInfo;
            PMKEN01010E.CategoryEquipmentInfoDataTable ctgEquipInfoTable = dat.CategoryEquipmentInfo;
            DataTable retTable = new DataTable();
            Dictionary<string, ValueList> lst = new Dictionary<string, ValueList>();
            List<string> equipGenreLst = new List<string>();
            ValueList vList;

            for (int i = 0; i < dat.CEqpDefDspInfo.Count; i++)
            {
                if (lst.ContainsKey(eqpInfoTable[i].EquipmentGenreNm))
                {
                    vList = lst[eqpInfoTable[i].EquipmentGenreNm];
                    ValueListItem item = new ValueListItem(eqpInfoTable[i].EquipmentName);
                    item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[eqpInfoTable[i].EquipmentIconCode];
                    vList.ValueListItems.Add(item);
                }
                else
                {
                    vList = new ValueList();
                    vList.DisplayStyle = ValueListDisplayStyle.DataValueAndPicture;
                    vList.Key = eqpInfoTable[i].EquipmentGenreNm;
                    ValueListItem item = new ValueListItem(eqpInfoTable[i].EquipmentName);

                    item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[eqpInfoTable[i].EquipmentIconCode];
                    vList.ValueListItems.Add(item);
                    lst.Add(vList.Key, vList);
                }
            }

            return lst;
        }
#endif
        #endregion

        #region [ フル型式固定番号配列取得 ]
        /// <summary>
        /// 車両管理マスタにセットするフル型式固定番号配列を作成します。
        /// </summary>
        /// <param name="carModelDat"></param>
        /// <returns></returns>
        public int[] GetFullModelFixedNoArray(PMKEN01010E.CarModelInfoDataTable carModelDat)
        {
            string query = string.Format("{0}=True", carModelDat.SelectionStateColumn.ColumnName);
            PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])carModelDat.Select(query);

            // --- UPD m.suzuki 2010/04/19 ---------->>>>>
            //int rowCount = row.Length;
            //int[] lst = new int[rowCount];
            //for (int i = 0; i < rowCount; i++)
            //{
            //    lst[i] = row[i].FullModelFixedNo;
            //}
            //return lst;

            int rowCount = row.Length;
            List<int> lst = new List<int>();
            for ( int i = 0; i < rowCount; i++ )
            {
                // 自由検索分を除く
                if ( row[i].FreeSrchMdlFxdNo.Trim() != string.Empty )
                {
                    continue;
                }
                lst.Add( row[i].FullModelFixedNo );
            }
            return lst.ToArray();
            // --- UPD m.suzuki 2010/04/19 ----------<<<<<
        }
        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>
        /// 車両管理マスタにセットするフル型式固定番号配列を作成します。
        /// </summary>
        /// <param name="carModelDat"></param>
        /// <param name="fullModelFixedNoArray"></param>
        /// <param name="freeSrchMdlFxdNoArray"></param>
        /// <returns></returns>
        public void GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo( PMKEN01010E.CarModelInfoDataTable carModelDat, out int[] fullModelFixedNoArray, out string[] freeSrchMdlFxdNoArray )
        {
            string query = string.Format( "{0}=True", carModelDat.SelectionStateColumn.ColumnName );
            PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])carModelDat.Select( query );

            int rowCount = row.Length;
            List<int> lst = new List<int>();
            List<string> fslst = new List<string>();

            for ( int i = 0; i < rowCount; i++ )
            {
                if ( row[i].FreeSrchMdlFxdNo.Trim() == string.Empty )
                {
                    // 提供データ分
                    lst.Add( row[i].FullModelFixedNo );
                }
                else
                {
                    // 自由検索分
                    fslst.Add( row[i].FreeSrchMdlFxdNo );
                }
            }
            fullModelFixedNoArray = lst.ToArray();
            freeSrchMdlFxdNoArray = fslst.ToArray();
        }
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
        #endregion


        // 2009/10/27 Add >>>
        /// <summary>
        /// フル型式固定番号がゼロのデータを圧縮します。
        /// </summary>
        /// <param name="carInfo">車輌情報テーブル</param>
        /// <returns>True:圧縮あり</returns>
        public bool CompressFullModelFixedNoZero(PMKEN01010E carInfo )
        {
            bool compress = false;

            // 圧縮対象が無くなるまでループさせる
            while (true)
            {
                compress = false;

                string selectStr = string.Format("{0} = 0 AND {1} > 0", carInfo.CarModelInfo.FullModelFixedNoColumn, carInfo.CarModelInfo.StProduceFrameNoColumn);
                
                PMKEN01010E.CarModelInfoRow[] baseRows = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(selectStr);
                if (baseRows != null && baseRows.Length > 1)
                {
                    compress = false;
                    for (int ix = 0; ix < baseRows.Length; ix++)
                    {
                        PMKEN01010E.CarModelInfoRow row = baseRows[ix];

                        for (int iy = ix + 1; iy < baseRows.Length; iy++)
                        {
                            PMKEN01010E.CarModelInfoRow checkRow = baseRows[iy];

                            // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                            //if (( row.FullModel == checkRow.FullModel ) &&                    // フル型式
                            //    ( row.ModelGradeNm == checkRow.ModelGradeNm ) &&              // 型式グレード名称
                            //    ( row.BodyName == checkRow.BodyName ) &&                      // ボディー名称
                            //    ( row.DoorCount == checkRow.DoorCount ) &&                    // ドア数
                            //    ( row.EngineModelNm == checkRow.EngineModelNm ) &&            // エンジン型式名称
                            //    ( row.EngineDisplaceNm == checkRow.EngineDisplaceNm ) &&      // 排気量名称
                            //    ( row.EDivNm == checkRow.EDivNm ) &&                          // E区分名称
                            //    ( row.TransmissionNm == checkRow.TransmissionNm ) &&          // ミッション名称
                            //    ( row.ShiftNm == checkRow.ShiftNm ) &&                        // シフト名称
                            //    ( row.WheelDriveMethodNm == checkRow.WheelDriveMethodNm ) &&  // 駆動方式名称
                            //    ( row.AddiCarSpec1 == checkRow.AddiCarSpec1 ) &&              // 追加諸元1
                            //    ( row.AddiCarSpec2 == checkRow.AddiCarSpec2 ) &&              // 追加諸元2
                            //    ( row.AddiCarSpec3 == checkRow.AddiCarSpec3 ) &&              // 追加諸元3
                            //    ( row.AddiCarSpec4 == checkRow.AddiCarSpec4 ) &&              // 追加諸元4
                            //    ( row.AddiCarSpec5 == checkRow.AddiCarSpec5 ) &&              // 追加諸元5
                            //    ( row.AddiCarSpec6 == checkRow.AddiCarSpec6 )                 // 追加諸元6
                            //   )
                            if ( (row.FullModel == checkRow.FullModel) &&                    // フル型式
                                (row.ModelGradeNm == checkRow.ModelGradeNm) &&              // 型式グレード名称
                                (row.BodyName == checkRow.BodyName) &&                      // ボディー名称
                                (row.DoorCount == checkRow.DoorCount) &&                    // ドア数
                                (row.EngineModelNm == checkRow.EngineModelNm) &&            // エンジン型式名称
                                (row.EngineDisplaceNm == checkRow.EngineDisplaceNm) &&      // 排気量名称
                                (row.EDivNm == checkRow.EDivNm) &&                          // E区分名称
                                (row.TransmissionNm == checkRow.TransmissionNm) &&          // ミッション名称
                                (row.ShiftNm == checkRow.ShiftNm) &&                        // シフト名称
                                (row.WheelDriveMethodNm == checkRow.WheelDriveMethodNm) &&  // 駆動方式名称
                                (row.AddiCarSpec1 == checkRow.AddiCarSpec1) &&              // 追加諸元1
                                (row.AddiCarSpec2 == checkRow.AddiCarSpec2) &&              // 追加諸元2
                                (row.AddiCarSpec3 == checkRow.AddiCarSpec3) &&              // 追加諸元3
                                (row.AddiCarSpec4 == checkRow.AddiCarSpec4) &&              // 追加諸元4
                                (row.AddiCarSpec5 == checkRow.AddiCarSpec5) &&              // 追加諸元5
                                (row.AddiCarSpec6 == checkRow.AddiCarSpec6) &&              // 追加諸元6
                                (row.FreeSrchMdlFxdNo == checkRow.FreeSrchMdlFxdNo)         // 自由検索型式固定番号
                               )
                            // --- UPD m.suzuki 2010/04/19 ----------<<<<<
                            {
                                // チェックしている行の車台番号の範囲が、基準となる行の車台番号の範囲内
                                if (row.StProduceFrameNo <= checkRow.StProduceFrameNo &&
                                    row.EdProduceFrameNo >= checkRow.EdProduceFrameNo
                                   )
                                {
                                    // 年式も範囲内か繋がる場合
                                    if ((row.StProduceTypeOfYear <= checkRow.StProduceTypeOfYear &&
                                         row.EdProduceTypeOfYear >= checkRow.EdProduceTypeOfYear ) || 
                                        (row.EdProduceTypeOfYear == checkRow.StProduceTypeOfYear)
                                       )
                                    {
                                        row.EdProduceTypeOfYear = checkRow.EdProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }

                                // 基準となる行の車台番号の範囲が、チェックしている行の車台番号の範囲内
                                if (checkRow.StProduceFrameNo <= row.StProduceFrameNo &&
                                    checkRow.EdProduceFrameNo >= row.EdProduceFrameNo
                                   )
                                {
                                    // 年式も範囲内か繋がる場合
                                    if ((checkRow.StProduceTypeOfYear <= row.StProduceTypeOfYear &&
                                         checkRow.EdProduceTypeOfYear >= row.EdProduceTypeOfYear ) || 
                                        (checkRow.EdProduceTypeOfYear == row.StProduceTypeOfYear)
                                       )
                                    {
                                        row.StProduceTypeOfYear = checkRow.StProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }

                                // 基準となる行と、チェックしている行の車台番号が繋がる
                                if (row.EdProduceFrameNo + 1 == checkRow.StProduceFrameNo)
                                {
                                    // 年式も繋がる
                                    if (row.EdProduceTypeOfYear == checkRow.StProduceTypeOfYear)
                                    {
                                        row.EdProduceFrameNo = checkRow.EdProduceFrameNo;
                                        row.EdProduceTypeOfYear = checkRow.EdProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }
                                // チェックしている行と、基準となる行の車台番号が繋がる
                                if (checkRow.EdProduceFrameNo + 1 == row.StProduceFrameNo)
                                {
                                    // 年式も繋がる
                                    if (checkRow.EdProduceTypeOfYear == row.StProduceTypeOfYear)
                                    {
                                        row.StProduceFrameNo = checkRow.StProduceFrameNo;
                                        row.StProduceTypeOfYear = checkRow.StProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (compress) break;
                    }
                }

                if (!compress) break;
            }
            return compress;
        }
        // 2009/10/27 Add <<<

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>
        /// VINコード文字列からハンドル位置情報を取得します。
        /// </summary>
        /// <param name="VinCode">VINコード文字列</param>
        /// <returns>ハンドル位置情報(HandleInfoCdRet)</returns>
        public HandleInfoCdRet GetHandlePositionFromVinCode(string VinCode)
        {
            HandleInfoCdRet retValue = HandleInfoCdRet.PositionError;
            
            System.Text.Encoding Sjis_enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            
            string HandlePosiStr = string.Empty;
            int HandlePosiNum = -1;

            if (string.IsNullOrEmpty(VinCode))
            {
                // 引数が空
                return retValue;
            }
            else if (VinCode.Length != 17 ||
                     Sjis_enc.GetByteCount(VinCode) != 17)
            {
                // 文字数が17Byteでない。または全角文字が含まれている。
                return retValue;
            }

            // 10Byte目の文字列を1Byte取得(VINコードのフォーマットより)
            HandlePosiStr = VinCode.Substring(9, 1);

            if (!int.TryParse(HandlePosiStr, out HandlePosiNum))
            {
                // ハンドル位置情報が非数値
                return retValue;
            }
            else
            {
                if (HandlePosiNum == 2)
                {
                    // 右ハンドル
                    retValue = HandleInfoCdRet.PositionRight;
                }
                else if (HandlePosiNum == 1)
                {
                    // 左ハンドル
                    retValue = HandleInfoCdRet.PositionLeft;
                }
                else
                {
                    // 両型式
                    retValue = HandleInfoCdRet.PositionBoth;
                }
            }

            return retValue;
        }
        // --- ADD 2013/03/21 ----------<<<<<

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>
        /// 車輌情報データクラス(＋自由検索情報)
        /// </summary>
        /// <remarks>CarModelRetWorkのリストに格納可能な自由検索型式情報用のクラスを定義します。</remarks>
        internal class CarModelRetWorkEx : CarModelRetWork
        {
            /// <summary>自由検索型式固定番号</summary>
            private string _freeSrchMdlFxdNo;

            /// <summary>
            /// 自由検索型式固定番号
            /// </summary>
            public string FreeSrchMdlFxdNo
            {
                get { return _freeSrchMdlFxdNo; }
                set { _freeSrchMdlFxdNo = value; }
            }
        }
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
    }
}
