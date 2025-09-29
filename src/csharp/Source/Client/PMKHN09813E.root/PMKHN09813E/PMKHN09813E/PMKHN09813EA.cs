//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �|���}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : ���V�@���M
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasShWork �� RateTextShWork
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RateTextShWork
    /// <summary>
    ///                      �|���}�X�^�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/06/12</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
// --- CHG  2015/10/14 ���V�@���M --- >>>>
//  public class StockMasShWork
    public class RateTextShWork
// --- CHG  2015/10/14 ���V�@���M --- <<<<
    {
        # region �� private field ��
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>���_�R�[�h�i�J�n�j</summary>
        private string _sectionCodeSt;

        /// <summary>���_�R�[�h�i�I���j</summary>
        private string _sectionCodeEd;

        /// <summary>�P�����</summary>
        private string _warehouseCodeSt;

        # endregion  �� private field ��

        # region �� public propaty ��
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// ���_�R�[�h�i�J�n�j
        /// </summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }
        /// <summary>
        /// ���_�R�[�h�i�I���j
        /// </summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        /// <summary>
        /// �P�����
        /// </summary>
        public string WarehouseCdSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// �|���}�X�^�i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMasShWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMasShWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
// --- CHG  2015/10/14 ���V�@���M --- >>>>
//      public StockMasShWork()
        public RateTextShWork()
// --- CHG  2015/10/14 ���V�@���M --- <<<<
        {
        }
        # endregion �� Constructor ��
    }
}
