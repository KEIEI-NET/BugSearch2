using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.RCDS.Web.Services;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 相場価格選択アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2010/06/17</br>
    /// </remarks>
    public class SelectionMarketPriceAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        private MarketPriceInfoDataSet _dataSet;
        private MarketPriceInfoDataSet.MarketPriceInfoDataTable _priceInfoTable;
        private SobaServiceAcs _sobaServiceAcs;

        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Public Enum
        #endregion


        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Property

        /// <summary>
        /// 相場価格情報データテーブル
        /// </summary>
        public MarketPriceInfoDataSet.MarketPriceInfoDataTable PriceInfoDataTable
        {
            get { return _priceInfoTable; }
            set { _priceInfoTable = value; }
        }


        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Costructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SelectionMarketPriceAcs()
        {
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method

        /// <summary>
        /// 相場価格検索
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int MarketPriceSearch( MarketPriceAcqCond condition, out string errMsg )
        {
            return MarketPriceSearchProc( condition, out errMsg );
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// 相場価格検索
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private int MarketPriceSearchProc( MarketPriceAcqCond marketPriceAcqCond, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            errMsg = string.Empty;

            try
            {
                //--------------------------------------------------
                // ①相場価格設定マスタの取得
                //--------------------------------------------------
                SCMMrktPriSt scmMrktPriSt = this.GetMrktPriSt( marketPriceAcqCond.EnterpriseCode, marketPriceAcqCond.SectionCode );
                if ( scmMrktPriSt == null ) return 1000;

                //--------------------------------------------------
                // ②相場情報の取得＋相場価格の計算
                //--------------------------------------------------

                // 相場サービスアクセスクラス生成
                if ( _sobaServiceAcs == null )
                {
                    _sobaServiceAcs = new SobaServiceAcs();
                }
                // 相場情報取得
                List<SobaServiceAcs.GetSobaResTypeUnitData> sobaResList = _sobaServiceAcs.GetSobaResponce( marketPriceAcqCond, scmMrktPriSt );
                if ( sobaResList == null || sobaResList.Count == 0 )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                // データテーブルへ格納
                _dataSet = new MarketPriceInfoDataSet();
                _priceInfoTable = _dataSet.MarketPriceInfo;
                if ( sobaResList != null )
                {
                    foreach ( SobaServiceAcs.GetSobaResTypeUnitData sobaRes in sobaResList )
                    {
                        MarketPriceInfoDataSet.MarketPriceInfoRow row = _priceInfoTable.NewMarketPriceInfoRow();
                        CopyToRowFromRes( ref row, sobaRes, scmMrktPriSt );

                        // 算出した金額がゼロ以外ならば表示テーブルに追加
                        if ( row.MarketPrice != 0 )
                        {
                            _priceInfoTable.Rows.Add( row );
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }

                // ソート順設定
                _priceInfoTable.DefaultView.Sort = string.Format( "{0}", _priceInfoTable.PriorityColumn.ColumnName );
            }
            catch ( Exception ex )
            {
                // 例外発生
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// データテーブルへの格納処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="sobaRes"></param>
        private void CopyToRowFromRes( ref MarketPriceInfoDataSet.MarketPriceInfoRow row, SobaServiceAcs.GetSobaResTypeUnitData sobaRes, SCMMrktPriSt scmMrktPriSt )
        {
            // 選択フラグ初期化
            row.Selected = false;

            // 優先順位
            row.Priority = sobaRes.Index + 1; // 1,2,3 ← 0,1,2

            // 地域
            row.MarketPriceAreaCd = sobaRes.GetSobaReqType.AreaCode;
            row.MarketPriceAreaNm = _sobaServiceAcs.GetMarketPriceAreaNm( scmMrktPriSt.EnterpriseCode, sobaRes.GetSobaReqType.AreaCode );
            
            // 種別
            row.MarketPriceKindCd = sobaRes.GetSobaReqType.KindCode;
            row.MarketPriceKindNm = _sobaServiceAcs.GetMarketPriceKindNm( scmMrktPriSt.EnterpriseCode, sobaRes.GetSobaReqType.KindCode );

            // 品質
            row.MarketPriceQualityCd = sobaRes.GetSobaReqType.QualityCode;
            row.MarketPriceQualityNm = _sobaServiceAcs.GetMarketPriceQualityNm( scmMrktPriSt.EnterpriseCode, sobaRes.GetSobaReqType.QualityCode );

            // 流通相場価格(※元々の価格)
            row.DstrMarketPrice = sobaRes.GetSobaResType.SobaList[0].StdDev;

            // 相場価格(※相場価格掛率に従う)
            row.MarketPrice = SobaServiceAcs.GetMarketPrice( sobaRes.GetSobaResType, scmMrktPriSt );
        }

        /// <summary>
        /// 相場設定マスタの取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private SCMMrktPriSt GetMrktPriSt( string enterpriseCode, string sectionCode )
        {
            SCMMrktPriSt scmMrktPriSt = null;

            SCMMrktPriStAcs scmMrktPriStAcs = new SCMMrktPriStAcs();
            {
                ArrayList al;
                int status = scmMrktPriStAcs.SearchAll( out al, enterpriseCode );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && al != null && al.Count > 0 )
                {
                    List<SCMMrktPriSt> dataList = new List<SCMMrktPriSt>();
                    foreach ( SCMMrktPriSt data in al )
                    {
                        dataList.Add( data );
                    }

                    dataList.Sort( new SCMMrktPriStComparer() );

                    scmMrktPriSt = dataList.Find
                        (
                            delegate( SCMMrktPriSt dt )
                            {
                                if ( dt.SectionCode.Trim() == sectionCode.Trim() || dt.SectionCode.Trim() == "00".Trim() )
                                {
                                    return true;
                                }
                                return false;
                            }
                        );
                }
            }
            return scmMrktPriSt;
        }

        #endregion



        #region ソート用クラス

        /// <summary>
        /// 相場設定マスタを、拠点コード逆順にソートする
        /// </summary>
        /// <remarks></remarks>
        private class SCMMrktPriStComparer : Comparer<SCMMrktPriSt>
        {
            public override int Compare( SCMMrktPriSt x, SCMMrktPriSt y )
            {
                int result = y.SectionCode.Trim().CompareTo( x.SectionCode.Trim() );
                if ( result != 0 ) return result;

                return result;
            }
        }
        #endregion
    }

}
