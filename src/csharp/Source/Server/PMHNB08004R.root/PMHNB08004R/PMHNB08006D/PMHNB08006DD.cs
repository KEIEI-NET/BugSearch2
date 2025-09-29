using System;
using System.Collections;

//using Broadleaf.Library.Data;  // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      ���R���[���Ϗ��⑫�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[���Ϗ��⑫�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   22018 ��ؐ��b</br>
    /// <br>Date             :   2008/10/03</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePEstFmParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FrePEstFmParaWork()
        {
        }
    }

}
