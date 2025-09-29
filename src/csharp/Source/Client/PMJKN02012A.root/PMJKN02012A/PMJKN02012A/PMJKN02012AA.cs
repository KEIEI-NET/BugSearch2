//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタアクセスクラス
// プログラム概要   : 自由検索部品マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由検索部品マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
    /// <br></br>
    /// </remarks>
    public class FreeSearchPartsAcs
    {
        /// <summary>
        /// 自由検索型式ﾞテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :自由検索型式マステーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchPartsAcs()
        {
            this._goodsAcs = new GoodsAcs();
            this._iFreeSearchPartsPrintDB = (IFreeSearchPartsPrintDB)MediationFreeSearchPartsPrintDB.GetFreeSearchPartsPrintDB();
        }

        /// <summary>オーナーフォーム</summary>
        public IWin32Window Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        #region ■ Private Member

        // 自由検索部品マスタ印刷用DB Access RemoteObjectインターフェース
        private IFreeSearchPartsPrintDB _iFreeSearchPartsPrintDB;

        private GoodsAcs _goodsAcs;

        private IWin32Window _owner = null;

        #endregion ■ Private Member

        #region ◎ 自由検索型式検索処理
        /// <summary>
        /// 自由検索型式検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="freeSearchPartsPrint">自由検索部品マスタ（印刷）条件クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式の全検索処理を行います。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, FreeSearchPartsPrint freeSearchPartsPrint)
        {
            retList = new ArrayList();
            object retObject = null;

            FreeSearchPartsParaWork paraWork = null;
            // 抽出条件展開処理
            int status = CopyFromPrintToWork(freeSearchPartsPrint, out paraWork);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = this._iFreeSearchPartsPrintDB.SearchAll(paraWork, out retObject);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        retList = retObject as ArrayList;
                        // データ展開処理
                        status = CopyFromWorkToSet(ref retList, freeSearchPartsPrint);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                }
            }
            
            return status;
        }
        #endregion ■ 自由検索型式検索処理

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="freeSearchPartsPrint">UI抽出条件クラス</param>
        /// <param name="freeSearchPartsParaWork">リモート抽出条件クラス</param>
        /// <returns>Status</returns>
        private int CopyFromPrintToWork(FreeSearchPartsPrint freeSearchPartsPrint, out FreeSearchPartsParaWork freeSearchPartsParaWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            freeSearchPartsParaWork = new FreeSearchPartsParaWork();
            try
            {
                //企業コード
                freeSearchPartsParaWork.EnterpriseCode = freeSearchPartsPrint.EnterpriseCode;

                // 改頁
                freeSearchPartsParaWork.NewPageDiv = (int)freeSearchPartsPrint.NewPageDiv;

                //車種メーカーコード
                freeSearchPartsParaWork.CarMakerCodeSt = freeSearchPartsPrint.CarMakerCodeSt;
                freeSearchPartsParaWork.CarMakerCodeEd = freeSearchPartsPrint.CarMakerCodeEd;

                //車種コード
                freeSearchPartsParaWork.CarModelCodeSt = freeSearchPartsPrint.CarModelCodeSt;
                freeSearchPartsParaWork.CarModelCodeEd = freeSearchPartsPrint.CarModelCodeEd;

                //車種サブコード
                freeSearchPartsParaWork.CarModelSubCodeSt = freeSearchPartsPrint.CarModelSubCodeSt;
                freeSearchPartsParaWork.CarModelSubCodeEd = freeSearchPartsPrint.CarModelSubCodeEd;

                //代表型式
                freeSearchPartsParaWork.ModelName = freeSearchPartsPrint.ModelName;

                //部品メーカー
                freeSearchPartsParaWork.MakerCodeSt = freeSearchPartsPrint.MakerCodeSt;
                freeSearchPartsParaWork.MakerCodeEd = freeSearchPartsPrint.MakerCodeEd;

                //ＢＬコード
                freeSearchPartsParaWork.BLGoodsCodeSt = freeSearchPartsPrint.BLGoodsCodeSt;
                freeSearchPartsParaWork.BLGoodsCodeEd = freeSearchPartsPrint.BLGoodsCodeEd;

                //登録日
                freeSearchPartsParaWork.CreateDateTime = freeSearchPartsPrint.CreateDateTime;

                //登録日（条件）
                freeSearchPartsParaWork.CreateDateTimeCode = freeSearchPartsPrint.CreateDateTimeCode;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion ◎ 抽出条件展開処理

        #region ◎ データ展開処理
        /// <summary>
        /// データ展開処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="freeSearchPartsPrint">自由検索部品マスタ（印刷）条件クラス</param>
        /// <returns>Status</returns>
        private int CopyFromWorkToSet(ref ArrayList retList, FreeSearchPartsPrint freeSearchPartsPrint)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList newList = new ArrayList();
            FreeSearchPartsSet set = null;

            GoodsUnitData goodsUnitData = null;

            try
            {
                foreach (FreeSearchPartsPrintWork work in retList)
                {
                    set = new FreeSearchPartsSet();
                    set.CreateDateTime = work.CreateDateTime;
                    set.UpdateDateTime = work.UpdateDateTime;
                    set.EnterpriseCode = work.EnterpriseCode;
                    set.FileHeaderGuid = work.FileHeaderGuid;
                    set.UpdEmployeeCode = work.UpdEmployeeCode;
                    set.UpdAssemblyId1 = work.UpdAssemblyId1;
                    set.UpdAssemblyId2 = work.UpdAssemblyId2;
                    set.LogicalDeleteCode = work.LogicalDeleteCode;
                    set.FreSrchPrtPropNo = work.FreSrchPrtPropNo;
                    set.MakerCode = work.MakerCode;
                    set.ModelCode = work.ModelCode;
                    set.ModelSubCode = work.ModelSubCode;
                    set.FullModel = work.FullModel;
                    set.TbsPartsCode = work.TbsPartsCode;
                    set.TbsPartsCdDerivedNo = work.TbsPartsCdDerivedNo;
                    set.GoodsNo = work.GoodsNo;
                    set.GoodsNoNoneHyphen = work.GoodsNoNoneHyphen;
                    set.GoodsMakerCd = work.GoodsMakerCd;
                    set.PartsQty = work.PartsQty;
                    set.PartsOpNm = work.PartsOpNm;
                    set.ModelPrtsAdptYm = work.ModelPrtsAdptYm;
                    set.ModelPrtsAblsYm = work.ModelPrtsAblsYm;
                    set.ModelPrtsAdptFrameNo = work.ModelPrtsAdptFrameNo;
                    set.ModelPrtsAblsFrameNo = work.ModelPrtsAblsFrameNo;
                    set.ModelGradeNm = work.ModelGradeNm;
                    set.BodyName = work.BodyName;
                    set.DoorCount = work.DoorCount;
                    set.EngineModelNm = work.EngineModelNm;
                    set.EngineDisplaceNm = work.EngineDisplaceNm;
                    set.EDivNm = work.EDivNm;
                    set.TransmissionNm = work.TransmissionNm;
                    set.WheelDriveMethodNm = work.WheelDriveMethodNm;
                    set.ShiftNm = work.ShiftNm;
                    set.CreateDate = work.CreateDate;
                    set.UpdateDate = work.UpdateDate;
                    set.ModelFullName = work.ModelFullName;
                    set.MakerName = work.MakerName;

                    // 指定した商品コードを元に商品情報を取得
                    status = GetGoodsUnitData(work, freeSearchPartsPrint, out goodsUnitData);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //品名が提供データにないの場合
                        if (string.IsNullOrEmpty(goodsUnitData.GoodsNameKana))
                        {
                            set.BLGoodsHalfName = work.BLGoodsHalfName;
                        }
                        else
                        {
                            set.BLGoodsHalfName = goodsUnitData.GoodsNameKana;
                        }

                        //標準価格が提供データにありの場合
                        if (goodsUnitData.GoodsPriceList != null && goodsUnitData.GoodsPriceList.Count > 0)
                        {
                            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
                            {
                                if (goodsPrice.PriceStartDate == DateTime.Today)
                                {
                                    set.ListPrice = goodsPrice.ListPrice;
                                }
                            }
                        }
                        else
                        {
                            set.ListPrice = 0;
                        }
                    }
                    else
                    {
                        set.BLGoodsHalfName = work.BLGoodsHalfName;
                        set.ListPrice = 0;
                    }

                    newList.Add(set);
                }

                retList = newList;
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion ◎ データ展開処理

        #region ◎ 商品検索処理
        /// <summary>
        /// 指定した商品コードを元に商品情報を取得します。
        /// </summary>
        /// <param name="work">自由検索部品マスタ（印刷）情報クラス</param>
        /// <param name="print">自由検索部品マスタ（印刷）条件クラス</param>
        /// <param name="goodsUnitData">商品情報オブジェクト（out）</param>
        /// <param name="message">メッセージ(out)</param>
        /// <returns>STATUS</returns>
        private int GetGoodsUnitData(FreeSearchPartsPrintWork work, FreeSearchPartsPrint print, out GoodsUnitData goodsUnitData)
        {
            string message;

            List<GoodsUnitData> goodsUnitDataList;

            this._goodsAcs.Owner = this._owner;

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = print.EnterpriseCode; // 企業コード
            goodsCndtn.SectionCode = print.SectionCode; // 拠点コード
            goodsCndtn.GoodsNo = work.GoodsNo; // 商品コード
            goodsCndtn.GoodsMakerCd = work.GoodsMakerCd; // 商品メーカーコード
            goodsCndtn.PriceApplyDate = DateTime.Today; // 価格適用日

            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, false, out goodsUnitDataList, out message);

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
        #endregion ◎ 商品検索処理
    }
}