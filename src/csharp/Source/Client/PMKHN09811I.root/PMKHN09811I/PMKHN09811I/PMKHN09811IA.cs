//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�C���|�[�g�E�G�N�X�|�[�gMDI�q��ʃC���^�[�t�F�[�X
// �v���O�����T�v   : �|���}�X�^�C���|�[�g�E�G�N�X�|�[�gMDI�q��ʃC���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{
    public delegate void ParentToolbarSettingEventHandler(object sender);

    public delegate void ExecCsvConvertEventHandler(object sender, ref int? result);
    
    /// <summary>
    /// �C���|�[�g�E�G�N�X�|�[�gMDI�q��ʃ��C����ʃC���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
    public interface ICSVExportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        event ExecCsvConvertEventHandler ExecCsvConvertEvent;

        // Methods
        int Extract(ref object parameter);
        int GetCSVInfo(ref object parameter);
        bool ExportBeforeCheck();
        void Show(object parameter);
        void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName);
        void AfterExportSuccess();
    }

    /// <summary>
    /// �C���|�[�g�E�G�N�X�|�[�gMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : ���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
    public interface ICSVImportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        void Show(object parameter);
        bool IsUseBaseCheck();
        string ImportFileName();
        bool ImportBeforeCheck();
        bool ItemCntCheck(int csvDataRowCnt);
        void CheckErrEvent();
        int Import(object csvDataList);
    }
}
