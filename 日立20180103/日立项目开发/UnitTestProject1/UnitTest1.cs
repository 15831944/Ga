using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM2.Service.Code030;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Isdbo003Server _sdbo003Server;
        public UnitTest1(Isdbo003Server _sdbo003Server) {
            this._sdbo003Server = _sdbo003Server;
        }
        [TestMethod]
        public void TestMethod1()
        {
            //this._sdbo003Server.GetpvcnbInfo()
        }
    }
}
