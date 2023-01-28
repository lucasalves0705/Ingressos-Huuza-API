using Infrastructure.Fabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFabric
{
    [TestClass]
    public class EventTest
    {

        [TestMethod]
        public void EventListTest()
        {

            using (var fabric = new EventFabric())
            {

                var x = fabric.GetInstance().ListInitialEvent();

            }

        }

        [TestMethod]
        public void ListAllEmployers()
        {

            using (var fabric = new UserFabric())
            {

                var x = fabric.GetInstance().ListAllEmployers();

            }

        }

        [TestMethod]
        public void GetEventInitial()
        {

            using (var fabric = new EventFabric())
            {

                var result = fabric.GetInstance().GetEventInitial();

            }

        }

    }
}
