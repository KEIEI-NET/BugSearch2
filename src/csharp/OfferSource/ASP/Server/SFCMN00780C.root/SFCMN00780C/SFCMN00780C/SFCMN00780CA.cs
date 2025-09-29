using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Library.Data.SqlClient
{
    /// <summary>
    /// 変更PG案内　SQL接続情報取得部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : 変更PG案内　SQL接続情報取得部品</br>
    /// <br>Programmer : 23002　上野　耕平</br>
    /// <br>Date       : 2007.03.02</br>
    /// <br></br>
    /// <br>Update Note: 2007.11.26 （冗長化構成用）</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.19  21024　佐々木 健</br>
    /// <br>           : PM用に変更</br>
    /// <br>Update Note: 2009.08.18  21024　佐々木 健</br>
    /// <br>           : 冗長化構成対応</br>
    /// </remarks>
    public class ChangePgGuideSqlInfo
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChangePgGuideSqlInfo()
        {
        }
        #endregion

        #region パブリックメソッド
        /// <summary>
        /// 変更PG案内用　SQLコネクション取得
        /// </summary>
        /// <returns></returns>
        public string GetConnectionText()
        {
            return GetConnectionTextProc();
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// 変更PG案内用　SQLコネクション取得（実行部）
        /// </summary>
        /// <returns></returns>
        private string GetConnectionTextProc()
        {
            //開発用
            //return "packet size=4096; User id=sfuser; Pwd=sfuser001; data source=10.20.150.155; persist security info=False; initial catalog=SF_NET_MCAS_DB";
            //本番用
            //return "packet size=4096; User id=mcasuser; Pwd=mcasuser001; data source=Fragonard\\SF_NET_CNV_DB; persist security info=False; initial catalog=SF_NET_MCAS_DB";

            // 2008.11.19 Update >>>
            ////2007.11.19 ADD UENO 本番用（冗長化構成用）
            //string dbName = GetDBName();
            //return "packet size=4096; User id=mcasuser; Pwd=mcasuser001; data source=" + dbName + "; persist security info=False; initial catalog=SF_NET_MCAS_DB";

            string dbName = GetDBName();
            
            //return "packet size=4096; User id=pmuser; Pwd=pmuser001; data source=" + dbName + "; persist security info=False; initial catalog=PM_NET_MCAS_DB";

            // 2009.08.18 >>>
            //return "packet size=4096; User id=pmmcasuser; Pwd=pmmcasuser001; data source=pmtestdb01; persist security info=False; initial catalog=PM_NET_MCAS_DB";

            // 開発環境用（ツール用）
            //return "packet size=4096; User id=pmmcasuser; Pwd=pmmcasuser001; data source=10.30.20.228; persist security info=False; initial catalog=PM_NET_MCAS_DB";

            // 営業デモ用（ツール用）
            //return "packet size=4096; User id=pmmcasuser; Pwd=pmmcasuser001; data source=pmtestdb01; persist security info=False; initial catalog=PM_NET_MCAS_DB";

            // 本番サーバー(ツール用)
            //return "packet size=4096; User id=pmmcasuser; Pwd=pmmcasuser001; data source=VT-PM-DB01; persist security info=False; initial catalog=PM_NET_MCAS_DB";

            // 本番サーバー用
            return "packet size=4096; User id=pmmcasuser; Pwd=pmmcasuser001; data source=" + dbName + "; persist security info=False; initial catalog=PM_NET_MCAS_DB";
            // 2009.08.18 <<<

            // 開発用

            //return "packet size=4096; User id=pmuser; Pwd=pmuser001; data source=10.30.20.228; persist security info=False; initial catalog=PM_NET_MCAS_DB";

            // 2008.11.19 Update <<<
        }

        /// <summary>
        /// 認証WebサービスURL取得処理
        /// </summary>
        /// <returns></returns>
        private string GetDBName()
        {
            string result = "";
            try
            {
                result = System.Web.Configuration.WebConfigurationManager.AppSettings["DBName"];
            }
            catch( Exception ex )
            {
                // 2009.08.18 >>>
                //result = "VT-SF-DPL-DB01";

                // 本番用
                result = "VT-PM-DB01";
                // 2009.08.18 <<<
            }
            return result;
        }
        #endregion
    }
}
