//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ�
// �v���O�����T�v   : SCM�⍇�����O�e�[�u���ɑ΂��Č����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/19  �C�����e : Redmine#17394
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/24  �C�����e : Redmine#17505
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Е��i���������Ɖ�̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : �� ��</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    public class ScmInqLogAcs
    {
        #region �� Private Members ��
        // SCM�⍇�����O�f�[�^�Z�b�g
        private ScmInqLogInquiryDataSet _scmInqLogDataSet;
        // SCM�⍇�����O�f�[�^�e�[�u��
        private ScmInqLogInquiryDataSet.ScmInqLogInquiryDataTable _scmInqLogDataTable;
        private IScmInqLogInquiryDB _iScmInqLogDB;
        private static ScmInqLogAcs _scmInqLogAcs;
        #endregion �� Private Members ��

        #region �� Properties ��

        /// <summary>
        /// SCM�⍇�����O�f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public ScmInqLogInquiryDataSet.ScmInqLogInquiryDataTable ScmInqLogDataTable
        {
            get { return _scmInqLogDataTable; }
        }
        #endregion �� Properties ��

        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private ScmInqLogAcs()
        {
            // �ϐ�������
            this._scmInqLogDataSet = new ScmInqLogInquiryDataSet();
            this._scmInqLogDataTable = this._scmInqLogDataSet.ScmInqLogInquiry;
            this._iScmInqLogDB = MediationScmInqLogInquiryDB.GetIScmInqLogInquiryDB();
        }
        # endregion �� Constructor ��

        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA���M�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="readMode">�Ǎ����[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : SCM�⍇�����O�擾�������s���B</br>      
        /// <br>Programmer : �� ��</br>                                  
        /// <br>Date       : 2010/11/11</br> 
        /// </remarks>
        //public int search(ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode) // DEL 2010/11/19
        public int search(ref object scmInqLogInquirySearchPara, int readMode) // ADD 2010/11/19
        {
            ArrayList outScmInqLogList = new ArrayList();
            object outObj = outScmInqLogList as object;

            //int status = this._iScmInqLogDB.Search(out outObj, scmInqLogInquirySearchPara, readMode); // DEL 2010/11/19
            int status = this._iScmInqLogDB.Search(out outObj, ref scmInqLogInquirySearchPara, readMode); // ADD 2010/11/19
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                outScmInqLogList = (ArrayList)outObj;
                int i = 1;
                this._scmInqLogDataTable.Clear();
                // ---UPD 2010/11/24 ------------------------------->>>
                //foreach (ScmInqLogInquiryWork scmInqLog in outScmInqLogList)
                //{
                //    ScmInqLogInquiryDataSet.ScmInqLogInquiryRow scmInqLogRow = this._scmInqLogDataTable.NewScmInqLogInquiryRow();
                //    scmInqLogRow.CnectOriginalEpNm = scmInqLog.CnectOriginalEpNm;
                //    //scmInqLogRow.CreateDateTime = scmInqLog.CreateDateTime; // DEL 2010/11/19
                //    scmInqLogRow.CreateDate = scmInqLog.CreateDateTime.Date; // ADD 2010/11/19
                //    scmInqLogRow.CreateTime = scmInqLog.CreateDateTime.TimeOfDay.ToString().Substring(0, 8); // ADD 2010/11/19
                //    scmInqLogRow.RowNo = i++;
                //    scmInqLogRow.ScmInqContents = scmInqLog.ScmInqContents;
                //    switch (scmInqLog.InqDataInputSystem)
                //    {
                //        case 1:
                //            scmInqLogRow.UseSystem = "SF.NS";
                //            break;
                //        case 2:
                //            scmInqLogRow.UseSystem = "BK/BF.NS";
                //            break;
                //        case 3:
                //            scmInqLogRow.UseSystem = "RC.NS";
                //            break;
                //        case 4:
                //            scmInqLogRow.UseSystem = "SF7";
                //            break;
                //        case 5:
                //            scmInqLogRow.UseSystem = "BK�p�[�t�F�N�g";
                //            break;
                //        case 6:
                //            scmInqLogRow.UseSystem = "RC7";
                //            break;
                //        default:
                //            break;
                //    }
                //    this._scmInqLogDataTable.Rows.Add(scmInqLogRow);
                //}
                this._scmInqLogDataTable.BeginLoadData();
                try
                {
                    foreach (ScmInqLogInquiryWork scmInqLog in outScmInqLogList)
                    {
                        ScmInqLogInquiryDataSet.ScmInqLogInquiryRow scmInqLogRow = this._scmInqLogDataTable.NewScmInqLogInquiryRow();
                        scmInqLogRow.CnectOriginalEpNm = scmInqLog.CnectOriginalEpNm;
                        scmInqLogRow.CreateDate = scmInqLog.CreateDateTime.Date;
                        scmInqLogRow.CreateTime = scmInqLog.CreateDateTime.TimeOfDay.ToString().Substring(0, 8); // ADD 2010/11/19
                        scmInqLogRow.RowNo = i++;
                        scmInqLogRow.ScmInqContents = scmInqLog.ScmInqContents;
                        switch (scmInqLog.InqDataInputSystem)
                        {
                            case 1:
                                scmInqLogRow.UseSystem = "SF.NS";
                                break;
                            case 2:
                                scmInqLogRow.UseSystem = "BK/BF.NS";
                                break;
                            case 3:
                                scmInqLogRow.UseSystem = "RC.NS";
                                break;
                            case 4:
                                scmInqLogRow.UseSystem = "SF7";
                                break;
                            case 5:
                                scmInqLogRow.UseSystem = "BK�p�[�t�F�N�g";
                                break;
                            case 6:
                                scmInqLogRow.UseSystem = "RC7";
                                break;
                            default:
                                break;
                        }
                        this._scmInqLogDataTable.Rows.Add(scmInqLogRow);
                    }
                }
                finally
                {
                    this._scmInqLogDataTable.EndLoadData();
                }
                // ---UPD 2010/11/24 -------------------------------<<<
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._scmInqLogDataTable.Clear();
                return status;
            }
            else
            {
                return status;
            }
        }

        # region �� SCM�⍇�����O�A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// SCM�⍇�����O�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM�⍇�����O�擾�������s���B</br>      
        /// <br>Programmer : �� ��</br>                                  
        /// <br>Date       : 2010/11/11</br> 
        /// </remarks>
        public static ScmInqLogAcs GetInstance()
        {
            if (_scmInqLogAcs == null)
            {
                _scmInqLogAcs = new ScmInqLogAcs();
            }

            return _scmInqLogAcs;
        }
        # endregion �� SCM�⍇�����O�A�N�Z�X�N���X �C���X�^���X�擾���� ��
    }
}
