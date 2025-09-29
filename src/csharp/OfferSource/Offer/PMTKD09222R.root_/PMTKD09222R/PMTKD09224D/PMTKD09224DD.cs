using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MergeInfoGetCond
    /// <summary>
    ///                      �}�[�W�Ώێ擾�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �}�[�W�Ώێ擾�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    public class MergeInfoGetCond
    {
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

        /// <summary>�D�ǐݒ�}�X�^�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _prmSetFlg;

        /// <summary>�D�ǐݒ�ύX�}�X�^�����敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _prmSetChgFlg;


        /// public propaty name  :  PMakerFlg
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

        /// public propaty name  :  ModelNameFlg
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

        /// public propaty name  :  GoodsMGroupFlg
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

        /// public propaty name  :  BLGroupFlg
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

        /// public propaty name  :  BLFlg
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

        /*/// public propaty name  :  SupplierFlg
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

        /// public propaty name  :  PartsPosFlg
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

        /// public propaty name  :  PrmSetFlg
        /// <summary>�D�ǐݒ�}�X�^�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�}�X�^�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetFlg
        {
            get { return _prmSetFlg; }
            set { _prmSetFlg = value; }
        }

        /// public propaty name  :  PrmSetChgFlg
        /// <summary>�D�ǐݒ�ύX�}�X�^�����敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ύX�}�X�^�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetChgFlg
        {
            get { return _prmSetChgFlg; }
            set { _prmSetChgFlg = value; }
        }

        /// <summary>
        /// �}�[�W�Ώێ擾�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MergeInfoGetCond�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MergeInfoGetCond�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MergeInfoGetCond()
        {
        }

    }
}
