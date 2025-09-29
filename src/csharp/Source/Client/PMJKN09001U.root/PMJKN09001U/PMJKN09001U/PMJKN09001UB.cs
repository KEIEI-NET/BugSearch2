//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������f�[�^�e�[�u���X�L�[�}���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������f�[�^�e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������f�[�^�̃e�[�u���X�L�[�}���N���X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// </remarks>
    class PMJKN09001UB
    {
        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������f�[�^�e�[�u���X�L�[�}���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������f�[�^�e�[�u���X�L�[�}���N���X�̏������A</br>
        /// <br>             �y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public PMJKN09001UB()
        {
        }
        #endregion

        #region -- Public Members --
        /*----------------------------------------------------------------------------------*/
        // DataTable��
        /// <summary> �������f�[�^�e�[�u������ </summary>
        public const string TBL_CARSPECVIEW = "CARSPECVIEW";

        // DataTable��
        /// <summary>�O���[�h</summary>
        public const string COL_MODELGRADENM_TITLE = "�O���[�h";
        /// <summary>�{�f�B</summary>
        public const string COL_BODYNAME_TITLE = "�{�f�B";
        /// <summary>�h�A</summary>
        public const string COL_DOORCOUNT_TITLE = "�h�A";
        /// <summary>�G���W��</summary>
        public const string COL_ENGINEMODELNM_TITLE = "�G���W��";
        /// <summary>�r�C��</summary>
        public const string COL_ENGINEDISPLACENM_TITLE = "�r�C��";
        /// <summary>E�敪</summary>
        public const string COL_EDIVNM_TITLE = "E�敪";
        /// <summary>�~�b�V����</summary>
        public const string COL_TRANSMISSIONNM_TITLE = "�~�b�V����";
        /// <summary>�쓮�`��</summary>
        public const string COL_WHEELDRIVEMETHODNM_TITLE = "�쓮�`��";
        /// <summary>�V�t�g</summary>
        public const string COL_SHIFTNM_TITLE = "�V�t�g";
        #endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g�X�L�[�}�ݒ菈��
        /// </summary>
        /// <param name="ds">�ݒ�Ώۃf�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̃X�L�[�}��ݒ肵�܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        static public void DataSetColumnConstruction(ref DataSet ds)
        {
            if (ds.Tables.Contains(TBL_CARSPECVIEW))
            {
                // �e�[�u�������݂���ꍇ�̓N���A�[�̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ�
                ds.Tables[TBL_CARSPECVIEW].Clear();
            }
            else
            {
                // �e�[�u�������݂��Ȃ��ꍇ�̂݃X�L�[�}��ݒ�

                // �X�L�[�}�ݒ�
                ds.Tables.Add(TBL_CARSPECVIEW);
                DataTable dt = ds.Tables[TBL_CARSPECVIEW];

                // �O���[�h
                dt.Columns.Add(COL_MODELGRADENM_TITLE, typeof(string));
                dt.Columns[COL_MODELGRADENM_TITLE].DefaultValue = "";
                // �{�f�B
                dt.Columns.Add(COL_BODYNAME_TITLE, typeof(string));
                dt.Columns[COL_BODYNAME_TITLE].DefaultValue = "";
                // �h�A
                dt.Columns.Add(COL_DOORCOUNT_TITLE, typeof(string));
                dt.Columns[COL_DOORCOUNT_TITLE].DefaultValue = "";
                // �G���W��
                dt.Columns.Add(COL_ENGINEMODELNM_TITLE, typeof(string));
                dt.Columns[COL_ENGINEMODELNM_TITLE].DefaultValue = "";
                // �r�C��
                dt.Columns.Add(COL_ENGINEDISPLACENM_TITLE, typeof(string));
                dt.Columns[COL_ENGINEDISPLACENM_TITLE].DefaultValue = "";
                // E�敪
                dt.Columns.Add(COL_EDIVNM_TITLE, typeof(string));
                dt.Columns[COL_EDIVNM_TITLE].DefaultValue = "";
                // �~�b�V����
                dt.Columns.Add(COL_TRANSMISSIONNM_TITLE, typeof(string));
                dt.Columns[COL_TRANSMISSIONNM_TITLE].DefaultValue = "";
                // �쓮�`��
                dt.Columns.Add(COL_WHEELDRIVEMETHODNM_TITLE, typeof(string));
                dt.Columns[COL_WHEELDRIVEMETHODNM_TITLE].DefaultValue = "";
                // �V�t�g
                dt.Columns.Add(COL_SHIFTNM_TITLE, typeof(string));
                dt.Columns[COL_SHIFTNM_TITLE].DefaultValue = "";
            }
        }
        #endregion
    }
}
