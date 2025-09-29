//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCMデモ用設定ツール
// プログラム概要   : 新着通知・受信間隔をデモ用に秒単位で設定するツールです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PMSCM09999E
{
    public partial class PMSCM09999E : Form
    {
        /// <summary>PM.NSインストールディレクトリ</summary>
        private string _installDirectory = string.Empty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMSCM09999E()
        {
            InitializeComponent();
        }

        #region プライベートメソッド
        /// <summary>
        /// インストールディレクトリを取得します
        /// </summary>
        /// <returns></returns>
        private int GetInstallDirectory()
        {
            int status = 0;
            string rKeyName = @"SOFTWARE\Broadleaf\Product\Partsman";
            string idValue = "InstallDirectory";
            try
            {
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);
                _installDirectory = (string)rKey.GetValue(idValue);
                rKey.Close();
            }
            catch
            {
                status = 1;
            }
            return status;
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <param name="receiveTime"></param>
        /// <returns>0:OK　1:入力エラー</returns>
        private int CheckReceiveTime(int receiveTime)
        {
            int status = 0;
            if (receiveTime >= 5 && receiveTime <= 99 || receiveTime == 0)
            {
                status = 0;
            }
            else
            {
                status = 1;
            }
            return status;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private int SaveToBinaryFile(int obj, string path)
        {
            int status = 0;
            try
            {
                FileStream fs = new FileStream(path,
                    FileMode.Create,
                    FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                //シリアル化して書き込む
                bf.Serialize(fs, obj);
                fs.Close();
            }
            catch
            {
                status = 1;
            }
            return status;
        }

        /// <summary>
        /// 読込処理
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private object LoadFromBinaryFile(string path)
        {
            object obj = null;
            try
            {
                FileStream fs = new FileStream(path,
                    FileMode.Open,
                    FileAccess.Read);
                BinaryFormatter f = new BinaryFormatter();
                //読み込んで逆シリアル化する
                obj = f.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                obj = null;
            }

            return obj;
        }
        #endregion

        #region イベント
        /// <summary>
        /// 保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSave_Click(object sender, EventArgs e)
        {
            int receiveTime = 0;
            try
            {
                // テキストボックスが空白なら0をセット
                if (string.IsNullOrEmpty(this.tBox_receiveTime.Text))
                {
                    this.tBox_receiveTime.Text = "0";
                }
                receiveTime = Convert.ToInt32(this.tBox_receiveTime.Text);
            }
            catch
            {
                // 数値以外の文字が入力されている
                MessageBox.Show("新着通知・受信間隔の値が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tBox_receiveTime.Focus();
                this.tBox_receiveTime.SelectAll();
                return;
            }

            // 入力チェック
            if (0 != CheckReceiveTime(receiveTime))
            {
                MessageBox.Show("新着通知・受信間隔は 5秒～99秒で設定して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tBox_receiveTime.Focus();
                this.tBox_receiveTime.SelectAll();
            }
            else
            {
                string fileName = _installDirectory + "\\UISettings\\SCMDemoSetting.xml";
                // 0が入力されている場合は削除処理を実行
                if (receiveTime == 0)
                {
                    // 削除処理　削除ボタンクリックイベント呼出
                    this.bDelete_Click(sender, e);
                }
                else
                {
                    // 保存処理
                    if (0 == SaveToBinaryFile(receiveTime, fileName))
                    {
                        MessageBox.Show("設定ファイルを保存しました。", "完了報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 念の為、保存に失敗した場合
                        MessageBox.Show("設定ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 完全削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, EventArgs e)
        {
            string fileName = _installDirectory + "\\UISettings\\SCMDemoSetting.xml";
            File.Delete(fileName);
            MessageBox.Show("設定ファイルの削除処理を実行しました。\n新着通知・受信間隔は、SCM全体設定を参照します。", "完了報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM09999E_Load(object sender, EventArgs e)
        {
            // レジストリ内容チェック
            if (this.GetInstallDirectory() == 1 || string.IsNullOrEmpty(_installDirectory))
            {
                MessageBox.Show("PM.NSがインストールされていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                string fileName = _installDirectory + "\\UISettings\\SCMDemoSetting.xml";
                object obj = LoadFromBinaryFile(fileName);
                if (obj != null)
                {
                    // 既存ファイルが存在する場合は、画面に展開
                    this.tBox_receiveTime.Text = obj.ToString();
                }
            }
        }
        #endregion

    }
}