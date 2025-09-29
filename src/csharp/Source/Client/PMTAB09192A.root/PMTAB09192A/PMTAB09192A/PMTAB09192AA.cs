//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : PMTAB初期表示従業員設定マスタ
// プログラム概要   : PMTAB初期表示従業員設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using System.Runtime.Remoting;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB初期表示従業員設定マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB初期表示従業員設定マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 31065 豊沢 憲弘</br>
    /// <br>Date       : 2014/09/19</br>
    /// <br></br>
    /// </remarks>
    public class PmtDefEmpAcs
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        //PMTAB初期表示従業員設定マスタ
        private IPmtDefEmpDB _iPmtDefEmpDB = null;

        #endregion

        #region Constructor

        /// <summary>
        ///PMTAB初期表示従業員設定マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public PmtDefEmpAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iPmtDefEmpDB = (IPmtDefEmpDB)MediationPmtDefEmpDB.GetPmtDefEmpDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //////////this._iPmtDefEmpDB = null;
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
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iPmtDefEmpDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ読み込み処理
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="loginAgenCode">ログイン担当者コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタを読み込みます。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Read(out PmtDefEmp pmtDefEmp, string enterpriseCode, string loginAgenCode)
        {
            try
            {
                // キー情報の設定
                pmtDefEmp = null;
                PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();
                pmtDefEmpWork.EnterpriseCode = enterpriseCode;
                pmtDefEmpWork.LoginAgenCode = loginAgenCode;

                // PMTAB初期表示従業員設定マスタワーカークラスをオブジェクトに設定
                object paraObj = pmtDefEmpWork as object;

                // PMTAB初期表示従業員設定マスタ読み込み
                int status = this._iPmtDefEmpDB.Read(ref paraObj, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 読み込み結果をPMTAB初期表示従業員設定マスタワーカークラスに設定
                    PmtDefEmpWork wkPmtDefEmpWork = (PmtDefEmpWork)paraObj;
                    // PMTAB初期表示従業員設定マスタワーカークラスからPMTAB初期表示従業員設定マスタクラスにコピー
                    pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork(wkPmtDefEmpWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //////////this._iPmtDefEmpDB = null;
                //通信エラーは-1を戻す
                pmtDefEmp = null;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ登録・更新処理
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタの登録・更新を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Write(ref PmtDefEmp pmtDefEmp)
        {
            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();
            ArrayList paraList = new ArrayList();

            // PMTAB初期表示従業員設定マスタクラスからPMTAB初期表示従業員設定マスタワーククラスにメンバコピー
            pmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            // PMTAB初期表示従業員設定マスタの登録・更新情報を設定
            paraList.Add(pmtDefEmpWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // PMTAB初期表示従業員設定マスタ書き込み
                status = this._iPmtDefEmpDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    pmtDefEmp = new PmtDefEmp();

                    // PMTAB初期表示従業員設定マスタワーククラスからPMTAB初期表示従業員設定マスタクラスにメンバコピー
                    pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);
                }
            }
            catch (Exception e)
            {
                // オフライン時はnullをセット
                //////////this._iPmtDefEmpDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ登録・更新処理
        /// </summary>
        /// <param name="PmtDefEmpList">PMTAB初期表示従業員設定マスタクラス</param>
        /// <param name="parsePmtDefEmp">企業コード</param>
        /// <param name="retTotalCnt">件数</param>
        /// <param name="readMode"></param>
        /// <param name="readCnt">件数</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタの登録・更新を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Search(ref List<PmtDefEmp> pmtDefEmpList, PmtDefEmp parsePmtDefEmp, out int retTotalCnt, int readMode, int readCnt, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            Object objPmtDefEmpWorkList = null;
            PmtDefEmpWork parsePmtDefEmpWork = null;
            ArrayList pmtDefEmpWorkResultList = null;
            List<PmtDefEmpWork> pmtDefEmpWorkList = null;

            retTotalCnt = 0;
            parsePmtDefEmpWork = new PmtDefEmpWork();
            parsePmtDefEmpWork.EnterpriseCode = parsePmtDefEmp.EnterpriseCode;
            parsePmtDefEmpWork.LoginAgenCode = parsePmtDefEmp.LoginAgenCode;

            //検索処理
            status = _iPmtDefEmpDB.Search(ref objPmtDefEmpWorkList, parsePmtDefEmpWork, readMode, logicalMode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //結果を戻す
            pmtDefEmpWorkResultList = objPmtDefEmpWorkList as ArrayList;

            if (pmtDefEmpWorkResultList != null)
            {
                pmtDefEmpWorkList = new List<PmtDefEmpWork>((PmtDefEmpWork[])pmtDefEmpWorkResultList.ToArray(typeof(PmtDefEmpWork)));
            }

            if (pmtDefEmpWorkList != null)
            {
                pmtDefEmpList = new List<PmtDefEmp>();
                PmtDefEmp pmtDefEmp = null;
                foreach (PmtDefEmpWork pmtDefEmpWork in pmtDefEmpWorkList)
                {
                    pmtDefEmp = null;
                    pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork(pmtDefEmpWork);
                    pmtDefEmpList.Add(pmtDefEmp);
                }
            }

            return status;
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ登録・更新処理
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタの登録・更新を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int LogicalDelete(ref PmtDefEmp pmtDefEmp)
        {

            ArrayList paraList = new ArrayList();
            PmtDefEmpWork PmtDefEmpWork = new PmtDefEmpWork();

            // PMTAB初期表示従業員設定マスタクラスからPMTAB初期表示従業員設定マスタワーククラスにメンバコピー
            PmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            paraList.Add(PmtDefEmpWork);

            Object objPmtDefEmpWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


            // 論理削除処理
            status = _iPmtDefEmpDB.LogicalDelete(ref objPmtDefEmpWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                paraList = (ArrayList)objPmtDefEmpWorkList;

                pmtDefEmp = new PmtDefEmp();

                // PMTAB初期表示従業員設定マスタワーククラスからPMTAB初期表示従業員設定マスタクラスにメンバコピー
                pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);

                return status;
            }
            return status;
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ登録・更新処理
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタの登録・更新を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Delete(ref PmtDefEmp pmtDefEmp)
        {

            PmtDefEmpWork PmtDefEmpWork = new PmtDefEmpWork();

            ArrayList paraList = new ArrayList();

            // PMTAB初期表示従業員設定マスタクラスからPMTAB初期表示従業員設定マスタワーククラスにメンバコピー
            PmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            paraList.Add(PmtDefEmpWork);

            Object objPmtDefEmpWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //物理削除処理
            status = _iPmtDefEmpDB.Delete(objPmtDefEmpWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objPmtDefEmpWorkList;

                pmtDefEmp = new PmtDefEmp();

                // PMTAB初期表示従業員設定マスタワーククラスからPMTAB初期表示従業員設定マスタクラスにメンバコピー
                pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);

                return status;
            }

            return status;
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ登録・更新処理
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタの登録・更新を行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref PmtDefEmp pmtDefEmp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();

            ArrayList paraList = new ArrayList();

            // PMTAB初期表示従業員設定マスタクラスからPMTAB初期表示従業員設定マスタワーククラスにメンバコピー
            pmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            paraList.Add(pmtDefEmpWork);

            Object objPmtDefEmpWorkList = paraList;

            //復活処理
            status = _iPmtDefEmpDB.RevivalLogicalDelete(ref objPmtDefEmpWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objPmtDefEmpWorkList;

                pmtDefEmp = new PmtDefEmp();

                // PMTAB初期表示従業員設定マスタワーククラスからPMTAB初期表示従業員設定マスタクラスにメンバコピー
                pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);

                return status;
            }

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（PMTAB初期表示従業員設定マスタワーククラス⇒PMTAB初期表示従業員設定マスタクラス）
        /// </summary>
        /// <param name="PmtDefEmpWork">PMTAB初期表示従業員設定マスタワーククラス</param>
        /// <returns>PMTAB初期表示従業員設定マスタ</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタワーククラスからPMTAB初期表示従業員設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private PmtDefEmp CopyToPmtDefEmpFromPmtDefEmpWork(PmtDefEmpWork pmtDefEmpWork)
        {
            PmtDefEmp pmtDefEmp = new PmtDefEmp();
            pmtDefEmp.CreateDateTime = pmtDefEmpWork.CreateDateTime;
            pmtDefEmp.UpdateDateTime = pmtDefEmpWork.UpdateDateTime;
            pmtDefEmp.EnterpriseCode = pmtDefEmpWork.EnterpriseCode;
            pmtDefEmp.FileHeaderGuid = pmtDefEmpWork.FileHeaderGuid;
            pmtDefEmp.UpdEmployeeCode = pmtDefEmpWork.UpdEmployeeCode;
            pmtDefEmp.UpdAssemblyId1 = pmtDefEmpWork.UpdAssemblyId1;
            pmtDefEmp.UpdAssemblyId2 = pmtDefEmpWork.UpdAssemblyId2;
            pmtDefEmp.LogicalDeleteCode = pmtDefEmpWork.LogicalDeleteCode;
            pmtDefEmp.LoginAgenCode = pmtDefEmpWork.LoginAgenCode;
            pmtDefEmp.SalesEmpDiv = pmtDefEmpWork.SalesEmpDiv;
            pmtDefEmp.SalesEmployeeCd = pmtDefEmpWork.SalesEmployeeCd;
            pmtDefEmp.FrontEmpDiv = pmtDefEmpWork.FrontEmpDiv;
            pmtDefEmp.FrontEmployeeCd = pmtDefEmpWork.FrontEmployeeCd;
            pmtDefEmp.SalesInputDiv = pmtDefEmpWork.SalesInputDiv;
            pmtDefEmp.SalesInputCode = pmtDefEmpWork.SalesInputCode;

            return pmtDefEmp;
        }

        /// <summary>
        /// クラスメンバーコピー処理（PMTAB初期表示従業員設定マスタクラス⇒PMTAB初期表示従業員設定マスタワーククラス）
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB初期表示従業員設定マスタワーククラス</param>
        /// <returns>PMTAB初期表示従業員設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : PMTAB初期表示従業員設定マスタクラスからPMTAB初期表示従業員設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 31065 豊沢 憲弘</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private PmtDefEmpWork CopyToPmtDefEmpWorkFromPmtDefEmp(PmtDefEmp pmtDefEmp)
        {
            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();

            pmtDefEmpWork.CreateDateTime = pmtDefEmp.CreateDateTime;
            pmtDefEmpWork.UpdateDateTime = pmtDefEmp.UpdateDateTime;
            pmtDefEmpWork.EnterpriseCode = pmtDefEmp.EnterpriseCode;
            pmtDefEmpWork.FileHeaderGuid = pmtDefEmp.FileHeaderGuid;
            pmtDefEmpWork.UpdEmployeeCode = pmtDefEmp.UpdEmployeeCode;
            pmtDefEmpWork.UpdAssemblyId1 = pmtDefEmp.UpdAssemblyId1;
            pmtDefEmpWork.UpdAssemblyId2 = pmtDefEmp.UpdAssemblyId2;
            pmtDefEmpWork.LogicalDeleteCode = pmtDefEmp.LogicalDeleteCode;
            pmtDefEmpWork.LoginAgenCode = pmtDefEmp.LoginAgenCode;
            pmtDefEmpWork.SalesEmpDiv = pmtDefEmp.SalesEmpDiv;
            pmtDefEmpWork.SalesEmployeeCd = pmtDefEmp.SalesEmployeeCd;
            pmtDefEmpWork.FrontEmpDiv = pmtDefEmp.FrontEmpDiv;
            pmtDefEmpWork.FrontEmployeeCd = pmtDefEmp.FrontEmployeeCd;
            pmtDefEmpWork.SalesInputDiv = pmtDefEmp.SalesInputDiv;
            pmtDefEmpWork.SalesInputCode = pmtDefEmp.SalesInputCode;

            return pmtDefEmpWork;
        }

        #endregion
    }
}