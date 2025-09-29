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
// �Ǘ��ԍ�              �쐬�S�� : 30434�@�H�� �b�D
// �� �� ��  2010/04/20  �C�����e : �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF��������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : ���㖾�׃f�[�^.���ה��l�̃Z�b�g�d�l��ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : wangqx
// �� �� ��  2013/02/18  �C�����e : 2013/03/13�z�M���@ �V�X�e����Q �Ǘ���267�Ή�
//                                  �⍇���f�[�^���ďo�������s�����ہA�������ɖ⍇�����Z�b�g�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/03/07  �C�����e : SCM��Q��10489�Ή� 
//                                  �蓮�񓚎��ŕi�Ԍ����ŊY���Ȃ��̎��A����`�[���̖͂��ׂ�����ɕ\������Ȃ���Q�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2013/08/07  �C�����e : PM-SCM�d�|�ꗗ��10556�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2014/01/16  �C�����e : �����艿�󎚑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/01/30  �C�����e : Redmine#41771 ��Q��13�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F���@30745
// �� �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Manual
{
    /// <summary>
    /// SCM�蓮�񓚗p����f�[�^�쐬�����N���X
    /// </summary>
    public sealed class SCMManualSalesDataMaker : SCMSalesDataMaker
    {
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="referee">SCM�񓚔��菈��</param>
        public SCMManualSalesDataMaker(SCMReferee referee) : base(referee) { }

        #endregion // </Constructor>

        #region <Override>

        /// <summary>
        /// ���ナ�X�g�̐����҂𐶐����܂��B
        /// </summary>
        /// <returns>���ナ�X�g�̐�����</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override SCMSalesListEssence CreateSCMSalesListEssence()
        {
            return new SCMManualSalesListEssence();
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
            return true;
        }

        #region <SCM�󒍃f�[�^>

        /// <summary>
        /// SCM�󒍃f�[�^���񓚗p�ɃR�s�[����ѕҏW���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>�񓚗p�ɕҏW����SCM�󒍃f�[�^�̃��R�[�h</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override Broadleaf.Application.UIData.ISCMOrderHeaderRecord CopyAndEditSCMOrderHeaderRecord(Broadleaf.Application.UIData.ISCMOrderHeaderRecord headerRecord)
        {
            UserSCMOrderHeaderRecord userHeaderRecord = base.CopyAndEditSCMOrderHeaderRecord(
                headerRecord
            ) as UserSCMOrderHeaderRecord;
            {
                // 036.�񓚍쐬�敪(0:����, 1:�蓮(Web), 2:�蓮(���̑�))
                if (userHeaderRecord.AnswerCreateDiv.Equals((int)AnswerCreateDivValue.Auto))
                {
                    userHeaderRecord.AnswerCreateDiv = (int)AnswerCreateDivValue.ManualWeb;
                }
            }
            return userHeaderRecord;
        }

        #endregion // </SCM�󒍃f�[�^>

        // ���i�Ԍ����Ńq�b�g���Ȃ������ꍇ���܂�
        #region <SCM�󒍖��׃f�[�^(��)>

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)��ҏW���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <param name="scmGoodsUnitData">�t�����t�����i�A���f�[�^</param>
        /// <returns>�ҏW����SCM�󒍖��׃f�[�^(��)�̃��R�[�h</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override ISCMOrderAnswerRecord EditSCMOrderAnswerRecord(
            ISCMOrderAnswerRecord answerRecord,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // �i�Ԍ����Ńq�b�g���Ȃ������ꍇ
            {
                // SCM�󒍖��׃f�[�^(�⍇���E����)���قڃR�s�[������ԂŕԂ�
                UserSCMOrderAnswerRecord userAnswerRecord = answerRecord as UserSCMOrderAnswerRecord;
                {
                    if (userAnswerRecord == null)
                    {
                        Debug.Assert(false, "User�^��SCM�󒍖��׃f�[�^(��)�ł͂���܂���B");
                        return answerRecord;
                    }

                    // 001.�쐬����         �c���ʃw�b�_ �����[�g�擾
                    // 002.�X�V����         �c���ʃw�b�_ �����[�g�擾
                    userAnswerRecord.EnterpriseCode = answerRecord.InqOtherEpCd;    // 003.��ƃR�[�h�c���ʃw�b�_ �����[�g�擾
                    // 004.GUID             �c���ʃw�b�_ �����[�g�擾
                    // 005.�X�V�]�ƈ��R�[�h �c���ʃw�b�_ �����[�g�擾
                    // 006.�X�V�A�Z���u��ID1�c���ʃw�b�_ �����[�g�擾
                    // 007.�X�V�A�Z���u��ID2�c���ʃw�b�_ �����[�g�擾
                    // 008.�_���폜�敪     �c���ʃw�b�_ �����[�g�擾

                    // 009.�⍇������ƃR�[�h   �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 010.�⍇�������_�R�[�h   �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 011.�⍇�����ƃR�[�h   �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 012.�⍇���拒�_�R�[�h   �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 013.�⍇���ԍ�           �cSCM�󒍖��׃f�[�^(�⍇���E����)

                    userAnswerRecord.UpdateDate = DateTime.MinValue;    // 014.�X�V�N����       �c�����[�g�擾
                    userAnswerRecord.UpdateTime = 0;                    // 015.�X�V�����b�~���b �c�����[�g�擾

                    // 016.�⍇���s�ԍ��cSCM�󒍖��׃f�[�^(�⍇���E����)

                    // 017.�⍇���s�ԍ��}�ԁc�A�ԕt��(�⍇���s�ԍ��P��)
                    userAnswerRecord.InqRowNumDerivedNo = NextRowNumDerivedNo(scmGoodsUnitData.SourceDetailRecord);

                    // 018.�⍇�������׎���GUID�cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 019.�⍇���斾�׎���GUID�cSCM�󒍖��׃f�[�^(�⍇���E����)

                    // HACK:userAnswerRecord.GoodsDivCd = scmGoodsUnitData.GetGoodsDivCd(true);                 // 020.���i���                 �c���i���(GoodsUnitData)�Ƒ����񂩂�Z�b�g
                    // HACK:userAnswerRecord.RecyclePrtKindCode = scmGoodsUnitData.GetRecyclePrtKindCode(true); // 021.���T�C�N�����i���       �c���i���(GoodsUnitData)�Ƒ����񂩂�Z�b�g
                    // HACK:userAnswerRecord.RecyclePrtKindName = scmGoodsUnitData.GetRecyclePrtKindName(true); // 022.���T�C�N�����i��ʖ���   �c���i���(GoodsUnitData)�Ƒ����񂩂�Z�b�g

                    // 023.�[�i�敪     �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 024.�戵�敪     �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 025.���i�`��     �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 026.�[�i�m�F�敪 �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 027.�[�i�����\���

                    // HACK:userAnswerRecord.AnswerDeliveryDate = scmGoodsUnitData.GetAnswerDeliveryDate(); // 028.�񓚔[���cSCM�[���ݒ�}�X�^

                    // BL�R�[�h��SCM�󒍖��׃f�[�^(�⍇���E����)�̒l�̂܂�
                    //userAnswerRecord.BLGoodsCode = scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode;  // 029.BL���i�R�[�h�c���i���(GoodsUnitData)
                    // HACK:030.BL���i�R�[�h�}�ԁc���i���(GoodsUnitData) �����i���ɂȂ��H
                    //userAnswerRecord.BLGoodsDrCode = scmGoodsUnitData.RealGoodsUnitData.BLGoodsDrCode;

                    // FIXME:031.�┭���i���cSCM�󒍖��׃f�[�^(�⍇���E����)�H

                    //userAnswerRecord.AnsGoodsName = scmGoodsUnitData.RealGoodsUnitData.GoodsName;   // 032.�񓚏��i���c���i���(GoodsUnitData)

                    // 033.�������cSCM�󒍖��׃f�[�^(�⍇���E����)

                    // HACK:userAnswerRecord.DeliveredGoodsCount = userAnswerRecord.SalesOrderCount;    // 034.�[�i���cSCM�󒍖��׃f�[�^(�⍇���E����).������

                    // HACK:userAnswerRecord.GoodsNo = scmGoodsUnitData.RealGoodsUnitData.GoodsNo;              // 035.���i�ԍ�             �c���i���(GoodsUnitData)
                    // HACK:userAnswerRecord.GoodsMakerCd = scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd;    // 036.���i���[�J�[�R�[�h   �c���i���(GoodsUnitData)
                    // HACK:userAnswerRecord.GoodsMakerNm = scmGoodsUnitData.RealGoodsUnitData.MakerName;       // 037.���i���[�J�[����
                    // HACK:userAnswerRecord.PureGoodsMakerCd = scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd;// FIXME:038.�������i���[�J�[�R�[�h

                    // 039.�┭�������i�ԍ��cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // HACK:userAnswerRecord.AnsPureGoodsNo = scmGoodsUnitData.RealGoodsUnitData.GoodsNo;   // FIXME:040.�񓚏������i�ԍ�

                    // HACK:userAnswerRecord.ListPrice = scmGoodsUnitData.GetListPrice();   // 041.�艿�c�Z�o
                    // HACK:userAnswerRecord.UnitPrice = scmGoodsUnitData.GetUnitPrice();   // 042.�P���c�Z�o

                    // 043.���i�⑫���cSCM�󒍖��׃f�[�^(�⍇���E����)

                    // HACK:userAnswerRecord.RoughRrofit = scmGoodsUnitData.GetRoughRrofit();   // 044.�e���z�c�Z�o
                    // HACK:userAnswerRecord.RoughRate = scmGoodsUnitData.GetRoughRate();       // 045.�e�����c�Z�o

                    // 046.�񓚊���     �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 047.���l(����)   �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 048.�Y�t�t�@�C��(����)   �c���g�p
                    // 049.�Y�t�t�@�C����(����) �c���g�p

                    // HACK:050.�I�ԁc���i���(GoodsUnitData) ���݌Ɉϑ��̏ꍇ�̂݃Z�b�g
                    //if (scmGoodsUnitData.GetStockDiv().Equals((int)StockDiv.Trust))
                    //{
                    //    userAnswerRecord.ShelfNo = scmGoodsUnitData.GetShelfNo();
                    //}

                    // 051.�ǉ��敪�cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 052.�����敪�cSCM�󒍖��׃f�[�^(�⍇���E����)

                    // HACK:userAnswerRecord.AcptAnOdrStatus = scmGoodsUnitData.GetAcptAnOdrStatus();           // 053.�󒍃X�e�[�^�X�c�Z�o
                    userAnswerRecord.AcptAnOdrStatus = SCMDataHelper.GetDefaultAcptAnOdrStatus(userAnswerRecord.InqOrdDivCd);
                    userAnswerRecord.SalesSlipNum = DEFAULT_SALES_SLIP_NUM;                             // 054.����`�[�ԍ��c�����[�g�擾
                    userAnswerRecord.SalesRowNo = userAnswerRecord.InqRowNumDerivedNo;                  // 055.����s�ԍ��c�A�ԕt��(����`�[�ԍ��P��)
                    // HACK:userAnswerRecord.CampaignCode = scmGoodsUnitData.CampaignInformation.CampaignCode;  // 056.�L�����y�[���R�[�h�c�Z�o
                    // HACK:userAnswerRecord.StockDiv = scmGoodsUnitData.GetStockDiv();                         // 057.�݌ɋ敪�c�Z�o
                    userAnswerRecord.StockDiv = (int)StockDiv.None;

                    // 058.�⍇���E������� �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 059.�\������         �cSCM�󒍖��׃f�[�^(�⍇���E����)
                    // 060.���i�Ǘ��ԍ�     �cSCM�󒍖��׃f�[�^(�⍇���E����)
                }
                // ADD 2013/03/07 SCM��Q��10489�Ή� ----------------------------------------------------------->>>>>
                // �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF��������
                answerRecord.AcptAnOdrStatus = answerRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry)
                    ?
                (int)AcptAnOdrStatus.Estimate : (int)AcptAnOdrStatus.Order;
                // �i���݂̂ŕi�Ԍ����ł��Ȃ�������
                if (userAnswerRecord.GoodsNo.Length.Equals(0) && !userAnswerRecord.InqGoodsName.Length.Equals(0))
                {
                    // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // userAnswerRecord.AnswerDeliveryDate = scmGoodsUnitData.GetAnswerDeliveryDate((int)FuwioutAutoAnsDiv.None); // 028.�񓚔[���cSCM�[���ݒ�}�X�^
                    Int16 ansDeliDateDiv = 0;
                    userAnswerRecord.AnswerDeliveryDate = scmGoodsUnitData.GetAnswerDeliveryDate((int)FuwioutAutoAnsDiv.None,out ansDeliDateDiv); // 028.�񓚔[���cSCM�[���ݒ�}�X�^
                    userAnswerRecord.AnsDeliDateDiv = ansDeliDateDiv;   // �񓚔[���敪
                    // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                }
                // ADD 2013/03/07 SCM��Q��10489�Ή� -----------------------------------------------------------<<<<<
                return userAnswerRecord;
            }   // if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // �i�Ԍ����Ńq�b�g���Ȃ������ꍇ
            // DEL 2010/04/20 �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF�������� ---------->>>>>
            //return base.EditSCMOrderAnswerRecord(answerRecord, scmGoodsUnitData);
            // DEL 2010/04/20 �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF�������� ----------<<<<<
            // ADD 2010/04/20 �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF�������� ---------->>>>>
            base.EditSCMOrderAnswerRecord(answerRecord, scmGoodsUnitData);

            // �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF��������
            answerRecord.AcptAnOdrStatus = answerRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry)
                ?
            (int)AcptAnOdrStatus.Estimate : (int)AcptAnOdrStatus.Order;
            
            return answerRecord;
            // ADD 2010/04/20 �蓮�񓚂̏ꍇ�A�󒍃X�e�[�^�X�� �⍇���E������ʁF�⍇�������ρA�⍇���E������ʁF�������� ----------<<<<<
        }

        #endregion // <SCM�󒍖��׃f�[�^(��)>

        // ���i�Ԍ����Ńq�b�g���Ȃ������ꍇ���܂�
        #region <���㖾�׃f�[�^>

        /// <summary>
        /// ���㖾�׃f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="scmGoodsUnitData">SCM�p�̏��t���i�A���f�[�^</param>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <param name="carRecord">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h</param>
        /// <param name="enmDetailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <returns>���㖾�׃f�[�^</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override SalesDetail CreateSalesDetail(
            SCMGoodsUnitData scmGoodsUnitData,
            ISCMOrderAnswerRecord answerRecord,
            ISCMOrderHeaderRecord headerRecord,
            ISCMOrderCarRecord carRecord
          , ISCMOrderDetailRecord enmDetailRecord // ADD 2014/01/16 T.Miyamoto
        )
        {
            // ----ADD 2013/02/18 wangqx �Ǘ���267---- >>>>>
            DateTime getServerNowTime;
            SalesSlipInputAcs salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            getServerNowTime = salesSlipInputAcs.GetServerNowTime;
            // ----ADD 2013/02/18 wangqx �Ǘ���267---- <<<<<

            if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // �i�Ԍ����Ńq�b�g���Ȃ������ꍇ
            {
                UserSCMOrderAnswerRecord userAnswerRecord = answerRecord as UserSCMOrderAnswerRecord;

                // SCM�󒍌n�f�[�^�݂̂Ő�������
                SalesDetail salesDetail = new SalesDetail();
                {
                    // 001.�쐬����         �c���ʃw�b�_�@�����[�g�擾
                    // 002.�X�V����         �c���ʃw�b�_�@�����[�g�擾
                    salesDetail.EnterpriseCode = userAnswerRecord.InqOtherEpCd; // 003.��ƃR�[�h�c���ʃw�b�_�@�����[�g�擾
                    // 004.GUID             �c���ʃw�b�_�@�����[�g�擾
                    // 005.�X�V�]�ƈ��R�[�h �c���ʃw�b�_�@�����[�g�擾
                    // 006.�X�V�A�Z���u��ID1�c���ʃw�b�_�@�����[�g�擾
                    // 007.�X�V�A�Z���u��ID2�c���ʃw�b�_�@�����[�g�擾
                    // 008.�_���폜�敪     �c���ʃw�b�_�@�����[�g�擾

                    // 009.�󒍔ԍ��c�����[�g�擾
                    salesDetail.AcptAnOdrStatus = userAnswerRecord.AcptAnOdrStatus; // 010.�󒍃X�e�[�^�X   �c30:����, 20:��, 10:����
                    salesDetail.SalesSlipNum = DEFAULT_SALES_SLIP_NUM;              // 011.����`�[�ԍ�     �c�����[�g�擾
                    salesDetail.SalesRowNo = userAnswerRecord.InqRowNumDerivedNo;   // 012.����s�ԍ�       �c�A��
                    salesDetail.SalesRowDerivNo = 0;                                // 013.����s�ԍ��}��   �c0
                    salesDetail.SectionCode = userAnswerRecord.InqOtherSecCd;       // 014.���_�R�[�h       �c���O�C�����_
                    salesDetail.SubSectionCode = GetSubSectionCode(headerRecord);   // 015.����R�[�h       �cSCM�󒍃f�[�^�̉񓚏]�ƈ��̏�������R�[�h
                    salesDetail.SalesDate = headerRecord.InquiryDate;               // 016.������t         �cSCM�󒍃f�[�^�̖⍇����
                    // ----ADD 2013/02/18 wangqx �Ǘ���267---- >>>>>
                    // �󒍏ꍇ�A���㖾�׃f�[�^�`�[�̔�����t�̓T�[�o�[���t�Őݒ肷��
                    if (headerRecord.InqOrdDivCd == (int)InqOrdDivCdValue.Ordering)
                    {
                        salesDetail.SalesDate = getServerNowTime;               // 016.������t         �c�V�X�e�����t
                    }
                    // ----ADD 2013/02/18 wangqx �Ǘ���267---- <<<<<
                    // 017.���ʒʔ�     �c�����[�g�擾
                    // 018.���㖾�גʔ� �c�����[�g�擾
                    // 019.�󒍃X�e�[�^�X(��)
                    // 020.���㖾�גʔ�(��)
                    // 021.�d���`��(����)
                    // 022.�d�����גʔ�(��)
                    salesDetail.SalesSlipCdDtl = 0; // 023.����`�[�敪(����)�c0:����
                    // 024.�[�i�����\���

                    // 025.���i���� 
                    salesDetail.GoodsSearchDivCd = 2;                           // 026.���i�����敪         �c2:�����
                    salesDetail.GoodsMakerCd = userAnswerRecord.GoodsMakerCd;   // 027.���i���[�J�[�R�[�h   �cSCM�󒍖��׃f�[�^(�⍇���E����).���i���[�J�[�R�[�h
                    salesDetail.MakerName = userAnswerRecord.GoodsMakerNm;      // 028.���[�J�[����         �cSCM�󒍖��׃f�[�^(�⍇���E����).���i���[�J�[����
                    // 029.���[�J�[�J�i����
                    salesDetail.GoodsNo = userAnswerRecord.GoodsNo;             // 030.���i�ԍ�             �cSCM�󒍖��׃f�[�^(�⍇���E����).���i�ԍ�
                    salesDetail.GoodsName = userAnswerRecord.InqGoodsName;      // 031.���i����             �cSCM�󒍖��׃f�[�^(�⍇���E����).�┭���i��
                    
                    // 032.���i���̃J�i
                    // 033.���i�啪�ރR�[�h
                    // 034.���i�啪�ޖ���
                    // 035.���i�����ރR�[�h
                    // 036.���i�����ޖ���
                    // 037.BL�O���[�v�R�[�h
                    // 038.BL�O���[�v�R�[�h����
                    salesDetail.BLGoodsCode = userAnswerRecord.BLGoodsCode; // 039.BL���i�R�[�h

                    // 040.BL���i�R�[�h����(�S�p)
                    // 041.���Е��ރR�[�h
                    // 042.���Е��ޖ���
                    // 043.�q�ɃR�[�h
                    // 044.�q�ɖ���
                    // 045.�q�ɒI��
                    // 046.����݌Ɏ�񂹋敪
                    // 047.�I�[�v�����i�敪
                    // 048.���i�|�������N

                    salesDetail.CustRateGrpCode = GetCustRateGrpCode(headerRecord, userAnswerRecord.GoodsMakerCd);  // 049.���Ӑ�|���O���[�v�R�[�h �c���Ӑ�|���O���[�v�}�X�^

                    // 050.�艿��
                    // 051.�|���ݒ苒�_(�艿)
                    // 052.�|���ݒ�敪(�艿)
                    // 053.�P���Z�o�敪(�艿)
                    // 054.���i�敪(�艿)
                    // 055.��P��(�艿)
                    // 056.�[�������P��(�艿)
                    // 057.�[������(�艿)
                    salesDetail.ListPriceTaxIncFl = userAnswerRecord.ListPrice; // HACK:058.�艿(�ō�,����)  �c�Z�o
                    salesDetail.ListPriceTaxExcFl = userAnswerRecord.ListPrice; // 059.�艿(�Ŕ�,����)  �cSCM�󒍖��׃f�[�^(�⍇���E����).�艿
                    salesDetail.ListPriceChngCd = 0;                            // 060.�艿�ύX�敪     �c0:�ύX�Ȃ�

                    // 061.������
                    // 062.�|���ݒ苒�_(����)
                    // 063.�|���ݒ�敪(����)
                    // 064.�P���Z�o�敪(����)
                    // 065.���i�敪(����)
                    // 066.��P��(����)
                    // 067.�[�������P��(����)
                    // 068.�[������(����)
                    salesDetail.SalesUnPrcTaxIncFl = userAnswerRecord.UnitPrice;    // HACK:069.����(�ō�,����)  �c�Z�o
                    salesDetail.SalesUnPrcTaxExcFl = userAnswerRecord.UnitPrice;    // 070.����(�Ŕ�,����)  �cSCM�󒍖��׃f�[�^(�⍇���E����).�P��
                    salesDetail.SalesUnPrcChngCd = 0;                               // 071.�����ύX�敪     �c0:�ύX�Ȃ�

                    // 072.������
                    // 073.�|���ݒ苒�_(�����P��)
                    // 074.�|���ݒ�敪(�����P��)
                    // 075.�P���Z�o�敪(�����P��)
                    // 076.���i�敪(�����P��)
                    // 077.��P��(�����P��)
                    // 078.�[�������P��(�����P��)
                    // 079.�[������(�����P��)
                    // 080.�����P��
                    // 081.�����P���ύX�敪

                    // 082.BL���i�R�[�h(�|��)
                    // 083.BL���i�R�[�h����(�|��)
                    // 084.���i�|���O���[�v�R�[�h(�|��)
                    // 085.���i�|���O���[�v����(�|��)
                    // 086.BL�O���[�v�R�[�h(�|��)
                    // 087.BL�O���[�v����(�|��)
                    // 088.BL���i�R�[�h(���)
                    // 088.BL���i�R�[�h(���)
                    // 089.BL���i�R�[�h����(���)
                    // 090.�̔��敪�R�[�h
                    // 091.�̔��敪����
                    // 092.��ƍH��

                    salesDetail.ShipmentCnt = scmGoodsUnitData.SourceDetailRecord.SalesOrderCount;          // 093.�o�א�       �cSCM�󒍖��׃f�[�^(�⍇���E����)�̔�����
                    salesDetail.AcceptAnOrderCnt = scmGoodsUnitData.SourceDetailRecord.SalesOrderCount;     // 094.�󒍐���     �cSCM�󒍖��׃f�[�^(�⍇���E����)�̔�����
                    salesDetail.AcptAnOdrAdjustCnt = 0;                                                     // 095.�󒍒�����   �c0
                    salesDetail.AcptAnOdrRemainCnt = scmGoodsUnitData.SourceDetailRecord.SalesOrderCount;   // 096.�󒍎c��     �cSCM�󒍖��׃f�[�^(�⍇���E����)�̔�����

                    // 097.�c���X�V���c�����[�g�擾

                    // --- DEL 2013/08/07 Y.Wakita ---------->>>>>
                    //salesDetail.SalesMoneyTaxInc = (long)(salesDetail.SalesUnPrcTaxIncFl * salesDetail.ShipmentCnt);    // FIXME:098.������z(�ō���)   �c�Z�o
                    //salesDetail.SalesMoneyTaxExc = (long)(salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt);    // FIXME:099.������z(�Ŕ���)   �c�Z�o
                    // --- DEL 2013/08/07 Y.Wakita ----------<<<<<
                    // --- ADD 2013/08/07 Y.Wakita ---------->>>>>
                    SCMPriceCalculator priceCalculator = new SCMPriceCalculator();

                    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                    //priceCalculator.SetCurrentSCMOrderData(headerRecord.CustomerCode, salesDetail);
                    priceCalculator.SetCurrentSCMOrderData(headerRecord.CustomerCode, salesDetail, headerRecord.CancelDiv, headerRecord.InquiryDate);
                    // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<

                    double salesMoneyTaxInc = 0;
                    double salesMoneyTaxExc = 0;

                    priceCalculator.CalcPrice(salesDetail.TaxationDivCd,
                                              (salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt),
                                              out salesMoneyTaxExc,
                                              out salesMoneyTaxInc);

                    salesDetail.SalesMoneyTaxInc = (long)salesMoneyTaxInc;    // FIXME:098.������z(�ō���)   �c�Z�o
                    salesDetail.SalesMoneyTaxExc = (long)salesMoneyTaxExc;    // FIXME:099.������z(�Ŕ���)   �c�Z�o
                    // --- ADD 2013/08/07 Y.Wakita ----------<<<<<
                    salesDetail.Cost = (long)(salesDetail.SalesUnitCost * salesDetail.ShipmentCnt);                     // FIXME:100.����               �c�Z�o

                    // 101.�e���`�F�b�N�敪

                    salesDetail.SalesGoodsCd = 0;   // 102.���㏤�i�敪�c0:���i
                    salesDetail.SalesPriceConsTax = salesDetail.SalesMoneyTaxInc - salesDetail.SalesMoneyTaxExc;    // 103.������z����Ŋz�c�Z�o
                    salesDetail.TaxationDivCd = 0;   // 104.�ېŋ敪�c0:�ې�

                    // 105.�����`�[�ԍ�(����)
                    // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                    //// 106.���ה��l
                    salesDetail.DtlNote = userAnswerRecord.CommentDtl; // 106.���ה��l �� ���l(����)
                    // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                    // 107.�d����R�[�h
                    // 108.�d���於��
                    // 109.�����ԍ�
                    // 110.�������@
                    // 111.�`�[����1
                    // 112.�`�[����2
                    // 113.�`�[����3
                    // 114.�Г�����1
                    // 115.�Г�����2
                    // 116.�Г�����3

                    salesDetail.BfListPrice = userAnswerRecord.ListPrice;       // 117.�ύX�O�艿�cSCM�󒍖��׃f�[�^(�⍇���E����).�艿
                    salesDetail.BfSalesUnitPrice = userAnswerRecord.UnitPrice;  // 118.�ύX�O�����cSCM�󒍖��׃f�[�^(�⍇���E����).�P��
                    // 119.�ύX�O����

                    // 120.�ꎮ���הԍ�
                    // 121.���[�J�[�R�[�h(�ꎮ)
                    // 122.���[�J�[����(�ꎮ)
                    // 123.���[�J�[�J�i����(�ꎮ)
                    // 124.���i����(�ꎮ)
                    // 125.����(�ꎮ)
                    // 126.����P��(�ꎮ)
                    // 127.������z(�ꎮ)
                    // 128.�����P��(�ꎮ)
                    // 129.�������z(�ꎮ)
                    // 130.�����`�[�ԍ�(�ꎮ)
                    // 131.�ꎮ���l

                    salesDetail.PrtGoodsNo = userAnswerRecord.GoodsNo;          // 132.����p�i��           �cSCM�󒍖��׃f�[�^(�⍇���E����).�i��
                    salesDetail.PrtMakerCode = userAnswerRecord.GoodsMakerCd;   // 133.����p���[�J�[�R�[�h �cSCM�󒍖��׃f�[�^(�⍇���E����).���i���[�J�[�R�[�h
                    salesDetail.PrtMakerName = userAnswerRecord.GoodsMakerNm;   // 134.����p���[�J�[����   �cSCM�󒍖��׃f�[�^(�⍇���E����).���i���[�J�[����

                    // ���׋���GUID
                    salesDetail.DtlRelationGuid = userAnswerRecord.SalesRelationId;
                    // �ԗ�����GUID
                    salesDetail.CarRelationGuid = carRecord.SalesRelationId;
                    // ADD 2013/03/07 SCM��Q��10489 ---------------------------------------------->>>>>
                    salesDetail.AnswerDelivDate = userAnswerRecord.AnswerDeliveryDate; // 138.�񓚔[���@�@�@�@�@�@ �cSCM�󒍖��׃f�[�^(��)
                    // ADD 2013/03/07 SCM��Q��10489 ----------------------------------------------<<<<<
                }
                return salesDetail;
            }   // if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // �i�Ԍ����Ńq�b�g���Ȃ������ꍇ
            // UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
            //return base.CreateSalesDetail(scmGoodsUnitData, answerRecord, headerRecord, carRecord);
            return base.CreateSalesDetail(scmGoodsUnitData, answerRecord, headerRecord, carRecord, enmDetailRecord);
            // UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
        }

        #endregion // </���㖾�׃f�[�^>

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
                ioWriteCtrlOpt.EnterpriseCode = GetEnterpriseCodeIf(ioWriteCtrlOpt.EnterpriseCode); // ��ƃR�[�h

                // ����S�̐ݒ���擾
                SalesTtlSt salesTotalSetting = SalesTtlStDB.Find(
                    ioWriteCtrlOpt.EnterpriseCode,
                    GetSectioncodeIf(string.Empty)
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

        // 2011/02/14 Add >>>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool IsAutoAnswer()
        {
            return false;
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
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<


        #endregion // </Override>

        /// <summary>
        /// ��ƃR�[�h����̏ꍇ�A���O�C����񂩂��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>��ƃR�[�h</returns>
        private static string GetEnterpriseCodeIf(string enterpriseCode)
        {
            return string.IsNullOrEmpty(enterpriseCode.Trim()) ? LoginInfoAcquisition.EnterpriseCode : enterpriseCode;
        }

        /// <summary>
        /// ���_�R�[�h����̏ꍇ�A���O�C����񂩂狒�_�R�[�h���擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_�R�[�h</returns>
        private static string GetSectioncodeIf(string sectionCode)
        {
            return string.IsNullOrEmpty(sectionCode) ? LoginInfoAcquisition.Employee.BelongSectionCode : sectionCode;
        }
    }
}
