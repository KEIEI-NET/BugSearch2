//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/06/16  修正内容 : PVCS票＃158の動作ディレクトリ設定の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/31  修正内容 : Redmine #24278: データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 受信処理自起動
    /// </summary>
    public partial class PMKYO01150UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region [ Private Member ]
        private DataReceiveInputAcs _dataReceiveInputAcs;
        private string enterpriseCode;

        /// <summary>コントロール</summary>
        private IAPSendMessageDB _extraAddUpdControlDB;
        // ADD 2009/02/02 機能追加：対象日付取得 ---------->>>>>
        /// <summary>
        /// マージの実行者を取得します。
        /// </summary>
        private IAPSendMessageDB ExtraAddUpdControlDB
        {
            get
            {
                if (_extraAddUpdControlDB == null)
                {
                    _extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
                }
                return _extraAddUpdControlDB;
            }
        }

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 受信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMKYO01150UA()
        {
            // 初期化処理
            InitializeComponent();
            this._dataReceiveInputAcs = DataReceiveInputAcs.GetInstance();
        }
        #endregion

        #region [ 配信連動自動マージ処理 ]
        internal void MergeOfferToUser()
        {
            try
            {
                // 接続先チェック
                string errMsg = null;
                int _connectPointDiv = 1;
                if (!_dataReceiveInputAcs.CheckConnect(LoginInfoAcquisition.EnterpriseCode, out _connectPointDiv, out errMsg, 1))
                {
                    return;
                }

                // 企業コード
                enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                ArrayList secMngSetWork = null;
                string msg = "";
                // 拠点情報を検索する
                int status = ExtraAddUpdControlDB.SearchSecMngSetData(enterpriseCode, out secMngSetWork, out msg);
                //// 異常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._dataReceiveInputAcs.AutoSendRecvDiv = true;//2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                    // 更新処理
                    status = this._dataReceiveInputAcs.MergeOfferToUserUpdate(secMngSetWork, _connectPointDiv, enterpriseCode);
                }


            }
            catch (Exception e){ 
                MessageBox.Show("Exception:" + e.Message);
            }
        }
        #endregion
    }
}