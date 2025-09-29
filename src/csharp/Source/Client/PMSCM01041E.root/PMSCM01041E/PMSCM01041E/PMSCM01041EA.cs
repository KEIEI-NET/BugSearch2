using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SmplInqInf
    /// <summary>
    ///                      �ȒP�⍇��ID���Ǘ��}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ȒP�⍇��ID���Ǘ��}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   ���� �m</br>
    /// <br>Genarated Date   :   2010/04/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SmplInqInf
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�ȒP�⍇��ID�t�����Ǘ��ԍ�</summary>
        /// <remarks>���[�U�[�P�ʂ̘A��</remarks>
        private Int64 _simpleInqIdInfMngNo;

        /// <summary>�ȒP�⍇���A�J�E���gID</summary>
        /// <remarks>(���p�p��)</remarks>
        private string _simplInqAcntAcntId = "";

        /// <summary>�ȒP�⍇���A�J�E���g�p�X���[�h</summary>
        /// <remarks>(���p�̂�)(���p�p��)</remarks>
        private string _simplInqAcntPass = "";


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  SimpleInqIdInfMngNo
        /// <summary>�ȒP�⍇��ID�t�����Ǘ��ԍ��v���p�e�B</summary>
        /// <value>���[�U�[�P�ʂ̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇��ID�t�����Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SimpleInqIdInfMngNo
        {
            get { return _simpleInqIdInfMngNo; }
            set { _simpleInqIdInfMngNo = value; }
        }

        /// public propaty name  :  SimplInqAcntAcntId
        /// <summary>�ȒP�⍇���A�J�E���gID�v���p�e�B</summary>
        /// <value>(���p�p��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇���A�J�E���gID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SimplInqAcntAcntId
        {
            get { return _simplInqAcntAcntId; }
            set { _simplInqAcntAcntId = value; }
        }

        /// public propaty name  :  SimplInqAcntPass
        /// <summary>�ȒP�⍇���A�J�E���g�p�X���[�h�v���p�e�B</summary>
        /// <value>(���p�̂�)(���p�p��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇���A�J�E���g�p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SimplInqAcntPass
        {
            get { return _simplInqAcntPass; }
            set { _simplInqAcntPass = value; }
        }


        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SmplInqInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqInf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqInf()
        {
        }

        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="simpleInqIdInfMngNo">�ȒP�⍇��ID�t�����Ǘ��ԍ�(���[�U�[�P�ʂ̘A��)</param>
        /// <param name="simplInqAcntAcntId">�ȒP�⍇���A�J�E���gID((���p�p��))</param>
        /// <param name="simplInqAcntPass">�ȒP�⍇���A�J�E���g�p�X���[�h((���p�̂�)(���p�p��))</param>
        /// <returns>SmplInqInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqInf�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqInf(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int64 simpleInqIdInfMngNo, string simplInqAcntAcntId, string simplInqAcntPass)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._simpleInqIdInfMngNo = simpleInqIdInfMngNo;
            this._simplInqAcntAcntId = simplInqAcntAcntId;
            this._simplInqAcntPass = simplInqAcntPass;

        }

        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^��������
        /// </summary>
        /// <returns>SmplInqInf�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SmplInqInf�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqInf Clone()
        {
            return new SmplInqInf(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._simpleInqIdInfMngNo, this._simplInqAcntAcntId, this._simplInqAcntPass);
        }

        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SmplInqInf�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqInf�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SmplInqInf target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SimpleInqIdInfMngNo == target.SimpleInqIdInfMngNo )
                 && ( this.SimplInqAcntAcntId == target.SimplInqAcntAcntId )
                 && ( this.SimplInqAcntPass == target.SimplInqAcntPass ) );
        }

        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="smplInqInf1">
        ///                    ��r����SmplInqInf�N���X�̃C���X�^���X
        /// </param>
        /// <param name="smplInqInf2">��r����SmplInqInf�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqInf�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SmplInqInf smplInqInf1, SmplInqInf smplInqInf2)
        {
            return ( ( smplInqInf1.CreateDateTime == smplInqInf2.CreateDateTime )
                 && ( smplInqInf1.UpdateDateTime == smplInqInf2.UpdateDateTime )
                 && ( smplInqInf1.LogicalDeleteCode == smplInqInf2.LogicalDeleteCode )
                 && ( smplInqInf1.SimpleInqIdInfMngNo == smplInqInf2.SimpleInqIdInfMngNo )
                 && ( smplInqInf1.SimplInqAcntAcntId == smplInqInf2.SimplInqAcntAcntId )
                 && ( smplInqInf1.SimplInqAcntPass == smplInqInf2.SimplInqAcntPass ) );
        }
        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SmplInqInf�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqInf�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SmplInqInf target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SimpleInqIdInfMngNo != target.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (this.SimplInqAcntAcntId != target.SimplInqAcntAcntId) resList.Add("SimplInqAcntAcntId");
            if (this.SimplInqAcntPass != target.SimplInqAcntPass) resList.Add("SimplInqAcntPass");

            return resList;
        }

        /// <summary>
        /// �ȒP�⍇��ID���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="smplInqInf1">��r����SmplInqInf�N���X�̃C���X�^���X</param>
        /// <param name="smplInqInf2">��r����SmplInqInf�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqInf�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SmplInqInf smplInqInf1, SmplInqInf smplInqInf2)
        {
            ArrayList resList = new ArrayList();
            if (smplInqInf1.CreateDateTime != smplInqInf2.CreateDateTime) resList.Add("CreateDateTime");
            if (smplInqInf1.UpdateDateTime != smplInqInf2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (smplInqInf1.LogicalDeleteCode != smplInqInf2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (smplInqInf1.SimpleInqIdInfMngNo != smplInqInf2.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (smplInqInf1.SimplInqAcntAcntId != smplInqInf2.SimplInqAcntAcntId) resList.Add("SimplInqAcntAcntId");
            if (smplInqInf1.SimplInqAcntPass != smplInqInf2.SimplInqAcntPass) resList.Add("SimplInqAcntPass");

            return resList;
        }
    }
}
