using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GetHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            char result = 'n';
            while (result == 'n')
            {
                result = EnterPath();
            }
        }

        public static string Md5_2(byte[] buffer)
        {
            var data = MD5.Create().ComputeHash(buffer);
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string Md5_1(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = MD5.Create().ComputeHash(buffer);
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strText));
            StringBuilder sc = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sc.Append(result[i].ToString("x2"));
            }
            return sc.ToString();
        }
        static char EnterPath()
        {
            Console.WriteLine("please enter file path:");
            var path = Console.ReadLine();
            GetFile(path);
            GetMD5(path);
            GetSHA1(path);
            GetSHA256(path);
            Console.Write("quit?(y/n):");
            var key = Console.ReadKey();
            Console.WriteLine();
            return key.KeyChar;
        }
        static void GetFile(string s)
        {
            try
            {
                FileInfo fi = new FileInfo(s);
                Console.WriteLine("file path：{0}", s);
                Console.WriteLine("file name：{0}", fi.Name.ToString());
                Console.WriteLine("file type：{0}", fi.Extension.TrimStart('.'));
                Console.WriteLine("file size：{0} K", fi.Length / 1024);
                Console.WriteLine("file created time：{0}", fi.CreationTime.ToString());
                Console.WriteLine("file last access time：{0}", fi.LastAccessTime.ToString());
                Console.WriteLine("file last wtrte time：{0}", fi.LastWriteTime.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void GetMD5(string s)
        {
            try
            {
                FileStream file = new FileStream(s, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retval = md5.ComputeHash(file);
                file.Close();
                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                Console.WriteLine("file MD5：{0}", sc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void GetSHA1(string s)
        {
            try
            {
                FileStream file = new FileStream(s, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();
                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                Console.WriteLine("file SHA1：{0}", sc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void GetSHA256(string s)
        {
            try
            {
                FileStream file = new FileStream(s, FileMode.Open);
                SHA256 sha256 = new SHA256CryptoServiceProvider();
                byte[] retval = sha256.ComputeHash(file);
                file.Close();
                StringBuilder sc = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sc.Append(retval[i].ToString("x2"));
                }
                Console.WriteLine("file SHA256：{0}", sc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
