//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE�����pI/OWriteDB�����[�g�I�u�W�F�N�g
//                  :   PMUOE01006R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : xuxh
// �C �� ��  2009/12/29  �C�����e :�y�v��No.2�z																																							
//	                                ������Ƀg���^���w�莞�ɂ́A���}�[�N�Q�̓��͕͂s�Ƃ���
//                                 �i�A�g���A�ϰ�2�ɘA�g�ԍ��Ƃ��Ďg�p����ׁj																																							
//	                                �d�����ׁi�����f�[�^�j�̍쐬���s���ʐM�͍s��Ȃ��l�ɂ���																																							
//                       �C�����e :�y�v��No.3�z
//                                  ������̓��͐���i�g���^�͓��͕s�Ƃ���j���s��
//                                  �g���^�d�q�J�^���O�Ŏg�p���鑗�M�E��M�f�[�^�̕ۑ��ꏊ��ݒ肷��
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �k���r
// �C �� ��  2010/03/08  �C�����e : PM1006 �t�n�d�����ԍ��E�t�n�d�����s�ԍ��̐ݒ�̑Ή�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : gaoyh
// �� �� ��  2010/04/26  �C�����e : PM1007C �O�HUOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ����
// �C �� ��  2010/05/07  �C�����e : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : liyp
// �C �� ��  2011/01/06  �C�����e : ��IOWriteControlDB���̋@�\�ǉ�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : �� ��
// �C �� ��  2011/01/30  �C�����e : UOE���������� 
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �C �� ��  2011/03/01  �C�����e : ���YUOE������B�Ή�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �{�z��
// �C �� ��  2011/05/10  �C�����e : ��IOWriteControlDB���̋@�\�ǉ�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/10/28  �C�����e :��Q�� #26283�Ə�Q�� #26284�̑Ή�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : LIUSY
// �C �� ��  2011/11/26  �C�����e : PM1113 ��NET-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/06  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� 
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : wangyl
// �C �� ��  2013/02/26  �C�����e : 10900690-00 2013/03/13�z�M���ً̋}�Ή�
//                                  Redmine#34578�̑Ή� �����ꗗ�\����݌Ɉꊇ������A���M������ʂŕi�Ԃ��~���ɂȂ��Ă��� 
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : pengjie
// �� �� ��  2013/03/14  �C�����e : redmine#34986�̑Ή� �����ꗗ�\��UOE���������̃T�[�o�[�ŁA���엚�����O�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangl2
// �C �� ��  2013/04/03  �C�����e : Redmine#35210�̑Ή� �uUOE����͔����v�ŘA�Ԃ��S�� "1" �ŃG���[�ɂȂ�i��1802�j 
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangll
// �C �� ��  2013/05/10  �C�����e : Redmine#34986�̑Ή� ���엚�����O���e�C��
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wuyk
// �C �� ��  2013/08/19  �C�����e : Redmine#39934�̑Ή��EUOE�^�d����M���s�����ۂ̃I�����C���ԍ��s���̌��ɂ��ďC��
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 杍^
// �C �� ��  2013/11/18  �C�����e : Redmine#41206�̑Ή��E�񓚔ԍ����̔Ԃ̏C��
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  11000192-00 �쐬�S�� : ���N�n��
// �C �� ��  2014/11/19  �C�����e : �d�|�ꗗ�F��2565 Redmine#43752�̑Ή��E����UOEWEB�̉����d����M�����̏ꍇ�A�������ᔽ�̒����̑Ή�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�  11900025-00  �쐬�S�� : �c������
// �� �� ��  2023/01/20   �C�����e : PMKOBETSU-4202 �����d����M������Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12100013-00  �쐬�S�� : ���O
// �� �� ��  2025/01/10   �C�����e : PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE�����pI/OWriteDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�����pI/OWrite�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� e-Parts�Ή�</br>
    /// <br>Date       : 2009.05.25</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/29 xuxh</br>
    /// <br>             �E�y�v��No.2�z�Ɓy�v��No.3�z�̏C��</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/03/08 �k���r�@PM1006</br>
    /// <br>             �t�n�d�����ԍ��E�t�n�d�����s�ԍ��̐ݒ�̑Ή�</br>
    /// <br>UpdateNote : 2010/05/07 ����@PM1008</br>
    /// <br>             ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpdateNote  : 2011/03/01 liyp </br>
    /// <br>             ���YUOE������B�Ή�</br>
    /// <br>UpdateNote  : 2011/05/10 �{�z��</br>
    /// <br>             ��IOWriteControlDB���̋@�\�ǉ�</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
    /// <br>              RRedmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
    /// <br>Update Note : 2013/04/03 wangl2</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              Redmine#35210�̑Ή� �uUOE����͔����v�ŘA�Ԃ��S�� "1" �ŃG���[�ɂȂ�i��1802�j  </br>
    /// <br>Update Note : 2013/08/19 wuyk</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              Redmine#39934�̑Ή��EUOE�^�d����M���s�����ۂ̃I�����C���ԍ��s���̌��ɂ��ďC��  </br>
    /// <br>Update Note : 2014/11/19 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 11000192-00</br>
    /// <br>              �d�|�ꗗ�F��2565 Redmine#43752�̑Ή��E����UOEWEB�̉����d����M�����̏ꍇ�A�������ᔽ�̒����̑Ή�  </br>
    /// </remarks>
    [Serializable]
    public class IOWriteUOEOdrDtlDB : RemoteWithAppLockDB, IIOWriteUOEOdrDtlDB
    {
        private Hashtable _ComAsmIdToMaxDtlCntTable = null;

        # region [�g�p�����[�g]

        # region [�̔ԊǗ��N���X �v���p�e�B]
        private NumberingManager _numMng = null;

        private NumberingManager NumMng
        {
            get
            {
                if (this._numMng == null)
                {
                    this._numMng = new NumberingManager();
                }

                return this._numMng;
            }
        }
        # endregion

        # region [UOE�����f�[�^�����[�g �v���p�e�B]
        private UOEOrderDtlDB _UOEOdrDtlDb = null;

        private UOEOrderDtlDB UOEOdrDtlDb
        {
            get
            {
                if (this._UOEOdrDtlDb == null)
                {
                    this._UOEOdrDtlDb = new UOEOrderDtlDB();
                }

                return this._UOEOdrDtlDb;
            }
        }
        # endregion

        # region [�d��I/O�����[�g �v���p�e�B]
        private IOWriteMASIRDB _IOWriteMaSirDb = null;

        private IOWriteMASIRDB IOWriteMaSirDb
        {
            get
            {
                if (this._IOWriteMaSirDb == null)
                {
                    this._IOWriteMaSirDb = new IOWriteMASIRDB();
                }

                return this._IOWriteMaSirDb;
            }
        }
        # endregion

        # region [�d�������[�g �v���p�e�B]
        private StockSlipDB _StockSlipDb = null;

        private StockSlipDB StockSlipDb
        {
            get
            {
                if (this._StockSlipDb == null)
                {
                    this._StockSlipDb = new StockSlipDB();
                }

                return this._StockSlipDb;
            }
        }
        # endregion


        # endregion

        /// <summary>
        /// UOE�����pI/OWriteDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>UpdateNote  : 2010/03/08 �k���r �t�n�d�����ԍ��E�t�n�d�����s�ԍ��̐ݒ�̑Ή�</br>
        /// <br>UpdateNote  : 2010/05/07 ���� PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote :2011/01/06 liyp �t�n�d�����s�ԍ��̐ݒ�́A�P�̂t�n�d�����ԍ��ɑ΂��āA�ő�S���ׂ܂łƂ���</br>
        /// <br>UpdateNote  : 2011/01/30 �� �� �t�n�d����������</br>
        /// <br>UpdateNote  : 2011/03/01 liyp ���YUOE������B�Ή�</br>
        /// <br>UpdateNote  : 2011/05/10 �{�z�� �}�c�_WEB�Ή�</br>
        /// </remarks>
        public IOWriteUOEOdrDtlDB()
            : base("PMUOE01008D", "Broadleaf.Application.Remoting.ParamData.IOWriteUOEOdrDtlWork", "IOWRITEUOEODRDTLRF")
        {
            _ComAsmIdToMaxDtlCntTable = new Hashtable();

            // �ʐM�A�Z���u��ID �� ���[�J�[���̑��M�ő喾�א����֘A�t����
            _ComAsmIdToMaxDtlCntTable.Add("0102", 3);   //�g���^
            _ComAsmIdToMaxDtlCntTable.Add("0202", 4);   //���Y
            _ComAsmIdToMaxDtlCntTable.Add("0301", 3);   //�O�H
            // ---ADD 2010/04/26 gaoyh ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0302", 5);�@//�O�Hweb-UOE
            // ---ADD 2010/04/26 gaoyh ----------------------------------------<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0303", 5);�@//�O�Hweb-UOE ADD 2011/01/06
            _ComAsmIdToMaxDtlCntTable.Add("0401", 6);   //���}�c�_
            _ComAsmIdToMaxDtlCntTable.Add("0402", 6);   //�V�}�c�_
            _ComAsmIdToMaxDtlCntTable.Add("0501", 10);  //�z���_
            _ComAsmIdToMaxDtlCntTable.Add("0801", 1);   //�X�o��
            _ComAsmIdToMaxDtlCntTable.Add("1001", 5);   //�D�ǃ��[�J�[
            // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0502", 6);   //e-Parts
            // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0103", 3);�@//�g���^�d�q�J�^���O // ADD 2009/12/29 xuxh
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0203", 4);�@//���Yweb-UOE
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0204", 4); //���Yweb-UOE ADD 2011/01/06
            // ---ADD 2010/05/07 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("1004", 5);�@//����web-UOE
            // ---ADD 2010/05/07 ----------------------------------------<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0104", 3);�@//�g���^�������� // ADD 2011/01/30 �� ��
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0205", 4); // ���YWEBUOE
            _ComAsmIdToMaxDtlCntTable.Add("0206", 4); // ���YWEBUOE
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
            // ---ADD 2011/05/10 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0403", 5);   //�}�c�_WEB
            // ---ADD 2011/05/10 ----------------------------------------<<<<

            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("1003", 5);�@//��NET-WEB
            // ---ADD 2011/10/26 ----------------------------------------<<<<

#if DEBUG
            Console.WriteLine("UOE�����pI/OWriteDB�����[�g�I�u�W�F�N�g");
#endif
        }

        # region [Write]
        /// <summary>
        /// UOE�����pI/OWrite����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�ǉ��E�X�V����UOE�����pI/OWrite�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����pI/OWrite����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int Write(ref object uoeOdrDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeOdrDtlList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE�����pI/OWrite����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�ǉ��E�X�V����UOE�����pI/OWrite�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����pI/OWrite����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int Write(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �V�X�e�����b�N 
            Dictionary<string, string> dic = new Dictionary<string, string>();

            ArrayList infoList = new ArrayList();
            UOEOrderDtlWork stockdtlwork = uoeOdrDtlList[0] as UOEOrderDtlWork;

            foreach (UOEOrderDtlWork st in uoeOdrDtlList)
            {
                if (dic.ContainsKey(st.SectionCode) == false)
                {
                    dic.Add(st.SectionCode, st.SectionCode);
                }
            }

            ShareCheckInfo info = new ShareCheckInfo();
            foreach (string secCd in dic.Keys)
            {
                info.Keys.Add(stockdtlwork.EnterpriseCode, ShareCheckType.Section, secCd, "");
            }
            status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

            if (status != 0) return status;

            status = this.WriteInitial(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.WriteProc(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);
            }

            // �V�X�e�����b�N����
            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

            return status;
        }

        /// <summary>
        /// UOE�����pI/OWrite����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�ǉ��E�X�V����UOE�����pI/OWrite�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����pI/OWrite����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>UpdateNote  : 2010/03/08 �k���r �t�n�d�����ԍ��E�t�n�d�����s�ԍ��̐ݒ�̑Ή�</br>
        /// <br>UpdateNote  : 2011/01/30 �� �� �t�n�d����������</br>
        /// <br>UpdateNote  : 2011/03/01 liyp ���YUOE������B�Ή�</br>
        /// <br>UpdateNote  : 2011/05/10 �{�z�� ��IOWriteControlDB���̋@�\�ǉ�</br>
        /// <br>UpdateNote  : 2011/11/18 杍^ �񓚔ԍ����̔ԕs��</br>
        public int WriteInitial(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                if (ListUtils.IsNotEmpty(uoeOdrDtlList) && sqlConnection != null && sqlTransaction != null)
                {
                    UOEOrderDtlWork UOEOdrDtl = uoeOdrDtlList[0] as UOEOrderDtlWork;

                    if (UOEOdrDtl != null)
                    {
                        // �ԍ��̔Ԏ��ɐF�X�ƕ��ѕς���̂ŁA�R�s�[������ď������s��
                        // ���X�g�Ɋi�[����Ă���UOE�����f�[�^�͓���C���X�^���X�ׁ̈A�̔Ԍ��ʂȂǂ͐������i�[�����
                        ArrayList tmpOdrDtlList = new ArrayList();
                        tmpOdrDtlList.AddRange(uoeOdrDtlList);

                        # region [�I�����C���ԍ��̔ԏ���]
                        // �I�����C���ԍ��ƃI�����C���s�ԍ��̍̔ԏ��� (�O��Ƃ��Ė��̔ԁE�̔ԍς̃f�[�^�͍��݂��Ȃ�)
                        if (UOEOdrDtl.OnlineNo == 0)
                        {
                            status = this.NumberingOfOnlineNo(ref tmpOdrDtlList, ref sqlConnection, ref sqlTransaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                errmsg += ": �I�����C���ԍ��̍̔ԂɎ��s���܂���.";
                                base.WriteErrorLog(errmsg, status);
                                return status;
                            }

                            // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (UOEOdrDtl.SystemDivCd != 0)
                            //if (UOEOdrDtl.SystemDivCd != 0 || UOEOdrDtl.CommAssemblyId == "0502") // DEL 2009/12/29 xuxh
                            if (UOEOdrDtl.SystemDivCd != 0 || UOEOdrDtl.CommAssemblyId == "0502"
                                // ---UPD 2010/03/08 ---------------------------------------->>>>>
                                //|| UOEOdrDtl.CommAssemblyId == "0103") // ADD 2009/12/29 xuxh
                                || UOEOdrDtl.CommAssemblyId == "0103" || UOEOdrDtl.CommAssemblyId == "0203"
                                || UOEOdrDtl.CommAssemblyId == "0104" // �g���^�������� // ADD 2011/01/30 �� ��
                                || UOEOdrDtl.CommAssemblyId == "0204" // ADD 2011/01/06 liyp
                                || UOEOdrDtl.CommAssemblyId == "0302" // ADD 2010/04/26 gaoyh
                                || UOEOdrDtl.CommAssemblyId == "0205" // ADD 2011/03/01
                                || UOEOdrDtl.CommAssemblyId == "0206" // ADD 2011/03/01
                                || UOEOdrDtl.CommAssemblyId == "0303" // ADD 2011/01/06	liyp
                                || UOEOdrDtl.CommAssemblyId == "0403")  // ADD 2011/05/10
                            // ---UPD 2010/03/08 ----------------------------------------<<<<<
                            // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                // ����͔����ȊO�̏ꍇ�A�I�����C���ԍ����̔Ԃ����ꍇ�͂����ŏ����𒆒f����
                                // ������͔����̏ꍇ�͈�������UOE�����ԍ��̍̔ԏ������s��
                                return status;
                            }
                        }
                        # endregion

                        # region [UOE�����ԍ��̔ԏ���]
                        // UOE�����ԍ���UOE�����s�ԍ��̍̔ԏ��� (�O��Ƃ��Ė��̔ԁE�̔ԍς̃f�[�^�����݂��Ȃ�)
                        //if (UOEOdrDtl.UOESalesOrderNo == 0)   // DEL 杍^ 2013/11/18
                        if (UOEOdrDtl.UOEKind == 0 && UOEOdrDtl.UOESalesOrderNo == 0) // ADD 杍^ 2013/11/18
                        {
                            status = this.NumberingOfUOESalesOrderNo(ref tmpOdrDtlList, ref sqlConnection, ref sqlTransaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                errmsg += ": UOE�����ԍ��̍̔ԂɎ��s���܂���.";
                                base.WriteErrorLog(errmsg, status);
                                return status;
                            }
                        }
                        # endregion

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// UOE�����pI/OWrite����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�ǉ��E�X�V����UOE�����pI/OWrite�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����pI/OWrite����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int WriteProc(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                if (ListUtils.IsNotEmpty(uoeOdrDtlList) && sqlConnection != null && sqlTransaction != null)
                {
                    status = this.UOEOdrDtlDb.Write(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        # endregion

        #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802�̑Ή�
        #region  [WriteUOESalesOrderNo]
        /// <summary>
        /// UOE�����f�[�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE�����f�[�^���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����f�[�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013.04.03</br>
        public int WriteUOESalesOrderNo(ref ArrayList uoeOdrDtlList)
        {
            SqlConnection sqlConnection = this.CreateConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            // UOE�����ԍ��ݒ菈��
            int status = this.NumberingOfUOESalesOrderNoForStockEstmt(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);
            return status;
        }
        #endregion
        #endregion

        # region [Search]

        /// <summary>
        /// ����̃L�[��񂪍��v����UOE�����f�[�^�𕡐��������܂��B
        /// </summary>
        /// <param name="param">�����L�[���܂�UOE�����f�[�^�̃��X�g</param>
        /// <param name="result">��������</param>
        /// <param name="sqlConnection">DB�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int Search(ArrayList param, out ArrayList result, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList uoeOdrDtlList = new ArrayList();

            result = new ArrayList();

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (ListUtils.IsEmpty(param))
            {
                errmsg += ": UOE�����f�[�^�Ǎ��p�����[�^�����ݒ�ł�.";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(errmsg, status);
            }
            else
            {
                foreach (object item in param)
                {
                    UOEOrderDtlWork uoeOdrDtl = item as UOEOrderDtlWork;

                    if (uoeOdrDtl != null)
                    {
                        uoeOdrDtlList.Clear();
                        status = this.UOEOdrDtlDb.Search(ref uoeOdrDtlList, uoeOdrDtl, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            result.AddRange(uoeOdrDtlList);
                        }
                        else
                        {
                            result.Clear();
                            break;
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// UOE�����f�[�^�̓��荀�ڂ��L�[�ɁAUOE�����f�[�^�Ƃ���ɕR�t���d���f�[�^�{�d�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">���������ƂȂ�UOE�����f�[�^</param>
        /// <param name="slipGroupList">��������(UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������Ɉ�v����UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.12.10</br>
        // <br>Update Note : 2014/11/19 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 11000192-00</br>
        /// <br>             �d�|�ꗗ�F��2565 Redmine#43752�̑Ή��E����UOEWEB�̉����d����M�����̏ꍇ�A�������ᔽ�̒����̑Ή�  </br>
        public int Search(ref object uoeOrderDtlList, ref object slipGroupList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�`�F�b�N]

                if (ListUtils.IsEmpty(uoeOrderDtlList as ArrayList))
                {
                    errmsg += ": UOE�����f�[�^�Ǎ��p�����[�^�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (slipGroupList != null && !(slipGroupList is CustomSerializeArrayList))
                {
                    errmsg += ": �������ʊi�[���X�g�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����̎擾�Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlTransaction sqlTransaction = null;

                # endregion

                # region [UOE�����f�[�^�Ǎ�]

                ArrayList uoeReadParam = uoeOrderDtlList as ArrayList;
                ArrayList uoeReadResult = new ArrayList();
                ArrayList uoeOdrDtlList = new ArrayList();
                CustomSerializeArrayList stockList = new CustomSerializeArrayList();// ADD 2014/11/19 ���N�n�� �d�|�ꗗ�F��2565

                foreach (object item in uoeReadParam)
                {
                    UOEOrderDtlWork uoeOdrDtl = item as UOEOrderDtlWork;

                    if (uoeOdrDtl != null)
                    {
                        uoeReadResult.Clear();

                        status = this.UOEOdrDtlDb.Search(ref uoeReadResult, uoeOdrDtl, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            uoeOdrDtlList.AddRange(uoeReadResult);
                        }
                        else
                        {
                            errmsg += ": UOE�����f�[�^�̓Ǎ��Ɏ��s���܂���.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                # region [�d���f�[�^�Ǎ�]

                ArrayList slipGrpList = slipGroupList as ArrayList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    slipGrpList.Add(uoeOdrDtlList);

                    Dictionary<StockSlipPrimary, StockSlipReadWork> stcReadDic = new Dictionary<StockSlipPrimary, StockSlipReadWork>();

                    # region [UOE�������׃f�[�^���A�d�����Ȃ��d���f�[�^�̃L�[�l�����W����]
                    foreach (UOEOrderDtlWork odrDtlWrk in uoeOdrDtlList)
                    {
                        StockSlipPrimary key = new StockSlipPrimary();
                        key.EnterpriseCode = odrDtlWrk.EnterpriseCode;  // ��ƃR�[�h
                        key.SupplierFormal = odrDtlWrk.SupplierFormal;  // �d���`��
                        key.SupplierSlipNo = odrDtlWrk.SupplierSlipNo;  // �d���`�[�ԍ�

                        if (!stcReadDic.ContainsKey(key))
                        {
                            StockSlipReadWork value = new StockSlipReadWork();
                            value.EnterpriseCode = key.EnterpriseCode;
                            value.SupplierFormal = key.SupplierFormal;
                            value.SupplierSlipNo = key.SupplierSlipNo;
                            stcReadDic.Add(key, value);
                        }
                    }
                    # endregion

                    CustomSerializeArrayList stcReadParam = new CustomSerializeArrayList();
                    CustomSerializeArrayList stcReadResult = new CustomSerializeArrayList();
                    object freeParam = null;

                    foreach (StockSlipReadWork readWrk in stcReadDic.Values)
                    {
                        stcReadParam.Clear();
                        stcReadParam.Add(readWrk);
                        stcReadResult.Clear();// ADD 2014/11/19 ���N�n�� �d�|�ꗗ�F��2565 
                        status = this.StockSlipDb.Read(this.GetType().Name, ref stcReadParam, ref stcReadResult, 0, "", ref freeParam, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            stockList.AddRange(stcReadResult);// ADD 2014/11/19 ���N�n�� �d�|�ꗗ�F��2565
                            //slipGrpList.Add(stcReadResult);// DEL 2014/11/19 ���N�n�� �d�|�ꗗ�F��2565
                        }
                        else
                        {
                            errmsg += ": �d���f�[�^�̓Ǎ��Ɏ��s���܂���.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    slipGrpList.Clear();
                }
                // --- ADD 2014/11/19 ���N�n�� �d�|�ꗗ�F��2565 ---------->>>>>
                else
                {
                    slipGrpList.Add(stockList);
                }
                // --- ADD 2014/11/19 ���N�n�� �d�|�ꗗ�F��2565 ----------<<<<<
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------>>>>>
        /// <summary>
        /// UOE�����f�[�^�̓��荀�ڂ��L�[�ɁAUOE�����f�[�^�Ƃ���ɕR�t���d���f�[�^�{�d�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">���������ƂȂ�UOE�����f�[�^</param>
        /// <param name="slipGroupList">��������(UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^)</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4202 �����d����M������Q�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/01/20</br>
        /// <br>Update Note: PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2025/01/10</br>
        public int Search2(ref object uoeOrderDtlList, ref object slipGroupList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�`�F�b�N]

                if (ListUtils.IsEmpty(uoeOrderDtlList as ArrayList))
                {
                    errmsg += ": UOE�����f�[�^�Ǎ��p�����[�^�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (slipGroupList != null && !(slipGroupList is CustomSerializeArrayList))
                {
                    errmsg += ": �������ʊi�[���X�g�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����̎擾�Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlTransaction sqlTransaction = null;

                # endregion

                # region [UOE�����f�[�^�Ǎ�]

                ArrayList uoeReadParam = uoeOrderDtlList as ArrayList;
                ArrayList uoeReadResult = new ArrayList();
                ArrayList uoeOdrDtlList = new ArrayList();
                CustomSerializeArrayList stockList = new CustomSerializeArrayList();

                foreach (object item in uoeReadParam)
                {
                    UOEOrderDtlWork uoeOdrDtl = item as UOEOrderDtlWork;

                    if (uoeOdrDtl != null)
                    {
                        uoeReadResult.Clear();

                        status = this.UOEOdrDtlDb.Search(ref uoeReadResult, uoeOdrDtl, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            uoeOdrDtlList.AddRange(uoeReadResult);
                        }
                        else
                        {
                        	//PMUOE01051R.Serch�̌������ʂ�4�̏ꍇ�́A�G���[�Ƃ����ɂ���ȍ~�̌������s��
                        	if(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        	{
                        		continue;
                        	}
                            errmsg += ": UOE�����f�[�^�̓Ǎ��Ɏ��s���܂���.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                # region [�d���f�[�^�Ǎ�]

                ArrayList slipGrpList = slipGroupList as ArrayList;

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)     // DEL 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�
                if (uoeOdrDtlList.Count > 0)    // ADD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή�
                {
                    slipGrpList.Add(uoeOdrDtlList);

                    Dictionary<StockSlipPrimary, StockSlipReadWork> stcReadDic = new Dictionary<StockSlipPrimary, StockSlipReadWork>();

                    # region [UOE�������׃f�[�^���A�d�����Ȃ��d���f�[�^�̃L�[�l�����W����]
                    foreach (UOEOrderDtlWork odrDtlWrk in uoeOdrDtlList)
                    {
                        StockSlipPrimary key = new StockSlipPrimary();
                        key.EnterpriseCode = odrDtlWrk.EnterpriseCode;  // ��ƃR�[�h
                        key.SupplierFormal = odrDtlWrk.SupplierFormal;  // �d���`��
                        key.SupplierSlipNo = odrDtlWrk.SupplierSlipNo;  // �d���`�[�ԍ�

                        if (!stcReadDic.ContainsKey(key))
                        {
                            StockSlipReadWork value = new StockSlipReadWork();
                            value.EnterpriseCode = key.EnterpriseCode;
                            value.SupplierFormal = key.SupplierFormal;
                            value.SupplierSlipNo = key.SupplierSlipNo;
                            stcReadDic.Add(key, value);
                        }
                    }
                    # endregion

                    CustomSerializeArrayList stcReadParam = new CustomSerializeArrayList();
                    CustomSerializeArrayList stcReadResult = new CustomSerializeArrayList();
                    object freeParam = null;

                    foreach (StockSlipReadWork readWrk in stcReadDic.Values)
                    {
                        stcReadParam.Clear();
                        stcReadParam.Add(readWrk);
                        stcReadResult.Clear();
                        status = this.StockSlipDb.Read(this.GetType().Name, ref stcReadParam, ref stcReadResult, 0, "", ref freeParam, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            stockList.AddRange(stcReadResult);
                        }
                        else
                        {
                            // --- ADD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή� ----->>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                continue;
                            }
                            // --- ADD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή� -----<<<<<
                            errmsg += ": �d���f�[�^�̓Ǎ��Ɏ��s���܂���.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                // --- UPD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή� ----->>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    slipGrpList.Clear();
                //}
                //else
                //{
                //    slipGrpList.Add(stockList);
                //}
                if (stockList.Count > 0)
                {
                    slipGrpList.Add(stockList);
                }
                // --- UPD 2025/01/10 ���O PMKOBETSU-4369 �R�`���i��_�����d����M�����s��Ή� -----<<<<<
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------<<<<<

        // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// UOE�����f�[�^�̓��荀�ڂ��L�[�ɁAUOE�����f�[�^�Ƃ���ɕR�t���d���f�[�^�{�d�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="paraList">��������</param>
        /// <param name="uoeOrderDtlList">��������(UOE�����f�[�^)</param>
        /// <param name="stockDtlList">��������(�d�����׃f�[�^)</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������Ɉ�v����UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22008�@����</br>
        /// <br>Date       : 2009.05.25</br>
        public int UoeOdrDtlGodsReadAll(object paraList, ref object uoeOrderDtlList, ref object stockDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�`�F�b�N]

                if (ListUtils.IsEmpty(paraList as ArrayList))
                {
                    errmsg += ": UOE�����f�[�^�Ǎ��p�����[�^�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (uoeOrderDtlList == null || stockDtlList == null)
                {
                    errmsg += ": �������ʊi�[���X�g�����ݒ�ł�.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ����̎擾�Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlTransaction sqlTransaction = null;

                # endregion

                # region [UOE�����f�[�^�Ǎ�]

                ArrayList uoeReadParam = paraList as ArrayList;
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeReadParam != null)
                {
                    status = this.UOEOdrDtlDb.UoeOdrDtlGodsReadAll(ref uoeOrderDtlArray, uoeReadParam, ref sqlConnection, ref sqlTransaction);
                }

                # endregion

                # region [�d���f�[�^�Ǎ�]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList prmDtlList = new ArrayList();
                    ArrayList retDtlList = null;

                    foreach (UOEOrderDtlWork uoeOdrDtl in uoeOrderDtlArray)
                    {
                        // ���ʏ�͋N���蓾�Ȃ����A�s���f�[�^�̓X�L�b�v����
                        if (string.IsNullOrEmpty(uoeOdrDtl.EnterpriseCode) ||
                            uoeOdrDtl.StockSlipDtlNum == 0)
                        {
                            continue;
                        }

                        StockDetailWork stkDtl = new StockDetailWork();
                        stkDtl.EnterpriseCode = uoeOdrDtl.EnterpriseCode;    // ��ƃR�[�h
                        stkDtl.SupplierFormal = uoeOdrDtl.SupplierFormal;    // �d���`��
                        stkDtl.StockSlipDtlNum = uoeOdrDtl.StockSlipDtlNum;  // �d�����גʔ�
                        prmDtlList.Add(stkDtl);
                    }

                    status = this.StockSlipDb.ReadStockDetailWork(out retDtlList, prmDtlList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ((ArrayList)stockDtlList).AddRange(retDtlList);

                        # region [UOE�����f�[�^�Ǝd�����׃f�[�^�̓ˍ�]
                        List<UOEOrderDtlWork> uoeOdrDtlListSrc = new List<UOEOrderDtlWork>((UOEOrderDtlWork[])uoeOrderDtlArray.ToArray(typeof(UOEOrderDtlWork)));
                        List<UOEOrderDtlWork> uoeOdrDtlListDst = new List<UOEOrderDtlWork>();

                        foreach (StockDetailWork stcDtlItem in retDtlList)
                        {
                            UOEOrderDtlWork match = uoeOdrDtlListSrc.Find(delegate(UOEOrderDtlWork uoeDtlItem)
                            {
                                return (uoeDtlItem.EnterpriseCode == stcDtlItem.EnterpriseCode &&
                                        uoeDtlItem.SupplierFormal == stcDtlItem.SupplierFormal &&
                                        uoeDtlItem.StockSlipDtlNum == stcDtlItem.StockSlipDtlNum);
                            });

                            if (match != null)
                            {
                                uoeOdrDtlListDst.Add(match);
                            }
                        }

                        uoeOrderDtlArray.Clear();
                        uoeOrderDtlArray.AddRange(uoeOdrDtlListDst);

                        # endregion
                    }
                }

                # endregion
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// UOE�����pI/OWrite���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSendProcCndtn">��������</param>
        /// <param name="uoeOrderDtlList">��������(UOE�����f�[�^)</param>
        /// <param name="stockDtlList">��������(�d�����׃f�[�^)</param>        
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Note       : �����ꗗ�\��UOE���������̃T�[�o�[�ŁA���엚�����O�ǉ�</br>
        /// <br>Programmer : pengjie</br>
        /// <br>Date       : 2012.03.14</br>
        public int Search(object uoeSendProcCndtn, ref object uoeOrderDtlList, ref object stockDtlList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB(); // ADD pengjie 2013/03/14 REDMINE#34986
            String recordMsg = ""; // ADD zhangll 2013/05/10 REDMINE#34986
            try
            {
                # region [�p�����[�^�[�`�F�b�N]
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeOrderDtlArray == null)
                {
                    errmsg += ": �������ʂ��i�[���郊�X�g���ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                UOESendProcCndtnWork uoeSndPrcCnd = uoeSendProcCndtn as UOESendProcCndtnWork;

                if (uoeSndPrcCnd == null)
                {
                    errmsg += ": �����������ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                # endregion

                //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                // DB���샍�O
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE�����f�[�^", "���o�J�n", "PMUOE01006R", 0); 
                //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                // UOE�����f�[�^�Ǎ�
                status = this.UOEOdrDtlDb.SearchUoeSend(ref uoeOrderDtlArray, uoeSndPrcCnd, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                //-----DEL zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                ////-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                //// DB���샍�O
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(uoeOrderDtlArray))
                //{
                //    String recordMsg = "���o�I��" + "�A" + "ST=" + status + "�A" + "���o����=" + uoeOrderDtlArray.Count;
                //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE�����f�[�^", recordMsg, "PMUOE01006R", 0);
                //}
                //else
                //{
                //    String recordMsg = "���o�I��" + "�A" + "ST=" + status;
                //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE�����f�[�^", recordMsg, "PMUOE01006R", 0);
                //}
                ////-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                //-----DEL zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                //-----ADD zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                recordMsg = "���o�I��" + "�A" + "ST=" + status;
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE�����f�[�^", recordMsg, "PMUOE01006R", 0);
                //-----ADD zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                # region [�����f�[�^�̓Ǎ�]

                // UOE�����f�[�^�ɕR�t���d���f�[�^���擾����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(uoeOrderDtlArray))
                {
                    ArrayList prmDtlList = new ArrayList();
                    ArrayList retDtlList = null;

                    foreach (UOEOrderDtlWork uoeOdrDtl in uoeOrderDtlArray)
                    {
                        // ���ʏ�͋N���蓾�Ȃ����A�s���f�[�^�̓X�L�b�v����
                        if (string.IsNullOrEmpty(uoeOdrDtl.EnterpriseCode) ||
                            uoeOdrDtl.StockSlipDtlNum == 0)
                        {
                            continue;
                        }

                        StockDetailWork stkDtl = new StockDetailWork();
                        stkDtl.EnterpriseCode = uoeOdrDtl.EnterpriseCode;    // ��ƃR�[�h
                        stkDtl.SupplierFormal = uoeOdrDtl.SupplierFormal;    // �d���`��
                        stkDtl.StockSlipDtlNum = uoeOdrDtl.StockSlipDtlNum;  // �d�����גʔ�
                        prmDtlList.Add(stkDtl);
                    }

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // DB���샍�O
                    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "�d�����׃f�[�^", "���o�J�n", "PMUOE01006R", 0);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    status = this.StockSlipDb.ReadStockDetailWork(out retDtlList, prmDtlList, ref sqlConnection, ref sqlTransaction);

                    //-----DEL zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                    ////-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    //// DB���샍�O
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(retDtlList))
                    //{
                    //    String recordMsg = "���o�I��" + "�A" + "ST=" + status + "�A" + "���o����=" + retDtlList.Count;
                    //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "�d�����׃f�[�^", recordMsg, "PMUOE01006R", 0);
                    //}
                    //else
                    //{
                    //    String recordMsg = "���o�I��" + "�A" + "ST=" + status;
                    //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "�d�����׃f�[�^", recordMsg, "PMUOE01006R", 0);

                    //}
                    ////-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                    //-----DEL zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                    //-----ADD zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                    recordMsg = "���o�I��" + "�A" + "ST=" + status;
                    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "�d�����׃f�[�^", recordMsg, "PMUOE01006R", 0);
                    //-----ADD zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ((ArrayList)stockDtlList).AddRange(retDtlList);

                        # region [UOE�����f�[�^�Ǝd�����׃f�[�^�̓ˍ�]
                        List<UOEOrderDtlWork> uoeOdrDtlListSrc = new List<UOEOrderDtlWork>((UOEOrderDtlWork[])uoeOrderDtlArray.ToArray(typeof(UOEOrderDtlWork)));
                        List<UOEOrderDtlWork> uoeOdrDtlListDst = new List<UOEOrderDtlWork>();

                        foreach (StockDetailWork stcDtlItem in retDtlList)
                        {
                            UOEOrderDtlWork match = uoeOdrDtlListSrc.Find(delegate(UOEOrderDtlWork uoeDtlItem)
                            {
                                return (uoeDtlItem.EnterpriseCode == stcDtlItem.EnterpriseCode &&
                                        uoeDtlItem.SupplierFormal == stcDtlItem.SupplierFormal &&
                                        uoeDtlItem.StockSlipDtlNum == stcDtlItem.StockSlipDtlNum);
                            });

                            if (match != null)
                            {
                                uoeOdrDtlListDst.Add(match);
                            }
                        }

                        uoeOrderDtlArray.Clear();
                        uoeOrderDtlArray.AddRange(uoeOdrDtlListDst);

                        # endregion
                    }
                }

                # endregion
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^��_���폜���܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�_���폜����UOE�����f�[�^���܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�ƁA����ɕR�t���d�����׃f�[�^��_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int LogicalDelete(ref object uoeOdrDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                ArrayList uoeOdrDtlArray = uoeOdrDtlList as ArrayList;
                status = this.LogicalDelete(ref uoeOdrDtlArray, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE�����pI/OWrite���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeOdrDtlList">�_���폜�𑀍삷��UOE�����pI/OWrite�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlEncryptInfo">�Í������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ioWriteUOEOdrDtlWork �Ɋi�[����Ă���UOE�����pI/OWrite���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int LogicalDelete(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
            ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�[�`�F�b�N]

                if (ListUtils.IsEmpty(uoeOdrDtlList))
                {
                    errmsg += ": �폜�Ώۂ�UOE�����f�[�^���ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (ListUtils.Find(uoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) == null)
                {
                    errmsg += ": �폜�Ώۂ�UOE�����f�[�^���ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ڑ���񂪐ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (sqlTransaction == null)
                {
                    errmsg += ": �g�����U�N�V������񂪐ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion
                // UOE�󒍃f�[�^�̘_���폜
                status = this.UOEOdrDtlDb.ReceiptLogicalDelete(ref uoeOdrDtlList, 0, ref sqlConnection, ref sqlTransaction);  // ADD BY ������ on 2011/10/28 for #26283�Ə�Q�� #26284�̑Ή�
                // UOE�����f�[�^�̘_���폜
                status = this.UOEOdrDtlDb.LogicalDelete(ref uoeOdrDtlList, 0, ref sqlConnection, ref sqlTransaction);

                // �d������(��������)�f�[�^�̘_���폜
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList stockDtlList = new ArrayList();

                    foreach (UOEOrderDtlWork UOEOrderDtl in uoeOdrDtlList)
                    {
                        StockDetailWork StockDetail = new StockDetailWork();
                        StockDetail.EnterpriseCode = UOEOrderDtl.EnterpriseCode;
                        StockDetail.SupplierFormal = UOEOrderDtl.SupplierFormal;
                        StockDetail.StockSlipDtlNum = UOEOrderDtl.StockSlipDtlNum;
                        stockDtlList.Add(StockDetail);
                    }

                    string retMsg = string.Empty;
                    string retInfo = string.Empty;
                    status = this.IOWriteMaSirDb.DeleteforOrderInput(ref stockDtlList, out retMsg, out retInfo, ref sqlConnection,
                             ref sqlTransaction, ref sqlEncryptInfo);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {

            }

            return status;
        }

        # endregion

        # region [UOE�����m�菈��]

        /// <summary>
        /// UOE�����m�菈��
        /// </summary>
        /// <param name="uoeOdrSlipList"></param>
        /// <returns>STATUS</returns>
        public int OrderFixation(ref object uoeOdrSlipList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;  // �ۗ�

            try
            {
                # region [�p�����[�^�[�`�F�b�N]
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�ւ̐ڑ��Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (sqlTransaction == null)
                {
                    errmsg += ": �g�����U�N�V�����̊J�n�Ɏ��s���܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                ArrayList uoeOrderSlipArray = uoeOdrSlipList as ArrayList;

                if (ListUtils.IsEmpty(uoeOrderSlipArray))
                {
                    errmsg += ": �����f�[�^(�m��)���ݒ肳��Ă��܂���.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                # endregion

                // ********* DEL sakurai 2009/02/25 MAKON01814R�Ŋ|���Ă��邽��2�d���b�N�h�~ ***************
                #region
                // �V�X�e�����b�N 
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //ArrayList allOdrDtlList = new ArrayList();

                // 2009/02/20 MANTIS 11671 >>>>>>>>>>>>>>>>>>>
                //foreach (object item in uoeOrderSlipArray)
                //{
                //    ArrayList OrderSlips = item as ArrayList;

                //    if (OrderSlips != null)
                //    {
                //        ArrayList OdrDtlList = ListUtils.Find(OrderSlips, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                //        if (ListUtils.IsNotEmpty(OdrDtlList))
                //        {
                //            allOdrDtlList.AddRange(OdrDtlList);
                //        }
                //    }
                //}

                //StockDetailWork stockdtlwork = allOdrDtlList[0] as StockDetailWork;

                //foreach (StockDetailWork stwork in allOdrDtlList)
                //{
                //    if (dic.ContainsKey(stwork.SectionCode) == false)
                //    {
                //        dic.Add(stwork.SectionCode, stwork.SectionCode);
                //    }
                //}

                //����G���[��������UOE�����f�[�^�̂�UI����n����邽�߁A
                //�V�F�A�`�F�b�N�Ώۃ��X�g��UOE�����f�[�^�ɕύX
                //allOdrDtlList = ListUtils.Find(uoeOrderSlipArray, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

                //UOEOrderDtlWork uoeOrderdtlwork = allOdrDtlList[0] as UOEOrderDtlWork;

                //foreach (UOEOrderDtlWork uoework in allOdrDtlList)
                //{
                //    if (dic.ContainsKey(uoework.SectionCode) == false)
                //    {
                //        dic.Add(uoework.SectionCode, uoework.SectionCode);
                //    }
                //}
                //// 2009/02/20 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<,

                //ShareCheckInfo info = new ShareCheckInfo();
                //foreach (string secCd in dic.Keys)
                //{
                //    info.Keys.Add(uoeOrderdtlwork.EnterpriseCode, ShareCheckType.Section, secCd,"");
                //}

                //if (info.Keys.Count != 0)
                //{
                //    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                //}

                //if (status != 0) return status;
                #endregion
                // *****************************************************************************************

                status = this.OrderFixationProc(ref uoeOrderSlipArray, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // ********* DEL sakurai 2009/02/25 MAKON01814R�Ŋ|���Ă��邽��2�d���b�N�h�~ ***************
                #region
                //if (info.Keys.Count != 0)
                //{
                //    // �V�X�e�����b�N����
                //    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                //}
                #endregion
                // *****************************************************************************************
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uoeOdrSlipList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        private int OrderFixationProc(ref ArrayList uoeOdrSlipList,
                                      ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                string retMsg = string.Empty;
                string retItemInfo = string.Empty;

                bool existOdrSlip = false;  // �d��(����)�f�[�^���݊m�F�t���O true:�L�� false:����

                # region [�d������(��������)�f�[�^�̍X�V����]

                // �d������(��������)�f�[�^���P��ArrayList�ɂ܂Ƃ߂� �� �������׍X�V�����p
                ArrayList allOdrDtlList = new ArrayList();

                foreach (object item in uoeOdrSlipList)
                {
                    ArrayList OrderSlips = item as ArrayList;

                    if (OrderSlips != null)
                    {
                        ArrayList OdrDtlList = ListUtils.Find(OrderSlips, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        if (ListUtils.IsNotEmpty(OdrDtlList))
                        {
                            // �d������(��������)�f�[�^��1�ɂ܂Ƃ߂�
                            allOdrDtlList.AddRange(OdrDtlList);
                        }

                        // �����Ďd��(����[�d���`��=2])�f�[�^�̑��݊m�F���s��
                        if (!existOdrSlip)
                        {
                            StockSlipWork orderSlip = ListUtils.Find(OrderSlips, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                            if (orderSlip != null && orderSlip.SupplierFormal == 2)
                            {
                                existOdrSlip = true;
                            }
                        }
                    }
                }

                if (ListUtils.IsNotEmpty(allOdrDtlList))
                {
                    // �X�V�Ώۂ̎d������(��������)�f�[�^���L��ꍇ�ɂ̂ݏ������s��
                    status = this.IOWriteMaSirDb.WriteforOrderInput(ref allOdrDtlList, out retMsg, out retItemInfo,
                                                                    ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errmsg += ": �d������(��������)�f�[�^�̍X�V�Ɏ��s���܂���.";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }

                # endregion

                # region [�����f�[�^�̓o�^]

                # region [DEL �ύX�O]
                //foreach (object item in uoeOdrSlipList)
                //{
                //    ArrayList OrdSlip = item as ArrayList;

                //    // �����f�[�^�i�[�����������s��
                //    if (ListUtils.IsNotEmpty(OrdSlip) &&
                //        ListUtils.Find(OrdSlip, typeof(StockSlipWork), ListUtils.FindType.Class) != null &&
                //        ListUtils.Find(OrdSlip, typeof(StockDetailWork), ListUtils.FindType.Array) != null)
                //    {
                //        status = this.StockSlipDb.WriteforSalesOrderPrint(ref OrdSlip, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            errmsg += ": �����f�[�^�̓o�^�Ɏ��s���܂���.";
                //            base.WriteErrorLog(errmsg, status);
                //            return status;
                //        }
                //    }
                //}
                # endregion

                if (existOdrSlip)
                {
                    //status = this.StockSlipDb.WriteforSalesOrderPrint(ref uoeOdrSlipList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);                                //DEL 2009/01/16 M.Kubota
                    status = this.IOWriteMaSirDb.WriteforSalesOrderPrint(ref uoeOdrSlipList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);  //ADD 2009/01/16 M.Kubota

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errmsg += ": �����f�[�^�̓o�^�Ɏ��s���܂���.";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                # endregion

                # region [UOE�����f�[�^�̍X�V����]

                // UOE�����f�[�^�̃��X�g�𕪗�����
                ArrayList uoeOdrDtlList = ListUtils.Find(uoeOdrSlipList, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

                if (ListUtils.IsNotEmpty(uoeOdrDtlList))
                {
                    if (ListUtils.IsNotEmpty(allOdrDtlList))
                    {
                        // ��ɓo�^���������f�[�^�̎d���`�[�ԍ���ݒ肷��
                        DtlRelationGuidComp dtlRelGuidCmp = new DtlRelationGuidComp();
                        allOdrDtlList.Sort(dtlRelGuidCmp);

                        foreach (UOEOrderDtlWork uoeOrderDtl in uoeOdrDtlList)
                        {
                            int idx = allOdrDtlList.BinarySearch(uoeOrderDtl, dtlRelGuidCmp);

                            if (idx >= 0)
                            {
                                uoeOrderDtl.SupplierSlipNo = (allOdrDtlList[idx] as StockDetailWork).SupplierSlipNo;
                            }
                        }
                    }

                    // UOE�����f�[�^�̍X�V���s��
                    status = this.UOEOdrDtlDb.Write(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errmsg += ": UOE�����f�[�^�̍X�V�Ɏ��s���܂���.";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                # endregion

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {

            }

            return status;
        }

        # endregion

        # region [UOE�I�����C���ԍ��̔ԏ���]

        /// <summary>
        /// UOE�I�����C���ԍ��ݒ菈��
        /// </summary>
        /// <param name="UoeOdrDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              RRedmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// <br>Update Note : 2013/08/19 wuyk</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00</br>
        /// <br>              Redmine#39934�̑Ή��EUOE�^�d����M���s�����ۂ̃I�����C���ԍ��s���̌��ɂ��ďC�� </br>
        /// </remarks>
        private int NumberingOfOnlineNo(ref ArrayList UoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (ListUtils.IsNotEmpty(UoeOdrDtlList))
            {
                UOEOrderDtlWork UOEOdrDtl = ListUtils.Find(UoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) as UOEOrderDtlWork;

                if (UOEOdrDtl != null)
                {
                    // ���X�g�ɓo�^����Ă��鏇��(��ʂɕ\������Ă��鏇��)���ꎞ�I�ɃI�����C���s�ԍ��Ɋi�[����
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            UOEOdrDtl.OnlineRowNo = idx + 1;
                        }
                    }

                    int uoeKind = (UoeOdrDtlList[0] as UOEOrderDtlWork).UOEKind;        // UOE���(0:UOE 1:�����d����M)        // ADD wuyk 2013/08/19 Redmine#39934

                    // �I�����C���ԍ��̔ԗp�̕��ёւ����s��
                    //UoeOdrDtlList.Sort(new OnlineNoComparer());     // DEL wuyk 2013/08/19 Redmine#39934
                    UoeOdrDtlList.Sort(new OnlineNoComparer(uoeKind));     // ADD wuyk 2013/08/19 Redmine#39934

                    int savUOESupplierCd = 0;  // UOE������R�[�h
                    int valOnlineNo = 0;       // �I�����C���ԍ�
                    int valOnlineRowNo = 0;    // �I�����C���s�ԍ�
                    string savWarehouseCd = ""; // �q�ɃR�[�h // ADD wangyl 2013/02/06 FOR Redmine#34578

                    int systemDiv = (UoeOdrDtlList[0] as UOEOrderDtlWork).SystemDivCd;  //�V�X�e���敪

                    // ���ёւ�������UOE�����f�[�^�̃��X�g���AUOE������R�[�h���u���[�N�L�[�Ƃ���
                    // �I�����C���ԍ��ƃI�����C���s�ԍ���ݒ肷��
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            //---DEL wangyl 2013/02/06 Redmine#34578------>>>>>
                            //// 2009/02/14 MANTIS 9776>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// �`���̏ꍇ�͏���̂݁A�I�����C���ԍ����擾���A����ȍ~�͓����
                            //// �I�����C���ԍ����g�p����悤�ɕύX

                            //// �O��ێ�����UOE������R�[�h�ƈقȂ�ꍇ�ɃI�����C���ԍ����̔Ԃ���
                            ////if (savUOESupplierCd != UOEOdrDtl.UOESupplierCd)
                            //if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) &&
                            //    (systemDiv != 1 || idx == 0))
                            //// 2009/02/14 MANTIS 9776<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            //{
                            //    savUOESupplierCd = UOEOdrDtl.UOESupplierCd;

                            //    // �I�����C���s�ԍ��̏�����
                            //    valOnlineRowNo = 0;

                            //    // �I�����C���ԍ��̍̔�
                            //    status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                            //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //    {
                            //        break;  // �� �̔ԂɎ��s�����珈���I��
                            //    }
                            //}
                            //---DEL wangyl 2013/02/06 Redmine#34578------<<<<<

                            //---ADD wuyk 2013/08/19 Redmine#39934------>>>>>
                            // UOE���(0:UOE 1:�����d����M) 
                            if (uoeKind == 1)
                            {
                                // �`���̏ꍇ�͏���̂݁A�I�����C���ԍ����擾���A����ȍ~�͓����
                                // �I�����C���ԍ����g�p����悤�ɕύX

                                // �O��ێ�����UOE������R�[�h�ƈقȂ�ꍇ�ɃI�����C���ԍ����̔Ԃ���
                                if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) &&
                                    (systemDiv != 1 || idx == 0))
                                {
                                    savUOESupplierCd = UOEOdrDtl.UOESupplierCd;

                                    // �I�����C���s�ԍ��̏�����
                                    valOnlineRowNo = 0;

                                    // �I�����C���ԍ��̍̔�
                                    status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        break;  // �� �̔ԂɎ��s�����珈���I��
                                    }
                                }
                            }
                            else
                            {
                            //---ADD wuyk 2013/08/19 Redmine#39934------<<<<<
                                //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                                // �O��ێ�����UOE������R�[�h�ƈقȂ�ꍇ�ɃI�����C���ԍ����̔Ԃ���
                                if (systemDiv != 3)
                                {
                                    if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) &&
                                        (systemDiv != 1 || idx == 0))
                                    {
                                        savUOESupplierCd = UOEOdrDtl.UOESupplierCd;
                                        //�I�����C���s�ԍ��̏�����
                                        valOnlineRowNo = 0;

                                        //�I�����C���ԍ��̍̔�
                                        status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            break;  // �� �̔ԂɎ��s�����珈���I��
                                        }
                                    }
                                }
                                else
                                {
                                    if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) || (savWarehouseCd != UOEOdrDtl.WarehouseCode)) //�݌Ɉꊇ�������[�h�̏ꍇ�ɃI�����C���ԍ����̔Ԃ���
                                    {
                                        savUOESupplierCd = UOEOdrDtl.UOESupplierCd;
                                        savWarehouseCd = UOEOdrDtl.WarehouseCode;
                                        //�I�����C���s�ԍ��̏�����
                                        valOnlineRowNo = 0;

                                        //�I�����C���ԍ��̍̔�
                                        status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            break;  // �� �̔ԂɎ��s�����珈���I��
                                        }
                                    }
                                }
                                //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                            }       // ADD wuyk 2013/08/19 Redmine#39934
                            // UOE������R�[�h�����l�̊ԁA�����I�����C���ԍ���ݒ肷��
                            UOEOdrDtl.OnlineNo = valOnlineNo;

                            // �I�����C���s�ԍ��𑝉�������ɐݒ肷��(�����l��0�ׁ̈A�ŏ���+1����)
                            valOnlineRowNo++;
                            UOEOdrDtl.OnlineRowNo = valOnlineRowNo;
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// UOE�I�����C���ԍ��̔ԏ���
        /// </summary>
        /// <param name="keyItem"></param>
        /// <param name="onlineNo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int CreateOnlineNo(UOEOrderDtlWork keyItem, out int onlineNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            onlineNo = 0;

            //�ԍ��͈͕����[�v
            Int32 loopCnt = 1;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            string enterpriseCode = keyItem.EnterpriseCode;
            string sectionCode = keyItem.SectionCode;

            long no = 0;

            # region [SELECT��]
            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " UOE.ONLINENORF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  UOEORDERDTLRF AS UOE" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  UOE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND UOE.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
            sqlText += "  AND UOE.ONLINENORF = @FINDONLINENO" + Environment.NewLine;
            # endregion

            SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);

            SqlDataReader myReader = null;

            try
            {
                # region [�ԍ��̎擾�E�󂫔ԍ��̊m�F����]
                while (loopCnt <= 999999999)
                {
                    //�I�����C���ԍ��͋��_�Ǘ��L��
                    status = NumMng.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.UOEOnlineNo, out no);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                        break;
                    }
                    else
                    {
                        //�󂫔Ԃ̃`�F�b�N���s��
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                        //�ԍ��𐔒l�^�ɕϊ�
                        Int32 tmpOnlineNo = System.Convert.ToInt32(no);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                        findOnlineNo.Value = SqlDataMediator.SqlSetInt32(tmpOnlineNo);

                        if (myReader != null && !myReader.IsClosed)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        //�f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                        if (!myReader.Read())
                        {
                            onlineNo = tmpOnlineNo;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }

                    //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                    loopCnt++;
                }
                # endregion

                //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
                if (loopCnt == 999999999 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    errmsg += ": UOE�I�����C���ԍ��ɋ󂫔ԍ����L��܂���.";
                    base.WriteErrorLog(errmsg, status);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }

        /// <summary>
        /// �I�����C���ԍ��̔ԗp���ёւ�����
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00 2013/03/13�z�M����</br>
        /// <br>              RRedmine#34578�̑Ή� �q�ɖ��ɑq�ɖ��ɔ������s�����ہA�q�ɖ��ɂ܂Ƃ܂�Ȃ��i�\�����ʁj�q�ɒP�ʂɃ��}�[�N�𒼂����� </br>
        /// <br>Update Note : 2013/08/19 wuyk</br>
        /// <br>�Ǘ��ԍ�    : 10900690-00</br>
        /// <br>              Redmine#39934�̑Ή��EUOE�^�d����M���s�����ۂ̃I�����C���ԍ��s���̌��ɂ��ďC�� </br>
        /// </remarks>
        private class OnlineNoComparer : IComparer
        {
            //---ADD wuyk 2013/08/19 Redmine#39934------>>>>>
            // UOE��ʁi0:UOE 1:�����d����M�j
            private int _uoeKind = 0;

            /// <summary>
            /// UOE��ʁi0:UOE 1:�����d����M�j
            /// </summary>
            public int UOEKind
            {
                get { return _uoeKind; }
                set { _uoeKind = value; }
            }

            /// <summary>
            /// �I�����C���ԍ��̔ԗp���ёւ������N���X�R���X�g���N�^
            /// </summary>
            /// <param name="uoeKind">UOE��ʁi0:UOE 1:�����d����M�j</param>
            public OnlineNoComparer(int uoeKind)
            {
                this._uoeKind = uoeKind;
            }
            //---ADD wuyk 2013/08/19 Redmine#39934------<<<<<

            public int Compare(object x, object y)
            {
                UOEOrderDtlWork xDtl = x as UOEOrderDtlWork;
                UOEOrderDtlWork yDtl = y as UOEOrderDtlWork;
                int ret = (xDtl == null ? 0 : 1) - (yDtl == null ? 0 : 1);

                #region DEL wuyk 2013/08/19 Redmine#39934
                //if (ret == 0 && xDtl != null)
                //{
                //    //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                //    // �V�X�e���敪��3:�ꊇ �̏ꍇ�ɂ̂݁A�q�ɃR�[�h�Ŕ�r
                //    if (xDtl.SystemDivCd == 3)
                //    {
                //        ret = xDtl.WarehouseCode.CompareTo(yDtl.WarehouseCode);
                //        //---ADD wangyl 2013/02/26 Redmine#34578------<<<<<
                //        if (ret == 0)
                //        {
                //            ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //        }
                //        //---ADD wangyl 2013/02/26 Redmine#34578------>>>>>
                //    }
                //    //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                //    //---DEL wangyl 2013/02/06 Redmine#34578------>>>>>
                //    //// �V�X�e���敪�� 2:���� 3:�ꊇ �̏ꍇ�ɂ̂݁AUOE������R�[�h�Ŕ�r
                //    //if (xDtl.SystemDivCd == 2 || xDtl.SystemDivCd == 3)
                //    //{
                //    //    ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //    //}
                //    //---DEL wangyl 2013/02/06 Redmine#34578------<<<<<
                //    //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                //    // �V�X�e���敪�� 2:�����̏ꍇ�ɂ̂݁AUOE������R�[�h�Ŕ�r
                //    if (xDtl.SystemDivCd == 2)
                //    {
                //        ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //    }
                //    //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                //    if (ret == 0)
                //    {
                //        // �I�����C���s�ԍ��Ŕ�r
                //        ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                //        //---DEL wangyl 2013/02/26 Redmine#34578------<<<<<
                //        ////---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                //        //if (xDtl.SystemDivCd == 3)
                //        //{
                //        //    ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //        //}
                //        ////---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                //        //---DEL wangyl 2013/02/26 Redmine#34578------>>>>>
                //    }
                //}
                #endregion

                #region ADD wuyk 2013/08/19 Redmine#39934
                if (ret == 0 && xDtl != null)
                {
                    // UOE���(0:UOE 1:�����d����M) 
                    if (_uoeKind == 1)
                    {
                        // �V�X�e���敪�� 2:���� 3:�ꊇ �̏ꍇ�AUOE������R�[�h�Ŕ�r
                        if (xDtl.SystemDivCd == 2 || xDtl.SystemDivCd == 3)
                        {
                            ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                        }

                        if (ret == 0)
                        {
                            // �I�����C���s�ԍ��Ŕ�r
                            ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                        }
                    }
                    else
                    {
                        // �V�X�e���敪��3:�ꊇ �̏ꍇ�A�q�ɃR�[�h�AUOE������R�[�h�Ŕ�r
                        if (xDtl.SystemDivCd == 3)
                        {
                            ret = xDtl.WarehouseCode.CompareTo(yDtl.WarehouseCode);
                            if (ret == 0)
                            {
                                ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                            }
                        }

                        // �V�X�e���敪�� 2:�����̏ꍇ�AUOE������R�[�h�Ŕ�r
                        if (xDtl.SystemDivCd == 2)
                        {
                            ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                        }

                        if (ret == 0)
                        {
                            // �I�����C���s�ԍ��Ŕ�r
                            ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                        }
                    }
                }
                #endregion

                return ret;
            }
        }

        # endregion

        # region [UOE�����ԍ��̔ԏ���]

        /// <summary>
        /// UOE�����ԍ��ݒ菈��
        /// </summary>
        /// <param name="UoeOdrDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int NumberingOfUOESalesOrderNo(ref ArrayList UoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (ListUtils.IsNotEmpty(UoeOdrDtlList))
            {
                UOEOrderDtlWork UOEOdrDtl = ListUtils.Find(UoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) as UOEOrderDtlWork;

                if (UOEOdrDtl != null)
                {
                    // UOE�����ԍ��̔ԗp�ɕ��ёւ����s��
                    UoeOdrDtlList.Sort(new SalesOrderNoComparer());

                    int savUOESupplierCd = 0;       // UOE������R�[�h
                    int savOnlineNo = 0;            // �I�����C���ԍ�
                    int savMaxRowCnt = 1;           // ���M�\�ő喾�׍s��

                    int valUOESalesOrderNo = 0;     // UOE�����ԍ�
                    int valUOESalesOrderRowNo = 0;  // UOE�����s�ԍ�

                    // ���ёւ�������UOE�����f�[�^�̃��X�g���AUOE������R�[�h�ƃI�����C���ԍ����u���[�N�L�[�Ƃ�
                    // �X�ɒʐM�A�Z���u��ID�Ɋ֘A�t������ő喾�׍s������UOE�����ԍ���UOE�����s�ԍ���ݒ肷��
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            // ���M�\�ő喾�׍s���̎擾
                            savMaxRowCnt = (int)this._ComAsmIdToMaxDtlCntTable[UOEOdrDtl.CommAssemblyId];

                            // �O��ێ�����UOE������R�[�h��I�����C���ԍ����قȂ�ꍇ��
                            // UOE�����ԍ����̔Ԃ���
                            if (savUOESupplierCd != UOEOdrDtl.UOESupplierCd ||
                                savOnlineNo != UOEOdrDtl.OnlineNo ||
                                savMaxRowCnt <= valUOESalesOrderRowNo)
                            {
                                savUOESupplierCd = UOEOdrDtl.UOESupplierCd;
                                savOnlineNo = UOEOdrDtl.OnlineNo;
                                valUOESalesOrderRowNo = 0;

                                // UOE�����ԍ��̍̔�
                                status = this.CreateUOESalesOrderNo(UOEOdrDtl, out valUOESalesOrderNo, ref sqlConnection, ref sqlTransaction);

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    break;  // �� �̔ԂɎ��s�����珈���I��
                                }
                            }

                            // UOE������R�[�h�ƃI�����C���ԍ������l�ŁA�����M�\�ő喾�׍s���ȉ��̊�
                            // ����UOE�����ԍ���ݒ肷��
                            UOEOdrDtl.UOESalesOrderNo = valUOESalesOrderNo;

                            // UOE�����s�ԍ��𑝉�������ɐݒ肷��
                            valUOESalesOrderRowNo++;
                            UOEOdrDtl.UOESalesOrderRowNo = valUOESalesOrderRowNo;
                        }
                    }
                }
            }

            return status;
        }

        #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802�̑Ή�
        /// <summary>
        /// UOE�����ԍ��ݒ菈��
        /// </summary>
        /// <param name="UoeOdrDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int NumberingOfUOESalesOrderNoForStockEstmt(ref ArrayList UoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (ListUtils.IsNotEmpty(UoeOdrDtlList))
            {
                UOEOrderDtlWork UOEOdrDtl = ListUtils.Find(UoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) as UOEOrderDtlWork;

                if (UOEOdrDtl != null)
                {
                    int valUOESalesOrderNo = 0;     // UOE�����ԍ�
                    int uOESalesOrderNo = 0;
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            
                            // UOE�����ԍ����̔Ԃ���
                            if (valUOESalesOrderNo != UOEOdrDtl.UOESalesOrderNo)
                            {
                                valUOESalesOrderNo = UOEOdrDtl.UOESalesOrderNo;
                                // UOE�����ԍ��̍̔�
                                status = this.CreateUOESalesOrderNo(UOEOdrDtl, out uOESalesOrderNo, ref sqlConnection, ref sqlTransaction);

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    break;  // �� �̔ԂɎ��s�����珈���I��
                                }
                            }

                            // ����UOE�����ԍ���ݒ肷��
                            UOEOdrDtl.UOESalesOrderNo = uOESalesOrderNo;
                        }
                    }
                }
            }

            return status;
        }


        # region �t�n�d�����s�ԍ��̍ő�l�擾
        /// <summary>
        /// �t�n�d�����s�ԍ��̍ő�l�擾
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u���h�c</param>
        /// <param name="businessCode">�Ɩ��敪</param>
        /// <returns>�t�n�d�����s�ԍ��̍ő�l</returns>
        private int GetMaxOrderRowNo(string commAssemblyId, int businessCode)
        {
            int maxOrderRowNo = 0;

            //����
            if (businessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://�g���^
                        maxOrderRowNo = 3;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0202://�j�b�T��
                        maxOrderRowNo = 4;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0301://�~�c�r�V
                        maxOrderRowNo = 3;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0401://���}�c�_
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0402://�V�}�c�_
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0501://�z���_
                        maxOrderRowNo = 10;
                        break;
                    default:                                //�D�ǃ��[�J�[
                        maxOrderRowNo = 5;
                        break;
                }
            }
            //����
            else if (businessCode == (int)EnumUoeConst.TerminalDiv.ct_Estmt)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://�g���^
                    case EnumUoeConst.ctCommAssemblyId_0202://�j�b�T��
                    case EnumUoeConst.ctCommAssemblyId_0301://�~�c�r�V
                    case EnumUoeConst.ctCommAssemblyId_0401://���}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0402://�V�}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0501://�z���_
                        maxOrderRowNo = 10;
                        break;
                    default:                                //�D�ǃ��[�J�[
                        maxOrderRowNo = 0;
                        break;
                }
            }
            //�݌�
            else if (businessCode == (int)EnumUoeConst.TerminalDiv.ct_Stock)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://�g���^
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0202://�j�b�T��
                        maxOrderRowNo = 5;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0301://�~�c�r�V
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0401://���}�c�_
                        maxOrderRowNo = 15;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0402://�V�}�c�_
                        maxOrderRowNo = 5;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0501://�z���_
                        maxOrderRowNo = 15;
                        break;
                    default:                                //�D�ǃ��[�J�[
                        maxOrderRowNo = 5;
                        break;
                }
            }
            return (maxOrderRowNo);
        }
        #endregion
        #endregion
        /// <summary>
        /// UOE�����ԍ��̔ԏ���
        /// </summary>
        /// <param name="keyItem"></param>
        /// <param name="uoeSalesOrderNo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int CreateUOESalesOrderNo(UOEOrderDtlWork keyItem, out int uoeSalesOrderNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            uoeSalesOrderNo = 0;

            //�ԍ��͈͕����[�v
            Int32 loopCnt = 1;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            string enterpriseCode = keyItem.EnterpriseCode;
            string sectionCode = "000000";

            long no = 0;

            # region [SELECT��]
            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "  UOE.UOESALESORDERNORF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  UOEORDERDTLRF AS UOE" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  UOE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND UOE.UOESALESORDERNORF = @FINDUOESALESORDERNO" + Environment.NewLine;
            # endregion

            SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findUOESalesOrderNo = sqlCommand.Parameters.Add("@FINDUOESALESORDERNO", SqlDbType.Int);

            SqlDataReader myReader = null;

            try
            {
                # region [�ԍ��̎擾�E�󂫔ԍ��̊m�F����]
                while (loopCnt <= 999999999)
                {
                    //�I�����C���ԍ��͋��_�Ǘ��L��
                    status = NumMng.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.UOESalesOrderNo, out no);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                        break;
                    }
                    else
                    {
                        //�󂫔Ԃ̃`�F�b�N���s��
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                        //�ԍ��𐔒l�^�ɕϊ�
                        Int32 tmpUOESalesOrderNo = System.Convert.ToInt32(no);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(tmpUOESalesOrderNo);

                        if (myReader != null && !myReader.IsClosed)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        //�f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                        if (!myReader.Read())
                        {
                            uoeSalesOrderNo = tmpUOESalesOrderNo;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }

                    //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                    loopCnt++;
                }
                # endregion              xmpp

                //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
                if (loopCnt == 999999999 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    errmsg += ": UOE�����ԍ��ɋ󂫔ԍ����L��܂���.";
                    base.WriteErrorLog(errmsg, status);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }

        /// <summary>
        /// UOE�����ԍ��̔ԗp���ёւ�����
        /// </summary>
        private class SalesOrderNoComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UOEOrderDtlWork xDtl = x as UOEOrderDtlWork;
                UOEOrderDtlWork yDtl = y as UOEOrderDtlWork;
                int ret = (xDtl == null ? 0 : 1) - (yDtl == null ? 0 : 1);

                if (ret == 0 && xDtl != null)
                {
                    // UOE������R�[�h�Ŕ�r
                    ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);

                    if (ret == 0)
                    {
                        // �I�����C���ԍ��Ŕ�r
                        ret = xDtl.OnlineNo.CompareTo(yDtl.OnlineNo);
                    }

                    if (ret == 0)
                    {
                        // �I�����C���s�ԍ��Ŕ�r
                        ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                    }
                }

                return ret;
            }
        }

        # endregion

        private class DtlRelationGuidComp : IComparer
        {
            public int Compare(object x, object y)
            {
                Guid xGuid = Guid.Empty;
                Guid yGuid = Guid.Empty;

                if (x is StockDetailWork)
                {
                    xGuid = (x as StockDetailWork).DtlRelationGuid;
                }
                else if (x is UOEOrderDtlWork)
                {
                    xGuid = (x as UOEOrderDtlWork).DtlRelationGuid;
                }

                if (y is StockDetailWork)
                {
                    yGuid = (y as StockDetailWork).DtlRelationGuid;
                }
                else if (y is UOEOrderDtlWork)
                {
                    yGuid = (y as UOEOrderDtlWork).DtlRelationGuid;
                }

                return xGuid.CompareTo(yGuid);
            }
        }

# if false
        # region [Read]
        /// <summary>
        /// �P���UOE�����pI/OWrite�����擾���܂��B
        /// </summary>
        /// <param name="ioWriteUOEOdrDtlObj">IOWriteUOEOdrDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����pI/OWrite�̃L�[�l����v����UOE�����pI/OWrite�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int Read(ref object ioWriteUOEOdrDtlObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork = ioWriteUOEOdrDtlObj as IOWriteUOEOdrDtlWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref ioWriteUOEOdrDtlWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �P���UOE�����pI/OWrite�����擾���܂��B
        /// </summary>
        /// <param name="ioWriteUOEOdrDtlWork">IOWriteUOEOdrDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����pI/OWrite�̃L�[�l����v����UOE�����pI/OWrite�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int Read(ref IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref ioWriteUOEOdrDtlWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P���UOE�����pI/OWrite�����擾���܂��B
        /// </summary>
        /// <param name="ioWriteUOEOdrDtlWork">IOWriteUOEOdrDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����pI/OWrite�̃L�[�l����v����UOE�����pI/OWrite�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        private int ReadProc(ref IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

        # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  IOWRITEUOEODRDTLRF" + Environment.NewLine;
                sqlText += "" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
        # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToIOWriteUOEOdrDtlWorkFromReader(ref myReader, ref ioWriteUOEOdrDtlWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Delete]
        /// <summary>
        /// UOE�����pI/OWrite���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOdrDtlList">�����폜����UOE�����pI/OWrite�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����pI/OWrite�̃L�[�l����v����UOE�����pI/OWrite���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int Delete(object ioWriteUOEOdrDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = ioWriteUOEOdrDtlList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// UOE�����pI/OWrite���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE�����pI/OWrite�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����pI/OWrite���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        public int Delete(ArrayList ioWriteUOEOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(ioWriteUOEOdrDtlList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����pI/OWrite���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE�����pI/OWrite�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList �Ɋi�[����Ă���UOE�����pI/OWrite���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        private int DeleteProc(ArrayList ioWriteUOEOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (ioWriteUOEOdrDtlList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < ioWriteUOEOdrDtlList.Count; i++)
                    {
                        IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork = ioWriteUOEOdrDtlList[i] as IOWriteUOEOdrDtlWork;

        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  IOWRITEUOEODRDTLRF" + Environment.NewLine;
                        sqlText += "" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != ioWriteUOEOdrDtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

        # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  IOWRITEUOEODRDTLRF" + Environment.NewLine;
                            sqlText += "" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
        # endregion

                            // KEY�R�}���h���Đݒ�
                            
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion


        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ioWriteUOEOdrDtlWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(ioWriteUOEOdrDtlWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� IOWriteUOEOdrDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>IOWriteUOEOdrDtlWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private IOWriteUOEOdrDtlWork CopyToIOWriteUOEOdrDtlWorkFromReader(ref SqlDataReader myReader)
        {
            IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork = new IOWriteUOEOdrDtlWork();

            this.CopyToIOWriteUOEOdrDtlWorkFromReader(ref myReader, ref ioWriteUOEOdrDtlWork);

            return ioWriteUOEOdrDtlWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� IOWriteUOEOdrDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="ioWriteUOEOdrDtlWork">IOWriteUOEOdrDtlWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void CopyToIOWriteUOEOdrDtlWorkFromReader(ref SqlDataReader myReader, ref IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork)
        {
            if (myReader != null && ioWriteUOEOdrDtlWork != null)
            {
        # region �N���X�֊i�[
                
        # endregion
            }
        }
        # endregion

# endif

    }
}
