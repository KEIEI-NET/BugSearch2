using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 印刷設定画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 印刷設定画面を行います。</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/05/17</br>
    /// </remarks>
    public partial class SFCMN00293UE : Form
    {
        #region Constructor
        /// <summary>
        /// 印刷設定画面クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 印刷設定画面クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        public SFCMN00293UE()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Members
        private int _maxPageCount;  //印刷設定画面の最大ページ数
        private int _curPageCount;  //印刷設定画面の当前ページ数
        private int _pageCount;     //印刷ページ数
        private ArrayList _selectPageList;//選択したページリスト
      
        private DialogResult _dialogRes = DialogResult.No;   　// ダイアログリザルト

        private int _fromPageBe = 0; //ページ前回値from
        private int _toPageBe = 0;   //ページ前回値to
        #endregion

        # region Properties
        /// <summary>
        /// 選択されたページの取得
        /// </summary>
        /// <returns>選択されたページ</returns>
        /// <remarks>
        /// <br>Note       : 選択されたページを取得します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        public ArrayList SelectPageList
        {
            get { return _selectPageList; }
            set { this._selectPageList = value; }
        }
        # endregion

        #region Public Methods
        /// <summary>
        /// 印刷設定画面起動
        /// </summary>
        /// <param name="owner">owner</param>
        /// <param name="pageCount">ページ数</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        public DialogResult Show(IWin32Window owner, int pageCount)
        {
            _pageCount = pageCount;

            this._fromPageBe = 1;
            this._toPageBe = pageCount;

            this._selectPageList = new ArrayList();

            DialogResult dr = base.ShowDialog(owner);
            return _dialogRes;
        }
        #endregion

        #region Private Members
        /// <summary>
        /// checkbox制御
        /// </summary>
        /// <remarks>
        /// <br>Note       : checkbox制御を行います。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void pageChkEnable()
        {
            int maxCount = 0;
            int tempCount = 0;
            if (this._curPageCount != this._maxPageCount)
            {
                maxCount = 100;
            }
            else
            {
                tempCount = _pageCount % 100;
                if (tempCount != 0)
                {
                maxCount = _pageCount % 100;
            }
                else
                {
                    maxCount = 100;
                }
            }

            string name = string.Empty;
            for (int i = 1; i < 101; i++)
            {
                name = "ultraCheckEditor_" + i;
                //ページ表示制御
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                if (i > maxCount)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }
        }

        /// <summary>
        /// 選択したページリスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 選択したページリスを設定する。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setSelectPageList()
        {
            for (int i = 0; i < _pageCount; i++)
            {
                // 全てページ を選択したページリストに設定する
                if (!this._selectPageList.Contains(i))
                {
                    this._selectPageList.Add(i);
                }
            }
        }

        /// <summary>
        /// checkbox選択制御
        /// </summary>
        /// <remarks>
        /// <br>Note       : checkbox選択制御を行います。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void pageChkChecked(bool checkFlag)
        {
            string name = string.Empty;
            for (int i = 1; i < 101; i++)
            {
                name = "ultraCheckEditor_" + i;
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                if( control.Visible)
                {
                    control.Checked = checkFlag;
                }
            }
        }

        /// <summary>
        /// 画面選択状態初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面選択状態初期化を行います。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setPageChecked()
        {
            string name = string.Empty;
            int pageFrom = (this._curPageCount - 1) * 100;//当前ページ数範囲from
            int pageTo = this._curPageCount * 100;        //当前ページ数範囲to

            for (int i = pageFrom; i < pageTo; i++)
            {
                int index = i - (this._curPageCount - 1) * 100 + 1;
                name = "ultraCheckEditor_" + index;
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

                if (this._selectPageList.Contains(i))
                {
                    control.Checked = true;
                }
                else
                {
                    control.Checked = false;
                }
            }
        }

        /// <summary>
        /// 画面表示名称設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面表示名称を設定します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setPageCheckNm()
        {
            string name = string.Empty;
            int index = (this._curPageCount - 1) * 100;
            for (int i = 1; i < 101; i++)
            {
                name = "ultraCheckEditor_"+ i;
                Infragistics.Win.UltraWinEditors.UltraCheckEditor control = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                int temp = index + i;
                control.Text = temp.ToString();
            }
        }

        /// <summary>
        /// 画面表示名称設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面表示名称を設定します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        private void setPageBtnEnable()
        {
            //前ページボタン操作の設定
            if (this._curPageCount == 1)
            {
                this.uButton_prePage.Enabled = false;
            }
            else
            {
                this.uButton_prePage.Enabled = true;
            }
            //後ページボタン操作の設定
            if (this._curPageCount != _maxPageCount)
            {
                this.uButton_nextPage.Enabled = true;
            }
            else
            {
                this.uButton_nextPage.Enabled = false;
            }
        }

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// </remarks>
        internal DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "SFCMN00293U", iMsg, iSt, iButton, iDefButton);
        }

        #endregion

        #region Control Event
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00293UE_Load(object sender, EventArgs e)
        {
            int tempCount = 0;
            tempCount = _pageCount % 100;

            if (tempCount != 0)
            {
            // 印刷設定画面の最大ページ数の設定
            this._maxPageCount = _pageCount / 100 + 1;
            }
            else
            {
                // 印刷設定画面の最大ページ数の設定
                this._maxPageCount = _pageCount / 100;
            }

            // 印刷設定画面の当前ページ数の設定
            this._curPageCount = 1;
            // 前ページボタン操作可
            this.uButton_prePage.Enabled = false;
            // 後ページボタン制御
            if (this._maxPageCount > 1)
            {
                this.uButton_nextPage.Enabled = true;
            }
            else
            {
                this.uButton_nextPage.Enabled = false;
            }
            // ページ制御
            this.pageChkEnable();

            // 全部ページを選択する
            this.setSelectPageList();

            // 画面選択状態制御
            this.setPageChecked();

                //指定ページFROM
            this.tNedit_pageFrom.SetInt(1);
                //指定ページTO
            this.tNedit_pageTo.SetInt(this._pageCount);
        }

        /// <summary>
        /// CheckedChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // checkbox対応したページ数を取得する
            string name = ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Name;
            string[] nameTemp = name.Split('_');
            int value = Int32.Parse(nameTemp[1]);
            if (value == 00)
            {
                value = _curPageCount * 100 - 1;
            }
            else
            {
                value += (_curPageCount - 1) * 100 - 1;
            }

            //選択されたページを「選択したページリスト」に設定する
            if (((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Checked)
            {
                if (!this._selectPageList.Contains(value))
                {
                    this._selectPageList.Add(value);
                }
            }
            else
            {
                //選択しないページを「選択したページリスト」から削除する
                if (this._selectPageList.Contains(value))
                {
                    this._selectPageList.Remove(value);
                }
            }
        }

        /// <summary>
        /// キャンセルボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_cancle_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        /// <summary>
        /// 設定ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_set_Click(object sender, EventArgs e)
        {
            //画面情報設定、画面を閉じる
            if (this._selectPageList != null && this._selectPageList.Count != 0)
            {
                this._dialogRes = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                           "印刷ページが選択されていません。",
                                           0,
                                           MessageBoxButtons.OK,
                                           MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// 全選択ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SelectAll_Click(object sender, EventArgs e)
        {
            // 画面に全て項目が選択したの状態を設定する
            this.pageChkChecked(true);

            this.tNedit_pageTo.SetInt(this._pageCount);
            this.tNedit_pageFrom.SetInt(1);
            this._fromPageBe = 1;
            this._toPageBe = this._pageCount;

            //「選択したページリスト」を設定する
            this.setSelectPageList();
        }

        /// <summary>
        /// 全解除ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_UnSelect_Click(object sender, EventArgs e)
        {
            // 画面に全て項目が選択しないの状態を設定する
            this.pageChkChecked(false);

            this.tNedit_pageTo.SetInt(0);
            this.tNedit_pageFrom.SetInt(0);

            this._fromPageBe = 0;
            this._toPageBe = 0;
            //「選択したページリスト」をクリアする
            this._selectPageList.Clear();
        }

        /// <summary>
        /// 前ページボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_prePage_Click(object sender, EventArgs e)
        {
            // 当前ページ数の設定
            if (this._curPageCount > 1)
            {
                this._curPageCount -= 1;
            }

            // 画面表示再設定
            this.setPageCheckNm();
            this.setPageChecked();
            this.pageChkEnable();

            // ページ遷移ボタン制御
            this.setPageBtnEnable();
        }
        
        /// <summary>
        /// 後ページボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_nextPage_Click(object sender, EventArgs e)
        {
            // 当前ページ数の設定
            if (this._curPageCount < _maxPageCount)
            {
                this._curPageCount += 1;
            }

            // 画面表示再設定
            this.setPageCheckNm();
            this.setPageChecked();
            this.pageChkEnable();
            // ページ遷移ボタン制御
            this.setPageBtnEnable();
        }

        /// <summary>
        /// closingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN00293UE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._dialogRes != DialogResult.OK)
            {
                this._dialogRes = DialogResult.Cancel;

                //全部ページを設定する
                this._selectPageList.Clear();
                this.setSelectPageList();
            }
        }

        /// <summary>
        /// MouseUpイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraCheckEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            //指定ページに空白を設定する
            this.tNedit_pageFrom.SetInt(0);
            this.tNedit_pageTo.SetInt(0);

            this._toPageBe = 0;
            this._fromPageBe = 0;
        }

        /// <summary>
        /// KeyUpイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraCheckEditor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        //指定ページに空白を設定する
                        this.tNedit_pageFrom.SetInt(0);
                        this.tNedit_pageTo.SetInt(0);

                        this._toPageBe = 0;
                        this._fromPageBe = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                #region 指定ページFrom
                case "tNedit_pageFrom":
                    {
                        //指定ページ範囲の取得
                        int pageFrom = this.tNedit_pageFrom.GetInt();
                        int pageTo = this.tNedit_pageTo.GetInt();
                        if (!(pageTo == 0 && pageFrom == 0))
                        {
                            // 入力チェック
                            if (pageFrom > this._pageCount
                                || (pageFrom > pageTo
                                && (pageTo != 0)))
                            {
                                this.TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                            "正しい印刷範囲を設定してください。",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);
                                e.NextCtrl = this.tNedit_pageFrom;
                                return;
                            }
                            //指定ページfrom設定しないの場合：１を設定する
                            if (pageFrom == 0)
                            {
                                pageFrom = 1;
                            }
                            //指定ページTo設定しないの場合：最大ページを設定する
                            if (pageTo == 0 && pageFrom != 0)
                            {
                                pageTo = this._pageCount;
                            }

                            if (this._fromPageBe != pageFrom)
                            {
                                //選択されたページを設定する
                                this._selectPageList.Clear();
                                for (int i = pageFrom; i <= pageTo; i++)
                                {
                                    this._selectPageList.Add(i - 1);
                                }
                                //画面選択状態変更
                                this.setPageChecked();

                                this._fromPageBe = pageFrom;
                            }
                        }
                        else
                        {
                            this._fromPageBe = 0;
                        }
                        break;
                    }
                #endregion

                #region 指定ページTo
                case "tNedit_pageTo":
                    {
                        //指定ページ範囲の取得
                        int pageFrom = this.tNedit_pageFrom.GetInt();
                        int pageTo = this.tNedit_pageTo.GetInt();

                        if (!(pageTo == 0 && pageFrom == 0))
                        {
                            // 入力チェック
                            if (pageTo > this._pageCount
                                || (pageFrom > pageTo
                                && (pageTo != 0)))
                            {
                                this.TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                            "正しい印刷範囲を設定してください。",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);
                                e.NextCtrl = this.tNedit_pageTo;
                                return;
                            }
                            //指定ページfrom設定しないの場合：１を設定する
                            if (pageFrom == 0)
                            {
                                pageFrom = 1;
                            }
                            //指定ページTo設定しないの場合：最大ページを設定する
                            if (pageTo == 0 && pageFrom != 0)
                            {
                                pageTo = this._pageCount;
                            }

                            if (this._toPageBe != pageTo)
                            {
                                //選択されたページを設定する
                                this._selectPageList.Clear();
                                for (int i = pageFrom; i <= pageTo; i++)
                                {
                                    this._selectPageList.Add(i - 1);
                                }
                                //画面選択状態変更
                                this.setPageChecked();

                                this._toPageBe = pageTo;
                            }
                        }
                        else
                        {
                            this._toPageBe = 0;
                        }
                        break;
                    }
                    #endregion
            }
        }
        #endregion
    }
}