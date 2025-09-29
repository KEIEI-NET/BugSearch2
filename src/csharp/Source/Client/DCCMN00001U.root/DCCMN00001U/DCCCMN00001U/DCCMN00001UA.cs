using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using Broadleaf.Library.Resources;
using System.IO;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �t�h���͍��ڐݒ�c�[��
    /// </summary>
    /// <remarks>
    /// Note       : UI���͍��ڂ̓��͐���ݒ���s���c�[���ł��B<br />
    /// Programmer : 22018 ��� ���b<br />
    /// Date       : 2008.01.30<br />
    /// <br />
    /// Update Note: 2008.05.09 ��ؐ��b<br />
    ///                �@PM.NS�������R���p�C��<br />
    ///                �ATDateEdit���\������TNedit���������o���Ȃ��悤�ɕύX(���̂Ŕ���)
    /// </remarks>
    public partial class DCCMN00001UA : Form
    {
        # region �� private field ��
        // UI�ݒ�t�@�C���A�N�Z�X
        private UiSetFileAcs _uiSetFileAcs;
        // �ݒ�f�[�^�Z�b�g
        private UiSetDataSet _uisetDataSet;
        // ���ʐݒ�t�@�C���N���X
        private UiSetCommon _uiSetCommon;
        // �A�Z���u���ʐݒ�t�@�C���N���X
        private UiSetByAssembly _uiSetAsm;
        # endregion �� private field ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public DCCMN00001UA()
        {
            InitializeComponent();

            _uiSetFileAcs = new UiSetFileAcs();
            _uisetDataSet = new UiSetDataSet();

            _uisetDataSet.UiSet.Rows.Clear();
            _uisetDataSet.SetDD.Rows.Clear();

            // ������ԂōX�V�{�^���͉����Ȃ��悤�ɂ���
            this.bt_Update.Enabled = false;
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCCMN00001UA_Load( object sender, EventArgs e )
        {
            // ���͍��ڗp�O���b�h�ݒ�
            SettingGridUiSet();

            // �c�c�p�O���b�h�ݒ�
            SettingGridSetDD();
        }
        # endregion �� �t�H�[�����[�h ��

        # region �� �ݒ�\���֘A ��
        /// <summary>
        /// �\���{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Load_Click( object sender, EventArgs e )
        {
            string assemblyFileName = this.tb_Assembly.Text.Trim();

            DialogResult res;

            # region [�A�Z���u�����̃`�F�b�N]
            if ( assemblyFileName == string.Empty )
            {
                res = MessageBox.Show( "���ʐݒ��\�����܂����H", "�m�F", MessageBoxButtons.YesNo );
                if ( res == DialogResult.No )
                {
                    return;
                }
            }
            else
            {
                if ( !File.Exists( assemblyFileName ) )
                {
                    MessageBox.Show( "�t�@�C����������܂���B", "����" );
                    return;
                }
                List<string> extList = new List<string>( new string[] { "DLL", "EXE" } );
                if ( !extList.Contains( Path.GetExtension( assemblyFileName ).Replace( ".", "" ).ToUpper() ) )
                {
                    MessageBox.Show( "*.EXE�܂���*.DLL����͂��ĉ������B", "����" );
                    return;
                }
            }
            # endregion

            string asmName = Path.GetFileNameWithoutExtension( assemblyFileName );
            lb_AssemblySnm.Text = asmName;

            bool existsXML = false;

            if ( asmName != string.Empty )
            {
                if ( _uiSetFileAcs.ExistsUiSetByAssembly( asmName ) )
                {
                    // �ݒ�t�@�C������
                    existsXML = true;
                }
                else
                {
                    // �ݒ�t�@�C���Ȃ�
                    res = MessageBox.Show( "���̃A�Z���u���̐ݒ�XML�t�@�C��������܂���B\n�V�K�쐬���܂����H", "�m�F", MessageBoxButtons.YesNo );
                    if ( res == DialogResult.No )
                    {
                        // �m�n�����f
                        return;
                    }
                }
            }

            // ������
            _uisetDataSet.UiSet.Rows.Clear();
            _uisetDataSet.SetDD.Rows.Clear();


            SFCMN00299CA progressDialog = new SFCMN00299CA();
            try
            {
                progressDialog.Title = "������...";
                progressDialog.Message = "�ݒ�̓ǂݍ��ݒ��ł�...";
                progressDialog.Show();

                //---------------------------------------------------
                // ���ʐݒ�
                //---------------------------------------------------
                // ���ʐݒ�XML�t�@�C����ǂݍ���
                _uiSetCommon = _uiSetFileAcs.ReadUiSetCommon();

                if ( _uiSetCommon == null )
                {
                    _uiSetCommon = new UiSetCommon();
                    _uiSetCommon.UISetDD = new List<UiSet>();
                    _uiSetCommon.UISetItems = new List<UiSetItem>();
                    // return;
                }
                // �O���b�h�\��
                CopyToUiSetTableFromUiSetCommon( _uiSetCommon );

                if ( asmName != string.Empty )
                {
                    //---------------------------------------------------
                    // �A�Z���u���ݒ�
                    //---------------------------------------------------
                    if ( existsXML )
                    {
                        // �A�Z���u���ɑΉ�����XML�t�@�C����ǂݍ���
                        _uiSetAsm = _uiSetFileAcs.ReadUiSetByAssembly( asmName );
                        // �O���b�h�\�� 
                        CopyToUiSetTableFromUiSetAsm( _uiSetAsm, asmName );
                    }

                    // �A�Z���u���ɑ΂��ă��t���N�V�����ɂ��ݒ�l���擾����
                    // (�����ł�XML�t�@�C���������Ă��A�ύX���𒊏o����ׂɍēx�s��)
                    CreateSetting( assemblyFileName );
                }

                // �\��������������A�X�V�{�^����������悤�ɂ���
                this.bt_Update.Enabled = true;

            }
            finally
            {
                // �������t�H�[�������
                progressDialog.Close();

                //if ( _uiSetCommon == null )
                //{
                //    MessageBox.Show( "���ʐݒ�t�@�C����������܂���B" );
                //}
            }
        }
        /// <summary>
        /// �A�Z���u���ʐݒ�@�V�K�쐬����
        /// </summary>
        /// <param name="asmName"></param>
        /// <remarks>
        /// <br>���t���N�V�����ɂ��A�t�h�A�Z���u��������͍��ڈꗗ�𐶐����܂��B</br>
        /// </remarks>
        private void CreateSetting( string assemblyFileName )
        {
            // �A�Z���u���̃��[�h
            Assembly assembly = Assembly.LoadFile( assemblyFileName );
            if ( assembly == null )
            {
                return;
            }

            // �t�H�[���N���X�̒��o
            foreach ( Type definedType in assembly.GetTypes() )
            {
                //try
                //{
                //    // �C���X�^���X����
                //    object obj = Activator.CreateInstance( definedType );

                //    // �C���X�^���X��Form���p������N���X�̃C���X�^���X��
                //    // ���肵�A�������s��
                //    if ( obj is Form )
                //    {
                //        CreateSettingByForm( (Form)obj, assemblyFileName );
                //    }
                //}
                //catch
                //{
                //    // �f�t�H���g�R���X�g���N�^�̖����N���X��
                //    // CreateInstance�ŃG���[�ɂȂ邪�A�������ēǂݔ�΂��B
                //}

                // Form�܂���Form�̃T�u�N���X�܂���UserControl�܂���UserControl�T�u�N���X�Ȃ�Β��o
                if ( definedType == typeof(Form) || definedType.IsSubclassOf( typeof(Form) ) ||
                     definedType == typeof(UserControl) || definedType.IsSubclassOf( typeof(UserControl)))
                {
                    CreateSettingByForm( definedType, assemblyFileName );
                }
            }
        }
        /// <summary>
        /// �t�H�[�����̓��͍��ڂ��O���b�h�ɓW�J����
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="assemblyFileName"></param>
        private void CreateSettingByForm( Type formType, string assemblyFileName )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/09 ADD
            // ���o���珜�O����R���g���[�����̂̃��X�g
            List<string> ignoreNames = new List<string>(new string[]
                {
                    "YearEdit",     // TDateEdit���\������NEdit
                    "MonthEdit",    // TDateEdit���\�����錎Edit
                    "DayEdit"       // TDateEdit���\�������Edit
                });
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/09 ADD

            FieldInfo[] fields = formType.GetFields( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
            foreach ( FieldInfo fieldInfo in fields )
            {
                // TEdit�܂���TEdit�̃T�u�N���X�iTNedit�܂ށj�Ȃ��
                if ( fieldInfo.FieldType == typeof(TEdit) || fieldInfo.FieldType.IsSubclassOf( typeof( TEdit ) ) )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/09 ADD
                    // ���O���閼�̂Ȃ�ΉI��
                    if ( ignoreNames.Contains( fieldInfo.Name ) )
                    {
                        continue;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/09 ADD

                    // ���ꖼ�̂Őݒ肪�������m�F����
                    if ( ExistsItemSetting( fieldInfo.Name ) )
                    {
                        continue;
                    }

                    // �V�����s��ǉ�
                    UiSetDataSet.UiSetRow row = _uisetDataSet.UiSet.NewUiSetRow();

                    row.NewMark = "NEW";        // ���t���N�V�����ɂ�莩�����o��������"NEW"�\��
                    row.DDName = string.Empty;  // ������Ԃ͖����͂ɂ���
                    row.ItemName = fieldInfo.Name;
                    row.AssemblyName = Path.GetFileNameWithoutExtension( assemblyFileName );
                    row.FormName = formType.Name;

                    _uisetDataSet.UiSet.AddUiSetRow( row );
                }
            }
        }
        ///// <summary>
        ///// �t�H�[�����̓��͍��ڐݒ���O���b�h�ɓW�J����
        ///// </summary>
        ///// <param name="form"></param>
        //private void CreateSettingByForm( Form form, string assemblyFileName )
        //{
        //    // �R���g���[���ꗗ����
        //    List<Control> controlList = new List<Control>();
        //    CreateControlList( ref controlList, form );

        //    // �ꗗ������UI�ݒ�N���X�𐶐�
        //    foreach ( Control control in controlList )
        //    {
        //        // TEdit/TNedit�Ȃ��
        //        if ( control is TEdit )
        //        {
        //            // ���ꖼ�̂Őݒ肪�������m�F����
        //            if ( ExistsItemSetting( control.Name ) )
        //            {
        //                continue;
        //            }

        //            // �V�����s��ǉ�
        //            UiSetDataSet.UiSetRow row = _uisetDataSet.UiSet.NewUiSetRow();

        //            row.NewMark = "NEW";        // ���t���N�V�����ɂ�莩�����o��������"NEW"�\��
        //            row.DDName = string.Empty;  // ������Ԃ͖����͂ɂ���
        //            row.ItemName = control.Name;
        //            row.AssemblyName = Path.GetFileNameWithoutExtension( assemblyFileName );
        //            row.FormName = form.GetType().Name;

        //            _uisetDataSet.UiSet.AddUiSetRow( row );
        //        }
        //    }
        //}
        ///// <summary>
        ///// �R���g���[���ꗗ����
        ///// </summary>
        ///// <param name="controlList"></param>
        ///// <param name="control"></param>
        //private void CreateControlList( ref List<Control> controlList, Control control )
        //{
        //    // ���X�g�ɒǉ�
        //    controlList.Add( control );

        //    // �q�R���g���[���ɍċA
        //    foreach ( Control childControl in control.Controls )
        //    {
        //        CreateControlList( ref controlList, childControl );
        //    }
        //}

        /// <summary>
        /// ���ꖼ�̂̍��ڂ����݂��邩�`�F�b�N����i���ʁE�A�Z���u���ʂǂ�����`�F�b�N����j
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private bool ExistsItemSetting( string itemName )
        {
            // �f�[�^�r���[����
            DataView view = new DataView( _uisetDataSet.UiSet );
            view.RowFilter = string.Format( "{0} = '{1}'",
                                            _uisetDataSet.UiSet.ItemNameColumn.ColumnName, itemName );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //���啶���E����������ʂ��Ă��Ȃ������̂ŁA�ȉ��C��

            //if ( view.Count > 0 )
            //{
            //    // ���ꖼ�̂̃��R�[�h�����݂���
            //    return true;
            //}
            //else
            //{
            //    // ���ꖼ�̂̃��R�[�h�����݂��Ȃ�
            //    return false;
            //}

            foreach ( DataRowView rowView in view )
            {
                if ( (string)rowView[_uisetDataSet.UiSet.ItemNameColumn.ColumnName] == itemName )
                {
                    // ���ꖼ�̂̍��ڂ���
                    return true;
                }
            }
            // ���ꖼ�̂̍��ڂȂ�
            return false;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// ���ʐݒ�ɓ��ꖼ�̂̍��ڂ����݂��邩�`�F�b�N����
        /// </summary>
        /// <returns></returns>
        private bool ExistsItemSetting( string assemblyName, string formName, string itemName )
        {
            // �f�[�^�r���[����
            DataView view = new DataView( _uisetDataSet.UiSet );
            view.RowFilter = string.Format( "{0} = '{1}' AND {2} = '{3}'",
                                            _uisetDataSet.UiSet.AssemblyNameColumn.ColumnName, assemblyName,
                                            _uisetDataSet.UiSet.FormNameColumn.ColumnName, formName,
                                            _uisetDataSet.UiSet.ItemNameColumn.ColumnName, itemName );

            foreach ( DataRowView rowView in view )
            {
                if ( (string)rowView[_uisetDataSet.UiSet.ItemNameColumn.ColumnName] == itemName )
                {
                    // ���ꖼ�̂̍��ڂ���
                    return true;
                }
            }
            // ���ꖼ�̂̍��ڂȂ�
            return false;
        }

        /// <summary>
        /// ���ʐݒ��荞�݁iUiSetCommon �� UiSetTable�j
        /// </summary>
        /// <param name="_uiSetCommon"></param>
        private void CopyToUiSetTableFromUiSetCommon( UiSetCommon uiSetCommon )
        {
            // ���͍��ڐݒ�̃R���{�{�b�N�X����
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)this.gridUiSet.Columns[_uisetDataSet.UiSet.DDNameColumn.ColumnName];
            // ������
            cmbColumn.Items.Clear();
            cmbColumn.Items.Add( string.Empty );
            

            //---------------------------------------------------
            // �c�c�ݒ�
            //---------------------------------------------------
            UiSetDataSet.SetDDRow ddRow;

            foreach ( UiSet ddItem in uiSetCommon.UISetDD )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // ���ɓ���c�c������Ώ��O�i��ɓǂݍ��񂾓��e���D��j
                if ( cmbColumn.Items.Contains( ddItem.ItemDDName ) )
                {
                    continue;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // �P���ږ��ɂP�s�ǉ�
                ddRow = _uisetDataSet.SetDD.NewSetDDRow();

                ddRow.Remarks = ddItem.Remarks;
                ddRow.AssemblyName = string.Empty;  // ���ʐݒ�Ȃ̂�Empty
                ddRow.DDName = ddItem.ItemDDName;
                ddRow.Columns = ddItem.Column;
                ddRow.AllowAlpha = ddItem.AllowAlpha;
                ddRow.AllowKana = ddItem.AllowKana;
                ddRow.AllowNum = ddItem.AllowNum;
                ddRow.AllowNumSign = ddItem.AllowNumSign;
                ddRow.AllowSign = ddItem.AllowSign;
                ddRow.AllowSpace = ddItem.AllowSpace;
                ddRow.AllowWord = ddItem.AllowWord;
                ddRow.PadZero = ddItem.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                ddRow.AllowZeroCode = ddItem.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD
                ddRow.ImeMode = this.GetImeModeText( ddItem.ImeMode );
                ddRow.HAlign = this.GetHAlignText( ddItem.HAlign );

                // �ǉ�
                _uisetDataSet.SetDD.Rows.Add( ddRow );

                // ���͍��ڐݒ�̃R���{�{�b�N�X�ɃA�C�e���ǉ�
                cmbColumn.Items.Add( ddItem.ItemDDName );
            }

            //---------------------------------------------------
            // ���͍��ڐݒ�
            //---------------------------------------------------
            UiSetDataSet.UiSetRow setRow;
            
            foreach ( UiSetItem item in uiSetCommon.UISetItems )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // ���ꖼ�̂Őݒ肪�������m�F����
                // (���������ʐݒ���ɏd�����ēo�^������΁A�P�ɂ܂Ƃ߂�B
                //    ���̂Ƃ��AXML�t�@�C����A��ԏ�ɋL�q����Ă������̂��D��)
                if ( ExistsItemSetting( item.ItemName ) )
                {
                    continue;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // �P���ږ��ɂP�s�ǉ�
                setRow = _uisetDataSet.UiSet.NewUiSetRow();

                setRow.NewMark = string.Empty;      // �ݒ�ςݍ��ڂȂ̂ŁA"NEW"�\�����Ȃ�
                setRow.AssemblyName = string.Empty; // ���ʐݒ�Ȃ̂�Empty
                setRow.FormName = string.Empty;     // ���ʐݒ�Ȃ̂�Empty
                setRow.ItemName = item.ItemName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                //{
                //    cmbColumn.Items.Add( item.ItemDDName );
                //}
                //setRow.DDName = item.ItemDDName;

                if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                {
                    // �c�c�ݒ�ɖ����ꍇ�͋󔒂ɂ���i�����ӁI�󔒂̂܂܍X�V����Ɛݒ肪�폜����܂��I�j
                    setRow.DDName = string.Empty;
                }
                else
                {
                    setRow.DDName = item.ItemDDName;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // �ǉ�
                _uisetDataSet.UiSet.Rows.Add( setRow );
            }

            // �R���{�{�b�N�X�A�C�e�����\�[�g����
            ComboBoxItemSort( cmbColumn );
        }

        /// <summary>
        /// �R���{�{�b�N�X�A�C�e���̃\�[�g����
        /// </summary>
        /// <param name="cmbColumn"></param>
        private void ComboBoxItemSort( DataGridViewComboBoxColumn cmbColumn )
        {
            // �A�C�e�������X�g�Ɉڂ��ւ���
            List<string> _itemList = new List<string>();
            foreach ( object obj in cmbColumn.Items )
            {
                if ( obj is string )
                {
                    _itemList.Add( (string)obj );
                }
            }

            // �\�[�g����
            _itemList.Sort();

            // �A�C�e���������ւ���
            cmbColumn.Items.Clear();
            cmbColumn.Items.AddRange( _itemList.ToArray() );
        }
        /// <summary>
        /// �A�Z���u���ʐݒ��荞�݁iUiSetByAssembly �� UiSetTable�j
        /// </summary>
        /// <param name="uiSetAsm"></param>
        private void CopyToUiSetTableFromUiSetAsm( UiSetByAssembly uiSetAsm, string assemblyName )
        {
            // ���͍��ڐݒ�̃R���{�{�b�N�X����
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)this.gridUiSet.Columns[_uisetDataSet.UiSet.DDNameColumn.ColumnName];
            //// ���������Ȃ�
            //cmbColumn.Items.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �A�Z���u���ŗL�̂c�c�̏d���`�F�b�N�p
            List<string> thisAsmDDList = new List<string>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //---------------------------------------------------
            // �c�c�ݒ�
            //---------------------------------------------------
            UiSetDataSet.SetDDRow ddRow;

            foreach ( UiSet ddItem in uiSetAsm.UISetDD )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �A�Z���u���ŗL�̂c�c�̏d���`�F�b�N
                if ( thisAsmDDList.Contains( ddItem.ItemDDName ) )
                {
                    // ���̃A�Z���u���ŗL�̂c�c�Ƃ��Ċ��ɑ��݂���Ώ��O�i��ɓǂݍ��񂾕����D��j
                    continue;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // �P���ږ��ɂP�s�ǉ�
                ddRow = _uisetDataSet.SetDD.NewSetDDRow();

                ddRow.Remarks = ddItem.Remarks;
                ddRow.AssemblyName = assemblyName;  // �A�Z���u���ʐݒ�Ȃ̂ŁA���̃Z�b�g
                ddRow.DDName = ddItem.ItemDDName;
                ddRow.Columns = ddItem.Column;
                ddRow.AllowAlpha = ddItem.AllowAlpha;
                ddRow.AllowKana = ddItem.AllowKana;
                ddRow.AllowNum = ddItem.AllowNum;
                ddRow.AllowNumSign = ddItem.AllowNumSign;
                ddRow.AllowSign = ddItem.AllowSign;
                ddRow.AllowSpace = ddItem.AllowSpace;
                ddRow.AllowWord = ddItem.AllowWord;
                ddRow.PadZero = ddItem.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                ddRow.AllowZeroCode = ddItem.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD

                ddRow.ImeMode = this.GetImeModeText( ddItem.ImeMode );
                ddRow.HAlign = this.GetHAlignText( ddItem.HAlign );

                // �ǉ�
                _uisetDataSet.SetDD.Rows.Add( ddRow );

                // ���͍��ڐݒ�̃R���{�{�b�N�X�ɃA�C�e���ǉ�
                cmbColumn.Items.Add( ddItem.ItemDDName );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �A�Z���u���ŗL�̂c�c�̏d���`�F�b�N�p
                thisAsmDDList.Add( ddItem.ItemDDName );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            //---------------------------------------------------
            // ���͍��ڐݒ�
            //---------------------------------------------------
            UiSetDataSet.UiSetRow setRow;

            foreach ( UiSetByForm uiSetFm in uiSetAsm.UISetByForms )
            {
                foreach ( UiSetItem item in uiSetFm.UISetItems )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // ����A�Z���u������t�H�[�����ŏd������ݒ肪�L�����ꍇ�͂P�ɂ܂Ƃ߂�
                    // (�����̂Ƃ��AXML�t�@�C�����ԏ�ɋL�q����Ă������e��D��)
                    ExistsItemSetting( assemblyName, uiSetFm.FormName, item.ItemName );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // �P���ږ��ɂP�s�ǉ�
                    setRow = _uisetDataSet.UiSet.NewUiSetRow();

                    setRow.NewMark = string.Empty;          // �ݒ�ςݍ��ڂȂ̂�"NEW"�\�����Ȃ�
                    setRow.AssemblyName = assemblyName;     // �A�Z���u���ʐݒ�Ȃ̂ŁA���̃Z�b�g
                    setRow.FormName = uiSetFm.FormName;     // �A�Z���u���ʐݒ�Ȃ̂ŁA���̃Z�b�g
                    setRow.ItemName = item.ItemName;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                    //{
                    //    cmbColumn.Items.Add( item.ItemDDName );
                    //}
                    //setRow.DDName = item.ItemDDName;

                    if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                    {
                        // �c�c�ݒ�ɓo�^��������΋󔒂ɂ���B�i�����ӁI�󔒂ōX�V����Ɛݒ肪�폜����܂��I�j
                        setRow.DDName = string.Empty;
                    }
                    else
                    {
                        setRow.DDName = item.ItemDDName;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // �ǉ�
                    _uisetDataSet.UiSet.Rows.Add( setRow );
                }
            }

            // �R���{�{�b�N�X�A�C�e�����\�[�g����
            ComboBoxItemSort( cmbColumn );

        }

        /// <summary>
        /// ���E������������Ή����镶������擾
        /// </summary>
        /// <param name="hAlign"></param>
        /// <returns></returns>
        private string GetHAlignText( Infragistics.Win.HAlign hAlign )
        {
            switch ( hAlign )
            {
                case Infragistics.Win.HAlign.Center:
                    return "Center";
                case Infragistics.Win.HAlign.Default:
                    return "Left";  // default��Left�ɂ���
                case Infragistics.Win.HAlign.Left:
                    return "Left";
                case Infragistics.Win.HAlign.Right:
                    return "Right";
                default:
                    return "Left";  // default��Left�ɂ���
            }
        }
        /// <summary>
        /// �����񂩂�Ή����鍶�E�����������擾
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Infragistics.Win.HAlign GetHAlign( string hAlignText )
        {
            switch ( hAlignText )
            {
                case "Left":
                    return Infragistics.Win.HAlign.Left;
                case "Center":
                    return Infragistics.Win.HAlign.Center;
                case "Right":
                    return Infragistics.Win.HAlign.Right;
                default:
                    return Infragistics.Win.HAlign.Left;    // default��Left�ɂ���
            }
        }
        /// <summary>
        /// �h�l�d���[�h�ɑΉ����镶������擾
        /// </summary>
        /// <param name="imeMode"></param>
        /// <returns></returns>
        private string GetImeModeText( ImeMode imeMode )
        {
            switch ( imeMode )
            {
                case ImeMode.Alpha:
                    return "Alpha";
                case ImeMode.AlphaFull:
                    return "AlphaFull";
                case ImeMode.Close:
                    return "Close";
                case ImeMode.Disable:
                    return "Disable";
                case ImeMode.Hangul:
                    return "Hangul";
                case ImeMode.HangulFull:
                    return "HangulFull";
                case ImeMode.Hiragana:
                    return "Hiragana";
                case ImeMode.Inherit:
                    return "Inherit";
                case ImeMode.Katakana:
                    return "Katakana";
                case ImeMode.KatakanaHalf:
                    return "KatakanaHalf";
                case ImeMode.NoControl:
                    return "NoControl";
                case ImeMode.Off:
                    return "Off";
                case ImeMode.On:
                    return "On";
                default:
                    return "NoControl"; // default��NoControl�ɂ���
            }
        }
        /// <summary>
        /// ������ɑΉ�����h�l�d���[�h���擾
        /// </summary>
        /// <param name="imeModeText"></param>
        /// <returns></returns>
        private ImeMode GetImeMode( string imeModeText )
        {
            switch ( imeModeText )
            {
                case "Alpha":
                    return ImeMode.Alpha;
                case "AlphaFull":
                    return ImeMode.AlphaFull;
                case "Close":
                    return ImeMode.Close;
                case "Disable":
                    return ImeMode.Disable;
                case "Hangul":
                    return ImeMode.Hangul;
                case "HangulFull":
                    return ImeMode.HangulFull;
                case "Hiragana":
                    return ImeMode.Hiragana;
                case "Inherit":
                    return ImeMode.Inherit;
                case "Katakana":
                    return ImeMode.Katakana;
                case "KatakanaHalf":
                    return ImeMode.KatakanaHalf;
                case "NoControl":
                    return ImeMode.NoControl;
                case "Off":
                    return ImeMode.Off;
                case "On":
                    return ImeMode.On;
                default:
                    return ImeMode.NoControl;   // default��NoControl�ɂ���
            }
        }


        # endregion �� �ݒ�\���֘A ��

        # region �� �ݒ�t�@�C���������݊֘A ��
        /// <summary>
        /// �������݃{�^���������̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click( object sender, EventArgs e )
        {
            // �X�V�_�C�A���O
            SaveCompletionDialog cmplDialog;

            // ���ʐݒ菑������
            DialogResult dialogResult = MessageBox.Show( "�S�o�f���ʂ̐ݒ���X�V���܂����H", "�m�F", MessageBoxButtons.YesNo );
            if ( dialogResult == DialogResult.Yes )
            {
                if ( WriteXMLCommon() )
                {
                    cmplDialog = new SaveCompletionDialog();
                    cmplDialog.ShowDialog( 2 );
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    MessageBox.Show( "�S�o�f���ʐݒ�̍X�V�Ɏ��s���܂����B\r\n�i�ǂݎ���p�������m�F���ĉ������j" );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }

            if ( this.lb_AssemblySnm.Text.Trim() != string.Empty )
            {
                // �A�Z���u���ʐݒ菑������
                dialogResult = MessageBox.Show( "�A�Z���u���ʂ̐ݒ���X�V���܂����H", "�m�F", MessageBoxButtons.YesNo );
                if ( dialogResult == DialogResult.Yes )
                {
                    if ( WriteXMLByAssembly() )
                    {
                        cmplDialog = new SaveCompletionDialog();
                        cmplDialog.ShowDialog( 2 );
                    }
                    else
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        MessageBox.Show( "�A�Z���u���ʐݒ�̍X�V�Ɏ��s���܂����B\r\n�i�ǂݎ���p�������m�F���ĉ������j" );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    }
                }
            }
        }
        /// <summary>
        /// �A�Z���u���ʐݒ�w�l�k�t�@�C���������ݏ���
        /// </summary>
        private bool WriteXMLByAssembly()
        {
            // �ݒ�N���X����
            UiSetByAssembly uiSetAsm = new UiSetByAssembly();

            //-----------------------------------------------------------
            // �c�c�ݒ�
            //-----------------------------------------------------------
            uiSetAsm.UISetDD = new List<UiSet>();

            foreach ( UiSetDataSet.SetDDRow ddRow in _uisetDataSet.SetDD.Rows )
            {
                // �������ݒ肳��Ă��Ȃ��s�͏��O
                if ( ddRow.DDName == string.Empty )
                {
                    continue;
                }
                // ���ʐݒ�̍s�͏��O
                if ( ddRow.AssemblyName == string.Empty )
                {
                    continue;
                }

                UiSet uiSet = new UiSet();

                uiSet.Remarks = ddRow.Remarks;
                uiSet.ItemDDName = ddRow.DDName;
                uiSet.Column = ddRow.Columns;
                uiSet.AllowAlpha = ddRow.AllowAlpha;
                uiSet.AllowKana = ddRow.AllowKana;
                uiSet.AllowNum = ddRow.AllowNum;
                uiSet.AllowNumSign = ddRow.AllowNumSign;
                uiSet.AllowSign = ddRow.AllowSign;
                uiSet.AllowSpace = ddRow.AllowSpace;
                uiSet.AllowWord = ddRow.AllowWord;
                uiSet.PadZero = ddRow.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                uiSet.AllowZeroCode = ddRow.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD

                uiSet.ImeMode = this.GetImeMode( ddRow.ImeMode );
                uiSet.HAlign = this.GetHAlign( ddRow.HAlign );

                uiSetAsm.UISetDD.Add( uiSet );
            }
            // �\�[�g
            uiSetAsm.UISetDD.Sort();


            //-----------------------------------------------------------
            // ���͍��ڐݒ�
            //-----------------------------------------------------------

            uiSetAsm.UISetByForms = new List<UiSetByForm>();
            Dictionary<string,UiSetByForm> setFmDic = new Dictionary<string,UiSetByForm>();

            foreach ( UiSetDataSet.UiSetRow setRow in _uisetDataSet.UiSet.Rows )
            {
                // �������ݒ肳��Ă��Ȃ��s�͏��O
                if ( setRow.ItemName == string.Empty )
                {
                    continue;
                }
                // �������ݒ肳��Ă��Ȃ��s�͏��O
                if ( setRow.DDName == string.Empty )
                {
                    continue;
                }
                // �A�Z���u���ʐݒ�̍s�͏��O
                if ( setRow.AssemblyName == string.Empty )
                {
                    continue;
                }


                // �t�H�[���̐؂蕪��
                UiSetByForm uiSetFm;
                if ( setFmDic.ContainsKey( setRow.FormName ) )
                {
                    // �����̃t�H�[���ݒ�
                    uiSetFm = setFmDic[setRow.FormName];
                }
                else
                {
                    // �V�K�t�H�[���ݒ���쐬
                    uiSetFm = new UiSetByForm();
                    uiSetFm.FormName = setRow.FormName;
                    uiSetFm.UISetItems = new List<UiSetItem>();
                    uiSetAsm.UISetByForms.Add( uiSetFm );   // �Q�ƌ^�Ȃ̂Ő�ɒǉ����Ă��n�j

                    // �f�B�N�V���i���ɒǉ�
                    setFmDic.Add( uiSetFm.FormName, uiSetFm );
                }

                UiSetItem uiSetItem = new UiSetItem();

                uiSetItem.ItemName = setRow.ItemName;
                uiSetItem.ItemDDName = setRow.DDName;

                uiSetFm.UISetItems.Add( uiSetItem );
            }
            // �\�[�g
            foreach ( UiSetByForm fm in uiSetAsm.UISetByForms )
            {
                fm.UISetItems.Sort();
            }

            // ��������
            return _uiSetFileAcs.WriteXMLByAssembly( this.lb_AssemblySnm.Text, uiSetAsm );

        }
        /// <summary>
        /// ���ʐݒ�w�l�k�t�@�C���������ݏ���
        /// </summary>
        private bool WriteXMLCommon()
        {
            // �ݒ�N���X����
            UiSetCommon uiSetCmn = new UiSetCommon();

            //-----------------------------------------------------------
            // �c�c�ݒ�
            //-----------------------------------------------------------
            uiSetCmn.UISetDD = new List<UiSet>();

            foreach ( UiSetDataSet.SetDDRow ddRow in _uisetDataSet.SetDD.Rows )
            {
                // �������ݒ肳��Ă��Ȃ��s�͏��O
                if ( ddRow.DDName == string.Empty )
                {
                    continue;
                }
                // �A�Z���u���ʐݒ�̍s�͏��O
                if ( ddRow.AssemblyName != string.Empty )
                {
                    continue;
                }

                UiSet uiSet = new UiSet();
                
                uiSet.Remarks = ddRow.Remarks;
                uiSet.ItemDDName = ddRow.DDName;
                uiSet.Column = ddRow.Columns;
                uiSet.AllowAlpha = ddRow.AllowAlpha;
                uiSet.AllowKana = ddRow.AllowKana;
                uiSet.AllowNum = ddRow.AllowNum;
                uiSet.AllowNumSign = ddRow.AllowNumSign;
                uiSet.AllowSign = ddRow.AllowSign;
                uiSet.AllowSpace = ddRow.AllowSpace;
                uiSet.AllowWord = ddRow.AllowWord;
                uiSet.PadZero = ddRow.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                uiSet.AllowZeroCode = ddRow.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD
                uiSet.ImeMode = this.GetImeMode( ddRow.ImeMode );
                uiSet.HAlign = this.GetHAlign( ddRow.HAlign );

                uiSetCmn.UISetDD.Add( uiSet );
            }
            // �\�[�g
            uiSetCmn.UISetDD.Sort();


            //-----------------------------------------------------------
            // ���͍��ڐݒ�
            //-----------------------------------------------------------
            uiSetCmn.UISetItems = new List<UiSetItem>();

            foreach ( UiSetDataSet.UiSetRow setRow in _uisetDataSet.UiSet.Rows )
            {
                // �������ݒ肳��Ă��Ȃ��s�͏��O
                if ( setRow.ItemName == string.Empty )
                {
                    continue;
                }
                // �������ݒ肳��Ă��Ȃ��s�͏��O
                if ( setRow.DDName == string.Empty )
                {
                    continue;
                }
                // �A�Z���u���ʐݒ�̍s�͏��O
                if ( setRow.AssemblyName != string.Empty )
                {
                    continue;
                }

                UiSetItem uiSetItem = new UiSetItem();

                uiSetItem.ItemName = setRow.ItemName;
                uiSetItem.ItemDDName = setRow.DDName;

                uiSetCmn.UISetItems.Add( uiSetItem );
            }
            // �\�[�g
            uiSetCmn.UISetItems.Sort();


            // ��������
            return _uiSetFileAcs.WriteXMLCommon( uiSetCmn );
        }

        # endregion �� �ݒ�t�@�C���������݊֘A ��

        # region �� �O���b�h�����ݒ�֘A ��
        /// <summary>
        /// ���͍��ڗp�O���b�h�̐ݒ菈��
        /// </summary>
        private void SettingGridUiSet()
        {
            // �f�[�^�\�[�X��o�^
            this.gridUiSet.DataSource = _uisetDataSet.UiSet;

            // �t�H���g�ݒ�
            this.gridUiSet.Font = new Font( "�l�r �S�V�b�N", 10.5f );

            // ComboBox��̐ݒ�
            List<string> itemList = new List<string>(); // �����ڂ����I�ɕς��ׁA���̃^�C�~���O�ł͒ǉ��ł��Ȃ��̂ŁA��̃��X�g��n��
            SetComboBoxColumn( this.gridUiSet, _uisetDataSet.UiSet, _uisetDataSet.UiSet.DDNameColumn.ColumnName, itemList );

            // ���ږ���ݒ�
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.NewMarkColumn.ColumnName, "", 40, true );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.AssemblyNameColumn.ColumnName, "�A�Z���u��", 120 );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.FormNameColumn.ColumnName, "�t�H�[��", 120 );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.ItemNameColumn.ColumnName, "���͍��ږ�(*)", 210 );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.DDNameColumn.ColumnName, "�c�c(*)", 210 );

        }
        /// <summary>
        /// �c�c�p�O���b�h�̐ݒ菈��
        /// </summary>
        private void SettingGridSetDD()
        {
            // �f�[�^�\�[�X��o�^
            this.gridSetDD.DataSource = _uisetDataSet.SetDD;

            // �t�H���g�ݒ�
            this.gridSetDD.Font = new Font( "�l�r �S�V�b�N", 10.5f );

            // ComboBox��̐ݒ�
            // (HAlign)
            List<string> itemList = new List<string>();
            itemList.Add( "Left" );
            itemList.Add( "Center" );
            itemList.Add( "Right" );
            SetComboBoxColumn( this.gridSetDD, _uisetDataSet.SetDD, _uisetDataSet.SetDD.HAlignColumn.ColumnName, itemList );
            // (IMEMode)
            itemList = new List<string>();
            itemList.Add( "Alpha" );
            itemList.Add( "AlphaFull" );
            itemList.Add( "Close" );
            itemList.Add( "Disable" );
            itemList.Add( "Hangul" );
            itemList.Add( "HangulFull" );
            itemList.Add( "Hiragana" );
            itemList.Add( "Inherit" );
            itemList.Add( "Katakana" );
            itemList.Add( "KatakanaHalf" );
            itemList.Add( "NoControl" );
            itemList.Add( "Off" );
            itemList.Add( "On" );
            SetComboBoxColumn( this.gridSetDD, _uisetDataSet.SetDD, _uisetDataSet.SetDD.ImeModeColumn.ColumnName, itemList );

            // ���ږ���ݒ�
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AssemblyNameColumn.ColumnName, "������", 100 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.RemarksColumn.ColumnName, "����", 110 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.DDNameColumn.ColumnName, "�c�c(*)", 110 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.ColumnsColumn.ColumnName, "����", 30 );
            
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowAlphaColumn.ColumnName, "�p��", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowKanaColumn.ColumnName, "�J�i", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowNumColumn.ColumnName, "����", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowNumSignColumn.ColumnName, "���L��", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowSignColumn.ColumnName, "�L��", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowSpaceColumn.ColumnName, "��", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowWordColumn.ColumnName, "�S�p", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.HAlignColumn.ColumnName, "���E��", 80 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.PadZeroColumn.ColumnName, "��ۋl", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowZeroCodeColumn.ColumnName, "��ۉ�", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.ImeModeColumn.ColumnName, "IMEӰ��", 120 );

        }

        /// <summary>
        /// �O���b�h��X�^�C���ݒ�
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        private void SetColumnStyle( DataGridView grid, string columnName, string caption, int width )
        {
            // ��X�^�C���ݒ�iReadOnly=false�j
            SetColumnStyle( grid, columnName, caption, width, false );
        }

        /// <summary>
        /// �O���b�h��X�^�C���ݒ�
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        private void SetColumnStyle( DataGridView grid, string columnName, string caption, int width, bool readOnly )
        {
            // �^�ɂ���āA���E�����ʒu�������Ŏ擾
            DataGridViewContentAlignment align;

            if ( grid.Columns[columnName].ValueType == typeof( Int32 ) )
            {
                align = DataGridViewContentAlignment.MiddleRight;
            }
            else if ( grid.Columns[columnName].ValueType == typeof( Boolean ) )
            {
                align = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                align = DataGridViewContentAlignment.MiddleLeft;
            }

            // ��X�^�C���ݒ�
            SetColumnStyle( grid, columnName, caption, width, align, readOnly );
        }
        /// <summary>
        /// �O���b�h��X�^�C���ݒ�
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        private void SetColumnStyle( DataGridView grid, string columnName, string caption, int width, DataGridViewContentAlignment align, bool readOnly )
        {
            grid.Columns[columnName].HeaderText = caption;
            grid.Columns[columnName].Width = width;
            grid.Columns[columnName].DefaultCellStyle.Alignment = align;

            // �ǂݎ���p�̗�X�^�C��
            if ( readOnly )
            {
                grid.Columns[columnName].ReadOnly = true;
                grid.Columns[columnName].DefaultCellStyle.SelectionForeColor = Color.Black;
                grid.Columns[columnName].DefaultCellStyle.BackColor = SystemColors.Control;
                grid.Columns[columnName].DefaultCellStyle.SelectionBackColor = SystemColors.Control;
            }
        }
        /// <summary>
        /// �R���{�{�b�N�X��̐ݒ�
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="itemList"></param>
        private void SetComboBoxColumn( DataGridView grid, DataTable table, string columnName, List<string> itemList )
        {
            // �R���{�{�b�N�X����`����
            DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();
            
            // �I���A�C�e���ꗗ�𐶐�
            foreach ( string itemText in itemList )
            {
                cmbColumn.Items.Add( itemText );
            }

            // ���������R���{�{�b�N�X��Ɗ����̗�������ւ���
            string cmbColumnName = columnName;
            cmbColumn.DataPropertyName = cmbColumnName;

            int index = table.Columns.IndexOf( cmbColumnName );

            grid.Columns.Insert( index, cmbColumn );
            grid.Columns.Remove( cmbColumnName );
            cmbColumn.Name = cmbColumnName;
        }
        # endregion �� �O���b�h�����ݒ�֘A ��

        # region �� �h���b�O���h���b�v ��
        /// <summary>
        /// �h���b�O���h���b�v����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Assembly_DragOver( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                if ( (e.AllowedEffect & DragDropEffects.Move) != 0 )
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        /// <summary>
        /// �h���b�O���h���b�v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Assembly_DragDrop( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                // �h���b�v���ꂽ�t�@�C���̖��̂��擾
                string[] astr = (string[])e.Data.GetData( DataFormats.FileDrop );

                // �t�@�C�������e�L�X�g�{�b�N�X�ɕ\��
                tb_Assembly.Text = astr[0];
            }
        }
        # endregion ���h���b�O���h���b�v ��

        # region �� �t�@�C���I�� ��
        /// <summary>
        /// �t�@�C���I���_�C�A���O
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click( object sender, EventArgs e )
        {
            DialogResult res = openFileDialog1.ShowDialog( this );
            if ( res == DialogResult.OK )
            {
                this.tb_Assembly.Text = openFileDialog1.FileName;
                this.bt_Load.Focus();
            }
        }
        # endregion �� �t�@�C���I�� ��

        # region �� �s�폜�{�^�� ��
        /// <summary>
        /// �s�폜�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1( object sender, EventArgs e )
        {
            // �I������Ă���^�u�ɂ���āA�A�N�e�B�u�ȃO���b�h���ς��
            if ( tabControl1.SelectedIndex == 0 )
            {
                // ���͍��ڐݒ�
                int selectedCount = gridUiSet.SelectedRows.Count;
                for ( int index = 0; index < selectedCount; index++ )
                {
                    int rowIndex = gridUiSet.SelectedRows[0].Index;
                    if ( rowIndex != gridUiSet.Rows.Count - 1 )
                    {
                        gridUiSet.Rows.RemoveAt( rowIndex );
                    }
                }
            }
            else
            {
                // �c�c�ݒ�
                int selectedCount = gridSetDD.SelectedRows.Count;
                for ( int index = 0; index < selectedCount; index++ )
                {
                    int rowIndex = gridSetDD.SelectedRows[0].Index;
                    if ( rowIndex != gridUiSet.Rows.Count - 1 )
                    {
                        gridSetDD.Rows.RemoveAt( rowIndex );
                    }
                }
            }
        }
        # endregion �� �s�폜�{�^�� ��
    }

}