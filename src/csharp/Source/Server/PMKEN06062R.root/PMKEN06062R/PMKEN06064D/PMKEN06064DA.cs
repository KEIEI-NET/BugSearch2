using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UsrPartsNoSearchCondWork
    /// <summary>
    ///                      ���[�U�[�����������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�U�[�����������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UsrPartsNoSearchCondWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>���i�i��</summary>
        private string _prtsNo = "";

        /// <summary>�����͈�</summary>
        private int _searchRange;

        /// public property name  :  EnterpriseCode
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

        /// public property name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public property name  :  PrtsNo
        /// <summary>���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>
        /// �����͈� [ 0 : ���i���̂�[�f�t�H���g]  1 : ���i���y�уZ�b�g���  2 : �i�Ԍ������� ]
        /// </summary>
        public int SearchRange
        {
            get { return _searchRange; }
            set { _searchRange = value; }
        }

        /// <summary>
        /// ���[�U�[�����������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UsrPartsNoSearchCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UsrPartsNoSearchCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UsrPartsNoSearchCondWork()
        {
        }

        /// <summary>
        /// ���[�U�[�����������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UsrPartsNoSearchCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UsrPartsNoSearchCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UsrPartsNoSearchCondWork(UsrPartsNoSearchCondWork srcObject)
        {
            _enterpriseCode = srcObject.EnterpriseCode;
            _makerCode = srcObject.MakerCode;
            _prtsNo = srcObject.PrtsNo;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public enum UsrSearchFlg
    {
        /// <summary>���[�U�[���i�̂�</summary>
        UsrPartsOnly = 0,
        /// <summary>���[�U�[���i�ƃZ�b�g�擾</summary>
        UsrPartsAndSet = 1,
        /// <summary>���[�U�[�Z�b�g�̂ݎ擾</summary>
        UsrSetOnly = 2,
        /// <summary>���[�U�[���i�ƌ����A�Z�b�g</summary>
        UsrPartsJoinSet = 3,
        /// <summary>���[�U�[���i�A�����A�Z�b�g�A��֑S�Ď擾</summary>
        UsrPartsAndAll = 4
    }
}
