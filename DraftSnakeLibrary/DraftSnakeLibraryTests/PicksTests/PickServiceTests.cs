using System.Collections.Generic;
using DraftSnakeLibrary.Repositories;
using Xunit;
using Moq;
using DraftSnakeLibrary.Models.Picks;
using DraftSnakeLibrary.Services.Picks;

namespace DraftSnakeLibraryTests.PicksTests
{
    public class PickServiceTests
    {
        [Fact]
        public async void RetrievePicksTest_Scenario_ReturnsPicksByDraftId()
        {
            var _picksRepository = new Mock<IModelDynamoDbRepository<Pick>>();
            var expectedPicks = new List<Pick>()
            {
                new Pick()
                {
                    DraftId = "TEST",
                    OverallOrder = 1,
                    PlayerId = "TestId",
                    Selection = "potato chips"
                }
            };

            _picksRepository.Setup(pr =>
                pr.RetrieveByDraftId(It.IsAny<string>()))
                    .ReturnsAsync(expectedPicks);

            var pickService = new PickService(_picksRepository.Object);

            var result = await pickService.RetrieveByDraftId("TEST");

            Assert.Equal(expectedPicks, result);
        }

        [Fact]
        public async void PutTest_Scenario_PutsPick()
        {
            var _pickRepository = new Mock<IModelDynamoDbRepository<Pick>>();

            var pickToPut = new Pick()
            {
                DraftId = "TEST",
                OverallOrder = 3,
                PlayerId = "TestId",
                Selection = "Mashed Potatoes"
            };

            _pickRepository.Setup(pr =>
                pr.Put(It.IsAny<Pick>()))
                    .ReturnsAsync(pickToPut);


            var pickService = new PickService(_pickRepository.Object);

            var result = await pickService.Put(pickToPut);

            _pickRepository.Verify(x => x.Put(pickToPut), Times.Once);
            
        }

    }

}
