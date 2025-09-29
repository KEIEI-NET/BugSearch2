//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[�� �`�[�ԍ��ϊ��A�N�Z�X�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS�����c�[�� �`�[�ԍ��ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[�� �`�[�ԍ��ϊ��A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/07</br>
    /// </remarks>
    public class SlipNoConvertAcs
    {
        #region -- Member --

        /// <summary>�`�[�ԍ��ϊ������[�g�I�u�W�F�N�g</summary>
        private ISlipNoConvertDB iSlipNoConvertDb;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@PM.NS�`�[�ԍ��ϊ������c�[���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :PM.NS�`�[�ԍ��ϊ������c�[���A�N�Z�X�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public SlipNoConvertAcs()
        {
            // ISlipNoConvertDB�̏��������s���܂�
            this.iSlipNoConvertDb = (ISlipNoConvertDB)MediationSlipNoConvertDB.GetSlipNoConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableMap">�R�[�h�ϊ��Ώۃe�[�u���̃��X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ϊ��Ώۂ̏��������擾���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public int GetTargetTableList(int secDiv,IDictionary<int, IList<SlpNoTargetTableListResult>> targetTableMap)
        {

            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            IList<SlpNoTargetTableList> retObjMap = new List<SlpNoTargetTableList>();
            Object retObj = retObjMap;

            // �����[�g�I�u�W�F�N�g�����{���A�R�[�h�ϊ��Ώۂ̃��X�g���擾���܂��B
            status = this.iSlipNoConvertDb.GetTargetTableList(secDiv,ref retObj);


            // �X�e�[�^�X�������̏ꍇ�́AXML����擾�������e��ϐ��ɓ���ւ���
            if(status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IList<SlpNoTargetTableList>;

                foreach(SlpNoTargetTableList work in retObjMap)
                {
                    //����L�[�����݂���
                    if (targetTableMap.ContainsKey(work.TargetNo))
                    {
                        targetTableMap[work.TargetNo].Add(this.SlpNoTargetTableListToSlpNoTargetTableListResult(work));
                    }
                    //����L�[�����݂��Ȃ�
                    else
                    {
                        targetTableMap.Add(work.TargetNo, new List<SlpNoTargetTableListResult>());
                        targetTableMap[work.TargetNo].Add(this.SlpNoTargetTableListToSlpNoTargetTableListResult(work));
                    }

                }
            }

            return status;
        }

        /// <summary>
        /// �`�[�ϊ��`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="slpNoTargetListResult">�`�F�b�N�Ώۃf�[�^</param>
        /// <param name="checkInfo">�`�F�b�N����(True:�f�[�^����/False�F�f�[�^�Ȃ�)</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɓ`�[�ԍ��ϊ��\���ǂ����`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public int CheckCOnvertSlipNo(string enterpriseCode, SlpNoConvertData slpNoConvertDt,out bool checkInfo)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // �`�F�b�N���̏�����
            checkInfo = false;
            //�f�[�^��ϊ�����
            Object retObj = this.SlpNoConvertDataToSlipNoConvertPrmInfoList(slpNoConvertDt);
            
            // �����[�g�I�u�W�F�N�g�����{���`�F�b�N���ʂ��擾���܂�
            status = this.iSlipNoConvertDb.CheckConvertSlipNo(enterpriseCode, retObj, ref checkInfo);

            return status;
        }

        /// <summary>
        /// �`�[�ԍ��ϊ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="slpNoTargetListResult">�`�F�b�N�Ώۃf�[�^</param>
        /// <param name="prcssngCnt">�X�V�f�[�^��</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɓ`�[�ԍ��ϊ��\���ǂ����`�F�b�N���s���܂��B<</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public int SlipNoConvert(string enterpriseCode, SlpNoConvertData slpNoConvertData, ref long prcssngCnt)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prcssngCnt = 0;

            //�f�[�^�ϊ����s��
            Object retObj = this.SlpNoConvertDataToSlipNoConvertPrmInfoList(slpNoConvertData);

            //�����[�g�I�u�W�F�N�g�����{���`�F�b�N���ʂ��擾���܂�
            status = this.iSlipNoConvertDb.ConvertSlipNo(enterpriseCode, retObj,ref prcssngCnt);

            return status;

        }

        #endregion

        #region -- Private Method --

        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�e�[�u�����</param>
        /// <returns>�e�[�u�����</returns>
        /// <remarks>
        /// <br>Note       : SlpNoTargetTableList����SlpNoTargetTableListResult�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/11</br>
        /// </remarks>
        private SlpNoTargetTableListResult SlpNoTargetTableListToSlpNoTargetTableListResult(SlpNoTargetTableList trgTblList)
        {
            SlpNoTargetTableListResult trgTblLstRslt = new SlpNoTargetTableListResult();

            //�ԍ��R�[�h(�����Ώ۔ԍ�)
            trgTblLstRslt.TargetNo = trgTblList.TargetNo;
            //�e�[�u��ID(������)
            trgTblLstRslt.TargetTable = trgTblList.TargetTable;
            //�e�[�u����(�_����)
            trgTblLstRslt.TargetTableName = trgTblList.TargetTableName;
            //�J������(������)
            trgTblLstRslt.TargetColum = trgTblList.TargetColum;
            //�J������(�_����)
            trgTblLstRslt.TargetColumName = trgTblList.TargetColumName;
            //�󒍃X�e�[�^�XID
            trgTblLstRslt.TargetAcptStatusId = trgTblList.TargetAcptStatusId;
            //�󒍃X�e�[�^�X�R�[�h
            trgTblLstRslt.TargetAcptStatus = trgTblList.TargetAcptStatus;
            
            return trgTblLstRslt;
        }


        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�e�[�u�����</param>
        /// <returns>�e�[�u�����</returns>
        /// <remarks>
        /// <br>Note       : SlpNoTargetTableListResult����SlpNoTargetTableList�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private SlipNoConvertPrmInfoList SlpNoConvertDataToSlipNoConvertPrmInfoList(SlpNoConvertData trgCvt)
        {
            SlipNoConvertPrmInfoList trgCvtInfo = new SlipNoConvertPrmInfoList();

            //�ԍ��R�[�h(�����Ώ۔ԍ�)
            trgCvtInfo.NoCode = trgCvt.NoCode;
            //�e�[�u��ID(������)
            trgCvtInfo.Table = trgCvt.Table;
            //�e�[�u����(�_����)
            trgCvtInfo.TableName = trgCvt.TableName;
            //�J������(������)
            trgCvtInfo.Colum = trgCvt.Colum;
            //�J������(�_����)
            trgCvtInfo.ColumName = trgCvt.ColumName;
            //�󒍃X�e�[�^�XID
            trgCvtInfo.AcptStatusId = trgCvt.AcptStatusId;
            //�󒍃X�e�[�^�X�R�[�h
            trgCvtInfo.AcptStatus = trgCvt.AcptStatus;
            //�ԍ����ݒl
            trgCvtInfo.NoPresentVal = trgCvt.NoPresentVal;
            //�ݒ�J�n�ԍ�
            trgCvtInfo.SettingStartNo = trgCvt.SettingStartNo;
            //�ݒ�I���ԍ�
            trgCvtInfo.SettingEndNo = trgCvt.SettingEndNo;
            //�ԍ������l
            trgCvtInfo.NoIncDecWidth = trgCvt.NoIncDecWidth;

            return trgCvtInfo;
     
        }

        #endregion
    }
}
