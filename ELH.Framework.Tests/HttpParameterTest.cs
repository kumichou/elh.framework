using System;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using ELH.Framework.Interfaces;
using Moq;
using NUnit.Framework;

namespace ELH.Framework.Tests
{
    [TestFixture]
    public class HttpParameterTest
    {
        private HttpContextBase _testContext;

        [TestFixtureSetUp]
        public void SetupMethods()
        {
        }

        [TestFixtureTearDown]
        public void TearDownMethods()
        {
        }

        [SetUp]
        public void SetupTest()
        {
            NameValueCollection formParams = new NameValueCollection();
            formParams.Add("formkey1", "2");
            formParams.Add("formkey2", "stuff");
            formParams.Add("formkey3", "SingleFamilyHome");
            formParams.Add("formkey4", "0");
            formParams.Add("formkey5", "true");

            NameValueCollection queryParams = new NameValueCollection();
            queryParams.Add("key1", "2");
            queryParams.Add("key2", "stuff");
            queryParams.Add("key3", "SingleFamilyHome");
            queryParams.Add("key4", "0");
            queryParams.Add("key5", "true");

            var context = new Mock<HttpContextBase>();
            var files = new Mock<HttpFileCollectionBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();
            request.Setup(req => req.ApplicationPath).Returns("~/");
            request.Setup(req => req.AppRelativeCurrentExecutionFilePath).Returns("~/");
            request.Setup(req => req.PathInfo).Returns(string.Empty);
            request.Setup(req => req.Form).Returns(formParams);
            request.Setup(req => req.QueryString).Returns(queryParams);
            request.Setup(req => req.Files).Returns(files.Object);
            response.Setup(res => res.ApplyAppPathModifier(It.IsAny<string>())).Returns((string virtualPath) => virtualPath);
            user.Setup(usr => usr.Identity).Returns(identity.Object);
            identity.SetupGet(ident => ident.IsAuthenticated).Returns(true);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);

            _testContext = context.Object;
        }

        [TearDown]
        public void TearDownTest()
        {
            _testContext = null;
        }

        [Test]
        public void GetQueryStringParameterWithIntValue()
        {
            IHttpParameters httpParameters = new HttpParameters(_testContext);
            int value = httpParameters.GetValue<int>("key1");
            Assert.AreEqual(2, value);
        }

        [Test]
        public void GetQueryStringParameterWithStringValue()
        {
            IHttpParameters httpParameters = new HttpParameters(_testContext);
            string value = httpParameters.GetValue<string>("key2");
            Assert.AreEqual("stuff", value);
        }

        [Test]
        public void GetFormEnumParameterWithEnumValue()
        {
            IHttpParameters httpParameters = new HttpParameters(_testContext);
            PropertyType value = httpParameters.GetValue<PropertyType>("formkey3");
            Assert.AreEqual(PropertyType.SingleFamilyHome, value);
        }
    }
}