using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// モバイル受発注データ書き込みクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : モバイル受発注データ書き込みを行うクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/01  22018 鈴木 正臣</br>
    /// <br>           : 自由帳票(売上伝票)リモートの抽出条件クラスのSectionCodeが不要なので削除。</br>
    /// <br></br>
    /// </remarks>
    internal class MblOdrDataWriter
    {
        // 伝票リモート(自社名取得に使用)
        private IFrePSalesSlipDB iFrePSalesSlipDB;
        
        private List<SlipPrtSetWork> _slipPrtSetWorkList = null;
        private List<CustSlipMngWork> _custSlipMngWorkList = null;
        private string _loginSectionCode;

        // モバイル受発注データWEBサービスアクセスクラス
        private MblOdrDataAcs2 _mblOdrDataAcs;


        // 拠点ゼロ
        private const string ct_SectionZero = "00";
        // 倉庫ゼロ
        private const string ct_WarehouseZero = "0000";
        // 得意先ゼロ
        private const int ct_CustomerZero = 0;
        // 伝票種別 30:売上
        private const int ct_SlipKind_Sales = 30;

        /// <summary>
        /// モバイル受発注データ書き込み
        /// </summary>
        /// <param name="qrGuid"></param>
        /// <param name="salesSlip"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <returns></returns>
        public int WriteMblOdrData( Guid qrGuid, SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCar, List<SalesDetailWork> salesDetailList, List<AcceptOdrCarWork> acceptOdrCarList )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // パラメータチェック
            if (qrGuid == Guid.Empty) return status;
            if (salesSlip == null) return status;
            if (salesDetailList == null ) return status;

            if ( _mblOdrDataAcs == null )
            {
                _mblOdrDataAcs = new MblOdrDataAcs2();
            }

            //------------------------------------------------
            // ヘッダ
            //------------------------------------------------

            // モバイル受発注データ(ヘッダ)読み込み
            MblOdrData mblOdrData;
            bool mblOdrExists = ReadMblOdrData( qrGuid, salesSlip, out mblOdrData );

            // モバイル受発注データ(ヘッダ)更新
            ReflectMblOdrDataFromSalesSlip( ref mblOdrData, qrGuid, salesSlip, acceptOdrCar, mblOdrExists );


            //------------------------------------------------
            // 明細
            //------------------------------------------------

            // モバイル受発注明細データ(明細)
            List<MblOdrDtl> mblOdrDtlList = new List<MblOdrDtl>();
            foreach ( SalesDetailWork salesDetail in salesDetailList )
            {
                bool isRowDiscount = false;

                // 行値引/商品値引/注釈行判断
                switch ( salesDetail.SalesSlipCdDtl )
                {
                    case 2:
                    case 3:
                        // 2:行値引/商品値引⇒取込区分を"1:不可"とする
                        // 3:注釈行⇒取込区分を"1:不可"とする
                        isRowDiscount = true;
                        break;
                }

                MblOdrDtl mblOdrDtl = CopyToMblOdrDtlFromSalesDetail( salesSlip, salesDetail, isRowDiscount );
                mblOdrDtlList.Add( mblOdrDtl );
            }

            //------------------------------------------------
            // 書き込み
            //------------------------------------------------
            status = WriteMblOdrDataProc( ref mblOdrData, ref mblOdrDtlList );

            return status;
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="qrGuid"></param>
        /// <param name="salesSlip"></param>
        /// <param name="mblOdrData"></param>
        /// <returns></returns>
        private bool ReadMblOdrData( Guid qrGuid, SalesSlipWork salesSlip, out MblOdrData mblOdrData )
        {
            bool mblOdrExists = false; // false:存在しない
            List<MblOdrDtl> mblOdrDtlList;

            // Guidを指定してモバイル受発注データを読み込む
            int status = _mblOdrDataAcs.Read( qrGuid, out mblOdrData, out mblOdrDtlList );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                // 念の為、KEYをチェック
                if ( mblOdrData.InqOtherEpCd.Trim() == salesSlip.EnterpriseCode.Trim() &&
                     mblOdrData.MblOdrNo == ToInt( salesSlip.SalesSlipNum ) )
                {
                    mblOdrExists = true; // true:存在する
                }
            }

            return mblOdrExists;
        }
        /// <summary>
        /// 書き込み処理
        /// </summary>
        /// <param name="mblOdrData"></param>
        /// <param name="mblOdrDtlList"></param>
        /// <returns></returns>
        private int WriteMblOdrDataProc( ref MblOdrData mblOdrData, ref List<MblOdrDtl> mblOdrDtlList )
        {
            int status = _mblOdrDataAcs.Write( ref mblOdrData, ref mblOdrDtlList );
            return status;
        }

        # region [データ操作]
        /// <summary>
        /// データのセット(モバイル受発注←売上)
        /// </summary>
        /// <param name="qrGuid"></param>
        /// <param name="mblOdrData"></param>
        /// <param name="salesSlip"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="mblOdrExists"></param>
        private void ReflectMblOdrDataFromSalesSlip( ref MblOdrData mblOdrData, Guid qrGuid, SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCar, bool mblOdrExists )
        {
            if ( mblOdrData == null )
            {
                mblOdrData = new MblOdrData();
            }

            // 自社名の取得
            string companyName1;
            string companyName2;
            GetCompanyName( out companyName1, out companyName2, salesSlip );

            # region [値セット]
            mblOdrData.InqOtherEpCd = salesSlip.EnterpriseCode; // 問合せ先企業コード ← 売上データ．企業コード
            mblOdrData.InqOtherSecCd = salesSlip.SalesInpSecCd; // 問合せ先拠点コード ← 売上データ．売上入力拠点コード
            mblOdrData.InqOtherEpNm1 = companyName1; // 問合せ先企業名称１ ← 自社名称1
            mblOdrData.InqOtherEpNm2 = companyName2; // 問合せ先企業名称２ ← 自社名称2
            mblOdrData.InqOriginalEpNm1 = Left( salesSlip.CustomerName, 20 ); // 問合せ元企業名称１ ← 売上データ．得意先名称
            mblOdrData.InqOriginalEpNm2 = Left( salesSlip.CustomerName2, 20 ); // 問合せ元企業名称２ ← 売上データ．得意先名称2
            mblOdrData.AnsEmployeeCd = salesSlip.SalesEmployeeCd; // 回答従業員コード ← 売上データ．販売従業員コード
            mblOdrData.AnsEmployeeNm = Left( salesSlip.SalesEmployeeNm, 30 ); // 回答従業員名称 ← 売上データ．販売従業員名称
            mblOdrData.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // 型式指定番号 ← 受注マスタ（車両）.型式指定番号
            mblOdrData.CategoryNo = acceptOdrCar.CategoryNo; // 類別番号 ← 受注マスタ（車両）.類別番号
            mblOdrData.MakerCode = acceptOdrCar.MakerCode; // メーカーコード ← 受注マスタ（車両）.メーカーコード
            mblOdrData.ModelCode = acceptOdrCar.ModelCode; // 車種コード ← 受注マスタ（車両）.車種コード
            mblOdrData.ModelSubCode = acceptOdrCar.ModelSubCode; // 車種サブコード ← 受注マスタ（車両）.車種サブコード
            mblOdrData.ModelName = Left( acceptOdrCar.ModelFullName, 20 ); // 車種名 ← 受注マスタ（車両）.車種全角名称
            mblOdrData.FullModel = Left( acceptOdrCar.FullModel, 44 ); // 型式（フル型） ← 受注マスタ（車両）.型式（フル型）
            mblOdrData.FrameNo = Left( acceptOdrCar.FrameNo, 30 ); // 車台番号 ← 受注マスタ（車両）.車台番号
            mblOdrData.FrameModel = Left( acceptOdrCar.FrameModel, 16 ); // 車台型式 ← 受注マスタ（車両）.車台型式
            mblOdrData.ProduceTypeOfYearNum = acceptOdrCar.FirstEntryDate; // 生産年式（NUMタイプ） ← 受注マスタ（車両）.初年度
            mblOdrData.RpColorCode = Left( acceptOdrCar.ColorCode, 20 ); // リペアカラーコード ← 受注マスタ（車両）.カラーコード
            mblOdrData.ColorName1 = Left( acceptOdrCar.ColorName1, 40 ); // カラー名称1 ← 受注マスタ（車両）.カラー名称1
            mblOdrData.TrimCode = Left( acceptOdrCar.TrimCode, 15 ); // トリムコード ← 受注マスタ（車両）.トリムコード
            mblOdrData.TrimName = Left( acceptOdrCar.TrimName, 40 ); // トリム名称 ← 受注マスタ（車両）.トリム名称
            mblOdrData.Mileage = acceptOdrCar.Mileage; // 車両走行距離 ← 受注マスタ（車両）.車両走行距離
            mblOdrData.ScmBusinessDiv = 1; // 1：PM、2：GD、3：RC
            mblOdrData.ScmSlipCd = (short)salesSlip.SalesSlipCd; // 伝票区分 ← 売上データ．売上伝票区分
            mblOdrData.ScmPmSlipNo = ToInt( salesSlip.SalesSlipNum ); // PM伝票番号 ← 売上データ．売上伝票番号
            # endregion

            // 新規登録の場合のみset
            if ( !mblOdrExists )
            {
                mblOdrData.QRTakeInGUID = qrGuid; // QRｺｰﾄﾞのGUID
                mblOdrData.MblOdrNo = ToInt( salesSlip.SalesSlipNum ); // モバイル受発注番号 ← 売上データ．売上伝票番号
                mblOdrData.QRMailTakeInDiv = 0; // 0:未取込み １：取込み済み
            }
        }

        /// <summary>
        /// データのセット(モバイル受発注明細←売上明細)
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetail"></param>
        /// <param name="isRowDiscount"></param>
        /// <returns></returns>
        private MblOdrDtl CopyToMblOdrDtlFromSalesDetail( SalesSlipWork salesSlip, SalesDetailWork salesDetail, bool isRowDiscount )
        {
            MblOdrDtl mblOdrDtl = new MblOdrDtl();

            // 0:売上⇒+1／1:返品⇒-1
            int countSign;
            if ( salesSlip.SalesSlipCd == 0 )
            {
                countSign = 1;
            }
            else
            {
                countSign = -1;
            }
            

            # region [値セット]
            mblOdrDtl.InqOtherEpCd = salesDetail.EnterpriseCode; // 問合せ先企業コード ← 売上明細データ.企業コード
            mblOdrDtl.MblOdrNo = ToInt( salesDetail.SalesSlipNum ); // モバイル受発注番号 ← 売上明細データ.売上伝票番号
            mblOdrDtl.MblOdrRowNo = salesDetail.SalesRowNo; // モバイル受発注番号枝番 ← 売上明細データ.売上行番号
            if ( !isRowDiscount )
            {
                mblOdrDtl.GoodsDivCd = salesDetail.GoodsKindCode; // 商品種別 ← 売上明細データ.商品属性 (行値引時は99)
            }
            else
            {
                mblOdrDtl.GoodsDivCd = 99; // 99:行値引
            }
            mblOdrDtl.RecyclePrtKindCode = salesDetail.RecycleDiv; // リサイクル部品種別 ← 売上明細データ.リサイクル区分
            mblOdrDtl.RecyclePrtKindName = Left( salesDetail.RecycleDivNm, 10 ); // リサイクル部品種別名称 ← 売上明細データ.リサイクル区分名称
            if ( !isRowDiscount || salesDetail.ShipmentCnt != 0 )
            {
                mblOdrDtl.BLGoodsCode = salesDetail.PrtBLGoodsCode; // BL商品コード ← 売上明細データ.BL商品コード（印刷）
            }
            else
            {
                mblOdrDtl.BLGoodsCode = -1; // 行値引ならばBLｺｰﾄﾞ=-1
            }
            mblOdrDtl.AnsGoodsName = Left( GetPrintGoodsName( salesDetail ), 60 ); // 回答商品名 ← 売上明細データ.品名カナor品名
            mblOdrDtl.SalesOrderCount = Round( salesDetail.AcceptAnOrderCnt ) * countSign; // 発注数 ← 売上明細データ.受注数量
            mblOdrDtl.DeliveredGoodsCount = Round( salesDetail.ShipmentCnt ) * countSign; // 納品数 ← 売上明細データ.出荷数
            mblOdrDtl.GoodsNo = Left( salesDetail.PrtGoodsNo, 40 ); // 商品番号 ← 売上明細データ.印刷用品番
            mblOdrDtl.GoodsMakerCd = salesDetail.PrtMakerCode; // 商品メーカーコード ← 売上明細データ.印刷用メーカーコード
            mblOdrDtl.GoodsMakerNm = Left( salesDetail.PrtMakerName, 24 ); // 商品メーカー名称 ← 売上明細データ.印刷用メーカー名称
            mblOdrDtl.ListPrice = Round( salesDetail.ListPriceTaxExcFl ); // 定価 ← 売上明細データ.定価（税抜，浮動）
            mblOdrDtl.UnitPrice = Round( salesDetail.SalesUnPrcTaxExcFl ); // 単価 ← 売上明細データ.売上単価（税抜，浮動）
            mblOdrDtl.CommentDtl = salesDetail.DtlNote; // 備考(明細) ← 売上明細データ.明細備考
            mblOdrDtl.ShelfNo = Left( salesDetail.WarehouseShelfNo, 8 ); // 棚番 ← 売上明細データ.倉庫棚番
            # endregion

            return mblOdrDtl;
        }
        /// <summary>
        /// 印刷品名取得処理
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns></returns>
        private string GetPrintGoodsName( SalesDetailWork salesDetail )
        {
            // ※伝票印刷と同様の仕様で品名を取得します。

            // "品名カナ"が空の場合は"品名"
            if ( !string.IsNullOrEmpty( salesDetail.GoodsNameKana ) && salesDetail.GoodsNameKana.Trim() != string.Empty )
            {
                // 品名カナ
                return salesDetail.GoodsNameKana;
            }
            else
            {
                // 品名
                return salesDetail.GoodsName;
            }
        }
        # endregion

        # region [自社名称取得]
        /// <summary>
        /// 自社名称取得
        /// </summary>
        /// <param name="companyName1"></param>
        /// <param name="companyName2"></param>
        /// <param name="salesSlip"></param>
        private void GetCompanyName( out string companyName1, out string companyName2, SalesSlipWork salesSlip )
        {
            companyName1 = string.Empty;
            companyName2 = string.Empty;

            // ログイン拠点退避
            _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            // リモートオブジェクト取得
            if ( iFrePSalesSlipDB == null )
            {
                iFrePSalesSlipDB = MediationFrePSalesSlipDB.GetFrePSalesSlipDB();
            }
            // 伝票関連情報取得
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            // --- UPD m.suzuki 2010/07/01 ---------->>>>>
            //int status = iFrePSalesSlipDB.Search( CreateRemotePara( salesSlip, _loginSectionCode ), out retObj, out mstList, out msgDiv, out errMsg );
            int status = iFrePSalesSlipDB.Search( CreateRemotePara( salesSlip ), out retObj, out mstList, out msgDiv, out errMsg );
            // --- UPD m.suzuki 2010/07/01 ----------<<<<<

            // リスト展開
            List<ArrayList> printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
            List<object> masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );

            # region [マスタリスト展開]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // 伝票印刷パターン設定マスタリスト生成
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // 伝票設定マスタリスト生成
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
            }
            # endregion


            int enterpriseNamePrtCd = 0;

            # region [自社名印字区分の決定]
            // 伝票タイプを確定
            CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( ct_SlipKind_Sales, salesSlip );
            if ( custSlipMngWork != null )
            {
                // 自社名印字区分を取得
                SlipPrtSetWork slipPrtSetWork = FindSlipPrtSetWork( salesSlip.EnterpriseCode, custSlipMngWork.SlipPrtSetPaperId, ct_SlipKind_Sales );
                if ( slipPrtSetWork != null )
                {
                    enterpriseNamePrtCd = slipPrtSetWork.EnterpriseNamePrtCd;
                }
            }
            # endregion


            // 売上伝票データ
            FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[0][0]);
            if ( slip != null )
            {
                if ( enterpriseNamePrtCd != 1 )
                {
                    // 1:拠点以外
                    // 自社orビットマップorなし⇒自社設定
                    companyName1 = slip.COMPANYINFRF_COMPANYNAME1RF;
                    companyName2 = slip.COMPANYINFRF_COMPANYNAME2RF;
                }
                else
                {
                    // 1:拠点
                    // 拠点⇒拠点に紐付く自社名称
                    companyName1 = slip.COMPANYNMRF_COMPANYNAME1RF;
                    companyName2 = slip.COMPANYNMRF_COMPANYNAME2RF;
                }
            }
        }

        /// <summary>
        /// 伝票リモート呼び出しパラメータ生成
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/07/01 ---------->>>>>
        //private FrePSalesSlipParaWork CreateRemotePara( SalesSlipWork salesSlip, string loginSectionCode )
        private FrePSalesSlipParaWork CreateRemotePara( SalesSlipWork salesSlip )
        // --- UPD m.suzuki 2010/07/01 ----------<<<<<
        {
            FrePSalesSlipParaWork paraWork = new FrePSalesSlipParaWork();
            paraWork.EnterpriseCode = salesSlip.EnterpriseCode;
            // --- DEL m.suzuki 2010/07/01 ---------->>>>>
            //paraWork.SectionCode = loginSectionCode;
            // --- DEL m.suzuki 2010/07/01 ----------<<<<<
            paraWork.FrePSalesSlipParaKeyList = new List<FrePSalesSlipParaWork.FrePSalesSlipParaKey>();
            paraWork.FrePSalesSlipParaKeyList.Add( new FrePSalesSlipParaWork.FrePSalesSlipParaKey( salesSlip.AcptAnOdrStatus, salesSlip.SalesSlipNum ) );

            return paraWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="salesSlip"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefault( int slipKind, SalesSlipWork salesSlip )
        {
            CustSlipMngWork custSlipMngWork = null;
            string enterpriseCode = salesSlip.EnterpriseCode;

            if ( salesSlip.CustomerCode != 0 )
            {
                // 得意先毎[拠点=0]
                custSlipMngWork = FindCustSlipMngWork( enterpriseCode, ct_SectionZero, salesSlip.CustomerCode, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( enterpriseCode, "0", salesSlip.CustomerCode, slipKind );
                }
            }

            // 拠点毎[得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // 全社設定[拠点=0,得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }
        /// <summary>
        /// 得意先マスタ伝票管理（伝票タイプ管理マスタ）Find処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <returns></returns>
        private CustSlipMngWork FindCustSlipMngWork( string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind )
        {
            if ( _custSlipMngWorkList == null ) return null;

            return _custSlipMngWorkList.Find(
                        delegate( CustSlipMngWork custSlipMngWork )
                        {
                            return (custSlipMngWork.EnterpriseCode == enterpriseCode)
                                    && ((custSlipMngWork.SectionCode.Trim() == sectionCode.Trim()) || ((sectionCode.Trim() == ct_SectionZero) && (custSlipMngWork.SectionCode.Trim() == string.Empty)))
                                    && (custSlipMngWork.CustomerCode == customerCode)
                                    && (custSlipMngWork.LogicalDeleteCode == 0)
                                    && (custSlipMngWork.SlipPrtKind == slipPrtKind);
                        } );
        }
        /// <summary>
        /// 伝票印刷設定マスタ Find処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <param name="slipPrtKind"></param>
        /// <returns></returns>
        private SlipPrtSetWork FindSlipPrtSetWork( string enterpriseCode, string slipPrtSetPaperId, int slipPrtKind )
        {
            if ( _slipPrtSetWorkList == null ) return null;

            return _slipPrtSetWorkList.Find(
                        delegate( SlipPrtSetWork slipPrtSetWork )
                        {
                            return (slipPrtSetWork.EnterpriseCode.TrimEnd() == enterpriseCode)
                                    && (slipPrtSetWork.SlipPrtSetPaperId.TrimEnd() == slipPrtSetPaperId)
                                    && (slipPrtSetWork.LogicalDeleteCode == 0)
                                    && (slipPrtSetWork.SlipPrtKind == slipPrtKind);
                        } );
        }
        # endregion

        # region [共通処理]
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int Round( double orgValue )
        {
            Int64 resultValue;

            // 端数処理（1:切捨 2:四捨五入 3:切上）
            FractionCalculate.FracCalcMoney( (double)orgValue, 1.0f, 2, out resultValue );

            return (int)resultValue;
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int ToInt( string orgValue )
        {
            try
            {
                return Int32.Parse( orgValue );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 指定文字数でカットする
        /// </summary>
        /// <param name="orgValue"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string Left( string orgValue, int length )
        {
            if ( !string.IsNullOrEmpty(orgValue) )
            {
                // 通常は指定文字数分を返す(不足分は埋めない)
                return orgValue.Substring( 0, Math.Min( orgValue.Length, length ) );
            }
            else
            {
                // NULLまたはEmptyならばEmptyを返す
                return string.Empty;
            }
        }
        # endregion
    }
}
