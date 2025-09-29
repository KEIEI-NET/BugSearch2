using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 引用登録フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 引用登録フォームの設定を行います。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/11/28</br>
    /// </remarks>
    public partial class PMKEN09110UB : Form
    {
        #region ■ Const

        // プログラムID
        private const string ASSEMBLY_ID = "PMKEN09110U";
        
        #endregion ■ Const


        #region ■ Private Members

        // 企業コード
        private string _enterpriseCode;
        // 装備分類
        private Int32 _equipGanreCode;
        // 装備名
        private String _equipGanreName;

        private List<TBOSearchU> _allTBOSearchUList;

        private TBOSearchUAcs _tboSearchAcs;

        private string _prevEquipNameSt;
        private string _prevEquipNameEd;

        // 画面デザイン変更クラス
        private ControlScreenSkin _controlScreenSkin;

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// 引用登録フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 引用登録フォームクラスのインスタンスを作成します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        public PMKEN09110UB()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._tboSearchAcs = new TBOSearchUAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // 装備分類設定
            this.tComboEditor_EquipGenreCode.Items.Clear();
            this.tComboEditor_EquipGenreCode.Items.Add(1001, "バッテリー");
            this.tComboEditor_EquipGenreCode.Items.Add(1005, "タイヤ");
            this.tComboEditor_EquipGenreCode.Items.Add(1010, "オイル");
        }

        #endregion ■ Constructor


        #region ■ Public Property

        /// <summary>装備分類プロパティ</summary>
        /// <value>引用登録画面の呼び元から装備分類を取得します。</value>
        public Int32 EquipGanreCode
        {
            get
            {
                return this._equipGanreCode;
            }
            set
            {
                this._equipGanreCode = value;
            }
        }

        /// <summary>装備名プロパティ</summary>
        /// <value>引用登録画面の呼び元から装備名を取得します。</value>
        public String EquipGanreName
        {
            get
            {
                return this._equipGanreName;
            }
            set
            {
                this._equipGanreName = value;
            }
        }

        /// <summary>TBO検索リスト(ユーザー登録)プロパティ</summary>
        /// <value>引用登録画面の呼び元からTBO検索リスト(ユーザー登録)を取得します。</value>
        public List<TBOSearchU> AllTBOSearchUList
        {
            set
            {
                this._allTBOSearchUList = value;
            }
        }
        #endregion ■ Public Property


        #region ■ Private Methods

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面情報をクリアします。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tComboEditor_EquipGenreCode.Value = 0;
            this.tEdit_EquipGenreNameOrigin.Clear();
            this.tEdit_EquipGenreNameAfter.Clear();

            this._prevEquipNameSt = "";
            this._prevEquipNameEd = "";
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: コントロールサイズを設定します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tComboEditor_EquipGenreCode.Size = new Size(144, 24);
            this.tEdit_EquipGenreNameOrigin.Size = new Size(496, 24);
            this.tEdit_EquipGenreNameAfter.Size = new Size(496, 24);
        }

        /// <summary>
        /// 装備名ガイド表示処理
        /// </summary>
        /// <param name="equipName">装備名</param>
        /// <param name="equipGanreCode">装備分類</param>
        /// <param name="searchName">検索名(曖昧検索対応)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 装備名ガイドを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int ShowEquipNameGuide(out string equipName, int equipGanreCode, string searchName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            equipName = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                status = this._tboSearchAcs.ExecuteGuid(this._enterpriseCode, equipGanreCode, searchName, out equipName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                if (this.tComboEditor_EquipGenreCode.Value == null)
                {
                    errMsg = "装備分類を選択してください。";
                    this.tComboEditor_EquipGenreCode.Focus();
                    return (false);
                }

                if (this.tEdit_EquipGenreNameOrigin.DataText.Trim() == "")
                {
                    errMsg = "引用元の装備名を入力してください。";
                    this.tEdit_EquipGenreNameOrigin.Focus();
                    return (false);
                }

                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
                string equipName = this.tEdit_EquipGenreNameOrigin.DataText.Trim();

                List<GoodsUnitData> goodsUnitDataList;
                int status = this._tboSearchAcs.Search(out goodsUnitDataList,
                                                       this._enterpriseCode,
                                                       LoginInfoAcquisition.Employee.BelongSectionCode,
                                                       equipGanreCode,
                                                       equipName);
                if ((status != 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                {
                    errMsg = "マスタに登録されていません。";
                    this.tEdit_EquipGenreNameOrigin.Focus();
                    return (false);
                }

                if (this.tEdit_EquipGenreNameAfter.DataText.Trim() == "")
                {
                    errMsg = "引用先の装備名を入力してください。";
                    this.tEdit_EquipGenreNameAfter.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int SaveProc()
        {
            //--------------------------------------------------
            // 入力チェック
            //--------------------------------------------------
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (-1);
            }

            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
            string equipNameOrigin = this.tEdit_EquipGenreNameOrigin.DataText.Trim();
            string equipNameAfter = this.tEdit_EquipGenreNameAfter.DataText.Trim();

            //--------------------------------------------------
            // 引用先の商品連結データリスト取得
            //--------------------------------------------------
            List<GoodsUnitData> goodsUnitDataListAfter;
            int status = this._tboSearchAcs.Search(out goodsUnitDataListAfter,
                                                   this._enterpriseCode,
                                                   LoginInfoAcquisition.Employee.BelongSectionCode,
                                                   equipGanreCode,
                                                   equipNameAfter);

            if ((status == 0) && (goodsUnitDataListAfter.Count > 0))
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                  "登録先に明細が存在します。" + "\r\n" + "\r\n" + "登録してもよろしいですか？",
                                                  0,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1);
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            break;
                        }
                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            return (1);
                        }
                }
            }

            //--------------------------------------------------
            // 引用元の商品連結データリスト取得(ユーザー、提供)
            //--------------------------------------------------
            List<GoodsUnitData> goodsUnitDataListOrigin;
            status = this._tboSearchAcs.Search(out goodsUnitDataListOrigin,
                                                   this._enterpriseCode,
                                                   LoginInfoAcquisition.Employee.BelongSectionCode,
                                                   equipGanreCode,
                                                   equipNameOrigin);

            if ((status != 0) || (goodsUnitDataListOrigin == null) || (goodsUnitDataListOrigin.Count == 0))
            {
                this.DialogResult = DialogResult.Cancel;
                return (1);
            }

            //--------------------------------------------------
            // TBO検索マスタリスト取得(ユーザー登録分)
            //--------------------------------------------------
            // 引用先
            List<TBOSearchU> tboSearchUListAfter = FindUserTBOSearchUList(equipGanreCode, equipNameAfter);

            // 引用元
            List<TBOSearchU> tboSearchUListOrigin = FindUserTBOSearchUList(equipGanreCode, equipNameOrigin);

            //--------------------------------------------------
            // TBO検索マスタリスト取得(提供分)
            //--------------------------------------------------
            // 引用先
            List<TBOSearchU> offerTboSearchUListAfter = new List<TBOSearchU>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataListAfter)
            {
                int index = tboSearchUListAfter.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index < 0)
                {
                    TBOSearchU newTBOSearchU = new TBOSearchU();
                    newTBOSearchU.EnterpriseCode = this._enterpriseCode;
                    newTBOSearchU.BLGoodsCode = goodsUnitData.BLGoodsCode;
                    newTBOSearchU.EquipGenreCode = equipGanreCode;
                    newTBOSearchU.EquipName = equipNameAfter;
                    newTBOSearchU.CarInfoJoinDispOrder = goodsUnitData.DisplayOrder;
                    newTBOSearchU.JoinDestMakerCd = goodsUnitData.GoodsMakerCd;
                    newTBOSearchU.JoinDestMakerName = goodsUnitData.MakerName;
                    newTBOSearchU.JoinDestPartsNo = goodsUnitData.GoodsNo;
                    newTBOSearchU.JoinDestGoodsName = goodsUnitData.GoodsName;
                    newTBOSearchU.JoinQty = goodsUnitData.JoinQty;
                    newTBOSearchU.EquipSpecialNote = goodsUnitData.JoinSpecialNote;

                    offerTboSearchUListAfter.Add(newTBOSearchU);
                }
            }

            // 引用元
            List<TBOSearchU> offerTboSearchUListOrigin = new List<TBOSearchU>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataListOrigin)
            {
                int index = tboSearchUListOrigin.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index < 0)
                {
                    TBOSearchU newTBOSearchU = new TBOSearchU();
                    newTBOSearchU.EnterpriseCode = this._enterpriseCode;
                    newTBOSearchU.BLGoodsCode = goodsUnitData.BLGoodsCode;
                    newTBOSearchU.EquipGenreCode = equipGanreCode;
                    newTBOSearchU.EquipName = equipNameAfter;
                    newTBOSearchU.CarInfoJoinDispOrder = goodsUnitData.DisplayOrder;
                    newTBOSearchU.JoinDestMakerCd = goodsUnitData.GoodsMakerCd;
                    newTBOSearchU.JoinDestMakerName = goodsUnitData.MakerName;
                    newTBOSearchU.JoinDestPartsNo = goodsUnitData.GoodsNo;
                    newTBOSearchU.JoinDestGoodsName = goodsUnitData.GoodsName;
                    newTBOSearchU.JoinQty = goodsUnitData.JoinQty;
                    newTBOSearchU.EquipSpecialNote = goodsUnitData.JoinSpecialNote;

                    offerTboSearchUListOrigin.Add(newTBOSearchU);
                }
            }

            //--------------------------------------------------
            // 保存リスト作成
            //--------------------------------------------------
            List<TBOSearchU> saveTBOList = new List<TBOSearchU>();

            // 引用先のTBOマスタリスト(ユーザー)を保存リストに追加
            foreach (TBOSearchU tboSearchU in tboSearchUListAfter)
            {
                saveTBOList.Add(tboSearchU.Clone());
            }

            // 引用先のTBOマスタリスト(提供)を保存リストに追加
            foreach (TBOSearchU tboSearchU in offerTboSearchUListAfter)
            {
                saveTBOList.Add(tboSearchU.Clone());
            }

            // 引用元のTBOマスタリスト(ユーザー)を保存リストに追加・上書き
            foreach (TBOSearchU tboSearchU in tboSearchUListOrigin)
            {
                int index = saveTBOList.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == tboSearchU.JoinDestMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index >= 0)
                {
                    // 上書き
                    saveTBOList[index].CarInfoJoinDispOrder = tboSearchU.CarInfoJoinDispOrder;
                    saveTBOList[index].JoinQty = tboSearchU.JoinQty;
                    saveTBOList[index].EquipSpecialNote = tboSearchU.EquipSpecialNote;
                }
                else
                {
                    // 新規追加
                    tboSearchU.EquipName = equipNameAfter;
                    saveTBOList.Add(tboSearchU.Clone());
                }
            }

            // 引用元のTBOマスタリスト(提供)を保存リストに追加・上書き
            foreach (TBOSearchU tboSearchU in offerTboSearchUListOrigin)
            {
                int index = saveTBOList.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == tboSearchU.JoinDestMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index >= 0)
                {
                    // 上書き
                    saveTBOList[index].CarInfoJoinDispOrder = tboSearchU.CarInfoJoinDispOrder;
                    saveTBOList[index].JoinQty = tboSearchU.JoinQty;
                    saveTBOList[index].EquipSpecialNote = tboSearchU.EquipSpecialNote;
                }
                else
                {
                    // 新規追加
                    tboSearchU.EquipName = equipNameAfter;
                    saveTBOList.Add(tboSearchU.Clone());
                }
            }

            //--------------------------------------------------
            // 商品存在チェック
            //--------------------------------------------------
            ArrayList saveGoodsList = new ArrayList();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataListOrigin)
            {
                // 商品マスタに未登録の場合
                if (goodsUnitData.OfferKubun >= 3)
                {
                    goodsUnitData.OfferDate = DateTime.MinValue;
                    if (goodsUnitData.GoodsPriceList != null)
                    {
                        foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                        {
                            price.OfferDate = DateTime.MinValue;
                        }
                    }

                    saveGoodsList.Add(goodsUnitData.Clone());
                }
            }

            // 保存リストをArrayListに変換
            ArrayList saveList = new ArrayList();
            foreach (TBOSearchU tboSearchU in saveTBOList)
            {
                saveList.Add(tboSearchU.Clone());
            }

            // 保存処理
            status = this._tboSearchAcs.WriteRelation(saveList, saveGoodsList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 登録完了ダイアログ表示
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        this.DialogResult = DialogResult.OK;
                        this._equipGanreCode = equipGanreCode;
                        this._equipGanreName = equipNameAfter;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
                default:
                    {
                        // 登録失敗
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "登録に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// TBO検索マスタリスト取得処理(ユーザー)
        /// </summary>
        /// <param name="equipGanreCode">装備分類</param>
        /// <param name="equipName">装備名</param>
        /// <returns>TBO検索マスタリスト(ユーザー)</returns>
        /// <remarks>
        /// <br>Note       : TBO検索マスタリスト(ユーザー)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private List<TBOSearchU> FindUserTBOSearchUList(int equipGanreCode, string equipName)
        {
            // ユーザーデータ取得
            List<TBOSearchU> userTBOSearchUList = this._allTBOSearchUList.FindAll(delegate(TBOSearchU target)
            {
                if ((target.EquipGenreCode == equipGanreCode) && (target.EquipName.Trim() == equipName.Trim()))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (userTBOSearchUList == null)
            {
                userTBOSearchUList = new List<TBOSearchU>();
            }

            return userTBOSearchUList;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "既に他端末より更新されています。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "既に他端末より削除されています。",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        #region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._tboSearchAcs,	            // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームをロードした時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UB_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            SetControlSize();

            // アイコン設定
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.EquipGenreGuideOrign_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EquipGenreGuideAfter_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期化
            ClearScreen();

            // 装備分類・装備名を設定
            this.tComboEditor_EquipGenreCode.Value = this._equipGanreCode;
            this.tEdit_EquipGenreNameOrigin.DataText = this._equipGanreName.Trim();
            this._prevEquipNameSt = this._equipGanreName.Trim();

            // フォーカス設定
            this.tComboEditor_EquipGenreCode.Focus();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 装備名ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void EquipGenreGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            string equipName;
            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

            int status = ShowEquipNameGuide(out equipName, equipGanreCode, "*");
            if (status == 0)
            {
                // 装備名設定
                if (uButton.Name == "EquipGenreGuideOrign_Button")
                {
                    // 引用元
                    this.tEdit_EquipGenreNameOrigin.DataText = equipName.Trim();
                    this._prevEquipNameSt = equipName.Trim();
                }
                else
                {
                    // 引用先
                    this.tEdit_EquipGenreNameAfter.DataText = equipName.Trim();
                    this._prevEquipNameEd = equipName.Trim();
                }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            int status = SaveProc();

            // 入力エラーの場合
            if (status == -1)
            {
                return;
            }

            this.Close();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 閉じるボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォーカスが移動した時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 装備名(開始)
                case "tEdit_EquipGenreNameOrigin":
                    {
                        string equipName = this.tEdit_EquipGenreNameOrigin.DataText.Trim();

                        if (equipName != "")
                        {
                            if (equipName != this._prevEquipNameSt.Trim())
                            {
                                // 装備分類コード取得
                                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

                                // 曖昧検索
                                if (equipName.Substring(equipName.Length - 1) == "*")
                                {
                                    string retName;

                                    // 装備分類ガイド表示
                                    int status = ShowEquipNameGuide(out retName, equipGanreCode, equipName);
                                    if (status == 0)
                                    {
                                        this.tEdit_EquipGenreNameOrigin.DataText = retName.Trim();
                                        this._prevEquipNameSt = retName.Trim();
                                    }
                                }
                                else
                                {
                                    this._prevEquipNameSt = equipName;
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (equipName != "")
                                {
                                    e.NextCtrl = this.tEdit_EquipGenreNameAfter;
                                }
                            }
                        }
                        break;
                    }
                // 装備名(開始)
                case "tEdit_EquipGenreNameAfter":
                    {
                        string equipName = this.tEdit_EquipGenreNameAfter.DataText.Trim();

                        if (equipName != "")
                        {
                            if (equipName != this._prevEquipNameEd.Trim())
                            {
                                // 装備分類コード取得
                                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

                                // 曖昧検索
                                if (equipName.Substring(equipName.Length - 1) == "*")
                                {
                                    string retName;

                                    // 装備分類ガイド表示
                                    int status = ShowEquipNameGuide(out retName, equipGanreCode, equipName);
                                    if (status == 0)
                                    {
                                        this.tEdit_EquipGenreNameAfter.DataText = retName.Trim();
                                        this._prevEquipNameEd = retName.Trim();
                                    }
                                }
                                else
                                {
                                    this._prevEquipNameEd = equipName;
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (equipName != "")
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                            }
                        }
                        break;
                    }
            }
        }
        #endregion ■ Control Events
    }
}