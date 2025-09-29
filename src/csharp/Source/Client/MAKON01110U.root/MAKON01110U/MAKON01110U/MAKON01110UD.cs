using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 伝票番号入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>UpDate</br>
    /// <br>2010/01/06 30434 工藤 MANTIS[14856] コントロールの初期値は固定とする</br>
    /// <br>2010/12/03 yangmj 障害改良対応</br>
    /// <br>Update Note: 拠点管理 送信済データチェック不具合対応</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2012/08/30</br>
    /// </remarks>
	public partial class MAKON01110UD : Form
	{
		public MAKON01110UD(int supplierFormal, int supplierSlipNo, bool canSupplierFormalChange, MAKON01320UA.ExtractSlipCdType extractSlipCdType)
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // DEL 2010/01/06 MANTIS対応[14856]：コントロールの初期値は固定とする ---------->>>>>
            // MEMO:以下のフィールド値によって伝票番号の種別、番号指定の種別の選択コントロールの初期値が変化するので、設定を廃止
            // this._supplierFormal = supplierFormal;
            // this._supplierSlipNo = supplierSlipNo;
            // DEL 2010/01/06 MANTIS対応[14856]：コントロールの初期値は固定とする ----------<<<<<

			this._canSupplierFormalChange = canSupplierFormalChange;
            this._extractSlipCdType = extractSlipCdType;
		}

        //----ADD 2010/12/03----->>>>>
        /// <summary>
        /// 仕入入力フォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <param name="supplierFormal">伝票番号の種別</param>
        /// <param name="supplierSlipNo">番号指定</param>
        /// <param name="canSupplierFormalChange">伝票番号の種別が選択するかどうか</param>
        /// <param name="extractSlipCdType">番号タイプ</param>
        /// <param name="type">伝票種別　０：入荷計上</param>
        public MAKON01110UD(int supplierFormal, int supplierSlipNo, bool canSupplierFormalChange, MAKON01320UA.ExtractSlipCdType extractSlipCdType, int type)
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            if (type == 0)
            {
                this._supplierFormal = supplierFormal;
            }

            this._canSupplierFormalChange = canSupplierFormalChange;
            this._extractSlipCdType = extractSlipCdType;
        }
        //----ADD 2010/12/03-----<<<<<

        public MAKON01110UD(int supplierFormal, string partySalesSlipNum, bool canSupplierFormalChange, MAKON01320UA.ExtractSlipCdType extractSlipCdType)
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

			this._supplierFormal = supplierFormal;
			this._partySalesSlipNum = partySalesSlipNum;
			this._canSupplierFormalChange = canSupplierFormalChange;
            this._extractSlipCdType = extractSlipCdType;
		}

		private ImageList _imageList16 = null;

		private StockSlipInputAcs _stockSlipInputAcs;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        // DEL 2010/01/06 MANTIS対応[14856]：コントロールの初期値は固定とする ---------->>>>>
        //private int _supplierFormal = 0;
        //private int _supplierSlipNo = 0;
        // DEL 2010/01/06 MANTIS対応[14856]：コントロールの初期値は固定とする ----------<<<<<
        // ADD 2010/01/06 MANTIS対応[14856]：コントロールの初期値は固定とする ---------->>>>>
        private readonly int _supplierFormal = 0;
        private readonly int _supplierSlipNo = 0;
        // ADD 2010/01/06 MANTIS対応[14856]：コントロールの初期値は固定とする ----------<<<<<

		private bool _canSupplierFormalChange = false;
		private string _partySalesSlipNum;
        private MAKON01320UA.ExtractSlipCdType _extractSlipCdType = MAKON01320UA.ExtractSlipCdType.All;

		private StockSlip _stockSlip = null;
        private StockSlip _baseStockSlip = null; // 2009.03.25
		private List<StockDetail> _stockDetailList = null;
		private List<StockDetail> _addUpSrcDetailList = null;
		private List<SalesTemp> _salesTempList = null;
		private PaymentSlp _paymentSlp = null;
        private List<PaymentDtl> _paymentDtlList = null;
		private List<StockWork> _stockWorkList = null;

		DialogResult _result = DialogResult.Cancel;

		#region ■Properties
        /// <summary>仕入データプロパティ</summary>
        internal StockSlip StockSlip
        {
            get { return _stockSlip; }
        }

        // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>補正前仕入データプロパティ</summary>
        internal StockSlip BaseStockSlip
        {
            get { return _baseStockSlip; }
        }
        // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>仕入明細データリストプロパティ</summary>
		internal List<StockDetail> StockDetailList
		{
			get { return _stockDetailList; }
		}

		/// <summary>計上元明細リストプロパティ</summary>
		internal List<StockDetail> AddUpSrcDetailList
		{
			get { return _addUpSrcDetailList; }
		}

		/// <summary>支払データプロパティ</summary>
		internal PaymentSlp PaymentSlp
		{
			get { return _paymentSlp; }
		}

        /// <summary>支払明細データリストプロパティ</summary>
        internal List<PaymentDtl> PaymentDtlList
        {
            get { return _paymentDtlList; }
        }

		/// <summary>売上データ(仕入同時計上)データリスト</summary>
		internal List<SalesTemp> SalesTempList
		{
			get { return _salesTempList; }
		}

		/// <summary>在庫ワークリスト</summary>
		internal List<StockWork> StockWorkList
		{
			get { return _stockWorkList; }
		}
		#endregion

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>true:保存成功 false:保存失敗</returns>
		private bool Save()
		{
			if (this.tNedit_SupplierSlipNo.GetInt() == 0)
			{
                int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);
                string msg = ( numberselect == 0 ) ? "伝票番号" : "仕入SEQ番号";
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    string.Format("{0}が入力されていません。", msg),
                    -1,
                    MessageBoxButtons.OK);

				return false;
			}
			else
			{
				StockSlip stockSlip;
                StockSlip baseStockSlip; // 2009.03.25
				List<StockDetail> stockDetailList;
				List<StockDetail> addUpSrcDetailList;
				PaymentSlp paymentSlp;
                List<PaymentDtl> paymentDtlList;
				List<SalesTemp> salesTempList;
				List<StockWork> stockWorkList;

				int supplierFormal = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SupplierFormal);

				// データリード処理
                //int status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormal, this.tNedit_SupplierSlipNo.GetInt(), false, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
                int status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormal, this.tNedit_SupplierSlipNo.GetInt(), false, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    stockSlip.PreStockDate = stockSlip.StockDate;   //ADD 2012/08/30
                    this._result = DialogResult.OK;
					this._stockSlip = stockSlip;
                    this._baseStockSlip = baseStockSlip; // 2009.03.25
					this._stockDetailList = stockDetailList;
					this._paymentSlp = paymentSlp;
                    this._paymentDtlList = paymentDtlList;
					this._addUpSrcDetailList = addUpSrcDetailList;
					this._salesTempList = salesTempList;
					this._stockWorkList = stockWorkList;
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"該当データが存在しません。",
						-1,
						MessageBoxButtons.OK);

					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 保存処理(相手先伝票番号用)
		/// </summary>
		/// <returns>true:保存成功 false:保存失敗</returns>
		private bool SavePartySalesSlipNum()
		{
			if (string.IsNullOrEmpty(this.tEdit_PartySaleSlipNum.Text))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"伝票番号が入力されていません。",
					-1,
					MessageBoxButtons.OK);

				return false;
			}
			else
			{
				List<StockSlip> stockSlipList;
				int supplierFormal = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SupplierFormal);

				int status = this._stockSlipInputAcs.ReadStockSlip(this._enterpriseCode, supplierFormal, this.tEdit_PartySaleSlipNum.Text, 1, out stockSlipList);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					StockSlip selectStockSlip;  
					// 複数件数あった場合は同一仕入伝票番号選択画面を起動
					if (( stockSlipList != null ) && ( stockSlipList.Count > 1 ))
					{
						MAKON01110UH stockSlipSelectGuide = new MAKON01110UH();

						DialogResult dialogResult = stockSlipSelectGuide.ShowDialog(this, supplierFormal, stockSlipList);
						if (( dialogResult == DialogResult.OK ))
						{
							selectStockSlip = stockSlipSelectGuide.SelectDataList[0];
						}
						else
						{
							return false;
						}
					}
					else
					{
						selectStockSlip = stockSlipList[0].Clone();
					}
					if (selectStockSlip != null)
					{
						StockSlip stockSlip;
                        StockSlip baseStockSlip; // 2009.03.25
						List<StockDetail> stockDetailList;
						List<StockDetail> addUpSrcDetailList;
						PaymentSlp paymentSlp;
                        List<PaymentDtl> paymentDtlList;
						List<SalesTemp> salesTempList;
						List<StockWork> stockWorkList;


						// データリード処理
                        //status = this._stockSlipInputAcs.ReadDBData(selectStockSlip.EnterpriseCode, selectStockSlip.SupplierFormal, selectStockSlip.SupplierSlipNo, false, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
                        status = this._stockSlipInputAcs.ReadDBData(selectStockSlip.EnterpriseCode, selectStockSlip.SupplierFormal, selectStockSlip.SupplierSlipNo, false, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
                            stockSlip.PreStockDate = stockSlip.StockDate;   //ADD 2012/08/30
                            this._result = DialogResult.OK;
							this._stockSlip = stockSlip;
                            this._baseStockSlip = baseStockSlip; // 2009.03.25
							this._stockDetailList = stockDetailList;
							this._paymentSlp = paymentSlp;
							this._addUpSrcDetailList = addUpSrcDetailList;
							this._salesTempList = salesTempList;
							this._stockWorkList = stockWorkList;
						}
						else
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"該当データが存在しません。",
								-1,
								MessageBoxButtons.OK);

							return false;
						}
					}
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"該当データが存在しません。",
						-1,
						MessageBoxButtons.OK);

					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/12/03 yangmj 修正呼び出し時の伝票番号入力ダイアログの入力制御の修正</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				// 仕入SEQ番号 ============================================ //
				case "tNedit_SupplierSlipNo":
				{
					switch (e.Key)
					{
						case Keys.Return:
						{
							int code = this.tNedit_SupplierSlipNo.GetInt();

							if (code != 0)
							{
								bool canSave = this.Save();

								if (canSave)
								{
									this.Close();
								}
								else
								{
									e.NextCtrl = e.PrevCtrl;
								}
							}
							break;
						}
					}

					break;
				}
			// 伝票番号 ============================================ //
			case "tEdit_PartySaleSlipNum":
				{
					switch (e.Key)
					{
						case Keys.Return:
							{
								string code = this.tEdit_PartySaleSlipNum.Text;

								if (!string.IsNullOrEmpty(code))
								{
									bool canSave = this.SavePartySalesSlipNum();

									if (canSave)
									{
										this.Close();
									}
									else
									{
										e.NextCtrl = e.PrevCtrl;
									}
								}
								break;
							}
					}

					break;
				}
            //----ADD 2010/12/03----->>>>>
            // 番号指定 ============================================ //
            case "tComboEditor_NumberSelect":
                {
                    int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);
                    this.SlipNumberDisplayChange(numberselect);
                    switch (e.Key)
                    {
                        case Keys.Return:
                            {
                                if (this.tComboEditor_SupplierFormal.Enabled == true)
                                {
                                    this.tComboEditor_SupplierFormal.Focus();
                                }
                                else if (this.panel_PartySalesSlipNum.Visible == true && this.tEdit_PartySaleSlipNum.Enabled == true)
                                {
                                    this.tEdit_PartySaleSlipNum.Focus();
                                }
                                else if (this.tNedit_SupplierSlipNo.Visible == true && this.tNedit_SupplierSlipNo.Enabled == true)
                                {
                                    this.tNedit_SupplierSlipNo.Focus();
                                }
                                break;
                            }
                    }
                    break;
                }
            //----ADD 2010/12/03-----<<<<<
			}
		}

		/// <summary>
		/// 確定ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Save_Click(object sender, EventArgs e)
		{
            int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);

            bool canSave = ( numberselect == 0 ) ? this.SavePartySalesSlipNum() : this.Save();

			if (canSave)
			{
				this.Close();
			}
			else
			{
                if (numberselect == 0)
                {
                    this.tNedit_SupplierSlipNo.Focus();
                }
                else
                {
                    this.tEdit_PartySaleSlipNum.Focus();
                }
			}
		}

		/// <summary>
		/// 閉じるボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// フォームクローズ後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAKON01110UD_FormClosed(object sender, FormClosedEventArgs e)
		{
			DialogResult = this._result;
		}

		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAKON01110UD_Load(object sender, EventArgs e)
		{
			this.uButton_SupplierSlipGuide.ImageList = this._imageList16;
			this.uButton_SupplierSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;

			this.uButton_PartySaleSlipNumGuide.ImageList = this._imageList16;
			this.uButton_PartySaleSlipNumGuide.Appearance.Image = (int)Size16_Index.STAR1;

			int numberSelectDefaultValue = ( this._supplierSlipNo == 0 ) ? 0 : 1;
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_NumberSelect, numberSelectDefaultValue, true);
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, this._supplierFormal, true);
			this.tNedit_SupplierSlipNo.SetInt(this._supplierSlipNo);
			this.tEdit_PartySaleSlipNum.Text = this._partySalesSlipNum;

			if (this._canSupplierFormalChange)
			{
				this.tComboEditor_SupplierFormal.Enabled = true;
			}
			else
			{
				this.tComboEditor_SupplierFormal.Enabled = false;
			}

			this.SlipNumberDisplayChange(numberSelectDefaultValue);

			this.timer_InitialSetFocus.Enabled = true;
		}

		/// <summary>
		/// 初期フォーカス設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;
			this.tNedit_SupplierSlipNo.Focus();
		}

		/// <summary>
		/// 仕入伝票検索ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_SupplierSlipGuide_Click(object sender, EventArgs e)
		{
            int supplierFormal = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SupplierFormal);

            MAKON01320UA supplierSlipGuide = new MAKON01320UA(this._stockSlipInputAcs.StockSlip.StockSectionCd, this._extractSlipCdType);
            supplierSlipGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
            supplierSlipGuide.SectionName= this._stockSlipInputAcs.StockSlip.StockSectionNm;

			supplierSlipGuide.TComboEditor_SupplierFormal = this.tComboEditor_SupplierFormal.Enabled;
            DialogResult result = supplierSlipGuide.ShowDialog(this, supplierFormal);

            if (result == DialogResult.OK)
            {
                SearchRetStockSlip searchRetStockSlip = supplierSlipGuide.searchRetStockSlip;

                if (searchRetStockSlip != null)
                {
                    this.tNedit_SupplierSlipNo.SetInt(searchRetStockSlip.SupplierSlipNo);
					this.tEdit_PartySaleSlipNum.Text = searchRetStockSlip.PartySaleSlipNum;

                    ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, searchRetStockSlip.SupplierFormal, true);

                    bool canSave = this.Save();

                    if (canSave)
                    {
                        this.Close();
                    }
                    else
                    {
						if (sender == this.uButton_SupplierSlipGuide)
						{
							this.tNedit_SupplierSlipNo.Focus();
						}
						else if (sender == this.uButton_PartySaleSlipNumGuide)
						{
							this.tEdit_PartySaleSlipNum.Focus();
						}
                    }
                }
            }
		}

		/// <summary>
		/// 番号指定コンボエディタ選択確定後発生イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tComboEditor_NumberSelect_SelectionChangeCommitted( object sender, EventArgs e )
		{
			int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);
			this.SlipNumberDisplayChange(numberselect);
		}

		/// <summary>
		/// 伝票番号表示変更
		/// </summary>
		/// <param name="numberSelect">番号指定</param>
		private void SlipNumberDisplayChange(int numberSelect)
		{
			switch (numberSelect)
			{
				case 1:
					{
						this.panel_PartySalesSlipNum.Visible = false;
						this.tNedit_SupplierSlipNo.Enabled = true;
						this.uButton_SupplierSlipGuide.Enabled = true;
						break;
					}
				default:
					{
						this.panel_PartySalesSlipNum.Visible = true;
						this.tNedit_SupplierSlipNo.Enabled = false;
						this.uButton_SupplierSlipGuide.Enabled = false;
						break;
					}
			}
		}

	
	}
}