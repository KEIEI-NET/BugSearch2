
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 通信ログデータアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 通信ログデータ照会アクセスクラス</br>
    /// <br>Programmer  : 30350 櫻井　亮太</br>
    /// <br>Date        : 2008/12/03</br>
    /// </remarks>
    public class ComLogOrderAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IOprtnHisLogDB _oprtnHisLogDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// 通信ログデータ照会コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 通信ログデータアクセスクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        public ComLogOrderAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._oprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._oprtnHisLogDB = null;
            }

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="updHisDspWorkList">検索結果リスト</param>
        /// <returns>ステータス</returns>
        public int Search(ComLogOrderParam extrInfo, out List<ComRogDataResult> comRogDataResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            comRogDataResultList = new List<ComRogDataResult>();

            // クラスメンバコピー処理(E→D)
            OprationLogOrderWork paraWork = CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(extrInfo);
            
            ArrayList retList;
            object paraObj = paraWork;
            object retObj = new object();

            try
            {
                status = this._oprtnHisLogDB.SearchUOE(ref retObj, paraObj,0,0);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (OprtnHisLogWork retWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        comRogDataResultList.Add(CopyToInventoryDataDspResultFromOprationLogOrderWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                comRogDataResultList = new List<ComRogDataResult>();
            }

            return (status);
        }

        /// <summary>
        /// ログデータ削除
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <returns>ステータス</returns>
        public int Delete(ComLogOrderParam opParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            OprationLogOrderWork paraWork = CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(opParam);

            try
            {
                status = this._oprtnHisLogDB.DeleteUOE(paraWork);
            }
            catch
            {
                status = -1;
            }
            return status;
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="para">通信ログデータ条件クラス</param>
        /// <returns>操作履歴ログワーククラス</returns>
        private OprationLogOrderWork CopyToInventoryDataDspParamWorkFromOprationLogOrderParam(ComLogOrderParam para)
        {
            OprationLogOrderWork paraWork = new OprationLogOrderWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.St_LogDataCreateDateTime = para.St_LogDataCreateDateTime;
            paraWork.Ed_LogDataCreateDateTime = para.Ed_LogDataCreateDateTime.AddDays(1);
            paraWork.SectionCodes = para.SectionCodes;
            paraWork.LogDataMachineName = para.LogDataMachineName;
            paraWork.LogDataObjClassID = para.LogDataObjClassID;
            paraWork.LogDataKindCd = para.LogDataKindCd;

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">通信ログデータ照会結果ワーククラス</param>
        /// <returns>操作履歴ログ結果クラス</returns>
        private ComRogDataResult CopyToInventoryDataDspResultFromOprationLogOrderWork(OprtnHisLogWork retWork)
        {
            ComRogDataResult ret = new ComRogDataResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.Date = retWork.LogDataCreateDateTime;
            ret.TerminalNo = retWork.LogDataMachineName;
            if (retWork.LogDataObjClassID == string.Empty || retWork.LogDataObjClassID == null)
            {
                ret.UOESupplierCd = 0;
            }
            else 
            {
                ret.UOESupplierCd = Int32.Parse(retWork.LogDataObjClassID);
            }
            ret.DspDiv = retWork.LogDataOperationCd;
            ret.DspPGID = retWork.LogDataObjBootProgramNm;
            ret.DspStatus = retWork.LogOperationStatus;
            ret.DspMessage = retWork.LogDataMassage;

            return ret;
        }

        #endregion Private Methods
    }
}
