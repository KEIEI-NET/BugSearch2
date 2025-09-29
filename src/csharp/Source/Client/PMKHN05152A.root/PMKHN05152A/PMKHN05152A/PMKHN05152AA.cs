//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール 伝票番号変換アクセスクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS統合ツール 伝票番号変換アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール 伝票番号変換アクセスクラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/07</br>
    /// </remarks>
    public class SlipNoConvertAcs
    {
        #region -- Member --

        /// <summary>伝票番号変換リモートオブジェクト</summary>
        private ISlipNoConvertDB iSlipNoConvertDb;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　PM.NS伝票番号変換処理ツールアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :PM.NS伝票番号変換処理ツールアクセスクラスの初期処理を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public SlipNoConvertAcs()
        {
            // ISlipNoConvertDBの初期化を行います
            this.iSlipNoConvertDb = (ISlipNoConvertDB)MediationSlipNoConvertDB.GetSlipNoConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableMap">コード変換対象テーブルのリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 変換対象の情報を情報を取得します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public int GetTargetTableList(int secDiv,IDictionary<int, IList<SlpNoTargetTableListResult>> targetTableMap)
        {

            // ステータスの初期化
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            IList<SlpNoTargetTableList> retObjMap = new List<SlpNoTargetTableList>();
            Object retObj = retObjMap;

            // リモートオブジェクトを実施し、コード変換対象のリストを取得します。
            status = this.iSlipNoConvertDb.GetTargetTableList(secDiv,ref retObj);


            // ステータスが成功の場合は、XMLから取得した内容を変数に入れ替える
            if(status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IList<SlpNoTargetTableList>;

                foreach(SlpNoTargetTableList work in retObjMap)
                {
                    //同一キーが存在する
                    if (targetTableMap.ContainsKey(work.TargetNo))
                    {
                        targetTableMap[work.TargetNo].Add(this.SlpNoTargetTableListToSlpNoTargetTableListResult(work));
                    }
                    //同一キーが存在しない
                    else
                    {
                        targetTableMap.Add(work.TargetNo, new List<SlpNoTargetTableListResult>());
                        targetTableMap[work.TargetNo].Add(this.SlpNoTargetTableListToSlpNoTargetTableListResult(work));
                    }

                }
            }

            return status;
        }

        /// <summary>
        /// 伝票変換チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slpNoTargetListResult">チェック対象データ</param>
        /// <param name="checkInfo">チェック結果(True:データあり/False：データなし)</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に伝票番号変換可能かどうかチェックを行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public int CheckCOnvertSlipNo(string enterpriseCode, SlpNoConvertData slpNoConvertDt,out bool checkInfo)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // チェック情報の初期化
            checkInfo = false;
            //データを変換する
            Object retObj = this.SlpNoConvertDataToSlipNoConvertPrmInfoList(slpNoConvertDt);
            
            // リモートオブジェクトを実施しチェック結果を取得します
            status = this.iSlipNoConvertDb.CheckConvertSlipNo(enterpriseCode, retObj, ref checkInfo);

            return status;
        }

        /// <summary>
        /// 伝票番号変換処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slpNoTargetListResult">チェック対象データ</param>
        /// <param name="prcssngCnt">更新データ数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した変換条件元に伝票番号変換可能かどうかチェックを行います。<</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public int SlipNoConvert(string enterpriseCode, SlpNoConvertData slpNoConvertData, ref long prcssngCnt)
        {
            // ステータスの初期化
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prcssngCnt = 0;

            //データ変換を行う
            Object retObj = this.SlpNoConvertDataToSlipNoConvertPrmInfoList(slpNoConvertData);

            //リモートオブジェクトを実施しチェック結果を取得します
            status = this.iSlipNoConvertDb.ConvertSlipNo(enterpriseCode, retObj,ref prcssngCnt);

            return status;

        }

        #endregion

        #region -- Private Method --

        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="trgTblList">テーブル情報</param>
        /// <returns>テーブル情報</returns>
        /// <remarks>
        /// <br>Note       : SlpNoTargetTableListからSlpNoTargetTableListResultにデータを変換します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/11</br>
        /// </remarks>
        private SlpNoTargetTableListResult SlpNoTargetTableListToSlpNoTargetTableListResult(SlpNoTargetTableList trgTblList)
        {
            SlpNoTargetTableListResult trgTblLstRslt = new SlpNoTargetTableListResult();

            //番号コード(処理対象番号)
            trgTblLstRslt.TargetNo = trgTblList.TargetNo;
            //テーブルID(物理名)
            trgTblLstRslt.TargetTable = trgTblList.TargetTable;
            //テーブル名(論理名)
            trgTblLstRslt.TargetTableName = trgTblList.TargetTableName;
            //カラム名(物理名)
            trgTblLstRslt.TargetColum = trgTblList.TargetColum;
            //カラム名(論理名)
            trgTblLstRslt.TargetColumName = trgTblList.TargetColumName;
            //受注ステータスID
            trgTblLstRslt.TargetAcptStatusId = trgTblList.TargetAcptStatusId;
            //受注ステータスコード
            trgTblLstRslt.TargetAcptStatus = trgTblList.TargetAcptStatus;
            
            return trgTblLstRslt;
        }


        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="trgTblList">テーブル情報</param>
        /// <returns>テーブル情報</returns>
        /// <remarks>
        /// <br>Note       : SlpNoTargetTableListResultからSlpNoTargetTableListにデータを変換します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private SlipNoConvertPrmInfoList SlpNoConvertDataToSlipNoConvertPrmInfoList(SlpNoConvertData trgCvt)
        {
            SlipNoConvertPrmInfoList trgCvtInfo = new SlipNoConvertPrmInfoList();

            //番号コード(処理対象番号)
            trgCvtInfo.NoCode = trgCvt.NoCode;
            //テーブルID(物理名)
            trgCvtInfo.Table = trgCvt.Table;
            //テーブル名(論理名)
            trgCvtInfo.TableName = trgCvt.TableName;
            //カラム名(物理名)
            trgCvtInfo.Colum = trgCvt.Colum;
            //カラム名(論理名)
            trgCvtInfo.ColumName = trgCvt.ColumName;
            //受注ステータスID
            trgCvtInfo.AcptStatusId = trgCvt.AcptStatusId;
            //受注ステータスコード
            trgCvtInfo.AcptStatus = trgCvt.AcptStatus;
            //番号現在値
            trgCvtInfo.NoPresentVal = trgCvt.NoPresentVal;
            //設定開始番号
            trgCvtInfo.SettingStartNo = trgCvt.SettingStartNo;
            //設定終了番号
            trgCvtInfo.SettingEndNo = trgCvt.SettingEndNo;
            //番号増減値
            trgCvtInfo.NoIncDecWidth = trgCvt.NoIncDecWidth;

            return trgCvtInfo;
     
        }

        #endregion
    }
}
