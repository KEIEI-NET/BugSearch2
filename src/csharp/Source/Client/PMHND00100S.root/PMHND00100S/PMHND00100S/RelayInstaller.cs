//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PMNS-HTT通信サービス
// プログラム概要   : PMNS-HTT間の通信を行うサービスプログラムです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 佐藤　智之
// 作 成 日  2017/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace PMHND00100S
{
    /// public class name:   HT_Service_Installer
    /// <summary>
    ///                      サービスの各プロパティの初期設定
    /// </summary>
    /// <remarks>
    /// <br>note             :   サービスの初期設定用クラス</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// </remarks>
    [RunInstaller(true)]
    public partial class HT_Service_Installer : Installer
    {
        private ServiceInstaller _si;
        private ServiceProcessInstaller _pi;

        /// <summary>
        /// サービスの各プロパティの初期設定
        /// </summary>
        public HT_Service_Installer()
        {
            _pi = new ServiceProcessInstaller();

            //サービスの実行ユーザー
            _pi.Account = ServiceAccount.LocalSystem;
            //_pi.Account = ServiceAccount.User;

            this.Installers.Add(_pi);

            _si = new ServiceInstaller();

            //開始方法の指定
            _si.StartType = ServiceStartMode.Automatic;
            
            //サービス名
            _si.ServiceName = "Partsman.NS HT_RELAY_SERVICE";

            //サービスの説明
            _si.Description = "Partsman.NS-HT間の通信を行います。" + "\r\n" +
                              "Partsman.NSと当サービス間は、IPC通信。" + "\r\n" +
                              "当サービスとHT間は、Socket通信。";

            //サービスの表示名
            _si.DisplayName = "Partsman.NS HT_RELAY_SERVICE";

            this.Installers.Add(_si);

            InitializeComponent();
        }
    }
}