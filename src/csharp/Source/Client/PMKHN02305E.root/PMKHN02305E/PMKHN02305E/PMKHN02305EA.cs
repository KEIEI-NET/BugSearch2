//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �������i���i�������o�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i�������o�N���X</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public class PMKHN02305EA : IExtrProc
    {
        # region �� Constants

        /// <summary> �v���O����ID </summary>
        private const string ct_PGID = "PMKHN02305E";

        # endregion �� Constants


        # region �� Private Members

        /// <summary> ������N���X </summary>
        private SFCMN06002C _printInfo = null;

        /// <summary> ���o�����N���X </summary>
        private GoodsInfoCndtn _extraInfo = null;

        /// <summary> �������i���i�����A�N�Z�X�N���X </summary>
        private GoodsInfoAcs _goodsInfoAcs = null;

        # endregion �� Private Members


        # region �� Constractor

        /// <summary>
        /// �������i���i�������o�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i���i����UI�N���X</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02305EA(object printInfo)
        {
            // ������N���X
            this._printInfo = printInfo as SFCMN06002C;

            // ���o�����N���X
            this._extraInfo = this._printInfo.jyoken as GoodsInfoCndtn;

            // �������i���i�����A�N�Z�X�N���X
            this._goodsInfoAcs = new GoodsInfoAcs();
        }

        # endregion �� Constractor


        # region �� IExtrProc �C���^�[�t�F�[�X
        /// <summary> ������N���X�v���p�e�B </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: ����̃��C���������s���܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA form = new SFCMN00299CA();

            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�f�[�^�𒊏o���ł��B";

            try
            {
                // �_�C�A���O�\��
                form.Show();
                // ���o�������s
                status = this.ExtraProc();
            }
            finally
            {
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        # endregion  �� IExtrProc �C���^�[�t�F�[�X


        # region �� Private Methods
        /// <summary>
        /// ���o�������C������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: ����̃��C���������s���܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private int ExtraProc()
        {
            //string errMsg = "";
            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //try
            //{
            //    // �݌ɒ����m�F�f�[�^�擾
            //    // �X�V�������s������̏ꍇ�A�f�[�^�͊��Ɏ擾�ς݂Ȃ̂ŁA�������s��Ȃ�
            //    if (this._printInfo.rdData == null)
            //    {
            //        DataTable dataTable;
            //        //status = this._goodsInfoAcs.Search(this._extraInfo, out dataTable, out errMsg);
            //        dataTable = new DataTable();
            //        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //        {
            //            // �t�B���^�[������
            //            string strFilter = "";
            //            // �\�[�g��������擾
            //            string strSort = MakeSortingOrderString();

            //            // ���o���ʃe�[�u������w�肳�ꂽ�t�B���^�E�\�[�g�����Ńf�[�^�r���[���쐬
            //            DataView dv = new DataView(dataTable, strFilter, strSort, DataViewRowState.CurrentRows);
            //            if (dv.Count > 0)
            //            {
            //                // �f�[�^���Z�b�g
            //                this._printInfo.rdData = dv;
            //            }
            //            // �Y���f�[�^����
            //            else
            //            {
            //                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            //}
            //finally
            //{
            //    // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
            //        case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
            //                            MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            //                break;
            //            }
            //    }
            //}
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        ///// <summary>
        ///// �\�[�g������쐬����
        ///// </summary>
        ///// <returns>�\�[�g������</returns>
        ///// <remarks>
        ///// <br>Note       : �\�[�g��������쐬���܂��B</br>
        ///// <br>Programmer : ���痈</br>
        ///// <br>Date       : 2009/04/28</br>
        ///// </remarks>
        //public static string MakeSortingOrderString()
        //{
        //    string sortStr = "";

        //    // �ϑ���q�ɃR�[�h
        //    //MakeSortQuery(ref sortStr, PMKHN02306EA.ct_Col_AfWarehouseCode, 0);

        //    // ���[�J�[
        //    //MakeSortQuery(ref sortStr, PMKHN02306EA.ct_Col_MakerCode, 0);

        //    // �i��
        //    //MakeSortQuery(ref sortStr, PMKHN02306EA.ct_Col_GoodsNo, 0);

        //    return sortStr;
        //}

        ///// <summary>
        ///// �\�[�g�p������쐬����
        ///// </summary>
        ///// <param name="colName">�񖼏�</param>
        ///// <param name="ascDescDiv">�����E�~���敪[0:����, 1:�~��]</param>
        ///// <param name="strQuery">�\�[�g�p������</param>
        ///// <remarks>
        ///// <br>Note       : �\�[�g�p�̕�����̍쐬���s���܂��B</br>
        ///// <br>Programmer : ���痈</br>
        ///// <br>Date       : 2009/04/28</br>
        ///// </remarks>
        //private static void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
        //{
        //    if (strQuery == null)
        //    {
        //        strQuery = "";
        //    }

        //    if (strQuery == "")
        //    {
        //        strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
        //    }
        //    else
        //    {
        //        strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
        //    }
        //}

        ///// <summary>
        ///// �G���[���b�Z�[�W�\��
        ///// </summary>
        ///// <param name="iLevel">�G���[���x��</param>
        ///// <param name="iMsg">�G���[���b�Z�[�W</param>
        ///// <param name="iSt">�G���[�X�e�[�^�X</param>
        ///// <param name="iButton">�\���{�^��</param>
        ///// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        ///// <returns>DialogResult</returns>
        ///// <remarks>
        ///// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        ///// <br>Programmer : ���痈</br>
        ///// <br>Date       : 2009/04/28</br>
        ///// </remarks>
        //private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        //{
        //    return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        //}
        # endregion �� Private Methods
    }
}
