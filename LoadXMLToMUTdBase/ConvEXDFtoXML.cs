using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace LoadXMLToMUTdBase
{
    public class ConvEXDFtoXML
    {
        //public static object buffer = string.Empty;
        private static string buffer = string.Empty;
        private static byte[] m_BitRotationEncryption;
        private const byte CS_ENCRYPTION_KEY = 170;
        private static byte[] encryptionValue;
        private static byte[] m_VernamEncryption;
        private static long m_LastError;
        private static string filePath;
        private static byte[] BitRotationEncryption(byte[] orgValue, long orgValuesize)
        {
            if (m_BitRotationEncryption != null)
            {
                m_BitRotationEncryption.Initialize();
                m_BitRotationEncryption = (byte[])null;
            }
            if (orgValuesize > 0L)
            {
                m_BitRotationEncryption = new byte[orgValuesize];
                for (long index = 0; index < orgValuesize; ++index)
                {
                    byte num = 0;
                    if (((int)orgValue[index] & 1) == 1)
                        num = (byte)128;
                    if (((int)orgValue[index] & 2) == 2)
                        num += (byte)64;
                    if (((int)orgValue[index] & 4) == 4)
                        num += (byte)32;
                    if (((int)orgValue[index] & 8) == 8)
                        num += (byte)16;
                    if (((int)orgValue[index] & 16) == 16)
                        num += (byte)8;
                    if (((int)orgValue[index] & 32) == 32)
                        num += (byte)4;
                    if (((int)orgValue[index] & 64) == 64)
                        num += (byte)2;
                    if (((int)orgValue[index] & 128) == 128)
                        ++num;
                    m_BitRotationEncryption[index] = num;
                }
            }
            return m_BitRotationEncryption;
        }
        private static byte[] VernamEncryption(byte[] orgValue, long orgValuesize)
        {
            try
            {
                if (m_VernamEncryption != null)
                {
                    m_VernamEncryption.Initialize();
                    m_VernamEncryption = (byte[])null;
                }
                if (orgValuesize > 0L)
                {
                    m_VernamEncryption = new byte[orgValuesize];
                    for (long index = 0; index < orgValuesize; ++index)
                        m_VernamEncryption[index] = (byte)((uint)orgValue[index] ^ 170U);
                }
            }
            catch
            {
                m_LastError = -1L;
            }
            return m_VernamEncryption;
        }
        private static long ExecDecryption(bool utf8)
        {
            long num = 0;
            long length = (long)encryptionValue.Length;
            byte[] orgValue = BitRotationEncryption(encryptionValue, length);

            byte[] bytes = VernamEncryption(orgValue, length);

            buffer = "";
            if (num == 0L)
            {
                if (utf8)
                {
                    if (bytes.Length > 3 && bytes[0] == (byte)239 && (bytes[1] == (byte)187 && bytes[2] == (byte)191))
                    {
                        List<byte> list = ((IEnumerable<byte>)bytes).ToList<byte>();
                        list.RemoveRange(0, 3);
                        bytes = list.ToArray();
                    }
                    buffer = Encoding.UTF8.GetString(bytes);
                }
                else
                    buffer = Encoding.Default.GetString(bytes);
            }

            return num;
        }
        public void ConvertFiles()
        {
            //создать диалоговое окно открытия файла
            //и показать в нем только файлы exdf
            var openDlg = new OpenFileDialog { Filter = "Text Files |*.exdf" };

            //Был ли клик на кнопке ОК
            if (true == openDlg.ShowDialog())
            {
                //Загрузить содержимое выбранного файла
                encryptionValue = File.ReadAllBytes(openDlg.FileName);
            }
            else return;

            ExecDecryption(true);
            Data.SendConvData = buffer;
        }
    }
}