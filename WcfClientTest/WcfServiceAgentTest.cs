using WcfClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WcfClient.WcfService;
using Moq;

namespace WcfClientTest
{
    [TestClass()]
    public class WcfClientUnitTest
    {
        [TestMethod()]
        public void MockWcfService()
        {
            string val = "MockedValue";
            string actualRetVal;

            // Initialisation du Mock du service WCF
            Mock<IWcfService> wcfMock = new Mock<IWcfService>();

            // Initialisation de la fonction GetData(int)
            wcfMock.Setup<string>(s => s.GetData(It.IsAny<int>())).Returns(val);

            // Définition de l'objet Mock
            IWcfService wcfMockObject = wcfMock.Object;

            // Initialisation de l'agent avec le Mock du service
            WcfServiceAgent serviceAgent = new WcfServiceAgent(wcfMockObject);

            // Appel de la fonction
            actualRetVal = serviceAgent.HitWCFService();

            // Vérification des résultats
            wcfMock.Verify(s => s.GetData(It.IsAny<int>()), Times.Exactly(1));
            Assert.AreEqual("MockedValue", actualRetVal, "Not same.");
        }

        [TestMethod()]
        public void MockWcfService2()
        {
            string val = "MockedValue";
            string actualRetVal;

            // Initialisation du Mock du service WCF
            Mock<IWcfService> wcfMock = new Mock<IWcfService>();

            // Initialisation de la fonction GetData(int)
            wcfMock.Setup<string>(s => s.GetData(4)).Returns(val);

            // Définition de l'objet Mock
            IWcfService wcfMockObject = wcfMock.Object;

            // Initialisation de l'agent avec le Mock du service
            WcfServiceAgent serviceAgent = new WcfServiceAgent(wcfMockObject);

            // Appel de la fonction
            actualRetVal = serviceAgent.HitWCFService();

            // Vérification des résultats
            wcfMock.Verify(s => s.GetData(4), Times.Exactly(1));
            Assert.AreEqual("MockedValue", actualRetVal, "Not same.");
        }
    }
}
