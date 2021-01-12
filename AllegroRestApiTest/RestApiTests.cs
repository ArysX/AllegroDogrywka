using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using AllegroRestApiTest.Models;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace AllegroRestApiTest
{
    class RestApiTests : Base
    {
        [Test]
        public void TryToConnectWithoutToken()
        {
            var ClientAPI = new RestClient("https://api.allegro.pl");
            var sendRequest = new RestRequest($"/sale/categories", Method.GET);
            sendRequest.AddHeader("accept", "application/vnd.allegro.public.v1+json");
            var response = ClientAPI.Execute(sendRequest);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public void CheckAllMainCategoryName()
        {
            var response = ApiRequest(Method.GET, string.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseObject = new JsonDeserializer().Deserialize<CategoryList>(response);
            var list = new List<string> { "Dom i Ogród", "Dziecko", "Elektronika", "Firma i usługi", "Kolekcje i sztuka", "Kultura i rozrywka",
                "Moda", "Motoryzacja", "Nieruchomości", "Sport i turystyka", "Supermarket", "Uroda", "Zdrowie"};
            Assert.AreEqual(list, responseObject.Categories.Select(x => x.Name).ToList());
        }

        [TestCase("Dom i Ogród", "5")]
        [TestCase("Dziecko", "11763")]
        [TestCase("Elektronika", "42540aec-367a-4e5e-b411-17c09b08e41f")]
        [TestCase("Firma i usługi", "4bd97d96-f0ff-46cb-a52c-2992bd972bb1")]
        [TestCase("Kolekcje i sztuka", "a408e75a-cede-4587-8526-54e9be600d9f")]
        [TestCase("Kultura i rozrywka", "38d588fd-7e9c-4c42-a4ae-6831775eca45")]
        [TestCase("Moda", "ea5b98dd-4b6f-4bd0-8c80-22c2629132d0")]
        [TestCase("Motoryzacja", "3")]
        [TestCase("Nieruchomości", "20782")]
        [TestCase("Sport i turystyka", "3919")]
        [TestCase("Supermarket", "258832")]
        [TestCase("Uroda", "1429")]
        [TestCase("Zdrowie", "121882")]
        public void GetCategoryById(string categoryName, string id)
        {
            var response = ApiRequest(Method.GET, $"/{id}");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseObject = new JsonDeserializer().Deserialize<Category>(response);
            Assert.AreEqual(categoryName, responseObject.Name);
            Assert.IsNotNull(responseObject.Id);
            Assert.IsNotNull(responseObject.Options);
        }

        [Test]
        public void GetCategoryByNotExistId()
        {
            var response = ApiRequest(Method.GET, "/abc$%^&*()_+");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            var responseObject = new JsonDeserializer().Deserialize<ErrorsList>(response);
            Assert.AreEqual("Category 'abc$%^&*()_+' not found", responseObject.Errors.FirstOrDefault().Message);
        }

        [Test]
        public void GetParametersSupportedByCategory()
        {
            var response = ApiRequest(Method.GET, "/709/parameters");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseObject = new JsonDeserializer().Deserialize<CategoryParameterList>(response);
            Assert.IsNotNull(responseObject);

            foreach (var parameter in responseObject.Parameters)
            {
                switch (parameter.Type)
                {
                    case "dictionary":
                        Assert.IsNotNull(parameter.Restrictions.MultipleChoices);
                        Assert.IsNotNull(parameter.Dictionary);
                        break;
                    case "string":
                        Assert.IsNotNull(parameter.Restrictions.AllowedNumberOfValues);
                        Assert.IsTrue(parameter.Restrictions.MinLength >= 0);
                        Assert.IsTrue(parameter.Restrictions.MaxLength >= 0);
                        break;
                    case "float":
                        Assert.IsNotNull(parameter.Restrictions.Precision);
                        Assert.IsNotNull(parameter.Restrictions.Range);
                        Assert.IsTrue(parameter.Restrictions.Min >= 0);
                        Assert.IsTrue(parameter.Restrictions.Max >= 0);
                        break;
                    case "integer":
                        Assert.IsNotNull(parameter.Restrictions.Range);
                        Assert.IsTrue(parameter.Restrictions.Min >= 0);
                        Assert.IsTrue(parameter.Restrictions.Max >= 0);
                        break;
                }

                Assert.IsNotNull(parameter.Id);
                Assert.IsNotNull(parameter.Name);
            }
        }

        [Test]
        public void GetParametersSupportedByCategoryNotExistId()
        {
            var response = ApiRequest(Method.GET, $"/abc$%^&*()_+/parameters");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            var responseObject = new JsonDeserializer().Deserialize<ErrorsList>(response);
            Assert.AreEqual("Category 'abc$%^&*()_+' not found", responseObject.Errors.FirstOrDefault().Message);
        }

        [Test]
        public void GetNotHandledFunction()
        {
            var response = ApiRequest(Method.GET, $"/x/x");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            var responseObject = new JsonDeserializer().Deserialize<ErrorsList>(response);
            Assert.AreEqual("Function is not available. Contact the author of the application.", responseObject.Errors.FirstOrDefault().UserMessage);
        }
    }
}
