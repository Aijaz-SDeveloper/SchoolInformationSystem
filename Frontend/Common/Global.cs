using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frontend.Common
{
    class Global
    {
        public static string strConnAWSM;

        private static long sUserEmpId;
        public static string sUserId;
        public static string sCompanyName;
        public static string sNewCustomer;
        public static Int32 nBranchId;
        public static Int32 nLocationId;
     
        public static string sIPAddress;
        

        public static string AWSMConn
        {
            get
            {
                return strConnAWSM;
            }
            set
            {
                strConnAWSM = value;
            }
        }
        public static long UserEmpId
        {
            get
            {
                return sUserEmpId;
            }
            set
            {
                sUserEmpId = value;
            }
        }
        public static string UserId
        {
            get
            {
                return sUserId;
            }
            set
            {
                sUserId = value;
            }
        }
        public static Int32 BranchId
        {
            get
            {
                return nBranchId;
            }
            set
            {
                nBranchId = value;
            }
        }
        public static Int32 LocationId
        {
            get
            {
                return nLocationId;
            }
            set
            {
                nLocationId = value;
            }
        }

        public static string CompanyName
        {
            get
            {
                return sCompanyName;
            }
            set
            {
                sCompanyName = value;
            }
        }
        public static string NewCustomer
        {
            get
            {
                return sNewCustomer;
            }
            set
            {
                sNewCustomer = value;
            }
        }
        public static string IPAddress
        {
            get
            {
                return sIPAddress;
            }
            set
            {
                sIPAddress = value;
            }
        }
    }
}
