using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率マスタ画面用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>NSユーザー改良要望一覧連番265の対応</br>
    /// <br>Note       : 掛率マスタ画面用のユーザー設定フォームクラスです。</br>
    /// <br>Programmer : caohh  連番265</br>
    /// <br>Date       : 2011/08/05</br>
    /// </remarks>
    public partial class PMKHN09302UB : Form
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// 掛率マスタ画面用ユーザー設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note       : 掛率マスタ画面用ユーザー設定クラスの初期処理を行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09302UB()
        {
            InitializeComponent();
            // 変数初期化
            _imageList16 = IconResourceManagement.ImageList16;
            _rateInputConstructionAcs = new RateInputConstructionAcs();

            this.tComboEditor1.SelectedIndex = this._rateInputConstructionAcs.SaveInfoDiv;

        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private RateInputConstructionAcs _rateInputConstructionAcs = null;
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/05</br>
        /// </remarks>
        private void PMKHN09302UB_Load(object sender, EventArgs e)
        {
            this.OK_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.OK_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.BEFORE;

            this.tComboEditor1.SelectedIndex = this._rateInputConstructionAcs.SaveInfoDiv;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/05</br>
        /// </remarks>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this._rateInputConstructionAcs.SaveInfoDiv = this.tComboEditor1.SelectedIndex;
            this._rateInputConstructionAcs.Serialize();
        }
        # endregion
    }
}