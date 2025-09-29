//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : UOE接続先情報マスタメンテナンス
// プログラム概要   : UOE接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caowj
// 作 成 日  2010/07/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE接続先情報マスタメンテナンスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE接続先情報マスタを行います
    ///					: IMasterMaintenanceSingleTypeを実装しています</br>
    /// <br>Programer	: caowj</br>
    /// <br>Date		: 2010/07/27</br>
    /// <br></br>
    /// <br>Update Note : </br>
    /// </remarks>
    public class PMUOE09050UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel SocketCommPort_Label;
        private Infragistics.Win.Misc.UltraLabel ReceiveComputerNm_Label;
        private Infragistics.Win.Misc.UltraLabel ClientTimeOut_Label;
        private Infragistics.Win.Misc.UltraLabel CashRegisterNo_Label;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Close_Button;
        private Broadleaf.Library.Windows.Forms.TEdit SocketCommPort_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit ReceiveComputerNm_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit CashRegisterNo_tEdit;
        private System.Windows.Forms.Timer timer1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraLabel CommAssemblyId_Label;
        private TEdit CommAssemblyId_tEdit;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TEdit ClientTimeOut_tEdit;
        private Infragistics.Win.Misc.UltraLabel unit_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabe11;
        private System.ComponentModel.IContainer components;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// PMUOE09050Uコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: UOE接続先情報マスタコンストラクタです</br>
        /// <br>Programer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public PMUOE09050UA()
        {
            InitializeComponent();

            // DataSet列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            this._nextData = false;
            this._totalCount = 0;

            // uOEConnectInfoクラス
            this._uOEConnectInfo = new UOEConnectInfo();
            // uOEConnectInfoクラスアクセスクラス
            this._uOEConnectInfoAcs = new UOEConnectInfoAcs();

            this._uOEConnectInfoTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 印刷可能フラグを設定します。
            // Frameの印刷ボタンの表示非表示の制御に使用します。
            this._canPrint = false;

            this._indexBuf = -2;
        }
        #endregion

        #region Private Member
        /// <summary>
        /// グローバル変数・定数宣言
        /// </summary>
        private UOEConnectInfo _uOEConnectInfo;
        private UOEConnectInfoAcs _uOEConnectInfoAcs;
        private UOEConnectInfo _uOEConnectInfoClone; // データ比較用        
        private string _enterpriseCode;

        //HashTable
        private Hashtable _uOEConnectInfoTable;

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool _nextData;
        //件数
        private int _totalCount;

        private const string ASSEMBLY_ID = "PMUOE09050U";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_COMMASSEMBLYID = "通信アセンブリID";
        private const string VIEW_CASHREGISTERNO = "端末番号";
        private const string VIEW_SOCKETCOMMPORT = "通信PORT番号";
        private const string VIEW_RECEIVECOMPUTERNM = "接続先コンピュータ名";
        private const string VIEW_CLIENTTIMEOUT = "クライアントタイムアウト";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private int _indexBuf;

        #endregion

        #region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09050UA));
            this.SocketCommPort_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ReceiveComputerNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ClientTimeOut_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CashRegisterNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.SocketCommPort_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ReceiveComputerNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CashRegisterNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.CommAssemblyId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CommAssemblyId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ClientTimeOut_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.unit_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabe11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SocketCommPort_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveComputerNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTimeOut_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // SocketCommPort_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.SocketCommPort_Label.Appearance = appearance1;
            this.SocketCommPort_Label.Location = new System.Drawing.Point(12, 135);
            this.SocketCommPort_Label.Name = "SocketCommPort_Label";
            this.SocketCommPort_Label.Size = new System.Drawing.Size(125, 23);
            this.SocketCommPort_Label.TabIndex = 7;
            this.SocketCommPort_Label.Tag = "8";
            this.SocketCommPort_Label.Text = "通信ポート番号";
            // 
            // ReceiveComputerNm_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.ReceiveComputerNm_Label.Appearance = appearance2;
            this.ReceiveComputerNm_Label.Location = new System.Drawing.Point(12, 171);
            this.ReceiveComputerNm_Label.Name = "ReceiveComputerNm_Label";
            this.ReceiveComputerNm_Label.Size = new System.Drawing.Size(170, 23);
            this.ReceiveComputerNm_Label.TabIndex = 13;
            this.ReceiveComputerNm_Label.Tag = "13";
            this.ReceiveComputerNm_Label.Text = "接続先コンピュータ名";
            // 
            // ClientTimeOut_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ClientTimeOut_Label.Appearance = appearance3;
            this.ClientTimeOut_Label.Location = new System.Drawing.Point(12, 207);
            this.ClientTimeOut_Label.Name = "ClientTimeOut_Label";
            this.ClientTimeOut_Label.Size = new System.Drawing.Size(202, 23);
            this.ClientTimeOut_Label.TabIndex = 14;
            this.ClientTimeOut_Label.Tag = "14";
            this.ClientTimeOut_Label.Text = "クライアントタイムアウト";
            // 
            // CashRegisterNo_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.CashRegisterNo_Label.Appearance = appearance6;
            this.CashRegisterNo_Label.Location = new System.Drawing.Point(12, 91);
            this.CashRegisterNo_Label.Name = "CashRegisterNo_Label";
            this.CashRegisterNo_Label.Size = new System.Drawing.Size(79, 23);
            this.CashRegisterNo_Label.TabIndex = 17;
            this.CashRegisterNo_Label.Tag = "17";
            this.CashRegisterNo_Label.Text = "端末番号";
            // 
            // Mode_Label
            // 
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance7;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(442, 2);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 289);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(554, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Close_Button.Location = new System.Drawing.Point(417, 243);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(125, 34);
            this.Close_Button.TabIndex = 9;
            this.Close_Button.Text = "閉じる(&X)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // SocketCommPort_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            this.SocketCommPort_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            this.SocketCommPort_tEdit.Appearance = appearance9;
            this.SocketCommPort_tEdit.AutoSelect = true;
            this.SocketCommPort_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SocketCommPort_tEdit.DataText = "";
            this.SocketCommPort_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SocketCommPort_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SocketCommPort_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SocketCommPort_tEdit.Location = new System.Drawing.Point(220, 135);
            this.SocketCommPort_tEdit.MaxLength = 6;
            this.SocketCommPort_tEdit.Name = "SocketCommPort_tEdit";
            this.SocketCommPort_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SocketCommPort_tEdit.Size = new System.Drawing.Size(67, 24);
            this.SocketCommPort_tEdit.TabIndex = 3;
            // 
            // ReceiveComputerNm_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Left";
            this.ReceiveComputerNm_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            this.ReceiveComputerNm_tEdit.Appearance = appearance5;
            this.ReceiveComputerNm_tEdit.AutoSelect = true;
            this.ReceiveComputerNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ReceiveComputerNm_tEdit.DataText = "";
            this.ReceiveComputerNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ReceiveComputerNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.ReceiveComputerNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ReceiveComputerNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ReceiveComputerNm_tEdit.Location = new System.Drawing.Point(220, 171);
            this.ReceiveComputerNm_tEdit.MaxLength = 20;
            this.ReceiveComputerNm_tEdit.Name = "ReceiveComputerNm_tEdit";
            this.ReceiveComputerNm_tEdit.Size = new System.Drawing.Size(179, 24);
            this.ReceiveComputerNm_tEdit.TabIndex = 4;
            // 
            // CashRegisterNo_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlignAsString = "Right";
            this.CashRegisterNo_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            this.CashRegisterNo_tEdit.Appearance = appearance19;
            this.CashRegisterNo_tEdit.AutoSelect = true;
            this.CashRegisterNo_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CashRegisterNo_tEdit.DataText = "";
            this.CashRegisterNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CashRegisterNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CashRegisterNo_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CashRegisterNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CashRegisterNo_tEdit.Location = new System.Drawing.Point(220, 91);
            this.CashRegisterNo_tEdit.MaxLength = 3;
            this.CashRegisterNo_tEdit.Name = "CashRegisterNo_tEdit";
            this.CashRegisterNo_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CashRegisterNo_tEdit.Size = new System.Drawing.Size(44, 24);
            this.CashRegisterNo_tEdit.TabIndex = 2;
            this.CashRegisterNo_tEdit.Leave += new System.EventHandler(this.CashRegisterNo_tEdit_Leave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // CommAssemblyId_Label
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.CommAssemblyId_Label.Appearance = appearance12;
            this.CommAssemblyId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CommAssemblyId_Label.Location = new System.Drawing.Point(12, 47);
            this.CommAssemblyId_Label.Name = "CommAssemblyId_Label";
            this.CommAssemblyId_Label.Size = new System.Drawing.Size(135, 23);
            this.CommAssemblyId_Label.TabIndex = 118;
            this.CommAssemblyId_Label.Text = "通信アセンブリID";
            // 
            // CommAssemblyId_tEdit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.CommAssemblyId_tEdit.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            this.CommAssemblyId_tEdit.Appearance = appearance21;
            this.CommAssemblyId_tEdit.AutoSelect = true;
            this.CommAssemblyId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CommAssemblyId_tEdit.DataText = "";
            this.CommAssemblyId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CommAssemblyId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CommAssemblyId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CommAssemblyId_tEdit.Location = new System.Drawing.Point(220, 47);
            this.CommAssemblyId_tEdit.MaxLength = 4;
            this.CommAssemblyId_tEdit.Name = "CommAssemblyId_tEdit";
            this.CommAssemblyId_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CommAssemblyId_tEdit.Size = new System.Drawing.Size(51, 24);
            this.CommAssemblyId_tEdit.TabIndex = 1;
            this.CommAssemblyId_tEdit.Leave += new System.EventHandler(this.CommAssemblyId_tEdit_Leave);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(163, 243);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Revive_Button.Location = new System.Drawing.Point(290, 243);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 8;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(290, 243);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ClientTimeOut_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.ClientTimeOut_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.ClientTimeOut_tEdit.Appearance = appearance11;
            this.ClientTimeOut_tEdit.AutoSelect = true;
            this.ClientTimeOut_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ClientTimeOut_tEdit.DataText = "";
            this.ClientTimeOut_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ClientTimeOut_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.ClientTimeOut_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClientTimeOut_tEdit.Location = new System.Drawing.Point(220, 207);
            this.ClientTimeOut_tEdit.MaxLength = 6;
            this.ClientTimeOut_tEdit.Name = "ClientTimeOut_tEdit";
            this.ClientTimeOut_tEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClientTimeOut_tEdit.Size = new System.Drawing.Size(67, 24);
            this.ClientTimeOut_tEdit.TabIndex = 5;
            // 
            // unit_Label
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.unit_Label.Appearance = appearance26;
            this.unit_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.unit_Label.Location = new System.Drawing.Point(294, 208);
            this.unit_Label.Name = "unit_Label";
            this.unit_Label.Size = new System.Drawing.Size(80, 23);
            this.unit_Label.TabIndex = 120;
            this.unit_Label.Text = "1/1000秒";
            // 
            // ultraLabe11
            // 
            this.ultraLabe11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabe11.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabe11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabe11.Location = new System.Drawing.Point(12, 81);
            this.ultraLabe11.Name = "ultraLabe11";
            this.ultraLabe11.Size = new System.Drawing.Size(530, 3);
            this.ultraLabe11.TabIndex = 121;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(12, 125);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(530, 3);
            this.ultraLabel2.TabIndex = 122;
            // 
            // PMUOE09050UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(554, 312);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabe11);
            this.Controls.Add(this.unit_Label);
            this.Controls.Add(this.ClientTimeOut_tEdit);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.CommAssemblyId_tEdit);
            this.Controls.Add(this.CommAssemblyId_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SocketCommPort_tEdit);
            this.Controls.Add(this.ReceiveComputerNm_tEdit);
            this.Controls.Add(this.CashRegisterNo_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.CashRegisterNo_Label);
            this.Controls.Add(this.ClientTimeOut_Label);
            this.Controls.Add(this.ReceiveComputerNm_Label);
            this.Controls.Add(this.SocketCommPort_Label);
            this.Controls.Add(this.Close_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PMUOE09050UA";
            this.Text = "UOE接続情報マスタ";
            this.Load += new System.EventHandler(this.PMUOE09050UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMUOE09050UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMUOE09050UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SocketCommPort_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveComputerNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTimeOut_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Main Entry Point
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09050UA());
        }
        #endregion

        #region IMasterMaintenanceMultiTypeメンバ
        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Method --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList uOEConnectInfoList = null;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._uOEConnectInfoAcs.Search(out uOEConnectInfoList, this._enterpriseCode);

                this._totalCount = uOEConnectInfoList.Count;
            }
            else
            {
                status = this._uOEConnectInfoAcs.SearchAll(
                    out uOEConnectInfoList,
                    out this._totalCount,
                    out this._nextData,
                    this._enterpriseCode,
                    readCount,
                    this._uOEConnectInfo);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (uOEConnectInfoList.Count > 0)
                        {
                            // 最終のUOE接続先情報マスタをオブジェクトを退避する
                            this._uOEConnectInfo = ((UOEConnectInfo)uOEConnectInfoList[uOEConnectInfoList.Count - 1]).Clone();
                        }
                        int index = 0;
                        // 読み込んだインスタンス
                        foreach (UOEConnectInfo uOEConnectInfo in uOEConnectInfoList)
                        {
                            // DataSetにセットする
                            UOEConnectInfoToDataSet(uOEConnectInfo.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 全件読み込み完了の場合は、何もしない
                        break;
                    }
                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "UOE接続先情報マスタメンテナンス", // プログラム名称
                            "Search", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._uOEConnectInfoAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
            totalCount = this._totalCount;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            UOEConnectInfo uOEConnectInfo = (UOEConnectInfo)this._uOEConnectInfoTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // UOE接続先情報マスタ情報論理削除処理
            status = this._uOEConnectInfoAcs.LogicalDelete(ref uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._uOEConnectInfoAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // UOE接続先情報マスタ情報クラスデータセット展開処理
            UOEConnectInfoToDataSet(uOEConnectInfo.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //通信アセンブリID
            appearanceTable.Add(VIEW_COMMASSEMBLYID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //端末番号
            appearanceTable.Add(VIEW_CASHREGISTERNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //通信ポート番号
            appearanceTable.Add(VIEW_SOCKETCOMMPORT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //接続先コンピュータ名
            appearanceTable.Add(VIEW_RECEIVECOMPUTERNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //クライアントタイムアウト
            appearanceTable.Add(VIEW_CLIENTTIMEOUT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// UOE接続先情報マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタメンテナンスクラスをデータセットに格納します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void UOEConnectInfoToDataSet(UOEConnectInfo uOEConnectInfo, int index)
        {
            // indexの値がDataSetの既存行をさしていなかったら
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // indexに行の最終行番号をセットする
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            if (uOEConnectInfo.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = uOEConnectInfo.UpdateDateTimeJpInFormal;
            }

            // 通信アセンブリID
            if (uOEConnectInfo.CommAssemblyId.Trim().Length < 4)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMASSEMBLYID] = uOEConnectInfo.CommAssemblyId.Trim().PadLeft(4, '0');
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_COMMASSEMBLYID] = uOEConnectInfo.CommAssemblyId.Trim();
            }
            // 端末番号
            if (uOEConnectInfo.CashRegisterNo.ToString().Length < 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO] = uOEConnectInfo.CashRegisterNo.ToString().PadLeft(3, '0');
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASHREGISTERNO] = uOEConnectInfo.CashRegisterNo.ToString();
            }
            // 通信ポート番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SOCKETCOMMPORT] = uOEConnectInfo.SocketCommPort.ToString();
            // 接続先コンピュータ名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVECOMPUTERNM] = uOEConnectInfo.ReceiveComputerNm.Trim();
            // クライアントタイムアウト
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CLIENTTIMEOUT] = uOEConnectInfo.ClientTimeOut.ToString();
            //GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = uOEConnectInfo.FileHeaderGuid;

            // インスタンステーブルにもセットする
            if (this._uOEConnectInfoTable.ContainsKey(uOEConnectInfo.FileHeaderGuid) == true)
            {
                this._uOEConnectInfoTable.Remove(uOEConnectInfo.FileHeaderGuid);
            }
            this._uOEConnectInfoTable.Add(uOEConnectInfo.FileHeaderGuid, uOEConnectInfo);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable uOEConnectInfoTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。
            uOEConnectInfoTable.Columns.Add(DELETE_DATE, typeof(string));               //削除日
            uOEConnectInfoTable.Columns.Add(VIEW_COMMASSEMBLYID, typeof(string));       //通信アセンブリID
            uOEConnectInfoTable.Columns.Add(VIEW_CASHREGISTERNO, typeof(string));          //端末番号
            uOEConnectInfoTable.Columns.Add(VIEW_SOCKETCOMMPORT, typeof(int));          //通信ポート番号
            uOEConnectInfoTable.Columns.Add(VIEW_RECEIVECOMPUTERNM, typeof(string));    //接続先コンピュータ名
            uOEConnectInfoTable.Columns.Add(VIEW_CLIENTTIMEOUT, typeof(int));           //クライアントタイムアウト
            uOEConnectInfoTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(uOEConnectInfoTable);
        }

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面の初期設定を行います。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 画面を初期化します
            EditClear();
        }

        /// <summary>
        /// エディットボックス初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面を初期化します</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// </remarks>
        private void EditClear()
        {
            this.CommAssemblyId_tEdit.Text = string.Empty;              //通信アセンブリID
            this.CashRegisterNo_tEdit.Text = string.Empty;				// 端末番号
            this.SocketCommPort_tEdit.Text = string.Empty;				// 通信ポート番号
            this.ReceiveComputerNm_tEdit.Text = string.Empty;		    // 接続先コンピュータ名
            this.ClientTimeOut_tEdit.Text = string.Empty;				// クライアントタイムアウト
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                //_dataIndexバッファ保持
                this._indexBuf = this._dataIndex;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // 通信アセンブリID設定
                this.CommAssemblyId_tEdit.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                UOEConnectInfo uOEConnectInfo = (UOEConnectInfo)this._uOEConnectInfoTable[guid];

                // 画面展開処理
                UOEConnectInfoToScreen(uOEConnectInfo);

                if (uOEConnectInfo.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // クローン作成
                    this._uOEConnectInfoClone = uOEConnectInfo.Clone();
                    // 画面情報UOE接続先情報マスタメンテナンスクラス格納処理
                    DispToUOEConnectInfo(ref this._uOEConnectInfoClone);

                    this.SocketCommPort_tEdit.Focus();
                    this.SocketCommPort_tEdit.SelectAll();
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面情報UOE接続先情報マスタメンテナンスクラス格納処理
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からUOE接続先情報マスタオブジェクトにデータを格納します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void DispToUOEConnectInfo(ref UOEConnectInfo uOEConnectInfo)
        {
            if (uOEConnectInfo == null)
            {
                // 新規の場合
                uOEConnectInfo = new UOEConnectInfo();
            }

            // 各項目のセット
            // 企業コード
            uOEConnectInfo.EnterpriseCode = this._enterpriseCode;
            // 通信アセンブリID
            uOEConnectInfo.CommAssemblyId = this.CommAssemblyId_tEdit.Text.Trim();
            // 端末番号
            int cashRegisterNo = 0;
            if (int.TryParse(this.CashRegisterNo_tEdit.Text.Trim(), out cashRegisterNo))
            {
                uOEConnectInfo.CashRegisterNo = cashRegisterNo;
            }
            else
            {
                uOEConnectInfo.CashRegisterNo = 1000;            //端末番号の最大桁数＋１を設定
            }
            // 通信ポート番号
            int socketCommPort = 0;
            if (int.TryParse(this.SocketCommPort_tEdit.Text.Trim(), out socketCommPort))
            {
                uOEConnectInfo.SocketCommPort = socketCommPort;
            }
            else
            {
                uOEConnectInfo.SocketCommPort = 1000000;         //通信ポート番号の最大桁数＋１を設定
            }
            // 接続先コンピュータ名
            uOEConnectInfo.ReceiveComputerNm = this.ReceiveComputerNm_tEdit.Text.Trim();
            // クライアントタイムアウト
            int clientTimeOut = 0;
            if (int.TryParse(this.ClientTimeOut_tEdit.Text.Trim(), out clientTimeOut))
            {
                uOEConnectInfo.ClientTimeOut = clientTimeOut;
            }
            else
            {
                uOEConnectInfo.ClientTimeOut = 1000000;         //クライアントタイムアウトの最大桁数＋１を設定
            }
        }

        /// <summary>
        /// UOE接続先情報マスタメンテナンスクラス画面展開処理
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタオブジェクトから画面にデータを展開します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void UOEConnectInfoToScreen(UOEConnectInfo uOEConnectInfo)
        {
            // 各項目のセット
            // 通信アセンブリID
            this.CommAssemblyId_tEdit.Text = uOEConnectInfo.CommAssemblyId.Trim().PadLeft(4, '0');
            // 端末番号
            this.CashRegisterNo_tEdit.Text = uOEConnectInfo.CashRegisterNo.ToString().PadLeft(3, '0');
            // 通信ポート番号
            this.SocketCommPort_tEdit.Text = uOEConnectInfo.SocketCommPort.ToString();
            // 接続先コンピュータ名
            this.ReceiveComputerNm_tEdit.Text = uOEConnectInfo.ReceiveComputerNm;
            // クライアントタイムアウト
            this.ClientTimeOut_tEdit.Text = uOEConnectInfo.ClientTimeOut.ToString();
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // 入力項目
                    this.CommAssemblyId_tEdit.Enabled = true;
                    this.CashRegisterNo_tEdit.Enabled = true;
                    this.SocketCommPort_tEdit.Enabled = true;
                    this.ReceiveComputerNm_tEdit.Enabled = true;
                    this.ClientTimeOut_tEdit.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    break;
                case UPDATE_MODE:
                    // 入力項目
                    this.CommAssemblyId_tEdit.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = false;
                    this.SocketCommPort_tEdit.Enabled = true;
                    this.ReceiveComputerNm_tEdit.Enabled = true;
                    this.ClientTimeOut_tEdit.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    break;
                case DELETE_MODE:
                    // 入力項目
                    this.CommAssemblyId_tEdit.Enabled = false;
                    this.CashRegisterNo_tEdit.Enabled = false;
                    this.SocketCommPort_tEdit.Enabled = false;
                    this.ReceiveComputerNm_tEdit.Enabled = false;
                    this.ClientTimeOut_tEdit.Enabled = false;

                    // ボタン
                    this.Ok_Button.Visible = false;
                    this.Close_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// OK_Button_Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 保存ボタンクリックイベント</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 保存前データチェック
            if (!IsValueCheck())
            {
                // チェックＮＧの場合処理終了
                return;
            }
            // データ保存
            if (!IsSaveProc())
            {
                // 保存に失敗したときは処理終了
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 保存前データチェックメソッド
        /// </summary>
        /// <returns>チェック結果｛true : チェックＯＫ | false : チェックＮＧ｝</returns>
        /// <remarks>
        /// <br>Note		: 保存前データチェックメソッド</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private bool IsValueCheck()
        {
            string errorMsg = string.Empty;	// エラーメッセージ格納
            int setFocusNum = 0;	// フォーカスセットするための区分

            try
            {
                // エラーチェック
                setFocusNum = CheckError(ref errorMsg);
            }
            finally
            {
                if (setFocusNum == 0)
                {
                    // 正常
                }
                else
                {
                    // 警告メッセージの表示
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,							// アセンブリID
                        errorMsg,	                        　　// 表示するメッセージ
                        0,   									// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

                    // フォーカスセット
                    SetFocusToComponent(setFocusNum);
                }
            }
            if (setFocusNum == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <returns>Status｛成功：true ｜ 失敗：false｝</returns>
        /// <remarks>
        /// <br>Note		: データの保存処理を行います。</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private bool IsSaveProc()
        {
            UOEConnectInfo uOEConnectInfo = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                uOEConnectInfo = ((UOEConnectInfo)this._uOEConnectInfoTable[guid]).Clone();
            }
            else
            {
                uOEConnectInfo = new UOEConnectInfo();
            }

            this.DispToUOEConnectInfo(ref uOEConnectInfo);

            int status = this._uOEConnectInfoAcs.Write(ref uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            "データが既に存在しています。",		// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

                        this.CommAssemblyId_tEdit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            "UOE接続先情報マスタ",							// プログラム名称
                            "IsSaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "登録に失敗しました。",						// 表示するメッセージ 
                            status,								// ステータス値
                            this._uOEConnectInfoAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet展開処理
            UOEConnectInfoToDataSet(uOEConnectInfo, this.DataIndex);

            return true;

        }

        /// <summary>
        /// エラーチェック処理
        /// </summary>
        /// <param name="errorMsg">エラーメッセージ格納用変数（受け取り時は空）</param>
        /// <returns>フォーカスをセットするコンポーネント</returns>
        /// <remarks>
        /// <br>Note		: コンポーネントにフォーカスをセットします。</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private int CheckError(ref string errorMsg)
        {
            // フォーカスセットするエディットの番号
            int setFocusNum = 0;

            // 通信アセンブリIDが入力されていない場合
            if (String.IsNullOrEmpty(this.CommAssemblyId_tEdit.DataText.Trim()))
            {
                errorMsg = "通信アセンブリIDを入力してく下さい。";
                setFocusNum = 11;
                return setFocusNum;
            }
            int commAssemblyId = 0;
            if (!int.TryParse(this.CommAssemblyId_tEdit.DataText, out commAssemblyId))
            {
                errorMsg = "通信アセンブリIDに入力文字列の形式が正しくありません。";
                setFocusNum = 12;
                return setFocusNum;
            }

            // 端末番号場合のcheck
            if (String.IsNullOrEmpty(this.CashRegisterNo_tEdit.DataText.Trim()))
            {
                errorMsg = "端末番号を入力してく下さい。";
                setFocusNum = 1;
                return setFocusNum;
            }
            int cashRegisterNo = 0;
            if (!int.TryParse(this.CashRegisterNo_tEdit.DataText, out cashRegisterNo))
            {
                errorMsg = "端末番号に入力文字列の形式が正しくありません。";
                setFocusNum = 2;
                return setFocusNum; 
            }

            // 通信ポート番号が設定されていないとだめ
            if (String.IsNullOrEmpty(this.SocketCommPort_tEdit.DataText.Trim()))
            {
                errorMsg = "通信ポート番号を入力してく下さい。";
                setFocusNum = 3;
                return setFocusNum;


            }
            int socketCommPort = 0;
            if (!int.TryParse(this.SocketCommPort_tEdit.DataText, out socketCommPort))
            {
                errorMsg = "通信ポート番号に入力文字列の形式が正しくありません。";
                setFocusNum = 6;
                return setFocusNum;
            }

            // 接続先コンピュータ名が設定されていないとだめ
            if (String.IsNullOrEmpty(this.ReceiveComputerNm_tEdit.DataText.Trim()))
            {
                errorMsg = "接続先コンピュータ名を入力してく下さい。";
                setFocusNum = 4;
                return setFocusNum;
            }

            // クライアントタイムアウトが設定されていないとだめ
            if (String.IsNullOrEmpty(this.ClientTimeOut_tEdit.DataText.Trim()))
            {
                errorMsg = "クライアントタイムアウトを入力してく下さい。";
                setFocusNum = 5;
                return setFocusNum;
            }
            int clientTimeOut = 0;
            if (!int.TryParse(this.ClientTimeOut_tEdit.DataText, out clientTimeOut))
            {
                errorMsg = "クライアントタイムアウトに入力文字列の形式が正しくありません。";
                setFocusNum = 7;
                return setFocusNum;
            }

            return setFocusNum;
        }

        /// <summary>
        /// フォーカスセット処理
        /// </summary>
        /// <param name="setFocusNum">フォーカスセットするコンポーネント番号</param>
        /// <remarks>
        /// <br>Note		: コンポーネントにフォーカスをセットします。</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private void SetFocusToComponent(int setFocusNum)
        {
            if (setFocusNum != 0)
            {
                //フォーカスセット
                switch (setFocusNum)
                {
                    case 11:
                        {
                            // 通信アセンブリID
                            this.CommAssemblyId_tEdit.Focus();
                            break;
                        }
                    case 12:
                        {
                            // 通信アセンブリID
                            this.CommAssemblyId_tEdit.Focus();
                            break;
                        }
                    case 1:
                        {
                            // 端末番号
                            this.CashRegisterNo_tEdit.Focus();
                            break;
                        }
                    case 2:
                        {
                            // 端末番号
                            this.CashRegisterNo_tEdit.Focus();
                            break;
                        }
                    case 3:
                        {
                            // 通信ポート番号
                            this.SocketCommPort_tEdit.Focus();
                            break;
                        }
                    case 6:
                        {
                            // 通信ポート番号
                            this.SocketCommPort_tEdit.Focus();
                            break;
                        }
                    case 4:
                        {
                            // 接続先コンピュータ名
                            this.ReceiveComputerNm_tEdit.Focus();
                            break;
                        }
                    case 5:
                        {
                            // クライアントタイムアウト
                            this.ClientTimeOut_tEdit.Focus();
                            break;
                        }
                    case 7:
                        {
                            // クライアントタイムアウト
                            this.ClientTimeOut_tEdit.Focus();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return;
            }
            
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            "既に他端末より更新されています。",	    // 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            "既に他端末より削除されています。",	    // 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._dataIndex = -1;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion Private Method End

        # region Control Events
        /// <summary>
        ///	Form.Load イベント(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void PMUOE09050UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する			
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Close_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Close_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            // 画面初期設定処理
            ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : 画面の表示、非表示が変わった時に発生します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void PMUOE09050UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();

                return;
            }

            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            timer1.Enabled = true;

            ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.Load イベント(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void Close_Button_Click(object sender, System.EventArgs e)
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                //画面情報を取得する
                string CommAssemblyId = this.CommAssemblyId_tEdit.DataText.Trim();
                string CashRegisterNo = this.CashRegisterNo_tEdit.DataText.Trim();
                string SocketCommPort = this.SocketCommPort_tEdit.DataText.Trim();
                string ReceiveComputerNm = this.ReceiveComputerNm_tEdit.DataText.Trim();
                string ClientTimeOut = this.ClientTimeOut_tEdit.DataText.Trim();
                //最初に取得した画面情報と比較
                if (!String.IsNullOrEmpty(CommAssemblyId) || !String.IsNullOrEmpty(CashRegisterNo) || !String.IsNullOrEmpty(SocketCommPort) || !String.IsNullOrEmpty(ReceiveComputerNm) || !String.IsNullOrEmpty(ClientTimeOut))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!IsValueCheck() || !IsSaveProc())
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                this.Close_Button.Focus();
                                return;
                            }
                    }
                }
            }
            // 削除モード以外の場合は保存確認処理を行う
            else if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                UOEConnectInfo compareUOEConnectInfo = new UOEConnectInfo();
                compareUOEConnectInfo = this._uOEConnectInfoClone.Clone();
                //現在の画面情報を取得する
                DispToUOEConnectInfo(ref compareUOEConnectInfo);
                //最初に取得した画面情報と比較
                if (!(this._uOEConnectInfoClone.Equals(compareUOEConnectInfo)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!IsValueCheck() || !IsSaveProc())
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                this.Close_Button.Focus();
                                return;
                            }
                    }
                }
            }

                this.DialogResult = DialogResult.Cancel;
                this._indexBuf = -2;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
        

        /// <summary>
        /// Form.Closingイベント(PMUOE09050UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームクローズ時のイベントです</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// </remarks>
        private void PMUOE09050UA_Closing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// タイマー処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : タイマー処理</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
            // 画面再構築処理
            ScreenReconstruction();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            UOEConnectInfo uOEConnectInfo = ((UOEConnectInfo)this._uOEConnectInfoTable[guid]).Clone();

            // UOE接続先情報マスタ削除処理
            int status = this._uOEConnectInfoAcs.Delete(uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._uOEConnectInfoTable.Remove(uOEConnectInfo.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._uOEConnectInfoAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programer  : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // 復活対象データ取得
            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            UOEConnectInfo uOEConnectInfo = ((UOEConnectInfo)this._uOEConnectInfoTable[guid]).Clone();

            // UOE接続先情報マスタ論理削除復活処理
            int status = this._uOEConnectInfoAcs.Revival(ref uOEConnectInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        UOEConnectInfoToDataSet(uOEConnectInfo, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._uOEConnectInfoAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Leave  イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 通信アセンブリIDは４桁が不足時に発生します。</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/08/05</br>
        /// </remarks>
        private void CommAssemblyId_tEdit_Leave(object sender, EventArgs e)
        {
            this.CommAssemblyId_tEdit.DataText = this.CommAssemblyId_tEdit.DataText.Trim();

            // ４桁が不足時、左に「０」を補足
            if (this.CommAssemblyId_tEdit.DataText.Length < 4 && this.CommAssemblyId_tEdit.DataText.Length > 0)
            {
                this.CommAssemblyId_tEdit.DataText = this.CommAssemblyId_tEdit.DataText.PadLeft(4, '0');
            }
        }

        /// <summary>
        /// Leave  イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 端末番号は３桁が不足時に発生します。</br>
        /// <br>Programer   : caowj</br>
        /// <br>Date	    : 2010/08/05</br>
        /// </remarks>
        private void CashRegisterNo_tEdit_Leave(object sender, EventArgs e)
        {
            this.CashRegisterNo_tEdit.DataText = this.CashRegisterNo_tEdit.DataText.Trim();

            // 3桁が不足時、左に「０」を補足
            if (this.CashRegisterNo_tEdit.DataText.Length < 3 && this.CashRegisterNo_tEdit.DataText.Length > 0)
            {
                this.CashRegisterNo_tEdit.DataText = this.CashRegisterNo_tEdit.DataText.PadLeft(3, '0');
            }
        }
        #endregion Control Events End
    }
}
