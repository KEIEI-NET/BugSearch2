using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Operation
    /// <summary>
    ///                      �I�y���[�V�����}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I�y���[�V�����}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/07/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class Operation
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>�J�e�S���R�[�h</summary>
        /// <remarks>0:���i 1:�G���g�� 2:�X�V 3:�Ɖ� 4:���[ 5:�}�X���� 99:���̑�</remarks>
        private Int32 _categoryCode;

        /// <summary>�J�e�S������</summary>
        private string _categoryName = "";

        /// <summary>�J�e�S���\������</summary>
        private Int32 _categoryDspOdr;

        /// <summary>�v���O�����h�c</summary>
        /// <remarks>�J�e�S���ݒ�̏ꍇ�� String.Empty</remarks>
        private string _pgId = "";

        /// <summary>�v���O��������</summary>
        /// <remarks>�S�p�ŊǗ�</remarks>
        private string _pgName = "";

        /// <summary>�v���O�����\������</summary>
        private Int32 _pgDspOdr;

        /// <summary>�I�y���[�V�����R�[�h</summary>
        /// <remarks>�v���O�������ɍ̔�</remarks>
        private Int32 _operationCode;

        /// <summary>�I�y���[�V��������</summary>
        private string _operationName = "";

        /// <summary>�I�y���[�V�����\������</summary>
        private Int32 _operationDspOdr;


        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  CategoryCode
        /// <summary>�J�e�S���R�[�h�v���p�e�B</summary>
        /// <value>0:���i 1:�G���g�� 2:�X�V 3:�Ɖ� 4:���[ 5:�}�X���� 99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�e�S���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryCode
        {
            get { return _categoryCode; }
            set { _categoryCode = value; }
        }

        /// public propaty name  :  CategoryName
        /// <summary>�J�e�S�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�e�S�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        /// public propaty name  :  CategoryDspOdr
        /// <summary>�J�e�S���\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�e�S���\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryDspOdr
        {
            get { return _categoryDspOdr; }
            set { _categoryDspOdr = value; }
        }

        /// public propaty name  :  PgId
        /// <summary>�v���O�����h�c�v���p�e�B</summary>
        /// <value>�J�e�S���ݒ�̏ꍇ�� String.Empty</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���O�����h�c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PgId
        {
            get { return _pgId; }
            set { _pgId = value; }
        }

        /// public propaty name  :  PgName
        /// <summary>�v���O�������̃v���p�e�B</summary>
        /// <value>�S�p�ŊǗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���O�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PgName
        {
            get { return _pgName; }
            set { _pgName = value; }
        }

        /// public propaty name  :  PgDspOdr
        /// <summary>�v���O�����\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���O�����\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PgDspOdr
        {
            get { return _pgDspOdr; }
            set { _pgDspOdr = value; }
        }

        /// public propaty name  :  OperationCode
        /// <summary>�I�y���[�V�����R�[�h�v���p�e�B</summary>
        /// <value>�v���O�������ɍ̔�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�y���[�V�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OperationCode
        {
            get { return _operationCode; }
            set { _operationCode = value; }
        }

        /// public propaty name  :  OperationName
        /// <summary>�I�y���[�V�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�y���[�V�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OperationName
        {
            get { return _operationName; }
            set { _operationName = value; }
        }

        /// public propaty name  :  OperationDspOdr
        /// <summary>�I�y���[�V�����\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�y���[�V�����\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OperationDspOdr
        {
            get { return _operationDspOdr; }
            set { _operationDspOdr = value; }
        }


        /// <summary>
        /// �I�y���[�V�����}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>Operation�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Operation�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Operation()
        {
        }

        /// <summary>
        /// �I�y���[�V�����}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="offerDate">�񋟓��t(YYYYMMDD)</param>
        /// <param name="categoryCode">�J�e�S���R�[�h(0:���i 1:�G���g�� 2:�X�V 3:�Ɖ� 4:���[ 5:�}�X���� 99:���̑�)</param>
        /// <param name="categoryName">�J�e�S������</param>
        /// <param name="categoryDspOdr">�J�e�S���\������</param>
        /// <param name="pgId">�v���O�����h�c(�J�e�S���ݒ�̏ꍇ�� String.Empty)</param>
        /// <param name="pgName">�v���O��������(�S�p�ŊǗ�)</param>
        /// <param name="pgDspOdr">�v���O�����\������</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h(�v���O�������ɍ̔�)</param>
        /// <param name="operationName">�I�y���[�V��������</param>
        /// <param name="operationDspOdr">�I�y���[�V�����\������</param>
        /// <returns>Operation�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Operation�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Operation(Int32 offerDate, Int32 categoryCode, string categoryName, Int32 categoryDspOdr, string pgId, string pgName, Int32 pgDspOdr, Int32 operationCode, string operationName, Int32 operationDspOdr)
        {
            this._offerDate = offerDate;
            this._categoryCode = categoryCode;
            this._categoryName = categoryName;
            this._categoryDspOdr = categoryDspOdr;
            this._pgId = pgId;
            this._pgName = pgName;
            this._pgDspOdr = pgDspOdr;
            this._operationCode = operationCode;
            this._operationName = operationName;
            this._operationDspOdr = operationDspOdr;

        }

        /// <summary>
        /// �I�y���[�V�����}�X�^��������
        /// </summary>
        /// <returns>Operation�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Operation�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Operation Clone()
        {
            return new Operation(this._offerDate, this._categoryCode, this._categoryName, this._categoryDspOdr, this._pgId, this._pgName, this._pgDspOdr, this._operationCode, this._operationName, this._operationDspOdr);
        }

        /// <summary>
        /// �I�y���[�V�����}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Operation�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Operation�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(Operation target)
        {
            return ((this.OfferDate == target.OfferDate)
                 && (this.CategoryCode == target.CategoryCode)
                 && (this.CategoryName == target.CategoryName)
                 && (this.CategoryDspOdr == target.CategoryDspOdr)
                 && (this.PgId == target.PgId)
                 && (this.PgName == target.PgName)
                 && (this.PgDspOdr == target.PgDspOdr)
                 && (this.OperationCode == target.OperationCode)
                 && (this.OperationName == target.OperationName)
                 && (this.OperationDspOdr == target.OperationDspOdr));
        }

        /// <summary>
        /// �I�y���[�V�����}�X�^��r����
        /// </summary>
        /// <param name="operation1">
        ///                    ��r����Operation�N���X�̃C���X�^���X
        /// </param>
        /// <param name="operation2">��r����Operation�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Operation�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(Operation operation1, Operation operation2)
        {
            return ((operation1.OfferDate == operation2.OfferDate)
                 && (operation1.CategoryCode == operation2.CategoryCode)
                 && (operation1.CategoryName == operation2.CategoryName)
                 && (operation1.CategoryDspOdr == operation2.CategoryDspOdr)
                 && (operation1.PgId == operation2.PgId)
                 && (operation1.PgName == operation2.PgName)
                 && (operation1.PgDspOdr == operation2.PgDspOdr)
                 && (operation1.OperationCode == operation2.OperationCode)
                 && (operation1.OperationName == operation2.OperationName)
                 && (operation1.OperationDspOdr == operation2.OperationDspOdr));
        }
        /// <summary>
        /// �I�y���[�V�����}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Operation�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Operation�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(Operation target)
        {
            ArrayList resList = new ArrayList();
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.CategoryCode != target.CategoryCode) resList.Add("CategoryCode");
            if (this.CategoryName != target.CategoryName) resList.Add("CategoryName");
            if (this.CategoryDspOdr != target.CategoryDspOdr) resList.Add("CategoryDspOdr");
            if (this.PgId != target.PgId) resList.Add("PgId");
            if (this.PgName != target.PgName) resList.Add("PgName");
            if (this.PgDspOdr != target.PgDspOdr) resList.Add("PgDspOdr");
            if (this.OperationCode != target.OperationCode) resList.Add("OperationCode");
            if (this.OperationName != target.OperationName) resList.Add("OperationName");
            if (this.OperationDspOdr != target.OperationDspOdr) resList.Add("OperationDspOdr");

            return resList;
        }

        /// <summary>
        /// �I�y���[�V�����}�X�^��r����
        /// </summary>
        /// <param name="operation1">��r����Operation�N���X�̃C���X�^���X</param>
        /// <param name="operation2">��r����Operation�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Operation�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(Operation operation1, Operation operation2)
        {
            ArrayList resList = new ArrayList();
            if (operation1.OfferDate != operation2.OfferDate) resList.Add("OfferDate");
            if (operation1.CategoryCode != operation2.CategoryCode) resList.Add("CategoryCode");
            if (operation1.CategoryName != operation2.CategoryName) resList.Add("CategoryName");
            if (operation1.CategoryDspOdr != operation2.CategoryDspOdr) resList.Add("CategoryDspOdr");
            if (operation1.PgId != operation2.PgId) resList.Add("PgId");
            if (operation1.PgName != operation2.PgName) resList.Add("PgName");
            if (operation1.PgDspOdr != operation2.PgDspOdr) resList.Add("PgDspOdr");
            if (operation1.OperationCode != operation2.OperationCode) resList.Add("OperationCode");
            if (operation1.OperationName != operation2.OperationName) resList.Add("OperationName");
            if (operation1.OperationDspOdr != operation2.OperationDspOdr) resList.Add("OperationDspOdr");

            return resList;
        }
    }
}
