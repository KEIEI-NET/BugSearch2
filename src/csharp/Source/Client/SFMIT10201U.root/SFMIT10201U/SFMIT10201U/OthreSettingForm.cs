using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinToolTip;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// その他設定画面
    /// </summary>
    public partial class OthreSettingForm : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OthreSettingForm()
        {
            InitializeComponent();
            this._enterpirseCode = "";
            this._sectionList = new List<Propose_Para_Section>();
            this._saveFlag = false;
            this._TBOServiceACS = new TBOServiceACS();
            this._settingsDic = new Dictionary<string, Settings>();
        }
        #endregion

        #region const
        private const string CT_ASSEMBLYID = "SFMIT1201U";

        private readonly string CT_INFOMATION = "「通知する」に設定した場合、提案商品登録画面に「在庫状態」列が追加され" + Environment.NewLine +
                                             " 設定した「在庫状態」が整備工場側へ通知されます。" + Environment.NewLine +
                                             " ※通知される内容はあくまで提案商品登録時の在庫状態となりますので" + Environment.NewLine +
                                             "　 「通知する」にて運用を行われる場合は定期的に在庫状態のメンテナンスを行って下さい。";

        #endregion

        #region メンバ

        /// <summary>
        /// 動作設定ディクショナリ
        /// </summary>
        public Dictionary<string, Settings> _settingsDic;

        /// <summary>拠点選択値</summary>
        private string _selectValue;

        #region 起動パラメータ

        // 企業コード
        public string _enterpirseCode;

        // 拠点コード
        public string _sectionCode;

        // 拠点リスト
        public List<Propose_Para_Section> _sectionList;

        // TBOアクセスクラス
        private TBOServiceACS _TBOServiceACS;

        #endregion

        #region 結果パラメータ

        // データ更新フラグ
        public bool _saveFlag;

        #endregion

        #endregion

        #region Public

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowOtherSettinfForm()
        {
            //int st = 0;
            //string errMsg = "";

            // ツールチップ
            UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
            ultraToolTipInfo.ToolTipText = CT_INFOMATION;
            this.ultraToolTipManager1.SetUltraToolTip(this.info_pictureBox, ultraToolTipInfo);

            //this.Size = new Size(540, 186);

            // 拠点
            // もらったものをそのままセット
            foreach (Propose_Para_Section section in _sectionList)
            {
        		this.Section_ComboEditor.Items.Add(section.SectionCode, section.SectionGuideNm);
            }

            // 在庫通知
            this.StockInfo_tComboEditor.Items.Add(0,"通知しない");
            this.StockInfo_tComboEditor.Items.Add(1,"通知する");

            // 設定データ取得
            //List<Settings> retList = new List<Settings>();
            //st = this._TBOServiceACS.GetSettings(this._enterpirseCode, out retList, out errMsg);
            //if (st == 0)
            //{
            //    foreach (Settings setting in retList)
            //    {
            //        if (!this._settingsDic.ContainsKey(setting.sectionCode))
            //        {
            //            this._settingsDic.Add(setting.sectionCode, setting);
            //        }
            //    }
            //}
            //else
            //{
            //    TMsgDisp.Show(
            //    this,							    // 親ウィンドウフォーム
            //    emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
            //    CT_ASSEMBLYID,					    // アセンブリIDまたはクラスID
            //    "動作設定の取得に失敗しました。",	// 表示するメッセージ 
            //    st,								    // ステータス値
            //    MessageBoxButtons.OK);			    // 表示するボタン
            //    return DialogResult.Cancel;
            //}

            // 
            this.Section_ComboEditor.Value = this._selectValue = this._sectionCode;

            // 画面構築
            this.DispSetting();

            // イベントセット
            this.Section_ComboEditor.ValueChanged += new EventHandler(Section_ComboEditor_ValueChanged);

            return this.ShowDialog();
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        private void DispSetting()
        {
            // 初期化
            this.StockInfo_tComboEditor.SelectedIndex = 0;

            // データが存在するか確認
            if (this._settingsDic.ContainsKey(this.Section_ComboEditor.Value.ToString()))
            {
                // データ有
                this.StockInfo_tComboEditor.Value = this._settingsDic[this.Section_ComboEditor.Value.ToString()].stockDisplayFlag ? 1 : 0;
            }
            else
            {
                // データ無
                this.StockInfo_tComboEditor.Value = 0;
            }
        }

        #endregion

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.SaveProc();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        private int SaveProc()
        {
            int st = 0;
            string errMsg = "";

            // 保存対象データ作成
            Settings settings = new Settings();
            if (this._settingsDic.ContainsKey(this.Section_ComboEditor.Value.ToString()))
            {
                // 更新
                settings = (this._settingsDic[this.Section_ComboEditor.Value.ToString()].Clone());
            }
            else
            {
                // 新規
                settings.enterpriseCode = this._enterpirseCode;
                settings.inquiryUseFlag = false;
                settings.releaseDateDisplayFlag = false;
                settings.sectionCode = this.Section_ComboEditor.Value.ToString();
            }

            if ((int)this.StockInfo_tComboEditor.Value == 0)
            {
                settings.stockDisplayFlag = false;
            }
            else
            {
                settings.stockDisplayFlag = true;
            }

            List<Settings> saveList = new List<Settings>();
            saveList.Add(settings);
            st = this._TBOServiceACS.SaveSettings(ref saveList, out errMsg);

            if (st == 0)
            {
                // 1件更新しかしない
                if (saveList != null && saveList.Count > 0)
                {
                    // データ更新
                    if (this._settingsDic.ContainsKey(saveList[0].sectionCode))
                    {
                        this._settingsDic.Remove(saveList[0].sectionCode);
                        this._settingsDic.Add(saveList[0].sectionCode, saveList[0]);
                    }
                    else
                    {
                        this._settingsDic.Add(saveList[0].sectionCode, saveList[0]);
                    }
                }

                this._saveFlag = true;

                TMsgDisp.Show(
                this,							    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                CT_ASSEMBLYID,					    // アセンブリIDまたはクラスID
                "保存しました。",	                // 表示するメッセージ 
                st,								    // ステータス値
                MessageBoxButtons.OK);
               
            }
            else
            {
                TMsgDisp.Show(
                this,							    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                CT_ASSEMBLYID,					    // アセンブリIDまたはクラスID
                errMsg,	                            // 表示するメッセージ 
                st,								    // ステータス値
                MessageBoxButtons.OK);
                return st;
            }
            return st;
        }

       

        /// <summary>
        /// 拠点コンボ変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Section_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 変更チェック
            if (this._selectValue != this.Section_ComboEditor.Value.ToString())
            {
                // 拠点が変更された
                bool dataSearhFlag = false;
                // 更新確認
                if (CheckUpDate())
                {
                    // メッセージを表示
                    DialogResult ret = TMsgDisp.Show(
                       this,							                        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                       CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                       "現在編集中のデータが存在します。"                       // 表示するメッセージ 
                       + Environment.NewLine + "登録してもよろしいですか？",
                       0,								                        // ステータス値
                       MessageBoxButtons.YesNoCancel);


                    if (ret == DialogResult.Yes)
                    {
                        // 保存処理

                        int st = this.SaveProc();
                        if (st == 0)
                        {
                            this._selectValue = this.Section_ComboEditor.Value.ToString();
                            dataSearhFlag = true;
                        }
                        else
                        {
                            // 保存に失敗
                            this.Section_ComboEditor.ValueChanged -= new EventHandler(this.Section_ComboEditor_ValueChanged);
                            this.Section_ComboEditor.Value = this._selectValue;
                            this.Section_ComboEditor.ValueChanged += new EventHandler(this.Section_ComboEditor_ValueChanged);

                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        // 編集内容を破棄 インデックを更新
                        this._selectValue = this.Section_ComboEditor.Value.ToString();
                        dataSearhFlag = true;
                    }
                    else
                    {
                        // キャンセル →　戻す
                        this.Section_ComboEditor.Validated -= new EventHandler(this.Section_ComboEditor_ValueChanged);
                        this.Section_ComboEditor.Value = this._selectValue;
                        this.Section_ComboEditor.Validated += new EventHandler(this.Section_ComboEditor_ValueChanged);
                    }
                }
                else
                {
                    // データ変更なし
                    // インデックスを更新
                    this._selectValue = this.Section_ComboEditor.Value.ToString();
                    dataSearhFlag = true;
                }
                if (dataSearhFlag)
                {
                    // 画面再構築
                    this.DispSetting();
                }
            }
        }

        /// <summary>
        /// 変更チェック
        /// </summary>
        private bool CheckUpDate()
        {
            bool ret = false;
            // 更新前データ取得
            if (this._settingsDic.ContainsKey(this._selectValue))
            {
                int befSet = 0;
                if (this._settingsDic[this._selectValue].stockDisplayFlag)
                {
                    befSet = 1;
                }

                if (((int)this.StockInfo_tComboEditor.Value).Equals(befSet) == false)
                {
                    return true;
                }
            }
            return ret;
        }

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// OthreSettingForm_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OthreSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 更新確認
            if (CheckUpDate())
            {
                // メッセージを表示
                DialogResult ret = TMsgDisp.Show(
                   this,							                        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_INFO,	                            // エラーレベル
                   CT_ASSEMBLYID,					                        // アセンブリIDまたはクラスID
                   "現在編集中のデータが存在します。"                       // 表示するメッセージ 
                   + Environment.NewLine + "登録してもよろしいですか？",
                   0,								                        // ステータス値
                   MessageBoxButtons.YesNoCancel);

                if (ret == DialogResult.Yes)
                {
                    int st = this.SaveProc();
                    if (st != 0)
                    {
                        e.Cancel = true;
                        return;
                    } 
                }
                else if (ret == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }
    }
}