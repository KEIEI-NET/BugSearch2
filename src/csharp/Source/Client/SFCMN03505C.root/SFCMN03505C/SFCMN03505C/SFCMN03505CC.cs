using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace Broadleaf.Library.Runtime.InteropServices
{
    /// <summary>
    /// フェリカアクセス用構造体
    /// </summary>
    /// <remarks>
    /// <br>Note       : フェリカアクセスに用いる構造体です。</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2008.10.30</br>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct StructurePolling
    {
        public int FelicaSystemCode;
        public byte TimeSlot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureCardInformation
    {
        public uint CardIdm;
        public uint CardPmm;
    }

    // --------------------------------------------
    [StructLayout(LayoutKind.Sequential)]
    public struct StructureAllFelicaErrorType
    {
        public byte NumberOfFelicaErrorTypes;
        public FeliCaErrorType FelicaErrorType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureAllRWErrorType
    {
        public uint NumberOfRWErrorTypes;
        public RwErrorType RWErrorType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureCallBackParameter
    {
        public IntPtr handle;
        public uint MessageOfCardFind;
        public uint MessageOfCardLoss;
        public uint Interval;
        public uint RetryCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureDeviceInformation
    {
        public byte DeviceInfoType;
        public byte DeviceInfoConnect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructurePlugAndPlayCallBackParameters
    {
        public IntPtr handle;
        public uint MessageOfReaderWriterConnect;
        public uint MessageOfReaderWriterPullout;
        public String PortName;
        public bool ReconnectFlag;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputDumb
    {
        public Int16 time_out;
        public Int16 retry_count;
        public int CardCommandPacketData;
        public int CardCommandPacketLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputReadBlockWithoutEncryption
    {
        public uint CardIdm;
        public byte NumberOfServices;
        public int ServiceCodeList;
        public byte NumberOfBlocks;
        public int BlockList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputRequestService
    {
        public uint CardIdm;
        public byte NumberOfServices;
        public int ServiceCcodeList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputRequestSystemCode
    {
        public uint CardIdm;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputSearchServiceCode
    {
        public int BufferSizeOfAreaCodes;
        public int BufferSizeOfServiceCodes;
        public Int16 OffsetOfAreaServiceIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputSearchServiceCode2
    {
        public uint CardIdm;
        public int BufferSizeOfAreaCodes;
        public int BufferSizeOfServiceCodes;
        public Int16 OffsetOfAreaServiceIndex;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct StructureInputWriteBlockWithoutEncryption
    {
        public uint CardIdm;
        public byte NumberOfServices;
        public int ServiceCodeList;
        public byte NumberOfBlocks;
        public int BlockList;
        public int BlockData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOutputDumb
    {
        public int CardResponsePacketData;
        public int ResponsePacketLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOutputReadBlockWithoutEncryption
    {
        public int StatusFlag1;
        public int StatusFlag2;
        public int ResultNumberOfBlocks;
        public int BlockData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOutputRequestService
    {
        public int lngNumberOfServices;
        public int lngServiceKeyVersionList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOutputRequestSystemCode
    {
        public byte NumberOfSystemCode;
        public int SystemCodeList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOutputSearchServiceCode
    {
        public int NumberOfServiceCodes;
        public int ServiceCodeList;
        public int NumberOfAreaCodes;
        public int AreaCodeList;
        public int EndServiceCodeList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOutputWriteBlockWithoutEncryption
    {
        public int StatusFlag1;
        public int StatusFlag2;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct StructureReaderWriterMode
    {
        public String PortName;
        public int BaudRate;
        public byte EncryptionMode;
        public int Kar;
        public int Kbr;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureOpenReaderWriterModeWithoutEncryption
    {
        public string PortName;
        public int BaudRate;
    }

    #region 封印
    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureKeyList
    //{
    //    public int lngSystemKey;
    //    public int lngArea0000Key;
    //    public byte bytNumberOfAreaKeys;
    //    public int lngAreaKeyList;
    //    public byte bytNumberOfServiceKeys;
    //    public int lngServiceKeyList;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureAccessKey
    //{
    //    public int lngGroupServiceKey;
    //    public int lngUserServiceKey;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct InputStructureMutualAuthentication
    //{
    //    public uint CardIdm;
    //    public byte bytNumberOfAreas;
    //    public int lngAreaCodeList;
    //    public byte bytNumberOfServices;
    //    public int lngServiceCodeList;
    //    public int lngGroupServiceKey;
    //    public int lngUserServiceKey;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct InputStructureWriteBlock
    //{
    //    public byte bytNumberOfBlocks;
    //    public int lngBlockList;
    //    public int lngBlockData;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct OutputStructureWriteBlock
    //{
    //    public int lngStatusFlag1;
    //    public int lngStatusFlag2;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct OutputStructureMutualAuthentication
    //{
    //    public int lngResultCode;
    //    public int lngIdi;
    //    public int lngPmi;
    //    public int lngIdt;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct InputStructureReadBlock
    //{
    //    public byte bytNumberOfBlocks;
    //    public int lngBlockList;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct OutputStructureReadBlock
    //{
    //    public int lngStatusFlag1;
    //    public int lngStatusFlag2;
    //    public int lngResultNumberOfBlocks;
    //    public int lngBlockData;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureAppendKeyList
    //{
    //    public byte bytAppendFlag;
    //    public int lngGroupServiceKey;
    //    public int lngUserServiceKey;
    //    public byte bytNumberOfAreaKeys;
    //    public int lngAreaKeyList;
    //    public byte bytNumberOfServiceKeys;
    //    public int lngServiceKeyList;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureAppendAccessKey
    //{
    //    public int lngResultGroupServiceKey;
    //    public int lngResultUserServiceKey;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureKeyInformationForType2
    //{
    //    public byte bytPackageKind;
    //    public int lngOldKey;
    //    public int lngNewKey;
    //    public int lngNewKeyVersion;
    //    public int lngParentKey;
    //    public int lngIntervalKeyExchangeInformation1;
    //    public int lngIntervalKeyExchangeInformation2;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureKeyExchangeInformationForType2
    //{
    //    public int lngResultCode;
    //    public int lngType2KeyExchangeInformation1;
    //    public int lngType2KeyExchangeInformation2;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct StructureKeyExchangeInformation
    //{
    //    public int lngKeyExchangeInformation1;
    //    public int lngKeyExchangeInformation2;
    //}
    #endregion
}