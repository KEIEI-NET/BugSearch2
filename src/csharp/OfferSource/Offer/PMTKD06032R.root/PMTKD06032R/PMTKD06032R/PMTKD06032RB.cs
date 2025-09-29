using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    internal struct SubstChkKey
    {
        private int _makerCd;
        private int _goodsMGroup;
        private string _prmPartsNo;

        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        public int MakerCd
        {
            get { return _makerCd; }
            set { _makerCd  = value;}
        }

        /// <summary>
        /// ���i������
        /// </summary>
        public int GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// <summary>
        /// �i��
        /// </summary>
        public string PrmPartsNo
        {
            get { return _prmPartsNo; }
            set { _prmPartsNo = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="goodsMGroup">���i������</param>
        /// <param name="makerCd">���[�J�[�R�[�h</param>
        /// <param name="prmPartsNo">�i��</param>
        public SubstChkKey(int goodsMGroup, int makerCd, string prmPartsNo)
        {
            _makerCd = makerCd;
            _goodsMGroup = goodsMGroup;
            _prmPartsNo = prmPartsNo;
        }

    }
}
