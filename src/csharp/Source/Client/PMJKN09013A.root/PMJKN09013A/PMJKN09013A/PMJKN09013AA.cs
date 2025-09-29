//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 自由検索部品
// プログラム概要   : 自由検索部品マスタテーブルのアクセス制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由検索部品マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br>UpDate</br>
    /// <br>2010.05.22 葛軍 RedMine#8049</br>
    /// </remarks>
    public class FreeSearchPartsAcs
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // 自由検索部品マスタ
        private IFreeSearchPartsDB _iFreeSearchPartsDB = null;

        private GoodsAcs _goodsAcs;

        private IWin32Window _owner;

        private List<MakerUMnt> _makerUMntList = null;         // メーカーマスタリスト
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // ＢＬコードマスタリスト

        private ArrayList _freeSearchPartsList = new ArrayList();         // 自由検索部品マスタ

        #endregion

        #region ■プロパティ
        /// <summary>オーナーフォーム</summary>
        public IWin32Window Owner
        {
            set { this._owner = value; }
            get { return this._owner; }
        }

        /// <summary>自由検索部品マスタ</summary>
        public ArrayList FreeSearchPartsList
        {
            set { this._freeSearchPartsList = value; }
            get { return this._freeSearchPartsList; }
        }
        #endregion

        #region ReadInitData
        // メーカーマスタ
        public void GetMakerUMntList(out List<MakerUMnt> makerUMntList)
        {
            makerUMntList = this._makerUMntList;
        }
        public void SetMakerUMntList(List<MakerUMnt> makerUMntList)
        {
            this._makerUMntList = makerUMntList;
        }
        // ＢＬコードリス
        public void GetBlGoodsCdUMntList(out List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            blGoodsCdUMntList = this._blGoodsCdUMntList;
        }
        public void SetBlGoodsCdUMntList(List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            this._blGoodsCdUMntList = blGoodsCdUMntList;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 自由検索部品マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchPartsAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iFreeSearchPartsDB = (IFreeSearchPartsDB)MediationFreeSearchPartsDB.GetFreeSearchPartsDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFreeSearchPartsDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iFreeSearchPartsDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 自由検索部品登録・更新処理
        /// </summary>
        /// <param name="freeSearchPartsList">自由検索部品オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品の登録・更新を行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Write(ref ArrayList freeSearchPartsList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            try
            {
                if (freeSearchPartsList != null && freeSearchPartsList.Count != 0)
                {
                    ArrayList paraList = new ArrayList();

                    foreach (FreeSearchParts freeSearchParts in freeSearchPartsList)
                    {
                        // 自由検索部品クラスから自由検索部品ワーククラスにメンバコピー
                        FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                        // データクラスを読込結果へコピー
                        paraList.Add(freeSearchPartsWork);
                    }

                    object paraObj = paraList;
                    // 自由検索部品書き込み
                    status = this._iFreeSearchPartsDB.Write(ref paraObj);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        paraList = (ArrayList)paraObj;

                        if (paraList != null && paraList.Count > 0)
                        {
                            freeSearchPartsList.Clear();
                            foreach (FreeSearchPartsWork wkfreeSearchPartsWork in paraList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                FreeSearchParts freeSearchPartsPara = CopyToFreeSearchPartsFromFreeSearchPartsWork(wkfreeSearchPartsWork);
                                // データクラスを読込結果へコピー
                                freeSearchPartsList.Add(freeSearchPartsPara);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iFreeSearchPartsDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 自由検索部品登録・更新・物理削除処理
        /// </summary>
        /// <param name="writeParaList">自由検索部品オブジェクトリスト</param>
        /// <param name="deleteParaList">自由検索部品オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品の登録・更新・物理削除を行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int WriteAndDelete(ref ArrayList writeParaList, ArrayList deleteParaList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            try
            {
                if ((writeParaList != null && writeParaList.Count != 0) || (deleteParaList != null && deleteParaList.Count != 0))
                {
                    ArrayList wparaList = new ArrayList();
                    ArrayList dparaList = new ArrayList();

                    if (writeParaList != null && writeParaList.Count != 0)
                    {
                        foreach (FreeSearchParts freeSearchParts in writeParaList)
                        {
                            // 自由検索部品クラスから自由検索部品ワーククラスにメンバコピー
                            FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                            // データクラスを読込結果へコピー
                            wparaList.Add(freeSearchPartsWork);
                        }
                    }

                    if (deleteParaList != null && deleteParaList.Count != 0)
                    {
                        foreach (FreeSearchParts freeSearchParts in deleteParaList)
                        {
                            // 自由検索部品クラスから自由検索部品ワーククラスにメンバコピー
                            FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                            // データクラスを読込結果へコピー
                            dparaList.Add(freeSearchPartsWork);
                        }
                    }

                    object wparaObj = wparaList;
                    object dparaObj = dparaList;
                    // 自由検索部品書き込み
                    status = this._iFreeSearchPartsDB.WriteAndDelete(ref wparaObj, dparaObj);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        wparaList = (ArrayList)wparaObj;

                        if (wparaList != null && wparaList.Count > 0)
                        {
                            writeParaList.Clear();
                            foreach (FreeSearchPartsWork wkfreeSearchPartsWork in wparaList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                FreeSearchParts freeSearchPartsPara = CopyToFreeSearchPartsFromFreeSearchPartsWork(wkfreeSearchPartsWork);
                                // データクラスを読込結果へコピー
                                writeParaList.Add(freeSearchPartsPara);
                            }
                        }
                    }
                }
                //ADD START 2009/05/22 GEJUN FOR REDMINE#8049
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                //ADD END 2009/05/22 GEJUN FOR REDMINE#8049
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iFreeSearchPartsDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }


        /// <summary>
        /// 自由検索部品物理削除処理
        /// </summary>
        /// <param name="freeSearchPartsList">自由検索部品オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品情報の物理削除を行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Delete(ArrayList freeSearchPartsList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            try
            {
                if (freeSearchPartsList != null && freeSearchPartsList.Count != 0)
                {
                    ArrayList paraList = new ArrayList();

                    foreach (FreeSearchParts freeSearchParts in freeSearchPartsList)
                    {
                        // 自由検索部品クラスから自由検索部品ワーククラスにメンバコピー
                        FreeSearchPartsWork freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);
                        // データクラスを読込結果へコピー
                        paraList.Add(freeSearchPartsWork);
                    }

                    object paraObj = paraList;

                    // 自由検索部品物理削除
                    status = this._iFreeSearchPartsDB.Delete(paraObj);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFreeSearchPartsDB = null;
                //通信エラーは-1を戻す
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 自由検索部品検索処理（論理削除含まない）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="freeSearchParts">検索条件</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品の全検索処理を行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(out ArrayList retList, FreeSearchParts freeSearchParts)
        {
            retList = new ArrayList();
            try
            {
                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                // 自由検索部品マスタ
                status = this.Search(ref retList, freeSearchParts, ConstantManagement.LogicalMode.GetData0);
                // 自由検索部品マスタデータ
                this._freeSearchPartsList = retList;
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFreeSearchPartsDB = null;
                //通信エラーは-1を戻す
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        //#region Private Methods
        /// <summary>
        /// 自由検索部品検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="freeSearchParts">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品の検索処理を行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private int Search(ref ArrayList retList, FreeSearchParts freeSearchParts, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                FreeSearchPartsWork freeSearchPartsWork = new FreeSearchPartsWork();

                //自由検索部品クラス⇒自由検索部品ワーククラス
                freeSearchPartsWork = CopyToFreeSearchPartsWorkFromFreeSearchParts(freeSearchParts);

                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                ArrayList workList = new ArrayList();
                object retObj = workList;


                // 自由検索部品ワーカークラスをオブジェクトに設定
                object paraObj = (object)freeSearchPartsWork;

                // 全件読込
                status = this._iFreeSearchPartsDB.Search(paraObj, out retObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (FreeSearchPartsWork wkfreeSearchPartsWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                FreeSearchParts freeSearchPartsPara = CopyToFreeSearchPartsFromFreeSearchPartsWork(wkfreeSearchPartsWork);
                                // データクラスを読込結果へコピー
                                retList.Add(freeSearchPartsPara);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFreeSearchPartsDB = null;
                //通信エラーは-1を戻す
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// クラスメンバーコピー処理（自由検索部品ワーククラス⇒自由検索部品クラス）
        /// </summary>
        /// <param name="freeSearchPartsWork">自由検索部品ワーククラス</param>
        /// <returns>自由検索部品クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品ワーククラスから自由検索部品クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchParts CopyToFreeSearchPartsFromFreeSearchPartsWork(FreeSearchPartsWork freeSearchPartsWork)
        {
            FreeSearchParts freeSearchParts = new FreeSearchParts();

            freeSearchParts.CreateDateTime = freeSearchPartsWork.CreateDateTime;
            freeSearchParts.UpdateDateTime = freeSearchPartsWork.UpdateDateTime;
            freeSearchParts.EnterpriseCode = freeSearchPartsWork.EnterpriseCode;
            freeSearchParts.FileHeaderGuid = freeSearchPartsWork.FileHeaderGuid;
            freeSearchParts.UpdEmployeeCode = freeSearchPartsWork.UpdEmployeeCode;
            freeSearchParts.UpdAssemblyId1 = freeSearchPartsWork.UpdAssemblyId1;
            freeSearchParts.UpdAssemblyId2 = freeSearchPartsWork.UpdAssemblyId2;
            freeSearchParts.LogicalDeleteCode = freeSearchPartsWork.LogicalDeleteCode;
            freeSearchParts.FreSrchPrtPropNo = freeSearchPartsWork.FreSrchPrtPropNo;
            freeSearchParts.MakerCode = freeSearchPartsWork.MakerCode;
            freeSearchParts.ModelCode = freeSearchPartsWork.ModelCode;
            freeSearchParts.ModelSubCode = freeSearchPartsWork.ModelSubCode;
            freeSearchParts.FullModel = freeSearchPartsWork.FullModel;
            freeSearchParts.TbsPartsCode = freeSearchPartsWork.TbsPartsCode;
            freeSearchParts.TbsPartsCdDerivedNo = freeSearchPartsWork.TbsPartsCdDerivedNo;
            freeSearchParts.GoodsNo = freeSearchPartsWork.GoodsNo;
            freeSearchParts.GoodsNoNoneHyphen = freeSearchPartsWork.GoodsNoNoneHyphen;
            freeSearchParts.GoodsMakerCd = freeSearchPartsWork.GoodsMakerCd;
            freeSearchParts.PartsQty = freeSearchPartsWork.PartsQty;
            freeSearchParts.PartsOpNm = freeSearchPartsWork.PartsOpNm;
            freeSearchParts.ModelPrtsAdptYm = freeSearchPartsWork.ModelPrtsAdptYm;
            freeSearchParts.ModelPrtsAblsYm = freeSearchPartsWork.ModelPrtsAblsYm;
            freeSearchParts.ModelPrtsAdptFrameNo = freeSearchPartsWork.ModelPrtsAdptFrameNo;
            freeSearchParts.ModelPrtsAblsFrameNo = freeSearchPartsWork.ModelPrtsAblsFrameNo;
            freeSearchParts.ModelGradeNm = freeSearchPartsWork.ModelGradeNm;
            freeSearchParts.BodyName = freeSearchPartsWork.BodyName;
            freeSearchParts.DoorCount = freeSearchPartsWork.DoorCount;
            freeSearchParts.EngineModelNm = freeSearchPartsWork.EngineModelNm;
            freeSearchParts.EngineDisplaceNm = freeSearchPartsWork.EngineDisplaceNm;
            freeSearchParts.EDivNm = freeSearchPartsWork.EDivNm;
            freeSearchParts.TransmissionNm = freeSearchPartsWork.TransmissionNm;
            freeSearchParts.WheelDriveMethodNm = freeSearchPartsWork.WheelDriveMethodNm;
            freeSearchParts.ShiftNm = freeSearchPartsWork.ShiftNm;
            freeSearchParts.CreateDate = freeSearchPartsWork.CreateDate;
            freeSearchParts.UpdateDate = freeSearchPartsWork.UpdateDate;
            return freeSearchParts;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自由検索部品クラス⇒自由検索部品ワーククラス）
        /// </summary>
        /// <param name="freeSearchParts">自由検索部品ワーククラス</param>
        /// <returns>自由検索部品クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品クラスから自由検索部品ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchPartsWork CopyToFreeSearchPartsWorkFromFreeSearchParts(FreeSearchParts freeSearchParts)
        {
            FreeSearchPartsWork freeSearchPartsWork = new FreeSearchPartsWork();

            freeSearchPartsWork.CreateDateTime = freeSearchParts.CreateDateTime;
            freeSearchPartsWork.UpdateDateTime = freeSearchParts.UpdateDateTime;
            freeSearchPartsWork.EnterpriseCode = freeSearchParts.EnterpriseCode;
            freeSearchPartsWork.FileHeaderGuid = freeSearchParts.FileHeaderGuid;
            freeSearchPartsWork.UpdEmployeeCode = freeSearchParts.UpdEmployeeCode;
            freeSearchPartsWork.UpdAssemblyId1 = freeSearchParts.UpdAssemblyId1;
            freeSearchPartsWork.UpdAssemblyId2 = freeSearchParts.UpdAssemblyId2;
            freeSearchPartsWork.LogicalDeleteCode = freeSearchParts.LogicalDeleteCode;
            freeSearchPartsWork.FreSrchPrtPropNo = freeSearchParts.FreSrchPrtPropNo;
            freeSearchPartsWork.MakerCode = freeSearchParts.MakerCode;
            freeSearchPartsWork.ModelCode = freeSearchParts.ModelCode;
            freeSearchPartsWork.ModelSubCode = freeSearchParts.ModelSubCode;
            freeSearchPartsWork.FullModel = freeSearchParts.FullModel;
            freeSearchPartsWork.TbsPartsCode = freeSearchParts.TbsPartsCode;
            freeSearchPartsWork.TbsPartsCdDerivedNo = freeSearchParts.TbsPartsCdDerivedNo;
            freeSearchPartsWork.GoodsNo = freeSearchParts.GoodsNo;
            freeSearchPartsWork.GoodsNoNoneHyphen = freeSearchParts.GoodsNoNoneHyphen;
            freeSearchPartsWork.GoodsMakerCd = freeSearchParts.GoodsMakerCd;
            freeSearchPartsWork.PartsQty = freeSearchParts.PartsQty;
            freeSearchPartsWork.PartsOpNm = freeSearchParts.PartsOpNm;
            freeSearchPartsWork.ModelPrtsAdptYm = freeSearchParts.ModelPrtsAdptYm;
            freeSearchPartsWork.ModelPrtsAblsYm = freeSearchParts.ModelPrtsAblsYm;
            freeSearchPartsWork.ModelPrtsAdptFrameNo = freeSearchParts.ModelPrtsAdptFrameNo;
            freeSearchPartsWork.ModelPrtsAblsFrameNo = freeSearchParts.ModelPrtsAblsFrameNo;
            freeSearchPartsWork.ModelGradeNm = freeSearchParts.ModelGradeNm;
            freeSearchPartsWork.BodyName = freeSearchParts.BodyName;
            freeSearchPartsWork.DoorCount = freeSearchParts.DoorCount;
            freeSearchPartsWork.EngineModelNm = freeSearchParts.EngineModelNm;
            freeSearchPartsWork.EngineDisplaceNm = freeSearchParts.EngineDisplaceNm;
            freeSearchPartsWork.EDivNm = freeSearchParts.EDivNm;
            freeSearchPartsWork.TransmissionNm = freeSearchParts.TransmissionNm;
            freeSearchPartsWork.WheelDriveMethodNm = freeSearchParts.WheelDriveMethodNm;
            freeSearchPartsWork.ShiftNm = freeSearchParts.ShiftNm;
            freeSearchPartsWork.CreateDate = freeSearchParts.CreateDate;
            freeSearchPartsWork.UpdateDate = freeSearchParts.UpdateDate;
            freeSearchPartsWork.GoodsNoFuzzy = freeSearchParts.GoodsNoFuzzy;


            return freeSearchPartsWork;
        }

        /// <summary>
        /// 指定した商品コードを元に商品情報を取得します。
        /// </summary>
        /// <param name="goodsCndtn">商品検索条件</param>
        /// <param name="goodsUnitData">商品情報オブジェクト（out）</param>
        /// <param name="message">メッセージ(out)</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(GoodsCndtn goodsCndtn, out GoodsUnitData goodsUnitData, out string message)
        {

            List<GoodsUnitData> goodsUnitDataList;

            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);

            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                goodsUnitData = goodsUnitDataList[0];
            }
            else
            {
                goodsUnitData = null;
            }
            return status;
        }

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>ConstantManagement.MethodResult(-3:車両情報無し)</returns>
        public int SearchPartsFromBLCode(int salesRowNo, string enterpriseCode, string sectionCode, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList, PMKEN01010E carInfo)
        {
            #region ●初期化
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            goodsUnitDataList = new List<GoodsUnitData>();
            #endregion

            #region ●抽出条件設定
            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.BLGoodsCode = bLGoodsCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.IsSettingSupplier = 1;


            cndtn.SearchCarInfo = carInfo;
            #endregion

            #region ●車両情報存在チェック
            //-----------------------------------------------------------------------------
            // 車両情報存在チェック
            //-----------------------------------------------------------------------------
            if (cndtn.SearchCarInfo == null) return -3;
            #endregion

            #region ●BLコード検索
            //-----------------------------------------------------------------------------
            // BLコード検索
            //-----------------------------------------------------------------------------
            if (_goodsAcs == null)
            {
                string retMessage;
                this._goodsAcs = new GoodsAcs();
                this._goodsAcs.SearchInitial(cndtn.EnterpriseCode, cndtn.SectionCode, out retMessage);
            }
            int status = this._goodsAcs.SearchPartsFromBLCode(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            #endregion

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
                    #region ●部品選択制御起動
                    //-----------------------------------------------------------------------------
                    // 部品選択制御起動
                    //-----------------------------------------------------------------------------
                    partsInfoDataSet.TBOInitializeFlg = 0;
                    DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this._owner, cndtn.SearchCarInfo, partsInfoDataSet);
                    #endregion

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                        case DialogResult.Cancel:
                            partsInfoDataSet.Clear();
                            goodsUnitDataList.Clear();
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            #region ●部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true).ToArray(typeof(GoodsUnitData)));
                            #endregion
                            break;
                        case DialogResult.Retry:
                            break;
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    break;
            }
            return status;
        }
    }
}
