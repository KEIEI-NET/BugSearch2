using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップ画面に自動回答情報を表示するかどうかの設定画面
    /// </summary>
    /// <remarks>
    /// <br>Note		: 設定画面</br>
    /// <br>Programmer	: duzg</br>
    /// <br>Date		: 2011/07/18</br>
    /// <br>Update Note : 2011/07/27 duzg</br>
    /// <br>            :  新着チェッカー改良:Redmine#23240 ボタン調整</br> 
    /// <br>Update Note : 2011/07/28 duzg</br>
    /// <br>            :  新着チェッカー改良:Redmine#23241対応</br> 
    /// <br>Update Note : 2014/10/17 宮本 利明</br>
    /// <br>            :  SCM仕掛一覧№82　着信音対応</br> 
    /// <br>Update Note : 2014/10/28 宮本 利明</br>
    /// <br>            :  システムテスト障害一覧№1：EnableCharsプロパティのWordをTrueに設定</br> 
    /// <br>            :  システムテスト障害一覧№2：ArrowKeyControlを付ける。</br> 
    /// </remarks>
    public partial class PMSCM00005UF : Form
    {
        /// <summary>自動回答の情報を表示するかどうか定数</summary>
        private const string CT_Conf_AutoAnswerView = "AutoAnswerView";

        /// <summary>「config」ファイル</summary>
        private const string Exe_Conf_Filename = "PMSCM00005U.exe.config";

        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";

        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        /// <summary>着信音設定</summary>
        private const string CT_Conf_SoundMode = "SoundMode"; //着信音モード
        private const string CT_Conf_SoundTime = "SoundTime"; //着信音秒数
        private const string CT_Conf_SoundPath = "SoundPath"; //着信音ファイル

        private bool _soundMode = false;
        private int _soundTime = 0;
        private string _soundPath = string.Empty;

        public bool SoundMode
        {
            set { _soundMode = value; }
            get { return _soundMode; }
        }
        public int SoundTime
        {
            set { this._soundTime = value; }
            get { return this._soundTime; }
        }
        public string SoundPath
        {
            set { this._soundPath = value; }
            get { return this._soundPath; }
        }
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM00005UF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定ボタンイベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 設定ボタン処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void setButton_Click(object sender, EventArgs e)
        {
            Configuration config = null;
            AppSettingsSection appSettingSection = GetAppSettingsSection(out config);
            if (this.checkEditor.Checked)
            {
                appSettingSection.Settings[CT_Conf_AutoAnswerView].Value = "1";
            }
            else
            {
                appSettingSection.Settings[CT_Conf_AutoAnswerView].Value = "0";
            }
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            // 着信音モード
            if (this.checkSound.Checked)
            {
                appSettingSection.Settings[CT_Conf_SoundMode].Value = "1"; //オン

                // 着信音設定内容チェック
                if (!checkSoundTime()) return;
                if (!checkSoundPath()) return;
            }
            else
            {
                appSettingSection.Settings[CT_Conf_SoundMode].Value = "0"; //オフ
            }
            // 着信音秒数
            appSettingSection.Settings[CT_Conf_SoundTime].Value = this.tNedit_SoundSec.GetInt().ToString();
            // 着信音ファイル
            appSettingSection.Settings[CT_Conf_SoundPath].Value = this.tEdit_SoundPath.Text.Trim();

            _soundMode = this.checkSound.Checked;
            _soundTime = this.tNedit_SoundSec.GetInt();
            _soundPath = this.tEdit_SoundPath.Text.Trim();
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

            config.Save(ConfigurationSaveMode.Modified);

            this.Close();
        }

        /// <summary>
        /// 閉じるボタンイベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 閉じるボタン処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面表示イベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面表示処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void PMSCM00005UF_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Activate();

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
            Configuration config = null;
            AppSettingsSection appSettingSection = GetAppSettingsSection(out config);

            if (appSettingSection.Settings[CT_Conf_AutoAnswerView].Value.Equals("1"))
                this.checkEditor.Checked = true;
            else
                this.checkEditor.Checked = false;

            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            _soundMode = (!appSettingSection.Settings[CT_Conf_SoundMode].Value.Equals("0"));
            _soundTime = int.Parse(appSettingSection.Settings[CT_Conf_SoundTime].Value);
            _soundPath = appSettingSection.Settings[CT_Conf_SoundPath].Value;

            tNedit_SoundSec.SetInt(this._soundTime);
            tEdit_SoundPath.DataText = this._soundPath;
            checkSound.Checked = this._soundMode;
            SoundEnabledChanged();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            uButton_SoundGuide.ImageList = imageList16;
            uButton_SoundGuide.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
        }

        /// <summary>
        /// ConfigurationSection取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection取得処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private AppSettingsSection GetAppSettingsSection(out Configuration config)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            
            file.ExeConfigFilename = Exe_Conf_Filename;
            config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            AppSettingsSection appSettingSection = (AppSettingsSection)config.GetSection(App_Set_Section);
            // 着信音モード設定の項目が無い場合、コンフィグに追加して保存
            if (appSettingSection.Settings[CT_Conf_SoundMode] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_SoundMode, "0");
            }
            config.Save(ConfigurationSaveMode.Modified);
            if (appSettingSection.Settings[CT_Conf_SoundTime] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_SoundTime, "0");
            }
            config.Save(ConfigurationSaveMode.Modified);
            if (appSettingSection.Settings[CT_Conf_SoundPath] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_SoundPath, string.Empty);
            }
            config.Save(ConfigurationSaveMode.Modified);
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }

        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        /// <summary>
        /// 着信音のON/OFF切替
        /// </summary>
        private void checkSound_CheckedChanged(object sender, EventArgs e)
        {
            SoundEnabledChanged();
        }

        /// <summary>
        /// 着信音のON/OFF切替による項目設定
        /// </summary>
        private void SoundEnabledChanged()
        {
            tNedit_SoundSec.Enabled = checkSound.Checked;
            tEdit_SoundPath.Enabled = checkSound.Checked;
            uButton_SoundGuide.Enabled = checkSound.Checked;
            uLabel_Sound.Enabled = checkSound.Checked;
            uLabel_SoundSec.Enabled = checkSound.Checked;
            uLabel_SoundPath.Enabled = checkSound.Checked;
            uLabel_SoundNotes.Enabled = checkSound.Checked;
        }

        /// <summary>
        /// 着信音設定ダイアログ
        /// </summary>
        private void uButton_SoundGuide_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tEdit_SoundPath.DataText = this.openFileDialog.FileName;
                if (!checkSoundPath()) return;
            }
        }

        /// <summary>
        /// 着信音設定値チェック：再生時間
        /// </summary>
        private bool checkSoundTime()
        {
            bool bRet = true;
            string sErrMsg = string.Empty;

            if (this.tNedit_SoundSec.GetInt() == 0)
            {
                sErrMsg = "再生時間を設定してください。";
                bRet = false;
            }
            if (!bRet)
            {
                TMsgDisp.Show(this                               // 親ウィンドウフォーム
                             ,emErrorLevel.ERR_LEVEL_EXCLAMATION // エラーレベル
                             ,"PMSCM00005UF"                     // アセンブリＩＤまたはクラスＩＤ
                             ,sErrMsg                            // 表示するメッセージ
                             ,0                                  // ステータス値
                             ,MessageBoxButtons.OK);             // 表示するボタン
                this.tNedit_SoundSec.Focus();
            }
            return bRet;
        }

        /// <summary>
        /// 着信音設定値チェック：着信音ファイル
        /// </summary>
        private bool checkSoundPath()
        {
            bool bRet = true;
            string sErrMsg = string.Empty;

            if (!this.tEdit_SoundPath.Text.Trim().Equals(string.Empty))
            {
                if (!System.IO.File.Exists(this.tEdit_SoundPath.Text.Trim()))
                {
                    sErrMsg = "指定した着信音ファイルは存在しません。";
                    bRet = false;
                }
                else
                {
                    string sExtension = Path.GetExtension(this.tEdit_SoundPath.Text).TrimStart('.');
                    if (sExtension.ToUpper() != "WAV")
                    {
                        sErrMsg = "ファイル形式に誤りがあります。";
                        bRet = false;
                    }
                }
                if (!bRet)
                {
                    TMsgDisp.Show(this
                                 ,emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 ,"PMSCM00005UF"
                                 ,sErrMsg
                                 ,0
                                 ,MessageBoxButtons.OK);
                    this.tEdit_SoundPath.Focus();
                }
            }
            return bRet;
        }

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_SoundSec":
                {
                    if (!checkSoundTime()) e.NextCtrl = e.PrevCtrl;
                    break;
                }
                case "tEdit_SoundPath":
                {
                    if (!checkSoundPath()) e.NextCtrl = e.PrevCtrl;
                    break;
                }
            }
        }
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
    }
}