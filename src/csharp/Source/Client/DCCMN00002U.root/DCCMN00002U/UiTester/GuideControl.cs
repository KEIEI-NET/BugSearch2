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
    # region �� �K�C�h�{�^�� ��
    /// <summary>
    /// �K�C�h�{�^���N���X
    /// </summary>
    /// <remarks>
    /// <br>�K�C�h�R���g���[���N���X�ɂ��A�}�X�^�ǂݍ��݁E�K�C�h�\����</br>
    /// <br>�T�|�[�g����E���g���{�^���N���X�ł��B</br>
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
        /// ���ڃ^�C�g��
        /// </summary>
        [Category( "Read����" )]
        public string ReadTitle
        {
            get { return _readTitle; }
            set { _readTitle = value; }
        }
        /// <summary>
        /// �����͋���
        /// </summary>
        [Category( "Read����" )]
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
        /// �R�[�h����
        /// </summary>
        [Category( "�K�C�h����" )]
        public Control CodeControl
        {
            get { return _codeControl; }
            set { _codeControl = value; }
        }
        /// <summary>
        /// ���̍���
        /// </summary>
        [Category( "�K�C�h����" )]
        public Control NameControl
        {
            get { return _nameControl; }
            set { _nameControl = value; }
        }
        /// <summary>
        /// �K�C�h�I���� ������
        /// </summary>
        [Category( "�K�C�h����" )]
        public Control GuideNextControl
        {
            get { return _guideNextControl; }
            set { _guideNextControl = value; }
        }
        /// <summary>
        /// �K�C�h���
        /// </summary>
        [Category( "�K�C�h����" )]
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
        /// �R���X�g���N�^
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
        /// �e�R���g���[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GuideButtonParent_Load( object sender, EventArgs e )
        {
            // �e�R���g���[���̃��[�h�^�C�~���O�Ŏ����̃C���[�W���Z�b�g����
            this.SetIconImage( Size16_Index.STAR1 );
        }
        /// <summary>
        /// ���T�C�Y����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GuideButton_Resize( object sender, EventArgs e )
        {
            this.Width = 25;
            this.Height = 25;
        }
        /// <summary>
        /// �{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideButton_Click( object sender, EventArgs e )
        {
            this._guideControl.ExecuteGuid();
        }
        /// <summary>
        /// �`�揈��
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
        /// �R�[�h���ڂ̔w�i�F������
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
        /// �ǂݍ��݁@�񑶍ݎ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _guideControl_NotFound( object sender, EventArgs e )
        {
            MessageBox.Show( string.Format( "{0}�����݂��܂���B", _readTitle ) );
        }
        /// <summary>
        /// �ǂݍ��݁@�����͎�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _guideControl_NoInput( object sender, EventArgs e )
        {
            MessageBox.Show( string.Format( "{0}����͂��ĉ������B", _readTitle ) );
        }
        /// <summary>
        /// �K�C�h�^�C�v���̎擾
        /// </summary>
        /// <returns></returns>
        private string GetGuideTypeName()
        {
            switch ( _guideType )
            {
                case GuideTypeDiv.Section:
                    return "���_";
                case GuideTypeDiv.Customer:
                    return "���Ӑ�";
                case GuideTypeDiv.Employee:
                    return "�S����";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �K�C�h�R���g���[���C���X�^���X�擾����
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
        /// �{�^���C���[�W�ݒ菈��
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
        /// �}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <returns></returns>
        public int Read()
        {
            return _guideControl.Read();
        }
        # endregion
    }

    /// <summary>
    /// �K�C�h�^�C�v
    /// </summary>
    public enum GuideTypeDiv
    {
        /// <summary>
        /// ���_
        /// </summary>
        Section = 0,
        /// <summary>
        /// ���Ӑ�
        /// </summary>
        Customer = 1,
        /// <summary>
        /// �S����
        /// </summary>
        Employee = 2,
    }
    # endregion �� �K�C�h�{�^�� ��

    # region �� �K�C�h�R���g���[�� ��
    /// <summary>
    /// �K�C�h�R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>�}�X�^�ǂݍ��݁E�K�C�h�\�����R���g���[������N���X�ł��B</br>
    /// <br>�v���p�e�B�Őݒ肳�ꂽ�R�[�h���ځE���̍��ڂɌ��ʂ��o�͂��܂��B</br>
    /// <br>�iGuideControl�͂��̑��̃K�C�h�R���g���[���̊�{�ƂȂ�N���X�ł��j</br>
    /// </remarks>
    public class GuideControl
    {
        # region [private fields]
        // ��ƃR�[�h
        private string _enterpriseCode;
        // �R�[�h����
        private Control _codeControl;
        // ���̍���
        private Control _nameControl;
        // �O����͓��e
        private string _prevInputCode;
        // ������R�[�h�敪
        private bool _codeIsString;
        // �����͋���
        protected bool _allowNoInput;
        // �K�C�h�㎟����
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
        /// �R���X�g���N�^
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
        /// �ǂݍ��ݏ���
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
        /// �A�N�Z�X�N���X�ǂݍ���
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
        /// �K�C�h�Ăяo��
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
        /// �A�N�Z�X�N���X�K�C�h�Ăяo��
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
    /// ���_�K�C�h�R���g���[���N���X
    /// </summary>
    public class SectionGuideControl : GuideControl
    {
        # region [static members]
        // ���_�A�N�Z�X�N���X
        private static SecInfoSetAcs stc_secInfoSetAcs;
        # endregion

        # region [constructor]
        /// <summary>
        /// �R���X�g���N�^
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
        /// ���[�h����
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
        /// �K�C�h�\������
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
    /// ���Ӑ�K�C�h�R���g���[���N���X
    /// </summary>
    public class CustomerGuideControl : GuideControl
    {
        # region [private members]
        // ���Ӑ�A�N�Z�X�N���X
        private static CustomerInfoAcs stc_CustomerInfoAcs;
        // ���Ӑ�K�C�h�ԋp�p
        private bool _customerSelect;
        private int _customerCode;
        private string _customerName;
        // ���Ӑ�K�C�h�E�I�[�i�[�t�H�[��
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
        /// �R���X�g���N�^
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
        /// ���[�h����
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
        /// �K�C�h�\������
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
        /// ���Ӑ�K�C�h�E�I����
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
    /// �S���҃K�C�h
    /// </summary>
    public class EmployeeGuideControl : GuideControl
    {
        # region [static members]
        // ���_�A�N�Z�X�N���X
        private static EmployeeAcs stc_EmployeeAcsAcs;
        # endregion

        # region [constructor]
        /// <summary>
        /// �R���X�g���N�^
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
        /// ���[�h����
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
        /// �K�C�h�\������
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
    # endregion �� �K�C�h�R���g���[�� ��
}
