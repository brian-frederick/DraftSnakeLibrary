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
                    Id = 1,
                    PlayerId = "TestId",
                    Selection = "potato chips"
                }
            };

            _picksRepository.Setup(pr =>
                pr.RetrieveByDraftId(It.IsAny<string>()))
                    .ReturnsAsync(expectedPicks);

            var pickService = new PickService(_picksRepository.Object);

            var result = await pickService.Retrieve("TEST");

            Assert.Equal(expectedPicks, result);
        }

        [Fact]
        public async void PutTest_Scenario_PutsPick()
        {
            var _pickRepository = new Mock<IModelDynamoDbRepository<Pick>>();

            var pickToPut = new Pick()
            {
                DraftId = "TEST",
                Id = 3,
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

        [Fact]
        public async void GetNextIdByDraft_Scenario_FirstPickOfDraftIs1()
        {
            var _picksRepository = new Mock<IModelDynamoDbRepository<Pick>>();
            var pickService = new PickService(_picksRepository.Object);

            var emptyPicksList = new List<Pick>();
            _picksRepository
                .Setup(pr => pr.RetrieveByDraftId(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<int?>()))
                .ReturnsAsync(emptyPicksList);

            var nextOverallOrder = await pickService.GetNextIdByDraft("testDraft");

            Assert.Equal(1, nextOverallOrder);

        }

        [Fact]
        public async void GetNextIdByDraft_Scenario_ThirdPickOfDraftIs3()
        {
            var _picksRepository = new Mock<IModelDynamoDbRepository<Pick>>();
            var pickService = new PickService(_picksRepository.Object);

            var picksListWithTopPick = new List<Pick>()
            {
                new Pick(){DraftId = "TestDraft", Id = 20, PlayerId = "testPlayer2", Selection = "Gnocchi"}
            };

            _picksRepository
                .Setup(pr => pr.RetrieveByDraftId(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<int?>()))
                .ReturnsAsync(picksListWithTopPick);

            var nextOverallOrder = await pickService.GetNextIdByDraft("testDraft");

            Assert.Equal(21, nextOverallOrder);

        }


    }

}
