using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;

namespace Broadleaf.NSNetworkChk.Data
{
    /// <summary>
    /// AWS自動テスト情報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : AWS自動テスト情報のクラスです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2019.01.02</br>
    /// </remarks>
    public class NSNetWorkAutoTestInfo
    {
        /// <summary>
        /// AWS自動テスト情報コンストラクタ
        /// </summary>
        /// <returns>NSNetWorkAutoTestInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NSNetWorkAutoTestInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NSNetWorkAutoTestInfo()
        {
        }

        /// <summary>自動テスト製品</summary>
        private string _autoProductName;

        /// <summary>自動テスト区分</summary>
        private bool _autoStartupDiv;

        /// public propaty name  :  AutoProductName
        /// <summary>自動テスト製品プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動テスト製品プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AutoProductName
        {
            get { return _autoProductName; }
            set { _autoProductName = value; }
        }

        /// public propaty name  :  AutoStartupDiv
        /// <summary>自動テスト区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動テスト区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool AutoStartupDiv
        {
            get { return _autoStartupDiv; }
            set { _autoStartupDiv = value; }
        }

        /// <summary>
        /// デシリアライズ化
        /// </summary>
        /// <returns>AWS自動テスト情報クラス</returns>
        /// <remarks>
        /// <br>Note       : XMLからNSNetWorkAutoTestInfoデータを読み込みます。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public static int Deserialize(out NSNetWorkAutoTestInfo nSNetWorkAutoTestInfo, string filename)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // AWS自動テスト情報のインスタンスを取得
                // AWS自動テスト情報ファイルの存在を確認
                if (UserSettingController.ExistUserSetting(Path.Combine(System.Windows.Forms.Application.StartupPath, filename)))
                {
                    nSNetWorkAutoTestInfo = UserSettingController.DeserializeUserSetting<NSNetWorkAutoTestInfo>(Path.Combine(System.Windows.Forms.Application.StartupPath, filename));
                }
                else
                {
                    // AWS自動テスト情報定ファイルが存在しない場合
                    nSNetWorkAutoTestInfo = Default();
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }
            //XMLが読み込み失敗の場合
            catch (Exception)
            {
                nSNetWorkAutoTestInfo = Default();
                status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }
            
            return status;
        }

        /// <summary>
        /// AWS自動テスト情報取得処理
        /// </summary>
        /// <returns>AWS自動テスト情報の初期値</returns>
        /// <remarks>
        /// <br>Note       : AWS自動テスト情報の初期値を設定します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private static NSNetWorkAutoTestInfo Default()
        {
            NSNetWorkAutoTestInfo nSNetWorkAutoTestInfoDefault = new NSNetWorkAutoTestInfo();

            nSNetWorkAutoTestInfoDefault._autoProductName = "製品を選択して下さい";
            nSNetWorkAutoTestInfoDefault._autoStartupDiv = false;

            return nSNetWorkAutoTestInfoDefault;
        }

    }
}
