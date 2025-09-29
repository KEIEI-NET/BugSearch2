using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 自由検索部品　自動登録リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタ自動登録のデータ操作を行うクラスです。</br>
    /// <br>Programmer : 22018</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class IOWriteFreeSearchParts : RemoteWithAppLockDB
    {
        # region [Write]
        /// <summary>
        /// 自由検索部品マスタ自動登録処理
        /// </summary>
        /// <param name="salesDetailList"></param>
        /// <param name="acpOdrCarList"></param>
        /// <param name="slpDtlAdInfList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int WriteFreeSearchParts( ref ArrayList salesDetailList, ref ArrayList acpOdrCarList, ref ArrayList slpDtlAdInfList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList freeSearchPartsList = new ArrayList();

                // ArrayList.BinarySearch において、比較対象項目が同じアイテムがリスト内に複数存在した場合
                // 正しいインデックス値を返せない問題を回避する為にジェネリックにコピーして以降の処理を行う
                List<SalesDetailWork> slsDtlList = new List<SalesDetailWork>();

                if ( salesDetailList != null )
                {
                    slsDtlList.AddRange( (SalesDetailWork[])salesDetailList.ToArray( typeof( SalesDetailWork ) ) );
                }


                // 受注マスタ(車両)ディクショナリ
                Dictionary<string, AcceptOdrCarWork> acpOdrCarDic = new Dictionary<string, AcceptOdrCarWork>();
                // 受注マスタ(車両)をディクショナリに格納する
                foreach ( AcceptOdrCarWork acceptOdrCar in acpOdrCarList )
                {
                    string key = GetKey( acceptOdrCar.AcptAnOdrStatus, acceptOdrCar.AcceptAnOrderNo );
                    if ( !acpOdrCarDic.ContainsKey( key ) )
                    {
                        acpOdrCarDic.Add( key, acceptOdrCar );
                    }
                }

                // 伝票明細追加情報の明細関連付けGUID比較クラス
                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();

                if ( ListUtils.IsNotEmpty( slpDtlAdInfList ) )
                {
                    slpDtlAdInfList.Sort( DtlRelationGuidComp );

                    # region [売上明細データ → 自由検索部品]

                    if ( slsDtlList.Count > 0 )
                    {
                        foreach ( SalesDetailWork slsDtlWrk in slsDtlList )
                        {
                            // 売上明細に紐付く伝票明細追加情報を取得
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch( slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp );

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if ( slpDtlAdInfPos > -1 )
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // 伝票明細追加情報が存在し、且つ自由検索部品登録区分が 1:登録 の場合
                            if ( slpDtlAdInfWrk != null && slpDtlAdInfWrk.FreeSearchPartsEntryDiv == 1 )
                            {
                                // 売上明細に対応する受注マスタ(車両)を取得（※keyとなる受注ステータスは変換が必要）
                                string key = GetKey( GetAcptStatus( slsDtlWrk.AcptAnOdrStatus ), slsDtlWrk.AcceptAnOrderNo );
                                if ( acpOdrCarDic.ContainsKey( key ) )
                                {
                                    FreeSearchPartsWork[] freeSearchPartsWorks = CreateFreeSearchPartsInfo( slsDtlWrk, acpOdrCarDic[key], slpDtlAdInfWrk.FullModelList );
                                    if ( freeSearchPartsWorks != null )
                                    {
                                        freeSearchPartsList.AddRange( freeSearchPartsWorks );
                                    }
                                }
                            }
                        }
                    }

                    # endregion
                }

                if ( ListUtils.IsNotEmpty( freeSearchPartsList ) )
                {
                    // 自由検索部品マスタに書き込み
                    FreeSearchPartsDB freeSearchPartsDB = new FreeSearchPartsDB();
                    status = freeSearchPartsDB.Write( ref freeSearchPartsList, ref sqlConnection, ref sqlTransaction );
                }
                else
                {
                    // 自由検索部品マスタに登録すべきデータが存在しない場合は ctDB_NORMAL とする。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch ( Exception ex )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                base.WriteErrorLog( ex, errmsg, status );
            }

            return status;
        }
        # endregion

        # region [privateメソッド]
        /// <summary>
        /// 受注ステータス変換処理（売上明細⇒受注マスタ(車両)）
        /// </summary>
        /// <param name="acptStatus"></param>
        /// <returns></returns>
        private int GetAcptStatus( int acptStatus )
        {
            switch ( acptStatus )
            {
                // 見積10⇒1
                case 10: return 1;
                // 受注20⇒3
                case 20: return 3;
                // 売上30⇒7
                case 30: return 7;
                // 貸出40⇒5
                case 40: return 5;
                // (defaultは売上とみなす)
                default: return 7;
            }
        }
        /// <summary>
        /// 受注マスタ(車両)キー文字列取得処理
        /// </summary>
        /// <param name="acptStatus"></param>
        /// <param name="acptNo"></param>
        /// <returns></returns>
        private string GetKey( int acptStatus, int acptNo )
        {
            // ※処理の流れにより制約される為、下記条件は省略する。
            //   ・企業コード一致
            //   ・受注マスタ(車両)のDataInputSystem=10

            return string.Format( "{0},{1}", acptStatus.ToString( "00" ), acptNo.ToString( "000000000" ) );
        }
        /// <summary>
        /// 自由検索部品マスタ情報生成処理（売上明細＋受注マスタ(車両)⇒自由検索部品マスタ）
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="fullModelList"></param>
        /// <returns></returns>
        private FreeSearchPartsWork[] CreateFreeSearchPartsInfo( SalesDetailWork salesDetail, AcceptOdrCarWork acceptOdrCar, string[] fullModelList )
        {
            // フル型式リストが空ならば登録なし
            if ( fullModelList == null || fullModelList.Length == 0 )
            {
                return null;
            }

            List<FreeSearchPartsWork> retList = new List<FreeSearchPartsWork>();

            // 対象となるフル型式の分だけレコードを生成する
            foreach (string fullModel in fullModelList)
	        {
                FreeSearchPartsWork fsParts = new FreeSearchPartsWork();

                # region [項目セット]
                //--------------------------------------------------
                // FileHeader
                //--------------------------------------------------
                fsParts.EnterpriseCode = salesDetail.EnterpriseCode; // 企業コード
                fsParts.LogicalDeleteCode = 0; // 論理削除区分


                //--------------------------------------------------
                // Fields
                //--------------------------------------------------

                fsParts.FreSrchPrtPropNo = GetNewFreSrchPrtPropNo(); // 自由検索部品固有番号

                fsParts.MakerCode = acceptOdrCar.MakerCode; // メーカーコード
                fsParts.ModelCode = acceptOdrCar.ModelCode; // 車種コード
                fsParts.ModelSubCode = acceptOdrCar.ModelSubCode; // 車種サブコード
                fsParts.FullModel = fullModel; // 型式（フル型）

                fsParts.TbsPartsCode = salesDetail.BLGoodsCode; // BL商品コード
                fsParts.TbsPartsCdDerivedNo = 0; // 翼部品コード枝番
                fsParts.GoodsNo = salesDetail.GoodsNo; // 商品番号
                fsParts.GoodsNoNoneHyphen = salesDetail.GoodsNo.Replace( "-", "" ); // ハイフン無商品番号
                fsParts.GoodsMakerCd = salesDetail.GoodsMakerCd; // 商品メーカーコード
                fsParts.PartsQty = Math.Abs( salesDetail.ShipmentCnt ); // 部品QTY
                fsParts.PartsOpNm = string.Empty; // 部品オプション名称

                fsParts.ModelPrtsAdptYm = DateTime.MinValue; // 型式別部品採用年月
                fsParts.ModelPrtsAblsYm = DateTime.MinValue; // 型式別部品廃止年月
                fsParts.ModelPrtsAdptFrameNo = 0; // 型式別部品採用車台番号
                fsParts.ModelPrtsAblsFrameNo = 0; // 型式別部品廃止車台番号
                fsParts.ModelGradeNm = string.Empty; // 型式グレード名称
                fsParts.BodyName = string.Empty; // ボディー名称
                fsParts.DoorCount = 0; // ドア数
                fsParts.EngineModelNm = string.Empty; // エンジン型式名称
                fsParts.EngineDisplaceNm = string.Empty; // 排気量名称
                fsParts.EDivNm = string.Empty; // E区分名称
                fsParts.TransmissionNm = string.Empty; // ミッション名称
                fsParts.WheelDriveMethodNm = string.Empty; // 駆動方式名称
                fsParts.ShiftNm = string.Empty; // シフト名称

                fsParts.CreateDate = TDateTime.DateTimeToLongDate( DateTime.Today ); // 作成日付
                fsParts.UpdateDate = TDateTime.DateTimeToLongDate( DateTime.Today ); // 更新年月日

                # endregion

                retList.Add( fsParts );
	        }

            // ゼロ件ならばnullを返す
            if ( retList.Count == 0 )
            {
                return null;
            }

            // 返却
            return retList.ToArray();
        }

        /// <summary>
        /// 新規自由検索部品固有番号 取得処理
        /// </summary>
        /// <returns></returns>
        private string GetNewFreSrchPrtPropNo()
        {
            // 新規GUIDを採番して、ハイフンを取り除く
            return Guid.NewGuid().ToString().Replace( "-", "" );
        }

        # endregion
    }
}
