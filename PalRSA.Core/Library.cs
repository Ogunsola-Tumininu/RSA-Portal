using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PalRSA.Core
{
    public static class Library
    {
        public static void WriteErrorLog(Exception err, string moduleTitle)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile" + DateTime.Now.Date.ToString("yyyyMM") + ".txt", true);
                if (err.InnerException != null)
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + moduleTitle + ":: " + err.Source.ToString().Trim() + "; " + err.InnerException.ToString().Trim());
                }
                else
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + moduleTitle + ":: " + err.Source.ToString().Trim() + "; " + err.Message.Trim());
                }


                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        public static void WriteErrorLog(Exception err)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile" + DateTime.Now.Date.ToString("yyyyMM") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + err.Source.ToString().Trim() + "; " + err.StackTrace.Trim());
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        public static void WriteErrorLog(string errMessage)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile" + DateTime.Now.Date.ToString("yyyyMM") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + errMessage.Trim());
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}