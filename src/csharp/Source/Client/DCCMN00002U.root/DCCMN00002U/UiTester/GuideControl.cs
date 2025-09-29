using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Library.Windows.Forms
{
    # region ■ ガイドボタン ■
    /// <summary>
    /// ガイドボタンクラス
    /// </summary>
    /// <remarks>
    /// <br>ガイドコントロールクラスによる、マスタ読み込み・ガイド表示を</br>
    /// <br>サポートするウルトラボタンクラスです。</br>
    /// <br></br>
    /// </remarks>
    [ToolboxBitmap( typeof( GuideButton ), "GuideButton.bmp" )]
    public class GuideButton : Infragistics.Win.Misc.UltraButton
    {
        # region [private fields]
        private Control _codeControl;
        private Control _nameControl;
        private Control _guideNextControl;
        private GuideTypeDiv _guideType;

        private GuideControl _guideControl;
        private bool _allowNoInput;

        private string _readTitle;
        # endregion

        # region [public propaties]
        /// <summary>
        /// 項目タイトル
        /// </summary>
        [Category( "Read動作" )]
        public string ReadTitle
        {
            get { return _readTitle; }
            set { _readTitle = value; }
        }
        /// <summary>
        /// 未入力許可
        /// </summary>
        [Category( "Read動作" )]
        public bool AllowNoInput
        {
            get { return _allowNoInput; }
            set 
            { 
                _allowNoInput = value;

                setCodeEditColor();
            }
        }
        /// <summary>
        /// コード項目
        /// </summary>
        [Category( "ガイド動作" )]
        public Control CodeControl
        {
            get { return _codeControl; }
            set { _codeControl = value; }
        }
        /// <summary>
        /// 名称項目
        /// </summary>
        [Category( "ガイド動作" )]
        public Control NameControl
        {
            get { return _nameControl; }
            set { _nameControl = value; }
        }
        /// <summary>
        /// ガイド選択後 次項目
        /// </summary>
        [Category( "ガイド動作" )]
        public Control GuideNextControl
        {
            get { return _guideNextControl; }
            set { _guideNextControl = value; }
        }
        /// <summary>
        /// ガイド種別
        /// </summary>
        [Category( "ガイド動作" )]
        public GuideTypeDiv GuideType
        {
            get { return _guideType; }
            set
            {
                _guideType = value;
                _readTitle = GetGuideTypeName();
            }
        }
        # endregion

        # region [constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GuideButton()
        {
            this.Paint += new PaintEventHandler( GuideButton_Paint );
            this.Click += new EventHandler( GuideButton_Click );
            this.Resize += new EventHandler( GuideButton_Resize );
        }
        #endregion

        # region [static members]
        static Color editBackColor = Color.FromArgb( 179, 219, 231 );
        static Color editBackColorDisabled = System.Drawing.SystemColors.Control;
        # endregion

        # region [private methods]
        /// <summary>
        /// 親コントロールロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GuideButtonParent_Load( object sender, EventArgs e )
        {
            // 親コントロールのロードタイミングで自分のイメージをセットする
            this.SetIconImage( Size16_Index.STAR1 );
        }
        /// <summary>
        /// リサイズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GuideButton_Resize( object sender, EventArgs e )
        {
            this.Width = 25;
            this.Height = 25;
        }
        /// <summary>
        /// ボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideButton_Click( object sender, EventArgs e )
        {
            this._guideControl.ExecuteGuid();
        }
        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideButton_Paint( object sender, PaintEventArgs e )
        {
            this.Text = "";
            this.Width = 25;
            this.Height = 25;

            if ( !DesignMode )
            {
                if ( this._guideControl == null )
                {
                    //if ( this.Created )
                    //{
                    //    SetIconImage( Size16_Index.STAR1 );
                    //}
                    this._guideControl = GetGuideControl();

                    if ( _guideControl != null )
                    {
                        this._guideControl.AllowNoInput = _allowNoInput;
                        this._guideControl.NoInput += new EventHandler( _guideControl_NoInput );
                        this._guideControl.NotFound += new EventHandler( _guideControl_NotFound );

                        this._readTitle = GetGuideTypeName();

                        setCodeEditColor();
                    }
                }
            }
        }
        /// <summary>
        /// コード項目の背景色初期化
        /// </summary>
        private void setCodeEditColor()
        {
            if ( CodeControl != null && CodeControl is TEdit )
            {
                if ( this._allowNoInput )
                {
                    (CodeControl as TEdit).Appearance.BackColor = Color.White;
                    (CodeControl as TEdit).Appearance.BackColorDisabled = Color.White;
                }
                else
                {
                    (CodeControl as TEdit).Appearance.BackColor = editBackColor;
                    (CodeControl as TEdit).Appearance.BackColorDisabled = editBackColorDisabled;
                }
            }
        }

        /// <summary>
        /// 読み込み　非存在時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _guideControl_NotFound( object sender, EventArgs e )
        {
            MessageBox.Show( string.Format( "{0}が存在しません。", _readTitle ) );
        }
        /// <summary>
        /// 読み込み　未入力時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _guideControl_NoInput( object sender, EventArgs e )
        {
            MessageBox.Show( string.Format( "{0}を入力して下さい。", _readTitle ) );
        }
        /// <summary>
        /// ガイドタイプ名称取得
        /// </summary>
        /// <returns></returns>
        private string GetGuideTypeName()
        {
            switch ( _guideType )
            {
                case GuideTypeDiv.Section:
                    return "拠点";
                case GuideTypeDiv.Customer:
                    return "得意先";
                case GuideTypeDiv.Employee:
                    return "担当者";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ガイドコントロールインスタンス取得処理
        /// </summary>
        /// <returns></returns>
        private GuideControl GetGuideControl()
        {
            switch ( _guideType )
            {
                case GuideTypeDiv.Section:
                    return new SectionGuideControl( LoginInfoAcquisition.EnterpriseCode, this._codeControl, this._nameControl, this._guideNextControl );
                case GuideTypeDiv.Customer:
                    return new CustomerGuideControl( LoginInfoAcquisition.EnterpriseCode, this._codeControl, this._nameControl, this._guideNextControl );
                case GuideTypeDiv.Employee:
                    return new EmployeeGuideControl( LoginInfoAcquisition.EnterpriseCode, this._codeControl, this._nameControl, this._guideNextControl );
                default:
                    return null;
            }
        }
        /// <summary>
        /// ボタンイメージ設定処理
        /// </summary>
        /// <param name="iconIndex"></param>
        private void SetIconImage( Size16_Index iconIndex )
        {
            this.ImageList = IconResourceManagement.ImageList16;
            this.Appearance.Image = iconIndex;
        }
        # endregion

        # region [public methods]
        /// <summary>
        /// マスタ読み込み処理
        /// </summary>
        /// <returns></returns>
        public int Read()
        {
            return _guideControl.Read();
        }
        # endregion
    }

    /// <summary>
    /// ガイドタイプ
    /// </summary>
    public enum GuideTypeDiv
    {
        /// <summary>
        /// 拠点
        /// </summary>
        Section = 0,
        /// <summary>
        /// 得意先
        /// </summary>
        Customer = 1,
        /// <summary>
        /// 担当者
        /// </summary>
        Employee = 2,
    }
    # endregion ■ ガイドボタン ■

    # region ■ ガイドコントロール ■
    /// <summary>
    /// ガイドコントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>マスタ読み込み・ガイド表示をコントロールするクラスです。</br>
    /// <br>プロパティで設定されたコード項目・名称項目に結果を出力します。</br>
    /// <br>（GuideControlはその他のガイドコントロールの基本となるクラスです）</br>
    /// </remarks>
    public class GuideControl
    {
        # region [private fields]
        // 企業コード
        private string _enterpriseCode;
        // コード項目
        private Control _codeControl;
        // 名称項目
        private Control _nameControl;
        // 前回入力内容
        private string _prevInputCode;
        // 文字列コード区分
        private bool _codeIsString;
        // 未入力許可
        protected bool _allowNoInput;
        // ガイド後次項目
        private Control _guideNextControl;
        # endregion

        # region [public propaty]
        public bool AllowNoInput
        {
            get { return _allowNoInput; }
            set { _allowNoInput = value; }
        }
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        public Control CodeControl
        {
            get { return _codeControl; }
            set { _codeControl = value; }
        }
        public Control NameControl
        {
            get { return _nameControl; }
            set { _nameControl = value; }
        }
        public Control GuideNextControl
        {
            get { return _guideNextControl; }
            set { _guideNextControl = value; }
        }
        # endregion

        # region [constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="guideNextEdit"></param>
        public GuideControl( string enterpriseCode, Control codeEdit, Control nameEdit, Control guideNextEdit, bool codeIsString )
        {
            _enterpriseCode = enterpriseCode;

            _prevInputCode = string.Empty;

            _codeControl = codeEdit;
            _nameControl = nameEdit;
            _guideNextControl = guideNextEdit;

            _codeIsString = codeIsString;

            _allowNoInput = true;
        }
        # endregion

        # region [public methods]
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <returns></returns>
        virtual public int Read()
        {
            int status = 0;

            if ( _codeControl == null )
            {
                return 0;
            }
            string textCode = _codeControl.Text;
            int numCode = 0;
            try
            {
                numCode = Int32.Parse( textCode );
            }
            catch
            {
            }
            int numPrevInputCode = 0;
            try
            {
                numPrevInputCode = Int32.Parse( _prevInputCode );
            }
            catch
            {
            }

            if ( textCode == _prevInputCode || (!_codeIsString && numCode == numPrevInputCode) )
            {
                return 0;
            }
            if ( !(textCode == string.Empty || (!_codeIsString && numCode == 0)) )
            {
                string outCode;
                string outName;
                status = AcsRead( _enterpriseCode, textCode, out outCode, out outName );

                if ( status == 0 )
                {
                    if ( _codeControl != null )
                    {
                        _codeControl.Text = outCode.TrimEnd();
                    }
                    if ( _nameControl != null )
                    {
                        _nameControl.Text = outName.TrimEnd();
                    }
                    _prevInputCode = _codeControl.Text;
                }
                else
                {
                    _codeControl.Text = _prevInputCode;
                    if ( NotFound != null )
                    {
                        NotFound( _codeControl, new EventArgs() );
                    }
                }
            }
            else
            {
                if ( !_allowNoInput )
                {
                    _codeControl.Text = _prevInputCode;
                    if ( NoInput != null )
                    {
                        NoInput( _codeControl, new EventArgs() );
                    }
                    return 9;
                }
                else
                {
                    _prevInputCode = string.Empty;
                    _codeControl.Text = string.Empty;
                    if ( _nameControl != null )
                    {
                        _nameControl.Text = string.Empty;
                    }
                    return 0;
                }
            }

            return status;
        }
        /// <summary>
        /// アクセスクラス読み込み
        /// </summary>
        /// <param name="textCode"></param>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        virtual protected int AcsRead( string enterpriseCode, string textCode, out string outCode, out string outName )
        {
            outCode = string.Empty;
            outName = string.Empty;
            return 0;
        }
        /// <summary>
        /// ガイド呼び出し
        /// </summary>
        /// <returns></returns>
        virtual public int ExecuteGuid()
        {
            string outCode;
            string outName;

            int status = AcsExecuteGuid( _enterpriseCode, out outCode, out outName );
            if ( status == 0 )
            {
                if ( _codeControl != null )
                {
                    _codeControl.Text = outCode.TrimEnd();
                }
                if ( _nameControl != null )
                {
                    _nameControl.Text = outName.TrimEnd();
                }
                _prevInputCode = outCode;

                if ( _guideNextControl != null )
                {
                    _guideNextControl.Focus();
                }
            }
            else
            {
            }
            return status;
        }
        /// <summary>
        /// アクセスクラスガイド呼び出し
        /// </summary>
        /// <returns></returns>
        virtual protected int AcsExecuteGuid( string enterpriseCode, out string outCode, out string outName )
        {
            outCode = string.Empty;
            outName = string.Empty;
            return 0;
        }
        # endregion

        # region [events]
        public event EventHandler NotFound;
        public event EventHandler NoInput;
        # endregion
    }
    /// <summary>
    /// 拠点ガイドコントロールクラス
    /// </summary>
    public class SectionGuideControl : GuideControl
    {
        # region [static members]
        // 拠点アクセスクラス
        private static SecInfoSetAcs stc_secInfoSetAcs;
        # endregion

        # region [constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="guideNextEdit"></param>
        public SectionGuideControl( string enterpriseCode, Control codeEdit, Control nameEdit, Control guideNextEdit )
            : base( enterpriseCode, codeEdit, nameEdit, guideNextEdit, true )
        {
        }
        # endregion

        # region [private methods]
        /// <summary>
        /// リード処理
        /// </summary>
        /// <param name="textCode"></param>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        protected override int AcsRead( string enterpriseCode, string textCode, out string outCode, out string outName )
        {
            SecInfoSet secInfoSet;
            if ( stc_secInfoSetAcs == null )
            {
                stc_secInfoSetAcs = new SecInfoSetAcs();
            }
            int status = stc_secInfoSetAcs.Read( out secInfoSet, enterpriseCode, textCode );

            if ( status == 0 )
            {
                outCode = secInfoSet.SectionCode;
                outName = secInfoSet.SectionGuideNm;
            }
            else
            {
                outCode = string.Empty;
                outName = string.Empty;
            }
            return status;
        }
        /// <summary>
        /// ガイド表示処理
        /// </summary>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        protected override int AcsExecuteGuid( string enterpriseCode, out string outCode, out string outName )
        {
            if ( stc_secInfoSetAcs == null )
            {
                stc_secInfoSetAcs = new SecInfoSetAcs();
            }
            SecInfoSet secInfoSet;
            int status = stc_secInfoSetAcs.ExecuteGuid( enterpriseCode, true, out secInfoSet );
            if ( status == 0 )
            {
                outCode = secInfoSet.SectionCode;
                outName = secInfoSet.SectionGuideNm;
            }
            else
            {
                outCode = string.Empty;
                outName = string.Empty;
            }
            return status;
        }
        # endregion
    }
    /// <summary>
    /// 得意先ガイドコントロールクラス
    /// </summary>
    public class CustomerGuideControl : GuideControl
    {
        # region [private members]
        // 得意先アクセスクラス
        private static CustomerInfoAcs stc_CustomerInfoAcs;
        // 得意先ガイド返却用
        private bool _customerSelect;
        private int _customerCode;
        private string _customerName;
        // 得意先ガイド・オーナーフォーム
        private Form _ownerForm;
        # endregion

        # region [public propaties]
        public Form OwnerForm
        {
            get { return _ownerForm; }
            set { _ownerForm = value; }
        }
        # endregion

        # region [constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="guideNextEdit"></param>
        public CustomerGuideControl( string enterpriseCode, Control codeEdit, Control nameEdit, Control guideNextEdit )
            : base( enterpriseCode, codeEdit, nameEdit, guideNextEdit, false )
        {
        }
        # endregion

        # region [private methods]
        /// <summary>
        /// リード処理
        /// </summary>
        /// <param name="textCode"></param>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        protected override int AcsRead( string enterpriseCode, string textCode, out string outCode, out string outName )
        {
            CustomerInfo customerInfo;
            if ( stc_CustomerInfoAcs == null )
            {
                stc_CustomerInfoAcs = new CustomerInfoAcs();
            }
            int status = stc_CustomerInfoAcs.ReadDBData( enterpriseCode, Int32.Parse( textCode ), out customerInfo );

            if ( status == 0 )
            {
                outCode = customerInfo.CustomerCode.ToString().Trim();
                outName = customerInfo.Name;
            }
            else
            {
                outCode = string.Empty;
                outName = string.Empty;
            }
            return status;
        }
        /// <summary>
        /// ガイド表示処理
        /// </summary>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        protected override int AcsExecuteGuid( string enterpriseCode, out string outCode, out string outName )
        {
            SFTOK01370UA customerGuide = new SFTOK01370UA( SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY );
            customerGuide.CustomerSelect += new CustomerSelectEventHandler( stc_CustomerGuide_CustomerSelect );

            _customerSelect = false;
            customerGuide.ShowDialog( OwnerForm );

            int status = 0;

            if ( _customerSelect )
            {
                outCode = _customerCode.ToString().TrimEnd();
                outName = _customerName;
            }
            else
            {
                outCode = string.Empty;
                outName = string.Empty;
                status = 9;
            }
            return status;
        }
        /// <summary>
        /// 得意先ガイド・選択時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void stc_CustomerGuide_CustomerSelect( object sender, Broadleaf.Application.UIData.CustomerSearchRet customerSearchRet )
        {
            _customerCode = customerSearchRet.CustomerCode;
            _customerName = customerSearchRet.Name;
            _customerSelect = true;
        }
        # endregion
    }
    /// <summary>
    /// 担当者ガイド
    /// </summary>
    public class EmployeeGuideControl : GuideControl
    {
        # region [static members]
        // 拠点アクセスクラス
        private static EmployeeAcs stc_EmployeeAcsAcs;
        # endregion

        # region [constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="guideNextEdit"></param>
        public EmployeeGuideControl( string enterpriseCode, Control codeEdit, Control nameEdit, Control guideNextEdit )
            : base( enterpriseCode, codeEdit, nameEdit, guideNextEdit, true )
        {
        }
        # endregion

        # region [private methods]
        /// <summary>
        /// リード処理
        /// </summary>
        /// <param name="textCode"></param>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        protected override int AcsRead( string enterpriseCode, string textCode, out string outCode, out string outName )
        {
            Employee employee;
            if ( stc_EmployeeAcsAcs == null )
            {
                stc_EmployeeAcsAcs = new EmployeeAcs();
            }
            int status = stc_EmployeeAcsAcs.Read( out employee, enterpriseCode, textCode );

            if ( status == 0 )
            {
                outCode = employee.EmployeeCode;
                outName = employee.Name;
            }
            else
            {
                outCode = string.Empty;
                outName = string.Empty;
            }
            return status;
        }
        /// <summary>
        /// ガイド表示処理
        /// </summary>
        /// <param name="outCode"></param>
        /// <param name="outName"></param>
        /// <returns></returns>
        protected override int AcsExecuteGuid( string enterpriseCode, out string outCode, out string outName )
        {
            if ( stc_EmployeeAcsAcs == null )
            {
                stc_EmployeeAcsAcs = new EmployeeAcs();
            }
            Employee employee;
            int status = stc_EmployeeAcsAcs.ExecuteGuid( enterpriseCode, true, out employee );
            if ( status == 0 )
            {
                outCode = employee.EmployeeCode;
                outName = employee.Name;
            }
            else
            {
                outCode = string.Empty;
                outName = string.Empty;
            }
            return status;
        }
        # endregion
    }
    # endregion ■ ガイドコントロール ■
}
