//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�C���|�[�g�j���o�����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :������
// �C �� ��  2012/06/12  �C�����e :10801804-00 ��z�Č��ARedmine#30393 
//                                 ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� :������
// �C �� ��  2012/07/20  �C�����e :��z�Č��ARedmine#30387 
//                                 ��Q�ꗗ�̎w�ENO.108�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_CustomerImportWorkTbl
    /// <summary>
    ///                      ���Ӑ�}�X�^�i�C���|�[�g�j���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^�i�C���|�[�g�j���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/06/12 ������</br>
    /// <br>�Ǘ��ԍ�         :   10801804-00 ��z�Č�</br>
    /// <br>                     Redmine#30393   ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�</br>
    /// <br>Update Note      :   2012/07/20 ������</br>
    /// <br>�Ǘ��ԍ�         :   10801804-00 ��z�Č�</br>
    /// <br>                     Redmine#30387  ��Q�ꗗ�̎w�ENO.108�̑Ή�</br>
    /// </remarks>
    public class ExtrInfo_CustomerImportWorkTbl
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�����敪</summary>
        private Int32 _processKbn;

        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
        /// <summary>�`�F�b�N�敪</summary>
        private Int32 _checkKbn;
        // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<

        /// <summary>CSV�f�[�^��񃊃X�g</summary>
        private List<string[]> _csvDataInfoList;

        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        /// <summary>�G���[���O�t�@�C����</summary>
        private string _errorLogFileName;
        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<

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

        /// public propaty name  :  ProcessKbn
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcessKbn
        {
            get { return _processKbn; }
            set { _processKbn = value; }
        }

        // ------ ADD START 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�-------->>>>
        /// public propaty name  :  CheckKbn
        /// <summary>�`�F�b�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckKbn
        {
            get { return _checkKbn; }
            set { _checkKbn = value; }
        }
        // ------ ADD END 2012/07/20 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.108�̑Ή�--------<<<<

        /// public propaty name  :  CsvDataInfoList
        /// <summary>CSV�f�[�^��񃊃X�g</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CSV�f�[�^��񃊃X�g</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string[]> CsvDataInfoList
        {
            get { return _csvDataInfoList; }
            set { _csvDataInfoList = value; }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�C���|�[�g�j���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_CustomerImportWorkTbl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_CustomerImportWorkTbl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_CustomerImportWorkTbl()
        {
        }
        // --------------- ADD START 2012/06/12 Redmine#30393 ������-------->>>>
        /// public propaty name  :  ErrorLogFileName
        /// <summary>�G���[���O�t�@�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���O�t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorLogFileName
        {
            get { return _errorLogFileName; }
            set { _errorLogFileName = value; }
        }
        // --------------- ADD END 2012/06/12 Redmine#30393 ������--------<<<<
    }
}
