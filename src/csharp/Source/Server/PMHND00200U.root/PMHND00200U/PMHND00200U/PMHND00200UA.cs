//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 検品データ削除処理 フォームクラス                       //
// プログラム概要   : 検品データテーブルに対して削除処理を行う                //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊                                 //
// 作 成 日  2017/05/22  修正内容 : 新規作成                                  //
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
    /// 検品データ削除処理 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 検品データ削除処理UIフォームクラス</br>
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/05/22</br>
    /// </remarks>
    public partial class PMHND00200UA : Form
    {
        #region ■ Const Memebers ■
        /// <summary>XMLファイル</summary>
        private const string ct_XMLFileName = "PMHND00200U_UserSetting.xml";
        /// <summary>デフォルト保存日付</summary>
        private const int ct_DefaultHoldDays = 30;
        #endregion

        # region ■ private field ■
        /// <summary>ユーザー設定情報</summary>
        private UserSettingInfo UserSetInfo;
        /// <summary>検品データ削除処理アクセスクラス</summary>
        private InspectDataAcs _inspectDataAcs;
        #endregion
       
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="workDir">実行環境パス</param>
        /// <remarks>
        /// <br>Note        : コンストラクタ</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/05/22</br>
        /// </remarks>
        public PMHND00200UA(string workDir)
        {
            InitializeComponent();

            // ユーザー設定情報<
            this.UserSetInfo = new UserSettingInfo();
            // 検品データ削除処理アクセスクラス
            this._inspectDataAcs = InspectDataAcs.GetInstance();

            // デシリアライズ処理
            this.Deserialize(workDir);
        }
        #endregion

        # region ■ イベント ■
        /// <summary>
        /// 検品データ削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検品データ削除処理を行います。</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/05/22</br>
        /// </remarks>
        public int DeleteData()
        {
            // 検索パラメータ設定
            InspectDataWork inspectDataWork = new InspectDataWork();

            // 企業コード
            inspectDataWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 保存日付
            int intHoldDays = 0;
            // 保存日数の数字タイプ変換
            bool parseFlg = int.TryParse(this.UserSetInfo.HoldDays, out intHoldDays);
            if (!parseFlg)
            {
                intHoldDays = ct_DefaultHoldDays;
            }
            DateTime createDateTimeEnd = DateTime.Today.AddDays((intHoldDays * -1) + 1);
            // 作成日時
            inspectDataWork.CreateDateTime = createDateTimeEnd;

            // データ削除処理
            string errMsg;
            int status = this._inspectDataAcs.DeleteData(inspectDataWork, out errMsg);
            return status;
        }
        #endregion

        #region ■ 配置ファイルデシリアライズ・シリアライズ処理 ■
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <param name="workDir">実行環境パス</param>
        /// <remarks>
        /// <br>Note        : デシリアライズ処理を行う。</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/05/22</br>
        /// </remarks>
        private void Deserialize(string workDir)
        {

            if (UserSettingController.ExistUserSetting(Path.Combine(workDir, ct_XMLFileName)))
            {
                try
                {
                    this.UserSetInfo = UserSettingController.DeserializeUserSetting<UserSettingInfo>(Path.Combine(workDir, ct_XMLFileName));
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
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/05/22</br>
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
