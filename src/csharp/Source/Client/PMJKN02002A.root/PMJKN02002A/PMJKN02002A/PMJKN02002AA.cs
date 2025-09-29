//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタアクセスクラス
// プログラム概要   : 自由検索型式マスタの登録・変更・削除を行う
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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由検索型式マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
    /// <br></br>
    /// </remarks>
    public class FreeSearchModelAcs
    {
        /// <summary>
        /// 自由検索型式ﾞテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :自由検索型式マステーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchModelAcs()
        {
            this._iFreeSearchModelPrintDB = (IFreeSearchModelPrintDB)MediationFreeSearchModelPrintDB.GetFreeSearchModelPrintDB();
        }

        #region ■ Private Member

        // 自由検索型式マスタ印刷用DB Access RemoteObjectインターフェース
        private IFreeSearchModelPrintDB _iFreeSearchModelPrintDB;

        #endregion ■ Private Member

        #region ◎ 自由検索型式検索処理
        /// <summary>
        /// 自由検索型式検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="freeSearchModelPrint">自由検索型式マスタ（印刷）条件クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式の全検索処理を行います。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, FreeSearchModelPrint freeSearchModelPrint)
        {
            retList = new ArrayList();
            object retObject = null;

            FreeSearchModelParaWork paraWork = null;
            // 抽出条件展開処理
            int status = CopyFromPrintToWork(freeSearchModelPrint, out paraWork);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 企業コード 
                paraWork.EnterpriseCode = enterpriseCode;

                status = this._iFreeSearchModelPrintDB.SearchAll(paraWork, out retObject);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        retList = retObject as ArrayList;

                        // データ展開処理
                        status = CopyFromWorkToSet(ref retList);
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
        /// <param name="freeSearchModelPrint">UI抽出条件クラス</param>
        /// <param name="freeSearchModelParaWork">リモート抽出条件クラス</param>
        /// <returns>Status</returns>
        private int CopyFromPrintToWork(FreeSearchModelPrint freeSearchModelPrint, out FreeSearchModelParaWork freeSearchModelParaWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            freeSearchModelParaWork = new FreeSearchModelParaWork();
            try
            {
                // 改頁
                freeSearchModelParaWork.NewPageDiv = (int)freeSearchModelPrint.NewPageDiv;

                //車種メーカーコード
                freeSearchModelParaWork.CarMakerCodeSt = freeSearchModelPrint.CarMakerCodeSt;
                freeSearchModelParaWork.CarMakerCodeEd = freeSearchModelPrint.CarMakerCodeEd;

                //車種コード
                freeSearchModelParaWork.CarModelCodeSt = freeSearchModelPrint.CarModelCodeSt;
                freeSearchModelParaWork.CarModelCodeEd = freeSearchModelPrint.CarModelCodeEd;

                //車種サブコード
                freeSearchModelParaWork.CarModelSubCodeSt = freeSearchModelPrint.CarModelSubCodeSt;
                freeSearchModelParaWork.CarModelSubCodeEd = freeSearchModelPrint.CarModelSubCodeEd;

                //代表型式
                freeSearchModelParaWork.ModelName = freeSearchModelPrint.ModelName;

                //登録日
                freeSearchModelParaWork.CreateDateTime = freeSearchModelPrint.CreateDateTime;

                //登録日（条件）
                freeSearchModelParaWork.CreateDateTimeCode = freeSearchModelPrint.CreateDateTimeCode;
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
        /// <returns>Status</returns>
        private int CopyFromWorkToSet(ref ArrayList retList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList newList = new ArrayList();
            FreeSearchModelSet set = null;

            try
            {
                foreach (FreeSearchModelPrintWork work in retList)
                {
                    set = new FreeSearchModelSet();
                    set.CreateDateTime = work.CreateDateTime;
                    set.UpdateDateTime = work.UpdateDateTime;
                    set.EnterpriseCode = work.EnterpriseCode;
                    set.FileHeaderGuid = work.FileHeaderGuid;
                    set.UpdEmployeeCode = work.UpdEmployeeCode;
                    set.UpdAssemblyId1 = work.UpdAssemblyId1;
                    set.UpdAssemblyId2 = work.UpdAssemblyId2;
                    set.LogicalDeleteCode = work.LogicalDeleteCode;
                    set.FreeSrchMdlFxdNo = work.FreeSrchMdlFxdNo;
                    set.MakerCode = work.MakerCode;
                    set.ModelCode = work.ModelCode;
                    set.ModelSubCode = work.ModelSubCode;
                    set.ExhaustGasSign = work.ExhaustGasSign;
                    set.SeriesModel = work.SeriesModel;
                    set.CategorySignModel = work.CategorySignModel;
                    set.FullModel = work.FullModel;
                    set.ModelDesignationNo = work.ModelDesignationNo;
                    set.CategoryNo = work.CategoryNo;
                    set.StProduceTypeOfYear = work.StProduceTypeOfYear;
                    set.EdProduceTypeOfYear = work.EdProduceTypeOfYear;
                    set.StProduceFrameNo = work.StProduceFrameNo;
                    set.EdProduceFrameNo = work.EdProduceFrameNo;
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

                    newList.Add(set);
                }

                retList = newList;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion ◎ データ展開処理
    }
}