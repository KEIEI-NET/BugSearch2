using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MergeCond
    /// <summary>
    ///                      �}�[�W�Ώێ擾�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �}�[�W�Ώێ擾�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
    /// </remarks>
    public class MergeCond
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���i���[�J�[�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _pMakerFlg;

        /// <summary>�Ԏ폈���敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _modelNameFlg;

        /// <summary>���i�����ޏ����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _goodsMGroupFlg;

        /// <summary>BL�O���[�v�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _bLGroupFlg;

        /// <summary>BL�R�[�h�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _bLFlg;

        /*/// <summary>�d����}�X�^�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _supplierFlg;*/

        /// <summary>���ʃ}�X�^�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _partsPosFlg;

        // ADD 2009/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ---------->>>>>
        /// <summary>����</summary>
        public const int DOING_FLG_AS_INT = 1;
        /// <summary>���Ȃ�</summary>
        public const int NOT_DOING_FLG_AS_INT = 0;

        /// <summary>���i���������敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private int _priceRevisionFlg;

        /// <summary>�D�ǐݒ�ύX�}�X�^�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private int _prmSetChgFlg;

        /// <summary>�D�ǐݒ�}�X�^�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private int _prmSetFlg;
        // ADD 2008/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ----------<<<<<

        /// <summary>���i���[�J�[���̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _pMakerNmOwFlg;

        /// <summary>�Ԏ햼�̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _modelNameNmOwFlg;

        /// <summary>���i�����ޖ��̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _goodsMGroupNmOwFlg;

        /// <summary>BL�O���[�v���̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _bLGroupNmOwFlg;

        /// <summary>BL�R�[�h���̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _bLNmOwFlg;

        /// <summary>���ʃ}�X�^���̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _partsPosNmOwFlg;

        // ADD 2009/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ---------->>>>>
        /// <summary>����</summary>
        public const bool DOING_FLG_AS_BOOL = true;
        /// <summary>���Ȃ�</summary>
        public const bool NOT_DOING_FLG_AS_BOOL = !DOING_FLG_AS_BOOL;

        /// <summary>���i�������̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _priceRevisionNmOwFlg;

        /// <summary>�D�ǐݒ�ύX�}�X�^���̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _prmSetChgNmOwFlg;

        /// <summary>�D�ǐݒ�}�X�^���̏㏑���t���O</summary>
        /// <remarks>false:���Ȃ��@true:����</remarks>
        private bool _prmSetNmOwFlg;

        /// <summary>�X�V�Ώۂ̊���t</summary>
        private DateTime _targetDate = DateTime.Now;
        // ADD 2008/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ----------<<<<<

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

        /// public property name  :  PMakerFlg
        /// <summary>���i���[�J�[�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMakerFlg
        {
            get { return _pMakerFlg; }
            set { _pMakerFlg = value; }
        }

        /// public property name  :  ModelNameFlg
        /// <summary>�Ԏ폈���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ폈���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelNameFlg
        {
            get { return _modelNameFlg; }
            set { _modelNameFlg = value; }
        }

        /// public property name  :  GoodsMGroupFlg
        /// <summary>���i�����ޏ����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޏ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroupFlg
        {
            get { return _goodsMGroupFlg; }
            set { _goodsMGroupFlg = value; }
        }

        /// public property name  :  BLGroupFlg
        /// <summary>BL�O���[�v�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupFlg
        {
            get { return _bLGroupFlg; }
            set { _bLGroupFlg = value; }
        }

        /// public property name  :  BLFlg
        /// <summary>BL�R�[�h�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLFlg
        {
            get { return _bLFlg; }
            set { _bLFlg = value; }
        }

        /*/// public property name  :  SupplierFlg
        /// <summary>�d����}�X�^�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����}�X�^�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFlg
        {
            get { return _supplierFlg; }
            set { _supplierFlg = value; }
        }*/

        /// public property name  :  PartsPosFlg
        /// <summary>���ʃ}�X�^�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃ}�X�^�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsPosFlg
        {
            get { return _partsPosFlg; }
            set { _partsPosFlg = value; }
        }

        // ADD 2009/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ---------->>>>>
        /// <summary>
        /// ���i���������敪�v���p�e�B
        /// </summary>
        /// <value>0:���Ȃ��@1:����</value>
        public int PriceRevisionFlg
        {
            get { return _priceRevisionFlg; }
            set { _priceRevisionFlg = value; }
        }

        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^�����敪�v���p�e�B
        /// </summary>
        /// <value>0:���Ȃ��@1:����</value>
        public int PrmSetChgFlg
        {
            get { return _prmSetChgFlg; }
            set { _prmSetChgFlg = value; }
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�����敪�v���p�e�B
        /// </summary>
        /// <value>0:���Ȃ��@1:����</value>
        public int PrmSetFlg
        {
            get { return _prmSetFlg; }
            set { _prmSetFlg = value; }
        }
        // ADD 2008/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ----------<<<<<

        /// public property name  :  PMakerNmOwFlg
        /// <summary>���i���[�J�[���̏㏑���t���O�v���p�e�B</summary>
        /// <value>false:���Ȃ��@true:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���̏㏑���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool PMakerNmOwFlg
        {
            get { return _pMakerNmOwFlg; }
            set { _pMakerNmOwFlg = value; }
        }

        /// public property name  :  ModelNameNmOwFlg
        /// <summary>�Ԏ햼�̖��̏㏑���t���O�v���p�e�B</summary>
        /// <value>false:���Ȃ��@true:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�̖��̏㏑���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool ModelNameNmOwFlg
        {
            get { return _modelNameNmOwFlg; }
            set { _modelNameNmOwFlg = value; }
        }

        /// public property name  :  GoodsMGroupNmOwFlg
        /// <summary>���i�����ޖ��̏㏑���t���O�v���p�e�B</summary>
        /// <value>false:���Ȃ��@true:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̏㏑���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool GoodsMGroupNmOwFlg
        {
            get { return _goodsMGroupNmOwFlg; }
            set { _goodsMGroupNmOwFlg = value; }
        }

        /// public property name  :  BLGroupNmOwFlg
        /// <summary>BL�O���[�v���̏㏑���t���O�v���p�e�B</summary>
        /// <value>false:���Ȃ��@true:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v���̏㏑���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool BLGroupNmOwFlg
        {
            get { return _bLGroupNmOwFlg; }
            set { _bLGroupNmOwFlg = value; }
        }

        /// public property name  :  BLNmOwFlg
        /// <summary>BL�R�[�h���̏㏑���t���O�v���p�e�B</summary>
        /// <value>false:���Ȃ��@true:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h���̏㏑���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool BLNmOwFlg
        {
            get { return _bLNmOwFlg; }
            set { _bLNmOwFlg = value; }
        }

        /// public property name  :  PartsPosNmOwFlg
        /// <summary>���ʃ}�X�^���̏㏑���t���O�v���p�e�B</summary>
        /// <value>false:���Ȃ��@true:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃ}�X�^���̏㏑���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool PartsPosNmOwFlg
        {
            get { return _partsPosNmOwFlg; }
            set { _partsPosNmOwFlg = value; }
        }

        // ADD 2009/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ---------->>>>>
        /// <summary>
        /// ���i�������̏㏑���t���O�v���p�e�B
        /// </summary>
        /// <value>false:���Ȃ��@true:����</value>
        public bool PriceRevisionNmOwFlg
        {
            get { return _priceRevisionNmOwFlg; }
            set { _priceRevisionNmOwFlg = value; }
        }

        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^���̏㏑���t���O�v���p�e�B
        /// </summary>
        /// <value>false:���Ȃ��@true:����</value>
        public bool PrmSetChgNmOwFlg
        {
            get { return _prmSetChgNmOwFlg; }
            set { _prmSetChgNmOwFlg = value; }
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^���̏㏑���t���O�v���p�e�B
        /// </summary>
        /// <value>false:���Ȃ��@true:����</value>
        public bool PrmSetNmOwFlg
        {
            get { return _prmSetNmOwFlg; }
            set { _prmSetNmOwFlg = value; }
        }

        /// <summary>
        /// �X�V�Ώۂ̊���t�v���p�e�B
        /// </summary>
        public DateTime TargetDate
        {
            get { return _targetDate; }
            set { _targetDate = value; }
        }
        // ADD 2008/01/28 �@�\�ǉ��F���i�����A�D�ǐݒ�}�X�^ ----------<<<<<

        /// <summary>
        /// �}�[�W�Ώێ擾�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MergeObjectCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MergeObjectCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MergeCond()
        {
        }
    }
}
