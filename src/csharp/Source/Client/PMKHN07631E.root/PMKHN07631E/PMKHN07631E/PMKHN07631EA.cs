//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�C���|�[�g�j���o�����N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/03/31  �C�����e : Mantis.15256 ���i�}�X�^�C���|�[�g�̑Ώۍ��ڐݒ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/12  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_GoodsUImportWorkTbl
    /// <summary>
    ///                      ���i�}�X�^�i�C���|�[�g�j���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�}�X�^�i�C���|�[�g�j���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   2012/06/12 wangf </br>
    /// <br>                 :   10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
    /// </remarks>
    public class ExtrInfo_GoodsUImportWorkTbl
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�����敪</summary>
        private Int32 _processKbn;

        /// <summary>CSV�f�[�^��񃊃X�g</summary>
        private List<string[]> _csvDataInfoList;

        // 2010/03/31 Add >>>
        /// <summary>�C���|�[�g�Ώېݒ胊�X�g</summary>
        private List<int[]> _setUpInfoList;
        // 2010/03/31 Add <<<
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// <summary>�G���[���O�t�@�C����</summary>
        private string _errorLogFileName;
        /// <summary>���i�J�n�N����</summary>
        private DateTime _priceStartDate;
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
        /// <summary>�`�F�b�N�敪</summary>
        private Int32 _dataCheckKbn;
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<

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

        // 2010/03/31 Add >>>
        /// public propaty name  :  SetUpInfoList
        /// <summary>�C���|�[�g�Ώېݒ胊�X�g</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �C���|�[�g�Ώېݒ胊�X�g</br>
        /// <br>Programer        :   30517 �Ė� �x��</br>
        /// </remarks>
        public List<int[]> SetUpInfoList
        {
            get { return _setUpInfoList; }
            set { _setUpInfoList = value; }
        }
        // 2010/03/31 Add <<<
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
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
        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n�N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
        /// public propaty name  :  DataCheckKbn
        /// <summary>�`�F�b�N�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataCheckKbn
        {
            get { return _dataCheckKbn; }
            set { _dataCheckKbn = value; }
        }
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
    }
}
