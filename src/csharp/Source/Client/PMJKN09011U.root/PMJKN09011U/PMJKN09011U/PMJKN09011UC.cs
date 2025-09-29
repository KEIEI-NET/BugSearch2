using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���׏��f�[�^�e�[�u���X�L�[�}���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���׏��f�[�^�̃e�[�u���X�L�[�}���N���X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// </remarks>
    class PMJKN09011UC
    {
        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���׏��f�[�^�e�[�u���X�L�[�}���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׏��f�[�^�e�[�u���X�L�[�}���N���X�̏������A</br>
        /// <br>             �y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public PMJKN09011UC()
        {
        }
        #endregion

        #region -- Public Members --
        /*----------------------------------------------------------------------------------*/
        // DataTable��
        /// <summary> ���׏��f�[�^�e�[�u������ </summary>
        public const string TBL_DETAILVIEW = "DETAILVIEW";

        // DataTable��
        /// <summary>No.</summary>
        public const string COL_NO_TITLE = "No.";
        /// <summary>�i��</summary>
        public const string COL_GOODSNO_TITLE = "�i��";
        /// <summary>���[�J�[</summary>
        public const string COL_MAKER_TITLE = "Ұ��";
        /// <summary>BL�R�[�h</summary>
        public const string COL_BLCODE_TITLE = "BL����";
        /// <summary>�i��</summary>
        public const string COL_GOODSNM_TITLE = "�i��";
        /// <summary>QTY</summary>
        public const string COL_PARTSQTY_TITLE = "QTY";
        /// <summary>�W�����i</summary>
        public const string COL_COSTRATE_TITLE = "�W�����i";
        /// <summary>���Y�N��</summary>
        public const string COL_CREATEYEAR_TITLE = "���Y�N��";
        /// <summary>���Y�ԑ�ԍ�</summary>
        public const string COL_CREATECARNO_TITLE = "���Y�ԑ�ԍ�";
        /// <summary>�O���[�h</summary>
        public const string COL_MODELGRADENM_TITLE = "��ڰ��";
        /// <summary>�{�f�B</summary>
        public const string COL_BODYNAME_TITLE = "���ި";
        /// <summary>�h�A</summary>
        public const string COL_DOORCOUNT_TITLE = "�ޱ";
        /// <summary>�G���W��</summary>
        public const string COL_ENGINEMODELNM_TITLE = "�ݼ��";
        /// <summary>�r�C��</summary>
        public const string COL_ENGINEDISPLACENM_TITLE = "�r�C��";
        /// <summary>E�敪</summary>
        public const string COL_EDIVNM_TITLE = "E�敪";
        /// <summary>�~�b�V����</summary>
        public const string COL_TRANSMISSIONNM_TITLE = "Я���";
        /// <summary>�쓮�`��</summary>
        public const string COL_WHEELDRIVEMETHODNM_TITLE = "�쓮����";
        /// <summary>�V�t�g</summary>
        public const string COL_SHIFTNM_TITLE = "���";
        /// <summary>�E�v</summary>
        public const string COL_ADDICARSPEC_TITLE = "�E�v";
        /// <summary>���R�������i�ŗL�ԍ�</summary>
        public const string COL_FRESRCHPRTPROPNO_TITLE = "���R�������i�ŗL�ԍ�";
        /// <summary>�^���O���[�v�敪</summary>
        public const string COL_FULLMODELGROUP_TITLE = "�^���O���[�v�敪";

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
        public void DataSetColumnConstruction(ref DataSet ds)
        {
            if (ds.Tables.Contains(TBL_DETAILVIEW))
            {
                // �e�[�u�������݂���ꍇ�̓N���A�[�̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ�
                ds.Tables[TBL_DETAILVIEW].Clear();
            }
            else
            {
                // �e�[�u�������݂��Ȃ��ꍇ�̂݃X�L�[�}��ݒ�

                // �X�L�[�}�ݒ�
                ds.Tables.Add(TBL_DETAILVIEW);
                DataTable dt = ds.Tables[TBL_DETAILVIEW];

                // No.
                dt.Columns.Add(COL_NO_TITLE, typeof(string));
                dt.Columns[COL_NO_TITLE].DefaultValue = "";
                // �i��
                dt.Columns.Add(COL_GOODSNO_TITLE, typeof(string));
                dt.Columns[COL_GOODSNO_TITLE].DefaultValue = "";
                // ���[�J�[
                dt.Columns.Add(COL_MAKER_TITLE, typeof(string));
                dt.Columns[COL_MAKER_TITLE].DefaultValue = "";
                // BL�R�[�h
                dt.Columns.Add(COL_BLCODE_TITLE, typeof(string));
                dt.Columns[COL_BLCODE_TITLE].DefaultValue = "";
                // �r�C��
                dt.Columns.Add(COL_GOODSNM_TITLE, typeof(string));
                dt.Columns[COL_GOODSNM_TITLE].DefaultValue = "";
                // QTY
                dt.Columns.Add(COL_PARTSQTY_TITLE, typeof(string));
                dt.Columns[COL_PARTSQTY_TITLE].DefaultValue = "";
                // �W�����i
                dt.Columns.Add(COL_COSTRATE_TITLE, typeof(string));
                dt.Columns[COL_COSTRATE_TITLE].DefaultValue = "";
                // �J�n���Y�N��
                dt.Columns.Add(COL_CREATEYEAR_TITLE, typeof(string));
                dt.Columns[COL_CREATEYEAR_TITLE].DefaultValue = "";
                // ���Y�ԑ�ԍ�
                dt.Columns.Add(COL_CREATECARNO_TITLE, typeof(string));
                dt.Columns[COL_CREATECARNO_TITLE].DefaultValue = "";
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
                // �E�v
                dt.Columns.Add(COL_ADDICARSPEC_TITLE, typeof(string));
                dt.Columns[COL_ADDICARSPEC_TITLE].DefaultValue = "";
                // ���R�������i�ŗL�ԍ�
                dt.Columns.Add(COL_FRESRCHPRTPROPNO_TITLE, typeof(string));
                dt.Columns[COL_FRESRCHPRTPROPNO_TITLE].DefaultValue = "";
                // �^���O���[�v�敪
                dt.Columns.Add(COL_FULLMODELGROUP_TITLE, typeof(string));
                dt.Columns[COL_FULLMODELGROUP_TITLE].DefaultValue = "";
            }
        }
        #endregion
    }
}
