//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : PMTABセッション管理データ削除処理 フォームクラス        //
// プログラム概要   : PMTABセッション管理データテーブルに対して削除処理を行う //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11300141-00 作成担当 : 譚洪                                      //
// 作 成 日  2017/04/06 修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMTABセッション管理データ削除処理 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : PMTABセッション管理データ削除処理UIフォームクラス</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2017/04/06</br>
    /// </remarks>
    public partial class PMTAB00200UA : Form
    {
        #region ■ Const Memebers ■
        /// <summary>プログラムID</summary>
        private const string ASSEMBLY_ID = "PMTAB00200UA";
        /// <summary>XMLファイル</summary>
        private const string XMLFileName = "PMTAB00200U_UserSetting.xml";
        #endregion

        # region ■ private field ■
        /// <summary>ユーザー設定情報</summary>
        private UserSettingInfo UserSetInfo;
        private PmTabSessionMngAcs _pmTabSessionMngAcs;
        #endregion
       
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="workDir">実行環境パス</param>
        /// <remarks>
        /// <br>Note        : コンストラクタ</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/04/06</br>
        /// </remarks>
        public PMTAB00200UA(string workDir)
        {
            InitializeComponent();

            this.UserSetInfo = new UserSettingInfo();
            this._pmTabSessionMngAcs = PmTabSessionMngAcs.GetInstance();

            this.Deserialize(workDir);
        }
        #endregion

        # region ■ イベント ■
        /// <summary>
        /// PMTABセッション管理データ削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: PMTABセッション管理データ削除処理を行います。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/04/06</br>
        /// </remarks>
        public int DeleteData()
        {
            // 検索パラメータ設定
            PmTabSessionMngWork pmTabSessionMngWork = new PmTabSessionMngWork();
            pmTabSessionMngWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            string holdDays = this.UserSetInfo.HoldDays;
            int holdDaysResult = 0;
            if (!int.TryParse(holdDays, out holdDaysResult))
            {
                // 変換できなかった場合は7日を固定とする
                holdDaysResult = 7;
            }
            DateTime holdDaysDateTime = DateTime.Today.AddDays((holdDaysResult * -1) + 1);
            pmTabSessionMngWork.CreateDateTime = holdDaysDateTime;

            // データ削除処理
            string errMsg;
            int status = this._pmTabSessionMngAcs.DeleteData(pmTabSessionMngWork, out errMsg);
            return status;
        }
        #endregion

        #region ◎ 配置ファイルデシリアライズ・シリアライズ処理
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <param name="workDir">実行環境パス</param>
        /// <remarks>
        /// <br>Note        : デシリアライズ処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/04/06</br>
        /// </remarks>
        private void Deserialize(string workDir)
        {

            if (UserSettingController.ExistUserSetting(Path.Combine(workDir, XMLFileName)))
            {
                try
                {
                    this.UserSetInfo = UserSettingController.DeserializeUserSetting<UserSettingInfo>(Path.Combine(workDir, XMLFileName));
                }
                catch
                {
                    this.UserSetInfo = new UserSettingInfo();
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// XML情報取得用ユーザー設定情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : XML情報取得用ユーザー設定情報クラスです。</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2017/04/06</br>
    /// </remarks>
    public class UserSettingInfo
    {
        /// <summary> 保存日付 </summary>
        private string _holdDays = string.Empty;

        /// <summary>
        /// 保存日付
        /// </summary>
        public string HoldDays
        {
            get { return _holdDays; }
            set { _holdDays = value; }
        }
    }
}
