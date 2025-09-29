//**********************************************************************//
// System           :   ＰＭ．ＮＳ
// Sub System       :
// Program name     :   自由帳票（請求書）　リモートオブジェクト
//                  :   PMKAU08004R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   22018 鈴木 正臣
// Date             :   2008.06.12
//----------------------------------------------------------------------//
// Update Note      :
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
//using Broadleaf.Application.UIData; // DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数使用の修正
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
	/// 自由帳票（請求書）　リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票印字位置設定マスタ取得を行うクラスです。</br>
	/// <br>Programmer : 22018　鈴木　正臣</br>
	/// <br>Date       : 2008.06.03</br>
    /// <br></br>
	/// <br>Update Note: 2009.06.26  22018 鈴木 正臣</br>
    /// <br>           : 請求書番号を追加。</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.15  22018 鈴木 正臣</br>
    /// <br>           : 請求書(総括)に対応する為、変更。</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/25  30517 夏野 駿希</br>
    /// <br>           : 森川部品個別対応</br>
    /// <br>           : 入金予定額追加の為、締日，集金月区分コード追加</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/23  30531 大矢　睦美</br>
    /// <br>           : 竹田商会個別対応</br>
    /// <br>           : 消費税転嫁方式追加</br>
    /// <br></br>
    /// <br>Update Note: 2011/02/22  22018 鈴木 正臣</br>
    /// <br>           : 請求書単位の件数が99件の時エラーになる不具合の修正。</br>
    /// <br>Update Note: 2011/11/28  凌小青</br>
    /// <br>           : Redmine#7765の対応。</br>
    /// <br>Update Note: 2012/02/06  許培珠</br>
    /// <br>管理番号　 : 10707327-00 2012/03/28配信分</br>	
    /// <br>           : Redmine#28258 請求書／ログ出力の追加</br>
    /// <br>Update Note: 2012/03/05  許培珠</br>
    /// <br>管理番号　 : 10707327-00 2012/03/28配信分</br>	
    /// <br>           : Redmine#28258 請求書／ログ出力の追加</br>
    /// <br>Update Note: 2012/06/04 30517 夏野 駿希</br>
    /// <br>管理番号　 : </br>	
    /// <br>           : 請求書／ログ出力内容の改良</br>
    /// <br>Update Note: 2012/06/21 30517 夏野 駿希</br>
    /// <br>管理番号　 : </br>	
    /// <br>           : 入金手数料・値引の不具合修正</br>
    /// <br>Update Note: 2012/07/02 30517 夏野 駿希</br>
    /// <br>管理番号　 : </br>	
    /// <br>           : ①親に売上がない場合、入金データを取得出来ない不具合修正</br>
    /// <br>           : ②拠点違いの得意先に入金データが印刷される不具合修正</br>
    /// <br>Update Note: 2012/07/11 yangmj</br>
    /// <br>管理番号　 : </br>	
    /// <br>           : リモーティングクラスにてプライベート変数使用の修正</br>
    /// <br>Update Note  : 2022/10/18 田村顕成</br>
    /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
    /// </remarks>
	[Serializable]
    public class FrePBillDB : RemoteDB, IFrePBillDB
    {
        # region [private フィールド]
        //----- DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
        ////// 請求先別締範囲ディクショナリ（KEY→情報）
        ////private Dictionary<DmdRangeEachClaimKey, DmdRangeEachClaim> _dmdRangeEachClaimDic;
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        //// 請求先別締範囲ディクショナリ（KEY→情報）
        //private Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic;
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        //// 親得意先ディクショナリ（子→親）
        //private Dictionary<int, List<DmdSummaryKey>> _parentCustomerDic;
        //// 子得意先ディクショナリ（親→子）
        //private Dictionary<int, List<int>> _childCustomerDic;
        //// --- ADD m.suzuki 2010/02/15 ---------->>>>>
        //// 得意先(総括設定)のディクショナリ（親→子）  Dictionary<総括得意先, List<KeyValuePair<請求拠点,請求得意先>>>
        //private Dictionary<int, List<KeyValuePair<string,int>>> _sumCustChildDic;
        //// 総括親ディクショナリ（子→親）
        //private Dictionary<int, int> _sumCustParentDic;
        ////// 総括拠点ディクショナリ（総括得意先→総括拠点）
        ////private Dictionary<int, string> _sumCustSectionDic;
        //// --- ADD m.suzuki 2010/02/15 ----------<<<<<

        //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
        //private Dictionary<string, object> requestMessage = new Dictionary<string, object>();
        //private string logExceptionMsg; 
        //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
        //----- DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
        # endregion

        /// <summary>
        /// 自由帳票（請求書）　リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22018 鈴木　正臣</br>
		/// <br>Date       : 2008.06.03</br>
		/// </remarks>
        public FrePBillDB()
		{
        }

        #region [Search]
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.06.12</br>
        /// </remarks>
        public int Search( object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg )
        {
            return SearchProc( frePrtCmnExtPrmWork, out frePSalesSlipRetWorkList, out frePMasterList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchProc( object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlEncryptInfo sqlEncryptInfo = null;
            msgDiv = false;
            errMsg = string.Empty;
            frePSalesSlipRetWorkList = null;
            frePMasterList = null;
            //this.logExceptionMsg = string.Empty; // ADD 2012/02/06 xupz for redmine#28258// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
            string logExceptionMsg = string.Empty;// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
            // デシリアライズ
            FrePBillParaWork extPrm = (FrePBillParaWork)XmlByteSerializer.Deserialize( (byte[])frePrtCmnExtPrmWork, typeof( FrePBillParaWork ) );

            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //// 暗号化情報設定
                //if ((extPrm.CipherItemsLs != null) && (extPrm.CipherItemsLs.Count > 0))
                //{
                //    sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, extPrm.CipherItemsLs.ToArray());
                //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //}

                // 関連マスタ抽出
                status = SearchSetInfos( extPrm, out frePMasterList, ref sqlConnection );

                // データ抽出
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                    //status = SearchProc( extPrm, out frePSalesSlipRetWorkList, ref sqlConnection );
                    //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>)
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (this.logExceptionMsg != string.Empty) )
                    //{
                    //    errMsg = this.logExceptionMsg;
                    //}
                    //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
                    //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                    //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                    status = SearchProc(extPrm, out frePSalesSlipRetWorkList, ref sqlConnection, ref logExceptionMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (logExceptionMsg != string.Empty))
                    {
                        errMsg = logExceptionMsg;
                    }
                    //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    frePSalesSlipRetWorkList = null;
                    frePMasterList = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票（請求書）抽出処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePDailyExtRetDB_Search\n"+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //暗号化キークローズ
                if ( sqlEncryptInfo != null )
                {
                    if ( sqlEncryptInfo.IsOpen )
                    {
                        sqlEncryptInfo.CloseSymKey( ref sqlConnection );
                    }
                }
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePBillRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="logExceptionMsg"></param>
        /// <returns></returns>
        //private int SearchProc( FrePBillParaWork extPrm, out object frePBillRetWorkList, ref SqlConnection sqlConnection )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private int SearchProc(FrePBillParaWork extPrm, out object frePBillRetWorkList, ref SqlConnection sqlConnection, ref string logExceptionMsg)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
            // 得意先(総括設定)のディクショナリ（親→子）  Dictionary<総括得意先, List<KeyValuePair<請求拠点,請求得意先>>>
            Dictionary<int, List<KeyValuePair<string,int>>> _sumCustChildDic =  new Dictionary<int, List<KeyValuePair<string, int>>>();
            // 総括拠点ディクショナリ（総括得意先→総括拠点）
            Dictionary<int, int> _sumCustParentDic = new Dictionary<int,int>();
            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            frePBillRetWorkList = null;

            //# region [得意先情報取得]
            //// 明細部の抽出が必要なフォームレイアウトのSlipPrtKindのリスト
            //List<int> detailExistsFormList = new List<int>( new int[] { 60, 70 } );

            //// 請求先別締範囲取得処理
            //if ( extPrm != null && extPrm.FrePBillParaKeyList != null && extPrm.FrePBillParaKeyList.Count > 0 && detailExistsFormList.Contains( extPrm.SlipPrtKind ) )
            //{
            //    _dmdRangeEachClaimDic = GetDmdRangeEachClaimDic( extPrm.FrePBillParaKeyList[0].AddUpDate, ref sqlConnection );
            //}
            //# endregion

            // --- ADD m.suzuki 2010/02/15 ---------->>>>>
            # region [総括設定の取得]
            if ( extPrm.UseSumCust )
            {
                //-----------------------------------------------------------
                // 総括設定のディクショナリを生成（全件）
                //-----------------------------------------------------------

                // 得意先マスタ(総括設定)の取得
                ArrayList sumCustList;
                status = SearchSumCustSt( extPrm, out sumCustList, ref sqlConnection );

                // ディクショナリへ退避
                _sumCustChildDic = new Dictionary<int, List<KeyValuePair<string, int>>>();
                _sumCustParentDic = new Dictionary<int, int>();
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    foreach ( SumCustStWork sumCustSt in sumCustList )
                    {
                        // 親→子のディクショナリ
                        if ( _sumCustChildDic.ContainsKey( sumCustSt.SumClaimCustCode ) )
                        {
                            // 既存のKEY
                            _sumCustChildDic[sumCustSt.SumClaimCustCode].Add( new KeyValuePair<string, int>( sumCustSt.DemandAddUpSecCd.Trim(), sumCustSt.CustomerCode ) );
                        }
                        else
                        {
                            // 新規のKEY
                            List<KeyValuePair<string, int>> sumCustChildList = new List<KeyValuePair<string, int>>();
                            sumCustChildList.Add( new KeyValuePair<string, int>( sumCustSt.DemandAddUpSecCd.Trim(), sumCustSt.CustomerCode ) );
                            _sumCustChildDic.Add( sumCustSt.SumClaimCustCode, sumCustChildList );
                        }

                        // 子→親のディクショナリ
                        if ( !_sumCustParentDic.ContainsKey( sumCustSt.CustomerCode ) )
                        {
                            _sumCustParentDic.Add( sumCustSt.CustomerCode, sumCustSt.SumClaimCustCode );
                        }
                    }
                }
            }
            # endregion
            // --- ADD m.suzuki 2010/02/15 ----------<<<<<

            # region [抽出メイン]
            // 対象リストを分割する
            List<List<FrePBillParaWork.FrePBillParaKey>> list = DevelopFrePBillParaKeyList( extPrm.FrePBillParaKeyList );

            // 分割した分繰り返し
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            for ( int index = 0; index < list.Count; index++ )
            {
                // 分割した抽出条件を生成
                FrePBillParaWork newExtPrm = new FrePBillParaWork();
                newExtPrm.EnterpriseCode = extPrm.EnterpriseCode;
                newExtPrm.SlipPrtKind = extPrm.SlipPrtKind;
                newExtPrm.FrePBillParaKeyList = list[index];
                // --- ADD m.suzuki 2010/02/15 ---------->>>>>
                newExtPrm.UseSumCust = extPrm.UseSumCust;
                // --- ADD m.suzuki 2010/02/15 ----------<<<<<

                // 結果
                object retObj;

                // 抽出処理
                //status = SearchProcMain( newExtPrm, out retObj, ref sqlConnection );// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                status = SearchProcMain(newExtPrm, out retObj, ref sqlConnection, _sumCustChildDic, _sumCustParentDic, ref logExceptionMsg);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) break;

                retList.AddRange( (retObj as CustomSerializeArrayList) );
            }
            # endregion


            // 結果を格納
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                frePBillRetWorkList = retList;
            }
            return status;
        }
        /// <summary>
        /// 対象リストから対象リストのリストを生成
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<List<FrePBillParaWork.FrePBillParaKey>> DevelopFrePBillParaKeyList( List<FrePBillParaWork.FrePBillParaKey> list )
        {
            const int ct_DevideCount = 100;
            List<List<FrePBillParaWork.FrePBillParaKey>> listList = new List<List<FrePBillParaWork.FrePBillParaKey>>();

            int rangeStart = 0;
            int rangeCount = ct_DevideCount;

            while ( rangeStart < list.Count )
            {
                listList.Add( new List<FrePBillParaWork.FrePBillParaKey>() );
                // --- UPD m.suzuki 2011/02/22 ---------->>>>>
                //if ( rangeStart + rangeCount - 1 > list.Count )
                if ( rangeStart + rangeCount > list.Count )
                // --- UPD m.suzuki 2011/02/22 ----------<<<<<
                {
                    rangeCount = list.Count - rangeStart;
                }
                listList[listList.Count - 1].AddRange( list.GetRange( rangeStart, rangeCount ) );
                rangeStart += ct_DevideCount;
            }

            return listList;
        }
        ///// <summary>
        ///// 請求先別締め範囲取得処理（抽出前処理）
        ///// </summary>
        ///// <param name="addUpDate"></param>
        ///// <param name="sqlConnection"></param>
        ///// <returns></returns>
        //private Dictionary<int, DmdRangeEachClaim> GetDmdRangeEachClaimDic( int addUpDate, ref SqlConnection sqlConnection )
        //{
        //    Dictionary<int, DmdRangeEachClaim> retDic = new Dictionary<int, DmdRangeEachClaim>();
            
        //    return retDic;
        //}

        /// <summary>
        /// データ抽出処理（メイン）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePBillRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_sumCustChildDic"></param>
        /// <param name="_sumCustParentDic"></param>
        /// <param name="logExceptionMsg"></param>
        /// <returns></returns>
        //private int SearchProcMain( FrePBillParaWork extPrm, out object frePBillRetWorkList, ref SqlConnection sqlConnection ) //DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private int SearchProcMain(FrePBillParaWork extPrm, out object frePBillRetWorkList, ref SqlConnection sqlConnection, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, Dictionary<int, int> _sumCustParentDic, ref string logExceptionMsg) // ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
            // 請求先別締範囲ディクショナリ（KEY→情報）
            Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic = new Dictionary<string,DmdRangeEachClaim>();

            // 子得意先ディクショナリ（親→子）
            Dictionary<int, List<int>> _childCustomerDic = new Dictionary<int,List<int>>();

            Dictionary<string, object> requestMessage = new Dictionary<string, object>();
            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
            frePBillRetWorkList = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            List<FrePBillHeadWork> billList = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            //Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>> salesListDic = null;
            //Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>> depositListDic = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            Dictionary<string, List<FrePBillDetailWork>> salesListDic = null;
            Dictionary<string, List<FrePBillDetailWork>> depositListDic = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            // 請求書ヘッダ抽出処理
            //status = SearchProcOfBill(extPrm, out billList, sqlConnection);// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
            status = SearchProcOfBill(extPrm, out billList, sqlConnection, ref _dmdRangeEachClaimDic, _sumCustChildDic, _sumCustParentDic, ref requestMessage);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/17 ADD
            // 締範囲の算出
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //status = SearchProcOfDmdRangeSt(extPrm, billList, sqlConnection);// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                status = SearchProcOfDmdRangeSt(extPrm, billList, sqlConnection, ref _dmdRangeEachClaimDic, ref requestMessage);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/17 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            // 対象得意先の取得
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if (extPrm != null && extPrm.FrePBillParaKeyList != null && extPrm.FrePBillParaKeyList.Count > 0)
                {
                    //status = SearchProcOfTargetCustomers( extPrm, extPrm.FrePBillParaKeyList[0].GetAddUpDateLongDate(), sqlConnection );// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                    status = SearchProcOfTargetCustomers(extPrm, extPrm.FrePBillParaKeyList[0].GetAddUpDateLongDate(), sqlConnection, ref _childCustomerDic); // ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

            // 請求書売上明細抽出処理
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //status = SearchProcOfSales(extPrm, out salesListDic, sqlConnection);// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                status = SearchProcOfSales(extPrm, out salesListDic, sqlConnection, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic, ref requestMessage);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                if ( salesListDic == null )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                    //salesListDic = new Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>>();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                    salesListDic = new Dictionary<string, List<FrePBillDetailWork>>();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                }
                if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // 請求書入金明細抽出処理
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //status = SearchProcOfDeposit(extPrm, out depositListDic, sqlConnection);// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                status = SearchProcOfDeposit(extPrm, out depositListDic, sqlConnection, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic, ref requestMessage);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                if ( depositListDic == null )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                    //depositListDic = new Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>>();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                    depositListDic = new Dictionary<string, List<FrePBillDetailWork>>();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                }
                if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            // 返却データ生成
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                CustomSerializeArrayList retList = new CustomSerializeArrayList();
                foreach ( FrePBillHeadWork billWork in billList )
                {
                    CustomSerializeArrayList newBillList = new CustomSerializeArrayList();
                    newBillList.Add( billWork );

                    FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey( 
                                                                    billWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(), 
                                                                    billWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                                    billWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(), 
                                                                    billWork.CUSTDMDPRCRF_CUSTOMERCODERF, 
                                                                    billWork.CUSTDMDPRCRF_ADDUPDATERF );
                    
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                    //// 売上明細に同一キーのリストがあれば、請求書リストに追加
                    //if ( salesListDic.ContainsKey( key ) )
                    //{
                    //    newBillList.Add( salesListDic[key] );
                    //}
                    //else
                    //{
                    //    newBillList.Add( new List<FrePBillDetailWork>() );
                    //}
                    //// 入金明細に同一キーのリストがあれば、請求書リストに追加
                    //if ( depositListDic.ContainsKey( key ) )
                    //{
                    //    newBillList.Add( depositListDic[key] );
                    //}
                    //else
                    //{
                    //    newBillList.Add( new List<FrePBillDetailWork>() );
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                    string keyString = key.CreateKey();
                    // 売上明細に同一キーのリストがあれば、請求書リストに追加
                    if ( salesListDic.ContainsKey( keyString ) )
                    {
                        newBillList.Add(salesListDic[keyString]);
                    }
                    else
                    {
                        newBillList.Add( new List<FrePBillDetailWork>() );
                    }
                    // 入金明細に同一キーのリストがあれば、請求書リストに追加
                    if ( depositListDic.ContainsKey( keyString ) )
                    {
                        newBillList.Add( depositListDic[keyString] );
                    }
                    else
                    {
                        newBillList.Add( new List<FrePBillDetailWork>() );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                    retList.Add( newBillList );
                }
                frePBillRetWorkList = retList;
            }
   
            // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //明細請求書発行時、鑑部分の今回売上額と明細合計（入金を含まない）を比較して、違いがあった場合はＬＯＧ出力する
                //返却データの処理
                CustomSerializeArrayList requestInfo = new CustomSerializeArrayList();
                requestInfo = (CustomSerializeArrayList)frePBillRetWorkList;

                // 請求書情報リスト
                List<RequestLogData> requestLogDataList = new List<RequestLogData>();
                //ログフラグ
                int logFlag = 0;

                foreach (CustomSerializeArrayList item in requestInfo)
                {
                    CustomSerializeArrayList requestInfoDetail = item;

                    FrePBillHeadWork frePBillHeadWork = new FrePBillHeadWork();
                    List<FrePBillDetailWork> frePBillSalesDetailWorkList = new List<FrePBillDetailWork>();
                    List<FrePBillDetailWork> frePBillDemandDetailWorkList = new List<FrePBillDetailWork>(); // add 2012/06/04

                    if(requestInfoDetail[0] != null)
                    {
                        // 自由帳票請求書ヘッダ（ヘッダ）
                        frePBillHeadWork = (FrePBillHeadWork)requestInfoDetail[0];
                    }
                        
                    if(requestInfoDetail[1] != null)
                    {
                        // 自由帳票請求書明細（売上）
                        frePBillSalesDetailWorkList = (List<FrePBillDetailWork>)requestInfoDetail[1];
                    }

                    // add 2012/06/04 >>>
                    if (requestInfoDetail[2] != null)
                    {
                        frePBillDemandDetailWorkList = (List<FrePBillDetailWork>)requestInfoDetail[2];
                    }
                    // add 2012/06/04 <<<
     
                    //得意先の今回売上金額
                    Int64 thisTimeSalesPrice = 0;
                    //明細合計金額（入金を含まない）
                    Int64 salesTotalPrice = 0;
                    //差額
                    Int64 differentPrice = 0;

                    // add 2012/06/04 >>>
                    // 得意先の今回入金額
                    Int64 thisTimeDmdNrml = 0;
                    // 明細合計金額（入金のみ）
                    Int64 demandTotalPrice = 0;
                    // 前回締日
                    int startCAddUpUpdDate = 0;

                    DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                    frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                    frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF,
                                    frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                    frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF);
                    string keyString = key.CreateKey();
                    startCAddUpUpdDate = _dmdRangeEachClaimDic[keyString].DmdRangeSt;
                    // add 2012/06/04 <<<

                    // 得意先の今回売上金額(今回売上金額-今回返品金額-今回値引金金額)
                    thisTimeSalesPrice = frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;

                    // add 2012/06/04 >>>
                    // 得意先の今回入金額（今回入金額（通常））
                    thisTimeDmdNrml = frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                    // add 2012/06/04 <<<

                    // 明細合計金額（入金を含まない）
                    foreach (FrePBillDetailWork frePBillDetailWork in frePBillSalesDetailWorkList)
                    {

                        salesTotalPrice += frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF;
                    }

                    // add 2012/06/04 >>>
                    // 明細合計金額（入金のみ）
                    if (frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim() == "00" &&
                        frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0)
                    {
                        if (frePBillDemandDetailWorkList.Count != 0)
                        {
                            // add 2012/06/21 >>>
                            // 手数料・値引加算のキー
                            List<string> keyList = new List<string>();
                            // add 2012/06/21 <<<
                            foreach (FrePBillDetailWork frePBillDemandWork in frePBillDemandDetailWorkList)
                            {
                                demandTotalPrice += frePBillDemandWork.DEPSITDTLRF_DEPOSITRF;
                                // add 2012/06/21 >>>
                                string depKey = string.Format("{0}{1}", frePBillDemandWork.DEPSITMAINRF_ACPTANODRSTATUSRF, frePBillDemandWork.DEPSITMAINRF_DEPOSITSLIPNORF);
                                if (!keyList.Contains(depKey))
                                {
                                    demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_FEEDEPOSITRF;
                                    // キー更新
                                    keyList.Add(depKey);
                                }
                                // add 2012/06/21 <<<
                            }
                            // del 2012/06/21 >>>
                            //demandTotalPrice += frePBillDemandDetailWorkList[0].DEPSITMAINRF_DISCOUNTDEPOSITRF;
                            //demandTotalPrice += frePBillDemandDetailWorkList[0].DEPSITMAINRF_FEEDEPOSITRF;
                            // del 2012/06/21 <<<
                        }

                    }
                    else
                    {
                        // 集計レコード以外は0
                        demandTotalPrice = 0;
                    }
                    // add 2012/06/04 <<<

                    // 得意先の今回売上金額と、明細合計（入金を含まない）を比較して、違いがあった場合ＬＯＧ出力する。
                    // updt 2012/06/04 >>>
                    // または得意先の今回入金額と明細合計（入金のみ）を比較して、違いがあった場合、LOG出力する。
                    //if (thisTimeSalesPrice != salesTotalPrice)
                    if (thisTimeSalesPrice != salesTotalPrice || thisTimeDmdNrml != demandTotalPrice)
                    // updt 2012/06/04 <<<
                    {
                        RequestLogData requestLogData = new RequestLogData();
                        // 得意先CD
                        int customerCode = frePBillHeadWork.CADD_CUSTOMERCODERF;
                        requestLogData.CustomerCode = customerCode;
                        if (customerCode == 0)
                        {
                            requestLogData.CustomerCode = frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF;
                        }

                        //前回請求処理日
                        DateTime forwardRequestDay = new DateTime();
                        // del 2012/06/04 >>>
                        //for (int index = 0; index < extPrm.FrePBillParaKeyList.Count; index++)
                        //{
                        //    //検索条件に前回請求処理日を取得
                        //    forwardRequestDay = extPrm.FrePBillParaKeyList[index].AddUpDate;
                        //}
                        // del 2012/06/04 <<<
                        // add 2012/06/04 >>>
                        try
                        {
                            forwardRequestDay = new DateTime(startCAddUpUpdDate / 10000, startCAddUpUpdDate % 10000 / 100, startCAddUpUpdDate % 100);
                        }
                        catch
                        {
                            forwardRequestDay = DateTime.MinValue;
                        }
                        // add 2012/06/04 <<<
                        requestLogData.AddupDate = forwardRequestDay;

                        //今回金額
                        requestLogData.ThisTimeSalesPrice = thisTimeSalesPrice;

                        //明細合計金額
                        requestLogData.TotalPrice = salesTotalPrice;

                        // 差額
                        differentPrice = salesTotalPrice - thisTimeSalesPrice;
                        requestLogData.DifferentPrice = differentPrice;

                        // add 2012/06/04 >>>
                        //今回入金額
                        requestLogData.ThisTimeDemandPrice = thisTimeDmdNrml;

                        //明細合計金額（入金）
                        requestLogData.TotalDemandPrice = demandTotalPrice;

                        // 入金差額
                        differentPrice = demandTotalPrice - thisTimeDmdNrml;
                        requestLogData.DifferentDemandPrice = differentPrice;
                        // add 2012/06/04 <<<

                        requestLogDataList.Add(requestLogData);

                        logFlag ++;
                     }

                }

                // LOGが有る
                if (logFlag > 0) 
                {
                    //LogWrite(requestLogDataList, requestMessage);// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                    LogWrite(requestLogDataList, requestMessage, ref logExceptionMsg);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                }
            }
            // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<

            return status;
        }

        #endregion

        #region [private メソッド]

        # region [マスタ抽出]
        /// <summary>
        /// 自由帳票（請求書）関連マスタ検索処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePMasterList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns>ステータス</returns>
        /// <remarks>請求書発行に必要な各種マスタを格納して返します。</remarks>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        private int SearchSetInfos( FrePBillParaWork extPrm, out object frePMasterList, ref SqlConnection sqlConnection )
        {
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            CustomSerializeArrayList dmdPrtPtnList = new CustomSerializeArrayList();
            int status;

            // 請求書印刷パターン設定 (MAKAU09154R.DmdPrtPtnDB)
            status = SearchDmdPrtPtn( extPrm, ref dmdPrtPtnList, ref sqlConnection );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && dmdPrtPtnList.Count > 0 )
            {
                retList.Add( dmdPrtPtnList[0] );
            }

            // 自由帳票印字位置設定 (SFANL08124R.FrePrtPSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchFrePrtPSet( extPrm, (DmdPrtPtnWork[])dmdPrtPtnList[0], ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 得意先マスタ（請求書）設定　(PMKHN09084R.CustDmdSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchCustDmdSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 伝票出力先設定 (DCKHN09264R.SlipOutputSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchSlipOutputSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 請求全体設定 (SFUKK09104R.BillAllStDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchBillAllSt( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 請求印刷設定 (SFUKK09084R.BillPrtStDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchBillPrtSt( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 全体初期値設定 (SFCMN09084R.AllDefSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchAllDefSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            //売上金額処理区分設定 (MAHNB09134R.SalesProcMoneyDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchSalesProcMoney(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<

            frePMasterList = retList;
            return status;
        }

        /// <summary>
        /// Search 請求書印刷パターン設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchDmdPrtPtn( FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            DmdPrtPtnDB dmdPrtPtnDB = new DmdPrtPtnDB();
            
            // 検索
            DmdPrtPtnWork paraWork = new DmdPrtPtnWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.DataInputSystem = 0;
            paraWork.SlipPrtKind = 0;
            paraWork.SlipPrtSetPaperId = string.Empty;

            object retObj;
            int status = dmdPrtPtnDB.Search( out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData0 );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null && (retObj as ArrayList).Count > 0 )
            {
                refRetList.Add( (retObj as ArrayList).ToArray( typeof( DmdPrtPtnWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 伝票出力先設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchSlipOutputSet( FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            SlipOutputSetDB slipOutputSetDB = new SlipOutputSetDB();

            // 検索
            ArrayList retList;
            SearchSlipOutputSetParaWork paraWork = new SearchSlipOutputSetParaWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.CashRegisterNo = -1;
            paraWork.DataInputSystem = 0;
            paraWork.SlipPrtKind = -1;
            int status = slipOutputSetDB.SearchSlipOutputSetProc( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( SlipOutputSetWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 得意先マスタ(請求書管理)設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchCustDmdSet( FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            CustDmdSetDB custDmdSetDB = new CustDmdSetDB();

            // 検索
            ArrayList retList = new ArrayList();
            CustDmdSetWork paraWork = new CustDmdSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            // SQLトランザクション開始
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            int status = custDmdSetDB.Search( ref retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                // コミット
                sqlTransaction.Commit();

                refRetList.Add( retList.ToArray( typeof( CustDmdSetWork ) ) );
            }
            else
            {
                // ロールバック
                sqlTransaction.Rollback();
            }
            sqlTransaction.Dispose();

            return status;
        }
        /// <summary>
        /// Search 請求全体設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchBillAllSt( FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            BillAllStDB billAllStDB = new BillAllStDB();

            // 検索
            ArrayList retList = new ArrayList();
            BillAllStWork paraWork = new BillAllStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            SqlTransaction sqlTransaction = null;
            int status = billAllStDB.Search( ref retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( BillAllStWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 請求印刷設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchBillPrtSt( FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            BillPrtStDB billPrtStDB = new BillPrtStDB();

            // 検索
            BillPrtStWork paraWork = new BillPrtStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            //int status = billPrtStDB.Search( ref retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );
            object retObj;
            ArrayList retList;
            int status = billPrtStDB.SearchProc( out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null )
            {
                if ( retObj != null )
                {
                    retList = (retObj as ArrayList);
                    refRetList.Add( retList.ToArray( typeof( BillPrtStWork ) ) );
                }
            }
            return status;
        }
        /// <summary>
        /// Search 全体初期値設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchAllDefSet( FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            AllDefSetDB allDefSetDB = new AllDefSetDB();

            // 検索
            AllDefSetWork paraWork = new AllDefSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            ArrayList retList;
            int status = allDefSetDB.Search( out retList, paraWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0 );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( AllDefSetWork ) ) );
            }
            return status;
        }

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        /// <summary>
        /// Search 売上金額処理区分設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSalesProcMoney(FrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();

            //検索
            SalesProcMoneyWork paraWork = new SalesProcMoneyWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;
            ArrayList retList;
            int status = salesProcMoneyDB.SearchSalesProcMoneyProc(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            //取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(SalesProcMoneyWork)));
            }
            return status;
            
        }
        // --- ADD END 田村顕成 2022/10/18 -----<<<<<

        /// <summary>
        /// Search 自由帳票印字位置設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="dmdPrtPtnWorkList"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchFrePrtPSet( FrePBillParaWork extPrm, DmdPrtPtnWork[] dmdPrtPtnWorkList, ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection )
        {
            List<FrePrtPSetDB.FrePrtPSetReadKey> keyList = new List<FrePrtPSetDB.FrePrtPSetReadKey>();
            foreach ( DmdPrtPtnWork dmdPrtPtnWork in dmdPrtPtnWorkList )
            {
                keyList.Add( GetFrePrtPSetKey( dmdPrtPtnWork ) );
            }

            // ユーザーＤＢ検索
            FrePrtPSetDB frePrtPSetDB = new FrePrtPSetDB();
            List<FrePrtPSetWork> frePrtPSetWorkList;
            int status = frePrtPSetDB.SearchFrePrtPSetProc( extPrm.EnterpriseCode, keyList, out frePrtPSetWorkList, ref sqlConnection );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && frePrtPSetWorkList != null )
            {
                retList.Add( frePrtPSetWorkList.ToArray() );
            }
            return status;
        }
        /// <summary>
        /// 自由帳票印字位置設定Readキー取得処理
        /// </summary>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <returns>自由帳票印字位置設定Readキー</returns>
        private FrePrtPSetDB.FrePrtPSetReadKey GetFrePrtPSetKey( DmdPrtPtnWork dmdPrtPtnWork )
        {
            FrePrtPSetDB.FrePrtPSetReadKey key = new FrePrtPSetDB.FrePrtPSetReadKey();
            key.OutputFormFileName = dmdPrtPtnWork.OutputFormFileName;

            if ( dmdPrtPtnWork.SlipPrtSetPaperId.StartsWith( dmdPrtPtnWork.OutputFormFileName ) )
            {
                string DerivNoText = dmdPrtPtnWork.SlipPrtSetPaperId.Substring( dmdPrtPtnWork.OutputFormFileName.Length, dmdPrtPtnWork.SlipPrtSetPaperId.Length - dmdPrtPtnWork.OutputFormFileName.Length );
                try
                {
                    key.UserPrtPprIdDerivNo = Int32.Parse( DerivNoText );
                }
                catch
                {
                    key.UserPrtPprIdDerivNo = 0;
                }
            }

            return key;
        }
        // --- ADD m.suzuki 2010/02/15 ---------->>>>>
        /// <summary>
        /// 得意先マスタ(総括設定)の取得
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSumCustSt( FrePBillParaWork extPrm, out ArrayList list, ref SqlConnection sqlConnection )
        {
            SumCustStWork paraWork = new SumCustStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            SqlTransaction sqlTransaction = null;
            list = new ArrayList();

            SumCustStDB sumCustStDB = new SumCustStDB();
            int status = sumCustStDB.Search( ref list, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            return status;
        }
        // --- ADD m.suzuki 2010/02/15 ----------<<<<<

        ///// <summary>
        ///// 自由帳票印字位置設定Readキー取得処理
        ///// </summary>
        ///// <param name="slipPrtSetWork">伝票印字位置設定</param>
        ///// <returns>自由帳票印字位置設定Readキー</returns>
        //private FrePrtPSetDB.FrePrtPSetReadKey GetFrePrtPSetKey( SlipPrtSetWork slipPrtSetWork )
        //{
        //    FrePrtPSetDB.FrePrtPSetReadKey key = new FrePrtPSetDB.FrePrtPSetReadKey();
        //    key.OutputFormFileName = slipPrtSetWork.OutputFormFileName;

        //    if ( slipPrtSetWork.SlipPrtSetPaperId.StartsWith( slipPrtSetWork.OutputFormFileName ) )
        //    {
        //        string DerivNoText = slipPrtSetWork.SlipPrtSetPaperId.Substring( slipPrtSetWork.OutputFormFileName.Length, slipPrtSetWork.SlipPrtSetPaperId.Length - slipPrtSetWork.OutputFormFileName.Length );
        //        try
        //        {
        //            key.UserPrtPprIdDerivNo = Int32.Parse( DerivNoText );
        //        }
        //        catch
        //        {
        //            key.UserPrtPprIdDerivNo = 0;
        //        }
        //    }

        //    return key;
        //}
        //# endregion

        //# region [売上データ抽出]
        ///// <summary>
        ///// 自由帳票日次帳票グループ情報検索処理（メイン部）
        ///// </summary>
        ///// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        ///// <param name="retObj">印字位置設定ワーククラス配列</param>
        ///// <param name="sqlConnection">SQLコネクション</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note		: 指定された自由帳票印字位置設定検索結果クラスワークLISTを取得します。</br>
        ///// <br>Programmer	: 22018 鈴木　正臣</br>
        ///// <br>Date		: 2008.06.03</br>
        ///// </remarks>
        //private int SearchProcOfSlip( FrePSalesSlipParaWork extPrm, out List<FrePSalesSlipWork> retObj, SqlConnection sqlConnection )
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    List<FrePSalesSlipWork> frePSalesSlipWorkList = new List<FrePSalesSlipWork>();
        //    retObj = null;

        //    try
        //    {
        //        //-------------------------------------------------------------------
        //        // 対象テーブル
        //        //   売上データ           SalesSlipRF 
        //        //   拠点情報設定マスタ   SecInfoSetRF       
        //        //   自社名称マスタ       CompanyNmRF
        //        //   画像情報マスタ       ImageInfoRF
        //        //   部門マスタ           SubsectionRF
        //        //   従業員マスタ①       EmployeeRF As EMPINP
        //        //   従業員マスタ②       EmployeeRF As EMPFRT
        //        //   従業員マスタ③       EmployeeRF As EMPSAL
        //        //   得意先マスタ①       CustomerRF As CSTCLM
        //        //   得意先マスタ②       CustomerRF As CSTCST
        //        //   得意先マスタ③       CustomerRF As CSTADR
        //        //   自社情報マスタ       CompanyInfRF
        //        //-------------------------------------------------------------------
        //        SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForSlip( extPrm )
        //            + Environment.NewLine
        //            + " FROM SALESSLIPRF " + Environment.NewLine
        //            + LeftJoin( "SALESSLIPRF", "SECINFOSETRF", string.Empty, new string[] { "SECTIONCODERF" }, new string[] { } )  // 企業cd,拠点cd
        //            + LeftJoin( "SECINFOSETRF", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECINFOSETRF.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" } )    // 企業cd,自社名称cd
        //            + LeftJoin( "COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" } )    // 企業cd,画像情報cd,区分=10
        //            + LeftJoin( "SALESSLIPRF", "SUBSECTIONRF", string.Empty, new string[] { "SUBSECTIONCODERF" }, new string[] { } )   // 企業cd,部門cd
        //            + LeftJoin( "SALESSLIPRF", "EMPLOYEERF", "EMPINP", new string[] { }, new string[] { "SALESSLIPRF.SALESINPUTCODERF=EMPINP.EMPLOYEECODERF" } )   // 企業cd,従業員cd
        //            + LeftJoin( "SALESSLIPRF", "EMPLOYEERF", "EMPFRT", new string[] { }, new string[] { "SALESSLIPRF.FRONTEMPLOYEENMRF=EMPFRT.EMPLOYEECODERF" } )  // 企業cd,従業員cd
        //            + LeftJoin( "SALESSLIPRF", "EMPLOYEERF", "EMPSAL", new string[] { }, new string[] { "SALESSLIPRF.SALESEMPLOYEECDRF=EMPSAL.EMPLOYEECODERF" } )  // 企業cd,従業員cd
        //            + LeftJoin( "SALESSLIPRF", "CUSTOMERRF", "CSTCLM", new string[] { }, new string[] { "SALESSLIPRF.CLAIMCODERF=CSTCLM.CUSTOMERCODERF" } )    // 企業cd,得意先cd
        //            + LeftJoin( "SALESSLIPRF", "CUSTOMERRF", "CSTCST", new string[] { }, new string[] { "SALESSLIPRF.CUSTOMERCODERF=CSTCST.CUSTOMERCODERF" } ) // 企業cd,得意先cd
        //            + LeftJoin( "SALESSLIPRF", "CUSTOMERRF", "CSTADR", new string[] { }, new string[] { "SALESSLIPRF.ADDRESSEECODERF=CSTADR.CUSTOMERCODERF" } )    // 企業cd,得意先cd
        //            + LeftJoin( "SALESSLIPRF", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { } ) // 企業cd
        //            , sqlConnection );

        //        // WHERE文を生成
        //        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extPrm);
        //        // タイムアウト時間設定
        //        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            FrePSalesSlipWork frePSalesSlipWork = new FrePSalesSlipWork();

        //            #region データのコピー

        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACCEPTANORDERNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACCEPTANORDERNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRSTATUSRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARDELIREPAIRSTATUSRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARDELIREPAIRSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARDELIREPAIRSTATUSRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.STOCKREPAIRCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_STOCKREPAIRCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKREPAIRCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RELEVANCECOMPANYCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RELEVANCECOMPANYCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RELEVANCECOMPANYCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ENTRUSTORDERCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ENTRUSTORDERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTRUSTORDERCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCORDERDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCORDERDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OSRCORDERDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEBITNOTEDIVRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEBITNOTEDIVRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEBITNLNKACPTANODRRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEBITNLNKACPTANODRRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AUTODEPOSITSLIPNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AUTODEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.INPUTDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_INPUTDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLDDSTRCTPRTSEXTRACDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLDDSTRCTPRTSEXTRACDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLDDSTRCTPRTSEXTRACDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DATAINPUTSYSTEMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DATAINPUTSYSTEMRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SLIPNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SLIPNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SEARCHSLIPDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SEARCHSLIPDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAINWORKDIVCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAINWORKDIVCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINWORKDIVCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TOPMAINWORKCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TOPMAINWORKCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TOPMAINWORKCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TOPMAINWORKNMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TOPMAINWORKNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TOPMAINWORKNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAINWORKSHORTNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAINWORKSHORTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAINWORKSHORTNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARINSPECTORGECDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARINSPECTORGECDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTORGECDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARINSPECTORGENMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARINSPECTORGENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTORGENMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHECKDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CHECKDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHECKDIVNMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CHECKDIVNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHECKDIVNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.WORKPOINTSHEETNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_WORKPOINTSHEETNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WORKPOINTSHEETNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPSLIPKINDCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPSLIPKINDCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RPSLIPKINDCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPSLIPNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPSLIPNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPSLIPNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPCOMPESTMSLIPNO1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPCOMPESTMSLIPNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOMPESTMSLIPNO1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRSLIPKINDCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRSLIPKINDCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BRSLIPKINDCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRSLIPNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRSLIPNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRSLIPNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRCOMPESTMSLIPNO1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRCOMPESTMSLIPNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BRCOMPESTMSLIPNO1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ESTMORODERKINDCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ESTMORODERKINDCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMORODERKINDCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CSORDERFORMNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CSORDERFORMNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSORDERFORMNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CSCOMPESTMSLIPNO1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CSCOMPESTMSLIPNO1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CSCOMPESTMSLIPNO1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ESTIMATEINPSECCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ESTIMATEINPSECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEINPSECCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DELIGDSINPSECCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DELIGDSINPSECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIGDSINPSECCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEMANDADDUPSECCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEMANDADDUPSECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RESULTSADDUPSECCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RESULTSADDUPSECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.UPDATESECCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_UPDATESECCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ESTIMATEDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ESTIMATEDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARENTERDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARENTERDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARENTERDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CAROUTDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CAROUTDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROUTDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACCEPTANORDERDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACCEPTANORDERDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ADDUPADATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ENTRYEXPECTEDDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ENTRYEXPECTEDDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTRYEXPECTEDDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NEXTTIMEENTRYDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NEXTTIMEENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NEXTTIMEENTRYDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NEXTTIMECIMATDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NEXTTIMECIMATDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NEXTTIMECIMATDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NTIMEAUTOLIAMATDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NTIMEAUTOLIAMATDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMEAUTOLIAMATDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARDELIEXPECTEDDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARDELIEXPECTEDDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARDELIEXPECTEDDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARDELIDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARDELIDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARDELIDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.POSSIBILITYLEVELRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_POSSIBILITYLEVELRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSSIBILITYLEVELRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BUSINESSTALKSRESULTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BUSINESSTALKSRESULTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTALKSRESULTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRONTEMPLOYEECDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRONTEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRONTEMPLOYEENMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRONTEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRONTEMPLOYINOUTCOCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRONTEMPLOYINOUTCOCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTEMPLOYINOUTCOCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MECHAEMPLOYEECDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MECHAEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MECHAEMPLOYEECDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MECHAEMPLOYEENMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MECHAEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MECHAEMPLOYEENMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MECHAEMPLOYINOUTCOCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MECHAEMPLOYINOUTCOCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MECHAEMPLOYINOUTCOCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SALESEMPLOYEECDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SALESEMPLOYEECDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SALESEMPLOYEENMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SALESEMPLOYEENMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SALESEMPLOYINOUTCOCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SALESEMPLOYINOUTCOCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESEMPLOYINOUTCOCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTRPGELAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTRPGELAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTRPGELAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTRPCILAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTRPCILAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTRPCILAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBRBASELAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBRBASELAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBRBASELAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBREXCHLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBREXCHLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBREXCHLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBROPLTLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBROPLTLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBROPLTLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBRIPLTFRMLAVORRTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBRIPLTFRMLAVORRTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBRIPLTFRMLAVORRTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBRBPLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBRBPLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBRBPLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBRMTRLPRCLAVORRTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBRMTRLPRCLAVORRTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBRMTRLPRCLAVORRTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTBRRPLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTBRRPLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CUSTBRRPLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CREDITORLOANCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CREDITORLOANCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CREDITCOMPANYCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CREDITCOMPANYCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CREDITSALESRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CREDITSALESRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITSALESRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CREDITFEERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CREDITFEERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITFEERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEMANDABLETTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEMANDABLETTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEMANDABLETTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEPOSITALLOWANCETTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEPOSITALLOWANCETTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNYDEPOALLOWANCETTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MNYDEPOALLOWANCETTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MNYDEPOALLOWANCETTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPLAVORSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPLAVORSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPLAVORSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPPARTSSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPPARTSSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPPARTSSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRLAVORSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRLAVORSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRLAVORSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BPLAVORSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BPLAVORSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BPLAVORSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRPARTSSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRPARTSSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRPARTSSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MATERIALSSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MATERIALSSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MATERIALSSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BROTHERSSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BROTHERSSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BROTHERSSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARBODYPRICERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARBODYPRICERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CARBODYPRICERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARBODYPRICEBFDISRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARBODYPRICEBFDISRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CARBODYPRICEBFDISRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAKEROPTIONSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAKEROPTIONSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MAKEROPTIONSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEALEROPTIONSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEALEROPTIONSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEALEROPTIONSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ADDEQIPORRPSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ADDEQIPORRPSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADDEQIPORRPSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRSALESTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRSALESTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRSALESTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRDISCOUNTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRDISCOUNTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRDISCOUNTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRCONSTAXTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRCONSTAXTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRCONSTAXTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTTAXTOTALRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTTAXTOTALRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTTAXTOTALRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTTAXFREETOTALRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTTAXFREETOTALRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTTAXFREETOTALRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTCONSTAXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTCONSTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTCONSTAXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPLAVORCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPLAVORCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPLAVORCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPPARTSCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPPARTSCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPPARTSCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTOTALLAVORSALESRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTOTALLAVORSALESRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTOTALLAVORSALESRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTTLPARTSSALESRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTTLPARTSSALESRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTTLPARTSSALESRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTOTALLAVORCOSTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTOTALLAVORCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTOTALLAVORCOSTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTTLPARTSCOSTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTTLPARTSCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTTLPARTSCOSTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREETOTALLAVORSALESRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREETOTALLAVORSALESRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREETOTALLAVORSALESRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREETOTALPARTSSALESRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREETOTALPARTSSALESRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREETOTALPARTSSALESRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREEOSRCTTLLAVORSALERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREEOSRCTTLLAVORSALERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREEOSRCTTLLAVORSALERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREEOSRCTTLPARTSSALERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREEOSRCTTLPARTSSALERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREEOSRCTTLPARTSSALERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRLAVORCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRLAVORCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRLAVORCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BPLAVORCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BPLAVORCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BPLAVORCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRPARTSCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRPARTSCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRPARTSCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MATERIALSCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MATERIALSCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MATERIALSCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BROTHERSCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BROTHERSCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BROTHERSCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARBODYCOSTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARBODYCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CARBODYCOSTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAKEROPTIONCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAKEROPTIONCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MAKEROPTIONCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEALEROPTIONCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEALEROPTIONCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEALEROPTIONCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ADDEQIPORRPCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ADDEQIPORRPCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADDEQIPORRPCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRCOSTTTLRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRCOSTTTLRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRCOSTTTLRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEMANDPRORATACDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEMANDPRORATACDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEMANDPRORATACDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM1CODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM1CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIM1CODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM1NAME1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM1NAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM1NAME1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM1NAME2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM1NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM1NAME2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM2CODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM2CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIM2CODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM2NAME1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM2NAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM2NAME1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM2NAME2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM2NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM2NAME2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM3CODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM3CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIM3CODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM3NAME1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM3NAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM3NAME1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM3NAME2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM3NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM3NAME2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM4CODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM4CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIM4CODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM4NAME1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM4NAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM4NAME1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM4NAME2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM4NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM4NAME2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM5CODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM5CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIM5CODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM5NAME1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM5NAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM5NAME1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CLAIM5NAME2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CLAIM5NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIM5NAME2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTCLAIMCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTCLAIMCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCLAIMCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARCLAIMCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARCLAIMCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARCLAIMCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PRORATE1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_PRORATE1RF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRORATE1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PRORATE2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_PRORATE2RF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRORATE2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PRORATE3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_PRORATE3RF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRORATE3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PRORATE4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_PRORATE4RF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRORATE4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PRORATE5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_PRORATE5RF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRORATE5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AGENTPROPORTDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AGENTPROPORTDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGENTPROPORTDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.REPAIRSALESTTL1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_REPAIRSALESTTL1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REPAIRSALESTTL1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.REPAIRSALESTTL2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_REPAIRSALESTTL2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REPAIRSALESTTL2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.REPAIRSALESTTL3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_REPAIRSALESTTL3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REPAIRSALESTTL3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.REPAIRSALESTTL4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_REPAIRSALESTTL4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REPAIRSALESTTL4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.REPAIRSALESTTL5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_REPAIRSALESTTL5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REPAIRSALESTTL5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRDISCTTL1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRDISCTTL1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRDISCTTL1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRDISCTTL2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRDISCTTL2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRDISCTTL2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRDISCTTL3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRDISCTTL3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRDISCTTL3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRDISCTTL4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRDISCTTL4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRDISCTTL4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACPTANODRDISCTTL5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACPTANODRDISCTTL5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPTANODRDISCTTL5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPCONSUMPTIONTAX1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPCONSUMPTIONTAX1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPCONSUMPTIONTAX1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPCONSUMPTIONTAX2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPCONSUMPTIONTAX2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPCONSUMPTIONTAX2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPCONSUMPTIONTAX3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPCONSUMPTIONTAX3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPCONSUMPTIONTAX3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPCONSUMPTIONTAX4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPCONSUMPTIONTAX4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPCONSUMPTIONTAX4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPCONSUMPTIONTAX5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPCONSUMPTIONTAX5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPCONSUMPTIONTAX5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARIOUSCOSTTTL1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARIOUSCOSTTTL1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARIOUSCOSTTTL1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARIOUSCOSTTTL2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARIOUSCOSTTTL2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARIOUSCOSTTTL2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARIOUSCOSTTTL3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARIOUSCOSTTTL3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARIOUSCOSTTTL3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARIOUSCOSTTTL4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARIOUSCOSTTTL4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARIOUSCOSTTTL4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARIOUSCOSTTTL5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARIOUSCOSTTTL5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARIOUSCOSTTTL5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXTINTTLVARCOST1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXTINTTLVARCOST1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXTINTTLVARCOST1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXTINTTLVARCOST2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXTINTTLVARCOST2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXTINTTLVARCOST2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXTINTTLVARCOST3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXTINTTLVARCOST3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXTINTTLVARCOST3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXTINTTLVARCOST4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXTINTTLVARCOST4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXTINTTLVARCOST4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXTINTTLVARCOST5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXTINTTLVARCOST5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXTINTTLVARCOST5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXFREETTLVARCOST1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXFREETTLVARCOST1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXFREETTLVARCOST1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXFREETTLVARCOST2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXFREETTLVARCOST2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXFREETTLVARCOST2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXFREETTLVARCOST3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXFREETTLVARCOST3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXFREETTLVARCOST3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXFREETTLVARCOST4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXFREETTLVARCOST4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXFREETTLVARCOST4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAXFREETTLVARCOST5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TAXFREETTLVARCOST5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXFREETTLVARCOST5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTCONSTAXTTL1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTCONSTAXTTL1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTCONSTAXTTL1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTCONSTAXTTL2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTCONSTAXTTL2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTCONSTAXTTL2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTCONSTAXTTL3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTCONSTAXTTL3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTCONSTAXTTL3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTCONSTAXTTL4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTCONSTAXTTL4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTCONSTAXTTL4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.VARCSTCONSTAXTTL5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_VARCSTCONSTAXTTL5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("VARCSTCONSTAXTTL5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEPOSITALLOWANCE1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEPOSITALLOWANCE1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCE1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNYONDEPOALLOWANCE1RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MNYONDEPOALLOWANCE1RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MNYONDEPOALLOWANCE1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEPOSITALLOWANCE2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEPOSITALLOWANCE2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCE2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNYONDEPOALLOWANCE2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MNYONDEPOALLOWANCE2RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MNYONDEPOALLOWANCE2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEPOSITALLOWANCE3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEPOSITALLOWANCE3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCE3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNYONDEPOALLOWANCE3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MNYONDEPOALLOWANCE3RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MNYONDEPOALLOWANCE3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEPOSITALLOWANCE4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEPOSITALLOWANCE4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCE4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNYONDEPOALLOWANCE4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MNYONDEPOALLOWANCE4RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MNYONDEPOALLOWANCE4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DEPOSITALLOWANCE5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DEPOSITALLOWANCE5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCE5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNYONDEPOALLOWANCE5RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MNYONDEPOALLOWANCE5RF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MNYONDEPOALLOWANCE5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTOMERCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTOMERSUBCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NAME2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.HONORIFICTITLERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_HONORIFICTITLERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.KANARF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_KANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OFFICETELNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OFFICETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OFFICEFAXNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OFFICEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAINCONTACTCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAINCONTACTCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TELNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TELNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SEARCHTELNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SEARCHTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CORPORATEDIVCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CORPORATEDIVCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AACOUNTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AACOUNTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AACOUNTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.STOCKCARMNGNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_STOCKCARMNGNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKCARMNGNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARMNGNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARMNGNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NUMBERPLATE1CODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NUMBERPLATE1NAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NUMBERPLATE2RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NUMBERPLATE3RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NUMBERPLATE4RF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ENTRYDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTRYDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FIRSTENTRYDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAKERPARTSSRCHCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAKERPARTSSRCHCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERPARTSSRCHCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAKERCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AIRAMAKERCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AIRAMAKERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AIRAMAKERCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MAKERNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AIRAMAKERNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AIRAMAKERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AIRAMAKERNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MODELCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MODELCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MODELSUBCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MODELNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MODELNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.GRADECODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_GRADECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRADECODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.GRADENAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_GRADENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRADENAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.GRADEFULLNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_GRADEFULLNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRADEFULLNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARINSPECTCERTMODELRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARINSPECTCERTMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SERIESMODELRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SERIESMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTOMIZECODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CUSTOMIZECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMIZECODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRAMENORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRAMENORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MODELDESIGNATIONNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CATEGORYNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.INSPECTMATURITYDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_INSPECTMATURITYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARINSPECTYEARRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARINSPECTYEARRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MILEAGERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MILEAGERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MILEMETERDISPVALUNITRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MILEMETERDISPVALUNITRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEMETERDISPVALUNITRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AUTOLIAMATURITYDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AUTOLIAMATURITYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOLIAMATURITYDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DMOUTPUTCONDITIONCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DMOUTPUTCONDITIONCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTPUTCONDITIONCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.THISTIMEMILEAGERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_THISTIMEMILEAGERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("THISTIMEMILEAGERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.THISTIMEMILEAGEDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_THISTIMEMILEAGEDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("THISTIMEMILEAGEDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LASTTIMEMILEAGERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LASTTIMEMILEAGERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LASTTIMEMILEAGERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LASTTIMEMILEAGEDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LASTTIMEMILEAGEDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LASTTIMEMILEAGEDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMECIMATDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMECIMATDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LTIMECIMATDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMEAUTOLIAMATDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMEAUTOLIAMATDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LTIMEAUTOLIAMATDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMECIGENERALCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMECIGENERALCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LTIMECIGENERALCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMECIGENERALNMRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMECIGENERALNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LTIMECIGENERALNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMECHECKCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMECHECKCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LTIMECHECKCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMECHECKNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMECHECKNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LTIMECHECKNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMECHECKDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMECHECKDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LTIMECHECKDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.LTIMEREPAIRDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_LTIMEREPAIRDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LTIMEREPAIRDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DOMESTICFOREIGNCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DOMESTICFOREIGNCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SERIESCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_SERIESCDRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERIESCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.GENRECODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_GENRECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GENRECODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.GENRENAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_GENRENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GENRENAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.COURSECODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_COURSECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COURSECODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.EXISTINGCUSTDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_EXISTINGCUSTDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXISTINGCUSTDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRONTDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRONTDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRONTSECTIONCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRONTSECTIONCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTSECTIONCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OTHERTOTALPROFITRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OTHERTOTALPROFITRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERTOTALPROFITRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OTHEREXPENSETTLCOSTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OTHEREXPENSETTLCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHEREXPENSETTLCOSTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TOTALFREECOSTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TOTALFREECOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALFREECOSTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.POSSIBILITYCONTENTSRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_POSSIBILITYCONTENTSRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSSIBILITYCONTENTSRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BSINSSTLKRSTCONTENTSRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BSINSSTLKRSTCONTENTSRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BSINSSTLKRSTCONTENTSRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TOTALVARCOSTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TOTALVARCOSTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALVARCOSTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.EXPECTEDCEDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_EXPECTEDCEDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPECTEDCEDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.EXPECTEDCODATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_EXPECTEDCODATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPECTEDCODATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRONTDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FRONTDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.EXPECTEDCARENTRYDATERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_EXPECTEDCARENTRYDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPECTEDCARENTRYDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ADJUSTERCONFSTATUSRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ADJUSTERCONFSTATUSRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTERCONFSTATUSRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.INSPECTORCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_INSPECTORCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSPECTORCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.INSPECTORNAMERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_INSPECTORNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSPECTORNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TRUSTCOMPANYCODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TRUSTCOMPANYCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTCOMPANYCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TRUSTCONTMANAGECODERF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TRUSTCONTMANAGECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTCONTMANAGECODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TRUSTCONTINOUTDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TRUSTCONTINOUTDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTCONTINOUTDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ACCEPTNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ACCEPTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCEPTNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHECKINSTRUCTIONSNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CHECKINSTRUCTIONSNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHECKINSTRUCTIONSNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BASETRUSTDESIGNATNORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BASETRUSTDESIGNATNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BASETRUSTDESIGNATNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AGREEMENTFEETABLENORF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AGREEMENTFEETABLENORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGREEMENTFEETABLENORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.AGREEMENTFEEDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_AGREEMENTFEEDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGREEMENTFEEDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TRUSTCONTCARDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_TRUSTCONTCARDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTCONTCARDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHECKCALCUNNCSRYCDRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CHECKCALCUNNCSRYCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKCALCUNNCSRYCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPLAVORSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPLAVORSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPLAVORSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPLAVORSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPLAVORSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPLAVORSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPPARTSSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPPARTSSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPPARTSSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.RPPARTSSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_RPPARTSSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RPPARTSSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRLAVORSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRLAVORSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRLAVORSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRLAVORSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRLAVORSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRLAVORSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BPLAVORSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BPLAVORSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BPLAVORSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BPLAVORSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BPLAVORSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BPLAVORSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRPARTSSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRPARTSSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRPARTSSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BRPARTSSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BRPARTSSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRPARTSSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MTRLSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MTRLSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MTRLSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MTRLSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MTRLSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MTRLSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BROTHSSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BROTHSSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BROTHSSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BROTHSSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_BROTHSSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BROTHSSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARBODYPRICETAXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARBODYPRICETAXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CARBODYPRICETAXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARBODYPRICECONSTAXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_CARBODYPRICECONSTAXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CARBODYPRICECONSTAXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MKROPTSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MKROPTSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKROPTSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MKROPTSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_MKROPTSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKROPTSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DLROPTSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DLROPTSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DLROPTSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DLROPTSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DLROPTSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DLROPTSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ADEQRPSALESTTLTXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ADEQRPSALESTTLTXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADEQRPSALESTTLTXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.ADEQRPSALESTTLCNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_ADEQRPSALESTTLCNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADEQRPSALESTTLCNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTTLLVRSALETXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTTLLVRSALETXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTTLLVRSALETXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTTLLVRSALECNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTTLLVRSALECNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTTLLVRSALECNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTTLPRTSALETXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTTLPRTSALETXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTTLPRTSALETXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.OSRCTTLPRTSALECNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_OSRCTTLPRTSALECNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OSRCTTLPRTSALECNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREETTLLVRSALETXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREETTLLVRSALETXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREETTLLVRSALETXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREETTLLVRSALECNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREETTLLVRSALECNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREETTLLVRSALECNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREETTLPRTSALETXINCRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREETTLPRTSALETXINCRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREETTLPRTSALETXINCRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREETTLPRTSALECNSTXRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREETTLPRTSALECNSTXRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREETTLPRTSALECNSTXRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREEOSRCTTLLVRSALETIRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREEOSRCTTLLVRSALETIRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREEOSRCTTLLVRSALETIRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREEOSRCTTLLVRSALECTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREEOSRCTTLLVRSALECTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREEOSRCTTLLVRSALECTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREEOSRCTTLPRTSALETIRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREEOSRCTTLPRTSALETIRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREEOSRCTTLPRTSALETIRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FREEOSRCTTLPRTSALECTRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_FREEOSRCTTLPRTSALECTRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FREEOSRCTTLPRTSALECTRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DBTNLNKORGNACPTANODRRF"))
        //            //    frePrtPSetSearchRetWk.ACCEPTODRRF_DBTNLNKORGNACPTANODRRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DBTNLNKORGNACPTANODRRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PRODUCETYPEOFYEARRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_PRODUCETYPEOFYEARRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MNGSECTIONCODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_MNGSECTIONCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SERVICESECTIONCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SERVICESECTIONCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERVICESECTIONCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FEEGROUPCODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FEEGROUPCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FEEGROUPCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FEEGROUPNAMERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FEEGROUPNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FEEGROUPNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FEEHEADERCODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FEEHEADERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FEEHEADERCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FEEHEADERNAMERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FEEHEADERNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FEEHEADERNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.MODEL12FULLMODELRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_MODEL12FULLMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODEL12FULLMODELRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARPROPERNORF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARPROPERNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO1RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO2RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO3RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO4RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO5RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO6RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO6RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO7RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO7RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO7RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO8RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO8RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO8RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO9RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO9RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO9RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELFIXEDNO10RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELFIXEDNO10RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FULLMODELFIXEDNO10RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FRAMEMODELRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FRAMEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHASSISNORF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CHASSISNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CUSTOMIZECODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CUSTOMIZECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMIZECODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARADDITIONALINFO1CDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARADDITIONALINFO1CDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARADDITIONALINFO1CDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARADDITIONALINFO1NMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARADDITIONALINFO1NMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARADDITIONALINFO1NMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHILDCODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CHILDCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHILDCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHILDNAMERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CHILDNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHILDNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.COLORNORF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_COLORNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TRIMNORF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_TRIMNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.KEYNORF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_KEYNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KEYNORF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BOOKINDEXMAKERCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_BOOKINDEXMAKERCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOKINDEXMAKERCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BOOKINDEXMODELCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_BOOKINDEXMODELCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOKINDEXMODELCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BOOKINDEXMODELSUBCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_BOOKINDEXMODELSUBCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOKINDEXMODELSUBCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BOOKINDEXMAKERNMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_BOOKINDEXMAKERNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOOKINDEXMAKERNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.BOOKINDEXMODELNMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_BOOKINDEXMODELNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOOKINDEXMODELNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SERIESCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SERIESCDRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERIESCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SERIESNMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SERIESNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARANALYSISCD1RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARANALYSISCD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARANALYSISCD1RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARANALYSISCD2RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARANALYSISCD2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARANALYSISCD2RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARANALYSISCD3RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARANALYSISCD3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARANALYSISCD3RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARANALYSISCD4RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARANALYSISCD4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARANALYSISCD4RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARANALYSISCD5RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARANALYSISCD5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARANALYSISCD5RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARANALYSISCD6RF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARANALYSISCD6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARANALYSISCD6RF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.DMOUTPUTCONDITIONCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_DMOUTPUTCONDITIONCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTPUTCONDITIONCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NEWUSEDCARCODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_NEWUSEDCARCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NEWUSEDCARCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.NEWUSEDCARNAMERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_NEWUSEDCARNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWUSEDCARNAMERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PASSENBSINESCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_PASSENBSINESCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PASSENBSINESCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.PSSNGRBSINSSCDNMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_PSSNGRBSINSSCDNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PSSNGRBSINSSCDNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SALESLFOTHRMKRCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SALESLFOTHRMKRCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESLFOTHRMKRCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SALESLFOTHRMKRNMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SALESLFOTHRMKRNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESLFOTHRMKRNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SELFOTHRMKRCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SELFOTHRMKRCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELFOTHRMKRCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.SELFOTHRMKRNMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_SELFOTHRMKRNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELFOTHRMKRNMRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TAKEINIMAGEGROUPCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_TAKEINIMAGEGROUPCDRF = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("TAKEINIMAGEGROUPCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FIRSTTIMECIYEARRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FIRSTTIMECIYEARRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTTIMECIYEARRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FIRSTTIMECIMATDATERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FIRSTTIMECIMATDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTTIMECIMATDATERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.EXCHSTDGROUPCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_EXCHSTDGROUPCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXCHSTDGROUPCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.EXCHSTDCARDIVCODERF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_EXCHSTDCARDIVCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXCHSTDCARDIVCODERF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.TRUSTCONTCARDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_TRUSTCONTCARDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTCONTCARDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CHECKCALCUNNCSRYCDRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CHECKCALCUNNCSRYCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKCALCUNNCSRYCDRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.FULLMODELORORDERSIGNRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_FULLMODELORORDERSIGNRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELORORDERSIGNRF"));
        //            //if (extPrm.SelectItems.Contains("ACCEPTODRRF.CARADDITIONALINFO3NMRF"))
        //            //    frePrtPSetSearchRetWk.CARMAINRF_CARADDITIONALINFO3NMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARADDITIONALINFO3NMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARKINDCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARKINDCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARKINDCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARKINDNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARKINDNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARKINDNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARPURPOSECODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARPURPOSECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPURPOSECODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARPURPOSENAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARPURPOSENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARPURPOSENAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARPRIVATEBUSINESSCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARPRIVATEBUSINESSCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPRIVATEBUSINESSCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.PRIVATEBUSINESSNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_PRIVATEBUSINESSNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIVATEBUSINESSNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.BODYSHAPECODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_BODYSHAPECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BODYSHAPECODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.AIRABODYSHAPECODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_AIRABODYSHAPECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AIRABODYSHAPECODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.BODYSHAPENAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_BODYSHAPENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYSHAPENAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.PASSENGERCAPACITY1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_PASSENGERCAPACITY1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PASSENGERCAPACITY1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.PASSENGERCAPACITY2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_PASSENGERCAPACITY2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PASSENGERCAPACITY2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.MAXLOADINGCAPACITY1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_MAXLOADINGCAPACITY1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAXLOADINGCAPACITY1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.MAXLOADINGCAPACITY2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_MAXLOADINGCAPACITY2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAXLOADINGCAPACITY2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.VEHICLEWEIGHTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_VEHICLEWEIGHTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VEHICLEWEIGHTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.GROSSVEHICLEWEIGHT1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_GROSSVEHICLEWEIGHT1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GROSSVEHICLEWEIGHT1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.GROSSVEHICLEWEIGHT2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_GROSSVEHICLEWEIGHT2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GROSSVEHICLEWEIGHT2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARHEIGHT1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARHEIGHT1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARHEIGHT1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARHEIGHT2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARHEIGHT2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARHEIGHT2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARHEIGHT3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARHEIGHT3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARHEIGHT3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARLENGTH1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARLENGTH1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARLENGTH1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARLENGTH2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARLENGTH2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARLENGTH2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARLENGTH3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARLENGTH3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARLENGTH3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARWIDTH1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARWIDTH1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARWIDTH1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARWIDTH2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARWIDTH2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARWIDTH2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARWIDTH3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARWIDTH3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARWIDTH3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.FFAXLEWEIGHTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_FFAXLEWEIGHTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FFAXLEWEIGHTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.FRAXLEWEIGHTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_FRAXLEWEIGHTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRAXLEWEIGHTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.RFAXLEWEIGHTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_RFAXLEWEIGHTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RFAXLEWEIGHTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.RRAXLEWEIGHTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_RRAXLEWEIGHTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RRAXLEWEIGHTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.RELEVANCEMODELRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.ENGINEMODELRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_ENGINEMODELRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.ENGINEMODELNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TOTALENGINEDISPLACERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TOTALENGINEDISPLACERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALENGINEDISPLACERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TTLENGINEDISPUNITCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TTLENGINEDISPUNITCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLENGINEDISPUNITCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TTLENGINEDISPUNITNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TTLENGINEDISPUNITNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TTLENGINEDISPUNITNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CMNNMENGINEDISPLACERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CMNNMENGINEDISPLACERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMNNMENGINEDISPLACERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CMNNMENGDISPUNITCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CMNNMENGDISPUNITCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMNNMENGDISPUNITCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CMNNMENGDISPUNITNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CMNNMENGDISPUNITNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMNNMENGDISPUNITNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.ENGINEDISPLACERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_ENGINEDISPLACERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.DISPLACEMENTUNITCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_DISPLACEMENTUNITCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLACEMENTUNITCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.DISPLACEMENTUNITNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_DISPLACEMENTUNITNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLACEMENTUNITNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.ROTORCNTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_ROTORCNTRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROTORCNTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.FUELCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_FUELCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FUELCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.FUELNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_FUELNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FUELNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARADDITIONALINFO1CDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARADDITIONALINFO1CDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARADDITIONALINFO1CDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARTAXCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARTAXCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARTAXCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TONNAGETAXCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TONNAGETAXCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TONNAGETAXCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.AUTOLIACODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_AUTOLIACODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOLIACODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.DOORCOUNTRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_DOORCOUNTRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.WHEELDRIVEMETHODCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_WHEELDRIVEMETHODCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.WHEELDRIVEMETHODNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_WHEELDRIVEMETHODNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.GEARCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_GEARCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GEARCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.GEARNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_GEARNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GEARNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.NUMBEROFGEARRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_NUMBEROFGEARRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBEROFGEARRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.SHIFTMETHODRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_SHIFTMETHODRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIFTMETHODRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.SHIFTMETHODNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_SHIFTMETHODNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTMETHODNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.SYSTEMATICCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_SYSTEMATICCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMATICCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.SYSTEMATICNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_SYSTEMATICNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYSTEMATICNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.PRODUCETYPEOFYEARCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_PRODUCETYPEOFYEARCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.PRODUCETYPEOFYEARNMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_PRODUCETYPEOFYEARNMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CHARACTERISTICCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CHARACTERISTICCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHARACTERISTICCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CHARACTERISTICNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CHARACTERISTICNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHARACTERISTICNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.BODYNAMECODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_BODYNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BODYNAMECODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.BODYNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_BODYNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TMCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TMCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TMCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TMCODENAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TMCODENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TMCODENAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.HANDLEINFOCDRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_HANDLEINFOCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEINFOCDRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.HANDLEINFONMRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_HANDLEINFONMRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HANDLEINFONMRF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.ROOFSHAPECODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_ROOFSHAPECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROOFSHAPECODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.ROOFSHAPENAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_ROOFSHAPENAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROOFSHAPENAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.COLORCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_COLORCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.COLORCDDUPDERIVEDNORF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_COLORCDDUPDERIVEDNORF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLORCDDUPDERIVEDNORF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.COLORNAME1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_COLORNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.RPCOLORCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_RPCOLORCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TRIMCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TRIMCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.TRIMNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_TRIMNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERNAME1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERNAME1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERNAME2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERNAME2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERKANARF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERKANARF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARUSERCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDRCD1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDRCD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARUSERADDRCD1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDRCD2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDRCD2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARUSERADDRCD2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDRCD3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDRCD3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARUSERADDRCD3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERPOSTNORF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERPOSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERPOSTNORF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDR1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDR1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERADDR1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDR2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDR2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARUSERADDR2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDR3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDR3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERADDR3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERADDR4RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERADDR4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERADDR4RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERTELKINDCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERTELKINDCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARUSERTELKINDCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERTELKINDNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERTELKINDNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERTELKINDNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CARUSERTELNORF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CARUSERTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARUSERTELNORF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERNAME1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERNAME1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERNAME2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERNAME2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERKANARF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERKANARF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERKANARF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERDIVIDECODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERDIVIDECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERDIVIDECODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDRCD1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDRCD1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERADDRCD1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDRCD2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDRCD2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERADDRCD2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDRCD3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDRCD3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERADDRCD3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERPOSTNORF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERPOSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERPOSTNORF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDR1RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDR1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERADDR1RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDR2RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDR2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERADDR2RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDR3RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDR3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERADDR3RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERADDR4RF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERADDR4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERADDR4RF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERTELKINDCODERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERTELKINDCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAROWNERTELKINDCODERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERTELKINDNAMERF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERTELKINDNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERTELKINDNAMERF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.CAROWNERTELNORF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_CAROWNERTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAROWNERTELNORF"));
        //            //if (extPrm.SelectItems.Contains("AODRCICERTRF.MATERIALDATAOFFERFLGRF"))
        //            //    frePrtPSetSearchRetWk.AODRCICERTRF_MATERIALDATAOFFERFLGRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MATERIALDATAOFFERFLGRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.OUTPUTNAMECODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.OUTPUTNAMERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_OUTPUTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.SEXCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_SEXCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.SEXNAMERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_SEXNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BIRTHDAYRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BIRTHDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.POSTNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_POSTNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESS1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESS2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESS2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESS3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESS4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESSCODE1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESSCODE2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.ADDRESSCODE3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_ADDRESSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSCODE3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.HOMETELNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_HOMETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.OFFICETELNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_OFFICETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.PORTABLETELNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_PORTABLETELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.HOMEFAXNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_HOMEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.OFFICEFAXNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_OFFICEFAXNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.OTHERSTELNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_OTHERSTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAINCONTACTCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAINCONTACTCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.SEARCHTELNORF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_SEARCHTELNORF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.GELAVORDISCOUNTRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_GELAVORDISCOUNTRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GELAVORDISCOUNTRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.GEPARTSDISCOUNTRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_GEPARTSDISCOUNTRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GEPARTSDISCOUNTRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CILAVORDISCOUNTRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CILAVORDISCOUNTRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CILAVORDISCOUNTRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CIPARTSDISCOUNTRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CIPARTSDISCOUNTRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CIPARTSDISCOUNTRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRBPLAVORDISRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRBPLAVORDISRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BRBPLAVORDISRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRBPPARTSDISRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRBPPARTSDISRATERF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BRBPPARTSDISRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.INPSECTIONCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_INPSECTIONCODERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTANALYSCODE1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTANALYSCODE2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTANALYSCODE3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTANALYSCODE4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTANALYSCODE5RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTANALYSCODE6RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BILLOUTPUTCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BILLOUTPUTCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BILLOUTPUTNAMERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BILLOUTPUTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.TOTALDAYRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_TOTALDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.LASTTIMETEMPDATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_LASTTIMETEMPDATERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LASTTIMETEMPDATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.COLLECTMONEYCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_COLLECTMONEYCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.COLLECTMONEYNAMERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.COLLECTMONEYDAYRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CLAIMCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.DMOUTCODERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_DMOUTCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.DMOUTNAMERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_DMOUTNAMERF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAINSENDMAILADDRCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAINSENDMAILADDRCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDCODE1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDNAME1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRESS1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRESS1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDCODE1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDCODE1RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDNAME1RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDNAME1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDCODE2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDNAME2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRESS2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRESS2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDCODE2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDCODE2RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDNAME2RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDNAME2RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDCODE3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDNAME3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDNAME3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRESS3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRESS3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDCODE3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDCODE3RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDNAME3RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDNAME3RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME3RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDCODE4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDNAME4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDNAME4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRESS4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRESS4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDCODE4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDCODE4RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDNAME4RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDNAME4RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME4RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDCODE5RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE5RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDNAME5RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDNAME5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME5RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRESS5RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRESS5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS5RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDCODE5RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDCODE5RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE5RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDNAME5RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDNAME5RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME5RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDCODE6RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE6RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRKINDNAME6RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRKINDNAME6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME6RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILADDRESS6RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILADDRESS6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS6RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDCODE6RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDCODE6RF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE6RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.MAILSENDNAME6RF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_MAILSENDNAME6RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME6RF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CUSTOMERAGENTCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BILLCOLLECTERCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BILLCOLLECTERCDRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRLVRRTUNPRCADOPTCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRLVRRTUNPRCADOPTCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BRLVRRTUNPRCADOPTCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRBASELAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRBASELAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRBASELAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BREXCHLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BREXCHLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BREXCHLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BROUTPLATELAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BROUTPLATELAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BROUTPLATELAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRINPLTFRMLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRINPLTFRMLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRINPLTFRMLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRBPLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRBPLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRBPLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRMTRLPRICELAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRMTRLPRICELAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRMTRLPRICELAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.BRRPLAVORRATERF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_BRRPLAVORRATERF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BRRPLAVORRATERF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.TRUSTCOMPANYDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_TRUSTCOMPANYDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTCOMPANYDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.PARTSSUPPLIERDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_PARTSSUPPLIERDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSUPPLIERDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.CARSUPPLIERDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_CARSUPPLIERDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARSUPPLIERDIVCDRF"));
        //            //if (extPrm.SelectItems.Contains("CUSTOMERRF.OSRCSUPPLIERDIVCDRF"))
        //            //    frePrtPSetSearchRetWk.CUSTOMERRF_OSRCSUPPLIERDIVCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OSRCSUPPLIERDIVCDRF"));
        //            #endregion

        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki　保留
        //            # region [データのコピー]
        //            frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONCODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBSECTIONCODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DEBITNOTEDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEBITNOTEDIVRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEBITNLNKSALESSLNUMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESSLIPCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESGOODSCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ACCRECDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCRECDIVCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SEARCHSLIPDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEARCHSLIPDATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SHIPMENTDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SHIPMENTDAYRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DELAYPAYMENTDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELAYPAYMENTDIVRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATEFORMNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATEDIVIDERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ESTIMATEDIVIDERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESINPUTCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESINPUTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTNAMERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEECDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEENMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEECDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEECDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEENMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TOTALAMOUNTDISPWAYCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TTLAMNTDISPRATEAPYRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXINCRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXEXCRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXINCRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXEXCRF" ) );
        //            //frePSalesSlipWork.SALESSLIPRF_SALSENETPRICERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSENETPRICERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESOUTTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESINTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSUBTTLSUBTOTAXFRERF" ) );
        //            //frePSalesSlipWork.SALESSLIPRF_SALSEOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSEOUTTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALAMNTCONSTAXINCLURF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESDISTTLTAXEXCRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESDISOUTTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESDISINTAXRF" ) );
        //            //frePSalesSlipWork.SALESSLIPRF_ITDEDSALSEDISTAXFRERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALSEDISTAXFRERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESDISOUTTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESDISTTLTAXINCLURF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_TOTALCOSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TOTALCOSTRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONSTAXLAYMETHODRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CONSTAXRATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_FRACTIONPROCCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FRACTIONPROCCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ACCRECCONSTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACCRECCONSTAXRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITSLIPNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITALLOWANCETTLRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DEPOSITALWCBLNCERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITALWCBLNCERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CLAIMSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMSNMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAMERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAME2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HONORIFICTITLERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDRESSEECODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAMERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAME2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEPOSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEEPOSTNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEEADDR1RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEEADDR3RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEEADDR4RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEETELNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEEFAXNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_PARTYSALESLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSALESLIPNUMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SLIPNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SLIPNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "RETGOODSREASONDIVRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RETGOODSREASONRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_REGIPROCDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "REGIPROCDATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_CASHREGISTERNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CASHREGISTERNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_POSRECEIPTNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "POSRECEIPTNORF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DETAILROWCOUNTRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DETAILROWCOUNTRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_EDISENDDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EDISENDDATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_EDITAKEINDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EDITAKEINDATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_UOEREMARK1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK1RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_UOEREMARK2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SLIPPRINTFINISHCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPPRINTDATERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BUSINESSTYPECODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BUSINESSTYPENAMERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ORDERNUMBERRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ORDERNUMBERRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVNMRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESAREACODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESAREACODERF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_SALESAREANAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESAREANAMERF" ) );
        //            //frePSalesSlipWork.SALESSLIPRF_COMPLETECDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "COMPLETECDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "STOCKGOODSTTLTAXEXCRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "PUREGOODSTTLTAXEXCRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "LISTPRICEPRINTDIVRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ERANAMEDISPCD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ERANAMEDISPCD1RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATAXDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ESTIMATAXDIVCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMPRTCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ESTIMATEFORMPRTCDRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATESUBJECTRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATESUBJECTRF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_FOOTNOTES1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FOOTNOTES1RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_FOOTNOTES2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FOOTNOTES2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATETITLE1RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATETITLE2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATETITLE3RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATETITLE4RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATETITLE5RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATENOTE1RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATENOTE2RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATENOTE3RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATENOTE4RF" ) );
        //            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ESTIMATENOTE5RF" ) );
        //            frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONGUIDENMRF" ) );
        //            frePSalesSlipWork.SECINFOSETRF_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONGUIDESNMRF" ) );
        //            frePSalesSlipWork.SECINFOSETRF_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "COMPANYNAMECD1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRRF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME2RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "POSTNORF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS3RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS4RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO2RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO3RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE2RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE3RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSFERGUIDANCERF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO2RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO3RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE2RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_IMAGEINFODIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "IMAGEINFODIVRF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "IMAGEINFOCODERF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYURLRF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRSENTENCE2RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT1RF" ) );
        //            frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT2RF" ) );
        //            frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "IMAGEINFODATARF" ) );
        //            frePSalesSlipWork.SUBSECTIONRF_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUBSECTIONNAMERF" ) );
        //            frePSalesSlipWork.EMPINP_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMPINPKANARF" ) );
        //            frePSalesSlipWork.EMPINP_SHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMPINPSHORTNAMERF" ) );
        //            frePSalesSlipWork.EMPFRT_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMPFRTKANARF" ) );
        //            frePSalesSlipWork.EMPFRT_SHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMPFRTSHORTNAMERF" ) );
        //            frePSalesSlipWork.EMPSAL_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMPSALKANARF" ) );
        //            frePSalesSlipWork.EMPSAL_SHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMPSALSHORTNAMERF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSUBCODERF" ) );
        //            frePSalesSlipWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAMERF" ) );
        //            frePSalesSlipWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAME2RF" ) );
        //            frePSalesSlipWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHONORIFICTITLERF" ) );
        //            frePSalesSlipWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMKANARF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSNMRF" ) );
        //            frePSalesSlipWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMOUTPUTNAMECODERF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE1RF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE2RF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE3RF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE4RF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE5RF" ) );
        //            frePSalesSlipWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE6RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE1RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE2RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE3RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE4RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE5RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE6RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE7RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE8RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE9RF" ) );
        //            frePSalesSlipWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE10RF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSUBCODERF" ) );
        //            frePSalesSlipWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAMERF" ) );
        //            frePSalesSlipWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAME2RF" ) );
        //            frePSalesSlipWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHONORIFICTITLERF" ) );
        //            frePSalesSlipWork.CSTCST_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTKANARF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSNMRF" ) );
        //            frePSalesSlipWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTOUTPUTNAMECODERF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE1RF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE2RF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE3RF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE4RF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE5RF" ) );
        //            frePSalesSlipWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE6RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE1RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE2RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE3RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE4RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE5RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE6RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE7RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE8RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE9RF" ) );
        //            frePSalesSlipWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE10RF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRCUSTOMERSUBCODERF" ) );
        //            frePSalesSlipWork.CSTADR_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNAMERF" ) );
        //            frePSalesSlipWork.CSTADR_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNAME2RF" ) );
        //            frePSalesSlipWork.CSTADR_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRHONORIFICTITLERF" ) );
        //            frePSalesSlipWork.CSTADR_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRKANARF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRCUSTOMERSNMRF" ) );
        //            frePSalesSlipWork.CSTADR_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADROUTPUTNAMECODERF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADRCUSTANALYSCODE1RF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADRCUSTANALYSCODE2RF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADRCUSTANALYSCODE3RF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADRCUSTANALYSCODE4RF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADRCUSTANALYSCODE5RF" ) );
        //            frePSalesSlipWork.CSTADR_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTADRCUSTANALYSCODE6RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE1RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE2RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE3RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE4RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE5RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE6RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE7RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE8RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE9RF" ) );
        //            frePSalesSlipWork.CSTADR_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTADRNOTE10RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME1RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME2RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "POSTNORF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS1RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS3RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS4RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO1RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO2RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO3RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE1RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE2RF" ) );
        //            frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE3RF" ) );
        //            # endregion
        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki　保留

        //            //frePDailyExtRetWorkLs.Add(frePrtPSetSearchRetWk);
        //            frePSalesSlipWorkList.Add( frePSalesSlipWork );
        //        }

        //        //if (frePDailyExtRetWorkLs.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        //retObj = (object)frePDailyExtRetWorkLs;
        //        if ( frePSalesSlipWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        retObj = frePSalesSlipWorkList;
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //        {
        //            if (!myReader.IsClosed)
        //                myReader.Close();
        //        }
        //    }
        //    return status;
        //}
        //# endregion

        //# region [売上明細データ抽出]
        ///// <summary>
        ///// 売上明細データ抽出
        ///// </summary>
        ///// <param name="extPrm"></param>
        ///// <param name="frePSalesSlipRetWorkList"></param>
        ///// <param name="sqlConnection"></param>
        ///// <returns></returns>
        //private int SearchProcOfDetail( FrePSalesSlipParaWork extPrm, out Dictionary<string,List<FrePSalesDetailWork>> retObj, SqlConnection sqlConnection )
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;

        //    Dictionary<string, List<FrePSalesDetailWork>> detailListDic = new Dictionary<string, List<FrePSalesDetailWork>>();
        //    retObj = null;

        //    try
        //    {
        //        //-------------------------------------------------------------------
        //        // 対象テーブル
        //        //   売上明細データ       SalesDetailRF 
        //        //   受注マスタ(車両)     AcceptOdrCarRF
        //        //   メーカーマスタ①     MakerURF As MAKGDS
        //        //   メーカーマスタ②     MakerURF As MAKCMP
        //        //   商品マスタ           GoodsURF
        //        //   在庫マスタ           StockRF
        //        //   倉庫マスタ           WarehouseRF
        //        //   ﾕｰｻﾞｰｶﾞｲﾄﾞﾏｽﾀ①     UserGdBdURF As USRCSG
        //        ////   ﾕｰｻﾞｰｶﾞｲﾄﾞﾏｽﾀ②     UserGdBdURF As USRSPG
        //        //   仕入先マスタ         SupplierRF
        //        //   ＢＬｺｰﾄﾞﾏｽﾀ         BLGoodsCdURF
        //        //-------------------------------------------------------------------
        //        SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForDetail( extPrm )
        //            + Environment.NewLine
        //            + " FROM SALESDETAILRF " + Environment.NewLine
        //            + LeftJoin( "SALESDETAILRF", "ACCEPTODRCARRF", string.Empty, new string[] { "ACCEPTANORDERNORF", "ACPTANODRSTATUSRF" }, new string[] { "ACCEPTODRCARRF.DATAINPUTSYSTEMRF='0'" } )    // 企業cd, 受注番号,受注ｽﾃｰﾀｽ,入力ｼｽﾃﾑ=0
        //            + LeftJoin( "SALESDETAILRF", "MAKERURF", "MAKGDS", new string[] { "GOODSMAKERCDRF" }, new string[] { } )    // 企業cd,ﾒｰｶｰcd
        //            + LeftJoin( "SALESDETAILRF", "MAKERURF", "MAKCMP", new string[] { }, new string[] { "SALESDETAILRF.CMPLTGOODSMAKERCDRF=MAKCMP.GOODSMAKERCDRF" } )    // 企業cd,ﾒｰｶｰcd
        //            + LeftJoin( "SALESDETAILRF", "GOODSURF", string.Empty, new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { } )    // 企業cd,商品番号,ﾒｰｶｰcd
        //            + LeftJoin( "SALESDETAILRF", "STOCKRF", string.Empty, new string[] { "GOODSNORF", "GOODSMAKERCDRF", "WAREHOUSECODERF" }, new string[] { } )    // 企業cd,商品番号,ﾒｰｶｰcd,倉庫cd
        //            + LeftJoin( "SALESDETAILRF", "WAREHOUSERF", string.Empty, new string[] { "WAREHOUSECODERF" }, new string[] { } )    // 企業cd,倉庫cd
        //            + LeftJoin( "SALESDETAILRF", "USERGDBDURF", "USRCSG", new string[] { }, new string[] { "USRCSG.USERGUIDEDIVCDRF='43'", "SALESDETAILRF.CUSTRATEGRPCODERF=USRCSG.GUIDECODERF" } )    // 企業cd,ｶﾞｲﾄﾞ区分=43,ｶﾞｲﾄﾞcd
        //            //+ LeftJoin( "SALESDETAILRF", "USERGDBDURF", "USRSPG", new string[] { }, new string[] { "USRSPG.USERGUIDEDIVCDRF='44'", "SALESDETAILRF.SUPPRATEGRPCODERF=USRSPG.GUIDECODERF" } )    // 企業cd,ｶﾞｲﾄﾞ区分=44,ｶﾞｲﾄﾞcd
        //            + LeftJoin( "SALESDETAILRF", "SUPPLIERRF", string.Empty, new string[] { "SUPPLIERCDRF" }, new string[] { } )    // 企業cd,仕入先cd
        //            + LeftJoin( "SALESDETAILRF", "BLGOODSCDURF", string.Empty, new string[] { "BLGOODSCODERF" }, new string[] { } )    // 企業cd,BLcd
        //            , sqlConnection );

        //        // WHERE文を生成
        //        sqlCommand.CommandText += MakeWhereStringForDetail( ref sqlCommand, extPrm );
        //        // タイムアウト時間設定
        //        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );

        //        myReader = sqlCommand.ExecuteReader();

        //        while ( myReader.Read() )
        //        {
        //            FrePSalesDetailWork frePSalesDetailWork = new FrePSalesDetailWork();

        //            # region [データのコピー]
        //            frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCEPTANORDERNORF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_COMMONSEQNORF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "COMMONSEQNORF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSLIPDTLNUMRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSSRCRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSSRCRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSLIPDTLNUMSRCRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SUPPLIERFORMALSYNCRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERFORMALSYNCRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "STOCKSLIPDTLNUMSYNCRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_STOCKMNGEXISTCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STOCKMNGEXISTCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIGDSCMPLTDUEDATERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GOODSKINDCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_MAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GOODSSHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSSHORTNAMERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_LARGEGOODSGANRECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "LARGEGOODSGANRECODERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_LARGEGOODSGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "LARGEGOODSGANRENAMERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_MEDIUMGOODSGANRECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MEDIUMGOODSGANRECODERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_MEDIUMGOODSGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MEDIUMGOODSGANRENAMERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_DETAILGOODSGANRECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DETAILGOODSGANRECODERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_DETAILGOODSGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DETAILGOODSGANRENAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSFULLNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ENTERPRISEGANRECODERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISEGANRENAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_WAREHOUSECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_WAREHOUSENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESORDERDIVCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_OPENPRICEDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_UNITCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "UNITCODERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_UNITNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UNITNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GOODSRATERANKRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSRATERANKRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CUSTRATEGRPCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTRATEGRPCODERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_SUPPRATEGRPCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPRATEGRPCODERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_LISTPRICERATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICERATERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXINCFLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXEXCFLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_LISTPRICECHNGCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "LISTPRICECHNGCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESRATERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXINCFLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXEXCFLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_COSTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "COSTRATERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNITCOSTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SHIPMENTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SHIPMENTCNTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "ACCEPTANORDERCNTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ACPTANODRADJUSTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "ACPTANODRADJUSTCNTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ACPTANODRREMAINCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "ACPTANODRREMAINCNTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_REMAINCNTUPDDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "REMAINCNTUPDDATERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXINCRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_COSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "COSTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_GRSPROFITCHKDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GRSPROFITCHKDIVRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESGOODSCDRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_SALSEPRICECONSTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSEPRICECONSTAXRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TAXATIONDIVCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSLIPNUMDTLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_DTLNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DTLNOTERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SUPPLIERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERSNMRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_ORDERNUMBERRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ORDERNUMBERRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO1RF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO2RF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO3RF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO1RF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO2RF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO3RF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_BFLISTPRICERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFLISTPRICERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFSALESUNITPRICERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_BFUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFUNITCOSTRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNORF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_PRTGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNAMERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_PRTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTGOODSMAKERCDRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_PRTGOODSMAKERNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSMAKERNMRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_CONTRACTDIVCDDTLRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONTRACTDIVCDDTLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTSALESROWNORF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTGOODSMAKERCDRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTMAKERNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTGOODSNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSHIPMENTCNTRF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_CMPLTUNITCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTUNITCODERF" ) );
        //            //frePSalesDetailWork.SALESDETAILRF_CMPLTUNITNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTUNITNAMERF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSALESUNPRCFLRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "CMPLTSALESMONEYRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSALESUNITCOSTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTCOSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "CMPLTCOSTRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTPARTYSALSLNUMRF" ) );
        //            frePSalesDetailWork.SALESDETAILRF_CMPLTNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTNOTERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_CARMNGNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_CARMNGCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CARMNGCODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "NUMBERPLATE1CODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE1NAMERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE2RF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE3RF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "NUMBERPLATE4RF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FIRSTENTRYDATERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MAKERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MAKERFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERFULLNAMERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MODELCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EXHAUSTGASSIGNRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_SERIESMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SERIESMODELRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CATEGORYSIGNMODELRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_FULLMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELDESIGNATIONNORF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATEGORYNORF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_FRAMEMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMEMODELRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_FRAMENORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMENORF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_SEARCHFRAMENORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEARCHFRAMENORF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RELEVANCEMODELRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_SUBCARNMCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBCARNMCDRF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MODELGRADESNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELGRADESNAMERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_COLORCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_COLORNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORNAME1RF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_TRIMCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_TRIMNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMNAMERF" ) );
        //            frePSalesDetailWork.ACCEPTODRCARRF_MILEAGERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MILEAGERF" ) );
        //            frePSalesDetailWork.MAKGDS_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKGDSMAKERSHORTNAMERF" ) );
        //            frePSalesDetailWork.MAKGDS_MAKERKANANAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKGDSMAKERKANANAMERF" ) );
        //            frePSalesDetailWork.MAKGDS_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKGDSGOODSMAKERCDRF" ) );
        //            frePSalesDetailWork.MAKCMP_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKCMPMAKERSHORTNAMERF" ) );
        //            frePSalesDetailWork.MAKCMP_MAKERKANANAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKCMPMAKERKANANAMERF" ) );
        //            frePSalesDetailWork.MAKCMP_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKCMPGOODSMAKERCDRF" ) );
        //            frePSalesDetailWork.GOODSURF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMEKANARF" ) );
        //            frePSalesDetailWork.GOODSURF_JANRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "JANRF" ) );
        //            frePSalesDetailWork.GOODSURF_GOODSRATERANKRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSRATERANKRF" ) );
        //            frePSalesDetailWork.GOODSURF_GOODSNONONEHYPHENRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNONONEHYPHENRF" ) );
        //            frePSalesDetailWork.GOODSURF_GOODSNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNOTE1RF" ) );
        //            frePSalesDetailWork.GOODSURF_GOODSNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNOTE2RF" ) );
        //            frePSalesDetailWork.GOODSURF_GOODSSPECIALNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSSPECIALNOTERF" ) );
        //            frePSalesDetailWork.STOCKRF_SHIPMENTPOSCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SHIPMENTPOSCNTRF" ) );
        //            frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DUPLICATIONSHELFNO1RF" ) );
        //            frePSalesDetailWork.STOCKRF_DUPLICATIONSHELFNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DUPLICATIONSHELFNO2RF" ) );
        //            frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSMANAGEMENTDIVIDE1RF" ) );
        //            frePSalesDetailWork.STOCKRF_PARTSMANAGEMENTDIVIDE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSMANAGEMENTDIVIDE2RF" ) );
        //            frePSalesDetailWork.STOCKRF_STOCKNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKNOTE1RF" ) );
        //            frePSalesDetailWork.STOCKRF_STOCKNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKNOTE2RF" ) );
        //            frePSalesDetailWork.WAREHOUSERF_WAREHOUSENOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENOTE1RF" ) );
        //            frePSalesDetailWork.USRCSG_GUIDENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "USRCSGGUIDENAMERF" ) );
        //            //frePSalesDetailWork.USRSPG_GUIDENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "USRSPGGUIDENAMERF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERNM1RF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERNM2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERNM2RF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPHONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPHONORIFICTITLERF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERKANARF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_PURECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PURECODERF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERNOTE1RF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERNOTE2RF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERNOTE3RF" ) );
        //            frePSalesDetailWork.SUPPLIERRF_SUPPLIERNOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERNOTE4RF" ) );
        //            frePSalesDetailWork.BLGOODSCDURF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODERF" ) );
        //            frePSalesDetailWork.BLGOODSCDURF_BLGOODSHALFNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSHALFNAMERF" ) );
        //            # endregion

        //            // 同一伝票番号のリストが存在しなければ追加
        //            if ( !detailListDic.ContainsKey( frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF ) )
        //            {
        //                detailListDic.Add( frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF, new List<FrePSalesDetailWork>() );
        //            }
        //            // レコード追加
        //            detailListDic[frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF].Add( frePSalesDetailWork );
        //        }

        //        if ( detailListDic.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        retObj = detailListDic;
        //    }
        //    catch ( Exception ex )
        //    {
        //        base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if ( myReader != null )
        //        {
        //            if ( !myReader.IsClosed )
        //                myReader.Close();
        //        }
        //    }
        //    return status;
        //}

        # endregion

        # region [請求書ヘッダデータ抽出]
        /// <summary>
        /// Search 請求書ヘッダ
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retObj"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="_sumCustChildDic"></param>
        /// <param name="_sumCustParentDic"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //private int SearchProcOfBill( FrePBillParaWork extPrm, out List<FrePBillHeadWork> retObj, SqlConnection sqlConnection )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private int SearchProcOfBill(FrePBillParaWork extPrm, out List<FrePBillHeadWork> retObj, SqlConnection sqlConnection, ref Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, Dictionary<int, int> _sumCustParentDic, ref Dictionary<string, object> requestMessage)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            List<FrePBillHeadWork> frePBillHeadWorkList = new List<FrePBillHeadWork>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   得意先請求金額マスタ　　　CustDmdPrcRF
                //   　拠点情報設定マスタ①　　SecInfoSetRF As SECHED
                //   　　自社名称マスタ　　　　CompanyNmRF
                //   　　　画像情報マスタ　　　ImageInfoRF
                //     得意先マスタ①　　　　　CustomerRF As CSTCST
                //     得意先マスタ②　　　　　CustomerRF As CSTCLM
                //     自社情報マスタ　　　　　CompanyInfRF
                //     入金設定マスタ　　　　　DepositStRF
                //     　請求入金集計データ①　DmdDepoTotalRF As DEPT01
                //     　請求入金集計データ②　DmdDepoTotalRF As DEPT02
                //     　請求入金集計データ③　DmdDepoTotalRF As DEPT03
                //     　請求入金集計データ④　DmdDepoTotalRF As DEPT04
                //     　請求入金集計データ⑤　DmdDepoTotalRF As DEPT05
                //     　請求入金集計データ⑥　DmdDepoTotalRF As DEPT06
                //     　請求入金集計データ⑦　DmdDepoTotalRF As DEPT07
                //     　請求入金集計データ⑧　DmdDepoTotalRF As DEPT08
                //     　請求入金集計データ⑨　DmdDepoTotalRF As DEPT09
                //     　請求入金集計データ⑩　DmdDepoTotalRF As DEPT10
                //     全体表示名称マスタ      AlItmDspNmRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForHead( extPrm )
                    + Environment.NewLine
                    + " FROM CUSTDMDPRCRF " + Environment.NewLine
                    + LeftJoin( "CUSTDMDPRCRF", "SECINFOSETRF", "SECHED", new string[] { }, new string[] { GetJoinForHeadSection() } )  // 企業cd,拠点cd
                    + LeftJoin( "SECHED", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECHED.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" } )    // 企業cd,自社名称cd
                    + LeftJoin( "COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" } )    // 企業cd,画像情報cd,区分=10
                    + LeftJoin( "CUSTDMDPRCRF", "CUSTOMERRF", "CSTCST", new string[] { }, new string[] { "CUSTDMDPRCRF.CUSTOMERCODERF=CSTCST.CUSTOMERCODERF" } )    // 企業cd,得意先cd
                    + LeftJoin( "CUSTDMDPRCRF", "CUSTOMERRF", "CSTCLM", new string[] { }, new string[] { "CUSTDMDPRCRF.CLAIMCODERF=CSTCLM.CUSTOMERCODERF" } )    // 企業cd,得意先cd
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 DEL
                    //+ LeftJoin( "CUSTDMDPRCRF", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { } )    // 企業cd
                    //+ LeftJoin( "CUSTDMDPRCRF", "DEPOSITSTRF", string.Empty, new string[] { }, new string[] { } )    // 企業cd
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
                    + LeftJoin( "CUSTDMDPRCRF", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { "COMPANYINFRF.COMPANYCODERF='0'" } )    // 企業cd,自社コード=0固定
                    + LeftJoin( "CUSTDMDPRCRF", "DEPOSITSTRF", string.Empty, new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTMNGCDRF='0'" } )    // 企業cd,入金設定管理コード=0固定
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 DEL
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT01", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT01.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT01.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT01.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT01.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT02", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT02.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT02.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT02.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT02.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT02.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT03", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT03.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT03.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT03.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT03.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT03.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT04", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT04.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT04.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT04.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT04.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT04.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT05", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT05.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT05.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT05.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT05.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT05.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT06", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT06.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT06.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT06.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT06.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT06.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT07", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT07.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT07.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT07.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT07.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT07.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT08", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT08.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT08.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT08.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT08.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT08.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT09", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT09.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT09.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT09.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT09.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT09.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT10", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT10.ADDUPSECCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT10.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT10.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT10.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT10.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 DEL
                    // --- UPD m.suzuki 2010/02/15 ---------->>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT01", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT01.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT01.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT01.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT01.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT02", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD2RF=DEPT02.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT02.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT02.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT02.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT02.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT03", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD3RF=DEPT03.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT03.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT03.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT03.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT03.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT04", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD4RF=DEPT04.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT04.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT04.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT04.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT04.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT05", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD5RF=DEPT05.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT05.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT05.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT05.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT05.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT06", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD6RF=DEPT06.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT06.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT06.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT06.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT06.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT07", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD7RF=DEPT07.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT07.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT07.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT07.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT07.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT08", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD8RF=DEPT08.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT08.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT08.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT08.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT08.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT09", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD9RF=DEPT09.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT09.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT09.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT09.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT09.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //+ LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT10", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD10RF=DEPT10.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT10.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT10.CLAIMCODERF", "CUSTDMDPRCRF.CUSTOMERCODERF=DEPT10.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT10.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
                    // "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CUSTOMERCODERF"へ変更
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT01", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT01.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT01.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT01.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT02", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD2RF=DEPT02.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT02.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT02.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT02.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT02.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT03", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD3RF=DEPT03.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT03.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT03.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT03.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT03.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT04", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD4RF=DEPT04.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT04.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT04.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT04.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT04.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT05", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD5RF=DEPT05.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT05.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT05.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT05.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT05.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT06", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD6RF=DEPT06.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT06.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT06.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT06.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT06.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT07", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD7RF=DEPT07.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT07.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT07.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT07.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT07.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT08", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD8RF=DEPT08.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT08.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT08.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT08.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT08.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT09", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD9RF=DEPT09.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT09.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT09.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT09.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT09.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT10", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD10RF=DEPT10.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT10.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT10.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT10.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT10.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    // --- UPD m.suzuki 2010/02/15 ----------<<<<<
                    + LeftJoin( "CUSTDMDPRCRF", "ALITMDSPNMRF", string.Empty, new string[] { }, new string[] { } )    // 企業cd
                    , sqlConnection );

                // WHERE文を生成
                //sqlCommand.CommandText += MakeWhereStringForHead(ref sqlCommand, extPrm);// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                sqlCommand.CommandText += MakeWhereStringForHead(ref sqlCommand, extPrm, _sumCustChildDic);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                ////請求書ログ出力用
                //if (this.requestMessage.ContainsKey("売上ヘッダ取得クエリ") == false)
                //{
                //    this.requestMessage.Add("売上ヘッダ取得クエリ", sqlCommand.CommandText);
                //}
                //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
                //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                //請求書ログ出力用
                if (requestMessage.ContainsKey("売上ヘッダ取得クエリ") == false)
                {
                    requestMessage.Add("売上ヘッダ取得クエリ", sqlCommand.CommandText);
                }
                //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<

                myReader = sqlCommand.ExecuteReader();


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                //_dmdRangeEachClaimDic = new Dictionary<DmdRangeEachClaimKey, DmdRangeEachClaim>();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                //_dmdRangeEachClaimDic = new Dictionary<string, DmdRangeEachClaim>();
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<

                // --- UPD m.suzuki 2010/02/15 ---------->>>>>
                # region // DEL
                //while (myReader.Read())
                //{
                //    FrePBillHeadWork frePBillHeadWork = new FrePBillHeadWork();

                //    #region データのコピー
                //    frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CLAIMNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAMERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CLAIMNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAME2RF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CLAIMSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMSNMRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAMERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAME2RF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPDATERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPYEARMONTHRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "LASTTIMEDEMANDRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEFEEDMDNRMLRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEDISDMDNRMLRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEDMDNRMLRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMETTLBLCDMDRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFSTHISTIMESALESRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFSTHISSALESTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETOUTTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETINTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETTAXFREERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_OFFSETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFFSETOUTTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_OFFSETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFFSETINTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISTIMESALESRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMESALESRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISSALESTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESOUTTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESINTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESTAXFREERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_SALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESOUTTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_SALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESINTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRICRGDSRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRCTAXRGDSRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETOUTTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETINTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETTAXFREERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLRETOUTERTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLRETINNERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLRETINNERTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRICDISRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRICDISRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRCTAXDISRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISOUTTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISINTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISTAXFREERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLDISOUTERTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TTLDISINNERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLDISINNERTAXRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_TAXADJUSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TAXADJUSTRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_BALANCEADJUSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "BALANCEADJUSTRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "AFCALDEMANDPRICERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL2TMBFBLDMDRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL3TMBFBLDMDRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCOUNTRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_BILLPRINTDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BILLPRINTDATERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EXPECTEDDEPOSITDATERF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_COLLECTCONDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "COLLECTCONDRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONSTAXLAYMETHODRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CONSTAXRATERF" ) );
                //    frePBillHeadWork.SECHED_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECHEDSECTIONGUIDENMRF" ) );
                //    frePBillHeadWork.SECHED_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECHEDSECTIONGUIDESNMRF" ) );
                //    frePBillHeadWork.SECHED_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SECHEDCOMPANYNAMECD1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRRF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME2RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "POSTNORF" ) );
                //    frePBillHeadWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS3RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS4RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO2RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO3RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE2RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE3RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSFERGUIDANCERF" ) );
                //    frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO2RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO3RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE2RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "IMAGEINFOCODERF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYURLRF" ) );
                //    frePBillHeadWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRSENTENCE2RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT1RF" ) );
                //    frePBillHeadWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT2RF" ) );
                //    frePBillHeadWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "IMAGEINFODATARF" ) );
                //    frePBillHeadWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSUBCODERF" ) );
                //    frePBillHeadWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAMERF" ) );
                //    frePBillHeadWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAME2RF" ) );
                //    frePBillHeadWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHONORIFICTITLERF" ) );
                //    frePBillHeadWork.CSTCST_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTKANARF" ) );
                //    frePBillHeadWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSNMRF" ) );
                //    frePBillHeadWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTOUTPUTNAMECODERF" ) );
                //    frePBillHeadWork.CSTCST_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTPOSTNORF" ) );
                //    frePBillHeadWork.CSTCST_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS1RF" ) );
                //    frePBillHeadWork.CSTCST_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS3RF" ) );
                //    frePBillHeadWork.CSTCST_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS4RF" ) );
                //    frePBillHeadWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE1RF" ) );
                //    frePBillHeadWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE2RF" ) );
                //    frePBillHeadWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE3RF" ) );
                //    frePBillHeadWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE4RF" ) );
                //    frePBillHeadWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE5RF" ) );
                //    frePBillHeadWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE6RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE1RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE2RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE3RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE4RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE5RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE6RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE7RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE8RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE9RF" ) );
                //    frePBillHeadWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE10RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSUBCODERF" ) );
                //    frePBillHeadWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAMERF" ) );
                //    frePBillHeadWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAME2RF" ) );
                //    frePBillHeadWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHONORIFICTITLERF" ) );
                //    frePBillHeadWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMKANARF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSNMRF" ) );
                //    frePBillHeadWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMOUTPUTNAMECODERF" ) );
                //    frePBillHeadWork.CSTCLM_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMPOSTNORF" ) );
                //    frePBillHeadWork.CSTCLM_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS1RF" ) );
                //    frePBillHeadWork.CSTCLM_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS3RF" ) );
                //    frePBillHeadWork.CSTCLM_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS4RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE1RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE2RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE3RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE4RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE5RF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE6RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE1RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE2RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE3RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE4RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE5RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE6RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE7RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE8RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE9RF" ) );
                //    frePBillHeadWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE10RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYNAME1RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYNAME2RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFPOSTNORF" ) );
                //    frePBillHeadWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS1RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS3RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS4RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO1RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO2RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO3RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE1RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE2RF" ) );
                //    frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE3RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD1RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD2RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD3RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD4RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD5RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD6RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD7RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD8RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD9RF" ) );
                //    frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD10RF" ) );
                //    frePBillHeadWork.DEPT01_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT01MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT01_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT01DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT02_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT02MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT02_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT02DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT03_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT03MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT03_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT03DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT04_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT04MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT04_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT04DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT05_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT05MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT05_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT05DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT06_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT06MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT06_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT06DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT07_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT07MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT07_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT07DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT08_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT08MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT08_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT08DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT09_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT09MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT09_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT09DEPOSITRF" ) );
                //    frePBillHeadWork.DEPT10_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT10MONEYKINDNAMERF" ) );
                //    frePBillHeadWork.DEPT10_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT10DEPOSITRF" ) );
                //    frePBillHeadWork.CSTCST_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCOLLECTMONEYNAMERF" ) );
                //    frePBillHeadWork.CSTCST_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCOLLECTMONEYDAYRF" ) );
                //    frePBillHeadWork.CSTCST_HOMETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHOMETELNORF" ) );
                //    frePBillHeadWork.CSTCST_OFFICETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOFFICETELNORF" ) );
                //    frePBillHeadWork.CSTCST_PORTABLETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTPORTABLETELNORF" ) );
                //    frePBillHeadWork.CSTCST_HOMEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHOMEFAXNORF" ) );
                //    frePBillHeadWork.CSTCST_OFFICEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOFFICEFAXNORF" ) );
                //    frePBillHeadWork.CSTCST_OTHERSTELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOTHERSTELNORF" ) );
                //    frePBillHeadWork.CSTCLM_HOMETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHOMETELNORF" ) );
                //    frePBillHeadWork.CSTCLM_OFFICETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOFFICETELNORF" ) );
                //    frePBillHeadWork.CSTCLM_PORTABLETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMPORTABLETELNORF" ) );
                //    frePBillHeadWork.CSTCLM_HOMEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHOMEFAXNORF" ) );
                //    frePBillHeadWork.CSTCLM_OFFICEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOFFICEFAXNORF" ) );
                //    frePBillHeadWork.CSTCLM_OTHERSTELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOTHERSTELNORF" ) );
                //    frePBillHeadWork.CSTCLM_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCOLLECTMONEYNAMERF" ) );
                //    frePBillHeadWork.CSTCLM_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCOLLECTMONEYDAYRF" ) );
                //    frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RESULTSSECTCDRF" ) );
                //    frePBillHeadWork.ALITMDSPNMRF_HOMETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HOMETELNODSPNAMERF" ) );
                //    frePBillHeadWork.ALITMDSPNMRF_OFFICETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OFFICETELNODSPNAMERF" ) );
                //    frePBillHeadWork.ALITMDSPNMRF_MOBILETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOBILETELNODSPNAMERF" ) );
                //    frePBillHeadWork.ALITMDSPNMRF_HOMEFAXNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HOMEFAXNODSPNAMERF" ) );
                //    frePBillHeadWork.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OFFICEFAXNODSPNAMERF" ) );
                //    frePBillHeadWork.ALITMDSPNMRF_OTHERTELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OTHERTELNODSPNAMERF" ) );
                //    frePBillHeadWork.CSTCLM_SALESAREACODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMSALESAREACODERF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERAGENTCDRF" ) );
                //    frePBillHeadWork.CSTCLM_BILLCOLLECTERCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMBILLCOLLECTERCDRF" ) );
                //    frePBillHeadWork.CSTCLM_OLDCUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOLDCUSTOMERAGENTCDRF" ) );
                //    frePBillHeadWork.CSTCLM_CUSTAGENTCHGDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTAGENTCHGDATERF" ) );
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/25 ADD
                //    frePBillHeadWork.CUSTDMDPRCRF_BILLNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BILLNORF" ) );
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/25 ADD
                //    # endregion 

                //    frePBillHeadWorkList.Add( frePBillHeadWork );

                //    # region [請求先別締範囲ディクショナリ]
                //    DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                //                                        frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                //                                        frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF,
                //                                        frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                //                                        frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF );

                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                //    //if ( !_dmdRangeEachClaimDic.ContainsKey( key ) ) 
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                //    string keyString = key.CreateKey();
                //    if ( !_dmdRangeEachClaimDic.ContainsKey( keyString ) )
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                //    {
                //        DmdRangeEachClaim dmdRangeEachClaim = new DmdRangeEachClaim();
                //        dmdRangeEachClaim.DmdRangeSt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                //        dmdRangeEachClaim.DmdRangeEd = frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF;

                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                //        //_dmdRangeEachClaimDic.Add( key, dmdRangeEachClaim );
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                //        _dmdRangeEachClaimDic.Add( keyString, dmdRangeEachClaim );
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                //    }
                //    //-------------------------------------------------------
                //    // ※このあと、
                //    //   SearchProcOfDmdRangeStで、DmdRangeStを書き換える。
                //    //-------------------------------------------------------
                //    # endregion
                //}
                # endregion

                if ( !extPrm.UseSumCust )
                {
                    //---------------------------------------------------
                    // 請求書
                    //---------------------------------------------------
                    # region [請求書]
                    while ( myReader.Read() )
                    {
                        // クエリ結果から結果クラスへ移行
                        FrePBillHeadWork frePBillHeadWork = CopyFromReader( myReader );
                        frePBillHeadWorkList.Add( frePBillHeadWork );

                        # region [請求先別締範囲ディクショナリ]
                        DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                            frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                            frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                            frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                                            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF );

                        string keyString = key.CreateKey();
                        if ( !_dmdRangeEachClaimDic.ContainsKey( keyString ) )
                        {
                            DmdRangeEachClaim dmdRangeEachClaim = new DmdRangeEachClaim();
                            dmdRangeEachClaim.DmdRangeSt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                            dmdRangeEachClaim.DmdRangeEd = frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF;
                            _dmdRangeEachClaimDic.Add( keyString, dmdRangeEachClaim );
                        }
                        //-------------------------------------------------------
                        // ※このあと、
                        //   SearchProcOfDmdRangeStで、DmdRangeStを書き換える。
                        //-------------------------------------------------------
                        # endregion
                    }
                    # endregion
                }
                else
                {
                    //---------------------------------------------------
                    // 請求書(総括)
                    //---------------------------------------------------
                    # region [請求書(総括)]
                    // 集計する為のWork用
                    Dictionary<int, FrePBillHeadWork> workParentDic = new Dictionary<int, FrePBillHeadWork>();
                    Dictionary<int, List<FrePBillHeadWork>> workChildDic = new Dictionary<int, List<FrePBillHeadWork>>();

                    //---------------------------------------------------
                    // クエリ結果から「親のディクショナリ」と「子リストのディクショナリ」を生成
                    //---------------------------------------------------
                    while ( myReader.Read() )
                    {
                        // クエリ結果から結果クラスへ移行
                        FrePBillHeadWork frePBillHeadWork = CopyFromReader( myReader );

                        // 総括親／総括子 判定
                        if ( _sumCustChildDic.ContainsKey( frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF ) )
                        {
                            if ( !workParentDic.ContainsKey( frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF ) )
                            {
                                // 総括親
                                workParentDic.Add( frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF, frePBillHeadWork );

                                # region [請求先別締範囲ディクショナリ]
                                DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                                    frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                                    frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                                    frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                                                    frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF );

                                string keyString = key.CreateKey();
                                if ( !_dmdRangeEachClaimDic.ContainsKey( keyString ) )
                                {
                                    DmdRangeEachClaim dmdRangeEachClaim = new DmdRangeEachClaim();
                                    dmdRangeEachClaim.DmdRangeSt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                                    dmdRangeEachClaim.DmdRangeEd = frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF;
                                    _dmdRangeEachClaimDic.Add( keyString, dmdRangeEachClaim );
                                }
                                //-------------------------------------------------------
                                // ※このあと、
                                //   SearchProcOfDmdRangeStで、DmdRangeStを書き換える。
                                //-------------------------------------------------------
                                # endregion
                            }
                        }
                        else
                        {
                            // 総括子リスト
                            int parentCode = _sumCustParentDic[frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF];
                            if ( !workChildDic.ContainsKey( parentCode ) )
                            {
                                workChildDic.Add( parentCode, new List<FrePBillHeadWork>() );
                            }
                            workChildDic[parentCode].Add( frePBillHeadWork );
                        }
                    }

                    //---------------------------------------------------
                    // 総括親レコードに、総括子レコードを合算する
                    //---------------------------------------------------
                    foreach ( int sumCustParentCode in workParentDic.Keys )
                    {
                        FrePBillHeadWork frePBillHeadWork = workParentDic[sumCustParentCode];
                        
                        // ※総括設定に親自身が含まれていない場合は、集計値項目を一度クリアする
                        if ( !_sumCustParentDic.ContainsKey( sumCustParentCode ) )
                        {
                            // 集計項目のみクリア
                            ClearSumCustParent( ref frePBillHeadWork );
                        }

                        // 総括子レコードのリストを参照
                        if ( workChildDic.ContainsKey( sumCustParentCode ) )
                        {
                            foreach ( FrePBillHeadWork childWork in workChildDic[sumCustParentCode] )
                            {
                                // 総括子から総括親へ合算する
                                AddToSumCustParent( ref frePBillHeadWork, childWork );
                            }
                        }

                        // 抽出結果リストに追加
                        frePBillHeadWorkList.Add( frePBillHeadWork );
                    }
                    # endregion
                }
                // --- UPD m.suzuki 2010/02/15 ----------<<<<<

                if ( frePBillHeadWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = frePBillHeadWorkList;
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }
            return status;
        }

        // --- ADD m.suzuki 2010/02/15 ---------->>>>>
        /// <summary>
        /// SQLDataReaderからの結果クラス取得処理（Head）
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        private FrePBillHeadWork CopyFromReader( SqlDataReader myReader )
        {
            FrePBillHeadWork frePBillHeadWork = new FrePBillHeadWork();

            #region データのコピー
            frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAMERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAME2RF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMSNMRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAMERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAME2RF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPYEARMONTHRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "LASTTIMEDEMANDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEFEEDMDNRMLRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEDISDMDNRMLRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEDMDNRMLRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMETTLBLCDMDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFSTHISTIMESALESRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFSTHISSALESTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFFSETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFFSETOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFFSETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFFSETINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMESALESRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMESALESRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_SALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_SALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRICRGDSRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRCTAXRGDSRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLRETOUTERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLRETINNERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLRETINNERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRICDISRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRICDISRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRCTAXDISRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLDISOUTERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLDISINNERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLDISINNERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TAXADJUSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TAXADJUSTRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_BALANCEADJUSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "BALANCEADJUSTRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "AFCALDEMANDPRICERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL2TMBFBLDMDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL3TMBFBLDMDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCOUNTRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_BILLPRINTDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BILLPRINTDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EXPECTEDDEPOSITDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_COLLECTCONDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "COLLECTCONDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONSTAXLAYMETHODRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CONSTAXRATERF" ) );
            frePBillHeadWork.SECHED_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECHEDSECTIONGUIDENMRF" ) );
            frePBillHeadWork.SECHED_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECHEDSECTIONGUIDESNMRF" ) );
            frePBillHeadWork.SECHED_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SECHEDCOMPANYNAMECD1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRRF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME2RF" ) );
            frePBillHeadWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "POSTNORF" ) );
            frePBillHeadWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS1RF" ) );
            frePBillHeadWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS3RF" ) );
            frePBillHeadWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS4RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO2RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO3RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE2RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE3RF" ) );
            frePBillHeadWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSFERGUIDANCERF" ) );
            frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO1RF" ) );
            frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO2RF" ) );
            frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO3RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE2RF" ) );
            frePBillHeadWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "IMAGEINFOCODERF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYURLRF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRSENTENCE2RF" ) );
            frePBillHeadWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT1RF" ) );
            frePBillHeadWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT2RF" ) );
            frePBillHeadWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "IMAGEINFODATARF" ) );
            frePBillHeadWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSUBCODERF" ) );
            frePBillHeadWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAMERF" ) );
            frePBillHeadWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAME2RF" ) );
            frePBillHeadWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHONORIFICTITLERF" ) );
            frePBillHeadWork.CSTCST_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTKANARF" ) );
            frePBillHeadWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSNMRF" ) );
            frePBillHeadWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTOUTPUTNAMECODERF" ) );
            frePBillHeadWork.CSTCST_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTPOSTNORF" ) );
            frePBillHeadWork.CSTCST_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS1RF" ) );
            frePBillHeadWork.CSTCST_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS3RF" ) );
            frePBillHeadWork.CSTCST_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS4RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE1RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE2RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE3RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE4RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE5RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE6RF" ) );
            frePBillHeadWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE1RF" ) );
            frePBillHeadWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE2RF" ) );
            frePBillHeadWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE3RF" ) );
            frePBillHeadWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE4RF" ) );
            frePBillHeadWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE5RF" ) );
            frePBillHeadWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE6RF" ) );
            frePBillHeadWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE7RF" ) );
            frePBillHeadWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE8RF" ) );
            frePBillHeadWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE9RF" ) );
            frePBillHeadWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE10RF" ) );
            frePBillHeadWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSUBCODERF" ) );
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            frePBillHeadWork.CSTCLM_SALESCNSTAXFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMSALESCNSTAXFRCPROCCDRF"));
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
            frePBillHeadWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAMERF" ) );
            frePBillHeadWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAME2RF" ) );
            frePBillHeadWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHONORIFICTITLERF" ) );
            frePBillHeadWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMKANARF" ) );
            frePBillHeadWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSNMRF" ) );
            frePBillHeadWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMOUTPUTNAMECODERF" ) );
            frePBillHeadWork.CSTCLM_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMPOSTNORF" ) );
            frePBillHeadWork.CSTCLM_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS1RF" ) );
            frePBillHeadWork.CSTCLM_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS3RF" ) );
            frePBillHeadWork.CSTCLM_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS4RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE1RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE2RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE3RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE4RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE5RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE6RF" ) );
            frePBillHeadWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE1RF" ) );
            frePBillHeadWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE2RF" ) );
            frePBillHeadWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE3RF" ) );
            frePBillHeadWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE4RF" ) );
            frePBillHeadWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE5RF" ) );
            frePBillHeadWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE6RF" ) );
            frePBillHeadWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE7RF" ) );
            frePBillHeadWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE8RF" ) );
            frePBillHeadWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE9RF" ) );
            frePBillHeadWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE10RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYNAME1RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYNAME2RF" ) );
            frePBillHeadWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFPOSTNORF" ) );
            frePBillHeadWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS1RF" ) );
            frePBillHeadWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS3RF" ) );
            frePBillHeadWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS4RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO1RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO2RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO3RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE1RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE2RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE3RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD1RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD2RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD3RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD4RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD5RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD6RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD7RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD8RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD9RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD10RF" ) );
            frePBillHeadWork.DEPT01_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT01MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT01_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT01DEPOSITRF" ) );
            frePBillHeadWork.DEPT02_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT02MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT02_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT02DEPOSITRF" ) );
            frePBillHeadWork.DEPT03_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT03MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT03_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT03DEPOSITRF" ) );
            frePBillHeadWork.DEPT04_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT04MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT04_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT04DEPOSITRF" ) );
            frePBillHeadWork.DEPT05_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT05MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT05_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT05DEPOSITRF" ) );
            frePBillHeadWork.DEPT06_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT06MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT06_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT06DEPOSITRF" ) );
            frePBillHeadWork.DEPT07_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT07MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT07_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT07DEPOSITRF" ) );
            frePBillHeadWork.DEPT08_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT08MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT08_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT08DEPOSITRF" ) );
            frePBillHeadWork.DEPT09_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT09MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT09_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT09DEPOSITRF" ) );
            frePBillHeadWork.DEPT10_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT10MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT10_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT10DEPOSITRF" ) );
            frePBillHeadWork.CSTCST_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCOLLECTMONEYNAMERF" ) );
            frePBillHeadWork.CSTCST_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCOLLECTMONEYDAYRF" ) );
            frePBillHeadWork.CSTCST_HOMETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHOMETELNORF" ) );
            frePBillHeadWork.CSTCST_OFFICETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOFFICETELNORF" ) );
            frePBillHeadWork.CSTCST_PORTABLETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTPORTABLETELNORF" ) );
            frePBillHeadWork.CSTCST_HOMEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHOMEFAXNORF" ) );
            frePBillHeadWork.CSTCST_OFFICEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOFFICEFAXNORF" ) );
            frePBillHeadWork.CSTCST_OTHERSTELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOTHERSTELNORF" ) );
            frePBillHeadWork.CSTCLM_HOMETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHOMETELNORF" ) );
            frePBillHeadWork.CSTCLM_OFFICETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOFFICETELNORF" ) );
            frePBillHeadWork.CSTCLM_PORTABLETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMPORTABLETELNORF" ) );
            frePBillHeadWork.CSTCLM_HOMEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHOMEFAXNORF" ) );
            frePBillHeadWork.CSTCLM_OFFICEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOFFICEFAXNORF" ) );
            frePBillHeadWork.CSTCLM_OTHERSTELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOTHERSTELNORF" ) );
            frePBillHeadWork.CSTCLM_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCOLLECTMONEYNAMERF" ) );
            frePBillHeadWork.CSTCLM_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCOLLECTMONEYDAYRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RESULTSSECTCDRF" ) );
            frePBillHeadWork.ALITMDSPNMRF_HOMETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HOMETELNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_OFFICETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OFFICETELNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_MOBILETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOBILETELNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_HOMEFAXNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HOMEFAXNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OFFICEFAXNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_OTHERTELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OTHERTELNODSPNAMERF" ) );
            frePBillHeadWork.CSTCLM_SALESAREACODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMSALESAREACODERF" ) );
            frePBillHeadWork.CSTCLM_CUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERAGENTCDRF" ) );
            frePBillHeadWork.CSTCLM_BILLCOLLECTERCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMBILLCOLLECTERCDRF" ) );
            frePBillHeadWork.CSTCLM_OLDCUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOLDCUSTOMERAGENTCDRF" ) );
            frePBillHeadWork.CSTCLM_CUSTAGENTCHGDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTAGENTCHGDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_BILLNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BILLNORF" ) );
            // 2010/05/25 Add >>>
            frePBillHeadWork.CSTCST_COLLECTMONEYCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCOLLECTMONEYCODERF"));
            frePBillHeadWork.CSTCLM_COLLECTMONEYCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCOLLECTMONEYCODERF"));
            frePBillHeadWork.CSTCLM_TOTALDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMTOTALDAYRF"));
            // 2010/05/25 Add <<<
            # endregion

            return frePBillHeadWork;
        }
        /// <summary>
        /// 総括親への合算処理（親←親＋子）
        /// </summary>
        /// <param name="headWork"></param>
        /// <param name="childWork"></param>
        private void AddToSumCustParent( ref FrePBillHeadWork headWork, FrePBillHeadWork childWork )
        {
            # region [合算（親←親＋子）]
            headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF += childWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF; // 前回請求金額
            headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF += childWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF; // 今回手数料額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF += childWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF; // 今回値引額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF += childWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF; // 今回入金金額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF += childWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF; // 今回繰越残高（請求計）
            headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF += childWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF; // 相殺後今回売上金額
            headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF += childWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF; // 相殺後今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF += childWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF; // 相殺後外税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF += childWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF; // 相殺後内税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF += childWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF; // 相殺後非課税対象額
            headWork.CUSTDMDPRCRF_OFFSETOUTTAXRF += childWork.CUSTDMDPRCRF_OFFSETOUTTAXRF; // 相殺後外税消費税
            headWork.CUSTDMDPRCRF_OFFSETINTAXRF += childWork.CUSTDMDPRCRF_OFFSETINTAXRF; // 相殺後内税消費税
            headWork.CUSTDMDPRCRF_THISTIMESALESRF += childWork.CUSTDMDPRCRF_THISTIMESALESRF; // 今回売上金額
            headWork.CUSTDMDPRCRF_THISSALESTAXRF += childWork.CUSTDMDPRCRF_THISSALESTAXRF; // 今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF += childWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF; // 売上外税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF += childWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF; // 売上内税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF += childWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF; // 売上非課税対象額
            headWork.CUSTDMDPRCRF_SALESOUTTAXRF += childWork.CUSTDMDPRCRF_SALESOUTTAXRF; // 売上外税額
            headWork.CUSTDMDPRCRF_SALESINTAXRF += childWork.CUSTDMDPRCRF_SALESINTAXRF; // 売上内税額
            headWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF += childWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF; // 今回売上返品金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF += childWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF; // 今回売上返品消費税
            headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF; // 返品外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF; // 返品内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF += childWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF; // 返品非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF += childWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF; // 返品外税額合計
            headWork.CUSTDMDPRCRF_TTLRETINNERTAXRF += childWork.CUSTDMDPRCRF_TTLRETINNERTAXRF; // 返品内税額合計
            headWork.CUSTDMDPRCRF_THISSALESPRICDISRF += childWork.CUSTDMDPRCRF_THISSALESPRICDISRF; // 今回売上値引金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF += childWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF; // 今回売上値引消費税
            headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF; // 値引外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF; // 値引内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF += childWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF; // 値引非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF += childWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF; // 値引外税額合計
            headWork.CUSTDMDPRCRF_TTLDISINNERTAXRF += childWork.CUSTDMDPRCRF_TTLDISINNERTAXRF; // 値引内税額合計
            headWork.CUSTDMDPRCRF_TAXADJUSTRF += childWork.CUSTDMDPRCRF_TAXADJUSTRF; // 消費税調整額
            headWork.CUSTDMDPRCRF_BALANCEADJUSTRF += childWork.CUSTDMDPRCRF_BALANCEADJUSTRF; // 残高調整額
            headWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF += childWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF; // 計算後請求金額
            headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF += childWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF; // 受注2回前残高（請求計）
            headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF += childWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF; // 受注3回前残高（請求計）
            headWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF += childWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF; // 売上伝票枚数
            headWork.DEPT01_DEPOSITRF += childWork.DEPT01_DEPOSITRF; // 入金金額１
            headWork.DEPT02_DEPOSITRF += childWork.DEPT02_DEPOSITRF; // 入金金額２
            headWork.DEPT03_DEPOSITRF += childWork.DEPT03_DEPOSITRF; // 入金金額３
            headWork.DEPT04_DEPOSITRF += childWork.DEPT04_DEPOSITRF; // 入金金額４
            headWork.DEPT05_DEPOSITRF += childWork.DEPT05_DEPOSITRF; // 入金金額５
            headWork.DEPT06_DEPOSITRF += childWork.DEPT06_DEPOSITRF; // 入金金額６
            headWork.DEPT07_DEPOSITRF += childWork.DEPT07_DEPOSITRF; // 入金金額７
            headWork.DEPT08_DEPOSITRF += childWork.DEPT08_DEPOSITRF; // 入金金額８
            headWork.DEPT09_DEPOSITRF += childWork.DEPT09_DEPOSITRF; // 入金金額９
            headWork.DEPT10_DEPOSITRF += childWork.DEPT10_DEPOSITRF; // 入金金額１０
            # endregion
        }
        /// <summary>
        /// 総括親の集計項目クリア用
        /// </summary>
        /// <param name="headWork"></param>
        private void ClearSumCustParent( ref FrePBillHeadWork headWork )
        {
            //---------------------------------------------------------
            // ※得意先総括設定に、親自身のコードが登録されていない時、
            //   親の分の金額等を除外する為に、ゼロクリアします。
            //---------------------------------------------------------
            # region [ゼロクリア]
            headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF = 0; // 前回請求金額
            headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = 0; // 今回手数料額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = 0; // 今回値引額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = 0; // 今回入金金額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = 0; // 今回繰越残高（請求計）
            headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF = 0; // 相殺後今回売上金額
            headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF = 0; // 相殺後今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = 0; // 相殺後外税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = 0; // 相殺後内税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = 0; // 相殺後非課税対象額
            headWork.CUSTDMDPRCRF_OFFSETOUTTAXRF = 0; // 相殺後外税消費税
            headWork.CUSTDMDPRCRF_OFFSETINTAXRF = 0; // 相殺後内税消費税
            headWork.CUSTDMDPRCRF_THISTIMESALESRF = 0; // 今回売上金額
            headWork.CUSTDMDPRCRF_THISSALESTAXRF = 0; // 今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = 0; // 売上外税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF = 0; // 売上内税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = 0; // 売上非課税対象額
            headWork.CUSTDMDPRCRF_SALESOUTTAXRF = 0; // 売上外税額
            headWork.CUSTDMDPRCRF_SALESINTAXRF = 0; // 売上内税額
            headWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF = 0; // 今回売上返品金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = 0; // 今回売上返品消費税
            headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = 0; // 返品外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = 0; // 返品内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = 0; // 返品非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF = 0; // 返品外税額合計
            headWork.CUSTDMDPRCRF_TTLRETINNERTAXRF = 0; // 返品内税額合計
            headWork.CUSTDMDPRCRF_THISSALESPRICDISRF = 0; // 今回売上値引金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = 0; // 今回売上値引消費税
            headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = 0; // 値引外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = 0; // 値引内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = 0; // 値引非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF = 0; // 値引外税額合計
            headWork.CUSTDMDPRCRF_TTLDISINNERTAXRF = 0; // 値引内税額合計
            headWork.CUSTDMDPRCRF_TAXADJUSTRF = 0; // 消費税調整額
            headWork.CUSTDMDPRCRF_BALANCEADJUSTRF = 0; // 残高調整額
            headWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF = 0; // 計算後請求金額
            headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = 0; // 受注2回前残高（請求計）
            headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = 0; // 受注3回前残高（請求計）
            headWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF = 0; // 売上伝票枚数
            headWork.DEPT01_DEPOSITRF = 0; // 入金金額１
            headWork.DEPT02_DEPOSITRF = 0; // 入金金額２
            headWork.DEPT03_DEPOSITRF = 0; // 入金金額３
            headWork.DEPT04_DEPOSITRF = 0; // 入金金額４
            headWork.DEPT05_DEPOSITRF = 0; // 入金金額５
            headWork.DEPT06_DEPOSITRF = 0; // 入金金額６
            headWork.DEPT07_DEPOSITRF = 0; // 入金金額７
            headWork.DEPT08_DEPOSITRF = 0; // 入金金額８
            headWork.DEPT09_DEPOSITRF = 0; // 入金金額９
            headWork.DEPT10_DEPOSITRF = 0; // 入金金額１０
            # endregion
        }
        // --- ADD m.suzuki 2010/02/15 ----------<<<<<

        /// <summary>
        /// JOIN 条件生成
        /// </summary>
        /// <returns></returns>
        static private string GetJoinForHeadSection()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 DEL
            //return "( CUSTDMDPRCRF.CUSTOMERCODERF<>'0' AND CUSTDMDPRCRF.RESULTSSECTCDRF=SECHED.SECTIONCODERF ) "
            //       + " OR ( CUSTDMDPRCRF.CUSTOMERCODERF='0' AND CUSTDMDPRCRF.ADDUPSECCODERF=SECHED.SECTIONCODERF ) ";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
            return "(( CUSTDMDPRCRF.CUSTOMERCODERF<>'0' AND CUSTDMDPRCRF.RESULTSSECTCDRF=SECHED.SECTIONCODERF ) "
                   + " OR ( CUSTDMDPRCRF.CUSTOMERCODERF='0' AND CUSTDMDPRCRF.ADDUPSECCODERF=SECHED.SECTIONCODERF )) ";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
        }
        /// <summary>
        /// SELECT項目 取得処理（ヘッダ）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        private string GetSelectItemsForHead( FrePBillParaWork extPrm )
        {
            //---------------------------------------------------------------------------------
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            //       最後の項目は後ろにカンマ(,)を付けない。
            //---------------------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();

            // 自由帳票レイアウトとは別に制御用に取得が必要
            sb.Append( "CUSTDMDPRCRF.STARTCADDUPUPDDATERF, " + Environment.NewLine );

            # region [項目名]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/25 ADD
            sb.Append( "CUSTDMDPRCRF.BILLNORF, " + Environment.NewLine );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/25 ADD
            sb.Append( "CUSTDMDPRCRF.ADDUPSECCODERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMCODERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMNAMERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMNAME2RF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMSNMRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERCODERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERNAMERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERNAME2RF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ADDUPDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ADDUPYEARMONTHRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.LASTTIMEDEMANDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMEDMDNRMLRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMETTLBLCDMDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFSTHISTIMESALESRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFSTHISSALESTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDOFFSETINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFFSETOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFFSETINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMESALESRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDSALESOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDSALESINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDSALESTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.SALESOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.SALESINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRICRGDSRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDRETINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDRETTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLRETOUTERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLRETINNERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRICDISRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRCTAXDISRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDDISINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDDISTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLDISOUTERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLDISINNERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TAXADJUSTRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.BALANCEADJUSTRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.AFCALDEMANDPRICERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.STARTCADDUPUPDDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.SALESSLIPCOUNTRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.BILLPRINTDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.EXPECTEDDEPOSITDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.COLLECTCONDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CONSTAXLAYMETHODRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CONSTAXRATERF, " + Environment.NewLine );
            sb.Append( "SECHED.SECTIONGUIDENMRF AS SECHEDSECTIONGUIDENMRF, " + Environment.NewLine );
            sb.Append( "SECHED.SECTIONGUIDESNMRF AS SECHEDSECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "SECHED.COMPANYNAMECD1RF AS SECHEDCOMPANYNAMECD1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYPRRF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.POSTNORF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ADDRESS1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ADDRESS3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ADDRESS4RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.TRANSFERGUIDANCERF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ACCOUNTNOINFO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ACCOUNTNOINFO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ACCOUNTNOINFO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYSETNOTE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYSETNOTE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.IMAGEINFOCODERF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYURLRF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYPRSENTENCE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF, " + Environment.NewLine );
            sb.Append( "IMAGEINFORF.IMAGEINFODATARF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTOMERSUBCODERF AS CSTCSTCUSTOMERSUBCODERF, " + Environment.NewLine );
            sb.Append( "CSTCST.NAMERF AS CSTCSTNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCST.NAME2RF AS CSTCSTNAME2RF, " + Environment.NewLine );
            sb.Append( "CSTCST.HONORIFICTITLERF AS CSTCSTHONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "CSTCST.KANARF AS CSTCSTKANARF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTOMERSNMRF AS CSTCSTCUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "CSTCST.OUTPUTNAMECODERF AS CSTCSTOUTPUTNAMECODERF, " + Environment.NewLine );
            sb.Append( "CSTCST.POSTNORF AS CSTCSTPOSTNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.ADDRESS1RF AS CSTCSTADDRESS1RF, " + Environment.NewLine );
            sb.Append( "CSTCST.ADDRESS3RF AS CSTCSTADDRESS3RF, " + Environment.NewLine );
            sb.Append( "CSTCST.ADDRESS4RF AS CSTCSTADDRESS4RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE1RF AS CSTCSTCUSTANALYSCODE1RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE2RF AS CSTCSTCUSTANALYSCODE2RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE3RF AS CSTCSTCUSTANALYSCODE3RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE4RF AS CSTCSTCUSTANALYSCODE4RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE5RF AS CSTCSTCUSTANALYSCODE5RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE6RF AS CSTCSTCUSTANALYSCODE6RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE1RF AS CSTCSTNOTE1RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE2RF AS CSTCSTNOTE2RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE3RF AS CSTCSTNOTE3RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE4RF AS CSTCSTNOTE4RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE5RF AS CSTCSTNOTE5RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE6RF AS CSTCSTNOTE6RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE7RF AS CSTCSTNOTE7RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE8RF AS CSTCSTNOTE8RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE9RF AS CSTCSTNOTE9RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE10RF AS CSTCSTNOTE10RF, " + Environment.NewLine );
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            sb.Append("CSTCLM.SALESCNSTAXFRCPROCCDRF AS CSTCLMSALESCNSTAXFRCPROCCDRF, " + Environment.NewLine);
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
            sb.Append( "CSTCLM.CUSTOMERSUBCODERF AS CSTCLMCUSTOMERSUBCODERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NAMERF AS CSTCLMNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NAME2RF AS CSTCLMNAME2RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.HONORIFICTITLERF AS CSTCLMHONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.KANARF AS CSTCLMKANARF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTOMERSNMRF AS CSTCLMCUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OUTPUTNAMECODERF AS CSTCLMOUTPUTNAMECODERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.POSTNORF AS CSTCLMPOSTNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.ADDRESS1RF AS CSTCLMADDRESS1RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.ADDRESS3RF AS CSTCLMADDRESS3RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.ADDRESS4RF AS CSTCLMADDRESS4RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE1RF AS CSTCLMCUSTANALYSCODE1RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE2RF AS CSTCLMCUSTANALYSCODE2RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE3RF AS CSTCLMCUSTANALYSCODE3RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE4RF AS CSTCLMCUSTANALYSCODE4RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE5RF AS CSTCLMCUSTANALYSCODE5RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE6RF AS CSTCLMCUSTANALYSCODE6RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE1RF AS CSTCLMNOTE1RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE2RF AS CSTCLMNOTE2RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE3RF AS CSTCLMNOTE3RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE4RF AS CSTCLMNOTE4RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE5RF AS CSTCLMNOTE5RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE6RF AS CSTCLMNOTE6RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE7RF AS CSTCLMNOTE7RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE8RF AS CSTCLMNOTE8RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE9RF AS CSTCLMNOTE9RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE10RF AS CSTCLMNOTE10RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYNAME1RF AS COMPANYINFRFCOMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYNAME2RF AS COMPANYINFRFCOMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.POSTNORF AS COMPANYINFRFPOSTNORF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS1RF AS COMPANYINFRFADDRESS1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS3RF AS COMPANYINFRFADDRESS3RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS4RF AS COMPANYINFRFADDRESS4RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO1RF AS COMPANYINFRFCOMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO2RF AS COMPANYINFRFCOMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO3RF AS COMPANYINFRFCOMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE1RF AS COMPANYINFRFCOMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE2RF AS COMPANYINFRFCOMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE3RF AS COMPANYINFRFCOMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD1RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD2RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD3RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD4RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD5RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD6RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD7RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD8RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD9RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD10RF, " + Environment.NewLine );
            sb.Append( "DEPT01.MONEYKINDNAMERF AS DEPT01MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT01.DEPOSITRF AS DEPT01DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT02.MONEYKINDNAMERF AS DEPT02MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT02.DEPOSITRF AS DEPT02DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT03.MONEYKINDNAMERF AS DEPT03MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT03.DEPOSITRF AS DEPT03DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT04.MONEYKINDNAMERF AS DEPT04MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT04.DEPOSITRF AS DEPT04DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT05.MONEYKINDNAMERF AS DEPT05MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT05.DEPOSITRF AS DEPT05DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT06.MONEYKINDNAMERF AS DEPT06MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT06.DEPOSITRF AS DEPT06DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT07.MONEYKINDNAMERF AS DEPT07MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT07.DEPOSITRF AS DEPT07DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT08.MONEYKINDNAMERF AS DEPT08MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT08.DEPOSITRF AS DEPT08DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT09.MONEYKINDNAMERF AS DEPT09MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT09.DEPOSITRF AS DEPT09DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT10.MONEYKINDNAMERF AS DEPT10MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT10.DEPOSITRF AS DEPT10DEPOSITRF, " + Environment.NewLine );
            sb.Append( "CSTCST.COLLECTMONEYNAMERF AS CSTCSTCOLLECTMONEYNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCST.COLLECTMONEYDAYRF AS CSTCSTCOLLECTMONEYDAYRF, " + Environment.NewLine );
            // 2010/05/25 Add >>>
            sb.Append("CSTCST.COLLECTMONEYCODERF AS CSTCSTCOLLECTMONEYCODERF, " + Environment.NewLine);
            sb.Append("CSTCLM.COLLECTMONEYCODERF AS CSTCLMCOLLECTMONEYCODERF, " + Environment.NewLine);
            sb.Append("CSTCLM.TOTALDAYRF AS CSTCLMTOTALDAYRF, " + Environment.NewLine);
            // 2010/05/25 Add <<<
            sb.Append( "CSTCST.HOMETELNORF AS CSTCSTHOMETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.OFFICETELNORF AS CSTCSTOFFICETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.PORTABLETELNORF AS CSTCSTPORTABLETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.HOMEFAXNORF AS CSTCSTHOMEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.OFFICEFAXNORF AS CSTCSTOFFICEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.OTHERSTELNORF AS CSTCSTOTHERSTELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.HOMETELNORF AS CSTCLMHOMETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OFFICETELNORF AS CSTCLMOFFICETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.PORTABLETELNORF AS CSTCLMPORTABLETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.HOMEFAXNORF AS CSTCLMHOMEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OFFICEFAXNORF AS CSTCLMOFFICEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OTHERSTELNORF AS CSTCLMOTHERSTELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.COLLECTMONEYNAMERF AS CSTCLMCOLLECTMONEYNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.COLLECTMONEYDAYRF AS CSTCLMCOLLECTMONEYDAYRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.RESULTSSECTCDRF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.HOMETELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.OFFICETELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.MOBILETELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.HOMEFAXNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.OFFICEFAXNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.OTHERTELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.SALESAREACODERF AS CSTCLMSALESAREACODERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTOMERAGENTCDRF AS CSTCLMCUSTOMERAGENTCDRF, " + Environment.NewLine );
            sb.Append( "CSTCLM.BILLCOLLECTERCDRF AS CSTCLMBILLCOLLECTERCDRF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OLDCUSTOMERAGENTCDRF AS CSTCLMOLDCUSTOMERAGENTCDRF, " + Environment.NewLine );
            sb.Append("CSTCLM.CUSTAGENTCHGDATERF AS CSTCLMCUSTAGENTCHGDATERF " + Environment.NewLine);// ←最後の項目はカンマなし
            # endregion

            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="_sumCustChildDic"></param>
        /// <returns>WHERE文</returns>
        //private string MakeWhereStringForHead( ref SqlCommand sqlCommand, FrePBillParaWork extPrm )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private string MakeWhereStringForHead(ref SqlCommand sqlCommand, FrePBillParaWork extPrm, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append( " WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            whereString.Append( " AND ( " );
            for ( int index = 0; index < extPrm.FrePBillParaKeyList.Count; index++ )
            {
                if ( index > 0 )
                {
                    whereString.Append( " OR " );
                }

                //CUSTDMDPRCRF
                //  ADDUPSECCODERF
                //  CLAIMCODERF
                //  RESULTSSECTCDRF
                //  CUSTOMERCODERF
                //  ADDUPDATERF

                // --- UPD m.suzuki 2010/02/15 ---------->>>>>
                # region // DEL
                //// WHERE
                //whereString.Append( string.Format( "(CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODE{0} "
                //                                 + " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCLAIMCODE{0} "
                //                                 + " AND CUSTDMDPRCRF.RESULTSSECTCDRF=@FINDRESULTSSECTCD{0} "
                //                                 + " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} " 
                //                                 + " AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE{0})", index ) );

                //// 計上拠点コード
                //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPSECCODE{0}", index ), SqlDbType.NChar );
                //paraAddUpSecCode.Value = extPrm.FrePBillParaKeyList[index].AddUpSecCode;

                //// 請求先コード
                //SqlParameter paraClaimCode = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODE{0}", index ), SqlDbType.Int );
                //paraClaimCode.Value = extPrm.FrePBillParaKeyList[index].ClaimCode;

                //// 実績拠点コード
                //SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add( string.Format( "@FINDRESULTSSECTCD{0}", index ), SqlDbType.NChar );
                //paraResultsSectCd.Value = extPrm.FrePBillParaKeyList[index].ResultsSectCd;

                //// 得意先コード
                //SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                //paraCustomerCode.Value = extPrm.FrePBillParaKeyList[index].CustomerCode;

                //// 計上年月日
                //SqlParameter paraAddUpDate = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPDATE{0}", index ), SqlDbType.Int );
                //paraAddUpDate.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();
                # endregion

                if ( !extPrm.UseSumCust )
                {
                    //--------------------------------------------------
                    // 請求書
                    //--------------------------------------------------
                    # region [請求書]
                    // WHERE
                    whereString.Append( string.Format( "(CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODE{0} "
                                                     + " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCLAIMCODE{0} "
                                                     + " AND CUSTDMDPRCRF.RESULTSSECTCDRF=@FINDRESULTSSECTCD{0} "
                                                     + " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} " 
                                                     + " AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE{0})", index ) );

                    // 計上拠点コード
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPSECCODE{0}", index ), SqlDbType.NChar );
                    paraAddUpSecCode.Value = extPrm.FrePBillParaKeyList[index].AddUpSecCode;

                    // 請求先コード
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODE{0}", index ), SqlDbType.Int );
                    paraClaimCode.Value = extPrm.FrePBillParaKeyList[index].ClaimCode;

                    // 実績拠点コード
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add( string.Format( "@FINDRESULTSSECTCD{0}", index ), SqlDbType.NChar );
                    paraResultsSectCd.Value = extPrm.FrePBillParaKeyList[index].ResultsSectCd;

                    // 得意先コード
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                    paraCustomerCode.Value = extPrm.FrePBillParaKeyList[index].CustomerCode;

                    // 計上年月日
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPDATE{0}", index ), SqlDbType.Int );
                    paraAddUpDate.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();
                    # endregion
                }
                else
                {
                    //--------------------------------------------------
                    // 請求書（総括）
                    //--------------------------------------------------
                    # region [請求書（総括）]
                    // WHERE
                    whereString.Append( string.Format( "(CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODE{0} "
                                                     + " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCLAIMCODE{0} "
                                                     + " AND CUSTDMDPRCRF.RESULTSSECTCDRF=@FINDRESULTSSECTCD{0} "
                                                     + " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} "
                                                     + " AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE{0})", index ) );

                    // 計上拠点コード
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPSECCODE{0}", index ), SqlDbType.NChar );
                    paraAddUpSecCode.Value = extPrm.FrePBillParaKeyList[index].AddUpSecCode;

                    // 請求先コード
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODE{0}", index ), SqlDbType.Int );
                    paraClaimCode.Value = extPrm.FrePBillParaKeyList[index].ClaimCode;

                    // 実績拠点コード
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add( string.Format( "@FINDRESULTSSECTCD{0}", index ), SqlDbType.NChar );
                    //paraResultsSectCd.Value = extPrm.FrePBillParaKeyList[index].ResultsSectCd;
                    paraResultsSectCd.Value = "00";

                    // 得意先コード
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                    //paraCustomerCode.Value = extPrm.FrePBillParaKeyList[index].CustomerCode;
                    paraCustomerCode.Value = 0;

                    // 計上年月日
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPDATE{0}", index ), SqlDbType.Int );
                    paraAddUpDate.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();


                    if ( _sumCustChildDic.ContainsKey( extPrm.FrePBillParaKeyList[index].ClaimCode ) )
                    {
                        whereString.Append( " OR " );
                        whereString.Append( " ( " );

                        whereString.Append( " ( " );
                        // 全ての総括子を抽出対象にする
                        int index2 = 0;
                        foreach ( KeyValuePair<string, int> pair in _sumCustChildDic[extPrm.FrePBillParaKeyList[index].ClaimCode] )
                        {
                            if ( index2 > 0 )
                            {
                                whereString.Append( " OR " );
                            }
                            whereString.Append( string.Format( "(CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODESUB{0}_{1} "
                                                             + " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCLAIMCODESUB{0}_{1} "
                                                             + " AND CUSTDMDPRCRF.RESULTSSECTCDRF=@FINDRESULTSSECTCDSUB{0}_{1} "
                                                             + " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODESUB{0}_{1}) ", index, index2 ) );

                            // (総括子)計上拠点コード
                            SqlParameter paraAddUpSecCodeSub = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPSECCODESUB{0}_{1}", index, index2 ), SqlDbType.NChar );
                            paraAddUpSecCodeSub.Value = pair.Key.Trim();

                            // (総括子)請求先コード
                            SqlParameter paraClaimCodeSub = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODESUB{0}_{1}", index, index2 ), SqlDbType.Int );
                            paraClaimCodeSub.Value = pair.Value;

                            // 実績拠点コード
                            SqlParameter paraResultsSectCdSub = sqlCommand.Parameters.Add( string.Format( "@FINDRESULTSSECTCDSUB{0}_{1}", index, index2 ), SqlDbType.NChar );
                            paraResultsSectCdSub.Value = "00";

                            // 得意先コード
                            SqlParameter paraCustomerCodeSub = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODESUB{0}_{1}", index, index2 ), SqlDbType.Int );
                            paraCustomerCodeSub.Value = 0;


                            index2++;
                        }
                        whereString.Append( " ) " );

                        // 計上年月日
                        whereString.Append( string.Format( " AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATESUB{0}", index ) );
                        SqlParameter paraAddUpDateSub = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPDATESUB{0}", index ), SqlDbType.Int );
                        paraAddUpDateSub.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();
                        whereString.Append( " ) " );
                    }
                    # endregion
                }
                // --- UPD m.suzuki 2010/02/15 ----------<<<<<

                whereString.Append( Environment.NewLine );
            }
            whereString.Append( " ) " + Environment.NewLine );

            return whereString.ToString();
        }

        /// <summary>
        /// 締範囲取得処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="billList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //private int SearchProcOfDmdRangeSt( FrePBillParaWork extPrm, List<FrePBillHeadWork> billList, SqlConnection sqlConnection )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private int SearchProcOfDmdRangeSt(FrePBillParaWork extPrm, List<FrePBillHeadWork> billList, SqlConnection sqlConnection, ref Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, ref Dictionary<string, object> requestMessage)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            foreach ( FrePBillHeadWork headWork in billList )
            {
                //status = SearchProcOfDmdRangeStProc( extPrm, headWork, sqlConnection );// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                status = SearchProcOfDmdRangeStProc(extPrm, headWork, sqlConnection, ref  _dmdRangeEachClaimDic, ref requestMessage);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) break;
            }

            return status;
        }
        /// <summary>
        /// 締範囲取得処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="headWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //private int SearchProcOfDmdRangeStProc( FrePBillParaWork extPrm, FrePBillHeadWork headWork, SqlConnection sqlConnection )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private int SearchProcOfDmdRangeStProc(FrePBillParaWork extPrm, FrePBillHeadWork headWork, SqlConnection sqlConnection, ref Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, ref Dictionary<string, object> requestMessage)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            //----------------------------------------------------------------
            // ※SearchProcOfBillですでに締開始日を取得済みだが、
            //   ここではテーブル上のレコードを参照して前回レコード内容より
            //   再セットを行う。
            //----------------------------------------------------------------


            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // キー生成
            DmdRangeEachClaimKey key = new DmdRangeEachClaimKey( headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(), headWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                                 headWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(), headWork.CUSTDMDPRCRF_CUSTOMERCODERF );

            // ディクショナリに無い or ディクショナリにあるが初期値以外である場合は迂回
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            //if ( !_dmdRangeEachClaimDic.ContainsKey( key ) || _dmdRangeEachClaimDic[key].DmdRangeSt != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            string keyString = key.CreateKey();

            //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
            ////請求書ログ出力用
            //if (this.requestMessage.ContainsKey("締め範囲取得前開始日付") == false)
            //{
            //    this.requestMessage.Add("締め範囲取得前開始日付", _dmdRangeEachClaimDic[keyString].DmdRangeSt);
            //}
            //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<

            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
            //請求書ログ出力用
            if (requestMessage.ContainsKey("締め範囲取得前開始日付") == false)
            {
                requestMessage.Add("締め範囲取得前開始日付", _dmdRangeEachClaimDic[keyString].DmdRangeSt);
            }
            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<

            if ( !_dmdRangeEachClaimDic.ContainsKey( keyString ) || _dmdRangeEachClaimDic[keyString].DmdRangeSt != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            {
                return status;
            }

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   得意先請求金額マスタ　　　CustDmdPrcRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT " + Environment.NewLine
                    + " ENTERPRISECODERF, ADDUPSECCODERF, CLAIMCODERF, RESULTSSECTCDRF, CUSTOMERCODERF, MAX(ADDUPDATERF) AS MAXADDUPDATERF " + Environment.NewLine
                    + "FROM CUSTDMDPRCRF " + Environment.NewLine
                    + "WHERE " + Environment.NewLine
                    + "  ENTERPRISECODERF=@FINDENTERPRISECODE AND " + Environment.NewLine
                    + "  ADDUPSECCODERF=@FINDADDUPSECCODE AND " + Environment.NewLine
                    + "  CLAIMCODERF=@FINDCLAIMCODE AND " + Environment.NewLine
                    + "  RESULTSSECTCDRF=@FINDRESULTSSECTCD AND " + Environment.NewLine
                    + "  CUSTOMERCODERF=@FINDCUSTOMERCODE AND " + Environment.NewLine
                    + "  ADDUPDATERF<@FINDADDUPDATE " + Environment.NewLine
                    + "GROUP BY " + Environment.NewLine
                    + "  ENTERPRISECODERF, ADDUPSECCODERF, CLAIMCODERF, RESULTSSECTCDRF, CUSTOMERCODERF " + Environment.NewLine
                    , sqlConnection );

                // WHEREの条件
                // (企業コード)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;
                // (計上拠点コード)
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
                findParaAddUpSecCode.Value = headWork.CUSTDMDPRCRF_ADDUPSECCODERF;
                // (請求先コード)
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add( "@FINDCLAIMCODE", SqlDbType.Int );
                findParaClaimCode.Value = headWork.CUSTDMDPRCRF_CLAIMCODERF;
                // (実績拠点コード)
                SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
                findParaResultsSectCd.Value = headWork.CUSTDMDPRCRF_RESULTSSECTCDRF;
                // (得意先コード)
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
                findParaCustomerCode.Value = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;
                // (計上日終了...今回の１つ前を得る為"<"指定)
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add( "@FINDADDUPDATE", SqlDbType.Int );
                findParaAddUpDate.Value = headWork.CUSTDMDPRCRF_ADDUPDATERF;


                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );

                //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                ////請求書ログ出力用
                //if (this.requestMessage.ContainsKey("前回締日取得クエリ") == false)
                //{
                //     this.requestMessage.Add("前回締日取得クエリ", sqlCommand.CommandText);
                //}
                //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
                //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                //請求書ログ出力用
                if (requestMessage.ContainsKey("前回締日取得クエリ") == false)
                {
                    requestMessage.Add("前回締日取得クエリ", sqlCommand.CommandText);
                }
                //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                myReader = sqlCommand.ExecuteReader();


                while ( myReader.Read() )
                {
                    // 前回締日取得
                    int dmdRangeSt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXADDUPDATERF" ) );

                    if ( dmdRangeSt != 0 )
                    {
                        DateTime dmdRangeStDate;
                        try
                        {
                            // 前回締日＋１の日付にする（今回締開始日）
                            dmdRangeStDate = new DateTime( dmdRangeSt / 10000, (dmdRangeSt / 100) % 100, dmdRangeSt % 100 );
                            dmdRangeStDate = dmdRangeStDate.AddDays( 1 );
                            dmdRangeSt = (dmdRangeStDate.Year * 10000) + (dmdRangeStDate.Month * 100) + dmdRangeStDate.Day;
                            //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                            //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                            ////請求書ログ出力用
                            //if (this.requestMessage.ContainsKey("前回締日＋１") == false)
                            //{
                            //    this.requestMessage.Add("前回締日＋１", dmdRangeSt);
                            //}
                            // ----- DEL 2012/02/06 xupz for redmine#28258----------<<<<<
                            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                            //請求書ログ出力用
                            if (requestMessage.ContainsKey("前回締日＋１") == false)
                            {
                                requestMessage.Add("前回締日＋１", dmdRangeSt);
                            }
                            //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                        }
                        catch
                        {
                            break;
                        }

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                        //if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
                        //{
                        //    // 今回締開始日の書き換え（値型なので一度削除して再度追加）
                        //    DmdRangeEachClaim dmdRangeEachClaim = _dmdRangeEachClaimDic[key];
                        //    dmdRangeEachClaim.DmdRangeSt = dmdRangeSt;
                        //    _dmdRangeEachClaimDic.Remove( key );
                        //    _dmdRangeEachClaimDic.Add( key, dmdRangeEachClaim );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        string currKeyString = key.CreateKey();
                        if ( _dmdRangeEachClaimDic.ContainsKey( currKeyString ) )
                        {
                            // 今回締開始日の書き換え（値型なので一度削除して再度追加）
                            DmdRangeEachClaim dmdRangeEachClaim = _dmdRangeEachClaimDic[currKeyString];
                            dmdRangeEachClaim.DmdRangeSt = dmdRangeSt;
                            _dmdRangeEachClaimDic.Remove( currKeyString );
                            _dmdRangeEachClaimDic.Add( currKeyString, dmdRangeEachClaim );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                    }

                    break;
                }

            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }

            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
        /// <summary>
        /// Search 対象得意先
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="targetDate"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_childCustomerDic"></param>
        /// <returns></returns>
        //private int SearchProcOfTargetCustomers( FrePBillParaWork extPrm, int targetDate, SqlConnection sqlConnection )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private int SearchProcOfTargetCustomers(FrePBillParaWork extPrm, int targetDate, SqlConnection sqlConnection, ref Dictionary<int, List<int>> _childCustomerDic)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ディクショナリのクリア
            // 親得意先ディクショナリ（子→親）
            Dictionary<int, List<DmdSummaryKey>> _parentCustomerDic = new Dictionary<int, List<DmdSummaryKey>>();// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更

            //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
            //_parentCustomerDic = new Dictionary<int, List<DmdSummaryKey>>();
            //_childCustomerDic = new Dictionary<int, List<int>>();
            //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   得意先請求金額マスタ　　　CustDmdPrcRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT " + Environment.NewLine
                    + "  ADDUPSECCODERF, CLAIMCODERF, CUSTOMERCODERF " + Environment.NewLine
                    + "FROM CUSTDMDPRCRF " + Environment.NewLine
                    + "WHERE " + Environment.NewLine
                    + "  ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                    + "  AND ADDUPDATERF=@FINDADDUPDATE " + Environment.NewLine
                    + "  AND CUSTOMERCODERF<>'0'" + Environment.NewLine
                    + "GROUP BY " + Environment.NewLine
                    + "  ADDUPSECCODERF, CLAIMCODERF, CUSTOMERCODERF " + Environment.NewLine
                    , sqlConnection );

                // WHEREの条件
                // (企業コード)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;
                // (計上日)
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add( "@FINDADDUPDATE", SqlDbType.Int );
                findParaAddUpDate.Value = targetDate;


                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );
                myReader = sqlCommand.ExecuteReader();


                while ( myReader.Read() )
                {
                    // 計上拠点コード
                    string addUpSecCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                    // 請求先(親)
                    int claimCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                    // 得意先(子)
                    int customerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );


                    // 【子→親】ディクショナリに追加
                    // （念の為、親は複数持てる構造にしておく。
                    //   通常の運用では子→親で該当は１つのみだが、得意先実績修正での手入力など可能性はある為。）
                    if ( !_parentCustomerDic.ContainsKey( customerCode ) )
                    {
                        _parentCustomerDic.Add( customerCode, new List<DmdSummaryKey>() );
                    }
                    _parentCustomerDic[customerCode].Add( new DmdSummaryKey( addUpSecCode, claimCode ) );


                    // 【親→子】ディクショナリに追加
                    if ( !_childCustomerDic.ContainsKey( claimCode ) )
                    {
                        _childCustomerDic.Add( claimCode, new List<int>() );
                    }
                    _childCustomerDic[claimCode].Add( customerCode );
                }

            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }

            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

        # endregion

        # region [請求書売上明細データ抽出]
        /// <summary>
        /// Search 請求書明細（売上）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retObj"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_childCustomerDic"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="_sumCustChildDic"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
        //private int SearchProcOfSales( FrePBillParaWork extPrm, out Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>> retObj, SqlConnection sqlConnection )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        //private int SearchProcOfSales( FrePBillParaWork extPrm, out Dictionary<string, List<FrePBillDetailWork>> retObj, SqlConnection sqlConnection )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
        private int SearchProcOfSales(FrePBillParaWork extPrm, out Dictionary<string, List<FrePBillDetailWork>> retObj, SqlConnection sqlConnection,
            Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, ref Dictionary<string, object> requestMessage)
        //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            //Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>> frePBillDetailWorkList = new Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            Dictionary<string, List<FrePBillDetailWork>> frePBillDetailWorkList = new Dictionary<string, List<FrePBillDetailWork>>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            retObj = null;

            foreach ( FrePBillParaWork.FrePBillParaKey frePBillParaKey in extPrm.FrePBillParaKeyList )
            {
                try
                {
                    //-------------------------------------------------------------------
                    // 対象テーブル
                    //   売上データ　　　　　　　　×SalesSlipRF→○SALESHISTORYRF // 売上履歴データに変更 m.suzuki 2009.02.23
                    //     拠点情報設定マスタ②　　SecInfoSetRF As SECDTL
                    //     部門マスタ①　　　　　　SubsectionRF As SUBSAL
                    //     売上明細データ　　　　　×SalesDetailRF→○SALESHISTDTLRF // 売上履歴明細データに変更 m.suzuki 2009.02.23
                    //       受注マスタ(車両)　　　AcceptOdrCarRF
                    //-------------------------------------------------------------------
                    SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForSales( extPrm )
                        + Environment.NewLine
                        + " FROM SALESHISTORYRF " + Environment.NewLine
                        + LeftJoin( "SALESHISTORYRF", "SECINFOSETRF", "SECDTL", new string[] { "SECTIONCODERF" }, new string[] { } )  // 企業cd,拠点cd
                        + LeftJoin( "SALESHISTORYRF", "SUBSECTIONRF", "SUBSAL", new string[] { "SUBSECTIONCODERF" }, new string[] { } )  // 企業cd,部門cd
                        + LeftJoin( "SALESHISTORYRF", "SALESHISTDTLRF", string.Empty, new string[] { "ACPTANODRSTATUSRF", "SALESSLIPNUMRF" }, new string[] { } )  // 企業cd,受注ステータス,伝票番号
                        //+ LeftJoin( "SALESDETAILRF", "ACCEPTODRCARRF", string.Empty, new string[] { "ACCEPTANORDERNORF" }, new string[] { "ACCEPTODRCARRF.ACPTANODRSTATUSRF=7", "ACCEPTODRCARRF.DATAINPUTSYSTEMRF=0" } )  // 企業cd,受注番号,受注ステータス,データ入力システム
                        + LeftJoin( "SALESHISTDTLRF", "ACCEPTODRCARRF", string.Empty, new string[] { "ACCEPTANORDERNORF" }, new string[] { "ACCEPTODRCARRF.DATAINPUTSYSTEMRF='10'", GetAcceptOdrCarJoinCndtn() } )    // 企業cd, 受注番号,受注ｽﾃｰﾀｽが対応する(GetAcceptOdrCarJoinCndtn),入力ｼｽﾃﾑ=10:PM
                        , sqlConnection );

                    // WHERE文を生成
                    //sqlCommand.CommandText += MakeWhereStringForSales( ref sqlCommand, extPrm, frePBillParaKey );// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                    sqlCommand.CommandText += MakeWhereStringForSales(ref sqlCommand, extPrm, frePBillParaKey, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    sqlCommand.CommandText += " ORDER BY " + Environment.NewLine
                                              + " SALESHISTORYRF.ADDUPADATERF, SALESHISTORYRF.SALESSLIPNUMRF, SALESHISTDTLRF.SALESROWNORF " + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD


                    // タイムアウト時間設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );

                    //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                    //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                    ////請求書ログ出力用
                    //if (this.requestMessage.ContainsKey("売上明細取得クエリ") == false)
                    //{
                    //    this.requestMessage.Add("売上明細取得クエリ", sqlCommand.CommandText);
                    //}
                    //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
                    //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                    //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                    //請求書ログ出力用
                    if (requestMessage.ContainsKey("売上明細取得クエリ") == false)
                    {
                        requestMessage.Add("売上明細取得クエリ", sqlCommand.CommandText);
                    }
                    //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        FrePBillDetailWork frePBillDetailWork = new FrePBillDetailWork();

                        # region データのコピー
                        frePBillDetailWork.SALESSLIPRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBSECTIONCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEBITNOTEDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEBITNOTEDIVRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSLIPCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESGOODSCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ACCRECDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCRECDIVCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEMANDADDUPSECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEMANDADDUPSECCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_INPUTAGENCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INPUTAGENCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_INPUTAGENNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INPUTAGENNMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESINPUTCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESINPUTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTNAMERF" ) );
                        frePBillDetailWork.SALESSLIPRF_FRONTEMPLOYEECDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_FRONTEMPLOYEENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEENMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESEMPLOYEECDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEECDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESEMPLOYEENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEENMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTSUBTTLINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTSUBTTLINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTSUBTTLEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTSUBTTLEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKSUBTTLINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKSUBTTLINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKSUBTTLEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKSUBTTLEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSUBTOTALTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDPARTSDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDPARTSDISOUTTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDPARTSDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDPARTSDISINTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDWORKDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDWORKDISOUTTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDWORKDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDWORKDISINTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_PARTSDISCOUNTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSDISCOUNTRATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_RAVORDISCOUNTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "RAVORDISCOUNTRATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_TOTALCOSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TOTALCOSTRF" ) );
                        frePBillDetailWork.SALESSLIPRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CONSTAXRATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITSLIPNORF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITALLOWANCETTLRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEPOSITALWCBLNCERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITALWCBLNCERF" ) );
                        frePBillDetailWork.SALESSLIPRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDRESSEECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDRESSEECODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDRESSEENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAMERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDRESSEENAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAME2RF" ) );
                        frePBillDetailWork.SALESSLIPRF_PARTYSALESLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSALESLIPNUMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SLIPNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) );
                        frePBillDetailWork.SALESSLIPRF_SLIPNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE2RF" ) );
                        frePBillDetailWork.SALESSLIPRF_SLIPNOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE3RF" ) );
                        frePBillDetailWork.SALESSLIPRF_RETGOODSREASONDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "RETGOODSREASONDIVRF" ) );
                        frePBillDetailWork.SALESSLIPRF_RETGOODSREASONRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RETGOODSREASONRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DETAILROWCOUNTRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DETAILROWCOUNTRF" ) );
                        frePBillDetailWork.SALESSLIPRF_UOEREMARK1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK1RF" ) );
                        frePBillDetailWork.SALESSLIPRF_UOEREMARK2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK2RF" ) );
                        frePBillDetailWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVNMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "STOCKGOODSTTLTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "PUREGOODSTTLTAXEXCRF" ) );
                        //frePBillDetailWork.SALESSLIPRF_FOOTNOTES1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FOOTNOTES1RF" ) );
                        //frePBillDetailWork.SALESSLIPRF_FOOTNOTES2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FOOTNOTES2RF" ) );
                        frePBillDetailWork.SECDTL_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECDTLSECTIONGUIDENMRF" ) );
                        frePBillDetailWork.SECDTL_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECDTLSECTIONGUIDESNMRF" ) );
                        frePBillDetailWork.SECDTL_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SECDTLCOMPANYNAMECD1RF" ) );
                        frePBillDetailWork.SUBSAL_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUBSALSUBSECTIONNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCEPTANORDERNORF" ) );
                        //frePBillDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
                        //frePBillDetailWork.SALESDETAILRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
                        //frePBillDetailWork.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIGDSCMPLTDUEDATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSKINDCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_MAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );
                        //frePBillDetailWork.SALESDETAILRF_GOODSSHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSSHORTNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSLGROUPRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSLGROUPRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSLGROUPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSLGROUPNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSMGROUPRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSMGROUPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSMGROUPNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGROUPCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGROUPCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGROUPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGROUPNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSFULLNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ENTERPRISEGANRECODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISEGANRENAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WAREHOUSECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WAREHOUSENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESORDERDIVCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_OPENPRICEDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSRATERANKRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSRATERANKRF" ) );
                        frePBillDetailWork.SALESDETAILRF_LISTPRICERATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICERATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXINCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXEXCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESRATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXINCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXEXCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_COSTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "COSTRATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNITCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTBLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTBLGOODSCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTBLGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTBLGOODSNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WORKMANHOURRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "WORKMANHOURRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SHIPMENTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SHIPMENTCNTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXINCRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
                        frePBillDetailWork.SALESDETAILRF_COSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "COSTRF" ) );
                        //frePBillDetailWork.SALESDETAILRF_SALSEPRICECONSTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALSEPRICECONSTAXRF" ) );
                        frePBillDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TAXATIONDIVCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSLIPNUMDTLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_DTLNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DTLNOTERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SUPPLIERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERSNMRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SLIPMEMO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO1RF" ) );
                        frePBillDetailWork.SALESDETAILRF_SLIPMEMO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO2RF" ) );
                        frePBillDetailWork.SALESDETAILRF_SLIPMEMO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO3RF" ) );
                        frePBillDetailWork.SALESDETAILRF_INSIDEMEMO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO1RF" ) );
                        frePBillDetailWork.SALESDETAILRF_INSIDEMEMO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO2RF" ) );
                        frePBillDetailWork.SALESDETAILRF_INSIDEMEMO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO3RF" ) );
                        frePBillDetailWork.SALESDETAILRF_BFLISTPRICERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFLISTPRICERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFSALESUNITPRICERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BFUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFUNITCOSTRF" ) );
                        //frePBillDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNORF" ) );
                        //frePBillDetailWork.SALESDETAILRF_PRTGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNAMERF" ) );
                        //frePBillDetailWork.SALESDETAILRF_PRTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTGOODSMAKERCDRF" ) );
                        //frePBillDetailWork.SALESDETAILRF_PRTGOODSMAKERNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSMAKERNMRF" ) );
                        //frePBillDetailWork.SALESDETAILRF_CONTRACTDIVCDDTLRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONTRACTDIVCDDTLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTSALESROWNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTGOODSMAKERCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTMAKERNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTGOODSNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSHIPMENTCNTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSALESUNPRCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "CMPLTSALESMONEYRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSALESUNITCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTCOSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "CMPLTCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTPARTYSALSLNUMRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTNOTERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CARMNGNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CARMNGCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CARMNGCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "NUMBERPLATE1CODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE1NAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE2RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE3RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "NUMBERPLATE4RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FIRSTENTRYDATERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MAKERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MAKERFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERFULLNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EXHAUSTGASSIGNRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_SERIESMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SERIESMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CATEGORYSIGNMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FULLMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELDESIGNATIONNORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATEGORYNORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FRAMEMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMEMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FRAMENORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMENORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_SEARCHFRAMENORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEARCHFRAMENORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RELEVANCEMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_SUBCARNMCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBCARNMCDRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELGRADESNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELGRADESNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_COLORCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_COLORNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORNAME1RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_TRIMCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_TRIMNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MILEAGERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MILEAGERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) );
                        frePBillDetailWork.SALESSLIPRF_RESULTSADDUPSECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RESULTSADDUPSECCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMEKANARF" ) );
                        frePBillDetailWork.SALESDETAILRF_MAKERKANANAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERKANANAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTMAKERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTMAKERCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTMAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTMAKERNAMERF" ) );
                        // --- ADD  大矢睦美  2010/06/23 ---------->>>>>
                        frePBillDetailWork.SALESSLIPRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                        // --- ADD  大矢睦美  2010/06/23 ----------<<<<<
                        # endregion

                        # region [ディクショナリへの追加]
                        int totalDay = frePBillParaKey.GetAddUpDateLongDate();

                        # region [計上日差し替え]
                        // 締範囲キー生成
                        DmdRangeEachClaimKey claimkey = new DmdRangeEachClaimKey(
                                                            frePBillParaKey.AddUpSecCode.Trim(),
                                                            frePBillParaKey.ClaimCode,
                                                            frePBillParaKey.ResultsSectCd.Trim(),
                                                            frePBillParaKey.CustomerCode);

                        // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                        //if ( _dmdRangeEachClaimDic.ContainsKey( claimkey ) )
                        //{
                        //    totalDay = _dmdRangeEachClaimDic[claimkey].DmdRangeEd;
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        string claimKeyString = claimkey.CreateKey();
                        if ( _dmdRangeEachClaimDic.ContainsKey( claimKeyString ) )
                        {
                            totalDay = _dmdRangeEachClaimDic[claimKeyString].DmdRangeEd;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                        # endregion

                        // 親/子レコード用のKEY
                        FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey(
                                                                    frePBillParaKey.AddUpSecCode.Trim(),
                                                                    frePBillParaKey.ClaimCode,
                                                                    frePBillParaKey.ResultsSectCd.Trim(),
                                                                    frePBillParaKey.CustomerCode,
                                                                    totalDay );

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                        //if ( !frePBillDetailWorkList.ContainsKey( key ) )
                        //{
                        //    frePBillDetailWorkList.Add( key, new List<FrePBillDetailWork>() );
                        //}
                        //frePBillDetailWorkList[key].Add( frePBillDetailWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        string keyString = key.CreateKey();
                        if ( !frePBillDetailWorkList.ContainsKey( keyString ) )
                        {
                            frePBillDetailWorkList.Add( keyString, new List<FrePBillDetailWork>() );
                        }
                        frePBillDetailWorkList[keyString].Add( frePBillDetailWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                        # endregion
                    }

                    if ( frePBillDetailWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retObj = frePBillDetailWorkList;
                }
                catch ( Exception ex )
                {
                    base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    if ( myReader != null )
                    {
                        if ( !myReader.IsClosed )
                            myReader.Close();
                    }
                }
            }

            return status;
        }
        /// <summary>
        /// 受注マスタ（車輌）のjoin条件
        /// </summary>
        /// <returns></returns>
        private string GetAcceptOdrCarJoinCndtn()
        {
            // "SALESHISTDTLRF"  : 10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  
            // "ACCEPTODRCARRF" : 1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払
            StringBuilder text = new StringBuilder();

            ////text.Append( " (" );
            ////// 売上
            ////text.Append( " SALESHISTDTLRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='7' AND SALESHISTORYRF.SALESSLIPCDRF='0'" );
            ////// 返品
            ////text.Append( "OR" );
            ////text.Append( " SALESHISTDTLRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='8' AND SALESHISTORYRF.SALESSLIPCDRF='1'" );
            ////text.Append( ")" );

            // 売上
            text.Append( " SALESHISTDTLRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='7'" );

            return text.ToString();
        }

        ///// <summary>
        ///// 請求書キー生成（売上明細より）
        ///// </summary>
        ///// <param name="frePBillDetailWork"></param>
        ///// <returns></returns>
        //private FrePBillParaWork.FrePBillParaKey CreateBillKeyFromSales( FrePBillDetailWork frePBillDetailWork, bool isParent )
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/17 DEL
        //    //return new FrePBillParaWork.FrePBillParaKey(    frePBillDetailWork.SALESSLIPRF_DEMANDADDUPSECCDRF, 
        //    //                                                frePBillDetailWork.SALESSLIPRF_CLAIMCODERF, 
        //    //                                                frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF, 
        //    //                                                frePBillDetailWork.SALESSLIPRF_ADDUPADATERF );
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/17 DEL
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/17 ADD
        //    // 集計レコードの場合
        //    if ( isParent )
        //    {
        //        frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF = 0;
        //    }

        //    // 返却キー生成
        //    FrePBillParaWork.FrePBillParaKey retKey = new FrePBillParaWork.FrePBillParaKey();
        //    retKey.AddUpSecCode = frePBillDetailWork.SALESSLIPRF_DEMANDADDUPSECCDRF;
        //    retKey.ClaimCode = frePBillDetailWork.SALESSLIPRF_CLAIMCODERF;
        //    //retKey.ResultsSectCd = frePBillDetailWork.salessliprf_resu
        //    retKey.CustomerCode = frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF;

        //    // 締範囲キー生成
        //    DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
        //                                                         frePBillDetailWork.SALESSLIPRF_DEMANDADDUPSECCDRF , frePBillDetailWork.SALESSLIPRF_CLAIMCODERF, 
        //                                                         frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF);

        //    // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
        //    if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
        //    {
        //        retKey.SetAddUpDateLongDate( _dmdRangeEachClaimDic[key].DmdRangeEd );
        //    }
        //    else
        //    {
        //        retKey.SetAddUpDateLongDate( frePBillDetailWork.SALESSLIPRF_ADDUPADATERF );
        //    }

        //    return retKey;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/17 ADD
        //}

        ///// <summary>
        ///// 請求書キー生成
        ///// </summary>
        ///// <param name="frePBillDetailWork"></param>
        ///// <returns></returns>
        //private List<FrePBillParaWork.FrePBillParaKey> CreateBillKeyFromSales( FrePBillDetailWork frePBillDetailWork )
        //{
        //    List<FrePBillParaWork.FrePBillParaKey> retKeyList = new List<FrePBillParaWork.FrePBillParaKey>();

        //    if ( _parentCustomerDic.ContainsKey( frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF ) )
        //    {
        //        foreach ( DmdSummaryKey sumKey in _parentCustomerDic[frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF] )
        //        {
        //            int totalDay = frePBillDetailWork.SALESSLIPRF_ADDUPADATERF;

        //            # region [計上日差し替え]
        //            // 締範囲キー生成
        //            DmdRangeEachClaimKey claimkey = new DmdRangeEachClaimKey( 
        //                                                sumKey.AddUpSecCode.Trim(), 
        //                                                sumKey.ClaimCode,
        //                                                frePBillDetailWork.SALESSLIPRF_RESULTSADDUPSECCDRF.Trim(), 
        //                                                frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF );

        //            // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
        //            if ( _dmdRangeEachClaimDic.ContainsKey( claimkey ) )
        //            {
        //                totalDay = _dmdRangeEachClaimDic[claimkey].DmdRangeEd;
        //            }
        //            # endregion

        //            // 親/子レコード用のKEY
        //            FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey( 
        //                                                        sumKey.AddUpSecCode.Trim(), 
        //                                                        sumKey.ClaimCode,
        //                                                        frePBillDetailWork.SALESSLIPRF_RESULTSADDUPSECCDRF.Trim(), 
        //                                                        frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF, 
        //                                                        totalDay );
        //            if ( !retKeyList.Contains( key ) ) retKeyList.Add( key );

        //            # region [計上日差し替え]
        //            // 締範囲キー生成
        //            claimkey = new DmdRangeEachClaimKey(
        //                        sumKey.AddUpSecCode.Trim(),
        //                        sumKey.ClaimCode,
        //                        "00",
        //                        0 );

        //            // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
        //            if ( _dmdRangeEachClaimDic.ContainsKey( claimkey ) )
        //            {
        //                totalDay = _dmdRangeEachClaimDic[claimkey].DmdRangeEd;
        //            }
        //            # endregion

        //            // 集計レコード用のKEY
        //            key = new FrePBillParaWork.FrePBillParaKey( sumKey.AddUpSecCode.Trim(), sumKey.ClaimCode, "00", 0, totalDay );
        //            if ( !retKeyList.Contains( key ) ) retKeyList.Add( key );
        //        }
        //    }

        //    return retKeyList;
        //}

        /// <summary>
        /// SELECT項目 取得処理（売上明細）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string GetSelectItemsForSales( FrePBillParaWork extPrm )
        {
            //---------------------------------------------------------------------------------
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            //       最後の項目は後ろにカンマ(,)を付けない。
            //---------------------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();

            # region [項目名]
            sb.Append( "SALESHISTORYRF.ACPTANODRSTATUSRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSLIPNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SECTIONCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SUBSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEBITNOTEDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSLIPCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESGOODSCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ACCRECDIVCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEMANDADDUPSECCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESDATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDUPADATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.INPUTAGENCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.INPUTAGENNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESINPUTCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESINPUTNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.FRONTEMPLOYEECDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.FRONTEMPLOYEENMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESEMPLOYEECDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESEMPLOYEENMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSUBTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSUBTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTSUBTTLINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTSUBTTLEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKSUBTTLINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKSUBTTLEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSUBTOTALTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDPARTSDISOUTTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDPARTSDISINTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDWORKDISOUTTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDWORKDISINTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.PARTSDISCOUNTRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RAVORDISCOUNTRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.TOTALCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CONSTAXRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.AUTODEPOSITCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.AUTODEPOSITSLIPNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEPOSITALLOWANCETTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEPOSITALWCBLNCERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CLAIMCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERNAME2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.HONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDRESSEECODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDRESSEENAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDRESSEENAME2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.PARTYSALESLIPNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SLIPNOTERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SLIPNOTE2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SLIPNOTE3RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RETGOODSREASONDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RETGOODSREASONRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DETAILROWCOUNTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.UOEREMARK1RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.UOEREMARK2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DELIVEREDGOODSDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DELIVEREDGOODSDIVNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.STOCKGOODSTTLTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.PUREGOODSTTLTAXEXCRF, " + Environment.NewLine );
            //sb.Append( "SALESHISTORYRF.FOOTNOTES1RF, " + Environment.NewLine );
            //sb.Append( "SALESHISTORYRF.FOOTNOTES2RF, " + Environment.NewLine );
            sb.Append( "SECDTL.SECTIONGUIDENMRF AS SECDTLSECTIONGUIDENMRF, " + Environment.NewLine );
            sb.Append( "SECDTL.SECTIONGUIDESNMRF AS SECDTLSECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "SECDTL.COMPANYNAMECD1RF AS SECDTLCOMPANYNAMECD1RF, " + Environment.NewLine );
            sb.Append( "SUBSAL.SUBSECTIONNAMERF AS SUBSALSUBSECTIONNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.ACCEPTANORDERNORF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.ACPTANODRSTATUSRF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.SALESSLIPNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESROWNORF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.DELIGDSCMPLTDUEDATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSKINDCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSMAKERCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.MAKERNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSNAMERF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.GOODSSHORTNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSLGROUPRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSLGROUPNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSMGROUPRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSMGROUPNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGROUPCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGROUPNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGOODSCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGOODSFULLNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.ENTERPRISEGANRECODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.ENTERPRISEGANRENAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WAREHOUSECODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WAREHOUSENAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WAREHOUSESHELFNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESORDERDIVCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.OPENPRICEDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSRATERANKRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.LISTPRICERATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.LISTPRICETAXINCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.LISTPRICETAXEXCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESUNPRCTAXINCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESUNPRCTAXEXCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.COSTRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESUNITCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTBLGOODSCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTBLGOODSNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WORKMANHOURRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SHIPMENTCNTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESMONEYTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESMONEYTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.COSTRF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.SALSEPRICECONSTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.TAXATIONDIVCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PARTYSLIPNUMDTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.DTLNOTERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SUPPLIERCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SUPPLIERSNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SLIPMEMO1RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SLIPMEMO2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SLIPMEMO3RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.INSIDEMEMO1RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.INSIDEMEMO2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.INSIDEMEMO3RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BFLISTPRICERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BFSALESUNITPRICERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BFUNITCOSTRF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.PRTGOODSNORF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.PRTGOODSNAMERF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.PRTGOODSMAKERCDRF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.PRTGOODSMAKERNMRF, " + Environment.NewLine );
            //sb.Append( "SALESHISTDTLRF.CONTRACTDIVCDDTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESROWNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTGOODSMAKERCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTMAKERNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTGOODSNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSHIPMENTCNTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESUNPRCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESMONEYRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESUNITCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTPARTYSALSLNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTNOTERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CARMNGNORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CARMNGCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE1CODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE1NAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE2RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE3RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE4RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FIRSTENTRYDATERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MAKERCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MAKERFULLNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELSUBCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELFULLNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.EXHAUSTGASSIGNRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.SERIESMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CATEGORYSIGNMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FULLMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELDESIGNATIONNORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CATEGORYNORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FRAMEMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FRAMENORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.SEARCHFRAMENORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.ENGINEMODELNMRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.RELEVANCEMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.SUBCARNMCDRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELGRADESNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.COLORCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.COLORNAME1RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.TRIMCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.TRIMNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MILEAGERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESSLIPCDDTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RESULTSADDUPSECCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSNAMEKANARF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.MAKERKANANAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELHALFNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTGOODSNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTMAKERCODERF, " + Environment.NewLine );
            // --- ADD  大矢睦美  2010/06/23 ---------->>>>>
            sb.Append("SALESHISTORYRF.CONSTAXLAYMETHODRF, " + Environment.NewLine);
            // --- ADD  大矢睦美  2010/06/23 ----------<<<<<
            sb.Append( "SALESHISTDTLRF.PRTMAKERNAMERF " + Environment.NewLine );// ←最後の項目はカンマなし
            # endregion

            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理（売上明細）
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="paraKey"></param>
        /// <param name="_childCustomerDic"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="_sumCustChildDic"></param>
        /// <returns>WHERE文</returns>
        //private string MakeWhereStringForSales( ref SqlCommand sqlCommand, FrePBillParaWork extPrm, FrePBillParaWork.FrePBillParaKey paraKey ) // DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private string MakeWhereStringForSales(ref SqlCommand sqlCommand, FrePBillParaWork extPrm, FrePBillParaWork.FrePBillParaKey paraKey, Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic) // ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append( " WHERE SALESHISTORYRF.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータス 30=売上 のみ
            whereString.Append( " AND SALESHISTORYRF.ACPTANODRSTATUSRF='30' " );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            # region // DEL
            //whereString.Append( " AND ( " );

            //for ( int index = 0; index < extPrm.FrePBillParaKeyList.Count; index++ )
            //{
            //    if ( index > 0 )
            //    {
            //        whereString.Append( " OR " );
            //    }

            //    //SALESSLIPRF
            //    //  DEMANDADDUPSECCDRF
            //    //  CLAIMCODERF
            //    //  CUSTOMERCODERF
            //    //  ADDUPADATERF

            //    // WHERE
            //    //whereString.Append( string.Format( "(SALESHISTORYRF.DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD{0} AND SALESHISTORYRF.CLAIMCODERF=@FINDCLAIMCODE{0} AND SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} AND SALESHISTORYRF.ADDUPADATERF=@FINDADDUPADATE{0})", index ) );

            //    whereString.Append( "(" );

            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            //    //// 計上拠点コード
            //    //whereString.Append( string.Format( "SALESHISTORYRF.DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD{0} ", index ) );
            //    //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add( string.Format( "@FINDDEMANDADDUPSECCD{0}", index ), SqlDbType.NChar );
            //    //paraAddUpSecCode.Value = extPrm.FrePBillParaKeyList[index].AddUpSecCode;

            //    //// 請求先コード
            //    //whereString.Append( string.Format( "AND SALESHISTORYRF.CLAIMCODERF=@FINDCLAIMCODE{0} ", index ) );
            //    //SqlParameter paraClaimCode = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODE{0}", index ), SqlDbType.Int );
            //    //paraClaimCode.Value = extPrm.FrePBillParaKeyList[index].ClaimCode;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL

            //    // 得意先コード
            //    if ( extPrm.FrePBillParaKeyList[index].CustomerCode != 0)
            //    {
            //        whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", index ) );
            //        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
            //        paraCustomerCode.Value = extPrm.FrePBillParaKeyList[index].CustomerCode;
            //    }

            //    // 計上年月日
            //    //whereString.Append( string.Format( "AND SALESHISTORYRF.ADDUPADATERF=@FINDADDUPADATE{0} ", index ) );
            //    //SqlParameter paraAddUpDate = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATE{0}", index ), SqlDbType.Int );
            //    //paraAddUpDate.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();

            //    // 伝票発行時と集計時で異なる可能性があるのでWHERE句にはAddUpSecCode,ClaimCodeを含めないが、
            //    // 抽出範囲の取得ではKEYとして指定する。
            //    DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
            //                                        extPrm.FrePBillParaKeyList[index].AddUpSecCode,
            //                                        extPrm.FrePBillParaKeyList[index].ClaimCode,
            //                                        extPrm.FrePBillParaKeyList[index].ResultsSectCd,
            //                                        extPrm.FrePBillParaKeyList[index].CustomerCode );

            //    DmdRangeEachClaim dmdRangeEachClaim;
            //    if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
            //    {
            //        dmdRangeEachClaim = _dmdRangeEachClaimDic[key];
            //    }
            //    else
            //    {
            //        dmdRangeEachClaim = new DmdRangeEachClaim( 0, 0 );
            //    }
                
            //    whereString.Append( string.Format( " AND SALESHISTORYRF.ADDUPADATERF>=@FINDADDUPADATEST{0} AND SALESHISTORYRF.ADDUPADATERF<=@FINDADDUPADATEED{0}", index ) );
            //    SqlParameter paraAddUpDateSt = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEST{0}", index ), SqlDbType.Int );
            //    paraAddUpDateSt.Value = dmdRangeEachClaim.DmdRangeSt;
            //    SqlParameter paraAddUpDateEd = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEED{0}", index ), SqlDbType.Int );
            //    paraAddUpDateEd.Value = dmdRangeEachClaim.DmdRangeEd;

            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/30 ADD
            //    // 売掛区分 AccRecDivCdRF（0:売掛なし,1:売掛）→1:売掛のみを対象とする
            //    whereString.Append( string.Format( " AND SALESHISTORYRF.ACCRECDIVCDRF=1 " ) );
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/30 ADD

            //    whereString.Append( ")" );
            //    whereString.Append( Environment.NewLine );
            //}
            //whereString.Append( " ) " + Environment.NewLine );
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD

            whereString.Append( " AND " );

            // --- ADD m.suzuki 2010/02/15 ---------->>>>>
            if ( !extPrm.UseSumCust )
            {
                //--------------------------------------------------------
                // 請求書
                //--------------------------------------------------------
            // --- ADD m.suzuki 2010/02/15 ----------<<<<<
                // 得意先コード
                if ( paraKey.CustomerCode != 0 )
                {
                    // 集計レコード以外はそのまま指定(１コードのみ)
                    whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                    paraCustomerCode.Value = paraKey.CustomerCode;

                    // ----- ADD 2012/03/05 xupz for redmine#28258---------->>>>>
                    // 計上拠点コード
                    whereString.Append(string.Format("AND SALESHISTORYRF.DEMANDADDUPSECCDRF =@FINDDEMANDADDUPSECCD{0} ", 0));
                    SqlParameter paraDemandAddUpSecCd = sqlCommand.Parameters.Add(string.Format("@FINDDEMANDADDUPSECCD{0}", 0), SqlDbType.NChar);
                    paraDemandAddUpSecCd.Value = paraKey.AddUpSecCode;

                    // 実績拠点コード
                    whereString.Append(string.Format("AND SALESHISTORYRF.RESULTSADDUPSECCDRF =@FINDRESULTSADDUPSECCD{0} ", 0));
                    SqlParameter paraResultSecCode = sqlCommand.Parameters.Add(string.Format("@FINDRESULTSADDUPSECCD{0}", 0), SqlDbType.NChar);
                    paraResultSecCode.Value = paraKey.ResultsSectCd;
                    // ----- ADD 2012/03/05 xupz for redmine#28258----------<<<<<
                }
                else
                {
                    // 集計レコードの場合は属する得意先コードを全て指定(複数コード)
                    if ( _childCustomerDic.ContainsKey( paraKey.ClaimCode ) )
                    {
                        whereString.Append( " ( " );
                        int index = 0;

                        foreach ( int customerCode in _childCustomerDic[paraKey.ClaimCode] )
                        {
                            if ( index > 0 )
                            {
                                whereString.Append( " OR " );
                            }
                            whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", index ) );
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                            paraCustomerCode.Value = customerCode;
                            index++;
                        }

                        whereString.Append( " ) " );
                    }
                    else
                    {
                        // 集計レコード以外はそのまま指定(１コードのみ)
                        whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                        paraCustomerCode.Value = paraKey.ClaimCode;
                    }
                }
            // --- ADD m.suzuki 2010/02/15 ---------->>>>>
            }
            else
            {
                //--------------------------------------------------------
                // 請求書(総括)
                //--------------------------------------------------------

                whereString.Append( " ( " );

                int index = 0;
                bool cndtnAdded = false;
                // 総括親(総括得意先)→全ての総括子(請求先)
                foreach ( KeyValuePair<string, int> pair in _sumCustChildDic[paraKey.ClaimCode] )
                {
                    int claimCode = pair.Value;

                    // 総括子(請求先)→全ての子得意先(得意先)
                    int index2 = 0;
                    foreach ( int customerCode in _childCustomerDic[claimCode] )
                    {
                        if ( cndtnAdded )
                        {
                            whereString.Append( " OR " );
                        }
                        whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODESUB{0}_{1} ", index, index2 ) );
                        SqlParameter paraCustomerCodeSub = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODESUB{0}_{1}", index, index2 ), SqlDbType.Int );
                        paraCustomerCodeSub.Value = customerCode;

                        index2++;
                        cndtnAdded = true;
                    }

                    index++;
                }

                whereString.Append( " ) " );
            }
            // --- ADD m.suzuki 2010/02/15 ----------<<<<<

            // 計上年月日
            // 伝票発行時と集計時で異なる可能性があるのでWHERE句にはAddUpSecCode,ClaimCodeを含めないが、
            // 抽出範囲の取得ではKEYとして指定する。
            DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                paraKey.AddUpSecCode.Trim(),
                                                paraKey.ClaimCode,
                                                paraKey.ResultsSectCd.Trim(),
                                                paraKey.CustomerCode );

            DmdRangeEachClaim dmdRangeEachClaim;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            //if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
            //{
            //    dmdRangeEachClaim = _dmdRangeEachClaimDic[key];
            //}
            //else
            //{
            //    dmdRangeEachClaim = new DmdRangeEachClaim( 0, paraKey.GetAddUpDateLongDate() );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            string keyString = key.CreateKey();
            if ( _dmdRangeEachClaimDic.ContainsKey( keyString ) )
            {
                dmdRangeEachClaim = _dmdRangeEachClaimDic[keyString];
            }
            else
            {
                dmdRangeEachClaim = new DmdRangeEachClaim( 0, paraKey.GetAddUpDateLongDate() );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            whereString.Append( string.Format( " AND SALESHISTORYRF.ADDUPADATERF>=@FINDADDUPADATEST{0} AND SALESHISTORYRF.ADDUPADATERF<=@FINDADDUPADATEED{0}", 0 ) );
            SqlParameter paraAddUpDateSt = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEST{0}", 0 ), SqlDbType.Int );
            paraAddUpDateSt.Value = dmdRangeEachClaim.DmdRangeSt;
            SqlParameter paraAddUpDateEd = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEED{0}", 0 ), SqlDbType.Int );
            paraAddUpDateEd.Value = dmdRangeEachClaim.DmdRangeEd;

            // 売掛区分 AccRecDivCdRF（0:売掛なし,1:売掛）→1:売掛のみを対象とする
            //whereString.Append( string.Format( " AND SALESHISTORYRF.ACCRECDIVCDRF='1' " ) ); //DEL BY 凌小青 on 2011/11/28 for Redmine#7765
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
            // 論理削除分は除外
            //LOGICALDELETECODERF='0'
            whereString.Append( " AND SALESHISTORYRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine );
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            paraLogicalDeleteCode.Value = 0;

            // 赤伝と元黒は除外(0:黒のみ)
            whereString.Append( " AND SALESHISTORYRF.DEBITNOTEDIVRF=@FINDDEBITNOTEDIV " + Environment.NewLine );
            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add( "@FINDDEBITNOTEDIV", SqlDbType.Int );
            paraDebitNoteDiv.Value = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

            return whereString.ToString();
        }

        # endregion

        # region [請求書入金明細データ抽出]
        /// <summary>
        /// Search 請求書明細（入金）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retObj"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="_childCustomerDic"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="_sumCustChildDic"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
        //private int SearchProcOfDeposit( FrePBillParaWork extPrm, out Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>> retObj, SqlConnection sqlConnection )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
        //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        //private int SearchProcOfDeposit( FrePBillParaWork extPrm, out Dictionary<string, List<FrePBillDetailWork>> retObj, SqlConnection sqlConnection )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
        //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
        private int SearchProcOfDeposit(FrePBillParaWork extPrm, out Dictionary<string, List<FrePBillDetailWork>> retObj, SqlConnection sqlConnection
            , Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, ref Dictionary<string, object> requestMessage)
        //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            //Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>> frePBillDetailWorkList = new Dictionary<FrePBillParaWork.FrePBillParaKey, List<FrePBillDetailWork>>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            Dictionary<string, List<FrePBillDetailWork>> frePBillDetailWorkList = new Dictionary<string, List<FrePBillDetailWork>>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            retObj = null;

            foreach ( FrePBillParaWork.FrePBillParaKey frePBillParaKey in extPrm.FrePBillParaKeyList )
            {
                // add 2012/07/02 >>>
                if (frePBillParaKey.CustomerCode != 0 && (frePBillParaKey.AddUpSecCode != frePBillParaKey.ResultsSectCd || frePBillParaKey.ClaimCode != frePBillParaKey.CustomerCode))
                {
                    continue;
                }
                // add 2012/07/02 <<<
                try
                {
                    //-------------------------------------------------------------------
                    // 対象テーブル
                    //   入金マスタ　　　　DepsitMainRF
                    //     部門マスタ②　　SubsectionRF As SUBDEP
                    //     入金明細データ　DepositDtlRF
                    //-------------------------------------------------------------------
                    SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForDeposit( extPrm )
                        + Environment.NewLine
                        + " FROM DEPSITMAINRF " + Environment.NewLine
                        + LeftJoin( "DEPSITMAINRF", "SUBSECTIONRF", "SUBDEP", new string[] { "SUBSECTIONCODERF" }, new string[] { } )  // 企業cd,部門cd
                        + LeftJoin( "DEPSITMAINRF", "DEPSITDTLRF", string.Empty, new string[] { "ACPTANODRSTATUSRF", "DEPOSITSLIPNORF" }, new string[] { } )  // 企業cd,受注ステータス,入金伝票番号
                        , sqlConnection );

                    // WHERE文を生成
                    //sqlCommand.CommandText += MakeWhereStringForDeposit( ref sqlCommand, extPrm, frePBillParaKey );// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                    sqlCommand.CommandText += MakeWhereStringForDeposit(ref sqlCommand, extPrm, frePBillParaKey, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic);// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                    // タイムアウト時間設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );
                    //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                    //// ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                    ////請求書ログ出力用
                    //if (this.requestMessage.ContainsKey("入金明細取得クエリ") == false)
                    //{
                    //    this.requestMessage.Add("入金明細取得クエリ", sqlCommand.CommandText);
                    //}
                    //// ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
                    //-----DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<
                    //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 ----->>>>>
                    //請求書ログ出力用
                    if (requestMessage.ContainsKey("入金明細取得クエリ") == false)
                    {
                        requestMessage.Add("入金明細取得クエリ", sqlCommand.CommandText);
                    }
                    //-----ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更 -----<<<<<  
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        FrePBillDetailWork frePBillDetailWork = new FrePBillDetailWork();

                        # region データのコピー
                        frePBillDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSLIPNORF" ) );
                        frePBillDetailWork.DEPSITMAINRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBSECTIONCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITDATERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "FEEDEPOSITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DISCOUNTDEPOSITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITCDRF" ) );
                        //frePBillDetailWork.DEPSITMAINRF_DEPOSITCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITCDRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DRAFTDRAWINGDATERF" ) );
                        //frePBillDetailWork.DEPSITMAINRF_DRAFTPAYTIMELIMITRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DRAFTPAYTIMELIMITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTKINDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DRAFTKINDRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DRAFTKINDNAMERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DRAFTDIVIDENAMERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DRAFTNORF" ) );
                        frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_OUTLINERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTLINERF" ) );
                        frePBillDetailWork.SUBDEP_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUBDEPSUBSECTIONNAMERF" ) );
                        frePBillDetailWork.DEPSITDTLRF_DEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFDEPOSITSLIPNORF" ) );
                        frePBillDetailWork.DEPSITDTLRF_DEPOSITROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFDEPOSITROWNORF" ) );
                        frePBillDetailWork.DEPSITDTLRF_MONEYKINDCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFMONEYKINDCODERF" ) );
                        frePBillDetailWork.DEPSITDTLRF_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPSITDTLRFMONEYKINDNAMERF" ) );
                        frePBillDetailWork.DEPSITDTLRF_MONEYKINDDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFMONEYKINDDIVRF" ) );
                        frePBillDetailWork.DEPSITDTLRF_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPSITDTLRFDEPOSITRF" ) );
                        frePBillDetailWork.DEPSITDTLRF_VALIDITYTERMRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFVALIDITYTERMRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_INPUTDEPOSITSECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INPUTDEPOSITSECCDRF" ) );
                        # endregion

                        # region [ディクショナリへの追加]
                        int totalDay = frePBillParaKey.GetAddUpDateLongDate();

                        # region [計上日差し替え]
                        // 締範囲キー生成
                        DmdRangeEachClaimKey claimkey = new DmdRangeEachClaimKey(
                                                            frePBillParaKey.AddUpSecCode.Trim(),
                                                            frePBillParaKey.ClaimCode,
                                                            frePBillParaKey.ResultsSectCd.Trim(),
                                                            frePBillParaKey.CustomerCode);

                        // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                        //if ( _dmdRangeEachClaimDic.ContainsKey( claimkey ) )
                        //{
                        //    totalDay = _dmdRangeEachClaimDic[claimkey].DmdRangeEd;
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        string claimKeyString = claimkey.CreateKey();
                        if ( _dmdRangeEachClaimDic.ContainsKey( claimKeyString ) )
                        {
                            totalDay = _dmdRangeEachClaimDic[claimKeyString].DmdRangeEd;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                        # endregion

                        // 親/子レコード用のKEY
                        FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey(
                                                                        frePBillParaKey.AddUpSecCode.Trim(),
                                                                        frePBillParaKey.ClaimCode,
                                                                        frePBillParaKey.ResultsSectCd.Trim(),
                                                                        frePBillParaKey.CustomerCode,
                                                                        totalDay );
                        // ディクショナリに追加
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                        //if ( !frePBillDetailWorkList.ContainsKey( key ) )
                        //{
                        //    frePBillDetailWorkList.Add( key, new List<FrePBillDetailWork>() );
                        //}
                        //frePBillDetailWorkList[key].Add( frePBillDetailWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        string keyString = key.CreateKey();
                        if ( !frePBillDetailWorkList.ContainsKey( keyString ) )
                        {
                            frePBillDetailWorkList.Add( keyString, new List<FrePBillDetailWork>() );
                        }
                        frePBillDetailWorkList[keyString].Add( frePBillDetailWork );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                        # endregion
                    }

                    if ( frePBillDetailWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retObj = frePBillDetailWorkList;
                }
                catch ( Exception ex )
                {
                    base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    if ( myReader != null )
                    {
                        if ( !myReader.IsClosed )
                            myReader.Close();
                    }
                }
            }

            return status;
        }

        /////// <summary>
        /////// 請求書キー生成（入金明細より）
        /////// </summary>
        /////// <param name="frePBillDetailWork"></param>
        /////// <returns></returns>
        ////private FrePBillParaWork.FrePBillParaKey CreateBillKeyFromDeposit( FrePBillDetailWork frePBillDetailWork, bool isParent )
        ////{
        ////    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/17 DEL
        ////    //return new FrePBillParaWork.FrePBillParaKey( frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF,
        ////    //                                                frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF,
        ////    //                                                frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF,
        ////    //                                                frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF );
        ////    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/17 DEL
        ////    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/17 ADD
        ////    // 親(集計)レコードの場合は得意先コード＝ゼロで扱う
        ////    if ( isParent )
        ////    {
        ////        frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF = 0;
        ////    }

        ////    // 返却キー生成
        ////    FrePBillParaWork.FrePBillParaKey retKey = new FrePBillParaWork.FrePBillParaKey();
        ////    retKey.AddUpSecCode = frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
        ////    retKey.ClaimCode = frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF;
        ////    retKey.CustomerCode = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;

        ////    // 締範囲キー生成
        ////    DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
        ////                                     frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF,
        ////                                     frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF,
        ////                                     frePBillDetailWork.DEPSITMAINRF_INPUTDEPOSITSECCDRF,
        ////                                     frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF );

        ////    // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
        ////    if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
        ////    {
        ////        retKey.SetAddUpDateLongDate( _dmdRangeEachClaimDic[key].DmdRangeEd );
        ////    }
        ////    else
        ////    {
        ////        retKey.SetAddUpDateLongDate( frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF );
        ////    }

        ////    return retKey;

        ////    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/17 ADD
        ////}
        ///// <summary>
        ///// 請求書キー生成
        ///// </summary>
        ///// <param name="frePBillDetailWork"></param>
        ///// <returns></returns>
        //private List<FrePBillParaWork.FrePBillParaKey> CreateBillKeyFromDeposit( FrePBillDetailWork frePBillDetailWork )
        //{
        //    List<FrePBillParaWork.FrePBillParaKey> retKeyList = new List<FrePBillParaWork.FrePBillParaKey>();

        //    if ( _parentCustomerDic.ContainsKey( frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF ) )
        //    {
        //        foreach ( DmdSummaryKey sumKey in _parentCustomerDic[frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF] )
        //        {
        //            int totalDay = frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF;

        //            # region [計上日差し替え]
        //            // 締範囲キー生成
        //            DmdRangeEachClaimKey claimkey = new DmdRangeEachClaimKey(
        //                                                sumKey.AddUpSecCode.Trim(),
        //                                                sumKey.ClaimCode,
        //                                                frePBillDetailWork.DEPSITMAINRF_INPUTDEPOSITSECCDRF.Trim(),
        //                                                frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF );

        //            // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
        //            if ( _dmdRangeEachClaimDic.ContainsKey( claimkey ) )
        //            {
        //                totalDay = _dmdRangeEachClaimDic[claimkey].DmdRangeEd;
        //            }
        //            # endregion

        //            // 親/子レコード用のKEY
        //            FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey( 
        //                                                            sumKey.AddUpSecCode.Trim(), 
        //                                                            sumKey.ClaimCode,
        //                                                            frePBillDetailWork.DEPSITMAINRF_INPUTDEPOSITSECCDRF.Trim(), 
        //                                                            frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF, 
        //                                                            totalDay );
        //            if ( !retKeyList.Contains( key ) ) retKeyList.Add( key );

        //            # region [計上日差し替え]
        //            // 締範囲キー生成
        //            claimkey = new DmdRangeEachClaimKey(
        //                        sumKey.AddUpSecCode.Trim(),
        //                        sumKey.ClaimCode,
        //                        "00",
        //                        0 );

        //            // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
        //            if ( _dmdRangeEachClaimDic.ContainsKey( claimkey ) )
        //            {
        //                totalDay = _dmdRangeEachClaimDic[claimkey].DmdRangeEd;
        //            }
        //            # endregion

        //            // 集計レコード用のKEY
        //            key = new FrePBillParaWork.FrePBillParaKey( sumKey.AddUpSecCode.Trim(), sumKey.ClaimCode, "00", 0, totalDay );
        //            if ( !retKeyList.Contains( key ) ) retKeyList.Add( key );
        //        }
        //    }

        //    return retKeyList;
        //}

        /// <summary>
        /// SELECT項目 取得処理（入金明細）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string GetSelectItemsForDeposit( FrePBillParaWork extPrm )
        {
            //---------------------------------------------------------------------------------
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            //       最後の項目は後ろにカンマ(,)を付けない。
            //---------------------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();

            # region [項目名]
            sb.Append( "DEPSITMAINRF.ACPTANODRSTATUSRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DEPOSITSLIPNORF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.SALESSLIPNUMRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.ADDUPSECCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.SUBSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DEPOSITDATERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.ADDUPADATERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.FEEDEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DISCOUNTDEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.AUTODEPOSITCDRF, " + Environment.NewLine );
            //sb.Append( "DEPSITMAINRF.DEPOSITCDRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTDRAWINGDATERF, " + Environment.NewLine );
            //sb.Append( "DEPSITMAINRF.DRAFTPAYTIMELIMITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTKINDRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTDIVIDENAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTNORF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.CUSTOMERCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.CLAIMCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.OUTLINERF, " + Environment.NewLine );
            sb.Append( "SUBDEP.SUBSECTIONNAMERF AS SUBDEPSUBSECTIONNAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.DEPOSITSLIPNORF AS DEPSITDTLRFDEPOSITSLIPNORF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.DEPOSITROWNORF AS DEPSITDTLRFDEPOSITROWNORF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.MONEYKINDCODERF AS DEPSITDTLRFMONEYKINDCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.MONEYKINDNAMERF AS DEPSITDTLRFMONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.MONEYKINDDIVRF AS DEPSITDTLRFMONEYKINDDIVRF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.DEPOSITRF AS DEPSITDTLRFDEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.VALIDITYTERMRF AS DEPSITDTLRFVALIDITYTERMRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.INPUTDEPOSITSECCDRF " + Environment.NewLine );  // ←最後の項目はカンマなし
            # endregion

            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理（入金明細）
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="paraKey"></param>
        /// <param name="_childCustomerDic"></param>
        /// <param name="_dmdRangeEachClaimDic"></param>
        /// <param name="_sumCustChildDic"></param>
        /// <returns>WHERE文</returns>
        //private string MakeWhereStringForDeposit( ref SqlCommand sqlCommand, FrePBillParaWork extPrm, FrePBillParaWork.FrePBillParaKey paraKey )// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private string MakeWhereStringForDeposit(ref SqlCommand sqlCommand, FrePBillParaWork extPrm, FrePBillParaWork.FrePBillParaKey paraKey, Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic) // ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更         
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append( " WHERE DEPSITMAINRF.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
            # region // DEL
            //whereString.Append( " AND ( " );
            //for ( int index = 0; index < extPrm.FrePBillParaKeyList.Count; index++ )
            //{
            //    if ( index > 0 )
            //    {
            //        whereString.Append( " OR " );
            //    }

            //    //DEPSITMAINRF
            //    //  ADDUPSECCODERF
            //    //  CLAIMCODERF
            //    //  CUSTOMERCODERF
            //    //  ADDUPADATERF

            //    // WHERE
            //    //whereString.Append( string.Format( "(DEPSITMAINRF.ADDUPSECCODERF=@FINDADDUPSECCODERF{0} AND DEPSITMAINRF.CLAIMCODERF=@FINDCLAIMCODE{0} AND DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} AND DEPSITMAINRF.ADDUPADATERF=@FINDADDUPADATE{0})", index ) );
            //    whereString.Append( "(" );

            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            //    //// 計上拠点コード
            //    //whereString.Append( string.Format( "DEPSITMAINRF.ADDUPSECCODERF=@FINDADDUPSECCODERF{0} ", index ) );
            //    //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPSECCODERF{0}", index ), SqlDbType.NChar );
            //    //paraAddUpSecCode.Value = extPrm.FrePBillParaKeyList[index].AddUpSecCode;

            //    //// 請求先コード
            //    //whereString.Append( string.Format( "AND DEPSITMAINRF.CLAIMCODERF=@FINDCLAIMCODE{0} ", index ) );
            //    //SqlParameter paraClaimCode = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODE{0}", index ), SqlDbType.Int );
            //    //paraClaimCode.Value = extPrm.FrePBillParaKeyList[index].ClaimCode;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL

            //    // 得意先コード
            //    if ( extPrm.FrePBillParaKeyList[index].CustomerCode != 0 )
            //    {
            //        whereString.Append( string.Format( "DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", index ) );
            //        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
            //        paraCustomerCode.Value = extPrm.FrePBillParaKeyList[index].CustomerCode;
            //    }

            //    // 計上年月日
            //    //whereString.Append( string.Format( "AND DEPSITMAINRF.ADDUPADATERF=@FINDADDUPADATE{0} ", index ) );
            //    //SqlParameter paraAddUpDate = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATE{0}", index ), SqlDbType.Int );
            //    //paraAddUpDate.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();

            //    // 伝票発行時と集計時で異なる可能性があるのでWHERE句にはAddUpSecCode,ClaimCodeを含めないが、
            //    // 抽出範囲の取得ではKEYとして指定する。
            //    DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
            //                                        extPrm.FrePBillParaKeyList[index].AddUpSecCode.Trim(),
            //                                        extPrm.FrePBillParaKeyList[index].ClaimCode,
            //                                        extPrm.FrePBillParaKeyList[index].ResultsSectCd.Trim(),
            //                                        extPrm.FrePBillParaKeyList[index].CustomerCode );

            //    DmdRangeEachClaim dmdRangeEachClaim;
            //    if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
            //    {
            //        dmdRangeEachClaim = _dmdRangeEachClaimDic[key];
            //    }
            //    else
            //    {
            //        dmdRangeEachClaim = new DmdRangeEachClaim( 0, extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate() );
            //    }

            //    whereString.Append( string.Format( "AND DEPSITMAINRF.ADDUPADATERF>=@FINDADDUPADATEST{0} AND DEPSITMAINRF.ADDUPADATERF<=@FINDADDUPADATEED{0} ", index ) );
            //    SqlParameter paraAddUpDateSt = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEST{0}", index ), SqlDbType.Int );
            //    paraAddUpDateSt.Value = dmdRangeEachClaim.DmdRangeSt;
            //    SqlParameter paraAddUpDateEd = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEED{0}", index ), SqlDbType.Int );
            //    paraAddUpDateEd.Value = dmdRangeEachClaim.DmdRangeEd;


            //    whereString.Append( ")" );
            //    whereString.Append( Environment.NewLine );
            //}
            //whereString.Append( " ) " + Environment.NewLine );
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD

            whereString.Append( " AND " );

            // --- ADD m.suzuki 2010/02/15 ---------->>>>>
            if ( !extPrm.UseSumCust )
            {
                //--------------------------------------------------
                // 請求書
                //--------------------------------------------------
            // --- ADD m.suzuki 2010/02/15 ----------<<<<<

                // del 2012/07/02 >>>
                //// 得意先コード
                //if ( paraKey.CustomerCode != 0 )
                //{
                //    // 集計レコード以外はそのまま指定(１コードのみ)
                //    whereString.Append( string.Format( "DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                //    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                //    paraCustomerCode.Value = paraKey.CustomerCode;
                //}
                //else
                //{
                    //// 集計レコードの場合は属する得意先コードを全て指定(複数コード)
                    //if ( _childCustomerDic.ContainsKey( paraKey.ClaimCode ) )
                    //{
                    //    whereString.Append( " ( " );
                    //    int index = 0;

                    //    foreach ( int customerCode in _childCustomerDic[paraKey.ClaimCode] )
                    //    {
                    //        if ( index > 0 )
                    //        {
                    //            whereString.Append( " OR " );
                    //        }
                    //        whereString.Append( string.Format( "DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", index ) );
                    //        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                    //        paraCustomerCode.Value = customerCode;
                    //        index++;
                    //    }

                    //    whereString.Append( " ) " );
                    //}
                    //else
                    //{
                        //// 集計レコード以外はそのまま指定(１コードのみ)
                        // del 2012/07/02 <<<
                        whereString.Append( string.Format( "DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                        paraCustomerCode.Value = paraKey.ClaimCode;
                    // del 2012/07/02 >>>
                    //}
                //}
				// del 2012/07/02 <<<
            }
            // --- ADD m.suzuki 2010/02/15 ---------->>>>>
            else
            {
                //--------------------------------------------------
                // 請求書(総括)
                //--------------------------------------------------

                // 得意先コード

                whereString.Append( " ( " );

                int index = 0;
                bool cndtnAdded = false;
                // 総括親(総括得意先)→全ての総括子(請求先)
                foreach ( KeyValuePair<string, int> pair in _sumCustChildDic[paraKey.ClaimCode] )
                {
                    int index2 = 0;
                    int claimCode = pair.Value;

                    // 総括子(請求先)→全ての子得意先(得意先)
                    foreach ( int customerCode in _childCustomerDic[claimCode] )
                    {
                        if ( cndtnAdded )
                        {
                            whereString.Append( " OR " );
                        }
                        whereString.Append( string.Format( "DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0}_{1} ", index, index2 ) );
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}_{1}", index, index2 ), SqlDbType.Int );
                        paraCustomerCode.Value = customerCode;

                        index2++;
                        cndtnAdded = true;
                    }
                    index++;
                }

                whereString.Append( " ) " );
            }
            // --- ADD m.suzuki 2010/02/15 ----------<<<<<

            // 計上年月日
            // 伝票発行時と集計時で異なる可能性があるのでWHERE句にはAddUpSecCode,ClaimCodeを含めないが、
            // 抽出範囲の取得ではKEYとして指定する。
            DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                paraKey.AddUpSecCode.Trim(),
                                                paraKey.ClaimCode,
                                                paraKey.ResultsSectCd.Trim(),
                                                paraKey.CustomerCode );

            DmdRangeEachClaim dmdRangeEachClaim;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            //if ( _dmdRangeEachClaimDic.ContainsKey( key ) )
            //{
            //    dmdRangeEachClaim = _dmdRangeEachClaimDic[key];
            //}
            //else
            //{
            //    dmdRangeEachClaim = new DmdRangeEachClaim( 0, paraKey.GetAddUpDateLongDate() );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            string keyString = key.CreateKey();
            if ( _dmdRangeEachClaimDic.ContainsKey( keyString ) )
            {
                dmdRangeEachClaim = _dmdRangeEachClaimDic[keyString];
            }
            else
            {
                dmdRangeEachClaim = new DmdRangeEachClaim( 0, paraKey.GetAddUpDateLongDate() );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            whereString.Append( string.Format( "AND DEPSITMAINRF.ADDUPADATERF>=@FINDADDUPADATEST{0} AND DEPSITMAINRF.ADDUPADATERF<=@FINDADDUPADATEED{0} ", 0) );
            SqlParameter paraAddUpDateSt = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEST{0}", 0 ), SqlDbType.Int );
            paraAddUpDateSt.Value = dmdRangeEachClaim.DmdRangeSt;
            SqlParameter paraAddUpDateEd = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEED{0}", 0 ), SqlDbType.Int );
            paraAddUpDateEd.Value = dmdRangeEachClaim.DmdRangeEd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
            // 論理削除分は除外
            //LOGICALDELETECODERF='0'
            whereString.Append( " AND DEPSITMAINRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine );
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            paraLogicalDeleteCode.Value = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

            return whereString.ToString();
        }
        # endregion

        # region [自動生成系処理]
        /// <summary>
        /// LeftJoin生成処理
        /// </summary>
        /// <param name="leftTable">左テーブル</param>
        /// <param name="rightTable">右テーブル</param>
        /// <param name="rightAs"></param>
        /// <param name="items">一致条件項目リスト</param>
        /// <param name="andMore">追加条件リスト</param>
        /// <returns>LEFT JOIN 文</returns>
        private string LeftJoin( string leftTable, string rightTable, string rightAs, string[] items, string[] andMore )
        {
            StringBuilder sb = new StringBuilder();

            // LEFT JOIN
            if ( rightAs == string.Empty )
            {
                sb.Append( string.Format( "  LEFT JOIN {0} ON ", rightTable ) );
                rightAs = rightTable;
            }
            else
            {
                sb.Append( string.Format( "  LEFT JOIN {0} AS {1} ON ", rightTable, rightAs ) );
            }

            // 企業コードは必須
            sb.Append( string.Format( "{0}.{2}={1}.{2} ", leftTable, rightAs, "ENTERPRISECODERF" ) );

            // その他Joinの条件
            for ( int index = 0; index < items.Length; index++ )
            {
                sb.Append( string.Format( "AND {0}.{2}={1}.{2} ", leftTable, rightAs, items[index] ) );
            }
            // 追加条件
            for ( int index = 0; index < andMore.Length; index++ )
            {
                sb.Append( string.Format( "AND {0} ", andMore[index] ) );
            }

            // 改行
            sb.Append( Environment.NewLine );

            return sb.ToString();
        }
        # endregion

        // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
        # region [請求書ログ出力]
        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="requestLogDataList">請求書ログデータ</param>
        /// <param name="requestMessage">請求書メッセージ</param>
        /// <param name="logExceptionMsg"></param>
        /// <returns></returns>
        //private void LogWrite(List<RequestLogData> requestLogDataList, Dictionary<string, object> requestMessage)// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        private void LogWrite(List<RequestLogData> requestLogDataList, Dictionary<string, object> requestMessage, ref string logExceptionMsg)// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
        {
            try
            {
                FileStream _fs;										// ファイルストリーム
                StreamWriter _sw;                                     // ストリームwriter

                //ファールのパスを取得する(regedit表から)
                string registData;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey broadleaf = software.OpenSubKey("BroadLeaf", true);
                RegistryKey service = broadleaf.OpenSubKey("Service", true);
                RegistryKey partsMan = service.OpenSubKey("Partsman", true);
                RegistryKey userAP =partsMan.OpenSubKey("USER_AP",true);
                registData = userAP.GetValue("InstallDirectory").ToString();


                //フォーだあるのかの判断
                string folderPath = registData + "\\LOG\\";
                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    DirectoryInfo dis = di.CreateSubdirectory("PMKAU08004R\\");
                }
                else
                {

                    if (!Directory.Exists(folderPath + "PMKAU08004R\\"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath + "PMKAU08004R\\");
                    }
                }

                DateTime edt = DateTime.Now;
                //ファイルを作成する
                _fs = new FileStream(registData + "\\LOG\\" + "PMKAU08004R\\" + "PMKAU08004R_" + edt.ToString("yyyyMMdd") + ".Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

                //ファイルにログを書くことがあるのかの判断
                FileInfo fi = new FileInfo(@_fs.Name);  
                if(fi.Length == 0)
                {
                    // updt 2012/06/04 >>>
                    //_sw.WriteLine("\"LOGﾌｧｲﾙ得意先CD\"," + "\"前回請求処理日\"," + "\"今回金額\"," + "\"明細合計金額\"," + "\"差額\"," + "\"メッセージ\"," + "\"出力値\"");
                    _sw.WriteLine("\"LOGﾌｧｲﾙ得意先CD\"," + "\"前回請求処理日\"," + "\"今回金額\"," + "\"明細合計金額\"," + "\"売上差額\"," + "\"今回入金額\"," + "\"明細合計金額（入金）\"," + "\"入金差額\"," + "\"メッセージ\"," + "\"出力値\"");
                    // updt 2012/06/04 <<<
                }

                //請求書メッセージのソート requestMessage --> requestSortedMessage
                string str1 = "売上ヘッダ取得クエリ";
                string str2 = "売上明細取得クエリ";
                string str3 = "入金明細取得クエリ";
                string str4 = "前回締日取得クエリ";
                string str5 = "締め範囲取得前開始日付";
                string str6 = "前回締日＋１";
                Dictionary<string, object> requestSortedMessage = new Dictionary<string, object>();
                if (requestMessage.ContainsKey(str1))
                {
                    requestSortedMessage.Add(str1, requestMessage[str1]);
                }
                if (requestMessage.ContainsKey(str2))
                {
                    requestSortedMessage.Add(str2, requestMessage[str2]);
                }
                if (requestMessage.ContainsKey(str3))
                {
                    requestSortedMessage.Add(str3, requestMessage[str3]);
                }
                if (requestMessage.ContainsKey(str4))
                {
                    requestSortedMessage.Add(str4, requestMessage[str4]);
                }
                if (requestMessage.ContainsKey(str5)) 
                {
                    requestSortedMessage.Add(str5, requestMessage[str5]);
                }
                if (requestMessage.ContainsKey(str6)) 
                {
                    requestSortedMessage.Add(str6, requestMessage[str6]);
                }

                //請求書メッセージをログファイルに書きます
                foreach(RequestLogData reld in requestLogDataList )
                {
                    foreach (KeyValuePair<string, object> item in requestSortedMessage)
                    {
                        _sw.WriteLine("\"" + reld.CustomerCode + "\",\"" + TDateTime.DateTimeToString("YYYY/MM/DD", reld.AddupDate) 
                                        + "\",\"" + reld.ThisTimeSalesPrice + "\",\"" + reld.TotalPrice + "\",\"" + reld.DifferentPrice 
                                        // add 2012/06/04 >>>
                                        + "\",\"" + reld.ThisTimeDemandPrice + "\",\"" + reld.TotalDemandPrice + "\",\"" + reld.DifferentDemandPrice
                                        // add 2012/06/04 <<<
                                        + "\",\"" + item.Key + "\",\"" + item.Value + "\"");
                        _sw.WriteLine(string.Empty);
                    }

                }
               

                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
                
            }
            catch (Exception ex)
            {
                //this.logExceptionMsg = ex.Message;// DEL yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
                logExceptionMsg = ex.Message;// ADD yangmj 2012/07/11 リモーティングクラスにてプライベート変数の使用の変更
            }
        }
        #endregion
        // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
        #endregion

        # region [請求先別締範囲キー　構造体]
        /// <summary>
        /// 請求先別締範囲キー　構造体
        /// </summary>
        private struct DmdRangeEachClaimKey
        {
            /// <summary>計上拠点コード</summary>
            private string _addUpSecCode;
            /// <summary>請求先コード</summary>
            private int _claimCode;
            /// <summary>実績拠点コード</summary>
            private string _resultsSectCd;
            /// <summary>得意先コード</summary>
            private int _customerCode;
            /// <summary>
            /// 計上拠点コード
            /// </summary>
            public string AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }
            /// <summary>
            /// 請求先コード
            /// </summary>
            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            /// <summary>
            /// 実績拠点コード
            /// </summary>
            public string ResultsSectCd
            {
                get { return _resultsSectCd; }
                set { _resultsSectCd = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="addUpSecCode">計上拠点コード</param>
            /// <param name="claimCode">請求先コード</param>
            /// <param name="resultsSectCd">実績拠点コード</param>
            /// <param name="customerCode">得意先コード</param>
            public DmdRangeEachClaimKey(string addUpSecCode , int claimCode, string resultsSectCd, int customerCode )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
                _resultsSectCd = resultsSectCd;
                _customerCode = customerCode;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            /// <summary>
            /// KEY文字列生成(Dictionary格納時の高速化を図る為)
            /// </summary>
            /// <returns></returns>
            public string CreateKey()
            {
                return string.Format( "{0}-{1:D8}-{2}-{3:D8}", _addUpSecCode, _claimCode, _resultsSectCd, _customerCode );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        }
        # endregion

        # region [請求先別締範囲　構造体]
        /// <summary>
        /// 請求先別締範囲　構造体
        /// </summary>
        private struct DmdRangeEachClaim
        {
            /// <summary>締開始日</summary>
            private int _dmdRangeSt;
            /// <summary>締終了日</summary>
            private int _dmdRangeEd;
            /// <summary>
            /// 締開始日
            /// </summary>
            public int DmdRangeSt
            {
                get { return _dmdRangeSt; }
                set { _dmdRangeSt = value; }
            }
            /// <summary>
            /// 締終了日
            /// </summary>
            public int DmdRangeEd
            {
                get { return _dmdRangeEd; }
                set { _dmdRangeEd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="dmdRangeSt">締開始日</param>
            /// <param name="dmdRangeEd">締終了日</param>
            public DmdRangeEachClaim( int dmdRangeSt, int dmdRangeEd )
            {
                _dmdRangeSt = dmdRangeSt;
                _dmdRangeEd = dmdRangeEd;
            }
        }
        # endregion

        # region [請求集計キー]
        /// <summary>
        /// 請求集計キー
        /// </summary>
        private struct DmdSummaryKey
        {
            /// <summary>計上拠点コード</summary>
            private string _addUpSecCode;
            /// <summary>請求先コード</summary>
            private int _claimCode;
            /// <summary>
            /// 計上拠点コード
            /// </summary>
            /// <remarks>拠点</remarks>
            public string AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }
            /// <summary>
            /// 請求先コード
            /// </summary>
            /// <remarks>得意先</remarks>
            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="addUpSecCode">計上拠点コード</param>
            /// <param name="claimCode">請求先コード</param>
            public DmdSummaryKey( string addUpSecCode, int claimCode )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            /// <summary>
            /// KEY文字列生成(Dictionary格納時の高速化を図る為)
            /// </summary>
            /// <returns></returns>
            public string CreateKey()
            {
                return string.Format( "{0}-{1:D8}", _addUpSecCode, _claimCode);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        }
        # endregion

        // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
        #region 請求書ログ出力データのクラス
        internal class RequestLogData
        {
            # region ■ private field ■
            /// <summary>LOGﾌｧｲﾙ得意先CD</summary>
            private int customerCode;
            /// <summary>前回請求処理日</summary>
            private DateTime addupDate;
            /// <summary>今回金額</summary>
            private long thisTimeSalesPrice;
            /// <summary>明細合計金額</summary>
            private long totalPrice;
            /// <summary>差額</summary>
            private long differentPrice;
            // add 2012/06/04 >>>
            /// <summary>今回入金額</summary>
            private long thisTimeDemandPrice;
            /// <summary>明細合計金額（入金</summary>
            private long totalDemandPrice;
            /// <summary>入金差額</summary>
            private long differentDemandPrice;
            // add 2012/06/04 <<<

            # endregion ■ private field ■

            # region ■ public propaty ■

            /// public propaty name  :  CustomerCode
            /// <summary>LOGﾌｧｲﾙ得意先CDプロパティ</summary>
            public int CustomerCode
            {
                get { return customerCode; }
                set { customerCode = value; }
            }

            /// public propaty name  :  AddupDate
            /// <summary>前回請求処理日プロパティ</summary>
            public DateTime AddupDate
            {
                get { return addupDate; }
                set { addupDate = value; }
            }

            /// public propaty name  :  ThisTimeSalesPrice
            /// <summary>今回金額プロパティ</summary>
            public long ThisTimeSalesPrice
            {
                get { return thisTimeSalesPrice; }
                set { thisTimeSalesPrice = value; }
            }

            /// public propaty name  :  TotalPrice
            /// <summary>明細合計金額プロパティ</summary>
            public long TotalPrice
            {
                get { return totalPrice; }
                set { totalPrice = value; }
            }

            /// public propaty name  :  DifferentPrice
            /// <summary>差額プロパティ</summary>
            public long DifferentPrice
            {
                get { return differentPrice; }
                set { differentPrice = value; }
            }

            // add 2012/06/04 >>>
            /// public propaty name  :  ThisTimeDemandPrice
            /// <summary>今回入金額プロパティ</summary>
            public long ThisTimeDemandPrice
            {
                get { return thisTimeDemandPrice; }
                set { thisTimeDemandPrice = value; }
            }

            /// public propaty name  :  TotalDemandPrice
            /// <summary>明細合計金額（入金）プロパティ</summary>
            public long TotalDemandPrice
            {
                get { return totalDemandPrice; }
                set { totalDemandPrice = value; }
            }

            /// public propaty name  :  DifferentDemandPrice
            /// <summary>入金差額プロパティ</summary>
            public long DifferentDemandPrice
            {
                get { return differentDemandPrice; }
                set { differentDemandPrice = value; }
            }
            // add 2012/06/04 <<<

            # endregion ■ public propaty ■

            # region ■ Constructor ■
            /// <summary>
            /// 請求書出力データのクラス
            /// </summary>
            /// <returns>RequestInfoクラスのインスタンス</returns>
            public RequestLogData()
            {
            }
            # endregion ■ Constructor ■
        }
        #endregion
        // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
    }
}