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

namespace Broadleaf.Web.UI
{
    /// <summary>
    /// タブレットPM結合選択ページ
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : LDNS</br>
    /// <br>Date        : 2013.06.03</br>
    /// <br>Note        : タブレットPM結合選択ページの内容を構築します。</br>
    /// </remarks>
    public partial class PMTAB04033W : System.Web.UI.Page
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
                throw new MobileWebException("PMTAB04033W", "Page_Load", "タブレットPM結合選択ページでエラーが発生しました。" + Environment.NewLine + exception2.Message, -1, exception2);
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