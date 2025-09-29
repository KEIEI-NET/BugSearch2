using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OfrSupplier
    /// <summary>
    ///                      �d����}�X�^�i�񋟁j
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����}�X�^�i�񋟁j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/1/29</br>
    /// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  ����</br>
    /// </remarks>
    public class OfrSupplier
    {
        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d����J�i</summary>
        private string _supplierKana = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";


        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>�d����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }


        /// <summary>
        /// �d����}�X�^�i�񋟁j�R���X�g���N�^
        /// </summary>
        /// <returns>OfrSupplier�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrSupplier�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfrSupplier()
        {
        }

        /// <summary>
        /// �d����}�X�^�i�񋟁j�R���X�g���N�^
        /// </summary>
        /// <param name="offerDate">�񋟓��t(YYYYMMDD)</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierNm1">�d���於1</param>
        /// <param name="supplierKana">�d����J�i</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <returns>OfrSupplier�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrSupplier�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfrSupplier( DateTime offerDate, Int32 supplierCd, string supplierNm1, string supplierKana, string supplierSnm )
        {
            this._offerDate = offerDate;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierKana = supplierKana;
            this._supplierSnm = supplierSnm;

        }

        /// <summary>
        /// �d����}�X�^�i�񋟁j��������
        /// </summary>
        /// <returns>OfrSupplier�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OfrSupplier�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfrSupplier Clone()
        {
            return new OfrSupplier( this._offerDate, this._supplierCd, this._supplierNm1, this._supplierKana, this._supplierSnm );
        }

        /// <summary>
        /// �d����}�X�^�i�񋟁j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OfrSupplier�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrSupplier�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( OfrSupplier target )
        {
            return ((this.OfferDate == target.OfferDate)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierKana == target.SupplierKana)
                 && (this.SupplierSnm == target.SupplierSnm));
        }

        /// <summary>
        /// �d����}�X�^�i�񋟁j��r����
        /// </summary>
        /// <param name="ofrSupplier1">
        ///                    ��r����OfrSupplier�N���X�̃C���X�^���X
        /// </param>
        /// <param name="ofrSupplier2">��r����OfrSupplier�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrSupplier�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( OfrSupplier ofrSupplier1, OfrSupplier ofrSupplier2 )
        {
            return ((ofrSupplier1.OfferDate == ofrSupplier2.OfferDate)
                 && (ofrSupplier1.SupplierCd == ofrSupplier2.SupplierCd)
                 && (ofrSupplier1.SupplierNm1 == ofrSupplier2.SupplierNm1)
                 && (ofrSupplier1.SupplierKana == ofrSupplier2.SupplierKana)
                 && (ofrSupplier1.SupplierSnm == ofrSupplier2.SupplierSnm));
        }
        /// <summary>
        /// �d����}�X�^�i�񋟁j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OfrSupplier�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrSupplier�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( OfrSupplier target )
        {
            ArrayList resList = new ArrayList();
            if ( this.OfferDate != target.OfferDate ) resList.Add( "OfferDate" );
            if ( this.SupplierCd != target.SupplierCd ) resList.Add( "SupplierCd" );
            if ( this.SupplierNm1 != target.SupplierNm1 ) resList.Add( "SupplierNm1" );
            if ( this.SupplierKana != target.SupplierKana ) resList.Add( "SupplierKana" );
            if ( this.SupplierSnm != target.SupplierSnm ) resList.Add( "SupplierSnm" );

            return resList;
        }

        /// <summary>
        /// �d����}�X�^�i�񋟁j��r����
        /// </summary>
        /// <param name="ofrSupplier1">��r����OfrSupplier�N���X�̃C���X�^���X</param>
        /// <param name="ofrSupplier2">��r����OfrSupplier�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfrSupplier�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( OfrSupplier ofrSupplier1, OfrSupplier ofrSupplier2 )
        {
            ArrayList resList = new ArrayList();
            if ( ofrSupplier1.OfferDate != ofrSupplier2.OfferDate ) resList.Add( "OfferDate" );
            if ( ofrSupplier1.SupplierCd != ofrSupplier2.SupplierCd ) resList.Add( "SupplierCd" );
            if ( ofrSupplier1.SupplierNm1 != ofrSupplier2.SupplierNm1 ) resList.Add( "SupplierNm1" );
            if ( ofrSupplier1.SupplierKana != ofrSupplier2.SupplierKana ) resList.Add( "SupplierKana" );
            if ( ofrSupplier1.SupplierSnm != ofrSupplier2.SupplierSnm ) resList.Add( "SupplierSnm" );

            return resList;
        }
    }
}
