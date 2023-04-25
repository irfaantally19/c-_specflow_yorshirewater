using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Pages.Models
{
    public class Credential
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }




        //T2 login credentials and URL - WJE20220830
        public static Credential GetT2Credential()
        {
            var user = Environment.GetEnvironmentVariable("T2Username");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("T2URL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("T2Password")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("T2URL"),
                Username = TestContext.Parameters.Get("T2Username"),
                Password = TestContext.Parameters.Get("T2Password")
            };
        }
        public static Credential GetEMPCredential()
        {
            var user = Environment.GetEnvironmentVariable("FioriUsername");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("FioriURL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("FioriPassword")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("FioriURL"),
                Username = TestContext.Parameters.Get("FioriUsername"),
                Password = TestContext.Parameters.Get("FioriPassword")
            };
        }
        public static Credential GetMGRCredential()
        {
            var user = Environment.GetEnvironmentVariable("FioriMGRUsername");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("FioriURL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("FioriPassword")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("FioriURL"),
                Username = TestContext.Parameters.Get("FioriMGRUsername"),
                Password = TestContext.Parameters.Get("FioriPassword")
            };
        }
        public static Credential GetMGR2Credential()
        {
            var user = Environment.GetEnvironmentVariable("FioriMGRU2sername");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("FioriURL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("FioriPassword")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("FioriURL"),
                Username = TestContext.Parameters.Get("FioriMGRU2sername"),
                Password = TestContext.Parameters.Get("FioriPassword")
            };
        }

        public static Credential GetHRBPcredential()
        {
            var user = Environment.GetEnvironmentVariable("FioriHRBPUsername");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("FioriURL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("FioriPassword")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("FioriURL"),
                Username = TestContext.Parameters.Get("FioriHRBPUsername"),
                Password = TestContext.Parameters.Get("FioriPassword")
            };
        }
        public static Credential GetHRPYADMcredential()
        {
            var user = Environment.GetEnvironmentVariable("FioriHRPYADMUsername");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("FioriURL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("FioriPassword")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("FioriURL"),
                Username = TestContext.Parameters.Get("FioriHRPYADMUsername"),
                Password = TestContext.Parameters.Get("FioriPassword")
            };
        }
        public static Credential GetHRADMcredential()
        {

            var user = Environment.GetEnvironmentVariable("FioriHRADMUsername");
            if (user != null)
            {
                return new()
                {
                    Url = Environment.GetEnvironmentVariable("FioriURL"),
                    Username = user,
                    Password = Environment.GetEnvironmentVariable("FioriPassword")
                };
            }

            return new()
            {
                Url = TestContext.Parameters.Get("FioriURL"),
                Username = TestContext.Parameters.Get("FioriHRADMUsername"),
                Password = TestContext.Parameters.Get("FioriPassword")
            };
        }
    }

}

