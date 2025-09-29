//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃f�[�^�폜�����A�N�Z�X�N���X
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��č폜�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �񋟍폜�Ώے�`���N���X
    /// </summary>
    /// <remarks>
    /// Note       : �񋟍폜�Ώے�`���ł��B<br />
    /// Programmer : ������<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public class OfferData
    {
        #region �� private Member ��
        private const string TBL_ADDICARSPECTTLRF = "�ǉ��������̃}�X�^";
        private const string TBL_BLGROUPRF = "�a�k�O���[�v�R�[�h�}�X�^";
        private const string TBL_CARMODELRF = "���q�^���}�X�^";
        private const string TBL_CARNRMLEQPRF = "���q�J�^���O�W�������}�X�^";
        private const string TBL_CATEGORYRF = "�ޕʃ}�X�^";
        private const string TBL_CEQPDEFDSPRF = "���q���������\���p�}�X�^";
        private const string TBL_CLGPNOINDXRF = "�J�^���O���i�i�ԃC���f�b�N�X�}�X�^";
        private const string TBL_CLGPNOINFORF = "�J�^���O���i�i�ԏ��}�X�^";
        private const string TBL_CLGPTNOEXCRF = "�J�^���O�i�ԍŐV�i�ԕϊ��}�X�^";
        private const string TBL_COLORCDRF = "�J���[�R�[�h�}�X�^";
        private const string TBL_CTGEQUIPPTRF = "�ޕʑ������i�}�X�^";
        private const string TBL_CTGRYEQUIPRF = "�ޕʑ����}�X�^";
        private const string TBL_CTGYMDLLNKRF = "�ޕʁE���q�^���A�g�}�X�^";
        private const string TBL_GOODSMGROUPRF = "���i�����ރ}�X�^";
        private const string TBL_JOINPARTSRF = "�����}�X�^";
        private const string TBL_JOINSUBSTRF = "������փ}�X�^";
        private const string TBL_MAKERNAMERF = "���[�J�[���̃}�X�^�i�񋟁j";
        private const string TBL_MDLNMSRCHRF = "�Ԏ햼�̌����}�X�^";
        private const string TBL_MODELNAMERF = "�Ԏ햼�̃}�X�^�i�񋟁j";
        private const string TBL_OFRSUPPLIERRF = "�d����}�X�^�i�񋟁j";
        private const string TBL_ORGCARMODELRF = "�I���W�i���^���}�X�^";
        private const string TBL_ORGPARTSNORF = "�I���W�i�����i�}�X�^";
        private const string TBL_PARTSPOSCODERF = "���ʃR�[�h�}�X�^";
        private const string TBL_PARTSSUBSTRF = "���i��փ}�X�^";
        private const string TBL_PLATEMDLLNKRF = "���f���v���[�g���q�^���A�g�}�X�^";
        private const string TBL_PMAKERNMRF = "���i���[�J�[���̃}�X�^�i�񋟁j";
        private const string TBL_POSTNUMBERRF = "�X�֔ԍ��}�X�^";
        private const string TBL_PRDTYPYEARRF = "���Y�N���}�X�^";
        private const string TBL_PRIMEPARTSRF = "�D�Ǖ��i�}�X�^";
        private const string TBL_PRMPRTPRICERF = "�D�ǉ��i�}�X�^";
        private const string TBL_PRMSETNOTERF = "�D�ǐݒ�p���l�}�X�^";
        private const string TBL_PRMSETTINGCHGRF = "�D�ǐݒ�ύX�}�X�^";
        private const string TBL_PRMSETTINGRF = "�D�ǐݒ�}�X�^";
        private const string TBL_PRTSCLRINFRF = "���i�J���[�R�[�h���}�X�^";
        private const string TBL_PRTSEQPINFRF = "���i�������}�X�^";
        private const string TBL_PRTSTRMINFRF = "���i�g�����R�[�h���}�X�^";
        private const string TBL_PTMKRPRICERF = "���i���i�}�X�^";
        private const string TBL_SEARCHPRTCTLRF = "�����i�ڐ���}�X�^";
        private const string TBL_SEARCHPRTNMRF = "�������i���̃}�X�^";
        private const string TBL_SETPARTSRF = "�Z�b�g�}�X�^";
        private const string TBL_SETSUBSTRF = "�Z�b�g��փ}�X�^";
        private const string TBL_TBOSEARCHRF = "TBO�����}�X�^";
        private const string TBL_TBSPARTSCODERF = "�a�k�R�[�h�}�X�^";
        private const string TBL_TRIMCDRF = "�g�����R�[�h�}�X�^";
        private const string TBL_PRIUPDHISRF = "���i�����X�V�����f�[�^";

        private const string TBL_ID_ADDICARSPECTTLRF = "ADDICARSPECTTLRF";
        private const string TBL_ID_BLGROUPRF = "BLGROUPRF";
        private const string TBL_ID_CARMODELRF = "CARMODELRF";
        private const string TBL_ID_CARNRMLEQPRF = "CARNRMLEQPRF";
        private const string TBL_ID_CATEGORYRF = "CATEGORYRF";
        private const string TBL_ID_CEQPDEFDSPRF = "CEQPDEFDSPRF";
        private const string TBL_ID_CLGPNOINDXRF = "CLGPNOINDXRF";
        private const string TBL_ID_CLGPNOINFORF = "CLGPNOINFORF";
        private const string TBL_ID_CLGPTNOEXCRF = "CLGPTNOEXCRF";
        private const string TBL_ID_COLORCDRF = "COLORCDRF";
        private const string TBL_ID_CTGEQUIPPTRF = "CTGEQUIPPTRF";
        private const string TBL_ID_CTGRYEQUIPRF = "CTGRYEQUIPRF";
        private const string TBL_ID_CTGYMDLLNKRF = "CTGYMDLLNKRF";
        private const string TBL_ID_GOODSMGROUPRF = "GOODSMGROUPRF";
        private const string TBL_ID_JOINPARTSRF = "JOINPARTSRF";
        private const string TBL_ID_JOINSUBSTRF = "JOINSUBSTRF";
        private const string TBL_ID_MAKERNAMERF = "MAKERNAMERF";
        private const string TBL_ID_MDLNMSRCHRF = "MDLNMSRCHRF";
        private const string TBL_ID_MODELNAMERF = "MODELNAMERF";
        private const string TBL_ID_OFRSUPPLIERRF = "OFRSUPPLIERRF";
        private const string TBL_ID_ORGCARMODELRF = "ORGCARMODELRF";
        private const string TBL_ID_ORGPARTSNORF = "ORGPARTSNORF";
        private const string TBL_ID_PARTSPOSCODERF = "PARTSPOSCODERF";
        private const string TBL_ID_PARTSSUBSTRF = "PARTSSUBSTRF";
        private const string TBL_ID_PLATEMDLLNKRF = "PLATEMDLLNKRF";
        private const string TBL_ID_PMAKERNMRF = "PMAKERNMRF";
        private const string TBL_ID_POSTNUMBERRF = "POSTNUMBERRF";
        private const string TBL_ID_PRDTYPYEARRF = "PRDTYPYEARRF";
        private const string TBL_ID_PRIMEPARTSRF = "PRIMEPARTSRF";
        private const string TBL_ID_PRMPRTPRICERF = "PRMPRTPRICERF";
        private const string TBL_ID_PRMSETNOTERF = "PRMSETNOTERF";
        private const string TBL_ID_PRMSETTINGCHGRF = "PRMSETTINGCHGRF";
        private const string TBL_ID_PRMSETTINGRF = "PRMSETTINGRF";
        private const string TBL_ID_PRTSCLRINFRF = "PRTSCLRINFRF";
        private const string TBL_ID_PRTSEQPINFRF = "PRTSEQPINFRF";
        private const string TBL_ID_PRTSTRMINFRF = "PRTSTRMINFRF";
        private const string TBL_ID_PTMKRPRICERF = "PTMKRPRICERF";
        private const string TBL_ID_SEARCHPRTCTLRF = "SEARCHPRTCTLRF";
        private const string TBL_ID_SEARCHPRTNMRF = "SEARCHPRTNMRF";
        private const string TBL_ID_SETPARTSRF = "SETPARTSRF";
        private const string TBL_ID_SETSUBSTRF = "SETSUBSTRF";
        private const string TBL_ID_TBOSEARCHRF = "TBOSEARCHRF";
        private const string TBL_ID_TBSPARTSCODERF = "TBSPARTSCODERF";
        private const string TBL_ID_TRIMCDRF = "TRIMCDRF";
        private const string TBL_ID_PRIUPDHISRF = "PRIUPDHISRF";

        private const Int32 OFFERDATA_CODE = 0;
        private const Int32 USERDATA_CODE = 9;

        private string FIELD = string.Empty;

        #endregion

        /// <summary>
        /// ��`�񋟍폜�Ώۏ��
        /// </summary>
        /// <remarks>
        /// Note       : ��`�񋟍폜�Ώۏ��B<br />
        /// Programmer : ������<br />
        /// Date       : 2009.06.16<br />
        /// </remarks>
        public ArrayList GetOfferDataList()
        {
            // �e�e�[�u���Ώ�
            OfferDataDeleteWork _offerDataDeleteWork = null;
            // �e�[�u���Ώۃ��X�g
            ArrayList offerDataList = new ArrayList();

            // �ǉ��������̃}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_ADDICARSPECTTLRF;
            _offerDataDeleteWork.TableID = TBL_ID_ADDICARSPECTTLRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �a�k�O���[�v�R�[�h�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_BLGROUPRF;
            _offerDataDeleteWork.TableID = TBL_ID_BLGROUPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���q�^���}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CARMODELRF;
            _offerDataDeleteWork.TableID = TBL_ID_CARMODELRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���q�J�^���O�W�������}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CARNRMLEQPRF;
            _offerDataDeleteWork.TableID = TBL_ID_CARNRMLEQPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �ޕʃ}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CATEGORYRF;
            _offerDataDeleteWork.TableID = TBL_ID_CATEGORYRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���q���������\���p�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CEQPDEFDSPRF;
            _offerDataDeleteWork.TableID = TBL_ID_CEQPDEFDSPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �J�^���O���i�i�ԃC���f�b�N�X�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CLGPNOINDXRF;
            _offerDataDeleteWork.TableID = TBL_ID_CLGPNOINDXRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �J�^���O���i�i�ԏ��}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CLGPNOINFORF;
            _offerDataDeleteWork.TableID = TBL_ID_CLGPNOINFORF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �J�^���O�i�ԍŐV�i�ԕϊ��}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CLGPTNOEXCRF;
            _offerDataDeleteWork.TableID = TBL_ID_CLGPTNOEXCRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �J���[�R�[�h�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_COLORCDRF;
            _offerDataDeleteWork.TableID = TBL_ID_COLORCDRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �ޕʑ������i�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CTGEQUIPPTRF;
            _offerDataDeleteWork.TableID = TBL_ID_CTGEQUIPPTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �ޕʑ����}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CTGRYEQUIPRF;
            _offerDataDeleteWork.TableID = TBL_ID_CTGRYEQUIPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �ޕʁE���q�^���A�g�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CTGYMDLLNKRF;
            _offerDataDeleteWork.TableID = TBL_ID_CTGYMDLLNKRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i�����ރ}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_GOODSMGROUPRF;
            _offerDataDeleteWork.TableID = TBL_ID_GOODSMGROUPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �����}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_JOINPARTSRF;
            _offerDataDeleteWork.TableID = TBL_ID_JOINPARTSRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ������փ}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_JOINSUBSTRF;
            _offerDataDeleteWork.TableID = TBL_ID_JOINSUBSTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���[�J�[���̃}�X�^�i�񋟁j
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_MAKERNAMERF;
            _offerDataDeleteWork.TableID = TBL_ID_MAKERNAMERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �Ԏ햼�̌����}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_MDLNMSRCHRF;
            _offerDataDeleteWork.TableID = TBL_ID_MDLNMSRCHRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �Ԏ햼�̃}�X�^�i�񋟁j
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_MODELNAMERF;
            _offerDataDeleteWork.TableID = TBL_ID_MODELNAMERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �d����}�X�^�i�񋟁j
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_OFRSUPPLIERRF;
            _offerDataDeleteWork.TableID = TBL_ID_OFRSUPPLIERRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �I���W�i���^���}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_ORGCARMODELRF;
            _offerDataDeleteWork.TableID = TBL_ID_ORGCARMODELRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �I���W�i�����i�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_ORGPARTSNORF;
            _offerDataDeleteWork.TableID = TBL_ID_ORGPARTSNORF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���ʃR�[�h�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PARTSPOSCODERF;
            _offerDataDeleteWork.TableID = TBL_ID_PARTSPOSCODERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i��փ}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PARTSSUBSTRF;
            _offerDataDeleteWork.TableID = TBL_ID_PARTSSUBSTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���f���v���[�g���q�^���A�g�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PLATEMDLLNKRF;
            _offerDataDeleteWork.TableID = TBL_ID_PLATEMDLLNKRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i���[�J�[���̃}�X�^�i�񋟁j
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PMAKERNMRF;
            _offerDataDeleteWork.TableID = TBL_ID_PMAKERNMRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �X�֔ԍ��}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_POSTNUMBERRF;
            _offerDataDeleteWork.TableID = TBL_ID_POSTNUMBERRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���Y�N���}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRDTYPYEARRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRDTYPYEARRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �D�Ǖ��i�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRIMEPARTSRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRIMEPARTSRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �D�ǉ��i�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMPRTPRICERF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMPRTPRICERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �D�ǐݒ�p���l�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMSETNOTERF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMSETNOTERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �D�ǐݒ�ύX�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMSETTINGCHGRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMSETTINGCHGRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �D�ǐݒ�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMSETTINGRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMSETTINGRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i�J���[�R�[�h���}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRTSCLRINFRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRTSCLRINFRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i�������}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRTSEQPINFRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRTSEQPINFRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i�g�����R�[�h���}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRTSTRMINFRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRTSTRMINFRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i���i�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PTMKRPRICERF;
            _offerDataDeleteWork.TableID = TBL_ID_PTMKRPRICERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �����i�ڐ���}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SEARCHPRTCTLRF;
            _offerDataDeleteWork.TableID = TBL_ID_SEARCHPRTCTLRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �������i���̃}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SEARCHPRTNMRF;
            _offerDataDeleteWork.TableID = TBL_ID_SEARCHPRTNMRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �Z�b�g�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SETPARTSRF;
            _offerDataDeleteWork.TableID = TBL_ID_SETPARTSRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �Z�b�g��փ}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SETSUBSTRF;
            _offerDataDeleteWork.TableID = TBL_ID_SETSUBSTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // TBO�����}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_TBOSEARCHRF;
            _offerDataDeleteWork.TableID = TBL_ID_TBOSEARCHRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �a�k�R�[�h�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_TBSPARTSCODERF;
            _offerDataDeleteWork.TableID = TBL_ID_TBSPARTSCODERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // �g�����R�[�h�}�X�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_TRIMCDRF;
            _offerDataDeleteWork.TableID = TBL_ID_TRIMCDRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ���i�����X�V�����f�[�^
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRIUPDHISRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRIUPDHISRF;
            _offerDataDeleteWork.Code = USERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);

            return offerDataList;
        }
    }
}
