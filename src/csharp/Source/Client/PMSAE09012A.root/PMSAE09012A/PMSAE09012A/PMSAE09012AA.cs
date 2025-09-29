//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス設定マスタメンテナンス
// プログラム概要   : オートバックス設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/08/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// オートバックス設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : オートバックス設定マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br></br>
    /// </remarks>
    public class SAndESettingAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private ISAndESettingDB _iSAndESettingDB = null;

        // ローカルＤＢモード
        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// <br></br>
        /// </remarks>
        public SAndESettingAcs()
        {
            // リモートオブジェクト取得
            this._iSAndESettingDB = (ISAndESettingDB)MediationSAndESettingDB.GetSAndESettingDB();
        }

        #endregion

        #region [ローカルアクセス用]
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        #endregion

        #region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="sAndESetting">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int Write(ref SAndESetting sAndESetting)
        {
            // UIデータクラス→ワーク
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);

            object objSAndESettingWork = sAndESettingWork;

            int status = 0;
            int writeMode = 0;

            // 書き込み処理
            status = this._iSAndESettingDB.Write(ref objSAndESettingWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                sAndESettingWork = objSAndESettingWork as SAndESettingWork;

                // クラス内メンバコピー
                sAndESetting = CopyToSAndESettingFromSAndESettingWork(sAndESettingWork);
            }

            return status;
        }

        #endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sAndESetting">オートバックス設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタの論理削除を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int LogicalDelete(ref SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);
            object objSAndESettingWork = sAndESettingWork;

            // 拠点情報論理削除
            int status = this._iSAndESettingDB.LogicalDelete(ref objSAndESettingWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                sAndESettingWork = objSAndESettingWork as SAndESettingWork;

                // クラス内メンバコピー
                sAndESetting = CopyToSAndESettingFromSAndESettingWork(sAndESettingWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="allDefSet">オートバックス設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタの物理削除を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int Delete(SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);

            // XMLへ変換し、文字列のバイナリ化
            object objSAndESettingWork = sAndESettingWork;

            // 拠点情報物理削除
            int status = this._iSAndESettingDB.Delete(ref objSAndESettingWork);

            return status;
        }

        #endregion

        #region -- 検索･復活処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オートバックス設定マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オートバックス設定マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>  
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            SAndESettingWork sAndESettingWork = new SAndESettingWork();

            sAndESettingWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList sAndESettingWorkList = new ArrayList();
            sAndESettingWorkList.Clear();

            object paraobj = sAndESettingWork;
            object retobj = null;

            status = this._iSAndESettingDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sAndESettingWorkList = retobj as ArrayList;

                foreach (SAndESettingWork wkSAndESettingWork in sAndESettingWorkList)
                {
                    retList.Add(CopyToSAndESettingFromSAndESettingWork(wkSAndESettingWork));
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オートバックス設定マスタ論理削除復活処理
        /// </summary>
        /// <param name="allDefSet">オートバックス設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタの復活を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        public int Revival(ref SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = CopyToSAndESettingWorkFromSAndESetting(sAndESetting);

            // XMLへ変換し、文字列のバイナリ化
            object objSAndESettingWork = sAndESettingWork;

            // 復活処理
            int status = this._iSAndESettingDB.RevivalLogicalDelete(ref objSAndESettingWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                sAndESettingWork = objSAndESettingWork as SAndESettingWork;

                // クラス内メンバコピー
                sAndESetting = CopyToSAndESettingFromSAndESettingWork(sAndESettingWork);

            }

            return status;
        }

        # endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（オートバックス設定マスタワーククラス⇒オートバックス設定マスタクラス）
        /// </summary>
        /// <param name="sAndESettingWork">オートバックス設定マスタワーククラス</param>
        /// <returns>オートバックス設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタワーククラスからオートバックス設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SAndESetting CopyToSAndESettingFromSAndESettingWork(SAndESettingWork sAndESettingWork)
        {
            SAndESetting sAndESetting = new SAndESetting();
            sAndESetting.CreateDateTime = sAndESettingWork.CreateDateTime;
            sAndESetting.UpdateDateTime = sAndESettingWork.UpdateDateTime;
            sAndESetting.EnterpriseCode = sAndESettingWork.EnterpriseCode;
            sAndESetting.FileHeaderGuid = sAndESettingWork.FileHeaderGuid;
            sAndESetting.UpdEmployeeCode = sAndESettingWork.UpdEmployeeCode;
            sAndESetting.UpdAssemblyId1 = sAndESettingWork.UpdAssemblyId1;
            sAndESetting.UpdAssemblyId2 = sAndESettingWork.UpdAssemblyId2;
            sAndESetting.LogicalDeleteCode = sAndESettingWork.LogicalDeleteCode;
            sAndESetting.SectionCode = sAndESettingWork.SectionCode;
            sAndESetting.CustomerCode = sAndESettingWork.CustomerCode;
            sAndESetting.AddresseeShopCd = sAndESettingWork.AddresseeShopCd;
            sAndESetting.SAndEMngCode = sAndESettingWork.SAndEMngCode;
            sAndESetting.ExpenseDivCd = sAndESettingWork.ExpenseDivCd;
            sAndESetting.DirectSendingCd = sAndESettingWork.DirectSendingCd;
            sAndESetting.AcptAnOrderDiv = sAndESettingWork.AcptAnOrderDiv;
            sAndESetting.DelivererCd = sAndESettingWork.DelivererCd;
            sAndESetting.DelivererNm = sAndESettingWork.DelivererNm;
            sAndESetting.DelivererAddress = sAndESettingWork.DelivererAddress;
            sAndESetting.DelivererPhoneNum = sAndESettingWork.DelivererPhoneNum;
            sAndESetting.TradCompName = sAndESettingWork.TradCompName;
            sAndESetting.TradCompSectName = sAndESettingWork.TradCompSectName;
            sAndESetting.PureTradCompCd = sAndESettingWork.PureTradCompCd;
            sAndESetting.PureTradCompRate = sAndESettingWork.PureTradCompRate;
            sAndESetting.PriTradCompCd = sAndESettingWork.PriTradCompCd;
            sAndESetting.PriTradCompRate = sAndESettingWork.PriTradCompRate;
            sAndESetting.ABGoodsCode = sAndESettingWork.ABGoodsCode;
            sAndESetting.CommentReservedDiv = sAndESettingWork.CommentReservedDiv;
            sAndESetting.GoodsMakerCd1 = sAndESettingWork.GoodsMakerCd1;
            sAndESetting.GoodsMakerCd2 = sAndESettingWork.GoodsMakerCd2;
            sAndESetting.GoodsMakerCd3 = sAndESettingWork.GoodsMakerCd3;
            sAndESetting.GoodsMakerCd4 = sAndESettingWork.GoodsMakerCd4;
            sAndESetting.GoodsMakerCd5 = sAndESettingWork.GoodsMakerCd5;
            sAndESetting.GoodsMakerCd6 = sAndESettingWork.GoodsMakerCd6;
            sAndESetting.GoodsMakerCd7 = sAndESettingWork.GoodsMakerCd7;
            sAndESetting.GoodsMakerCd8 = sAndESettingWork.GoodsMakerCd8;
            sAndESetting.GoodsMakerCd9 = sAndESettingWork.GoodsMakerCd9;
            sAndESetting.GoodsMakerCd10 = sAndESettingWork.GoodsMakerCd10;
            sAndESetting.GoodsMakerCd11 = sAndESettingWork.GoodsMakerCd11;
            sAndESetting.GoodsMakerCd12 = sAndESettingWork.GoodsMakerCd12;
            sAndESetting.GoodsMakerCd13 = sAndESettingWork.GoodsMakerCd13;
            sAndESetting.GoodsMakerCd14 = sAndESettingWork.GoodsMakerCd14;
            sAndESetting.GoodsMakerCd15 = sAndESettingWork.GoodsMakerCd15;
            sAndESetting.PartsOEMDiv = sAndESettingWork.PartsOEMDiv;
            sAndESetting.SectionName = sAndESettingWork.SectionName;
            sAndESetting.CustomerName = sAndESettingWork.CustomerName;

            return sAndESetting;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（オートバックス設定マスタクラス⇒オートバックス設定マスタワーククラス）
        /// </summary>
        /// <param name="allDefSet">オートバックス設定マスタクラス</param>
        /// <returns>オートバックス設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : オートバックス設定マスタクラスからオートバックス設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        /// </remarks>
        private SAndESettingWork CopyToSAndESettingWorkFromSAndESetting(SAndESetting sAndESetting)
        {
            SAndESettingWork sAndESettingWork = new SAndESettingWork();
            sAndESettingWork.CreateDateTime = sAndESetting.CreateDateTime;
            sAndESettingWork.UpdateDateTime = sAndESetting.UpdateDateTime;
            sAndESettingWork.EnterpriseCode = sAndESetting.EnterpriseCode;
            sAndESettingWork.FileHeaderGuid = sAndESetting.FileHeaderGuid;
            sAndESettingWork.UpdEmployeeCode = sAndESetting.UpdEmployeeCode;
            sAndESettingWork.UpdAssemblyId1 = sAndESetting.UpdAssemblyId1;
            sAndESettingWork.UpdAssemblyId2 = sAndESetting.UpdAssemblyId2;
            sAndESettingWork.LogicalDeleteCode = sAndESetting.LogicalDeleteCode;
            sAndESettingWork.SectionCode = sAndESetting.SectionCode;
            sAndESettingWork.CustomerCode = sAndESetting.CustomerCode;
            sAndESettingWork.AddresseeShopCd = sAndESetting.AddresseeShopCd;
            sAndESettingWork.SAndEMngCode = sAndESetting.SAndEMngCode;
            sAndESettingWork.ExpenseDivCd = sAndESetting.ExpenseDivCd;
            sAndESettingWork.DirectSendingCd = sAndESetting.DirectSendingCd;
            sAndESettingWork.AcptAnOrderDiv = sAndESetting.AcptAnOrderDiv;
            sAndESettingWork.DelivererCd = sAndESetting.DelivererCd;
            sAndESettingWork.DelivererNm = sAndESetting.DelivererNm;
            sAndESettingWork.DelivererAddress = sAndESetting.DelivererAddress;
            sAndESettingWork.DelivererPhoneNum = sAndESetting.DelivererPhoneNum;
            sAndESettingWork.TradCompName = sAndESetting.TradCompName;
            sAndESettingWork.TradCompSectName = sAndESetting.TradCompSectName;
            sAndESettingWork.PureTradCompCd = sAndESetting.PureTradCompCd;
            sAndESettingWork.PureTradCompRate = sAndESetting.PureTradCompRate;
            sAndESettingWork.PriTradCompCd = sAndESetting.PriTradCompCd;
            sAndESettingWork.PriTradCompRate = sAndESetting.PriTradCompRate;
            sAndESettingWork.ABGoodsCode = sAndESetting.ABGoodsCode;
            sAndESettingWork.CommentReservedDiv = sAndESetting.CommentReservedDiv;
            sAndESettingWork.GoodsMakerCd1 = sAndESetting.GoodsMakerCd1;
            sAndESettingWork.GoodsMakerCd2 = sAndESetting.GoodsMakerCd2;
            sAndESettingWork.GoodsMakerCd3 = sAndESetting.GoodsMakerCd3;
            sAndESettingWork.GoodsMakerCd4 = sAndESetting.GoodsMakerCd4;
            sAndESettingWork.GoodsMakerCd5 = sAndESetting.GoodsMakerCd5;
            sAndESettingWork.GoodsMakerCd6 = sAndESetting.GoodsMakerCd6;
            sAndESettingWork.GoodsMakerCd7 = sAndESetting.GoodsMakerCd7;
            sAndESettingWork.GoodsMakerCd8 = sAndESetting.GoodsMakerCd8;
            sAndESettingWork.GoodsMakerCd9 = sAndESetting.GoodsMakerCd9;
            sAndESettingWork.GoodsMakerCd10 = sAndESetting.GoodsMakerCd10;
            sAndESettingWork.GoodsMakerCd11 = sAndESetting.GoodsMakerCd11;
            sAndESettingWork.GoodsMakerCd12 = sAndESetting.GoodsMakerCd12;
            sAndESettingWork.GoodsMakerCd13 = sAndESetting.GoodsMakerCd13;
            sAndESettingWork.GoodsMakerCd14 = sAndESetting.GoodsMakerCd14;
            sAndESettingWork.GoodsMakerCd15 = sAndESetting.GoodsMakerCd15;
            sAndESettingWork.PartsOEMDiv = sAndESetting.PartsOEMDiv;
            sAndESettingWork.CustomerName = sAndESetting.CustomerName;
            sAndESettingWork.SectionName = sAndESetting.SectionName;

            return sAndESettingWork;

        }

        # endregion

    }
}
