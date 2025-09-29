using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���㖾�׃f�[�^�e�[�u����\���R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㖾�׃f�[�^�e�[�u���̗�\�����s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    internal class SalesDetailRowVisibleControl
    {
        private Dictionary<SalesDetailColStatusKey, bool> _statusDictionary = new Dictionary<SalesDetailColStatusKey, bool>();

        /// <summary>
        /// ��\����\���ݒ�l�ǉ�����
        /// </summary>
        /// <param name="colName">�񖼏�</param>
        /// <param name="statusType">�X�e�[�^�X�^�C�v</param>
        /// <param name="value">�l</param>
        /// <param name="hidden">�\����\���ݒ�l</param>
        internal void Add(string colName, StatusType statusType, int value, bool hidden)
        {
            SalesDetailColStatusKey key = new SalesDetailColStatusKey(colName, statusType, value);

            if (this._statusDictionary.ContainsKey(key))
            {
                this._statusDictionary[key] = hidden;
            }
            else
            {
                this._statusDictionary.Add(key, hidden);
            }
        }

        /// <summary>
        /// ��\����\���ݒ�l�擾����
        /// </summary>
        /// <param name="colName">�񖼏�</param>
        /// <param name="statusType">�X�e�[�^�X�^�C�v</param>
        /// <param name="value">�l</param>
        /// <param name="visible">�\����\���ݒ�l</param>
        /// <returns>0:�擾�\ 0�ȊO:�擾���s</returns>
        internal int GetHidden(string colName, StatusType statusType, int value, out bool hidden)
        {
            SalesDetailColStatusKey key = new SalesDetailColStatusKey(colName, statusType, value);

            if (this._statusDictionary.ContainsKey(key))
            {
                hidden = this._statusDictionary[key];
                return 0;
            }
            else
            {
                hidden = true;
                return -1;
            }
        }
    }

    /// <summary>
    /// ���㖾�׃f�[�^�e�[�u����X�e�[�^�X�L�[�\����
    /// </summary>
    internal struct SalesDetailColStatusKey
    {
        string _colName;
        StatusType _statusType;
        int _value;

        /// <summary>
        /// ���㖾�׃f�[�^�e�[�u����X�e�[�^�X�L�[�\���̃R���X�g���N�^
        /// </summary>
        /// <param name="colName">�񖼏�</param>
        /// <param name="statusType">�X�e�[�^�X�^�C�v</param>
        /// <param name="value">�l</param>
        internal SalesDetailColStatusKey(string colName, StatusType statusType, int value)
        {
            this._colName = colName;
            this._statusType = statusType;
            this._value = value;
        }

        /// <summary>�񖼏̃v���p�e�B</summary>
        internal string ColName
        {
            get { return _colName; }
            set { _colName = value; }
        }

        /// <summary>�X�e�[�^�X�^�C�v�v���p�e�B</summary>
        internal StatusType StatusType
        {
            get { return _statusType; }
            set { _statusType = value; }
        }

        /// <summary>�l�v���p�e�B</summary>
        internal int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    /// <summary>
    /// �R���{�G�f�B�^�f�[�^�擾�^�C�v
    /// </summary>
    internal enum StatusType : int
    {
        Default = 0,
        SalesGoodsCd = 1,
        ProductNumberInput = 2,
        AcptAnOdrStatus = 3,
        AcptAnOdrStatusAndSalesSlipCd = 4,
        InputChange = 5
    }
}
