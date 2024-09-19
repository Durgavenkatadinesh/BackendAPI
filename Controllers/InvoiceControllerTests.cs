using BackendAPI.Controllers;
using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static BackendAPI.Controllers.InvoiceController;

namespace BackendAPI.Tests.Controllers
{
	public class InvoiceControllerTests
	{
		private readonly InvoiceDbContext _context;
		private readonly InvoiceController _controller;

		public InvoiceControllerTests()
		{
			var options = new DbContextOptionsBuilder<InvoiceDbContext>()
				.UseInMemoryDatabase(databaseName: "TestInvoiceDb")
				.Options;

			_context = new InvoiceDbContext(options);

			_controller = new InvoiceController(_context);
		}

		[Fact] 

		public async Task CreateInvoice_RerevurturnsOkResult_WhenValid()
		{
			// Arrange
			var request = new Invoice
			{
				InvoiceId = 1,
				PMC = "PMC Test",
				SiteName = "Test Site",
				VendorName = "Vendor Test",
				PriorBalance = 100.0m
			};

			// Act
			var result = await _controller.CreateInvoice(request);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var response = Assert.IsType<BaseResponseModel<Invoice>>(okResult.Value);
			Assert.Equal(200, response.StatusCode);
			Assert.Equal("Invoice created successfully", response.Message);
		}

		[Fact]
		public async Task GetAllInvoices_ReturnsOkResult_WithData()
		{
			// Arrange: Seed the in-memory database
			_context.Invoices.Add(new Invoice { InvoiceId = 1, PMC = "PMC1", SiteName = "Site1", VendorName = "Vendor1", PriorBalance = 100.0m });
			_context.Invoices.Add(new Invoice { InvoiceId = 2, PMC = "PMC2", SiteName = "Site2", VendorName = "Vendor2", PriorBalance = 200.0m });
			await _context.SaveChangesAsync();

			// Act
			var result = await _controller.GetAllInvoices();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var response = Assert.IsType<BaseResponseModel<List<Invoice>>>(okResult.Value);
			Assert.Equal(200, response.StatusCode);
			Assert.Equal("Invoices retrieved successfully", response.Message);
			Assert.Equal(2, response.Data.Count);  
		}

		// Additional test methods here...
	}
}
