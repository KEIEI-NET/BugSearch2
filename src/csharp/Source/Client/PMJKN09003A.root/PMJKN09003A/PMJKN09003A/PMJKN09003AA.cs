//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタアクセスクラス
// プログラム概要   : 自由検索型式マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/30  修正内容 : 新規作成
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
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br></br>
    /// </remarks>
    public class FreeSearchModelAcs
    {

        #region ■ Constructor ■

        /// <summary>
        /// 自由検索型式テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchModelAcs()
        {
            this._iFreeSearchModelDB = (IFreeSearchModelDB)MediationFreeSearchModelDB.GetFreeSearchModelDB();
        }

        #endregion


        #region ■ Private Member ■

        // 自由検索型式マスタDB Access RemoteObjectインターフェース
        private IFreeSearchModelDB _iFreeSearchModelDB;

        #endregion


        #region ■ Private Methods ■

        /// <summary>
        /// クラスメンバーコピー処理（自由検索型式ワーククラス⇒自由検索型式クラス）
        /// </summary>
        /// <param name="uoeSupplierWork">自由検索型式ワーククラス</param>
        /// <returns>自由検索型式クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式ワーククラスから自由検索型式クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private FreeSearchModel CopyToFreeSearchModelFromFreeSearchModelWork(FreeSearchModelWork freeSearchModelWork)
        {
            FreeSearchModel freeSearchModel = new FreeSearchModel();

            freeSearchModel.CreateDateTime = freeSearchModelWork.CreateDateTime;
            freeSearchModel.UpdateDateTime = freeSearchModelWork.UpdateDateTime;
            freeSearchModel.EnterpriseCode = freeSearchModelWork.EnterpriseCode;
            freeSearchModel.FileHeaderGuid = freeSearchModelWork.FileHeaderGuid;
            freeSearchModel.UpdEmployeeCode = freeSearchModelWork.UpdEmployeeCode;
            freeSearchModel.UpdAssemblyId1 = freeSearchModelWork.UpdAssemblyId1;
            freeSearchModel.UpdAssemblyId2 = freeSearchModelWork.UpdAssemblyId2;
            freeSearchModel.LogicalDeleteCode = freeSearchModelWork.LogicalDeleteCode;

            freeSearchModel.FreeSrchMdlFxdNo = freeSearchModelWork.FreeSrchMdlFxdNo;
            freeSearchModel.MakerCode = freeSearchModelWork.MakerCode;
            freeSearchModel.ModelCode = freeSearchModelWork.ModelCode;
            freeSearchModel.ModelSubCode = freeSearchModelWork.ModelSubCode;
            freeSearchModel.ExhaustGasSign = freeSearchModelWork.ExhaustGasSign;
            freeSearchModel.SeriesModel = freeSearchModelWork.SeriesModel;
            freeSearchModel.CategorySignModel = freeSearchModelWork.CategorySignModel;
            freeSearchModel.FullModel = freeSearchModelWork.FullModel;
            freeSearchModel.ModelDesignationNo = freeSearchModelWork.ModelDesignationNo;
            freeSearchModel.CategoryNo = freeSearchModelWork.CategoryNo;
            freeSearchModel.StProduceTypeOfYear = freeSearchModelWork.StProduceTypeOfYear;
            freeSearchModel.EdProduceTypeOfYear = freeSearchModelWork.EdProduceTypeOfYear;
            freeSearchModel.StProduceFrameNo = freeSearchModelWork.StProduceFrameNo;
            freeSearchModel.EdProduceFrameNo = freeSearchModelWork.EdProduceFrameNo;
            freeSearchModel.ModelGradeNm = freeSearchModelWork.ModelGradeNm;
            freeSearchModel.BodyName = freeSearchModelWork.BodyName;
            freeSearchModel.DoorCount = freeSearchModelWork.DoorCount;
            freeSearchModel.EngineModelNm = freeSearchModelWork.EngineModelNm;
            freeSearchModel.EngineDisplaceNm = freeSearchModelWork.EngineDisplaceNm;
            freeSearchModel.EDivNm = freeSearchModelWork.EDivNm;
            freeSearchModel.TransmissionNm = freeSearchModelWork.TransmissionNm;
            freeSearchModel.WheelDriveMethodNm = freeSearchModelWork.WheelDriveMethodNm;
            freeSearchModel.ShiftNm = freeSearchModelWork.ShiftNm;
            freeSearchModel.CreateDate = freeSearchModelWork.CreateDate;
            freeSearchModel.UpdateDate = freeSearchModelWork.UpdateDate;

            return freeSearchModel;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自由検索型式クラス⇒自由検索型式ワーククラス）
        /// </summary>
        /// <param name="uoeSupplier">自由検索型式ワーククラス</param>
        /// <returns>自由検索型式クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式クラスから自由検索型式ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private FreeSearchModelWork CopyToFreeSearchModelWorkFromFreeSearchModel(FreeSearchModel freeSearchModel)
        {
            FreeSearchModelWork freeSearchModelWork = new FreeSearchModelWork();


            freeSearchModelWork.CreateDateTime = freeSearchModel.CreateDateTime;
            freeSearchModelWork.UpdateDateTime = freeSearchModel.UpdateDateTime;
            freeSearchModelWork.EnterpriseCode = freeSearchModel.EnterpriseCode;
            freeSearchModelWork.FileHeaderGuid = freeSearchModel.FileHeaderGuid;
            freeSearchModelWork.UpdEmployeeCode = freeSearchModel.UpdEmployeeCode;
            freeSearchModelWork.UpdAssemblyId1 = freeSearchModel.UpdAssemblyId1;
            freeSearchModelWork.UpdAssemblyId2 = freeSearchModel.UpdAssemblyId2;
            freeSearchModelWork.LogicalDeleteCode = freeSearchModel.LogicalDeleteCode;

            freeSearchModelWork.FreeSrchMdlFxdNo = freeSearchModel.FreeSrchMdlFxdNo;
            freeSearchModelWork.MakerCode = freeSearchModel.MakerCode;
            freeSearchModelWork.ModelCode = freeSearchModel.ModelCode;
            freeSearchModelWork.ModelSubCode = freeSearchModel.ModelSubCode;
            freeSearchModelWork.ExhaustGasSign = freeSearchModel.ExhaustGasSign;
            freeSearchModelWork.SeriesModel = freeSearchModel.SeriesModel;
            freeSearchModelWork.CategorySignModel = freeSearchModel.CategorySignModel;
            freeSearchModelWork.FullModel = freeSearchModel.FullModel;
            freeSearchModelWork.ModelDesignationNo = freeSearchModel.ModelDesignationNo;
            freeSearchModelWork.CategoryNo = freeSearchModel.CategoryNo;
            freeSearchModelWork.StProduceTypeOfYear = freeSearchModel.StProduceTypeOfYear;
            freeSearchModelWork.EdProduceTypeOfYear = freeSearchModel.EdProduceTypeOfYear;
            freeSearchModelWork.StProduceFrameNo = freeSearchModel.StProduceFrameNo;
            freeSearchModelWork.EdProduceFrameNo = freeSearchModel.EdProduceFrameNo;
            freeSearchModelWork.ModelGradeNm = freeSearchModel.ModelGradeNm;
            freeSearchModelWork.BodyName = freeSearchModel.BodyName;
            freeSearchModelWork.DoorCount = freeSearchModel.DoorCount;
            freeSearchModelWork.EngineModelNm = freeSearchModel.EngineModelNm;
            freeSearchModelWork.EngineDisplaceNm = freeSearchModel.EngineDisplaceNm;
            freeSearchModelWork.EDivNm = freeSearchModel.EDivNm;
            freeSearchModelWork.TransmissionNm = freeSearchModel.TransmissionNm;
            freeSearchModelWork.WheelDriveMethodNm = freeSearchModel.WheelDriveMethodNm;
            freeSearchModelWork.ShiftNm = freeSearchModel.ShiftNm;
            freeSearchModelWork.CreateDate = freeSearchModel.CreateDate;
            freeSearchModelWork.UpdateDate = freeSearchModel.UpdateDate;

            return freeSearchModelWork;
        }
        #endregion


        #region ■ 自由検索型式マスタ検索処理 ■
        /// <summary>
        /// 自由検索型式検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="freeSearchModel">自由検索型式マスタ条件クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式の全検索処理を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(out ArrayList retList, FreeSearchModel freeSearchModel)
        {
            retList = new ArrayList();
            object retObject = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            FreeSearchModelWork paraWork = null;

            this.CopyFromFreeSearchModelToWork(freeSearchModel, ref paraWork);

            status = this._iFreeSearchModelDB.Search(paraWork, out retObject);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        retList = retObject as ArrayList;

                        // データ展開処理
                        status = CopyFromWorkToSet(ref retList);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                default:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                    }
            }

            return status;
        }
        #endregion ■ 自由検索型式検索処理 ■


        #region ■ 自由検索型式マスタ登録・更新処理 ■

        /// <summary>
        /// 自由検索型式マスタ登録・更新処理
        /// </summary>
        /// <param name="freeSearchModel">自由検索型式マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタの登録・更新を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Write(ref FreeSearchModel freeSearchModel)
        {
            FreeSearchModelWork freeSearchModelWork = new FreeSearchModelWork();
            ArrayList paraList = new ArrayList();

            // 自由検索型式マスタから自由検索型式マスタワーククラスにメンバコピー
            freeSearchModelWork = CopyToFreeSearchModelWorkFromFreeSearchModel(freeSearchModel);

            // 自由検索型式マスタの登録・更新情報を設定
            paraList.Add(freeSearchModelWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // 自由検索型式マスタ書き込み
                status = this._iFreeSearchModelDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    freeSearchModel = new FreeSearchModel();

                    // 自由検索型式マスタワーククラスから自由検索型式マスタクラスにメンバコピー
                    freeSearchModel = this.CopyToFreeSearchModelFromFreeSearchModelWork((FreeSearchModelWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iFreeSearchModelDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        #endregion


        #region ■ 自由検索型式マスタ物理削除処理 ■

        /// <summary>
        /// 自由検索型式マスタ物理削除処理
        /// </summary>
        /// <param name="freeSearchModel">自由検索型式マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ情報の物理削除を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Delete(FreeSearchModel freeSearchModel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                FreeSearchModelWork freeSearchModelWork = new FreeSearchModelWork();
                ArrayList paraList = new ArrayList();

                // 自由検索型式マスタクラスから自由検索型式マスタワーククラスにメンバコピー
                freeSearchModelWork = CopyToFreeSearchModelWorkFromFreeSearchModel(freeSearchModel);
                // 自由検索型式マスタの物理削除情報を設定
                paraList.Add(freeSearchModelWork);

                object paraObj = paraList;

                // 自由検索型式マスタ物理削除
                status = this._iFreeSearchModelDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFreeSearchModelDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion


        #region ■ 抽出条件展開処理 ■
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="freeSearchModelPrint">UI抽出条件クラス</param>
        /// <param name="freeSearchModelParaWork">リモート抽出条件クラス</param>
        /// <returns>Status</returns>
        private int CopyFromFreeSearchModelToWork(FreeSearchModel freeSearchModel, ref FreeSearchModelWork freeSearchModelParaWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            freeSearchModelParaWork = new FreeSearchModelWork();
            try
            {
                //企業コード
                freeSearchModelParaWork.EnterpriseCode = freeSearchModel.EnterpriseCode;

                //自由検索型式固定番号
                freeSearchModelParaWork.FreeSrchMdlFxdNo = freeSearchModel.FreeSrchMdlFxdNo;

                //メーカーコード
                freeSearchModelParaWork.MakerCode = freeSearchModel.MakerCode;

                //車種コード
                freeSearchModelParaWork.ModelCode = freeSearchModel.ModelCode;

                //車種サブコード
                freeSearchModelParaWork.ModelSubCode = freeSearchModel.ModelSubCode;

                //排ガス記号
                freeSearchModelParaWork.ExhaustGasSign = freeSearchModel.ExhaustGasSign;

                //シリーズ型式
                freeSearchModelParaWork.SeriesModel = freeSearchModel.SeriesModel;

                //型式（類別記号）
                freeSearchModelParaWork.CategorySignModel = freeSearchModel.CategorySignModel;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion ◎ 抽出条件展開処理


        #region ■ データ展開処理 ■
        /// <summary>
        /// データ展開処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <returns>Status</returns>
        private int CopyFromWorkToSet(ref ArrayList retList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList newList = new ArrayList();
            FreeSearchModel set = null;

            try
            {
                foreach (FreeSearchModelWork work in retList)
                {
                    set = new FreeSearchModel();
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