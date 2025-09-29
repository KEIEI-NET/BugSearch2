using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using Broadleaf.Application.Common;
using Broadleaf.Configuration;
using Broadleaf.Web.Common;
using Broadleaf.Application.Resources;  // ADD 2013.08.27 kubo @ 参照設定にSFCMN00615Cを追加

namespace Broadleaf.Web.UI
{
    /// <summary>
    /// タブレットPM標準価格選択ページ
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : LDNS</br>
    /// <br>Date        : 2013.06.03</br>
    /// <br>Note        : タブレットPM標準価格選択ページの内容を構築します。</br>
    /// <br>-------------------------------------------------</br>
    /// <br>UpdateDate : 2013.08.27</br>
    /// <br>           : 22013 kubo</br>
    /// <br>           : WebSyncのパスを認証部品から取得するように変更</br>
    /// </remarks>
    public partial class PMTAB04036W : System.Web.UI.Page
    {
        /// <summary>
        /// ログインユーザ権限
        /// </summary>
        public string employeeAuth;

        /// <summary>
        /// ログインURL
        /// </summary>
        public string loginUrl;

        /// <summary>
        /// ログアウトURL
        /// </summary>
        public string logoutUrl;

        /// <summary>
        /// 企業コード
        /// </summary>
        public string enterpriseCode;

        /// <summary>
        /// ウェブシックのパス
        /// </summary>
        public string websyncAp;

        /// <summary>
        /// ページロードイベント処理。
        /// </summary>
        /// <param name="sender">発生元オブジェクト。</param>
        /// <param name="e">イベントデータ。</param>
        /// <remarks>
        /// <br>Programmer  : LDNS</br>
        /// <br>Date        : 2013.06.03</br>
        /// <br>Note        : ページロードのイベント処理を行います。</br>
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AspLoginInfoAcquisition acquisition = new AspLoginInfoAcquisition();
                this.employeeAuth = acquisition.Employee.Name;
                NSHttpApplicationConfigSectionHandler section = WebConfigurationManager.GetSection("nsHttpAppSettings") as NSHttpApplicationConfigSectionHandler;
                this.loginUrl = section.LoginControl.LoginUrl;
                this.logoutUrl = section.LoginControl.LogoutUrl;
                this.enterpriseCode = acquisition.EnterpriseCode;

                // DEL 2013.08.27 kubo @ WebSync接続先取得方法変更
                //this.websyncAp = acquisition.GetAPServiceTargetDomain("WEBSYNC_AP");
                // ADD 2013.08.27 kubo @ WebSync接続先取得方法変更 *-------------------->>>
                this.websyncAp =
                    string.Format("{0}{1}",
                        acquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP),
                        acquisition.GetConnectionInfo(
                            ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP,
                            ConstantManagement_SF_PRO.IndexCode_WebSync_Client_WebPath)
                    );
                // ADD 2013.08.27 kubo @ WebSync接続先取得方法変更 <<<--------------------*

                new UrlQueryString(base.Request.QueryString);

                // テーマ制御用のCSSファイルのロード処理
                this.LoadThemeCss();
            }
            catch (ThreadAbortException)
            {
            }
            catch (MobileWebException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw new MobileWebException("PMTAB04036W", "Page_Load", "タブレットPM標準価格選択ページでエラーが発生しました。" + Environment.NewLine + exception2.Message, -1, exception2);
            }

        }

        /// <summary>
        /// テーマ制御用のCSSファイルのロード処理
        /// </summary>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer   :   LDNS</br>
        /// <br>Date         :   2013.06.03</br>
        /// <br>Note         :   テーマ制御用のCSSファイルの切替を行う。</br>
        /// <br></br>
        ///</remarks>
        private void LoadThemeCss()
        {
            // TODO
            this.theme.Href = "css/common/pm_normal.css?ver=" + ExtFileVersion.Ver();
        }
    }
}