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
    # region �� UI���͍��ڐݒ�R���|�[�l���g ��
    /// <summary>
    /// �t�h���͍��ڐݒ�R���|�[�l���g
    /// </summary>
    /// <remarks>
    /// Note       : �t�h�̊e����͍��ڂɑ΂��A���ʂ̐�����s���ׂ̃R���|�[�l���g�ł��B<br />
    /// Programmer : 22018 ��� ���b<br />
    /// Date       : 2008.01.28<br />
    /// <br />
    /// Update Note: 2008.03.03  ��� ���b<br />
    ///                �@�O���b�h���ׂɑΉ�����ׂ̏����Ƃ��āA�t�h�ݒ���O���񋟂��郁�\�b�h��ǉ�<br />
    /// Update Note: 2008.03.25  ��� ���b<br />
    ///                �@�e�t�H�[�����œ��̓`�F�b�N�������s���ׂ̃��\�b�h��ǉ�<br />
    ///                  (��cs�t�@�C����TLibAvatar���g�p)<br />
    /// Update Note: 2008.04.16  ��� ���b<br />
    ///                �@�ꊇ�[���l�ߏ������\�b�h��ǉ�<br />
    /// �@�@�@�@�@�@�@�@�ATEdit�ҏW��Ԃ̃e�L�X�g���E�������L���ɂȂ�悤�ύX<br />
    ///                �B�}�E�X���{�^��������������ǉ�<br />
    /// Update Note: 2009.05.28  ��� ���b<br />
    ///                �@���[���C���t���[���őS���ڈꊇ�[���l�ߏ��������Ƃ��A<br />
    /// �@�@�@�@�@�@�@�@�@�q�t�H�[���ŗL�̐ݒ�ɏ]���ď�������Ȃ��s����C���B<br />
    /// </remarks>    
    [ToolboxBitmap( typeof( UiSetControl ), "UiSetControl.UiSetControl.bmp" ),
     DefaultEvent( "ChangeFocus" ), Serializable]
    public partial class UiSetControl : TbsBaseComponent
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
        # region [private static fields]
        /// <summary>UiSetControl���X�g(static)</summary>
        private static List<UiSetControl> stc_UiSetControlList;
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD

        # region [private fields]
        /// <summary>�ݒ�t�@�C���A�N�Z�X�N���X</summary>
        private UiSetFileAcs _uiSetFileAcs;
        /// <summary>OwnerForm����</summary>
        private string _ownerFormName;
        /// <summary>���͍��ڂ̕��������@</summary>
        private EditWidthSettingWayState _editWidthSettingWay;
        /// <summary>�[���l�߂���Edit�̃��X�g</summary>
        private List<string> _padZeroEditList;
        /// <summary>�[���l�߂��A�[�����͉\��Edit�̃��X�g</summary>
        private List<string> _inputableZeroCodePadZeroEditList;
        # endregion

        # region [Constructor]
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UiSetControl()
        {
            InitializeComponent();

            _uiSetFileAcs = new UiSetFileAcs();
            _ownerFormName = string.Empty;
            _padZeroEditList = new List<string>();
            _inputableZeroCodePadZeroEditList = new List<string>();
            _editWidthSettingWay = EditWidthSettingWayState.None;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
            if ( stc_UiSetControlList == null )
            {
                stc_UiSetControlList = new List<UiSetControl>();
            }
            stc_UiSetControlList.Add( this );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="container"></param>
        public UiSetControl( IContainer container )
        {
            container.Add( this );
            InitializeComponent();

            _uiSetFileAcs = new UiSetFileAcs();
            _ownerFormName = string.Empty;
            _padZeroEditList = new List<string>();
            _inputableZeroCodePadZeroEditList = new List<string>();
            _editWidthSettingWay = EditWidthSettingWayState.None;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
            if ( stc_UiSetControlList == null )
            {
                stc_UiSetControlList = new List<UiSetControl>();
            }
            stc_UiSetControlList.Add( this );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        }
        # endregion

        # region [event]
        /// <summary>
        /// TArrowKey��ChangeFocus�C�x���g����
        /// </summary>
        [Description( "TArrowKeyControl�ɐݒ肷����̂Ɠ���ChangeFocus�C�x���g�������w�肵�܂��B" )]
        public event Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler ChangeFocus;
        # endregion

        # region [enum]
        /// <summary>
        /// ���͍��ڂ̕��̐ݒ���@
        /// </summary>
        public enum EditWidthSettingWayState
        {
            /// <summary>���ݒ肵�Ȃ�</summary>
            None = 0,
            /// <summary>AutoWidth�v���p�e�B���g�p����</summary>
            UseAutoWidth = 1,
            /// <summary>�v�Z���ʂ��g�p����</summary>
            CalculateCollapsing = 2,
        }
        # endregion

        # region [public propaties]
        /// <summary>
        /// ���͍��ڂ̕��̒������@��ݒ肵�܂��B
        /// </summary>
        [Category( "����" ),
         Description( "TEdit/TNedit�̕��̒������@��ݒ肵�܂��B" )]
        public EditWidthSettingWayState EditWidthSettingWay
        {
            get { return _editWidthSettingWay; }
            set { _editWidthSettingWay = value; }
        }

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
                            //(base.OwnerForm as Form).ControlAdded -= this.OwnerFormOnControlAdded;
                        }

                        if ( base.OwnerForm is UserControl )
                        {
                            (base.OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                            //(base.OwnerForm as UserControl).ControlAdded -= this.OwnerFormOnControlAdded;
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
                                //(base.OwnerForm as Form).ControlAdded += OwnerFormOnControlAdded;
                            }

                            if ( base.OwnerForm is UserControl )
                            {
                                (base.OwnerForm as UserControl).Load += this.OwnerFormOnLoad;
                                //(base.OwnerForm as UserControl).ControlAdded += OwnerFormOnControlAdded;
                            }
                        }
                    }
                    else
                    {
                        base.OwnerForm = value;
                    }


                    // �ݒ�ǂݍ���
                    ReadUISetting( base.OwnerForm as ContainerControl );
                }
            }
        }

        # endregion

        # region [static public methods]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �w�肳�ꂽ�I�[�i�[�t�H�[���ɒ���t����ꂽ�AUiSetControl�I�u�W�F�N�g���擾����B
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static UiSetControl SearchFromOwner( ContainerControl owner )
        {
            UiSetControl uiSetControl = null;

            // ���t���N�V�����őS�t�B�[���h���擾
            Type type = owner.GetType();
            System.Reflection.FieldInfo[] fieldinfos = type.GetFields( System.Reflection.BindingFlags.Public |
                                                                      System.Reflection.BindingFlags.NonPublic |
                                                                      System.Reflection.BindingFlags.Instance |
                                                                      System.Reflection.BindingFlags.DeclaredOnly );
            if ( fieldinfos != null )
            {
                // �S�t�B�[���h�̒�����AUiSetControl��T��
                // (�����ӁF�����ł�1�t�H�[���ɑ΂���UiSetControl��1�����Ƃ����O��ŏ������Ă��܂�)
                foreach ( System.Reflection.FieldInfo field in fieldinfos )
                {
                    if ( field.FieldType == typeof( UiSetControl ) )
                    {
                        // �Ώۃt�H�[���̃t�B�[���h���I�u�W�F�N�g��
                        uiSetControl = (field.GetValue( owner ) as UiSetControl);
                        break;
                    }
                }
            }
            // �ԋp
            return uiSetControl;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        # endregion

        # region [public methods]
        # region [�t�h���ڐݒ�擾]
        /// <summary>
        /// �t�h���ڐݒ�擾����
        /// </summary>
        /// <param name="uiSet">(�o��)UI�ݒ���</param>
        /// <param name="editName">���͍��ږ�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>�t�h�ݒ�����O���ɒ񋟂��܂��B</br>
        /// </remarks>
        public int ReadUISet( out UiSet uiSet, string editName )
        {
            uiSet = this._uiSetFileAcs.GetUiSet( this._ownerFormName, editName );
            if ( uiSet != null )
            {
                return 0;
            }
            else
            {
                uiSet = new UiSet();
                return 9;
            }
        }
        /// <summary>
        /// �t�h���ڐݒ�擾�����i�����Ή��F���X�g�j
        /// </summary>
        /// <param name="uiSetList">(�o��)�ݒ胊�X�g</param>
        /// <param name="editNames">���͍��ږ����X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>�t�h�ݒ�����O���ɒ񋟂��܂��B</br>
        /// </remarks>
        public int ReadUISetList( out List<UiSet> uiSetList, List<string> editNames )
        {
            // ���X�g�擾
            uiSetList = this._uiSetFileAcs.GetUiSetList( this._ownerFormName, editNames );

            // ���X�g����łȂ����OK
            if ( uiSetList.Count > 0 )
            {
                return 0;
            }
            else
            {
                return 9;
            }
        }
        /// <summary>
        /// �t�h���ڐݒ�擾�����i�����Ή��F�f�B�N�V���i���j
        /// </summary>
        /// <param name="uiSetDic">(�o��)�ݒ�f�B�N�V���i��</param>
        /// <param name="editNames">���͍��ږ����X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>�t�h�ݒ�����O���ɒ񋟂��܂��B</br>
        /// </remarks>
        public int ReadUISetDictionary( out Dictionary<string, UiSet> uiSetDic, List<string> editNames )
        {
            // �f�B�N�V���i���擾
            uiSetDic = this._uiSetFileAcs.GetUiSetDictionary( this._ownerFormName, editNames );

            // �f�B�N�V���i������łȂ����OK
            if ( uiSetDic.Count > 0 )
            {
                return 0;
            }
            else
            {
                return 9;
            }
        }
        # endregion

        # region [���͋������p�^�[���`�F�b�N]
        /// <summary>
        /// ���͋������p�^�[���}�b�`����i�S������j
        /// </summary>
        /// <param name="tEdit">�Ώ�TEdit</param>
        /// <returns></returns>
        public bool CheckMatchingSet( TEdit tEdit )
        {
            return CheckMatchingSet( tEdit.Name, tEdit.Text );
        }
        /// <summary>
        /// ���͋������p�^�[���}�b�`����i�S������j
        /// </summary>
        /// <param name="tNedit">�Ώ�TNedit</param>
        /// <returns></returns>
        public bool CheckMatchingSet( TNedit tNedit )
        {
            return CheckMatchingSet( tNedit.Name, tNedit.Text );
        }
        /// <summary>
        /// ���͋������p�^�[���}�b�`����i�S������j
        /// </summary>
        /// <param name="editName">���͍��ږ�</param>
        /// <param name="fullText">���͍ς݂̂��ׂĂ̕�����</param>
        /// <returns>true: ���v����^false: ���v���Ȃ�</returns>
        public bool CheckMatchingSet( string editName, string fullText )
        {
            //-------------------------------------------------
            // ���̓p�^�[�������擾
            //-------------------------------------------------
            TLibAvatar.EnableChars enableChars = GetEnableChars( editName );


            //-------------------------------------------------
            // TLibAvatar�̑S�p�����,������̑S�����Ώۂ��ƌ������ǂ��Ȃ��̂ŁA�׍H����B
            //-------------------------------------------------
            // �S�p�����`�F�b�N(�񋖉Ȃ珜�O�`�F�b�N)
            if ( !enableChars.Word )
            {
                // �o�C�g�����������Ȃ�S�p���܂ނƔ��f����
                Encoding encoding = Encoding.GetEncoding( "Shift-JIS" );
                if ( encoding.GetByteCount( fullText ) != fullText.Length )
                {
                    return false;
                }
            }
            // �ȏ�őS�p�`�F�b�N�ς݂Ȃ̂�,�ȉ��ł͋��������ă`�F�b�N���X�L�b�v����
            enableChars.Word = true;


            //-------------------------------------------------
            // �S�����`�F�b�N
            //-------------------------------------------------
            // �����������[�v
            for ( int index = 0; index < fullText.Length; index++ )
            {
                // �P���������菈������
                if ( TLibAvatar.CheckCharactor( fullText[index], enableChars ) == false )
                {
                    return false;
                }
            }


            // �ȏ�̃`�F�b�N�����Ŗ��Ȃ���΂n�j
            return true;
        }
        /// <summary>
        /// ���͋������p�^�[���}�b�`����i�����P�Ɓj
        /// </summary>
        /// <param name="editName">���͍��ږ�</param>
        /// <param name="addingChar">������͕���</param>
        /// <returns>true: ���v����^false: ���v���Ȃ�</returns>
        public bool CheckMatchingSet( string editName, char addingChar )
        {
            // ���͋������p�^�[���Ƀ}�b�`���Ă��邩����
            return TLibAvatar.CheckCharactor( addingChar, GetEnableChars( editName ) );
        }
        /// <summary>
        /// ���͋������p�^�[���擾����
        /// </summary>
        /// <param name="editName">���͍��ږ�</param>
        /// <returns>���͋������p�^�[��</returns>
        public TLibAvatar.EnableChars GetEnableChars( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                return new TLibAvatar.EnableChars( uiSet.AllowSpace, uiSet.AllowSign, uiSet.AllowAlpha, uiSet.AllowKana, uiSet.AllowNum, uiSet.AllowNumSign, uiSet.AllowWord );
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////// �ݒ肪�݂���Ȃ������ꍇ�́A�S�ċ����Ȃ����̂Ƃ݂Ȃ�
                ////return new TLibAvatar.EnableChars( false, false, false, false, false, false, false );
                // �ݒ肪�݂���Ȃ������ꍇ�́A�S�ċ�������̂Ƃ݂Ȃ�
                return new TLibAvatar.EnableChars( true, true, true, true, true, true, true );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }
        # endregion

        # region [�[�����ߌ�e�L�X�g�擾]
        /// <summary>
        /// �[�����ߌ�e�L�X�g�擾����
        /// </summary>
        /// <param name="editName">���͍��ږ�</param>
        /// <param name="fullText">���͍ς݃e�L�X�g</param>
        /// <returns>�[�����߂����e�L�X�g</returns>
        public string GetZeroPaddedText( string editName, string fullText )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                if ( uiSet.PadZero )
                {
                    return GetZeroPaddedTextProc( fullText, uiSet.Column, uiSet.AllowZeroCode );
                }
                else
                {
                    // �[���l�߂��Ȃ����ڂȂ炻�̂܂ܕԂ�
                    return fullText;
                }
            }
            else
            {
                // �ݒ肪�Ȃ���΂��̂܂ܕԂ�
                return fullText;
            }
        }
        /// <summary>
        /// �[�����߃L�����Z����e�L�X�g�擾����
        /// </summary>
        /// <param name="editName">���͍��ږ�</param>
        /// <param name="fullText">���͍ς݃e�L�X�g</param>
        /// <returns>�[�����߃L�����Z�������e�L�X�g</returns>
        public string GetZeroPadCanceledText( string editName, string fullText )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                if ( uiSet.PadZero )
                {
                    return GetZeroPadCanceledTextProc( fullText, uiSet.AllowZeroCode );
                }
                else
                {
                    // �[���l�߂��Ȃ����ڂȂ炻�̂܂ܕԂ�
                    return fullText;
                }
            }
            else
            {
                // �ݒ肪�Ȃ���΂��̂܂ܕԂ�
                return fullText;
            }
        }

        # endregion

        # region [�ݒ�̋����Ăяo��]
        /// <summary>
        /// �t�H�[���ݒ�̌Ăяo������(�eForm����)
        /// </summary>
        /// <remarks>
        /// <br>��(����ȃP�[�X�ւ̑Ή�)</br>
        /// <br>  Load�C�x���g�O��UI�ݒ��K�p����K�v������ꍇ�̂݁A���̃��\�b�h���g�p���ĉ������B</br>
        /// <br>�@�ʏ�͂��̃��\�b�h���Ăяo���K�v�͂���܂���B</br>
        /// </remarks>
        public void SettingFormBeforeLoad()
        {
            //-------------------------------------------------------
            // ���̃��\�b�h�����������΁ALoad���ɓ��������͕s�v�Ȃ̂Ńn���h�����폜����
            //-------------------------------------------------------
            if ( base.OwnerForm is ContainerControl )
            {
                // �C�x���g�f���Q�[�g���폜����
                if ( base.OwnerForm is Form )
                {
                    (base.OwnerForm as Form).Load -= this.OwnerFormOnLoad;
                    //(base.OwnerForm as Form).ControlAdded -= this.OwnerFormOnControlAdded;
                }

                if ( base.OwnerForm is UserControl )
                {
                    (base.OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                    //(base.OwnerForm as UserControl).ControlAdded -= this.OwnerFormOnControlAdded;
                }
            }
            //-------------------------------------------------------
            // �����Ăяo��
            //-------------------------------------------------------
            OwnerFormOnLoad( this, new EventArgs() );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �S���ڃ[���l�߃e�L�X�g�ݒ菈��
        /// </summary>
        public void SettingAllControlsZeroPaddedText()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 DEL
            //if ( this.OwnerForm is Control )
            //{
            //    SettingChildControlZeroPaddedText( this.OwnerForm as Control );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
            if ( stc_UiSetControlList != null )
            {
                // �v���Z�X���̑S�Ă�UiSetControl�ɑ΂��ď���
                foreach ( UiSetControl uiSetControl in stc_UiSetControlList )
                {
                    try
                    {
                        if ( uiSetControl != null )
                        {
                            uiSetControl.SettingAllControlsZeroPaddedTextProc();
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                // �������g��������
                this.SettingAllControlsZeroPaddedTextProc();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
        /// <summary>
        /// �S���ڃ[���l�߃e�L�X�g�ݒ菈��
        /// </summary>
        internal void SettingAllControlsZeroPaddedTextProc()
        {
            if ( this.OwnerForm is Control )
            {
                SettingChildControlZeroPaddedText( this.OwnerForm as Control );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        # endregion

        # region [�ݒ�l�擾�����i�ݒ�v�f�P�Ɓj]
        /// <summary>
        /// �h�l�d���[�h�擾
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        public ImeMode GetSettingImeMode( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                // �h�l�d���[�h�ԋp
                return uiSet.ImeMode;
            }
            else
            {
                // ����Ȃ��i����j
                return ImeMode.NoControl;
            }
        }
        /// <summary>
        /// �����擾����
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        public int GetSettingColumnCount( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                // �����ԋp
                return uiSet.Column;
            }
            else
            {
                // ��O
                return 0;
            }
        }
        /// <summary>
        /// ���E�����ʒu�擾
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        public Infragistics.Win.HAlign GetSettingHAlign( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                // ���E�����ʒu
                return uiSet.HAlign;
            }
            else
            {
                // ����Ȃ��i����j
                return Infragistics.Win.HAlign.Default;
            }
        }
        # endregion
        # endregion

        # region [private methods]
        /// <summary>
        /// �t�h�ݒ�擾����
        /// </summary>
        private void ReadUISetting( ContainerControl ownerForm )
        {
            // OwnerForm�����A�Z���u���̖��̂��擾
            string asmName = Path.GetFileNameWithoutExtension( ownerForm.GetType().Assembly.GetName().Name );
            // OwnerForm�̖��̂��擾
            this._ownerFormName = ownerForm.GetType().Name;

            // �A�Z���u�����̐ݒ�擾
            _uiSetFileAcs.ReadXML( asmName );
        }
        /// <summary>
        /// �t�h���͍��ڐݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>OwnerForm�̃��[�h���ɂ��̃��\�b�h���Ăт܂��B</br>
        /// </remarks>
        private void SettingUI()
        {
            //// OwnerForm�����A�Z���u���̖��̂��擾
            //string asmName = Path.GetFileNameWithoutExtension( (this.OwnerForm as ContainerControl).GetType().Assembly.GetName().Name );
            //// OwnerForm�̖��̂��擾
            //this._ownerFormName = (this.OwnerForm as ContainerControl).GetType().Name;

            //// �A�Z���u�����̐ݒ�擾
            //_uiSetFileAcs.ReadXML( asmName );

            // �e��ݒ�l��K�p����B
            this.PropertyChange();
        }
        /// <summary>
        /// �t�H�[���y�уt�H�[����ɔz�u����Ă���R���|�[�l���g�̐ݒ���s���܂��B
        /// </summary>
        private void PropertyChange()
        {
            if ( this.OwnerForm is ContainerControl && !(this.OwnerForm as ContainerControl).IsDisposed )
            {
                ContainerControl owner = (this.OwnerForm as ContainerControl);

                object obj = null;

                if ( DesignMode )
                {
                    // �f�U�C�����͏������Ȃ�
                }
                else
                {
                    // ���s���̓��t���N�V�������g�p���� Form �̃t�B�[���h����R���|�[�l���g�̈ꗗ���擾����
                    Type type = owner.GetType();
                    System.Reflection.FieldInfo[] fieldinfos = type.GetFields( System.Reflection.BindingFlags.Public |
                                                                              System.Reflection.BindingFlags.NonPublic |
                                                                              System.Reflection.BindingFlags.Instance |
                                                                              System.Reflection.BindingFlags.DeclaredOnly );

                    if ( fieldinfos != null )
                    {
                        foreach ( System.Reflection.FieldInfo field in fieldinfos )
                        {
                            obj = field.GetValue( owner );

                            // �擾�����t�B�[���h�� Component �N���X���p�����Ă���A���� UiSetControl �N���X
                            // �ł͖����ꍇ�Ƀv���p�e�B�̕ύX�������s���B(���ʂȃ��[�v�������Ȃ�)
                            if ( obj is Component && !(obj is UiSetControl) )
                            {
                                this.SettingPropertys( obj );
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// �R���g���[�����̃v���p�e�B�ݒ菈��
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>
        /// <br>���TEdit/TNedit�ɑ΂��ď������s���܂��B</br>
        /// <br>���͎��̏���������s���ׁATArrowKeyControl/TRetKeyControl�ɑ΂��Ă��������s���܂��B</br>
        /// </remarks>
        private void SettingPropertys( object obj )
        {
            if ( obj is TEdit )
            {
                # region [for TEdit/TNedit]

                TEdit tEdit = (obj as TEdit);

                // �R���g���[���̖��̂���ݒ���e���擾
                UiSet uiSet = _uiSetFileAcs.GetUiSet( _ownerFormName, tEdit.Name );

                // �ݒ��K�p
                this.UISetting( tEdit, uiSet, ref this._padZeroEditList, ref this._inputableZeroCodePadZeroEditList );
                # endregion
            }
            else if ( obj is TArrowKeyControl )
            {
                # region [for TArrowKeyControl]
                //------------------------------------------------------------------------------
                // Form�Őݒ肳���ATArrowKeyControl �� ChangeFocus�C�x���g���������^�C�~���O��
                // �[���l�߂���ׂɍ׍H����B
                //------------------------------------------------------------------------------

                TArrowKeyControl akControl = (obj as TArrowKeyControl);
                if ( ChangeFocus != null )
                {
                    // Form���Z�b�g����C�x���g�n���h�����ꎞ�I�ɍ폜
                    akControl.ChangeFocus -= ChangeFocus;
                    // �[���l�߂���ɏ��������悤�ɐݒ肵�����B
                    akControl.ChangeFocus += new ChangeFocusEventHandler( akControl_ChangeFocus );
                    akControl.ChangeFocus += ChangeFocus;
                }
                else
                {
                    akControl.ChangeFocus += new ChangeFocusEventHandler( akControl_ChangeFocus );
                }
                # endregion
            }
            else if ( obj is TRetKeyControl )
            {
                # region [for TRetKeyControl]
                //------------------------------------------------------------------------------
                // Form�Őݒ肳���ATRetKeyControl �� ChangeFocus�C�x���g���������^�C�~���O��
                // �[���l�߂���ׂɍ׍H����B
                // (��TArrowKeyControl�Ɠ���ChangeFocus�C�x���g�n���h�����Z�b�g����Ă���O��ŏ������Ă��܂�)
                //------------------------------------------------------------------------------
                TRetKeyControl trkControl = (obj as TRetKeyControl);
                if ( ChangeFocus != null )
                {
                    // Form���Z�b�g����C�x���g�n���h�����ꎞ�I�ɍ폜
                    trkControl.ChangeFocus -= ChangeFocus;
                    // �[���l�߂���ɏ��������悤�ɐݒ肵�����B
                    trkControl.ChangeFocus += new ChangeFocusEventHandler( akControl_ChangeFocus );
                    trkControl.ChangeFocus += ChangeFocus;

                }
                # endregion
            }
        }
        /// <summary>
        /// �ݒ�N���X�̐ݒ�l��K�p�iTEdit/TNedit�Ώہj
        /// </summary>
        /// <param name="tEdit"></param>
        /// <param name="uiSet"></param>
        /// <param name="padZeroEditList"></param>
        /// <param name="inputableZeroCodePadZeroEditList"></param>
        /// <remarks>
        /// <br>���̏������A���ۂ̓��͍��ڂɑ΂���ݒ菈���ł��B</br>
        /// </remarks>
        private void UISetting( TEdit tEdit, UiSet uiSet, ref List<string> padZeroEditList, ref List<string> inputableZeroCodePadZeroEditList )
        {
            // �w�l�k�Őݒ肳��Ă��Ȃ����ڂȂ�΁A�������Ȃ�
            if ( uiSet == null )
            {
                return;
            }

            //--------------------------------------------------------
            // �v���p�e�B�̃Z�b�g
            //--------------------------------------------------------
            tEdit.ExtEdit.Column = uiSet.Column;                    // ����
            tEdit.ExtEdit.EnableChars.Alpha = uiSet.AllowAlpha;     // �A���t�@�x�b�g��
            tEdit.ExtEdit.EnableChars.Kana = uiSet.AllowKana;       // �J�i��
            tEdit.ExtEdit.EnableChars.Num = uiSet.AllowNum;         // ������
            tEdit.ExtEdit.EnableChars.NumSign = uiSet.AllowNumSign; // ���l�L����
            tEdit.ExtEdit.EnableChars.Sign = uiSet.AllowSign;       // �L����
            tEdit.ExtEdit.EnableChars.Space = uiSet.AllowSpace;     // �X�y�[�X��
            tEdit.ExtEdit.EnableChars.Word = uiSet.AllowWord;       // �S�p������
            tEdit.Appearance.TextHAlign = uiSet.HAlign;             // ���E����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            tEdit.ActiveAppearance.TextHAlign = uiSet.HAlign;       // �A�N�e�B�u�����E����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            tEdit.ImeMode = uiSet.ImeMode;                          // IME���[�h


            // ���ڂ̉���
            # region [����]
            if ( _editWidthSettingWay == EditWidthSettingWayState.None )
            {
                // ���䂵�Ȃ�
            }
            else if ( _editWidthSettingWay == EditWidthSettingWayState.UseAutoWidth )
            {
                // AutoWidth���g�p����
                tEdit.ExtEdit.AutoWidth = true;                 // ����������
            }
            else if ( _editWidthSettingWay == EditWidthSettingWayState.CalculateCollapsing )
            {
                // �v�Z�l���g�p����
                // �K�v�ȕ����v�Z��,�������Ȃ�ꍇ�̂݃Z�b�g����
                int resultWidth = this.GetEditWidth( tEdit );   // ���Z�o
                if ( resultWidth < tEdit.Width )
                {
                    tEdit.Width = resultWidth;
                }
            }
            # endregion

            // ���l�G�f�B�b�g�Ȃ�[���l�ߐݒ��ǉ�
            # region [���l�G�f�B�b�g]
            if ( tEdit is TNedit )
            {
                if ( uiSet.PadZero )
                {
                    (tEdit as TNedit).NumEdit.ZeroSupp = emZeroSupp.zsFILL;     // �[���l�߂���
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //(tEdit as TNedit).NumEdit.ZeroDisp = false;                 // ALL�[���\�����Ȃ�
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    (tEdit as TNedit).NumEdit.ZeroDisp = uiSet.AllowZeroCode;                 // ALL�[���\�����Ȃ�
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }
            # endregion


            //--------------------------------------------------------
            // �C�x���g�����̃Z�b�g
            //--------------------------------------------------------
            # region [�C�x���g]
            if ( uiSet.PadZero )
            {
                if ( uiSet.AllowZeroCode )
                {
                    //--------------------------------------------------
                    // �[�����͉\�E�[���l�߃R���g���[��
                    //--------------------------------------------------

                    tEdit.Enter += new EventHandler( InputableZeroCdPadZeroTEdit_Enter );  // �i���C�x���g

                    if ( this.ChangeFocus == null )
                    {
                        // ��ۓ��́���ۂ����͂��ꂽ���Ƃ���
                        tEdit.Leave += new EventHandler( InputableZeroCdPadZeroTEdit_Leave );  // �E�o�C�x���g
                    }
                    else
                    {
                        // Leave���s��TArrowKeyControl.ChangeFocus���������s���ׁA
                        // Leave�̃C�x���g�n���h���ɂ͓o�^�����A
                        // ���X�g�ɒǉ����Ă����Ē��O�ɏ�������B
                        inputableZeroCodePadZeroEditList.Add( tEdit.Name );
                    }
                }
                else
                {
                    //--------------------------------------------------
                    // �[�����͕s�E�[���l�߃R���g���[��
                    //--------------------------------------------------
                    tEdit.Enter += new EventHandler( PadZeroTEdit_Enter );  // �i���C�x���g

                    if ( this.ChangeFocus == null )
                    {
                        // ��ۓ��́������͂ɂ���
                        tEdit.Leave += new EventHandler( PadZeroTEdit_Leave );  // �E�o�C�x���g
                    }
                    else
                    {
                        // Leave���s��TArrowKeyControl.ChangeFocus���������s���ׁA
                        // Leave�̃C�x���g�n���h���ɂ͓o�^�����A
                        // ���X�g�ɒǉ����Ă����Ē��O�ɏ�������B
                        padZeroEditList.Add( tEdit.Name );
                    }
                
                }
            }
            # endregion
        }

        /// <summary>
        /// TEdit/TNedit��width�擾����
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private int GetEditWidth( TEdit tEdit )
        {
            // �P����������̕��ϕ�
            float wAveCharWidth;

            // �R���g���[���̃O���t�B�b�N���擾
            Graphics editGraphics = tEdit.CreateGraphics();
            // ���ɕ`�悷�镶������`
            string drawString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //----------------------------------------
            //  ���p����t�H���g�쐬
            //----------------------------------------
            # region [���p����t�H���g�쐬]

            System.Drawing.Font drawFont;
            string fontName;
            float fontSize;
            System.Drawing.FontStyle fontStyle = 0;

            // �t�H���g���̌���
            if ( (tEdit.Appearance.FontData.Name == "") || (tEdit.Appearance.FontData.Name == null) )
            {
                fontName = tEdit.Font.Name;
            }
            else
            {
                fontName = tEdit.Appearance.FontData.Name;
            }
            // �t�H���g�T�C�Y�̌���
            if ( tEdit.Appearance.FontData.SizeInPoints == 0.0 )
            {
                fontSize = tEdit.Font.SizeInPoints;
            }
            else
            {
                fontSize = tEdit.Appearance.FontData.SizeInPoints;
            }
            // �{�[���h�̎w��
            if ( tEdit.Appearance.FontData.Bold == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Bold == true )
                    fontStyle |= System.Drawing.FontStyle.Bold;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Bold == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Bold;
            }
            // �C�^���b�N�̎w��
            if ( tEdit.Appearance.FontData.Italic == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Italic == true )
                    fontStyle |= System.Drawing.FontStyle.Italic;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Italic == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Italic;
            }
            // ������̎w��
            if ( tEdit.Appearance.FontData.Strikeout == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Strikeout == true )
                    fontStyle |= System.Drawing.FontStyle.Strikeout;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Strikeout == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Strikeout;
            }
            // �����̎w��
            if ( tEdit.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Underline == true )
                    fontStyle |= System.Drawing.FontStyle.Underline;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Underline;
            }
            // �g�p����Ă���t�H���g���擾
            drawFont = new Font( fontName, fontSize, fontStyle );
            # endregion

            // �������\������ۂ̃t�H�[�}�b�g���w��
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            SizeF wSizeF;

            // ������t�H�[�}�b�g��ݒ�
            drawFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            // ������̕\���ɕK�v�ȃT�C�Y���擾
            wSizeF = editGraphics.MeasureString( drawString, drawFont, 640, drawFormat );
            // �A���t�@�x�b�g26�������̕������E�E�E26�Ŋ���Ε��ϕ�����
            wAveCharWidth = wSizeF.Width / 26;

            // �������������I�u�W�F�N�g�����
            # region [Dispose]
            drawFont.Dispose();
            editGraphics.Dispose();
            # endregion

            return (int)Math.Floor( wAveCharWidth * (tEdit.ExtEdit.Column + 2) );
        }
        /// <summary>
        /// �[�����ߌ�e�L�X�g�擾��������
        /// </summary>
        /// <param name="fullText">���͍ς݃e�L�X�g</param>
        /// <param name="columnCount">���͉\����</param>
        /// <param name="allowZeroCode">��ۺ��ޓ��͋���</param>
        /// <returns>�[�����߂����e�L�X�g</returns>
        private static string GetZeroPaddedTextProc( string fullText, int columnCount, bool allowZeroCode )
        {
            if ( fullText.Trim() != string.Empty )
            {
                if ( allowZeroCode )
                {
                    // �[���l�ߏ���
                    return fullText.PadLeft( columnCount, '0' );
                }
                else
                {
                    if ( GetIntFromString( fullText.Trim(), -1 ) == 0 )
                    {
                        // �l�[���Ȃ�΋�
                        return string.Empty;
                    }
                    else
                    {
                        // �[���l�ߏ���
                        return fullText.PadLeft( columnCount, '0' );
                    }
                }
            }
            else
            {
                if ( allowZeroCode )
                {
                    // �[���l�ߏ���
                    return fullText.PadLeft( columnCount, '0' );
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// �[�����߃L�����Z����e�L�X�g�擾��������
        /// </summary>
        /// <param name="fullText">���͍ς݃e�L�X�g</param>
        /// <param name="allowZeroCd"></param>
        /// <returns>�[�����߃L�����Z�������e�L�X�g</returns>
        private static string GetZeroPadCanceledTextProc( string fullText, bool allowZeroCd )
        {
            if ( fullText.Trim() != string.Empty )
            {
                if ( !allowZeroCd )
                {
                    // �擪�̃[���l�߂��폜
                    while ( fullText.StartsWith( "0" ) )
                    {
                        fullText = fullText.Substring( 1, fullText.Length - 1 );
                    }
                }
                return fullText;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// �q�R���g���[���̃[���l�߃e�L�X�g�ꊇ�ݒ菈��
        /// </summary>
        /// <param name="parentControl"></param>
        private void SettingChildControlZeroPaddedText( Control parentControl )
        {
            // �q�R���g���[���ɑ΂��ď�������
            foreach ( Control control in parentControl.Controls )
            {
                if ( control is TEdit )
                {
                    // �[�����߃e�L�X�g�Œu��������
                    control.Text = GetZeroPaddedText( control.Name, control.Text );
                }

                // �ċA�Ăяo��
                SettingChildControlZeroPaddedText( control );
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
            // �ݒ���s
            SettingUI();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ���{�^���L�����Z���p���b�Z�[�W�t�B���^�ǉ�
            // (Form��WindowsMessage���󂯎��O�ɏ�������܂�)
            System.Windows.Forms.Application.AddMessageFilter( MButtonCancelMessageFilter.GetInstance() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        ///// <summary>
        ///// �R���g���[���ǉ��C�x���g����
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>
        ///// <br>�R���g���[���ɋ��ʂ̐ݒ���s���܂��B</br>
        ///// <br>�������ł̓R���g���[�������̐ݒ�͍s���܂���B</br>
        ///// </remarks>
        //void OwnerFormOnControlAdded( object sender, ControlEventArgs e )
        //{
        //    if ( e.Control != null )
        //    {
        //        e.Control.ControlAdded += this.OwnerFormOnControlAdded;

        //        if ( e.Control is TEdit )
        //        {
        //            // AutoWidth���L�����Z������
        //            (e.Control as TEdit).ExtEdit.AutoWidth = false;
        //        }
        //    }
        //}
        # endregion �� OwnerForm�̃C�x���g ��

        # region �� TArrowKeyControl�̃C�x���g ��
        /// <summary>
        /// TArrowKeyControl��ChangeFocus�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�����̏������AForm�ɂĐݒ肳���ChangeFocus��������</br>
        /// <br>�@�����^�C�~���O�ŏ��������悤���䂵�Ă��܂��B</br>
        /// </remarks>
        void akControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null )
            {
                return;
            }

            if ( _padZeroEditList.Contains( e.PrevCtrl.Name ) )
            {
                // �R�[�h�[���l�߁{�[�����͍͂폜
                PadZeroTEdit_Leave( e.PrevCtrl, new EventArgs() );
            }
            else if ( _inputableZeroCodePadZeroEditList.Contains( e.PrevCtrl.Name ) )
            {
                // �R�[�h�[���l�߁{�[������
                InputableZeroCdPadZeroTEdit_Leave( e.PrevCtrl, new EventArgs() );
            }
        }
        # endregion �� TArrowKeyControl�̃C�x���g ��

        # region �� TEdit/TNedit�̃C�x���g ��
        /// <summary>
        /// �[���l�߂��s��TEdit�̐i���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void PadZeroTEdit_Enter( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // �擪�̃[���l�߂��폜
            tEdit.Text = GetZeroPadCanceledTextProc( tEdit.Text, false );
        }
        /// <summary>
        /// �[���l�߂��s��TEdit�̐i���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void InputableZeroCdPadZeroTEdit_Enter( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // �擪�̃[���l�߂��폜
            tEdit.Text = GetZeroPadCanceledTextProc( tEdit.Text, true );
        }
        /// <summary>
        /// �[���l�߂��s��TEdit�̒E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>TArrowKeyControl��ChangeFocus���ݒ肳��Ă���ꍇ�A</br>
        /// <br>���̃C�x���g�����͒���TEdit��Leave�C�x���g�n���h���ɓo�^�����A</br>
        /// <br>TArrowKeyControl��ChangeFocus�̒��O�ɏ��������悤�ɂ��܂��B</br>
        /// </remarks>
        static void PadZeroTEdit_Leave( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // �[���l�ߏ���(�l=��ۂȂ��߰��ɂ���)
            tEdit.Text = GetZeroPaddedTextProc( tEdit.Text, tEdit.ExtEdit.Column, false );
        }
        /// <summary>
        /// �[���l�߂��s��TEdit�̒E�o�C�x���g�����i��ۺ��ނ�������j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void InputableZeroCdPadZeroTEdit_Leave( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // �[���l�ߏ���(�l=��ۂł����̂܂�)
            tEdit.Text = GetZeroPaddedTextProc( tEdit.Text, tEdit.ExtEdit.Column, true );
        }
        /// <summary>
        /// �����񁨐��l�ϊ�
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        static int GetIntFromString( string str, int defaultValue )
        {
            try
            {
                return Int32.Parse( str );
            }
            catch
            {
                return defaultValue;
            }
        }
        # endregion �� TEdit/TNedit�̃C�x���g ��
    }
    # endregion �� UI���͍��ڐݒ�R���|�[�l���g ��

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
    # region �� �}�E�X���{�^���L�����Z���p���b�Z�[�W�t�B���^ ��
    /// <summary>
    /// �}�E�X���{�^���L�����Z���p���b�Z�[�W�t�B���^
    /// </summary>
    /// <remarks>���̃��b�Z�[�W�t�B���^�ŁA���{�^���𖳌������܂��B</remarks>
    internal class MButtonCancelMessageFilter : IMessageFilter
    {
        /// <summary>
        /// �C���X�^���X(singleton)
        /// </summary>
        private static MButtonCancelMessageFilter stc_mButtonCancelMessageFilter;
        /// <summary>
        /// �C���X�^���X�擾
        /// </summary>
        /// <returns></returns>
        public static MButtonCancelMessageFilter GetInstance()
        {
            if ( stc_mButtonCancelMessageFilter == null )
            {
                stc_mButtonCancelMessageFilter = new MButtonCancelMessageFilter();
            }
            return stc_mButtonCancelMessageFilter;
        }
        /// <summary>
        /// �v���C�x�[�g�R���X�g���N�^
        /// </summary>
        private MButtonCancelMessageFilter()
        {
        }
        /// <summary>
        /// ���b�Z�[�W�ɑ΂���t�B���^����
        /// </summary>
        /// <param name="m"></param>
        /// <returns>true: �������� / false: ����������</returns>
        /// <remarks>���̏�����Form��WindowsMessage���󂯎��O�ɏ�������܂��B</remarks>
        public bool PreFilterMessage( ref Message m )
        {
            // ���{�^���C�x���g�̓L�����Z������
            if ( m.Msg == (int)WindowsMessages.WM_MBUTTONDBLCLK ||
                m.Msg == (int)WindowsMessages.WM_MBUTTONDOWN ||
                m.Msg == (int)WindowsMessages.WM_MBUTTONUP )
            {
                return true;
            }

            return false;
        }
    }
    # endregion

    # region [WindowsMessages]
    /// <summary>
    /// �E�B���h�E�Y���b�Z�[�W
    /// </summary>
    internal enum WindowsMessages : uint
    {
        WM_ACTIVATE = 0x6,
        WM_ACTIVATEAPP = 0x1C,
        WM_AFXFIRST = 0x360,
        WM_AFXLAST = 0x37F,
        WM_APP = 0x8000,
        WM_ASKCBFORMATNAME = 0x30C,
        WM_CANCELJOURNAL = 0x4B,
        WM_CANCELMODE = 0x1F,
        WM_CAPTURECHANGED = 0x215,
        WM_CHANGECBCHAIN = 0x30D,
        WM_CHAR = 0x102,
        WM_CHARTOITEM = 0x2F,
        WM_CHILDACTIVATE = 0x22,
        WM_CLEAR = 0x303,
        WM_CLOSE = 0x10,
        WM_COMMAND = 0x111,
        WM_COMPACTING = 0x41,
        WM_COMPAREITEM = 0x39,
        WM_CONTEXTMENU = 0x7B,
        WM_COPY = 0x301,
        WM_COPYDATA = 0x4A,
        WM_CREATE = 0x1,
        WM_CTLCOLORBTN = 0x135,
        WM_CTLCOLORDLG = 0x136,
        WM_CTLCOLOREDIT = 0x133,
        WM_CTLCOLORLISTBOX = 0x134,
        WM_CTLCOLORMSGBOX = 0x132,
        WM_CTLCOLORSCROLLBAR = 0x137,
        WM_CTLCOLORSTATIC = 0x138,
        WM_CUT = 0x300,
        WM_DEADCHAR = 0x103,
        WM_DELETEITEM = 0x2D,
        WM_DESTROY = 0x2,
        WM_DESTROYCLIPBOARD = 0x307,
        WM_DEVICECHANGE = 0x219,
        WM_DEVMODECHANGE = 0x1B,
        WM_DISPLAYCHANGE = 0x7E,
        WM_DRAWCLIPBOARD = 0x308,
        WM_DRAWITEM = 0x2B,
        WM_DROPFILES = 0x233,
        WM_ENABLE = 0xA,
        WM_ENDSESSION = 0x16,
        WM_ENTERIDLE = 0x121,
        WM_ENTERMENULOOP = 0x211,
        WM_ENTERSIZEMOVE = 0x231,
        WM_ERASEBKGND = 0x14,
        WM_EXITMENULOOP = 0x212,
        WM_EXITSIZEMOVE = 0x232,
        WM_FONTCHANGE = 0x1D,
        WM_GETDLGCODE = 0x87,
        WM_GETFONT = 0x31,
        WM_GETHOTKEY = 0x33,
        WM_GETICON = 0x7F,
        WM_GETMINMAXINFO = 0x24,
        WM_GETOBJECT = 0x3D,
        WM_GETSYSMENU = 0x313,
        WM_GETTEXT = 0xD,
        WM_GETTEXTLENGTH = 0xE,
        WM_HANDHELDFIRST = 0x358,
        WM_HANDHELDLAST = 0x35F,
        WM_HELP = 0x53,
        WM_HOTKEY = 0x312,
        WM_HSCROLL = 0x114,
        WM_HSCROLLCLIPBOARD = 0x30E,
        WM_ICONERASEBKGND = 0x27,
        WM_IME_CHAR = 0x286,
        WM_IME_COMPOSITION = 0x10F,
        WM_IME_COMPOSITIONFULL = 0x284,
        WM_IME_CONTROL = 0x283,
        WM_IME_ENDCOMPOSITION = 0x10E,
        WM_IME_KEYDOWN = 0x290,
        WM_IME_KEYLAST = 0x10F,
        WM_IME_KEYUP = 0x291,
        WM_IME_NOTIFY = 0x282,
        WM_IME_REQUEST = 0x288,
        WM_IME_SELECT = 0x285,
        WM_IME_SETCONTEXT = 0x281,
        WM_IME_STARTCOMPOSITION = 0x10D,
        WM_INITDIALOG = 0x110,
        WM_INITMENU = 0x116,
        WM_INITMENUPOPUP = 0x117,
        WM_INPUT = 0x00FF,
        WM_INPUTLANGCHANGE = 0x51,
        WM_INPUTLANGCHANGEREQUEST = 0x50,
        WM_KEYDOWN = 0x100,
        WM_KEYFIRST = 0x100,
        WM_KEYLAST = 0x108,
        WM_KEYUP = 0x101,
        WM_KILLFOCUS = 0x8,
        WM_LBUTTONDBLCLK = 0x203,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_MBUTTONDBLCLK = 0x209,
        WM_MBUTTONDOWN = 0x207,
        WM_MBUTTONUP = 0x208,
        WM_MDIACTIVATE = 0x222,
        WM_MDICASCADE = 0x227,
        WM_MDICREATE = 0x220,
        WM_MDIDESTROY = 0x221,
        WM_MDIGETACTIVE = 0x229,
        WM_MDIICONARRANGE = 0x228,
        WM_MDIMAXIMIZE = 0x225,
        WM_MDINEXT = 0x224,
        WM_MDIREFRESHMENU = 0x234,
        WM_MDIRESTORE = 0x223,
        WM_MDISETMENU = 0x230,
        WM_MDITILE = 0x226,
        WM_MEASUREITEM = 0x2C,
        WM_MENUCHAR = 0x120,
        WM_MENUCOMMAND = 0x126,
        WM_MENUDRAG = 0x123,
        WM_MENUGETOBJECT = 0x124,
        WM_MENURBUTTONUP = 0x122,
        WM_MENUSELECT = 0x11F,
        WM_MOUSEACTIVATE = 0x21,
        WM_MOUSEFIRST = 0x200,
        WM_MOUSEHOVER = 0x2A1,
        WM_MOUSELAST = 0x20A,
        WM_MOUSELEAVE = 0x2A3,
        WM_MOUSEMOVE = 0x200,
        WM_MOUSEWHEEL = 0x20A,
        WM_MOUSEHWHEEL = 0x20E,
        WM_MOVE = 0x3,
        WM_MOVING = 0x216,
        WM_NCACTIVATE = 0x86,
        WM_NCCALCSIZE = 0x83,
        WM_NCCREATE = 0x81,
        WM_NCDESTROY = 0x82,
        WM_NCHITTEST = 0x84,
        WM_NCLBUTTONDBLCLK = 0xA3,
        WM_NCLBUTTONDOWN = 0xA1,
        WM_NCLBUTTONUP = 0xA2,
        WM_NCMBUTTONDBLCLK = 0xA9,
        WM_NCMBUTTONDOWN = 0xA7,
        WM_NCMBUTTONUP = 0xA8,
        WM_NCMOUSEHOVER = 0x2A0,
        WM_NCMOUSELEAVE = 0x2A2,
        WM_NCMOUSEMOVE = 0xA0,
        WM_NCPAINT = 0x85,
        WM_NCRBUTTONDBLCLK = 0xA6,
        WM_NCRBUTTONDOWN = 0xA4,
        WM_NCRBUTTONUP = 0xA5,
        WM_NEXTDLGCTL = 0x28,
        WM_NEXTMENU = 0x213,
        WM_NOTIFY = 0x4E,
        WM_NOTIFYFORMAT = 0x55,
        WM_NULL = 0x0,
        WM_PAINT = 0xF,
        WM_PAINTCLIPBOARD = 0x309,
        WM_PAINTICON = 0x26,
        WM_PALETTECHANGED = 0x311,
        WM_PALETTEISCHANGING = 0x310,
        WM_PARENTNOTIFY = 0x210,
        WM_PASTE = 0x302,
        WM_PENWINFIRST = 0x380,
        WM_PENWINLAST = 0x38F,
        WM_POWER = 0x48,
        WM_PRINT = 0x317,
        WM_PRINTCLIENT = 0x318,
        WM_QUERYDRAGICON = 0x37,
        WM_QUERYENDSESSION = 0x11,
        WM_QUERYNEWPALETTE = 0x30F,
        WM_QUERYOPEN = 0x13,
        WM_QUERYUISTATE = 0x129,
        WM_QUEUESYNC = 0x23,
        WM_QUIT = 0x12,
        WM_RBUTTONDBLCLK = 0x206,
        WM_RBUTTONDOWN = 0x204,
        WM_RBUTTONUP = 0x205,
        WM_RENDERALLFORMATS = 0x306,
        WM_RENDERFORMAT = 0x305,
        WM_SETCURSOR = 0x20,
        WM_SETFOCUS = 0x7,
        WM_SETFONT = 0x30,
        WM_SETHOTKEY = 0x32,
        WM_SETICON = 0x80,
        WM_SETREDRAW = 0xB,
        WM_SETTEXT = 0xC,
        WM_SETTINGCHANGE = 0x1A,
        WM_SHOWWINDOW = 0x18,
        WM_SIZE = 0x5,
        WM_SIZECLIPBOARD = 0x30B,
        WM_SIZING = 0x214,
        WM_SPOOLERSTATUS = 0x2A,
        WM_STYLECHANGED = 0x7D,
        WM_STYLECHANGING = 0x7C,
        WM_SYNCPAINT = 0x88,
        WM_SYSCHAR = 0x106,
        WM_SYSCOLORCHANGE = 0x15,
        WM_SYSCOMMAND = 0x112,
        WM_SYSDEADCHAR = 0x107,
        WM_SYSKEYDOWN = 0x104,
        WM_SYSKEYUP = 0x105,
        WM_SYSTIMER = 0x118,
        WM_TCARD = 0x52,
        WM_TIMECHANGE = 0x1E,
        WM_TIMER = 0x113,
        WM_UNDO = 0x304,
        WM_UNINITMENUPOPUP = 0x125,
        WM_USER = 0x400,
        WM_USERCHANGED = 0x54,
        WM_VKEYTOITEM = 0x2E,
        WM_VSCROLL = 0x115,
        WM_VSCROLLCLIPBOARD = 0x30A,
        WM_WINDOWPOSCHANGED = 0x47,
        WM_WINDOWPOSCHANGING = 0x46,
        WM_WININICHANGE = 0x1A,
        WM_XBUTTONDBLCLK = 0x20D,
        WM_XBUTTONDOWN = 0x20B,
        WM_XBUTTONUP = 0x20C
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
}
