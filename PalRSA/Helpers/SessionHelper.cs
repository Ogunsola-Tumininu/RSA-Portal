using PalRSA.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PalRSA.Helpers
{
    public static class SessionHelper
    {
        static PALSiteDBEntities db = new PALSiteDBEntities();

        public static string UserName
        {
            //
            get
            {
                return  HttpContext.Current.User.Identity.Name;
            }
        }
        public static string Pin
        {
            //
            get {
                return HttpContext.Current.Request.Cookies["pin"].Value;
                // return (String)HttpContext.Current.Session["Pin"];
            }
        }

        public static int FundId
        {
            //
            get
            {
                try
                {
                    
                   return  Convert.ToInt16(HttpContext.Current.Request.Cookies["pin"].Value);
                }
                catch (Exception)
                {

                    return 0;
                }
               
                // return (String)HttpContext.Current.Session["Pin"];
            }
        }

        public static string EmployerCode // (string rcno)
        {
            //
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Request.Cookies["rcno"].Value);
                }
                catch (Exception)
                {

                    return "";
                }

                // return (String)HttpContext.Current.Session["Pin"];

            }
        }

        public static string GetClientHost
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString();
               // string[] computer_name = System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
               // String ecn = System.Environment.MachineName;
               //return computer_name[0].ToString();
               //
               //IPHostEntry host = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString());

                //return  host.HostName.ToString();
            }
        }

        public static EmployerDetail EmployerContext // (string rcno)
        {
            //
            get
            {
                try
                {

                    return  db.EmployerDetails.Where(d=>d.Recno== HttpContext.Current.User.Identity.Name).FirstOrDefault();// (EmployerDetail) HttpContext.Current.Session["EmployerDetail"];
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public static void addToCookie(string cookieName, string refNo)
        {
            HttpContext.Current.Response.Cookies[cookieName].Value = refNo;
            HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddMonths(1);
        }


        public static string GetCookieValue(string cookieName)
        {
            string cookieValue="";
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                cookieValue = HttpContext.Current.Request.Cookies[cookieName].ToString();
            }
            return cookieValue;
        }
    }
}