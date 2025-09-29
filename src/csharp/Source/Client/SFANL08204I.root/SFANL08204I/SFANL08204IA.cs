using System;
using System.Drawing;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���R���[��������̃C���^�[�t�F�[�X�ł��B
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�̈���N���X�p�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.03.27</br>
    /// <br></br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public interface IFrePprPrintProc
    {
        // �v���p�e�B
        /// <summary>
        /// ����ɕK�v�ȏ��ł��B
        /// </summary>
        SFANL08205C Printinfo { get;set;}
        // ���\�b�h
        /// <summary>������J�n�����郁�\�b�h�ł��B</summary>
        int StartPrint();

    }

    /// <summary>
    /// ���R���[���o�����̃C���^�[�t�F�[�X�ł��B
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�̒��o�N���X�p�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.07.13</br>
    /// <br></br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public interface IFrePprExtraProc
    {
        // �v���p�e�B
        /// <summary>����ɕK�v�ȏ��ł��B</summary>
        SFANL08205C Printinfo { get;set;}
        
        // ���\�b�h
        /// <summary>���o���J�n�����郁�\�b�h�ł��B</summary>
        int ExtrPrintData();
    }
}
