using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �`�[�^�C�v����N���X
    /// </summary>
    /// <remarks>
    /// Note       : ����Ɏg�p����`�[�^�C�v(�`�[�Ǘ��ݒ�}�X�^�E���R�[�h)���m�肷��ׂ̃N���X�ł��B<br />
    ///              ����`�[���͂ȂǃG���g���֘A�o�f����݂̂̎g�p�Ƃ��܂��B�i�`�[���s�m�F�t�h����͖��g�p�j
    /// Programmer : 22018 ��� ���b<br />                                   
    /// Date       : 2008.08.07<br />                                      
    /// <br />
    /// </remarks>
    public class SlipTypeController
    {
        # region [private const]
        // ���_�[��
        private const string ct_SectionZero = "00";
        // �q�Ƀ[��
        private const string ct_WarehouseZero = "0000";
        // ���Ӑ�[��
        private const int ct_CustomerZero = 0;
        // ���W�ԍ��[��
        private const int ct_CashRegisterZero = 0;
        # endregion

        # region [public enum]
        /// <summary>
        /// �`�[�^�C�v �񋓌^
        /// </summary>
        public enum SlipKind
        {
            /// <summary>���Ϗ�</summary>
            EstimateForm = 10,
            /// <summary>�d���ԕi�`�[</summary>
            StockReturn = 40,
            /// <summary>����`�[</summary>
            SalesSlip = 30,
            /// <summary>�󒍓`�[</summary>
            AcceptSlip = 120,
            /// <summary>�ݏo�`�[</summary>
            LoanSlip = 130,
            /// <summary>���ϓ`�[</summary>
            EstimateSlip = 140,
            /// <summary>�t�n�d�`�[</summary>
            UOESlip = 160,
            /// <summary>�݌Ɉړ��`�[</summary>
            StockMoveSlip = 150,
        }
        # endregion

        # region [private �t�B�[���h]
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�擾���ƂȂ链�Ӑ�}�X�^�i�`�[�Ǘ��j���X�g</summary>
        private List<CustSlipMng> _custSlipMngList;
        /// <summary>�擾���ƂȂ�`�[����ݒ胊�X�g</summary>
        private List<SlipPrtSet> _slipPrtSetList;
        # endregion

        # region [public �v���p�e�B]
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �擾���ƂȂ链�Ӑ�}�X�^�i�`�[�Ǘ��j���X�g
        /// </summary>
        public List<CustSlipMng> CustSlipMngList
        {
            get 
            {
                if ( _custSlipMngList == null )
                {
                    _custSlipMngList = new List<CustSlipMng>();
                }
                return _custSlipMngList; 
            }
            set { _custSlipMngList = value; }
        }
        /// <summary>
        /// �擾���ƂȂ�`�[����ݒ�}�X�^���X�g
        /// </summary>
        public List<SlipPrtSet> SlipPrtSetList
        {
            get 
            {
                if ( _slipPrtSetList == null )
                {
                    _slipPrtSetList = new List<SlipPrtSet>();
                }
                return _slipPrtSetList; 
            }
            set { _slipPrtSetList = value; }
        }
        # endregion

        # region [public ���\�b�h]
        /// <summary>
        /// �`�[�^�C�v�擾����
        /// </summary>
        /// <param name="slipKind">�`�[���</param>
        /// <param name="retSlipPrtSet">(�o��)�`�[����ݒ�}�X�^�C���X�^���X</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS (0:����,9:�G���[)</returns>
        public int GetSlipType( SlipKind slipKind, out SlipPrtSet retSlipPrtSet, string sectionCode, int customerCode )
        {
            return GetSlipTypeProc(slipKind, out retSlipPrtSet, sectionCode, customerCode );
        }
        # endregion

        # region [private ���\�b�h]
        /// <summary>
        /// �`�[�^�C�v�擾����
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="retSlipPrtSet"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns>STATUS</returns>
        private int GetSlipTypeProc( SlipKind slipKind, out SlipPrtSet retSlipPrtSet, string sectionCode, int customerCode )
        {
            retSlipPrtSet = new SlipPrtSet();

            //-------------------------------------------------------
            // ���Ӑ�}�X�^�`�[�Ǘ��@�擾
            //-------------------------------------------------------
            CustSlipMng custSlipMng = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( customerCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            {
                // ���Ӑ斈[���_=0]
                custSlipMng = FindCustSlipMng( this.EnterpriseCode, ct_SectionZero, customerCode, (int)slipKind );
                if ( custSlipMng == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂�"0"����������
                    custSlipMng = FindCustSlipMng( this.EnterpriseCode, "0", customerCode, (int)slipKind );
                }
            }

            // ���_��[���Ӑ�=0]
            if ( custSlipMng == null )
            {
                custSlipMng = FindCustSlipMng( this.EnterpriseCode, sectionCode, ct_CustomerZero, (int)slipKind );
            }

            // �S�Аݒ�[���_=0,���Ӑ�=0]
            if ( custSlipMng == null )
            {
                custSlipMng = FindCustSlipMng( this.EnterpriseCode, ct_SectionZero, ct_CustomerZero, (int)slipKind );
                if ( custSlipMng == null )
                {
                    // �����̃e�[�u���̃f�[�^�Z�b�g�d�l���s����Ȃ̂�"0"����������
                    custSlipMng = FindCustSlipMng( this.EnterpriseCode, "0", ct_CustomerZero, (int)slipKind );
                }
            }

            // �Y����������΃G���[STATUS��Ԃ��B
            if ( custSlipMng == null )
            {
                return 9;
            }

            //-------------------------------------------------------
            // �`�[����ݒ�}�X�^ �擾
            //-------------------------------------------------------
            retSlipPrtSet = FindSlipPrtSet( this.EnterpriseCode, custSlipMng.SlipPrtSetPaperId.TrimEnd(), (int)slipKind );

            // �Y����������΃G���[STATUS��Ԃ��B
            if ( retSlipPrtSet == null )
            {
                return 9;
            }

            return 0;
        }
        /// <summary>
        /// ���Ӑ�}�X�^�`�[�Ǘ��i�`�[�^�C�v�Ǘ��}�X�^�jFind����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <returns></returns>
        private CustSlipMng FindCustSlipMng( string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind )
        {
            if ( this.CustSlipMngList == null ) return null;

            return this.CustSlipMngList.Find(
                        delegate( CustSlipMng custSlipMng )
                        {
                            return (custSlipMng.EnterpriseCode.TrimEnd() == enterpriseCode)
                                    && ((custSlipMng.SectionCode.TrimEnd() == sectionCode) || (custSlipMng.SectionCode.TrimEnd() == string.Empty && sectionCode == ct_SectionZero))
                                    && (custSlipMng.CustomerCode == customerCode)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (custSlipMng.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (custSlipMng.SlipPrtKind == slipPrtKind);
                        } );
        }
        /// <summary>
        /// �`�[����ݒ�}�X�^ Find����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <param name="slipPrtKind"></param>
        /// <returns></returns>
        private SlipPrtSet FindSlipPrtSet( string enterpriseCode, string slipPrtSetPaperId, int slipPrtKind )
        {
            if ( this.SlipPrtSetList == null ) return null;

            return this.SlipPrtSetList.Find(
                        delegate( SlipPrtSet slipPrtSet )
                        {
                            return (slipPrtSet.EnterpriseCode.TrimEnd() == enterpriseCode)
                                    && (slipPrtSet.SlipPrtSetPaperId.TrimEnd() == slipPrtSetPaperId)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (slipPrtSet.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (slipPrtSet.SlipPrtKind == slipPrtKind);
                        } );
        }


        # endregion
    }
}
