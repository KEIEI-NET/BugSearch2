using System;
using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using System.Text.RegularExpressions;

using Broadleaf.Library.Windows.Forms; 
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// e-mail文章作成フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: e-mail文章の作成を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br> 
    ///                   IMailEditorを実装しています。
    /// <br>Programmer  : 980035 金沢　貞義</br>
    /// <br>Date        : 2010.05.25</br>
    /// </remarks>
    public partial class PMKHN07504UA : Form
    {
        #region Constractor
        /// <summary>
        /// e-mail文章作成フォームクラスコンストラクター
        /// </summary> 
        /// <remarks>
        /// <br>Note　　　 : e-mail文章作成クラスの変数を初期化します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        public PMKHN07504UA()
        {
            InitializeComponent();

            #region 共通

            //企業コード取得
			//this._enterpriseCode			= LoginInfoAcquisition.EnterpriseCode;
             //初期化
            this._mailInfoBase				= new MailInfoBase(MailServiceInfoCreateMode.Default);
            this._mailFactoryBase           = new MailFactoryBase(MailServiceInfoCreateMode.Default); 
           
            #endregion

            MailFactoryBase mailFactoryBase = new MailFactoryBase(MailServiceInfoCreateMode.Default);
            _mailSender = mailFactoryBase.GetMailSenderInterface();
        }
        #endregion
        
        #region Private Member

        #region Const
      
        //PGID
        private const string PGID               = "PMKHN07504U";
        //最大入力文字数
        private int maxCountPc                  = 0;
        //データが無い場合用
        private const int MAXCOUNT_PC           = 30000;
        private const int MAXCOUNT_MOBILE       = 500;

        //DM種類
        private const string DMKIND_MAIL    　  = "メール文書";
        private const string DMKIND_SIGNATURE   = "署名";
                                                
        //エディタバージョン(設定方法が決まるまで固定)
        private const string EDITERVERTION      = ".NS MailService 1.1.1.0";
        //DataSetのカラム名
        private const string MAILDOCUMENTCNTS   = "MailDocumentCnts";
        private const string MAILTITLE_TITLE    = "MailTitle";
        //ToolBarの名称
        private const string TOOLBARMENU_END    = "End";
        private const string TOOLBARMENU_SETUP  = "Tool_Setup";
        private const string TOOLBARMENU_SEND   = "Tool_Send";
             
        #endregion 

        #region Member
       
        #region 共通

        //private string			_enterpriseCode;

        private int _sizeDifferenceAddress = 800 - 647;
        private int _sizeDifferenceSubject = 800 - 685;
        private int _sizeDifferenceQRCode = 800 - 647;

        //メールサービス関連 Infomation Base クラス
        MailInfoBase _mailInfoBase ;
        //メールサービス オブジェクト管理クラス 
        MailFactoryBase _mailFactoryBase ; 
 
        private Control _control;

        //メールアドレス保存用
        private Dictionary<string, string> mailAddressList = new Dictionary<string, string>();
        private Dictionary<string, string> ccAddressList = new Dictionary<string, string>();

        //ユーザー設定画面
        private PMKHN07504UB _userSetupFrm;
        private bool _defaultStartFlg;

        private MailInfoSetting _mailInfoSetting = null;

        private AnalysisMailSettingAcs _analysisMailSettingAcs = null;
        private MailDefaultDataAcs _mailDefaultDataAcs = null;
        private MailDefaultHeader _mailDefaultHeader = null;
        private MailDefaultCar _mailDefaultCar = null;
        private List<MailDefaultDetail> _mailDefaultDetailList = null;

        private IMailSender _mailSender;

        // メール送信ボタン押下許可フラグ
        private bool _isClickSendMail = true;

        // 項目保存用
        private string _address_tEdit = null;
        private string _carbonCopy_tEdit = null;

        #endregion

        #endregion

        #endregion

        #region Delegate
        /// <summary>
        /// 起動パラメータ取得デリゲート
        /// </summary>
        /// <param name="param"></param>
        public delegate void GetStartParameterEventHandler(out string param);
        #endregion

        #region Events
        /// <summary>
        /// 起動パラメータ取得デリゲート
        /// </summary>
        public GetStartParameterEventHandler GetStartParameterEvent;
        #endregion

        #region IMailEditor メンバ

        ///// <summary>
        ///// エディタ起動処理
        ///// </summary>  
        ///// <remarks>
        ///// <br>Note　　　 : モードに応じてエディタを起動します</br>
        ///// <br>Programmer : 980035 金沢　貞義</br>
        ///// <br>Date       : 2010.05.25</br>
        ///// </remarks>
        //public bool ShowEditor()
        //{           
        //    bool result ;
        //    try
        //    {
                
        //        //とりあえず新規モードで起動
        //        ScreenPermissionControl(0);
        //        this.ShowDialog();
        //        result = true;
        //        return result;
        //    }
        //    catch(Exception)
        //    {
        //        result = false;
        //        return result;
        //    }                                                    
        //}

        /// <summary>
		/// エディタVertionプロパティ
		/// </summary>
		/// <returns>EDITERVERTION</returns>
		/// <remarks>
		/// <br>Note       : エディタのバージョンを返します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
		/// </remarks>
        public string Version
        {
            get { return EDITERVERTION; }
        }

        #endregion

        # region Main
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN07504UA());
		}
		# endregion

     	#region Events

		#endregion

        #region Public Methods

		#endregion

        #region Private Method

        #region 画面初期設定処理

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 画面構築
            this.QRCodePath_ultraLabel.Visible = false;
            this.QRCodePath_tEdit.Visible = false;
            this.uButton_QRCodePath.Visible = false;

            //設定内容読込
            this._analysisMailSettingAcs = new AnalysisMailSettingAcs();

            // 起動パラメータ取得
            string param;
            this.GetStartParameterDelegateCall(out param);

            //受け渡し情報読込
            this._mailDefaultDataAcs = new MailDefaultDataAcs();
            this._mailDefaultHeader = new MailDefaultHeader();
            this._mailDefaultCar = new MailDefaultCar();
            this._mailDefaultDetailList = new List<MailDefaultDetail>();
            this._defaultStartFlg = true;
            if (!string.IsNullOrEmpty(param))
            {
                // 初期値ファイルが存在するか？
                int st = _mailDefaultDataAcs.Read(param, out _mailDefaultHeader, out _mailDefaultCar, out _mailDefaultDetailList);
                if (st == 0)
                {
                    // 初期値ファイル削除
                    _mailDefaultDataAcs.Delete(param);
                }
                else
                {
                    // 初期値ファイルが存在しない
                    _defaultStartFlg = false;
                }
            }
            else
            {
                // 初期値ファイルのパスが無い
                _defaultStartFlg = false;
            }
        }

        #endregion

        #region 画面再構築処理
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>           : 画面の内容を内部変数に保持します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            #region ヘッダ部制御
            // 宛名初期値
            switch ((int)this._analysisMailSettingAcs.AddressInitialDivValue)
            {
                case 1:     // 売伝から表示
                    {
                        if (_defaultStartFlg)
                        {
                            //if (_mailDefaultHeader.SalesEmployeeNm != string.Empty)
                            //{
                            //    // データファイルの名称を表示
                            //    this.Address_tEdit.Text = _mailDefaultHeader.SalesEmployeeNm;
                            //}
                            //else if (_mailDefaultHeader.SalesEmployeeCd.Trim() != string.Empty)
                            if (_mailDefaultHeader.SalesEmployeeCd.Trim() != string.Empty)
                            {
                                // データファイルのコードから名称を取得
                                Employee employee;
                                EmployeeDtl employeeDtl;
                                int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, _mailDefaultHeader.SalesEmployeeCd.Trim());

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this.mailAddressList.Clear();
                                    this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                    //if (employeeDtl.MailAddress2 == string.Empty)
                                    //{
                                    //    this.Address_tEdit.Text = employee.Name.Trim() + "<メールアドレス未設定>";
                                    //}
                                    //else
                                    //{
                                    //    this.Address_tEdit.Text = employee.Name.Trim() + "<" + employeeDtl.MailAddress2 + ">";
                                    //}
                                    this.Address_tEdit.Text = employee.Name.Trim();
                                }
                            }
                            else
                            {
                                // コード未入力
                                this.Address_tEdit.Text = string.Empty;
                            }
                        }
                        else
                        {
                            // データファイルが存在しない
                            this.Address_tEdit.Text = string.Empty;
                        }
                        break;
                    }
                case 2:     // 任意設定から表示
                    {
                        if (this._analysisMailSettingAcs.AddressInitialCodeValue.Trim() != string.Empty)
                        {
                            // 従業員詳細マスタ読込
                            Employee employee;
                            EmployeeDtl employeeDtl;
                            int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, this._analysisMailSettingAcs.AddressInitialCodeValue.Trim());

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.mailAddressList.Clear();
                                this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                //if (employeeDtl.MailAddress2 == string.Empty)
                                //{
                                //    this.Address_tEdit.Text = employee.Name.Trim() + "<メールアドレス未設定>";
                                //}
                                //else
                                //{
                                //    this.Address_tEdit.Text = employee.Name.Trim() + "<" + employeeDtl.MailAddress2 + ">";
                                //}
                                this.Address_tEdit.Text = employee.Name.Trim();
                            }
                        }
                        break;
                    }
                default:    //  非表示
                    {
                        this.Address_tEdit.Text = string.Empty;
                        break;
                    }
            }

            // 件名初期値
            if ((int)this._analysisMailSettingAcs.SubjectInitialDivValue == 1)
            {
                this.Subject_tEdit.Text = (string)this._analysisMailSettingAcs.SubjectInitialValue;
            }
            else if (_defaultStartFlg)
            {
                //this.Subject_tEdit.Text = "テスト件名【得意先】";
                if (_mailDefaultHeader.CustomerSnm != string.Empty)
                {
                    // データファイルの名称を表示
                    this.Subject_tEdit.Text = _mailDefaultHeader.CustomerSnm;
                }
                else
                {
                    // 名称未入力
                    this.Subject_tEdit.Text = string.Empty;
                }
            }
            else
            {
                // データファイルが存在しない
                this.Subject_tEdit.Text = string.Empty;
            }

            // CC初期値
            if ((bool)this._analysisMailSettingAcs.CompanyCCDivValue == true)
            {
                this.ccAddressList.Clear();
                this.ccAddressList.Add("【自社】", _mailInfoSetting.MailAddress);
                //this.CarbonCopy_tEdit.Text = "【自社】<" + _mailInfoSetting.MailAddress + ">";
                this.CarbonCopy_tEdit.Text = "【自社】";

                this.CarbonCopy_tEdit.Enabled = false;
                this.uButton_CarbonCopyGuide.Visible = false;
            }
            else
            {
                this.CarbonCopy_tEdit.Enabled = true;
                this.uButton_CarbonCopyGuide.Visible = true;
            }

            // QRコード初期値
            if ((_defaultStartFlg) && (_mailDefaultHeader.Mode == 1))
            {
                this.QRCodePath_tEdit.Text = _mailDefaultHeader.AttachedFilePath;
            }
            if (_mailDefaultHeader.Mode == 1)
            {
                this.QRCodePath_ultraLabel.Visible = true;
                this.QRCodePath_tEdit.Visible = true;
                this.uButton_QRCodePath.Visible = true;
                //this.EMailInfo_panel.Height = 135;
                //this.PcEditor_richTextBox.Height = 341;
            }
            else
            {
                //this.EMailInfo_panel.Height = 105;
                //this.PcEditor_richTextBox.Height = 371;
            }

            #endregion

            #region メール本文編集
            string mailText = string.Empty;
            if (_defaultStartFlg)
            {
                #region 伝票ヘッダ情報
                // 得意先
                if ((bool)this._analysisMailSettingAcs.CustomerDiv == true)
                {
                    mailText = mailText + "得意先:" + _mailDefaultHeader.CustomerSnm + "\r\n";
                }
                // 伝票番号
                if ((bool)this._analysisMailSettingAcs.SalesSlipNumDiv == true)
                {
                    mailText = mailText + "伝票番号:" + _mailDefaultHeader.SalesSlipNum + "\r\n";
                }
                // 伝票種別
                if ((bool)this._analysisMailSettingAcs.AcptAnOdrStatusDiv == true)
                {
                    switch (_mailDefaultHeader.AcptAnOdrStatus)
                    {
                        case 10:
                            {
                                if (_mailDefaultHeader.EstimateDivide == 2)
                                {
                                    mailText = mailText + "種別:単価見積\r\n";
                                }
                                else if (_mailDefaultHeader.EstimateDivide == 3)
                                {
                                    mailText = mailText + "種別:検索見積\r\n";
                                }
                                else
                                {
                                    mailText = mailText + "種別:見積\r\n";
                                }
                                break;
                            }
                        case 20:
                            {
                                mailText = mailText + "種別:受注\r\n";
                                break;
                            }
                        case 30:
                            {
                                mailText = mailText + "種別:売上\r\n";
                                break;
                            }
                        case 40:
                            {
                                mailText = mailText + "種別:貸出\r\n";
                                break;
                            }
                    }
                }
                // 売上日付
                if ((bool)this._analysisMailSettingAcs.SalesDateDiv == true)
                {
                    mailText = mailText + "売上日:" + _mailDefaultHeader.SalesDate.ToShortDateString() + "\r\n";
                }
                #endregion

                #region 伝票車輌情報
                // 類別
                if ((bool)this._analysisMailSettingAcs.CategoryNoDiv == true)
                {
                    mailText = mailText + "類別:" + _mailDefaultCar.ModelDesignationNo.ToString("00000") + "-" + _mailDefaultCar.CategoryNo.ToString("0000") + "\r\n";
                }
                // 型式
                if ((bool)this._analysisMailSettingAcs.FullModelDiv == true)
                {
                    mailText = mailText + "型式:" + _mailDefaultCar.FullModel + "\r\n";
                }
                // 車種
                if ((bool)this._analysisMailSettingAcs.ModelCodeDiv == true)
                {
                    mailText = mailText + "車種:" + _mailDefaultCar.ModelFullName + "\r\n";
                }
                #endregion

                #region 伝票明細情報
                if (((bool)this._analysisMailSettingAcs.BLGoodsCodeDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.GoodsNameDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.GoodsNoDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.GoodsMakerDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.ShipmentCntDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.PriceDiv == true) ||
                    ((bool)this._analysisMailSettingAcs.SalesMoneyDiv == true))
                {
                    for (int ix = 0; ix < this._mailDefaultDetailList.Count; ix++)
                    {
                        MailDefaultDetail mailDefaultDetail = _mailDefaultDetailList[ix];
                        mailText = mailText + "\r\n";

                        // BLコード
                        if ((bool)this._analysisMailSettingAcs.BLGoodsCodeDiv == true)
                        {
                            mailText = mailText + "BLコード:" + mailDefaultDetail.BLGoodsCode.ToString("00000") + "\r\n";
                        }
                        // 品名
                        if ((bool)this._analysisMailSettingAcs.GoodsNameDiv == true)
                        {
                            mailText = mailText + "品名:" + mailDefaultDetail.GoodsName + "\r\n";
                        }
                        // 品番
                        if ((bool)this._analysisMailSettingAcs.GoodsNoDiv == true)
                        {
                            mailText = mailText + "品番:" + mailDefaultDetail.GoodsNo + "\r\n";
                        }
                        // メーカー
                        if ((bool)this._analysisMailSettingAcs.GoodsMakerDiv == true)
                        {
                            mailText = mailText + "メーカー:" + mailDefaultDetail.MakerName + "\r\n";
                        }
                        // 出荷数
                        if ((bool)this._analysisMailSettingAcs.ShipmentCntDiv == true)
                        {
                            mailText = mailText + "出荷数:" + mailDefaultDetail.ShipmentCnt.ToString() + "\r\n";
                        }
                        // 標準価格
                        if ((bool)this._analysisMailSettingAcs.PriceDiv == true)
                        {
                            mailText = mailText + "標準価格:" + mailDefaultDetail.ListPriceTaxExcFl.ToString() + "\r\n";
                        }
                        // 売単価
                        if ((bool)this._analysisMailSettingAcs.SalesMoneyDiv == true)
                        {
                            mailText = mailText + "売単価:" + mailDefaultDetail.SalesUnPrcTaxExcFl.ToString() + "\r\n";
                        }
                    }
                }
                #endregion
            }

            // 署名初期値
            if ((bool)this._analysisMailSettingAcs.SignatureDisplayDivValue == true)
            {
                string signatureText = (string)this._analysisMailSettingAcs.SignatureInitialValue;
                this.PcEditor_richTextBox.Text = mailText + "\r\n" + signatureText;
            }
            #endregion

            // 入力項目の保存
            this._address_tEdit = this.Address_tEdit.Text.Trim();
            this._carbonCopy_tEdit = this.CarbonCopy_tEdit.Text.Trim();

            // メール文書設定セット
            GetMailDocSet(this._analysisMailSettingAcs);

            //StatusBarに入力されている文字数を表示する
            SetWordsCountToUltraStatusBar(this.PcEditor_richTextBox);

        }
        #endregion

        #region 入力文字数表示処理
        
        /// <summary>
        /// 入力文字数表示処理
        /// </summary> 
        /// <param name="richTextBox">richTextBoxコントロール</param>
        /// <remarks>
        /// <br>Note　　　 : 入力された文字数をultraStatusBarに表示します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void SetWordsCountToUltraStatusBar(RichTextBox richTextBox)
        {
            int length = 0;

            //文字数を取得する場合        
            length = richTextBox.Text.Length;

            string msg = String.Format("入力文字数　"+"{0}/{1}",length,maxCountPc);
            this.ultraStatusBar1.SetStatusBarText(richTextBox, msg);
            this.ultraStatusBar1.Text = ultraStatusBar1.GetStatusBarText(richTextBox);
            //入力制限チェック
        }

        #endregion

        #region メール文書設定処理
        /// <summary>
        /// メール文書設定処理
        /// </summary>
        /// <param name="mailDocSet">メール設定情報</param>
        /// <remarks>
        /// <br>Note       : エディタの入力制御設定を行います </br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void GetMailDocSet(AnalysisMailSettingAcs mailDocSet)
        {
            //一行辺りの最大入力文字数PC用(半角)
            float limitChar_Pc ;
            //一行辺りの最大入力文字数MOBILE用(半角)
            //float limitChar_Mobile;

            //MSゴシック11.25で一文字あたりに必要なマージン
            float margin = 8.158F;
            
            #region PC

            //メール文書最大サイズ、行最大サイズをセットする。
            //0の場合は規定値を入れる
            if (mailDocSet.MailDocMaxSizeValue == 0)
            {
                //リテラル(500文字)
                //this.maxCountPc = MAXCOUNT_PC;
                this.maxCountPc = MAXCOUNT_MOBILE;
                this.PcEditor_richTextBox.MaxLength     =  this.maxCountPc;         //PC用               
            }
            else
            {
                //最大入力文字数を取得する
                this.maxCountPc = mailDocSet.MailDocMaxSizeValue;
                this.PcEditor_richTextBox.MaxLength     =  this.maxCountPc;      //PC用
            }
            
            //一行辺りの最大入力文字数PC用(半角)
            if (mailDocSet.MailLineStrMaxSizeValue == 0)
            {
                ////リテラル(72文字)
                //limitChar_Pc     = 72F;  //PC用              
                //リテラル(24文字)
                limitChar_Pc = 24F;  //携帯用     
            }
            else
            {
                //一行辺りの文字数を取得
                limitChar_Pc = (float)mailDocSet.MailLineStrMaxSizeValue;   //PC用
            }

            //余白設定(PC)
            if((int)limitChar_Pc < 57)
            {               
                this.PcEditor_richTextBox.RightMargin = (int)(margin*limitChar_Pc);
            }
            else if((int)limitChar_Pc == 57)
            {
                //57の時はうまく行かないので。。。             
                this.PcEditor_richTextBox.RightMargin = (int)(margin*limitChar_Pc - margin);
            }
            else
            {
                //56をこえると約1margin分誤差がでるので
                this.PcEditor_richTextBox.RightMargin = (int)(margin*limitChar_Pc - margin);
            }

            #endregion
        }
        #endregion

        #region 機種依存文字チェック
        /// <summary>
        /// 機種依存文字チェック処理
        /// </summary>
        /// <param name="text">チェック対象の文章</param>       
        /// <param name="halfKanaIndexes">半角ｶﾅがあるindex</param>
        /// <param name="addictIndexes">機種依存文字があるindex</param>      
        /// <returns>result(True:正常 false:異常)</returns>
        /// <remarks>
        /// <br>Note　　　 : 機種依存文字のチェックを行います</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2006.10.02</br>
        /// </remarks>
        private bool CheckText(string text, ref int[] halfKanaIndexes, ref int[] addictIndexes)
        {
            bool result = true;
            byte[] byteArray;

            byteArray = TStrConv.UnicodeToSJis(text);

            List<int> halfKanaIndexList = new List<int>();
            List<int> addictIndexList = new List<int>();

            int textIndex = 0;
            int ix = 0;
            while (ix < byteArray.Length)
            {
                switch (ByteType(byteArray[ix]))
                {
                    case 1:
                        {
                            //１byte文字
                            if (CheckHalfKana(byteArray[ix]) == false)
                            {
                                halfKanaIndexList.Add(textIndex);
                                result = false;
                            }
                            ix += 1;
                            break;
                        }
                    case 2:
                        {
                            //２byte文字
                            if (ix + 1 >= byteArray.Length)
                            {
                                addictIndexList.Add(textIndex);
                                result = false;
                            }

                            if (CheckAddictWord(byteArray[ix], byteArray[ix + 1]) == false)
                            {
                                addictIndexList.Add(textIndex);
                                result = false;
                            }
                            ix += 2;
                            break;
                        }
                    default:
                        {
                            addictIndexList.Add(textIndex);
                            result = false;
                            break;
                        }
                }
                textIndex++;
            }

            if (result == false)
            {
                halfKanaIndexes = halfKanaIndexList.ToArray();
                addictIndexes = addictIndexList.ToArray();
            }
            return result;
        }

        /// <summary>
        /// 文字のバイト数判定
        /// </summary> 
        /// <param name="byteChar">チェック対象のバイト文字列</param>
        /// <returns>0:1byte文字 1:2byte文字</returns>
        /// <remarks>
        /// <br>Note　　　 : 渡された文字のバイト数を判定します。</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2006.10.02</br>
        /// </remarks>
        private int ByteType(byte byteChar)
        {
            //１バイト文字
            //１バイト文字の領域に含まれているか判定する
            if ((byteChar <= 0x7e) || (0xa1 <= byteChar && byteChar <= 0xdf))
            {
                return 1;
            }
            //２バイト文字
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// 半角ｶﾅの判定
        /// </summary> 
        /// <param name="byteChar">チェック対象のバイト文字</param>
        /// <remarks>
        /// <br>Note　　　 : 渡されたバイト文字が半角ｶﾅであるか判定します</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2006.10.02</br>
        /// </remarks>
        private bool CheckHalfKana(byte byteChar)
        {
            //if(lChar >= #161) and (lChar <= #223) then
            // 10区 ・・・ 半角カタカナ等(シフトJISの00A1 ～ 00DF)
            bool result = true;
            //半角カナの場合
            if ((0xa1 <= byteChar) && (byteChar <= 0xdf))
            {
                result = false;
                return result;
            }
            return result;
        }


        /// <summary>
        /// 機種依存文字の判定
        /// </summary> 
        /// <param name="byteChar1">2byte文字の1byte目</param>
        /// <param name="byteChar2">2byte文字の1byte目</param>
        /// <remarks>
        /// <br>Note　　　 : 渡されたバイト文字列が機種依存文字であるか判定します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private bool CheckAddictWord(byte byteChar1, byte byteChar2)
        {
            bool result = false;

            // 13区 ・・・ ①②㈱℡ 等(シフトJISの0x8540 ～ 0x889E)
            if ((0x85 <= byteChar1) && (byteChar1 <= 0x88)) //(133～136 :10進数)
            {
                if (((byteChar1 == 0x85) && (byteChar2 < 0x40)) || (byteChar1 == 0x88) && (byteChar2 > 0x9e))
                {
                    result = true;
                }
            }

            // 92区 ・・・ 特殊な漢字、ⅰⅱ 等
            else if ((0xeb <= byteChar1) && (byteChar1 <= 0xef))
            {
                if (((byteChar1 == 0xeb) && (byteChar2 < 0x40)) || (byteChar1 == 0xef) && (byteChar2 > 0xfc))
                {
                    result = true;
                }
            }
            else if ((0xf0 <= byteChar1) && (byteChar2 >= 0x40))
            {

            }
            else
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region 機種依存文字チェック処理
        /// <summary>
		/// 機種依存文字チェック処理
		/// </summary> 
        /// <returns>結果</returns>
		/// <remarks>
		/// <br>Note       : 機種依存文字チェックを行います</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private bool TextCheckProc()
        {         
            bool result = false;

            this.Back_richTextBox.Text  = ""; 
            //PC用メール文書////////////////////////////////////////
            string text_pc = this.PcEditor_richTextBox.Text;
            //初期位置に戻す
            this.PcEditor_richTextBox.SelectAll();
            this.PcEditor_richTextBox.SelectionColor = Color.Black;
            this.PcEditor_richTextBox.Select( 0, 0 );
            //チェックに掛かった文字のindexを入れる。
            int[] halfKanaIndexes = null;
            int[] addictIndexes   = null;

            //チェック結果用フラグ         
            bool checkResult_Pc             = true;

            checkResult_Pc  = CheckText(text_pc,ref halfKanaIndexes,ref addictIndexes);   
                                                         
            if(checkResult_Pc == true)
            {
                //正常
                result = true;
            }
            else
            {                               
                //確認メッセージ
				DialogResult ret  = TMsgDisp.Show(
			    this,            
				emErrorLevel.ERR_LEVEL_INFO,                            // エラーレベル
				PGID, 						                            // アセンブリＩＤまたはクラスＩＤ
				 "入力された文章中に機種依存文字(半角ｶﾅや記号)が含まれています。"
                + System.Environment.NewLine
                + "このまま保存処理を続けてよろしいですか？",           // 表示するメッセージ
				0, 									                    // ステータス値
				MessageBoxButtons.YesNo);				            // 表示するボタン

                if(ret == DialogResult.Yes)
                {
                    //保存処理続行
                    result = true;
                }
                else
                {
                    //キャンセル
                    //キャンセル時に機種依存文字の文字色を変更してみる
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        //文字色のみ変更
                        #region PC用文章チェック処理
                        //表示しているRichTextで処理を行なうと画面がちらつくので非表示のRichText内で処理
                        this.Back_richTextBox.Text  = this.PcEditor_richTextBox.Text;                               
                      
                            
                        //半角ｶﾅ→全角カナ
                        if( halfKanaIndexes != null) 
                        {
                            for( int ix = 0; ix < halfKanaIndexes.Length; ix++ ) 
                            {                                                                                              
                                this.Back_richTextBox.SelectionStart  = halfKanaIndexes[ ix ];
                                this.Back_richTextBox.SelectionLength = 1;
                                this.Back_richTextBox.SelectionColor  = Color.Red;                                               
                            }
                        }
                        //機種依存文字の文字色をBlack→Redに変更
                        if( addictIndexes != null ) 
                        {
                            for( int ix = 0; ix < addictIndexes.Length; ix++ ) 
                            {                                                                
                                this.Back_richTextBox.SelectionStart  = addictIndexes[ ix ];
                                this.Back_richTextBox.SelectionLength = 1;                                  
                                this.Back_richTextBox.SelectionColor  = Color.Red;                
                            }
                        }
                       
                        
                        #endregion 

                        //文字色が必要なのでRtf形式で戻す
                        this.PcEditor_richTextBox.Rtf = this.Back_richTextBox.Rtf;
                        this.PcEditor_richTextBox.SelectionColor = Color.Black;                                   
                    }
                    catch(Exception)
                    {
                        //確認メッセージ
                        TMsgDisp.Show(
                        this,            
                        emErrorLevel.ERR_LEVEL_STOP,                            // エラーレベル
                        PGID, 						                            // アセンブリＩＤまたはクラスＩＤ
                        "文書チェック処理中に例外が発生しました",               // 表示するメッセージ
                        -1, 								                    // ステータス値
                        MessageBoxButtons.OK);		                            // 表示するボタン
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                   
                }
            }          
            return result;
        }
        #endregion

        #region ImeModeの初期化処理

        /// <summary>
		/// ImeModeの初期化処理
		/// </summary>    		
		/// <remarks>
		/// <br>Note       : ImeModeの初期化を行います</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void ImeModeClear()
        {
            this.PcEditor_richTextBox.ImeMode       = ImeMode.Hiragana;
            //this.MobileEditor_richTextBox.ImeMode   = ImeMode.Hiragana;

            if(this._control != null)
            {
                //PC用メールタイトル
                if((TEdit)this._control == this.CarbonCopy_tEdit)
                {
                    //ImeがOffになっているので一度Onにしないと駄目みたいです
                    this.CarbonCopy_tEdit.ImeMode = ImeMode.On;
                    this.CarbonCopy_tEdit.ImeMode = ImeMode.Hiragana;
                }
                //携帯用メールタイトル
                if((TEdit)this._control == this.Address_tEdit)
                {
                    this.Address_tEdit.ImeMode = ImeMode.On;
                    this.Address_tEdit.ImeMode = ImeMode.Hiragana;
                }
                //メール文書ファイル名
                //if((TEdit)this._control == this.EmailtextName_tEdit)
                //{
                //    this.EmailtextName_tEdit.ImeMode = ImeMode.On;
                //    this.EmailtextName_tEdit.ImeMode = ImeMode.Hiragana;
                //}

                //プレビュー起動用メールタイトル
                if((TEdit)this._control == this.MailTitle_tEdit)
                {
                    this.MailTitle_tEdit.ImeMode = ImeMode.On;
                    this.MailTitle_tEdit.ImeMode = ImeMode.Hiragana;
                }
            }                                     
        }

        #endregion

        #region 起動パラメータ取得デリゲートコール
        /// <summary>
        /// 起動パラメータ取得デリゲートコール
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameterDelegateCall(out string param)
        {
            param = string.Empty;
            if (this.GetStartParameterEvent != null)
            {
                this.GetStartParameterEvent(out param);
            }
        }
        #endregion

        #endregion

        #region Event

        #region Loadイベント
        /// <summary>
        /// Form Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : Formがロードされた時に発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PMKHN07504UA_Load(object sender, EventArgs e)
        {
            //マスメン起動時のツールバー設定
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            //ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;             
            //TODO:適切なアイコンを設定する。               
            this.MainToolbarsManager.ImageListSmall = imageList16;
            this.MainToolbarsManager.Tools[TOOLBARMENU_END].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.MainToolbarsManager.Tools[TOOLBARMENU_SETUP].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            this.MainToolbarsManager.Tools[TOOLBARMENU_SEND].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MAIL;

            //画面初期設定処理
            ScreenInitialSetting();

            this.Initial_Timer.Enabled = true;
        }

     
        #endregion
              
        #region RichTextBox_Enterイベント
        /// <summary>
        /// RichTextBox_Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : RichTextBox_Enterがアクティブになった時に発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PcEditor_richTextBox_Enter(object sender, EventArgs e)
        {                      
            //StatusBarに入力されている文字数を表示する
            SetWordsCountToUltraStatusBar(this.PcEditor_richTextBox);
            //IMEModeをひらがなにする
            this.PcEditor_richTextBox.ImeMode = ImeMode.Hiragana;
        }
        #endregion

        #region RichTextBox_TextChangedイベント
        /// <summary>
        /// RichTextBox_TextChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : Textのプロパティ値がコントロールで変更された時に発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PcEditor_richTextBox_TextChanged(object sender, EventArgs e)
        {           
            //フォントをMSゴシック11.25に固定します。
            //貼り付けなどをされた時の対応。
            //機能拡張して、フォントサイズの変更などが可能になったらはずしてください
            //2006/10/26 Undoが機能しなくなるので削除
            this.PcEditor_richTextBox.Font = new Font("ＭＳ ゴシック", 11.25F);               
            //this.PcEditor_richTextBox.SelectionColor = Color.Black; 
            //StatusBarに入力されている文字数を表示する
            SetWordsCountToUltraStatusBar(this.PcEditor_richTextBox);
        }
        #endregion

        #region RichTextBox_KeyDownイベント
         /// <summary>
        /// RichTextBox_KeyDown　イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : PcEditor_richTextBox上でkeyが押された時に発生</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if((RichTextBox)sender == this.PcEditor_richTextBox)
            {
                //SelectionColorがBlackで無ければBlackをセットする。
                if(this.PcEditor_richTextBox.SelectionColor != Color.Black)
                {
                    this.PcEditor_richTextBox.SelectionColor = Color.Black;
                }
            }

            //画像データの貼り付け制御      
            if ( e.Control )
            {
                if ( e.KeyCode == Keys.V )
                {                          
                    //クリップボードにあるデータをテキスト形式に変換可能か？
                    if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                    {                          
                       //テキストデータとして取り出す
                       object ob = Clipboard.GetDataObject().GetData(DataFormats.Text);
                       string words = ob.ToString();
                       if(this.PcEditor_richTextBox.Focused)
                       {
                           //richTextだとrtf形式で読み込むようなのでテキスト形式に変更して
                           //貼り付けるようにし、本来の処理はキャンセルする
                           //最大入力桁数を超えている場合は無効
                           if(this.maxCountPc > this.PcEditor_richTextBox.Text.Length)
                           {
                                //現在の文字数と追加する文字数の合計が最大入力文字数を超える場合もキャンセル
                                int totalLength = this.PcEditor_richTextBox.Text.Length + words.Length;
                                if(totalLength > this.maxCountPc)
                                {
                                    int overLength = totalLength - this.maxCountPc;
                                    string editWords = words.Remove(words.Length - overLength ,overLength);
                        　　        this.PcEditor_richTextBox.SelectedText = editWords;
                                }
                                else
                                {
                                    this.PcEditor_richTextBox.SelectedText = words;
                                }                              
                           }                          
                           //本来の貼り付け処理が走るのでそれをキャンセルする
                           e.Handled = true;
                       }
                    }
                    else
                    {
                        //bitmap等の画像データの場合はキャンセルする。
                        e.Handled = true;
                    }
                }
            }

            //Control+Zの対応               
            if ( e.Control )
            {
                if ( e.KeyCode == Keys.Z )
                {
                    if((RichTextBox)sender == this.PcEditor_richTextBox)
                    {       
                        if(this.PcEditor_richTextBox.CanUndo)
                        {
                            this.PcEditor_richTextBox.Undo();
                        }
                      
                    }
                }
            }

        }
    
        #endregion

        #region tRetKeyControl1_ChangeFocus イベント

        /// <summary>
        /// tRetKeyControl1_ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : EnterKeyによりフォーカスが遷移する再に発生します</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //ヘッダ部名称取得
            switch (e.PrevCtrl.Name)
            {
                // 担当者（宛先）
                case "Address_tEdit":
                    {
                        // 入力値変更チェック
                        if (this._address_tEdit == this.Address_tEdit.Text.Trim())
                        {
                            break;
                        }

                        bool canChangeFocus = true;
                        string code = this.Address_tEdit.Text.Trim();
                        string name = this.Address_tEdit.Text.Trim();
                        int codeInt;

                        #region マスタ読込
                        if ((code != "") &&
                            (code.Length <= 4) &&
                            (Int32.TryParse(code, out codeInt) == true))
                        {
                            // 従業員マスタ
                            Employee employee;
                            EmployeeDtl employeeDtl;
                            int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, codeInt.ToString("0000"));

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                name = employee.Name.Trim();
                                this.mailAddressList.Clear();
                                this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                if (employeeDtl.MailAddress2 == string.Empty)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "携帯用メールアドレスが設定されていません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    //name = name + "<メールアドレス未設定>";
                                }
                                //else
                                //{
                                //    name = name + "<" + employeeDtl.MailAddress2 + ">";
                                //}
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                     (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "担当者が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                //code = "";
                                canChangeFocus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "担当者の取得に失敗しました。",
                                    status,
                                    MessageBoxButtons.OK);

                                //code = "";
                                canChangeFocus = false;
                            }
                        }
                        else
                        {
                            // メールアドレス手入力
                            this.mailAddressList.Clear();
                            this.mailAddressList.Add(this.Address_tEdit.Text, this.Address_tEdit.Text);
                        }

                        // コード・名称セット
                        //this.tEdit_EmployeeCode.Text = code;
                        this.Address_tEdit.Text = name;

                        // 入力値の保存
                        this._address_tEdit = this.Address_tEdit.Text.Trim();
                        #endregion

                        #region NextCtrl制御
                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.Address_tEdit.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_AddressGuide;
                                        }
                                        else if (this.CarbonCopy_tEdit.Enabled == true)
                                        {
                                            e.NextCtrl = this.CarbonCopy_tEdit;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.Subject_tEdit;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }

                // 担当者（CC）
                case "CarbonCopy_tEdit":
                    {
                        // 入力値変更チェック
                        if (this._carbonCopy_tEdit == this.CarbonCopy_tEdit.Text.Trim())
                        {
                            break;
                        }

                        bool canChangeFocus = true;
                        string code = this.CarbonCopy_tEdit.Text.Trim();
                        string name = this.CarbonCopy_tEdit.Text.Trim();
                        int codeInt;

                        #region マスタ読込
                        if ((code != "") &&
                            (code.Length <= 4) &&
                            (Int32.TryParse(code, out codeInt) == true))
                        {
                            // 従業員マスタ
                            Employee employee;
                            EmployeeDtl employeeDtl;
                            int status = _mailInfoBase.GetEmployeeDtl(out employee, out employeeDtl, codeInt.ToString("0000"));

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                name = employee.Name.Trim();
                                this.ccAddressList.Clear();
                                this.ccAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                                if (employeeDtl.MailAddress2 == string.Empty)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "携帯用メールアドレスが設定されていません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    //name = name + "<メールアドレス未設定>";
                                }
                                //else
                                //{
                                //    name = name + "<" + employeeDtl.MailAddress2 + ">";
                                //}
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                     (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "担当者が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                //code = "";
                                canChangeFocus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "担当者の取得に失敗しました。",
                                    status,
                                    MessageBoxButtons.OK);

                                //code = "";
                                canChangeFocus = false;
                            }
                        }
                        else
                        {
                            // メールアドレス手入力
                            this.ccAddressList.Clear();
                            this.ccAddressList.Add(this.CarbonCopy_tEdit.Text, this.CarbonCopy_tEdit.Text);
                        }

                        // コード・名称セット
                        //this.tEdit_EmployeeCode.Text = code;
                        this.CarbonCopy_tEdit.Text = name;

                        // 入力値の保存
                        this._carbonCopy_tEdit = this.CarbonCopy_tEdit.Text.Trim();
                        #endregion

                        #region NextCtrl制御
                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.CarbonCopy_tEdit.Text.Trim().Length == 0)
                                        {
                                            e.NextCtrl = this.uButton_CarbonCopyGuide;
                                        }
                                        else if (this.QRCodePath_tEdit.Visible == true)
                                        {
                                            e.NextCtrl = this.QRCodePath_tEdit;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.PcEditor_richTextBox;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        #endregion

                        break;
                    }
            }

            //PC用メール文書の場合
            if(e.PrevCtrl == this.PcEditor_richTextBox)
            {
                //エディタ内でEnterKeyが押された場合
                if(e.Key == Keys.Enter)
                {
                    if(this.PcEditor_richTextBox.Text.Length < this.maxCountPc)
                    {
                        e.NextCtrl = null;
                        //改行文字を挿入します
                        this.PcEditor_richTextBox.SelectedText += System.Environment.NewLine;
                        this.PcEditor_richTextBox.AcceptsTab = true;
                    }
                   
                }
                //エディタ内で TabKeyが押された場合
                else if(e.Key == Keys.Tab)
                {
                     if(this.PcEditor_richTextBox.Text.Length < this.maxCountPc)
                     {
                         //タブを挿入
                         this.PcEditor_richTextBox.SelectedText += "\t";
                         e.NextCtrl = null;
                     }                   

                }
              
            }
        }

        #endregion

        #region MainToolbarsManager_ToolClickイベント
        /// <summary>
        /// Main_ToolbarsManager_ToolClick　イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : Main_ToolbarsManagerがクリックされた時に発生</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void MainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //TEditにフォーカスがある状態でガイド等を起動し、元の画面に戻ると
            //IMEがoffになっている。
            //文書チェックボタンを押下時にフォーカスがあったコントロールを保存

            //コントロールの初期化
            this._control = null;
            
            //PC用メールタイトルにフォーカスがあった場合
            if(this.CarbonCopy_tEdit.Focused)
            {
                this._control = this.CarbonCopy_tEdit;
            }

            //携帯用メールタイトルにフォーカスがあった場合
            if(this.Address_tEdit.Focused)
            {
                this._control = this.Address_tEdit;
            }
           
            //プレビュー起動用メールタイトル
            if(this.MailTitle_tEdit.Focused)
            {
                this._control = this.MailTitle_tEdit;
            }
            
            switch(e.Tool.Key)
            {
                #region 終了
                case TOOLBARMENU_END:
                {
                    this.Close();
                    break;
                }
                #endregion

                #region 設定
                case TOOLBARMENU_SETUP:
                {
                    if (this._userSetupFrm == null)
                        this._userSetupFrm = new PMKHN07504UB();

                    this._userSetupFrm.ShowDialog();
                    break;
                }
                #endregion

                #region 送信
                case TOOLBARMENU_SEND:
                {
                    //bool boolCheck = false;
                    //int cnt = 0;
                    int cntMail = 0;

                    #region メール送信
                    if (!this._isClickSendMail) break;
                    try
                    {
                        this._isClickSendMail = false;

                        // 機種依存文字チェック
                        bool checkResult = TextCheckProc();

                        if (checkResult == false)
                        {
                            return;
                        }

                        // 本文チェック
                        if (this.PcEditor_richTextBox.Text == string.Empty)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, "本文が未入力です", 0, MessageBoxButtons.OK);
                            return;
                        }

                        // 送信先チェック
                        if ((this.Address_tEdit.Text != string.Empty) &&
                            (this.mailAddressList.Count != 0))
                        {
                            foreach (string values in this.mailAddressList.Values)
                            {
                                if (values.Trim() == string.Empty) continue;
                                if (values.Contains("@") == false) continue;
                                cntMail++;
                            }
                        }
                        if (cntMail == 0)
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, "送信対象がありません", 0, MessageBoxButtons.OK);
                            return;
                        }

                        // メールを作成します
                        MailSourceData mailSourceData = new MailSourceData();
                        DataSet mailDocMngSet = mailSourceData.CreateNewMailDataList();
                        int ix = 0;

                        DataRow row_Pc = mailDocMngSet.Tables[0].NewRow();
                        mailDocMngSet.Tables[0].Rows.Add(row_Pc);
                        mailDocMngSet.Tables[0].Rows[ix][MAILDOCUMENTCNTS]  = this.PcEditor_richTextBox.Text;   //メール本文(PC)
                        mailDocMngSet.Tables[0].Rows[ix][MAILTITLE_TITLE]   = this.Subject_tEdit.Text;          //メールタイトル(PC)

                        //mailDocMngSet.Tables[0].Rows[ix]["EnterpriseCode"] = this._enterpriseCode;    //企業コード
                        mailDocMngSet.Tables[0].Rows[ix]["LogicalDeleteCode"] = 0;                      //論理削除区分
                        mailDocMngSet.Tables[0].Rows[ix]["MailSendCode1"] = 1;                          //メール送信区分コード(0以外をセット)

                        mailDocMngSet.Tables[0].Rows[ix]["AttachFile"] = this.QRCodePath_tEdit.Text;    //添付ファイル

                        foreach (string values in this.mailAddressList.Values)
                        {
                            if (values.Trim() == string.Empty) continue;
                            if (values.Contains("@") == false) continue;
                            mailDocMngSet.Tables[0].Rows[ix]["MailAddress"] = values.Trim();            //メールアドレス
                            break;
                        }
                        foreach (string values in this.ccAddressList.Values)
                        {
                            if (values.Trim() == string.Empty) continue;
                            if (values.Contains("@") == false) continue;
                            mailDocMngSet.Tables[0].Rows[ix]["CarbonCopy"] = values.Trim();             //CC
                            break;
                        }
                        ix++;

                        //何も入力されていない
                        if (mailDocMngSet.Tables[0].Rows.Count == 0)
                        {
                            //何もしない
                            return;
                        }
                        else
                        {
                            mailSourceData.MailDataList = mailDocMngSet;
                        }

                        // メールを送信します
                        //MailFactoryBase mailFactoryBase = new MailFactoryBase(MailServiceInfoCreateMode.Default);
                        //IMailSender _mailSender = mailFactoryBase.GetMailSenderInterface();

                        MailSenderOperationInfo mailSenderOperationInfo = new MailSenderOperationInfo(0);

                        // 送信形態を設定します
                        // プログレスバーの表示
                        mailSenderOperationInfo.DispProgressDialog = true;
                        // ＢＣＣ情報の送信
                        //mailSenderOperationInfo.SendBccBackup = SendBCCBackup_CheckEditor.Checked;
                        mailSenderOperationInfo.SendBccBackup = false;
                        // オペレーションモード
                        mailSenderOperationInfo.OperationMode = 0; // デフォルト設定
                        // ステータス（戻り値）
                        mailSenderOperationInfo.SendStatus = 0;
                        // メッセージ（戻り値）
                        mailSenderOperationInfo.StatusMessage = "";

                        DateTime nowTime = Broadleaf.Library.Globarization.TDateTime.GetSFDateNow();
                        //int st = mailSender.SendMail(ref mailSenderOperationInfo, this._mailSourceData);
                        int st = _mailSender.SendMail(ref mailSenderOperationInfo, mailSourceData);
                        switch (st)
                        {
                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                {
                                    this.DialogResult = DialogResult.OK;

                                    // 本文のテキスト出力
                                    string sNowDate = nowTime.Year.ToString("00") + nowTime.Month.ToString("00") + nowTime.Day.ToString("00");
                                    string sNowTime = nowTime.Hour.ToString("00") + nowTime.Minute.ToString("00");
                                    string fileName = "PMNSQR_" + sNowDate + "_" + sNowTime + nowTime.Second.ToString("00") + ".txt";
                                    string fullpath = _mailInfoSetting.FilePathNm;
                                    if ((fullpath.Trim() != string.Empty) && (fullpath.EndsWith("\\") == false))
                                    {
                                        fullpath = fullpath + "\\";
                                    }

                                    StreamWriter outfile = new StreamWriter(fullpath + fileName, true, Encoding.Default);
                                    outfile.Write(this.PcEditor_richTextBox.Text);
                                    outfile.Close();
                                    
                                    // ログの出力
                                    MailHist mailHist = new MailHist();
                                    List<MailHist> mailHistList = new List<MailHist>();
                                    MailSendHistAcs mailSendHistAcs = new MailSendHistAcs();

                                    mailHist.FileName = fileName;                       //本文ファイル名
                                    mailHist.QRCode = this.QRCodePath_tEdit.Text;       //添付ファイル
                                    mailHist.TransmitDate = sNowDate;                   //送信日付
                                    mailHist.TransmitTime = sNowTime;                   //送信時間
                                    mailHist.EmployeeName = string.Empty;
                                    foreach (string keys in this.mailAddressList.Keys)
                                    {
                                        if (keys.Trim() == string.Empty) continue;
                                        mailHist.EmployeeName = keys.Trim();            //受信者
                                        break;
                                    }
                                    mailHist.CCInfo = string.Empty;
                                    foreach (string keys in this.ccAddressList.Keys)
                                    {
                                        if (keys.Trim() == string.Empty) continue;
                                        mailHist.CCInfo = keys.Trim();                  //CC
                                        break;
                                    }
                                    mailHist.Title = this.Subject_tEdit.Text;           //件名

                                    mailSendHistAcs.Read(out mailHistList);
                                    mailHistList.Add(mailHist);
                                    mailSendHistAcs.Write(mailHistList);

                                    // 終了チェック開始
                                    EndChk_Timer.Enabled = true;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                                        mailSenderOperationInfo.StatusMessage, st, MessageBoxButtons.OK);
                                    this.DialogResult = DialogResult.Abort;
                                    break;
                                }
                        }
                    }
                    finally
                    {
                        this._isClickSendMail = true;
                    }
                    #endregion

                    break;
                }
                #endregion

                #region その他
                default:
                {
                    break;
                }
                #endregion
            }
        }
        
        #endregion

        #region Timer_Tickイベント

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 初期値フォーカス設定
            //this.PcEditor_richTextBox.Focus();
            this.Address_tEdit.Focus();

            // 画面初期設定処理
            //アイコン(☆) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_AddressGuide.ImageList = imageList16;
            this.uButton_CarbonCopyGuide.ImageList = imageList16;
            this.uButton_QRCodePath.ImageList = imageList16;
            this.uButton_AddressGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_CarbonCopyGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_QRCodePath.Appearance.Image = Size16_Index.STAR1;

            //メール情報設定マスタ読込
            int status = _mailInfoBase.GetMailInfoSetting(out _mailInfoSetting);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "メール情報設定が未登録です。\n登録後、再度処理して下さい。",
                    -1,
                    MessageBoxButtons.OK);
                Close();
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "メール情報設定の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
                Close();
            }

            //// 画面初期値取得処理
            ScreenReconstruction();
        }

        /// <summary>
        /// Timer.Tick イベント イベント(EndChk_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void EndChk_Timer_Tick(object sender, EventArgs e)
        {
            // メール送信後、プログラムを終了します。
            if (this._mailSender.SendEndFlg == true)
            {
                EndChk_Timer.Enabled = false;
                //TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "メール送信が完了しました。",
                //    -1,
                //    MessageBoxButtons.OK);
                Close();
            }
        }

        #endregion

        #region Form.Closing イベント
        /// <summary>
		/// Form.Closing イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2010.05.25</br>
        /// </remarks>
        private void PMKHN07504UA_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion         

        #region フォームサイズ変更イベント
        /// <summary>
        /// フォームサイズ変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKHN07504UA_Resize(object sender, EventArgs e)
        {
            // anchorの設定では正常動作しなかったためここで幅の調整を行う
            this.Address_tEdit.Width = this.Size.Width - this._sizeDifferenceAddress;
            this.CarbonCopy_tEdit.Width = this.Size.Width - this._sizeDifferenceAddress;
            this.Subject_tEdit.Width = this.Size.Width - this._sizeDifferenceSubject;
            this.QRCodePath_tEdit.Width = this.Size.Width - this._sizeDifferenceQRCode;
        }
        #endregion

        #region ガイドボタン イベント
        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_AddressGuide_Click(object sender, EventArgs e)
        {
            Employee employee;
            EmployeeDtl employeeDtl;

            // 従業員マスタ読込
            int status = _mailInfoBase.GetEmployeeGuid(out employee, out employeeDtl);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 従業員詳細マスタ読込
                string name = employee.Name.Trim();
                this.mailAddressList.Clear();
                this.mailAddressList.Add(employee.Name, employeeDtl.MailAddress2);
                if (employeeDtl.MailAddress2 == string.Empty)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "携帯用メールアドレスが設定されていません。",
                        -1,
                        MessageBoxButtons.OK);
                    //name = name + "<メールアドレス未設定>";
                }
                //else
                //{
                //    name = name + "<" + employeeDtl.MailAddress2 + ">";
                //}

                // セット先チェック
                if ((UltraButton)sender == this.uButton_AddressGuide)
                {
                    Address_tEdit.Text = name;

                    // 入力値の保存
                    this._address_tEdit = this.Address_tEdit.Text.Trim();
                }
                else if ((UltraButton)sender == this.uButton_CarbonCopyGuide)
                {
                    CarbonCopy_tEdit.Text = name;

                    // 入力値の保存
                    this._carbonCopy_tEdit = this.CarbonCopy_tEdit.Text.Trim();
                }
            }
        }

        /// <summary>
        /// QRコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_QRCodePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = _mailInfoSetting.FilePathNm;
            openFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true ;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                QRCodePath_tEdit.Text = openFileDialog.FileName;
            }
        }

        #endregion

        #endregion

    }
}