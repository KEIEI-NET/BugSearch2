using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �J�X�^�}�C�YRead�C�x���g�f���Q�[�g
    /// </summary>
    /// <param name="targetControls"></param>
    /// <param name="customizeData"></param>
    //public delegate void CustomizeReadEventHandler( List<Control> targetControls, List<string> customizeData );
    public delegate void CustomizeReadEventHandler( Control[] targetControls, string[] customizeData );
    /// <summary>
    /// �J�X�^�}�C�YWrite�C�x���g�f���Q�[�g
    /// </summary>
    /// <param name="targetControls"></param>
    /// <param name="customizeData"></param>
    //public delegate void CustomizeWriteEventHandler( List<Control> targetControls, out List<string> customizeData );
    public delegate void CustomizeWriteEventHandler( Control[] targetControls, out string[] customizeData );

    # region �� UI���͕ۑ��R���|�[�l���g ��
    /// <summary>
    /// �t�h���͕ۑ��R���|�[�l���g
    /// </summary>
    /// <remarks>
    /// Note       : �t�h�̓��͓��e��ۑ����A����N�����ɕ�������ׂ̃R���|�[�l���g�ł��B<br />
    /// Programmer : 22018 ��� ���b<br />
    /// Date       : 2008.04.21<br />
    /// <br />
    /// Update Note: 2011/08/02 ����� NS���[�U�[���Ǘv�]�ꗗ�A��939��1022<br />
    /// </remarks>    
    [ToolboxBitmap( typeof( UiMemInput ), "UiMemInput.UiMemInput.bmp" ),
     Serializable]
    public partial class UiMemInput : TbsBaseComponent
    {
        # region [private fields]
        /// <summary>OwnerForm����</summary>
        private string _ownerFormName;
        /// <summary>UI���͕ێ��t�@�C���A�N�Z�X</summary>
        private UiMemFileAcs _uiMemFileAcs;
        /// <summary>�ΏۃR���g���[�����X�g</summary>
        private List<Control> _targetControls;
        /// <summary>�I�����������݂���t���O</summary>
        private bool _writeOnClose;
        /// <summary>�J�n���ǂݍ��݂���t���O</summary>
        private bool _readOnLoad;
        /// <summary>�I�v�V�����R�[�h</summary>
        private string _optionCode;
        ///// <summary>OwnerUserControl��Load�����ς݃t���O</summary>
        //private bool _ownerUserControlLoaded;
        # endregion

        # region [public propaties]
        /// <summary>
        /// �ΏۃR���g���[�����X�g
        /// </summary>
        [Category( "����" ),
         Description( "�ΏۃR���g���[���̃��X�g���擾�E�ݒ肵�܂��B" )]
        public List<Control> TargetControls
        {
            //get { return _targetControls; }
            set 
            { 
                _targetControls = value;

                //-------------------------------------------------------
                // ���ȉ��̏����͈ꌩ�Ӗ��������悤�Ɍ����܂����A�d�v�ł��B
                //   OwnerForm�̃\�[�X�ɋL�q����Ă���Load�����������
                //   UiMemInput��Load�������s����悤�ɂ��܂��B
                //-------------------------------------------------------
                if ( OwnerForm is Form )
                {
                    (OwnerForm as Form).Load -= this.OwnerFormOnLoad;
                    (OwnerForm as Form).Load += this.OwnerFormOnLoad;
                }
                else if ( OwnerForm is UserControl )
                {
                    (OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                    (OwnerForm as UserControl).Load += this.OwnerFormOnLoad;
                }
            }
        }
        /// <summary>
        /// �I�����������݃t���O
        /// </summary>
        [Category( "����" ),
         DefaultValue(true),
         Description( "�I�����������݃t���O���擾�E�ݒ肵�܂��B" )]
        public bool WriteOnClose
        {
            get { return _writeOnClose; }
            set { _writeOnClose = value; }
        }
        /// <summary>
        /// �J�n���ǂݍ��݃t���O
        /// </summary>
        [Category( "����" ),
         DefaultValue( true ),
         Description( "�J�n���ǂݍ��݃t���O���擾�E�ݒ肵�܂��B" )]
        public bool ReadOnLoad
        {
            get { return _readOnLoad; }
            set { _readOnLoad = value; }
        }
        /// <summary>
        /// �I�v�V�����R�[�h
        /// </summary>
        [Category( "����" ),
         DefaultValue( "" ),
         Description( "OwnerForm�̐ݒ�𕡐��ێ�����ꍇ��Key�ƂȂ�R�[�h���擾�E�ݒ肵�܂��B" )]
        public string OptionCode
        {
            get 
            {
                if ( _optionCode == null )
                {
                    _optionCode = string.Empty;
                }
                return _optionCode; 
            }
            set { _optionCode = value; }
        }
        # endregion


        # region [Constructor]
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UiMemInput()
        {
            InitializeComponent();

            _ownerFormName = string.Empty;
            _uiMemFileAcs = new UiMemFileAcs();

            _optionCode = string.Empty;
            _targetControls = new List<Control>();
            //this.TargetControls = new List<Control>();
            this.WriteOnClose = true;
            this.ReadOnLoad = true;
            //_ownerUserControlLoaded = false;
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="container"></param>
        public UiMemInput( IContainer container )
        {
            container.Add( this );
            InitializeComponent();

            _ownerFormName = string.Empty;
            _uiMemFileAcs = new UiMemFileAcs();

            _optionCode = string.Empty;
            _targetControls = new List<Control>();
            //this.TargetControls = new List<Control>();
            this.WriteOnClose = true;
            this.ReadOnLoad = true;
            //_ownerUserControlLoaded = false;
        }
        # endregion

        # region [event]
        /// <summary>
        /// �J�X�^�}�C�YRead�C�x���g
        /// </summary>
        [Category( "����" ),
         Description( "�v���O�����ŗL�̃f�[�^Read���������܂��B" )]
        public event CustomizeReadEventHandler CustomizeRead;
        /// <summary>
        /// �J�X�^�}�C�YWrite�C�x���g
        /// </summary>
        [Category( "����" ),
         Description( "�v���O�����ŗL�̃f�[�^Write���������܂��B" )]
        public event CustomizeWriteEventHandler CustomizeWrite;
        # endregion

        # region [public propaties]
        /// <summary>
        /// �{�R���|�[�l���g�̏����ΏۂƂȂ�t�H�[�����擾���͐ݒ肵�܂��B
        /// </summary>
        public override ISynchronizeInvoke OwnerForm
        {
            get { return base.OwnerForm; }

            set
            {
                if ( base.OwnerForm != value )
                {
                    //----------------------------------------------------------
                    // �ύX�O��OwnerForm�ɑ΂���C�x���g�f���Q�[�g���폜����
                    //----------------------------------------------------------
                    if ( base.OwnerForm is ContainerControl )
                    {
                        // �C�x���g�f���Q�[�g���폜����
                        if ( base.OwnerForm is Form )
                        {
                            (base.OwnerForm as Form).Load -= this.OwnerFormOnLoad;
                            (base.OwnerForm as Form).FormClosing -= this.OwnerFormOnFormClosing;
                        }
                        if ( base.OwnerForm is UserControl )
                        {
                            (base.OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                            //(base.OwnerForm as UserControl).VisibleChanged -= this.OwnerFormOnVisibleChanged;
                        }
                    }

                    //----------------------------------------------------------
                    // �ύX���OwnerForm�ɑ΂���ݒ�
                    //----------------------------------------------------------
                    if ( value is ContainerControl || value is Control )
                    {
                        if ( value is Control )
                        {
                            // �R���g���[���̏ꍇ�͔z�u����Ă���t�H�[����T���Đݒ肷��
                            Form form = (value as Control).FindForm();

                            if ( form != null )
                            {
                                base.OwnerForm = form;
                            }
                            else
                            {
                                base.OwnerForm = value;
                            }
                        }
                        else
                        {
                            // �t�H�[���̏ꍇ�͂��̂܂ܐݒ肷��
                            base.OwnerForm = value;
                        }

                        if ( base.OwnerForm is ContainerControl )
                        {
                            if ( base.OwnerForm is Form )
                            {
                                (base.OwnerForm as Form).Load += this.OwnerFormOnLoad;
                                (base.OwnerForm as Form).FormClosing += this.OwnerFormOnFormClosing;
                            }

                            if ( base.OwnerForm is UserControl )
                            {
                                (base.OwnerForm as UserControl).Load += this.OwnerFormOnLoad;
                                //(base.OwnerForm as UserControl).VisibleChanged += this.OwnerFormOnVisibleChanged;
                            }
                        }
                    }
                    else
                    {
                        base.OwnerForm = value;
                    }
                }
            }
        }
        # endregion

        # region [public methods]
        /// <summary>
        /// ���͕ۑ��f�[�^�ǂݍ���
        /// </summary>
        public void ReadMemInput()
        {
            //_ownerUserControlLoaded = true;

            //----------------------------------------------------------------
            // �ǂݍ��ݏ���
            //----------------------------------------------------------------

            // OwnerForm�����A�Z���u�����̂��擾
            string asmName = Path.GetFileNameWithoutExtension( this.OwnerForm.GetType().Assembly.GetName().Name );
            // OwnerForm�̖��̂��擾
            string ownerName = this.OwnerForm.GetType().Name;

            //----------------------------------------------------------------
            // �O����͏��̎擾
            //----------------------------------------------------------------
            UiMemInputDataForm memForm;

            if ( _uiMemFileAcs.ReadMemInput( out memForm, asmName, ownerName, this.OptionCode ) != 0 )
            {
                // �ݒ肪�Ȃ���Ώ������Ȃ�
                return;
            }
            // �f�B�N�V���i������
            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            foreach ( UiMemInputData data in memForm.UiMemInputDatas )
            {
                if ( !dataDic.ContainsKey( data.TargetName ) )
                {
                    dataDic.Add( data.TargetName, data.InputData );
                }
            }

            //----------------------------------------------------------------
            // �e�R���g���[���ɓK�p (Load)
            //----------------------------------------------------------------
            foreach ( Control control in _targetControls )
            {
                if ( !dataDic.ContainsKey( control.Name ) ) continue;

                Type type = control.GetType();

                # region [Type���̑O����͒l�̓K�p]
                if ( IsClassOrSubClass( type, typeof( TDateEdit ) ) )
                {
                    //------------------------------------------------------
                    // ���tEdit
                    //------------------------------------------------------
                    DateTime dateTime = GetDateTime( dataDic[control.Name] );
                    if ( dateTime != DateTime.MinValue )
                    {
                        (control as TDateEdit).SetDateTime( dateTime );
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( TComboEditor ) ) )
                {
                    //------------------------------------------------------
                    // �R���{�{�b�N�X
                    //------------------------------------------------------
                    int index = GetInt( dataDic[control.Name], -1 );
                    if ( 0 <= index && index < (control as TComboEditor).Items.Count )
                    {
                        (control as TComboEditor).SelectedIndex = index;
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( TNedit ) ) )
                {
                    //------------------------------------------------------
                    // ���lEdit
                    //------------------------------------------------------
                    int number;
                    if ( GetInt( dataDic[control.Name], 0, out number ) )
                    {
                        (control as TNedit).SetInt( number );
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( TEdit ) ) )
                {
                    //------------------------------------------------------
                    // ������Edit
                    //------------------------------------------------------
                    if ( dataDic.ContainsKey( control.Name ) )
                    {
                        control.Text = dataDic[control.Name];
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.UltraWinEditors.UltraOptionSet ) ) )
                {
                    //------------------------------------------------------
                    // ���W�I�{�^���O���[�v
                    //------------------------------------------------------
                    Infragistics.Win.UltraWinEditors.UltraOptionSet optSet = (control as Infragistics.Win.UltraWinEditors.UltraOptionSet);

                    int number;
                    if ( GetInt( dataDic[control.Name], 0, out number ) && optSet.ValueList.FindByDataValue( number ) != null )
                    {
                        optSet.Value = number;
                    }
                    else
                    {
                        if ( optSet.ValueList.FindByDataValue( dataDic[control.Name] ) != null )
                        {
                            optSet.Value = dataDic[control.Name];
                        }
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( CheckedListBox ) ) )
                {
                    //------------------------------------------------------
                    // �`�F�b�N���X�g�{�b�N�X
                    //------------------------------------------------------
                    List<int> checkdIndexs = GetNumbersFromCSV( dataDic[control.Name] );

                    if ( checkdIndexs.Count > 0 )
                    {
                        for ( int index = 0; index < (control as CheckedListBox).Items.Count; index++ )
                        {
                            if ( checkdIndexs.Contains( index ) )
                            {
                                (control as CheckedListBox).SetItemChecked( index, true );
                            }
                            else
                            {
                                (control as CheckedListBox).SetItemChecked( index, false );
                            }
                        }
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( RadioButton ) ) )
                {
                    //------------------------------------------------------
                    // ���W�I�{�^��
                    //------------------------------------------------------

                    if ( dataDic[control.Name].ToUpper() == "TRUE" )
                    {
                        (control as RadioButton).Checked = true;
                    }
                    else if ( dataDic[control.Name].ToUpper() == "FALSE" )
                    {
                        (control as RadioButton).Checked = false;
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( CheckBox ) ) )
                {
                    //------------------------------------------------------
                    // �`�F�b�N�{�b�N�X
                    //------------------------------------------------------
                    if ( dataDic[control.Name].ToUpper() == "TRUE" )
                    {
                        (control as CheckBox).Checked = true;
                    }
                    else if ( dataDic[control.Name].ToUpper() == "FALSE" )
                    {
                        (control as CheckBox).Checked = false;
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.Misc.UltraLabel ) ) )
                {
                    //------------------------------------------------------
                    // ���x��
                    //------------------------------------------------------
                    (control as Infragistics.Win.Misc.UltraLabel).Text = dataDic[control.Name];
                }
                else if ( IsClassOrSubClass( type, typeof( Label ) ) )
                {
                    //------------------------------------------------------
                    // ���x��
                    //------------------------------------------------------
                    (control as Label).Text = dataDic[control.Name];
                }
                # endregion
            }

            //----------------------------------------------------------------
            // �J�X�^�}�C�YRead�C�x���g
            //----------------------------------------------------------------
            if ( this.CustomizeRead != null )
            {
                CustomizeRead( _targetControls.ToArray(), memForm.CustomizeData.ToArray() );
            }
        }
        /// <summary>
        /// ���͕ۑ��f�[�^��������
        /// </summary>
        public void WriteMemInput()
        {
            //----------------------------------------------------------------
            // �ǂݍ��ݏ���
            //----------------------------------------------------------------

            // OwnerForm�����A�Z���u�����̂��擾
            string asmName = Path.GetFileNameWithoutExtension( this.OwnerForm.GetType().Assembly.GetName().Name );
            // OwnerForm�̖��̂��擾
            string ownerName = this.OwnerForm.GetType().Name;

            //----------------------------------------------------------------
            // �O����͏��̎擾
            //----------------------------------------------------------------
            UiMemInputDataForm memForm;

            if ( _uiMemFileAcs.ReadMemInput( out memForm, asmName, ownerName, this.OptionCode ) != 0 )
            {
                // �ݒ肪�Ȃ���ΐV�K�쐬
                memForm = new UiMemInputDataForm();
                memForm.FormName = ownerName;
                memForm.OptionCode = this.OptionCode;
                //memForm.UiMemInputDatas = new List<UiMemInputData>();   // DEL 2011/08/02
            }
            memForm.UiMemInputDatas = new List<UiMemInputData>();   // ADD 2011/08/02

            //----------------------------------------------------------------
            // �e�R���g���[���̕ۑ� (FormClosing)
            //----------------------------------------------------------------
            foreach ( Control control in _targetControls )
            {
                Type type = control.GetType();
                string inputData = string.Empty;

                # region [Type���̍�����͒l�̕ۑ�]
                if ( IsClassOrSubClass( type, typeof( TDateEdit ) ) )
                {
                    //------------------------------------------------------
                    // ���tEdit
                    //------------------------------------------------------
                    inputData = (control as TDateEdit).GetLongDate().ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( TComboEditor ) ) )
                {
                    //------------------------------------------------------
                    // �R���{�{�b�N�X
                    //------------------------------------------------------
                    inputData = (control as TComboEditor).SelectedIndex.ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( TNedit ) ) )
                {
                    //------------------------------------------------------
                    // ���lEdit
                    //------------------------------------------------------
                    inputData = (control as TNedit).GetInt().ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( TEdit ) ) )
                {
                    //------------------------------------------------------
                    // ������Edit
                    //------------------------------------------------------
                    inputData = (control as TEdit).Text;
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.UltraWinEditors.UltraOptionSet ) ) )
                {
                    //------------------------------------------------------
                    // ���W�I�{�b�N�X�O���[�v
                    //------------------------------------------------------
                    if ( (control as Infragistics.Win.UltraWinEditors.UltraOptionSet).Value != null )
                    {
                        inputData = (control as Infragistics.Win.UltraWinEditors.UltraOptionSet).Value.ToString();
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( CheckedListBox ) ) )
                {
                    //------------------------------------------------------
                    // �`�F�b�N���X�g�{�b�N�X
                    //------------------------------------------------------
                    string checkedIndexs = string.Empty;

                    CheckedListBox chkListBox = (control as CheckedListBox);
                    for ( int index = 0; index < chkListBox.Items.Count; index++ )
                    {
                        if ( chkListBox.GetItemChecked( index ) )
                        {
                            if ( checkedIndexs != string.Empty )
                            {
                                checkedIndexs += ",";
                            }
                            checkedIndexs += index.ToString();
                        }
                    }
                    inputData = checkedIndexs;
                }
                else if ( IsClassOrSubClass( type, typeof( RadioButton ) ) )
                {
                    //------------------------------------------------------
                    // ���W�I�{�^��
                    //------------------------------------------------------
                    inputData = (control as RadioButton).Checked.ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( CheckBox ) ) )
                {
                    //------------------------------------------------------
                    // �`�F�b�N�{�b�N�X
                    //------------------------------------------------------
                    inputData = (control as CheckBox).Checked.ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.Misc.UltraLabel ) ) )
                {
                    //------------------------------------------------------
                    // �E���g�����x��
                    //------------------------------------------------------
                    inputData = (control as Infragistics.Win.Misc.UltraLabel).Text;
                }
                else if ( IsClassOrSubClass( type, typeof( Label ) ) )
                {
                    //------------------------------------------------------
                    // ���x��
                    //------------------------------------------------------
                    inputData = (control as Label).Text;
                }
                # endregion

                // �Z�b�g
                memForm.UiMemInputDatas.Add( new UiMemInputData( control.Name, inputData ) );
            }

            //----------------------------------------------------------------
            // �J�X�^�}�C�YWrite�C�x���g
            //----------------------------------------------------------------
            if ( this.CustomizeWrite != null )
            {
                string[] customizeData;
                CustomizeWrite( _targetControls.ToArray(), out customizeData );
                memForm.CustomizeData = new List<string>( customizeData );
            }

            // ������͏��̕ۑ�
            _uiMemFileAcs.WriteMemInput( memForm, asmName );
        }

        # endregion

        # region [private methods]
        /// <summary>
        /// �^��v���菈��
        /// </summary>
        /// <param name="type">���肷��^</param>
        /// <param name="targetType">�w��^</param>
        /// <returns>targetType�܂��͂��̃T�u�N���X�Ȃ��true</returns>
        private bool IsClassOrSubClass( Type type, Type targetType )
        {
            return (type == targetType || type.IsSubclassOf( targetType ));
        }
        /// <summary>
        /// CSV���l�擾
        /// </summary>
        /// <param name="dataText"></param>
        /// <returns></returns>
        private List<int> GetNumbersFromCSV( string dataText )
        {
            List<int> numbers = new List<int>();
            string[] splitStrings = dataText.Split( ',' );

            for ( int index = 0; index < splitStrings.Length; index++ )
            {
                int number;
                if ( GetInt( splitStrings[index], 0, out number ) )
                {
                    numbers.Add( number );
                }
            }
            return numbers;
        }
        /// <summary>
        /// ���t�擾����
        /// </summary>
        /// <param name="dataText"></param>
        /// <returns></returns>
        private DateTime GetDateTime( string dataText )
        {
            int longDate = GetInt( dataText, 0 );
            try
            {
                return new DateTime( longDate / 10000, longDate / 100 % 100, longDate % 100 );
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// ���l�擾����
        /// </summary>
        /// <param name="dataText"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private int GetInt( string dataText, int defaultValue )
        {
            int result = defaultValue;
            try
            {
                return Int32.Parse( dataText );
            }
            catch
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// ���l�擾�����i�ϊ��s���肠��j
        /// </summary>
        /// <param name="dataText"></param>
        /// <param name="defaultValue"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool GetInt( string dataText, int defaultValue, out int number )
        {
            number = 0;
            try
            {
                number = Int32.Parse( dataText );
                return true;
            }
            catch
            {
                return false;
            }
        }
        # endregion

        # region �� OwnerForm�̃C�x���g ��
        /// <summary>
        /// �I�[�i�[�t�H�[����Load�C�x���g�ɐݒ肷��C�x���g�n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OwnerFormOnLoad( Object sender, EventArgs e )
        {
            //----------------------------------
            // �ǂݍ���
            //----------------------------------
            if ( ReadOnLoad )
            {
                // �ǂݍ���
                ReadMemInput();
            }

            //----------------------------------
            // �C�x���g�n���h������
            //----------------------------------
            if ( OwnerForm is Form )
            {
                // �\��t���悪�q�t�H�[���̏ꍇ
                if ( (OwnerForm as Form).TopLevel == false && (OwnerForm as Form).ParentForm != null)
                {
                    // �\��t����̐e�t�H�[���ɃC�x���g�����ǉ�
                    (OwnerForm as Form).ParentForm.FormClosing += this.OwnerFormOnFormClosing;
                    // �\��t����t�H�[������C�x���g�����폜
                    (OwnerForm as Form).FormClosing -= this.OwnerFormOnFormClosing;
                }
            }
            else if ( OwnerForm is UserControl )
            {
                // �\��t���悪���[�U�[�R���g���[���̏ꍇ�͐e�t�H�[���ɑ΂��ăZ�b�g
                if ( (OwnerForm as UserControl).ParentForm != null )
                {
                    // �\��t����̐e�t�H�[���ɃC�x���g�����ǉ�
                    (OwnerForm as UserControl).ParentForm.FormClosing += this.OwnerFormOnFormClosing;
                }
            }
        }
        /// <summary>
        /// �I�[�i�[�t�H�[����FormClosing�C�x���g�ɐݒ肷��C�x���g�n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OwnerFormOnFormClosing( Object sender, EventArgs e )
        {
            if ( WriteOnClose )
            {
                // ��������
                WriteMemInput();
            }
        }
        # endregion �� OwnerForm�̃C�x���g ��
    }
    # endregion �� UI���͍��ڐݒ�R���|�[�l���g ��
}
