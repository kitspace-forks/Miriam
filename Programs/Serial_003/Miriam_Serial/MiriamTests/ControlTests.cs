using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miriam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Miriam.Tests
{
    [TestClass()]
    public class ControlTests
    {
        [TestMethod()]
        public void ReverseColumnOrderTest()
        {
            var fff = new Control();
            string stest = "158,112,91,133,76,129,6,6,6,7,39,16,220,154,114,182,93,154,6,6,6,7,1023,17,61,208,85,217,93,176,6,6,7,17,6,6,82,275,102,253,110,191,7,5,16,16,7,6,119,33,79,29,67,33,7,6,17,16,6,6,89,24,69,23,59,26,6,7,16,16,7,6,65,16,59,19,50,20,6,6,6,7,6,6,45,30,40,25,39,26,6,6,7,6,6,6,";
            string expected = "16,39,7,6,6,6,129,76,133,91,112,158,17,1023,7,6,6,6,154,93,182,114,154,220,6,6,17,7,6,6,176,93,217,85,208,61,6,7,16,16,5,7,191,110,253,102,275,82,6,6,16,17,6,7,33,67,29,79,33,119,6,7,16,16,7,6,26,59,23,69,24,89,6,6,7,6,6,6,20,50,19,59,16,65,6,6,6,7,6,6,26,39,25,40,30,45,";
            Assert.AreEqual(expected, fff.ReverseColumnOrder(stest));
        }

        [TestMethod()]
        public void RearrangeColumnOrderTest()
        {
            var tControl = new Control();

            string[] srows = { "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] scolumns_correct = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            string[] scolumns_rearranged = { "11", "12", "9", "10", "7", "8", "5", "6", "3", "4", "1", "2" };
            string s_correct = "";
            string s_output = "";
            for (int i = 0; i < srows.Length; i++)
                for (int j = 0; j < scolumns_correct.Length; j++)
                {
                    s_output += srows[i] + scolumns_rearranged[j] + ",";
                    s_correct += srows[i] + scolumns_correct[j] + ",";
                }
            Assert.AreEqual(s_correct, tControl.RearrangeColumnOrder(s_output));
        }

        [TestMethod()]
        public void check_versionTest()
        {
            var tControl = new Control();
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            //string version = fvi.FileVersion;
            //Console.WriteLine(version);
           // Console.WriteLine(version.Split('.')[0]);
            Assert.IsTrue(tControl.check_version("2.0.0"));
            Assert.IsTrue(tControl.check_version("2.0.1"));
            Assert.IsFalse(tControl.check_version("1.1.1"));
            Assert.IsFalse(tControl.check_version("2.1.1"));
        }
    }
}