//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新処理
// プログラム概要   : 商品バーコード更新アクセサ
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品バーコード更新アクセサクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード更新アクセサクラスの定義と実装</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    public class PrmGoodsBarCodeRevnUpdateAcs
    {
        #region ■ Sub Class

        /// <summary>
        /// 商品バーコード更新アクセサ独自の結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
              ReadCountMaxOrver = -1    // 取得可能最大レコード数超過
            , FatalError = 1000         // 致命的エラー
        };

        /// <summary>
        /// バーコード更新区分列挙体
        /// </summary>
        public enum BarcodeUpdateKndDiv
        {
              WithoutUserUpdate = 0     // ユーザー更新以外
            , ALL = 1                   // 全て
        };

        #endregion //■ Sub Class

        #region ■ Delegate

        /// <summary>
        /// 抽出件数取得処理デリゲート
        /// </summary>
        /// <param name="targetList">取得対象パラメータリスト</param>
        /// <param name="count">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出件数取得処理のデリゲート宣言</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        delegate int GetSearchCountDelegate( object targetList, out int count );

        /// <summary>
        /// 抽出処理デリゲート
        /// </summary>
        /// <param name="targetList">取得対象パラメータリスト</param>
        /// <param name="resultList">抽出情報リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出処理のデリゲート宣言</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        delegate int SearchDelegate( object targetList, out ArrayList resultList );

        #endregion //■ Delegate

        #region ■ Const

        /// <summary>
        /// 優良メーカーコード下限値
        /// </summary>
        public const int PrmMakerCodeMinimum = 1000;

        /// <summary>
        /// 優良メーカーコード上限値
        /// </summary>
        public const int PrmMakerCodeMaximum = 9999;

        /// <summary>
        /// 取得可能最大レコード数
        /// </summary>
        private const int MaxExecuteCount = 20000;

        /// <summary>
        /// 論理削除区分：有効
        /// </summary>
        private const int LogicalDeleteCodeValidity = 0;

        /// <summary>
        /// チェックデジット区分デフォルト値[0:なし]
        /// </summary>
        private const int CheckdigitCodeDefault = 0;

        /// <summary>
        /// 提供データ区分デフォルト値[1:提供データ]
        /// </summary>
        private const int OfferDataDivDefault = 1;

        /// <summary>
        /// バーコード更新区分
        /// </summary>
        private const int BarcodeUpdateKndDivDefault = (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.ALL;

        #region //操作ログ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string ApplicationName = "商品バーコード更新処理";

        /// <summary>
        /// オペレーションコードデフォルト
        /// </summary>
        private const int OperationCodeDefault = 0;

        /// <summary>
        ///  オペレーションステータスデフォルト
        /// </summary>
        private const int OperationStatusDefault = 0;

        /// <summary>
        /// バーコード更新区分要素文字列：ユーザー更新以外
        /// </summary>
        private static readonly string BarcodeUpdateKndNameWithoutUserUpdate = "ユーザー更新以外";

        /// <summary>
        /// バーコード更新区分要素文字列：全て
        /// </summary>
        private static readonly string BarcodeUpdateKndNameAll = "全て";

        /// <summary>
        /// 更新処理結果ログ文字列：メーカー範囲
        /// </summary>
        private static readonly string UpdateLogTextMakerRange = "メーカー：{0:0000} ～ {1:0000}";

        /// <summary>
        /// 更新処理結果ログ文字列：中分類
        /// </summary>
        private static readonly string UpdateLogTextGoodMGroup = " 中分類：{0:0000}";

        /// <summary>
        /// 更新処理結果ログ文字列：BLコード
        /// </summary>
        private static readonly string UpdateLogTextBLGoodsCode = " BLコード：{0:00000}";

        /// <summary>
        /// 更新処理結果ログ文字列：バーコード更新区分
        /// </summary>
        private static readonly string UpdateLogTextBarcodeUpdateKnd = " バーコード更新区分：{0}";

        /// <summary>
        /// 更新処理結果ログ文字列：処理件数
        /// </summary>
        private static readonly string UpdateLogTextResult = " より、商品バーコードマスタには、{0} 件を更新しました。";
        #endregion //操作ログ

        #endregion //■ Const

        #region ■ Private Field

        /// <summary>
        /// 商品バーコード更新リモートオブジェクトインターフェース
        /// </summary>
        private IPrmGoodsBarCodeRevnUpdateDB IPrmGoodsBrcdUpdDB = null;

        /// <summary>
        /// 優良部品バーコード情報抽出リモートオブジェクトインターフェース
        /// </summary>
        private  IOfferPrmPartsBrcdInfo IOfferPrmPartsBrcdDB = null;

        /// <summary>
        /// オペレーションログ出力クラス
        /// </summary>
        private OperationHistoryLog OperationHistLogger;

        /// <summary>
        /// アセンブリID
        /// </summary>
        private string AssemblyId;

        #endregion //■ Private Field

        #region  ■ Constructor

        /// <summary>
        /// 商品バーコード更新アクセサクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新アクセサクラスのインスタンスを生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public PrmGoodsBarCodeRevnUpdateAcs()
        {
            if (this.OperationHistLogger == null)
                this.OperationHistLogger = new OperationHistoryLog();

            // アセンブリ名をフルパスで取得
            string fullAssemblyName = this.GetType().Assembly.Location;
            // アセンブリ名のみを取得
            this.AssemblyId = System.IO.Path.GetFileName( fullAssemblyName );
        }
        #endregion

        #region ■ Public Method

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザー登録分）更新
        /// </summary>
        /// <param name="updateParam">更新パラメータ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 更新パラメータの条件に合致する優良部品バーコードマスタのデータを取得し、商品バーコード関連付けマスタ（ユーザーデータ）テーブルを更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public int Update(ref PrmGoodsBrcdUpdateParamWork updateParam, bool autoFlag)
        {
            return this.UpdateProc(ref updateParam, autoFlag);
        }

        /// <summary>
        /// オペレーションログ出力
        /// </summary>
        /// <param name="processName">処理名称</param>
        /// <param name="stepName">処理区分</param>
        /// <param name="data">更新内容</param>
        /// <remarks>
        /// <br>Note       : 引数の内容でオペレーションログに操作ログを出力する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public void WriteOperationLog( string processName, string stepName, string data )
        {
            const int LogDataMassageMaxLength = 500;
            const int LogOperationDataMaxLength = 80;

            if (LoginInfoAcquisition.Employee == null)
            {
                //自動の場合、商品バーコード更新リモートクラスの操作ログ出力メソッドでログ出力する。

                OprtnHisLogWork writeParam = new OprtnHisLogWork();
                writeParam.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                writeParam.LogDataObjClassID = this.AssemblyId;
                writeParam.LogDataCreateDateTime = DateTime.Now;
                writeParam.LogDataKindCd = (int)LogDataKind.SystemLog;
                writeParam.LogDataObjAssemblyID = this.AssemblyId;
                writeParam.LogDataObjAssemblyNm = PrmGoodsBarCodeRevnUpdateAcs.ApplicationName;
                writeParam.LogDataObjProcNm = processName;
                writeParam.LogOperationStatus = PrmGoodsBarCodeRevnUpdateAcs.OperationStatusDefault;
                writeParam.LogDataMassage = stepName;
                if ( !string.IsNullOrEmpty(stepName) && stepName.Length > LogDataMassageMaxLength)
                {
                    writeParam.LogDataMassage = stepName.Substring( 0, LogDataMassageMaxLength );
                }
                writeParam.LogOperationData = data;
                if ( !string.IsNullOrEmpty(data) && data.Length > LogOperationDataMaxLength)
                {
                    writeParam.LogDataMassage = data.Substring( 0, LogOperationDataMaxLength );
                }

                // 優良部品バーコード更新リモートオブジェクトの取得
                if (this.IPrmGoodsBrcdUpdDB == null)
                {
                    this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
                }
                this.IPrmGoodsBrcdUpdDB.WriteOprtnHisLog( writeParam );
            }
            else
            {
                //手動の場合、操作ログアクセサでログ出力する。

                this.OperationHistLogger.WriteOperationLog(
                    this,
                    DateTime.Now,
                    LogDataKind.SystemLog,
                    this.AssemblyId,
                    PrmGoodsBarCodeRevnUpdateAcs.ApplicationName,
                    processName,
                    PrmGoodsBarCodeRevnUpdateAcs.OperationCodeDefault,
                    PrmGoodsBarCodeRevnUpdateAcs.OperationStatusDefault,
                    stepName,
                    data
                );
            }
        }

        /// <summary>
        /// 更新処理結果ログ文字列生成
        /// </summary>
        /// <param name="updateParam">更新パラメータ</param>
        /// <returns>ログ文字列</returns>
        /// <remarks>
        /// <br>Note       : 更新処理終了時にログに出力するための文字列を生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public string CreateUpdateLogText( ref PrmGoodsBrcdUpdateParamWork updateParam )
        {
            StringBuilder logText = new StringBuilder();
            if (updateParam.MakerCdST > 0)
                logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextMakerRange, updateParam.MakerCdST, updateParam.MakerCdED );
            if (updateParam.GoodMGroup > 0)
                logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextGoodMGroup, updateParam.GoodMGroup );
            if (updateParam.BLGoodsCode > 0)
                logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextBLGoodsCode, updateParam.BLGoodsCode );
            logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextBarcodeUpdateKnd, updateParam.BarcodeUpdateKndDiv == (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.ALL
                ? PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndNameAll : PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndNameWithoutUserUpdate );
            logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextResult, updateParam.RecordCnt );

            return logText.ToString();
        }

        #endregion ■ Public Method

        #region ■ Private Method

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザー登録分）更新実体
        /// </summary>
        /// <param name="updateParam">更新パラメータ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 更新パラメータの条件に合致する優良部品バーコードマスタのデータを取得し、商品バーコード関連付けマスタ（ユーザーデータ）テーブルを更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int UpdateProc(ref PrmGoodsBrcdUpdateParamWork updateParam, bool autoFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 更新対象メーカー・BLコードリスト
            ArrayList prmPartsTargetList = null;

            // 提供DB側優良部品バーコード情報リスト
            ArrayList offerPrmPartsBrcdList = null;

            // ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）情報リスト
            ArrayList prmGoodsBrcdList = null;

            //
            // 優良設定マスタ取得パラメータの生成
            //
            // ※引数で渡された更新パラメータをリモート用抽出パラメータに変換する。
            PrmSetUParamForBrcdWork searchParam = this.CopyToRemortSearchParamFromUIUpdateParam( ref updateParam );

            //
            // 優良設定マスタリスト取得
            //
            status = this.SearchPrmPartsInfoList( ref searchParam, out prmPartsTargetList );
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //
            // 提供DB側優良部品バーコード情報取得
            //
            status = this.SearchOfferPrmPartsBrcdList( ref prmPartsTargetList, out offerPrmPartsBrcdList );
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //
            // ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）情報取得
            //
            status = this.SearchPrmGoodsBrcdList( ref prmPartsTargetList, out prmGoodsBrcdList );
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                return status;
            }

            //
            // ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）更新用リストの生成
            //
            ArrayList updateTargetList = null;
            StringBuilder resultTextList = null;
            status = CreateUpdateList(
                  ref updateParam
                , ref prmGoodsBrcdList
                , ref offerPrmPartsBrcdList
                , out updateTargetList
                , out resultTextList
                , autoFlag);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //
            // ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）の更新
            //
            int execCount = 0;
            status = UpdatePrmGoodsBrcdList( ref updateTargetList, updateParam.BarcodeUpdateKndDiv, out execCount );
            updateParam.RecordCnt = execCount;

            return status;
        }

        #region 【ユーザーDB】優良設定マスタリスト取得
        
        /// <summary>
        /// リモート用優良部品バーコード情報抽出条件パラメータ生成
        /// </summary>
        /// <param name="updateParam">UI用優良設定検索条件パラメータ</param>
        /// <returns>リモート用優良部品バーコード情報抽出条件パラメータ</returns>
        /// <remarks>
        /// <br>Note       : UI用優良設定検索条件パラメータワークの内容を持つリモート用優良部品バーコード情報抽出条件パラメータを生成する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private PrmSetUParamForBrcdWork CopyToRemortSearchParamFromUIUpdateParam( ref PrmGoodsBrcdUpdateParamWork updateParam )
        {
            PrmSetUParamForBrcdWork searchParam = new PrmSetUParamForBrcdWork();

            searchParam.EnterpriseCode = updateParam.EnterpriseCode;
            searchParam.MakerCdST = updateParam.MakerCdST;
            searchParam.MakerCdED = updateParam.MakerCdED;
            searchParam.GoodMGroup = updateParam.GoodMGroup;
            searchParam.BLGoodsCode = updateParam.BLGoodsCode;

            return searchParam;
        }
        
        /// <summary>
        /// 優良設定マスタリスト取得
        /// </summary>
        /// <param name="searchParam">抽出パラメータ</param>
        /// <param name="prmPartsTargetList">優良設定情報リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良設定情報をリストで取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchPrmPartsInfoList( ref PrmSetUParamForBrcdWork searchParam, out ArrayList prmPartsTargetList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            prmPartsTargetList = null;

            // 優良部品バーコード更新リモートオブジェクトの取得
            if (this.IPrmGoodsBrcdUpdDB == null)
            {
                this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
            }

            // 優良設定マスタ検索
            object getPrmPartsInfoListResult = null;
            status = this.IPrmGoodsBrcdUpdDB.GetPrmPartsInfoList( ref searchParam, out getPrmPartsInfoListResult );

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                prmPartsTargetList = getPrmPartsInfoListResult as ArrayList;
                if (prmPartsTargetList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else if (prmPartsTargetList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else if (!( prmPartsTargetList[0] is GetPrmPartsBrcdParaWork ))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        #endregion //【ユーザーDB】優良設定マスタリスト取得

        #region 【提供DB】優良部品バーコード情報取得

        /// <summary>
        /// 【提供DB】優良部品バーコード情報取得
        /// </summary>
        /// <param name="prmPartsTargetList">取得対象パラメータリスト</param>
        /// <param name="offerPrmPartsBrcdList">優良部品バーコード情報リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 提供DBから取得対象パラメータリストの条件に合致する優良部品バーコード情報をリストで取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchOfferPrmPartsBrcdList( ref ArrayList prmPartsTargetList, out ArrayList offerPrmPartsBrcdList )
        {
            offerPrmPartsBrcdList = null;
            return this.SearchListProc( ref prmPartsTargetList, this.GetSearchOfferPrmPartsBrcdCount, this.SearchOfferPrmPartsBrcdListMethod, out offerPrmPartsBrcdList, true );
        }

        /// <summary>
        /// 優良部品バーコード情報抽出件数取得
        /// </summary>
        /// <param name="searchParamList">取得対象パラメータリスト</param>
        /// <param name="count">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出リモートの優良部品バーコード情報抽出件数取得処理を実行する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchOfferPrmPartsBrcdCount( object prmPartsTargetList, out int count )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            count = -1;

            // 優良部品バーコード情報抽出リモートオブジェクトインターフェースの取得
            if (this.IOfferPrmPartsBrcdDB == null)
            {
                this.IOfferPrmPartsBrcdDB = MediationOfferPrmPartsWidthBrcdInfo.GetOfferPrmPartsWidthBrcdInfo();
            }

            // 優良部品バーコード情報抽出件数取得
            object paramList = (object)prmPartsTargetList;
            status = this.IOfferPrmPartsBrcdDB.GetSearchCount( ref paramList, out count );

            return status;
        }

        /// <summary>
        /// 優良部品バーコード情報抽出処理
        /// </summary>
        /// <param name="prmPartsTargetList">取得対象パラメータリスト</param>
        /// <param name="prmGoodsBrcdList">優良部品バーコード情報リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出リモートの優良部品バーコード情報抽出処理を実行する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchOfferPrmPartsBrcdListMethod( object prmPartsTargetList, out ArrayList offerPrmPartsBrcdList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            offerPrmPartsBrcdList = null;

            // 優良部品バーコード情報抽出リモートオブジェクトインターフェースの取得
            if (this.IOfferPrmPartsBrcdDB == null)
            {
                this.IOfferPrmPartsBrcdDB = MediationOfferPrmPartsWidthBrcdInfo.GetOfferPrmPartsWidthBrcdInfo();
            }

            // 商品バーコード関連付けマスタ（ユーザーデータ）抽出
            object resultList = null;
            status = this.IOfferPrmPartsBrcdDB.Search( ref prmPartsTargetList, out resultList );
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                offerPrmPartsBrcdList = resultList as ArrayList;
                if (offerPrmPartsBrcdList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else if (offerPrmPartsBrcdList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else if (!( offerPrmPartsBrcdList[0] is RettPrmPartsBrcdInfoWork ))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        #endregion //【提供DB】優良部品バーコード情報取得

        #region 【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）情報取得

        /// <summary>
        /// 【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）情報取得
        /// </summary>
        /// <param name="prmPartsTargetList">取得対象パラメータリスト</param>
        /// <param name="offerPrmPartsBrcdList">優良部品バーコード情報リスト</param>
        /// <param name="doRecursionFlag">再帰呼出指定フラグ[true:する、false:しない]</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : ユーザーDBから取得対象パラメータリストの条件に合致する 商品バーコード関連付けマスタ（ユーザーデータ）情報をリストで取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchPrmGoodsBrcdList( ref ArrayList prmPartsTargetList, out ArrayList prmGoodsBrcdList )
        {
            prmGoodsBrcdList = null;
            return this.SearchListProc( ref prmPartsTargetList, this.GetSearchPrmGoodsBrcdCount, this.SearchPrmGoodsBrcdListMethod, out prmGoodsBrcdList, true );
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得
        /// </summary>
        /// <param name="searchParamList">取得対象パラメータリスト</param>
        /// <param name="count">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新リモートの商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得処理を実行する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchPrmGoodsBrcdCount( object prmPartsTargetList, out int count)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            count = -1;

            // 商品バーコード更新リモートオブジェクトインターフェースの取得
            if (this.IPrmGoodsBrcdUpdDB == null)
            {
                this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
            }

            // 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得
            status = this.IPrmGoodsBrcdUpdDB.GetSearchCount( ref prmPartsTargetList, out count );

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出処理
        /// </summary>
        /// <param name="prmPartsTargetList">取得対象パラメータリスト</param>
        /// <param name="prmGoodsBrcdList">商品バーコード関連付けマスタ（ユーザーデータ）リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新リモートの商品バーコード関連付けマスタ（ユーザーデータ）抽出処理を実行する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchPrmGoodsBrcdListMethod( object prmPartsTargetList, out ArrayList prmGoodsBrcdList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            prmGoodsBrcdList = null;

            // 商品バーコード更新リモートオブジェクトインターフェースの取得
            if (this.IPrmGoodsBrcdUpdDB == null)
            {
                this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
            }

            // 商品バーコード関連付けマスタ（ユーザーデータ）抽出
            object resultList = null;
            status = this.IPrmGoodsBrcdUpdDB.Search( ref prmPartsTargetList, out resultList );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                prmGoodsBrcdList = resultList as ArrayList;
                if (prmGoodsBrcdList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else if (prmGoodsBrcdList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else if (!( prmGoodsBrcdList[0] is GoodsBarCodeRevnWork ))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        #endregion //【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）情報取得

        #region 情報取得サブメソッド

        /// <summary>
        /// 再帰型情報リスト取得処理
        /// </summary>
        /// <param name="searchParamList">取得対象パラメータリスト</param>
        /// <param name="getSearchCountMethod">抽出件数取得処理メソッド</param>
        /// <param name="searchMethod">抽出処理メソッド</param>
        /// <param name="resultList">取得情報リスト</param>
        /// <param name="doRecursionFlag">再帰呼出指定フラグ[true:する、false:しない]</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 取得対象パラメータリストの条件に合致する情報をリストで取得する</br>
        /// <br>             実行する抽出件数取得処理メソッド及び抽出処理メソッドはパラメータで指定する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchListProc( 
            ref ArrayList searchParamList
            , PrmGoodsBarCodeRevnUpdateAcs.GetSearchCountDelegate getSearchCountMethod
            , PrmGoodsBarCodeRevnUpdateAcs.SearchDelegate searchMethod
            , out ArrayList resultList
            , bool doRecursionFlag )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int count = 0;

            resultList = null;

            // 抽出件数取得
            status = getSearchCountMethod((object)searchParamList, out count );

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            if (count == 0)
            {
                resultList = new ArrayList();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else if (count > PrmGoodsBarCodeRevnUpdateAcs.MaxExecuteCount)
            {
                status = (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver;
                // 抽出件数が取得可能最大レコード数を超える場合
                if (!doRecursionFlag)
                {
                    // 再帰フラグがfalseの場合、戻り値として取得可能最大レコード数超過を返す
                    return status;
                }
                else
                {
                    // 再帰フラグがfalseの場合、抽出条件をメーカー毎に分割して取得する。
                    resultList = new ArrayList();

                    // 抽出条件をメーカー毎に分割
                    List<ArrayList> splitParam = this.SplitPrmPartsTargetList( ref searchParamList );
                    if (splitParam == null || splitParam.Count <= 0)
                    {
                        // 分割できなかった場合、処理中断
                        return status;
                    }

                    // メーカー毎に抽出する
                    for (int index = 0; index < splitParam.Count; index++)
                    {
                        ArrayList paramList = splitParam[index];
                        ArrayList splitResultList = null;

                        //本メソッドを再帰呼び出し
                        status = this.SearchListProc( ref paramList, getSearchCountMethod, searchMethod, out splitResultList, false );
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            resultList.AddRange( splitResultList );
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            continue;
                        }
                        else
                        {
                            resultList = null;
                            return status;
                        }
                    }
                }
            }
            else
            {
                // 抽出件数が取得可能最大レコード数以内の場合、抽出処理実行
                status = searchMethod( (object)searchParamList, out resultList);
            }

            return status;
        }
        
        /// <summary>
        /// メーカー別取得対象パラメータリスト生成
        /// </summary>
        /// <param name="prmPartsTargetList">取得対象パラメータリスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 取得対象パラメータリストからメーカー別の取得対象パラメータリストを生成する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private List<ArrayList> SplitPrmPartsTargetList( ref ArrayList prmPartsTargetList )
        {
            List<ArrayList> splitList = new List<ArrayList>();
            Dictionary<int, int> splitDic = new Dictionary<int, int>();

            foreach (object element in prmPartsTargetList)
            {
                GetPrmPartsBrcdParaWork work = element as GetPrmPartsBrcdParaWork;
                if (work == null)
                {
                    continue;
                }
                int index = -1;
                if (!splitDic.ContainsKey( work.MakerCode ))
                {
                    splitList.Add( new ArrayList() );
                    splitDic.Add( work.MakerCode, splitList.Count - 1 );
                }
                index = splitDic[work.MakerCode];
                GetPrmPartsBrcdParaWork copyWork = new GetPrmPartsBrcdParaWork();
                copyWork.EnterpriseCode = work.EnterpriseCode;
                copyWork.MakerCode = work.MakerCode;
                copyWork.BLGoodsCode = work.BLGoodsCode;
                splitList[index].Add( copyWork );
            }

            return splitList;
        }

        #endregion //情報取得サブメソッド

        #region 【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）更新

        /// <summary>
        /// 【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）更新用リスト生成
        /// </summary>
        /// <param name="updateParam">更新パラメータ</param>
        /// <param name="prmGoodsBrcdList">ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）リスト</param>
        /// <param name="offerPrmPartsBrcdList">提供DB側優良部品バーコード情報リスト</param>
        /// <param name="updateList">更新用ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）リスト</param>
        /// <param name="resultTextList">更新リスト作成時要素別判定結果（未使用）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 提供DB側優良部品バーコード情報リストとユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）リストから</br>
        /// <br>             ユーザーDB側商品バーコード関連付けマスタ（ユーザーデータ）更新用のリスト（以下、更新リスト と表記）を生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int CreateUpdateList( 
              ref PrmGoodsBrcdUpdateParamWork updateParam
            , ref ArrayList prmGoodsBrcdList
            , ref ArrayList offerPrmPartsBrcdList
            , out ArrayList updateList
            , out StringBuilder resultTextList
            , bool autoFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            updateList = null;
            resultTextList = new StringBuilder();

            //offerPrmPartsBrcdListの各要素について、検索を行う
            for (int index = 0; index < offerPrmPartsBrcdList.Count; index++)
            {
                //更新用商品バーコード関連付けマスタ（ユーザーデータ）情報初期化
                GoodsBarCodeRevnWork updateWork = null;

                //優良部品バーコード情報の取得
                RettPrmPartsBrcdInfoWork offerPrmPartsBrcd = offerPrmPartsBrcdList[index] as RettPrmPartsBrcdInfoWork;
                if (offerPrmPartsBrcd == null)
                {
                    continue;
                }

                //prmGoodsBrcdListの要素から優良部品バーコード情報に合致する要素を取得する
                foreach (object userWork in prmGoodsBrcdList)
                {
                    //商品バーコード関連付けマスタ（ユーザーデータ）情報の取得
                    GoodsBarCodeRevnWork prmGoodsBrcd = userWork as GoodsBarCodeRevnWork;
                    if (prmGoodsBrcd == null)
                    {
                        continue;
                    }
                    //対象の優良部品バーコード情報と合致する商品バーコード関連付けマスタ（ユーザーデータ）情報か否か比較する
                    if (prmGoodsBrcd.GoodsMakerCd != offerPrmPartsBrcd.PartsMakerCd)
                    {
                        continue;
                    }
                    if (prmGoodsBrcd.GoodsNo != offerPrmPartsBrcd.PrimePartsNoWithH)
                    {
                        continue;
                    }
                    //対象の優良部品バーコード情報と合致する商品バーコード関連付けマスタ（ユーザーデータ）情報か存在した場合、
                    //更新用商品バーコード関連付けマスタ（ユーザーデータ）情報を生成する
                    updateWork = new GoodsBarCodeRevnWork();
                    updateWork.CreateDateTime = prmGoodsBrcd.CreateDateTime;
                    updateWork.UpdateDateTime = prmGoodsBrcd.UpdateDateTime;
                    updateWork.EnterpriseCode = prmGoodsBrcd.EnterpriseCode;
                    updateWork.FileHeaderGuid = prmGoodsBrcd.FileHeaderGuid;
                    updateWork.UpdEmployeeCode = prmGoodsBrcd.UpdEmployeeCode;
                    updateWork.UpdAssemblyId1 = prmGoodsBrcd.UpdAssemblyId1;
                    updateWork.UpdAssemblyId2 = prmGoodsBrcd.UpdAssemblyId2;
                    updateWork.LogicalDeleteCode = prmGoodsBrcd.LogicalDeleteCode;
                    updateWork.GoodsMakerCd = prmGoodsBrcd.GoodsMakerCd;
                    updateWork.GoodsNo = prmGoodsBrcd.GoodsNo;
                    updateWork.GoodsBarCode = prmGoodsBrcd.GoodsBarCode;
                    updateWork.GoodsBarCodeKind = prmGoodsBrcd.GoodsBarCodeKind;
                    updateWork.CheckdigitCode = prmGoodsBrcd.CheckdigitCode;
                    updateWork.OfferDate = prmGoodsBrcd.OfferDate;
                    updateWork.OfferDataDiv = prmGoodsBrcd.OfferDataDiv;
                    break;
                }

                //更新用商品バーコード関連付けマスタ（ユーザーデータ）情報が生成されているか否かで処理を振り分け
                if (updateWork == null)
                {
                    //更新用商品バーコード関連付けマスタ（ユーザーデータ）情報が生成されていない場合、新規追加
                    updateWork = new GoodsBarCodeRevnWork();

                    if (autoFlag)
                    {
                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)updateWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    updateWork.EnterpriseCode = updateParam.EnterpriseCode;
                    updateWork.UpdAssemblyId1 = updateWork.UpdAssemblyId2;
                    updateWork.UpdEmployeeCode = updateWork.UpdEmployeeCode;
                    updateWork.LogicalDeleteCode = PrmGoodsBarCodeRevnUpdateAcs.LogicalDeleteCodeValidity;
                    updateWork.GoodsMakerCd = offerPrmPartsBrcd.PartsMakerCd;
                    updateWork.GoodsNo = offerPrmPartsBrcd.PrimePartsNoWithH;
                    updateWork.GoodsBarCode = offerPrmPartsBrcd.PrimePartsBarCode;
                    updateWork.GoodsBarCodeKind = offerPrmPartsBrcd.PrimePrtsBarCdKndDiv;
                    updateWork.CheckdigitCode = PrmGoodsBarCodeRevnUpdateAcs.CheckdigitCodeDefault;
                    updateWork.OfferDate = offerPrmPartsBrcd.OfferDate;
                    updateWork.OfferDataDiv = PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault;
                }
                else if (updateParam.BarcodeUpdateKndDiv == (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.WithoutUserUpdate
                    && updateWork.OfferDataDiv != PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault)
                {
                    // 提供データ区分が[0:ユーザー更新]でかつ、バーコード更新区分が[0:ユーザー更新以外]の場合更新対象外
                    updateWork = null;
                    continue;
                }
                else if (updateWork.OfferDataDiv == PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault
                    && updateWork.OfferDate == offerPrmPartsBrcd.OfferDate
                    && updateWork.GoodsBarCode == offerPrmPartsBrcd.PrimePartsBarCode
                    && updateWork.GoodsBarCodeKind == offerPrmPartsBrcd.PrimePrtsBarCdKndDiv)
                {
                    // 提供データ区分が[0:ユーザー更新]でかつ、提供データの情報で更新済みの場合更新対象外
                    // ※提供日付、商品バーコード情報、バーコード種別が何れも同一の場合
                    updateWork = null;
                    continue;
                }
                else
                {
                    if (autoFlag)
                    {
                        //更新ヘッダ情報を取得
                        object obj = (object)this;
                        GoodsBarCodeRevnWork dummyWork = new GoodsBarCodeRevnWork();
                        IFileHeader flhd = (IFileHeader)dummyWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        updateWork.UpdAssemblyId1 = dummyWork.UpdAssemblyId2;
                        updateWork.UpdEmployeeCode = dummyWork.UpdEmployeeCode;
                    }
                    updateWork.EnterpriseCode = updateParam.EnterpriseCode;
                    updateWork.GoodsBarCode = offerPrmPartsBrcd.PrimePartsBarCode;
                    updateWork.GoodsBarCodeKind = offerPrmPartsBrcd.PrimePrtsBarCdKndDiv;
                    updateWork.CheckdigitCode = PrmGoodsBarCodeRevnUpdateAcs.CheckdigitCodeDefault;
                    updateWork.OfferDate = offerPrmPartsBrcd.OfferDate;
                    updateWork.OfferDataDiv = PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault;
                }

                if (updateWork != null)
                {
                    if (updateList == null)
                        updateList = new ArrayList();
                    updateList.Add( updateWork );
                }
            }

            if (updateList != null && updateList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）更新
        /// </summary>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <param name="prmGoodsBrcdUpdateList">商品バーコード関連付けマスタ（ユーザーデータ）更新リスト</param>
        /// <param name="count">更新件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品品バーコード更新処理リモートの商品バーコード関連付けマスタ（ユーザーデータ）更新処理を実行する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int UpdatePrmGoodsBrcdList( ref ArrayList prmGoodsBrcdUpdateList, int barcodeUpdateKndDiv, out int count )
        {
            count = 0;
            return this.UpdatePrmGoodsBrcdList( ref prmGoodsBrcdUpdateList, barcodeUpdateKndDiv, out count, true );
        }

        /// <summary>
        /// 【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）更新
        /// </summary>
        /// <param name="prmGoodsBrcdUpdateList">商品バーコード関連付けマスタ（ユーザーデータ）更新リスト</param>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <param name="count">更新件数</param>
        /// <param name="doRecursionFlag">再帰呼出指定フラグ[true:する、false:しない]</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品品バーコード更新処理リモートの商品バーコード関連付けマスタ（ユーザーデータ）更新処理を実行する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int UpdatePrmGoodsBrcdList( ref ArrayList prmGoodsBrcdUpdateList, int barcodeUpdateKndDiv, out int count, bool doRecursionFlag )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            count = 0;

            if (prmGoodsBrcdUpdateList.Count > PrmGoodsBarCodeRevnUpdateAcs.MaxExecuteCount)
            {
                status = (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver;
                // 更新リスト要素数が処理可能最大レコード数を超える場合
                if (!doRecursionFlag)
                {
                    // 再帰フラグがfalseの場合、戻り値として取得可能最大レコード数超過を返す
                    return status;
                }

                // 20000件単位で更新処理を実行する
                int startIndex = 0;
                int untreatedCount = prmGoodsBrcdUpdateList.Count;
                int executeCount = PrmGoodsBarCodeRevnUpdateAcs.MaxExecuteCount;
                while (untreatedCount > 0)
                {
                    if (untreatedCount < executeCount)
                    {
                        executeCount = untreatedCount;
                    }
                    untreatedCount -= executeCount;

                    ArrayList updateList = new ArrayList();
                    updateList.AddRange( prmGoodsBrcdUpdateList.GetRange( startIndex, executeCount ) );

                    // 本メソッドを再帰呼出
                    int excecCount = 0;
                    status = this.UpdatePrmGoodsBrcdList( ref updateList, barcodeUpdateKndDiv, out excecCount, false );
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                    count += excecCount;
                    startIndex += executeCount;
                }
            }
            else
            {
                // 更新リスト要素数が処理可能最大レコード数、更新処理実行

                // 商品バーコード更新リモートオブジェクトインターフェースの取得
                if (this.IPrmGoodsBrcdUpdDB == null)
                {
                    this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
                }

                // 商品バーコード関連付けマスタ（ユーザーデータ）更新
                object updateParamList = (object)prmGoodsBrcdUpdateList;
                status = this.IPrmGoodsBrcdUpdDB.UpdateGoodsBarcodeRevn( ref updateParamList, out count, ref barcodeUpdateKndDiv );
            }

            return status;
        }

        #endregion //【ユーザーDB】商品バーコード関連付けマスタ（ユーザーデータ）更新

        #endregion //■ Private Method

    }
}
