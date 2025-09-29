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
    /// BLコード変換マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 吉岡 孝憲 30745</br>
    /// <br>Date       : 2012.08.01</br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCdChgUAcs
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        //BLコード変換マスタ
        private IBLGoodsCdChgUDB _iBLGoodsCdChgUDB = null;
        private SecInfoSetAcs _secInfoSetAcs = null;
        private Hashtable _secInfoSetTable = null;

        #endregion

        #region Constructor

        /// <summary>
        ///BLコード変換マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public BLGoodsCdChgUAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iBLGoodsCdChgUDB = (IBLGoodsCdChgUDB)MediationBLGoodsCdChgUDB.GetBLGoodsCdChgUDB();
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGoodsCdChgUDB = null;
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
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iBLGoodsCdChgUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
      
        /// <summary>
        ///BLコード変換マスタ読み込み処理
        /// </summary>
        /// <param name="blCodeChange">UOE自社オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタ情報を読み込みます。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Read(out  BLGoodsCdChgU blCodeChange, string enterpriseCode)
        {
            try
            {
                // キー情報の設定
                blCodeChange = null;
                BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();
                blCodeChangeWork.EnterpriseCode = enterpriseCode;
            
                //BLコード変換マスタワーカークラスをオブジェクトに設定
                object paraObj = blCodeChangeWork as object;

                //UOE自社マスタ読み込み
                int status = this._iBLGoodsCdChgUDB.Read(ref paraObj, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 読み込み結果をUOE自社ワーカークラスに設定
                    BLGoodsCdChgUWork wkBLGoodsCdChgUWork = (BLGoodsCdChgUWork)paraObj;
                    //BLコード変換マスタワーカークラスからBLコード変換マスタクラスにコピー
                    blCodeChange = CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork(wkBLGoodsCdChgUWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGoodsCdChgUDB = null;
                //通信エラーは-1を戻す
                blCodeChange = null;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }
             
        /// <summary>
        ///BLコード変換マスタ登録・更新処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタの登録・更新を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Write(ref BLGoodsCdChgU blCodeChange)
        {
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();
            ArrayList paraList = new ArrayList();

            //BLコード変換マスタクラスからBLコード変換マスタワーククラスにメンバコピー
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            //BLコード変換マスタの登録・更新情報を設定
            paraList.Add(blCodeChangeWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {               
                //BLコード変換マスタ書き込み
                status = this._iBLGoodsCdChgUDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    blCodeChange = new BLGoodsCdChgU();

                    //BLコード変換マスタワーククラスからBLコード変換マスタクラスにメンバコピー
                    blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iBLGoodsCdChgUDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
    
        /// <summary>
        ///BLコード変換マスタ登録・更新処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換マスタクラス</param>
        /// <param name="parseBLGoodsCdChgU">企業コード</param>
        /// <param name="retTotalCnt">件数</param>
        /// <param name="readMode"></param>
        /// <param name="readCnt">件数</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタの登録・更新を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Search(ref List<BLGoodsCdChgU> blCodeChangeList, BLGoodsCdChgU parseBLGoodsCdChgU, out int retTotalCnt, int readMode, int readCnt, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            blCodeChangeList = null;
            Object objblCodeChangeWorkList = null;
            BLGoodsCdChgUWork parseBLGoodsCdChgUWork = null;
            ArrayList blCodeChangeWorkResultList = null;
            List<BLGoodsCdChgUWork> blCodeChangeWorkList = null;

            retTotalCnt = 0;
            parseBLGoodsCdChgUWork = new BLGoodsCdChgUWork();
            parseBLGoodsCdChgUWork.EnterpriseCode = parseBLGoodsCdChgU.EnterpriseCode;
            parseBLGoodsCdChgUWork.SectionCode = parseBLGoodsCdChgU.SectionCode;

            // 拠点アクセスクラス
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            // 拠点情報
            ArrayList secInfoSetList = null;
            status = _secInfoSetAcs.Search(out secInfoSetList, parseBLGoodsCdChgU.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSetList != null)
            {
                this._secInfoSetTable = new Hashtable();
                foreach (SecInfoSet secInfoSet in secInfoSetList)
                {
                    this._secInfoSetTable.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideSnm);

                }
            }

            //検索処理
            status = _iBLGoodsCdChgUDB.Search(ref objblCodeChangeWorkList, parseBLGoodsCdChgUWork, readMode, logicalMode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //結果を戻す
            blCodeChangeWorkResultList = objblCodeChangeWorkList as ArrayList;

            if (blCodeChangeWorkResultList != null)
            {
                blCodeChangeWorkList = new List<BLGoodsCdChgUWork>((BLGoodsCdChgUWork[])blCodeChangeWorkResultList.ToArray(typeof(BLGoodsCdChgUWork)));
            }
            if (blCodeChangeWorkList != null)
            {
                blCodeChangeList = new List<BLGoodsCdChgU>();
                foreach (BLGoodsCdChgUWork blCodeChangeWork in blCodeChangeWorkList)
                {
                    if (blCodeChangeWork.EnterpriseCode == parseBLGoodsCdChgU.EnterpriseCode &&
                        ((parseBLGoodsCdChgU.SectionCode == "") || (blCodeChangeWork.SectionCode.TrimEnd() == parseBLGoodsCdChgU.SectionCode.TrimEnd()) || (blCodeChangeWork.SectionCode.TrimEnd() == "")))
                    {
                        BLGoodsCdChgU blCodeChange = null;
                        blCodeChange = CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork(blCodeChangeWork);
                        blCodeChangeList.Add(blCodeChange);
                    }
                }
            }

            return status;
        }
    
        /// <summary>
        ///BLコード変換マスタ登録・更新処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタの登録・更新を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int LogicalDelete(ref BLGoodsCdChgU blCodeChange) 
        {

            ArrayList paraList = new ArrayList();
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            //BLコード変換マスタクラスからBLコード変換マスタワーククラスにメンバコピー
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            paraList.Add(blCodeChangeWork);

            Object objblCodeChangeWorkList = paraList;
           
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
  
              
            // 論理削除処理
            status = _iBLGoodsCdChgUDB.LogicalDelete(ref objblCodeChangeWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                paraList = (ArrayList)objblCodeChangeWorkList;

                blCodeChange = new BLGoodsCdChgU();

                //BLコード変換マスタワーククラスからBLコード変換マスタクラスにメンバコピー
                blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);

                return status;
            }               
            return status;
        }
    
        /// <summary>
        ///BLコード変換マスタ登録・更新処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタの登録・更新を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int Delete(ref BLGoodsCdChgU blCodeChange)
        {

            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            ArrayList paraList = new ArrayList();

            //BLコード変換マスタクラスからBLコード変換マスタワーククラスにメンバコピー
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            paraList.Add(blCodeChangeWork);

            Object objblCodeChangeWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        
            //物理削除処理
            status = _iBLGoodsCdChgUDB.Delete(ref objblCodeChangeWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objblCodeChangeWorkList;

                blCodeChange = new BLGoodsCdChgU();

                //BLコード変換マスタワーククラスからBLコード変換マスタクラスにメンバコピー
                blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);

                return status;
            }

            return status;
        }
    
        /// <summary>
        ///BLコード変換マスタ登録・更新処理
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタの登録・更新を行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref BLGoodsCdChgU blCodeChange)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            ArrayList paraList = new ArrayList();

            //BLコード変換マスタクラスからBLコード変換マスタワーククラスにメンバコピー
            blCodeChangeWork = CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(blCodeChange);

            paraList.Add(blCodeChangeWork);

            Object objblCodeChangeWorkList = paraList;
          
            //復活処理
            status = _iBLGoodsCdChgUDB.RevivalLogicalDelete(ref objblCodeChangeWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objblCodeChangeWorkList;

                blCodeChange = new BLGoodsCdChgU();

                //BLコード変換マスタワーククラスからBLコード変換マスタクラスにメンバコピー
                blCodeChange = this.CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork((BLGoodsCdChgUWork)paraList[0]);

                return status;
            }       

            return status;
        }
      
        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（BLコード変換マスタワーククラス⇒BLコード変換マスタクラス）
        /// </summary>
        /// <param name="blCodeChangeWork">BLコード変換マスタワーククラス</param>
        /// <returns>BLコード変換マスタクラス</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタワーククラスからBLコード変換マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        private BLGoodsCdChgU CopyToBLGoodsCdChgUFromBLGoodsCdChgUWork(BLGoodsCdChgUWork blCodeChangeWork)
        {
            BLGoodsCdChgU blCodeChange = new BLGoodsCdChgU();
            blCodeChange.CreateDateTime = blCodeChangeWork.CreateDateTime;
            blCodeChange.UpdateDateTime = blCodeChangeWork.UpdateDateTime;
            blCodeChange.EnterpriseCode = blCodeChangeWork.EnterpriseCode;
            blCodeChange.FileHeaderGuid = blCodeChangeWork.FileHeaderGuid;
            blCodeChange.UpdEmployeeCode = blCodeChangeWork.UpdEmployeeCode;
            blCodeChange.UpdAssemblyId1 = blCodeChangeWork.UpdAssemblyId1;
            blCodeChange.UpdAssemblyId2 = blCodeChangeWork.UpdAssemblyId2;
            blCodeChange.LogicalDeleteCode = blCodeChangeWork.LogicalDeleteCode;
            blCodeChange.SectionCode = blCodeChangeWork.SectionCode;
            blCodeChange.CustomerCode = blCodeChangeWork.CustomerCode;

            blCodeChange.PMBLGoodsCode = blCodeChangeWork.PMBLGoodsCode;
            blCodeChange.PMBLGoodsCodeDerivNo = blCodeChangeWork.PMBLGoodsCodeDerivNo;
            blCodeChange.SFBLGoodsCode = blCodeChangeWork.SFBLGoodsCode;
            blCodeChange.SFBLGoodsCodeDerivNo = blCodeChangeWork.SFBLGoodsCodeDerivNo;
            blCodeChange.BLGoodsFullName = blCodeChangeWork.BLGoodsFullName;
            blCodeChange.BLGoodsHalfName = blCodeChangeWork.BLGoodsHalfName;                  

            return blCodeChange;
        }
     
        /// <summary>
        /// クラスメンバーコピー処理（BLコード変換マスタクラス⇒BLコード変換マスタワーククラス）
        /// </summary>
        /// <param name="blCodeChange">BLコード変換マスタワーククラス</param>
        /// <returns>BLコード変換マスタクラス</returns>
        /// <remarks>
        /// <br>Note       :BLコード変換マスタクラスからBLコード変換マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012.08.01</br>
        /// </remarks>
        private BLGoodsCdChgUWork CopyToBLGoodsCdChgUWorkFromBLGoodsCdChgU(BLGoodsCdChgU blCodeChange)
        {
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            blCodeChangeWork.CreateDateTime = blCodeChange.CreateDateTime;
            blCodeChangeWork.UpdateDateTime = blCodeChange.UpdateDateTime;
            blCodeChangeWork.EnterpriseCode = blCodeChange.EnterpriseCode;
            blCodeChangeWork.FileHeaderGuid = blCodeChange.FileHeaderGuid;
            blCodeChangeWork.UpdEmployeeCode = blCodeChange.UpdEmployeeCode;
            blCodeChangeWork.UpdAssemblyId1 = blCodeChange.UpdAssemblyId1;
            blCodeChangeWork.UpdAssemblyId2 = blCodeChange.UpdAssemblyId2;
            blCodeChangeWork.LogicalDeleteCode = blCodeChange.LogicalDeleteCode;
            blCodeChangeWork.SectionCode = blCodeChange.SectionCode;
            blCodeChangeWork.CustomerCode = blCodeChange.CustomerCode;
            blCodeChangeWork.PMBLGoodsCode = blCodeChange.PMBLGoodsCode;
            blCodeChangeWork.PMBLGoodsCodeDerivNo = blCodeChange.PMBLGoodsCodeDerivNo;
            blCodeChangeWork.SFBLGoodsCode = blCodeChange.SFBLGoodsCode;
            blCodeChangeWork.SFBLGoodsCodeDerivNo = blCodeChange.SFBLGoodsCodeDerivNo;
            blCodeChangeWork.BLGoodsFullName = blCodeChange.BLGoodsFullName;
            blCodeChangeWork.BLGoodsHalfName = blCodeChange.BLGoodsHalfName;
            return blCodeChangeWork;
        }      
      
        #endregion
    }
}
