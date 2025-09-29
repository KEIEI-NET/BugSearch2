using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMDeliDateStWork
    /// <summary>
    ///                      SCM�[���ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�[���ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/01/06 30517 �Ė� �x��</br>
    /// <br>           : SCM���،��ʑΉ�No.7�@�[���ݒ�����i�E�݌ɕi�ŕʂɐݒ�o����l�ɏC��</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/10/11  ���R</br>
    /// <br>Note       : Redmine #25765</br>
    /// <br>           : �D��݌ɉ񓚔[���敪�A�D��݌ɉ񓚔[���̒ǉ�</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2012/08/30 ���� ��</br>
    /// <br>           : SCM��Q�Ή�No.10345�@�񓚔[���̐ݒ���@��ύX</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/10 �g��</br>
    /// <br>           : SCM������ �񓚔[���敪�Ή�</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMDeliDateStWork : IFileHeader
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

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>0�͑S���Ӑ�</remarks>
        private Int32 _customerCode;

        /// <summary>�񓚒��؎����P</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime1;

        /// <summary>�񓚒��؎����Q</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime2;

        /// <summary>�񓚒��؎����R</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime3;

        /// <summary>�񓚒��؎����S</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime4;

        /// <summary>�񓚒��؎����T</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime5;

        /// <summary>�񓚒��؎����U</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime6;

        /// <summary>�񓚔[���P</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate1 = "";

        /// <summary>�񓚔[���Q</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate2 = "";

        /// <summary>�񓚔[���R</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate3 = "";

        /// <summary>�񓚔[���S</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate4 = "";

        /// <summary>�񓚔[���T</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate5 = "";

        /// <summary>�񓚔[���U</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate6 = "";

        // 2011/01/06 Add >>>
        /// <summary>�񓚒��؎����P�i�݌Ɂj</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime1Stc;

        /// <summary>�񓚒��؎����Q�i�݌Ɂj</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime2Stc;

        /// <summary>�񓚒��؎����R�i�݌Ɂj</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime3Stc;

        /// <summary>�񓚒��؎����S�i�݌Ɂj</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime4Stc;

        /// <summary>�񓚒��؎����T�i�݌Ɂj</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime5Stc;

        /// <summary>�񓚒��؎����U�i�݌Ɂj</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime6Stc;

        /// <summary>�񓚔[���P�i�݌Ɂj</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate1Stc = "";

        /// <summary>�񓚔[���Q�i�݌Ɂj</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate2Stc = "";

        /// <summary>�񓚔[���R�i�݌Ɂj</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate3Stc = "";

        /// <summary>�񓚔[���S�i�݌Ɂj</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate4Stc = "";

        /// <summary>�񓚔[���T�i�݌Ɂj</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate5Stc = "";

        /// <summary>�񓚔[���U�i�݌Ɂj</summary>
        /// <remarks>�P��,�Q��,�ŏI��,������ ���@</remarks>
        private string _answerDelivDate6Stc = "";

        /// <summary>�ϑ��݌ɉ񓚔[���敪</summary>
        /// <remarks>0:�݌ɐݒ�ɏ]���A1:�I�ԁA2:�ϑ��p�ɐݒ�</remarks>
        private Int32 _entStckAnsDeliDtDiv;

        /// <summary>�ϑ��݌ɉ񓚔[��</summary>
        /// <remarks></remarks>
        private string _entStckAnsDeliDate = "";
        // 2011/01/06 Add <<<

        // 2011/10/11 Add >>>
        /// <summary>�D��݌ɉ񓚔[���敪</summary>
        /// <remarks>0:�݌ɐݒ�ɏ]���A1:�D��p�ɐݒ�</remarks>
        private Int32 _priStckAnsDeliDtDiv;

        /// <summary>�D��݌ɉ񓚔[��</summary>
        /// <remarks></remarks>
        private string _priStckAnsDeliDate = "";
        // 2011/10/11 Add <<<

        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�񓚔[���i�݌ɕs���j</summary>
        private string _ansDelDatShortOfStc = "";

        /// <summary>�񓚔[���i�݌ɐ������j</summary>
        private string _ansDelDatWithoutStc = "";

        /// <summary>�ϑ��݌ɉ񓚔[���i�݌ɕs���j</summary>
        private string _entStcAnsDelDatShort = "";

        /// <summary>�ϑ��݌ɉ񓚔[���i�݌ɐ������j</summary>
        private string _entStcAnsDelDatWiout = "";

        /// <summary>�Q�ƍ݌ɉ񓚔[���i�݌ɕs���j</summary>
        private string _priStcAnsDelDatShort = "";

        /// <summary>�Q�ƍ݌ɉ񓚔[���i�݌ɐ������j</summary>
        private string _priStcAnsDelDatWiout = "";
        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�񓚔[���敪�P</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv1;

        /// <summary>�񓚔[���敪�Q</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv2;

        /// <summary>�񓚔[���敪�R</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv3;

        /// <summary>�񓚔[���敪�S</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv4;

        /// <summary>�񓚔[���敪�T</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv5;

        /// <summary>�񓚔[���敪�U</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv6;

        /// <summary>�񓚔[���敪�P�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv1Stc;

        /// <summary>�񓚔[���敪�Q�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv2Stc;

        /// <summary>�񓚔[���敪�R�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv3Stc;

        /// <summary>�񓚔[���敪�S�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv4Stc;

        /// <summary>�񓚔[���敪�T�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv5Stc;

        /// <summary>�񓚔[���敪�U�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtDiv6Stc;

        /// <summary>�ϑ��݌ɉ񓚔[���敪�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _entAnsDelDtStcDiv;

        /// <summary>�D��݌ɉ񓚔[���敪�i�݌Ɂj</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _priAnsDelDtStcDiv;

        /// <summary>�񓚔[���敪�i�݌ɕs���j</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtShoStcDiv;

        /// <summary>�񓚔[���敪�i�݌ɐ������j</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _ansDelDtWioStcDiv;

        /// <summary>�ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _entAnsDelDtShoDiv;

        /// <summary>�ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _entAnsDelDtWioDiv;

        /// <summary>�D��݌ɉ񓚔[���敪�i�݌ɕs���j</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _priAnsDelDtShoDiv;

        /// <summary>�D��݌ɉ񓚔[���敪�i�݌ɐ������j</summary>
        /// <remarks>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</remarks>
        private Int16 _priAnsDelDtWioDiv;
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�͑S���Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  AnswerDeadTime1
        /// <summary>�񓚒��؎����P�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime1
        {
            get { return _answerDeadTime1; }
            set { _answerDeadTime1 = value; }
        }

        /// public propaty name  :  AnswerDeadTime2
        /// <summary>�񓚒��؎����Q�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime2
        {
            get { return _answerDeadTime2; }
            set { _answerDeadTime2 = value; }
        }

        /// public propaty name  :  AnswerDeadTime3
        /// <summary>�񓚒��؎����R�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime3
        {
            get { return _answerDeadTime3; }
            set { _answerDeadTime3 = value; }
        }

        /// public propaty name  :  AnswerDeadTime4
        /// <summary>�񓚒��؎����S�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime4
        {
            get { return _answerDeadTime4; }
            set { _answerDeadTime4 = value; }
        }

        /// public propaty name  :  AnswerDeadTime5
        /// <summary>�񓚒��؎����T�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime5
        {
            get { return _answerDeadTime5; }
            set { _answerDeadTime5 = value; }
        }

        /// public propaty name  :  AnswerDeadTime6
        /// <summary>�񓚒��؎����U�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime6
        {
            get { return _answerDeadTime6; }
            set { _answerDeadTime6 = value; }
        }

        /// public propaty name  :  AnswerDelivDate1
        /// <summary>�񓚔[���P�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate1
        {
            get { return _answerDelivDate1; }
            set { _answerDelivDate1 = value; }
        }

        /// public propaty name  :  AnswerDelivDate2
        /// <summary>�񓚔[���Q�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate2
        {
            get { return _answerDelivDate2; }
            set { _answerDelivDate2 = value; }
        }

        /// public propaty name  :  AnswerDelivDate3
        /// <summary>�񓚔[���R�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate3
        {
            get { return _answerDelivDate3; }
            set { _answerDelivDate3 = value; }
        }

        /// public propaty name  :  AnswerDelivDate4
        /// <summary>�񓚔[���S�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate4
        {
            get { return _answerDelivDate4; }
            set { _answerDelivDate4 = value; }
        }

        /// public propaty name  :  AnswerDelivDate5
        /// <summary>�񓚔[���T�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate5
        {
            get { return _answerDelivDate5; }
            set { _answerDelivDate5 = value; }
        }

        /// public propaty name  :  AnswerDelivDate6
        /// <summary>�񓚔[���U�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate6
        {
            get { return _answerDelivDate6; }
            set { _answerDelivDate6 = value; }
        }

        // 2011/01/06 Add >>>
        /// public propaty name  :  AnswerDeadTime1Stc
        /// <summary>�񓚒��؎����P�i�݌Ɂj�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����P�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime1Stc
        {
            get { return _answerDeadTime1Stc; }
            set { _answerDeadTime1Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime2Stc
        /// <summary>�񓚒��؎����Q�i�݌Ɂj�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����Q�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime2Stc
        {
            get { return _answerDeadTime2Stc; }
            set { _answerDeadTime2Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime3Stc
        /// <summary>�񓚒��؎����R�i�݌Ɂj�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����R�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime3Stc
        {
            get { return _answerDeadTime3Stc; }
            set { _answerDeadTime3Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime4Stc
        /// <summary>�񓚒��؎����S�i�݌Ɂj�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����S�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime4Stc
        {
            get { return _answerDeadTime4Stc; }
            set { _answerDeadTime4Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime5Stc
        /// <summary>�񓚒��؎����T�i�݌Ɂj�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����T�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime5Stc
        {
            get { return _answerDeadTime5Stc; }
            set { _answerDeadTime5Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime6Stc
        /// <summary>�񓚒��؎����U�i�݌Ɂj�v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒��؎����U�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDeadTime6Stc
        {
            get { return _answerDeadTime6Stc; }
            set { _answerDeadTime6Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate1Stc
        /// <summary>�񓚔[���P�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���P�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate1Stc
        {
            get { return _answerDelivDate1Stc; }
            set { _answerDelivDate1Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate2Stc
        /// <summary>�񓚔[���Q�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���Q�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate2Stc
        {
            get { return _answerDelivDate2Stc; }
            set { _answerDelivDate2Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate3Stc
        /// <summary>�񓚔[���R�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���R�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate3Stc
        {
            get { return _answerDelivDate3Stc; }
            set { _answerDelivDate3Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate4Stc
        /// <summary>�񓚔[���S�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���S�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate4Stc
        {
            get { return _answerDelivDate4Stc; }
            set { _answerDelivDate4Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate5Stc
        /// <summary>�񓚔[���T�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���T�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate5Stc
        {
            get { return _answerDelivDate5Stc; }
            set { _answerDelivDate5Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate6Stc
        /// <summary>�񓚔[���U�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�P��,�Q��,�ŏI��,������ ���@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���U�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerDelivDate6Stc
        {
            get { return _answerDelivDate6Stc; }
            set { _answerDelivDate6Stc = value; }
        }

        /// public propaty name  :  EntStckAnsDeliDtDiv
        /// <summary>�ϑ��݌ɉ񓚔[���敪�v���p�e�B</summary>
        /// <value>0:�݌ɐݒ�ɏ]���A1:�I�ԁA2:�ϑ��p�ɐݒ�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EntStckAnsDeliDtDiv
        {
            get { return _entStckAnsDeliDtDiv; }
            set { _entStckAnsDeliDtDiv = value; }
        }

        /// public propaty name  :  EntStckAnsDeliDate
        /// <summary>�ϑ��݌ɉ񓚔[���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EntStckAnsDeliDate
        {
            get { return _entStckAnsDeliDate; }
            set { _entStckAnsDeliDate = value; }
        }
        // 2011/01/06 Add <<<

        // 2011/10/11 Add >>>
        /// public propaty name  :  PriStckAnsDeliDtDiv
        /// <summary>�D��݌ɉ񓚔[���敪�v���p�e�B</summary>
        /// <value>0:�݌ɐݒ�ɏ]���A1:�D��p�ɐݒ�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��݌ɉ񓚔[���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriStckAnsDeliDtDiv
        {
            get { return _priStckAnsDeliDtDiv; }
            set { _priStckAnsDeliDtDiv = value; }
        }

        /// public propaty name  :  PriStckAnsDeliDate
        /// <summary>�D��݌ɉ񓚔[���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��݌ɉ񓚔[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriStckAnsDeliDate
        {
            get { return _priStckAnsDeliDate; }
            set { _priStckAnsDeliDate = value; }
        }
        // 2011/10/11 Add <<<

        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDelDatShortOfStc
        /// <summary>�񓚔[���i�݌ɕs���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���i�݌ɕs���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsDelDatShortOfStc
        {
            get { return _ansDelDatShortOfStc; }
            set { _ansDelDatShortOfStc = value; }
        }

        /// public propaty name  :  AnsDelDatWithoutStc
        /// <summary>�񓚔[���i�݌ɐ������j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���i�݌ɐ������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsDelDatWithoutStc
        {
            get { return _ansDelDatWithoutStc; }
            set { _ansDelDatWithoutStc = value; }
        }

        /// public propaty name  :  EntStcAnsDelDatShort
        /// <summary>�ϑ��݌ɉ񓚔[���i�݌ɕs���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���i�݌ɕs���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EntStcAnsDelDatShort
        {
            get { return _entStcAnsDelDatShort; }
            set { _entStcAnsDelDatShort = value; }
        }

        /// public propaty name  :  EntStcAnsDelDatWiout
        /// <summary>�ϑ��݌ɉ񓚔[���i�݌ɐ������j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���i�݌ɐ������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EntStcAnsDelDatWiout
        {
            get { return _entStcAnsDelDatWiout; }
            set { _entStcAnsDelDatWiout = value; }
        }

        /// public propaty name  :  PriStcAnsDelDatShort
        /// <summary>�Q�ƍ݌ɉ񓚔[���i�݌ɕs���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriStcAnsDelDatShort
        {
            get { return _priStcAnsDelDatShort; }
            set { _priStcAnsDelDatShort = value; }
        }

        /// public propaty name  :  PriStcAnsDelDatWiout
        /// <summary>�Q�ƍ݌ɉ񓚔[���i�݌ɐ������j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriStcAnsDelDatWiout
        {
            get { return _priStcAnsDelDatWiout; }
            set { _priStcAnsDelDatWiout = value; }
        }
        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDelDtDiv1
        /// <summary>�񓚔[���敪�P�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv1
        {
            get { return _ansDelDtDiv1; }
            set { _ansDelDtDiv1 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv2
        /// <summary>�񓚔[���敪�Q�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv2
        {
            get { return _ansDelDtDiv2; }
            set { _ansDelDtDiv2 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv3
        /// <summary>�񓚔[���敪�R�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv3
        {
            get { return _ansDelDtDiv3; }
            set { _ansDelDtDiv3 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv4
        /// <summary>�񓚔[���敪�S�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv4
        {
            get { return _ansDelDtDiv4; }
            set { _ansDelDtDiv4 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv5
        /// <summary>�񓚔[���敪�T�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv5
        {
            get { return _ansDelDtDiv5; }
            set { _ansDelDtDiv5 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv6
        /// <summary>�񓚔[���敪�U�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv6
        {
            get { return _ansDelDtDiv6; }
            set { _ansDelDtDiv6 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv1Stc
        /// <summary>�񓚔[���敪�P�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�P�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv1Stc
        {
            get { return _ansDelDtDiv1Stc; }
            set { _ansDelDtDiv1Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv2Stc
        /// <summary>�񓚔[���敪�Q�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�Q�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv2Stc
        {
            get { return _ansDelDtDiv2Stc; }
            set { _ansDelDtDiv2Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv3Stc
        /// <summary>�񓚔[���敪�R�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�R�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv3Stc
        {
            get { return _ansDelDtDiv3Stc; }
            set { _ansDelDtDiv3Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv4Stc
        /// <summary>�񓚔[���敪�S�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�S�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv4Stc
        {
            get { return _ansDelDtDiv4Stc; }
            set { _ansDelDtDiv4Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv5Stc
        /// <summary>�񓚔[���敪�T�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�T�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv5Stc
        {
            get { return _ansDelDtDiv5Stc; }
            set { _ansDelDtDiv5Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv6Stc
        /// <summary>�񓚔[���敪�U�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�U�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtDiv6Stc
        {
            get { return _ansDelDtDiv6Stc; }
            set { _ansDelDtDiv6Stc = value; }
        }

        /// public propaty name  :  EntAnsDelDtStcDiv
        /// <summary>�ϑ��݌ɉ񓚔[���敪�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 EntAnsDelDtStcDiv
        {
            get { return _entAnsDelDtStcDiv; }
            set { _entAnsDelDtStcDiv = value; }
        }

        /// public propaty name  :  PriAnsDelDtStcDiv
        /// <summary>�D��݌ɉ񓚔[���敪�i�݌Ɂj�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��݌ɉ񓚔[���敪�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PriAnsDelDtStcDiv
        {
            get { return _priAnsDelDtStcDiv; }
            set { _priAnsDelDtStcDiv = value; }
        }

        /// public propaty name  :  AnsDelDtShoStcDiv
        /// <summary>�񓚔[���敪�i�݌ɕs���j�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�i�݌ɕs���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtShoStcDiv
        {
            get { return _ansDelDtShoStcDiv; }
            set { _ansDelDtShoStcDiv = value; }
        }

        /// public propaty name  :  AnsDelDtWioStcDiv
        /// <summary>�񓚔[���敪�i�݌ɐ������j�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�i�݌ɐ������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDelDtWioStcDiv
        {
            get { return _ansDelDtWioStcDiv; }
            set { _ansDelDtWioStcDiv = value; }
        }

        /// public propaty name  :  EntAnsDelDtShoDiv
        /// <summary>�ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 EntAnsDelDtShoDiv
        {
            get { return _entAnsDelDtShoDiv; }
            set { _entAnsDelDtShoDiv = value; }
        }

        /// public propaty name  :  EntAnsDelDtWioDiv
        /// <summary>�ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 EntAnsDelDtWioDiv
        {
            get { return _entAnsDelDtWioDiv; }
            set { _entAnsDelDtWioDiv = value; }
        }

        /// public propaty name  :  PriAnsDelDtShoDiv
        /// <summary>�D��݌ɉ񓚔[���敪�i�݌ɕs���j�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��݌ɉ񓚔[���敪�i�݌ɕs���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PriAnsDelDtShoDiv
        {
            get { return _priAnsDelDtShoDiv; }
            set { _priAnsDelDtShoDiv = value; }
        }

        /// public propaty name  :  PriAnsDelDtWioDiv
        /// <summary>�D��݌ɉ񓚔[���敪�i�݌ɐ������j�v���p�e�B</summary>
        /// <value>0:���ݒ�,1:����,2:1��,3:2�`3��,4:1�T��,5:�v�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��݌ɉ񓚔[���敪�i�݌ɐ������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PriAnsDelDtWioDiv
        {
            get { return _priAnsDelDtWioDiv; }
            set { _priAnsDelDtWioDiv = value; }
        }
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// SCM�[���ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMDeliDateStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMDeliDateStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMDeliDateStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMDeliDateStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMDeliDateStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMDeliDateStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMDeliDateStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMDeliDateStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMDeliDateStWork || graph is ArrayList || graph is SCMDeliDateStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMDeliDateStWork).FullName));

            if (graph != null && graph is SCMDeliDateStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMDeliDateStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMDeliDateStWork[])graph).Length;
            }
            else if (graph is SCMDeliDateStWork)
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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�񓚒��؎����P
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime1
            //�񓚒��؎����Q
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime2
            //�񓚒��؎����R
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime3
            //�񓚒��؎����S
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime4
            //�񓚒��؎����T
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime5
            //�񓚒��؎����U
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime6
            //�񓚔[���P
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate1
            //�񓚔[���Q
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate2
            //�񓚔[���R
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate3
            //�񓚔[���S
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate4
            //�񓚔[���T
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate5
            //�񓚔[���U
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate6
            // 2011/01/06 Add >>>
            //�񓚒��؎����P�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime1Stc
            //�񓚒��؎����Q�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime2Stc
            //�񓚒��؎����R�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime3Stc
            //�񓚒��؎����S�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime4Stc
            //�񓚒��؎����T�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime5Stc
            //�񓚒��؎����U�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime6Stc
            //�񓚔[���P�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate1Stc
            //�񓚔[���Q�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate2Stc
            //�񓚔[���R�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate3Stc
            //�񓚔[���S�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate4Stc
            //�񓚔[���T�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate5Stc
            //�񓚔[���U�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate6Stc
            //�ϑ��݌ɉ񓚔[���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EntStckAnsDeliDtDiv
            //�ϑ��݌ɉ񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //EntStckAnsDeliDate
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            //�D��݌ɉ񓚔[���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriStckAnsDeliDtDiv
            //�D��݌ɉ񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //PriStckAnsDeliDate
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            serInfo.MemberInfo.Add(typeof(string)); // AnsDelDatShortOfStc
            serInfo.MemberInfo.Add(typeof(string)); // AnsDelDatWithoutStc
            serInfo.MemberInfo.Add(typeof(string)); // EntStcAnsDelDatShort
            serInfo.MemberInfo.Add(typeof(string)); // EntStcAnsDelDatWiout
            serInfo.MemberInfo.Add(typeof(string)); // PriStcAnsDelDatShort
            serInfo.MemberInfo.Add(typeof(string)); // PriStcAnsDelDatWiout
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //�񓚔[���敪�P
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv1
            //�񓚔[���敪�Q
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv2
            //�񓚔[���敪�R
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv3
            //�񓚔[���敪�S
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv4
            //�񓚔[���敪�T
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv5
            //�񓚔[���敪�U
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv6
            //�񓚔[���敪�P�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv1Stc
            //�񓚔[���敪�Q�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv2Stc
            //�񓚔[���敪�R�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv3Stc
            //�񓚔[���敪�S�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv4Stc
            //�񓚔[���敪�T�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv5Stc
            //�񓚔[���敪�U�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv6Stc
            //�ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //EntAnsDelDtStcDiv
            //�D��݌ɉ񓚔[���敪�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int16)); //PriAnsDelDtStcDiv
            //�񓚔[���敪�i�݌ɕs���j
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtShoStcDiv
            //�񓚔[���敪�i�݌ɐ������j
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtWioStcDiv
            //�ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
            serInfo.MemberInfo.Add(typeof(Int16)); //EntAnsDelDtShoDiv
            //�ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
            serInfo.MemberInfo.Add(typeof(Int16)); //EntAnsDelDtWioDiv
            //�D��݌ɉ񓚔[���敪�i�݌ɕs���j
            serInfo.MemberInfo.Add(typeof(Int16)); //PriAnsDelDtShoDiv
            //�D��݌ɉ񓚔[���敪�i�݌ɐ������j
            serInfo.MemberInfo.Add(typeof(Int16)); //PriAnsDelDtWioDiv
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMDeliDateStWork)
            {
                SCMDeliDateStWork temp = (SCMDeliDateStWork)graph;

                SetSCMDeliDateStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMDeliDateStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMDeliDateStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMDeliDateStWork temp in lst)
                {
                    SetSCMDeliDateStWork(writer, temp);
                }

            }


        }

        /// <summary>
        /// SCMDeliDateStWork�����o��(public�v���p�e�B��)
        /// </summary>
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        //// 2011/01/06 >>>
        ////private const int currentMemberCount = 22;
        //// 2011/10/11 >>>
        ////private const int currentMemberCount = 36;
        //// 2012/08/30 UPD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        ////private const int currentMemberCount = 38;
        //private const int currentMemberCount = 44;
        //// 2012/08/30 UPD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// 2011/10/11 <<<
        //// 2011/01/06 <<<
        #endregion
        private const int currentMemberCount = 64;
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///  SCMDeliDateStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMDeliDateStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMDeliDateStWork(System.IO.BinaryWriter writer, SCMDeliDateStWork temp)
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
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�񓚒��؎����P
            writer.Write(temp.AnswerDeadTime1);
            //�񓚒��؎����Q
            writer.Write(temp.AnswerDeadTime2);
            //�񓚒��؎����R
            writer.Write(temp.AnswerDeadTime3);
            //�񓚒��؎����S
            writer.Write(temp.AnswerDeadTime4);
            //�񓚒��؎����T
            writer.Write(temp.AnswerDeadTime5);
            //�񓚒��؎����U
            writer.Write(temp.AnswerDeadTime6);
            //�񓚔[���P
            writer.Write(temp.AnswerDelivDate1);
            //�񓚔[���Q
            writer.Write(temp.AnswerDelivDate2);
            //�񓚔[���R
            writer.Write(temp.AnswerDelivDate3);
            //�񓚔[���S
            writer.Write(temp.AnswerDelivDate4);
            //�񓚔[���T
            writer.Write(temp.AnswerDelivDate5);
            //�񓚔[���U
            writer.Write(temp.AnswerDelivDate6);
            // 2011/01/06 Add >>>
            //�񓚒��؎����P�i�݌Ɂj
            writer.Write(temp.AnswerDeadTime1Stc);
            //�񓚒��؎����Q�i�݌Ɂj
            writer.Write(temp.AnswerDeadTime2Stc);
            //�񓚒��؎����R�i�݌Ɂj
            writer.Write(temp.AnswerDeadTime3Stc);
            //�񓚒��؎����S�i�݌Ɂj
            writer.Write(temp.AnswerDeadTime4Stc);
            //�񓚒��؎����T�i�݌Ɂj
            writer.Write(temp.AnswerDeadTime5Stc);
            //�񓚒��؎����U�i�݌Ɂj
            writer.Write(temp.AnswerDeadTime6Stc);
            //�񓚔[���P�i�݌Ɂj
            writer.Write(temp.AnswerDelivDate1Stc);
            //�񓚔[���Q�i�݌Ɂj
            writer.Write(temp.AnswerDelivDate2Stc);
            //�񓚔[���R�i�݌Ɂj
            writer.Write(temp.AnswerDelivDate3Stc);
            //�񓚔[���S�i�݌Ɂj
            writer.Write(temp.AnswerDelivDate4Stc);
            //�񓚔[���T�i�݌Ɂj
            writer.Write(temp.AnswerDelivDate5Stc);
            //�񓚔[���U�i�݌Ɂj
            writer.Write(temp.AnswerDelivDate6Stc);
            //�ϑ��݌ɉ񓚔[���敪
            writer.Write(temp.EntStckAnsDeliDtDiv);
            //�ϑ��݌ɉ񓚔[��
            writer.Write(temp.EntStckAnsDeliDate);
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            //�D��݌ɉ񓚔[���敪
            writer.Write(temp.PriStckAnsDeliDtDiv);
            //�D��݌ɉ񓚔[��
            writer.Write(temp.PriStckAnsDeliDate);
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �񓚔[���i�݌ɕs���j
            writer.Write(temp.AnsDelDatShortOfStc);
            // �񓚔[���i�݌ɐ������j
            writer.Write(temp.AnsDelDatWithoutStc);
            // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
            writer.Write(temp.EntStcAnsDelDatShort);
            // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
            writer.Write(temp.EntStcAnsDelDatWiout);
            // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
            writer.Write(temp.PriStcAnsDelDatShort);
            // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
            writer.Write(temp.PriStcAnsDelDatWiout);
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //�񓚔[���敪�P
            writer.Write(temp.AnsDelDtDiv1);
            //�񓚔[���敪�Q
            writer.Write(temp.AnsDelDtDiv2);
            //�񓚔[���敪�R
            writer.Write(temp.AnsDelDtDiv3);
            //�񓚔[���敪�S
            writer.Write(temp.AnsDelDtDiv4);
            //�񓚔[���敪�T
            writer.Write(temp.AnsDelDtDiv5);
            //�񓚔[���敪�U
            writer.Write(temp.AnsDelDtDiv6);
            //�񓚔[���敪�P�i�݌Ɂj
            writer.Write(temp.AnsDelDtDiv1Stc);
            //�񓚔[���敪�Q�i�݌Ɂj
            writer.Write(temp.AnsDelDtDiv2Stc);
            //�񓚔[���敪�R�i�݌Ɂj
            writer.Write(temp.AnsDelDtDiv3Stc);
            //�񓚔[���敪�S�i�݌Ɂj
            writer.Write(temp.AnsDelDtDiv4Stc);
            //�񓚔[���敪�T�i�݌Ɂj
            writer.Write(temp.AnsDelDtDiv5Stc);
            //�񓚔[���敪�U�i�݌Ɂj
            writer.Write(temp.AnsDelDtDiv6Stc);
            //�ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
            writer.Write(temp.EntAnsDelDtStcDiv);
            //�D��݌ɉ񓚔[���敪�i�݌Ɂj
            writer.Write(temp.PriAnsDelDtStcDiv);
            //�񓚔[���敪�i�݌ɕs���j
            writer.Write(temp.AnsDelDtShoStcDiv);
            //�񓚔[���敪�i�݌ɐ������j
            writer.Write(temp.AnsDelDtWioStcDiv);
            //�ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
            writer.Write(temp.EntAnsDelDtShoDiv);
            //�ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
            writer.Write(temp.EntAnsDelDtWioDiv);
            //�D��݌ɉ񓚔[���敪�i�݌ɕs���j
            writer.Write(temp.PriAnsDelDtShoDiv);
            //�D��݌ɉ񓚔[���敪�i�݌ɐ������j
            writer.Write(temp.PriAnsDelDtWioDiv);
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        ///  SCMDeliDateStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMDeliDateStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMDeliDateStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMDeliDateStWork GetSCMDeliDateStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMDeliDateStWork temp = new SCMDeliDateStWork();

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
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�񓚒��؎����P
            temp.AnswerDeadTime1 = reader.ReadInt32();
            //�񓚒��؎����Q
            temp.AnswerDeadTime2 = reader.ReadInt32();
            //�񓚒��؎����R
            temp.AnswerDeadTime3 = reader.ReadInt32();
            //�񓚒��؎����S
            temp.AnswerDeadTime4 = reader.ReadInt32();
            //�񓚒��؎����T
            temp.AnswerDeadTime5 = reader.ReadInt32();
            //�񓚒��؎����U
            temp.AnswerDeadTime6 = reader.ReadInt32();
            //�񓚔[���P
            temp.AnswerDelivDate1 = reader.ReadString();
            //�񓚔[���Q
            temp.AnswerDelivDate2 = reader.ReadString();
            //�񓚔[���R
            temp.AnswerDelivDate3 = reader.ReadString();
            //�񓚔[���S
            temp.AnswerDelivDate4 = reader.ReadString();
            //�񓚔[���T
            temp.AnswerDelivDate5 = reader.ReadString();
            //�񓚔[���U
            temp.AnswerDelivDate6 = reader.ReadString();
            // 2011/01/06 Add >>>
            //�񓚒��؎����P�i�݌Ɂj
            temp.AnswerDeadTime1Stc = reader.ReadInt32();
            //�񓚒��؎����Q�i�݌Ɂj
            temp.AnswerDeadTime2Stc = reader.ReadInt32();
            //�񓚒��؎����R�i�݌Ɂj
            temp.AnswerDeadTime3Stc = reader.ReadInt32();
            //�񓚒��؎����S�i�݌Ɂj
            temp.AnswerDeadTime4Stc = reader.ReadInt32();
            //�񓚒��؎����T�i�݌Ɂj
            temp.AnswerDeadTime5Stc = reader.ReadInt32();
            //�񓚒��؎����U�i�݌Ɂj
            temp.AnswerDeadTime6Stc = reader.ReadInt32();
            //�񓚔[���P�i�݌Ɂj
            temp.AnswerDelivDate1Stc = reader.ReadString();
            //�񓚔[���Q�i�݌Ɂj
            temp.AnswerDelivDate2Stc = reader.ReadString();
            //�񓚔[���R�i�݌Ɂj
            temp.AnswerDelivDate3Stc = reader.ReadString();
            //�񓚔[���S�i�݌Ɂj
            temp.AnswerDelivDate4Stc = reader.ReadString();
            //�񓚔[���T�i�݌Ɂj
            temp.AnswerDelivDate5Stc = reader.ReadString();
            //�񓚔[���U�i�݌Ɂj
            temp.AnswerDelivDate6Stc = reader.ReadString();
            //�ϑ��݌ɉ񓚔[���敪
            temp.EntStckAnsDeliDtDiv = reader.ReadInt32();
            //�ϑ��݌ɉ񓚔[��
            temp.EntStckAnsDeliDate = reader.ReadString();
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            //�D��݌ɉ񓚔[���敪
            temp.PriStckAnsDeliDtDiv = reader.ReadInt32();
            //�D��݌ɉ񓚔[��
            temp.PriStckAnsDeliDate = reader.ReadString();
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �񓚔[���i�݌ɕs���j
            temp.AnsDelDatShortOfStc = reader.ReadString();
            // �񓚔[���i�݌ɐ������j
            temp.AnsDelDatWithoutStc = reader.ReadString();
            // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
            temp.EntStcAnsDelDatShort = reader.ReadString();
            // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
            temp.EntStcAnsDelDatWiout = reader.ReadString();
            // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
            temp.PriStcAnsDelDatShort = reader.ReadString();
            // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
            temp.PriStcAnsDelDatWiout = reader.ReadString();
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //�񓚔[���敪�P
            temp.AnsDelDtDiv1 = reader.ReadInt16();
            //�񓚔[���敪�Q
            temp.AnsDelDtDiv2 = reader.ReadInt16();
            //�񓚔[���敪�R
            temp.AnsDelDtDiv3 = reader.ReadInt16();
            //�񓚔[���敪�S
            temp.AnsDelDtDiv4 = reader.ReadInt16();
            //�񓚔[���敪�T
            temp.AnsDelDtDiv5 = reader.ReadInt16();
            //�񓚔[���敪�U
            temp.AnsDelDtDiv6 = reader.ReadInt16();
            //�񓚔[���敪�P�i�݌Ɂj
            temp.AnsDelDtDiv1Stc = reader.ReadInt16();
            //�񓚔[���敪�Q�i�݌Ɂj
            temp.AnsDelDtDiv2Stc = reader.ReadInt16();
            //�񓚔[���敪�R�i�݌Ɂj
            temp.AnsDelDtDiv3Stc = reader.ReadInt16();
            //�񓚔[���敪�S�i�݌Ɂj
            temp.AnsDelDtDiv4Stc = reader.ReadInt16();
            //�񓚔[���敪�T�i�݌Ɂj
            temp.AnsDelDtDiv5Stc = reader.ReadInt16();
            //�񓚔[���敪�U�i�݌Ɂj
            temp.AnsDelDtDiv6Stc = reader.ReadInt16();
            //�ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
            temp.EntAnsDelDtStcDiv = reader.ReadInt16();
            //�D��݌ɉ񓚔[���敪�i�݌Ɂj
            temp.PriAnsDelDtStcDiv = reader.ReadInt16();
            //�񓚔[���敪�i�݌ɕs���j
            temp.AnsDelDtShoStcDiv = reader.ReadInt16();
            //�񓚔[���敪�i�݌ɐ������j
            temp.AnsDelDtWioStcDiv = reader.ReadInt16();
            //�ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
            temp.EntAnsDelDtShoDiv = reader.ReadInt16();
            //�ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
            temp.EntAnsDelDtWioDiv = reader.ReadInt16();
            //�D��݌ɉ񓚔[���敪�i�݌ɕs���j
            temp.PriAnsDelDtShoDiv = reader.ReadInt16();
            //�D��݌ɉ񓚔[���敪�i�݌ɐ������j
            temp.PriAnsDelDtWioDiv = reader.ReadInt16();
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
        /// <returns>SCMDeliDateStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMDeliDateStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMDeliDateStWork temp = GetSCMDeliDateStWork(reader, serInfo);
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
                    retValue = (SCMDeliDateStWork[])lst.ToArray(typeof(SCMDeliDateStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}