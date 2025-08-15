using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using FlightBookingApp.Controllers;
using FlightBookingApp.Models;
using System.Runtime.InteropServices;


namespace FlightBookTesting
{
        public class UnitTest1
        {
            public class FlightControllerTests

            {

                private readonly HttpClient _client;

                public IEnumerable<char> Details { get; private set; }

                public FlightControllerTests()

                {

                    // Initialize HttpClient

                    _client = new HttpClient();

                    _client.BaseAddress = new Uri("http://localhost:7143"); // Adjust the base address accordingly

                }

                [Fact]

                public async Task Index_GivesFlights()

                {

                    // Arrange

                    var controller = new FlightsController();

                    // Act

                    var result = controller.Index();

                    // Assert

                    Assert.NotNull(result);

                }



                [Fact]

                public async Task Create_Redirectsindex()

                {

                    // Arrange

                    var controller = new FlightsController();

                    var flight = new Flight { /* */ };

                    // Act

                    var result = await controller.Create(flight);

                    // Assert

                    var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

                    Assert.Equal("Index", redirectToActionResult.ActionName);

                }

                [Fact]

                public async Task _Details()

                {

                    // Arrange

                    var controller = new FlightsController();

                    // Act

                    var result = await controller.Details(30);

                    // Assert

                    var resultToActionResult = Assert.IsType<ViewResult>(result);

                    Assert.Equal(Details, resultToActionResult.ViewName);

                }

                [Fact]


                public async Task Delete_Returnsafter_delete()
                {
                    // Arrange
                    var controller = new FlightsController();
                    int id = 3; // Provide a valid flight id for testing
                    var httpClient = new HttpClient();

                    // Act
                    var response = await httpClient.GetAsync("http://localhost:7143/api/Flight/" + id);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var expectedStudent = JsonConvert.DeserializeObject<Flight>(apiResponse);
                    var result = await controller.Delete(id) as ViewResult;

                    // Assert
                    Assert.NotNull(result);
                    var model = Assert.IsAssignableFrom<Flight>(result.ViewData.Model);
                    Assert.Equal(expectedStudent.FlightId, model.FlightId);
                    // Add more assertions as needed
                }

                [Fact]
                public void PutFlight_ExistingIdAndValidAnimation_ReturnsRedirectToAction()
                {
                    // Arrange
                    var controller = new FlightsController();

                    // Act
                    var result = controller.Edit(7, new Flight { FlightId = 3, AirLine = "Spice Jet", EconomySeats = 199 }).Result as RedirectToActionResult;

                    // Assert
                    Assert.NotNull(result);
                    Assert.Equal("Index", result.ActionName);
                }

            [Fact]

            public async Task Create_NewRedirectsindex()

            {

                // Arrange

                var controller = new FlightsController();

                var flight = new Flight { /* */ };

                // Act

                var result = await controller.Create(flight);

                // Assert

                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

                Assert.Equal("Index", redirectToActionResult.ActionName);

            }


            [Fact]



            public async Task Delete__Returnsafter_deleting()

            {

                // Arrange

                var controller = new FlightsController();

                int id = 14; // Provide a valid flight id for testing

                var httpClient = new HttpClient();

                // Act

                var response = await httpClient.GetAsync("http://localhost:7143/api/Flight/" + id);

                response.EnsureSuccessStatusCode();

                var apiResponse = await response.Content.ReadAsStringAsync();

                var expectedStudent = JsonConvert.DeserializeObject<Flight>(apiResponse);

                var result = await controller.Delete(id) as ViewResult;

                // Assert

                Assert.NotNull(result);

                var model = Assert.IsAssignableFrom<Flight>(result.ViewData.Model);

                Assert.Equal(expectedStudent.FlightId, model.FlightId);

                // Add more assertions as needed

            }

            [Fact]
            public void PutStudentOF4_ExistingIdAndValidAnimation_ReturnsRedirectToAction()
            {
                // Arrange
                var controller = new FlightsController();

                // Act
                var result = controller.Edit(18, new Flight { FlightId = 4, AirLine = "Indigo", EconomySeats = 199, BusinessSeats = 200, BusinessPrice=20000 }).Result as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
            }


            [Fact]
            public void PutFlight__ExistingIdAndValidAnimation_ReturnsRedirectToAction()
            {
                // Arrange
                var controller = new FlightsController();

                // Act
                var result = controller.Edit(7, new Flight { FlightId = 3, AvailableBusinessSeats=60 , AvailableEconomySeats=220, From="hyderabad" , To="Delhi" }).Result as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
            }

            [Fact]
            public async Task Delete__Returnspost_deleting()

            {

                // Arrange

                var controller = new FlightsController();

                int id = 19; // Provide a valid flight id for testing

                var httpClient = new HttpClient();

                // Act

                var response = await httpClient.GetAsync("http://localhost:7143/api/Flight/" + id);

                response.EnsureSuccessStatusCode();

                var apiResponse = await response.Content.ReadAsStringAsync();

                var expectedStudent = JsonConvert.DeserializeObject<Flight>(apiResponse);

                var result = await controller.Delete(id) as ViewResult;

                // Assert

                Assert.NotNull(result);

                var model = Assert.IsAssignableFrom<Flight>(result.ViewData.Model);

                Assert.Equal(expectedStudent.FlightId, model.FlightId);

                // Add more assertions as needed

            }

            public void Dispose()

                    {

                        _client.Dispose();

                    }


                }


        }
    }