using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BLコードガイドマスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: BLコードガイドマスタのアクセス制御を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/09/30</br>
    /// </remarks>
    public class BLCodeGuideAcs
    {
        #region ■ Constants

        #endregion ■ Constants


        #region ■ Private Members

        private IBLCodeGuideDB _iBLCodeGuideDB = null;

        #endregion ■ Private Members


        # region ■ Constructor

        /// <summary>
        /// BLコードガイドマスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタアクセスクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public BLCodeGuideAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iBLCodeGuideDB = (IBLCodeGuideDB)MediationBLCodeGuideDB.GetBLCodeGuideDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iBLCodeGuideDB = null;
            }
        }

        # endregion ■ Constructor


        #region ■ Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iBLCodeGuideDB == null) || (this._iBLCodeGuideDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// BLコードガイドマスタ読込処理
        /// </summary>
        /// <param name="bLCodeGuide">BLコードガイドマスタ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="bLCodeDspPage">BLコード表示頁</param>
        /// <param name="bLCodeDspRow">BLコード表示行</param>
        /// <param name="bLCodeDspCol">BLコード表示列</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Read(out BLCodeGuide bLCodeGuide, string enterpriseCode, string sectionCode, int bLCodeDspPage,
                        int bLCodeDspRow, int bLCodeDspCol, int bLGoodsCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bLCodeGuide = new BLCodeGuide();

            try
            {
                // 検索条件設定
                BLCodeGuideWork paraWork = new BLCodeGuideWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.BLCodeDspPage = bLCodeDspPage;
                paraWork.BLCodeDspRow = bLCodeDspRow;
                paraWork.BLCodeDspCol = bLCodeDspCol;
                paraWork.BLGoodsCode = bLGoodsCode;

                object paraObj = paraWork;

                status = this._iBLCodeGuideDB.Read(ref paraObj, 0);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;

                    // クラスメンバコピー処理(D→E)
                    bLCodeGuide = CopyToBLCodeGuideFromBLCodeGuideWork((BLCodeGuideWork)retList[0]);
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ取得処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Search(out ArrayList bLCodeGuideList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out bLCodeGuideList, enterpriseCode, "", 0, logicalMode);

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ取得処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Search(out ArrayList bLCodeGuideList, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out bLCodeGuideList, enterpriseCode, sectionCode, 0, logicalMode);

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ取得処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Search(out ArrayList bLCodeGuideList, string enterpriseCode, string sectionCode, int bLGoodsCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out bLCodeGuideList, enterpriseCode, sectionCode, bLGoodsCode, logicalMode);

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ更新処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを更新します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Write(ref ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                status = this._iBLCodeGuideDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    bLCodeGuideList = new ArrayList();
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ論理削除処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを論理削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                // 論理削除処理
                status = this._iBLCodeGuideDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    bLCodeGuideList = new ArrayList();
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ削除処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを削除します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Delete(ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                // 物理削除処理
                status = this._iBLCodeGuideDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// BLコードガイドマスタ復活処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを復活します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Revival(ref ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // クラスメンバコピー処理(E→D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                // 復活処理
                status = this._iBLCodeGuideDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    bLCodeGuideList = new ArrayList();
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// BLコードガイドマスタ取得処理
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLコードガイドマスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int SearchProc(out ArrayList bLCodeGuideList, string enterpriseCode, string sectionCode, int bLGoodsCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bLCodeGuideList = new ArrayList();

            try
            {
                // 検索条件設定
                BLCodeGuideWork paraWork = new BLCodeGuideWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.BLGoodsCode = bLGoodsCode;

                object paraObj = paraWork;
                object retObj = bLCodeGuideList;

                status = this._iBLCodeGuideDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    ArrayList retList = retObj as ArrayList;
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="bLCodeGuide">BLコードガイドクラス</param>
        /// <returns>BLコードガイドワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private BLCodeGuideWork CopyToBLCodeGuideWorkFromBLCodeGuide(BLCodeGuide bLCodeGuide)
        {
            BLCodeGuideWork bLCodeGuideWork = new BLCodeGuideWork();

            bLCodeGuideWork.CreateDateTime = bLCodeGuide.CreateDateTime;        // 作成日時
            bLCodeGuideWork.UpdateDateTime = bLCodeGuide.UpdateDateTime;        // 更新日時
            bLCodeGuideWork.EnterpriseCode = bLCodeGuide.EnterpriseCode;        // 企業コード
            bLCodeGuideWork.FileHeaderGuid = bLCodeGuide.FileHeaderGuid;        // GUID
            bLCodeGuideWork.UpdEmployeeCode = bLCodeGuide.UpdEmployeeCode;      // 更新従業員コード
            bLCodeGuideWork.UpdAssemblyId1 = bLCodeGuide.UpdAssemblyId1;        // 更新アセンブリID1
            bLCodeGuideWork.UpdAssemblyId2 = bLCodeGuide.UpdAssemblyId2;        // 更新アセンブリID2
            bLCodeGuideWork.LogicalDeleteCode = bLCodeGuide.LogicalDeleteCode;  // 論理削除区分
            bLCodeGuideWork.SectionCode = bLCodeGuide.SectionCode;              // 拠点コード
            bLCodeGuideWork.BLCodeDspPage = bLCodeGuide.BLCodeDspPage;          // BLコード表示頁
            bLCodeGuideWork.BLCodeDspRow = bLCodeGuide.BLCodeDspRow;            // BLコード表示行
            bLCodeGuideWork.BLCodeDspCol = bLCodeGuide.BLCodeDspCol;            // BLコード表示列
            bLCodeGuideWork.BLGoodsCode = bLCodeGuide.BLGoodsCode;              // BLコード
            bLCodeGuideWork.BLGoodsName = bLCodeGuide.BLGoodsName;              // BLコード名

            return bLCodeGuideWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="bLCodeGuideWork">BLコードワーククラス</param>
        /// <returns>BLコードガイドクラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private BLCodeGuide CopyToBLCodeGuideFromBLCodeGuideWork(BLCodeGuideWork bLCodeGuideWork)
        {
            BLCodeGuide bLCodeGuide = new BLCodeGuide();

            bLCodeGuide.CreateDateTime = bLCodeGuideWork.CreateDateTime;        // 作成日時
            bLCodeGuide.UpdateDateTime = bLCodeGuideWork.UpdateDateTime;        // 更新日時
            bLCodeGuide.EnterpriseCode = bLCodeGuideWork.EnterpriseCode;        // 企業コード
            bLCodeGuide.FileHeaderGuid = bLCodeGuideWork.FileHeaderGuid;        // GUID
            bLCodeGuide.UpdEmployeeCode = bLCodeGuideWork.UpdEmployeeCode;      // 更新従業員コード
            bLCodeGuide.UpdAssemblyId1 = bLCodeGuideWork.UpdAssemblyId1;        // 更新アセンブリID1
            bLCodeGuide.UpdAssemblyId2 = bLCodeGuideWork.UpdAssemblyId2;        // 更新アセンブリID2
            bLCodeGuide.LogicalDeleteCode = bLCodeGuideWork.LogicalDeleteCode;  // 論理削除区分
            bLCodeGuide.SectionCode = bLCodeGuideWork.SectionCode;              // 拠点コード
            bLCodeGuide.BLCodeDspPage = bLCodeGuideWork.BLCodeDspPage;          // BLコード表示頁
            bLCodeGuide.BLCodeDspRow = bLCodeGuideWork.BLCodeDspRow;            // BLコード表示行
            bLCodeGuide.BLCodeDspCol = bLCodeGuideWork.BLCodeDspCol;            // BLコード表示列
            bLCodeGuide.BLGoodsCode = bLCodeGuideWork.BLGoodsCode;              // BLコード
            bLCodeGuide.BLGoodsName = bLCodeGuideWork.BLGoodsName;              // BLコード名

            return bLCodeGuide;
        }
        #endregion ■ Private Methods
    }
}
