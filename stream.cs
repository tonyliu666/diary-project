using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace 讀寫日記_期末專題_
{
    class Stream
    {
        public static void Write(string year, string month, string day,string title ,string weather,string body)
        {
            string path = "D:\\Diaries\\"+year+month+day+".txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //建立串流寫出器
            StreamWriter output = new StreamWriter(path, false);

           

            output.WriteLine("<title>" + title + "</title>");
            output.WriteLine("<weather>" + weather + "</weather>");
            output.WriteLine("<body>" + body + "</body>");
            output.Close();
        }

        public static void Read(string year, string month, string day, string beginMark, string endMark, out string[] elements)
        {
            int length = 0;
            string line = "";
            bool beginMarkFound = false;
            bool endMarkFound = false;
            int begin = -1;
            int end = -1;
            //讀取上限問題？
            const int MAX_N_ELEMENTS = 10;
            elements = new string[MAX_N_ELEMENTS];
            int nElements = 0;
            try
            {
                //建立串流讀入器
                StreamReader input = new StreamReader("D:\\Diaries\\" + year + month + day + ".txt", false);
                try
                {
                    while (!input.EndOfStream)
                    {
                        line = input.ReadLine();
                        if (beginMarkFound)
                        {
                            begin = 0;
                        }
                        else
                        {
                            begin = line.IndexOf(beginMark);
                            if (begin < 0) continue;
                            beginMarkFound = true;
                            begin = begin + beginMark.Length;
                        }

                        if (!endMarkFound)
                        {
                            end = line.IndexOf(endMark);
                            if (end < 0)
                            {
                                end = line.Length;
                            }
                            else
                            {
                                endMarkFound = true;
                            }
                            length = end - begin;
                            if (length > 0)
                            {
                                elements[nElements] = line.Substring(begin, length);
                                nElements++;
                            }
                            else
                            {
                                beginMarkFound = false;
                                endMarkFound = false;
                                begin = -1;
                                end = -1;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    input.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

