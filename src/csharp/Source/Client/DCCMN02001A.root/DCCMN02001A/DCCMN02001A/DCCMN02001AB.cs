using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 伝票タイプ制御クラス
    /// </summary>
    /// <remarks>
    /// Note       : 印刷に使用する伝票タイプ(伝票管理設定マスタ・レコード)を確定する為のクラスです。<br />
    ///              売上伝票入力などエントリ関連ＰＧからのみの使用とします。（伝票発行確認ＵＩからは未使用）
    /// Programmer : 22018 鈴木 正臣<br />                                   
    /// Date       : 2008.08.07<br />                                      
    /// <br />
    /// </remarks>
    public class SlipTypeController
    {
        # region [private const]
        // 拠点ゼロ
        private const string ct_SectionZero = "00";
        // 倉庫ゼロ
        private const string ct_WarehouseZero = "0000";
        // 得意先ゼロ
        private const int ct_CustomerZero = 0;
        // レジ番号ゼロ
        private const int ct_CashRegisterZero = 0;
        # endregion

        # region [public enum]
        /// <summary>
        /// 伝票タイプ 列挙型
        /// </summary>
        public enum SlipKind
        {
            /// <summary>見積書</summary>
            EstimateForm = 10,
            /// <summary>仕入返品伝票</summary>
            StockReturn = 40,
            /// <summary>売上伝票</summary>
            SalesSlip = 30,
            /// <summary>受注伝票</summary>
            AcceptSlip = 120,
            /// <summary>貸出伝票</summary>
            LoanSlip = 130,
            /// <summary>見積伝票</summary>
            EstimateSlip = 140,
            /// <summary>ＵＯＥ伝票</summary>
            UOESlip = 160,
            /// <summary>在庫移動伝票</summary>
            StockMoveSlip = 150,
        }
        # endregion

        # region [private フィールド]
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>取得元となる得意先マスタ（伝票管理）リスト</summary>
        private List<CustSlipMng> _custSlipMngList;
        /// <summary>取得元となる伝票印刷設定リスト</summary>
        private List<SlipPrtSet> _slipPrtSetList;
        # endregion

        # region [public プロパティ]
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 取得元となる得意先マスタ（伝票管理）リスト
        /// </summary>
        public List<CustSlipMng> CustSlipMngList
        {
            get 
            {
                if ( _custSlipMngList == null )
                {
                    _custSlipMngList = new List<CustSlipMng>();
                }
                return _custSlipMngList; 
            }
            set { _custSlipMngList = value; }
        }
        /// <summary>
        /// 取得元となる伝票印刷設定マスタリスト
        /// </summary>
        public List<SlipPrtSet> SlipPrtSetList
        {
            get 
            {
                if ( _slipPrtSetList == null )
                {
                    _slipPrtSetList = new List<SlipPrtSet>();
                }
                return _slipPrtSetList; 
            }
            set { _slipPrtSetList = value; }
        }
        # endregion

        # region [public メソッド]
        /// <summary>
        /// 伝票タイプ取得処理
        /// </summary>
        /// <param name="slipKind">伝票種別</param>
        /// <param name="retSlipPrtSet">(出力)伝票印刷設定マスタインスタンス</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS (0:正常,9:エラー)</returns>
        public int GetSlipType( SlipKind slipKind, out SlipPrtSet retSlipPrtSet, string sectionCode, int customerCode )
        {
            return GetSlipTypeProc(slipKind, out retSlipPrtSet, sectionCode, customerCode );
        }
        # endregion

        # region [private メソッド]
        /// <summary>
        /// 伝票タイプ取得処理
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="retSlipPrtSet"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns>STATUS</returns>
        private int GetSlipTypeProc( SlipKind slipKind, out SlipPrtSet retSlipPrtSet, string sectionCode, int customerCode )
        {
            retSlipPrtSet = new SlipPrtSet();

            //-------------------------------------------------------
            // 得意先マスタ伝票管理　取得
            //-------------------------------------------------------
            CustSlipMng custSlipMng = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( customerCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            {
                // 得意先毎[拠点=0]
                custSlipMng = FindCustSlipMng( this.EnterpriseCode, ct_SectionZero, customerCode, (int)slipKind );
                if ( custSlipMng == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので"0"も検索する
                    custSlipMng = FindCustSlipMng( this.EnterpriseCode, "0", customerCode, (int)slipKind );
                }
            }

            // 拠点毎[得意先=0]
            if ( custSlipMng == null )
            {
                custSlipMng = FindCustSlipMng( this.EnterpriseCode, sectionCode, ct_CustomerZero, (int)slipKind );
            }

            // 全社設定[拠点=0,得意先=0]
            if ( custSlipMng == null )
            {
                custSlipMng = FindCustSlipMng( this.EnterpriseCode, ct_SectionZero, ct_CustomerZero, (int)slipKind );
                if ( custSlipMng == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので"0"も検索する
                    custSlipMng = FindCustSlipMng( this.EnterpriseCode, "0", ct_CustomerZero, (int)slipKind );
                }
            }

            // 該当が無ければエラーSTATUSを返す。
            if ( custSlipMng == null )
            {
                return 9;
            }

            //-------------------------------------------------------
            // 伝票印刷設定マスタ 取得
            //-------------------------------------------------------
            retSlipPrtSet = FindSlipPrtSet( this.EnterpriseCode, custSlipMng.SlipPrtSetPaperId.TrimEnd(), (int)slipKind );

            // 該当が無ければエラーSTATUSを返す。
            if ( retSlipPrtSet == null )
            {
                return 9;
            }

            return 0;
        }
        /// <summary>
        /// 得意先マスタ伝票管理（伝票タイプ管理マスタ）Find処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <returns></returns>
        private CustSlipMng FindCustSlipMng( string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind )
        {
            if ( this.CustSlipMngList == null ) return null;

            return this.CustSlipMngList.Find(
                        delegate( CustSlipMng custSlipMng )
                        {
                            return (custSlipMng.EnterpriseCode.TrimEnd() == enterpriseCode)
                                    && ((custSlipMng.SectionCode.TrimEnd() == sectionCode) || (custSlipMng.SectionCode.TrimEnd() == string.Empty && sectionCode == ct_SectionZero))
                                    && (custSlipMng.CustomerCode == customerCode)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (custSlipMng.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (custSlipMng.SlipPrtKind == slipPrtKind);
                        } );
        }
        /// <summary>
        /// 伝票印刷設定マスタ Find処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <param name="slipPrtKind"></param>
        /// <returns></returns>
        private SlipPrtSet FindSlipPrtSet( string enterpriseCode, string slipPrtSetPaperId, int slipPrtKind )
        {
            if ( this.SlipPrtSetList == null ) return null;

            return this.SlipPrtSetList.Find(
                        delegate( SlipPrtSet slipPrtSet )
                        {
                            return (slipPrtSet.EnterpriseCode.TrimEnd() == enterpriseCode)
                                    && (slipPrtSet.SlipPrtSetPaperId.TrimEnd() == slipPrtSetPaperId)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (slipPrtSet.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (slipPrtSet.SlipPrtKind == slipPrtKind);
                        } );
        }


        # endregion
    }
}
