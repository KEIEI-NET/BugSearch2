using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMTtlStWork
    /// <summary>
    ///                      SCM�S�̐ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�S�̐ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/07/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/5/12  ����</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :   ���V�X�e���A�g�t�H���_</br>
    /// <br>Update Note      :   2009/5/15  ����</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :   �����񓚋敪</br>
    /// <br>Update Note      :   2009/5/28  ����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   0:���Ȃ� 1:����</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���</br>
    /// <br>Update Note      :   2009/7/7  ����</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :   ���Ϗ����s�敪</br>
    /// <br>Update Note      :   2012/08/31  30747 �O�� �L��</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :   �����񓚎��\���敪(2012/10���z�M�\�� SCM��Q��76�̑Ή�)</br>
    /// <br>Update Note      :   2012/11/09 30744 ���� ����q</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :   �����񓚋敪�i�⍇���j�A�����񓚋敪�i�����j</br>
    /// <br>                 :   ��t�]�ƈ��R�[�h�A��t�]�ƈ����́A�[�i�敪�A�[�i�敪����</br>
    /// <br>Update Note      :   2013/02/13 30744 ���� ����q</br>
    /// <br>                 :   ��SCM��Q�Ή� ���ڒǉ� </br>
    /// <br>                 :   �Y���������񓚋敪</br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh</br>
    /// <br>                 :   �z�M���Ȃ��� Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή� </br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangl2</br>
    /// <br>                 :   2013/05/15 �z�M�� Redmine#35269 </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMTtlStWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>����`�[���s�敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>�󒍓`�[���s�敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>���V�X�e���A�g�敪</summary>
        /// <remarks>0:���Ȃ�(PM.NS)�@1:����iPM7SP�j</remarks>
        private Int32 _oldSysCooperatDiv;

        /// <summary>���V�X�e���A�g�t�H���_</summary>
        /// <remarks>�f�t�H���g��"C:\SCMSHARE"</remarks>
        private string _oldSysCoopFolder = "";

        /// <summary>BL�R�[�h�ϊ��敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _bLCodeChgDiv;

        /// <summary>�����A�g�l��</summary>
        /// <remarks>�l������</remarks>
        private Double _autoCooperatDis;

        /// <summary>�l���K�p�敪</summary>
        /// <remarks>0:���Ȃ� 1:�S�� 2:�O���i�ȊO 3:�d�_�i��</remarks>
        private Int32 _discountApplyCd;

        /// <summary>�����񓚋敪</summary>
        /// <remarks>0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���</remarks>
        private Int32 _autoAnswerDiv;

        /// <summary>���Ϗ����s�敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _estimatePrtDiv;
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// <summary>���W�ԍ�</summary>
        private Int32 _cashRegisterNo;

        /// <summary>��M�����N���Ԋu</summary>
        private Int32 _rcvProcStInterval;

        /// <summary>�̔��敪�ݒ�(�����񓚎�)</summary>
        private Int32 _salesCdStAutoAns;

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�����񓚎��\���敪</summary>
        /// <remarks>0:�g�p���Ȃ�,1:PM�ݒ�ɏ]��,2:�D��,3:����,4:������(1:N),5:������(1:1)</remarks>
        private Int32 _autoAnsHourDspDiv;
        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        /// <summary>�����񓚋敪�i�⍇���j</summary>
        private Int32 _autoAnsInquiryDiv = 0;

        /// <summary>�����񓚋敪�i�����j</summary>
        private Int32 _autoAnsOrderDiv = 0;

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>PM�󒍎҃R�[�h</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>�[�i�敪</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsNm = "";

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
        /// <summary>�Y���������񓚋敪</summary>
        private Int32 _fuwioutAutoAnsDiv = 0;
        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>�f�[�^�X�V�q�ɋ敪</summary>
        /// <remarks>0:�ϑ��q��,1:��Ǒq��</remarks>
        private Int32 _dataUpDateWareHDiv;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // --------------- ADD START 2013.04.11 wangl2 FOR RedMine#35269------>>>> 
        /// <summary>������͎҃R�[�h</summary>
        private string _salesInputCode;
        // --------------- ADD END 2013.04.11 wangl2 FOR RedMine#35269------<<<<<

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>00�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>����`�[���s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>�󒍓`�[���s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍓`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  OldSysCooperatDiv
        /// <summary>���V�X�e���A�g�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�(PM.NS)�@1:����iPM7SP�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���V�X�e���A�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OldSysCooperatDiv
        {
            get { return _oldSysCooperatDiv; }
            set { _oldSysCooperatDiv = value; }
        }

        /// public propaty name  :  OldSysCoopFolder
        /// <summary>���V�X�e���A�g�t�H���_�v���p�e�B</summary>
        /// <value>�f�t�H���g��"C:\SCMSHARE"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���V�X�e���A�g�t�H���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldSysCoopFolder
        {
            get { return _oldSysCoopFolder; }
            set { _oldSysCoopFolder = value; }
        }

        /// public propaty name  :  BLCodeChgDiv
        /// <summary>BL�R�[�h�ϊ��敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�ϊ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCodeChgDiv
        {
            get { return _bLCodeChgDiv; }
            set { _bLCodeChgDiv = value; }
        }

        /// public propaty name  :  AutoCooperatDis
        /// <summary>�����A�g�l���v���p�e�B</summary>
        /// <value>�l������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����A�g�l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AutoCooperatDis
        {
            get { return _autoCooperatDis; }
            set { _autoCooperatDis = value; }
        }

        /// public propaty name  :  DiscountApplyCd
        /// <summary>�l���K�p�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:�S�� 2:�O���i�ȊO 3:�d�_�i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DiscountApplyCd
        {
            get { return _discountApplyCd; }
            set { _discountApplyCd = value; }
        }

        /// public propaty name  :  AutoAnswerDiv
        /// <summary>�����񓚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnswerDiv
        {
            get { return _autoAnswerDiv; }
            set { _autoAnswerDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>���Ϗ����s�敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ����s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  RcvProcStInterval
        /// <summary>��M�����N���Ԋu�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�����N���Ԋu�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RcvProcStInterval
        {
            get { return _rcvProcStInterval; }
            set { _rcvProcStInterval = value; }
        }

        /// public propaty name  :  SalesCdStAutoAns
        /// <summary>�̔��敪�ݒ�(�����񓚎�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�ݒ�(�����񓚎�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCdStAutoAns
        {
            get { return _salesCdStAutoAns; }
            set { _salesCdStAutoAns = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AutoAnsHourDspDiv
        /// <summary>�����񓚎��\���敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ�,1:PM�ݒ�ɏ]��,2:�D��,3:����,4:������(1:N),5:������(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚎��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnsHourDspDiv
        {
            get { return _autoAnsHourDspDiv; }
            set { _autoAnsHourDspDiv = value; }
        }
        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        /// public propaty name  :  AutoAnsInquiryDiv
        /// <summary>�����񓚋敪�i�⍇���j�v���p�e�B</summary>
        /// <value>0:���Ȃ�(�蓮),1:����(�S�Ď�����),2:����(�i�荞�ݎ�������)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�i�⍇���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnsInquiryDiv
        {
            get { return _autoAnsInquiryDiv; }
            set { _autoAnsInquiryDiv = value; }
        }


        /// public propaty name  : AutoAnsOrderDiv
        /// <summary>�����񓚋敪�i�����j�v���p�e�B</summary>
        /// <value>0:���Ȃ�(�蓮),1:����(�S�Ď�����),2:����(�ϑ��݌ɕ��̂ݎ�����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnsOrderDiv
        {
            get { return _autoAnsOrderDiv; }
            set { _autoAnsOrderDiv = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>PM�󒍎҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsNm
        {
            get { return _deliveredGoodsNm; }
            set { _deliveredGoodsNm = value; }
        }
        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
        /// public propaty name  :  FuwioutAutoAnsDiv
        /// <summary>�Y���������񓚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Y���������񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FuwioutAutoAnsDiv
        {
            get { return _fuwioutAutoAnsDiv;  }
            set { _fuwioutAutoAnsDiv = value; }
        }
        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<


        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  DataUpDateWareHDiv
        /// <summary>�f�[�^�X�V�q�ɋ敪�v���p�e�B</summary>
        /// <value>0:�ϑ��q��,1:��Ǒq��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V�q�ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataUpDateWareHDiv
        {
            get { return _dataUpDateWareHDiv; }
            set { _dataUpDateWareHDiv = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // --------------- ADD START 2013.04.11 wangl2 FOR RedMine#35269------>>>> 
        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }
        // --------------- ADD END 2013.04.11 wangl2 FOR RedMine#35269------<<<<<

        /// <summary>
        /// SCM�S�̐ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMTtlStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMTtlStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMTtlStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMTtlStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMTtlStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMTtlStWork || graph is ArrayList || graph is SCMTtlStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMTtlStWork).FullName));

            if (graph != null && graph is SCMTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMTtlStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMTtlStWork[])graph).Length;
            }
            else if (graph is SCMTtlStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrtDiv
            //�󒍓`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrSlipPrtDiv
            //���V�X�e���A�g�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OldSysCooperatDiv
            //���V�X�e���A�g�t�H���_
            serInfo.MemberInfo.Add(typeof(string)); //OldSysCoopFolder
            //BL�R�[�h�ϊ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCodeChgDiv
            //�����A�g�l��
            serInfo.MemberInfo.Add(typeof(Double)); //AutoCooperatDis
            //�l���K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DiscountApplyCd
            //�����񓚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDiv
            //���Ϗ����s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimatePrtDiv
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //���W�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //��M�����N���Ԋu
            serInfo.MemberInfo.Add(typeof(Int32)); //RcvProcStInterval
            //�̔��敪�ݒ�(�����񓚎�)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCdStAutoAns
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnsHourDspDiv
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            //�����񓚋敪�i�⍇���j
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnsInquiryDivRF
            //�����񓚋敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnsOrderDivRF
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //�[�i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //DeliveredGoodsNm
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
            //�Y���������񓚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FuwioutAutoAnsDiv
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //�f�[�^�X�V�q�ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DataUpDateWareHDiv
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // ������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string));// SalesInputCode //ADD 2013.04.11 wangl2 FOR RedMine#35269

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMTtlStWork)
            {
                SCMTtlStWork temp = (SCMTtlStWork)graph;

                SetSCMTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMTtlStWork temp in lst)
                {
                    SetSCMTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMTtlStWork�����o��(public�v���p�e�B��)
        /// </summary>
        //2012/04/20 UPD T.Nishi >>>>>>>>>>
        //private const int currentMemberCount = 18;
        // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //private const int currentMemberCount = 22;
        // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        //private const int currentMemberCount = 23;
        // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
        //private const int currentMemberCount = 29;
        //private const int currentMemberCount = 30;// DEL 2013/02/27 qijh #34752
        // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
        // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<
        // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        //2012/04/20 UPD T.Nishi <<<<<<<<<<
        //private const int currentMemberCount = 31;// ADD 2013/02/27 qijh #34752  // DEL  2013.04.11 wangl2 FOR RedMine#35269
        private const int currentMemberCount = 32;// ADD  2013.04.11 wangl2 FOR RedMine#35269

        /// <summary>
        ///  SCMTtlStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMTtlStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMTtlStWork(System.IO.BinaryWriter writer, SCMTtlStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����`�[���s�敪
            writer.Write(temp.SalesSlipPrtDiv);
            //�󒍓`�[���s�敪
            writer.Write(temp.AcpOdrrSlipPrtDiv);
            //���V�X�e���A�g�敪
            writer.Write(temp.OldSysCooperatDiv);
            //���V�X�e���A�g�t�H���_
            writer.Write(temp.OldSysCoopFolder);
            //BL�R�[�h�ϊ��敪
            writer.Write(temp.BLCodeChgDiv);
            //�����A�g�l��
            writer.Write(temp.AutoCooperatDis);
            //�l���K�p�敪
            writer.Write(temp.DiscountApplyCd);
            //�����񓚋敪
            writer.Write(temp.AutoAnswerDiv);
            //���Ϗ����s�敪
            writer.Write(temp.EstimatePrtDiv);
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //���W�ԍ�
            writer.Write(temp.CashRegisterNo);
            //��M�����N���Ԋu
            writer.Write(temp.RcvProcStInterval);
            //�̔��敪�ݒ�(�����񓚎�)
            writer.Write(temp.SalesCdStAutoAns);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            writer.Write(temp.AutoAnsHourDspDiv);
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            // �����񓚋敪�i�⍇���j
            writer.Write(temp.AutoAnsInquiryDiv);
            // �����񓚋敪�i�����j
            writer.Write(temp.AutoAnsOrderDiv);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //��t�]�ƈ�����
            writer.Write(temp.FrontEmployeeNm);
            //�[�i�敪
            writer.Write(temp.DeliveredGoodsDiv);
            //�[�i�敪����
            writer.Write(temp.DeliveredGoodsNm);
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
            //�Y���������񓚋敪
            writer.Write(temp.FuwioutAutoAnsDiv);
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //�f�[�^�X�V�q�ɋ敪
            writer.Write(temp.DataUpDateWareHDiv);
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // ������͎҃R�[�h
            writer.Write(temp.SalesInputCode);// ADD 2013.04.11 wangl2 FOR RedMine#35269

        }

        /// <summary>
        ///  SCMTtlStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMTtlStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMTtlStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMTtlStWork GetSCMTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMTtlStWork temp = new SCMTtlStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����`�[���s�敪
            temp.SalesSlipPrtDiv = reader.ReadInt32();
            //�󒍓`�[���s�敪
            temp.AcpOdrrSlipPrtDiv = reader.ReadInt32();
            //���V�X�e���A�g�敪
            temp.OldSysCooperatDiv = reader.ReadInt32();
            //���V�X�e���A�g�t�H���_
            temp.OldSysCoopFolder = reader.ReadString();
            //BL�R�[�h�ϊ��敪
            temp.BLCodeChgDiv = reader.ReadInt32();
            //�����A�g�l��
            temp.AutoCooperatDis = reader.ReadDouble();
            //�l���K�p�敪
            temp.DiscountApplyCd = reader.ReadInt32();
            //�����񓚋敪
            temp.AutoAnswerDiv = reader.ReadInt32();
            //���Ϗ����s�敪
            temp.EstimatePrtDiv = reader.ReadInt32();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //���W�ԍ�
            temp.CashRegisterNo = reader.ReadInt32();
            //��M�����N���Ԋu
            temp.RcvProcStInterval = reader.ReadInt32();
            //�̔��敪�ݒ�(�����񓚎�)
            temp.SalesCdStAutoAns = reader.ReadInt32();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�����񓚎��\���敪
            temp.AutoAnsHourDspDiv = reader.ReadInt32();
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            // �����񓚋敪�i�⍇���j
            temp.AutoAnsInquiryDiv = reader.ReadInt32();
            // �����񓚋敪�i�����j
            temp.AutoAnsOrderDiv = reader.ReadInt32();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //�[�i�敪
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //�[�i�敪����
            temp.DeliveredGoodsNm = reader.ReadString();
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
            //�Y���������񓚋敪
            temp.FuwioutAutoAnsDiv = reader.ReadInt32();
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //�f�[�^�X�V�q�ɋ敪
            temp.DataUpDateWareHDiv = reader.ReadInt32();
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // ������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();// ADD 2013.04.11 wangl2 FOR RedMine#35269

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SCMTtlStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMTtlStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMTtlStWork temp = GetSCMTtlStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMTtlStWork[])lst.ToArray(typeof(SCMTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}