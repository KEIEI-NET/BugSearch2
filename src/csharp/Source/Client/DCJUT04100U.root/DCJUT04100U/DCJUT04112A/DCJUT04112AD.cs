// 使用:  MAHNB06016D, DCHNB09053G, DCHNB09055O, DCKHN01070C 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上端数処理クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上端数処理算定を行います。</br>
    /// <br>             このクラスとDCKHN01070CのFractionCalculateクラスのみで</br>
    /// <br>             売上金額に対する端数処理が可能です。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.11.16</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.11.16 鈴木 正臣 新規作成</br>
    /// </remarks>
    internal class SalesFractionCalculate
    {
        // テーブル定義用
        /// <summary>テーブル名　売上端数処理テーブル</summary>
        private const string ct_Tbl_SalesProcMoneyTable = "SalesProcMoneyTable";
        /// <summary>端数処理対象区分</summary>
        private const string ct_Col_FracProcMoneyDiv = "FracProcMoneyDiv";
        /// <summary>端数処理コード</summary>
        private const string ct_Col_FractionProcCode = "FractionProcCode";
        /// <summary>上限金額</summary>
        private const string ct_Col_UpperLimitPrice = "UpperLimitPrice";
        /// <summary>端数処理単位</summary>
        private const string ct_Col_FractionProcUnit = "FractionProcUnit";
        /// <summary>端数処理区分</summary>
        private const string ct_Col_FractionProcCd = "FractionProcCd";

        // 端数処理対象金額区分定義
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        private const int ctFracProcMoneyDiv_SalesPrice = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        private const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        private const int ctFracProcMoneyDiv_SalesUnitPrice = 2;

        // 自分自身のインスタンス
        static SalesFractionCalculate stc_salesFractionCalculate;

        // リモートオブジェクト
        private ISalesProcMoneyDB _iSalesProcMoneyDB;   // from DCHNB09055O.dll
        private DataTable _salesProcMoneyTable;

        /// <summary>
        /// プライベートコンストラクタ
        /// </summary>
        private SalesFractionCalculate ()
        {
            // リモートオブジェクト取得
            _iSalesProcMoneyDB = (ISalesProcMoneyDB)MediationSalesProcMoneyDB.GetSalesProcMoneyDB();

            // テーブル生成
            this._salesProcMoneyTable = CreateTable();
        }
        /// <summary>
        /// スタティックコンストラクタ
        /// </summary>
        static SalesFractionCalculate ()
        {
            stc_salesFractionCalculate = new SalesFractionCalculate();
        }
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        public static SalesFractionCalculate GetInstance ()
        {
            return stc_salesFractionCalculate;
        }
        /// <summary>
        /// 取得準備・初期検索処理
        /// </summary>
        public void SearchInitial ( string enterpriseCode )
        {
            _salesProcMoneyTable.Clear();

            object returnStockProcMoney;
            SalesProcMoneyWork paraSalesProcMoneyWork = new SalesProcMoneyWork();
            paraSalesProcMoneyWork.EnterpriseCode = enterpriseCode;
            paraSalesProcMoneyWork.FracProcMoneyDiv = -1;

            int status = this._iSalesProcMoneyDB.Search( out returnStockProcMoney, paraSalesProcMoneyWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0 );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( returnStockProcMoney is ArrayList )
                {
                    foreach ( SalesProcMoneyWork salesProcMoneyWork in (ArrayList)returnStockProcMoney )
                    {
                        _salesProcMoneyTable.Rows.Add( CopyToDataRowFromSalesProcMoneyWork( salesProcMoneyWork ) );
                    }
                }
            }
        }
        /// <summary>
        /// 売上金額端数処理
        /// </summary>
        /// <param name="targetPrice">端数処理対象金額 ( 単価×数量 ) </param>
        /// <param name="procCd">端数処理コード ( 得意先仕入情報マスタに登録されている端数処理コード ) </param>
        /// <returns>算出結果</returns>
        public double GetSalesPrice ( double targetPrice, int procCd )
        {
            double resultMoney;
            try
            {
                double fractionProcUnitPrice;
                int fractionProcCd;

                // 仕入金額端数処理レコード取得（端数処理単位と端数処理区分を取得）
                GetFractionProcInfo( ctFracProcMoneyDiv_SalesPrice, procCd, targetPrice, out fractionProcUnitPrice, out fractionProcCd );

                // 端数処理クラスメソッドに渡して算出
                FractionCalculate.FracCalcMoney( targetPrice, fractionProcUnitPrice, fractionProcCd, out resultMoney );
            }
            catch
            {
                resultMoney = targetPrice;
            }

            return resultMoney;
        }
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// 
        private void GetFractionProcInfo ( int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd )
        {
            //デフォルト
            switch ( fracProcMoneyDiv )
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            // 端数処理対象金額区分、端数処理コードが一致するデータを昇順に取得
            DataRow[] dr = this._salesProcMoneyTable.Select( string.Format( "{0} = '{1}' AND {2} = '{3}'",
                                                                                ct_Col_FracProcMoneyDiv, fracProcMoneyDiv,
                                                                                ct_Col_FractionProcCode, fractionProcCode ),
                                                             string.Format( "{0} DESC", ct_Col_UpperLimitPrice ) );

            foreach ( DataRow stockProcMoneyRow in dr )
            {
                if ( (double)stockProcMoneyRow[ct_Col_UpperLimitPrice] < targetPrice )
                {
                    break;
                }
                fractionProcUnit = (double)stockProcMoneyRow[ct_Col_FractionProcUnit];
                fractionProcCd = (int)stockProcMoneyRow[ct_Col_FractionProcCd];
            }
        }
        /// <summary>
        /// SalesProcMoneyWork→DataRow 移行処理
        /// </summary>
        /// <param name="salesProcMoneyWork"></param>
        private DataRow CopyToDataRowFromSalesProcMoneyWork ( SalesProcMoneyWork salesProcMoneyWork )
        {
            DataRow row = _salesProcMoneyTable.NewRow();

            row[ct_Col_FracProcMoneyDiv] = salesProcMoneyWork.FracProcMoneyDiv;
            row[ct_Col_FractionProcCode] = salesProcMoneyWork.FractionProcCode;
            row[ct_Col_UpperLimitPrice] = salesProcMoneyWork.UpperLimitPrice;
            row[ct_Col_FractionProcUnit] = salesProcMoneyWork.FractionProcUnit;
            row[ct_Col_FractionProcCd] = salesProcMoneyWork.FractionProcCd;

            return row;
        }
        /// <summary>
        /// 売上端数処理テーブル生成
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTable ()
        {
            DataTable table = new DataTable( ct_Tbl_SalesProcMoneyTable );

            table.Columns.Add( new DataColumn( ct_Col_FracProcMoneyDiv, typeof( Int32 ) ) );
            table.Columns.Add( new DataColumn( ct_Col_FractionProcCode, typeof( Int32 ) ) );
            table.Columns.Add( new DataColumn( ct_Col_UpperLimitPrice, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_FractionProcUnit, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_FractionProcCd, typeof( Int32 ) ) );

            return table;
        }
    }
}

