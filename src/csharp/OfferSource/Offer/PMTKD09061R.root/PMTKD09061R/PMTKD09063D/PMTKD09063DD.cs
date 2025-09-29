using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
	
namespace Broadleaf.Application.Remoting.ParamData
{	
	/// <summary>
	/// �D�Ǖ��i�擾�p�����[�^
	/// </summary>
	[Serializable]
	public class GetPrimePartsInfPara
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
        public GetPrimePartsInfPara()
		{
		}

        /// <summary>�n�C�t���t�ŐV���i�i��</summary>
        private string [] _PrtsNoWithHyphen;

        /// <summary>�n�C�t�����ŐV���i�i��</summary>
        private string _PrtsNoNoneHyphen;

        /// <summary>���i���[�J�[</summary>
        private int _PartsMakerCode;

		/// <summary>���[�J�[�R�[�h</summary>
		private int [] _MakerCode;

        /// <summary>�Z�b�g�����t���O</summary>
        private int _setSearchFlg;

        /// <summary>���i�ԍ������敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private int _SrchTyp;

        /// <summary>���i�ԍ������敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        public int SearchType
        {
            get { return _SrchTyp; }
            set { _SrchTyp = value; }
        }

        /// �n�C�t���t�ŐV���i�i��
        public string [] PrtsNoWithHyphen
        {
            get { return this._PrtsNoWithHyphen; }
            set { this._PrtsNoWithHyphen = value; }
        }
        /// �n�C�t�����ŐV���i�i��
        public string PrtsNoNoneHyphen
        {
            get { return this._PrtsNoNoneHyphen; }
            set { this._PrtsNoNoneHyphen = value; }
        }

        /// ���i���[�J�[
		public int PartsMakerCode
		{
			get{return this._PartsMakerCode;}
			set{this._PartsMakerCode = value;}
		}

		/// ���[�J�[�R�[�h
		public int [] MakerCode
		{
			get { return this._MakerCode; }
			set { this._MakerCode = value; }
		}

        /// <summary>�Z�b�g�����t���O</summary>
        public int SetSearchFlg
        {
            get { return _setSearchFlg; }
            set { _setSearchFlg = value; }
        }
	}
}
