using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.Net.RequestInterceptors.Data
{
    public class FakeDatabase
    {
        public static bool UserHasAccepted;
        public static bool UserHasAcceptedTest;

        public static bool GetUserHasAccepted()
        {
            return UserHasAccepted;
        }

        public static void SetUserHasAccepted(bool value)
        {
            UserHasAccepted = value;
        }

        internal static void SetUserHasAcceptedTest(bool value)
        {
            UserHasAcceptedTest = value;
        }

        internal static bool GetUserHasAcceptedTest()
        {
            return UserHasAcceptedTest;
        }
    }
}