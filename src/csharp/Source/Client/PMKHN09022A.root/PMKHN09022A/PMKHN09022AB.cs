using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 提供仕入先テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先（提供）テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2008.10.30</br>
    /// </remarks>
    public class OfrSupplierAcs : IGeneralGuideData
    {
        # region [private フィールド]
        private IOfrSupplierDB _iOfrSupplierDB = null;

        // ガイド設定ファイル名
        private const string GUIDE_XML_FILENAME = "OFRSUPPLIERGUIDEPARENT.XML";   // XMLファイル名

        // ガイドパラメータ
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";  // (パラメータ)企業コード
        private const string GUIDE_MNGSECTIONCODE_PARA = "MngSectionCode";  // (パラメータ)管理拠点コード

        // ガイド項目タイプ
        private const string GUIDE_TYPE_STR = "System.String";              // String型

        // ガイド項目
        private const string GUIDE_OFFERDATE_TITLE = "OfferDate"; // 提供日付
        private const string GUIDE_SUPPLIERCD_TITLE = "SupplierCd"; // 仕入先コード
        private const string GUIDE_SUPPLIERNM1_TITLE = "SupplierNm1"; // 仕入先名1
        private const string GUIDE_SUPPLIERKANA_TITLE = "SupplierKana"; // 仕入先カナ
        private const string GUIDE_SUPPLIERSNM_TITLE = "SupplierSnm"; // 仕入先略称        
        private const string GUIDE_SUPPLIERCD_ZERO_TITLE = "SupplierCdZero"; // 仕入先コード(ゼロ詰め)

        // コードフォーマット
        private string _supplierCodeFormat;

        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OfrSupplierAcs()
        {
            // 仕入先コードフォーマット取得(アクセスクラス用)
            UiSetFileAcs uiSetFileAcs = new UiSetFileAcs();
            uiSetFileAcs.ReadXML( string.Empty );
            UiSet uiset = uiSetFileAcs.GetUiSet( string.Empty, "tNedit_SupplierCd" );
            if ( uiset != null )
            {
                _supplierCodeFormat = new string( '0', uiset.Column );
            }
            else
            {
                _supplierCodeFormat = string.Empty;
            }
        }
        # endregion


        # region [public メソッド]
        /// <summary>
        /// 提供仕入先読み込み処理
        /// </summary>
        /// <param name="ofrSupplier">仕入先オブジェクト</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報を読み込みます。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Read( out OfrSupplier ofrSupplier, int supplierCode )
        {
            try
            {
                ofrSupplier = new OfrSupplier();
                int status = 0;
                OfrSupplierWork paraWork = new OfrSupplierWork();
                paraWork.SupplierCd = supplierCode;
                object retObj;

                if ( _iOfrSupplierDB == null )
                {
                    _iOfrSupplierDB = MediationOfrSupplierDB.GetOfrSupplierDB();
                }
                status = this._iOfrSupplierDB.Read( out retObj, paraWork );

                if ( status == 0 )
                {
                    // クラス内メンバコピー
                    ofrSupplier = CopyToOfrSupplierFromOfrSupplierWork( (OfrSupplierWork)retObj );
                }
                return status;
            }
            catch ( Exception )
            {
                //通信エラーは-1を戻す
                ofrSupplier = null;
                //オフライン時はnullをセット
                this._iOfrSupplierDB = null;
                return -1;
            }
        }
        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="ofrSupplier">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        public int ExecuteGuid( out OfrSupplier ofrSupplier )
        {
            int status = -1;
            ofrSupplier = new OfrSupplier();

            TableGuideParent tableGuideParent = new TableGuideParent( GUIDE_XML_FILENAME );
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ガイド起動
            if ( tableGuideParent.Execute( 0, inObj, ref retObj ) )
            {
                // 選択データの取得
                ofrSupplier = CopyToOfrSupplierFromGuideData( retObj );
                status = 0;
            }
            else
            {
                // キャンセル
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// データコピー処理
        /// </summary>
        /// <param name="retObj"></param>
        /// <returns></returns>
        private OfrSupplier CopyToOfrSupplierFromGuideData( Hashtable retObj )
        {
            OfrSupplier ofrSupplier = new OfrSupplier();

            ofrSupplier.OfferDate = (DateTime)retObj["OfferDate"];
            ofrSupplier.SupplierCd = (int)retObj["SupplierCd"];
            ofrSupplier.SupplierKana = (string)retObj["SupplierKana"];
            ofrSupplier.SupplierNm1 = (string)retObj["SupplierNm1"];
            ofrSupplier.SupplierSnm = (string)retObj["SupplierSnm"];

            return ofrSupplier;
        }

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int GetGuideData( int mode, Hashtable inParm, ref DataSet guideList )
        {
            int status = -1;

            // マスタテーブル読込み
            ArrayList retList;
            status = this.SearchOffer( out retList);

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // ガイド初期起動時
                    if ( guideList.Tables.Count == 0 )
                    {
                        // ガイド用データセット列情報構築
                        this.GuideDataSetColumnConstruction( ref guideList );
                    }

                    // ガイド用データセットの作成
                    this.GetGuideDataSet( ref guideList, retList, inParm );

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = 4;
                    break;
                default:
                    status = -1;
                    break;
            }

            return status;
        }
        /// <summary>
        /// 提供仕入先検索処理
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="retTotalCnt"></param>
        /// <returns></returns>
        public int SearchOffer( out ArrayList retList, out int retTotalCnt )
        {
            return SearchProcOfOffer( out retList, out retTotalCnt );
        }
        /// <summary>
        /// 提供仕入先検索処理
        /// </summary>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int SearchOffer( out ArrayList retList )
        {
            int retTotalCnt;
            return SearchProcOfOffer( out retList, out retTotalCnt );
        }
        # endregion

        # region [private メソッド]
        /// <summary>
        /// 提供仕入先検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSupplierがnullの場合のみ戻る)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先の検索処理を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        private int SearchProcOfOffer( out ArrayList retList, out int retTotalCnt )
        {
            // 初期化
            retList = new ArrayList();
            retTotalCnt = 0;

            // 戻り値リスト
            ArrayList wkList = new ArrayList();

            // 検索条件セット
            OfrSupplierWork ofrSupplierWork = new OfrSupplierWork();

            // Searchパラメータ
            ArrayList paraList = new ArrayList();
            paraList.Add( ofrSupplierWork );
            object paraobj = paraList;

            // 検索
            object retobj = null;

            int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // リモート
            if ( _iOfrSupplierDB == null )
            {
                _iOfrSupplierDB = MediationOfrSupplierDB.GetOfrSupplierDB();
            }
            status_o = this._iOfrSupplierDB.Search( out retobj, paraobj ); 

            // 検索結果判定
            switch ( status_o )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    wkList = retobj as ArrayList;

                    if ( wkList != null )
                    {
                        foreach ( OfrSupplierWork wkLineupWork in wkList )
                        {
                            //メンバコピー
                            retList.Add( CopyToOfrSupplierFromOfrSupplierWork( wkLineupWork ) );
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status_o;
            }

            return status_o;
        }
        /// <summary>
        /// 提供仕入先データコピー
        /// </summary>
        /// <param name="ofrSupplierWork"></param>
        /// <returns></returns>
        private OfrSupplier CopyToOfrSupplierFromOfrSupplierWork( OfrSupplierWork ofrSupplierWork )
        {
            OfrSupplier ofrSupplier = new OfrSupplier();

            # region [OfrSupplier]
            ofrSupplier.OfferDate = GetDateTime( ofrSupplierWork.OfferDate ); // 提供日付
            ofrSupplier.SupplierCd = ofrSupplierWork.SupplierCd; // 仕入先コード
            ofrSupplier.SupplierNm1 = ofrSupplierWork.SupplierNm1; // 仕入先名1
            ofrSupplier.SupplierKana = ofrSupplierWork.SupplierKana; // 仕入先カナ
            ofrSupplier.SupplierSnm = ofrSupplierWork.SupplierSnm; // 仕入先略称
            # endregion
            
            return ofrSupplier;
        }
        /// <summary>
        /// 日付取得
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime GetDateTime( int longDate )
        {
            if ( longDate == 0 )
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return new DateTime( (longDate / 10000), (longDate / 100) % 100, (longDate % 100) );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        /// <summary>
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
        /// <param name="retList">結果取得アレイリスト</param>>
        /// <param name="inParm">絞込条件</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GetGuideDataSet( ref DataSet retDataSet, ArrayList retList, Hashtable inParm )
        {
            OfrSupplier ofrSupplier = null;
            DataRow guideRow = null;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while ( dataCnt < retList.Count )
            {
                ofrSupplier = (OfrSupplier)retList[dataCnt];
                guideRow = retDataSet.Tables[0].NewRow();
                // データコピー処理
                CopyToGuideRowFromOfrSupplier( ref guideRow, ofrSupplier );
                // データ追加
                retDataSet.Tables[0].Rows.Add( guideRow );
                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// ガイドデータコピー処理
        /// </summary>
        /// <param name="guideRow"></param>
        /// <param name="obj"></param>
        private void CopyToGuideRowFromOfrSupplier( ref DataRow guideRow, object obj )
        {
            OfrSupplier ofrSupplier = (OfrSupplier)obj;

            guideRow[GUIDE_OFFERDATE_TITLE] = ofrSupplier.OfferDate; // 提供日付
            guideRow[GUIDE_SUPPLIERCD_TITLE] = ofrSupplier.SupplierCd; // 仕入先コード
            guideRow[GUIDE_SUPPLIERNM1_TITLE] = ofrSupplier.SupplierNm1; // 仕入先名1
            guideRow[GUIDE_SUPPLIERKANA_TITLE] = ofrSupplier.SupplierKana; // 仕入先カナ
            guideRow[GUIDE_SUPPLIERSNM_TITLE] = ofrSupplier.SupplierSnm; // 仕入先略称

            guideRow[GUIDE_SUPPLIERCD_ZERO_TITLE] = ofrSupplier.SupplierCd.ToString( _supplierCodeFormat );
        }

        /// <summary>
        /// ガイド用データセット列情報構築処理
        /// </summary>
        /// <param name="guideList">ガイド用データセット</param>>
        /// <remarks>
        /// <br>Note       : ガイド用データセットの列情報を構築します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction( ref DataSet guideList )
        {
            DataTable table = new DataTable();

            # region [ガイド用テーブル生成（自動生成）]
            // 表示用仕入先コード(ゼロ詰め)
            table.Columns.Add( GUIDE_SUPPLIERCD_ZERO_TITLE, typeof( string ) );
            // 提供日付
            table.Columns.Add( GUIDE_OFFERDATE_TITLE, typeof( DateTime ) );
            // 仕入先コード
            table.Columns.Add( GUIDE_SUPPLIERCD_TITLE, typeof( Int32 ) );
            // 仕入先名1
            table.Columns.Add( GUIDE_SUPPLIERNM1_TITLE, typeof( string ) );
            // 仕入先カナ
            table.Columns.Add( GUIDE_SUPPLIERKANA_TITLE, typeof( string ) );
            // 仕入先略称
            table.Columns.Add( GUIDE_SUPPLIERSNM_TITLE, typeof( string ) );
            # endregion

            // テーブルコピー
            guideList.Tables.Add( table.Clone() );
        }
        # endregion
    }
}
