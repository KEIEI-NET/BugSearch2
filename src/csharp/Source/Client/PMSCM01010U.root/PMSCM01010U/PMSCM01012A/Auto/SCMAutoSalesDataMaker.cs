//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/10/10  �C�����e : Redmine#25762 �݌Ɋm�F�̎����񓚎��A���σf�[�^���쐬���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/11/12  �C�����e : Redmine#26533 Redmine#25762�̕ύX�����ɖ߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/08  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή�
//                                : 02.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i�񓚔��莞�j
//                                : 03.�ύX�O�P���v�Z�ďo�񐔉��ǑΉ�
//                                : 04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ�
//                                : 05.���Ӑ�}�X�^�i�`�[�Ǘ��j�擾���ǑΉ�
//                                : 06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j
//                                : 07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j
//                                : 08.����f�[�^�������̃V�X�e�����t�擾�Ή�
//                                : 09.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i����f�[�^�������j
//                                : 10.�P���v�Z�ďo�񐔉���
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller.Auto
{
    /// <summary>
    /// SCM�����񓚗p����f�[�^�쐬�����N���X
    /// </summary>
    public sealed class SCMAutoSalesDataMaker : SCMSalesDataMaker
    {
        #region <���O�p�萔>

        /// <summary>�N���X����</summary>
        private const string MY_NAME = "SCMAutoSalesDataMaker";

        #endregion // </���O�p�萔>

        #region <��\�f�[�^>

        /// <summary>��\SCM�󒍃f�[�^</summary>
        private ISCMOrderHeaderRecord _representativeSCMHeaderRecord;
        /// <summary>��\SCM�󒍃f�[�^���擾�܂��͐ݒ肵�܂��B</summary>
        private ISCMOrderHeaderRecord RepresentativeSCMHeaderRecord
        {
            get { return _representativeSCMHeaderRecord; }
            set
            {
                if (_representativeSCMHeaderRecord != null) return;
                _representativeSCMHeaderRecord = value;
            }
        }

        /// <summary>
        /// ��\��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <returns>��\SCM�󒍃f�[�^�̖⍇�����ƃR�[�h</returns>
        private string GetRepresentativeEnterpriseCode()
        {
            if (RepresentativeSCMHeaderRecord != null)
            {
                return RepresentativeSCMHeaderRecord.InqOtherEpCd;
            }
            return LoginInfoAcquisition.EnterpriseCode;
        }

        /// <summary>
        /// ��\���_�R�[�h���擾���܂��B
        /// </summary>
        /// <returns>��\SCM�󒍃f�[�^�̖⍇���拒�_�R�[�h</returns>
        private string GetRepresentativeSectionCode()
        {
            if (RepresentativeSCMHeaderRecord != null)
            {
                return RepresentativeSCMHeaderRecord.InqOtherSecCd;
            }
            return "00";    // �S��
        }

        #endregion // </��\�f�[�^>

        /// <summary>����񓚂݂̂ł��邩�̃t���O</summary>
        private bool _isSobaAnswerOnly;

        /// <summary>����񓚂݂̂�I/O Writer�p�p�����[�^</summary>
        /// <remarks><c>CreateSalesData()</c>�ɂāA���㖾�׃f�[�^�����݂��Ȃ��ꍇ�ɍ\�z����܂��B</remarks>
        private CustomSerializeArrayList _scmOrderDataWithSobaOnly;

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="referee">SCM�񓚔��菈��</param>
        public SCMAutoSalesDataMaker(SCMReferee referee) : base(referee) { }

        #endregion // </Constructor>

        #region <Override>


        // 2011/02/14 Add >>>
        /// <summary>
        /// �����񓚂����f���܂��B
        /// </summary>
        /// <returns></returns>
        protected override bool IsAutoAnswer()
        {
            return true;
        }
        // 2011/02/14 Add <<<

        // 2011/02/18 Add >>>
        /// <summary>
        /// �񓚍쐬�敪���擾���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>
        /// �󒍃X�e�[�^�X���u10:���ρv�u30:����v�̏ꍇ�A�u0:�����v��Ԃ��܂��B<br/>
        /// ����ȊO�i�u20:�󒍁v�j�̏ꍇ�A�u1:�蓮(Web)�v��Ԃ��܂��B
        /// </returns>
        protected override int GetAnswerCreateDiv(int acptAnOdrStatus)
        {
            if (
                acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)
                    ||
                acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
            )
            {
                return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.Auto;
            }
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// ����񓚂݂̂����f���܂��B
        /// </summary>
        /// <value>
        /// <c>true</c> :����񓚂݂̂ł��B<br/>
        /// <c>false</c>:����񓚂݂̂ł͂���܂���B
        /// </value>
        /// <see cref="SCMSalesDataMaker"/>
        public override bool IsSobaAnswerOnly
        {
            get { return _isSobaAnswerOnly; }
        }

        /// <summary>
        /// ����񓚂݂̂�I/O Writer�p�p�����[�^���擾���܂��B
        /// </summary>
        /// <see cref="SCMSalesDataMaker"/>
        public override CustomSerializeArrayList SobaOnlySCMOrderDataParameterList
        {
            get
            {
                if (_scmOrderDataWithSobaOnly == null)
                {
                    _scmOrderDataWithSobaOnly = base.CreateSalesData();
                }
                return _scmOrderDataWithSobaOnly;
            }
        }

        /// <summary>
        /// ���ナ�X�g�̐����҂𐶐����܂��B
        /// </summary>
        /// <returns>���ナ�X�g�̐�����</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override SCMSalesListEssence CreateSCMSalesListEssence()
        {
            return new SCMAutoSalesListEssence();
        }

        /// <summary>
        /// ����f�[�^���쐬�\�����f���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :�쐬�ł��܂��B<br/>
        /// <c>false</c>:�쐬�ł��܂���B
        /// </returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override bool CanMakeSalesData(ISCMOrderAnswerRecord answerRecord)
        {
            const string METHOD_NAME = "CanMakeSalesData()";    // ���O�p

            // ����񓚂̏ꍇ�A����f�[�^�̍쐬���s��Ȃ�
            if (SCMDataHelper.IsMarketPrice(answerRecord))
            {
                #region <Log>

                EasyLogger.Write(
                    MY_NAME,
                    METHOD_NAME,
                    LogHelper.GetInfoMsg("����񓚂ł��邽�ߔ��㖾�׃f�[�^���쐬���܂���ł����B" + Environment.NewLine + SCMDataHelper.GetProfile(answerRecord))
                );

                #endregion // </Log>

                return false;
            }

            return true;
        }

        #region <����f�[�^>

        /// <summary>
        /// �`�[�f�[�^�̐����҂𐶐����܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>�`�[�f�[�^�̐�����</returns>
        protected override SCMSlipDataFactory CreateSlipDataFactory(ISCMOrderHeaderRecord headerRecord)
        {
            switch (headerRecord.AcptAnOdrStatus)
            {
                case (int)AcptAnOdrStatus.Sales:
                    return new SCMSalesSlipDataFactory(headerRecord, true);
                case (int)AcptAnOdrStatus.Order:
                    return new SCMOrderSlipDataFactory(headerRecord, true);
                case (int)AcptAnOdrStatus.Estimate:
                    return new SCMEstimateSlipDataFactory(headerRecord, true);
                default:
                    throw new ArgumentException("�󒍃X�e�[�^�X���s���ł��B[=" + headerRecord.AcptAnOdrStatus.ToString() + "]");
            }
        }

        /// <summary>
        /// ����f�[�^�𐶐����܂��B
        /// </summary>
        /// <returns>����f�[�^</returns>
        public override CustomSerializeArrayList CreateSalesData()
        {
            const string METHOD_NAME = "CreateSalesData()"; // ���O�p

            // SCM�󒍖��׃f�[�^(��)�Ɣ���f�[�^���쐬
            MakeAnswerDataAndSalesData();
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("SCM�󒍖��׃f�[�^(��)�Ɣ���f�[�^���쐬�F����"));

            CustomSerializeArrayList salesData = new CustomSerializeArrayList();
            {
                bool canEntryCarMng = false;

                // ����f�[�^
                foreach (SCMSalesListEssence salesListEssence in SCMSalesListEssenceMap.Values)
                {
                    IList<SCMSalesListEssence> splitedEssence = salesListEssence.Split();

                    // ----- ADD 2011/11/12 ----- >>>>>
                    //// ----- ADD 2011/10/10 ----- >>>>>
                    //// PCCUOE�̍݌Ɋm�F�̏ꍇ
                    //if (salesListEssence.SCMHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE
                    //    && salesListEssence.SCMHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
                    //{
                    //    splitedEssence.Add(salesListEssence);
                    //}
                    //// ----- ADD 2011/10/10 ----- <<<<<
                    // ----- ADD 2011/11/12 ----- <<<<<
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(splitedEssence.Count.ToString() + " �`�[�ɕ�������܂����B"));

                    foreach (SCMSalesListEssence essence in splitedEssence)
                    {
                        // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ---------------------------------->>>>>
                        essence.PriceCalculator = PriceCalculator;
                        // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ----------------------------------<<<<<

                        CustomSerializeArrayList salesList = essence.CreateSalesList(out canEntryCarMng);
                        salesData.Add(salesList);
                    }

                    // ����񓚂݂̂̏ꍇ
                    if (ListUtil.IsNullOrEmpty(splitedEssence))
                    {
                        _scmOrderDataWithSobaOnly = base.CreateSalesData(true);
                        _isSobaAnswerOnly = !ListUtil.IsNullOrEmpty(_scmOrderDataWithSobaOnly);
                    }
                }

                // �����[�g�Q�Ɨp�p�����[�^
                salesData.Add(CreateIOWriteCtrlOptWork(canEntryCarMng));
            }
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("���`�����[�g�p�p�����[�^�̍\�z�F����"));

            return salesData;
        }

        #endregion // </����f�[�^>

        #region <SCM�󒍃f�[�^>

        /// <summary>
        /// SCM�󒍃f�[�^���񓚗p�ɃR�s�[����ѕҏW���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>�񓚗p�ɕҏW����SCM�󒍃f�[�^�̃��R�[�h</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override ISCMOrderHeaderRecord CopyAndEditSCMOrderHeaderRecord(ISCMOrderHeaderRecord headerRecord)
        {
            RepresentativeSCMHeaderRecord = headerRecord;

            UserSCMOrderHeaderRecord userHeaderRecord = base.CopyAndEditSCMOrderHeaderRecord(
                headerRecord
            ) as UserSCMOrderHeaderRecord;
            {
                // 036.�񓚍쐬�敪(0:����, 1:�蓮(Web), 2:�蓮(���̑�))
                userHeaderRecord.AnswerCreateDiv = GetAnswerCreateDiv(userHeaderRecord.AcptAnOdrStatus);
            }
            return userHeaderRecord;
        }

        #endregion // </SCM�󒍃f�[�^>

        #region <�����[�g�Q�Ɨp�p�����[�^>

        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^�𐶐����܂��B
        /// </summary>
        /// <param name="canEntryCarMng">�ԗ��Ǘ��}�X�^�ɓo�^����t���O</param>
        /// <returns>�����[�g�Q�Ɨp�p�����[�^</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override IOWriteCtrlOptWork CreateIOWriteCtrlOptWork(bool canEntryCarMng)
        {
            IOWriteCtrlOptWork ioWriteCtrlOpt = base.CreateIOWriteCtrlOptWork(canEntryCarMng);
            {
                ioWriteCtrlOpt.EnterpriseCode = GetRepresentativeEnterpriseCode();

                // ����S�̐ݒ���擾
                SalesTtlSt salesTotalSetting = SalesTtlStDB.Find(
                    ioWriteCtrlOpt.EnterpriseCode,
                    GetRepresentativeSectionCode()
                );
                if (salesTotalSetting != null)
                {
                    ioWriteCtrlOpt.AcpOdrrAddUpRemDiv = salesTotalSetting.AcpOdrrAddUpRemDiv;   // �󒍃f�[�^�v��c�敪(0:�c��/1:�c���Ȃ�)
                    ioWriteCtrlOpt.ShipmAddUpRemDiv = salesTotalSetting.ShipmAddUpRemDiv;       // �o�׃f�[�^�v��c�敪(0:�c��/1:�c���Ȃ�)
                    ioWriteCtrlOpt.EstimateAddUpRemDiv = salesTotalSetting.EstmateAddUpRemDiv;  // ���σf�[�^�v��c�敪(0:�c��/1:�c���Ȃ�)
                }
            }
            return ioWriteCtrlOpt;
        }

        #endregion  // </�����[�g�Q�Ɨp�p�����[�^>

        #endregion // </Override>
    }
}
