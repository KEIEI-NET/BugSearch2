using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   UnPrcInfoConfRet
	/// <summary>
	///                      �P�����m�F����
	/// </summary>
	/// <remarks>
	/// <br>note             :   �P�����m�F���ʃw�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/06/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class UnPrcInfoConfRet
	{
		/// <summary>�P���Z�o�敪</summary>
		/// <remarks>1:�|��,2:�����t�o��,3:�e����</remarks>
		private Int32 _unitPrcCalcDiv;

		/// <summary>�|��</summary>
		/// <remarks>�|��</remarks>
		private Double _rateVal;

		/// <summary>�P���[�������P��</summary>
		private Double _unPrcFracProcUnit;

		/// <summary>�P���[�������敪</summary>
		private Int32 _unPrcFracProcDiv;

		/// <summary>��P��</summary>
		private Double _stdUnitPrice;

		/// <summary>�P���i�Ŕ��C�����j</summary>
		private Double _unitPriceTaxExcFl;

		/// <summary>�P���i�ō��C�����j</summary>
		private Double _unitPriceTaxIncFl;


		/// public propaty name  :  UnitPrcCalcDiv
		/// <summary>�P���Z�o�敪�v���p�e�B</summary>
		/// <value>1:�|��,2:�����t�o��,3:�e����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���Z�o�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnitPrcCalcDiv
		{
			get { return _unitPrcCalcDiv; }
			set { _unitPrcCalcDiv = value; }
		}

		/// public propaty name  :  RateVal
		/// <summary>�|���v���p�e�B</summary>
		/// <value>�|��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �|���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double RateVal
		{
			get { return _rateVal; }
			set { _rateVal = value; }
		}

		/// public propaty name  :  UnPrcFracProcUnit
		/// <summary>�P���[�������P�ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���[�������P�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double UnPrcFracProcUnit
		{
			get { return _unPrcFracProcUnit; }
			set { _unPrcFracProcUnit = value; }
		}

		/// public propaty name  :  UnPrcFracProcDiv
		/// <summary>�P���[�������敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnPrcFracProcDiv
		{
			get { return _unPrcFracProcDiv; }
			set { _unPrcFracProcDiv = value; }
		}

		/// public propaty name  :  StdUnitPrice
		/// <summary>��P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double StdUnitPrice
		{
			get { return _stdUnitPrice; }
			set { _stdUnitPrice = value; }
		}

		/// public propaty name  :  UnitPriceTaxExcFl
		/// <summary>�P���i�Ŕ��C�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���i�Ŕ��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double UnitPriceTaxExcFl
		{
			get { return _unitPriceTaxExcFl; }
			set { _unitPriceTaxExcFl = value; }
		}

		/// public propaty name  :  UnitPriceTaxIncFl
		/// <summary>�P���i�ō��C�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���i�ō��C�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double UnitPriceTaxIncFl
		{
			get { return _unitPriceTaxIncFl; }
			set { _unitPriceTaxIncFl = value; }
		}


		/// <summary>
		/// �P�����m�F���ʃR���X�g���N�^
		/// </summary>
		/// <returns>UnPrcInfoConfRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConfRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UnPrcInfoConfRet()
		{
		}

		/// <summary>
		/// �P�����m�F���ʃR���X�g���N�^
		/// </summary>
		/// <param name="unitPrcCalcDiv">�P���Z�o�敪(1:�|��,2:�����t�o��,3:�e����)</param>
		/// <param name="rateVal">�|��(�|��)</param>
		/// <param name="unPrcFracProcUnit">�P���[�������P��</param>
		/// <param name="unPrcFracProcDiv">�P���[�������敪</param>
		/// <param name="stdUnitPrice">��P��</param>
		/// <param name="unitPriceTaxExcFl">�P���i�Ŕ��C�����j</param>
		/// <param name="unitPriceTaxIncFl">�P���i�ō��C�����j</param>
		/// <returns>UnPrcInfoConfRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConfRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UnPrcInfoConfRet( Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl )
		{
			this._unitPrcCalcDiv = unitPrcCalcDiv;
			this._rateVal = rateVal;
			this._unPrcFracProcUnit = unPrcFracProcUnit;
			this._unPrcFracProcDiv = unPrcFracProcDiv;
			this._stdUnitPrice = stdUnitPrice;
			this._unitPriceTaxExcFl = unitPriceTaxExcFl;
			this._unitPriceTaxIncFl = unitPriceTaxIncFl;

		}

		/// <summary>
		/// �P�����m�F���ʕ�������
		/// </summary>
		/// <returns>UnPrcInfoConfRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UnPrcInfoConfRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UnPrcInfoConfRet Clone()
		{
			return new UnPrcInfoConfRet(this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl);
		}

		/// <summary>
		/// �P�����m�F���ʔ�r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�UnPrcInfoConfRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConfRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals( UnPrcInfoConfRet target )
		{
			return ( ( this.UnitPrcCalcDiv == target.UnitPrcCalcDiv )
				 && ( this.RateVal == target.RateVal )
				 && ( this.UnPrcFracProcUnit == target.UnPrcFracProcUnit )
				 && ( this.UnPrcFracProcDiv == target.UnPrcFracProcDiv )
				 && ( this.StdUnitPrice == target.StdUnitPrice )
				 && ( this.UnitPriceTaxExcFl == target.UnitPriceTaxExcFl )
				 && ( this.UnitPriceTaxIncFl == target.UnitPriceTaxIncFl ) );
		}

		/// <summary>
		/// �P�����m�F���ʔ�r����
		/// </summary>
		/// <param name="unPrcInfoConfRet1">
		///                    ��r����UnPrcInfoConfRet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="unPrcInfoConfRet2">��r����UnPrcInfoConfRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConfRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals( UnPrcInfoConfRet unPrcInfoConfRet1, UnPrcInfoConfRet unPrcInfoConfRet2 )
		{
			return ( ( unPrcInfoConfRet1.UnitPrcCalcDiv == unPrcInfoConfRet2.UnitPrcCalcDiv )
				 && ( unPrcInfoConfRet1.RateVal == unPrcInfoConfRet2.RateVal )
				 && ( unPrcInfoConfRet1.UnPrcFracProcUnit == unPrcInfoConfRet2.UnPrcFracProcUnit )
				 && ( unPrcInfoConfRet1.UnPrcFracProcDiv == unPrcInfoConfRet2.UnPrcFracProcDiv )
				 && ( unPrcInfoConfRet1.StdUnitPrice == unPrcInfoConfRet2.StdUnitPrice )
				 && ( unPrcInfoConfRet1.UnitPriceTaxExcFl == unPrcInfoConfRet2.UnitPriceTaxExcFl )
				 && ( unPrcInfoConfRet1.UnitPriceTaxIncFl == unPrcInfoConfRet2.UnitPriceTaxIncFl ) );
		}
		/// <summary>
		/// �P�����m�F���ʔ�r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�UnPrcInfoConfRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConfRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare( UnPrcInfoConfRet target )
		{
			ArrayList resList = new ArrayList();
			if (this.UnitPrcCalcDiv != target.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
			if (this.RateVal != target.RateVal) resList.Add("RateVal");
			if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
			if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
			if (this.StdUnitPrice != target.StdUnitPrice) resList.Add("StdUnitPrice");
			if (this.UnitPriceTaxExcFl != target.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
			if (this.UnitPriceTaxIncFl != target.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");

			return resList;
		}

		/// <summary>
		/// �P�����m�F���ʔ�r����
		/// </summary>
		/// <param name="unPrcInfoConfRet1">��r����UnPrcInfoConfRet�N���X�̃C���X�^���X</param>
		/// <param name="unPrcInfoConfRet2">��r����UnPrcInfoConfRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UnPrcInfoConfRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare( UnPrcInfoConfRet unPrcInfoConfRet1, UnPrcInfoConfRet unPrcInfoConfRet2 )
		{
			ArrayList resList = new ArrayList();
			if (unPrcInfoConfRet1.UnitPrcCalcDiv != unPrcInfoConfRet2.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
			if (unPrcInfoConfRet1.RateVal != unPrcInfoConfRet2.RateVal) resList.Add("RateVal");
			if (unPrcInfoConfRet1.UnPrcFracProcUnit != unPrcInfoConfRet2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
			if (unPrcInfoConfRet1.UnPrcFracProcDiv != unPrcInfoConfRet2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
			if (unPrcInfoConfRet1.StdUnitPrice != unPrcInfoConfRet2.StdUnitPrice) resList.Add("StdUnitPrice");
			if (unPrcInfoConfRet1.UnitPriceTaxExcFl != unPrcInfoConfRet2.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
			if (unPrcInfoConfRet1.UnitPriceTaxIncFl != unPrcInfoConfRet2.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");

			return resList;
		}
	}
}
