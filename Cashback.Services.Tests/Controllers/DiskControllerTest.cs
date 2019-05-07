using Cashback.Domain.Entities;
using Cashback.Domain.Interfaces;
using Cashback.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Cashback.Services.Tests
{
    public class DiskControllerTest
    {
        [Fact]
        public void Must_Return_Disk_By_Id()
        {
            string expected = "Disco 1";
            var id = Guid.NewGuid();
            Mock<IDiskReadRepositoy> _mockRepo = new Mock<IDiskReadRepositoy>();
            DiskController controller = new DiskController(_mockRepo.Object);
            _mockRepo.Setup(x => x.Get(id)).Returns(new Disk("Disco 1", "Disco description", 10, Domain.Enumerators.DiskGenreEnum.MPB));

            var result = (OkObjectResult)controller.GetDiskById(id).Result;

            Assert.Equal(expected, ((Disk)result.Value).Name);
        }
    }
}
